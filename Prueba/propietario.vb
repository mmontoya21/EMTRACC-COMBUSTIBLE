Imports System.Data
Imports MySql.Data.MySqlClient
Imports MySql.Data
Public Class propietario
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
    Private Sub propietario_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        conectar()
        act()
        listadoCamDgv()
        CamDGV.BackgroundColor = colorFondo
        CamDGV.RowsDefaultCellStyle.BackColor = Color.Bisque
        CamDGV.AlternatingRowsDefaultCellStyle.BackColor = Color.Lavender

        PanelP.Enabled = False
    End Sub
    Private Sub conectar()
        Dim servidor As String = "localhost"
        Dim baseDatos As String = "givemefuel"
        Dim userid As String = "root"
        Dim clave As String = ""


        'con.ConnectionString = "Server=168.119.90.215; Database=datasafe_eda; Uid=datasafe_edausr; Pwd=@Paradoja18"

        'con.ConnectionString = "Server=185.224.137.172; Database=u282951626_eda; Uid=u282951626_edauser; Pwd=@Paradoja18"

        con.ConnectionString = "Server=" & servidor & "; Database=" & baseDatos & "; Uid = " & userid & "; Pwd = " & clave

        Try

            con.Open()

            MsgBox("La Wea se conectó")

        Catch ex As Exception

            MsgBox("No se conecto por: " & ex.Message)
        End Try
    End Sub
    Sub limpiar()
        Me.codProTb.Text = ""
        Me.nEmpresaTb.Text = ""
        Me.nPropietarioTb.Text = ""
        Me.RTNTb.Text = ""
        Me.Tel1TB.Text = ""
        Me.Tel2Tb.Text = ""
        Me.DireccionTb.Text = ""
        Me.correoETb.Text = ""
    End Sub
    Private Sub act()
        Me.NuevoBtn.Enabled = True
        Me.EditarBtn.Enabled = False
        Me.GuardarBtn.Enabled = False
        Me.ModificarBtn.Enabled = False
        Me.CancelarBtn.Enabled = False
        Me.EliminarBtn.Enabled = False
    End Sub
    Private Sub NuevoBtn_Click(sender As Object, e As EventArgs) Handles NuevoBtn.Click '============== NUEVO =================
        limpiar()
        PanelP.Enabled = True
        GuardarBtn.Enabled = True
        CamDGV.Enabled = False
        CancelarBtn.Enabled = True

        EditarBtn.Enabled = False
        EliminarBtn.Enabled = False

        propBusqTB.Text = ""
        placaBusqTB.Text = ""
        buscartxt.Text = ""
    End Sub

    Private Sub EditarBtn_Click(sender As Object, e As EventArgs) Handles EditarBtn.Click '============== EDITAR =============
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
    Private Sub GuardarBtn_Click(sender As Object, e As EventArgs) Handles GuardarBtn.Click  '============== GUARDAR =============
        con.Close()
        con.Open()
        If Me.codProTb.Text = "" Or Me.nEmpresaTb.Text = "" Or Me.nPropietarioTb.Text = "" Or Me.RTNTb.Text = "" Or Me.Tel1TB.Text = "" Or Me.Tel2Tb.Text = "" Or Me.DireccionTb.Text = "" Or Me.correoETb.Text = "" Then
            MsgBox("Existen Campos vacíos, colocar 'X' en caso de no contar con datos")

        Else
            Try
                guardar = New MySqlCommand("INSERT INTO propietario (codProP, nEmpresa, nPropietario, RTN, Tel1, Tel2, Direccion, correoE)" & Chr(13) &
            "VALUES(@codProP, @nEmpresa, @nPropietario, @RTN, @Tel1, @Tel2, @Direccion, @correoE)", con)

                guardar.Parameters.AddWithValue("@codProP", codProTb.Text)
                guardar.Parameters.AddWithValue("@nEmpresa", nEmpresaTb.Text)
                guardar.Parameters.AddWithValue("@nPropietario", nPropietarioTb.Text)
                guardar.Parameters.AddWithValue("@RTN", RTNTb.Text)
                guardar.Parameters.AddWithValue("@Tel1", Tel1TB.Text)
                guardar.Parameters.AddWithValue("@Tel2", Tel2Tb.Text)
                guardar.Parameters.AddWithValue("@Direccion", DireccionTb.Text)
                guardar.Parameters.AddWithValue("@correoE", correoETb.Text)


                guardar.ExecuteNonQuery()
                MsgBox("Registo guardado")

            Catch ex As Exception
            MsgBox("Elemento no pudo se almacenado", ex.StackTrace)
        End Try

        limpiar()

        act()

        CamDGV.Enabled = True
            listadoCamDgv()
        End If
    End Sub
    Private Sub ModificarBtn_Click(sender As Object, e As EventArgs) Handles ModificarBtn.Click  '============== MODIFICAR =============
        actual()
        act()
        PanelP.Enabled = False
        CamDGV.Enabled = True
        Me.GuardarBtn.Visible = True
        listadoCamDgv()
    End Sub
    Public Sub actual()
        Dim actualizar As String
        actualizar = "UPDATE propietario SET codProP= '" & codProTb.Text & "', nEmpresa= '" & nEmpresaTb.Text & "', nPropietario= '" & nPropietarioTb.Text & "', RTN= '" & RTNTb.Text & "' ,Tel1= '" & Tel1TB.Text & "' ,Tel2= '" & Tel2Tb.Text & "' ,Direccion= '" & DireccionTb.Text & "' ,correoE= '" & correoETb.Text & "' WHERE codProp = '" & buscartxt.Text & "'"
        Dim act As New MySqlCommand(actualizar, con)
        act.ExecuteNonQuery()
        MsgBox("Registo Actualizado")
    End Sub
    Private Sub EliminarBtn_Click(sender As Object, e As EventArgs) Handles EliminarBtn.Click  '============== ELIMINAR =============
        Try

            Dim opc As DialogResult = MsgBox("¿Desea Eliminar este registro?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Eliminar")
            If opc = Windows.Forms.DialogResult.Yes Then

                Dim eliminar As String

                eliminar = "DELETE FROM propietario WHERE codProP = '" & Conversion.Int(Me.buscartxt.Text) & "'"
                Dim eli As New MySqlCommand(eliminar, con)
                eli.ExecuteNonQuery()

                listadoCamDgv()

            End If
        Catch
            MessageBox.Show("Actualización Base de Datos, " & Chr(13) & "favor escoger de nuevo el registro y eliminarlo", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)

        End Try

        act()
    End Sub
    Private Sub CancelarBtn_Click(sender As Object, e As EventArgs) Handles CancelarBtn.Click '============== CANCELAR =============
        act()
        PanelP.Enabled = False
        CamDGV.Enabled = True
        Me.GuardarBtn.Visible = True
    End Sub
    Private Sub listadoCamDgv() 'Muestra los datos
        Dim table As New DataTable()
        Dim adaptadoListado As New MySqlDataAdapter("SELECT codigoP, codProP, nPropietario, nEmpresa, RTN, Tel1, Tel2 FROM propietario", con)
        adaptadoListado.Fill(table)

        CamDGV.DataSource = table

        ListadoD()

    End Sub
    Private Sub ListadoD()
        CamDGV.Columns(0).HeaderText = "1"
        CamDGV.Columns(0).Width = 1

        CamDGV.Columns(1).HeaderText = "Código"
        CamDGV.Columns(1).Width = 75

        CamDGV.Columns(2).HeaderText = "Propietario"
        CamDGV.Columns(2).Width = 200

        CamDGV.Columns(3).HeaderText = "Empresa"
        CamDGV.Columns(3).Width = 200

        CamDGV.Columns(4).HeaderText = "RTN"
        CamDGV.Columns(4).Width = 100

        CamDGV.Columns(5).HeaderText = "Tel 1"
        CamDGV.Columns(5).Width = 100

    End Sub

    Private Sub CamDGV_Click(sender As Object, e As EventArgs) Handles CamDGV.Click
        If Me.CamDGV.RowCount = 0 Then
            MessageBox.Show("No hay datos a mostrar")
        Else
            Dim i As Integer = Me.CamDGV.CurrentRow.Index
            Me.placaBusqTB.Text = Me.CamDGV.Item(1, i).Value

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
            consulta = "SELECT * FROM propietario WHERE codigoP = '" & buscartxt.Text & "'"
            adaptador = New MySqlDataAdapter(consulta, con)
            datos = New DataSet
            adaptador.Fill(datos, "propietario")
            lista = datos.Tables("propietario").Rows.Count
        End If

        If lista <> 0 Then
            codProTb.Text = datos.Tables("propietario").Rows(0).Item("codProP").ToString
            nEmpresaTb.Text = datos.Tables("propietario").Rows(0).Item("nEmpresa").ToString
            nPropietarioTb.Text = datos.Tables("propietario").Rows(0).Item("nPropietario").ToString
            RTNTb.Text = datos.Tables("propietario").Rows(0).Item("RTN").ToString
            Tel1TB.Text = datos.Tables("propietario").Rows(0).Item("Tel1").ToString
            Tel2Tb.Text = datos.Tables("propietario").Rows(0).Item("Tel2").ToString
            DireccionTb.Text = datos.Tables("propietario").Rows(0).Item("Direccion").ToString
            correoETb.Text = datos.Tables("propietario").Rows(0).Item("correoE").ToString
        Else
            MsgBox("Datos no encontrados")
        End If
        listadoCamDgv()
    End Sub

    Private Sub placaBusqTB_TextChanged(sender As Object, e As EventArgs) Handles placaBusqTB.TextChanged
        codCamDgv()
    End Sub
    Private Sub codCamDgv() 'Autobusqueda Codigo
        Dim table As New DataTable()
        Dim adaptadoListado As New MySqlDataAdapter("SELECT * FROM propietario WHERE codProp LIKE '%" & placaBusqTB.Text & "%'", con)
        adaptadoListado.Fill(table)

        CamDGV.DataSource = table

        ListadoD()

    End Sub
    Private Sub propBusqTB_TextChanged(sender As Object, e As EventArgs) Handles propBusqTB.TextChanged
        propCamDgv()
    End Sub
    Private Sub propCamDgv()
        Dim table As New DataTable()
        Dim adaptadoListado As New MySqlDataAdapter("SELECT * FROM propietario WHERE nPropietario LIKE '%" & propBusqTB.Text & "%'", con)
        adaptadoListado.Fill(table)

        CamDGV.DataSource = table

        ListadoD()
    End Sub
    Private Sub ButtonX6_Click(sender As Object, e As EventArgs) Handles ButtonX6.Click
        propBusqTB.Text = ""
        placaBusqTB.Text = ""
        buscartxt.Text = ""

        EditarBtn.Enabled = False
        EliminarBtn.Enabled = False

        Me.codProTb.Text = ""
        Me.nEmpresaTb.Text = ""
        Me.nPropietarioTb.Text = ""
        Me.RTNTb.Text = ""
        Me.Tel1TB.Text = ""
        Me.Tel2Tb.Text = ""
        Me.DireccionTb.Text = ""
        Me.correoETb.Text = ""

    End Sub


End Class