Imports MySql.Data.MySqlClient
Imports System.Security.Cryptography
Imports System.Text

Imports System.Data
Imports MySql.Data
Public Class acceso
    Dim adaptador As New MySqlDataAdapter
    Dim datos As DataSet

    ' Permisos: array de checkboxes (se inicializa en Load desde controles del Designer)
    Private chkModulos() As CheckBox
    Private ReadOnly moduloKeys() As String = {"camiones", "placa", "transportistas", "tanque", "empresa", "acceso", "medicion", "comprobante", "factura", "propietario", "consumo", "reporte", "valorComb", "rutas", "reporteFact"}

    Private Sub acceso_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("es-CO")
        System.Threading.Thread.CurrentThread.CurrentCulture.DateTimeFormat.ShortDatePattern = "yyyy/MM/dd"
        System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencyDecimalSeparator = "."
        System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencyGroupSeparator = ","
        System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator = "."
        System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.NumberGroupSeparator = ","

        EstilizarFormulario()
        EnsurePermisosColumn()

        ' Inicializar array de checkboxes desde controles del Designer
        chkModulos = New CheckBox() {chkCamiones, chkPlacas, chkTransportistas, chkTanque, chkEmpresa, chkAccesos, chkMedicion, chkComprobante, chkFactura, chkPropietario, chkConsumo, chkReporte, chkValorComb, chkRutas, chkReporteFact}
        PanelPermisos.Enabled = False

        act()
        listadoCamDgv()
        EstilizarDataGridViewWinUI(AcceDGV)

        HabilitarControles(False)
    End Sub

    Private Sub EstilizarFormulario()
        ' === WinUI 3 Dark Theme ===
        Dim fondoForm As Color = Color.FromArgb(32, 32, 32)
        Dim fondoCard As Color = Color.FromArgb(44, 44, 44)
        Dim fondoControl As Color = Color.FromArgb(55, 55, 55)
        Dim colorAccent As Color = Color.FromArgb(96, 205, 255)

        ' === Formulario ===
        Me.BackColor = fondoForm
        Me.Text = "EMTRACC - Accesos"

        ' === Paneles (tarjetas) ===
        PanelP.BackColor = fondoCard
        PanelPermisos.BackColor = fondoCard

        ' === Labels en PanelP ===
        For Each ctrl As Control In PanelP.Controls
            If TypeOf ctrl Is Label Then
                Dim lbl = DirectCast(ctrl, Label)
                lbl.Font = New Font("Segoe UI Semibold", 11, FontStyle.Bold)
                lbl.ForeColor = Color.White
            End If
        Next

        ' === TextBoxes en PanelP ===
        For Each ctrl As Control In PanelP.Controls
            If TypeOf ctrl Is TextBox Then
                Dim tb = DirectCast(ctrl, TextBox)
                tb.BackColor = fondoControl
                tb.ForeColor = Color.White
                tb.Font = New Font("Segoe UI", 11)
                tb.BorderStyle = BorderStyle.FixedSingle
            End If
        Next

        ' === ComboBoxes en PanelP ===
        For Each ctrl As Control In PanelP.Controls
            If TypeOf ctrl Is ComboBox Then
                Dim cb = DirectCast(ctrl, ComboBox)
                cb.BackColor = fondoControl
                cb.ForeColor = Color.White
                cb.Font = New Font("Segoe UI", 11)
                cb.FlatStyle = FlatStyle.Flat
            End If
        Next

        ' === DateTimePicker ===
        fechDpk.Font = New Font("Segoe UI", 11)

        ' === Botones de accion ===
        EstilizarBoton(NuevoBtn, fondoControl)
        EstilizarBoton(EditarBtn, fondoControl)
        EstilizarBoton(GuardarBtn, Color.FromArgb(16, 137, 62))
        EstilizarBoton(ModificarBtn, Color.FromArgb(255, 180, 0), Color.Black)
        EstilizarBoton(EliminarBtn, Color.FromArgb(232, 17, 35))
        EstilizarBoton(CancelarBtn, fondoControl)

        ' === Boton ojo (toggle clave) ===
        ButtonX1.FlatStyle = FlatStyle.Flat
        ButtonX1.FlatAppearance.BorderSize = 0
        ButtonX1.BackColor = fondoControl
        ButtonX1.ForeColor = Color.White
        ButtonX1.Cursor = Cursors.Hand

        ' === Checkboxes en PanelPermisos ===
        For Each ctrl As Control In PanelPermisos.Controls
            If TypeOf ctrl Is CheckBox Then
                Dim chk = DirectCast(ctrl, CheckBox)
                chk.ForeColor = Color.FromArgb(200, 215, 240)
                chk.Font = New Font("Segoe UI", 9)
                chk.BackColor = Color.Transparent
            End If
        Next

        ' === Titulo permisos ===
        LblPermisos.ForeColor = colorAccent
        LblPermisos.Font = New Font("Segoe UI Semibold", 10, FontStyle.Bold)
    End Sub

    Private Sub EstilizarBoton(btn As Button, bgColor As Color, Optional fgColor As Color = Nothing)
        If fgColor = Nothing Then fgColor = Color.White
        btn.FlatStyle = FlatStyle.Flat
        btn.FlatAppearance.BorderSize = 1
        btn.FlatAppearance.BorderColor = bgColor
        btn.FlatAppearance.MouseOverBackColor = ControlPaint.Light(bgColor, 0.15F)
        btn.FlatAppearance.MouseDownBackColor = ControlPaint.Dark(bgColor, 0.15F)
        btn.BackColor = bgColor
        btn.ForeColor = fgColor
        btn.Font = New Font("Segoe UI", 9.5!, FontStyle.Bold)
        btn.Cursor = Cursors.Hand
    End Sub

    Private Sub HabilitarControles(habilitar As Boolean)
        For Each ctrl As Control In PanelP.Controls
            If TypeOf ctrl Is TextBox OrElse
               TypeOf ctrl Is ComboBox OrElse
               TypeOf ctrl Is DateTimePicker OrElse
               TypeOf ctrl Is Button Then
                ctrl.Enabled = habilitar
            End If
        Next
        PanelPermisos.Enabled = habilitar
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

    ' ============ PANEL DE PERMISOS ============
    Private Sub EnsurePermisosColumn()
        Try
            Using conLocal As MySqlConnection = ModuloConexion.ObtenerConexion()
                conLocal.Open()
                Using cmd As New MySqlCommand("ALTER TABLE accesos ADD COLUMN permisos TEXT", conLocal)
                    cmd.ExecuteNonQuery()
                End Using
            End Using
        Catch
            ' Columna ya existe
        End Try
    End Sub

    Private Function ObtenerPermisos() As String
        Dim permisos As New List(Of String)
        For i As Integer = 0 To 14
            If chkModulos(i).Checked Then
                permisos.Add(moduloKeys(i))
            End If
        Next
        Return String.Join(",", permisos)
    End Function

    Private Sub CargarPermisos(permisos As String)
        If String.IsNullOrEmpty(permisos) Then
            For i As Integer = 0 To 14
                chkModulos(i).Checked = True
            Next
            Return
        End If

        Dim lista() As String = permisos.Split(","c)
        For i As Integer = 0 To 14
            chkModulos(i).Checked = lista.Contains(moduloKeys(i))
        Next
    End Sub

    Private Sub AplicarDefaultsPorTipo()
        ' Primero marcar todos
        For i As Integer = 0 To 14
            chkModulos(i).Checked = True
        Next

        Select Case tipoTbx.Text.ToUpper()
            Case "ADMIN"
                For i As Integer = 0 To 14
                    If moduloKeys(i) = "empresa" OrElse moduloKeys(i) = "acceso" Then
                        chkModulos(i).Checked = False
                    End If
                Next
            Case "USUARIO"
                For i As Integer = 0 To 14
                    If moduloKeys(i) = "empresa" OrElse moduloKeys(i) = "acceso" OrElse moduloKeys(i) = "factura" Then
                        chkModulos(i).Checked = False
                    End If
                Next
            Case "TEST"
                For i As Integer = 0 To 14
                    If moduloKeys(i) = "acceso" Then
                        chkModulos(i).Checked = False
                    End If
                Next
            Case "DESPACHADOR"
                For i As Integer = 0 To 14
                    chkModulos(i).Checked = False
                Next
                ' Activar solo: comprobante, placa, rutas, propietario, camiones, transportistas
                For i As Integer = 0 To 14
                    If moduloKeys(i) = "comprobante" OrElse moduloKeys(i) = "placa" OrElse
                       moduloKeys(i) = "rutas" OrElse moduloKeys(i) = "propietario" OrElse
                       moduloKeys(i) = "camiones" OrElse moduloKeys(i) = "transportistas" Then
                        chkModulos(i).Checked = True
                    End If
                Next
        End Select
    End Sub

    Private Sub tipoTbx_SelectedIndexChanged(sender As Object, e As EventArgs) Handles tipoTbx.SelectedIndexChanged
        If PanelPermisos.Enabled Then
            AplicarDefaultsPorTipo()
        End If
    End Sub

    ' ============ DATOS ============
    Private Sub listadoCamDgv()
        Try
            Dim table As New DataTable()
            Using conLocal As MySqlConnection = ModuloConexion.ObtenerConexion()
                conLocal.Open()
                Using adaptadoListado As New MySqlDataAdapter("SELECT id, nombre, apellido, usuario, tipo, status, fecha FROM accesos", conLocal)
                    adaptadoListado.Fill(table)
                End Using
            End Using
            AcceDGV.DataSource = table
            ListadoD()
        Catch ex As Exception
            MessageBox.Show("Error al cargar datos: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub ListadoD()
        AcceDGV.Columns(0).HeaderText = "ID"
        AcceDGV.Columns(0).Width = 10

        AcceDGV.Columns(1).HeaderText = "Nombre"
        AcceDGV.Columns(1).Width = 100

        AcceDGV.Columns(2).HeaderText = "Apellido"
        AcceDGV.Columns(2).Width = 100

        AcceDGV.Columns(3).HeaderText = "Usuario"
        AcceDGV.Columns(3).Width = 175

        AcceDGV.Columns(4).HeaderText = "Tipo"
        AcceDGV.Columns(4).Width = 100

        AcceDGV.Columns(5).HeaderText = "Estatus"
        AcceDGV.Columns(5).Width = 100

        AcceDGV.Columns(6).HeaderText = "Fecha"
        AcceDGV.Columns(6).Width = 100
    End Sub
    Sub limpiar()
        Me.nombTbx.Text = ""
        Me.ApelTbx.Text = ""
        Me.usuaTbx.Text = ""
        Me.clavTbx.Text = ""
        Me.tipoTbx.Text = ""
        Me.statTbx.Text = ""
        Me.fechDpk.Value = Today
        For i As Integer = 0 To 14
            chkModulos(i).Checked = True
        Next
    End Sub
    Private Sub act()
        Me.NuevoBtn.Enabled = True
        Me.EditarBtn.Enabled = False
        Me.GuardarBtn.Enabled = False
        Me.ModificarBtn.Enabled = False
        Me.CancelarBtn.Enabled = False
        Me.EliminarBtn.Enabled = False
    End Sub
    Private Sub NuevoBtn_Click(sender As Object, e As EventArgs) Handles NuevoBtn.Click '============  NUEVO  ===========
        limpiar()

        nombTbx.Focus()

        AcceDGV.Enabled = False
        Me.GuardarBtn.Enabled = True
        Me.ModificarBtn.Enabled = False
        Me.EditarBtn.Enabled = False
        Me.CancelarBtn.Enabled = True
        Me.EliminarBtn.Enabled = False
        Me.NuevoBtn.Enabled = False

        HabilitarControles(True)
    End Sub

    Private Sub EditarBtn_Click(sender As Object, e As EventArgs) Handles EditarBtn.Click  '============  EDITAR  ===========
        HabilitarControles(True)
        Me.AcceDGV.Enabled = False
        Me.GuardarBtn.Enabled = False
        Me.GuardarBtn.Visible = False
        Me.ModificarBtn.Enabled = True
        Me.EditarBtn.Enabled = False
        Me.CancelarBtn.Enabled = True
        Me.NuevoBtn.Enabled = False
        Me.EliminarBtn.Enabled = False
    End Sub

    Private Sub CancelarBtn_Click(sender As Object, e As EventArgs) Handles CancelarBtn.Click  '============  CANCELAR  ===========
        act()
        HabilitarControles(False)
        AcceDGV.Enabled = True
        Me.GuardarBtn.Visible = True
    End Sub

    Private Sub EliminarBtn_Click(sender As Object, e As EventArgs) Handles EliminarBtn.Click  '============  ELIMINAR  ===========
        Try
            Dim opc As DialogResult = MsgBox("¿Desea Eliminar este registro?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Eliminar")
            If opc = Windows.Forms.DialogResult.Yes Then
                Using conLocal As MySqlConnection = ModuloConexion.ObtenerConexion()
                    conLocal.Open()
                    Using eli As New MySqlCommand("DELETE FROM accesos WHERE id = @id", conLocal)
                        eli.Parameters.AddWithValue("@id", Conversion.Int(Me.buscartxt.Text))
                        eli.ExecuteNonQuery()
                    End Using
                End Using
                MsgBox("Registro eliminado correctamente", MsgBoxStyle.Information, "Eliminado")
                listadoCamDgv()
            End If
        Catch ex As Exception
            MessageBox.Show("Error al eliminar: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try

        act()
    End Sub
    Private Sub GuardarBtn_Click(sender As Object, e As EventArgs) Handles GuardarBtn.Click  '============  GUARDADO  ===========
        Dim fe As Date = fechDpk.Value.ToString("yyyy-MM-dd")
        Dim hashedClave As String = ComputeSHA256(clavTbx.Text)
        Dim permisos As String = ObtenerPermisos()

        Try
            Using conLocal As MySqlConnection = ModuloConexion.ObtenerConexion()
                conLocal.Open()
                Using guardar As New MySqlCommand("INSERT INTO accesos (nombre, apellido, usuario, clave, tipo, status, fecha, permisos) VALUES(@nombre, @apellido, @usuario, @clave, @tipo, @status, @fecha, @permisos)", conLocal)
                    guardar.Parameters.AddWithValue("@nombre", nombTbx.Text)
                    guardar.Parameters.AddWithValue("@apellido", ApelTbx.Text)
                    guardar.Parameters.AddWithValue("@usuario", usuaTbx.Text)
                    guardar.Parameters.AddWithValue("@clave", hashedClave)
                    guardar.Parameters.AddWithValue("@tipo", tipoTbx.Text)
                    guardar.Parameters.AddWithValue("@status", statTbx.Text)
                    guardar.Parameters.AddWithValue("@fecha", fe)
                    guardar.Parameters.AddWithValue("@permisos", permisos)
                    guardar.ExecuteNonQuery()
                End Using
            End Using
            MsgBox("Registro guardado")
        Catch ex As Exception
            MessageBox.Show("Error al guardar: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        limpiar()
        act()
        HabilitarControles(False)
        AcceDGV.Enabled = True
        listadoCamDgv()
    End Sub

    Private Sub ModificarBtn_Click(sender As Object, e As EventArgs) Handles ModificarBtn.Click  '============  MODIFICAR  ===========
        actual()
        act()
        HabilitarControles(False)
        AcceDGV.Enabled = True
        Me.GuardarBtn.Visible = True
        listadoCamDgv()
    End Sub
    Public Sub actual()
        Dim permisos As String = ObtenerPermisos()

        Try
            Using conLocal As MySqlConnection = ModuloConexion.ObtenerConexion()
                conLocal.Open()

                Dim sql As String
                If clavTbx.Text.Trim() <> "" Then
                    sql = "UPDATE accesos SET nombre=@nombre, apellido=@apellido, usuario=@usuario, clave=@clave, tipo=@tipo, status=@status, fecha=@fecha, permisos=@permisos WHERE id=@id"
                Else
                    sql = "UPDATE accesos SET nombre=@nombre, apellido=@apellido, usuario=@usuario, tipo=@tipo, status=@status, fecha=@fecha, permisos=@permisos WHERE id=@id"
                End If

                Using cmd As New MySqlCommand(sql, conLocal)
                    cmd.Parameters.AddWithValue("@nombre", nombTbx.Text)
                    cmd.Parameters.AddWithValue("@apellido", ApelTbx.Text)
                    cmd.Parameters.AddWithValue("@usuario", usuaTbx.Text)
                    If clavTbx.Text.Trim() <> "" Then
                        cmd.Parameters.AddWithValue("@clave", ComputeSHA256(clavTbx.Text))
                    End If
                    cmd.Parameters.AddWithValue("@tipo", tipoTbx.Text)
                    cmd.Parameters.AddWithValue("@status", statTbx.Text)
                    cmd.Parameters.AddWithValue("@fecha", fechDpk.Value.ToString("yyyy-MM-dd"))
                    cmd.Parameters.AddWithValue("@permisos", permisos)
                    cmd.Parameters.AddWithValue("@id", buscartxt.Text)
                    cmd.ExecuteNonQuery()
                End Using
            End Using
            MsgBox("Registro Actualizado")
        Catch ex As Exception
            MessageBox.Show("Error al actualizar: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub CamDGV_Click(sender As Object, e As EventArgs) Handles AcceDGV.Click
        If Me.AcceDGV.RowCount = 0 Then
            MessageBox.Show("No hay datos a mostrar")
        Else
            Dim y As Integer = Me.AcceDGV.CurrentRow.Index
            Dim idcod As Integer = Me.AcceDGV.Item(0, y).Value
            buscartxt.Text = idcod
            seleccion()
            Me.EditarBtn.Enabled = True
            Me.EliminarBtn.Enabled = True
        End If
    End Sub
    Public Sub seleccion()
        Try
            If buscartxt.Text = "" OrElse buscartxt.Text = "-" Then Return

            Using conLocal As MySqlConnection = ModuloConexion.ObtenerConexion()
                conLocal.Open()
                Using cmd As New MySqlCommand("SELECT * FROM accesos WHERE id = @id", conLocal)
                    cmd.Parameters.AddWithValue("@id", buscartxt.Text)
                    adaptador = New MySqlDataAdapter(cmd)
                    datos = New DataSet
                    adaptador.Fill(datos, "accesos")
                End Using
            End Using

            If datos.Tables("accesos").Rows.Count <> 0 Then
                Dim row = datos.Tables("accesos").Rows(0)
                nombTbx.Text = row.Item("nombre").ToString
                ApelTbx.Text = row.Item("apellido").ToString
                usuaTbx.Text = row.Item("usuario").ToString
                clavTbx.Text = ""
                tipoTbx.Text = row.Item("tipo").ToString
                statTbx.Text = row.Item("status").ToString
                Try
                    fechDpk.Value = row.Item("fecha")
                Catch
                    fechDpk.Value = Today
                End Try
                ' Cargar permisos
                Try
                    Dim permisos As String = row.Item("permisos").ToString()
                    CargarPermisos(permisos)
                Catch
                    CargarPermisos("")
                End Try
            Else
                MsgBox("Datos no encontrados")
            End If
        Catch ex As Exception
            MessageBox.Show("Error al seleccionar: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ButtonX1_Click(sender As Object, e As EventArgs) Handles ButtonX1.Click
        clavTbx.UseSystemPasswordChar = Not clavTbx.UseSystemPasswordChar
    End Sub

    Private Sub EstilizarDataGridViewWinUI(dgv As DataGridView)
        dgv.BackgroundColor = Color.FromArgb(32, 32, 32)
        dgv.GridColor = Color.FromArgb(60, 60, 60)
        dgv.BorderStyle = BorderStyle.None

        dgv.EnableHeadersVisualStyles = False
        dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(44, 44, 44)
        dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
        dgv.ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI Semibold", 9.75, FontStyle.Bold)
        dgv.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(44, 44, 44)
        dgv.ColumnHeadersHeight = 36

        dgv.DefaultCellStyle.Font = New Font("Segoe UI", 9.75)
        dgv.DefaultCellStyle.ForeColor = Color.White
        dgv.DefaultCellStyle.BackColor = Color.FromArgb(44, 44, 44)
        dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(96, 205, 255)
        dgv.DefaultCellStyle.SelectionForeColor = Color.Black
        dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(50, 50, 50)
        dgv.RowTemplate.Height = 30

        dgv.RowHeadersVisible = False
        dgv.AllowUserToAddRows = False
        dgv.AllowUserToDeleteRows = False
        dgv.AllowUserToResizeRows = False
        dgv.ReadOnly = True
        dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgv.MultiSelect = False
    End Sub
End Class
