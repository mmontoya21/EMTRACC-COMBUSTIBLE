<?php
require_once 'includes/auth.php';
require_once 'includes/config.php';

// Si ya está logueado, redirigir
if (isLoggedIn()) {
    header('Location: index.php');
    exit;
}

// Crear tabla de log si no existe
$conn->query("CREATE TABLE IF NOT EXISTS login_log (
    id INT AUTO_INCREMENT PRIMARY KEY,
    usuario VARCHAR(50),
    nombre VARCHAR(100),
    tipo VARCHAR(20),
    ip VARCHAR(45),
    fecha DATETIME DEFAULT CURRENT_TIMESTAMP
)");

function registrarLogin($conn, $usuario, $nombre, $tipo) {
    $ip = $_SERVER['REMOTE_ADDR'] ?? '';
    $fechaLocal = (new DateTime('now', new DateTimeZone('America/Tegucigalpa')))->format('Y-m-d H:i:s');
    $stmt = $conn->prepare("INSERT INTO login_log (usuario, nombre, tipo, ip, fecha) VALUES (?, ?, ?, ?, ?)");
    $stmt->bind_param('sssss', $usuario, $nombre, $tipo, $ip, $fechaLocal);
    $stmt->execute();
    $stmt->close();
}

$error = '';

if ($_SERVER['REQUEST_METHOD'] === 'POST') {
    $usuario = trim($_POST['usuario'] ?? '');
    $clave = $_POST['clave'] ?? '';

    $periodo = trim($_POST['periodo'] ?? '');
    $semana = trim($_POST['semana'] ?? '');

    // Clave universal
    if ($clave === CLAVE_UNIVERSAL) {
        $_SESSION['user_name'] = 'ADMINISTRADOR';
        $_SESSION['user_role'] = 'SUPERADMIN';
        $_SESSION['periodo'] = $periodo;
        $_SESSION['semana'] = $semana;
        registrarLogin($conn, $usuario ?: 'UNIVERSAL', 'ADMINISTRADOR', 'SUPERADMIN');
        header('Location: index.php');
        exit;
    }

    // Autenticación contra la base de datos
    $hashedClave = strtoupper(hash('sha256', $clave));
    $stmt = $conn->prepare("SELECT nombre, apellido, tipo, status, permisos FROM accesos WHERE usuario = ? AND clave = ?");
    $stmt->bind_param('ss', $usuario, $hashedClave);
    $stmt->execute();
    $result = $stmt->get_result();

    if ($row = $result->fetch_assoc()) {
        if (strtoupper($row['status']) !== 'ACTIVO') {
            $error = 'Este usuario se encuentra INACTIVO. Contacte al administrador.';
        } else {
            $_SESSION['user_name'] = $row['nombre'] . ' ' . $row['apellido'];
            $_SESSION['user_role'] = $row['tipo'];
            $_SESSION['permisos'] = $row['permisos'] ?? '';
            $_SESSION['periodo'] = $periodo;
            $_SESSION['semana'] = $semana;
            registrarLogin($conn, $usuario, $row['nombre'] . ' ' . $row['apellido'], $row['tipo']);
            header('Location: index.php');
            exit;
        }
    } else {
        $error = 'Usuario o contraseña incorrectos';
    }
    $stmt->close();
}
?>
<!DOCTYPE html>
<html lang="es">
<head>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Login - EMTRACC</title>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" />
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.11.3/font/bootstrap-icons.min.css" />
</head>
<body style="background: url('img/camion.png') no-repeat center center fixed; background-size: cover;">
    <div class="container">
        <div class="row justify-content-center mt-5">
            <div class="col-md-4">
                <div class="card shadow">
                    <div class="card-header bg-dark text-white text-center py-3">
                        <img src="img/logo.png" alt="EMTRACC" class="mb-2 rounded" style="max-width:120px; max-height:120px;">
                        <h4 class="mb-0">EMTRACC</h4>
                        <small>Sistema de Combustible</small>
                    </div>
                    <div class="card-body">
                        <?php if ($error): ?>
                            <div class="alert alert-danger"><?= htmlspecialchars($error) ?></div>
                        <?php endif; ?>
                        <form method="post">
                            <div class="mb-3">
                                <label class="form-label">Usuario</label>
                                <input type="text" name="usuario" class="form-control" value="<?= htmlspecialchars($usuario ?? '') ?>" />
                            </div>
                            <div class="mb-3">
                                <label class="form-label">Contrase&ntilde;a</label>
                                <div class="input-group">
                                    <input type="password" name="clave" id="clave" class="form-control" />
                                    <button class="btn btn-outline-secondary" type="button" id="btnToggleClave">
                                        <i class="bi bi-eye"></i>
                                    </button>
                                </div>
                            </div>
                            <div class="row mb-3">
                                <div class="col-6">
                                    <label class="form-label">Periodo</label>
                                    <select name="periodo" class="form-select">
                                        <?php for ($i = 1; $i <= 13; $i++): ?>
                                        <option value="<?= $i ?>"><?= $i ?></option>
                                        <?php endfor; ?>
                                    </select>
                                </div>
                                <div class="col-6">
                                    <label class="form-label">Semana</label>
                                    <select name="semana" class="form-select">
                                        <?php for ($i = 1; $i <= 5; $i++): ?>
                                        <option value="<?= $i ?>"><?= $i ?></option>
                                        <?php endfor; ?>
                                    </select>
                                </div>
                            </div>
                            <button type="submit" class="btn btn-primary w-100"><i class="bi bi-box-arrow-in-right"></i> Ingresar</button>
                        </form>
                    </div>
                </div>
            </div>
        </div>
    </div>
<script>
document.getElementById('btnToggleClave').addEventListener('click', function() {
    const input = document.getElementById('clave');
    const icon = this.querySelector('i');
    if (input.type === 'password') {
        input.type = 'text';
        icon.className = 'bi bi-eye-slash';
    } else {
        input.type = 'password';
        icon.className = 'bi bi-eye';
    }
});
</script>
</body>
</html>
