// ==================== ESTADO GLOBAL ====================
let currentMode = 'view'; // 'view' | 'create' | 'edit'
let selectedId = null;
let currentPage = 1;

// ==================== CONSTANTES DE PERMISOS ====================
const MODULO_KEYS = [
    'camiones', 'placa', 'transportistas', 'tanque', 'empresa', 'acceso',
    'medicion', 'comprobante', 'factura', 'propietario', 'consumo', 'reporte',
    'valorComb', 'rutas', 'reporteFact'
];

const DEFAULTS_UNCHECK = {
    SUPERADMIN: [],
    ADMIN: ['empresa', 'acceso'],
    USUARIO: ['empresa', 'acceso', 'factura'],
    TEST: ['acceso']
};

// ==================== INICIALIZACION ====================
document.addEventListener('DOMContentLoaded', () => {
    cargarTabla();

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
    document.getElementById('nombre').addEventListener('input', function() { this.value = this.value.toUpperCase(); });
    document.getElementById('apellido').addEventListener('input', function() { this.value = this.value.toUpperCase(); });

    // Toggle contraseña
    document.getElementById('btnToggleClave').addEventListener('click', () => {
        const inp = document.getElementById('clave');
        const icon = document.querySelector('#btnToggleClave i');
        if (inp.type === 'password') {
            inp.type = 'text';
            icon.className = 'bi bi-eye-slash';
        } else {
            inp.type = 'password';
            icon.className = 'bi bi-eye';
        }
    });

    // Cambio de tipo → defaults de permisos
    document.getElementById('tipo').addEventListener('change', () => {
        if (currentMode !== 'view') {
            aplicarDefaultsPermisos();
        }
    });

    setModoVista();
});

// ==================== API HELPER ====================
async function apiGet(action, params = {}) {
    const url = new URL('api/acceso_api.php', window.location.href);
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
    const resp = await fetch('api/acceso_api.php', { method: 'POST', body: formData });
    const data = await resp.json();
    if (!resp.ok) throw new Error(data.error || 'Error del servidor');
    return data;
}

// ==================== PERMISOS ====================
function aplicarDefaultsPermisos() {
    const tipo = document.getElementById('tipo').value;
    const uncheck = DEFAULTS_UNCHECK[tipo] || [];
    document.querySelectorAll('.chk-permiso').forEach(chk => {
        chk.checked = !uncheck.includes(chk.value);
    });
}

function getPermisosString() {
    return Array.from(document.querySelectorAll('.chk-permiso:checked'))
        .map(chk => chk.value).join(',');
}

function cargarPermisos(permisos) {
    if (!permisos || permisos === '') {
        document.querySelectorAll('.chk-permiso').forEach(chk => chk.checked = true);
        return;
    }
    const lista = permisos.split(',').map(s => s.trim());
    document.querySelectorAll('.chk-permiso').forEach(chk => {
        chk.checked = lista.includes(chk.value);
    });
}

// ==================== CARGAR TABLA ====================
async function cargarTabla() {
    try {
        const params = {
            pagina: currentPage,
            usuario: document.getElementById('filtroUsuario').value,
            nombre: document.getElementById('filtroNombre').value
        };

        const data = await apiGet('list', params);
        const tbody = document.getElementById('tbodyAccesos');
        tbody.innerHTML = '';

        if (data.rows.length === 0) {
            tbody.innerHTML = '<tr><td colspan="7" class="text-center text-muted">No se encontraron registros</td></tr>';
        } else {
            data.rows.forEach((row, idx) => {
                const tr = document.createElement('tr');
                tr.dataset.id = row.id;
                tr.className = idx % 2 === 0 ? 'row-white' : 'row-blue';

                if (currentMode === 'view') {
                    tr.style.cursor = 'pointer';
                    tr.addEventListener('click', () => selectRow(row.id));
                }

                const statusClass = row.status === 'ACTIVO' ? 'bg-success' : 'bg-danger';
                const fecha = row.fecha ? new Date(row.fecha + 'T00:00:00').toLocaleDateString('es-HN') : '';

                tr.innerHTML = `
                    <td>${esc(row.id)}</td>
                    <td><strong>${esc(row.nombre)}</strong></td>
                    <td>${esc(row.apellido)}</td>
                    <td>${esc(row.usuario)}</td>
                    <td class="d-none d-md-table-cell">${esc(row.tipo)}</td>
                    <td class="d-none d-md-table-cell"><span class="badge ${statusClass}">${esc(row.status)}</span></td>
                    <td class="d-none d-lg-table-cell">${fecha}</td>
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
        selectedId = data.id;

        document.getElementById('accesoId').value = data.id;
        document.getElementById('nombre').value = data.nombre || '';
        document.getElementById('apellido').value = data.apellido || '';
        document.getElementById('usuario').value = data.usuario || '';
        document.getElementById('clave').value = '';
        document.getElementById('clave').type = 'password';
        document.querySelector('#btnToggleClave i').className = 'bi bi-eye';
        document.getElementById('tipo').value = data.tipo || '';
        document.getElementById('status').value = data.status || '';
        document.getElementById('fecha').value = data.fecha || '';

        // Cargar permisos
        cargarPermisos(data.permisos);

        // Resaltar fila
        document.querySelectorAll('#tbodyAccesos tr').forEach(tr => tr.classList.remove('selected'));
        const row = document.querySelector(`#tbodyAccesos tr[data-id="${id}"]`);
        if (row) row.classList.add('selected');

        // Habilitar botones
        document.getElementById('btnEditar').disabled = false;
        document.getElementById('btnEliminar').disabled = false;

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
    document.querySelectorAll('#tbodyAccesos tr').forEach(tr => {
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
    document.querySelectorAll('#tbodyAccesos tr').forEach(tr => {
        tr.style.cursor = 'default';
        tr.replaceWith(tr.cloneNode(true));
    });
}

function toggleFormEnabled(enabled) {
    const panel = document.getElementById('formPanel');
    panel.querySelectorAll('input:not(#accesoId), select').forEach(el => {
        el.disabled = !enabled;
    });

    // Toggle checkboxes
    document.querySelectorAll('.chk-permiso').forEach(chk => {
        chk.disabled = !enabled;
    });

    // Toggle boton ojo
    document.getElementById('btnToggleClave').disabled = !enabled;

    if (enabled) {
        panel.classList.add('enabled');
    } else {
        panel.classList.remove('enabled');
    }
}

function limpiarFormulario() {
    document.getElementById('accesoId').value = '';
    document.getElementById('nombre').value = '';
    document.getElementById('apellido').value = '';
    document.getElementById('usuario').value = '';
    document.getElementById('clave').value = '';
    document.getElementById('clave').type = 'password';
    document.querySelector('#btnToggleClave i').className = 'bi bi-eye';
    document.getElementById('tipo').value = '';
    document.getElementById('status').value = 'ACTIVO';
    document.getElementById('fecha').value = '';

    // Todos los checkboxes marcados por defecto
    document.querySelectorAll('.chk-permiso').forEach(chk => chk.checked = true);
}

// ==================== ACCIONES CRUD ====================
function clickNuevo() {
    limpiarFormulario();
    setModoCrear();
    // Fecha de hoy
    document.getElementById('fecha').value = new Date().toISOString().split('T')[0];
    document.getElementById('nombre').focus();
}

async function clickGuardar() {
    const nombre = document.getElementById('nombre').value.trim();
    const apellido = document.getElementById('apellido').value.trim();
    const usuario = document.getElementById('usuario').value.trim();
    const clave = document.getElementById('clave').value;
    const tipo = document.getElementById('tipo').value;
    const status = document.getElementById('status').value;
    const fecha = document.getElementById('fecha').value;

    if (!nombre) { alert('El nombre es obligatorio'); document.getElementById('nombre').focus(); return; }
    if (!apellido) { alert('El apellido es obligatorio'); document.getElementById('apellido').focus(); return; }
    if (!usuario) { alert('El usuario es obligatorio'); document.getElementById('usuario').focus(); return; }
    if (!clave) { alert('La clave es obligatoria para nuevos usuarios'); document.getElementById('clave').focus(); return; }
    if (!tipo) { alert('Seleccione un tipo de usuario'); document.getElementById('tipo').focus(); return; }
    if (!fecha) { alert('La fecha es obligatoria'); document.getElementById('fecha').focus(); return; }

    if (!confirm('¿Desea guardar el usuario?')) return;

    try {
        const body = {
            nombre, apellido, usuario, clave, tipo, status, fecha,
            permisos: getPermisosString()
        };
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
    document.getElementById('nombre').focus();
}

async function clickModificar() {
    const nombre = document.getElementById('nombre').value.trim();
    const apellido = document.getElementById('apellido').value.trim();
    const usuario = document.getElementById('usuario').value.trim();
    const clave = document.getElementById('clave').value;
    const tipo = document.getElementById('tipo').value;
    const status = document.getElementById('status').value;
    const fecha = document.getElementById('fecha').value;

    if (!nombre) { alert('El nombre es obligatorio'); document.getElementById('nombre').focus(); return; }
    if (!apellido) { alert('El apellido es obligatorio'); document.getElementById('apellido').focus(); return; }
    if (!usuario) { alert('El usuario es obligatorio'); document.getElementById('usuario').focus(); return; }
    if (!tipo) { alert('Seleccione un tipo de usuario'); document.getElementById('tipo').focus(); return; }
    if (!fecha) { alert('La fecha es obligatoria'); document.getElementById('fecha').focus(); return; }

    if (!confirm('¿Desea modificar el usuario?')) return;

    try {
        const body = {
            id: selectedId, nombre, apellido, usuario, clave, tipo, status, fecha,
            permisos: getPermisosString()
        };
        const result = await apiPost('update', body);
        alert(result.message);
        setModoVista();
    } catch (err) {
        alert('Error: ' + err.message);
    }
}

async function clickEliminar() {
    if (!selectedId) return;
    if (!confirm('¿Esta seguro que desea ELIMINAR este usuario?')) return;

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
function esc(str) {
    if (str == null) return '';
    const div = document.createElement('div');
    div.textContent = str;
    return div.innerHTML;
}

function limpiarFiltros() {
    document.getElementById('filtroUsuario').value = '';
    document.getElementById('filtroNombre').value = '';
    currentPage = 1;
    cargarTabla();
}
