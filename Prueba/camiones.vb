Imports System.Data
Imports MySql.Data.MySqlClient
Imports MySql.Data
Public Class camiones
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

        conectar()
        act()
        listadoCamDgv()
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

    Private Sub TextBoxX7_TextChanged(sender As Object, e As EventArgs) Handles cAduaneTb.TextChanged

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

            guardar = New MySqlCommand("INSERT INTO camiones (placa, propietario, documentos, revision, contrato, tmpContrato, codAduanero, codProp)" & Chr(13) &
            "VALUES(@placa, @propietario, @documentos, @revision, @contrato, @tmpContrato, @codAduanero, @codProp)", con)

            guardar.Parameters.AddWithValue("@placa", PlacTb.Text)
            guardar.Parameters.AddWithValue("@propietario", propTb.Text)
            guardar.Parameters.AddWithValue("@documentos", docTb.Text)
            guardar.Parameters.AddWithValue("@revision", reviTb.Text)
            guardar.Parameters.AddWithValue("@contrato", contraTb.Text)
            guardar.Parameters.AddWithValue("@tmpContrato", tContraTb.Text)
            guardar.Parameters.AddWithValue("@codAduanero", cAduaneTb.Text)
            guardar.Parameters.AddWithValue("@codProp", codePTb.Text)

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
        actualizar = "UPDATE camiones SET placa = '" & PlacTb.Text & "', propietario= '" & propTb.Text & "', documentos= '" & docTb.Text & "', revision= '" & reviTb.Text & "', contrato= '" & contraTb.Text & "', tmpContrato= '" & tContraTb.Text & "', codAduanero= '" & cAduaneTb.Text & "', codProp= '" & codePTb.Text & "' WHERE idCamiones = '" & buscartxt.Text & "'"
        Dim act As New MySqlCommand(actualizar, con)
        act.ExecuteNonQuery()
        MsgBox("Registo Actualizado")
    End Sub
    Private Sub EliminarBtn_Click(sender As Object, e As EventArgs) Handles EliminarBtn.Click '============  ELIMINAR  ===========
        Try

            Dim opc As DialogResult = MsgBox("¿Desea Eliminar este registro?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Eliminar")
            If opc = Windows.Forms.DialogResult.Yes Then

                Dim eliminar As String

                eliminar = "DELETE FROM camiones WHERE idCamiones = '" & Conversion.Int(Me.buscartxt.Text) & "'"
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
        Me.PlacTb.Text = ""
        Me.propTb.Text = ""
        Me.docTb.Text = ""
        Me.reviTb.Text = ""
        Me.contraTb.Text = ""
        Me.tContraTb.Text = ""
        Me.cAduaneTb.Text = ""
        Me.codePTb.Text = ""
    End Sub
    Private Sub ListadoD()
        CamDGV.Columns(0).HeaderText = "Id"
        CamDGV.Columns(0).Width = 1

        CamDGV.Columns(1).HeaderText = "Placa"
        CamDGV.Columns(1).Width = 100

        CamDGV.Columns(2).HeaderText = "Propietario"
        CamDGV.Columns(2).Width = 175

        CamDGV.Columns(3).HeaderText = "Documentos"
        CamDGV.Columns(3).Width = 75

        CamDGV.Columns(4).HeaderText = "Revision"
        CamDGV.Columns(4).Width = 50

        CamDGV.Columns(5).HeaderText = "Contrato"
        CamDGV.Columns(5).Width = 175

        CamDGV.Columns(6).HeaderText = "Código Propietario"
        CamDGV.Columns(6).Width = 90
    End Sub
    Private Sub placCamDgv() 'Autobusqueda PLACA
        Dim table As New DataTable()
        Dim adaptadoListado As New MySqlDataAdapter("SELECT idCamiones, placa, propietario, documentos, revision, contrato, codProp FROM camiones WHERE placa LIKE '%" & placaBusqTB.Text & "%'", con)
        adaptadoListado.Fill(table)

        CamDGV.DataSource = table

        ListadoD()

    End Sub
    Private Sub propCamDgv() 'Autobusqueda Propietario
        Dim table As New DataTable()
        Dim adaptadoListado As New MySqlDataAdapter("SELECT idCamiones, placa, propietario, documentos, revision, contrato, codProp FROM camiones WHERE propietario LIKE '%" & propBusqTB.Text & "%'", con)
        adaptadoListado.Fill(table)

        CamDGV.DataSource = table

        ListadoD()

    End Sub

    Private Sub listadoCamDgv() 'Muestra los datos
        Dim table As New DataTable()
        Dim adaptadoListado As New MySqlDataAdapter("SELECT idCamiones, placa, propietario, documentos, revision, contrato, codProp FROM camiones", con)
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

        PlacTb.Text = ""
        propTb.Text = ""
        docTb.Text = ""
        reviTb.Text = ""
        contraTb.Text = ""
        tContraTb.Text = ""
        cAduaneTb.Text = ""
        codePTb.Text = ""
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
            consulta = "SELECT * FROM camiones WHERE idCamiones = '" & buscartxt.Text & "'"
            adaptador = New MySqlDataAdapter(consulta, con)
            datos = New DataSet
            adaptador.Fill(datos, "camiones")
            lista = datos.Tables("camiones").Rows.Count
        End If

        If lista <> 0 Then
            PlacTb.Text = datos.Tables("camiones").Rows(0).Item("placa").ToString
            propTb.Text = datos.Tables("camiones").Rows(0).Item("propietario").ToString
            docTb.Text = datos.Tables("camiones").Rows(0).Item("documentos").ToString
            reviTb.Text = datos.Tables("camiones").Rows(0).Item("revision").ToString
            contraTb.Text = datos.Tables("camiones").Rows(0).Item("contrato").ToString
            tContraTb.Text = datos.Tables("camiones").Rows(0).Item("tmpContrato").ToString
            cAduaneTb.Text = datos.Tables("camiones").Rows(0).Item("codAduanero").ToString
            codePTb.Text = datos.Tables("camiones").Rows(0).Item("codProp").ToString

        Else
            MsgBox("Datos no encontrados")
        End If
        listadoCamDgv()
    End Sub
End Class
