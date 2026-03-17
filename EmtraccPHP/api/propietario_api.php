<?php
require_once '../includes/auth.php';
requireLogin();
requirePermisoApi('propietario');
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

    if ($filtroCodigo !== '') { $where[] = "codProp LIKE ?"; $params[] = "%$filtroCodigo%"; $types .= 's'; }
    if ($filtroPropietario !== '') { $where[] = "nPropietario LIKE ?"; $params[] = "%$filtroPropietario%"; $types .= 's'; }

    $whereSQL = count($where) > 0 ? 'WHERE ' . implode(' AND ', $where) : '';

    // Totales
    $stmtC = $conn->prepare("SELECT COUNT(*) as total FROM propietario $whereSQL");
    if ($types !== '') $stmtC->bind_param($types, ...$params);
    $stmtC->execute();
    $totales = $stmtC->get_result()->fetch_assoc();
    $stmtC->close();

    // Paginacion
    $pagina = max(1, (int)($_GET['pagina'] ?? 1));
    $porPagina = 50;
    $offset = ($pagina - 1) * $porPagina;

    // Datos
    $sql = "SELECT codigoP, codProp, nPropietario, nEmpresa, RTN, tel1, tel2, direccion, correoE
            FROM propietario $whereSQL
            ORDER BY nPropietario ASC
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

    $stmt = $conn->prepare("SELECT * FROM propietario WHERE codigoP = ?");
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

    $codProp = trim($_POST['codProp'] ?? '');
    $nEmpresa = mb_strtoupper(trim($_POST['nEmpresa'] ?? ''));
    $nPropietario = mb_strtoupper(trim($_POST['nPropietario'] ?? ''));
    $RTN = trim($_POST['RTN'] ?? '');
    $tel1 = trim($_POST['tel1'] ?? '');
    $tel2 = trim($_POST['tel2'] ?? '');
    $direccion = trim($_POST['direccion'] ?? '');
    $correoE = trim($_POST['correoE'] ?? '');

    if ($codProp === '') jsonError('El codigo de propietario es obligatorio');
    if ($nPropietario === '') jsonError('El nombre del propietario es obligatorio');

    // Verificar codigo duplicado
    $stmt = $conn->prepare("SELECT codigoP FROM propietario WHERE codProp = ?");
    $stmt->bind_param('s', $codProp);
    $stmt->execute();
    if ($stmt->get_result()->num_rows > 0) {
        $stmt->close();
        jsonError('Ya existe un propietario con el codigo ' . $codProp);
    }
    $stmt->close();

    $stmt = $conn->prepare("INSERT INTO propietario (codProp, nEmpresa, nPropietario, RTN, tel1, tel2, direccion, correoE) VALUES (?, ?, ?, ?, ?, ?, ?, ?)");
    $stmt->bind_param('ssssssss', $codProp, $nEmpresa, $nPropietario, $RTN, $tel1, $tel2, $direccion, $correoE);

    if ($stmt->execute()) {
        $newId = $conn->insert_id;
        $stmt->close();
        jsonResponse(['success' => true, 'id' => $newId, 'message' => 'Propietario guardado correctamente']);
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

    $codProp = trim($_POST['codProp'] ?? '');
    $nEmpresa = mb_strtoupper(trim($_POST['nEmpresa'] ?? ''));
    $nPropietario = mb_strtoupper(trim($_POST['nPropietario'] ?? ''));
    $RTN = trim($_POST['RTN'] ?? '');
    $tel1 = trim($_POST['tel1'] ?? '');
    $tel2 = trim($_POST['tel2'] ?? '');
    $direccion = trim($_POST['direccion'] ?? '');
    $correoE = trim($_POST['correoE'] ?? '');

    if ($codProp === '') jsonError('El codigo de propietario es obligatorio');
    if ($nPropietario === '') jsonError('El nombre del propietario es obligatorio');

    // Verificar codigo duplicado (excluyendo el registro actual)
    $stmt = $conn->prepare("SELECT codigoP FROM propietario WHERE codProp = ? AND codigoP != ?");
    $stmt->bind_param('si', $codProp, $id);
    $stmt->execute();
    if ($stmt->get_result()->num_rows > 0) {
        $stmt->close();
        jsonError('Ya existe otro propietario con el codigo ' . $codProp);
    }
    $stmt->close();

    $stmt = $conn->prepare("UPDATE propietario SET codProp=?, nEmpresa=?, nPropietario=?, RTN=?, tel1=?, tel2=?, direccion=?, correoE=? WHERE codigoP=?");
    $stmt->bind_param('ssssssssi', $codProp, $nEmpresa, $nPropietario, $RTN, $tel1, $tel2, $direccion, $correoE, $id);

    if ($stmt->execute()) {
        $stmt->close();
        jsonResponse(['success' => true, 'message' => 'Propietario modificado correctamente']);
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

    // Verificar si tiene placas asociadas
    $stmt = $conn->prepare("SELECT p.codProp FROM propietario p WHERE p.codigoP = ?");
    $stmt->bind_param('i', $id);
    $stmt->execute();
    $prop = $stmt->get_result()->fetch_assoc();
    $stmt->close();

    if (!$prop) jsonError('Registro no encontrado', 404);

    $stmt = $conn->prepare("SELECT COUNT(*) as cnt FROM placa WHERE codigoPro = ?");
    $stmt->bind_param('s', $prop['codProp']);
    $stmt->execute();
    $cnt = $stmt->get_result()->fetch_assoc()['cnt'];
    $stmt->close();

    if ($cnt > 0) jsonError("No se puede eliminar: tiene $cnt placa(s) asociada(s). Elimine las placas primero.");

    $stmt = $conn->prepare("DELETE FROM propietario WHERE codigoP = ?");
    $stmt->bind_param('i', $id);

    if ($stmt->execute()) {
        $stmt->close();
        jsonResponse(['success' => true, 'message' => 'Propietario eliminado correctamente']);
    } else {
        $stmt->close();
        jsonError('Error al eliminar: ' . $conn->error, 500);
    }
    break;

// ==================== PLACAS DEL PROPIETARIO ====================
case 'placas':
    $codProp = $_GET['codProp'] ?? '';
    if ($codProp === '') jsonResponse([]);

    $stmt = $conn->prepare("SELECT idPlaca, codigoPro, placa, propietario, observaciones, activo FROM placa WHERE codigoPro = ? ORDER BY placa");
    $stmt->bind_param('s', $codProp);
    $stmt->execute();
    $result = $stmt->get_result();
    $items = [];
    while ($row = $result->fetch_assoc()) $items[] = $row;
    $stmt->close();
    jsonResponse($items);
    break;

default:
    jsonError('Accion no reconocida: ' . $action, 400);
}
