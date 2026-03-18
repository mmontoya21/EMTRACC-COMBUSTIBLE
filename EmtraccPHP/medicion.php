<?php
require_once 'includes/auth.php';
requireLogin();
requirePermiso('medicion');
require_once 'includes/config.php';

$pageTitle = 'Medición Tanque';
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

<h5 class="mb-2"><i class="bi bi-rulers"></i> Medici&oacute;n de Tanque</h5>

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
    <button id="btnCalcular" class="btn btn-warning btn-sm" style="display:none"><i class="bi bi-calculator"></i> Calcular Despachados</button>
</div>

<!-- Layout principal -->
<div class="row g-2">
    <!-- FORMULARIO -->
    <div class="col-lg-4 col-xl-3">
        <div class="card">
            <div class="card-header bg-dark text-white py-1 d-flex justify-content-between align-items-center">
                <strong class="small">Datos de Medici&oacute;n</strong>
                <button class="btn btn-sm btn-outline-light d-lg-none py-0" type="button"
                        data-bs-toggle="collapse" data-bs-target="#formCollapse">
                    <small>Ver/Ocultar</small>
                </button>
            </div>
            <div id="formCollapse" class="collapse show">
                <div class="card-body p-2" id="formPanel">
                    <input type="hidden" id="medicionId">

                    <div class="mb-2">
                        <label class="form-label small mb-0">Fecha</label>
                        <input type="date" id="fecha" class="form-control form-control-sm" disabled>
                    </div>

                    <div class="row g-1 mb-2">
                        <div class="col-6">
                            <label class="form-label small mb-0">Periodo</label>
                            <select id="periodo" class="form-select form-select-sm" disabled>
                                <option value="">--</option>
                                <?php for ($i = 1; $i <= 12; $i++): ?>
                                <option value="<?= $i ?>"><?= $i ?></option>
                                <?php endfor; ?>
                            </select>
                        </div>
                        <div class="col-6">
                            <label class="form-label small mb-0">Semana</label>
                            <select id="semana" class="form-select form-select-sm" disabled>
                                <option value="">--</option>
                                <?php for ($i = 1; $i <= 5; $i++): ?>
                                <option value="<?= $i ?>"><?= $i ?></option>
                                <?php endfor; ?>
                            </select>
                        </div>
                    </div>

                    <div class="row g-1 mb-2">
                        <div class="col-6">
                            <label class="form-label small mb-0">Gal. Inicio (Calc)</label>
                            <input type="text" id="galonesCalc" class="form-control form-control-sm" disabled>
                        </div>
                        <div class="col-6">
                            <label class="form-label small mb-0">PGL Cal</label>
                            <input type="text" id="pglCal" class="form-control form-control-sm" disabled>
                        </div>
                    </div>

                    <div class="row g-1 mb-2">
                        <div class="col-6">
                            <label class="form-label small mb-0">Gal. Final (Med)</label>
                            <input type="text" id="galonesMed" class="form-control form-control-sm" disabled>
                        </div>
                        <div class="col-6">
                            <label class="form-label small mb-0">PGL Med</label>
                            <input type="text" id="pglMed" class="form-control form-control-sm" disabled>
                        </div>
                    </div>

                    <div class="mb-2">
                        <label class="form-label small mb-0">Capacidad Tanque</label>
                        <input type="text" id="capacidadTanque" class="form-control form-control-sm" disabled>
                    </div>

                    <div class="mb-2">
                        <label class="form-label small mb-0">Gal. Recibidos</label>
                        <input type="text" id="galRecibidos" class="form-control form-control-sm" disabled>
                    </div>

                    <div class="mb-2">
                        <label class="form-label small mb-0">Gal. Despachados</label>
                        <input type="text" id="galDespachados" class="form-control form-control-sm bg-light" readonly>
                    </div>

                    <div class="mb-2">
                        <label class="form-label small mb-0">Gal. Esperados</label>
                        <input type="text" id="galEsperados" class="form-control form-control-sm bg-light" readonly>
                    </div>

                    <div class="mb-2">
                        <label class="form-label small mb-0">Diferencia</label>
                        <input type="text" id="diferencia" class="form-control form-control-sm fw-bold" readonly>
                    </div>

                    <div class="mb-1">
                        <label class="form-label small mb-0">Observaciones</label>
                        <textarea id="observaciones" class="form-control form-control-sm" rows="2" disabled></textarea>
                    </div>
                </div>
            </div>
        </div>

        <!-- Panel Grafico -->
        <div class="card mt-2">
            <div class="card-header bg-dark text-white py-1">
                <strong class="small"><i class="bi bi-bar-chart-fill"></i> Indicadores</strong>
            </div>
            <div class="card-body p-2" style="background-color: #2d3748;">
                <!-- Nivel Tanque -->
                <div class="text-white small fw-bold mb-1">Nivel Tanque</div>
                <div class="d-flex align-items-end gap-2 mb-2">
                    <div id="tankContainer" style="width:60px;height:140px;border:2px solid #96a0b4;position:relative;background:#1a202c;">
                        <div id="tankFill" style="position:absolute;bottom:0;left:2px;right:2px;height:0%;transition:height 0.5s;"></div>
                    </div>
                    <div>
                        <div id="tankPercent" class="text-white fw-bold" style="font-size:1.2rem;">0.0%</div>
                        <div id="tankGalones" class="text-secondary small">0 gal</div>
                        <div id="tankCapacidad" class="text-secondary small"></div>
                    </div>
                </div>

                <!-- Barras Comparativas -->
                <div class="text-white small fw-bold mb-1">Comparativo Semanal</div>
                <div class="d-flex justify-content-around align-items-end mb-1" style="height:100px;" id="barsContainer">
                    <div class="text-center">
                        <div id="barInicioVal" class="text-white small fw-bold">0</div>
                        <div id="barInicio" style="width:45px;height:0px;background:linear-gradient(#4285f4,#1e50b4);transition:height 0.5s;"></div>
                        <div class="text-white small mt-1">Inicio</div>
                    </div>
                    <div class="text-center">
                        <div id="barEsperadoVal" class="text-white small fw-bold">0</div>
                        <div id="barEsperado" style="width:45px;height:0px;background:linear-gradient(#ffa726,#c87800);transition:height 0.5s;"></div>
                        <div class="text-white small mt-1">Esperado</div>
                    </div>
                    <div class="text-center">
                        <div id="barRealVal" class="text-white small fw-bold">0</div>
                        <div id="barReal" style="width:45px;height:0px;transition:height 0.5s;"></div>
                        <div class="text-white small mt-1">Real</div>
                    </div>
                </div>

                <!-- Reconciliacion -->
                <hr style="border-color:#4a5568;" class="my-2">
                <div class="text-white small fw-bold">Reconciliaci&oacute;n:</div>
                <div id="formulaText" class="text-secondary small"></div>
                <div id="formulaText2" class="text-secondary small"></div>
                <div id="diffBadge" class="mt-1"></div>
            </div>
        </div>
    </div>

    <!-- TABLA -->
    <div class="col-lg-8 col-xl-9">
        <!-- Resumen -->
        <div class="d-flex flex-wrap gap-2 mb-2">
            <span class="badge bg-primary">Registros: <span id="resumenTotal">0</span></span>
        </div>

        <!-- Tabla -->
        <div class="table-responsive" style="max-height: 65vh; overflow-y: auto;">
            <table class="table table-bordered table-sm table-hover mb-0" id="tblMedicion">
                <thead class="table-dark sticky-top">
                    <tr>
                        <th style="width:50px">ID</th>
                        <th style="width:90px">Fecha</th>
                        <th style="width:40px">Per</th>
                        <th style="width:40px">Sem</th>
                        <th class="text-end" style="width:90px">Gal. Inicio</th>
                        <th class="text-end" style="width:90px">Gal. Final</th>
                        <th class="text-end" style="width:90px">Despachados</th>
                        <th class="text-end" style="width:90px">Esperados</th>
                        <th class="text-end" style="width:90px">Diferencia</th>
                    </tr>
                </thead>
                <tbody id="tbodyMedicion">
                    <tr><td colspan="9" class="text-center text-muted">Cargando...</td></tr>
                </tbody>
            </table>
        </div>

        <!-- Paginacion -->
        <nav class="mt-2" id="paginacion"></nav>
    </div>
</div>

<script src="js/medicion.js"></script>

<?php include 'includes/footer.php'; ?>
