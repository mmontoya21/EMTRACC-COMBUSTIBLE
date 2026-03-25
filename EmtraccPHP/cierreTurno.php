<?php
require_once 'includes/auth.php';
requireLogin();
require_once 'includes/config.php';

$pageTitle = 'Cierre de Turno';
include 'includes/header.php';
?>

<script>
const APP = {
    turno: <?= json_encode(getTurno()) ?>,
    despachador: <?= json_encode(strtoupper(getUserName())) ?>,
    periodo: <?= json_encode(getPeriodo()) ?>,
    semana: <?= json_encode(getSemana()) ?>
};
</script>

<h5 class="mb-2"><i class="bi bi-clock-history"></i> Cierre de Turno</h5>

<!-- Info -->
<div class="row g-2 mb-2">
    <div class="col-md-3"><span class="badge bg-warning text-dark fs-6">Turno: <span id="infoTurno">-</span></span></div>
    <div class="col-md-3"><span class="badge bg-primary fs-6">Despachador: <span id="infoDesp">-</span></span></div>
    <div class="col-md-3"><span class="badge bg-info fs-6">Periodo: <span id="infoPeriodo">-</span></span></div>
    <div class="col-md-3"><span class="badge bg-secondary fs-6">Fecha: <?= date('d/m/Y') ?></span></div>
</div>

<!-- Resumen -->
<div class="row g-2 mb-2">
    <div class="col-md-4">
        <div class="card bg-dark text-white">
            <div class="card-body text-center py-2">
                <small class="text-muted">Comprobantes</small>
                <h3 id="resComprobantes" class="text-success mb-0">0</h3>
            </div>
        </div>
    </div>
    <div class="col-md-4">
        <div class="card bg-dark text-white">
            <div class="card-body text-center py-2">
                <small class="text-muted">Total Galones</small>
                <h3 id="resGalones" class="text-success mb-0">0.00</h3>
            </div>
        </div>
    </div>
    <div class="col-md-4">
        <div class="card bg-dark text-white">
            <div class="card-body text-center py-2">
                <small class="text-muted">Total Monto</small>
                <h3 id="resMonto" class="text-warning mb-0">L. 0.00</h3>
            </div>
        </div>
    </div>
</div>

<!-- Detalle -->
<div class="table-responsive mb-2" style="max-height:40vh; overflow-y:auto">
    <table class="table table-bordered table-sm table-dark mb-0">
        <thead class="table-secondary sticky-top">
            <tr>
                <th>Comprobante</th><th>Boleta</th><th>Placa</th>
                <th class="text-end">Galones</th><th class="text-end">Total</th><th>Hora</th>
            </tr>
        </thead>
        <tbody id="tbodyDetalle">
            <tr><td colspan="6" class="text-center text-muted">Cargando...</td></tr>
        </tbody>
    </table>
</div>

<!-- Odometro inicio -->
<div class="alert alert-success py-1 mb-1"><strong>Odometro Inicio:</strong> <span id="infoOdoInicio">0.00</span> gal</div>

<!-- Info tanque -->
<div class="alert alert-info py-1 small mb-2" id="infoTanque">Info tanque: -</div>

<!-- Cierre -->
<div class="card bg-dark text-white">
    <div class="card-body py-2">
        <div class="row g-2 align-items-end">
            <div class="col-md-2">
                <label class="form-label text-warning small mb-0">Medicion Tanque (gal)</label>
                <input type="number" step="0.01" id="txtMedicion" class="form-control form-control-lg">
            </div>
            <div class="col-md-2">
                <label class="form-label text-success small mb-0">Odometro Cierre (gal)</label>
                <input type="number" step="0.01" id="txtOdoCierre" class="form-control form-control-lg">
            </div>
            <div class="col-md-4">
                <label class="form-label small mb-0">Observaciones</label>
                <input type="text" id="txtObservaciones" class="form-control">
            </div>
            <div class="col-md-2">
                <button id="btnRefrescar" class="btn btn-outline-info w-100"><i class="bi bi-arrow-clockwise"></i> Refrescar</button>
            </div>
            <div class="col-md-2">
                <button id="btnCerrar" class="btn btn-danger w-100 btn-lg"><i class="bi bi-lock"></i> Cerrar Turno</button>
            </div>
        </div>
    </div>
</div>

<script src="js/cierreTurno.js"></script>

<?php include 'includes/footer.php'; ?>
