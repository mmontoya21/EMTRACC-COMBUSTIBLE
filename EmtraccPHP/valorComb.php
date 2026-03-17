<?php
require_once 'includes/auth.php';
requireLogin();
requirePermiso('valorComb');
require_once 'includes/config.php';

$pageTitle = 'Valor Combustible';
include 'includes/header.php';
?>

<script>
const APP = {
    userRole: <?= json_encode(getUserRole()) ?>,
    userName: <?= json_encode(getUserName()) ?>
};
</script>

<h5 class="mb-2"><i class="bi bi-currency-dollar"></i> Valor Combustible <span id="precioActualBadge" class="badge bg-secondary ms-2">Cargando...</span></h5>

<!-- Toolbar -->
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
</div>

<!-- Layout principal -->
<div class="row g-2">
    <!-- FORMULARIO -->
    <div class="col-lg-4 col-xl-3">
        <div class="card">
            <div class="card-header bg-dark text-white py-1 d-flex justify-content-between align-items-center">
                <strong class="small">Datos del Precio</strong>
                <button class="btn btn-sm btn-outline-light d-lg-none py-0" type="button"
                        data-bs-toggle="collapse" data-bs-target="#formCollapse">
                    <small>Ver/Ocultar</small>
                </button>
            </div>
            <div id="formCollapse" class="collapse show">
                <div class="card-body p-2" id="formPanel">
                    <input type="hidden" id="valorId">

                    <div class="mb-2">
                        <label class="form-label small mb-0">Precio <span class="text-danger">*</span></label>
                        <input type="text" id="valorCombustible" class="form-control form-control-sm" maxlength="10" disabled>
                    </div>

                    <div class="mb-2">
                        <label class="form-label small mb-0">Fecha <span class="text-danger">*</span></label>
                        <input type="date" id="fecha" class="form-control form-control-sm" disabled>
                    </div>

                    <div class="mb-2">
                        <label class="form-label small mb-0">Descripci&oacute;n</label>
                        <input type="text" id="descripcion" class="form-control form-control-sm" maxlength="200" disabled>
                    </div>

                    <div class="mb-1">
                        <div class="form-check">
                            <input type="checkbox" id="activo" class="form-check-input" checked disabled>
                            <label class="form-check-label small" for="activo">Activo</label>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <!-- TABLA -->
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
                        <div class="col-5 col-md-3">
                            <label class="form-label small mb-0">Desde</label>
                            <input type="date" id="filtroFechaDesde" class="form-control form-control-sm">
                        </div>
                        <div class="col-5 col-md-3">
                            <label class="form-label small mb-0">Hasta</label>
                            <input type="date" id="filtroFechaHasta" class="form-control form-control-sm">
                        </div>
                        <div class="col-2 col-md-auto d-flex gap-1">
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
        </div>

        <!-- Tabla -->
        <div class="table-responsive" style="max-height: 65vh; overflow-y: auto;">
            <table class="table table-bordered table-sm table-hover mb-0" id="tblValorComb">
                <thead class="table-dark sticky-top">
                    <tr>
                        <th style="width:60px">ID</th>
                        <th style="width:100px" class="text-end">Precio</th>
                        <th style="width:100px">Fecha</th>
                        <th>Descripci&oacute;n</th>
                        <th style="width:80px" class="text-center">Estado</th>
                    </tr>
                </thead>
                <tbody id="tbodyValorComb">
                    <tr><td colspan="5" class="text-center text-muted">Cargando...</td></tr>
                </tbody>
            </table>
        </div>

        <!-- Paginacion -->
        <nav class="mt-2" id="paginacion"></nav>
    </div>
</div>

<script src="js/valorComb.js"></script>

<?php include 'includes/footer.php'; ?>
