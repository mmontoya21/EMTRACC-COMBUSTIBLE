let resumenData = {};

document.addEventListener('DOMContentLoaded', () => {
    document.getElementById('btnRefrescar').addEventListener('click', cargarResumen);
    document.getElementById('btnCerrar').addEventListener('click', cerrarTurno);
    cargarResumen();
});

function cargarResumen() {
    fetch('api/cierreTurno_api.php?action=resumen')
        .then(r => r.json())
        .then(data => {
            if (data.error) { alert(data.error); return; }
            resumenData = data;

            document.getElementById('infoTurno').textContent = data.turno || '-';
            document.getElementById('infoDesp').textContent = data.despachador || '-';
            document.getElementById('infoPeriodo').textContent = 'P' + (data.periodo || '-') + ' S' + (data.semana || '-');

            document.getElementById('infoOdoInicio').textContent = parseFloat(data.odometroInicio || 0).toFixed(2);
            document.getElementById('resComprobantes').textContent = data.totalComprobantes;
            document.getElementById('resGalones').textContent = parseFloat(data.totalGalones).toFixed(2);
            document.getElementById('resMonto').textContent = 'L. ' + parseFloat(data.totalMonto).toFixed(2);

            // Detalle
            const tbody = document.getElementById('tbodyDetalle');
            if (!data.detalle || data.detalle.length === 0) {
                tbody.innerHTML = '<tr><td colspan="6" class="text-center text-muted">Sin comprobantes en este turno</td></tr>';
            } else {
                tbody.innerHTML = data.detalle.map(r =>
                    `<tr>
                        <td>${r.nCompro || ''}</td>
                        <td>${r.nBoleta || ''}</td>
                        <td>${r.placaCbz || ''}</td>
                        <td class="text-end">${parseFloat(r.galDesp || 0).toFixed(2)}</td>
                        <td class="text-end">${parseFloat(r.total || 0).toFixed(2)}</td>
                        <td>${r.hora || ''}</td>
                    </tr>`
                ).join('');
            }

            // Info tanque
            if (data.tanque) {
                const t = data.tanque;
                document.getElementById('infoTanque').textContent =
                    `Tanque - Inicio: ${parseFloat(t.galonesCalc || 0).toFixed(2)} | Recibidos: ${parseFloat(t.galRecibidos || 0).toFixed(2)} | Capacidad: ${parseFloat(t.capacidadTanque || 0).toFixed(2)}`;
            } else {
                document.getElementById('infoTanque').textContent = 'Sin medicion de tanque para este periodo/semana';
            }
        })
        .catch(err => alert('Error al cargar resumen: ' + err));
}

function cerrarTurno() {
    const medicion = parseFloat(document.getElementById('txtMedicion').value);
    if (isNaN(medicion) || medicion <= 0) {
        alert('Ingrese una medicion de tanque valida.');
        document.getElementById('txtMedicion').focus();
        return;
    }

    const odoCierre = parseFloat(document.getElementById('txtOdoCierre').value);
    if (isNaN(odoCierre) || odoCierre <= 0) {
        alert('Ingrese la lectura del odometro de cierre.');
        document.getElementById('txtOdoCierre').focus();
        return;
    }

    const obs = document.getElementById('txtObservaciones').value.trim();
    const odoInicio = parseFloat(resumenData.odometroInicio || 0);

    if (!confirm(`Confirmar cierre de turno?\n\nTurno: ${resumenData.turno}\nComprobantes: ${resumenData.totalComprobantes}\nGalones despachados: ${parseFloat(resumenData.totalGalones).toFixed(2)}\nOdometro Inicio: ${odoInicio.toFixed(2)}\nOdometro Cierre: ${odoCierre.toFixed(2)}\nMedicion tanque: ${medicion.toFixed(2)}`)) {
        return;
    }

    fetch('api/cierreTurno_api.php?action=cerrar', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({
            medicionTanque: medicion,
            odometroCierre: odoCierre,
            observaciones: obs,
            totalComprobantes: resumenData.totalComprobantes,
            totalGalones: resumenData.totalGalones,
            totalMonto: resumenData.totalMonto
        })
    })
    .then(r => r.json())
    .then(data => {
        if (data.error) { alert(data.error); return; }
        alert(data.mensaje || 'Turno cerrado correctamente');
        window.location.href = 'index.php';
    })
    .catch(err => alert('Error: ' + err));
}
