<?php
require_once 'includes/auth.php';
requireLogin();
requirePermiso('propietario');
require_once 'includes/config.php';

$pageTitle = 'Propietarios';
include 'includes/header.php';
?>

<script>
const APP = {
    userRole: <?= json_encode(getUserRole()) ?>,
    userName: <?= json_encode(getUserName()) ?>
};
</script>

<h5 class="mb-2">Cat&aacute;logo de Propietarios</h5>

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
                <strong class="small">Datos del Propietario</strong>
                <button class="btn btn-sm btn-outline-light d-lg-none py-0" type="button"
                        data-bs-toggle="collapse" data-bs-target="#formCollapse">
                    <small>Ver/Ocultar</small>
                </button>
            </div>
            <div id="formCollapse" class="collapse show">
                <div class="card-body p-2" id="formPanel">
                    <input type="hidden" id="codigoP">

                    <div class="mb-1">
                        <label class="form-label small mb-0">C&oacute;digo Propietario <span class="text-danger">*</span></label>
                        <input type="text" id="codProp" class="form-control form-control-sm fw-bold" maxlength="10" style="color:#d4a017;" disabled>
                    </div>

                    <div class="mb-1">
                        <label class="form-label small mb-0">Nombre Propietario <span class="text-danger">*</span></label>
                        <input type="text" id="nPropietario" class="form-control form-control-sm" maxlength="80" disabled>
                    </div>

                    <div class="mb-1">
                        <label class="form-label small mb-0">Empresa</label>
                        <input type="text" id="nEmpresa" class="form-control form-control-sm" maxlength="80" disabled>
                    </div>

                    <div class="mb-1">
                        <label class="form-label small mb-0">RTN</label>
                        <input type="text" id="RTN" class="form-control form-control-sm" maxlength="15" disabled>
                    </div>

                    <div class="row g-1 mb-1">
                        <div class="col-6">
                            <label class="form-label small mb-0">Tel&eacute;fono 1</label>
                            <input type="text" id="tel1" class="form-control form-control-sm" maxlength="12" disabled>
                        </div>
                        <div class="col-6">
                            <label class="form-label small mb-0">Tel&eacute;fono 2</label>
                            <input type="text" id="tel2" class="form-control form-control-sm" maxlength="12" disabled>
                        </div>
                    </div>

                    <div class="mb-1">
                        <label class="form-label small mb-0">Direcci&oacute;n</label>
                        <textarea id="direccion" class="form-control form-control-sm" maxlength="300" rows="2" disabled></textarea>
                    </div>

                    <div class="mb-1">
                        <label class="form-label small mb-0">Correo Electr&oacute;nico</label>
                        <input type="email" id="correoE" class="form-control form-control-sm" maxlength="50" disabled>
                    </div>
                </div>
            </div>
        </div>

        <!-- Sub-panel: Placas del propietario -->
        <div class="card mt-2" id="placasCard" style="display:none">
            <div class="card-header bg-secondary text-white py-1">
                <strong class="small">Placas Vinculadas</strong>
            </div>
            <div class="card-body p-0">
                <div class="table-responsive" style="max-height:200px; overflow-y:auto;">
                    <table class="table table-bordered table-sm mb-0">
                        <thead class="table-light">
                            <tr>
                                <th>Placa</th>
                                <th>Estado</th>
                            </tr>
                        </thead>
                        <tbody id="tbodyPlacas">
                            <tr><td colspan="2" class="text-center text-muted small">Seleccione un propietario</td></tr>
                        </tbody>
                    </table>
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
                            <label class="form-label small mb-0">C&oacute;digo</label>
                            <input type="text" id="filtroCodigo" class="form-control form-control-sm filtro-input" placeholder="Buscar c&oacute;digo...">
                        </div>
                        <div class="col-5 col-md-4">
                            <label class="form-label small mb-0">Propietario</label>
                            <input type="text" id="filtroPropietario" class="form-control form-control-sm filtro-input" placeholder="Buscar propietario...">
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
            <table class="table table-bordered table-sm table-hover mb-0" id="tblPropietarios">
                <thead class="table-dark sticky-top">
                    <tr>
                        <th>C&oacute;digo</th>
                        <th>Propietario</th>
                        <th class="d-none d-md-table-cell">Empresa</th>
                        <th class="d-none d-md-table-cell">RTN</th>
                        <th class="d-none d-lg-table-cell">Tel&eacute;fono 1</th>
                        <th class="d-none d-xl-table-cell">Tel&eacute;fono 2</th>
                    </tr>
                </thead>
                <tbody id="tbodyPropietarios">
                    <tr><td colspan="6" class="text-center text-muted">Cargando...</td></tr>
                </tbody>
            </table>
        </div>

        <!-- Paginacion -->
        <nav class="mt-2" id="paginacion"></nav>
    </div>
</div>

<script src="js/propietario.js"></script>

<?php include 'includes/footer.php'; ?>
