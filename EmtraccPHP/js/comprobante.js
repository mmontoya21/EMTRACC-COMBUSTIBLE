// ==================== ESTADO GLOBAL ====================
let currentMode = 'view'; // 'view' | 'create' | 'edit'
let selectedId = null;
let selectedAnulado = false;
let currentPage = 1;

// ==================== INICIALIZACION ====================
document.addEventListener('DOMContentLoaded', () => {
    cargarTabla();
    cargarDespachadores();
    refreshTankLevel();
    setupAutocomplete('placaCbz', 'autoPlaca', 'placa');
    setupAutocomplete('ruta', 'autoRuta', null);
    setupAutocomplete('nombCond', 'autoConductor', null);
    setupCodiPropLookup();

    // Calculo en tiempo real
    document.getElementById('galDesp').addEventListener('input', calcularTotal);
    document.getElementById('valor').addEventListener('input', calcularTotal);

    // Filtros
    document.getElementById('btnBuscar').addEventListener('click', () => { currentPage = 1; cargarTabla(); });
    document.getElementById('btnLimpiarFiltros').addEventListener('click', limpiarFiltros);

    // Botones de accion
    document.getElementById('btnNuevo').addEventListener('click', clickNuevo);
    document.getElementById('btnGuardar').addEventListener('click', clickGuardar);
    document.getElementById('btnEditar').addEventListener('click', clickEditar);
    document.getElementById('btnModificar').addEventListener('click', clickModificar);
    document.getElementById('btnCancelar').addEventListener('click', clickCancelar);
    document.getElementById('btnEliminar').addEventListener('click', clickEliminar);
    document.getElementById('btnAnular').addEventListener('click', clickAnular);
    document.getElementById('btnImprimir').addEventListener('click', clickImprimir);
    document.getElementById('btnImprimirDoc').addEventListener('click', clickImprimirDoc);

    // Enter en filtros dispara busqueda
    document.querySelectorAll('.filtro-input').forEach(el => {
        el.addEventListener('keydown', e => { if (e.key === 'Enter') { currentPage = 1; cargarTabla(); } });
    });

    setModoVista();
});

// ==================== API HELPER ====================
async function apiGet(action, params = {}) {
    const url = new URL('api/comprobante_api.php', window.location.href);
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
    const resp = await fetch('api/comprobante_api.php', { method: 'POST', body: formData });
    const data = await resp.json();
    if (!resp.ok) throw new Error(data.error || 'Error del servidor');
    return data;
}

// ==================== CARGAR TABLA ====================
async function cargarTabla() {
    try {
        const params = {
            pagina: currentPage,
            placa: document.getElementById('filtroPlaca').value,
            boleta: document.getElementById('filtroBoleta').value,
            fechaDesde: document.getElementById('filtroFechaDesde').value,
            fechaHasta: document.getElementById('filtroFechaHasta').value,
            despachador: document.getElementById('filtroDespachador').value
        };

        const data = await apiGet('list', params);
        const tbody = document.getElementById('tbodyComprobantes');
        tbody.innerHTML = '';

        data.rows.forEach((row, idx) => {
            const tr = document.createElement('tr');
            tr.dataset.id = row.idcprbnt;
            tr.dataset.anulado = row.anulado;

            if (parseInt(row.anulado) === 1) {
                tr.className = 'row-anulado';
            } else {
                tr.className = idx % 2 === 0 ? 'row-white' : 'row-blue';
            }

            if (currentMode === 'view') {
                tr.style.cursor = 'pointer';
                tr.addEventListener('click', () => selectRow(row.idcprbnt));
            }

            tr.innerHTML = `
                <td>${esc(row.nCompro)}</td>
                <td>${esc(row.nBoleta)}</td>
                <td>${esc(row.fechaFmt)}</td>
                <td class="d-none d-md-table-cell">${esc(row.nombDesp)}</td>
                <td class="d-none d-lg-table-cell">${esc(row.propCbz)}</td>
                <td>${esc(row.placaCbz)}</td>
                <td class="d-none d-md-table-cell">${esc(row.periodo)}</td>
                <td class="d-none d-md-table-cell">${esc(row.semana)}</td>
                <td class="d-none d-xl-table-cell">${esc(row.ruta)}</td>
                <td class="text-end">${number(row.galDesp)}</td>
                <td class="text-end d-none d-lg-table-cell">${number(row.total)}</td>
                <td><span class="badge ${parseInt(row.anulado) === 1 ? 'bg-danger' : 'bg-success'}">${parseInt(row.anulado) === 1 ? 'ANULADO' : 'ACTIVO'}</span></td>
            `;
            tbody.appendChild(tr);
        });

        // Resumen
        document.getElementById('resumenTotal').textContent = data.total;
        document.getElementById('resumenAnulados').textContent = data.anulados;
        document.getElementById('resumenGalones').textContent = number(data.totalGalones);
        document.getElementById('resumenMonto').textContent = number(data.totalMonto);

        // Paginacion
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
        selectedId = data.idcprbnt;
        selectedAnulado = parseInt(data.anulado) === 1;

        // Llenar formulario
        document.getElementById('idcprbnt').value = data.idcprbnt;
        document.getElementById('nCompro').value = data.nCompro || '';
        document.getElementById('nBoleta').value = data.nBoleta || '';
        document.getElementById('galDesp').value = data.galDesp || '';
        document.getElementById('valor').value = data.valor || '';
        document.getElementById('placaCbz').value = data.placaCbz || '';
        document.getElementById('nConte').value = data.nConte || '';
        document.getElementById('propCbz').value = data.propCbz || '';
        document.getElementById('codiProp').value = data.codiProp || '';
        document.getElementById('ruta').value = data.ruta || '';
        document.getElementById('nombCond').value = data.nombCond || '';
        document.getElementById('nombDesp').value = data.nombDesp || '';
        document.getElementById('fecha').value = data.fecha ? data.fecha.substring(0, 10) : '';
        document.getElementById('periodo').value = data.periodo || '';
        document.getElementById('semana').value = data.semana || '';
        document.getElementById('proxSem').value = data.proxSem || 'NO';

        calcularTotal();

        // Resaltar fila
        document.querySelectorAll('#tbodyComprobantes tr').forEach(tr => tr.classList.remove('selected'));
        const row = document.querySelector(`#tbodyComprobantes tr[data-id="${id}"]`);
        if (row) row.classList.add('selected');

        // Habilitar botones segun rol
        document.getElementById('btnEditar').disabled = false;
        document.getElementById('btnImprimir').disabled = false;
        document.getElementById('btnImprimirDoc').disabled = false;

        if (APP.userRole === 'ADMIN' || APP.userRole === 'SUPERADMIN') {
            document.getElementById('btnEliminar').disabled = false;
        }

        const btnAnular = document.getElementById('btnAnular');
        btnAnular.disabled = false;
        if (selectedAnulado) {
            btnAnular.innerHTML = '<i class="bi bi-arrow-counterclockwise"></i> Desanular';
            btnAnular.className = 'btn btn-outline-warning btn-sm';
            if (APP.userRole !== 'ADMIN' && APP.userRole !== 'SUPERADMIN') {
                btnAnular.disabled = true;
            }
        } else {
            btnAnular.innerHTML = '<i class="bi bi-slash-circle"></i> Anular';
            btnAnular.className = 'btn btn-warning btn-sm';
        }

        // Mostrar estado anulado
        const estadoLabel = document.getElementById('estadoLabel');
        if (selectedAnulado) {
            estadoLabel.textContent = 'ANULADO';
            estadoLabel.className = 'badge bg-danger ms-2';
            estadoLabel.style.display = 'inline';
        } else {
            estadoLabel.style.display = 'none';
        }

    } catch (err) {
        alert('Error al cargar registro: ' + err.message);
    }
}

// ==================== MODO VISTA / CREAR / EDITAR ====================
function setModoVista() {
    currentMode = 'view';
    selectedId = null;
    selectedAnulado = false;

    toggleFormEnabled(false);
    limpiarFormulario();

    document.getElementById('btnNuevo').disabled = false;
    document.getElementById('btnNuevo').style.display = '';
    document.getElementById('btnGuardar').style.display = 'none';
    document.getElementById('btnEditar').disabled = true;
    document.getElementById('btnEditar').style.display = '';
    document.getElementById('btnModificar').style.display = 'none';
    document.getElementById('btnCancelar').disabled = true;
    document.getElementById('btnEliminar').disabled = true;
    document.getElementById('btnAnular').disabled = true;
    document.getElementById('btnAnular').innerHTML = '<i class="bi bi-slash-circle"></i> Anular';
    document.getElementById('btnImprimir').disabled = true;
    document.getElementById('btnImprimirDoc').disabled = true;
    document.getElementById('estadoLabel').style.display = 'none';

    // Reactivar click en filas
    cargarTabla();
}

function setModoCrear() {
    currentMode = 'create';
    toggleFormEnabled(true);

    document.getElementById('nCompro').readOnly = true;

    document.getElementById('btnNuevo').disabled = true;
    document.getElementById('btnGuardar').style.display = '';
    document.getElementById('btnEditar').style.display = 'none';
    document.getElementById('btnModificar').style.display = 'none';
    document.getElementById('btnCancelar').disabled = false;
    document.getElementById('btnEliminar').disabled = true;
    document.getElementById('btnAnular').disabled = true;
    document.getElementById('btnImprimir').disabled = true;
    document.getElementById('btnImprimirDoc').disabled = true;

    // Deshabilitar click en filas
    document.querySelectorAll('#tbodyComprobantes tr').forEach(tr => {
        tr.style.cursor = 'default';
        tr.replaceWith(tr.cloneNode(true));
    });
}

function setModoEditar() {
    currentMode = 'edit';
    toggleFormEnabled(true);

    document.getElementById('nCompro').readOnly = true;

    document.getElementById('btnNuevo').disabled = true;
    document.getElementById('btnGuardar').style.display = 'none';
    document.getElementById('btnEditar').style.display = 'none';
    document.getElementById('btnModificar').style.display = '';
    document.getElementById('btnCancelar').disabled = false;
    document.getElementById('btnEliminar').disabled = true;
    document.getElementById('btnAnular').disabled = true;
    document.getElementById('btnImprimir').disabled = true;
    document.getElementById('btnImprimirDoc').disabled = true;

    // Deshabilitar click en filas
    document.querySelectorAll('#tbodyComprobantes tr').forEach(tr => {
        tr.style.cursor = 'default';
        tr.replaceWith(tr.cloneNode(true));
    });
}

function toggleFormEnabled(enabled) {
    const panel = document.getElementById('formPanel');
    const inputs = panel.querySelectorAll('input, select');
    inputs.forEach(el => {
        if (el.id === 'nCompro' || el.id === 'propCbz' || el.id === 'idcprbnt') {
            el.readOnly = true;
        } else if (el.id === 'nombDesp' || el.id === 'periodo' || el.id === 'semana') {
            // Solo ADMIN puede editar estos
            if (APP.userRole === 'ADMIN' || APP.userRole === 'SUPERADMIN') {
                el.readOnly = !enabled;
                el.disabled = !enabled;
            } else {
                el.readOnly = true;
                el.disabled = false;
            }
        } else {
            el.readOnly = !enabled;
            el.disabled = !enabled;
        }
    });

    if (enabled) {
        panel.classList.add('enabled');
    } else {
        panel.classList.remove('enabled');
    }
}

function limpiarFormulario() {
    document.getElementById('idcprbnt').value = '';
    document.getElementById('nCompro').value = '';
    document.getElementById('nBoleta').value = '';
    document.getElementById('galDesp').value = '';
    document.getElementById('valor').value = '';
    document.getElementById('placaCbz').value = '';
    document.getElementById('nConte').value = '';
    document.getElementById('propCbz').value = '';
    document.getElementById('codiProp').value = '';
    document.getElementById('ruta').value = '';
    document.getElementById('nombCond').value = '';
    document.getElementById('nombDesp').value = '';
    document.getElementById('fecha').value = '';
    document.getElementById('periodo').value = '';
    document.getElementById('semana').value = '';
    document.getElementById('proxSem').value = 'NO';
    document.getElementById('totalDisplay').textContent = 'L. 0.00';
}

// ==================== ACCIONES CRUD ====================
async function clickNuevo() {
    limpiarFormulario();
    setModoCrear();

    try {
        // Obtener numero y precio en paralelo
        const [numData, priceData] = await Promise.all([
            apiGet('nextNumber'),
            apiGet('currentPrice')
        ]);

        document.getElementById('nCompro').value = numData.numero;
        document.getElementById('valor').value = priceData.precio;
        document.getElementById('nombDesp').value = APP.userName;
        document.getElementById('periodo').value = APP.periodo;
        document.getElementById('semana').value = APP.semana;
        document.getElementById('fecha').value = new Date().toISOString().substring(0, 10);

        document.getElementById('galDesp').focus();
    } catch (err) {
        alert('Error al preparar nuevo comprobante: ' + err.message);
    }
}

async function clickGuardar() {
    const placaCbz = document.getElementById('placaCbz').value.trim();
    if (!placaCbz) { alert('La placa es obligatoria'); document.getElementById('placaCbz').focus(); return; }

    const confirmado = confirm('Desea guardar el comprobante?');
    if (!confirmado) return;

    try {
        const body = getFormData();
        const result = await apiPost('create', body);
        alert(result.message);

        // Abrir ventanas de impresion (como en VB.NET: imprime ambos automaticamente)
        const printConfirm = confirm('Desea imprimir el comprobante y documento?');
        if (printConfirm) {
            window.open('comprobante_print.php?id=' + result.id, '_blank', 'width=400,height=600');
            window.open('documento_print.php?id=' + result.id, '_blank', 'width=450,height=650');
        }

        setModoVista();
        refreshTankLevel();
    } catch (err) {
        alert('Error: ' + err.message);
    }
}

async function clickEditar() {
    if (!selectedId) return;
    setModoEditar();
    document.getElementById('galDesp').focus();
}

async function clickModificar() {
    const placaCbz = document.getElementById('placaCbz').value.trim();
    if (!placaCbz) { alert('La placa es obligatoria'); document.getElementById('placaCbz').focus(); return; }

    const confirmado = confirm('Desea modificar el comprobante?');
    if (!confirmado) return;

    try {
        const body = getFormData();
        body.id = selectedId;
        const result = await apiPost('update', body);
        alert(result.message);
        setModoVista();
        refreshTankLevel();
    } catch (err) {
        alert('Error: ' + err.message);
    }
}

async function clickEliminar() {
    if (!selectedId) return;
    if (APP.userRole !== 'ADMIN' && APP.userRole !== 'SUPERADMIN') {
        alert('Solo ADMIN puede eliminar registros');
        return;
    }

    const confirmado = confirm('Esta seguro que desea ELIMINAR permanentemente este comprobante?');
    if (!confirmado) return;

    try {
        const result = await apiPost('delete', { id: selectedId });
        alert(result.message);
        setModoVista();
        refreshTankLevel();
    } catch (err) {
        alert('Error: ' + err.message);
    }
}

async function clickAnular() {
    if (!selectedId) return;

    if (selectedAnulado) {
        // Desanular
        if (APP.userRole !== 'ADMIN' && APP.userRole !== 'SUPERADMIN') {
            alert('Solo ADMIN puede desanular registros');
            return;
        }
        if (!confirm('Desea DESANULAR este comprobante?')) return;

        try {
            const result = await apiPost('unannul', { id: selectedId });
            alert(result.message);
            setModoVista();
            refreshTankLevel();
        } catch (err) {
            alert('Error: ' + err.message);
        }
    } else {
        // Anular
        if (!confirm('Desea ANULAR este comprobante? Los galones y total se pondran en cero.')) return;

        try {
            const result = await apiPost('annul', { id: selectedId });
            alert(result.message);
            setModoVista();
            refreshTankLevel();
        } catch (err) {
            alert('Error: ' + err.message);
        }
    }
}

function clickCancelar() {
    setModoVista();
}

function clickImprimir() {
    if (!selectedId) return;
    window.open('comprobante_print.php?id=' + selectedId, '_blank', 'width=400,height=600');
}

function clickImprimirDoc() {
    if (!selectedId) return;
    window.open('documento_print.php?id=' + selectedId, '_blank', 'width=450,height=650');
}

// ==================== HELPERS ====================
function getFormData() {
    return {
        nCompro: document.getElementById('nCompro').value,
        nBoleta: document.getElementById('nBoleta').value,
        galDesp: document.getElementById('galDesp').value || '0',
        valor: document.getElementById('valor').value || '0',
        placaCbz: document.getElementById('placaCbz').value,
        nConte: document.getElementById('nConte').value,
        propCbz: document.getElementById('propCbz').value,
        ruta: document.getElementById('ruta').value,
        nombCond: document.getElementById('nombCond').value,
        nombDesp: document.getElementById('nombDesp').value,
        fecha: document.getElementById('fecha').value,
        periodo: document.getElementById('periodo').value,
        semana: document.getElementById('semana').value,
        proxSem: document.getElementById('proxSem').value,
        codiProp: document.getElementById('codiProp').value
    };
}

function calcularTotal() {
    const galDesp = parseFloat(document.getElementById('galDesp').value) || 0;
    const valor = parseFloat(document.getElementById('valor').value) || 0;
    const total = galDesp * valor;
    document.getElementById('totalDisplay').textContent = 'L. ' + total.toFixed(2);
}

function esc(str) {
    if (str == null) return '';
    const div = document.createElement('div');
    div.textContent = str;
    return div.innerHTML;
}

function number(val) {
    return parseFloat(val || 0).toFixed(2);
}

// ==================== TANK LEVEL ====================
async function refreshTankLevel() {
    try {
        const data = await apiGet('tankLevel');
        const badge = document.getElementById('tankBadge');
        badge.textContent = data.texto;

        badge.className = 'badge';
        if (data.porcentaje > 50) badge.classList.add('bg-success');
        else if (data.porcentaje > 25) badge.classList.add('bg-warning', 'text-dark');
        else badge.classList.add('bg-danger');
    } catch (err) {
        console.error('Error cargando nivel tanque:', err);
    }
}

// ==================== CARGAR DESPACHADORES ====================
async function cargarDespachadores() {
    try {
        const items = await apiGet('despachadores');
        const sel = document.getElementById('filtroDespachador');
        items.forEach(name => {
            const opt = document.createElement('option');
            opt.value = name;
            opt.textContent = name;
            sel.appendChild(opt);
        });
    } catch (err) {
        console.error('Error cargando despachadores:', err);
    }
}

// ==================== FILTROS ====================
function limpiarFiltros() {
    document.getElementById('filtroPlaca').value = '';
    document.getElementById('filtroBoleta').value = '';
    document.getElementById('filtroFechaDesde').value = '';
    document.getElementById('filtroFechaHasta').value = '';
    document.getElementById('filtroDespachador').value = '';
    currentPage = 1;
    cargarTabla();
}

// ==================== AUTOCOMPLETE ====================
function setupAutocomplete(inputId, action, fieldName) {
    const input = document.getElementById(inputId);
    if (!input) return;

    let debounceTimer = null;
    const container = document.createElement('div');
    container.className = 'autocomplete-dropdown';
    container.style.display = 'none';
    input.parentElement.style.position = 'relative';
    input.parentElement.appendChild(container);

    input.addEventListener('input', () => {
        clearTimeout(debounceTimer);
        const val = input.value.trim();
        if (val.length < 2) { container.style.display = 'none'; return; }

        debounceTimer = setTimeout(async () => {
            try {
                const data = await apiGet(action, { q: val });
                container.innerHTML = '';

                if (data.length === 0) { container.style.display = 'none'; return; }

                data.forEach(item => {
                    const div = document.createElement('div');
                    div.className = 'item';

                    if (action === 'autoPlaca') {
                        div.textContent = item.placa + ' - ' + (item.propietario || '');
                        div.addEventListener('click', () => {
                            input.value = item.placa;
                            document.getElementById('propCbz').value = item.propietario || '';
                            document.getElementById('codiProp').value = item.codigoPro || '';
                            container.style.display = 'none';
                        });
                    } else {
                        const text = typeof item === 'string' ? item : (item[fieldName] || item);
                        div.textContent = text;
                        div.addEventListener('click', () => {
                            input.value = text;
                            container.style.display = 'none';
                        });
                    }
                    container.appendChild(div);
                });
                container.style.display = 'block';
            } catch (err) {
                container.style.display = 'none';
            }
        }, 300);
    });

    // Cerrar dropdown al hacer click fuera
    document.addEventListener('click', e => {
        if (!input.contains(e.target) && !container.contains(e.target)) {
            container.style.display = 'none';
        }
    });

    // Para placa: al perder foco hacer lookup exacto
    if (action === 'autoPlaca') {
        input.addEventListener('change', async () => {
            const val = input.value.trim();
            if (val === '') { document.getElementById('propCbz').value = ''; document.getElementById('codiProp').value = ''; return; }
            try {
                const data = await apiGet('lookupPlaca', { placa: val });
                document.getElementById('propCbz').value = data.propCbz || '';
                document.getElementById('codiProp').value = data.codiProp || '';
            } catch (err) { /* silenciar */ }
        });
    }
}

// Lookup inverso: codigo propietario -> lista de placas
function setupCodiPropLookup() {
    const input = document.getElementById('codiProp');
    if (!input) return;

    let debounceTimer = null;
    const listBox = document.getElementById('placasList');

    input.addEventListener('input', () => {
        clearTimeout(debounceTimer);
        const val = input.value.trim();
        if (val === '') { listBox.innerHTML = ''; listBox.style.display = 'none'; return; }

        debounceTimer = setTimeout(async () => {
            try {
                const data = await apiGet('lookupCodigo', { codigo: val });
                listBox.innerHTML = '';
                if (data.length === 0) { listBox.style.display = 'none'; return; }

                data.forEach(item => {
                    const div = document.createElement('div');
                    div.className = 'item';
                    div.textContent = item.placa;
                    div.addEventListener('click', () => {
                        document.getElementById('placaCbz').value = item.placa;
                        document.getElementById('propCbz').value = item.propietario || '';
                        listBox.style.display = 'none';
                    });
                    listBox.appendChild(div);
                });
                listBox.style.display = 'block';
            } catch (err) {
                listBox.style.display = 'none';
            }
        }, 300);
    });
}
