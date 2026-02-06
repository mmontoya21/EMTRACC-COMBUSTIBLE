Imports MySql.Data.MySqlClient
Imports System.Security.Cryptography
Imports System.Text

Imports System.Data
Imports MySql.Data
Public Class acceso
    Dim con As New MySqlConnection
    Dim cm As New MySqlCommand
    Dim guardar As New MySqlCommand
    Dim adaptador As New MySqlDataAdapter
    Dim datos As DataSet
    Private Sub acceso_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim colorFondo = Color.FromArgb(106, 126, 168)
        Dim colorTextbox = Color.FromArgb(240, 210, 249)

        On Error Resume Next

        System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("es-CO")
        System.Threading.Thread.CurrentThread.CurrentCulture.DateTimeFormat.ShortDatePattern = "yyyy/MM/dd"
        System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencyDecimalSeparator = "."
        System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencyGroupSeparator = ","
        System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator = "."
        System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.NumberGroupSeparator = ","


        conectar()
        act()
        listadoCamDgv()
        EstilizarDataGridView(CamDGV)

        PanelP.Enabled = False
    End Sub
    Private Function ComputeSHA256(input As String) As String
        ' Crear instancia del algoritmo SHA256
        Using sha256 As SHA256 = SHA256.Create()
            ' Convertir el texto de entrada en bytes
            Dim inputBytes As Byte() = Encoding.UTF8.GetBytes(input)

            ' Calcular el hash
            Dim hashBytes As Byte() = sha256.ComputeHash(inputBytes)

            ' Convertir los bytes del hash a una cadena hexadecimal
            Dim sb As New StringBuilder()
            For Each b As Byte In hashBytes
                sb.Append(b.ToString("X2"))
            Next

            Return sb.ToString()
        End Using
    End Function
    Public Sub conectar()
        con = ModuloConexion.ObtenerConexion()
        Try
            If con.State = ConnectionState.Closed Then
                con.Open()
            End If
            MsgBox("Sistema conectado")
        Catch ex As Exception
            MsgBox("No se conecto por: " & ex.Message)
        End Try
    End Sub
    Private Sub listadoCamDgv() 'Muestra los datos
        Dim table As New DataTable()
        Dim adaptadoListado As New MySqlDataAdapter("SELECT id, nombre, apellido, usuario , tipo, status, fecha FROM accesos", con)
        adaptadoListado.Fill(table)

        CamDGV.DataSource = table

        ListadoD()

    End Sub
    Private Sub ListadoD()

        CamDGV.Columns(0).HeaderText = "ID"
        CamDGV.Columns(0).Width = 10

        CamDGV.Columns(1).HeaderText = "Nombre"
        CamDGV.Columns(1).Width = 100

        CamDGV.Columns(2).HeaderText = "Apellido"
        CamDGV.Columns(2).Width = 100

        CamDGV.Columns(3).HeaderText = "Usuario"
        CamDGV.Columns(3).Width = 175

        CamDGV.Columns(4).HeaderText = "Tipo"
        CamDGV.Columns(4).Width = 100

        CamDGV.Columns(5).HeaderText = "Estatus"
        CamDGV.Columns(5).Width = 100

        CamDGV.Columns(6).HeaderText = "Fecha"
        CamDGV.Columns(6).Width = 100

    End Sub
    Sub limpiar()
        Me.nombTbx.Text = ""
        Me.ApelTbx.Text = ""
        Me.usuaTbx.Text = ""
        Me.clavTbx.Text = ""
        Me.tipoTbx.Text = ""
        Me.statTbx.Text = ""
        Me.fechDpk.Value = Today
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

        CamDGV.Enabled = False
        Me.GuardarBtn.Enabled = True
        Me.ModificarBtn.Enabled = False
        Me.EditarBtn.Enabled = False
        Me.CancelarBtn.Enabled = True
        Me.EliminarBtn.Enabled = False
        Me.NuevoBtn.Enabled = False

        PanelP.Enabled = True
    End Sub

    Private Sub EditarBtn_Click(sender As Object, e As EventArgs) Handles EditarBtn.Click  '============  EDITAR  ===========
        PanelP.Enabled = True
        Me.CamDGV.Enabled = False
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
        PanelP.Enabled = False
        CamDGV.Enabled = True
        Me.GuardarBtn.Visible = True
    End Sub

    Private Sub EliminarBtn_Click(sender As Object, e As EventArgs) Handles EliminarBtn.Click  '============  ELIMINAR  ===========
        Try

            Dim opc As DialogResult = MsgBox("¿Desea Eliminar este registro?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Eliminar")
            If opc = Windows.Forms.DialogResult.Yes Then

                Dim eliminar As String

                eliminar = "DELETE FROM accesos WHERE id = '" & Conversion.Int(Me.buscartxt.Text) & "'"
                Dim eli As New MySqlCommand(eliminar, con)
                eli.ExecuteNonQuery()

                listadoCamDgv()

            End If
        Catch
            MessageBox.Show("Actualización Base de Datos, " & Chr(13) & "favor escoger de nuevo el registro y eliminarlo", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)

        End Try

        act()
    End Sub
    Private Sub GuardarBtn_Click(sender As Object, e As EventArgs) Handles GuardarBtn.Click  '============  GUARDADO  ===========
        con.Close()
        con.Open()

        Dim fe As Date = fechDpk.Value.ToString("yyyy-MM-dd")

        Dim claveHash As String = clavTbx.Text ' El texto del TextBox
        Dim hashedClave As String = ComputeSHA256(claveHash)

        Try

            guardar = New MySqlCommand("INSERT INTO accesos (nombre, apellido, usuario, clave, tipo, status, fecha)" & Chr(13) &
                                                     "VALUES(@nombre, @apellido, @usuario, @clave, @tipo, @status, @fecha)", con)

            'guardar = New MySqlCommand("INSERT INTO accesos (nombre, apellido, usuario, fecha)" & Chr(13) &
            '"VALUES(@nombre, @apellido, @usuario, @clave)", con)

            guardar.Parameters.AddWithValue("@nombre", nombTbx.Text)
            guardar.Parameters.AddWithValue("@apellido", ApelTbx.Text)
            guardar.Parameters.AddWithValue("@usuario", usuaTbx.Text)
            guardar.Parameters.AddWithValue("@clave", hashedClave)
            guardar.Parameters.AddWithValue("@tipo", tipoTbx.Text)
            guardar.Parameters.AddWithValue("@status", statTbx.Text)
            guardar.Parameters.AddWithValue("@fecha", fe)


            guardar.ExecuteNonQuery()
            MsgBox("Registo guardado")

        Catch ex As Exception
            MsgBox("Elemento no pudo se almacenado", ex.StackTrace)
        End Try

        limpiar()

        act()

        CamDGV.Enabled = True
        listadoCamDgv()
    End Sub

    Private Sub ModificarBtn_Click(sender As Object, e As EventArgs) Handles ModificarBtn.Click  '============  MODIFICAR  ===========
        actual()
        act()
        PanelP.Enabled = False
        CamDGV.Enabled = True
        Me.GuardarBtn.Visible = True
        listadoCamDgv()
    End Sub
    Public Sub actual()
        Dim actualizar As String

        Dim claveHash As String = clavTbx.Text ' El texto del TextBox
        Dim hashedClave As String = ComputeSHA256(claveHash)

        actualizar = "UPDATE accesos SET nombre = '" & nombTbx.Text & "', apellido = '" & ApelTbx.Text & "', usuario = '" & usuaTbx.Text & "', clave = '" & hashedClave & "', tipo = '" & tipoTbx.Text & "', status = '" & statTbx.Text & "', fecha = '" & fechDpk.Text & "' WHERE id = '" & buscartxt.Text & "'"
        Dim act As New MySqlCommand(actualizar, con)
        act.ExecuteNonQuery()
        MsgBox("Registo Actualizado")
    End Sub

    Private Sub CamDGV_Click(sender As Object, e As EventArgs) Handles CamDGV.Click
        If Me.CamDGV.RowCount = 0 Then
            MessageBox.Show("No hay datos a mostrar")
        Else
            'Dim i As Integer = Me.CamDGV.CurrentRow.Index
            'Me.placaBusqTB.Text = Me.CamDGV.Item(1, i).Value

            Dim y As Integer = Me.CamDGV.CurrentRow.Index
            Dim idcod As Integer = Me.CamDGV.Item(0, y).Value
            buscartxt.Text = idcod
            seleccion()
            Me.EditarBtn.Enabled = True
            Me.EliminarBtn.Enabled = True
        End If
    End Sub
    Public Sub seleccion()
        Dim consulta As String
        Dim lista As Byte

        If buscartxt.Text <> "" Then
            consulta = "SELECT * FROM accesos WHERE id = '" & buscartxt.Text & "'"
            adaptador = New MySqlDataAdapter(consulta, con)
            datos = New DataSet
            adaptador.Fill(datos, "accesos")
            lista = datos.Tables("accesos").Rows.Count
        End If

        If lista <> 0 Then

            nombTbx.Text = datos.Tables("accesos").Rows(0).Item("nombre").ToString
            ApelTbx.Text = datos.Tables("accesos").Rows(0).Item("apellido").ToString
            usuaTbx.Text = datos.Tables("accesos").Rows(0).Item("usuario").ToString
            clavTbx.Text = datos.Tables("accesos").Rows(0).Item("clave").ToString
            tipoTbx.Text = datos.Tables("accesos").Rows(0).Item("tipo").ToString
            statTbx.Text = datos.Tables("accesos").Rows(0).Item("status").ToString
            Try
                fechDpk.Value = datos.Tables("accesos").Rows(0).Item("fecha")
            Catch
                fechDpk.Value = Today
            End Try

        Else
            MsgBox("Datos no encontrados")
        End If
        listadoCamDgv()
    End Sub

    Private Sub ButtonX1_Click(sender As Object, e As EventArgs) Handles ButtonX1.Click
        If clavTbx.UseSystemPasswordChar = True Then
            clavTbx.UseSystemPasswordChar = False
        Else
            clavTbx.UseSystemPasswordChar = True
        End If
    End Sub
End Class