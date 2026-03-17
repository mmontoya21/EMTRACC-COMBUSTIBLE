// ==================== ESTADO GLOBAL ====================
let currentMode = 'view'; // 'view' | 'create' | 'edit'
let selectedId = null;
let selectedActivo = true;
let currentPage = 1;

// ==================== INICIALIZACION ====================
document.addEventListener('DOMContentLoaded', () => {
    cargarTabla();

    // Autocomplete bidireccional
    setupAutocompleteCodigo();
    setupAutocompletePropietario();

    // Botones
    document.getElementById('btnNuevo').addEventListener('click', clickNuevo);
    document.getElementById('btnGuardar').addEventListener('click', clickGuardar);
    document.getElementById('btnEditar').addEventListener('click', clickEditar);
    document.getElementById('btnModificar').addEventListener('click', clickModificar);
    document.getElementById('btnCancelar').addEventListener('click', clickCancelar);
    document.getElementById('btnEliminar').addEventListener('click', clickEliminar);
    document.getElementById('btnBloquear').addEventListener('click', clickBloquear);

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

    // Uppercase en placa
    document.getElementById('placa').addEventListener('input', function() { this.value = this.value.toUpperCase(); });

    setModoVista();
});

// ==================== API HELPER ====================
async function apiGet(action, params = {}) {
    const url = new URL('api/placa_api.php', window.location.href);
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
    const resp = await fetch('api/placa_api.php', { method: 'POST', body: formData });
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
            propietario: document.getElementById('filtroPropietario').value,
            placa: document.getElementById('filtroPlaca').value,
            estado: document.getElementById('filtroEstado').value
        };

        const data = await apiGet('list', params);
        const tbody = document.getElementById('tbodyPlacas');
        tbody.innerHTML = '';

        if (data.rows.length === 0) {
            tbody.innerHTML = '<tr><td colspan="5" class="text-center text-muted">No se encontraron registros</td></tr>';
        } else {
            data.rows.forEach((row, idx) => {
                const tr = document.createElement('tr');
                tr.dataset.id = row.idPlaca;
                tr.dataset.activo = row.activo;
                const activo = parseInt(row.activo) === 1;

                if (!activo) {
                    tr.className = 'row-bloqueado';
                } else {
                    tr.className = idx % 2 === 0 ? 'row-white' : 'row-blue';
                }

                if (currentMode === 'view') {
                    tr.style.cursor = 'pointer';
                    tr.addEventListener('click', () => selectRow(row.idPlaca));
                }

                tr.innerHTML = `
                    <td>${esc(row.codigoPro)}</td>
                    <td><strong>${esc(row.placa)}</strong></td>
                    <td>${esc(row.propietario)}</td>
                    <td class="d-none d-md-table-cell">${esc(row.observaciones)}</td>
                    <td><span class="badge ${activo ? 'bg-success' : 'bg-danger'}">${activo ? 'Activo' : 'Bloqueado'}</span></td>
                `;
                tbody.appendChild(tr);
            });
        }

        // Resumen
        document.getElementById('resumenTotal').textContent = data.total;
        document.getElementById('resumenActivos').textContent = data.activos;
        document.getElementById('resumenBloqueados').textContent = data.bloqueados;

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
        selectedId = data.idPlaca;
        selectedActivo = parseInt(data.activo) === 1;

        document.getElementById('idPlaca').value = data.idPlaca;
        document.getElementById('codigoPro').value = data.codigoPro || '';
        document.getElementById('propietario').value = data.propietario || '';
        document.getElementById('placa').value = data.placa || '';
        document.getElementById('observaciones').value = data.observaciones || '';

        // Resaltar fila
        document.querySelectorAll('#tbodyPlacas tr').forEach(tr => tr.classList.remove('selected'));
        const row = document.querySelector(`#tbodyPlacas tr[data-id="${id}"]`);
        if (row) row.classList.add('selected');

        // Habilitar botones
        document.getElementById('btnEditar').disabled = false;
        if (APP.userRole === 'ADMIN' || APP.userRole === 'SUPERADMIN') {
            document.getElementById('btnEliminar').disabled = false;
        }

        // Boton bloquear/desbloquear
        const btnBlq = document.getElementById('btnBloquear');
        btnBlq.disabled = false;
        if (selectedActivo) {
            btnBlq.innerHTML = '<i class="bi bi-lock"></i> Bloquear';
            btnBlq.className = 'btn btn-warning btn-sm';
        } else {
            btnBlq.innerHTML = '<i class="bi bi-unlock"></i> Desbloquear';
            btnBlq.className = 'btn btn-outline-success btn-sm';
        }

        // Badge de estado
        const badge = document.getElementById('estadoBadge');
        badge.style.display = 'inline';
        if (selectedActivo) {
            badge.textContent = 'ACTIVO';
            badge.className = 'badge bg-success';
        } else {
            badge.textContent = 'BLOQUEADO';
            badge.className = 'badge bg-danger';
        }

    } catch (err) {
        alert('Error al cargar registro: ' + err.message);
    }
}

// ==================== MODOS ====================
function setModoVista() {
    currentMode = 'view';
    selectedId = null;
    selectedActivo = true;

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
    document.getElementById('btnBloquear').disabled = true;
    document.getElementById('btnBloquear').innerHTML = '<i class="bi bi-lock"></i> Bloquear';
    document.getElementById('btnBloquear').className = 'btn btn-warning btn-sm';
    document.getElementById('estadoBadge').style.display = 'none';

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
    document.getElementById('btnBloquear').disabled = true;

    // Deshabilitar click en filas
    document.querySelectorAll('#tbodyPlacas tr').forEach(tr => {
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
    document.getElementById('btnBloquear').disabled = true;

    // Deshabilitar click en filas
    document.querySelectorAll('#tbodyPlacas tr').forEach(tr => {
        tr.style.cursor = 'default';
        tr.replaceWith(tr.cloneNode(true));
    });
}

function toggleFormEnabled(enabled) {
    const panel = document.getElementById('formPanel');
    const inputs = panel.querySelectorAll('input, textarea');
    inputs.forEach(el => {
        if (el.id === 'idPlaca') return;
        el.disabled = !enabled;
    });

    if (enabled) {
        panel.classList.add('enabled');
    } else {
        panel.classList.remove('enabled');
    }
}

function limpiarFormulario() {
    document.getElementById('idPlaca').value = '';
    document.getElementById('codigoPro').value = '';
    document.getElementById('propietario').value = '';
    document.getElementById('placa').value = '';
    document.getElementById('observaciones').value = '';
}

// ==================== ACCIONES CRUD ====================
function clickNuevo() {
    limpiarFormulario();
    setModoCrear();
    document.getElementById('codigoPro').focus();
}

async function clickGuardar() {
    const placa = document.getElementById('placa').value.trim();
    if (!placa) { alert('La placa es obligatoria'); document.getElementById('placa').focus(); return; }

    if (!confirm('Desea guardar la placa?')) return;

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
    document.getElementById('codigoPro').focus();
}

async function clickModificar() {
    const placa = document.getElementById('placa').value.trim();
    if (!placa) { alert('La placa es obligatoria'); document.getElementById('placa').focus(); return; }

    if (!confirm('Desea modificar la placa?')) return;

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

    if (!confirm('Esta seguro que desea ELIMINAR esta placa?')) return;

    try {
        const result = await apiPost('delete', { id: selectedId });
        alert(result.message);
        setModoVista();
    } catch (err) {
        alert('Error: ' + err.message);
    }
}

async function clickBloquear() {
    if (!selectedId) return;

    if (selectedActivo) {
        if (!confirm('Desea BLOQUEAR esta placa? No podra ser usada en comprobantes.')) return;
        try {
            const result = await apiPost('block', { id: selectedId });
            alert(result.message);
            setModoVista();
        } catch (err) {
            alert('Error: ' + err.message);
        }
    } else {
        if (!confirm('Desea DESBLOQUEAR esta placa?')) return;
        try {
            const result = await apiPost('unblock', { id: selectedId });
            alert(result.message);
            setModoVista();
        } catch (err) {
            alert('Error: ' + err.message);
        }
    }
}

function clickCancelar() {
    setModoVista();
}

// ==================== AUTOCOMPLETE BIDIRECCIONAL ====================
function setupAutocompleteCodigo() {
    const input = document.getElementById('codigoPro');
    let debounceTimer = null;
    const container = document.createElement('div');
    container.className = 'autocomplete-dropdown';
    container.style.display = 'none';
    input.parentElement.appendChild(container);

    input.addEventListener('input', () => {
        clearTimeout(debounceTimer);
        const val = input.value.trim();
        if (val.length < 1) { container.style.display = 'none'; return; }

        debounceTimer = setTimeout(async () => {
            try {
                const data = await apiGet('autoCodigo', { q: val });
                container.innerHTML = '';
                if (data.length === 0) { container.style.display = 'none'; return; }

                data.forEach(item => {
                    const div = document.createElement('div');
                    div.className = 'item';
                    div.textContent = item.codProp + ' - ' + item.nPropietario;
                    div.addEventListener('click', () => {
                        input.value = item.codProp;
                        document.getElementById('propietario').value = item.nPropietario;
                        container.style.display = 'none';
                    });
                    container.appendChild(div);
                });
                container.style.display = 'block';
            } catch (err) {
                container.style.display = 'none';
            }
        }, 300);
    });

    // Lookup exacto al perder foco
    input.addEventListener('change', async () => {
        const val = input.value.trim();
        if (val === '') { document.getElementById('propietario').value = ''; return; }
        try {
            const data = await apiGet('lookupCodigo', { codigo: val });
            if (data.nPropietario) {
                document.getElementById('propietario').value = data.nPropietario;
            }
        } catch (err) { /* silenciar */ }
    });

    document.addEventListener('click', e => {
        if (!input.contains(e.target) && !container.contains(e.target)) {
            container.style.display = 'none';
        }
    });
}

function setupAutocompletePropietario() {
    const input = document.getElementById('propietario');
    let debounceTimer = null;
    const container = document.createElement('div');
    container.className = 'autocomplete-dropdown';
    container.style.display = 'none';
    input.parentElement.appendChild(container);

    input.addEventListener('input', () => {
        clearTimeout(debounceTimer);
        const val = input.value.trim();
        if (val.length < 2) { container.style.display = 'none'; return; }

        debounceTimer = setTimeout(async () => {
            try {
                const data = await apiGet('autoPropietario', { q: val });
                container.innerHTML = '';
                if (data.length === 0) { container.style.display = 'none'; return; }

                data.forEach(item => {
                    const div = document.createElement('div');
                    div.className = 'item';
                    div.textContent = item.nPropietario + ' (' + item.codProp + ')';
                    div.addEventListener('click', () => {
                        input.value = item.nPropietario;
                        document.getElementById('codigoPro').value = item.codProp;
                        container.style.display = 'none';
                    });
                    container.appendChild(div);
                });
                container.style.display = 'block';
            } catch (err) {
                container.style.display = 'none';
            }
        }, 300);
    });

    // Lookup exacto al perder foco
    input.addEventListener('change', async () => {
        const val = input.value.trim();
        if (val === '') { document.getElementById('codigoPro').value = ''; return; }
        try {
            const data = await apiGet('lookupPropietario', { nombre: val });
            if (data.codProp) {
                document.getElementById('codigoPro').value = data.codProp;
            }
        } catch (err) { /* silenciar */ }
    });

    document.addEventListener('click', e => {
        if (!input.contains(e.target) && !container.contains(e.target)) {
            container.style.display = 'none';
        }
    });
}

// ==================== HELPERS ====================
function getFormData() {
    return {
        codigoPro: document.getElementById('codigoPro').value,
        propietario: document.getElementById('propietario').value,
        placa: document.getElementById('placa').value,
        observaciones: document.getElementById('observaciones').value
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
    document.getElementById('filtroPlaca').value = '';
    document.getElementById('filtroEstado').value = '';
    currentPage = 1;
    cargarTabla();
}
