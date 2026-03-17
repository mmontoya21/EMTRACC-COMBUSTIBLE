<?php
require_once '../includes/auth.php';
requireLogin();
requirePermisoApi('factura');
require_once '../includes/config.php';

header('Content-Type: application/json; charset=utf-8');

$action = $_GET['action'] ?? $_POST['action'] ?? '';
$role = getUserRole();
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
    $where = [];
    $params = [];
    $types = '';

    $filtroCodProp = $_GET['codProp'] ?? '';
    $filtroPropietario = $_GET['propietario'] ?? '';
    $filtroFechaDesde = $_GET['fechaDesde'] ?? '';
    $filtroFechaHasta = $_GET['fechaHasta'] ?? '';

    if ($filtroCodProp !== '') { $where[] = "codProp LIKE ?"; $params[] = "%$filtroCodProp%"; $types .= 's'; }
    if ($filtroPropietario !== '') { $where[] = "propietario LIKE ?"; $params[] = "%$filtroPropietario%"; $types .= 's'; }
    if ($filtroFechaDesde !== '') { $where[] = "fecha >= ?"; $params[] = $filtroFechaDesde; $types .= 's'; }
    if ($filtroFechaHasta !== '') { $where[] = "fecha <= ?"; $params[] = $filtroFechaHasta . ' 23:59:59'; $types .= 's'; }

    $whereSQL = count($where) > 0 ? 'WHERE ' . implode(' AND ', $where) : '';

    // Totales
    $sqlCount = "SELECT COUNT(*) as total FROM factura $whereSQL";
    $stmt = $conn->prepare($sqlCount);
    if ($types !== '') $stmt->bind_param($types, ...$params);
    $stmt->execute();
    $totales = $stmt->get_result()->fetch_assoc();
    $stmt->close();

    // Paginacion
    $pagina = max(1, (int)($_GET['pagina'] ?? 1));
    $porPagina = 50;
    $offset = ($pagina - 1) * $porPagina;

    // Datos
    $sql = "SELECT idFactura, codProp, empresa, propietario, nFactura, DATE_FORMAT(fecha, '%d/%m/%Y') AS fechaFmt, fecha
            FROM factura $whereSQL
            ORDER BY fecha DESC, idFactura DESC
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

    $stmt = $conn->prepare("SELECT * FROM factura WHERE idFactura = ?");
    $stmt->bind_param('i', $id);
    $stmt->execute();
    $row = $stmt->get_result()->fetch_assoc();
    $stmt->close();

    if (!$row) jsonError('Registro no encontrado', 404);
    jsonResponse($row);
    break;

// ==================== NEXT NUMBER ====================
case 'nextNumber':
    $res = $conn->query("SELECT nFactura FROM factura ORDER BY idFactura DESC LIMIT 1");
    $row = $res->fetch_assoc();
    $last = $row ? (int)$row['nFactura'] : 0;
    $next = str_pad($last + 1, 8, '0', STR_PAD_LEFT);
    jsonResponse(['numero' => $next]);
    break;

// ==================== LOOKUP PROPIETARIO BY codProp ====================
case 'lookupPropietario':
    $codigo = $_GET['codigo'] ?? '';
    if ($codigo === '') jsonResponse(['nPropietario' => '', 'nEmpresa' => '', 'RTN' => '', 'codProp' => '']);
    $stmt = $conn->prepare("SELECT codProp, nPropietario, nEmpresa, RTN FROM propietario WHERE codProp = ? LIMIT 1");
    $stmt->bind_param('s', $codigo);
    $stmt->execute();
    $row = $stmt->get_result()->fetch_assoc();
    $stmt->close();
    jsonResponse($row ?: ['nPropietario' => '', 'nEmpresa' => '', 'RTN' => '', 'codProp' => '']);
    break;

// ==================== EMPRESA DATA ====================
case 'empresa':
    $res = $conn->query("SELECT nEmpre, rtn, cai, ochoDig, rangoIni, rangoFin, fechaLimit, dire1, dire2, dire3, tel1, correoE FROM empresa LIMIT 1");
    $row = $res->fetch_assoc();
    jsonResponse($row ?: []);
    break;

// ==================== CREATE ====================
case 'create':
    if ($_SERVER['REQUEST_METHOD'] !== 'POST') jsonError('Metodo no permitido', 405);
    requireNotReadOnlyApi();

    $nFactura = trim($_POST['nFactura'] ?? '');
    $fecha = trim($_POST['fecha'] ?? date('Y-m-d'));
    $propietario = trim($_POST['propietario'] ?? '');
    $empresa = trim($_POST['empresa'] ?? '');
    $rtn = trim($_POST['rtn'] ?? '');
    $tipoPag = trim($_POST['tipoPag'] ?? 'CONTADO');
    $facCantidad = (float)($_POST['facCantidad'] ?? 0);
    $facExe = (float)($_POST['facExe'] ?? 0);
    $facTotal = (float)($_POST['facTotal'] ?? 0);
    $comentario = trim($_POST['comentario'] ?? '');
    $comentario2 = trim($_POST['comentario2'] ?? '');
    $cantd1 = (float)($_POST['cantd1'] ?? 0);
    $cantd2 = (float)($_POST['cantd2'] ?? 0);
    $descrip1 = trim($_POST['descrip1'] ?? '');
    $descrip2 = trim($_POST['descrip2'] ?? '');
    $total1 = (float)($_POST['total1'] ?? 0);
    $total2 = (float)($_POST['total2'] ?? 0);
    $perMes = trim($_POST['perMes'] ?? '');
    $perSem = trim($_POST['perSem'] ?? '');
    $preUni1 = (float)($_POST['preUni1'] ?? 0);
    $preUni2 = (float)($_POST['preUni2'] ?? 0);
    $codProp = trim($_POST['codProp'] ?? '');

    $stmt = $conn->prepare("INSERT INTO factura (nFactura, fecha, propietario, empresa, rtn, tipoPag, facCantidad, facExe, facTotal, comentario, comentario2, cantd1, cantd2, descrip1, descrip2, total1, total2, perMes, PerSem, preUni1, preUni2, codProp) VALUES(?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)");
    $stmt->bind_param('ssssssdddssddssddssdds',
        $nFactura, $fecha, $propietario, $empresa, $rtn, $tipoPag,
        $facCantidad, $facExe, $facTotal, $comentario, $comentario2,
        $cantd1, $cantd2, $descrip1, $descrip2, $total1, $total2,
        $perMes, $perSem, $preUni1, $preUni2, $codProp);

    if ($stmt->execute()) {
        $newId = $conn->insert_id;
        $stmt->close();
        jsonResponse(['success' => true, 'id' => $newId, 'message' => 'Factura creada exitosamente']);
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

    $nFactura = trim($_POST['nFactura'] ?? '');
    $fecha = trim($_POST['fecha'] ?? date('Y-m-d'));
    $propietario = trim($_POST['propietario'] ?? '');
    $empresa = trim($_POST['empresa'] ?? '');
    $rtn = trim($_POST['rtn'] ?? '');
    $tipoPag = trim($_POST['tipoPag'] ?? 'CONTADO');
    $facCantidad = (float)($_POST['facCantidad'] ?? 0);
    $facExe = (float)($_POST['facExe'] ?? 0);
    $facTotal = (float)($_POST['facTotal'] ?? 0);
    $comentario = trim($_POST['comentario'] ?? '');
    $comentario2 = trim($_POST['comentario2'] ?? '');
    $cantd1 = (float)($_POST['cantd1'] ?? 0);
    $cantd2 = (float)($_POST['cantd2'] ?? 0);
    $descrip1 = trim($_POST['descrip1'] ?? '');
    $descrip2 = trim($_POST['descrip2'] ?? '');
    $total1 = (float)($_POST['total1'] ?? 0);
    $total2 = (float)($_POST['total2'] ?? 0);
    $perMes = trim($_POST['perMes'] ?? '');
    $perSem = trim($_POST['perSem'] ?? '');
    $preUni1 = (float)($_POST['preUni1'] ?? 0);
    $preUni2 = (float)($_POST['preUni2'] ?? 0);
    $codProp = trim($_POST['codProp'] ?? '');

    $stmt = $conn->prepare("UPDATE factura SET nFactura=?, fecha=?, propietario=?, empresa=?, rtn=?, tipoPag=?, facCantidad=?, facExe=?, facTotal=?, comentario=?, comentario2=?, cantd1=?, cantd2=?, descrip1=?, descrip2=?, total1=?, total2=?, perMes=?, PerSem=?, preUni1=?, preUni2=?, codProp=? WHERE idFactura=?");
    $stmt->bind_param('ssssssdddssddssddssdds' . 'i',
        $nFactura, $fecha, $propietario, $empresa, $rtn, $tipoPag,
        $facCantidad, $facExe, $facTotal, $comentario, $comentario2,
        $cantd1, $cantd2, $descrip1, $descrip2, $total1, $total2,
        $perMes, $perSem, $preUni1, $preUni2, $codProp, $id);

    if ($stmt->execute()) {
        $stmt->close();
        jsonResponse(['success' => true, 'message' => 'Factura modificada exitosamente']);
    } else {
        $stmt->close();
        jsonError('Error al modificar: ' . $conn->error, 500);
    }
    break;

// ==================== DELETE ====================
case 'delete':
    if ($_SERVER['REQUEST_METHOD'] !== 'POST') jsonError('Metodo no permitido', 405);
    requireNotReadOnlyApi();

    $id = (int)($_POST['id'] ?? 0);
    if ($id <= 0) jsonError('ID invalido');

    $stmt = $conn->prepare("DELETE FROM factura WHERE idFactura = ?");
    $stmt->bind_param('i', $id);

    if ($stmt->execute()) {
        $stmt->close();
        jsonResponse(['success' => true, 'message' => 'Factura eliminada']);
    } else {
        $stmt->close();
        jsonError('Error al eliminar: ' . $conn->error, 500);
    }
    break;

// ==================== REPORT DATA (comprobantes grouped by Cod. Cliente) ====================
case 'reportData':
    $where = ["(anulado = 0 OR anulado IS NULL)"];
    $params = [];
    $types = '';

    $usarFecha = ($_GET['usarFecha'] ?? '0') === '1';
    $fechaDesde = $_GET['fechaDesde'] ?? '';
    $fechaHasta = $_GET['fechaHasta'] ?? '';
    $codCliente = $_GET['codCliente'] ?? '';
    $placa = $_GET['placa'] ?? '';
    $boleta = $_GET['boleta'] ?? '';

    if ($usarFecha && $fechaDesde !== '') { $where[] = "fecha >= ?"; $params[] = $fechaDesde; $types .= 's'; }
    if ($usarFecha && $fechaHasta !== '') { $where[] = "fecha <= ?"; $params[] = $fechaHasta . ' 23:59:59'; $types .= 's'; }
    if ($codCliente !== '') { $where[] = "codiProp LIKE ?"; $params[] = "%$codCliente%"; $types .= 's'; }
    if ($placa !== '') { $where[] = "placaCbz LIKE ?"; $params[] = "%$placa%"; $types .= 's'; }
    if ($boleta !== '') { $where[] = "nBoleta LIKE ?"; $params[] = "%$boleta%"; $types .= 's'; }

    $whereSQL = 'WHERE ' . implode(' AND ', $where);

    $sql = "SELECT DATE_FORMAT(fecha, '%d/%m/%Y') AS fecha, placaCbz AS placa, nConte AS contenedor,
                   galDesp AS galones, total, codiProp AS codCliente, nBoleta AS boleta,
                   periodo, semana, valor
            FROM comprobante $whereSQL
            ORDER BY codiProp ASC, fecha DESC, nBoleta ASC";

    $stmt = $conn->prepare($sql);
    if ($types !== '') $stmt->bind_param($types, ...$params);
    $stmt->execute();
    $result = $stmt->get_result();
    $rows = [];
    while ($row = $result->fetch_assoc()) {
        $rows[] = $row;
    }
    $stmt->close();

    jsonResponse(['rows' => $rows, 'total' => count($rows)]);
    break;

default:
    jsonError('Accion no reconocida: ' . $action, 400);
}
