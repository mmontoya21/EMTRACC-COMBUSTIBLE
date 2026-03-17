// ==================== ESTADO GLOBAL ====================
let currentMode = 'view'; // 'view' | 'create' | 'edit'
let selectedId = null;
let currentPage = 1;

// ==================== INICIALIZACION ====================
document.addEventListener('DOMContentLoaded', () => {
    cargarTabla();
    cargarPrecioActual();

    // Botones toolbar
    document.getElementById('btnNuevo').addEventListener('click', clickNuevo);
    document.getElementById('btnGuardar').addEventListener('click', clickGuardar);
    document.getElementById('btnEditar').addEventListener('click', clickEditar);
    document.getElementById('btnModificar').addEventListener('click', clickModificar);
    document.getElementById('btnCancelar').addEventListener('click', clickCancelar);
    document.getElementById('btnEliminar').addEventListener('click', clickEliminar);

    // Filtros
    document.getElementById('btnBuscar').addEventListener('click', () => { currentPage = 1; cargarTabla(); });
    document.getElementById('btnLimpiarFiltros').addEventListener('click', limpiarFiltros);

    setModoVista();
});

// ==================== API HELPER ====================
async function apiGet(action, params = {}) {
    const url = new URL('api/valorComb_api.php', window.location.href);
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
    const resp = await fetch('api/valorComb_api.php', { method: 'POST', body: formData });
    const data = await resp.json();
    if (!resp.ok) throw new Error(data.error || 'Error del servidor');
    return data;
}

// ==================== PRECIO ACTUAL ====================
async function cargarPrecioActual() {
    try {
        const data = await apiGet('precioActual');
        const badge = document.getElementById('precioActualBadge');
        if (data.precio !== null) {
            badge.textContent = 'L. ' + Number(data.precio).toFixed(2) + ' (' + data.fecha + ')';
            badge.className = 'badge bg-success ms-2';
        } else {
            badge.textContent = 'Sin precio';
            badge.className = 'badge bg-secondary ms-2';
        }
    } catch (err) {
        console.error('Error cargando precio actual:', err);
    }
}

// ==================== CARGAR TABLA ====================
async function cargarTabla() {
    try {
        const params = {
            pagina: currentPage,
            fecha_desde: document.getElementById('filtroFechaDesde').value,
            fecha_hasta: document.getElementById('filtroFechaHasta').value
        };

        const data = await apiGet('list', params);
        const tbody = document.getElementById('tbodyValorComb');
        tbody.innerHTML = '';

        if (data.rows.length === 0) {
            tbody.innerHTML = '<tr><td colspan="5" class="text-center text-muted">No se encontraron registros</td></tr>';
        } else {
            data.rows.forEach((row, idx) => {
                const tr = document.createElement('tr');
                tr.dataset.id = row.valorId;
                tr.className = idx % 2 === 0 ? 'row-white' : 'row-blue';

                if (currentMode === 'view') {
                    tr.style.cursor = 'pointer';
                    tr.addEventListener('click', () => selectRow(row.valorId));
                }

                const estadoBadge = row.activo == 1
                    ? '<span class="badge bg-success">Activo</span>'
                    : '<span class="badge bg-secondary">Inactivo</span>';

                tr.innerHTML = `
                    <td>${esc(row.valorId)}</td>
                    <td class="text-end">${Number(row.valorCombustible).toFixed(2)}</td>
                    <td>${esc(row.fechaFmt)}</td>
                    <td>${esc(row.descripcion)}</td>
                    <td class="text-center">${estadoBadge}</td>
                `;
                tbody.appendChild(tr);
            });
        }

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
        selectedId = data.valorId;

        document.getElementById('valorId').value = data.valorId;
        document.getElementById('valorCombustible').value = data.valorCombustible || '';
        document.getElementById('fecha').value = data.fecha || '';
        document.getElementById('descripcion').value = data.descripcion || '';
        document.getElementById('activo').checked = data.activo == 1;

        // Resaltar fila
        document.querySelectorAll('#tbodyValorComb tr').forEach(tr => tr.classList.remove('selected'));
        const row = document.querySelector(`#tbodyValorComb tr[data-id="${id}"]`);
        if (row) row.classList.add('selected');

        // Habilitar botones
        document.getElementById('btnEditar').disabled = false;
        if (APP.userRole === 'ADMIN' || APP.userRole === 'SUPERADMIN') {
            document.getElementById('btnEliminar').disabled = false;
        }

    } catch (err) {
        alert('Error al cargar registro: ' + err.message);
    }
}

// ==================== MODOS ====================
function setModoVista() {
    currentMode = 'view';
    selectedId = null;

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

    cargarTabla();
}

function setModoCrear() {
    currentMode = 'create';
    toggleFormEnabled(true);

    document.getElementById('btnNuevo').disabled = true;
    document.getElementById('btnGuardar').style.display = '';
    document.getElementById('btnEditar').style.display = 'none';
    document.getElementById('btnModificar').style.display = 'none';
    document.getElementById('btnCancelar').disabled = false;
    document.getElementById('btnEliminar').disabled = true;

    // Deshabilitar click en filas
    document.querySelectorAll('#tbodyValorComb tr').forEach(tr => {
        tr.style.cursor = 'default';
        tr.replaceWith(tr.cloneNode(true));
    });
}

function setModoEditar() {
    currentMode = 'edit';
    toggleFormEnabled(true);

    document.getElementById('btnNuevo').disabled = true;
    document.getElementById('btnGuardar').style.display = 'none';
    document.getElementById('btnEditar').style.display = 'none';
    document.getElementById('btnModificar').style.display = '';
    document.getElementById('btnCancelar').disabled = false;
    document.getElementById('btnEliminar').disabled = true;

    // Deshabilitar click en filas
    document.querySelectorAll('#tbodyValorComb tr').forEach(tr => {
        tr.style.cursor = 'default';
        tr.replaceWith(tr.cloneNode(true));
    });
}

function toggleFormEnabled(enabled) {
    const panel = document.getElementById('formPanel');
    panel.querySelectorAll('input:not(#valorId), textarea').forEach(el => {
        el.disabled = !enabled;
    });

    if (enabled) {
        panel.classList.add('enabled');
    } else {
        panel.classList.remove('enabled');
    }
}

function limpiarFormulario() {
    document.getElementById('valorId').value = '';
    document.getElementById('valorCombustible').value = '';
    document.getElementById('fecha').value = '';
    document.getElementById('descripcion').value = '';
    document.getElementById('activo').checked = true;
}

// ==================== ACCIONES CRUD ====================
function clickNuevo() {
    limpiarFormulario();
    setModoCrear();
    document.getElementById('valorCombustible').focus();
}

async function clickGuardar() {
    const valorCombustible = document.getElementById('valorCombustible').value.trim();
    const fecha = document.getElementById('fecha').value;

    if (!valorCombustible) { alert('El precio es obligatorio'); document.getElementById('valorCombustible').focus(); return; }
    if (isNaN(valorCombustible)) { alert('El precio debe ser un valor numerico'); document.getElementById('valorCombustible').focus(); return; }
    if (!fecha) { alert('La fecha es obligatoria'); document.getElementById('fecha').focus(); return; }

    if (!confirm('¿Desea guardar el precio?')) return;

    try {
        const body = {
            valorCombustible,
            fecha,
            descripcion: document.getElementById('descripcion').value,
            activo: document.getElementById('activo').checked ? 1 : 0
        };
        const result = await apiPost('create', body);
        alert(result.message);
        setModoVista();
        cargarPrecioActual();
    } catch (err) {
        alert('Error: ' + err.message);
    }
}

function clickEditar() {
    if (!selectedId) return;
    setModoEditar();
    document.getElementById('valorCombustible').focus();
}

async function clickModificar() {
    const valorCombustible = document.getElementById('valorCombustible').value.trim();
    const fecha = document.getElementById('fecha').value;

    if (!valorCombustible) { alert('El precio es obligatorio'); document.getElementById('valorCombustible').focus(); return; }
    if (isNaN(valorCombustible)) { alert('El precio debe ser un valor numerico'); document.getElementById('valorCombustible').focus(); return; }
    if (!fecha) { alert('La fecha es obligatoria'); document.getElementById('fecha').focus(); return; }

    if (!confirm('¿Desea modificar el precio?')) return;

    try {
        const body = {
            id: selectedId,
            valorCombustible,
            fecha,
            descripcion: document.getElementById('descripcion').value,
            activo: document.getElementById('activo').checked ? 1 : 0
        };
        const result = await apiPost('update', body);
        alert(result.message);
        setModoVista();
        cargarPrecioActual();
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

    if (!confirm('¿Esta seguro que desea ELIMINAR este precio?')) return;

    try {
        const result = await apiPost('delete', { id: selectedId });
        alert(result.message);
        setModoVista();
        cargarPrecioActual();
    } catch (err) {
        alert('Error: ' + err.message);
    }
}

function clickCancelar() {
    setModoVista();
}

// ==================== HELPERS ====================
function esc(str) {
    if (str == null) return '';
    const div = document.createElement('div');
    div.textContent = str;
    return div.innerHTML;
}

function limpiarFiltros() {
    document.getElementById('filtroFechaDesde').value = '';
    document.getElementById('filtroFechaHasta').value = '';
    currentPage = 1;
    cargarTabla();
}
