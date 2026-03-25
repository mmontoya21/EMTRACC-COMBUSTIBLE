<?php
session_start();

function requireLogin() {
    if (!isset($_SESSION['user_name'])) {
        header('Location: login.php');
        exit;
    }
}

function isLoggedIn() {
    return isset($_SESSION['user_name']);
}

function getUserName() {
    return $_SESSION['user_name'] ?? '';
}

function getUserRole() {
    return $_SESSION['user_role'] ?? '';
}

function getPeriodo() {
    return $_SESSION['periodo'] ?? '';
}

function getSemana() {
    return $_SESSION['semana'] ?? '';
}

function getPermisos() {
    return $_SESSION['permisos'] ?? '';
}

function getTurno() {
    return $_SESSION['turno'] ?? '';
}

function getIdTurno() {
    return $_SESSION['idTurno'] ?? 0;
}

function getOdometroInicio() {
    return $_SESSION['odometroInicio'] ?? 0;
}

function hasPermiso($modulo) {
    $role = getUserRole();
    if ($role === 'SUPERADMIN') return true;
    $permisos = getPermisos();
    if ($permisos === '') return true;
    $lista = array_map('trim', explode(',', $permisos));
    return in_array($modulo, $lista);
}

function requirePermiso($modulo) {
    if (!hasPermiso($modulo)) {
        header('Location: index.php');
        exit;
    }
}

function isReadOnly() {
    return getUserRole() === 'TEST';
}

function requireNotReadOnly() {
    if (isReadOnly()) {
        header('Location: index.php');
        exit;
    }
}

function requireNotReadOnlyApi() {
    if (isReadOnly()) {
        http_response_code(403);
        echo json_encode(['error' => 'Usuario TEST: solo lectura, no puede realizar esta accion'], JSON_UNESCAPED_UNICODE);
        exit;
    }
}

function requirePermisoApi($modulo) {
    if (!hasPermiso($modulo)) {
        http_response_code(403);
        echo json_encode(['error' => 'No tiene permisos para este modulo'], JSON_UNESCAPED_UNICODE);
        exit;
    }
}
