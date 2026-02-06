Imports System.Data
Imports MySql.Data.MySqlClient
Imports MySql.Data

Module Globales
    Public facturaF As factura
End Module
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
        EstilizarDataGridView(CamDGV)
        EstilizarDataGridView(PlacasDGV)

        PanelP.Enabled = False

    End Sub

    Private Sub propietario_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        ' Cerrar la conexión al cerrar el formulario
        Try
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
        Catch ex As Exception
            ' Ignorar errores al cerrar la conexión
        End Try
    End Sub
    Private Sub conectar()
        con = ModuloConexion.ObtenerConexion()
        Try
            If con.State = ConnectionState.Broken Or con.State = ConnectionState.Closed Then
                If con.State = ConnectionState.Broken Then
                    con.Close()
                End If
                con.Open()
                MessageBox.Show("El sistema está conectado", "Combustible")
            End If
        Catch ex As Exception
            MsgBox("No se conecto por: " & ex.Message)
        End Try
    End Sub

    Private Sub VerificarConexion()
        Try
            ' Si la conexión está cerrada o rota, reconectar
            If con.State = ConnectionState.Broken Then
                con.Close()
            End If
            If con.State = ConnectionState.Closed Then
                con.Open()
            End If
        Catch ex As Exception
            ' Intentar reconectar en caso de error
            Try
                con.Close()
                con.Open()
            Catch ex2 As Exception
                MsgBox("Error de conexión: " & ex2.Message)
            End Try
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
        NuevoBtn.Enabled = False

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
        ' Verificar y asegurar que la conexión esté abierta
        VerificarConexion()
        If Me.codProTb.Text = "" Or Me.nEmpresaTb.Text = "" Or Me.nPropietarioTb.Text = "" Or Me.RTNTb.Text = "" Or Me.Tel1TB.Text = "" Or Me.Tel2Tb.Text = "" Or Me.DireccionTb.Text = "" Or Me.correoETb.Text = "" Then
            MsgBox("Existen Campos vacíos, colocar 'X' en caso de no contar con datos")

        Else
            Try
                ' Limpiar parámetros previos si existen
                guardar.Parameters.Clear()

                guardar = New MySqlCommand("INSERT INTO propietario (codProp, nEmpresa, nPropietario, RTN, tel1, tel2, direccion, correoE) VALUES(@codProp, @nEmpresa, @nPropietario, @RTN, @tel1, @tel2, @direccion, @correoE)", con)

                guardar.Parameters.AddWithValue("@codProp", codProTb.Text.Trim())
                guardar.Parameters.AddWithValue("@nEmpresa", nEmpresaTb.Text.Trim())
                guardar.Parameters.AddWithValue("@nPropietario", nPropietarioTb.Text.Trim())
                guardar.Parameters.AddWithValue("@RTN", RTNTb.Text.Trim())
                guardar.Parameters.AddWithValue("@tel1", Tel1TB.Text.Trim())
                guardar.Parameters.AddWithValue("@tel2", Tel2Tb.Text.Trim())
                guardar.Parameters.AddWithValue("@direccion", DireccionTb.Text.Trim())
                guardar.Parameters.AddWithValue("@correoE", correoETb.Text.Trim())

                guardar.ExecuteNonQuery()
                MsgBox("Registro guardado correctamente", MsgBoxStyle.Information, "Éxito")

                ' Solo ejecutar estas líneas si el guardado fue exitoso
                limpiar()
                act()
                CamDGV.Enabled = True
                listadoCamDgv()

            Catch ex As MySqlException
                ' Error específico de MySQL
                MsgBox("Error al guardar el registro: " & ex.Message & vbCrLf & "Código de error MySQL: " & ex.Number.ToString(), MsgBoxStyle.Critical, "Error de Base de Datos")
            Catch ex As Exception
                MsgBox("Elemento no pudo ser almacenado: " & ex.Message & vbCrLf & "Tipo de error: " & ex.GetType().Name, MsgBoxStyle.Critical, "Error")
            End Try
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
        ' Verificar que la conexión esté abierta
        VerificarConexion()

        Try
            Dim act As New MySqlCommand("UPDATE propietario SET codProp=@codProp, nEmpresa=@nEmpresa, nPropietario=@nPropietario, RTN=@RTN, tel1=@tel1, tel2=@tel2, direccion=@direccion, correoE=@correoE WHERE codigoP=@codigoP", con)
            act.Parameters.AddWithValue("@codProp", codProTb.Text)
            act.Parameters.AddWithValue("@nEmpresa", nEmpresaTb.Text)
            act.Parameters.AddWithValue("@nPropietario", nPropietarioTb.Text)
            act.Parameters.AddWithValue("@RTN", RTNTb.Text)
            act.Parameters.AddWithValue("@tel1", Tel1TB.Text)
            act.Parameters.AddWithValue("@tel2", Tel2Tb.Text)
            act.Parameters.AddWithValue("@direccion", DireccionTb.Text)
            act.Parameters.AddWithValue("@correoE", correoETb.Text)
            act.Parameters.AddWithValue("@codigoP", buscartxt.Text)
            act.ExecuteNonQuery()
            MsgBox("Registro Actualizado")
        Catch ex As Exception
            MsgBox("Error al actualizar: " & ex.Message)
        End Try
    End Sub
    Private Sub EliminarBtn_Click(sender As Object, e As EventArgs) Handles EliminarBtn.Click  '============== ELIMINAR =============
        Try
            Dim opc As DialogResult = MsgBox("¿Desea Eliminar este registro?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Eliminar")
            If opc = Windows.Forms.DialogResult.Yes Then

                ' Verificar que la conexión esté abierta
                VerificarConexion()

                Dim eli As New MySqlCommand("DELETE FROM propietario WHERE codigoP = @codigoP", con)
                eli.Parameters.AddWithValue("@codigoP", Conversion.Int(Me.buscartxt.Text))
                eli.ExecuteNonQuery()

                MsgBox("Registro eliminado correctamente", MsgBoxStyle.Information, "Éxito")
                limpiar()
                listadoCamDgv()
            End If
        Catch ex As Exception
            MessageBox.Show("Error al eliminar: " & ex.Message & Chr(13) & "Favor escoger de nuevo el registro e intentar eliminarlo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
        Try
            ' Verificar que la conexión esté abierta
            VerificarConexion()

            Dim table As New DataTable()
            Dim adaptadoListado As New MySqlDataAdapter("SELECT codigoP, codProp, nPropietario, nEmpresa, RTN, tel1, tel2 FROM propietario", con)
            adaptadoListado.Fill(table)

            CamDGV.DataSource = table

            ListadoD()
        Catch ex As Exception
            MessageBox.Show("Error al cargar datos: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
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
        Try
            If Me.CamDGV.RowCount = 0 Then
                MessageBox.Show("No hay datos a mostrar")
            Else
                Dim i As Integer = Me.CamDGV.CurrentRow.Index
                Dim codigoProp As String = Me.CamDGV.Item(1, i).Value.ToString()
                Me.placaBusqTB.Text = codigoProp

                Dim y As Integer = Me.CamDGV.CurrentRow.Index
                Dim idcod As Integer = Me.CamDGV.Item(0, y).Value
                buscartxt.Text = idcod
                seleccion()

                ' Cargar las placas del propietario seleccionado
                cargarPlacasPropietario(codigoProp)

                Me.EditarBtn.Enabled = True
                Me.EliminarBtn.Enabled = True
            End If
        Catch ex As Exception
            MessageBox.Show("Error al seleccionar registro: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Sub seleccion()
        Try
            Dim consulta As String
            Dim lista As Integer = 0

            If buscartxt.Text <> "" Then
                ' Verificar que la conexión esté abierta
                VerificarConexion()

                consulta = "SELECT * FROM propietario WHERE codigoP = @codigoP"
                Dim cmd As New MySqlCommand(consulta, con)
                cmd.Parameters.AddWithValue("@codigoP", buscartxt.Text)
                adaptador = New MySqlDataAdapter(cmd)
                datos = New DataSet
                adaptador.Fill(datos, "propietario")
                lista = datos.Tables("propietario").Rows.Count
            End If

            If lista <> 0 Then
                codProTb.Text = datos.Tables("propietario").Rows(0).Item("codProp").ToString
                nEmpresaTb.Text = datos.Tables("propietario").Rows(0).Item("nEmpresa").ToString
                nPropietarioTb.Text = datos.Tables("propietario").Rows(0).Item("nPropietario").ToString
                RTNTb.Text = datos.Tables("propietario").Rows(0).Item("RTN").ToString
                Tel1TB.Text = datos.Tables("propietario").Rows(0).Item("tel1").ToString
                Tel2Tb.Text = datos.Tables("propietario").Rows(0).Item("tel2").ToString
                DireccionTb.Text = datos.Tables("propietario").Rows(0).Item("direccion").ToString
                correoETb.Text = datos.Tables("propietario").Rows(0).Item("correoE").ToString
            Else
                MsgBox("Datos no encontrados")
            End If
        Catch ex As Exception
            MessageBox.Show("Error al seleccionar datos: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub placaBusqTB_TextChanged(sender As Object, e As EventArgs) Handles placaBusqTB.TextChanged
        codCamDgv()
    End Sub
    Private Sub codCamDgv() 'Autobusqueda Codigo
        Try
            ' Verificar que la conexión esté abierta
            VerificarConexion()

            Dim table As New DataTable()
            Dim cmd As New MySqlCommand("SELECT * FROM propietario WHERE codProp LIKE @codProp", con)
            cmd.Parameters.AddWithValue("@codProp", "%" & placaBusqTB.Text & "%")
            Dim adaptadoListado As New MySqlDataAdapter(cmd)
            adaptadoListado.Fill(table)

            CamDGV.DataSource = table

            ListadoD()
        Catch ex As Exception
            MessageBox.Show("Error en búsqueda por código: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub propBusqTB_TextChanged(sender As Object, e As EventArgs) Handles propBusqTB.TextChanged
        propCamDgv()
    End Sub
    Private Sub propCamDgv()
        Try
            ' Verificar que la conexión esté abierta
            VerificarConexion()

            Dim table As New DataTable()
            Dim cmd As New MySqlCommand("SELECT * FROM propietario WHERE nPropietario LIKE @nPropietario", con)
            cmd.Parameters.AddWithValue("@nPropietario", "%" & propBusqTB.Text & "%")
            Dim adaptadoListado As New MySqlDataAdapter(cmd)
            adaptadoListado.Fill(table)

            CamDGV.DataSource = table

            ListadoD()
        Catch ex As Exception
            MessageBox.Show("Error en búsqueda por propietario: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' Método para cargar las placas del propietario seleccionado
    Private Sub cargarPlacasPropietario(codigoPropietario As String)
        Try
            If String.IsNullOrEmpty(codigoPropietario) Then
                PlacasDGV.DataSource = Nothing
                Return
            End If

            ' Verificar que la conexión esté abierta
            VerificarConexion()

            Dim table As New DataTable()
            Dim cmd As New MySqlCommand("SELECT codigoPro AS 'Código Prop.', placa AS 'Placa', propietario AS 'Propietario' FROM placa WHERE codigoPro = @codigoPro", con)
            cmd.Parameters.AddWithValue("@codigoPro", codigoPropietario)
            Dim adaptadorPlacas As New MySqlDataAdapter(cmd)
            adaptadorPlacas.Fill(table)

            PlacasDGV.DataSource = table

            ' Configurar anchos de columnas si hay datos
            If PlacasDGV.Columns.Count > 0 Then
                PlacasDGV.Columns(0).Width = 100  ' Código Prop.
                PlacasDGV.Columns(1).Width = 100  ' Placa
                PlacasDGV.Columns(2).Width = 250  ' Propietario
            End If

        Catch ex As Exception
            MessageBox.Show("Error al cargar placas: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
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

        ' Limpiar el DataGridView de placas
        PlacasDGV.DataSource = Nothing

        ' Recargar el listado completo
        listadoCamDgv()
    End Sub

    Private Sub EnviarTb_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If facturaF IsNot Nothing Then
            facturaF.LabelX1.Text = Me.nPropietarioTb.Text
            'factura.LabelX1.Text = Me.Label1.Text
            'Me.placaBusqTB.Text = nPropietarioTb.Text
        End If
    End Sub
End Class