Imports System.Data
Imports MySql.Data.MySqlClient

Public Class cierreTurno

    Private Sub cierreTurno_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.BackColor = Color.FromArgb(24, 32, 50)
        CargarResumen()
    End Sub

    Private Sub CargarResumen()
        lblDespachador.Text = ModuloConexion.DespachadorSesion
        lblTurno.Text = ModuloConexion.TurnoSesion
        lblFecha.Text = DateTime.Now.ToString("dd/MM/yyyy")
        lblPeriodo.Text = "P" & ModuloConexion.PeriodoSesion & " - S" & ModuloConexion.SemanaSesion
        lblOdometroInicio.Text = "Odometro Inicio: " & ModuloConexion.OdometroInicioTurno.ToString("N2") & " gal"

        Try
            Using con As MySqlConnection = ModuloConexion.ObtenerConexion()
                con.Open()

                ' Resumen de comprobantes del turno actual
                Dim sql As String = "SELECT COUNT(*) AS total, COALESCE(SUM(galDesp), 0) AS galones, COALESCE(SUM(total), 0) AS monto " &
                    "FROM comprobante WHERE turno = @turno AND nombDesp = @desp AND DATE(fecha) = CURDATE() AND (anulado = 0 OR anulado IS NULL)"
                Using cmd As New MySqlCommand(sql, con)
                    cmd.Parameters.AddWithValue("@turno", ModuloConexion.TurnoSesion)
                    cmd.Parameters.AddWithValue("@desp", ModuloConexion.DespachadorSesion)
                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        If reader.Read() Then
                            lblComprobantes.Text = reader("total").ToString()
                            lblGalones.Text = Convert.ToDouble(reader("galones")).ToString("N2")
                            lblMonto.Text = "L. " & Convert.ToDouble(reader("monto")).ToString("N2")
                        End If
                    End Using
                End Using

                ' Cargar detalle en DataGridView
                Dim sqlDetalle As String = "SELECT nCompro AS Comprobante, nBoleta AS Boleta, placaCbz AS Placa, " &
                    "galDesp AS Galones, total AS Total, DATE_FORMAT(fecha, '%H:%i') AS Hora " &
                    "FROM comprobante WHERE turno = @turno AND nombDesp = @desp AND DATE(fecha) = CURDATE() AND (anulado = 0 OR anulado IS NULL) " &
                    "ORDER BY fecha ASC"
                Using cmd As New MySqlCommand(sqlDetalle, con)
                    cmd.Parameters.AddWithValue("@turno", ModuloConexion.TurnoSesion)
                    cmd.Parameters.AddWithValue("@desp", ModuloConexion.DespachadorSesion)
                    Dim dt As New DataTable()
                    Dim adapter As New MySqlDataAdapter(cmd)
                    adapter.Fill(dt)
                    dgvDetalle.DataSource = dt
                End Using

                EstilizarDataGridView(dgvDetalle)

                ' Cargar nivel de tanque actual (ultima medicion)
                Dim sqlTanque As String = "SELECT galonesCalc, galRecibidos, capacidadTanque FROM tanquemed " &
                    "WHERE periodo = @periodo AND semana = @semana ORDER BY idMedida DESC LIMIT 1"
                Using cmd As New MySqlCommand(sqlTanque, con)
                    cmd.Parameters.AddWithValue("@periodo", ModuloConexion.PeriodoSesion)
                    cmd.Parameters.AddWithValue("@semana", ModuloConexion.SemanaSesion)
                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        If reader.Read() Then
                            Dim galInicio As Double = If(reader("galonesCalc") IsNot DBNull.Value, Convert.ToDouble(reader("galonesCalc")), 0)
                            Dim galRecibidos As Double = If(reader("galRecibidos") IsNot DBNull.Value, Convert.ToDouble(reader("galRecibidos")), 0)
                            Dim capacidad As Double = If(reader("capacidadTanque") IsNot DBNull.Value, Convert.ToDouble(reader("capacidadTanque")), 0)
                            lblTanqueInfo.Text = String.Format("Inicio: {0:N2} | Recibidos: {1:N2} | Capacidad: {2:N2}", galInicio, galRecibidos, capacidad)
                        Else
                            lblTanqueInfo.Text = "Sin medicion registrada para este periodo/semana"
                        End If
                    End Using
                End Using

            End Using
        Catch ex As Exception
            MessageBox.Show("Error al cargar resumen: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnCerrarTurno_Click(sender As Object, e As EventArgs) Handles btnCerrarTurno.Click
        Dim medicion As Double = 0
        If Not Double.TryParse(txtMedicionTanque.Text, medicion) Then
            MessageBox.Show("Ingrese una medicion de tanque valida.", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtMedicionTanque.Focus()
            Return
        End If

        Dim odometroCierre As Double = 0
        If Not Double.TryParse(txtOdometroCierre.Text, odometroCierre) OrElse odometroCierre <= 0 Then
            MessageBox.Show("Ingrese la lectura del odometro de cierre.", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtOdometroCierre.Focus()
            Return
        End If

        ' Confirmar odometro de cierre
        Dim respOdo As DialogResult = MessageBox.Show(
            "El odometro de cierre es " & odometroCierre.ToString("N2") & " galones." & vbCrLf &
            "Es correcto?",
            "Confirmar Odometro de Cierre", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If respOdo = DialogResult.No Then
            txtOdometroCierre.Focus()
            txtOdometroCierre.SelectAll()
            Return
        End If

        Dim opc As DialogResult = MessageBox.Show(
            "Desea cerrar el turno?" & vbCrLf & vbCrLf &
            "Despachador: " & ModuloConexion.DespachadorSesion & vbCrLf &
            "Turno: " & ModuloConexion.TurnoSesion & vbCrLf &
            "Comprobantes: " & lblComprobantes.Text & vbCrLf &
            "Galones despachados: " & lblGalones.Text & vbCrLf &
            "Odometro Inicio: " & ModuloConexion.OdometroInicioTurno.ToString("N2") & vbCrLf &
            "Odometro Cierre: " & odometroCierre.ToString("N2") & vbCrLf &
            "Medicion tanque: " & medicion.ToString("N2"),
            "Confirmar Cierre de Turno", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If opc = DialogResult.No Then Return

        Try
            Using con As MySqlConnection = ModuloConexion.ObtenerConexion()
                con.Open()

                Dim totalComp As Integer = 0 : Integer.TryParse(lblComprobantes.Text, totalComp)
                Dim totalGal As Double = 0 : Double.TryParse(lblGalones.Text, totalGal)
                Dim totalMonto As Double = 0 : Double.TryParse(lblMonto.Text.Replace("L. ", "").Replace(",", ""), totalMonto)

                Dim sql As String = "INSERT INTO cierre_turno (idTurno, despachador, fecha, periodo, semana, turnoNombre, " &
                    "totalComprobantes, totalGalones, totalMonto, odometroInicio, odometroCierre, medicionTanque, observaciones) " &
                    "VALUES(@idTurno, @desp, CURDATE(), @periodo, @semana, @turnoNombre, " &
                    "@totalComp, @totalGal, @totalMonto, @odoInicio, @odoCierre, @medicion, @obs)"

                Using cmd As New MySqlCommand(sql, con)
                    cmd.Parameters.AddWithValue("@idTurno", ModuloConexion.IdTurnoSesion)
                    cmd.Parameters.AddWithValue("@desp", ModuloConexion.DespachadorSesion)
                    cmd.Parameters.AddWithValue("@periodo", ModuloConexion.PeriodoSesion)
                    cmd.Parameters.AddWithValue("@semana", ModuloConexion.SemanaSesion)
                    cmd.Parameters.AddWithValue("@turnoNombre", ModuloConexion.TurnoSesion)
                    cmd.Parameters.AddWithValue("@totalComp", totalComp)
                    cmd.Parameters.AddWithValue("@totalGal", totalGal)
                    cmd.Parameters.AddWithValue("@totalMonto", totalMonto)
                    cmd.Parameters.AddWithValue("@odoInicio", ModuloConexion.OdometroInicioTurno)
                    cmd.Parameters.AddWithValue("@odoCierre", odometroCierre)
                    cmd.Parameters.AddWithValue("@medicion", medicion)
                    cmd.Parameters.AddWithValue("@obs", txtObservaciones.Text)
                    cmd.ExecuteNonQuery()
                End Using

                ' Marcar apertura de turno como cerrada
                Using cmdCerrar As New MySqlCommand("UPDATE apertura_turno SET cerrado = 1 WHERE despachador = @desp AND cerrado = 0", con)
                    cmdCerrar.Parameters.AddWithValue("@desp", ModuloConexion.DespachadorSesion)
                    cmdCerrar.ExecuteNonQuery()
                End Using
            End Using

            MessageBox.Show("Turno cerrado correctamente.", "Cierre Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Close()

        Catch ex As Exception
            MessageBox.Show("Error al cerrar turno: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnRefrescar_Click(sender As Object, e As EventArgs) Handles btnRefrescar.Click
        CargarResumen()
    End Sub
End Class
