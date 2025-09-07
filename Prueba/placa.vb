Imports System.Data
Imports MySql.Data.MySqlClient
Imports MySql.Data
Public Class placa
    Dim cm As New MySqlCommand
    Dim guardar As New MySqlCommand
    Dim adaptador As New MySqlDataAdapter
    Dim datos As DataSet
    Dim dr As MySqlDataReader
    Private m_tmr As Timer
    Public img As Image
    Dim con As New MySqlConnection

    Dim colorFondo = Color.FromArgb(106, 126, 168)
    Dim colorTextbox = Color.FromArgb(240, 210, 249)
    Private Sub placa_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        conectar()
        propiet()
        placaAutoC()


        act()
        listadoCamDgv()
        CamDGV.BackgroundColor = colorFondo
        CamDGV.RowsDefaultCellStyle.BackColor = Color.Bisque
        CamDGV.AlternatingRowsDefaultCellStyle.BackColor = Color.Lavender

        Me.BackColor = Color.SteelBlue

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

        Dim servidor As String = "localhost"
        'Dim servidor As String = "192.168.68.101"
        Dim baseDatos As String = "givemefuel"
        Dim userid As String = "root"
        Dim clave As String = ""


        'con.ConnectionString = "Server=168.119.90.215; Database=datasafe_eda; Uid=datasafe_edausr; Pwd=@Paradoja18"

        'con.ConnectionString = "Server=185.224.137.172; Database=u282951626_eda; Uid=u282951626_edauser; Pwd=@Paradoja18"

        con.ConnectionString = "Server=" & servidor & "; Database=" & baseDatos & "; Uid = " & userid & "; Pwd = " & clave

        Try

            con.Open()

            'MsgBox("El sistema se conectó")
            MessageBox.Show("El sistema esá conectado", "Combustible")

        Catch ex As Exception
            MsgBox("No se conecto por: " & ex.Message)

        End Try


    End Sub

    Public Sub placaAutoC()
        con.Close()
        Try
            Dim query As String = "SELECT codProp FROM propietario;"

            Dim autoCompleteSource As New AutoCompleteStringCollection()


            Using cmd As New MySqlCommand(query, con)
                con.Open()
                Dim reader As MySqlDataReader = cmd.ExecuteReader()

                While reader.Read()
                    autoCompleteSource.Add(reader("codProp").ToString())
                End While

                reader.Close()
            End Using

            'placaCbzTb.AutoCompleteMode = AutoCompleteMode.Suggest
            'placaCbzTb.AutoCompleteSource = autoCompleteSource.cu
            codTb.AutoCompleteCustomSource = autoCompleteSource
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        Finally
            conexion.Close()
        End Try
    End Sub
    Public Sub propiet()
        con.Close()
        Try
            Dim query As String = "SELECT nPropietario FROM propietario;"

            Dim autoCompleteSource As New AutoCompleteStringCollection()


            Using cmd As New MySqlCommand(query, con)
                con.Open()
                Dim reader As MySqlDataReader = cmd.ExecuteReader()

                While reader.Read()
                    autoCompleteSource.Add(reader("nPropietario").ToString())
                End While

                reader.Close()
            End Using

            'placaCbzTb.AutoCompleteMode = AutoCompleteMode.Suggest
            'placaCbzTb.AutoCompleteSource = autoCompleteSource.cu
            propTb.AutoCompleteCustomSource = autoCompleteSource
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        Finally
            conexion.Close()
        End Try
    End Sub
    Private Sub listadoCamDgv() 'Muestra los datos
        Dim table As New DataTable()
        Dim adaptadoListado As New MySqlDataAdapter("SELECT idPlaca, codigoPro, placa, propietario,  observaciones FROM placa", con)
        adaptadoListado.Fill(table)

        CamDGV.DataSource = table

        ListadoD()

    End Sub
    Private Sub ListadoD()
        CamDGV.Columns(0).HeaderText = "Id"
        CamDGV.Columns(0).Width = 1

        CamDGV.Columns(1).HeaderText = "Placa"
        CamDGV.Columns(1).Width = 100

        CamDGV.Columns(2).HeaderText = "Codigo"
        CamDGV.Columns(2).Width = 75

        CamDGV.Columns(3).HeaderText = "Propietario"
        CamDGV.Columns(3).Width = 200
    End Sub
    Sub limpiar()
        Me.codTb.Text = ""
        Me.propTb.Text = ""
        Me.placaTb.Text = ""
        Me.obserTb.Text = ""
    End Sub
    Private Sub NuevoBtn_Click(sender As Object, e As EventArgs) Handles NuevoBtn.Click  '============  NUEVO  ===========
        limpiar()
        PanelP.Enabled = True
        GuardarBtn.Enabled = True
        CamDGV.Enabled = False
        CancelarBtn.Enabled = True
        NuevoBtn.Enabled = False
    End Sub
    Private Sub EditarBtn_Click(sender As Object, e As EventArgs) Handles EditarBtn.Click  '============ EDITAR  ===========
        PanelP.Enabled = True
        Me.CamDGV.Enabled = False
        Me.GuardarBtn.Enabled = False
        Me.GuardarBtn.Visible = False +
        Me.ModificarBtn.Enabled = True
        Me.EditarBtn.Enabled = False
        Me.CancelarBtn.Enabled = True
        Me.NuevoBtn.Enabled = False
        Me.EliminarBtn.Enabled = False

    End Sub
    Private Sub GuardarBtn_Click(sender As Object, e As EventArgs) Handles GuardarBtn.Click  '============ GUARDAR  ===========
        con.Close()
        con.Open()
        Try

            guardar = New MySqlCommand("INSERT INTO placa (codigoPro, propietario, placa, observaciones)" & Chr(13) &
            "VALUES(@codigoPro, @propietario, @placa, @observaciones)", con)


            guardar.Parameters.AddWithValue("@codigoPro", codTb.Text)
            guardar.Parameters.AddWithValue("@propietario", propTb.Text)
            guardar.Parameters.AddWithValue("@placa", placaTb.Text)
            guardar.Parameters.AddWithValue("@observaciones", obserTb.Text)


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
    Private Sub ModificarBtn_Click(sender As Object, e As EventArgs) Handles ModificarBtn.Click  '============ MODIFICAR  ===========
        actual()
        act()
        PanelP.Enabled = False
        CamDGV.Enabled = True
        Me.GuardarBtn.Visible = True
        listadoCamDgv()
    End Sub
    Public Sub actual()
        Dim actualizar As String
        actualizar = "UPDATE placa SET codigoPro = '" & codTb.Text & "', placa = '" & placaTb.Text & "', observaciones = '" & obserTb.Text & "' WHERE idPlaca = '" & buscartxt.Text & "'"
        Dim act As New MySqlCommand(actualizar, con)
        act.ExecuteNonQuery()
        MsgBox("Registo Actualizado")
    End Sub
    Private Sub EliminarBtn_Click(sender As Object, e As EventArgs) Handles EliminarBtn.Click  '============ ELIMINAR  ===========
        Try

            Dim opc As DialogResult = MsgBox("¿Desea Eliminar este registro?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Eliminar")
            If opc = Windows.Forms.DialogResult.Yes Then

                Dim eliminar As String

                eliminar = "DELETE FROM placas WHERE idplaca = '" & Conversion.Int(Me.buscartxt.Text) & "'"
                Dim eli As New MySqlCommand(eliminar, con)
                eli.ExecuteNonQuery()

                listadoCamDgv()

            End If
        Catch
            MessageBox.Show("Actualización Base de Datos, " & Chr(13) & "favor escoger de nuevo el registro y eliminarlo", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)

        End Try

        act()
    End Sub
    Private Sub CancelarBtn_Click(sender As Object, e As EventArgs) Handles CancelarBtn.Click  '============ CANCELAR  ===========
        act()
        PanelP.Enabled = False
        CamDGV.Enabled = True
        Me.GuardarBtn.Visible = True
    End Sub

    Private Sub CamDGV_Click(sender As Object, e As EventArgs) Handles CamDGV.Click
        If Me.CamDGV.RowCount = 0 Then
            MessageBox.Show("No hay datos a mostrar")
        Else
            Dim i As Integer = Me.CamDGV.CurrentRow.Index
            Me.placaBusqTB.Text = Me.CamDGV.Item(1, i).Value
            PanelP.Enabled = True 'Para que se vea el Panel
            Dim y As Integer = Me.CamDGV.CurrentRow.Index
            Dim idcod As Integer = Me.CamDGV.Item(0, y).Value
            buscartxt.Text = idcod
            Seleccion()
            Me.EditarBtn.Enabled = True
            Me.EliminarBtn.Enabled = True
        End If
    End Sub
    Public Sub Seleccion()
        Dim consulta As String
        Dim lista As Byte

        If placaBusqTB.Text <> "" Then
            consulta = "SELECT * FROM placa WHERE idPlaca = '" & buscartxt.Text & "'"
            adaptador = New MySqlDataAdapter(consulta, con)
            datos = New DataSet
            adaptador.Fill(datos, "placa")
            lista = datos.Tables("placa").Rows.Count
        End If

        If lista <> 0 Then

            codTb.Text = datos.Tables("placa").Rows(0).Item("codigoPro").ToString
            propTb.Text = datos.Tables("placa").Rows(0).Item("propietario").ToString
            placaTb.Text = datos.Tables("placa").Rows(0).Item("placa").ToString
            obserTb.Text = datos.Tables("placa").Rows(0).Item("observaciones").ToString

        Else
            MsgBox("Datos no encontrados")
        End If
        'listadoCamDgv()
    End Sub

    Private Sub propTb_KeyDown(sender As Object, e As KeyEventArgs) Handles propTb.KeyDown
        If e.KeyCode = Keys.Enter Then
            Seleccion2()
        End If
        If e.KeyCode = Keys.Delete Then
            propTb.Text = ""
        End If
    End Sub
    Public Sub Seleccion2()
        Dim consulta As String
        Dim lista As Byte

        If propTb.Text <> "" Then
            consulta = "SELECT * FROM propietario WHERE nPropietario = '" & propTb.Text & "'"
            adaptador = New MySqlDataAdapter(consulta, con)
            datos = New DataSet
            adaptador.Fill(datos, "propietario")
            lista = datos.Tables("propietario").Rows.Count
        End If

        If lista <> 0 Then
            codTb.Text = datos.Tables("propietario").Rows(0).Item("codProP").ToString
        Else
            MsgBox("Datos no encontrados")
        End If
        'listadoCamDgv()
    End Sub
    Private Sub codTb_KeyDown(sender As Object, e As KeyEventArgs) Handles codTb.KeyDown
        If e.KeyCode = Keys.Enter Then
            Seleccion3()
        End If
        If e.KeyCode = Keys.Delete Then
            codTb.Text = ""
        End If
    End Sub
    Public Sub Seleccion3()
        Dim consulta As String
        Dim lista As Byte

        If codTb.Text <> "" Then
            consulta = "SELECT * FROM propietario WHERE codProp  = '" & codTb.Text & "'"
            adaptador = New MySqlDataAdapter(consulta, con)
            datos = New DataSet
            adaptador.Fill(datos, "propietario")
            lista = datos.Tables("propietario").Rows.Count
        End If

        If lista <> 0 Then
            propTb.Text = datos.Tables("propietario").Rows(0).Item("nPropietario").ToString
        Else
            MsgBox("Datos no encontrados")
        End If
        'listadoCamDgv()
    End Sub

    Private Sub CamDGV_MouseLeave(sender As Object, e As EventArgs) Handles CamDGV.MouseLeave
        PanelP.Enabled = False
    End Sub

    Private Sub CamDGV_MouseEnter(sender As Object, e As EventArgs) Handles CamDGV.MouseEnter
        PanelP.Enabled = True
    End Sub
End Class