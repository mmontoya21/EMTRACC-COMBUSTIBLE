<?php
require_once '../includes/auth.php';
requireLogin();
requirePermisoApi('comprobante');
require_once '../includes/config.php';

header('Content-Type: application/json; charset=utf-8');

$action = $_GET['action'] ?? $_POST['action'] ?? '';
$role = getUserRole();
$userName = getUserName();
$periodo = getPeriodo();
$semana = getSemana();

function jsonResponse($data, $code = 200) {
    http_response_code($code);
    echo json_encode($data, JSON_UNESCAPED_UNICODE);
    exit;
}

function jsonError($msg, $code = 400) {
    jsonResponse(['error' => $msg], $code);
}

function registrarLog($conn, $idcprbnt, $accion, $usuario, $detalle) {
    $stmt = $conn->prepare("INSERT INTO log_comprobante (idcprbnt, accion, usuario, detalle) VALUES (?, ?, ?, ?)");
    $stmt->bind_param('ssss', $idcprbnt, $accion, $usuario, $detalle);
    $stmt->execute();
    $stmt->close();
}

function actualizarTanquemed($conn, $periodo, $semana) {
    if ($periodo === '' || $semana === '') return;

    // Obtener datos del tanque para el periodo/semana
    $stmt = $conn->prepare("SELECT idMedida, galonesCalc, galRecibidos, capacidadTanque, galonesMed FROM tanquemed WHERE periodo = ? AND semana = ? ORDER BY idMedida DESC LIMIT 1");
    $stmt->bind_param('ss', $periodo, $semana);
    $stmt->execute();
    $res = $stmt->get_result();
    $tanque = $res->fetch_assoc();
    $stmt->close();

    if (!$tanque) return;

    // Sumar galones despachados (no anulados)
    $stmt = $conn->prepare("SELECT COALESCE(SUM(galDesp), 0) as totalDesp FROM comprobante WHERE periodo = ? AND semana = ? AND (anulado = 0 OR anulado IS NULL)");
    $stmt->bind_param('ss', $periodo, $semana);
    $stmt->execute();
    $res = $stmt->get_result();
    $row = $res->fetch_assoc();
    $totalDespachado = (float)$row['totalDesp'];
    $stmt->close();

    $galonesCalc = (float)$tanque['galonesCalc'];
    $galRecibidos = (float)$tanque['galRecibidos'];
    $galonesMed = (float)$tanque['galonesMed'];

    $galEsperados = $galonesCalc + $galRecibidos - $totalDespachado;
    $diferencia = $galonesMed - $galEsperados;

    $stmt = $conn->prepare("UPDATE tanquemed SET galDespachados = ?, galEsperados = ?, diferencia = ? WHERE idMedida = ?");
    $stmt->bind_param('dddi', $totalDespachado, $galEsperados, $diferencia, $tanque['idMedida']);
    $stmt->execute();
    $stmt->close();
}

switch ($action) {

// ==================== LIST ====================
case 'list':
    $where = [];
    $params = [];
    $types = '';

    if ($role === 'DESPACHADOR') {
        $where[] = "nombDesp = ?";
        $params[] = $userName;
        $types .= 's';
    }

    $filtroPlaca = $_GET['placa'] ?? '';
    $filtroBoleta = $_GET['boleta'] ?? '';
    $filtroComprobante = $_GET['comprobante'] ?? '';
    $filtroFechaDesde = $_GET['fechaDesde'] ?? '';
    $filtroFechaHasta = $_GET['fechaHasta'] ?? '';
    $filtroDespachador = $_GET['despachador'] ?? '';

    if ($filtroPlaca !== '') { $where[] = "placaCbz LIKE ?"; $params[] = "%$filtroPlaca%"; $types .= 's'; }
    if ($filtroBoleta !== '') { $where[] = "nBoleta LIKE ?"; $params[] = "%$filtroBoleta%"; $types .= 's'; }
    if ($filtroComprobante !== '') { $where[] = "nCompro LIKE ?"; $params[] = "%$filtroComprobante%"; $types .= 's'; }
    if ($filtroFechaDesde !== '') { $where[] = "fecha >= ?"; $params[] = $filtroFechaDesde; $types .= 's'; }
    if ($filtroFechaHasta !== '') { $where[] = "fecha <= ?"; $params[] = $filtroFechaHasta . ' 23:59:59'; $types .= 's'; }
    if ($filtroDespachador !== '') { $where[] = "nombDesp = ?"; $params[] = $filtroDespachador; $types .= 's'; }

    $whereSQL = count($where) > 0 ? 'WHERE ' . implode(' AND ', $where) : '';

    // Totales
    $sqlCount = "SELECT COUNT(*) as total,
                 SUM(CASE WHEN anulado = 1 THEN 1 ELSE 0 END) as anulados,
                 SUM(CASE WHEN (anulado = 0 OR anulado IS NULL) THEN IFNULL(galDesp,0) ELSE 0 END) as totalGalones,
                 SUM(CASE WHEN (anulado = 0 OR anulado IS NULL) THEN IFNULL(total,0) ELSE 0 END) as totalMonto
                 FROM comprobante $whereSQL";
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
    $sql = "SELECT idcprbnt, nCompro, nBoleta, DATE_FORMAT(fecha, '%d/%m/%Y') AS fechaFmt, fecha,
                   nombDesp, propCbz, placaCbz, periodo, semana, ruta, galDesp, valor, total,
                   nConte, nombCond, codiProp, proxSem,
                   COALESCE(anulado, 0) AS anulado
            FROM comprobante $whereSQL
            ORDER BY fecha DESC, nCompro DESC
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
        'anulados' => (int)$totales['anulados'],
        'totalGalones' => (float)$totales['totalGalones'],
        'totalMonto' => (float)$totales['totalMonto'],
        'pagina' => $pagina,
        'totalPaginas' => max(1, ceil((int)$totales['total'] / $porPagina))
    ]);
    break;

// ==================== GET ====================
case 'get':
    $id = (int)($_GET['id'] ?? 0);
    if ($id <= 0) jsonError('ID invalido');

    $sql = "SELECT *, COALESCE(anulado, 0) AS anulado FROM comprobante WHERE idcprbnt = ?";
    if ($role === 'DESPACHADOR') {
        $sql .= " AND nombDesp = ?";
        $stmt = $conn->prepare($sql);
        $stmt->bind_param('is', $id, $userName);
    } else {
        $stmt = $conn->prepare($sql);
        $stmt->bind_param('i', $id);
    }
    $stmt->execute();
    $row = $stmt->get_result()->fetch_assoc();
    $stmt->close();

    if (!$row) jsonError('Registro no encontrado', 404);
    jsonResponse($row);
    break;

// ==================== NEXT NUMBER ====================
case 'nextNumber':
    $res = $conn->query("SELECT nCompro FROM comprobante ORDER BY idcprbnt DESC LIMIT 1");
    $row = $res->fetch_assoc();
    $last = $row ? (int)$row['nCompro'] : 0;
    $next = str_pad($last + 1, 8, '0', STR_PAD_LEFT);
    jsonResponse(['numero' => $next]);
    break;

// ==================== CURRENT PRICE ====================
case 'currentPrice':
    $res = $conn->query("SELECT valorCombustible FROM valorComb WHERE activo = 1 ORDER BY fecha DESC LIMIT 1");
    $row = $res->fetch_assoc();
    $precio = $row ? (float)$row['valorCombustible'] : 0;
    jsonResponse(['precio' => $precio]);
    break;

// ==================== AUTOCOMPLETE PLACA ====================
case 'autoPlaca':
    $q = $_GET['q'] ?? '';
    if (strlen($q) < 1) jsonResponse([]);
    $like = "%$q%";
    $stmt = $conn->prepare("SELECT placa, codigoPro, propietario FROM placa WHERE activo = 1 AND placa LIKE ? ORDER BY placa LIMIT 15");
    $stmt->bind_param('s', $like);
    $stmt->execute();
    $result = $stmt->get_result();
    $items = [];
    while ($row = $result->fetch_assoc()) $items[] = $row;
    $stmt->close();
    jsonResponse($items);
    break;

// ==================== AUTOCOMPLETE RUTA ====================
case 'autoRuta':
    $q = $_GET['q'] ?? '';
    if (strlen($q) < 1) jsonResponse([]);
    $like = "%$q%";
    $stmt = $conn->prepare("SELECT rutas FROM rutas WHERE rutas LIKE ? ORDER BY rutas LIMIT 15");
    $stmt->bind_param('s', $like);
    $stmt->execute();
    $result = $stmt->get_result();
    $items = [];
    while ($row = $result->fetch_assoc()) $items[] = $row['rutas'];
    $stmt->close();
    jsonResponse($items);
    break;

// ==================== AUTOCOMPLETE CONDUCTOR ====================
case 'autoConductor':
    $q = $_GET['q'] ?? '';
    if (strlen($q) < 1) jsonResponse([]);
    $like = "%$q%";
    $stmt = $conn->prepare("SELECT DISTINCT nombCond FROM comprobante WHERE nombCond IS NOT NULL AND nombCond LIKE ? ORDER BY nombCond LIMIT 15");
    $stmt->bind_param('s', $like);
    $stmt->execute();
    $result = $stmt->get_result();
    $items = [];
    while ($row = $result->fetch_assoc()) $items[] = $row['nombCond'];
    $stmt->close();
    jsonResponse($items);
    break;

// ==================== LOOKUP PLACA ====================
case 'lookupPlaca':
    $placa = $_GET['placa'] ?? '';
    if ($placa === '') jsonResponse(['propCbz' => '', 'codiProp' => '']);
    $stmt = $conn->prepare("SELECT propietario, codigoPro FROM placa WHERE placa = ? AND activo = 1 LIMIT 1");
    $stmt->bind_param('s', $placa);
    $stmt->execute();
    $row = $stmt->get_result()->fetch_assoc();
    $stmt->close();
    jsonResponse([
        'propCbz' => $row['propietario'] ?? '',
        'codiProp' => $row['codigoPro'] ?? ''
    ]);
    break;

// ==================== LOOKUP CODIGO PROPIETARIO ====================
case 'lookupCodigo':
    $codigo = $_GET['codigo'] ?? '';
    if ($codigo === '') jsonResponse([]);
    $stmt = $conn->prepare("SELECT placa, propietario FROM placa WHERE codigoPro = ? AND activo = 1 ORDER BY placa");
    $stmt->bind_param('s', $codigo);
    $stmt->execute();
    $result = $stmt->get_result();
    $items = [];
    while ($row = $result->fetch_assoc()) $items[] = $row;
    $stmt->close();
    jsonResponse($items);
    break;

// ==================== TANK LEVEL ====================
case 'tankLevel':
    $p = $_GET['periodo'] ?? $periodo;
    $s = $_GET['semana'] ?? $semana;
    if ($p === '' || $s === '') jsonResponse(['nivel' => 0, 'porcentaje' => 0, 'texto' => 'Sin datos de periodo/semana']);

    $stmt = $conn->prepare("SELECT galonesCalc, galRecibidos, capacidadTanque FROM tanquemed WHERE periodo = ? AND semana = ? ORDER BY idMedida DESC LIMIT 1");
    $stmt->bind_param('ss', $p, $s);
    $stmt->execute();
    $tanque = $stmt->get_result()->fetch_assoc();
    $stmt->close();

    if (!$tanque) jsonResponse(['nivel' => 0, 'porcentaje' => 0, 'texto' => 'Sin medicion para periodo ' . $p . ' semana ' . $s]);

    $stmt = $conn->prepare("SELECT COALESCE(SUM(galDesp), 0) as totalDesp FROM comprobante WHERE periodo = ? AND semana = ? AND (anulado = 0 OR anulado IS NULL)");
    $stmt->bind_param('ss', $p, $s);
    $stmt->execute();
    $row = $stmt->get_result()->fetch_assoc();
    $stmt->close();

    $galonesCalc = (float)$tanque['galonesCalc'];
    $galRecibidos = (float)$tanque['galRecibidos'];
    $capacidad = (float)$tanque['capacidadTanque'];
    $totalDesp = (float)$row['totalDesp'];

    $nivel = $galonesCalc + $galRecibidos - $totalDesp;
    $porcentaje = $capacidad > 0 ? round(($nivel / $capacidad) * 100, 1) : 0;

    jsonResponse([
        'nivel' => round($nivel, 2),
        'porcentaje' => $porcentaje,
        'capacidad' => $capacidad,
        'texto' => 'Tanque: ' . number_format($nivel, 2) . ' gal (' . $porcentaje . '%)'
    ]);
    break;

// ==================== EMPRESA ====================
case 'empresa':
    $res = $conn->query("SELECT nEmpre, rtn FROM empresa LIMIT 1");
    $row = $res->fetch_assoc();
    jsonResponse($row ?: ['nEmpre' => '', 'rtn' => '']);
    break;

// ==================== DESPACHADORES (para filtro) ====================
case 'despachadores':
    $res = $conn->query("SELECT DISTINCT nombDesp FROM comprobante WHERE nombDesp IS NOT NULL AND nombDesp != '' ORDER BY nombDesp");
    $items = [];
    while ($row = $res->fetch_assoc()) $items[] = $row['nombDesp'];
    jsonResponse($items);
    break;

// ==================== CREATE ====================
case 'create':
    if ($_SERVER['REQUEST_METHOD'] !== 'POST') jsonError('Metodo no permitido', 405);
    requireNotReadOnlyApi();

    $nCompro = trim($_POST['nCompro'] ?? '');
    $nBoleta = trim($_POST['nBoleta'] ?? '');
    $galDesp = (float)($_POST['galDesp'] ?? 0);
    $valor = (float)($_POST['valor'] ?? 0);
    $placaCbz = trim($_POST['placaCbz'] ?? '');
    $nConte = trim($_POST['nConte'] ?? '');
    $propCbz = trim($_POST['propCbz'] ?? '');
    $ruta = trim($_POST['ruta'] ?? '');
    $nombCond = trim($_POST['nombCond'] ?? '');
    $nombDesp = trim($_POST['nombDesp'] ?? '');
    $fecha = trim($_POST['fecha'] ?? date('Y-m-d'));
    $periodoF = trim($_POST['periodo'] ?? $periodo);
    $semanaF = trim($_POST['semana'] ?? $semana);
    $proxSem = trim($_POST['proxSem'] ?? 'NO');
    $codiProp = trim($_POST['codiProp'] ?? '');

    $turnoComp = getTurno();

    if ($placaCbz === '') jsonError('La placa es obligatoria');

    $total = $galDesp * $valor;

    $stmt = $conn->prepare("INSERT INTO comprobante (nCompro, nBoleta, galDesp, valor, total, placaCbz, nConte, propCbz, ruta, nombCond, nombDesp, fecha, periodo, semana, proxSem, codiProp, turno, anulado) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, 0)");
    $stmt->bind_param('ssdddssssssssssss', $nCompro, $nBoleta, $galDesp, $valor, $total, $placaCbz, $nConte, $propCbz, $ruta, $nombCond, $nombDesp, $fecha, $periodoF, $semanaF, $proxSem, $codiProp, $turnoComp);

    if ($stmt->execute()) {
        $newId = $conn->insert_id;
        $stmt->close();

        registrarLog($conn, (string)$newId, 'CREAR', $userName, "Comprobante $nCompro creado. Placa: $placaCbz, Galones: $galDesp, Total: $total");
        actualizarTanquemed($conn, $periodoF, $semanaF);

        jsonResponse(['success' => true, 'id' => $newId, 'message' => 'Comprobante creado exitosamente']);
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

    $nCompro = trim($_POST['nCompro'] ?? '');
    $nBoleta = trim($_POST['nBoleta'] ?? '');
    $galDesp = (float)($_POST['galDesp'] ?? 0);
    $valor = (float)($_POST['valor'] ?? 0);
    $placaCbz = trim($_POST['placaCbz'] ?? '');
    $nConte = trim($_POST['nConte'] ?? '');
    $propCbz = trim($_POST['propCbz'] ?? '');
    $ruta = trim($_POST['ruta'] ?? '');
    $nombCond = trim($_POST['nombCond'] ?? '');
    $nombDesp = trim($_POST['nombDesp'] ?? '');
    $fecha = trim($_POST['fecha'] ?? date('Y-m-d'));
    $periodoF = trim($_POST['periodo'] ?? $periodo);
    $semanaF = trim($_POST['semana'] ?? $semana);
    $proxSem = trim($_POST['proxSem'] ?? 'NO');
    $codiProp = trim($_POST['codiProp'] ?? '');

    if ($placaCbz === '') jsonError('La placa es obligatoria');

    $total = $galDesp * $valor;

    $stmt = $conn->prepare("UPDATE comprobante SET nCompro=?, nBoleta=?, galDesp=?, valor=?, total=?, placaCbz=?, nConte=?, propCbz=?, ruta=?, nombCond=?, nombDesp=?, fecha=?, periodo=?, semana=?, proxSem=?, codiProp=? WHERE idcprbnt=?");
    $stmt->bind_param('ssdddsssssssssssi', $nCompro, $nBoleta, $galDesp, $valor, $total, $placaCbz, $nConte, $propCbz, $ruta, $nombCond, $nombDesp, $fecha, $periodoF, $semanaF, $proxSem, $codiProp, $id);

    if ($stmt->execute()) {
        $stmt->close();
        registrarLog($conn, (string)$id, 'MODIFICAR', $userName, "Comprobante $nCompro modificado. Placa: $placaCbz, Galones: $galDesp, Total: $total");
        actualizarTanquemed($conn, $periodoF, $semanaF);
        jsonResponse(['success' => true, 'message' => 'Comprobante modificado exitosamente']);
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

    // Obtener datos antes de borrar para log
    $stmt = $conn->prepare("SELECT nCompro, placaCbz, periodo, semana FROM comprobante WHERE idcprbnt = ?");
    $stmt->bind_param('i', $id);
    $stmt->execute();
    $row = $stmt->get_result()->fetch_assoc();
    $stmt->close();

    if (!$row) jsonError('Registro no encontrado', 404);

    $stmt = $conn->prepare("DELETE FROM comprobante WHERE idcprbnt = ?");
    $stmt->bind_param('i', $id);

    if ($stmt->execute()) {
        $stmt->close();
        registrarLog($conn, (string)$id, 'ELIMINAR', $userName, "Comprobante {$row['nCompro']} eliminado. Placa: {$row['placaCbz']}");
        actualizarTanquemed($conn, $row['periodo'], $row['semana']);
        jsonResponse(['success' => true, 'message' => 'Comprobante eliminado']);
    } else {
        $stmt->close();
        jsonError('Error al eliminar: ' . $conn->error, 500);
    }
    break;

// ==================== ANNUL ====================
case 'annul':
    if ($_SERVER['REQUEST_METHOD'] !== 'POST') jsonError('Metodo no permitido', 405);
    requireNotReadOnlyApi();

    $id = (int)($_POST['id'] ?? 0);
    if ($id <= 0) jsonError('ID invalido');

    $stmt = $conn->prepare("SELECT nCompro, placaCbz, periodo, semana FROM comprobante WHERE idcprbnt = ?");
    $stmt->bind_param('i', $id);
    $stmt->execute();
    $row = $stmt->get_result()->fetch_assoc();
    $stmt->close();

    if (!$row) jsonError('Registro no encontrado', 404);

    $stmt = $conn->prepare("UPDATE comprobante SET anulado = 1, galDesp = 0, total = 0, valor = 0 WHERE idcprbnt = ?");
    $stmt->bind_param('i', $id);

    if ($stmt->execute()) {
        $stmt->close();
        registrarLog($conn, (string)$id, 'ANULAR', $userName, "Comprobante {$row['nCompro']} anulado");
        actualizarTanquemed($conn, $row['periodo'], $row['semana']);
        jsonResponse(['success' => true, 'message' => 'Comprobante anulado']);
    } else {
        $stmt->close();
        jsonError('Error al anular: ' . $conn->error, 500);
    }
    break;

// ==================== UNANNUL ====================
case 'unannul':
    if ($_SERVER['REQUEST_METHOD'] !== 'POST') jsonError('Metodo no permitido', 405);
    if (!in_array($role, ['ADMIN', 'SUPERADMIN'])) jsonError('No tiene permisos para desanular', 403);

    $id = (int)($_POST['id'] ?? 0);
    if ($id <= 0) jsonError('ID invalido');

    $stmt = $conn->prepare("SELECT nCompro, periodo, semana FROM comprobante WHERE idcprbnt = ?");
    $stmt->bind_param('i', $id);
    $stmt->execute();
    $row = $stmt->get_result()->fetch_assoc();
    $stmt->close();

    if (!$row) jsonError('Registro no encontrado', 404);

    $stmt = $conn->prepare("UPDATE comprobante SET anulado = 0 WHERE idcprbnt = ?");
    $stmt->bind_param('i', $id);

    if ($stmt->execute()) {
        $stmt->close();
        registrarLog($conn, (string)$id, 'DESANULAR', $userName, "Comprobante {$row['nCompro']} desanulado");
        actualizarTanquemed($conn, $row['periodo'], $row['semana']);
        jsonResponse(['success' => true, 'message' => 'Comprobante desanulado']);
    } else {
        $stmt->close();
        jsonError('Error al desanular: ' . $conn->error, 500);
    }
    break;

default:
    jsonError('Accion no reconocida: ' . $action, 400);
}
