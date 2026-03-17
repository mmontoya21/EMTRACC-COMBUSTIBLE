Imports MySql.Data.MySqlClient
Imports System.Security.Cryptography
Imports System.Text
Imports System.Data

Public Class login

    Private Sub login_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        usuarioTbx.Focus()
    End Sub

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

                            Dim frm As New Principal()
                            frm.Text = "EMTRACC - " & nombre & " " & apellido & " (" & tipo & ")"
                            frm.Tag = tipo
                            frm.PermisosUsuario = permisos
                            frm.Show()
                            Me.Hide()
                        Else
                            MessageBox.Show("Usuario o contraseña incorrectos", "Error de Autenticación", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            claveTbx.Text = ""
                            claveTbx.Focus()
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
