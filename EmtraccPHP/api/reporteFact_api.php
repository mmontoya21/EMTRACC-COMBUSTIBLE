<?php
require_once '../includes/auth.php';
requireLogin();
requirePermisoApi('factura');
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

// ==================== REPORT DATA ====================
case 'data':
    $where = ["(anulado = 0 OR anulado IS NULL)"];
    $params = [];
    $types = '';

    $fechaDesde = $_GET['fechaDesde'] ?? '';
    $fechaHasta = $_GET['fechaHasta'] ?? '';
    $codCliente = $_GET['codCliente'] ?? '';
    $placa = $_GET['placa'] ?? '';
    $boleta = $_GET['boleta'] ?? '';

    if ($fechaDesde !== '') { $where[] = "fecha >= ?"; $params[] = $fechaDesde; $types .= 's'; }
    if ($fechaHasta !== '') { $where[] = "fecha <= ?"; $params[] = $fechaHasta . ' 23:59:59'; $types .= 's'; }
    if ($codCliente !== '') { $where[] = "codiProp LIKE ?"; $params[] = "%$codCliente%"; $types .= 's'; }
    if ($placa !== '') { $where[] = "placaCbz LIKE ?"; $params[] = "%$placa%"; $types .= 's'; }
    if ($boleta !== '') { $where[] = "nBoleta LIKE ?"; $params[] = "%$boleta%"; $types .= 's'; }

    $whereSQL = 'WHERE ' . implode(' AND ', $where);

    $sql = "SELECT nCompro, nBoleta, DATE_FORMAT(fecha, '%d/%m/%Y') AS fechaFmt, fecha,
                   placaCbz, nConte, galDesp, total, codiProp, periodo, semana, valor
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

// ==================== TANK MEASUREMENT DATA ====================
case 'tanquemed':
    $periodo = getPeriodo();
    $semana = getSemana();

    if ($periodo === '' || $semana === '') {
        jsonResponse(['galInicio' => null, 'galFinal' => null]);
        break;
    }

    $stmt = $conn->prepare("SELECT galonesCalc, galonesMed FROM tanquemed WHERE periodo = ? AND semana = ? ORDER BY idMedida DESC LIMIT 1");
    $stmt->bind_param('ss', $periodo, $semana);
    $stmt->execute();
    $row = $stmt->get_result()->fetch_assoc();
    $stmt->close();

    jsonResponse([
        'galInicio' => $row ? (float)$row['galonesCalc'] : null,
        'galFinal' => $row ? (float)$row['galonesMed'] : null
    ]);
    break;

// ==================== ODOMETRO DATA ====================
case 'odometro':
    $fechaDesde = $_GET['fechaDesde'] ?? '';
    $fechaHasta = $_GET['fechaHasta'] ?? '';

    if ($fechaDesde === '' && $fechaHasta === '') {
        jsonResponse(['rows' => []]);
        break;
    }

    $where = [];
    $params = [];
    $types = '';

    if ($fechaDesde !== '') { $where[] = "fecha >= ?"; $params[] = $fechaDesde; $types .= 's'; }
    if ($fechaHasta !== '') { $where[] = "fecha <= ?"; $params[] = $fechaHasta; $types .= 's'; }

    $whereSQL = count($where) > 0 ? 'WHERE ' . implode(' AND ', $where) : '';

    $sql = "SELECT despachador, turnoNombre, MIN(odometroInicio) AS odoInicio, MAX(odometroCierre) AS odoCierre, fecha
            FROM cierre_turno $whereSQL
            GROUP BY despachador, fecha ORDER BY fecha ASC";

    $stmt = $conn->prepare($sql);
    if ($types !== '') $stmt->bind_param($types, ...$params);
    $stmt->execute();
    $result = $stmt->get_result();
    $rows = [];
    while ($row = $result->fetch_assoc()) {
        $row['odoInicio'] = (float)$row['odoInicio'];
        $row['odoCierre'] = (float)$row['odoCierre'];
        $row['fechaFmt'] = date('d/m/Y', strtotime($row['fecha']));
        $rows[] = $row;
    }
    $stmt->close();

    jsonResponse(['rows' => $rows]);
    break;

default:
    jsonError('Accion no reconocida: ' . $action, 400);
}
