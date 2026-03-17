<?php
require_once 'includes/auth.php';
requireLogin();
requirePermiso('factura');
require_once 'includes/config.php';

$pageTitle = 'Factura';
include 'includes/header.php';
?>

<!-- Variables para JS -->
<script>
const APP = {
    userRole: <?= json_encode(getUserRole()) ?>,
    userName: <?= json_encode(getUserName()) ?>
};
</script>

<h5 class="mb-2">Factura</h5>

<!-- Toolbar de botones -->
<div class="btn-toolbar mb-2 gap-1 flex-wrap" role="toolbar">
    <button id="btnNuevo" class="btn btn-success btn-sm"><i class="bi bi-plus-circle"></i> Nuevo</button>
    <button id="btnGuardar" class="btn btn-primary btn-sm" style="display:none"><i class="bi bi-floppy"></i> Guardar</button>
    <button id="btnEditar" class="btn btn-info btn-sm" disabled><i class="bi bi-pencil"></i> Editar</button>
    <button id="btnModificar" class="btn btn-primary btn-sm" style="display:none"><i class="bi bi-check-circle"></i> Modificar</button>
    <button id="btnCancelar" class="btn btn-secondary btn-sm" disabled><i class="bi bi-x-circle"></i> Cancelar</button>
    <button id="btnEliminar" class="btn btn-danger btn-sm" disabled><i class="bi bi-trash"></i> Eliminar</button>
</div>

<!-- Tabs: Factura / Reporte -->
<ul class="nav nav-tabs mb-2" id="facturaTab" role="tablist">
    <li class="nav-item" role="presentation">
        <button class="nav-link active" id="tab-factura" data-bs-toggle="tab" data-bs-target="#pane-factura" type="button" role="tab">
            <i class="bi bi-receipt"></i> Factura
        </button>
    </li>
    <li class="nav-item" role="presentation">
        <button class="nav-link" id="tab-reporte" data-bs-toggle="tab" data-bs-target="#pane-reporte" type="button" role="tab">
            <i class="bi bi-file-earmark-bar-graph"></i> Reporte Comprobantes
        </button>
    </li>
</ul>

<div class="tab-content">
<!-- ==================== TAB FACTURA ==================== -->
<div class="tab-pane fade show active" id="pane-factura" role="tabpanel">
<div class="row g-2">
    <!-- FORMULARIO -->
    <div class="col-lg-5 col-xl-4">
        <div class="card">
            <div class="card-header bg-dark text-white py-1">
                <strong class="small">Datos de la Factura</strong>
            </div>
            <div class="card-body p-2" id="formPanel">
                <input type="hidden" id="idFactura">

                <!-- Buscar Propietario por Codigo -->
                <div class="row g-1 mb-1">
                    <div class="col-5">
                        <label class="form-label small mb-0">Cod. Propietario</label>
                        <div class="input-group input-group-sm">
                            <input type="text" id="codBusq" class="form-control form-control-sm" placeholder="Buscar..." disabled>
                            <button id="btnBuscarProp" class="btn btn-outline-primary btn-sm" type="button" disabled><i class="bi bi-search"></i></button>
                        </div>
                    </div>
                    <div class="col-4">
                        <label class="form-label small mb-0">N&deg; Factura</label>
                        <input type="text" id="nFactura" class="form-control form-control-sm fw-bold text-primary" readonly>
                    </div>
                    <div class="col-3">
                        <label class="form-label small mb-0">Tipo Pago</label>
                        <select id="tipoPag" class="form-select form-select-sm" disabled>
                            <option value="CONTADO">CONTADO</option>
                            <option value="CREDITO">CREDITO</option>
                        </select>
                    </div>
                </div>

                <div class="mb-1">
                    <label class="form-label small mb-0">Empresa</label>
                    <input type="text" id="empresa" class="form-control form-control-sm bg-light" readonly>
                </div>
                <div class="mb-1">
                    <label class="form-label small mb-0">Propietario</label>
                    <input type="text" id="propietario" class="form-control form-control-sm bg-light" readonly>
                </div>
                <div class="row g-1 mb-1">
                    <div class="col-6">
                        <label class="form-label small mb-0">RTN</label>
                        <input type="text" id="rtn" class="form-control form-control-sm bg-light" readonly>
                    </div>
                    <div class="col-6">
                        <label class="form-label small mb-0">Cod. Prop</label>
                        <input type="text" id="codProp" class="form-control form-control-sm bg-light" readonly>
                    </div>
                </div>

                <div class="row g-1 mb-1">
                    <div class="col-6">
                        <label class="form-label small mb-0">Fecha</label>
                        <input type="date" id="fecha" class="form-control form-control-sm" disabled>
                    </div>
                    <div class="col-3">
                        <label class="form-label small mb-0">Periodo</label>
                        <input type="text" id="perMes" class="form-control form-control-sm" maxlength="15" disabled>
                    </div>
                    <div class="col-3">
                        <label class="form-label small mb-0">Semana</label>
                        <input type="text" id="perSem" class="form-control form-control-sm" maxlength="10" disabled>
                    </div>
                </div>

                <hr class="my-1">
                <p class="small fw-bold mb-1">Detalle de productos</p>

                <!-- Linea 1 -->
                <div class="row g-1 mb-1">
                    <div class="col-3">
                        <label class="form-label small mb-0">Cantd 1</label>
                        <input type="number" id="cantd1" class="form-control form-control-sm calc-input" step="0.01" min="0" disabled>
                    </div>
                    <div class="col-3">
                        <label class="form-label small mb-0">Descrip 1</label>
                        <input type="text" id="descrip1" class="form-control form-control-sm" maxlength="80" disabled>
                    </div>
                    <div class="col-3">
                        <label class="form-label small mb-0">P. Unit 1</label>
                        <input type="number" id="preUni1" class="form-control form-control-sm calc-input" step="0.01" min="0" disabled>
                    </div>
                    <div class="col-3">
                        <label class="form-label small mb-0">Total 1</label>
                        <input type="text" id="total1" class="form-control form-control-sm bg-light fw-bold" readonly>
                    </div>
                </div>

                <!-- Linea 2 -->
                <div class="row g-1 mb-1">
                    <div class="col-3">
                        <label class="form-label small mb-0">Cantd 2</label>
                        <input type="number" id="cantd2" class="form-control form-control-sm calc-input" step="0.01" min="0" disabled>
                    </div>
                    <div class="col-3">
                        <label class="form-label small mb-0">Descrip 2</label>
                        <input type="text" id="descrip2" class="form-control form-control-sm" maxlength="80" disabled>
                    </div>
                    <div class="col-3">
                        <label class="form-label small mb-0">P. Unit 2</label>
                        <input type="number" id="preUni2" class="form-control form-control-sm calc-input" step="0.01" min="0" disabled>
                    </div>
                    <div class="col-3">
                        <label class="form-label small mb-0">Total 2</label>
                        <input type="text" id="total2" class="form-control form-control-sm bg-light fw-bold" readonly>
                    </div>
                </div>

                <hr class="my-1">

                <div class="row g-1 mb-1">
                    <div class="col-4">
                        <label class="form-label small mb-0">Cantidad</label>
                        <input type="text" id="facCantidad" class="form-control form-control-sm bg-light fw-bold" readonly>
                    </div>
                    <div class="col-4">
                        <label class="form-label small mb-0">Exento</label>
                        <input type="text" id="facExe" class="form-control form-control-sm bg-light" readonly>
                    </div>
                    <div class="col-4">
                        <label class="form-label small mb-0">TOTAL</label>
                        <input type="text" id="facTotal" class="form-control form-control-sm bg-success text-white fw-bold" readonly>
                    </div>
                </div>

                <div class="mb-1">
                    <label class="form-label small mb-0">En letras</label>
                    <input type="text" id="pLetras" class="form-control form-control-sm bg-light" readonly>
                </div>

                <div class="mb-1">
                    <label class="form-label small mb-0">Observaciones</label>
                    <textarea id="comentario" class="form-control form-control-sm" rows="2" disabled></textarea>
                </div>
                <div class="mb-1">
                    <label class="form-label small mb-0">Detalle entrega combustible</label>
                    <textarea id="comentario2" class="form-control form-control-sm" rows="3" disabled></textarea>
                </div>
            </div>
        </div>
    </div>

    <!-- TABLA FACTURAS -->
    <div class="col-lg-7 col-xl-8">
        <!-- Filtros -->
        <div class="card mb-2">
            <div class="card-header bg-secondary text-white py-1">
                <strong class="small">Filtros</strong>
            </div>
            <div class="card-body p-2">
                <div class="row g-1 align-items-end">
                    <div class="col-6 col-md-auto">
                        <label class="form-label small mb-0">Cod. Prop</label>
                        <input type="text" id="filtroCodProp" class="form-control form-control-sm filtro-input" placeholder="Buscar...">
                    </div>
                    <div class="col-6 col-md-auto">
                        <label class="form-label small mb-0">Desde</label>
                        <input type="date" id="filtroFechaDesde" class="form-control form-control-sm filtro-input">
                    </div>
                    <div class="col-6 col-md-auto">
                        <label class="form-label small mb-0">Hasta</label>
                        <input type="date" id="filtroFechaHasta" class="form-control form-control-sm filtro-input">
                    </div>
                    <div class="col-6 col-md-auto d-flex gap-1">
                        <button id="btnBuscar" class="btn btn-primary btn-sm"><i class="bi bi-search"></i> Buscar</button>
                        <button id="btnLimpiarFiltros" class="btn btn-outline-secondary btn-sm"><i class="bi bi-eraser"></i></button>
                    </div>
                </div>
            </div>
        </div>

        <div class="d-flex flex-wrap gap-2 mb-2">
            <span class="badge bg-primary">Registros: <span id="resumenTotal">0</span></span>
        </div>

        <div class="table-responsive" style="max-height: 65vh; overflow-y: auto;">
            <table class="table table-bordered table-sm table-hover mb-0" id="tblFacturas">
                <thead class="table-dark sticky-top">
                    <tr>
                        <th>Cod. Prop</th>
                        <th>Empresa</th>
                        <th>Propietario</th>
                        <th>N&deg; Factura</th>
                        <th>Fecha</th>
                    </tr>
                </thead>
                <tbody id="tbodyFacturas">
                    <tr><td colspan="5" class="text-center text-muted">Cargando...</td></tr>
                </tbody>
            </table>
        </div>

        <nav class="mt-2" id="paginacion"></nav>
    </div>
</div>
</div>

<!-- ==================== TAB REPORTE ==================== -->
<div class="tab-pane fade" id="pane-reporte" role="tabpanel">
    <!-- Filtros de reporte -->
    <div class="card mb-2">
        <div class="card-header bg-secondary text-white py-1">
            <strong class="small">Filtros de Reporte</strong>
        </div>
        <div class="card-body p-2">
            <div class="row g-1 align-items-end">
                <div class="col-auto">
                    <div class="form-check form-check-inline mt-3">
                        <input class="form-check-input" type="checkbox" id="chkUsarFechaR">
                        <label class="form-check-label small" for="chkUsarFechaR">Filtrar fechas</label>
                    </div>
                </div>
                <div class="col-6 col-md-auto">
                    <label class="form-label small mb-0">Desde</label>
                    <input type="date" id="fechaDesdeR" class="form-control form-control-sm" disabled>
                </div>
                <div class="col-6 col-md-auto">
                    <label class="form-label small mb-0">Hasta</label>
                    <input type="date" id="fechaHastaR" class="form-control form-control-sm" disabled>
                </div>
                <div class="col-6 col-md-auto">
                    <label class="form-label small mb-0">Cod. Cliente</label>
                    <input type="text" id="codClienteR" class="form-control form-control-sm">
                </div>
                <div class="col-6 col-md-auto">
                    <label class="form-label small mb-0">Placa</label>
                    <input type="text" id="placaR" class="form-control form-control-sm">
                </div>
                <div class="col-6 col-md-auto">
                    <label class="form-label small mb-0">Boleta</label>
                    <input type="text" id="boletaR" class="form-control form-control-sm">
                </div>
                <div class="col-auto d-flex gap-1">
                    <button id="btnBuscarR" class="btn btn-primary btn-sm"><i class="bi bi-search"></i> Buscar</button>
                    <button id="btnLimpiarR" class="btn btn-outline-secondary btn-sm"><i class="bi bi-eraser"></i></button>
                    <button id="btnExportarR" class="btn btn-success btn-sm"><i class="bi bi-file-earmark-excel"></i> Excel</button>
                </div>
            </div>
        </div>
    </div>

    <div class="d-flex flex-wrap gap-2 mb-2">
        <span class="badge bg-primary">Registros: <span id="lblTotalR">0</span></span>
    </div>

    <div class="table-responsive" style="max-height: 65vh; overflow-y: auto;">
        <table class="table table-bordered table-sm mb-0" id="tblReporte">
            <thead class="table-dark sticky-top">
                <tr>
                    <th>Fecha</th>
                    <th>Placa</th>
                    <th>Contenedor</th>
                    <th class="text-end">Galones</th>
                    <th class="text-end">Total</th>
                    <th>Cod. Cliente</th>
                    <th>Boletas</th>
                    <th>Periodo</th>
                    <th>Semana</th>
                    <th class="text-end">Valor</th>
                </tr>
            </thead>
            <tbody id="tbodyReporte">
                <tr><td colspan="10" class="text-center text-muted">Use los filtros para cargar datos</td></tr>
            </tbody>
        </table>
    </div>
</div>
</div>

<script src="js/factura.js"></script>

<?php include 'includes/footer.php'; ?>
