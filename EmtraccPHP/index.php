<?php
require_once 'includes/auth.php';
requireLogin();
requirePermiso('reporte');
require_once 'includes/config.php';

$pageTitle = 'Comprobantes';

// Parámetros de filtro
$fechaDesde = $_GET['fechaDesde'] ?? '';
$fechaHasta = $_GET['fechaHasta'] ?? '';
$periodo = $_GET['periodo'] ?? '';
$semana = $_GET['semana'] ?? '';
$despachador = $_GET['despachador'] ?? '';
$propietario = $_GET['propietario'] ?? '';
$placa = $_GET['placa'] ?? '';
$boleta = $_GET['boleta'] ?? '';
$comprobante = $_GET['comprobante'] ?? '';
$ordenar = $_GET['ordenar'] ?? 'fecha';
$dir = $_GET['dir'] ?? 'desc';
$pagina = max(1, (int)($_GET['pagina'] ?? 1));
$pageSize = 50;

// Construir WHERE
$where = [];
$params = [];
$types = '';

// Restricción por rol: DESPACHADOR solo ve sus registros
if (getUserRole() === 'DESPACHADOR') {
    $where[] = "nombDesp = ?";
    $params[] = getUserName();
    $types .= 's';
}

if ($fechaDesde !== '') {
    $where[] = "fecha >= ?";
    $params[] = $fechaDesde;
    $types .= 's';
}
if ($fechaHasta !== '') {
    $where[] = "fecha <= ?";
    $params[] = $fechaHasta . ' 23:59:59';
    $types .= 's';
}
if ($periodo !== '') {
    $where[] = "periodo = ?";
    $params[] = $periodo;
    $types .= 's';
}
if ($semana !== '') {
    $where[] = "semana = ?";
    $params[] = $semana;
    $types .= 's';
}
if ($despachador !== '') {
    $where[] = "nombDesp = ?";
    $params[] = $despachador;
    $types .= 's';
}
if ($propietario !== '') {
    $where[] = "propCbz LIKE ?";
    $params[] = "%$propietario%";
    $types .= 's';
}
if ($placa !== '') {
    $where[] = "placaCbz LIKE ?";
    $params[] = "%$placa%";
    $types .= 's';
}
if ($boleta !== '') {
    $where[] = "nBoleta LIKE ?";
    $params[] = "%$boleta%";
    $types .= 's';
}
if ($comprobante !== '') {
    $where[] = "nCompro LIKE ?";
    $params[] = "%$comprobante%";
    $types .= 's';
}

$whereSQL = count($where) > 0 ? 'WHERE ' . implode(' AND ', $where) : '';

// Resumen
$sqlCount = "SELECT COUNT(*) as total, SUM(anulado) as anulados, SUM(CASE WHEN anulado = 0 THEN IFNULL(galDesp,0) ELSE 0 END) as totalGalones, SUM(CASE WHEN anulado = 0 THEN IFNULL(total,0) ELSE 0 END) as totalMonto FROM comprobante $whereSQL";
$stmt = $conn->prepare($sqlCount);
if ($types !== '') {
    $stmt->bind_param($types, ...$params);
}
$stmt->execute();
$resumen = $stmt->get_result()->fetch_assoc();
$stmt->close();

$totalRegistros = (int)$resumen['total'];
$registrosAnulados = (int)$resumen['anulados'];
$totalGalones = (float)$resumen['totalGalones'];
$totalMonto = (float)$resumen['totalMonto'];

// Paginación
$totalPaginas = max(1, (int)ceil($totalRegistros / $pageSize));
if ($pagina > $totalPaginas) $pagina = $totalPaginas;
$offset = ($pagina - 1) * $pageSize;

// Ordenamiento
$columnas = [
    'compro' => 'nCompro', 'boleta' => 'nBoleta', 'fecha' => 'fecha',
    'despachador' => 'nombDesp', 'propietario' => 'propCbz', 'placa' => 'placaCbz',
    'galones' => 'galDesp', 'total' => 'total'
];
$orderCol = $columnas[$ordenar] ?? 'fecha';
$orderDir = ($dir === 'asc') ? 'ASC' : 'DESC';

// Consulta principal
$sql = "SELECT * FROM comprobante $whereSQL ORDER BY $orderCol $orderDir LIMIT $pageSize OFFSET $offset";
$stmt = $conn->prepare($sql);
if ($types !== '') {
    $stmt->bind_param($types, ...$params);
}
$stmt->execute();
$datos = $stmt->get_result()->fetch_all(MYSQLI_ASSOC);
$stmt->close();

// Listas para filtros (sin parámetros)
$periodos = [];
$res = $conn->query("SELECT DISTINCT periodo FROM comprobante WHERE periodo IS NOT NULL ORDER BY periodo");
while ($r = $res->fetch_assoc()) $periodos[] = $r['periodo'];

$semanas = [];
$res = $conn->query("SELECT DISTINCT semana FROM comprobante WHERE semana IS NOT NULL ORDER BY semana");
while ($r = $res->fetch_assoc()) $semanas[] = $r['semana'];

$despachadores = [];
$res = $conn->query("SELECT DISTINCT nombDesp FROM comprobante WHERE nombDesp IS NOT NULL ORDER BY nombDesp");
while ($r = $res->fetch_assoc()) $despachadores[] = $r['nombDesp'];

// Funciones helper
function sortUrl($campo) {
    $params = $_GET;
    $newDir = (isset($_GET['ordenar']) && $_GET['ordenar'] === $campo && (!isset($_GET['dir']) || $_GET['dir'] !== 'asc')) ? 'asc' : 'desc';
    $params['ordenar'] = $campo;
    $params['dir'] = $newDir;
    $params['pagina'] = 1;
    return '?' . http_build_query($params);
}

function sortIcon($campo) {
    if (!isset($_GET['ordenar']) || $_GET['ordenar'] !== $campo) return '';
    return (isset($_GET['dir']) && $_GET['dir'] === 'asc') ? ' ▲' : ' ▼';
}

function pageUrl($pag) {
    $params = $_GET;
    $params['pagina'] = $pag;
    return '?' . http_build_query($params);
}

function exportUrl($action) {
    $params = $_GET;
    unset($params['pagina'], $params['ordenar'], $params['dir']);
    return $action . '?' . http_build_query($params);
}

include 'includes/header.php';
?>

<div class="d-flex flex-wrap justify-content-between align-items-center mb-2">
    <h4 class="mb-0">Comprobantes de Combustible</h4>
    <div>
        <a href="<?= exportUrl('exportar_pdf.php') ?>" class="btn btn-danger btn-sm"><i class="bi bi-file-earmark-pdf"></i> PDF</a>
        <a href="<?= exportUrl('exportar_excel.php') ?>" class="btn btn-success btn-sm"><i class="bi bi-file-earmark-excel"></i> Excel</a>
        <a href="<?= exportUrl('exportar_xlsx.php') ?>" class="btn btn-outline-success btn-sm"><i class="bi bi-file-earmark-spreadsheet"></i> XLSX</a>
    </div>
</div>

<!-- Filtros colapsables en móvil -->
<div class="mb-3">
    <button class="btn btn-outline-dark btn-sm d-md-none w-100 mb-2" type="button" data-bs-toggle="collapse" data-bs-target="#filtrosPanel">
        <i class="bi bi-sliders"></i> Mostrar/Ocultar Filtros
    </button>
    <form method="get" id="filtrosPanel" class="collapse show">
        <div class="row g-2 align-items-end">
            <div class="col-6 col-md-auto">
                <label class="form-label mb-0">Desde</label>
                <input type="date" name="fechaDesde" value="<?= htmlspecialchars($fechaDesde) ?>" class="form-control form-control-sm" />
            </div>
            <div class="col-6 col-md-auto">
                <label class="form-label mb-0">Hasta</label>
                <input type="date" name="fechaHasta" value="<?= htmlspecialchars($fechaHasta) ?>" class="form-control form-control-sm" />
            </div>
            <div class="col-6 col-md-auto">
                <label class="form-label mb-0">Período</label>
                <select name="periodo" class="form-select form-select-sm">
                    <option value="">-- Todos --</option>
                    <?php foreach ($periodos as $p): ?>
                        <option value="<?= htmlspecialchars($p) ?>" <?= $p === $periodo ? 'selected' : '' ?>><?= htmlspecialchars($p) ?></option>
                    <?php endforeach; ?>
                </select>
            </div>
            <div class="col-6 col-md-auto">
                <label class="form-label mb-0">Semana</label>
                <select name="semana" class="form-select form-select-sm">
                    <option value="">-- Todas --</option>
                    <?php foreach ($semanas as $s): ?>
                        <option value="<?= htmlspecialchars($s) ?>" <?= $s === $semana ? 'selected' : '' ?>><?= htmlspecialchars($s) ?></option>
                    <?php endforeach; ?>
                </select>
            </div>
            <div class="col-6 col-md-auto">
                <label class="form-label mb-0">Despachador</label>
                <select name="despachador" class="form-select form-select-sm">
                    <option value="">-- Todos --</option>
                    <?php foreach ($despachadores as $d): ?>
                        <option value="<?= htmlspecialchars($d) ?>" <?= $d === $despachador ? 'selected' : '' ?>><?= htmlspecialchars($d) ?></option>
                    <?php endforeach; ?>
                </select>
            </div>
            <div class="col-6 col-md-auto">
                <label class="form-label mb-0">Propietario</label>
                <input type="text" name="propietario" value="<?= htmlspecialchars($propietario) ?>" class="form-control form-control-sm" placeholder="Buscar..." />
            </div>
            <div class="col-6 col-md-auto">
                <label class="form-label mb-0">Placa</label>
                <input type="text" name="placa" value="<?= htmlspecialchars($placa) ?>" class="form-control form-control-sm" placeholder="Buscar..." />
            </div>
            <div class="col-6 col-md-auto">
                <label class="form-label mb-0">No. Boleta</label>
                <input type="text" name="boleta" value="<?= htmlspecialchars($boleta) ?>" class="form-control form-control-sm" placeholder="Buscar..." />
            </div>
            <div class="col-6 col-md-auto">
                <label class="form-label mb-0">No. Comprobante</label>
                <input type="text" name="comprobante" value="<?= htmlspecialchars($comprobante) ?>" class="form-control form-control-sm" placeholder="Buscar..." />
            </div>
            <div class="col-12 col-md-auto">
                <button type="submit" class="btn btn-primary btn-sm"><i class="bi bi-funnel"></i> Filtrar</button>
                <a href="index.php" class="btn btn-outline-secondary btn-sm"><i class="bi bi-eraser"></i> Limpiar</a>
            </div>
        </div>
    </form>
</div>

<!-- Resumen -->
<div class="d-flex flex-wrap gap-2 mb-2">
    <span class="badge bg-primary">Total: <?= $totalRegistros ?></span>
    <span class="badge bg-danger">Anulados: <?= $registrosAnulados ?></span>
    <span class="badge bg-success">Galones: <?= number_format($totalGalones, 2) ?></span>
    <span class="badge bg-info">Total L: <?= number_format($totalMonto, 2) ?></span>
</div>

<?php
// Odometro: mostrar si hay filtro de fecha o despachador
$odoRows = [];
if (!empty($fechaDesde) || !empty($fechaHasta) || !empty($despachador)) {
    $odoWhere = [];
    $odoParams = [];
    $odoTypes = '';
    if (!empty($fechaDesde)) { $odoWhere[] = "fecha >= ?"; $odoParams[] = $fechaDesde; $odoTypes .= 's'; }
    if (!empty($fechaHasta)) { $odoWhere[] = "fecha <= ?"; $odoParams[] = $fechaHasta; $odoTypes .= 's'; }
    if (!empty($despachador)) { $odoWhere[] = "despachador = ?"; $odoParams[] = strtoupper($despachador); $odoTypes .= 's'; }
    $odoSQL = "SELECT despachador, turnoNombre, MIN(odometroInicio) AS odoInicio, MAX(odometroCierre) AS odoCierre, fecha
               FROM cierre_turno" . (count($odoWhere) > 0 ? " WHERE " . implode(' AND ', $odoWhere) : "") .
               " GROUP BY despachador, fecha ORDER BY fecha ASC";
    $stmtOdo = $conn->prepare($odoSQL);
    if ($odoTypes !== '') $stmtOdo->bind_param($odoTypes, ...$odoParams);
    $stmtOdo->execute();
    $odoRows = $stmtOdo->get_result()->fetch_all(MYSQLI_ASSOC);
    $stmtOdo->close();
}
if (!empty($odoRows)): ?>
<div class="card border-success mb-2">
    <div class="card-header bg-success text-white py-1 small"><strong>Odometro por Turno</strong></div>
    <div class="card-body p-1">
        <table class="table table-sm table-bordered mb-0 small">
            <thead class="table-light">
                <tr><th>Despachador</th><th>Fecha</th><th class="text-end">Odo. Inicio</th><th class="text-end">Odo. Cierre</th></tr>
            </thead>
            <tbody>
                <?php foreach ($odoRows as $odo): ?>
                <tr>
                    <td><?= htmlspecialchars($odo['despachador']) ?></td>
                    <td><?= date('d/m/Y', strtotime($odo['fecha'])) ?></td>
                    <td class="text-end"><?= number_format((float)$odo['odoInicio'], 2) ?></td>
                    <td class="text-end"><?= number_format((float)$odo['odoCierre'], 2) ?></td>
                </tr>
                <?php endforeach; ?>
            </tbody>
        </table>
    </div>
</div>
<?php endif; ?>

<!-- Tabla -->
<div class="table-responsive">
    <table class="table table-bordered table-sm">
        <thead class="table-dark">
            <tr>
                <th><a href="<?= sortUrl('compro') ?>">No. Compro<?= sortIcon('compro') ?></a></th>
                <th><a href="<?= sortUrl('boleta') ?>">No. Boleta<?= sortIcon('boleta') ?></a></th>
                <th><a href="<?= sortUrl('fecha') ?>">Fecha<?= sortIcon('fecha') ?></a></th>
                <th><a href="<?= sortUrl('despachador') ?>">Despachador<?= sortIcon('despachador') ?></a></th>
                <th><a href="<?= sortUrl('propietario') ?>">Propietario<?= sortIcon('propietario') ?></a></th>
                <th><a href="<?= sortUrl('placa') ?>">Placa<?= sortIcon('placa') ?></a></th>
                <th>Período</th>
                <th>Semana</th>
                <th>Ruta</th>
                <th><a href="<?= sortUrl('galones') ?>">Galones<?= sortIcon('galones') ?></a></th>
                <th>Valor</th>
                <th><a href="<?= sortUrl('total') ?>">Total<?= sortIcon('total') ?></a></th>
                <th>Contenedor</th>
                <th>Conductor</th>
                <th>Estado</th>
            </tr>
        </thead>
        <tbody>
            <?php $rowIndex = 0; foreach ($datos as $c): ?>
                <?php
                    if ($c['anulado'])
                        $rowClass = 'row-anulado';
                    else
                        $rowClass = $rowIndex % 2 === 0 ? 'row-white' : 'row-blue';
                    $rowIndex++;
                ?>
                <tr class="<?= $rowClass ?>">
                    <td><?= htmlspecialchars($c['nCompro'] ?? '') ?></td>
                    <td><?= htmlspecialchars($c['nBoleta'] ?? '') ?></td>
                    <td><?= $c['fecha'] ? date('d/m/Y', strtotime($c['fecha'])) : '' ?></td>
                    <td><?= htmlspecialchars($c['nombDesp'] ?? '') ?></td>
                    <td><?= htmlspecialchars($c['propCbz'] ?? '') ?></td>
                    <td><?= htmlspecialchars($c['placaCbz'] ?? '') ?></td>
                    <td><?= htmlspecialchars($c['periodo'] ?? '') ?></td>
                    <td><?= htmlspecialchars($c['semana'] ?? '') ?></td>
                    <td><?= htmlspecialchars($c['ruta'] ?? '') ?></td>
                    <td class="text-end"><?= number_format((float)($c['galDesp'] ?? 0), 2) ?></td>
                    <td class="text-end"><?= number_format((float)($c['valor'] ?? 0), 2) ?></td>
                    <td class="text-end"><?= number_format((float)($c['total'] ?? 0), 2) ?></td>
                    <td><?= htmlspecialchars($c['nConte'] ?? '') ?></td>
                    <td><?= htmlspecialchars($c['nombCond'] ?? '') ?></td>
                    <td>
                        <?php if ($c['anulado']): ?>
                            <span class="badge bg-danger">ANULADO</span>
                        <?php else: ?>
                            <span class="badge bg-success">ACTIVO</span>
                        <?php endif; ?>
                    </td>
                </tr>
            <?php endforeach; ?>
        </tbody>
    </table>
</div>

<?php if (empty($datos)): ?>
    <div class="alert alert-warning">No se encontraron comprobantes con los filtros seleccionados.</div>
<?php endif; ?>

<!-- Paginación -->
<?php if ($totalPaginas > 1): ?>
<nav>
    <ul class="pagination pagination-sm justify-content-center">
        <li class="page-item <?= $pagina <= 1 ? 'disabled' : '' ?>">
            <a class="page-link" href="<?= pageUrl(1) ?>">««</a>
        </li>
        <li class="page-item <?= $pagina <= 1 ? 'disabled' : '' ?>">
            <a class="page-link" href="<?= pageUrl($pagina - 1) ?>">«</a>
        </li>
        <?php
            $start = max(1, $pagina - 3);
            $end = min($totalPaginas, $pagina + 3);
        ?>
        <?php for ($i = $start; $i <= $end; $i++): ?>
            <li class="page-item <?= $i === $pagina ? 'active' : '' ?>">
                <a class="page-link" href="<?= pageUrl($i) ?>"><?= $i ?></a>
            </li>
        <?php endfor; ?>
        <li class="page-item <?= $pagina >= $totalPaginas ? 'disabled' : '' ?>">
            <a class="page-link" href="<?= pageUrl($pagina + 1) ?>">»</a>
        </li>
        <li class="page-item <?= $pagina >= $totalPaginas ? 'disabled' : '' ?>">
            <a class="page-link" href="<?= pageUrl($totalPaginas) ?>">»»</a>
        </li>
    </ul>
    <p class="text-center text-muted small">Página <?= $pagina ?> de <?= $totalPaginas ?></p>
</nav>
<?php endif; ?>

<?php include 'includes/footer.php'; ?>
