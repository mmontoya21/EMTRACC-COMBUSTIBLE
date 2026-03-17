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
$total = (float)($c['galDesp'] ?? 0) * (float)($c['valor'] ?? 0);
$anulado = (int)($c['anulado'] ?? 0);
?>
<!DOCTYPE html>
<html lang="es">
<head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Comprobante <?= htmlspecialchars($c['nCompro']) ?></title>
    <style>
        * { margin: 0; padding: 0; box-sizing: border-box; }
        body { font-family: 'Courier New', monospace; font-size: 12px; padding: 10px; max-width: 380px; margin: 0 auto; }

        .header { text-align: center; margin-bottom: 8px; }
        .header img.logo { display: block; margin: 0 auto 4px; max-height: 55px; }
        .header h2 { font-size: 14px; margin-bottom: 2px; }
        .header .rtn { font-size: 11px; color: #555; }
        .title { text-align: center; font-weight: bold; font-size: 11px; border-top: 1px dashed #000; border-bottom: 1px dashed #000; padding: 4px 0; margin: 6px 0; }

        .field { display: flex; justify-content: space-between; padding: 2px 0; border-bottom: 1px dotted #ccc; }
        .field .label { font-weight: bold; color: #333; }
        .field .value { text-align: right; max-width: 60%; }

        .section { font-weight: bold; background: #f0f0f0; padding: 3px 5px; margin: 6px 0 3px 0; font-size: 11px; text-transform: uppercase; }

        .total-box { background: #e8e8e8; padding: 6px; margin: 8px 0; text-align: center; font-weight: bold; font-size: 14px; border: 1px solid #999; }

        .firma { margin-top: 30px; text-align: center; }
        .firma .linea { border-top: 1px solid #000; width: 70%; margin: 0 auto; padding-top: 3px; font-size: 11px; }

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

<div class="field">
    <span class="label">Fecha:</span>
    <span class="value"><?= $fecha ?></span>
</div>

<div class="field">
    <span class="label">Comprobante No:</span>
    <span class="value"><?= htmlspecialchars($c['nCompro']) ?></span>
</div>

<div class="field">
    <span class="label">Proxima Semana:</span>
    <span class="value"><?= htmlspecialchars($c['proxSem'] ?? 'NO') ?></span>
</div>

<div class="section">Combustible Despachado</div>

<div class="field">
    <span class="label">Galones:</span>
    <span class="value"><?= number_format((float)$c['galDesp'], 2) ?></span>
</div>

<div class="field">
    <span class="label">Valor por Galon:</span>
    <span class="value">L. <?= number_format((float)$c['valor'], 2) ?></span>
</div>

<div class="total-box">
    TOTAL: L. <?= number_format($total, 2) ?>
</div>

<div class="section">Propietario Cabezal</div>

<div class="field">
    <span class="label">Propietario:</span>
    <span class="value"><?= htmlspecialchars($c['propCbz'] ?? '') ?></span>
</div>

<div class="field">
    <span class="label">Codigo:</span>
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
    <span class="label">No Boleta:</span>
    <span class="value"><?= htmlspecialchars($c['nBoleta'] ?? '') ?></span>
</div>

<div class="field">
    <span class="label">Ruta:</span>
    <span class="value"><?= htmlspecialchars($c['ruta'] ?? '') ?></span>
</div>

<div class="section">Conductor</div>
<div class="field">
    <span class="label">Nombre:</span>
    <span class="value"><?= htmlspecialchars($c['nombCond'] ?? '') ?></span>
</div>

<div class="firma">
    <div class="linea">Firma Conductor</div>
</div>

<div class="section" style="margin-top:15px;">Despachador</div>
<div class="field">
    <span class="label">Nombre:</span>
    <span class="value"><?= htmlspecialchars($c['nombDesp'] ?? '') ?></span>
</div>

<div class="firma">
    <div class="linea">Firma Despachador</div>
</div>

<div style="text-align:center; margin-top:15px; font-size:10px; color:#777;">
    Periodo <?= htmlspecialchars($c['periodo'] ?? '') ?> - Semana <?= htmlspecialchars($c['semana'] ?? '') ?>
</div>

<script>
    // Auto-imprimir al cargar (opcional)
    // window.onload = () => window.print();
</script>
</body>
</html>
