<?php
require_once '../includes/auth.php';
requireLogin();
requirePermisoApi('placa');
require_once '../includes/config.php';

header('Content-Type: application/json; charset=utf-8');

$action = $_GET['action'] ?? $_POST['action'] ?? '';
$role = getUserRole();

function jsonResponse($data, $code = 200) {
    http_response_code($code);
    echo json_encode($data, JSON_UNESCAPED_UNICODE);
    exit;
}

function jsonError($msg, $code = 400) {
    jsonResponse(['error' => $msg], $code);
}

switch ($action) {

// ==================== LIST ====================
case 'list':
    $where = [];
    $params = [];
    $types = '';

    $filtroCodigo = $_GET['codigo'] ?? '';
    $filtroPropietario = $_GET['propietario'] ?? '';
    $filtroPlaca = $_GET['placa'] ?? '';
    $filtroEstado = $_GET['estado'] ?? '';

    if ($filtroCodigo !== '') { $where[] = "codigoPro LIKE ?"; $params[] = "%$filtroCodigo%"; $types .= 's'; }
    if ($filtroPropietario !== '') { $where[] = "propietario LIKE ?"; $params[] = "%$filtroPropietario%"; $types .= 's'; }
    if ($filtroPlaca !== '') { $where[] = "placa LIKE ?"; $params[] = "%$filtroPlaca%"; $types .= 's'; }
    if ($filtroEstado === 'activo') { $where[] = "activo = 1"; }
    elseif ($filtroEstado === 'bloqueado') { $where[] = "activo = 0"; }

    $whereSQL = count($where) > 0 ? 'WHERE ' . implode(' AND ', $where) : '';

    // Totales
    $sqlCount = "SELECT COUNT(*) as total,
                 SUM(CASE WHEN activo = 1 THEN 1 ELSE 0 END) as activos,
                 SUM(CASE WHEN activo = 0 THEN 1 ELSE 0 END) as bloqueados
                 FROM placa $whereSQL";
    $stmtC = $conn->prepare($sqlCount);
    if ($types !== '') $stmtC->bind_param($types, ...$params);
    $stmtC->execute();
    $totales = $stmtC->get_result()->fetch_assoc();
    $stmtC->close();

    // Paginacion
    $pagina = max(1, (int)($_GET['pagina'] ?? 1));
    $porPagina = 50;
    $offset = ($pagina - 1) * $porPagina;

    // Datos
    $sql = "SELECT idPlaca, codigoPro, placa, propietario, observaciones, activo
            FROM placa $whereSQL
            ORDER BY placa ASC
            LIMIT $porPagina OFFSET $offset";
    $stmt = $conn->prepare($sql);
    if ($types !== '') $stmt->bind_param($types, ...$params);
    $stmt->execute();
    $result = $stmt->get_result();
    $rows = [];
    while ($row = $result->fetch_assoc()) {
        $rows[] = $row;
    }
    $stmt->close();

    jsonResponse([
        'rows' => $rows,
        'total' => (int)$totales['total'],
        'activos' => (int)($totales['activos'] ?? 0),
        'bloqueados' => (int)($totales['bloqueados'] ?? 0),
        'pagina' => $pagina,
        'totalPaginas' => max(1, ceil((int)$totales['total'] / $porPagina))
    ]);
    break;

// ==================== GET ====================
case 'get':
    $id = (int)($_GET['id'] ?? 0);
    if ($id <= 0) jsonError('ID invalido');

    $stmt = $conn->prepare("SELECT * FROM placa WHERE idPlaca = ?");
    $stmt->bind_param('i', $id);
    $stmt->execute();
    $row = $stmt->get_result()->fetch_assoc();
    $stmt->close();

    if (!$row) jsonError('Registro no encontrado', 404);
    jsonResponse($row);
    break;

// ==================== CREATE ====================
case 'create':
    if ($_SERVER['REQUEST_METHOD'] !== 'POST') jsonError('Metodo no permitido', 405);
    requireNotReadOnlyApi();

    $codigoPro = trim($_POST['codigoPro'] ?? '');
    $propietario = trim($_POST['propietario'] ?? '');
    $placa = mb_strtoupper(trim($_POST['placa'] ?? ''));
    $observaciones = trim($_POST['observaciones'] ?? '');

    if ($placa === '') jsonError('La placa es obligatoria');

    // Verificar placa duplicada
    $stmt = $conn->prepare("SELECT idPlaca FROM placa WHERE placa = ?");
    $stmt->bind_param('s', $placa);
    $stmt->execute();
    if ($stmt->get_result()->num_rows > 0) {
        $stmt->close();
        jsonError('Ya existe una placa con el numero ' . $placa);
    }
    $stmt->close();

    $stmt = $conn->prepare("INSERT INTO placa (codigoPro, propietario, placa, observaciones, activo) VALUES (?, ?, ?, ?, 1)");
    $stmt->bind_param('ssss', $codigoPro, $propietario, $placa, $observaciones);

    if ($stmt->execute()) {
        $newId = $conn->insert_id;
        $stmt->close();
        jsonResponse(['success' => true, 'id' => $newId, 'message' => 'Placa guardada correctamente']);
    } else {
        $stmt->close();
        jsonError('Error al guardar: ' . $conn->error, 500);
    }
    break;

// ==================== UPDATE ====================
case 'update':
    if ($_SERVER['REQUEST_METHOD'] !== 'POST') jsonError('Metodo no permitido', 405);
    requireNotReadOnlyApi();

    $id = (int)($_POST['id'] ?? 0);
    if ($id <= 0) jsonError('ID invalido');

    $codigoPro = trim($_POST['codigoPro'] ?? '');
    $propietario = trim($_POST['propietario'] ?? '');
    $placa = mb_strtoupper(trim($_POST['placa'] ?? ''));
    $observaciones = trim($_POST['observaciones'] ?? '');

    if ($placa === '') jsonError('La placa es obligatoria');

    // Verificar placa duplicada (excluyendo el registro actual)
    $stmt = $conn->prepare("SELECT idPlaca FROM placa WHERE placa = ? AND idPlaca != ?");
    $stmt->bind_param('si', $placa, $id);
    $stmt->execute();
    if ($stmt->get_result()->num_rows > 0) {
        $stmt->close();
        jsonError('Ya existe otra placa con el numero ' . $placa);
    }
    $stmt->close();

    $stmt = $conn->prepare("UPDATE placa SET codigoPro=?, propietario=?, placa=?, observaciones=? WHERE idPlaca=?");
    $stmt->bind_param('ssssi', $codigoPro, $propietario, $placa, $observaciones, $id);

    if ($stmt->execute()) {
        $stmt->close();
        jsonResponse(['success' => true, 'message' => 'Placa modificada correctamente']);
    } else {
        $stmt->close();
        jsonError('Error al modificar: ' . $conn->error, 500);
    }
    break;

// ==================== DELETE ====================
case 'delete':
    if ($_SERVER['REQUEST_METHOD'] !== 'POST') jsonError('Metodo no permitido', 405);
    if (!in_array($role, ['ADMIN', 'SUPERADMIN'])) jsonError('No tiene permisos para eliminar', 403);

    $id = (int)($_POST['id'] ?? 0);
    if ($id <= 0) jsonError('ID invalido');

    $stmt = $conn->prepare("DELETE FROM placa WHERE idPlaca = ?");
    $stmt->bind_param('i', $id);

    if ($stmt->execute()) {
        $stmt->close();
        jsonResponse(['success' => true, 'message' => 'Placa eliminada correctamente']);
    } else {
        $stmt->close();
        jsonError('Error al eliminar: ' . $conn->error, 500);
    }
    break;

// ==================== BLOCK / UNBLOCK ====================
case 'block':
    if ($_SERVER['REQUEST_METHOD'] !== 'POST') jsonError('Metodo no permitido', 405);
    requireNotReadOnlyApi();

    $id = (int)($_POST['id'] ?? 0);
    if ($id <= 0) jsonError('ID invalido');

    $stmt = $conn->prepare("UPDATE placa SET activo = 0 WHERE idPlaca = ?");
    $stmt->bind_param('i', $id);

    if ($stmt->execute()) {
        $stmt->close();
        jsonResponse(['success' => true, 'message' => 'Placa bloqueada']);
    } else {
        $stmt->close();
        jsonError('Error al bloquear: ' . $conn->error, 500);
    }
    break;

case 'unblock':
    if ($_SERVER['REQUEST_METHOD'] !== 'POST') jsonError('Metodo no permitido', 405);
    requireNotReadOnlyApi();

    $id = (int)($_POST['id'] ?? 0);
    if ($id <= 0) jsonError('ID invalido');

    $stmt = $conn->prepare("UPDATE placa SET activo = 1 WHERE idPlaca = ?");
    $stmt->bind_param('i', $id);

    if ($stmt->execute()) {
        $stmt->close();
        jsonResponse(['success' => true, 'message' => 'Placa desbloqueada']);
    } else {
        $stmt->close();
        jsonError('Error al desbloquear: ' . $conn->error, 500);
    }
    break;

// ==================== AUTOCOMPLETE CODIGO ====================
case 'autoCodigo':
    $q = $_GET['q'] ?? '';
    if (strlen($q) < 1) jsonResponse([]);
    $like = "%$q%";
    $stmt = $conn->prepare("SELECT codProp, nPropietario FROM propietario WHERE codProp LIKE ? ORDER BY codProp LIMIT 15");
    $stmt->bind_param('s', $like);
    $stmt->execute();
    $result = $stmt->get_result();
    $items = [];
    while ($row = $result->fetch_assoc()) $items[] = $row;
    $stmt->close();
    jsonResponse($items);
    break;

// ==================== AUTOCOMPLETE PROPIETARIO ====================
case 'autoPropietario':
    $q = $_GET['q'] ?? '';
    if (strlen($q) < 1) jsonResponse([]);
    $like = "%$q%";
    $stmt = $conn->prepare("SELECT codProp, nPropietario FROM propietario WHERE nPropietario LIKE ? ORDER BY nPropietario LIMIT 15");
    $stmt->bind_param('s', $like);
    $stmt->execute();
    $result = $stmt->get_result();
    $items = [];
    while ($row = $result->fetch_assoc()) $items[] = $row;
    $stmt->close();
    jsonResponse($items);
    break;

// ==================== LOOKUP CODIGO → PROPIETARIO ====================
case 'lookupCodigo':
    $codigo = $_GET['codigo'] ?? '';
    if ($codigo === '') jsonResponse(['codProp' => '', 'nPropietario' => '']);
    $stmt = $conn->prepare("SELECT codProp, nPropietario FROM propietario WHERE codProp = ? LIMIT 1");
    $stmt->bind_param('s', $codigo);
    $stmt->execute();
    $row = $stmt->get_result()->fetch_assoc();
    $stmt->close();
    jsonResponse([
        'codProp' => $row['codProp'] ?? '',
        'nPropietario' => $row['nPropietario'] ?? ''
    ]);
    break;

// ==================== LOOKUP PROPIETARIO → CODIGO ====================
case 'lookupPropietario':
    $nombre = $_GET['nombre'] ?? '';
    if ($nombre === '') jsonResponse(['codProp' => '', 'nPropietario' => '']);
    $stmt = $conn->prepare("SELECT codProp, nPropietario FROM propietario WHERE nPropietario = ? LIMIT 1");
    $stmt->bind_param('s', $nombre);
    $stmt->execute();
    $row = $stmt->get_result()->fetch_assoc();
    $stmt->close();
    jsonResponse([
        'codProp' => $row['codProp'] ?? '',
        'nPropietario' => $row['nPropietario'] ?? ''
    ]);
    break;

default:
    jsonError('Accion no reconocida: ' . $action, 400);
}
