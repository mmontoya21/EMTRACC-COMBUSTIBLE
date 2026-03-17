// ==================== ESTADO GLOBAL ====================
let currentMode = 'view'; // 'view' | 'create' | 'edit'
let recordExists = false;

// Todos los campos del formulario
const CAMPOS = [
    'nEmpre', 'nPropie', 'nombLocal', 'local', 'rtn', 'correoE',
    'dire1', 'dire2', 'dire3', 'tel1', 'cel2', 'fax',
    'cai', 'ochoDig', 'rangoIni', 'rangoFin', 'fechaLimit', 'otros1', 'otros2'
];

// ==================== INICIALIZACION ====================
document.addEventListener('DOMContentLoaded', () => {
    // Botones
    document.getElementById('btnNuevo').addEventListener('click', clickNuevo);
    document.getElementById('btnGuardar').addEventListener('click', clickGuardar);
    document.getElementById('btnEditar').addEventListener('click', clickEditar);
    document.getElementById('btnModificar').addEventListener('click', clickModificar);
    document.getElementById('btnCancelar').addEventListener('click', clickCancelar);
    document.getElementById('btnEliminar').addEventListener('click', clickEliminar);

    cargarDatos();
});

// ==================== API HELPER ====================
async function apiGet(action, params = {}) {
    const url = new URL('api/empresa_api.php', window.location.href);
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
    const resp = await fetch('api/empresa_api.php', { method: 'POST', body: formData });
    const data = await resp.json();
    if (!resp.ok) throw new Error(data.error || 'Error del servidor');
    return data;
}

// ==================== CARGAR DATOS ====================
async function cargarDatos() {
    try {
        const data = await apiGet('get');

        if (data.exists) {
            recordExists = true;
            CAMPOS.forEach(campo => {
                const el = document.getElementById(campo);
                if (el) el.value = data[campo] || '';
            });
            setModoVista();
        } else {
            recordExists = false;
            limpiarFormulario();
            setModoVista();
            document.getElementById('statusBadge').textContent = 'Sin datos';
            document.getElementById('statusBadge').className = 'badge bg-warning';
        }
    } catch (err) {
        console.error('Error cargando datos:', err);
    }
}

// ==================== MODOS ====================
function setModoVista() {
    currentMode = 'view';
    toggleFormEnabled(false);

    document.getElementById('btnNuevo').disabled = recordExists;
    document.getElementById('btnGuardar').style.display = 'none';
    document.getElementById('btnEditar').disabled = !recordExists;
    document.getElementById('btnEditar').style.display = '';
    document.getElementById('btnModificar').style.display = 'none';
    document.getElementById('btnCancelar').disabled = true;
    document.getElementById('btnEliminar').disabled = !recordExists;

    if (recordExists) {
        document.getElementById('statusBadge').textContent = 'Registro cargado';
        document.getElementById('statusBadge').className = 'badge bg-success';
    }
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

    document.getElementById('statusBadge').textContent = 'Creando...';
    document.getElementById('statusBadge').className = 'badge bg-info';
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

    document.getElementById('statusBadge').textContent = 'Editando...';
    document.getElementById('statusBadge').className = 'badge bg-warning text-dark';
}

function toggleFormEnabled(enabled) {
    const panel = document.getElementById('formPanel');
    panel.querySelectorAll('input, textarea').forEach(el => {
        el.disabled = !enabled;
    });

    if (enabled) {
        panel.classList.add('enabled');
    } else {
        panel.classList.remove('enabled');
    }
}

function limpiarFormulario() {
    CAMPOS.forEach(campo => {
        const el = document.getElementById(campo);
        if (el) el.value = '';
    });
}

// ==================== ACCIONES ====================
function clickNuevo() {
    limpiarFormulario();
    setModoCrear();
    document.getElementById('nEmpre').focus();
}

async function clickGuardar() {
    const nEmpre = document.getElementById('nEmpre').value.trim();
    if (!nEmpre) { alert('El nombre de la empresa es obligatorio'); document.getElementById('nEmpre').focus(); return; }

    if (!confirm('¿Desea guardar los datos de la empresa?')) return;

    try {
        const body = getFormData();
        const result = await apiPost('save', body);
        alert(result.message);
        recordExists = true;
        cargarDatos();
    } catch (err) {
        alert('Error: ' + err.message);
    }
}

function clickEditar() {
    if (!recordExists) return;
    setModoEditar();
    document.getElementById('nEmpre').focus();
}

async function clickModificar() {
    const nEmpre = document.getElementById('nEmpre').value.trim();
    if (!nEmpre) { alert('El nombre de la empresa es obligatorio'); document.getElementById('nEmpre').focus(); return; }

    if (!confirm('¿Desea modificar los datos de la empresa?')) return;

    try {
        const body = getFormData();
        const result = await apiPost('save', body);
        alert(result.message);
        cargarDatos();
    } catch (err) {
        alert('Error: ' + err.message);
    }
}

async function clickEliminar() {
    if (!recordExists) return;
    if (!confirm('¿Esta seguro que desea ELIMINAR los datos de la empresa? Esta accion no se puede deshacer.')) return;

    try {
        const result = await apiPost('delete');
        alert(result.message);
        recordExists = false;
        limpiarFormulario();
        cargarDatos();
    } catch (err) {
        alert('Error: ' + err.message);
    }
}

function clickCancelar() {
    cargarDatos();
}

// ==================== HELPERS ====================
function getFormData() {
    const data = {};
    CAMPOS.forEach(campo => {
        const el = document.getElementById(campo);
        data[campo] = el ? el.value : '';
    });
    return data;
}
