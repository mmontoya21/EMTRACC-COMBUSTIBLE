<!DOCTYPE html>
<html lang="es">
<head>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title><?= htmlspecialchars($pageTitle ?? 'EMTRACC') ?> - EMTRACC</title>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" />
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.11.3/font/bootstrap-icons.min.css" />
    <link rel="stylesheet" href="css/style.css" />
</head>
<body<?= isReadOnly() ? ' class="read-only"' : '' ?>>
    <header>
        <nav class="navbar navbar-expand-sm navbar-dark bg-dark border-bottom box-shadow mb-3">
            <div class="container-fluid">
                <a class="navbar-brand" href="index.php">EMTRACC</a>
                <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarNav"
                        aria-controls="navbarNav" aria-expanded="false" aria-label="Toggle navigation">
                    <span class="navbar-toggler-icon"></span>
                </button>
                <div class="navbar-collapse collapse d-sm-inline-flex justify-content-between" id="navbarNav">
                    <ul class="navbar-nav flex-grow-1">
                        <?php if (hasPermiso('comprobante')): ?>
                        <li class="nav-item">
                            <a class="nav-link" href="comprobante.php"><i class="bi bi-plus-circle"></i> Nuevo Comprobante</a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" href="consulta.php"><i class="bi bi-search"></i> Consulta</a>
                        </li>
                        <?php endif; ?>
                        <?php if (hasPermiso('propietario') || hasPermiso('placa') || hasPermiso('rutas') || hasPermiso('valorComb') || hasPermiso('acceso') || hasPermiso('empresa') || hasPermiso('medicion')): ?>
                        <li class="nav-item dropdown">
                            <a class="nav-link dropdown-toggle" href="#" data-bs-toggle="dropdown"><i class="bi bi-journal-text"></i> Cat&aacute;logos</a>
                            <ul class="dropdown-menu">
                                <?php if (hasPermiso('propietario')): ?>
                                <li><a class="dropdown-item" href="propietario.php"><i class="bi bi-people"></i> Propietarios</a></li>
                                <?php endif; ?>
                                <?php if (hasPermiso('placa')): ?>
                                <li><a class="dropdown-item" href="placa.php"><i class="bi bi-truck"></i> Placas</a></li>
                                <?php endif; ?>
                                <?php if (hasPermiso('rutas')): ?>
                                <li><a class="dropdown-item" href="rutas.php"><i class="bi bi-signpost-2"></i> Rutas</a></li>
                                <?php endif; ?>
                                <?php if (hasPermiso('valorComb')): ?>
                                <li><a class="dropdown-item" href="valorComb.php"><i class="bi bi-currency-dollar"></i> Valor Comb.</a></li>
                                <?php endif; ?>
                                <?php if (hasPermiso('empresa')): ?>
                                <li><a class="dropdown-item" href="empresa.php"><i class="bi bi-building"></i> Empresa</a></li>
                                <?php endif; ?>
                                <?php if (hasPermiso('medicion')): ?>
                                <li><a class="dropdown-item" href="medicion.php"><i class="bi bi-rulers"></i> Medici&oacute;n Tanque</a></li>
                                <?php endif; ?>
                                <?php if (hasPermiso('acceso')): ?>
                                <li><hr class="dropdown-divider"></li>
                                <li><a class="dropdown-item" href="acceso.php"><i class="bi bi-shield-lock"></i> Accesos</a></li>
                                <?php endif; ?>
                            </ul>
                        </li>
                        <?php endif; ?>
                        <?php if (hasPermiso('factura')): ?>
                        <li class="nav-item">
                            <a class="nav-link" href="factura.php"><i class="bi bi-receipt"></i> Factura</a>
                        </li>
                        <?php endif; ?>
                        <?php if (hasPermiso('reporte')): ?>
                        <li class="nav-item">
                            <a class="nav-link" href="index.php"><i class="bi bi-file-earmark-bar-graph"></i> Reporte</a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" href="dashboard.php"><i class="bi bi-speedometer2"></i> Dashboard</a>
                        </li>
                        <?php endif; ?>
                        <?php if (getUserRole() === 'SUPERADMIN'): ?>
                        <li class="nav-item">
                            <a class="nav-link" href="login_log.php"><i class="bi bi-clock-history"></i> Log</a>
                        </li>
                        <?php endif; ?>
                    </ul>
                    <?php if (isLoggedIn()): ?>
                    <ul class="navbar-nav">
                        <li class="nav-item">
                            <span class="nav-link text-light"><i class="bi bi-person-circle"></i> <?= htmlspecialchars(getUserName()) ?></span>
                        </li>
                        <li class="nav-item">
                            <a href="logout.php" class="nav-link text-warning"><i class="bi bi-box-arrow-right"></i> Cerrar sesi&oacute;n</a>
                        </li>
                    </ul>
                    <?php endif; ?>
                </div>
            </div>
        </nav>
    </header>
    <div class="container-fluid">
        <main role="main" class="pb-3">
