Imports MySql.Data.MySqlClient
Imports System.Security.Cryptography
Imports System.Text
Imports System.Data

Public Class login

    Private turnosData As New Dictionary(Of String, Integer()) ' nombre -> {idTurno, horaInicio (minutos), horaFin (minutos)}

    Private Sub login_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ModuloConexion.EnsureTurnoTables()
        CargarTurnos()
        usuarioTbx.Focus()
    End Sub

    Private Sub CargarTurnos()
        Try
            Using con As MySqlConnection = ModuloConexion.ObtenerConexion()
                con.Open()
                Using cmd As New MySqlCommand("SELECT idTurno, nombre, horaInicio, horaFin FROM turnos WHERE activo = 1 ORDER BY horaInicio", con)
                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        turnoCbx.Items.Clear()
                        turnosData.Clear()
                        While reader.Read()
                            Dim nombre As String = reader("nombre").ToString()
                            Dim idTurno As Integer = Convert.ToInt32(reader("idTurno"))
                            Dim hInicio As TimeSpan = CType(reader("horaInicio"), TimeSpan)
                            Dim hFin As TimeSpan = CType(reader("horaFin"), TimeSpan)
                            turnoCbx.Items.Add(nombre)
                            turnosData(nombre) = {idTurno, CInt(hInicio.TotalMinutes), CInt(hFin.TotalMinutes)}
                        End While
                    End Using
                End Using
            End Using
        Catch
            ' Si falla, dejar vacio
        End Try
    End Sub

    Private Function EstaEnHorarioDeTurno(nombreTurno As String) As Boolean
        If Not turnosData.ContainsKey(nombreTurno) Then Return True
        Dim datos() As Integer = turnosData(nombreTurno)
        Dim ahora As Integer = CInt(DateTime.Now.TimeOfDay.TotalMinutes)
        Dim inicio As Integer = datos(1)
        Dim fin As Integer = datos(2)

        ' Turno nocturno (cruza medianoche)
        If inicio > fin Then
            Return ahora >= inicio OrElse ahora < fin
        Else
            Return ahora >= inicio AndAlso ahora < fin
        End If
    End Function

    Private Function ComputeSHA256(input As String) As String
        Using sha256 As SHA256 = SHA256.Create()
            Dim inputBytes As Byte() = Encoding.UTF8.GetBytes(input)
            Dim hashBytes As Byte() = sha256.ComputeHash(inputBytes)
            Dim sb As New StringBuilder()
            For Each b As Byte In hashBytes
                sb.Append(b.ToString("X2"))
            Next
            Return sb.ToString()
        End Using
    End Function

    Private Sub ingresarBtn_Click(sender As Object, e As EventArgs) Handles ingresarBtn.Click
        Autenticar()
    End Sub

    Private Sub claveTbx_KeyDown(sender As Object, e As KeyEventArgs) Handles claveTbx.KeyDown
        If e.KeyCode = Keys.Enter Then
            Autenticar()
            e.SuppressKeyPress = True
        End If
    End Sub

    Private Sub usuarioTbx_KeyDown(sender As Object, e As KeyEventArgs) Handles usuarioTbx.KeyDown
        If e.KeyCode = Keys.Enter Then
            claveTbx.Focus()
            e.SuppressKeyPress = True
        End If
    End Sub

    Private Sub Autenticar()
        If usuarioTbx.Text.Trim() = "" Then
            MessageBox.Show("Ingrese el usuario", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            usuarioTbx.Focus()
            Return
        End If

        If claveTbx.Text.Trim() = "" Then
            MessageBox.Show("Ingrese la contraseña", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            claveTbx.Focus()
            Return
        End If

        If periodoCbx.SelectedIndex < 0 Then
            MessageBox.Show("Seleccione el Período", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            periodoCbx.Focus()
            Return
        End If

        If semanaCbx.SelectedIndex < 0 Then
            MessageBox.Show("Seleccione la Semana", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            semanaCbx.Focus()
            Return
        End If

        ' Guardar período y semana en la sesión
        ModuloConexion.PeriodoSesion = periodoCbx.Text
        ModuloConexion.SemanaSesion = semanaCbx.Text

        ' Clave universal
        If claveTbx.Text = "@Paradoja2026" Then
            ModuloConexion.DespachadorSesion = "ADMINISTRADOR"
            ModuloConexion.TipoUsuarioSesion = "SUPERADMIN"
            Dim frm As New Principal()
            frm.Text = "EMTRACC - Administrador (UNIVERSAL)"
            frm.Tag = "SUPERADMIN"
            frm.PermisosUsuario = ""
            frm.Show()
            Me.Hide()
            Return
        End If

        Dim hashedClave As String = ComputeSHA256(claveTbx.Text)

        Try
            Using conLocal As MySqlConnection = ModuloConexion.ObtenerConexion()
                conLocal.Open()
                Using cmd As New MySqlCommand("SELECT nombre, apellido, tipo, status, permisos FROM accesos WHERE usuario = @usuario AND clave = @clave", conLocal)
                    cmd.Parameters.AddWithValue("@usuario", usuarioTbx.Text.Trim())
                    cmd.Parameters.AddWithValue("@clave", hashedClave)

                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        If reader.Read() Then
                            Dim status As String = reader("status").ToString()
                            If status.ToUpper() <> "ACTIVO" Then
                                MessageBox.Show("Este usuario se encuentra INACTIVO." & vbCrLf & "Contacte al administrador.", "Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                Return
                            End If

                            Dim nombre As String = reader("nombre").ToString()
                            Dim apellido As String = reader("apellido").ToString()
                            Dim tipo As String = reader("tipo").ToString()
                            Dim permisos As String = ""
                            If Not IsDBNull(reader("permisos")) Then
                                permisos = reader("permisos").ToString()
                            End If

                            ' Guardar nombre completo del despachador en la sesión
                            ModuloConexion.DespachadorSesion = (nombre & " " & apellido).ToUpper()
                            ModuloConexion.TipoUsuarioSesion = tipo.ToUpper()

                            ' Validar turno para DESPACHADOR
                            If tipo.ToUpper() = "DESPACHADOR" Then
                                reader.Close()

                                ' Verificar si hay turno abierto sin cerrar
                                Dim turnoAbierto As Boolean = False
                                Dim sqlApertura As String = "SELECT id, turnoNombre, idTurno, odometroInicio, periodo, semana FROM apertura_turno WHERE despachador = @desp AND cerrado = 0 ORDER BY id DESC LIMIT 1"
                                Using cmdAp As New MySqlCommand(sqlApertura, conLocal)
                                    cmdAp.Parameters.AddWithValue("@desp", (nombre & " " & apellido).ToUpper())
                                    Using readerAp As MySqlDataReader = cmdAp.ExecuteReader()
                                        If readerAp.Read() Then
                                            Dim turnoAb As String = readerAp("turnoNombre").ToString()
                                            Dim idTurnoAb As Integer = Convert.ToInt32(readerAp("idTurno"))
                                            Dim odoAb As Double = If(readerAp("odometroInicio") IsNot DBNull.Value, Convert.ToDouble(readerAp("odometroInicio")), 0)

                                            Dim respAb As DialogResult = MessageBox.Show(
                                                "Tiene un turno abierto:" & vbCrLf &
                                                "Turno: " & turnoAb & vbCrLf &
                                                "Odometro Inicio: " & odoAb.ToString("N2") & " gal" & vbCrLf & vbCrLf &
                                                "Desea continuar con ese turno?",
                                                "Turno Abierto Detectado", MessageBoxButtons.YesNo, MessageBoxIcon.Information)

                                            If respAb = DialogResult.Yes Then
                                                ModuloConexion.TurnoSesion = turnoAb
                                                ModuloConexion.IdTurnoSesion = idTurnoAb
                                                ModuloConexion.OdometroInicioTurno = odoAb
                                                turnoAbierto = True
                                            End If
                                        End If
                                    End Using
                                End Using

                                If Not turnoAbierto Then
                                    ' Pedir turno nuevo
                                    If turnoCbx.SelectedIndex < 0 Then
                                        MessageBox.Show("Seleccione su Turno", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                        turnoCbx.Focus()
                                        Return
                                    End If

                                    Dim turnoSeleccionado As String = turnoCbx.Text
                                    ModuloConexion.TurnoSesion = turnoSeleccionado
                                    If turnosData.ContainsKey(turnoSeleccionado) Then
                                        ModuloConexion.IdTurnoSesion = turnosData(turnoSeleccionado)(0)
                                    End If

                                    ' Validar odometro
                                    Dim odometroVal As Double = 0
                                    If Not Double.TryParse(odometroTbx.Text, odometroVal) OrElse odometroVal <= 0 Then
                                        MessageBox.Show("Ingrese la lectura del odometro de inicio (galones en tanque).", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                        odometroTbx.Focus()
                                        Return
                                    End If

                                    ' Confirmar odometro
                                    Dim respOdo As DialogResult = MessageBox.Show(
                                        "El odometro de inicio es " & odometroVal.ToString("N2") & " galones." & vbCrLf &
                                        "Es correcto?",
                                        "Confirmar Odometro de Inicio", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                                    If respOdo = DialogResult.No Then
                                        odometroTbx.Focus()
                                        odometroTbx.SelectAll()
                                        Return
                                    End If

                                    ModuloConexion.OdometroInicioTurno = odometroVal

                                    If Not EstaEnHorarioDeTurno(turnoSeleccionado) Then
                                        Dim resp As DialogResult = MessageBox.Show(
                                            "Esta fuera del horario del turno '" & turnoSeleccionado & "'." & vbCrLf &
                                            "Desea continuar de todas formas?",
                                            "Advertencia de Turno", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                                        If resp = DialogResult.No Then Return
                                    End If

                                    ' Registrar apertura de turno
                                    Using cmdIns As New MySqlCommand("INSERT INTO apertura_turno (despachador, idTurno, turnoNombre, odometroInicio, periodo, semana) VALUES(@desp, @idT, @nombre, @odo, @per, @sem)", conLocal)
                                        cmdIns.Parameters.AddWithValue("@desp", (nombre & " " & apellido).ToUpper())
                                        cmdIns.Parameters.AddWithValue("@idT", ModuloConexion.IdTurnoSesion)
                                        cmdIns.Parameters.AddWithValue("@nombre", ModuloConexion.TurnoSesion)
                                        cmdIns.Parameters.AddWithValue("@odo", ModuloConexion.OdometroInicioTurno)
                                        cmdIns.Parameters.AddWithValue("@per", ModuloConexion.PeriodoSesion)
                                        cmdIns.Parameters.AddWithValue("@sem", ModuloConexion.SemanaSesion)
                                        cmdIns.ExecuteNonQuery()
                                    End Using
                                End If
                            End If

                            Dim frm As New Principal()
                            Dim tituloTurno As String = If(tipo.ToUpper() = "DESPACHADOR" AndAlso turnoCbx.SelectedIndex >= 0, " - Turno: " & turnoCbx.Text, "")
                            frm.Text = "EMTRACC - " & nombre & " " & apellido & " (" & tipo & ")" & tituloTurno
                            frm.Tag = tipo
                            frm.PermisosUsuario = permisos
                            frm.Show()
                            Me.Hide()
                        Else
                            MessageBox.Show("Usuario o contraseña incorrectos", "Error de Autenticación", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            claveTbx.Focus()
                            claveTbx.SelectAll()
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error al conectar con la base de datos:" & vbCrLf & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub verClaveBtn_Click(sender As Object, e As EventArgs) Handles verClaveBtn.Click
        claveTbx.UseSystemPasswordChar = Not claveTbx.UseSystemPasswordChar
    End Sub
End Class
