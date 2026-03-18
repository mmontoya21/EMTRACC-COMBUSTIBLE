<?php
require_once 'includes/auth.php';
requireLogin();
requirePermiso('factura');
require_once 'includes/config.php';

$pageTitle = 'Reporte Facturas';
include 'includes/header.php';
?>

<script>
const APP = {
    userRole: <?= json_encode(getUserRole()) ?>,
    userName: <?= json_encode(getUserName()) ?>,
    periodo: <?= json_encode(getPeriodo()) ?>,
    semana: <?= json_encode(getSemana()) ?>
};
</script>

<h5 class="mb-2"><i class="bi bi-file-earmark-bar-graph"></i> Reporte de Facturas</h5>

<!-- Filtros -->
<div class="card mb-2">
    <div class="card-header bg-secondary text-white py-1 d-flex justify-content-between align-items-center">
        <strong class="small">Filtros</strong>
        <button class="btn btn-sm btn-outline-light d-md-none py-0" type="button"
                data-bs-toggle="collapse" data-bs-target="#filtrosCollapse">
            <small>Ver/Ocultar</small>
        </button>
    </div>
    <div id="filtrosCollapse" class="collapse show">
        <div class="card-body p-2">
            <div class="row g-1 align-items-end">
                <div class="col-auto">
                    <div class="form-check mt-3">
                        <input type="checkbox" id="chkUsarFecha" class="form-check-input">
                        <label class="form-check-label small" for="chkUsarFecha">Fecha</label>
                    </div>
                </div>
                <div class="col-5 col-md-2">
                    <label class="form-label small mb-0">Desde</label>
                    <input type="date" id="fechaDesde" class="form-control form-control-sm" disabled>
                </div>
                <div class="col-5 col-md-2">
                    <label class="form-label small mb-0">Hasta</label>
                    <input type="date" id="fechaHasta" class="form-control form-control-sm" disabled>
                </div>
                <div class="col-6 col-md-2">
                    <label class="form-label small mb-0">Cod. Cliente</label>
                    <input type="text" id="filtroCodCliente" class="form-control form-control-sm" maxlength="50">
                </div>
                <div class="col-6 col-md-2">
                    <label class="form-label small mb-0">Placa</label>
                    <input type="text" id="filtroPlaca" class="form-control form-control-sm" maxlength="20">
                </div>
                <div class="col-6 col-md-2">
                    <label class="form-label small mb-0">Boleta</label>
                    <input type="text" id="filtroBoleta" class="form-control form-control-sm" maxlength="20">
                </div>
            </div>
            <div class="mt-2 d-flex gap-1 flex-wrap">
                <button id="btnBuscar" class="btn btn-primary btn-sm"><i class="bi bi-search"></i> Buscar</button>
                <button id="btnOrdenar" class="btn btn-outline-info btn-sm"><i class="bi bi-sort-alpha-down"></i> Agrupar por Cliente</button>
                <button id="btnLimpiar" class="btn btn-outline-secondary btn-sm"><i class="bi bi-eraser"></i> Limpiar</button>
                <button id="btnExportarCSV" class="btn btn-outline-success btn-sm"><i class="bi bi-filetype-csv"></i> Exportar CSV</button>
                <button id="btnExportarExcel" class="btn btn-success btn-sm"><i class="bi bi-file-earmark-excel"></i> Exportar Excel</button>
            </div>
        </div>
    </div>
</div>

<!-- Resumen -->
<div class="d-flex flex-wrap gap-2 mb-2">
    <span class="badge bg-primary">Registros: <span id="resumenTotal">0</span></span>
    <span class="badge bg-info">Galones: <span id="resumenGalones">0.00</span></span>
    <span class="badge bg-warning text-dark">Total: L <span id="resumenMonto">0.00</span></span>
</div>

<!-- Tabla -->
<div class="table-responsive" style="max-height: 70vh; overflow-y: auto;">
    <table class="table table-bordered table-sm mb-0" id="tblReporte">
        <thead class="table-dark sticky-top">
            <tr>
                <th style="width:90px" class="text-center">Comprobante</th>
                <th style="width:80px" class="text-center">Boleta</th>
                <th style="width:90px" class="text-center">Fecha</th>
                <th style="width:90px">Placa</th>
                <th style="width:110px">Contenedor</th>
                <th style="width:90px" class="text-end">Galones</th>
                <th style="width:90px" class="text-end">Total</th>
                <th style="width:100px">Cod. Cliente</th>
                <th style="width:70px" class="text-center">Periodo</th>
                <th style="width:70px" class="text-center">Semana</th>
                <th style="width:80px" class="text-end">Valor</th>
            </tr>
        </thead>
        <tbody id="tbodyReporte">
            <tr><td colspan="11" class="text-center text-muted">Use los filtros para buscar datos</td></tr>
        </tbody>
    </table>
</div>

<script src="js/reporteFact.js"></script>

<?php include 'includes/footer.php'; ?>
