<?php
require_once 'includes/auth.php';
requireLogin();
requirePermiso('empresa');
require_once 'includes/config.php';

$pageTitle = 'Empresa';
include 'includes/header.php';
?>

<script>
const APP = {
    userRole: <?= json_encode(getUserRole()) ?>,
    userName: <?= json_encode(getUserName()) ?>
};
</script>

<div class="d-flex justify-content-between align-items-center mb-2 flex-wrap">
    <h5 class="mb-0"><i class="bi bi-building"></i> Datos de la Empresa</h5>
    <span id="statusBadge" class="badge bg-secondary">Cargando...</span>
</div>

<!-- Toolbar -->
<div class="btn-toolbar mb-2 gap-1 flex-wrap" role="toolbar">
    <button id="btnNuevo" class="btn btn-success btn-sm"><i class="bi bi-plus-circle"></i> Nuevo</button>
    <button id="btnGuardar" class="btn btn-primary btn-sm" style="display:none"><i class="bi bi-floppy"></i> Guardar</button>
    <button id="btnEditar" class="btn btn-info btn-sm" disabled><i class="bi bi-pencil"></i> Editar</button>
    <button id="btnModificar" class="btn btn-primary btn-sm" style="display:none"><i class="bi bi-check-circle"></i> Modificar</button>
    <button id="btnCancelar" class="btn btn-secondary btn-sm" disabled><i class="bi bi-x-circle"></i> Cancelar</button>
    <button id="btnEliminar" class="btn btn-danger btn-sm" disabled><i class="bi bi-trash"></i> Eliminar</button>
</div>

<!-- Formulario de empresa -->
<div class="card">
    <div class="card-header bg-dark text-white py-1">
        <strong class="small">Informaci&oacute;n de la Empresa</strong>
    </div>
    <div class="card-body p-3" id="formPanel">

        <!-- Seccion: Datos Generales -->
        <div class="row g-2 mb-3">
            <div class="col-md-6">
                <label class="form-label small mb-0">Nombre Empresa <span class="text-danger">*</span></label>
                <input type="text" id="nEmpre" class="form-control form-control-sm fw-bold" maxlength="60" disabled>
            </div>
            <div class="col-md-6">
                <label class="form-label small mb-0">Propietario</label>
                <input type="text" id="nPropie" class="form-control form-control-sm" maxlength="60" disabled>
            </div>
        </div>

        <div class="row g-2 mb-3">
            <div class="col-md-4">
                <label class="form-label small mb-0">RTN</label>
                <input type="text" id="rtn" class="form-control form-control-sm" maxlength="18" disabled>
            </div>
            <div class="col-md-4">
                <label class="form-label small mb-0">Nombre Local</label>
                <input type="text" id="nombLocal" class="form-control form-control-sm" maxlength="30" disabled>
            </div>
            <div class="col-md-2">
                <label class="form-label small mb-0">Local</label>
                <input type="text" id="local" class="form-control form-control-sm" maxlength="15" disabled>
            </div>
            <div class="col-md-2">
                <label class="form-label small mb-0">Correo</label>
                <input type="email" id="correoE" class="form-control form-control-sm" maxlength="40" disabled>
            </div>
        </div>

        <!-- Seccion: Direcciones -->
        <hr class="my-2">
        <p class="small text-muted mb-1 fw-bold"><i class="bi bi-geo-alt"></i> Direcciones</p>
        <div class="row g-2 mb-3">
            <div class="col-md-4">
                <label class="form-label small mb-0">Direcci&oacute;n 1</label>
                <textarea id="dire1" class="form-control form-control-sm" maxlength="60" rows="2" disabled></textarea>
            </div>
            <div class="col-md-4">
                <label class="form-label small mb-0">Direcci&oacute;n 2</label>
                <textarea id="dire2" class="form-control form-control-sm" maxlength="60" rows="2" disabled></textarea>
            </div>
            <div class="col-md-4">
                <label class="form-label small mb-0">Direcci&oacute;n 3</label>
                <textarea id="dire3" class="form-control form-control-sm" maxlength="60" rows="2" disabled></textarea>
            </div>
        </div>

        <!-- Seccion: Contacto -->
        <hr class="my-2">
        <p class="small text-muted mb-1 fw-bold"><i class="bi bi-telephone"></i> Contacto</p>
        <div class="row g-2 mb-3">
            <div class="col-md-4">
                <label class="form-label small mb-0">Tel&eacute;fono 1</label>
                <input type="text" id="tel1" class="form-control form-control-sm" maxlength="30" disabled>
            </div>
            <div class="col-md-4">
                <label class="form-label small mb-0">Tel&eacute;fono 2</label>
                <input type="text" id="cel2" class="form-control form-control-sm" maxlength="30" disabled>
            </div>
            <div class="col-md-4">
                <label class="form-label small mb-0">Fax</label>
                <input type="text" id="fax" class="form-control form-control-sm" maxlength="16" disabled>
            </div>
        </div>

        <!-- Seccion: Datos Fiscales -->
        <hr class="my-2">
        <p class="small text-muted mb-1 fw-bold"><i class="bi bi-receipt"></i> Datos Fiscales</p>
        <div class="row g-2 mb-3">
            <div class="col-md-6">
                <label class="form-label small mb-0">CAI</label>
                <input type="text" id="cai" class="form-control form-control-sm" maxlength="45" disabled>
            </div>
            <div class="col-md-3">
                <label class="form-label small mb-0">8 D&iacute;gitos</label>
                <input type="text" id="ochoDig" class="form-control form-control-sm" maxlength="16" disabled>
            </div>
            <div class="col-md-3">
                <label class="form-label small mb-0">Fecha L&iacute;mite Emisi&oacute;n</label>
                <input type="text" id="fechaLimit" class="form-control form-control-sm" maxlength="12" disabled>
            </div>
        </div>

        <div class="row g-2 mb-3">
            <div class="col-md-6">
                <label class="form-label small mb-0">Rango Inicial</label>
                <input type="text" id="rangoIni" class="form-control form-control-sm" maxlength="20" disabled>
            </div>
            <div class="col-md-6">
                <label class="form-label small mb-0">Rango Final</label>
                <input type="text" id="rangoFin" class="form-control form-control-sm" maxlength="20" disabled>
            </div>
        </div>

        <!-- Seccion: Otros -->
        <hr class="my-2">
        <p class="small text-muted mb-1 fw-bold"><i class="bi bi-three-dots"></i> Otros</p>
        <div class="row g-2">
            <div class="col-md-6">
                <label class="form-label small mb-0">Otros 1</label>
                <textarea id="otros1" class="form-control form-control-sm" maxlength="30" rows="2" disabled></textarea>
            </div>
            <div class="col-md-6">
                <label class="form-label small mb-0">Otros 2</label>
                <textarea id="otros2" class="form-control form-control-sm" maxlength="30" rows="2" disabled></textarea>
            </div>
        </div>

    </div>
</div>

<script src="js/empresa.js"></script>

<?php include 'includes/footer.php'; ?>
