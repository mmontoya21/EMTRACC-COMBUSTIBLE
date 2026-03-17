<?php
require_once 'includes/auth.php';
requireLogin();
requirePermiso('comprobante');
require_once 'includes/config.php';

$pageTitle = 'Comprobante';
include 'includes/header.php';
?>

<!-- Variables para JS -->
<script>
const APP = {
    userRole: <?= json_encode(getUserRole()) ?>,
    userName: <?= json_encode(getUserName()) ?>,
    periodo: <?= json_encode(getPeriodo()) ?>,
    semana: <?= json_encode(getSemana()) ?>
};
</script>

<!-- Barra superior: Titulo + Tanque -->
<div class="d-flex justify-content-between align-items-center mb-2 flex-wrap">
    <h5 class="mb-0">Comprobante de Combustible</h5>
    <div>
        <span id="tankBadge" class="badge bg-secondary">Cargando tanque...</span>
        <span id="estadoLabel" class="badge bg-danger ms-2" style="display:none">ANULADO</span>
    </div>
</div>

<!-- Toolbar de botones -->
<div class="btn-toolbar mb-2 gap-1 flex-wrap" role="toolbar">
    <button id="btnNuevo" class="btn btn-success btn-sm"><i class="bi bi-plus-circle"></i> Nuevo</button>
    <button id="btnGuardar" class="btn btn-primary btn-sm" style="display:none"><i class="bi bi-floppy"></i> Guardar</button>
    <button id="btnEditar" class="btn btn-info btn-sm" disabled><i class="bi bi-pencil"></i> Editar</button>
    <button id="btnModificar" class="btn btn-primary btn-sm" style="display:none"><i class="bi bi-check-circle"></i> Modificar</button>
    <button id="btnCancelar" class="btn btn-secondary btn-sm" disabled><i class="bi bi-x-circle"></i> Cancelar</button>
    <?php if (in_array(getUserRole(), ['ADMIN', 'SUPERADMIN'])): ?>
    <button id="btnEliminar" class="btn btn-danger btn-sm" disabled><i class="bi bi-trash"></i> Eliminar</button>
    <?php else: ?>
    <button id="btnEliminar" class="btn btn-danger btn-sm" style="display:none" disabled><i class="bi bi-trash"></i> Eliminar</button>
    <?php endif; ?>
    <button id="btnAnular" class="btn btn-warning btn-sm" disabled><i class="bi bi-slash-circle"></i> Anular</button>
    <button id="btnImprimir" class="btn btn-outline-dark btn-sm" disabled><i class="bi bi-printer"></i> Comprobante</button>
    <button id="btnImprimirDoc" class="btn btn-outline-dark btn-sm" disabled><i class="bi bi-file-earmark-text"></i> Documento</button>
</div>

<!-- Layout principal: Formulario + Tabla -->
<div class="row g-2">
    <!-- FORMULARIO (izquierda en desktop, arriba en mobile) -->
    <div class="col-lg-4 col-xl-3">
        <div class="card">
            <div class="card-header bg-dark text-white py-1 d-flex justify-content-between align-items-center">
                <strong class="small">Datos del Comprobante</strong>
                <button class="btn btn-sm btn-outline-light d-lg-none py-0" type="button"
                        data-bs-toggle="collapse" data-bs-target="#formCollapse">
                    <small>Ver/Ocultar</small>
                </button>
            </div>
            <div id="formCollapse" class="collapse show">
                <div class="card-body p-2" id="formPanel">
                    <input type="hidden" id="idcprbnt">

                    <div class="row g-1 mb-1">
                        <div class="col-6">
                            <label class="form-label small mb-0">No. Comprobante</label>
                            <input type="text" id="nCompro" class="form-control form-control-sm fw-bold text-primary" readonly>
                        </div>
                        <div class="col-6">
                            <label class="form-label small mb-0">No. Boleta</label>
                            <input type="text" id="nBoleta" class="form-control form-control-sm" maxlength="10" disabled>
                        </div>
                    </div>

                    <div class="row g-1 mb-1">
                        <div class="col-4">
                            <label class="form-label small mb-0">Galones</label>
                            <input type="number" id="galDesp" class="form-control form-control-sm" step="0.01" min="0" disabled>
                        </div>
                        <div class="col-4">
                            <label class="form-label small mb-0">Valor</label>
                            <input type="number" id="valor" class="form-control form-control-sm" step="0.01" min="0" disabled>
                        </div>
                        <div class="col-4">
                            <label class="form-label small mb-0">Total</label>
                            <div id="totalDisplay" class="form-control form-control-sm bg-light fw-bold text-success">L. 0.00</div>
                        </div>
                    </div>

                    <hr class="my-1">

                    <div class="mb-1" style="position:relative">
                        <label class="form-label small mb-0">Placa Cabezal</label>
                        <input type="text" id="placaCbz" class="form-control form-control-sm fw-bold" maxlength="25" style="font-size:1.1rem; color:#d4a017;" disabled>
                    </div>

                    <div class="mb-1" style="position:relative">
                        <label class="form-label small mb-0">Codigo Propietario</label>
                        <input type="text" id="codiProp" class="form-control form-control-sm" maxlength="25" style="color:#d4a017;" disabled>
                        <div id="placasList" class="autocomplete-dropdown" style="display:none"></div>
                    </div>

                    <div class="mb-1">
                        <label class="form-label small mb-0">Propietario</label>
                        <input type="text" id="propCbz" class="form-control form-control-sm bg-light" maxlength="80" readonly>
                    </div>

                    <div class="mb-1">
                        <label class="form-label small mb-0">Contenedor</label>
                        <input type="text" id="nConte" class="form-control form-control-sm" maxlength="10" disabled>
                    </div>

                    <div class="mb-1" style="position:relative">
                        <label class="form-label small mb-0">Ruta</label>
                        <input type="text" id="ruta" class="form-control form-control-sm" maxlength="80" disabled>
                    </div>

                    <div class="mb-1" style="position:relative">
                        <label class="form-label small mb-0">Conductor</label>
                        <input type="text" id="nombCond" class="form-control form-control-sm" maxlength="80" disabled>
                    </div>

                    <div class="mb-1">
                        <label class="form-label small mb-0">Despachador</label>
                        <input type="text" id="nombDesp" class="form-control form-control-sm bg-light" maxlength="80" readonly>
                    </div>

                    <hr class="my-1">

                    <div class="row g-1 mb-1">
                        <div class="col-6">
                            <label class="form-label small mb-0">Fecha</label>
                            <input type="date" id="fecha" class="form-control form-control-sm" disabled>
                        </div>
                        <div class="col-3">
                            <label class="form-label small mb-0">Periodo</label>
                            <input type="text" id="periodo" class="form-control form-control-sm bg-light" readonly>
                        </div>
                        <div class="col-3">
                            <label class="form-label small mb-0">Semana</label>
                            <input type="text" id="semana" class="form-control form-control-sm bg-light" readonly>
                        </div>
                    </div>

                    <div class="mb-1">
                        <label class="form-label small mb-0">Prox. Semana</label>
                        <select id="proxSem" class="form-select form-select-sm" disabled>
                            <option value="NO">NO</option>
                            <option value="SI">SI</option>
                        </select>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <!-- TABLA (derecha en desktop, abajo en mobile) -->
    <div class="col-lg-8 col-xl-9">
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
                        <div class="col-6 col-md-auto">
                            <label class="form-label small mb-0">Placa</label>
                            <input type="text" id="filtroPlaca" class="form-control form-control-sm filtro-input" placeholder="Buscar placa...">
                        </div>
                        <div class="col-6 col-md-auto">
                            <label class="form-label small mb-0">Boleta</label>
                            <input type="text" id="filtroBoleta" class="form-control form-control-sm filtro-input" placeholder="Buscar boleta...">
                        </div>
                        <div class="col-6 col-md-auto">
                            <label class="form-label small mb-0">Desde</label>
                            <input type="date" id="filtroFechaDesde" class="form-control form-control-sm filtro-input">
                        </div>
                        <div class="col-6 col-md-auto">
                            <label class="form-label small mb-0">Hasta</label>
                            <input type="date" id="filtroFechaHasta" class="form-control form-control-sm filtro-input">
                        </div>
                        <div class="col-6 col-md-auto">
                            <label class="form-label small mb-0">Despachador</label>
                            <select id="filtroDespachador" class="form-select form-select-sm filtro-input">
                                <option value="">Todos</option>
                            </select>
                        </div>
                        <div class="col-6 col-md-auto d-flex gap-1">
                            <button id="btnBuscar" class="btn btn-primary btn-sm"><i class="bi bi-search"></i> Buscar</button>
                            <button id="btnLimpiarFiltros" class="btn btn-outline-secondary btn-sm"><i class="bi bi-eraser"></i> Limpiar</button>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <!-- Resumen -->
        <div class="d-flex flex-wrap gap-2 mb-2">
            <span class="badge bg-primary">Registros: <span id="resumenTotal">0</span></span>
            <span class="badge bg-danger">Anulados: <span id="resumenAnulados">0</span></span>
            <span class="badge bg-info text-dark">Galones: <span id="resumenGalones">0.00</span></span>
            <span class="badge bg-success">Total: L. <span id="resumenMonto">0.00</span></span>
        </div>

        <!-- Tabla -->
        <div class="table-responsive" style="max-height: 65vh; overflow-y: auto;">
            <table class="table table-bordered table-sm table-hover mb-0" id="tblComprobantes">
                <thead class="table-dark sticky-top">
                    <tr>
                        <th>Compro</th>
                        <th>Boleta</th>
                        <th>Fecha</th>
                        <th class="d-none d-md-table-cell">Despachador</th>
                        <th class="d-none d-lg-table-cell">Propietario</th>
                        <th>Placa</th>
                        <th class="d-none d-md-table-cell">Per</th>
                        <th class="d-none d-md-table-cell">Sem</th>
                        <th class="d-none d-xl-table-cell">Ruta</th>
                        <th>Galones</th>
                        <th class="d-none d-lg-table-cell">Total</th>
                        <th>Estado</th>
                    </tr>
                </thead>
                <tbody id="tbodyComprobantes">
                    <tr><td colspan="12" class="text-center text-muted">Cargando...</td></tr>
                </tbody>
            </table>
        </div>

        <!-- Paginacion -->
        <nav class="mt-2" id="paginacion"></nav>
    </div>
</div>

<script src="js/comprobante.js"></script>

<?php include 'includes/footer.php'; ?>
