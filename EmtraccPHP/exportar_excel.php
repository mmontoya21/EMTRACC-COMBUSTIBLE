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

// Construir texto de filtros aplicados
$filtrosTexto = 'Filtros: ';
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
$filtrosTexto = $hayFiltros ? rtrim($filtrosTexto, ' | ') : 'Sin filtros aplicados';

$numCols = 15;
$mergeAcross = $numCols - 1;

// Headers
$filename = 'Comprobantes_' . date('Ymd_His') . '.xls';
header('Content-Type: application/vnd.ms-excel');
header('Content-Disposition: attachment; filename="' . $filename . '"');
header('Cache-Control: max-age=0');

$rowIndex = 0;
$totalGalones = 0;
$totalMonto = 0;
$anulados = 0;

echo '<?xml version="1.0" encoding="UTF-8"?>' . "\n";
echo '<?mso-application progid="Excel.Sheet"?>' . "\n";
?>
<Workbook xmlns="urn:schemas-microsoft-com:office:spreadsheet"
          xmlns:ss="urn:schemas-microsoft-com:office:spreadsheet"
          xmlns:x="urn:schemas-microsoft-com:office:excel">
<Styles>
    <Style ss:ID="Default"><Font ss:FontName="Calibri" ss:Size="10"/></Style>
    <!-- Título del reporte -->
    <Style ss:ID="Title">
        <Font ss:FontName="Calibri" ss:Size="16" ss:Bold="1" ss:Color="#FFFFFF"/>
        <Interior ss:Color="#6A7EA8" ss:Pattern="Solid"/>
        <Alignment ss:Horizontal="Center" ss:Vertical="Center"/>
    </Style>
    <!-- Info filtros y fecha -->
    <Style ss:ID="Info">
        <Font ss:FontName="Calibri" ss:Size="10" ss:Italic="1" ss:Color="#666666"/>
    </Style>
    <!-- Encabezados de columnas -->
    <Style ss:ID="Header">
        <Font ss:FontName="Calibri" ss:Size="10" ss:Bold="1" ss:Color="#FFFFFF"/>
        <Interior ss:Color="#4A5A78" ss:Pattern="Solid"/>
        <Alignment ss:Horizontal="Center"/>
        <Borders>
            <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1" ss:Color="#000000"/>
            <Border ss:Position="Left" ss:LineStyle="Continuous" ss:Weight="1" ss:Color="#000000"/>
            <Border ss:Position="Right" ss:LineStyle="Continuous" ss:Weight="1" ss:Color="#000000"/>
            <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="1" ss:Color="#000000"/>
        </Borders>
    </Style>
    <!-- Filas de datos -->
    <Style ss:ID="RowWhite">
        <Interior ss:Color="#FFFFFF" ss:Pattern="Solid"/>
        <Borders>
            <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1" ss:Color="#D0D0D0"/>
        </Borders>
    </Style>
    <Style ss:ID="RowBlue">
        <Interior ss:Color="#F0F0F5" ss:Pattern="Solid"/>
        <Borders>
            <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1" ss:Color="#D0D0D0"/>
        </Borders>
    </Style>
    <Style ss:ID="RowAnulado">
        <Interior ss:Color="#FFC8C8" ss:Pattern="Solid"/>
        <Font ss:FontName="Calibri" ss:Size="10" ss:Color="#8B0000"/>
        <Borders>
            <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1" ss:Color="#D0D0D0"/>
        </Borders>
    </Style>
    <!-- Celdas numéricas -->
    <Style ss:ID="NumWhite">
        <Interior ss:Color="#FFFFFF" ss:Pattern="Solid"/>
        <NumberFormat ss:Format="#,##0.00"/>
        <Alignment ss:Horizontal="Right"/>
        <Borders>
            <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1" ss:Color="#D0D0D0"/>
        </Borders>
    </Style>
    <Style ss:ID="NumBlue">
        <Interior ss:Color="#F0F0F5" ss:Pattern="Solid"/>
        <NumberFormat ss:Format="#,##0.00"/>
        <Alignment ss:Horizontal="Right"/>
        <Borders>
            <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1" ss:Color="#D0D0D0"/>
        </Borders>
    </Style>
    <Style ss:ID="NumAnulado">
        <Interior ss:Color="#FFC8C8" ss:Pattern="Solid"/>
        <NumberFormat ss:Format="#,##0.00"/>
        <Alignment ss:Horizontal="Right"/>
        <Font ss:FontName="Calibri" ss:Size="10" ss:Color="#8B0000"/>
        <Borders>
            <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="1" ss:Color="#D0D0D0"/>
        </Borders>
    </Style>
    <!-- Fila TOTAL -->
    <Style ss:ID="TotalRow">
        <Font ss:FontName="Calibri" ss:Size="10" ss:Bold="1" ss:Color="#FFFFFF"/>
        <Interior ss:Color="#4A5A78" ss:Pattern="Solid"/>
        <Borders>
            <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="2" ss:Color="#000000"/>
            <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="2" ss:Color="#000000"/>
        </Borders>
    </Style>
    <Style ss:ID="TotalNum">
        <Font ss:FontName="Calibri" ss:Size="10" ss:Bold="1"/>
        <Interior ss:Color="#D4E6F1" ss:Pattern="Solid"/>
        <NumberFormat ss:Format="#,##0.00"/>
        <Alignment ss:Horizontal="Right"/>
        <Borders>
            <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="2" ss:Color="#000000"/>
            <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="2" ss:Color="#000000"/>
        </Borders>
    </Style>
    <Style ss:ID="TotalNumGreen">
        <Font ss:FontName="Calibri" ss:Size="10" ss:Bold="1"/>
        <Interior ss:Color="#D5F5E3" ss:Pattern="Solid"/>
        <NumberFormat ss:Format="#,##0.00"/>
        <Alignment ss:Horizontal="Right"/>
        <Borders>
            <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="2" ss:Color="#000000"/>
            <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="2" ss:Color="#000000"/>
        </Borders>
    </Style>
    <Style ss:ID="TotalEmpty">
        <Interior ss:Color="#E8E8F0" ss:Pattern="Solid"/>
        <Borders>
            <Border ss:Position="Bottom" ss:LineStyle="Continuous" ss:Weight="2" ss:Color="#000000"/>
            <Border ss:Position="Top" ss:LineStyle="Continuous" ss:Weight="2" ss:Color="#000000"/>
        </Borders>
    </Style>
    <!-- Resumen -->
    <Style ss:ID="ResumenTitle">
        <Font ss:FontName="Calibri" ss:Size="12" ss:Bold="1" ss:Color="#FFFFFF"/>
        <Interior ss:Color="#6A7EA8" ss:Pattern="Solid"/>
    </Style>
    <Style ss:ID="Bold">
        <Font ss:FontName="Calibri" ss:Size="10" ss:Bold="1"/>
    </Style>
    <Style ss:ID="BoldRed">
        <Font ss:FontName="Calibri" ss:Size="10" ss:Bold="1" ss:Color="#FF0000"/>
    </Style>
    <Style ss:ID="InfoBlue">
        <Font ss:FontName="Calibri" ss:Size="10" ss:Color="#2E86AB"/>
    </Style>
    <Style ss:ID="NumBold">
        <Font ss:FontName="Calibri" ss:Size="10" ss:Bold="1"/>
        <NumberFormat ss:Format="#,##0.00"/>
    </Style>
    <Style ss:ID="NumRed">
        <Font ss:FontName="Calibri" ss:Size="10" ss:Bold="1" ss:Color="#C62828"/>
        <NumberFormat ss:Format="#,##0.00"/>
    </Style>
    <Style ss:ID="NumBoldBlue">
        <Font ss:FontName="Calibri" ss:Size="10" ss:Bold="1" ss:Color="#1565C0"/>
        <NumberFormat ss:Format="#,##0.00"/>
    </Style>
</Styles>
<Worksheet ss:Name="Comprobantes">
<Table>
    <Column ss:Width="80"/>
    <Column ss:Width="75"/>
    <Column ss:Width="80"/>
    <Column ss:Width="130"/>
    <Column ss:Width="150"/>
    <Column ss:Width="75"/>
    <Column ss:Width="60"/>
    <Column ss:Width="60"/>
    <Column ss:Width="100"/>
    <Column ss:Width="70"/>
    <Column ss:Width="70"/>
    <Column ss:Width="70"/>
    <Column ss:Width="85"/>
    <Column ss:Width="120"/>
    <Column ss:Width="65"/>

    <!-- ========== TITULO ========== -->
    <Row ss:AutoFitHeight="0" ss:Height="35">
        <Cell ss:MergeAcross="<?= $mergeAcross ?>" ss:StyleID="Title"><Data ss:Type="String">REPORTE DE COMPROBANTES DE COMBUSTIBLE</Data></Cell>
    </Row>

    <!-- ========== FILTROS APLICADOS ========== -->
    <Row>
        <Cell ss:MergeAcross="<?= $mergeAcross ?>" ss:StyleID="Info"><Data ss:Type="String"><?= htmlspecialchars($filtrosTexto) ?></Data></Cell>
    </Row>

    <!-- ========== FECHA GENERACION ========== -->
    <Row>
        <Cell ss:MergeAcross="<?= $mergeAcross ?>" ss:StyleID="Info"><Data ss:Type="String">Generado: <?= date('d/m/Y H:i:s') ?></Data></Cell>
    </Row>

    <!-- Fila vacía -->
    <Row></Row>

    <!-- ========== ENCABEZADOS ========== -->
    <Row ss:AutoFitHeight="0" ss:Height="22" ss:StyleID="Header">
        <Cell><Data ss:Type="String">No. Compro</Data></Cell>
        <Cell><Data ss:Type="String">No. Boleta</Data></Cell>
        <Cell><Data ss:Type="String">Fecha</Data></Cell>
        <Cell><Data ss:Type="String">Despachador</Data></Cell>
        <Cell><Data ss:Type="String">Propietario</Data></Cell>
        <Cell><Data ss:Type="String">Placa</Data></Cell>
        <Cell><Data ss:Type="String">Per&#237;odo</Data></Cell>
        <Cell><Data ss:Type="String">Semana</Data></Cell>
        <Cell><Data ss:Type="String">Ruta</Data></Cell>
        <Cell><Data ss:Type="String">Galones</Data></Cell>
        <Cell><Data ss:Type="String">Valor</Data></Cell>
        <Cell><Data ss:Type="String">Total</Data></Cell>
        <Cell><Data ss:Type="String">Contenedor</Data></Cell>
        <Cell><Data ss:Type="String">Conductor</Data></Cell>
        <Cell><Data ss:Type="String">Estado</Data></Cell>
    </Row>

    <!-- ========== DATOS ========== -->
<?php foreach ($datos as $c):
    if ($c['anulado']) {
        $style = 'RowAnulado';
        $numStyle = 'NumAnulado';
        $anulados++;
    } else {
        $style = $rowIndex % 2 === 0 ? 'RowWhite' : 'RowBlue';
        $numStyle = $rowIndex % 2 === 0 ? 'NumWhite' : 'NumBlue';
        $totalGalones += (float)($c['galDesp'] ?? 0);
        $totalMonto += (float)($c['total'] ?? 0);
    }
    $rowIndex++;
?>
    <Row ss:StyleID="<?= $style ?>">
        <Cell><Data ss:Type="String"><?= htmlspecialchars($c['nCompro'] ?? '') ?></Data></Cell>
        <Cell><Data ss:Type="String"><?= htmlspecialchars($c['nBoleta'] ?? '') ?></Data></Cell>
        <Cell><Data ss:Type="String"><?= $c['fecha'] ? date('d/m/Y', strtotime($c['fecha'])) : '' ?></Data></Cell>
        <Cell><Data ss:Type="String"><?= htmlspecialchars($c['nombDesp'] ?? '') ?></Data></Cell>
        <Cell><Data ss:Type="String"><?= htmlspecialchars($c['propCbz'] ?? '') ?></Data></Cell>
        <Cell><Data ss:Type="String"><?= htmlspecialchars($c['placaCbz'] ?? '') ?></Data></Cell>
        <Cell><Data ss:Type="String"><?= htmlspecialchars($c['periodo'] ?? '') ?></Data></Cell>
        <Cell><Data ss:Type="String"><?= htmlspecialchars($c['semana'] ?? '') ?></Data></Cell>
        <Cell><Data ss:Type="String"><?= htmlspecialchars($c['ruta'] ?? '') ?></Data></Cell>
        <Cell ss:StyleID="<?= $numStyle ?>"><Data ss:Type="Number"><?= (float)($c['galDesp'] ?? 0) ?></Data></Cell>
        <Cell ss:StyleID="<?= $numStyle ?>"><Data ss:Type="Number"><?= (float)($c['valor'] ?? 0) ?></Data></Cell>
        <Cell ss:StyleID="<?= $numStyle ?>"><Data ss:Type="Number"><?= (float)($c['total'] ?? 0) ?></Data></Cell>
        <Cell><Data ss:Type="String"><?= htmlspecialchars($c['nConte'] ?? '') ?></Data></Cell>
        <Cell><Data ss:Type="String"><?= htmlspecialchars($c['nombCond'] ?? '') ?></Data></Cell>
        <Cell><Data ss:Type="String"><?= $c['anulado'] ? 'ANULADO' : 'ACTIVO' ?></Data></Cell>
    </Row>
<?php endforeach; ?>

    <!-- ========== FILA TOTAL ========== -->
    <Row>
        <Cell ss:MergeAcross="8" ss:StyleID="TotalRow"><Data ss:Type="String">TOTAL</Data></Cell>
        <Cell ss:StyleID="TotalNum"><Data ss:Type="Number"><?= $totalGalones ?></Data></Cell>
        <Cell ss:StyleID="TotalEmpty"><Data ss:Type="String"></Data></Cell>
        <Cell ss:StyleID="TotalNumGreen"><Data ss:Type="Number"><?= $totalMonto ?></Data></Cell>
        <Cell ss:StyleID="TotalEmpty"><Data ss:Type="String"></Data></Cell>
        <Cell ss:StyleID="TotalEmpty"><Data ss:Type="String"></Data></Cell>
        <Cell ss:StyleID="TotalEmpty"><Data ss:Type="String"></Data></Cell>
    </Row>

    <!-- Fila vacía -->
    <Row></Row>

    <!-- ========== RESUMEN ========== -->
    <Row>
        <Cell ss:MergeAcross="3" ss:StyleID="ResumenTitle"><Data ss:Type="String">RESUMEN</Data></Cell>
    </Row>
<?php if ($despachador !== ''): ?>
    <Row>
        <Cell ss:StyleID="Bold"><Data ss:Type="String">Despachador:</Data></Cell>
        <Cell ss:StyleID="InfoBlue"><Data ss:Type="String"><?= htmlspecialchars($despachador) ?></Data></Cell>
    </Row>
<?php endif; ?>
<?php if ($periodo !== ''): ?>
    <Row>
        <Cell ss:StyleID="Bold"><Data ss:Type="String">Periodo:</Data></Cell>
        <Cell><Data ss:Type="String"><?= htmlspecialchars($periodo) ?></Data></Cell>
    </Row>
<?php endif; ?>
<?php if ($semana !== ''): ?>
    <Row>
        <Cell ss:StyleID="Bold"><Data ss:Type="String">Semana:</Data></Cell>
        <Cell><Data ss:Type="String"><?= htmlspecialchars($semana) ?></Data></Cell>
    </Row>
<?php endif; ?>
<?php if ($fechaDesde !== '' || $fechaHasta !== ''): ?>
    <Row>
        <Cell ss:StyleID="Bold"><Data ss:Type="String">Fecha Desde:</Data></Cell>
        <Cell><Data ss:Type="String"><?= htmlspecialchars($fechaDesde ?: 'N/A') ?></Data></Cell>
    </Row>
    <Row>
        <Cell ss:StyleID="Bold"><Data ss:Type="String">Fecha Hasta:</Data></Cell>
        <Cell><Data ss:Type="String"><?= htmlspecialchars($fechaHasta ?: 'N/A') ?></Data></Cell>
    </Row>
<?php endif; ?>
    <!-- Línea separadora -->
    <Row></Row>
    <Row>
        <Cell ss:StyleID="Bold"><Data ss:Type="String">Total Registros:</Data></Cell>
        <Cell><Data ss:Type="Number"><?= count($datos) ?></Data></Cell>
    </Row>
    <Row>
        <Cell ss:StyleID="Bold"><Data ss:Type="String">Registros Anulados:</Data></Cell>
        <Cell ss:StyleID="BoldRed"><Data ss:Type="Number"><?= $anulados ?></Data></Cell>
    </Row>
    <Row>
        <Cell ss:StyleID="Bold"><Data ss:Type="String">Total Galones:</Data></Cell>
        <Cell ss:StyleID="NumBold"><Data ss:Type="Number"><?= $totalGalones ?></Data></Cell>
    </Row>
    <Row>
        <Cell ss:StyleID="Bold"><Data ss:Type="String">Monto Total:</Data></Cell>
        <Cell ss:StyleID="NumBold"><Data ss:Type="Number"><?= $totalMonto ?></Data></Cell>
    </Row>
<?php
// MEDICION DE TANQUE + ODOMETRO POR TURNO
if ($fechaDesde !== '' || $fechaHasta !== '' || $despachador !== '') {
    $odoWhere = [];
    $odoParams = [];
    $odoTypes = '';
    if ($fechaDesde !== '') { $odoWhere[] = "fecha >= ?"; $odoParams[] = $fechaDesde; $odoTypes .= 's'; }
    if ($fechaHasta !== '') { $odoWhere[] = "fecha <= ?"; $odoParams[] = $fechaHasta; $odoTypes .= 's'; }
    if ($despachador !== '') { $odoWhere[] = "despachador = ?"; $odoParams[] = strtoupper($despachador); $odoTypes .= 's'; }

    // Global MIN/MAX
    $gSQL = "SELECT MIN(odometroInicio) AS odoMin, MAX(odometroCierre) AS odoMax FROM cierre_turno" .
        (count($odoWhere) > 0 ? " WHERE " . implode(' AND ', $odoWhere) : "");
    $stmtG = $conn->prepare($gSQL);
    if ($odoTypes !== '') $stmtG->bind_param($odoTypes, ...$odoParams);
    $stmtG->execute();
    $gRow = $stmtG->get_result()->fetch_assoc();
    $stmtG->close();
    $odoIni = $gRow ? (float)$gRow['odoMin'] : 0;
    $odoFin = $gRow ? (float)$gRow['odoMax'] : 0;
    $totalDisp = $odoFin - $odoIni;
    $consumoOdo = $totalGalones;
    $difMed = $totalDisp - $consumoOdo;
    $difColor = $difMed < 0 ? ' ss:StyleID="NumRed"' : ($difMed == 0 ? ' ss:StyleID="NumBoldBlue"' : ' ss:StyleID="NumBold"');
?>
    <Row></Row>
    <Row>
        <Cell ss:MergeAcross="3" ss:StyleID="ResumenTitle"><Data ss:Type="String">MEDICION DE TANQUE</Data></Cell>
    </Row>
    <Row>
        <Cell ss:StyleID="Bold"><Data ss:Type="String">Odometro Inicial:</Data></Cell>
<?php if ($odoIni > 0 || $odoFin > 0): ?>
        <Cell ss:StyleID="NumBold"><Data ss:Type="Number"><?= $odoIni ?></Data></Cell>
<?php else: ?>
        <Cell><Data ss:Type="String">Sin medicion</Data></Cell>
<?php endif; ?>
    </Row>
    <Row>
        <Cell ss:StyleID="Bold"><Data ss:Type="String">Odometro Final:</Data></Cell>
<?php if ($odoIni > 0 || $odoFin > 0): ?>
        <Cell ss:StyleID="NumBold"><Data ss:Type="Number"><?= $odoFin ?></Data></Cell>
<?php else: ?>
        <Cell><Data ss:Type="String">Sin medicion</Data></Cell>
<?php endif; ?>
    </Row>
    <Row>
        <Cell ss:StyleID="Bold"><Data ss:Type="String">Total Dispensado:</Data></Cell>
        <Cell ss:StyleID="NumBold"><Data ss:Type="Number"><?= $totalDisp ?></Data></Cell>
    </Row>
    <Row>
        <Cell ss:StyleID="Bold"><Data ss:Type="String">Consumo segun Odometro:</Data></Cell>
        <Cell ss:StyleID="NumBold"><Data ss:Type="Number"><?= $consumoOdo ?></Data></Cell>
    </Row>
    <Row>
        <Cell ss:StyleID="Bold"><Data ss:Type="String">Diferencia:</Data></Cell>
        <Cell<?= $difColor ?>><Data ss:Type="Number"><?= $difMed ?></Data></Cell>
    </Row>
<?php
    // Per-despachador detail
    $odoSQL = "SELECT despachador, MIN(odometroInicio) AS odoInicio, MAX(odometroCierre) AS odoCierre, fecha
               FROM cierre_turno" . (count($odoWhere) > 0 ? " WHERE " . implode(' AND ', $odoWhere) : "") .
               " GROUP BY despachador, fecha ORDER BY fecha ASC";
    $stmtOdo = $conn->prepare($odoSQL);
    if ($odoTypes !== '') $stmtOdo->bind_param($odoTypes, ...$odoParams);
    $stmtOdo->execute();
    $odoResult = $stmtOdo->get_result()->fetch_all(MYSQLI_ASSOC);
    $stmtOdo->close();

    if (!empty($odoResult)):
        $totalOdo = 0;
        foreach ($odoResult as $odo) { $totalOdo += ((float)$odo['odoCierre'] - (float)$odo['odoInicio']); }
        $variacion = $totalOdo - $totalGalones;
        $varColor = $variacion < 0 ? ' ss:StyleID="NumRed"' : ($variacion == 0 ? ' ss:StyleID="NumBoldBlue"' : ' ss:StyleID="NumBold"');
?>
    <Row></Row>
    <Row>
        <Cell ss:MergeAcross="3" ss:StyleID="ResumenTitle"><Data ss:Type="String">ODOMETRO POR TURNO</Data></Cell>
    </Row>
    <Row>
        <Cell ss:StyleID="Bold"><Data ss:Type="String">Despachador</Data></Cell>
        <Cell ss:StyleID="Bold"><Data ss:Type="String">Fecha</Data></Cell>
        <Cell ss:StyleID="Bold"><Data ss:Type="String">Odo. Inicio</Data></Cell>
        <Cell ss:StyleID="Bold"><Data ss:Type="String">Odo. Cierre</Data></Cell>
    </Row>
<?php foreach ($odoResult as $odo): ?>
    <Row>
        <Cell><Data ss:Type="String"><?= htmlspecialchars($odo['despachador']) ?></Data></Cell>
        <Cell><Data ss:Type="String"><?= date('d/m/Y', strtotime($odo['fecha'])) ?></Data></Cell>
        <Cell ss:StyleID="NumBold"><Data ss:Type="Number"><?= (float)$odo['odoInicio'] ?></Data></Cell>
        <Cell ss:StyleID="NumBold"><Data ss:Type="Number"><?= (float)$odo['odoCierre'] ?></Data></Cell>
    </Row>
<?php endforeach; ?>
    <Row>
        <Cell ss:StyleID="Bold"><Data ss:Type="String">Total segun Odometro:</Data></Cell>
        <Cell ss:StyleID="NumBold"><Data ss:Type="Number"><?= $totalOdo ?></Data></Cell>
    </Row>
    <Row>
        <Cell ss:StyleID="Bold"><Data ss:Type="String">Total Galones Vendidos:</Data></Cell>
        <Cell ss:StyleID="NumBold"><Data ss:Type="Number"><?= $totalGalones ?></Data></Cell>
    </Row>
    <Row>
        <Cell ss:StyleID="Bold"><Data ss:Type="String">Variacion:</Data></Cell>
        <Cell<?= $varColor ?>><Data ss:Type="Number"><?= $variacion ?></Data></Cell>
    </Row>
<?php endif; } ?>
</Table>
</Worksheet>
</Workbook>
