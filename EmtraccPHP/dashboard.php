<?php
require_once 'includes/auth.php';
requireLogin();
requirePermiso('reporte');
require_once 'includes/config.php';

$pageTitle = 'Dashboard';

// Listas para filtros
$periodos = [];
$res = $conn->query("SELECT DISTINCT periodo FROM comprobante WHERE periodo IS NOT NULL ORDER BY periodo");
while ($r = $res->fetch_assoc()) $periodos[] = $r['periodo'];

$semanas = [];
$res = $conn->query("SELECT DISTINCT semana FROM comprobante WHERE semana IS NOT NULL ORDER BY semana");
while ($r = $res->fetch_assoc()) $semanas[] = $r['semana'];

include 'includes/header.php';
?>

<h4>Dashboard - EMTRACC</h4>

<!-- Filtros -->
<div class="row g-2 mb-3 align-items-end">
    <div class="col-auto">
        <label class="form-label mb-0">Período</label>
        <select id="filtroPeriodo" class="form-select form-select-sm">
            <option value="">-- Todos --</option>
            <?php foreach ($periodos as $p): ?>
                <option value="<?= htmlspecialchars($p) ?>"><?= htmlspecialchars($p) ?></option>
            <?php endforeach; ?>
        </select>
    </div>
    <div class="col-auto">
        <label class="form-label mb-0">Semana</label>
        <select id="filtroSemana" class="form-select form-select-sm">
            <option value="">-- Todas --</option>
            <?php foreach ($semanas as $s): ?>
                <option value="<?= htmlspecialchars($s) ?>"><?= htmlspecialchars($s) ?></option>
            <?php endforeach; ?>
        </select>
    </div>
    <div class="col-auto">
        <button onclick="cargarDashboard()" class="btn btn-primary btn-sm"><i class="bi bi-arrow-clockwise"></i> Actualizar</button>
    </div>
</div>

<div class="row">
    <!-- Galones por Despachador -->
    <div class="col-md-6 mb-4">
        <div class="card">
            <div class="card-header bg-dark text-white">Galones por Despachador</div>
            <div class="card-body">
                <canvas id="chartDespachador"></canvas>
            </div>
        </div>
    </div>

    <!-- Total L por Despachador -->
    <div class="col-md-6 mb-4">
        <div class="card">
            <div class="card-header bg-dark text-white">Total L por Despachador</div>
            <div class="card-body">
                <canvas id="chartDespachadorTotal"></canvas>
            </div>
        </div>
    </div>

    <!-- Galones por Fecha -->
    <div class="col-md-8 mb-4">
        <div class="card">
            <div class="card-header bg-dark text-white">Galones por Fecha</div>
            <div class="card-body">
                <canvas id="chartFecha"></canvas>
            </div>
        </div>
    </div>

    <!-- Galones por Ruta (Top 10) -->
    <div class="col-md-4 mb-4">
        <div class="card">
            <div class="card-header bg-dark text-white">Top 10 Rutas por Galones</div>
            <div class="card-body">
                <canvas id="chartRuta"></canvas>
            </div>
        </div>
    </div>

    <!-- Top 10 Propietarios por Galones -->
    <div class="col-md-6 mb-4">
        <div class="card">
            <div class="card-header bg-dark text-white"><i class="bi bi-people"></i> Top 10 Propietarios por Galones</div>
            <div class="card-body">
                <canvas id="chartPropietario"></canvas>
            </div>
        </div>
    </div>

    <!-- Top 10 Propietarios por Total L -->
    <div class="col-md-6 mb-4">
        <div class="card">
            <div class="card-header bg-dark text-white"><i class="bi bi-people"></i> Top 10 Propietarios por Total L</div>
            <div class="card-body">
                <canvas id="chartPropietarioTotal"></canvas>
            </div>
        </div>
    </div>
</div>

<script src="https://cdn.jsdelivr.net/npm/chart.js"></script>
<script>
    let chartDesp, chartDespTotal, chartFecha, chartRuta, chartProp, chartPropTotal;
    const colores = ['#4e79a7','#f28e2b','#e15759','#76b7b2','#59a14f','#edc948','#b07aa1','#ff9da7','#9c755f','#bab0ac'];

    function cargarDashboard() {
        const periodo = document.getElementById('filtroPeriodo').value;
        const semana = document.getElementById('filtroSemana').value;

        fetch(`dashboard_data.php?periodo=${encodeURIComponent(periodo)}&semana=${encodeURIComponent(semana)}`)
            .then(r => r.json())
            .then(data => {
                // Galones por Despachador
                if (chartDesp) chartDesp.destroy();
                chartDesp = new Chart(document.getElementById('chartDespachador'), {
                    type: 'bar',
                    data: {
                        labels: data.porDespachador.map(d => d.nombre),
                        datasets: [{
                            label: 'Galones',
                            data: data.porDespachador.map(d => d.galones),
                            backgroundColor: colores
                        }]
                    },
                    options: { responsive: true, plugins: { legend: { display: false } }, indexAxis: 'y' }
                });

                // Total L por Despachador
                if (chartDespTotal) chartDespTotal.destroy();
                chartDespTotal = new Chart(document.getElementById('chartDespachadorTotal'), {
                    type: 'bar',
                    data: {
                        labels: data.porDespachador.map(d => d.nombre),
                        datasets: [{
                            label: 'Total L',
                            data: data.porDespachador.map(d => d.total),
                            backgroundColor: colores
                        }]
                    },
                    options: { responsive: true, plugins: { legend: { display: false } }, indexAxis: 'y' }
                });

                // Galones por Fecha
                if (chartFecha) chartFecha.destroy();
                chartFecha = new Chart(document.getElementById('chartFecha'), {
                    type: 'line',
                    data: {
                        labels: data.porFecha.map(d => d.fecha),
                        datasets: [{
                            label: 'Galones',
                            data: data.porFecha.map(d => d.galones),
                            borderColor: '#4e79a7',
                            backgroundColor: 'rgba(78,121,167,0.1)',
                            fill: true,
                            tension: 0.3
                        }]
                    },
                    options: { responsive: true }
                });

                // Top Rutas
                if (chartRuta) chartRuta.destroy();
                chartRuta = new Chart(document.getElementById('chartRuta'), {
                    type: 'doughnut',
                    data: {
                        labels: data.porRuta.map(d => d.ruta),
                        datasets: [{
                            data: data.porRuta.map(d => d.galones),
                            backgroundColor: colores
                        }]
                    },
                    options: { responsive: true }
                });

                // Top Propietarios por Galones
                if (chartProp) chartProp.destroy();
                chartProp = new Chart(document.getElementById('chartPropietario'), {
                    type: 'bar',
                    data: {
                        labels: data.porPropietario.map(d => d.propietario),
                        datasets: [{
                            label: 'Galones',
                            data: data.porPropietario.map(d => d.galones),
                            backgroundColor: colores
                        }]
                    },
                    options: { responsive: true, plugins: { legend: { display: false } }, indexAxis: 'y' }
                });

                // Top Propietarios por Total L
                if (chartPropTotal) chartPropTotal.destroy();
                chartPropTotal = new Chart(document.getElementById('chartPropietarioTotal'), {
                    type: 'bar',
                    data: {
                        labels: data.porPropietario.map(d => d.propietario),
                        datasets: [{
                            label: 'Total L',
                            data: data.porPropietario.map(d => d.total),
                            backgroundColor: colores
                        }]
                    },
                    options: { responsive: true, plugins: { legend: { display: false } }, indexAxis: 'y' }
                });
            });
    }

    cargarDashboard();
</script>

<?php include 'includes/footer.php'; ?>
