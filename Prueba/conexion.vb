Imports System.Data
Imports MySql.Data.MySqlClient
Imports MySql.Data
Public Class conexion
    Dim con As New MySqlConnection
    Dim cm As New MySqlCommand
    Dim guardar As New MySqlCommand
    Dim adaptador As New MySqlDataAdapter
    Dim datos As DataSet
    Dim dr As MySqlDataReader
    Private m_tmr As Timer

    Private isMouseDown As Boolean = False
    Private mouseOffset As Point

    Dim colorFondo = Color.FromArgb(106, 126, 168)
    Dim colorTextbox = Color.FromArgb(240, 210, 249)
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'conectar()
        act()
        'listadoCamDgv()
        CamDGV.BackgroundColor = colorFondo
        CamDGV.RowsDefaultCellStyle.BackColor = Color.Bisque
        CamDGV.AlternatingRowsDefaultCellStyle.BackColor = Color.Lavender

        PanelP.Enabled = False
    End Sub
    Private Sub act()
        Me.NuevoBtn.Enabled = True
        Me.EditarBtn.Enabled = False
        Me.GuardarBtn.Enabled = False
        Me.ModificarBtn.Enabled = False
        Me.CancelarBtn.Enabled = False
        Me.EliminarBtn.Enabled = False
    End Sub
    Private Sub conectar()
        Dim servidor As String = srvTb.Text
        'Dim servidor As String = "192.168.68.101"
        Dim baseDatos As String = bdTb.Text
        Dim userid As String = userTb.Text
        Dim clave As String = passTb.Text


        'con.ConnectionString = "Server=168.119.90.215; Database=datasafe_eda; Uid=datasafe_edausr; Pwd=@Paradoja18"

        'con.ConnectionString = "Server=185.224.137.172; Database=u282951626_eda; Uid=u282951626_edauser; Pwd=@Paradoja18"

        con.ConnectionString = "Server=" & servidor & "; Database=" & baseDatos & "; Uid = " & userid & "; Pwd = " & clave

        Try

            con.Open()

            MsgBox("Sistema Conectado")
            listadoCamDgv()
        Catch ex As Exception

            MsgBox("No se conecto por: " & ex.Message)
        End Try


    End Sub

    Private Sub TextBoxX7_TextChanged(sender As Object, e As EventArgs)

    End Sub
    Private Sub ButtonX2_Click(sender As Object, e As EventArgs) Handles NuevoBtn.Click '============  NUEVO  ===========
        limpiar()
        PanelP.Enabled = True
        GuardarBtn.Enabled = True
        CamDGV.Enabled = False
        CancelarBtn.Enabled = True
    End Sub
    Private Sub EditarBtn_Click(sender As Object, e As EventArgs) Handles EditarBtn.Click '============  EDITAR  ===========
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
    Private Sub ButtonX1_Click(sender As Object, e As EventArgs) Handles GuardarBtn.Click '============  GUARDADO  ===========
        con.Close()
        con.Open()
        Try

            guardar = New MySqlCommand("INSERT INTO conexion (srv, bd, user, pass)" & Chr(13) &
            "VALUES(@srv, @bd, @user, @pass)", con)

            guardar.Parameters.AddWithValue("@srv", srvTb.Text)
            guardar.Parameters.AddWithValue("@bd", bdTb.Text)
            guardar.Parameters.AddWithValue("@user", userTb.Text)
            guardar.Parameters.AddWithValue("@pass", passTb.Text)


            guardar.ExecuteNonQuery()
            MsgBox("Registo guardado")

        Catch ex As Exception
            MsgBox("Elemento no pudo se almacenado", ex.StackTrace)
        End Try

        limpiar()

        act()

        CamDGV.Enabled = True
        listadoCamDgv()

        'articulosPanel.Enabled = False
        'ItemDgv.Enabled = True
        'Me.GuardarBtn.Visible = True
    End Sub
    Private Sub CancelarBtn_Click(sender As Object, e As EventArgs) Handles CancelarBtn.Click '============  CANCELAR  ===========
        act()
        PanelP.Enabled = False
        CamDGV.Enabled = True
        Me.GuardarBtn.Visible = True
    End Sub
    Private Sub ModificarBtn_Click(sender As Object, e As EventArgs) Handles ModificarBtn.Click '============  MODIFICAR  ===========
        actual()
        act()
        PanelP.Enabled = False
        CamDGV.Enabled = True
        Me.GuardarBtn.Visible = True
        listadoCamDgv()
    End Sub
    Public Sub actual()
        Dim actualizar As String
        actualizar = "UPDATE conexion SET srv = '" & srvTb.Text & "', bd = '" & bdTb.Text & "', user = '" & userTb.Text & "', pass = '" & passTb.Text & "' WHERE idConex = '" & buscartxt.Text & "'"
        Dim act As New MySqlCommand(actualizar, con)
        act.ExecuteNonQuery()
        MsgBox("Registo Actualizado")
    End Sub
    Private Sub EliminarBtn_Click(sender As Object, e As EventArgs) Handles EliminarBtn.Click '============  ELIMINAR  ===========
        Try

            Dim opc As DialogResult = MsgBox("¿Desea Eliminar este registro?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Eliminar")
            If opc = Windows.Forms.DialogResult.Yes Then

                Dim eliminar As String

                eliminar = "DELETE FROM conexion WHERE idConex = '" & Conversion.Int(Me.buscartxt.Text) & "'"
                Dim eli As New MySqlCommand(eliminar, con)
                eli.ExecuteNonQuery()

                listadoCamDgv()

            End If
        Catch
            MessageBox.Show("Actualización Base de Datos, " & Chr(13) & "favor escoger de nuevo el registro y eliminarlo", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)

        End Try

        act()
    End Sub
    Sub limpiar()
        Me.srvTb.Text = ""
        Me.userTb.Text = ""
        Me.bdTb.Text = ""
        Me.passTb.Text = ""

    End Sub
    Private Sub ListadoD()
        CamDGV.Columns(0).HeaderText = "ID"
        CamDGV.Columns(0).Width = 50

        CamDGV.Columns(1).HeaderText = "Servidor"
        CamDGV.Columns(1).Width = 100

        CamDGV.Columns(2).HeaderText = "Base Datos"
        CamDGV.Columns(2).Width = 175

        CamDGV.Columns(3).HeaderText = "Usuario"
        CamDGV.Columns(3).Width = 175

        CamDGV.Columns(4).HeaderText = "Clave"
        CamDGV.Columns(4).Width = 175

    End Sub
    Private Sub placCamDgv() 'Autobusqueda PLACA
        Dim table As New DataTable()
        Dim adaptadoListado As New MySqlDataAdapter("SELECT idConex, srv, bd, user, pass FROM conexion WHERE bd LIKE '%" & placaBusqTB.Text & "%'", con)
        adaptadoListado.Fill(table)

        CamDGV.DataSource = table

        ListadoD()

    End Sub
    Private Sub propCamDgv() 'Autobusqueda Propietario
        Dim table As New DataTable()
        Dim adaptadoListado As New MySqlDataAdapter("SELECT idConex, srv, bd, user, pass FROM conexion WHERE propietario LIKE '%" & propBusqTB.Text & "%'", con)
        adaptadoListado.Fill(table)

        CamDGV.DataSource = table

        ListadoD()

    End Sub

    Private Sub listadoCamDgv() 'Muestra los datos
        Dim table As New DataTable()
        Dim adaptadoListado As New MySqlDataAdapter("SELECT idconex, srv, bd, user, pass FROM conexion", con)
        adaptadoListado.Fill(table)

        CamDGV.DataSource = table

        ListadoD()

    End Sub

    Private Sub placaBusqTB_TextChanged(sender As Object, e As EventArgs) Handles placaBusqTB.TextChanged
        placCamDgv()
    End Sub

    Private Sub propBusqTB_TextChanged(sender As Object, e As EventArgs) Handles propBusqTB.TextChanged
        propCamDgv()
    End Sub

    Private Sub ButtonX6_Click(sender As Object, e As EventArgs) Handles ButtonX6.Click
        propBusqTB.Text = ""
        placaBusqTB.Text = ""
        buscartxt.Text = ""
        EditarBtn.Enabled = False
        EliminarBtn.Enabled = False

        srvTb.Text = ""
        userTb.Text = ""
        bdTb.Text = ""
        passTb.Text = ""

    End Sub
    Private Sub CamDGV_Click(sender As Object, e As EventArgs) Handles CamDGV.Click
        If Me.CamDGV.RowCount = 0 Then
            MessageBox.Show("No hay datos a mostrar")
        Else
            Dim i As Integer = Me.CamDGV.CurrentRow.Index
            Me.placaBusqTB.Text = Me.CamDGV.Item(0, i).Value
            'Dim y As Integer = Me.CamDGV.CurrentRow.Index
            'Dim idConex As Integer = Me.CamDGV.Item(0, 0).Value
            buscartxt.Text = Me.placaBusqTB.Text


            seleccion()
            Me.EditarBtn.Enabled = True
            Me.EliminarBtn.Enabled = True
        End If
    End Sub
    Public Sub seleccion()
        Dim consulta As String
        Dim lista As Byte

        If buscartxt.Text <> "" Then
            consulta = "SELECT * FROM conexion WHERE idConex = '" & buscartxt.Text & "'"
            adaptador = New MySqlDataAdapter(consulta, con)
            datos = New DataSet
            adaptador.Fill(datos, "conexion")
            lista = datos.Tables("conexion").Rows.Count
        End If

        If lista <> 0 Then
            srvTb.Text = datos.Tables("conexion").Rows(0).Item("srv").ToString
            userTb.Text = datos.Tables("conexion").Rows(0).Item("user").ToString
            bdTb.Text = datos.Tables("conexion").Rows(0).Item("bd").ToString
            passTb.Text = datos.Tables("conexion").Rows(0).Item("pass").ToString


        Else
            MsgBox("Datos no encontrados")
        End If
        listadoCamDgv()
    End Sub

    Private Sub ButtonX1_Click_1(sender As Object, e As EventArgs) Handles ButtonX1.Click
        conectar()
    End Sub

    Private Sub ButtonX2_Click_1(sender As Object, e As EventArgs) Handles ButtonX2.Click
        srvTb.Text = "localhost"
        userTb.Text = "root"
        bdTb.Text = "givemefuel"
        passTb.Text = ""
    End Sub
End Class
