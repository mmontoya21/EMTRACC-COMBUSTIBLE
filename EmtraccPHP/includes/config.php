<?php
// Configuración de base de datos
// Si tu hosting y BD están en el mismo servidor, cambia a 'localhost'
$db_host = '193.203.166.219';
$db_name = 'u282951626_emtraccF';
$db_user = 'u282951626_mmontoya';
$db_pass = 'Paradoja25';

$conn = new mysqli($db_host, $db_user, $db_pass, $db_name);
if ($conn->connect_error) {
    die('Error de conexión: ' . $conn->connect_error);
}
$conn->set_charset('utf8mb4');

// Clave universal (misma que la app de escritorio)
define('CLAVE_UNIVERSAL', '@Paradoja2026');
