<?php
require_once 'includes/auth.php';
requireLogin();
requirePermiso('comprobante');
require_once 'includes/config.php';

$id = (int)($_GET['id'] ?? 0);
if ($id <= 0) { echo 'ID invalido'; exit; }

// Obtener comprobante
$stmt = $conn->prepare("SELECT * FROM comprobante WHERE idcprbnt = ?");
$stmt->bind_param('i', $id);
$stmt->execute();
$c = $stmt->get_result()->fetch_assoc();
$stmt->close();

if (!$c) { echo 'Comprobante no encontrado'; exit; }

// Obtener empresa
$res = $conn->query("SELECT nEmpre, rtn FROM empresa LIMIT 1");
$empresa = $res->fetch_assoc() ?: ['nEmpre' => 'EMPRESA', 'rtn' => ''];

$fecha = $c['fecha'] ? date('d-m-Y', strtotime($c['fecha'])) : '';
$galDesp = (float)($c['galDesp'] ?? 0);
$valor = (float)($c['valor'] ?? 0);
$totalVenta = $galDesp * $valor;
$anulado = (int)($c['anulado'] ?? 0);
?>
<!DOCTYPE html>
<html lang="es">
<head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Documento <?= htmlspecialchars($c['nCompro']) ?></title>
    <style>
        * { margin: 0; padding: 0; box-sizing: border-box; }
        body { font-family: 'Calibri', 'Arial', sans-serif; font-size: 12px; padding: 15px; max-width: 420px; margin: 0 auto; }

        .header { text-align: center; margin-bottom: 10px; border: 1px solid #333; padding: 8px; }
        .header img.logo { display: block; margin: 0 auto 5px; max-height: 70px; }
        .header h2 { font-size: 14px; font-weight: bold; margin-bottom: 2px; }
        .header .rtn { font-size: 11px; color: #555; }
        .title {
            text-align: center;
            font-weight: bold;
            font-size: 13px;
            border: 1px solid #333;
            padding: 6px;
            margin: 8px 0;
            letter-spacing: 0.5px;
        }

        .separator { border-top: 2px solid #333; margin: 6px 0; }
        .separator-light { border-top: 1px dashed #999; margin: 4px 0; }

        .info-row { display: flex; justify-content: space-between; padding: 3px 0; }
        .info-row .label { font-weight: bold; font-size: 12px; }
        .info-row .value { font-size: 12px; text-align: right; max-width: 60%; }
        .info-row .value-bold { font-size: 13px; font-weight: bold; text-align: right; }

        .section { font-weight: bold; font-size: 11px; padding: 3px 0; color: #333; }

        .field { display: flex; justify-content: space-between; padding: 2px 0; border-bottom: 1px dotted #ddd; }
        .field .label { font-weight: bold; color: #333; font-size: 11px; }
        .field .value { text-align: right; max-width: 60%; font-size: 11px; }

        .financial-box { background: #f5f5f5; border: 1px solid #999; padding: 8px; margin: 10px 0; }
        .financial-row { display: flex; justify-content: space-between; padding: 3px 0; font-size: 12px; }
        .financial-row.total { font-weight: bold; font-size: 14px; border-top: 2px solid #333; padding-top: 5px; margin-top: 3px; }

        .firma { margin-top: 25px; text-align: center; }
        .firma .linea { border-top: 1px solid #000; width: 65%; margin: 0 auto; padding-top: 3px; font-size: 10px; }

        .anulado-stamp { color: red; font-size: 28px; font-weight: bold; text-align: center; transform: rotate(-15deg); border: 3px solid red; padding: 5px; margin: 10px 20px; opacity: 0.7; }

        .no-print { text-align: center; margin-bottom: 10px; }

        @media print {
            .no-print { display: none !important; }
            body { padding: 0; }
        }
    </style>
</head>
<body>

<div class="no-print">
    <button onclick="window.print()" style="padding:8px 20px; font-size:14px; cursor:pointer; background:#4A5A78; color:white; border:none; border-radius:4px;">Imprimir</button>
    <button onclick="window.close()" style="padding:8px 20px; font-size:14px; cursor:pointer; background:#999; color:white; border:none; border-radius:4px; margin-left:5px;">Cerrar</button>
    <hr style="margin:8px 0;">
</div>

<div class="header">
    <img src="img/Emtracc.png" alt="EMTRACC" class="logo">
    <h2><?= htmlspecialchars($empresa['nEmpre']) ?></h2>
    <div class="rtn">RTN: <?= htmlspecialchars($empresa['rtn']) ?></div>
</div>

<div class="title">COMPROBANTE DE DESPACHO DE COMBUSTIBLE</div>

<?php if ($anulado): ?>
<div class="anulado-stamp">ANULADO</div>
<?php endif; ?>

<!-- Info superior: Fecha, Periodo-Semana, Comprobante -->
<div class="separator"></div>

<div class="info-row">
    <span class="label">FECHA:</span>
    <span class="value"><?= $fecha ?></span>
</div>

<div class="info-row">
    <span class="label">Periodo - Semana:</span>
    <span class="value-bold"><?= htmlspecialchars($c['periodo'] ?? '') ?> - <?= htmlspecialchars($c['semana'] ?? '') ?></span>
</div>

<div class="info-row">
    <span class="label">Comprobante N&deg;:</span>
    <span class="value-bold"><?= htmlspecialchars($c['nCompro']) ?></span>
</div>

<div class="separator"></div>

<!-- Propietario Cabezal -->
<div class="section">=== Propietario Cabezal ===</div>

<div class="field">
    <span class="label">Propietario:</span>
    <span class="value"><?= htmlspecialchars($c['propCbz'] ?? '') ?></span>
</div>

<div class="field">
    <span class="label">Cod. Propietario:</span>
    <span class="value"><?= htmlspecialchars($c['codiProp'] ?? '') ?></span>
</div>

<div class="field">
    <span class="label">Cabezal:</span>
    <span class="value"><?= htmlspecialchars($c['placaCbz'] ?? '') ?></span>
</div>

<div class="field">
    <span class="label">Contenedor:</span>
    <span class="value"><?= htmlspecialchars($c['nConte'] ?? '') ?></span>
</div>

<div class="field">
    <span class="label">N&deg; Boleta:</span>
    <span class="value"><?= htmlspecialchars($c['nBoleta'] ?? '') ?></span>
</div>

<div class="separator-light"></div>

<!-- Ruta -->
<div class="field">
    <span class="label">Ruta:</span>
    <span class="value"><?= htmlspecialchars($c['ruta'] ?? '') ?></span>
</div>

<div class="separator"></div>

<!-- Conductor -->
<div class="section">=== Nombre Conductor ===</div>
<div class="field">
    <span class="label">Nombre:</span>
    <span class="value"><?= htmlspecialchars($c['nombCond'] ?? '') ?></span>
</div>

<div class="separator-light"></div>

<!-- Despachador -->
<div class="section">=== Nombre Despachador ===</div>
<div class="field">
    <span class="label">Nombre:</span>
    <span class="value"><?= htmlspecialchars($c['nombDesp'] ?? '') ?></span>
</div>

<div class="separator"></div>

<!-- Resumen financiero -->
<div class="financial-box">
    <div class="financial-row">
        <span>Galones Despachados:</span>
        <span><strong><?= number_format($galDesp, 2) ?></strong></span>
    </div>
    <div class="financial-row">
        <span>Precio por Gal&oacute;n:</span>
        <span>L. <?= number_format($valor, 2) ?></span>
    </div>
    <div class="financial-row total">
        <span>Total Venta:</span>
        <span>L. <?= number_format($totalVenta, 2) ?></span>
    </div>
</div>

<!-- Firma -->
<div class="firma">
    <div class="linea">Firma Autorizada</div>
</div>

<script>
    // window.onload = () => window.print();
</script>
</body>
</html>
