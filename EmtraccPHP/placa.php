<?php
require_once 'includes/auth.php';
requireLogin();
requirePermiso('placa');
require_once 'includes/config.php';

$pageTitle = 'Placas';
include 'includes/header.php';
?>

<script>
const APP = {
    userRole: <?= json_encode(getUserRole()) ?>,
    userName: <?= json_encode(getUserName()) ?>
};
</script>

<h5 class="mb-2">Cat&aacute;logo de Placas</h5>

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
    <button id="btnBloquear" class="btn btn-warning btn-sm" disabled><i class="bi bi-lock"></i> Bloquear</button>
</div>

<!-- Layout principal -->
<div class="row g-2">
    <!-- FORMULARIO -->
    <div class="col-lg-4 col-xl-3">
        <div class="card">
            <div class="card-header bg-dark text-white py-1 d-flex justify-content-between align-items-center">
                <strong class="small">Datos de la Placa</strong>
                <span id="estadoBadge" class="badge bg-secondary" style="display:none"></span>
            </div>
            <div id="formCollapse" class="collapse show">
                <div class="card-body p-2" id="formPanel">
                    <input type="hidden" id="idPlaca">

                    <div class="mb-1" style="position:relative">
                        <label class="form-label small mb-0">C&oacute;digo Propietario</label>
                        <input type="text" id="codigoPro" class="form-control form-control-sm fw-bold" maxlength="6" style="color:#d4a017;" disabled>
                    </div>

                    <div class="mb-1" style="position:relative">
                        <label class="form-label small mb-0">Propietario</label>
                        <input type="text" id="propietario" class="form-control form-control-sm" maxlength="30" disabled>
                    </div>

                    <div class="mb-1">
                        <label class="form-label small mb-0">Placa <span class="text-danger">*</span></label>
                        <input type="text" id="placa" class="form-control form-control-sm fw-bold" maxlength="15" style="font-size:1.1rem; color:#d4a017;" disabled>
                    </div>

                    <div class="mb-1">
                        <label class="form-label small mb-0">Observaciones</label>
                        <textarea id="observaciones" class="form-control form-control-sm" maxlength="200" rows="2" disabled></textarea>
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
                        <div class="col-6 col-md-2">
                            <label class="form-label small mb-0">C&oacute;digo</label>
                            <input type="text" id="filtroCodigo" class="form-control form-control-sm filtro-input" placeholder="C&oacute;digo...">
                        </div>
                        <div class="col-6 col-md-3">
                            <label class="form-label small mb-0">Propietario</label>
                            <input type="text" id="filtroPropietario" class="form-control form-control-sm filtro-input" placeholder="Propietario...">
                        </div>
                        <div class="col-6 col-md-2">
                            <label class="form-label small mb-0">Placa</label>
                            <input type="text" id="filtroPlaca" class="form-control form-control-sm filtro-input" placeholder="Placa...">
                        </div>
                        <div class="col-6 col-md-2">
                            <label class="form-label small mb-0">Estado</label>
                            <select id="filtroEstado" class="form-select form-select-sm filtro-input">
                                <option value="">Todos</option>
                                <option value="activo">Activos</option>
                                <option value="bloqueado">Bloqueados</option>
                            </select>
                        </div>
                        <div class="col-12 col-md-auto d-flex gap-1">
                            <button id="btnBuscar" class="btn btn-primary btn-sm"><i class="bi bi-search"></i> Buscar</button>
                            <button id="btnLimpiarFiltros" class="btn btn-outline-secondary btn-sm"><i class="bi bi-eraser"></i> Limpiar</button>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <!-- Resumen -->
        <div class="d-flex flex-wrap gap-2 mb-2">
            <span class="badge bg-primary">Total: <span id="resumenTotal">0</span></span>
            <span class="badge bg-success">Activas: <span id="resumenActivos">0</span></span>
            <span class="badge bg-danger">Bloqueadas: <span id="resumenBloqueados">0</span></span>
        </div>

        <!-- Tabla -->
        <div class="table-responsive" style="max-height: 65vh; overflow-y: auto;">
            <table class="table table-bordered table-sm table-hover mb-0" id="tblPlacas">
                <thead class="table-dark sticky-top">
                    <tr>
                        <th>C&oacute;digo</th>
                        <th>Placa</th>
                        <th>Propietario</th>
                        <th class="d-none d-md-table-cell">Observaciones</th>
                        <th>Estado</th>
                    </tr>
                </thead>
                <tbody id="tbodyPlacas">
                    <tr><td colspan="5" class="text-center text-muted">Cargando...</td></tr>
                </tbody>
            </table>
        </div>

        <!-- Paginacion -->
        <nav class="mt-2" id="paginacion"></nav>
    </div>
</div>

<script src="js/placa.js"></script>

<?php include 'includes/footer.php'; ?>
