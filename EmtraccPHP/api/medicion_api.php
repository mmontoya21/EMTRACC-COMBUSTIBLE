<?php
require_once '../includes/auth.php';
requireLogin();
requirePermisoApi('medicion');
require_once '../includes/config.php';

header('Content-Type: application/json; charset=utf-8');

$action = $_GET['action'] ?? $_POST['action'] ?? '';
$userName = getUserName();

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
    $pagina = max(1, (int)($_GET['pagina'] ?? 1));
    $porPagina = 50;
    $offset = ($pagina - 1) * $porPagina;

    // Totales
    $res = $conn->query("SELECT COUNT(*) as total FROM tanquemed");
    $totalRegistros = (int)$res->fetch_assoc()['total'];

    $sql = "SELECT idMedida, DATE_FORMAT(fecha, '%d/%m/%Y') AS fechaFmt, fecha, periodo, semana,
                   galonesCalc, galonesMed, galDespachados, galEsperados, diferencia
            FROM tanquemed ORDER BY idMedida DESC
            LIMIT $porPagina OFFSET $offset";
    $result = $conn->query($sql);
    $rows = [];
    while ($row = $result->fetch_assoc()) {
        $rows[] = $row;
    }

    jsonResponse([
        'rows' => $rows,
        'total' => $totalRegistros,
        'pagina' => $pagina,
        'totalPaginas' => max(1, ceil($totalRegistros / $porPagina))
    ]);
    break;

// ==================== GET ====================
case 'get':
    $id = (int)($_GET['id'] ?? 0);
    if ($id <= 0) jsonError('ID invalido');

    $stmt = $conn->prepare("SELECT * FROM tanquemed WHERE idMedida = ?");
    $stmt->bind_param('i', $id);
    $stmt->execute();
    $row = $stmt->get_result()->fetch_assoc();
    $stmt->close();

    if (!$row) jsonError('Registro no encontrado', 404);
    jsonResponse($row);
    break;

// ==================== LAST CAPACITY ====================
case 'lastCapacity':
    $res = $conn->query("SELECT capacidadTanque FROM tanquemed WHERE capacidadTanque > 0 ORDER BY idMedida DESC LIMIT 1");
    $row = $res->fetch_assoc();
    jsonResponse(['capacidad' => $row ? (float)$row['capacidadTanque'] : 0]);
    break;

// ==================== LAST MEASUREMENT (for chart) ====================
case 'lastMeasurement':
    $res = $conn->query("SELECT galonesCalc, galonesMed, galEsperados, capacidadTanque, diferencia FROM tanquemed ORDER BY idMedida DESC LIMIT 1");
    $row = $res->fetch_assoc();
    jsonResponse([
        'galInicio' => $row ? (float)$row['galonesCalc'] : 0,
        'galFinal' => $row ? (float)$row['galonesMed'] : 0,
        'galEsperado' => $row ? (float)$row['galEsperados'] : 0,
        'capacidad' => $row ? (float)$row['capacidadTanque'] : 0,
        'diferencia' => $row ? (float)$row['diferencia'] : 0
    ]);
    break;

// ==================== CALC DESPACHADOS ====================
case 'calcDespachados':
    $periodo = $_GET['periodo'] ?? '';
    $semana = $_GET['semana'] ?? '';
    if ($periodo === '' || $semana === '') jsonError('Periodo y semana son requeridos');

    $stmt = $conn->prepare("SELECT COALESCE(SUM(galDesp), 0) as totalDesp FROM comprobante WHERE periodo = ? AND semana = ? AND (anulado = 0 OR anulado IS NULL)");
    $stmt->bind_param('ss', $periodo, $semana);
    $stmt->execute();
    $row = $stmt->get_result()->fetch_assoc();
    $stmt->close();

    jsonResponse(['totalDespachados' => (float)$row['totalDesp']]);
    break;

// ==================== CREATE ====================
case 'create':
    if ($_SERVER['REQUEST_METHOD'] !== 'POST') jsonError('Metodo no permitido', 405);
    requireNotReadOnlyApi();

    $fecha = trim($_POST['fecha'] ?? date('Y-m-d'));
    $galonesCalc = (float)($_POST['galonesCalc'] ?? 0);
    $pglCal = (float)($_POST['pglCal'] ?? 0);
    $galonesMed = (float)($_POST['galonesMed'] ?? 0);
    $pglMed = (float)($_POST['pglMed'] ?? 0);
    $periodo = $_POST['periodo'] !== '' ? (int)$_POST['periodo'] : null;
    $semana = $_POST['semana'] !== '' ? (int)$_POST['semana'] : null;
    $capacidadTanque = (float)($_POST['capacidadTanque'] ?? 0);
    $galRecibidos = (float)($_POST['galRecibidos'] ?? 0);
    $galDespachados = (float)($_POST['galDespachados'] ?? 0);
    $galEsperados = (float)($_POST['galEsperados'] ?? 0);
    $diferencia = (float)($_POST['diferencia'] ?? 0);
    $observaciones = trim($_POST['observaciones'] ?? '');

    $stmt = $conn->prepare("INSERT INTO tanquemed (fecha, galonesCalc, pglCal, galonesMed, pglMed, periodo, semana, capacidadTanque, galRecibidos, galDespachados, galEsperados, diferencia, observaciones) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)");
    $stmt->bind_param('sddddiiddddds', $fecha, $galonesCalc, $pglCal, $galonesMed, $pglMed, $periodo, $semana, $capacidadTanque, $galRecibidos, $galDespachados, $galEsperados, $diferencia, $observaciones);

    if ($stmt->execute()) {
        $newId = $conn->insert_id;
        $stmt->close();
        jsonResponse(['success' => true, 'id' => $newId, 'message' => 'Registro guardado']);
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

    $fecha = trim($_POST['fecha'] ?? date('Y-m-d'));
    $galonesCalc = (float)($_POST['galonesCalc'] ?? 0);
    $pglCal = (float)($_POST['pglCal'] ?? 0);
    $galonesMed = (float)($_POST['galonesMed'] ?? 0);
    $pglMed = (float)($_POST['pglMed'] ?? 0);
    $periodo = $_POST['periodo'] !== '' ? (int)$_POST['periodo'] : null;
    $semana = $_POST['semana'] !== '' ? (int)$_POST['semana'] : null;
    $capacidadTanque = (float)($_POST['capacidadTanque'] ?? 0);
    $galRecibidos = (float)($_POST['galRecibidos'] ?? 0);
    $galDespachados = (float)($_POST['galDespachados'] ?? 0);
    $galEsperados = (float)($_POST['galEsperados'] ?? 0);
    $diferencia = (float)($_POST['diferencia'] ?? 0);
    $observaciones = trim($_POST['observaciones'] ?? '');

    $stmt = $conn->prepare("UPDATE tanquemed SET fecha=?, galonesCalc=?, pglCal=?, galonesMed=?, pglMed=?, periodo=?, semana=?, capacidadTanque=?, galRecibidos=?, galDespachados=?, galEsperados=?, diferencia=?, observaciones=? WHERE idMedida=?");
    $stmt->bind_param('sddddiiddddsi', $fecha, $galonesCalc, $pglCal, $galonesMed, $pglMed, $periodo, $semana, $capacidadTanque, $galRecibidos, $galDespachados, $galEsperados, $diferencia, $observaciones, $id);

    if ($stmt->execute()) {
        $stmt->close();
        jsonResponse(['success' => true, 'message' => 'Registro actualizado']);
    } else {
        $stmt->close();
        jsonError('Error al actualizar: ' . $conn->error, 500);
    }
    break;

// ==================== DELETE ====================
case 'delete':
    if ($_SERVER['REQUEST_METHOD'] !== 'POST') jsonError('Metodo no permitido', 405);
    if (!in_array(getUserRole(), ['ADMIN', 'SUPERADMIN'])) jsonError('No tiene permisos para eliminar', 403);

    $id = (int)($_POST['id'] ?? 0);
    if ($id <= 0) jsonError('ID invalido');

    $stmt = $conn->prepare("DELETE FROM tanquemed WHERE idMedida = ?");
    $stmt->bind_param('i', $id);

    if ($stmt->execute()) {
        $stmt->close();
        jsonResponse(['success' => true, 'message' => 'Registro eliminado']);
    } else {
        $stmt->close();
        jsonError('Error al eliminar: ' . $conn->error, 500);
    }
    break;

default:
    jsonError('Accion no reconocida: ' . $action, 400);
}
