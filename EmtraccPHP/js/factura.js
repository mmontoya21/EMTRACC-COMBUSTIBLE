// ==================== ESTADO GLOBAL ====================
let currentMode = 'view'; // 'view' | 'create' | 'edit'
let selectedId = null;
let currentPage = 1;

// ==================== INICIALIZACION ====================
document.addEventListener('DOMContentLoaded', () => {
    cargarTabla();

    // Calculo en tiempo real
    document.querySelectorAll('.calc-input').forEach(el => {
        el.addEventListener('input', calcularTotales);
    });

    // Buscar propietario por codigo
    document.getElementById('btnBuscarProp').addEventListener('click', buscarPropietario);
    document.getElementById('codBusq').addEventListener('keydown', e => {
        if (e.key === 'Enter') buscarPropietario();
    });

    // Filtros
    document.getElementById('btnBuscar').addEventListener('click', () => { currentPage = 1; cargarTabla(); });
    document.getElementById('btnLimpiarFiltros').addEventListener('click', limpiarFiltros);

    // Botones CRUD
    document.getElementById('btnNuevo').addEventListener('click', clickNuevo);
    document.getElementById('btnGuardar').addEventListener('click', clickGuardar);
    document.getElementById('btnEditar').addEventListener('click', clickEditar);
    document.getElementById('btnModificar').addEventListener('click', clickModificar);
    document.getElementById('btnCancelar').addEventListener('click', clickCancelar);
    document.getElementById('btnEliminar').addEventListener('click', clickEliminar);

    // Enter en filtros
    document.querySelectorAll('.filtro-input').forEach(el => {
        el.addEventListener('keydown', e => { if (e.key === 'Enter') { currentPage = 1; cargarTabla(); } });
    });

    // Reporte
    document.getElementById('chkUsarFechaR').addEventListener('change', function() {
        document.getElementById('fechaDesdeR').disabled = !this.checked;
        document.getElementById('fechaHastaR').disabled = !this.checked;
    });
    document.getElementById('btnBuscarR').addEventListener('click', cargarReporte);
    document.getElementById('btnLimpiarR').addEventListener('click', limpiarReporte);
    document.getElementById('btnExportarR').addEventListener('click', exportarReporteExcel);

    // Tab reporte: cargar al abrir
    document.getElementById('tab-reporte').addEventListener('shown.bs.tab', () => {
        cargarReporte();
    });

    setModoVista();
});

// ==================== API HELPERS ====================
async function apiGet(action, params = {}) {
    const url = new URL('api/factura_api.php', window.location.href);
    url.searchParams.set('action', action);
    Object.entries(params).forEach(([k, v]) => url.searchParams.set(k, v));
    const resp = await fetch(url);
    const data = await resp.json();
    if (!resp.ok) throw new Error(data.error || 'Error del servidor');
    return data;
}

async function apiPost(action, body = {}) {
    const formData = new FormData();
    formData.append('action', action);
    Object.entries(body).forEach(([k, v]) => formData.append(k, v));
    const resp = await fetch('api/factura_api.php', { method: 'POST', body: formData });
    const data = await resp.json();
    if (!resp.ok) throw new Error(data.error || 'Error del servidor');
    return data;
}

// ==================== HELPERS ====================
function esc(val) { return val == null ? '' : String(val).replace(/&/g,'&amp;').replace(/</g,'&lt;').replace(/>/g,'&gt;'); }
function number(val) { return parseFloat(val || 0).toFixed(2); }

// ==================== CARGAR TABLA FACTURAS ====================
async function cargarTabla() {
    try {
        const params = {
            pagina: currentPage,
            codProp: document.getElementById('filtroCodProp').value,
            fechaDesde: document.getElementById('filtroFechaDesde').value,
            fechaHasta: document.getElementById('filtroFechaHasta').value
        };

        const data = await apiGet('list', params);
        const tbody = document.getElementById('tbodyFacturas');
        tbody.innerHTML = '';

        data.rows.forEach((row, idx) => {
            const tr = document.createElement('tr');
            tr.dataset.id = row.idFactura;
            tr.className = idx % 2 === 0 ? 'row-white' : 'row-blue';

            if (currentMode === 'view') {
                tr.style.cursor = 'pointer';
                tr.addEventListener('click', () => selectRow(row.idFactura));
            }

            tr.innerHTML = `
                <td>${esc(row.codProp)}</td>
                <td>${esc(row.empresa)}</td>
                <td>${esc(row.propietario)}</td>
                <td>${esc(row.nFactura)}</td>
                <td>${esc(row.fechaFmt)}</td>
            `;
            tbody.appendChild(tr);
        });

        document.getElementById('resumenTotal').textContent = data.total;
        renderPaginacion(data.pagina, data.totalPaginas);
    } catch (err) {
        console.error('Error cargando tabla:', err);
    }
}

function renderPaginacion(pagina, totalPaginas) {
    const nav = document.getElementById('paginacion');
    if (totalPaginas <= 1) { nav.innerHTML = ''; return; }

    let html = '<ul class="pagination pagination-sm mb-0">';
    if (pagina > 1) html += `<li class="page-item"><a class="page-link" href="#" data-page="${pagina-1}">&laquo;</a></li>`;

    const start = Math.max(1, pagina - 2);
    const end = Math.min(totalPaginas, pagina + 2);
    for (let i = start; i <= end; i++) {
        html += `<li class="page-item ${i === pagina ? 'active' : ''}"><a class="page-link" href="#" data-page="${i}">${i}</a></li>`;
    }

    if (pagina < totalPaginas) html += `<li class="page-item"><a class="page-link" href="#" data-page="${pagina+1}">&raquo;</a></li>`;
    html += '</ul>';
    nav.innerHTML = html;

    nav.querySelectorAll('a[data-page]').forEach(a => {
        a.addEventListener('click', e => {
            e.preventDefault();
            currentPage = parseInt(a.dataset.page);
            cargarTabla();
        });
    });
}

// ==================== SELECCIONAR FILA ====================
async function selectRow(id) {
    if (currentMode !== 'view') return;

    try {
        const data = await apiGet('get', { id });
        selectedId = data.idFactura;

        document.getElementById('idFactura').value = data.idFactura;
        document.getElementById('nFactura').value = data.nFactura || '';
        document.getElementById('fecha').value = data.fecha ? data.fecha.substring(0, 10) : '';
        document.getElementById('propietario').value = data.propietario || '';
        document.getElementById('empresa').value = data.empresa || '';
        document.getElementById('rtn').value = data.rtn || '';
        document.getElementById('codProp').value = data.codProp || '';
        document.getElementById('codBusq').value = data.codProp || '';
        document.getElementById('tipoPag').value = data.tipoPag || 'CONTADO';
        document.getElementById('facCantidad').value = number(data.facCantidad);
        document.getElementById('facExe').value = number(data.facExe);
        document.getElementById('facTotal').value = number(data.facTotal);
        document.getElementById('comentario').value = data.comentario || '';
        document.getElementById('comentario2').value = data.comentario2 || '';
        document.getElementById('cantd1').value = data.cantd1 || '';
        document.getElementById('cantd2').value = data.cantd2 || '';
        document.getElementById('descrip1').value = data.descrip1 || '';
        document.getElementById('descrip2').value = data.descrip2 || '';
        document.getElementById('total1').value = number(data.total1);
        document.getElementById('total2').value = number(data.total2);
        document.getElementById('perMes').value = data.perMes || '';
        document.getElementById('perSem').value = data.PerSem || data.perSem || '';
        document.getElementById('preUni1').value = data.preUni1 || '';
        document.getElementById('preUni2').value = data.preUni2 || '';

        calcularLetras();

        // Resaltar fila
        document.querySelectorAll('#tbodyFacturas tr').forEach(tr => tr.classList.remove('selected'));
        const row = document.querySelector(`#tbodyFacturas tr[data-id="${id}"]`);
        if (row) row.classList.add('selected');

        // Habilitar botones
        document.getElementById('btnEditar').disabled = false;
        document.getElementById('btnEliminar').disabled = false;

    } catch (err) {
        alert('Error: ' + err.message);
    }
}

// ==================== BUSCAR PROPIETARIO ====================
async function buscarPropietario() {
    const codigo = document.getElementById('codBusq').value.trim();
    if (!codigo) return;

    try {
        const data = await apiGet('lookupPropietario', { codigo });
        if (data.nPropietario) {
            document.getElementById('empresa').value = data.nEmpresa || '';
            document.getElementById('propietario').value = data.nPropietario || '';
            document.getElementById('rtn').value = data.RTN || '';
            document.getElementById('codProp').value = data.codProp || '';
        } else {
            alert('Propietario no encontrado');
        }
    } catch (err) {
        alert('Error: ' + err.message);
    }
}

// ==================== CALCULOS ====================
function calcularTotales() {
    const cant1 = parseFloat(document.getElementById('cantd1').value) || 0;
    const cant2 = parseFloat(document.getElementById('cantd2').value) || 0;
    const preu1 = parseFloat(document.getElementById('preUni1').value) || 0;
    const preu2 = parseFloat(document.getElementById('preUni2').value) || 0;

    const tot1 = cant1 * preu1;
    const tot2 = cant2 * preu2;
    const facTotal = tot1 + tot2;
    const facCantidad = cant1 + cant2;

    document.getElementById('total1').value = tot1.toFixed(2);
    document.getElementById('total2').value = tot2.toFixed(2);
    document.getElementById('facTotal').value = facTotal.toFixed(2);
    document.getElementById('facCantidad').value = facCantidad.toFixed(2);
    document.getElementById('facExe').value = facTotal.toFixed(2);

    calcularLetras();
}

// ==================== NUMERO A LETRAS ====================
function calcularLetras() {
    const total = parseFloat(document.getElementById('facTotal').value) || 0;
    document.getElementById('pLetras').value = numeroALetras(total);
}

function numeroALetras(num) {
    const unidades = ['', 'UN', 'DOS', 'TRES', 'CUATRO', 'CINCO', 'SEIS', 'SIETE', 'OCHO', 'NUEVE'];
    const decenas = ['', 'DIEZ', 'VEINTE', 'TREINTA', 'CUARENTA', 'CINCUENTA', 'SESENTA', 'SETENTA', 'OCHENTA', 'NOVENTA'];
    const especiales = ['DIEZ', 'ONCE', 'DOCE', 'TRECE', 'CATORCE', 'QUINCE'];
    const centenas = ['', 'CIENTO', 'DOSCIENTOS', 'TRESCIENTOS', 'CUATROCIENTOS', 'QUINIENTOS', 'SEISCIENTOS', 'SETECIENTOS', 'OCHOCIENTOS', 'NOVECIENTOS'];

    if (num === 0) return 'CERO LEMPIRAS';

    const parteEntera = Math.floor(num);
    const centavos = Math.round((num - parteEntera) * 100);

    function convertirGrupo(n) {
        if (n === 0) return '';
        if (n === 100) return 'CIEN';

        let resultado = '';
        if (n >= 100) {
            resultado += centenas[Math.floor(n / 100)] + ' ';
            n = n % 100;
        }
        if (n >= 10 && n <= 15) {
            resultado += especiales[n - 10];
            return resultado.trim();
        }
        if (n >= 16 && n <= 19) {
            resultado += 'DIECI' + unidades[n - 10];
            return resultado.trim();
        }
        if (n >= 21 && n <= 29) {
            resultado += 'VEINTI' + unidades[n - 20];
            return resultado.trim();
        }
        if (n >= 10) {
            resultado += decenas[Math.floor(n / 10)];
            n = n % 10;
            if (n > 0) resultado += ' Y ';
        }
        if (n > 0) {
            resultado += unidades[n];
        }
        return resultado.trim();
    }

    let texto = '';
    if (parteEntera >= 1000000) {
        const millones = Math.floor(parteEntera / 1000000);
        texto += (millones === 1 ? 'UN MILLON' : convertirGrupo(millones) + ' MILLONES') + ' ';
    }
    const resto = parteEntera % 1000000;
    if (resto >= 1000) {
        const miles = Math.floor(resto / 1000);
        texto += (miles === 1 ? 'MIL' : convertirGrupo(miles) + ' MIL') + ' ';
    }
    const unidad = resto % 1000;
    if (unidad > 0) {
        texto += convertirGrupo(unidad);
    }

    texto = texto.trim() + ' LEMPIRAS';
    if (centavos > 0) {
        texto += ' CON ' + (centavos < 10 ? '0' : '') + centavos + '/100';
    }

    return texto;
}

// ==================== MODOS ====================
function setModoVista() {
    currentMode = 'view';
    setFormDisabled(true);

    document.getElementById('btnNuevo').style.display = '';
    document.getElementById('btnGuardar').style.display = 'none';
    document.getElementById('btnEditar').style.display = '';
    document.getElementById('btnModificar').style.display = 'none';
    document.getElementById('btnCancelar').disabled = true;
    document.getElementById('btnEliminar').disabled = true;
    document.getElementById('btnEditar').disabled = !selectedId;

    document.getElementById('codBusq').disabled = true;
    document.getElementById('btnBuscarProp').disabled = true;
}

function setFormDisabled(disabled) {
    const fields = ['tipoPag', 'fecha', 'perMes', 'perSem', 'cantd1', 'cantd2', 'descrip1', 'descrip2', 'preUni1', 'preUni2', 'comentario', 'comentario2'];
    fields.forEach(id => {
        document.getElementById(id).disabled = disabled;
    });
}

// ==================== ACCIONES CRUD ====================
async function clickNuevo() {
    try {
        const data = await apiGet('nextNumber');
        limpiarForm();
        document.getElementById('nFactura').value = data.numero;
        document.getElementById('fecha').value = new Date().toISOString().substring(0, 10);
        document.getElementById('tipoPag').value = 'CONTADO';
        document.getElementById('descrip1').value = 'Diessel';
        document.getElementById('descrip2').value = 'Diessel';
        document.getElementById('cantd1').value = '0';
        document.getElementById('cantd2').value = '0';
        document.getElementById('preUni1').value = '0';
        document.getElementById('preUni2').value = '0';

        currentMode = 'create';
        selectedId = null;
        setFormDisabled(false);
        document.getElementById('codBusq').disabled = false;
        document.getElementById('btnBuscarProp').disabled = false;

        document.getElementById('btnNuevo').style.display = 'none';
        document.getElementById('btnGuardar').style.display = '';
        document.getElementById('btnEditar').style.display = 'none';
        document.getElementById('btnModificar').style.display = 'none';
        document.getElementById('btnCancelar').disabled = false;
        document.getElementById('btnEliminar').disabled = true;

        calcularTotales();
        document.getElementById('codBusq').focus();
    } catch (err) {
        alert('Error: ' + err.message);
    }
}

async function clickGuardar() {
    const body = getFormData();

    try {
        await apiPost('create', body);
        alert('Factura guardada exitosamente');
        setModoVista();
        cargarTabla();
    } catch (err) {
        alert('Error: ' + err.message);
    }
}

function clickEditar() {
    if (!selectedId) return;
    currentMode = 'edit';
    setFormDisabled(false);
    document.getElementById('codBusq').disabled = false;
    document.getElementById('btnBuscarProp').disabled = false;

    document.getElementById('btnNuevo').style.display = 'none';
    document.getElementById('btnGuardar').style.display = 'none';
    document.getElementById('btnEditar').style.display = 'none';
    document.getElementById('btnModificar').style.display = '';
    document.getElementById('btnCancelar').disabled = false;
    document.getElementById('btnEliminar').disabled = true;
}

async function clickModificar() {
    if (!selectedId) return;
    const body = getFormData();
    body.id = selectedId;

    try {
        await apiPost('update', body);
        alert('Factura modificada exitosamente');
        setModoVista();
        cargarTabla();
    } catch (err) {
        alert('Error: ' + err.message);
    }
}

function clickCancelar() {
    limpiarForm();
    selectedId = null;
    setModoVista();
}

async function clickEliminar() {
    if (!selectedId) return;
    if (!confirm('¿Desea eliminar esta factura?')) return;

    try {
        await apiPost('delete', { id: selectedId });
        alert('Factura eliminada');
        limpiarForm();
        selectedId = null;
        setModoVista();
        cargarTabla();
    } catch (err) {
        alert('Error: ' + err.message);
    }
}

function getFormData() {
    return {
        nFactura: document.getElementById('nFactura').value,
        fecha: document.getElementById('fecha').value,
        propietario: document.getElementById('propietario').value,
        empresa: document.getElementById('empresa').value,
        rtn: document.getElementById('rtn').value,
        tipoPag: document.getElementById('tipoPag').value,
        facCantidad: document.getElementById('facCantidad').value,
        facExe: document.getElementById('facExe').value,
        facTotal: document.getElementById('facTotal').value,
        comentario: document.getElementById('comentario').value,
        comentario2: document.getElementById('comentario2').value,
        cantd1: document.getElementById('cantd1').value || '0',
        cantd2: document.getElementById('cantd2').value || '0',
        descrip1: document.getElementById('descrip1').value,
        descrip2: document.getElementById('descrip2').value,
        total1: document.getElementById('total1').value || '0',
        total2: document.getElementById('total2').value || '0',
        perMes: document.getElementById('perMes').value,
        perSem: document.getElementById('perSem').value,
        preUni1: document.getElementById('preUni1').value || '0',
        preUni2: document.getElementById('preUni2').value || '0',
        codProp: document.getElementById('codProp').value
    };
}

function limpiarForm() {
    const fields = ['idFactura', 'nFactura', 'fecha', 'propietario', 'empresa', 'rtn', 'codProp', 'codBusq',
        'facCantidad', 'facExe', 'facTotal', 'comentario', 'comentario2',
        'cantd1', 'cantd2', 'descrip1', 'descrip2', 'total1', 'total2',
        'perMes', 'perSem', 'preUni1', 'preUni2', 'pLetras'];
    fields.forEach(id => {
        const el = document.getElementById(id);
        if (el) el.value = '';
    });
    document.getElementById('tipoPag').value = 'CONTADO';
}

function limpiarFiltros() {
    document.getElementById('filtroCodProp').value = '';
    document.getElementById('filtroFechaDesde').value = '';
    document.getElementById('filtroFechaHasta').value = '';
    currentPage = 1;
    cargarTabla();
}

// ==================== REPORTE ====================
let reporteData = [];

async function cargarReporte() {
    try {
        const params = {
            usarFecha: document.getElementById('chkUsarFechaR').checked ? '1' : '0',
            fechaDesde: document.getElementById('fechaDesdeR').value,
            fechaHasta: document.getElementById('fechaHastaR').value,
            codCliente: document.getElementById('codClienteR').value,
            placa: document.getElementById('placaR').value,
            boleta: document.getElementById('boletaR').value
        };

        const data = await apiGet('reportData', params);
        reporteData = data.rows;
        document.getElementById('lblTotalR').textContent = data.total;
        renderReporte(data.rows);

    } catch (err) {
        console.error('Error cargando reporte:', err);
    }
}

function renderReporte(rows) {
    const tbody = document.getElementById('tbodyReporte');
    tbody.innerHTML = '';

    if (rows.length === 0) {
        tbody.innerHTML = '<tr><td colspan="10" class="text-center text-muted">Sin datos</td></tr>';
        return;
    }

    // Group by codCliente and add subtotals
    const coloresSuaves = ['#fff3e0', '#e3f2fd', '#e8f5e9'];
    const coloresIntensos = ['#ffe0b2', '#bbdefb', '#c8e6c9'];
    const coloresTextoSub = ['#503c00', '#002850', '#003c14'];

    let currentCliente = '';
    let sumaGalones = 0, sumaTotal = 0;
    let granGalones = 0, granTotal = 0;
    let grupoIndex = -1;
    let grupoRows = [];

    // Build grouped data
    for (let i = 0; i < rows.length; i++) {
        const row = rows[i];
        const cliente = (row.codCliente || '').trim();

        if (cliente !== currentCliente && currentCliente !== '') {
            // Add subtotal row
            grupoRows.push({
                type: 'subtotal',
                codCliente: 'SUBTOTAL: ' + currentCliente,
                galones: sumaGalones,
                total: sumaTotal,
                grupo: grupoIndex % 3
            });
            sumaGalones = 0;
            sumaTotal = 0;
        }

        if (cliente !== currentCliente) {
            grupoIndex++;
        }

        const gal = parseFloat(row.galones) || 0;
        const tot = parseFloat(row.total) || 0;
        sumaGalones += gal;
        sumaTotal += tot;
        granGalones += gal;
        granTotal += tot;
        currentCliente = cliente;

        grupoRows.push({
            type: 'data',
            row: row,
            grupo: grupoIndex % 3
        });
    }

    // Last subtotal
    if (currentCliente !== '') {
        grupoRows.push({
            type: 'subtotal',
            codCliente: 'SUBTOTAL: ' + currentCliente,
            galones: sumaGalones,
            total: sumaTotal,
            grupo: grupoIndex % 3
        });
    }

    // Gran total
    grupoRows.push({
        type: 'grandtotal',
        galones: granGalones,
        total: granTotal
    });

    // Render
    grupoRows.forEach(item => {
        const tr = document.createElement('tr');

        if (item.type === 'grandtotal') {
            tr.style.backgroundColor = '#ffb74d';
            tr.style.fontWeight = 'bold';
            tr.innerHTML = `
                <td colspan="3">GRAN TOTAL</td>
                <td class="text-end">${number(item.galones)}</td>
                <td class="text-end">${number(item.total)}</td>
                <td colspan="5"></td>
            `;
        } else if (item.type === 'subtotal') {
            tr.style.backgroundColor = coloresIntensos[item.grupo];
            tr.style.color = coloresTextoSub[item.grupo];
            tr.style.fontWeight = 'bold';
            tr.innerHTML = `
                <td colspan="3"></td>
                <td class="text-end">${number(item.galones)}</td>
                <td class="text-end">${number(item.total)}</td>
                <td>${esc(item.codCliente)}</td>
                <td colspan="4"></td>
            `;
        } else {
            const r = item.row;
            tr.style.backgroundColor = coloresSuaves[item.grupo];
            tr.style.cursor = 'pointer';
            tr.addEventListener('click', () => onReporteRowClick(r));
            tr.innerHTML = `
                <td>${esc(r.fecha)}</td>
                <td>${esc(r.placa)}</td>
                <td>${esc(r.contenedor)}</td>
                <td class="text-end">${number(r.galones)}</td>
                <td class="text-end">${number(r.total)}</td>
                <td>${esc(r.codCliente)}</td>
                <td>${esc(r.boleta)}</td>
                <td class="text-center">${esc(r.periodo)}</td>
                <td class="text-center">${esc(r.semana)}</td>
                <td class="text-end">${number(r.valor)}</td>
            `;
        }

        tbody.appendChild(tr);
    });
}

async function onReporteRowClick(row) {
    const codCliente = (row.codCliente || '').trim();
    if (!codCliente) return;

    try {
        // Lookup propietario
        const propData = await apiGet('lookupPropietario', { codigo: codCliente });
        if (propData.nPropietario) {
            document.getElementById('codBusq').value = propData.codProp || '';
            document.getElementById('codProp').value = propData.codProp || '';
            document.getElementById('propietario').value = propData.nPropietario || '';
            document.getElementById('empresa').value = propData.nEmpresa || '';
            document.getElementById('rtn').value = propData.RTN || '';
        }

        // Fill periodo/semana
        document.getElementById('perMes').value = row.periodo || '';
        document.getElementById('perSem').value = row.semana || '';

        // Fill cantd1 and preUni1 from galones/total
        document.getElementById('cantd1').value = row.galones || '';
        document.getElementById('preUni1').value = row.total || '';

        // Build comentario2 with all rows from same codCliente
        const lines = reporteData
            .filter(r => (r.codCliente || '').trim() === codCliente)
            .map(r => {
                const gal = parseFloat(r.galones) || 0;
                const tot = parseFloat(r.total) || 0;
                const val = parseFloat(r.valor) || 0;
                return `${r.fecha}\t${(r.placa || '').padEnd(10)}\tBol:${(r.boleta || '').padEnd(8)}\tGal:${gal.toFixed(2).padStart(8)}\tTot:${tot.toFixed(2).padStart(10)}\tVal:${val.toFixed(2).padStart(7)}`;
            });
        document.getElementById('comentario2').value = lines.join('\n');

        // Switch to factura tab
        const tabEl = document.getElementById('tab-factura');
        const tab = new bootstrap.Tab(tabEl);
        tab.show();

    } catch (err) {
        alert('Error: ' + err.message);
    }
}

function limpiarReporte() {
    document.getElementById('chkUsarFechaR').checked = false;
    document.getElementById('fechaDesdeR').value = '';
    document.getElementById('fechaHastaR').value = '';
    document.getElementById('fechaDesdeR').disabled = true;
    document.getElementById('fechaHastaR').disabled = true;
    document.getElementById('codClienteR').value = '';
    document.getElementById('placaR').value = '';
    document.getElementById('boletaR').value = '';
    cargarReporte();
}

// ==================== EXPORTAR EXCEL ====================
function exportarReporteExcel() {
    if (reporteData.length === 0) {
        alert('No hay datos para exportar');
        return;
    }

    // Build CSV content
    const headers = ['Fecha', 'Placa', 'Contenedor', 'Galones', 'Total', 'Cod. Cliente', 'Boletas', 'Periodo', 'Semana', 'Valor'];
    let csv = '\uFEFF'; // BOM for UTF-8
    csv += headers.join(',') + '\n';

    reporteData.forEach(r => {
        csv += [
            '"' + (r.fecha || '') + '"',
            '"' + (r.placa || '') + '"',
            '"' + (r.contenedor || '') + '"',
            number(r.galones),
            number(r.total),
            '"' + (r.codCliente || '') + '"',
            '"' + (r.boleta || '') + '"',
            '"' + (r.periodo || '') + '"',
            '"' + (r.semana || '') + '"',
            number(r.valor)
        ].join(',') + '\n';
    });

    const blob = new Blob([csv], { type: 'text/csv;charset=utf-8;' });
    const url = URL.createObjectURL(blob);
    const a = document.createElement('a');
    a.href = url;
    a.download = 'Reporte_Facturas_' + new Date().toISOString().substring(0, 10) + '.csv';
    a.click();
    URL.revokeObjectURL(url);
}
