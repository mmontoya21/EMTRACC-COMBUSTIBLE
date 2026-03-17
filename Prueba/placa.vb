Imports System.Data
Imports System.IO
Imports System.Text
Imports MySql.Data.MySqlClient
Imports MySql.Data
Imports ClosedXML.Excel
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
        EstilizarDataGridView(CamDGV)

        Me.BackColor = Color.SteelBlue

        PanelP.Enabled = False

    End Sub

    Private Sub placa_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        ' Cerrar la conexión al cerrar el formulario
        Try
            If con IsNot Nothing AndAlso con.State = ConnectionState.Open Then
                con.Close()
            End If
        Catch ex As Exception
            ' Ignorar errores al cerrar
        End Try
    End Sub

    Private Sub act()
        Me.NuevoBtn.Enabled = True
        Me.EditarBtn.Enabled = False
        Me.GuardarBtn.Enabled = False
        Me.ModificarBtn.Enabled = False
        Me.CancelarBtn.Enabled = False
        Me.EliminarBtn.Enabled = False
        Me.BloquearBtn.Enabled = False
        Me.BloquearBtn.Text = "Bloquear"
        If ModuloConexion.EsSoloLectura() Then NuevoBtn.Enabled = False
    End Sub
    Private Sub conectar()
        con = ModuloConexion.ObtenerConexion()
        Try
            If con.State = ConnectionState.Closed Then
                con.Open()
                MessageBox.Show("El sistema está conectado", "Combustible")
            End If
        Catch ex As Exception
            MsgBox("No se conecto por: " & ex.Message)
        End Try
    End Sub

    Private Sub AbrirConexion()
        Try
            ' Si la conexión es nula o está rota, obtener una nueva
            If con Is Nothing OrElse con.State = ConnectionState.Broken Then
                con = ModuloConexion.ObtenerConexion()
            End If
            ' Abrir si está cerrada
            If con.State = ConnectionState.Closed Then
                con.Open()
            End If
        Catch ex As Exception
            MessageBox.Show("Error al abrir conexión: " & ex.Message, "Error")
        End Try
    End Sub

    Private Sub CerrarConexion()
        Try
            If con IsNot Nothing AndAlso con.State = ConnectionState.Open Then
                con.Close()
            End If
        Catch ex As Exception
            MessageBox.Show("Error al cerrar conexión: " & ex.Message, "Error")
        End Try
    End Sub

    Private Sub VerificarConexion()
        Try
            ' Si la conexión es nula o está rota, obtener una nueva
            If con Is Nothing OrElse con.State = ConnectionState.Broken Then
                con = ModuloConexion.ObtenerConexion()
            End If
            ' Abrir si está cerrada
            If con.State = ConnectionState.Closed Then
                con.Open()
            End If
        Catch ex As Exception
            MessageBox.Show("Error al verificar conexión: " & ex.Message, "Error")
        End Try
    End Sub

    Public Sub placaAutoC()
        Try
            Dim query As String = "SELECT codProp FROM propietario;"
            Dim autoCompleteSource As New AutoCompleteStringCollection()

            AbrirConexion()
            Using cmd As New MySqlCommand(query, con)
                Using reader As MySqlDataReader = cmd.ExecuteReader()
                    While reader.Read()
                        autoCompleteSource.Add(reader("codProp").ToString())
                    End While
                End Using
            End Using

            codTb.AutoCompleteCustomSource = autoCompleteSource
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        Finally
            CerrarConexion()
        End Try
    End Sub
    Public Sub propiet()
        Try
            Dim query As String = "SELECT nPropietario FROM propietario;"
            Dim autoCompleteSource As New AutoCompleteStringCollection()

            AbrirConexion()
            Using cmd As New MySqlCommand(query, con)
                Using reader As MySqlDataReader = cmd.ExecuteReader()
                    While reader.Read()
                        autoCompleteSource.Add(reader("nPropietario").ToString())
                    End While
                End Using
            End Using

            propTb.AutoCompleteCustomSource = autoCompleteSource
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        Finally
            CerrarConexion()
        End Try
    End Sub
    Private Sub listadoCamDgv() 'Muestra los datos
        Try
            Dim table As New DataTable()
            AbrirConexion()
            Using adaptadoListado As New MySqlDataAdapter("SELECT idPlaca, codigoPro, placa, propietario, observaciones, CASE WHEN activo = 1 THEN 'Activo' ELSE 'Bloqueado' END AS estado FROM placa", con)
                adaptadoListado.Fill(table)
            End Using

            CamDGV.DataSource = table
            ListadoD()
        Catch ex As Exception
            MessageBox.Show("Error al cargar datos: " & ex.Message, "Error")
        Finally
            CerrarConexion()
        End Try
    End Sub
    Private Sub ListadoD()
        If CamDGV.Columns.Count < 6 Then Return

        CamDGV.Columns(0).HeaderText = "Id"
        CamDGV.Columns(0).Width = 1
        CamDGV.Columns(0).Visible = False

        CamDGV.Columns(1).HeaderText = "Código"
        CamDGV.Columns(1).Width = 80

        CamDGV.Columns(2).HeaderText = "Placa"
        CamDGV.Columns(2).Width = 90

        CamDGV.Columns(3).HeaderText = "Propietario"
        CamDGV.Columns(3).Width = 220

        CamDGV.Columns(4).HeaderText = "Observaciones"
        CamDGV.Columns(4).Width = 200

        CamDGV.Columns(5).HeaderText = "Estado"
        CamDGV.Columns(5).Width = 80
    End Sub
    Sub limpiar()
        Me.codTb.Text = ""
        Me.propTb.Text = ""
        Me.placaTb.Text = ""
        Me.obserTb.Text = ""
        Me.buscartxt.Text = ""
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
        Me.GuardarBtn.Visible = False
        Me.ModificarBtn.Enabled = True
        Me.EditarBtn.Enabled = False
        Me.CancelarBtn.Enabled = True
        Me.NuevoBtn.Enabled = False
        Me.EliminarBtn.Enabled = False
        Me.ModificarBtn.Enabled = True
    End Sub
    Private Sub GuardarBtn_Click(sender As Object, e As EventArgs) Handles GuardarBtn.Click  '============ GUARDAR  ===========
        Try
            AbrirConexion()
            Using guardarCmd As New MySqlCommand("INSERT INTO placa (codigoPro, propietario, placa, observaciones, activo)" & Chr(13) &
                "VALUES(@codigoPro, @propietario, @placa, @observaciones, 1)", con)

                guardarCmd.Parameters.AddWithValue("@codigoPro", codTb.Text)
                guardarCmd.Parameters.AddWithValue("@propietario", propTb.Text)
                guardarCmd.Parameters.AddWithValue("@placa", placaTb.Text)
                guardarCmd.Parameters.AddWithValue("@observaciones", obserTb.Text)

                guardarCmd.ExecuteNonQuery()
                MsgBox("Registo guardado")
            End Using

            limpiar()
            act()
            CamDGV.Enabled = True
            listadoCamDgv()
        Catch ex As Exception
            MsgBox("Elemento no pudo se almacenado: " & ex.Message)
        Finally
            CerrarConexion()
        End Try
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
        Try
            AbrirConexion()
            Using cmd As New MySqlCommand("UPDATE placa SET codigoPro = @codigoPro, propietario = @propietario, placa = @placa, observaciones = @observaciones WHERE idPlaca = @idPlaca", con)
                cmd.Parameters.AddWithValue("@codigoPro", codTb.Text)
                cmd.Parameters.AddWithValue("@propietario", propTb.Text)
                cmd.Parameters.AddWithValue("@placa", placaTb.Text)
                cmd.Parameters.AddWithValue("@observaciones", obserTb.Text)
                cmd.Parameters.AddWithValue("@idPlaca", buscartxt.Text)
                cmd.ExecuteNonQuery()
            End Using
            MsgBox("Registro Actualizado")
        Catch ex As Exception
            MessageBox.Show("Error al actualizar: " & ex.Message, "Error")
        Finally
            CerrarConexion()
        End Try
    End Sub
    Private Sub EliminarBtn_Click(sender As Object, e As EventArgs) Handles EliminarBtn.Click  '============ ELIMINAR  ===========
        Try
            Dim opc As DialogResult = MessageBox.Show("¿Desea Eliminar este registro?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If opc = Windows.Forms.DialogResult.Yes Then
                If String.IsNullOrEmpty(buscartxt.Text) Then
                    MessageBox.Show("No se ha seleccionado un registro para eliminar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return
                End If

                AbrirConexion()
                Dim eliminar As String = "DELETE FROM placa WHERE idPlaca = @idPlaca"
                Using eli As New MySqlCommand(eliminar, con)
                    eli.Parameters.AddWithValue("@idPlaca", Conversion.Int(Me.buscartxt.Text))
                    eli.ExecuteNonQuery()
                    MessageBox.Show("Registro eliminado correctamente", "Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End Using

                limpiar()
                act()
                listadoCamDgv()
            End If
        Catch ex As Exception
            MessageBox.Show("Error al eliminar registro: " & ex.Message & Chr(13) & "Favor escoger de nuevo el registro y eliminarlo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Finally
            CerrarConexion()
        End Try
    End Sub
    Private Sub CancelarBtn_Click(sender As Object, e As EventArgs) Handles CancelarBtn.Click  '============ CANCELAR  ===========
        act()
        PanelP.Enabled = False
        CamDGV.Enabled = True
        Me.GuardarBtn.Visible = True
    End Sub

    Public Sub Seleccion()
        Try
            Dim lista As Integer = 0

            If buscartxt.Text <> "" Then
                AbrirConexion()
                Dim cmd As New MySqlCommand("SELECT * FROM placa WHERE idPlaca = @idPlaca", con)
                cmd.Parameters.AddWithValue("@idPlaca", buscartxt.Text)
                adaptador = New MySqlDataAdapter(cmd)
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
        Catch ex As Exception
            MessageBox.Show("Error al seleccionar: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            CerrarConexion()
        End Try
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
        Try
            Dim lista As Integer = 0

            If propTb.Text <> "" Then
                AbrirConexion()
                Dim cmd As New MySqlCommand("SELECT * FROM propietario WHERE nPropietario = @nPropietario", con)
                cmd.Parameters.AddWithValue("@nPropietario", propTb.Text)
                adaptador = New MySqlDataAdapter(cmd)
                datos = New DataSet
                adaptador.Fill(datos, "propietario")
                lista = datos.Tables("propietario").Rows.Count
            End If

            If lista <> 0 Then
                codTb.Text = datos.Tables("propietario").Rows(0).Item("codProp").ToString
            Else
                MsgBox("Datos no encontrados")
            End If
        Catch ex As Exception
            MessageBox.Show("Error al buscar propietario: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            CerrarConexion()
        End Try
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
        Try
            Dim lista As Integer = 0

            If codTb.Text <> "" Then
                AbrirConexion()
                Dim cmd As New MySqlCommand("SELECT * FROM propietario WHERE codProp = @codProp", con)
                cmd.Parameters.AddWithValue("@codProp", codTb.Text)
                adaptador = New MySqlDataAdapter(cmd)
                datos = New DataSet
                adaptador.Fill(datos, "propietario")
                lista = datos.Tables("propietario").Rows.Count
            End If

            If lista <> 0 Then
                propTb.Text = datos.Tables("propietario").Rows(0).Item("nPropietario").ToString
            Else
                MsgBox("Datos no encontrados")
            End If
        Catch ex As Exception
            MessageBox.Show("Error al buscar código: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            CerrarConexion()
        End Try
    End Sub


    ' ============ MÉTODOS DE BÚSQUEDA ============
    Private Sub buscarPlacas()
        Try
            Dim filtro As String = ""
            Dim parametros As New List(Of MySqlParameter)()

            ' Construir filtro dinámico basado en los campos de búsqueda
            If Not String.IsNullOrEmpty(codBusqTB.Text.Trim()) Then
                filtro &= " codigoPro LIKE @codigo"
                parametros.Add(New MySqlParameter("@codigo", "%" & codBusqTB.Text.Trim() & "%"))
            End If

            If Not String.IsNullOrEmpty(propBusqTB.Text.Trim()) Then
                If filtro <> "" Then filtro &= " AND"
                filtro &= " propietario LIKE @propietario"
                parametros.Add(New MySqlParameter("@propietario", "%" & propBusqTB.Text.Trim() & "%"))
            End If

            If Not String.IsNullOrEmpty(placaBusqTB.Text.Trim()) Then
                If filtro <> "" Then filtro &= " AND"
                filtro &= " placa LIKE @placa"
                parametros.Add(New MySqlParameter("@placa", "%" & placaBusqTB.Text.Trim() & "%"))
            End If

            Dim consulta As String = "SELECT idPlaca, codigoPro, placa, propietario, observaciones, CASE WHEN activo = 1 THEN 'Activo' ELSE 'Bloqueado' END AS estado FROM placa"
            If filtro <> "" Then
                consulta &= " WHERE" & filtro
            End If

            Dim table As New DataTable()
            AbrirConexion()
            Using cmd As New MySqlCommand(consulta, con)
                For Each param As MySqlParameter In parametros
                    cmd.Parameters.Add(param)
                Next
                Using adaptadorBusq As New MySqlDataAdapter(cmd)
                    adaptadorBusq.Fill(table)
                End Using
            End Using

            CamDGV.DataSource = table
            ListadoD()

        Catch ex As Exception
            MessageBox.Show("Error al buscar: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            CerrarConexion()
        End Try
    End Sub

    Private Sub codBusqTB_TextChanged(sender As Object, e As EventArgs) Handles codBusqTB.TextChanged
        buscarPlacas()
    End Sub

    Private Sub propBusqTB_TextChanged(sender As Object, e As EventArgs) Handles propBusqTB.TextChanged
        buscarPlacas()
    End Sub

    Private Sub placaBusqTB_TextChanged(sender As Object, e As EventArgs) Handles placaBusqTB.TextChanged
        buscarPlacas()
    End Sub

    Private Sub limpiarBusqueda()
        codBusqTB.Text = ""
        propBusqTB.Text = ""
        placaBusqTB.Text = ""
    End Sub

    Private Sub CamDGV_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles CamDGV.CellClick
        If e.RowIndex >= 0 AndAlso Me.CamDGV.RowCount > 0 Then
            Dim i As Integer = e.RowIndex
            ' Evitar triggear búsqueda al seleccionar
            RemoveHandler Me.placaBusqTB.TextChanged, AddressOf placaBusqTB_TextChanged
            Me.placaBusqTB.Text = Me.CamDGV.Item(2, i).Value.ToString()
            AddHandler Me.placaBusqTB.TextChanged, AddressOf placaBusqTB_TextChanged
            PanelP.Enabled = True
            Dim idcod As Integer = Convert.ToInt32(Me.CamDGV.Item(0, i).Value)
            buscartxt.Text = idcod.ToString()
            Seleccion()
            Me.EditarBtn.Enabled = Not ModuloConexion.EsSoloLectura()
            Me.EliminarBtn.Enabled = Not ModuloConexion.EsSoloLectura()

            ' Actualizar botón Bloquear/Desbloquear según estado
            Me.BloquearBtn.Enabled = Not ModuloConexion.EsSoloLectura()
            Dim estado As String = Me.CamDGV.Item(5, i).Value.ToString()
            If estado = "Bloqueado" Then
                Me.BloquearBtn.Text = "Desbloquear"
                Me.BloquearBtn.SymbolColor = Color.Green
            Else
                Me.BloquearBtn.Text = "Bloquear"
                Me.BloquearBtn.SymbolColor = Color.FromArgb(220, 50, 50)
            End If
        End If
    End Sub

    ' ============ BLOQUEAR / DESBLOQUEAR PLACA ============
    Private Sub BloquearBtn_Click(sender As Object, e As EventArgs) Handles BloquearBtn.Click
        If String.IsNullOrEmpty(buscartxt.Text) Then
            MessageBox.Show("Debe seleccionar una placa primero.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim placaSeleccionada As String = ""
        If CamDGV.CurrentRow IsNot Nothing Then
            placaSeleccionada = CamDGV.CurrentRow.Cells(2).Value.ToString()
        End If

        Dim estadoActual As String = CamDGV.CurrentRow.Cells(5).Value.ToString()
        Dim nuevoActivo As Integer = If(estadoActual = "Bloqueado", 1, 0)
        Dim accion As String = If(nuevoActivo = 0, "bloquear", "desbloquear")

        Dim opc As DialogResult = MessageBox.Show(
            "¿Desea " & accion & " la placa """ & placaSeleccionada & """?" & vbCrLf &
            If(nuevoActivo = 0, "La placa no podrá ser usada en comprobantes.", "La placa podrá ser usada nuevamente en comprobantes."),
            "Confirmar " & accion,
            MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If opc = DialogResult.Yes Then
            Try
                AbrirConexion()
                Using cmd As New MySqlCommand("UPDATE placa SET activo = @activo WHERE idPlaca = @idPlaca", con)
                    cmd.Parameters.AddWithValue("@activo", nuevoActivo)
                    cmd.Parameters.AddWithValue("@idPlaca", Convert.ToInt32(buscartxt.Text))
                    cmd.ExecuteNonQuery()
                End Using

                MessageBox.Show("Placa " & If(nuevoActivo = 1, "desbloqueada", "bloqueada") & " correctamente.",
                    "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information)

                act()
                listadoCamDgv()
            Catch ex As Exception
                MessageBox.Show("Error al " & accion & ": " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                CerrarConexion()
            End Try
        End If
    End Sub

    ' Colorear filas bloqueadas en el DataGridView
    Private Sub CamDGV_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles CamDGV.CellFormatting
        If e.RowIndex >= 0 AndAlso CamDGV.Columns.Count > 5 Then
            Dim estadoCell As Object = CamDGV.Rows(e.RowIndex).Cells(5).Value
            If estadoCell IsNot Nothing AndAlso estadoCell.ToString() = "Bloqueado" Then
                CamDGV.Rows(e.RowIndex).DefaultCellStyle.ForeColor = Color.Gray
                CamDGV.Rows(e.RowIndex).DefaultCellStyle.Font = New Font(CamDGV.Font, FontStyle.Strikeout)
            Else
                CamDGV.Rows(e.RowIndex).DefaultCellStyle.ForeColor = Color.FromArgb(200, 215, 240)
                CamDGV.Rows(e.RowIndex).DefaultCellStyle.Font = New Font(CamDGV.Font, FontStyle.Regular)
            End If
        End If
    End Sub

    ' ============ EXPORTAR A EXCEL ============
    Private Sub ExportarExcelBtn_Click(sender As Object, e As EventArgs) Handles ExportarExcelBtn.Click
        If CamDGV.Rows.Count = 0 Then
            MessageBox.Show("No hay datos para exportar.", "Aviso")
            Return
        End If

        Using saveDialog As New SaveFileDialog()
            saveDialog.Filter = "Archivo Excel (*.xlsx)|*.xlsx|Archivo CSV (*.csv)|*.csv"
            saveDialog.FileName = "Listado_Placas_" & DateTime.Now.ToString("yyyyMMdd_HHmmss")
            saveDialog.Title = "Exportar Listado de Placas"

            If saveDialog.ShowDialog() = DialogResult.OK Then
                Try
                    If saveDialog.FileName.EndsWith(".csv") Then
                        ExportarCSV(saveDialog.FileName)
                    Else
                        ExportarExcel(saveDialog.FileName)
                    End If

                    MessageBox.Show("Archivo exportado correctamente:" & vbCrLf & saveDialog.FileName, "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    Dim result As DialogResult = MessageBox.Show("¿Desea abrir el archivo?", "Abrir archivo", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    If result = DialogResult.Yes Then
                        Process.Start(saveDialog.FileName)
                    End If

                Catch ex As Exception
                    MessageBox.Show("Error al exportar: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End If
        End Using
    End Sub

    Private Sub ExportarCSV(rutaArchivo As String)
        Dim sb As New StringBuilder()

        ' Encabezados (solo columnas visibles)
        Dim headers As New List(Of String)
        For Each col As DataGridViewColumn In CamDGV.Columns
            If col.Visible Then
                headers.Add("""" & col.HeaderText & """")
            End If
        Next
        sb.AppendLine(String.Join(",", headers))

        ' Datos
        For Each row As DataGridViewRow In CamDGV.Rows
            If Not row.IsNewRow Then
                Dim valores As New List(Of String)
                For Each cell As DataGridViewCell In row.Cells
                    If CamDGV.Columns(cell.ColumnIndex).Visible Then
                        Dim valor As String = If(cell.Value IsNot Nothing, cell.Value.ToString(), "")
                        valor = """" & valor.Replace("""", """""") & """"
                        valores.Add(valor)
                    End If
                Next
                sb.AppendLine(String.Join(",", valores))
            End If
        Next

        File.WriteAllText(rutaArchivo, sb.ToString(), Encoding.UTF8)
    End Sub

    Private Sub ExportarExcel(rutaArchivo As String)
        Using workbook As New XLWorkbook()
            Dim ws As IXLWorksheet = workbook.Worksheets.Add("Placas")

            ' Contar columnas visibles
            Dim colCount As Integer = 0
            For Each col As DataGridViewColumn In CamDGV.Columns
                If col.Visible Then colCount += 1
            Next

            ' ========== TITULO ==========
            ws.Cell(1, 1).SetValue("LISTADO DE PLACAS")
            ws.Range(1, 1, 1, colCount).Merge()
            With ws.Cell(1, 1).Style
                .Font.Bold = True
                .Font.FontSize = 16
                .Font.FontColor = XLColor.White
                .Fill.BackgroundColor = XLColor.FromHtml("#6A7EA8")
                .Alignment.Horizontal = XLAlignmentHorizontalValues.Center
            End With
            ws.Row(1).Height = 30

            ' ========== RESUMEN ==========
            ws.Cell(2, 1).SetValue("RESUMEN")
            ws.Range(2, 1, 2, colCount).Merge()
            With ws.Cell(2, 1).Style
                .Font.Bold = True
                .Font.FontSize = 12
                .Font.FontColor = XLColor.White
                .Fill.BackgroundColor = XLColor.FromHtml("#4A5A78")
                .Alignment.Horizontal = XLAlignmentHorizontalValues.Center
            End With

            ' Total de registros
            ws.Cell(3, 1).SetValue("Total de registros:")
            ws.Cell(3, 1).Style.Font.Bold = True
            ws.Cell(3, 2).SetValue(CamDGV.Rows.Count)
            ws.Cell(3, 2).Style.Font.Bold = True
            ws.Cell(3, 2).Style.Font.FontColor = XLColor.FromHtml("#2E86AB")

            ' Contar propietarios unicos
            Dim propietarios As New HashSet(Of String)
            For Each row As DataGridViewRow In CamDGV.Rows
                If Not row.IsNewRow Then
                    Dim propVal As Object = row.Cells("propietario").Value
                    If propVal IsNot Nothing AndAlso Not String.IsNullOrEmpty(propVal.ToString()) Then
                        propietarios.Add(propVal.ToString().Trim().ToUpper())
                    End If
                End If
            Next
            ws.Cell(4, 1).SetValue("Total de propietarios:")
            ws.Cell(4, 1).Style.Font.Bold = True
            ws.Cell(4, 2).SetValue(propietarios.Count)
            ws.Cell(4, 2).Style.Font.Bold = True
            ws.Cell(4, 2).Style.Font.FontColor = XLColor.FromHtml("#2E86AB")

            ' Fecha de generacion
            ws.Cell(5, 1).SetValue("Fecha de generación:")
            ws.Cell(5, 1).Style.Font.Bold = True
            ws.Cell(5, 2).SetValue(DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"))
            ws.Cell(5, 2).Style.Font.FontColor = XLColor.DarkGray

            ' Filtros aplicados
            Dim filtros As String = ""
            If Not String.IsNullOrEmpty(codBusqTB.Text.Trim()) Then filtros &= "Código: " & codBusqTB.Text.Trim() & " | "
            If Not String.IsNullOrEmpty(propBusqTB.Text.Trim()) Then filtros &= "Propietario: " & propBusqTB.Text.Trim() & " | "
            If Not String.IsNullOrEmpty(placaBusqTB.Text.Trim()) Then filtros &= "Placa: " & placaBusqTB.Text.Trim() & " | "

            If filtros <> "" Then
                filtros = filtros.TrimEnd(" | ".ToCharArray())
                ws.Cell(6, 1).SetValue("Filtros aplicados:")
                ws.Cell(6, 1).Style.Font.Bold = True
                ws.Cell(6, 2).SetValue(filtros)
                ws.Cell(6, 2).Style.Font.Italic = True
                ws.Cell(6, 2).Style.Font.FontColor = XLColor.DarkGray
            End If

            ' ========== ENCABEZADOS DE COLUMNAS ==========
            Dim headerRow As Integer = 8
            Dim colIndex As Integer = 1
            For Each col As DataGridViewColumn In CamDGV.Columns
                If col.Visible Then
                    Dim cell As IXLCell = ws.Cell(headerRow, colIndex)
                    cell.SetValue(col.HeaderText)
                    With cell.Style
                        .Font.Bold = True
                        .Font.FontColor = XLColor.White
                        .Fill.BackgroundColor = XLColor.FromHtml("#4A5A78")
                        .Alignment.Horizontal = XLAlignmentHorizontalValues.Center
                        .Border.OutsideBorder = XLBorderStyleValues.Thin
                        .Border.OutsideBorderColor = XLColor.Black
                    End With
                    colIndex += 1
                End If
            Next
            ws.Row(headerRow).Height = 22

            ' ========== DATOS CON COLORES INTERCALADOS ==========
            Dim color1 As XLColor = XLColor.FromHtml("#E8EAF6")  ' Lavanda suave
            Dim color2 As XLColor = XLColor.FromHtml("#FFF3E0")  ' Durazno suave

            Dim dataRowStart As Integer = headerRow + 1
            For row As Integer = 0 To CamDGV.Rows.Count - 1
                If Not CamDGV.Rows(row).IsNewRow Then
                    Dim excelRow As Integer = dataRowStart + row
                    Dim isAlternate As Boolean = (row Mod 2 = 1)
                    Dim rowColor As XLColor = If(isAlternate, color2, color1)

                    colIndex = 1
                    For Each col As DataGridViewColumn In CamDGV.Columns
                        If col.Visible Then
                            Dim cell As IXLCell = ws.Cell(excelRow, colIndex)
                            Dim valor As Object = CamDGV.Rows(row).Cells(col.Index).Value

                            If valor IsNot Nothing AndAlso Not String.IsNullOrEmpty(valor.ToString()) Then
                                cell.SetValue(valor.ToString())
                            End If

                            With cell.Style
                                .Fill.BackgroundColor = rowColor
                                .Border.OutsideBorder = XLBorderStyleValues.Thin
                                .Border.OutsideBorderColor = XLColor.LightGray
                            End With

                            colIndex += 1
                        End If
                    Next
                End If
            Next

            ' ========== AJUSTAR COLUMNAS ==========
            ws.Columns().AdjustToContents()

            workbook.SaveAs(rutaArchivo)
        End Using
    End Sub

End Class