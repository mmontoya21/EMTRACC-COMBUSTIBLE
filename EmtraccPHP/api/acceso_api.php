<?php
require_once '../includes/auth.php';
requireLogin();
requirePermisoApi('acceso');
require_once '../includes/config.php';

header('Content-Type: application/json; charset=utf-8');

$role = getUserRole();
if ($role !== 'SUPERADMIN') {
    http_response_code(403);
    echo json_encode(['error' => 'Acceso denegado'], JSON_UNESCAPED_UNICODE);
    exit;
}

$action = $_GET['action'] ?? $_POST['action'] ?? '';

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

    $filtroUsuario = $_GET['usuario'] ?? '';
    $filtroNombre = $_GET['nombre'] ?? '';

    if ($filtroUsuario !== '') { $where[] = "usuario LIKE ?"; $params[] = "%$filtroUsuario%"; $types .= 's'; }
    if ($filtroNombre !== '') { $where[] = "CONCAT(nombre, ' ', apellido) LIKE ?"; $params[] = "%$filtroNombre%"; $types .= 's'; }

    $whereSQL = count($where) > 0 ? 'WHERE ' . implode(' AND ', $where) : '';

    // Totales
    $stmtC = $conn->prepare("SELECT COUNT(*) as total FROM accesos $whereSQL");
    if ($types !== '') $stmtC->bind_param($types, ...$params);
    $stmtC->execute();
    $totales = $stmtC->get_result()->fetch_assoc();
    $stmtC->close();

    // Paginacion
    $pagina = max(1, (int)($_GET['pagina'] ?? 1));
    $porPagina = 50;
    $offset = ($pagina - 1) * $porPagina;

    // Datos
    $sql = "SELECT id, nombre, apellido, usuario, tipo, status, fecha
            FROM accesos $whereSQL
            ORDER BY nombre ASC
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
        'pagina' => $pagina,
        'totalPaginas' => max(1, ceil((int)$totales['total'] / $porPagina))
    ]);
    break;

// ==================== GET ====================
case 'get':
    $id = (int)($_GET['id'] ?? 0);
    if ($id <= 0) jsonError('ID invalido');

    $stmt = $conn->prepare("SELECT id, nombre, apellido, usuario, tipo, status, fecha, permisos FROM accesos WHERE id = ?");
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

    $nombre = mb_strtoupper(trim($_POST['nombre'] ?? ''));
    $apellido = mb_strtoupper(trim($_POST['apellido'] ?? ''));
    $usuario = trim($_POST['usuario'] ?? '');
    $clave = $_POST['clave'] ?? '';
    $tipo = trim($_POST['tipo'] ?? '');
    $status = trim($_POST['status'] ?? '');
    $fecha = trim($_POST['fecha'] ?? '');
    $permisos = trim($_POST['permisos'] ?? '');

    if ($nombre === '') jsonError('El nombre es obligatorio');
    if ($apellido === '') jsonError('El apellido es obligatorio');
    if ($usuario === '') jsonError('El usuario es obligatorio');
    if ($clave === '') jsonError('La clave es obligatoria para nuevos usuarios');
    if ($tipo === '') jsonError('El tipo es obligatorio');
    if ($status === '') jsonError('El status es obligatorio');
    if ($fecha === '') jsonError('La fecha es obligatoria');

    // Verificar usuario duplicado
    $stmt = $conn->prepare("SELECT id FROM accesos WHERE usuario = ?");
    $stmt->bind_param('s', $usuario);
    $stmt->execute();
    if ($stmt->get_result()->num_rows > 0) {
        $stmt->close();
        jsonError('Ya existe un usuario con el nombre "' . $usuario . '"');
    }
    $stmt->close();

    // Hash de clave (SHA256 uppercase, igual que VB.NET)
    $hashedClave = strtoupper(hash('sha256', $clave));

    $stmt = $conn->prepare("INSERT INTO accesos (nombre, apellido, usuario, clave, tipo, status, fecha, permisos) VALUES (?, ?, ?, ?, ?, ?, ?, ?)");
    $stmt->bind_param('ssssssss', $nombre, $apellido, $usuario, $hashedClave, $tipo, $status, $fecha, $permisos);

    if ($stmt->execute()) {
        $newId = $conn->insert_id;
        $stmt->close();
        jsonResponse(['success' => true, 'id' => $newId, 'message' => 'Usuario guardado correctamente']);
    } else {
        $stmt->close();
        jsonError('Error al guardar: ' . $conn->error, 500);
    }
    break;

// ==================== UPDATE ====================
case 'update':
    if ($_SERVER['REQUEST_METHOD'] !== 'POST') jsonError('Metodo no permitido', 405);

    $id = (int)($_POST['id'] ?? 0);
    if ($id <= 0) jsonError('ID invalido');

    $nombre = mb_strtoupper(trim($_POST['nombre'] ?? ''));
    $apellido = mb_strtoupper(trim($_POST['apellido'] ?? ''));
    $usuario = trim($_POST['usuario'] ?? '');
    $clave = $_POST['clave'] ?? '';
    $tipo = trim($_POST['tipo'] ?? '');
    $status = trim($_POST['status'] ?? '');
    $fecha = trim($_POST['fecha'] ?? '');
    $permisos = trim($_POST['permisos'] ?? '');

    if ($nombre === '') jsonError('El nombre es obligatorio');
    if ($apellido === '') jsonError('El apellido es obligatorio');
    if ($usuario === '') jsonError('El usuario es obligatorio');
    if ($tipo === '') jsonError('El tipo es obligatorio');
    if ($status === '') jsonError('El status es obligatorio');
    if ($fecha === '') jsonError('La fecha es obligatoria');

    // Verificar usuario duplicado (excluyendo el registro actual)
    $stmt = $conn->prepare("SELECT id FROM accesos WHERE usuario = ? AND id != ?");
    $stmt->bind_param('si', $usuario, $id);
    $stmt->execute();
    if ($stmt->get_result()->num_rows > 0) {
        $stmt->close();
        jsonError('Ya existe otro usuario con el nombre "' . $usuario . '"');
    }
    $stmt->close();

    // Update condicional: si clave no esta vacia, hashear e incluir
    if ($clave !== '') {
        $hashedClave = strtoupper(hash('sha256', $clave));
        $stmt = $conn->prepare("UPDATE accesos SET nombre=?, apellido=?, usuario=?, clave=?, tipo=?, status=?, fecha=?, permisos=? WHERE id=?");
        $stmt->bind_param('ssssssssi', $nombre, $apellido, $usuario, $hashedClave, $tipo, $status, $fecha, $permisos, $id);
    } else {
        $stmt = $conn->prepare("UPDATE accesos SET nombre=?, apellido=?, usuario=?, tipo=?, status=?, fecha=?, permisos=? WHERE id=?");
        $stmt->bind_param('sssssssi', $nombre, $apellido, $usuario, $tipo, $status, $fecha, $permisos, $id);
    }

    if ($stmt->execute()) {
        $stmt->close();
        jsonResponse(['success' => true, 'message' => 'Usuario modificado correctamente']);
    } else {
        $stmt->close();
        jsonError('Error al modificar: ' . $conn->error, 500);
    }
    break;

// ==================== DELETE ====================
case 'delete':
    if ($_SERVER['REQUEST_METHOD'] !== 'POST') jsonError('Metodo no permitido', 405);

    $id = (int)($_POST['id'] ?? 0);
    if ($id <= 0) jsonError('ID invalido');

    $stmt = $conn->prepare("DELETE FROM accesos WHERE id = ?");
    $stmt->bind_param('i', $id);

    if ($stmt->execute()) {
        $stmt->close();
        jsonResponse(['success' => true, 'message' => 'Usuario eliminado correctamente']);
    } else {
        $stmt->close();
        jsonError('Error al eliminar: ' . $conn->error, 500);
    }
    break;

default:
    jsonError('Accion no reconocida: ' . $action, 400);
}
