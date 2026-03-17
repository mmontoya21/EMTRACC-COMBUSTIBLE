<?php
require_once 'includes/auth.php';
requireLogin();
requirePermiso('rutas');
require_once 'includes/config.php';

$pageTitle = 'Rutas';
include 'includes/header.php';
?>

<script>
const APP = {
    userRole: <?= json_encode(getUserRole()) ?>,
    userName: <?= json_encode(getUserName()) ?>
};
</script>

<h5 class="mb-2"><i class="bi bi-signpost-2"></i> Cat&aacute;logo de Rutas</h5>

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
                <strong class="small">Datos de la Ruta</strong>
                <button class="btn btn-sm btn-outline-light d-lg-none py-0" type="button"
                        data-bs-toggle="collapse" data-bs-target="#formCollapse">
                    <small>Ver/Ocultar</small>
                </button>
            </div>
            <div id="formCollapse" class="collapse show">
                <div class="card-body p-2" id="formPanel">
                    <input type="hidden" id="rutaId">

                    <div class="mb-2">
                        <label class="form-label small mb-0">Ruta <span class="text-danger">*</span></label>
                        <input type="text" id="rutas" class="form-control form-control-sm" maxlength="200" disabled>
                    </div>

                    <div class="mb-1">
                        <label class="form-label small mb-0">Kil&oacute;metros</label>
                        <input type="text" id="kilom" class="form-control form-control-sm" maxlength="6" disabled>
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
                        <div class="col-8 col-md-5">
                            <label class="form-label small mb-0">Ruta</label>
                            <input type="text" id="filtroRuta" class="form-control form-control-sm" placeholder="Buscar ruta...">
                        </div>
                        <div class="col-4 col-md-auto d-flex gap-1">
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
            <table class="table table-bordered table-sm table-hover mb-0" id="tblRutas">
                <thead class="table-dark sticky-top">
                    <tr>
                        <th style="width:60px">ID</th>
                        <th>Ruta</th>
                        <th style="width:100px" class="text-end">Kil&oacute;metros</th>
                    </tr>
                </thead>
                <tbody id="tbodyRutas">
                    <tr><td colspan="3" class="text-center text-muted">Cargando...</td></tr>
                </tbody>
            </table>
        </div>

        <!-- Paginacion -->
        <nav class="mt-2" id="paginacion"></nav>
    </div>
</div>

<script src="js/rutas.js"></script>

<?php include 'includes/footer.php'; ?>
