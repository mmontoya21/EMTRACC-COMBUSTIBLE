// ==================== ESTADO GLOBAL ====================
let currentMode = 'view'; // 'view' | 'create' | 'edit'
let selectedId = null;
let selectedCodProp = null;
let currentPage = 1;

// ==================== INICIALIZACION ====================
document.addEventListener('DOMContentLoaded', () => {
    cargarTabla();

    // Botones
    document.getElementById('btnNuevo').addEventListener('click', clickNuevo);
    document.getElementById('btnGuardar').addEventListener('click', clickGuardar);
    document.getElementById('btnEditar').addEventListener('click', clickEditar);
    document.getElementById('btnModificar').addEventListener('click', clickModificar);
    document.getElementById('btnCancelar').addEventListener('click', clickCancelar);
    document.getElementById('btnEliminar').addEventListener('click', clickEliminar);

    // Filtros
    document.getElementById('btnBuscar').addEventListener('click', () => { currentPage = 1; cargarTabla(); });
    document.getElementById('btnLimpiarFiltros').addEventListener('click', limpiarFiltros);

    // Enter en filtros
    document.querySelectorAll('.filtro-input').forEach(el => {
        el.addEventListener('keydown', e => { if (e.key === 'Enter') { currentPage = 1; cargarTabla(); } });
    });

    // Debounce en filtros
    let debounceTimer = null;
    document.querySelectorAll('.filtro-input').forEach(el => {
        el.addEventListener('input', () => {
            clearTimeout(debounceTimer);
            debounceTimer = setTimeout(() => { currentPage = 1; cargarTabla(); }, 400);
        });
    });

    // Uppercase automatico
    document.getElementById('nPropietario').addEventListener('input', function() { this.value = this.value.toUpperCase(); });
    document.getElementById('nEmpresa').addEventListener('input', function() { this.value = this.value.toUpperCase(); });

    setModoVista();
});

// ==================== API HELPER ====================
async function apiGet(action, params = {}) {
    const url = new URL('api/propietario_api.php', window.location.href);
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
    const resp = await fetch('api/propietario_api.php', { method: 'POST', body: formData });
    const data = await resp.json();
    if (!resp.ok) throw new Error(data.error || 'Error del servidor');
    return data;
}

// ==================== CARGAR TABLA ====================
async function cargarTabla() {
    try {
        const params = {
            pagina: currentPage,
            codigo: document.getElementById('filtroCodigo').value,
            propietario: document.getElementById('filtroPropietario').value
        };

        const data = await apiGet('list', params);
        const tbody = document.getElementById('tbodyPropietarios');
        tbody.innerHTML = '';

        if (data.rows.length === 0) {
            tbody.innerHTML = '<tr><td colspan="6" class="text-center text-muted">No se encontraron registros</td></tr>';
        } else {
            data.rows.forEach((row, idx) => {
                const tr = document.createElement('tr');
                tr.dataset.id = row.codigoP;
                tr.className = idx % 2 === 0 ? 'row-white' : 'row-blue';

                if (currentMode === 'view') {
                    tr.style.cursor = 'pointer';
                    tr.addEventListener('click', () => selectRow(row.codigoP));
                }

                tr.innerHTML = `
                    <td><strong>${esc(row.codProp)}</strong></td>
                    <td>${esc(row.nPropietario)}</td>
                    <td class="d-none d-md-table-cell">${esc(row.nEmpresa)}</td>
                    <td class="d-none d-md-table-cell">${esc(row.RTN)}</td>
                    <td class="d-none d-lg-table-cell">${esc(row.tel1)}</td>
                    <td class="d-none d-xl-table-cell">${esc(row.tel2)}</td>
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
        selectedId = data.codigoP;
        selectedCodProp = data.codProp;

        document.getElementById('codigoP').value = data.codigoP;
        document.getElementById('codProp').value = data.codProp || '';
        document.getElementById('nPropietario').value = data.nPropietario || '';
        document.getElementById('nEmpresa').value = data.nEmpresa || '';
        document.getElementById('RTN').value = data.RTN || '';
        document.getElementById('tel1').value = data.tel1 || '';
        document.getElementById('tel2').value = data.tel2 || '';
        document.getElementById('direccion').value = data.direccion || '';
        document.getElementById('correoE').value = data.correoE || '';

        // Resaltar fila
        document.querySelectorAll('#tbodyPropietarios tr').forEach(tr => tr.classList.remove('selected'));
        const row = document.querySelector(`#tbodyPropietarios tr[data-id="${id}"]`);
        if (row) row.classList.add('selected');

        // Habilitar botones
        document.getElementById('btnEditar').disabled = false;
        if (APP.userRole === 'ADMIN' || APP.userRole === 'SUPERADMIN') {
            document.getElementById('btnEliminar').disabled = false;
        }

        // Cargar placas vinculadas
        cargarPlacas(data.codProp);

    } catch (err) {
        alert('Error al cargar registro: ' + err.message);
    }
}

// ==================== CARGAR PLACAS VINCULADAS ====================
async function cargarPlacas(codProp) {
    const card = document.getElementById('placasCard');
    const tbody = document.getElementById('tbodyPlacas');

    if (!codProp) {
        card.style.display = 'none';
        return;
    }

    try {
        const data = await apiGet('placas', { codProp });
        tbody.innerHTML = '';

        if (data.length === 0) {
            tbody.innerHTML = '<tr><td colspan="2" class="text-center text-muted small">Sin placas vinculadas</td></tr>';
        } else {
            data.forEach(item => {
                const tr = document.createElement('tr');
                const activo = parseInt(item.activo) === 1;
                if (!activo) tr.className = 'row-bloqueado';
                tr.innerHTML = `
                    <td><strong>${esc(item.placa)}</strong></td>
                    <td><span class="badge ${activo ? 'bg-success' : 'bg-danger'}">${activo ? 'Activo' : 'Bloqueado'}</span></td>
                `;
                tbody.appendChild(tr);
            });
        }
        card.style.display = 'block';
    } catch (err) {
        console.error('Error cargando placas:', err);
    }
}

// ==================== MODOS ====================
function setModoVista() {
    currentMode = 'view';
    selectedId = null;
    selectedCodProp = null;

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

    document.getElementById('placasCard').style.display = 'none';

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
    document.querySelectorAll('#tbodyPropietarios tr').forEach(tr => {
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
    document.querySelectorAll('#tbodyPropietarios tr').forEach(tr => {
        tr.style.cursor = 'default';
        tr.replaceWith(tr.cloneNode(true));
    });
}

function toggleFormEnabled(enabled) {
    const panel = document.getElementById('formPanel');
    const inputs = panel.querySelectorAll('input, textarea');
    inputs.forEach(el => {
        if (el.id === 'codigoP') return;
        el.disabled = !enabled;
    });

    if (enabled) {
        panel.classList.add('enabled');
    } else {
        panel.classList.remove('enabled');
    }
}

function limpiarFormulario() {
    document.getElementById('codigoP').value = '';
    document.getElementById('codProp').value = '';
    document.getElementById('nPropietario').value = '';
    document.getElementById('nEmpresa').value = '';
    document.getElementById('RTN').value = '';
    document.getElementById('tel1').value = '';
    document.getElementById('tel2').value = '';
    document.getElementById('direccion').value = '';
    document.getElementById('correoE').value = '';
}

// ==================== ACCIONES CRUD ====================
function clickNuevo() {
    limpiarFormulario();
    setModoCrear();
    document.getElementById('codProp').focus();
}

async function clickGuardar() {
    const codProp = document.getElementById('codProp').value.trim();
    const nPropietario = document.getElementById('nPropietario').value.trim();

    if (!codProp) { alert('El codigo de propietario es obligatorio'); document.getElementById('codProp').focus(); return; }
    if (!nPropietario) { alert('El nombre del propietario es obligatorio'); document.getElementById('nPropietario').focus(); return; }

    if (!confirm('Desea guardar el propietario?')) return;

    try {
        const body = getFormData();
        const result = await apiPost('create', body);
        alert(result.message);
        setModoVista();
    } catch (err) {
        alert('Error: ' + err.message);
    }
}

function clickEditar() {
    if (!selectedId) return;
    setModoEditar();
    document.getElementById('codProp').focus();
}

async function clickModificar() {
    const codProp = document.getElementById('codProp').value.trim();
    const nPropietario = document.getElementById('nPropietario').value.trim();

    if (!codProp) { alert('El codigo de propietario es obligatorio'); document.getElementById('codProp').focus(); return; }
    if (!nPropietario) { alert('El nombre del propietario es obligatorio'); document.getElementById('nPropietario').focus(); return; }

    if (!confirm('Desea modificar el propietario?')) return;

    try {
        const body = getFormData();
        body.id = selectedId;
        const result = await apiPost('update', body);
        alert(result.message);
        setModoVista();
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

    if (!confirm('Esta seguro que desea ELIMINAR este propietario?')) return;

    try {
        const result = await apiPost('delete', { id: selectedId });
        alert(result.message);
        setModoVista();
    } catch (err) {
        alert('Error: ' + err.message);
    }
}

function clickCancelar() {
    setModoVista();
}

// ==================== HELPERS ====================
function getFormData() {
    return {
        codProp: document.getElementById('codProp').value,
        nPropietario: document.getElementById('nPropietario').value,
        nEmpresa: document.getElementById('nEmpresa').value,
        RTN: document.getElementById('RTN').value,
        tel1: document.getElementById('tel1').value,
        tel2: document.getElementById('tel2').value,
        direccion: document.getElementById('direccion').value,
        correoE: document.getElementById('correoE').value
    };
}

function esc(str) {
    if (str == null) return '';
    const div = document.createElement('div');
    div.textContent = str;
    return div.innerHTML;
}

function limpiarFiltros() {
    document.getElementById('filtroCodigo').value = '';
    document.getElementById('filtroPropietario').value = '';
    currentPage = 1;
    cargarTabla();
}
