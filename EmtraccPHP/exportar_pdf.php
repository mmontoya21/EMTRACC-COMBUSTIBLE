<?php
require_once 'includes/auth.php';
requireLogin();
requirePermiso('reporte');
require_once 'includes/config.php';

// Parámetros de filtro
$fechaDesde = $_GET['fechaDesde'] ?? '';
$fechaHasta = $_GET['fechaHasta'] ?? '';
$periodo = $_GET['periodo'] ?? '';
$semana = $_GET['semana'] ?? '';
$despachador = $_GET['despachador'] ?? '';
$propietario = $_GET['propietario'] ?? '';
$placa = $_GET['placa'] ?? '';
$boleta = $_GET['boleta'] ?? '';
$comprobante = $_GET['comprobante'] ?? '';

$where = [];
$params = [];
$types = '';

if (getUserRole() === 'DESPACHADOR') {
    $where[] = "nombDesp = ?";
    $params[] = getUserName();
    $types .= 's';
}
if ($fechaDesde !== '') { $where[] = "fecha >= ?"; $params[] = $fechaDesde; $types .= 's'; }
if ($fechaHasta !== '') { $where[] = "fecha <= ?"; $params[] = $fechaHasta . ' 23:59:59'; $types .= 's'; }
if ($periodo !== '') { $where[] = "periodo = ?"; $params[] = $periodo; $types .= 's'; }
if ($semana !== '') { $where[] = "semana = ?"; $params[] = $semana; $types .= 's'; }
if ($despachador !== '') { $where[] = "nombDesp = ?"; $params[] = $despachador; $types .= 's'; }
if ($propietario !== '') { $where[] = "propCbz LIKE ?"; $params[] = "%$propietario%"; $types .= 's'; }
if ($placa !== '') { $where[] = "placaCbz LIKE ?"; $params[] = "%$placa%"; $types .= 's'; }
if ($boleta !== '') { $where[] = "nBoleta LIKE ?"; $params[] = "%$boleta%"; $types .= 's'; }
if ($comprobante !== '') { $where[] = "nCompro LIKE ?"; $params[] = "%$comprobante%"; $types .= 's'; }

$whereSQL = count($where) > 0 ? 'WHERE ' . implode(' AND ', $where) : '';

$sql = "SELECT * FROM comprobante $whereSQL ORDER BY fecha DESC";
$stmt = $conn->prepare($sql);
if ($types !== '') {
    $stmt->bind_param($types, ...$params);
}
$stmt->execute();
$datos = $stmt->get_result()->fetch_all(MYSQLI_ASSOC);
$stmt->close();

$totalRegistros = count($datos);
$anulados = 0;
$totalGalones = 0;
$totalMonto = 0;
foreach ($datos as $c) {
    if ($c['anulado']) {
        $anulados++;
    } else {
        $totalGalones += (float)($c['galDesp'] ?? 0);
        $totalMonto += (float)($c['total'] ?? 0);
    }
}

// Construir texto de filtros
$filtrosTexto = '';
$hayFiltros = false;
if ($fechaDesde !== '' || $fechaHasta !== '') {
    $filtrosTexto .= 'Fecha ' . ($fechaDesde ?: '...') . ' - ' . ($fechaHasta ?: '...') . ' | ';
    $hayFiltros = true;
}
if ($despachador !== '') { $filtrosTexto .= 'Despachador: ' . $despachador . ' | '; $hayFiltros = true; }
if ($periodo !== '') { $filtrosTexto .= 'Periodo: ' . $periodo . ' | '; $hayFiltros = true; }
if ($semana !== '') { $filtrosTexto .= 'Semana: ' . $semana . ' | '; $hayFiltros = true; }
if ($propietario !== '') { $filtrosTexto .= 'Propietario: ' . $propietario . ' | '; $hayFiltros = true; }
if ($placa !== '') { $filtrosTexto .= 'Placa: ' . $placa . ' | '; $hayFiltros = true; }
if ($boleta !== '') { $filtrosTexto .= 'Boleta: ' . $boleta . ' | '; $hayFiltros = true; }
if ($comprobante !== '') { $filtrosTexto .= 'Comprobante: ' . $comprobante . ' | '; $hayFiltros = true; }
$filtrosTexto = $hayFiltros ? 'Filtros: ' . rtrim($filtrosTexto, ' | ') : 'Sin filtros aplicados';
?>
<!DOCTYPE html>
<html lang="es">
<head>
    <meta charset="utf-8" />
    <title>Reporte de Comprobantes</title>
    <style>
        @page { size: legal landscape; margin: 10mm; }
        body { font-family: Arial, sans-serif; font-size: 8pt; margin: 0; padding: 10px; }

        /* Encabezado */
        .titulo {
            background-color: #6A7EA8;
            color: #FFFFFF;
            text-align: center;
            font-size: 16pt;
            font-weight: bold;
            padding: 10px;
            margin-bottom: 5px;
        }
        .filtros {
            font-style: italic;
            color: #666666;
            font-size: 9pt;
            margin: 3px 0;
        }
        .fecha-gen {
            font-style: italic;
            color: #666666;
            font-size: 9pt;
            margin: 3px 0 10px 0;
        }

        /* Tabla de datos */
        table.datos { width: 100%; border-collapse: collapse; }
        table.datos th {
            background-color: #4A5A78;
            color: #fff;
            padding: 5px 3px;
            font-size: 7pt;
            text-align: center;
            border: 1px solid #000;
        }
        table.datos td {
            padding: 3px;
            font-size: 7pt;
            border: 1px solid #ccc;
        }
        .row-white td { background-color: #FFFFFF; }
        .row-blue td { background-color: #F0F0F5; }
        .row-anulado td { background-color: #FFC8C8; color: #8B0000; }
        .text-end { text-align: right; }

        /* Fila TOTAL */
        .fila-total td {
            background-color: #4A5A78;
            color: #FFFFFF;
            font-weight: bold;
            font-size: 7pt;
            padding: 4px 3px;
            border: 2px solid #000;
        }
        .fila-total .total-galones {
            background-color: #D4E6F1;
            color: #000;
            text-align: right;
        }
        .fila-total .total-monto {
            background-color: #D5F5E3;
            color: #000;
            text-align: right;
        }
        .fila-total .total-vacio {
            background-color: #E8E8F0;
        }

        /* Resumen */
        .resumen-titulo {
            background-color: #6A7EA8;
            color: #FFFFFF;
            font-weight: bold;
            font-size: 11pt;
            padding: 6px 10px;
            margin-top: 15px;
            display: inline-block;
            min-width: 250px;
        }
        table.resumen {
            border-collapse: collapse;
            margin-top: 5px;
            font-size: 9pt;
        }
        table.resumen td {
            padding: 3px 10px 3px 5px;
            border: none;
        }
        table.resumen .label { font-weight: bold; }
        table.resumen .red { color: #FF0000; font-weight: bold; }
        table.resumen .blue { color: #2E86AB; }

        .no-print { margin: 15px 0; text-align: center; }
        @media print { .no-print { display: none; } }
    </style>
</head>
<body>
    <div class="no-print">
        <button onclick="window.print()" style="padding:10px 30px; font-size:14pt; cursor:pointer;">Imprimir / Guardar como PDF</button>
        <button onclick="window.close()" style="padding:10px 20px; font-size:14pt; cursor:pointer; margin-left:10px;">Cerrar</button>
    </div>

    <!-- ========== ENCABEZADO ========== -->
    <div style="text-align:center; margin-bottom:5px;">
        <img src="img/Emtracc.png" alt="EMTRACC" style="max-height:70px;">
    </div>
    <div class="titulo">REPORTE DE COMPROBANTES DE COMBUSTIBLE</div>
    <div class="filtros"><?= htmlspecialchars($filtrosTexto) ?></div>
    <div class="fecha-gen">Generado: <?= date('d/m/Y H:i:s') ?></div>

    <!-- ========== TABLA DE DATOS ========== -->
    <table class="datos">
        <thead>
            <tr>
                <th>No. Compro</th>
                <th>No. Boleta</th>
                <th>Fecha</th>
                <th>Despachador</th>
                <th>Propietario</th>
                <th>Placa</th>
                <th>Período</th>
                <th>Semana</th>
                <th>Ruta</th>
                <th>Galones</th>
                <th>Valor</th>
                <th>Total</th>
                <th>Contenedor</th>
                <th>Conductor</th>
                <th>Estado</th>
            </tr>
        </thead>
        <tbody>
            <?php $rowIndex = 0; foreach ($datos as $c): ?>
                <?php
                    if ($c['anulado'])
                        $rowClass = 'row-anulado';
                    else
                        $rowClass = $rowIndex % 2 === 0 ? 'row-white' : 'row-blue';
                    $rowIndex++;
                ?>
                <tr class="<?= $rowClass ?>">
                    <td><?= htmlspecialchars($c['nCompro'] ?? '') ?></td>
                    <td><?= htmlspecialchars($c['nBoleta'] ?? '') ?></td>
                    <td><?= $c['fecha'] ? date('d/m/Y', strtotime($c['fecha'])) : '' ?></td>
                    <td><?= htmlspecialchars($c['nombDesp'] ?? '') ?></td>
                    <td><?= htmlspecialchars($c['propCbz'] ?? '') ?></td>
                    <td><?= htmlspecialchars($c['placaCbz'] ?? '') ?></td>
                    <td><?= htmlspecialchars($c['periodo'] ?? '') ?></td>
                    <td><?= htmlspecialchars($c['semana'] ?? '') ?></td>
                    <td><?= htmlspecialchars($c['ruta'] ?? '') ?></td>
                    <td class="text-end"><?= number_format((float)($c['galDesp'] ?? 0), 2) ?></td>
                    <td class="text-end"><?= number_format((float)($c['valor'] ?? 0), 2) ?></td>
                    <td class="text-end"><?= number_format((float)($c['total'] ?? 0), 2) ?></td>
                    <td><?= htmlspecialchars($c['nConte'] ?? '') ?></td>
                    <td><?= htmlspecialchars($c['nombCond'] ?? '') ?></td>
                    <td><?= $c['anulado'] ? 'ANULADO' : 'ACTIVO' ?></td>
                </tr>
            <?php endforeach; ?>

            <!-- ========== FILA TOTAL ========== -->
            <tr class="fila-total">
                <td colspan="9">TOTAL</td>
                <td class="total-galones"><?= number_format($totalGalones, 2) ?></td>
                <td class="total-vacio"></td>
                <td class="total-monto"><?= number_format($totalMonto, 2) ?></td>
                <td class="total-vacio"></td>
                <td class="total-vacio"></td>
                <td class="total-vacio"></td>
            </tr>
        </tbody>
    </table>

    <!-- ========== RESUMEN ========== -->
    <div class="resumen-titulo">RESUMEN</div>
    <table class="resumen">
        <?php if ($despachador !== ''): ?>
        <tr><td class="label">Despachador:</td><td class="blue"><?= htmlspecialchars($despachador) ?></td></tr>
        <?php endif; ?>
        <?php if ($periodo !== ''): ?>
        <tr><td class="label">Periodo:</td><td><?= htmlspecialchars($periodo) ?></td></tr>
        <?php endif; ?>
        <?php if ($semana !== ''): ?>
        <tr><td class="label">Semana:</td><td><?= htmlspecialchars($semana) ?></td></tr>
        <?php endif; ?>
        <?php if ($fechaDesde !== '' || $fechaHasta !== ''): ?>
        <tr><td class="label">Fecha Desde:</td><td><?= htmlspecialchars($fechaDesde ?: 'N/A') ?></td></tr>
        <tr><td class="label">Fecha Hasta:</td><td><?= htmlspecialchars($fechaHasta ?: 'N/A') ?></td></tr>
        <?php endif; ?>
        <tr><td colspan="2">&nbsp;</td></tr>
        <tr><td class="label">Total Registros:</td><td><?= $totalRegistros ?></td></tr>
        <tr><td class="label">Registros Anulados:</td><td class="red"><?= $anulados ?></td></tr>
        <tr><td class="label">Total Galones:</td><td><?= number_format($totalGalones, 2) ?></td></tr>
        <tr><td class="label">Monto Total:</td><td><?= number_format($totalMonto, 2) ?></td></tr>
    </table>

    <script>
        window.onload = function() { window.print(); };
    </script>
</body>
</html>
