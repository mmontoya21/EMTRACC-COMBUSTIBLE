// ============ STATE ============
let rawData = [];

// Paleta de colores por grupo (ciclo de 3)
const coloresSuaves = ['#FFF3E0', '#E3F2FD', '#E8F5E9'];
const coloresIntensos = ['#FFE0B2', '#BBDEFB', '#C8E6C9'];
const coloresTextoSub = ['#503C00', '#002850', '#003C14'];

// ============ INIT ============
document.addEventListener('DOMContentLoaded', () => {
    document.getElementById('btnBuscar').addEventListener('click', cargarDatos);
    document.getElementById('btnOrdenar').addEventListener('click', agruparPorCliente);
    document.getElementById('btnLimpiar').addEventListener('click', limpiarFiltros);
    document.getElementById('btnExportarCSV').addEventListener('click', exportarCSV);
    document.getElementById('btnExportarExcel').addEventListener('click', exportarExcel);
    document.getElementById('chkUsarFecha').addEventListener('change', toggleFecha);

    // Cargar datos al inicio
    cargarDatos();
});

function toggleFecha() {
    const checked = document.getElementById('chkUsarFecha').checked;
    document.getElementById('fechaDesde').disabled = !checked;
    document.getElementById('fechaHasta').disabled = !checked;
}

// ============ LOAD DATA ============
function cargarDatos() {
    const params = new URLSearchParams({ action: 'data' });

    if (document.getElementById('chkUsarFecha').checked) {
        const desde = document.getElementById('fechaDesde').value;
        const hasta = document.getElementById('fechaHasta').value;
        if (desde) params.append('fechaDesde', desde);
        if (hasta) params.append('fechaHasta', hasta);
    }

    const codCliente = document.getElementById('filtroCodCliente').value.trim();
    const placa = document.getElementById('filtroPlaca').value.trim();
    const boleta = document.getElementById('filtroBoleta').value.trim();
    if (codCliente) params.append('codCliente', codCliente);
    if (placa) params.append('placa', placa);
    if (boleta) params.append('boleta', boleta);

    fetch('api/reporteFact_api.php?' + params.toString())
        .then(r => r.json())
        .then(data => {
            if (data.error) { alert(data.error); return; }
            rawData = data.rows;
            renderAgrupado(rawData);
        })
        .catch(err => alert('Error al cargar: ' + err));
}

// ============ RENDER WITH SUBTOTALS ============
function renderAgrupado(rows) {
    const tbody = document.getElementById('tbodyReporte');

    if (!rows.length) {
        tbody.innerHTML = '<tr><td colspan="11" class="text-center text-muted">Sin registros</td></tr>';
updateResumen(0, 0, 0);
        return;
    }

    // Agrupar por codiProp
    const grupos = {};
    const ordenGrupos = [];
    rows.forEach(r => {
        const cliente = (r.codiProp || '').trim();
        if (!grupos[cliente]) {
            grupos[cliente] = [];
            ordenGrupos.push(cliente);
        }
        grupos[cliente].push(r);
    });

    let html = '';
    let granTotalGalones = 0;
    let granTotalMonto = 0;
    let totalRegistros = 0;
    let grupoIndex = 0;

    ordenGrupos.forEach(cliente => {
        const filas = grupos[cliente];
        const colorIdx = grupoIndex % 3;
        let subGalones = 0;
        let subTotal = 0;

        filas.forEach(r => {
            const gal = parseFloat(r.galDesp) || 0;
            const tot = parseFloat(r.total) || 0;
            subGalones += gal;
            subTotal += tot;
            totalRegistros++;

            html += `<tr style="background-color:${coloresSuaves[colorIdx]}">
                <td class="text-center">${r.nCompro || ''}</td>
                <td class="text-center">${r.nBoleta || ''}</td>
                <td class="text-center">${r.fechaFmt || ''}</td>
                <td>${r.placaCbz || ''}</td>
                <td>${r.nConte || ''}</td>
                <td class="text-end">${fmtNum(gal)}</td>
                <td class="text-end">${fmtNum(tot)}</td>
                <td>${r.codiProp || ''}</td>
                <td class="text-center">${r.periodo || ''}</td>
                <td class="text-center">${r.semana || ''}</td>
                <td class="text-end">${fmtNum(parseFloat(r.valor) || 0)}</td>
            </tr>`;
        });

        // Subtotal row
        html += `<tr style="background-color:${coloresIntensos[colorIdx]};color:${coloresTextoSub[colorIdx]};font-weight:bold">
            <td colspan="5" class="text-end">SUBTOTAL: ${cliente || '(sin codigo)'}</td>
            <td class="text-end">${fmtNum(subGalones)}</td>
            <td class="text-end">${fmtNum(subTotal)}</td>
            <td colspan="4"></td>
        </tr>`;

        granTotalGalones += subGalones;
        granTotalMonto += subTotal;
        grupoIndex++;
    });

    // Gran Total row
    html += `<tr style="background-color:#FFB74D;font-weight:bold;font-size:1.05em">
        <td colspan="5" class="text-end">GRAN TOTAL</td>
        <td class="text-end">${fmtNum(granTotalGalones)}</td>
        <td class="text-end">${fmtNum(granTotalMonto)}</td>
        <td colspan="4"></td>
    </tr>`;

    tbody.innerHTML = html;
    updateResumen(totalRegistros, granTotalGalones, granTotalMonto);
}

function updateResumen(total, galones, monto) {
    document.getElementById('resumenTotal').textContent = total;
    document.getElementById('resumenGalones').textContent = fmtNum(galones);
    document.getElementById('resumenMonto').textContent = fmtNum(monto);
}

// ============ ACTIONS ============
function agruparPorCliente() {
    // Re-sort by codiProp and re-render
    const sorted = [...rawData].sort((a, b) => {
        const ca = (a.codiProp || '').trim();
        const cb = (b.codiProp || '').trim();
        return ca.localeCompare(cb);
    });
    renderAgrupado(sorted);
}

function limpiarFiltros() {
    document.getElementById('chkUsarFecha').checked = false;
    document.getElementById('fechaDesde').value = '';
    document.getElementById('fechaHasta').value = '';
    document.getElementById('fechaDesde').disabled = true;
    document.getElementById('fechaHasta').disabled = true;
    document.getElementById('filtroCodCliente').value = '';
    document.getElementById('filtroPlaca').value = '';
    document.getElementById('filtroBoleta').value = '';
    cargarDatos();
}

// ============ EXPORT CSV ============
function exportarCSV() {
    if (!rawData.length) { alert('No hay datos para exportar.'); return; }

    const headers = ['Comprobante', 'Boleta', 'Fecha', 'Placa', 'Contenedor', 'Galones', 'Total', 'Cod. Cliente', 'Periodo', 'Semana', 'Valor'];
    const keys = ['nCompro', 'nBoleta', 'fechaFmt', 'placaCbz', 'nConte', 'galDesp', 'total', 'codiProp', 'periodo', 'semana', 'valor'];

    let csv = '\uFEFF'; // BOM for Excel
    csv += headers.map(h => '"' + h + '"').join(',') + '\n';

    rawData.forEach(r => {
        csv += keys.map(k => {
            let v = (r[k] ?? '').toString().replace(/"/g, '""');
            return '"' + v + '"';
        }).join(',') + '\n';
    });

    const blob = new Blob([csv], { type: 'text/csv;charset=utf-8;' });
    const link = document.createElement('a');
    link.href = URL.createObjectURL(blob);
    link.download = 'Reporte_Facturas_' + new Date().toISOString().slice(0, 10) + '.csv';
    link.click();
    URL.revokeObjectURL(link.href);
}

// ============ EXPORT EXCEL (HTML table approach) ============
function exportarExcel() {
    if (!rawData.length) { alert('No hay datos para exportar.'); return; }

    // Build filtered info
    let filtrosTexto = '';
    if (document.getElementById('chkUsarFecha').checked) {
        filtrosTexto += 'Fecha: ' + (document.getElementById('fechaDesde').value || '...') + ' - ' + (document.getElementById('fechaHasta').value || '...') + ' | ';
    }
    const codCliente = document.getElementById('filtroCodCliente').value.trim();
    const placa = document.getElementById('filtroPlaca').value.trim();
    const boleta = document.getElementById('filtroBoleta').value.trim();
    if (codCliente) filtrosTexto += 'Cod. Cliente: ' + codCliente + ' | ';
    if (placa) filtrosTexto += 'Placa: ' + placa + ' | ';
    if (boleta) filtrosTexto += 'Boleta: ' + boleta + ' | ';
    filtrosTexto = filtrosTexto ? filtrosTexto.replace(/ \| $/, '') : 'Sin filtros aplicados';

    const now = new Date();
    const fechaGen = now.toLocaleDateString('es-HN') + ' ' + now.toLocaleTimeString('es-HN');

    // Group data
    const grupos = {};
    const ordenGrupos = [];
    rawData.forEach(r => {
        const cliente = (r.codiProp || '').trim();
        if (!grupos[cliente]) { grupos[cliente] = []; ordenGrupos.push(cliente); }
        grupos[cliente].push(r);
    });

    let html = `<html xmlns:o="urn:schemas-microsoft-com:office:office" xmlns:x="urn:schemas-microsoft-com:office:excel">
<head><meta charset="utf-8">
<style>
td,th{font-family:Calibri;font-size:11pt;border:1px solid #ccc;padding:3px 6px}
th{background:#4A5A78;color:white;font-weight:bold;text-align:center}
.num{mso-number-format:"\\#\\,\\#\\#0\\.00";text-align:right}
.center{text-align:center}
.subtotal{font-weight:bold}
.gran-total{background:#FFB74D;font-weight:bold;font-size:12pt}
.titulo{background:#6A7EA8;color:white;font-weight:bold;font-size:16pt;text-align:center}
.info{font-style:italic;color:gray;font-size:10pt}
.resumen-header{background:#6A7EA8;color:white;font-weight:bold;font-size:12pt}
.resumen-label{font-weight:bold}
</style></head><body>
<table>
<tr><td colspan="11" class="titulo">REPORTE DE FACTURAS</td></tr>
<tr><td colspan="11" class="info">${escapeHtml(filtrosTexto)}</td></tr>
<tr><td colspan="11" class="info">Generado: ${fechaGen}</td></tr>
<tr><td colspan="11"></td></tr>
<tr>
<th>Comprobante</th><th>Boleta</th><th>Fecha</th><th>Placa</th><th>Contenedor</th>
<th>Galones</th><th>Total</th><th>Cod. Cliente</th><th>Periodo</th><th>Semana</th><th>Valor</th>
</tr>`;

    let granGal = 0, granTot = 0, totalRegistros = 0;
    let grupoIdx = 0;

    ordenGrupos.forEach(cliente => {
        const filas = grupos[cliente];
        const colorIdx = grupoIdx % 3;
        let subGal = 0, subTot = 0;

        filas.forEach(r => {
            const gal = parseFloat(r.galDesp) || 0;
            const tot = parseFloat(r.total) || 0;
            subGal += gal; subTot += tot; totalRegistros++;

            html += `<tr style="background:${coloresSuaves[colorIdx]}">
                <td class="center">${r.nCompro || ''}</td>
                <td class="center">${r.nBoleta || ''}</td>
                <td class="center">${r.fechaFmt || ''}</td>
                <td>${r.placaCbz || ''}</td>
                <td>${r.nConte || ''}</td>
                <td class="num">${gal.toFixed(2)}</td>
                <td class="num">${tot.toFixed(2)}</td>
                <td class="center">${r.codiProp || ''}</td>
                <td class="center">${r.periodo || ''}</td>
                <td class="center">${r.semana || ''}</td>
                <td class="num">${(parseFloat(r.valor) || 0).toFixed(2)}</td>
            </tr>`;
        });

        html += `<tr class="subtotal" style="background:${coloresIntensos[colorIdx]};color:${coloresTextoSub[colorIdx]}">
            <td colspan="5" style="text-align:right">SUBTOTAL: ${escapeHtml(cliente || '(sin codigo)')}</td>
            <td class="num">${subGal.toFixed(2)}</td>
            <td class="num">${subTot.toFixed(2)}</td>
            <td colspan="4"></td>
        </tr>`;

        granGal += subGal; granTot += subTot;
        grupoIdx++;
    });

    html += `<tr class="gran-total">
        <td colspan="5" style="text-align:right">GRAN TOTAL</td>
        <td class="num">${granGal.toFixed(2)}</td>
        <td class="num">${granTot.toFixed(2)}</td>
        <td colspan="4"></td>
    </tr>`;

    // Resumen
    html += `<tr><td colspan="11"></td></tr>
    <tr><td colspan="4" class="resumen-header">RESUMEN</td><td colspan="7"></td></tr>`;

    if (codCliente) html += `<tr><td class="resumen-label">Cod. Cliente:</td><td>${escapeHtml(codCliente)}</td><td colspan="9"></td></tr>`;
    if (placa) html += `<tr><td class="resumen-label">Placa:</td><td>${escapeHtml(placa)}</td><td colspan="9"></td></tr>`;
    if (boleta) html += `<tr><td class="resumen-label">Boleta:</td><td>${escapeHtml(boleta)}</td><td colspan="9"></td></tr>`;

    html += `<tr><td class="resumen-label">Total Registros:</td><td>${totalRegistros}</td><td colspan="9"></td></tr>
    <tr><td class="resumen-label">Total Galones:</td><td class="num">${granGal.toFixed(2)}</td><td colspan="9"></td></tr>
    <tr><td class="resumen-label">Total Valor:</td><td class="num">${granTot.toFixed(2)}</td><td colspan="9"></td></tr>`;

    // Tank measurement
    html += `<tr><td colspan="11"></td></tr>
    <tr><td colspan="4" class="resumen-header">MEDICION DE TANQUE</td><td colspan="7"></td></tr>`;

    // Fetch tank data and complete export
    fetch('api/reporteFact_api.php?action=tanquemed')
        .then(r => r.json())
        .then(tank => {
            const galIni = tank.galInicio !== null ? tank.galInicio.toFixed(2) : 'Sin medicion';
            const galFin = tank.galFinal !== null ? tank.galFinal.toFixed(2) : 'Sin medicion';

            html += `<tr><td class="resumen-label">Odometro Inicial:</td><td class="num">${galIni}</td><td colspan="9"></td></tr>
            <tr><td class="resumen-label">Odometro Final:</td><td class="num">${galFin}</td><td colspan="9"></td></tr>
            <tr><td class="resumen-label">Total Dispensado:</td><td class="num">${granGal.toFixed(2)}</td><td colspan="9"></td></tr>
            </table></body></html>`;

            downloadExcel(html);
        })
        .catch(() => {
            html += `<tr><td class="resumen-label">Odometro Inicial:</td><td>Sin medicion</td><td colspan="9"></td></tr>
            <tr><td class="resumen-label">Odometro Final:</td><td>Sin medicion</td><td colspan="9"></td></tr>
            <tr><td class="resumen-label">Total Dispensado:</td><td class="num">${granGal.toFixed(2)}</td><td colspan="9"></td></tr>
            </table></body></html>`;

            downloadExcel(html);
        });
}

function downloadExcel(html) {
    const blob = new Blob([html], { type: 'application/vnd.ms-excel;charset=utf-8' });
    const link = document.createElement('a');
    link.href = URL.createObjectURL(blob);
    link.download = 'Reporte_Facturas_' + new Date().toISOString().slice(0, 10) + '.xls';
    link.click();
    URL.revokeObjectURL(link.href);
}

// ============ HELPERS ============
function fmtNum(val) {
    const n = parseFloat(val);
    if (isNaN(n)) return '';
    return n.toLocaleString('es-HN', { minimumFractionDigits: 2, maximumFractionDigits: 2 });
}

function escapeHtml(str) {
    const div = document.createElement('div');
    div.textContent = str;
    return div.innerHTML;
}
