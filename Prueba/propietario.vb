Imports System.Data
Imports MySql.Data.MySqlClient
Imports MySql.Data

Module Globales
    Public facturaF As factura
End Module
Public Class propietario
    Dim adaptador As New MySqlDataAdapter
    Dim datos As DataSet

    Private isMouseDown As Boolean = False
    Private mouseOffset As Point

    Dim colorFondo = Color.FromArgb(106, 126, 168)
    Dim colorTextbox = Color.FromArgb(240, 210, 249)



    Private Sub propietario_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        act()
        listadoCamDgv()
        EstilizarDataGridView(CamDGV)
        EstilizarDataGridView(PlacasDGV)

        PanelP.Enabled = False
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
        If ModuloConexion.EsSoloLectura() Then NuevoBtn.Enabled = False
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
        If Me.codProTb.Text = "" Or Me.nEmpresaTb.Text = "" Or Me.nPropietarioTb.Text = "" Or Me.RTNTb.Text = "" Or Me.Tel1TB.Text = "" Or Me.Tel2Tb.Text = "" Or Me.DireccionTb.Text = "" Or Me.correoETb.Text = "" Then
            MsgBox("Existen Campos vacíos, colocar 'X' en caso de no contar con datos")
        Else
            Try
                Using conLocal As MySqlConnection = ModuloConexion.ObtenerConexion()
                    conLocal.Open()
                    Using cmd As New MySqlCommand("INSERT INTO propietario (codProp, nEmpresa, nPropietario, RTN, tel1, tel2, direccion, correoE) VALUES(@codProp, @nEmpresa, @nPropietario, @RTN, @tel1, @tel2, @direccion, @correoE)", conLocal)
                        cmd.Parameters.AddWithValue("@codProp", codProTb.Text.Trim())
                        cmd.Parameters.AddWithValue("@nEmpresa", nEmpresaTb.Text.Trim())
                        cmd.Parameters.AddWithValue("@nPropietario", nPropietarioTb.Text.Trim())
                        cmd.Parameters.AddWithValue("@RTN", RTNTb.Text.Trim())
                        cmd.Parameters.AddWithValue("@tel1", Tel1TB.Text.Trim())
                        cmd.Parameters.AddWithValue("@tel2", Tel2Tb.Text.Trim())
                        cmd.Parameters.AddWithValue("@direccion", DireccionTb.Text.Trim())
                        cmd.Parameters.AddWithValue("@correoE", correoETb.Text.Trim())
                        cmd.ExecuteNonQuery()
                    End Using
                End Using

                MsgBox("Registro guardado correctamente", MsgBoxStyle.Information, "Éxito")
                limpiar()
                act()
                CamDGV.Enabled = True
                listadoCamDgv()

            Catch ex As MySqlException
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
        Try
            Using conLocal As MySqlConnection = ModuloConexion.ObtenerConexion()
                conLocal.Open()
                Using cmd As New MySqlCommand("UPDATE propietario SET codProp=@codProp, nEmpresa=@nEmpresa, nPropietario=@nPropietario, RTN=@RTN, tel1=@tel1, tel2=@tel2, direccion=@direccion, correoE=@correoE WHERE codigoP=@codigoP", conLocal)
                    cmd.Parameters.AddWithValue("@codProp", codProTb.Text)
                    cmd.Parameters.AddWithValue("@nEmpresa", nEmpresaTb.Text)
                    cmd.Parameters.AddWithValue("@nPropietario", nPropietarioTb.Text)
                    cmd.Parameters.AddWithValue("@RTN", RTNTb.Text)
                    cmd.Parameters.AddWithValue("@tel1", Tel1TB.Text)
                    cmd.Parameters.AddWithValue("@tel2", Tel2Tb.Text)
                    cmd.Parameters.AddWithValue("@direccion", DireccionTb.Text)
                    cmd.Parameters.AddWithValue("@correoE", correoETb.Text)
                    cmd.Parameters.AddWithValue("@codigoP", buscartxt.Text)
                    cmd.ExecuteNonQuery()
                End Using
            End Using
            MsgBox("Registro Actualizado")
        Catch ex As Exception
            MsgBox("Error al actualizar: " & ex.Message)
        End Try
    End Sub
    Private Sub EliminarBtn_Click(sender As Object, e As EventArgs) Handles EliminarBtn.Click  '============== ELIMINAR =============
        Try
            Dim opc As DialogResult = MsgBox("¿Desea Eliminar este registro?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Eliminar")
            If opc = Windows.Forms.DialogResult.Yes Then
                Using conLocal As MySqlConnection = ModuloConexion.ObtenerConexion()
                    conLocal.Open()
                    Using cmd As New MySqlCommand("DELETE FROM propietario WHERE codigoP = @codigoP", conLocal)
                        cmd.Parameters.AddWithValue("@codigoP", Conversion.Int(Me.buscartxt.Text))
                        cmd.ExecuteNonQuery()
                    End Using
                End Using

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
            Dim table As New DataTable()
            Using conLocal As MySqlConnection = ModuloConexion.ObtenerConexion()
                conLocal.Open()
                Using adaptadoListado As New MySqlDataAdapter("SELECT codigoP, codProp, nPropietario, nEmpresa, RTN, tel1, tel2 FROM propietario", conLocal)
                    adaptadoListado.Fill(table)
                End Using
            End Using

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

                Me.EditarBtn.Enabled = Not ModuloConexion.EsSoloLectura()
                Me.EliminarBtn.Enabled = Not ModuloConexion.EsSoloLectura()
            End If
        Catch ex As Exception
            MessageBox.Show("Error al seleccionar registro: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Sub seleccion()
        Try
            Dim lista As Integer = 0

            If buscartxt.Text <> "" Then
                Using conLocal As MySqlConnection = ModuloConexion.ObtenerConexion()
                    conLocal.Open()
                    Using cmd As New MySqlCommand("SELECT * FROM propietario WHERE codigoP = @codigoP", conLocal)
                        cmd.Parameters.AddWithValue("@codigoP", buscartxt.Text)
                        adaptador = New MySqlDataAdapter(cmd)
                        datos = New DataSet
                        adaptador.Fill(datos, "propietario")
                    End Using
                End Using
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
            Dim table As New DataTable()
            Using conLocal As MySqlConnection = ModuloConexion.ObtenerConexion()
                conLocal.Open()
                Using cmd As New MySqlCommand("SELECT * FROM propietario WHERE codProp LIKE @codProp", conLocal)
                    cmd.Parameters.AddWithValue("@codProp", "%" & placaBusqTB.Text & "%")
                    Using adaptadoListado As New MySqlDataAdapter(cmd)
                        adaptadoListado.Fill(table)
                    End Using
                End Using
            End Using

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
            Dim table As New DataTable()
            Using conLocal As MySqlConnection = ModuloConexion.ObtenerConexion()
                conLocal.Open()
                Using cmd As New MySqlCommand("SELECT * FROM propietario WHERE nPropietario LIKE @nPropietario", conLocal)
                    cmd.Parameters.AddWithValue("@nPropietario", "%" & propBusqTB.Text & "%")
                    Using adaptadoListado As New MySqlDataAdapter(cmd)
                        adaptadoListado.Fill(table)
                    End Using
                End Using
            End Using

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

            Dim table As New DataTable()
            Using conLocal As MySqlConnection = ModuloConexion.ObtenerConexion()
                conLocal.Open()
                Using cmd As New MySqlCommand("SELECT codigoPro AS 'Código Prop.', placa AS 'Placa', propietario AS 'Propietario', CASE WHEN activo = 1 THEN 'Activo' ELSE 'Bloqueado' END AS 'Estado' FROM placa WHERE codigoPro = @codigoPro", conLocal)
                    cmd.Parameters.AddWithValue("@codigoPro", codigoPropietario)
                    Using adaptadorPlacas As New MySqlDataAdapter(cmd)
                        adaptadorPlacas.Fill(table)
                    End Using
                End Using
            End Using

            PlacasDGV.DataSource = table

            If PlacasDGV.Columns.Count > 0 Then
                PlacasDGV.Columns(0).Width = 90
                PlacasDGV.Columns(1).Width = 90
                PlacasDGV.Columns(2).Width = 200
                If PlacasDGV.Columns.Count > 3 Then
                    PlacasDGV.Columns(3).Width = 70
                End If
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