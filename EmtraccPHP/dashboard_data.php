<?php
require_once 'includes/auth.php';
requireLogin();
require_once 'includes/config.php';

$periodo = $_GET['periodo'] ?? '';
$semana = $_GET['semana'] ?? '';

$where = ["anulado = 0"];
$params = [];
$types = '';

// Restricción por rol
if (getUserRole() === 'DESPACHADOR') {
    $where[] = "nombDesp = ?";
    $params[] = getUserName();
    $types .= 's';
}

if ($periodo !== '') {
    $where[] = "periodo = ?";
    $params[] = $periodo;
    $types .= 's';
}
if ($semana !== '') {
    $where[] = "semana = ?";
    $params[] = $semana;
    $types .= 's';
}

$whereSQL = 'WHERE ' . implode(' AND ', $where);

// Por Despachador
$sql = "SELECT IFNULL(nombDesp, 'Sin nombre') as nombre, SUM(IFNULL(galDesp,0)) as galones, SUM(IFNULL(total,0)) as total FROM comprobante $whereSQL GROUP BY nombDesp ORDER BY galones DESC";
$stmt = $conn->prepare($sql);
if ($types !== '') $stmt->bind_param($types, ...$params);
$stmt->execute();
$porDespachador = $stmt->get_result()->fetch_all(MYSQLI_ASSOC);
$stmt->close();

// Por Fecha
$sql = "SELECT DATE_FORMAT(fecha, '%d/%m') as fecha, SUM(IFNULL(galDesp,0)) as galones FROM comprobante $whereSQL AND fecha IS NOT NULL GROUP BY DATE(fecha) ORDER BY DATE(fecha)";
$stmt = $conn->prepare($sql);
if ($types !== '') $stmt->bind_param($types, ...$params);
$stmt->execute();
$porFecha = $stmt->get_result()->fetch_all(MYSQLI_ASSOC);
$stmt->close();

// Por Ruta (Top 10)
$sql = "SELECT IFNULL(ruta, 'Sin ruta') as ruta, SUM(IFNULL(galDesp,0)) as galones FROM comprobante $whereSQL GROUP BY ruta ORDER BY galones DESC LIMIT 10";
$stmt = $conn->prepare($sql);
if ($types !== '') $stmt->bind_param($types, ...$params);
$stmt->execute();
$porRuta = $stmt->get_result()->fetch_all(MYSQLI_ASSOC);
$stmt->close();

// Por Propietario (Top 10)
$sql = "SELECT IFNULL(propCbz, 'Sin propietario') as propietario, SUM(IFNULL(galDesp,0)) as galones, SUM(IFNULL(total,0)) as total FROM comprobante $whereSQL GROUP BY propCbz ORDER BY galones DESC LIMIT 10";
$stmt = $conn->prepare($sql);
if ($types !== '') $stmt->bind_param($types, ...$params);
$stmt->execute();
$porPropietario = $stmt->get_result()->fetch_all(MYSQLI_ASSOC);
$stmt->close();

// Convertir valores numéricos
foreach ($porDespachador as &$d) {
    $d['galones'] = (float)$d['galones'];
    $d['total'] = (float)$d['total'];
}
foreach ($porFecha as &$d) {
    $d['galones'] = (float)$d['galones'];
}
foreach ($porRuta as &$d) {
    $d['galones'] = (float)$d['galones'];
}
foreach ($porPropietario as &$d) {
    $d['galones'] = (float)$d['galones'];
    $d['total'] = (float)$d['total'];
}

header('Content-Type: application/json');
echo json_encode([
    'porDespachador' => $porDespachador,
    'porFecha' => $porFecha,
    'porRuta' => $porRuta,
    'porPropietario' => $porPropietario
]);
