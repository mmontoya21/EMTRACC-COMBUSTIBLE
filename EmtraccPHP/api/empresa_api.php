<?php
require_once '../includes/auth.php';
requireLogin();
requirePermisoApi('empresa');
require_once '../includes/config.php';

header('Content-Type: application/json; charset=utf-8');

function jsonResponse($data, $code = 200) {
    http_response_code($code);
    echo json_encode($data, JSON_UNESCAPED_UNICODE);
    exit;
}

function jsonError($msg, $code = 400) {
    jsonResponse(['error' => $msg], $code);
}

$action = $_GET['action'] ?? $_POST['action'] ?? '';

switch ($action) {

// ==================== GET (registro unico) ====================
case 'get':
    $stmt = $conn->prepare("SELECT * FROM empresa LIMIT 1");
    $stmt->execute();
    $row = $stmt->get_result()->fetch_assoc();
    $stmt->close();

    if (!$row) {
        jsonResponse(['exists' => false]);
    } else {
        $row['exists'] = true;
        jsonResponse($row);
    }
    break;

// ==================== SAVE (insert o update) ====================
case 'save':
    if ($_SERVER['REQUEST_METHOD'] !== 'POST') jsonError('Metodo no permitido', 405);
    requireNotReadOnlyApi();

    $nEmpre = trim($_POST['nEmpre'] ?? '');
    $nPropie = trim($_POST['nPropie'] ?? '');
    $nombLocal = trim($_POST['nombLocal'] ?? '');
    $local = trim($_POST['local'] ?? '');
    $rtn = trim($_POST['rtn'] ?? '');
    $correoE = trim($_POST['correoE'] ?? '');
    $dire1 = trim($_POST['dire1'] ?? '');
    $dire2 = trim($_POST['dire2'] ?? '');
    $dire3 = trim($_POST['dire3'] ?? '');
    $tel1 = trim($_POST['tel1'] ?? '');
    $cel2 = trim($_POST['cel2'] ?? '');
    $fax = trim($_POST['fax'] ?? '');
    $cai = trim($_POST['cai'] ?? '');
    $ochoDig = trim($_POST['ochoDig'] ?? '');
    $rangoIni = trim($_POST['rangoIni'] ?? '');
    $rangoFin = trim($_POST['rangoFin'] ?? '');
    $fechaLimit = trim($_POST['fechaLimit'] ?? '');
    $otros1 = trim($_POST['otros1'] ?? '');
    $otros2 = trim($_POST['otros2'] ?? '');

    if ($nEmpre === '') jsonError('El nombre de la empresa es obligatorio');

    // Verificar si ya existe un registro
    $check = $conn->query("SELECT COUNT(*) as cnt FROM empresa");
    $cnt = $check->fetch_assoc()['cnt'];

    if ($cnt > 0) {
        // UPDATE
        $sql = "UPDATE empresa SET nEmpre=?, nPropie=?, nombLocal=?, local=?, rtn=?, correoE=?,
                dire1=?, dire2=?, dire3=?, tel1=?, cel2=?, fax=?, cai=?, ochoDig=?,
                rangoIni=?, rangoFin=?, fechaLimit=?, otros1=?, otros2=?
                LIMIT 1";
        $stmt = $conn->prepare($sql);
        $stmt->bind_param('sssssssssssssssssss',
            $nEmpre, $nPropie, $nombLocal, $local, $rtn, $correoE,
            $dire1, $dire2, $dire3, $tel1, $cel2, $fax, $cai, $ochoDig,
            $rangoIni, $rangoFin, $fechaLimit, $otros1, $otros2
        );

        if ($stmt->execute()) {
            $stmt->close();
            jsonResponse(['success' => true, 'message' => 'Datos de empresa actualizados correctamente']);
        } else {
            $stmt->close();
            jsonError('Error al actualizar: ' . $conn->error, 500);
        }
    } else {
        // INSERT
        $sql = "INSERT INTO empresa (nEmpre, nPropie, nombLocal, `local`, rtn, correoE,
                dire1, dire2, dire3, tel1, cel2, fax, cai, ochoDig,
                rangoIni, rangoFin, fechaLimit, otros1, otros2)
                VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)";
        $stmt = $conn->prepare($sql);
        $stmt->bind_param('sssssssssssssssssss',
            $nEmpre, $nPropie, $nombLocal, $local, $rtn, $correoE,
            $dire1, $dire2, $dire3, $tel1, $cel2, $fax, $cai, $ochoDig,
            $rangoIni, $rangoFin, $fechaLimit, $otros1, $otros2
        );

        if ($stmt->execute()) {
            $stmt->close();
            jsonResponse(['success' => true, 'message' => 'Datos de empresa guardados correctamente']);
        } else {
            $stmt->close();
            jsonError('Error al guardar: ' . $conn->error, 500);
        }
    }
    break;

// ==================== DELETE ====================
case 'delete':
    if ($_SERVER['REQUEST_METHOD'] !== 'POST') jsonError('Metodo no permitido', 405);

    $role = getUserRole();
    if ($role !== 'SUPERADMIN') jsonError('Solo SUPERADMIN puede eliminar datos de empresa', 403);

    $stmt = $conn->prepare("DELETE FROM empresa LIMIT 1");

    if ($stmt->execute()) {
        $stmt->close();
        jsonResponse(['success' => true, 'message' => 'Registro de empresa eliminado correctamente']);
    } else {
        $stmt->close();
        jsonError('Error al eliminar: ' . $conn->error, 500);
    }
    break;

default:
    jsonError('Accion no reconocida: ' . $action, 400);
}
