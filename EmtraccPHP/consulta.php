<?php
require_once 'includes/auth.php';
requireLogin();
requirePermiso('comprobante');
require_once 'includes/config.php';

$pageTitle = 'Consulta';
include 'includes/header.php';
?>

<style>
    .detalle-anulado { border: 3px solid #dc3545 !important; }
    .sello-anulado { position: absolute; top: 50%; left: 50%; transform: translate(-50%,-50%) rotate(-25deg); font-size: 5rem; font-weight: bold; color: rgba(220,53,69,0.15); pointer-events: none; z-index: 1; letter-spacing: 10px; }
    #resultados tbody tr { cursor: pointer; }
    #resultados tbody tr:hover > td { background-color: #d0e0f0 !important; }
    #resultados tbody tr.selected > td { background-color: #b0c4de !important; }
    #detalleCard { display: none; }

    /* Formulario de detalle */
    .detalle-form label { font-size: 0.75rem; font-weight: 600; color: #6c757d; text-transform: uppercase; letter-spacing: 0.5px; margin-bottom: 2px; }
    .detalle-form .form-control { font-size: 1.1rem; border: 1px solid #dee2e6; }
    .detalle-form .form-control:read-only { background-color: #f8f9fa; }

    .input-compro { font-size: 1.4rem !important; font-weight: bold !important; color: #0d6efd !important; background-color: #e7f1ff !important; }
    .input-placa { font-size: 1.5rem !important; font-weight: bold !important; color: #b8860b !important; background-color: #fff8dc !important; letter-spacing: 1px; }
    .input-galones { font-size: 1.3rem !important; font-weight: bold !important; background-color: #e0f7fa !important; color: #006064 !important; }
    .input-valor { font-size: 1.1rem !important; background-color: #f5f5f5 !important; }
    .input-total { font-size: 1.4rem !important; font-weight: bold !important; background-color: #e8f5e9 !important; color: #198754 !important; }

    .seccion-titulo { font-size: 0.8rem; font-weight: 700; color: #4A5A78; text-transform: uppercase; letter-spacing: 1px; border-bottom: 2px solid #4A5A78; padding-bottom: 4px; margin-bottom: 8px; margin-top: 12px; }

    @media (max-width: 768px) {
        .detalle-form .form-control { font-size: 1rem; }
        .input-compro { font-size: 1.2rem !important; }
        .input-placa { font-size: 1.3rem !important; }
        .input-total { font-size: 1.2rem !important; }
        .sello-anulado { font-size: 3rem; }
    }
</style>

<h5 class="mb-3">Consulta de Comprobantes</h5>

<!-- BARRA DE BUSQUEDA -->
<div class="card mb-3">
    <div class="card-body p-2">
        <div class="row g-2 align-items-end">
            <div class="col-6 col-md-3">
                <label class="form-label small mb-0">N&deg; Boleta</label>
                <input type="text" id="busqBoleta" class="form-control form-control-sm busq-input" placeholder="Buscar boleta...">
            </div>
            <div class="col-6 col-md-3">
                <label class="form-label small mb-0">N&deg; Comprobante</label>
                <input type="text" id="busqComprobante" class="form-control form-control-sm busq-input" placeholder="Buscar comprobante...">
            </div>
            <div class="col-6 col-md-3">
                <label class="form-label small mb-0">N&deg; Placa</label>
                <input type="text" id="busqPlaca" class="form-control form-control-sm busq-input" placeholder="Buscar placa...">
            </div>
            <div class="col-6 col-md-3 d-flex gap-1">
                <button id="btnBuscar" class="btn btn-primary btn-sm"><i class="bi bi-search"></i> Buscar</button>
                <button id="btnLimpiar" class="btn btn-outline-secondary btn-sm"><i class="bi bi-eraser"></i> Limpiar</button>
            </div>
        </div>
    </div>
</div>

<!-- RESULTADOS -->
<div class="table-responsive mb-3" style="max-height: 35vh; overflow-y: auto;">
    <table class="table table-bordered table-sm mb-0" id="resultados">
        <thead class="table-dark sticky-top">
            <tr>
                <th>Comprobante</th>
                <th>Boleta</th>
                <th>Fecha</th>
                <th>Placa</th>
                <th class="d-none d-md-table-cell">Propietario</th>
                <th class="d-none d-md-table-cell">Despachador</th>
                <th>Estado</th>
            </tr>
        </thead>
        <tbody id="tbodyResultados">
            <tr><td colspan="7" class="text-center text-muted py-3">Ingrese un criterio de busqueda</td></tr>
        </tbody>
    </table>
</div>

<!-- DETALLE DEL REGISTRO -->
<div class="card shadow" id="detalleCard" style="position: relative; overflow: hidden;">
    <div class="card-header bg-dark text-white d-flex justify-content-between align-items-center">
        <strong>Detalle del Comprobante</strong>
        <div class="d-flex gap-1">
            <span id="dEstado"></span>
            <button id="btnPrintCompro" class="btn btn-sm btn-outline-light"><i class="bi bi-printer"></i> Comprobante</button>
            <button id="btnPrintDoc" class="btn btn-sm btn-outline-light"><i class="bi bi-file-earmark-text"></i> Documento</button>
        </div>
    </div>
    <div class="card-body p-3 detalle-form" id="detalleBody">
        <div id="selloAnulado" class="sello-anulado" style="display:none">ANULADO</div>

        <!-- IDENTIFICACION -->
        <div class="seccion-titulo">Identificaci&oacute;n</div>
        <div class="row g-2 mb-2">
            <div class="col-md-3 col-6">
                <label>N&deg; Comprobante</label>
                <input type="text" id="dCompro" class="form-control input-compro" readonly>
            </div>
            <div class="col-md-3 col-6">
                <label>N&deg; Boleta</label>
                <input type="text" id="dBoleta" class="form-control" readonly>
            </div>
            <div class="col-md-3 col-6">
                <label>Fecha</label>
                <input type="text" id="dFecha" class="form-control" readonly>
            </div>
            <div class="col-md-3 col-6">
                <label>Despachador</label>
                <input type="text" id="dDespachador" class="form-control" readonly>
            </div>
        </div>

        <!-- VEHICULO -->
        <div class="seccion-titulo">Veh&iacute;culo</div>
        <div class="row g-2 mb-2">
            <div class="col-md-4 col-6">
                <label>Placa Cabezal</label>
                <input type="text" id="dPlaca" class="form-control input-placa" readonly>
            </div>
            <div class="col-md-4 col-6">
                <label>Contenedor</label>
                <input type="text" id="dConte" class="form-control" readonly>
            </div>
            <div class="col-md-4 col-6">
                <label>C&oacute;digo Propietario</label>
                <input type="text" id="dCodiProp" class="form-control" readonly>
            </div>
        </div>
        <div class="row g-2 mb-2">
            <div class="col-md-6">
                <label>Propietario</label>
                <input type="text" id="dPropietario" class="form-control" readonly>
            </div>
            <div class="col-md-6">
                <label>Conductor</label>
                <input type="text" id="dConductor" class="form-control" readonly>
            </div>
        </div>

        <!-- RUTA -->
        <div class="seccion-titulo">Ruta</div>
        <div class="row g-2 mb-2">
            <div class="col-12">
                <label>Ruta</label>
                <input type="text" id="dRuta" class="form-control" readonly>
            </div>
        </div>

        <!-- DESPACHO -->
        <div class="seccion-titulo">Despacho de Combustible</div>
        <div class="row g-2 mb-2">
            <div class="col-md-3 col-4">
                <label>Galones Despachados</label>
                <input type="text" id="dGalones" class="form-control input-galones text-center" readonly>
            </div>
            <div class="col-md-3 col-4">
                <label>Valor por Gal&oacute;n</label>
                <input type="text" id="dValor" class="form-control input-valor text-center" readonly>
            </div>
            <div class="col-md-3 col-4">
                <label>Total</label>
                <input type="text" id="dTotal" class="form-control input-total text-center" readonly>
            </div>
            <div class="col-md-1 col-4">
                <label>Periodo</label>
                <input type="text" id="dPeriodo" class="form-control text-center" readonly>
            </div>
            <div class="col-md-1 col-4">
                <label>Semana</label>
                <input type="text" id="dSemana" class="form-control text-center" readonly>
            </div>
            <div class="col-md-1 col-4">
                <label>Prox. Sem</label>
                <input type="text" id="dProxSem" class="form-control text-center" readonly>
            </div>
        </div>
    </div>
</div>

<script>
let selectedId = null;

// Busqueda
document.getElementById('btnBuscar').addEventListener('click', buscar);
document.getElementById('btnLimpiar').addEventListener('click', limpiar);

// Enter en campos de busqueda
document.querySelectorAll('.busq-input').forEach(el => {
    el.addEventListener('keydown', e => { if (e.key === 'Enter') buscar(); });
});

// Debounce en campos de busqueda
let debounceTimer = null;
document.querySelectorAll('.busq-input').forEach(el => {
    el.addEventListener('input', () => {
        clearTimeout(debounceTimer);
        debounceTimer = setTimeout(buscar, 400);
    });
});

// Imprimir
document.getElementById('btnPrintCompro').addEventListener('click', () => {
    if (selectedId) window.open('comprobante_print.php?id=' + selectedId, '_blank', 'width=400,height=600');
});
document.getElementById('btnPrintDoc').addEventListener('click', () => {
    if (selectedId) window.open('documento_print.php?id=' + selectedId, '_blank', 'width=450,height=650');
});

async function buscar() {
    const boleta = document.getElementById('busqBoleta').value.trim();
    const comprobante = document.getElementById('busqComprobante').value.trim();
    const placa = document.getElementById('busqPlaca').value.trim();

    if (!boleta && !comprobante && !placa) {
        document.getElementById('tbodyResultados').innerHTML = '<tr><td colspan="7" class="text-center text-muted py-3">Ingrese un criterio de busqueda</td></tr>';
        document.getElementById('detalleCard').style.display = 'none';
        return;
    }

    try {
        const params = new URLSearchParams({ action: 'list', boleta, comprobante, placa, pagina: 1 });
        const resp = await fetch('api/comprobante_api.php?' + params);
        const data = await resp.json();

        const tbody = document.getElementById('tbodyResultados');

        if (data.rows.length === 0) {
            tbody.innerHTML = '<tr><td colspan="7" class="text-center text-muted py-3">No se encontraron resultados</td></tr>';
            return;
        }

        tbody.innerHTML = '';
        data.rows.forEach((row, idx) => {
            const tr = document.createElement('tr');
            tr.dataset.id = row.idcprbnt;
            const anulado = parseInt(row.anulado) === 1;

            if (anulado) tr.className = 'row-anulado';
            else tr.className = idx % 2 === 0 ? 'row-white' : 'row-blue';

            tr.innerHTML = `
                <td>${esc(row.nCompro)}</td>
                <td>${esc(row.nBoleta)}</td>
                <td>${esc(row.fechaFmt)}</td>
                <td><strong>${esc(row.placaCbz)}</strong></td>
                <td class="d-none d-md-table-cell">${esc(row.propCbz)}</td>
                <td class="d-none d-md-table-cell">${esc(row.nombDesp)}</td>
                <td><span class="badge ${anulado ? 'bg-danger' : 'bg-success'}">${anulado ? 'ANULADO' : 'ACTIVO'}</span></td>
            `;
            tr.addEventListener('click', () => seleccionarRegistro(row.idcprbnt, tr));
            tbody.appendChild(tr);
        });
    } catch (err) {
        console.error('Error en busqueda:', err);
    }
}

async function seleccionarRegistro(id, trElement) {
    // Resaltar fila
    document.querySelectorAll('#tbodyResultados tr').forEach(tr => tr.classList.remove('selected'));
    trElement.classList.add('selected');

    try {
        const resp = await fetch('api/comprobante_api.php?action=get&id=' + id);
        const c = await resp.json();
        if (c.error) { alert(c.error); return; }

        selectedId = c.idcprbnt;
        const anulado = parseInt(c.anulado) === 1;
        const fecha = c.fecha ? new Date(c.fecha).toLocaleDateString('es-HN', { day: '2-digit', month: '2-digit', year: 'numeric' }) : '';

        document.getElementById('dCompro').value = c.nCompro || '';
        document.getElementById('dBoleta').value = c.nBoleta || '';
        document.getElementById('dFecha').value = fecha;
        document.getElementById('dDespachador').value = c.nombDesp || '';
        document.getElementById('dPropietario').value = c.propCbz || '';
        document.getElementById('dCodiProp').value = c.codiProp || '';
        document.getElementById('dPlaca').value = c.placaCbz || '';
        document.getElementById('dConte').value = c.nConte || '';
        document.getElementById('dRuta').value = c.ruta || '';
        document.getElementById('dConductor').value = c.nombCond || '';
        document.getElementById('dGalones').value = parseFloat(c.galDesp || 0).toFixed(2);
        document.getElementById('dValor').value = 'L. ' + parseFloat(c.valor || 0).toFixed(2);
        document.getElementById('dTotal').value = 'L. ' + (parseFloat(c.galDesp || 0) * parseFloat(c.valor || 0)).toFixed(2);
        document.getElementById('dPeriodo').value = c.periodo || '';
        document.getElementById('dSemana').value = c.semana || '';
        document.getElementById('dProxSem').value = c.proxSem || '';

        // Estado
        if (anulado) {
            document.getElementById('dEstado').innerHTML = '<span class="badge bg-danger" style="font-size:1.2rem">ANULADO</span>';
            document.getElementById('detalleCard').classList.add('detalle-anulado');
            document.getElementById('selloAnulado').style.display = 'block';
        } else {
            document.getElementById('dEstado').innerHTML = '<span class="badge bg-success" style="font-size:1.2rem">ACTIVO</span>';
            document.getElementById('detalleCard').classList.remove('detalle-anulado');
            document.getElementById('selloAnulado').style.display = 'none';
        }

        document.getElementById('detalleCard').style.display = 'block';

        // Scroll al detalle en movil
        if (window.innerWidth < 768) {
            document.getElementById('detalleCard').scrollIntoView({ behavior: 'smooth', block: 'start' });
        }
    } catch (err) {
        console.error('Error cargando detalle:', err);
    }
}

function limpiar() {
    document.getElementById('busqBoleta').value = '';
    document.getElementById('busqComprobante').value = '';
    document.getElementById('busqPlaca').value = '';
    document.getElementById('tbodyResultados').innerHTML = '<tr><td colspan="7" class="text-center text-muted py-3">Ingrese un criterio de busqueda</td></tr>';
    document.getElementById('detalleCard').style.display = 'none';
    selectedId = null;
}

function esc(str) {
    if (str == null) return '';
    const div = document.createElement('div');
    div.textContent = str;
    return div.innerHTML;
}
</script>

<?php include 'includes/footer.php'; ?>
