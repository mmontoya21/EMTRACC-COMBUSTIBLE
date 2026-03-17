<?php
require_once '../includes/auth.php';
requireLogin();
requirePermisoApi('valorComb');
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

    $fechaDesde = $_GET['fecha_desde'] ?? '';
    $fechaHasta = $_GET['fecha_hasta'] ?? '';

    if ($fechaDesde !== '') { $where[] = "fecha >= ?"; $params[] = $fechaDesde; $types .= 's'; }
    if ($fechaHasta !== '') { $where[] = "fecha <= ?"; $params[] = $fechaHasta; $types .= 's'; }

    $whereSQL = count($where) > 0 ? 'WHERE ' . implode(' AND ', $where) : '';

    // Totales
    $stmtC = $conn->prepare("SELECT COUNT(*) as total FROM valorComb $whereSQL");
    if ($types !== '') $stmtC->bind_param($types, ...$params);
    $stmtC->execute();
    $totales = $stmtC->get_result()->fetch_assoc();
    $stmtC->close();

    // Paginacion
    $pagina = max(1, (int)($_GET['pagina'] ?? 1));
    $porPagina = 50;
    $offset = ($pagina - 1) * $porPagina;

    // Datos
    $sql = "SELECT valorId, valorCombustible, fecha, descripcion, activo FROM valorComb $whereSQL ORDER BY fecha DESC, valorId DESC LIMIT $porPagina OFFSET $offset";
    $stmt = $conn->prepare($sql);
    if ($types !== '') $stmt->bind_param($types, ...$params);
    $stmt->execute();
    $result = $stmt->get_result();
    $rows = [];
    while ($row = $result->fetch_assoc()) {
        // Formato fecha dd/mm/yyyy
        if ($row['fecha']) {
            $dt = DateTime::createFromFormat('Y-m-d', $row['fecha']);
            $row['fechaFmt'] = $dt ? $dt->format('d/m/Y') : $row['fecha'];
        } else {
            $row['fechaFmt'] = '';
        }
        $rows[] = $row;
    }
    $stmt->close();

    jsonResponse([
        'rows' => $rows,
        'total' => (int)$totales['total'],
        'pagina' => $pagina,
        'totalPaginas' => max(1, ceil((int)$totales['total'] / $porPagina))
    ]);
    break;

// ==================== GET ====================
case 'get':
    $id = (int)($_GET['id'] ?? 0);
    if ($id <= 0) jsonError('ID invalido');

    $stmt = $conn->prepare("SELECT valorId, valorCombustible, fecha, descripcion, activo FROM valorComb WHERE valorId = ?");
    $stmt->bind_param('i', $id);
    $stmt->execute();
    $row = $stmt->get_result()->fetch_assoc();
    $stmt->close();

    if (!$row) jsonError('Registro no encontrado', 404);
    jsonResponse($row);
    break;

// ==================== PRECIO ACTUAL ====================
case 'precioActual':
    $stmt = $conn->prepare("SELECT valorCombustible, fecha FROM valorComb WHERE activo = 1 ORDER BY fecha DESC LIMIT 1");
    $stmt->execute();
    $row = $stmt->get_result()->fetch_assoc();
    $stmt->close();

    if ($row) {
        $dt = DateTime::createFromFormat('Y-m-d', $row['fecha']);
        jsonResponse([
            'precio' => $row['valorCombustible'],
            'fecha' => $dt ? $dt->format('d/m/Y') : $row['fecha']
        ]);
    } else {
        jsonResponse(['precio' => null]);
    }
    break;

// ==================== CREATE ====================
case 'create':
    if ($_SERVER['REQUEST_METHOD'] !== 'POST') jsonError('Metodo no permitido', 405);
    requireNotReadOnlyApi();

    $valorCombustible = trim($_POST['valorCombustible'] ?? '');
    $fecha = trim($_POST['fecha'] ?? '');
    $descripcion = trim($_POST['descripcion'] ?? '');
    $activo = (int)($_POST['activo'] ?? 0);

    if ($valorCombustible === '') jsonError('El precio es obligatorio');
    if (!is_numeric($valorCombustible)) jsonError('El precio debe ser un valor numerico');
    if ($fecha === '') jsonError('La fecha es obligatoria');

    $stmt = $conn->prepare("INSERT INTO valorComb (valorCombustible, fecha, descripcion, activo) VALUES (?, ?, ?, ?)");
    $stmt->bind_param('dssi', $valorCombustible, $fecha, $descripcion, $activo);

    if ($stmt->execute()) {
        $newId = $conn->insert_id;
        $stmt->close();
        jsonResponse(['success' => true, 'id' => $newId, 'message' => 'Precio guardado correctamente']);
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

    $valorCombustible = trim($_POST['valorCombustible'] ?? '');
    $fecha = trim($_POST['fecha'] ?? '');
    $descripcion = trim($_POST['descripcion'] ?? '');
    $activo = (int)($_POST['activo'] ?? 0);

    if ($valorCombustible === '') jsonError('El precio es obligatorio');
    if (!is_numeric($valorCombustible)) jsonError('El precio debe ser un valor numerico');
    if ($fecha === '') jsonError('La fecha es obligatoria');

    $stmt = $conn->prepare("UPDATE valorComb SET valorCombustible=?, fecha=?, descripcion=?, activo=? WHERE valorId=?");
    $stmt->bind_param('dssii', $valorCombustible, $fecha, $descripcion, $activo, $id);

    if ($stmt->execute()) {
        $stmt->close();
        jsonResponse(['success' => true, 'message' => 'Precio modificado correctamente']);
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

    $stmt = $conn->prepare("DELETE FROM valorComb WHERE valorId = ?");
    $stmt->bind_param('i', $id);

    if ($stmt->execute()) {
        $stmt->close();
        jsonResponse(['success' => true, 'message' => 'Precio eliminado correctamente']);
    } else {
        $stmt->close();
        jsonError('Error al eliminar: ' . $conn->error, 500);
    }
    break;

default:
    jsonError('Accion no reconocida: ' . $action, 400);
}
