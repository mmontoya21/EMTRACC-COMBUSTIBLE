<?php
require_once 'includes/auth.php';
requireLogin();
requirePermiso('acceso');
if (getUserRole() !== 'SUPERADMIN') { header('Location: index.php'); exit; }
require_once 'includes/config.php';

$pageTitle = 'Accesos';
include 'includes/header.php';
?>

<script>
const APP = {
    userRole: <?= json_encode(getUserRole()) ?>,
    userName: <?= json_encode(getUserName()) ?>
};
</script>

<h5 class="mb-2"><i class="bi bi-shield-lock"></i> Gesti&oacute;n de Accesos</h5>

<!-- Toolbar -->
<div class="btn-toolbar mb-2 gap-1 flex-wrap" role="toolbar">
    <button id="btnNuevo" class="btn btn-success btn-sm"><i class="bi bi-plus-circle"></i> Nuevo</button>
    <button id="btnGuardar" class="btn btn-primary btn-sm" style="display:none"><i class="bi bi-floppy"></i> Guardar</button>
    <button id="btnEditar" class="btn btn-info btn-sm" disabled><i class="bi bi-pencil"></i> Editar</button>
    <button id="btnModificar" class="btn btn-primary btn-sm" style="display:none"><i class="bi bi-check-circle"></i> Modificar</button>
    <button id="btnCancelar" class="btn btn-secondary btn-sm" disabled><i class="bi bi-x-circle"></i> Cancelar</button>
    <button id="btnEliminar" class="btn btn-danger btn-sm" disabled><i class="bi bi-trash"></i> Eliminar</button>
</div>

<!-- Layout principal -->
<div class="row g-2">
    <!-- FORMULARIO -->
    <div class="col-lg-4 col-xl-3">
        <div class="card">
            <div class="card-header bg-dark text-white py-1 d-flex justify-content-between align-items-center">
                <strong class="small">Datos del Acceso</strong>
                <button class="btn btn-sm btn-outline-light d-lg-none py-0" type="button"
                        data-bs-toggle="collapse" data-bs-target="#formCollapse">
                    <small>Ver/Ocultar</small>
                </button>
            </div>
            <div id="formCollapse" class="collapse show">
                <div class="card-body p-2" id="formPanel">
                    <input type="hidden" id="accesoId">

                    <div class="mb-1">
                        <label class="form-label small mb-0">Nombre <span class="text-danger">*</span></label>
                        <input type="text" id="nombre" class="form-control form-control-sm" maxlength="30" disabled>
                    </div>

                    <div class="mb-1">
                        <label class="form-label small mb-0">Apellido <span class="text-danger">*</span></label>
                        <input type="text" id="apellido" class="form-control form-control-sm" maxlength="30" disabled>
                    </div>

                    <div class="mb-1">
                        <label class="form-label small mb-0">Usuario <span class="text-danger">*</span></label>
                        <input type="text" id="usuario" class="form-control form-control-sm" maxlength="20" disabled>
                    </div>

                    <div class="mb-1">
                        <label class="form-label small mb-0">Contrase&ntilde;a <span class="text-danger">*</span></label>
                        <div class="input-group input-group-sm">
                            <input type="password" id="clave" class="form-control form-control-sm" maxlength="200" disabled>
                            <button class="btn btn-outline-secondary" type="button" id="btnToggleClave" disabled>
                                <i class="bi bi-eye"></i>
                            </button>
                        </div>
                        <small class="text-muted" style="font-size:0.7rem;">Dejar vac&iacute;o para no cambiar al editar</small>
                    </div>

                    <div class="row g-1 mb-1">
                        <div class="col-6">
                            <label class="form-label small mb-0">Tipo <span class="text-danger">*</span></label>
                            <select id="tipo" class="form-select form-select-sm" disabled>
                                <option value="">-- Seleccionar --</option>
                                <option value="SUPERADMIN">SUPERADMIN</option>
                                <option value="ADMIN">ADMIN</option>
                                <option value="USUARIO">USUARIO</option>
                                <option value="TEST">TEST</option>
                                <option value="DESPACHADOR">DESPACHADOR</option>
                            </select>
                        </div>
                        <div class="col-6">
                            <label class="form-label small mb-0">Status</label>
                            <select id="status" class="form-select form-select-sm" disabled>
                                <option value="ACTIVO">ACTIVO</option>
                                <option value="INACTIVO">INACTIVO</option>
                            </select>
                        </div>
                    </div>

                    <div class="mb-1">
                        <label class="form-label small mb-0">Fecha</label>
                        <input type="date" id="fecha" class="form-control form-control-sm" disabled>
                    </div>
                </div>
            </div>
        </div>

        <!-- Panel de Permisos -->
        <div class="card mt-2">
            <div class="card-header bg-secondary text-white py-1">
                <strong class="small"><i class="bi bi-key"></i> Permisos de M&oacute;dulos</strong>
            </div>
            <div class="card-body p-2">
                <div class="row g-1">
                    <div class="col-6">
                        <div class="form-check form-check-sm">
                            <input class="form-check-input chk-permiso" type="checkbox" id="chk_camiones" value="camiones" disabled>
                            <label class="form-check-label small" for="chk_camiones">Camiones</label>
                        </div>
                    </div>
                    <div class="col-6">
                        <div class="form-check form-check-sm">
                            <input class="form-check-input chk-permiso" type="checkbox" id="chk_placa" value="placa" disabled>
                            <label class="form-check-label small" for="chk_placa">Placas</label>
                        </div>
                    </div>
                    <div class="col-6">
                        <div class="form-check form-check-sm">
                            <input class="form-check-input chk-permiso" type="checkbox" id="chk_transportistas" value="transportistas" disabled>
                            <label class="form-check-label small" for="chk_transportistas">Transportistas</label>
                        </div>
                    </div>
                    <div class="col-6">
                        <div class="form-check form-check-sm">
                            <input class="form-check-input chk-permiso" type="checkbox" id="chk_tanque" value="tanque" disabled>
                            <label class="form-check-label small" for="chk_tanque">Tanque</label>
                        </div>
                    </div>
                    <div class="col-6">
                        <div class="form-check form-check-sm">
                            <input class="form-check-input chk-permiso" type="checkbox" id="chk_empresa" value="empresa" disabled>
                            <label class="form-check-label small" for="chk_empresa">Empresa</label>
                        </div>
                    </div>
                    <div class="col-6">
                        <div class="form-check form-check-sm">
                            <input class="form-check-input chk-permiso" type="checkbox" id="chk_acceso" value="acceso" disabled>
                            <label class="form-check-label small" for="chk_acceso">Accesos</label>
                        </div>
                    </div>
                    <div class="col-6">
                        <div class="form-check form-check-sm">
                            <input class="form-check-input chk-permiso" type="checkbox" id="chk_medicion" value="medicion" disabled>
                            <label class="form-check-label small" for="chk_medicion">Medici&oacute;n</label>
                        </div>
                    </div>
                    <div class="col-6">
                        <div class="form-check form-check-sm">
                            <input class="form-check-input chk-permiso" type="checkbox" id="chk_comprobante" value="comprobante" disabled>
                            <label class="form-check-label small" for="chk_comprobante">Comprobante</label>
                        </div>
                    </div>
                    <div class="col-6">
                        <div class="form-check form-check-sm">
                            <input class="form-check-input chk-permiso" type="checkbox" id="chk_factura" value="factura" disabled>
                            <label class="form-check-label small" for="chk_factura">Factura</label>
                        </div>
                    </div>
                    <div class="col-6">
                        <div class="form-check form-check-sm">
                            <input class="form-check-input chk-permiso" type="checkbox" id="chk_propietario" value="propietario" disabled>
                            <label class="form-check-label small" for="chk_propietario">Propietario</label>
                        </div>
                    </div>
                    <div class="col-6">
                        <div class="form-check form-check-sm">
                            <input class="form-check-input chk-permiso" type="checkbox" id="chk_consumo" value="consumo" disabled>
                            <label class="form-check-label small" for="chk_consumo">Consumo</label>
                        </div>
                    </div>
                    <div class="col-6">
                        <div class="form-check form-check-sm">
                            <input class="form-check-input chk-permiso" type="checkbox" id="chk_reporte" value="reporte" disabled>
                            <label class="form-check-label small" for="chk_reporte">Reporte</label>
                        </div>
                    </div>
                    <div class="col-6">
                        <div class="form-check form-check-sm">
                            <input class="form-check-input chk-permiso" type="checkbox" id="chk_valorComb" value="valorComb" disabled>
                            <label class="form-check-label small" for="chk_valorComb">Valor Comb.</label>
                        </div>
                    </div>
                    <div class="col-6">
                        <div class="form-check form-check-sm">
                            <input class="form-check-input chk-permiso" type="checkbox" id="chk_rutas" value="rutas" disabled>
                            <label class="form-check-label small" for="chk_rutas">Rutas</label>
                        </div>
                    </div>
                    <div class="col-6">
                        <div class="form-check form-check-sm">
                            <input class="form-check-input chk-permiso" type="checkbox" id="chk_reporteFact" value="reporteFact" disabled>
                            <label class="form-check-label small" for="chk_reporteFact">Rep. Factura</label>
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
                            <label class="form-label small mb-0">Usuario</label>
                            <input type="text" id="filtroUsuario" class="form-control form-control-sm filtro-input" placeholder="Buscar usuario...">
                        </div>
                        <div class="col-5 col-md-4">
                            <label class="form-label small mb-0">Nombre</label>
                            <input type="text" id="filtroNombre" class="form-control form-control-sm filtro-input" placeholder="Buscar nombre...">
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
            <table class="table table-bordered table-sm table-hover mb-0" id="tblAccesos">
                <thead class="table-dark sticky-top">
                    <tr>
                        <th>ID</th>
                        <th>Nombre</th>
                        <th>Apellido</th>
                        <th>Usuario</th>
                        <th class="d-none d-md-table-cell">Tipo</th>
                        <th class="d-none d-md-table-cell">Status</th>
                        <th class="d-none d-lg-table-cell">Fecha</th>
                    </tr>
                </thead>
                <tbody id="tbodyAccesos">
                    <tr><td colspan="7" class="text-center text-muted">Cargando...</td></tr>
                </tbody>
            </table>
        </div>

        <!-- Paginacion -->
        <nav class="mt-2" id="paginacion"></nav>
    </div>
</div>

<script src="js/acceso.js"></script>

<?php include 'includes/footer.php'; ?>
