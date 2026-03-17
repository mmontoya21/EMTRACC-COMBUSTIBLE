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

// Texto de filtros
$filtrosTexto = '';
$hayFiltros = false;
if ($fechaDesde !== '' || $fechaHasta !== '') { $filtrosTexto .= 'Fecha ' . ($fechaDesde ?: '...') . ' - ' . ($fechaHasta ?: '...') . ' | '; $hayFiltros = true; }
if ($despachador !== '') { $filtrosTexto .= 'Despachador: ' . $despachador . ' | '; $hayFiltros = true; }
if ($periodo !== '') { $filtrosTexto .= 'Periodo: ' . $periodo . ' | '; $hayFiltros = true; }
if ($semana !== '') { $filtrosTexto .= 'Semana: ' . $semana . ' | '; $hayFiltros = true; }
if ($propietario !== '') { $filtrosTexto .= 'Propietario: ' . $propietario . ' | '; $hayFiltros = true; }
if ($placa !== '') { $filtrosTexto .= 'Placa: ' . $placa . ' | '; $hayFiltros = true; }
if ($boleta !== '') { $filtrosTexto .= 'Boleta: ' . $boleta . ' | '; $hayFiltros = true; }
if ($comprobante !== '') { $filtrosTexto .= 'Comprobante: ' . $comprobante . ' | '; $hayFiltros = true; }
$filtrosTexto = $hayFiltros ? 'Filtros: ' . rtrim($filtrosTexto, ' | ') : 'Sin filtros aplicados';

// ========== Funciones helper para XLSX ==========
function e($str) { return htmlspecialchars((string)$str, ENT_XML1, 'UTF-8'); }

function colLetter($col) {
    $letter = '';
    $col++;
    while ($col > 0) {
        $col--;
        $letter = chr(65 + ($col % 26)) . $letter;
        $col = intdiv($col, 26);
    }
    return $letter;
}

// ========== Construir datos de la hoja ==========
$numCols = 15;
$rows = [];
$merges = [];
$rowStyles = []; // rowIndex => styleId

// Fila 1: Título
$rows[] = [['v' => 'REPORTE DE COMPROBANTES DE COMBUSTIBLE', 't' => 's']];
$merges[] = 'A1:' . colLetter($numCols - 1) . '1';
$rowStyles[0] = 1; // Title style

// Fila 2: Filtros
$rows[] = [['v' => $filtrosTexto, 't' => 's']];
$merges[] = 'A2:' . colLetter($numCols - 1) . '2';
$rowStyles[1] = 2; // Info style

// Fila 3: Fecha generación
$rows[] = [['v' => 'Generado: ' . date('d/m/Y H:i:s'), 't' => 's']];
$merges[] = 'A3:' . colLetter($numCols - 1) . '3';
$rowStyles[2] = 2; // Info style

// Fila 4: vacía
$rows[] = [];

// Fila 5: Encabezados
$headers = ['No. Compro', 'No. Boleta', 'Fecha', 'Despachador', 'Propietario', 'Placa', 'Período', 'Semana', 'Ruta', 'Galones', 'Valor', 'Total', 'Contenedor', 'Conductor', 'Estado'];
$headerRow = [];
foreach ($headers as $h) {
    $headerRow[] = ['v' => $h, 't' => 's'];
}
$rows[] = $headerRow;
$rowStyles[4] = 3; // Header style

// Filas de datos
$rowIndex = 0;
$totalGalones = 0;
$totalMonto = 0;
$anulados = 0;

foreach ($datos as $c) {
    $dataRowIdx = count($rows);

    if ($c['anulado']) {
        $styleId = 6; // Anulado
        $numStyleId = 9; // NumAnulado
        $anulados++;
    } else {
        if ($rowIndex % 2 === 0) {
            $styleId = 4; // White
            $numStyleId = 7; // NumWhite
        } else {
            $styleId = 5; // Blue
            $numStyleId = 8; // NumBlue
        }
        $totalGalones += (float)($c['galDesp'] ?? 0);
        $totalMonto += (float)($c['total'] ?? 0);
    }
    $rowIndex++;

    $row = [
        ['v' => $c['nCompro'] ?? '', 't' => 's', 'si' => $styleId],
        ['v' => $c['nBoleta'] ?? '', 't' => 's', 'si' => $styleId],
        ['v' => $c['fecha'] ? date('d/m/Y', strtotime($c['fecha'])) : '', 't' => 's', 'si' => $styleId],
        ['v' => $c['nombDesp'] ?? '', 't' => 's', 'si' => $styleId],
        ['v' => $c['propCbz'] ?? '', 't' => 's', 'si' => $styleId],
        ['v' => $c['placaCbz'] ?? '', 't' => 's', 'si' => $styleId],
        ['v' => $c['periodo'] ?? '', 't' => 's', 'si' => $styleId],
        ['v' => $c['semana'] ?? '', 't' => 's', 'si' => $styleId],
        ['v' => $c['ruta'] ?? '', 't' => 's', 'si' => $styleId],
        ['v' => (float)($c['galDesp'] ?? 0), 't' => 'n', 'si' => $numStyleId],
        ['v' => (float)($c['valor'] ?? 0), 't' => 'n', 'si' => $numStyleId],
        ['v' => (float)($c['total'] ?? 0), 't' => 'n', 'si' => $numStyleId],
        ['v' => $c['nConte'] ?? '', 't' => 's', 'si' => $styleId],
        ['v' => $c['nombCond'] ?? '', 't' => 's', 'si' => $styleId],
        ['v' => $c['anulado'] ? 'ANULADO' : 'ACTIVO', 't' => 's', 'si' => $styleId],
    ];
    $rows[] = $row;
}

// Fila TOTAL
$totalRowIdx = count($rows);
$totalRowNum = $totalRowIdx + 1;
$totalRow = [];
for ($i = 0; $i < $numCols; $i++) {
    if ($i === 0) {
        $totalRow[] = ['v' => 'TOTAL', 't' => 's', 'si' => 10];
    } elseif ($i < 9) {
        $totalRow[] = ['v' => '', 't' => 's', 'si' => 10];
    } elseif ($i === 9) {
        $totalRow[] = ['v' => $totalGalones, 't' => 'n', 'si' => 11]; // Galones total
    } elseif ($i === 10) {
        $totalRow[] = ['v' => '', 't' => 's', 'si' => 13];
    } elseif ($i === 11) {
        $totalRow[] = ['v' => $totalMonto, 't' => 'n', 'si' => 12]; // Monto total
    } else {
        $totalRow[] = ['v' => '', 't' => 's', 'si' => 13];
    }
}
$rows[] = $totalRow;

// Fila vacía
$rows[] = [];

// RESUMEN
$resumenStartIdx = count($rows);
$resumenStartRow = $resumenStartIdx + 1;
$rows[] = [['v' => 'RESUMEN', 't' => 's', 'si' => 14]];
$merges[] = 'A' . $resumenStartRow . ':D' . $resumenStartRow;

if ($despachador !== '') {
    $rows[] = [['v' => 'Despachador:', 't' => 's', 'si' => 15], ['v' => $despachador, 't' => 's', 'si' => 16]];
}
if ($periodo !== '') {
    $rows[] = [['v' => 'Periodo:', 't' => 's', 'si' => 15], ['v' => $periodo, 't' => 's']];
}
if ($semana !== '') {
    $rows[] = [['v' => 'Semana:', 't' => 's', 'si' => 15], ['v' => $semana, 't' => 's']];
}
if ($fechaDesde !== '' || $fechaHasta !== '') {
    $rows[] = [['v' => 'Fecha Desde:', 't' => 's', 'si' => 15], ['v' => $fechaDesde ?: 'N/A', 't' => 's']];
    $rows[] = [['v' => 'Fecha Hasta:', 't' => 's', 'si' => 15], ['v' => $fechaHasta ?: 'N/A', 't' => 's']];
}
$rows[] = []; // separador
$rows[] = [['v' => 'Total Registros:', 't' => 's', 'si' => 15], ['v' => count($datos), 't' => 'n']];
$rows[] = [['v' => 'Registros Anulados:', 't' => 's', 'si' => 15], ['v' => $anulados, 't' => 'n', 'si' => 17]];
$rows[] = [['v' => 'Total Galones:', 't' => 's', 'si' => 15], ['v' => $totalGalones, 't' => 'n', 'si' => 18]];
$rows[] = [['v' => 'Monto Total:', 't' => 's', 'si' => 15], ['v' => $totalMonto, 't' => 'n', 'si' => 18]];

// ========== Generar XLSX con ZipArchive ==========
$tmp = tempnam(sys_get_temp_dir(), 'xlsx');
$zip = new ZipArchive();
$zip->open($tmp, ZipArchive::CREATE | ZipArchive::OVERWRITE);

// [Content_Types].xml
$zip->addFromString('[Content_Types].xml', '<?xml version="1.0" encoding="UTF-8" standalone="yes"?>
<Types xmlns="http://schemas.openxmlformats.org/package/2006/content-types">
<Default Extension="rels" ContentType="application/vnd.openxmlformats-package.relationships+xml"/>
<Default Extension="xml" ContentType="application/xml"/>
<Override PartName="/xl/workbook.xml" ContentType="application/vnd.openxmlformats-officedocument.spreadsheetml.sheet.main+xml"/>
<Override PartName="/xl/worksheets/sheet1.xml" ContentType="application/vnd.openxmlformats-officedocument.spreadsheetml.worksheet+xml"/>
<Override PartName="/xl/styles.xml" ContentType="application/vnd.openxmlformats-officedocument.spreadsheetml.styles+xml"/>
<Override PartName="/xl/sharedStrings.xml" ContentType="application/vnd.openxmlformats-officedocument.spreadsheetml.sharedStrings+xml"/>
</Types>');

// _rels/.rels
$zip->addFromString('_rels/.rels', '<?xml version="1.0" encoding="UTF-8" standalone="yes"?>
<Relationships xmlns="http://schemas.openxmlformats.org/package/2006/relationships">
<Relationship Id="rId1" Type="http://schemas.openxmlformats.org/officeDocument/2006/relationships/officeDocument" Target="xl/workbook.xml"/>
</Relationships>');

// xl/_rels/workbook.xml.rels
$zip->addFromString('xl/_rels/workbook.xml.rels', '<?xml version="1.0" encoding="UTF-8" standalone="yes"?>
<Relationships xmlns="http://schemas.openxmlformats.org/package/2006/relationships">
<Relationship Id="rId1" Type="http://schemas.openxmlformats.org/officeDocument/2006/relationships/worksheet" Target="worksheets/sheet1.xml"/>
<Relationship Id="rId2" Type="http://schemas.openxmlformats.org/officeDocument/2006/relationships/styles" Target="styles.xml"/>
<Relationship Id="rId3" Type="http://schemas.openxmlformats.org/officeDocument/2006/relationships/sharedStrings" Target="sharedStrings.xml"/>
</Relationships>');

// xl/workbook.xml
$zip->addFromString('xl/workbook.xml', '<?xml version="1.0" encoding="UTF-8" standalone="yes"?>
<workbook xmlns="http://schemas.openxmlformats.org/spreadsheetml/2006/main" xmlns:r="http://schemas.openxmlformats.org/officeDocument/2006/relationships">
<sheets><sheet name="Comprobantes" sheetId="1" r:id="rId1"/></sheets>
</workbook>');

// ========== Shared Strings ==========
$sharedStrings = [];
$ssIndex = [];
function getSSIndex($val) {
    global $sharedStrings, $ssIndex;
    $key = (string)$val;
    if (!isset($ssIndex[$key])) {
        $ssIndex[$key] = count($sharedStrings);
        $sharedStrings[] = $key;
    }
    return $ssIndex[$key];
}

// Pre-process rows to collect shared strings and build sheet data
$sheetRows = '';
foreach ($rows as $r => $row) {
    $rowNum = $r + 1;
    $defaultStyle = $rowStyles[$r] ?? 0;
    $sheetRows .= '<row r="' . $rowNum . '">';
    foreach ($row as $c => $cell) {
        $ref = colLetter($c) . $rowNum;
        $si = $cell['si'] ?? $defaultStyle;
        if ($cell['t'] === 'n') {
            $sheetRows .= '<c r="' . $ref . '" s="' . $si . '"><v>' . $cell['v'] . '</v></c>';
        } else {
            $idx = getSSIndex($cell['v']);
            $sheetRows .= '<c r="' . $ref . '" s="' . $si . '" t="s"><v>' . $idx . '</v></c>';
        }
    }
    $sheetRows .= '</row>';
}

// Build shared strings XML
$ssXml = '<?xml version="1.0" encoding="UTF-8" standalone="yes"?>';
$ssXml .= '<sst xmlns="http://schemas.openxmlformats.org/spreadsheetml/2006/main" count="' . count($sharedStrings) . '" uniqueCount="' . count($sharedStrings) . '">';
foreach ($sharedStrings as $s) {
    $ssXml .= '<si><t>' . e($s) . '</t></si>';
}
$ssXml .= '</sst>';
$zip->addFromString('xl/sharedStrings.xml', $ssXml);

// ========== Merges ==========
$mergesXml = '';
if (!empty($merges)) {
    $mergesXml = '<mergeCells count="' . count($merges) . '">';
    foreach ($merges as $m) {
        $mergesXml .= '<mergeCell ref="' . $m . '"/>';
    }
    $mergesXml .= '</mergeCells>';
}

// ========== Sheet ==========
$colWidths = [80,75,80,130,150,75,60,60,100,70,70,70,85,120,65];
$colsXml = '<cols>';
foreach ($colWidths as $i => $w) {
    $px = round($w / 7.5, 2);
    $colsXml .= '<col min="' . ($i+1) . '" max="' . ($i+1) . '" width="' . $px . '" customWidth="1"/>';
}
$colsXml .= '</cols>';

$sheetXml = '<?xml version="1.0" encoding="UTF-8" standalone="yes"?>
<worksheet xmlns="http://schemas.openxmlformats.org/spreadsheetml/2006/main" xmlns:r="http://schemas.openxmlformats.org/officeDocument/2006/relationships">
' . $colsXml . '
<sheetData>' . $sheetRows . '</sheetData>
' . $mergesXml . '
</worksheet>';
$zip->addFromString('xl/worksheets/sheet1.xml', $sheetXml);

// ========== Styles ==========
// Fonts: 0=default, 1=title(bold,white,16), 2=info(italic,gray), 3=header(bold,white), 4=bold, 5=anulado(darkred), 6=red, 7=blue
$stylesXml = '<?xml version="1.0" encoding="UTF-8" standalone="yes"?>
<styleSheet xmlns="http://schemas.openxmlformats.org/spreadsheetml/2006/main">
<numFmts count="1">
    <numFmt numFmtId="164" formatCode="#,##0.00"/>
</numFmts>
<fonts count="8">
    <font><sz val="10"/><name val="Calibri"/></font>
    <font><b/><sz val="16"/><color rgb="FFFFFFFF"/><name val="Calibri"/></font>
    <font><i/><sz val="10"/><color rgb="FF666666"/><name val="Calibri"/></font>
    <font><b/><sz val="10"/><color rgb="FFFFFFFF"/><name val="Calibri"/></font>
    <font><b/><sz val="10"/><name val="Calibri"/></font>
    <font><sz val="10"/><color rgb="FF8B0000"/><name val="Calibri"/></font>
    <font><b/><sz val="10"/><color rgb="FFFF0000"/><name val="Calibri"/></font>
    <font><sz val="10"/><color rgb="FF2E86AB"/><name val="Calibri"/></font>
</fonts>
<fills count="10">
    <fill><patternFill patternType="none"/></fill>
    <fill><patternFill patternType="gray125"/></fill>
    <fill><patternFill patternType="solid"><fgColor rgb="FF6A7EA8"/></patternFill></fill>
    <fill><patternFill patternType="solid"><fgColor rgb="FF4A5A78"/></patternFill></fill>
    <fill><patternFill patternType="solid"><fgColor rgb="FFFFFFFF"/></patternFill></fill>
    <fill><patternFill patternType="solid"><fgColor rgb="FFF0F0F5"/></patternFill></fill>
    <fill><patternFill patternType="solid"><fgColor rgb="FFFFC8C8"/></patternFill></fill>
    <fill><patternFill patternType="solid"><fgColor rgb="FFD4E6F1"/></patternFill></fill>
    <fill><patternFill patternType="solid"><fgColor rgb="FFD5F5E3"/></patternFill></fill>
    <fill><patternFill patternType="solid"><fgColor rgb="FFE8E8F0"/></patternFill></fill>
</fills>
<borders count="3">
    <border><left/><right/><top/><bottom/><diagonal/></border>
    <border><left style="thin"><color auto="1"/></left><right style="thin"><color auto="1"/></right><top style="thin"><color auto="1"/></top><bottom style="thin"><color auto="1"/></bottom></border>
    <border><left/><right/><top style="medium"><color auto="1"/></top><bottom style="medium"><color auto="1"/></bottom></border>
</borders>
<cellStyleXfs count="1"><xf numFmtId="0" fontId="0" fillId="0" borderId="0"/></cellStyleXfs>
<cellXfs count="19">
    <!-- 0: default -->
    <xf numFmtId="0" fontId="0" fillId="0" borderId="0"/>
    <!-- 1: Title - bold white 16 on blue -->
    <xf numFmtId="0" fontId="1" fillId="2" borderId="0" applyFont="1" applyFill="1" applyAlignment="1"><alignment horizontal="center" vertical="center"/></xf>
    <!-- 2: Info - italic gray -->
    <xf numFmtId="0" fontId="2" fillId="0" borderId="0" applyFont="1"/>
    <!-- 3: Header - bold white on dark blue, border -->
    <xf numFmtId="0" fontId="3" fillId="3" borderId="1" applyFont="1" applyFill="1" applyBorder="1" applyAlignment="1"><alignment horizontal="center"/></xf>
    <!-- 4: RowWhite -->
    <xf numFmtId="0" fontId="0" fillId="4" borderId="1" applyFill="1" applyBorder="1"/>
    <!-- 5: RowBlue -->
    <xf numFmtId="0" fontId="0" fillId="5" borderId="1" applyFill="1" applyBorder="1"/>
    <!-- 6: RowAnulado -->
    <xf numFmtId="0" fontId="5" fillId="6" borderId="1" applyFont="1" applyFill="1" applyBorder="1"/>
    <!-- 7: NumWhite -->
    <xf numFmtId="164" fontId="0" fillId="4" borderId="1" applyNumberFormat="1" applyFill="1" applyBorder="1" applyAlignment="1"><alignment horizontal="right"/></xf>
    <!-- 8: NumBlue -->
    <xf numFmtId="164" fontId="0" fillId="5" borderId="1" applyNumberFormat="1" applyFill="1" applyBorder="1" applyAlignment="1"><alignment horizontal="right"/></xf>
    <!-- 9: NumAnulado -->
    <xf numFmtId="164" fontId="5" fillId="6" borderId="1" applyNumberFormat="1" applyFont="1" applyFill="1" applyBorder="1" applyAlignment="1"><alignment horizontal="right"/></xf>
    <!-- 10: TotalRow - bold white on dark blue -->
    <xf numFmtId="0" fontId="3" fillId="3" borderId="2" applyFont="1" applyFill="1" applyBorder="1"/>
    <!-- 11: TotalNum galones - bold on light blue -->
    <xf numFmtId="164" fontId="4" fillId="7" borderId="2" applyNumberFormat="1" applyFont="1" applyFill="1" applyBorder="1" applyAlignment="1"><alignment horizontal="right"/></xf>
    <!-- 12: TotalNum monto - bold on green -->
    <xf numFmtId="164" fontId="4" fillId="8" borderId="2" applyNumberFormat="1" applyFont="1" applyFill="1" applyBorder="1" applyAlignment="1"><alignment horizontal="right"/></xf>
    <!-- 13: TotalEmpty -->
    <xf numFmtId="0" fontId="0" fillId="9" borderId="2" applyFill="1" applyBorder="1"/>
    <!-- 14: ResumenTitle - bold white 12 on blue -->
    <xf numFmtId="0" fontId="1" fillId="2" borderId="0" applyFont="1" applyFill="1"/>
    <!-- 15: Bold label -->
    <xf numFmtId="0" fontId="4" fillId="0" borderId="0" applyFont="1"/>
    <!-- 16: Blue text -->
    <xf numFmtId="0" fontId="7" fillId="0" borderId="0" applyFont="1"/>
    <!-- 17: Red bold number -->
    <xf numFmtId="0" fontId="6" fillId="0" borderId="0" applyFont="1"/>
    <!-- 18: Bold number formatted -->
    <xf numFmtId="164" fontId="4" fillId="0" borderId="0" applyNumberFormat="1" applyFont="1"/>
</cellXfs>
</styleSheet>';
$zip->addFromString('xl/styles.xml', $stylesXml);

$zip->close();

// Enviar archivo
$filename = 'Comprobantes_' . date('Ymd_His') . '.xlsx';
header('Content-Type: application/vnd.openxmlformats-officedocument.spreadsheetml.sheet');
header('Content-Disposition: attachment; filename="' . $filename . '"');
header('Content-Length: ' . filesize($tmp));
header('Cache-Control: max-age=0');
readfile($tmp);
unlink($tmp);
exit;
