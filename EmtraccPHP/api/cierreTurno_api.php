<?php
require_once '../includes/auth.php';
requireLogin();
require_once '../includes/config.php';

header('Content-Type: application/json; charset=utf-8');

$action = $_GET['action'] ?? '';

function jsonResponse($data, $code = 200) {
    http_response_code($code);
    echo json_encode($data, JSON_UNESCAPED_UNICODE);
    exit;
}

function jsonError($msg, $code = 400) {
    jsonResponse(['error' => $msg], $code);
}

switch ($action) {

case 'resumen':
    $turno = getTurno();
    $desp = strtoupper(getUserName());

    $stmt = $conn->prepare("SELECT COUNT(*) AS total, COALESCE(SUM(galDesp), 0) AS galones, COALESCE(SUM(total), 0) AS monto
        FROM comprobante WHERE turno = ? AND UPPER(nombDesp) = ? AND DATE(fecha) = CURDATE() AND (anulado = 0 OR anulado IS NULL)");
    $stmt->bind_param('ss', $turno, $desp);
    $stmt->execute();
    $row = $stmt->get_result()->fetch_assoc();
    $stmt->close();

    // Detalle
    $stmt2 = $conn->prepare("SELECT nCompro, nBoleta, placaCbz, galDesp, total, DATE_FORMAT(fecha, '%H:%i') AS hora
        FROM comprobante WHERE turno = ? AND UPPER(nombDesp) = ? AND DATE(fecha) = CURDATE() AND (anulado = 0 OR anulado IS NULL)
        ORDER BY fecha ASC");
    $stmt2->bind_param('ss', $turno, $desp);
    $stmt2->execute();
    $detalle = $stmt2->get_result()->fetch_all(MYSQLI_ASSOC);
    $stmt2->close();

    // Info tanque
    $periodo = getPeriodo();
    $semana = getSemana();
    $tanque = null;
    if ($periodo && $semana) {
        $stmtT = $conn->prepare("SELECT galonesCalc, galRecibidos, capacidadTanque FROM tanquemed WHERE periodo = ? AND semana = ? ORDER BY idMedida DESC LIMIT 1");
        $stmtT->bind_param('ss', $periodo, $semana);
        $stmtT->execute();
        $tanque = $stmtT->get_result()->fetch_assoc();
        $stmtT->close();
    }

    jsonResponse([
        'totalComprobantes' => (int)$row['total'],
        'totalGalones' => (float)$row['galones'],
        'totalMonto' => (float)$row['monto'],
        'detalle' => $detalle,
        'tanque' => $tanque,
        'turno' => $turno,
        'despachador' => $desp,
        'periodo' => $periodo,
        'semana' => $semana,
        'odometroInicio' => (float)getOdometroInicio()
    ]);
    break;

case 'cerrar':
    if ($_SERVER['REQUEST_METHOD'] !== 'POST') jsonError('Metodo no permitido', 405);

    $data = json_decode(file_get_contents('php://input'), true);
    $medicion = (float)($data['medicionTanque'] ?? 0);
    $odometroCierre = (float)($data['odometroCierre'] ?? 0);
    $observaciones = trim($data['observaciones'] ?? '');
    $totalComp = (int)($data['totalComprobantes'] ?? 0);
    $totalGal = (float)($data['totalGalones'] ?? 0);
    $totalMonto = (float)($data['totalMonto'] ?? 0);

    $idTurno = getIdTurno();
    $turno = getTurno();
    $desp = strtoupper(getUserName());
    $periodo = getPeriodo();
    $semana = getSemana();
    $odometroInicio = (float)getOdometroInicio();

    $stmt = $conn->prepare("INSERT INTO cierre_turno (idTurno, despachador, fecha, periodo, semana, turnoNombre, totalComprobantes, totalGalones, totalMonto, odometroInicio, odometroCierre, medicionTanque, observaciones)
        VALUES(?, ?, CURDATE(), ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)");
    $stmt->bind_param('issssidddddds', $idTurno, $desp, $periodo, $semana, $turno, $totalComp, $totalGal, $totalMonto, $odometroInicio, $odometroCierre, $medicion, $observaciones);
    $stmt->execute();
    $stmt->close();

    // Marcar apertura de turno como cerrada
    $stmtCerrar = $conn->prepare("UPDATE apertura_turno SET cerrado = 1 WHERE despachador = ? AND cerrado = 0");
    $stmtCerrar->bind_param('s', $desp);
    $stmtCerrar->execute();
    $stmtCerrar->close();

    jsonResponse(['ok' => true, 'mensaje' => 'Turno cerrado correctamente']);
    break;

case 'historial':
    $stmt = $conn->prepare("SELECT idCierre, turnoNombre, despachador, DATE_FORMAT(fecha, '%d/%m/%Y') AS fecha, periodo, semana, totalComprobantes, totalGalones, totalMonto, medicionTanque, DATE_FORMAT(fechaHoraCierre, '%d/%m/%Y %H:%i') AS fechaCierre
        FROM cierre_turno ORDER BY idCierre DESC LIMIT 50");
    $stmt->execute();
    $rows = $stmt->get_result()->fetch_all(MYSQLI_ASSOC);
    $stmt->close();
    jsonResponse(['rows' => $rows]);
    break;

default:
    jsonError('Accion no reconocida');
}
