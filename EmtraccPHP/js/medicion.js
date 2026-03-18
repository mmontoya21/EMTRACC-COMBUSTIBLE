// ============ STATE ============
let currentId = null;
let currentPage = 1;

// ============ INIT ============
document.addEventListener('DOMContentLoaded', () => {
    loadList();
    loadChart();

    if (APP.userRole === 'TEST') {
        document.getElementById('btnNuevo').style.display = 'none';
    }

    // Botones
    document.getElementById('btnNuevo').addEventListener('click', onNuevo);
    document.getElementById('btnGuardar').addEventListener('click', onGuardar);
    document.getElementById('btnEditar').addEventListener('click', onEditar);
    document.getElementById('btnModificar').addEventListener('click', onModificar);
    document.getElementById('btnCancelar').addEventListener('click', onCancelar);
    document.getElementById('btnEliminar').addEventListener('click', onEliminar);
    document.getElementById('btnCalcular').addEventListener('click', onCalcular);

    // Auto-calculo al cambiar campos
    ['galonesCalc', 'galRecibidos', 'galonesMed'].forEach(id => {
        document.getElementById(id).addEventListener('input', calcularDerivados);
    });
});

// ============ LIST ============
function loadList(page) {
    if (page) currentPage = page;
    fetch(`api/medicion_api.php?action=list&pagina=${currentPage}`)
        .then(r => r.json())
        .then(data => {
            if (data.error) { alert(data.error); return; }
            renderTable(data.rows);
            document.getElementById('resumenTotal').textContent = data.total;
            renderPagination(data.pagina, data.totalPaginas);
        })
        .catch(err => alert('Error al cargar: ' + err));
}

function renderTable(rows) {
    const tbody = document.getElementById('tbodyMedicion');
    if (!rows.length) {
        tbody.innerHTML = '<tr><td colspan="9" class="text-center text-muted">Sin registros</td></tr>';
        return;
    }
    tbody.innerHTML = rows.map(r => {
        const diff = parseFloat(r.diferencia) || 0;
        let diffClass = '';
        if (diff > 0) diffClass = 'text-success fw-bold';
        else if (diff < 0) diffClass = 'text-danger fw-bold';

        return `<tr data-id="${r.idMedida}" style="cursor:pointer" class="row-selectable">
            <td>${r.idMedida}</td>
            <td>${r.fechaFmt}</td>
            <td class="text-center">${r.periodo ?? ''}</td>
            <td class="text-center">${r.semana ?? ''}</td>
            <td class="text-end">${fmtNum(r.galonesCalc)}</td>
            <td class="text-end">${fmtNum(r.galonesMed)}</td>
            <td class="text-end">${fmtNum(r.galDespachados)}</td>
            <td class="text-end">${fmtNum(r.galEsperados)}</td>
            <td class="text-end ${diffClass}">${fmtNum(r.diferencia)}</td>
        </tr>`;
    }).join('');

    tbody.querySelectorAll('tr[data-id]').forEach(tr => {
        tr.addEventListener('click', () => selectRow(parseInt(tr.dataset.id)));
    });
}

function renderPagination(pagina, totalPaginas) {
    const nav = document.getElementById('paginacion');
    if (totalPaginas <= 1) { nav.innerHTML = ''; return; }
    let html = '<ul class="pagination pagination-sm mb-0">';
    html += `<li class="page-item ${pagina <= 1 ? 'disabled' : ''}"><a class="page-link" href="#" onclick="loadList(${pagina - 1});return false">&laquo;</a></li>`;
    for (let i = Math.max(1, pagina - 2); i <= Math.min(totalPaginas, pagina + 2); i++) {
        html += `<li class="page-item ${i === pagina ? 'active' : ''}"><a class="page-link" href="#" onclick="loadList(${i});return false">${i}</a></li>`;
    }
    html += `<li class="page-item ${pagina >= totalPaginas ? 'disabled' : ''}"><a class="page-link" href="#" onclick="loadList(${pagina + 1});return false">&raquo;</a></li>`;
    html += '</ul>';
    nav.innerHTML = html;
}

// ============ SELECT ROW ============
function selectRow(id) {
    currentId = id;
    fetch(`api/medicion_api.php?action=get&id=${id}`)
        .then(r => r.json())
        .then(data => {
            if (data.error) { alert(data.error); return; }
            fillForm(data);
            setMode('selected');
        })
        .catch(err => alert('Error: ' + err));
}

function fillForm(d) {
    document.getElementById('medicionId').value = d.idMedida;
    document.getElementById('fecha').value = d.fecha ? d.fecha.substring(0, 10) : '';
    document.getElementById('periodo').value = d.periodo ?? '';
    document.getElementById('semana').value = d.semana ?? '';
    document.getElementById('galonesCalc').value = d.galonesCalc ?? '';
    document.getElementById('pglCal').value = d.pglCal ?? '';
    document.getElementById('galonesMed').value = d.galonesMed ?? '';
    document.getElementById('pglMed').value = d.pglMed ?? '';
    document.getElementById('capacidadTanque').value = d.capacidadTanque ?? '';
    document.getElementById('galRecibidos').value = d.galRecibidos ?? '';
    document.getElementById('galDespachados').value = d.galDespachados ?? '';
    document.getElementById('galEsperados').value = d.galEsperados ?? '';
    document.getElementById('diferencia').value = d.diferencia ?? '';
    document.getElementById('observaciones').value = d.observaciones ?? '';
    colorearDiferencia();
}

function clearForm() {
    currentId = null;
    document.getElementById('medicionId').value = '';
    ['fecha', 'galonesCalc', 'pglCal', 'galonesMed', 'pglMed', 'capacidadTanque',
     'galRecibidos', 'galDespachados', 'galEsperados', 'diferencia', 'observaciones'].forEach(id => {
        document.getElementById(id).value = '';
    });
    document.getElementById('periodo').value = '';
    document.getElementById('semana').value = '';
    document.getElementById('diferencia').style.color = '';
}

// ============ MODES ============
function setMode(mode) {
    const isReadOnly = APP.userRole === 'TEST';
    const fields = ['fecha', 'galonesCalc', 'pglCal', 'galonesMed', 'pglMed',
                     'capacidadTanque', 'galRecibidos', 'observaciones', 'periodo', 'semana'];

    switch (mode) {
        case 'initial':
            fields.forEach(id => document.getElementById(id).disabled = true);
            document.getElementById('btnNuevo').disabled = false;
            document.getElementById('btnNuevo').style.display = '';
            document.getElementById('btnGuardar').style.display = 'none';
            document.getElementById('btnEditar').disabled = true;
            document.getElementById('btnModificar').style.display = 'none';
            document.getElementById('btnCancelar').disabled = true;
            document.getElementById('btnEliminar').disabled = true;
            document.getElementById('btnCalcular').style.display = 'none';
            document.getElementById('tblMedicion').style.pointerEvents = '';
            if (isReadOnly) document.getElementById('btnNuevo').style.display = 'none';
            break;

        case 'new':
            fields.forEach(id => document.getElementById(id).disabled = false);
            document.getElementById('btnNuevo').disabled = true;
            document.getElementById('btnGuardar').style.display = '';
            document.getElementById('btnModificar').style.display = 'none';
            document.getElementById('btnEditar').disabled = true;
            document.getElementById('btnCancelar').disabled = false;
            document.getElementById('btnEliminar').disabled = true;
            document.getElementById('btnCalcular').style.display = '';
            document.getElementById('tblMedicion').style.pointerEvents = 'none';
            break;

        case 'selected':
            fields.forEach(id => document.getElementById(id).disabled = true);
            document.getElementById('btnNuevo').disabled = false;
            document.getElementById('btnGuardar').style.display = 'none';
            document.getElementById('btnEditar').disabled = isReadOnly;
            document.getElementById('btnModificar').style.display = 'none';
            document.getElementById('btnCancelar').disabled = true;
            document.getElementById('btnEliminar').disabled = isReadOnly;
            document.getElementById('btnCalcular').style.display = 'none';
            document.getElementById('tblMedicion').style.pointerEvents = '';
            break;

        case 'edit':
            fields.forEach(id => document.getElementById(id).disabled = false);
            document.getElementById('btnNuevo').disabled = true;
            document.getElementById('btnGuardar').style.display = 'none';
            document.getElementById('btnModificar').style.display = '';
            document.getElementById('btnEditar').disabled = true;
            document.getElementById('btnCancelar').disabled = false;
            document.getElementById('btnEliminar').disabled = true;
            document.getElementById('btnCalcular').style.display = '';
            document.getElementById('tblMedicion').style.pointerEvents = 'none';
            break;
    }
}

// ============ ACTIONS ============
function onNuevo() {
    clearForm();
    document.getElementById('fecha').value = new Date().toISOString().substring(0, 10);

    // Pre-llenar periodo y semana de sesion
    if (APP.periodo) document.getElementById('periodo').value = APP.periodo;
    if (APP.semana) document.getElementById('semana').value = APP.semana;

    // Cargar ultima capacidad
    fetch('api/medicion_api.php?action=lastCapacity')
        .then(r => r.json())
        .then(data => {
            if (data.capacidad > 0) {
                document.getElementById('capacidadTanque').value = data.capacidad.toFixed(2);
            }
        }).catch(() => {});

    setMode('new');
    document.getElementById('galonesCalc').focus();
}

function onGuardar() {
    const body = buildFormData();
    fetch('api/medicion_api.php?action=create', { method: 'POST', body })
        .then(r => r.json())
        .then(data => {
            if (data.error) { alert(data.error); return; }
            alert(data.message);
            clearForm();
            setMode('initial');
            loadList();
            loadChart();
        })
        .catch(err => alert('Error: ' + err));
}

function onEditar() {
    setMode('edit');
}

function onModificar() {
    const body = buildFormData();
    body.append('id', document.getElementById('medicionId').value);
    fetch('api/medicion_api.php?action=update', { method: 'POST', body })
        .then(r => r.json())
        .then(data => {
            if (data.error) { alert(data.error); return; }
            alert(data.message);
            setMode('initial');
            loadList();
            loadChart();
        })
        .catch(err => alert('Error: ' + err));
}

function onCancelar() {
    clearForm();
    setMode('initial');
}

function onEliminar() {
    if (!currentId) return;
    if (!confirm('¿Desea eliminar este registro?')) return;

    const body = new FormData();
    body.append('id', currentId);
    fetch('api/medicion_api.php?action=delete', { method: 'POST', body })
        .then(r => r.json())
        .then(data => {
            if (data.error) { alert(data.error); return; }
            alert(data.message);
            clearForm();
            setMode('initial');
            loadList();
            loadChart();
        })
        .catch(err => alert('Error: ' + err));
}

function onCalcular() {
    const periodo = document.getElementById('periodo').value;
    const semana = document.getElementById('semana').value;
    if (!periodo || !semana) {
        alert('Seleccione Periodo y Semana para calcular los galones despachados.');
        return;
    }

    fetch(`api/medicion_api.php?action=calcDespachados&periodo=${periodo}&semana=${semana}`)
        .then(r => r.json())
        .then(data => {
            if (data.error) { alert(data.error); return; }
            document.getElementById('galDespachados').value = data.totalDespachados.toFixed(2);
            calcularDerivados();
        })
        .catch(err => alert('Error: ' + err));
}

// ============ CALCULO ============
function calcularDerivados() {
    const galInicio = parseFloat(document.getElementById('galonesCalc').value) || 0;
    const galRecibidos = parseFloat(document.getElementById('galRecibidos').value) || 0;
    const galDespachados = parseFloat(document.getElementById('galDespachados').value) || 0;
    const galFinal = parseFloat(document.getElementById('galonesMed').value) || 0;

    const esperado = galInicio + galRecibidos - galDespachados;
    document.getElementById('galEsperados').value = esperado.toFixed(2);

    const diff = galFinal - esperado;
    document.getElementById('diferencia').value = diff.toFixed(2);

    colorearDiferencia();
}

function colorearDiferencia() {
    const el = document.getElementById('diferencia');
    const diff = parseFloat(el.value) || 0;
    const cap = parseFloat(document.getElementById('capacidadTanque').value) || 0;

    if (diff >= 0) {
        el.style.color = '#198754';
    } else if (cap > 0 && Math.abs(diff) <= cap * 0.02) {
        el.style.color = '#ffc107';
    } else {
        el.style.color = '#dc3545';
    }
}

// ============ CHART ============
function loadChart() {
    fetch('api/medicion_api.php?action=lastMeasurement')
        .then(r => r.json())
        .then(data => {
            if (data.error) return;
            renderTank(data);
            renderBars(data);
            renderReconciliation(data);
        })
        .catch(() => {});
}

function renderTank(d) {
    const pct = d.capacidad > 0 ? Math.min(Math.max((d.galFinal / d.capacidad) * 100, 0), 100) : 0;
    const fill = document.getElementById('tankFill');
    fill.style.height = pct + '%';

    if (pct > 50) fill.style.background = 'linear-gradient(#34c759, #148c32)';
    else if (pct > 25) fill.style.background = 'linear-gradient(#ffcc00, #c89600)';
    else fill.style.background = 'linear-gradient(#ff453a, #b4281e)';

    document.getElementById('tankPercent').textContent = pct.toFixed(1) + '%';
    document.getElementById('tankGalones').textContent = fmtNum(d.galFinal) + ' gal';
    document.getElementById('tankCapacidad').textContent = d.capacidad > 0 ? 'de ' + fmtNum(d.capacidad) : '';
}

function renderBars(d) {
    const maxVal = Math.max(d.galInicio, d.galEsperado, d.galFinal, 1);
    const maxH = 80; // px

    const hInicio = (d.galInicio / maxVal) * maxH;
    const hEsperado = (d.galEsperado / maxVal) * maxH;
    const hReal = (d.galFinal / maxVal) * maxH;

    document.getElementById('barInicio').style.height = hInicio + 'px';
    document.getElementById('barInicioVal').textContent = Math.round(d.galInicio).toLocaleString();

    document.getElementById('barEsperado').style.height = hEsperado + 'px';
    document.getElementById('barEsperadoVal').textContent = Math.round(d.galEsperado).toLocaleString();

    document.getElementById('barReal').style.height = hReal + 'px';
    document.getElementById('barRealVal').textContent = Math.round(d.galFinal).toLocaleString();

    const barReal = document.getElementById('barReal');
    if (d.diferencia >= 0) {
        barReal.style.background = 'linear-gradient(#34c759, #148c32)';
    } else {
        barReal.style.background = 'linear-gradient(#ff453a, #b4281e)';
    }
}

function renderReconciliation(d) {
    document.getElementById('formulaText').textContent =
        `Inicio: ${d.galInicio.toFixed(2)}  +  Recibidos  -  Despachados  =  Esperado: ${d.galEsperado.toFixed(2)}`;
    document.getElementById('formulaText2').textContent =
        `Medicion Real: ${d.galFinal.toFixed(2)}`;

    const diffEl = document.getElementById('diffBadge');
    const sign = d.diferencia >= 0 ? '+' : '';
    const color = d.diferencia >= 0 ? 'success' : 'danger';
    diffEl.innerHTML = `<span class="badge bg-${color}">Dif: ${sign}${d.diferencia.toFixed(2)} gal</span>`;
}

// ============ HELPERS ============
function buildFormData() {
    const fd = new FormData();
    fd.append('fecha', document.getElementById('fecha').value);
    fd.append('galonesCalc', document.getElementById('galonesCalc').value);
    fd.append('pglCal', document.getElementById('pglCal').value);
    fd.append('galonesMed', document.getElementById('galonesMed').value);
    fd.append('pglMed', document.getElementById('pglMed').value);
    fd.append('periodo', document.getElementById('periodo').value);
    fd.append('semana', document.getElementById('semana').value);
    fd.append('capacidadTanque', document.getElementById('capacidadTanque').value);
    fd.append('galRecibidos', document.getElementById('galRecibidos').value);
    fd.append('galDespachados', document.getElementById('galDespachados').value);
    fd.append('galEsperados', document.getElementById('galEsperados').value);
    fd.append('diferencia', document.getElementById('diferencia').value);
    fd.append('observaciones', document.getElementById('observaciones').value);
    return fd;
}

function fmtNum(val) {
    const n = parseFloat(val);
    if (isNaN(n)) return '';
    return n.toLocaleString('es-HN', { minimumFractionDigits: 2, maximumFractionDigits: 2 });
}
