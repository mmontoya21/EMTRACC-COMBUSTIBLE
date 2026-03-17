<?php
require_once 'includes/auth.php';
requireLogin();
if (getUserRole() !== 'SUPERADMIN') { header('Location: index.php'); exit; }
require_once 'includes/config.php';

$pageTitle = 'Log de Accesos';
include 'includes/header.php';

// Filtros
$filtroUsuario = trim($_GET['usuario'] ?? '');
$filtroDesde = trim($_GET['desde'] ?? '');
$filtroHasta = trim($_GET['hasta'] ?? '');

$where = [];
$params = [];
$types = '';

if ($filtroUsuario !== '') { $where[] = "(usuario LIKE ? OR nombre LIKE ?)"; $params[] = "%$filtroUsuario%"; $params[] = "%$filtroUsuario%"; $types .= 'ss'; }
if ($filtroDesde !== '') { $where[] = "fecha >= ?"; $params[] = "$filtroDesde 00:00:00"; $types .= 's'; }
if ($filtroHasta !== '') { $where[] = "fecha <= ?"; $params[] = "$filtroHasta 23:59:59"; $types .= 's'; }

$whereSQL = count($where) > 0 ? 'WHERE ' . implode(' AND ', $where) : '';

// Paginacion
$pagina = max(1, (int)($_GET['pagina'] ?? 1));
$porPagina = 50;
$offset = ($pagina - 1) * $porPagina;

// Total
$stmtC = $conn->prepare("SELECT COUNT(*) as total FROM login_log $whereSQL");
if ($types !== '') $stmtC->bind_param($types, ...$params);
$stmtC->execute();
$total = $stmtC->get_result()->fetch_assoc()['total'];
$stmtC->close();
$totalPaginas = max(1, ceil($total / $porPagina));

// Datos
$sql = "SELECT id, usuario, nombre, tipo, ip, fecha FROM login_log $whereSQL ORDER BY fecha DESC, id DESC LIMIT $porPagina OFFSET $offset";
$stmt = $conn->prepare($sql);
if ($types !== '') $stmt->bind_param($types, ...$params);
$stmt->execute();
$result = $stmt->get_result();
$rows = [];
while ($row = $result->fetch_assoc()) { $rows[] = $row; }
$stmt->close();
?>

<h5 class="mb-2"><i class="bi bi-clock-history"></i> Log de Accesos</h5>

<!-- Filtros -->
<div class="card mb-2">
    <div class="card-header bg-secondary text-white py-1">
        <strong class="small">Filtros</strong>
    </div>
    <div class="card-body p-2">
        <form method="get" class="row g-1 align-items-end">
            <div class="col-6 col-md-3">
                <label class="form-label small mb-0">Usuario / Nombre</label>
                <input type="text" name="usuario" class="form-control form-control-sm" value="<?= htmlspecialchars($filtroUsuario) ?>">
            </div>
            <div class="col-6 col-md-2">
                <label class="form-label small mb-0">Desde</label>
                <input type="date" name="desde" class="form-control form-control-sm" value="<?= htmlspecialchars($filtroDesde) ?>">
            </div>
            <div class="col-6 col-md-2">
                <label class="form-label small mb-0">Hasta</label>
                <input type="date" name="hasta" class="form-control form-control-sm" value="<?= htmlspecialchars($filtroHasta) ?>">
            </div>
            <div class="col-6 col-md-auto d-flex gap-1">
                <button type="submit" class="btn btn-primary btn-sm"><i class="bi bi-search"></i> Buscar</button>
                <a href="login_log.php" class="btn btn-outline-secondary btn-sm"><i class="bi bi-eraser"></i> Limpiar</a>
            </div>
        </form>
    </div>
</div>

<!-- Resumen -->
<div class="d-flex flex-wrap gap-2 mb-2">
    <span class="badge bg-primary">Registros: <?= $total ?></span>
</div>

<!-- Tabla -->
<div class="table-responsive" style="max-height: 70vh; overflow-y: auto;">
    <table class="table table-bordered table-sm table-hover mb-0">
        <thead class="table-dark sticky-top">
            <tr>
                <th style="width:60px">ID</th>
                <th>Usuario</th>
                <th>Nombre</th>
                <th style="width:100px">Tipo</th>
                <th style="width:120px">IP</th>
                <th style="width:160px">Fecha / Hora</th>
            </tr>
        </thead>
        <tbody>
            <?php if (count($rows) === 0): ?>
                <tr><td colspan="6" class="text-center text-muted">No se encontraron registros</td></tr>
            <?php else: ?>
                <?php foreach ($rows as $idx => $r): ?>
                <tr class="<?= $idx % 2 === 0 ? 'row-white' : 'row-blue' ?>">
                    <td><?= htmlspecialchars($r['id']) ?></td>
                    <td><strong><?= htmlspecialchars($r['usuario']) ?></strong></td>
                    <td><?= htmlspecialchars($r['nombre']) ?></td>
                    <td>
                        <?php
                        if ($r['tipo'] === 'SUPERADMIN') $badgeClass = 'bg-danger';
                        elseif ($r['tipo'] === 'ADMIN') $badgeClass = 'bg-warning text-dark';
                        else $badgeClass = 'bg-info text-dark';
                        ?>
                        <span class="badge <?= $badgeClass ?>"><?= htmlspecialchars($r['tipo']) ?></span>
                    </td>
                    <td><small><?= htmlspecialchars($r['ip']) ?></small></td>
                    <td><small><?= date('d/m/Y H:i:s', strtotime($r['fecha'])) ?></small></td>
                </tr>
                <?php endforeach; ?>
            <?php endif; ?>
        </tbody>
    </table>
</div>

<!-- Paginacion -->
<?php if ($totalPaginas > 1): ?>
<nav class="mt-2">
    <ul class="pagination pagination-sm mb-0">
        <?php if ($pagina > 1): ?>
        <li class="page-item"><a class="page-link" href="?pagina=<?= $pagina-1 ?>&usuario=<?= urlencode($filtroUsuario) ?>&desde=<?= urlencode($filtroDesde) ?>&hasta=<?= urlencode($filtroHasta) ?>">&laquo;</a></li>
        <?php endif; ?>
        <?php for ($i = max(1, $pagina-2); $i <= min($totalPaginas, $pagina+2); $i++): ?>
        <li class="page-item <?= $i === $pagina ? 'active' : '' ?>"><a class="page-link" href="?pagina=<?= $i ?>&usuario=<?= urlencode($filtroUsuario) ?>&desde=<?= urlencode($filtroDesde) ?>&hasta=<?= urlencode($filtroHasta) ?>"><?= $i ?></a></li>
        <?php endfor; ?>
        <?php if ($pagina < $totalPaginas): ?>
        <li class="page-item"><a class="page-link" href="?pagina=<?= $pagina+1 ?>&usuario=<?= urlencode($filtroUsuario) ?>&desde=<?= urlencode($filtroDesde) ?>&hasta=<?= urlencode($filtroHasta) ?>">&raquo;</a></li>
        <?php endif; ?>
    </ul>
</nav>
<?php endif; ?>

<?php include 'includes/footer.php'; ?>
