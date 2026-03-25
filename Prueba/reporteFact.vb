Imports System.Data
Imports MySql.Data.MySqlClient
Imports System.Text
Imports System.IO
Imports ClosedXML.Excel

Public Class reporteFact

    Private Sub reporteFact_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cargarDatos()
    End Sub

    Private Sub cargarDatos()
        Try
            ' Construir query con filtros dinamicos
            Dim sql As New StringBuilder()
            sql.Append("SELECT nCompro AS 'Comprobante', nBoleta AS 'Boletas', ")
            sql.Append("DATE_FORMAT(fecha, '%d/%m/%Y') AS 'Fecha', ")
            sql.Append("placaCbz AS 'Placa', nConte AS 'Contenedor', galDesp AS 'Galones', ")
            sql.Append("total AS 'Total', codiProp AS 'Cod. Cliente', ")
            sql.Append("periodo AS 'Periodo', semana AS 'Semana', valor AS 'Valor' ")
            sql.Append("FROM comprobante WHERE (anulado = 0 OR anulado IS NULL) ")

            Using conLocal As MySqlConnection = ModuloConexion.ObtenerConexion()
                conLocal.Open()
                Using cmd As New MySqlCommand()
                    cmd.Connection = conLocal

                    ' Filtro por fecha
                    If chkUsarFecha.Checked Then
                        sql.Append("AND fecha >= @fechaDesde AND fecha <= @fechaHasta ")
                        cmd.Parameters.AddWithValue("@fechaDesde", fechaDesdePk.Value.Date)
                        cmd.Parameters.AddWithValue("@fechaHasta", fechaHastaPk.Value.Date)
                    End If

                    ' Filtro por codigo cliente
                    If codClienteTb.Text.Trim() <> "" Then
                        sql.Append("AND codiProp LIKE @codCliente ")
                        cmd.Parameters.AddWithValue("@codCliente", "%" & codClienteTb.Text.Trim() & "%")
                    End If

                    ' Filtro por placa
                    If placaTb.Text.Trim() <> "" Then
                        sql.Append("AND placaCbz LIKE @placa ")
                        cmd.Parameters.AddWithValue("@placa", "%" & placaTb.Text.Trim() & "%")
                    End If

                    ' Filtro por boleta
                    If boletaTb.Text.Trim() <> "" Then
                        sql.Append("AND nBoleta LIKE @boleta ")
                        cmd.Parameters.AddWithValue("@boleta", "%" & boletaTb.Text.Trim() & "%")
                    End If

                    sql.Append("ORDER BY fecha DESC, nBoleta ASC")

                    cmd.CommandText = sql.ToString()

                    Dim adapter As New MySqlDataAdapter(cmd)
                    Dim dt As New DataTable()
                    adapter.Fill(dt)

                    ' Agregar subtotales por Cod. Cliente
                    Dim registrosReales As Integer = dt.Rows.Count
                    dt = agregarSubtotales(dt)

                    reporteDgv.DataSource = dt

                    ' Actualizar contador (sin contar filas subtotal)
                    LblTotal.Text = "Total registros: " & registrosReales.ToString()

                    ' Consultar odometro de cierre_turno
                    lblOdometro.Text = ""
                    If chkUsarFecha.Checked Then
                        Try
                            Dim sqlOdo As String = "SELECT despachador, MIN(odometroInicio) AS odoMin, MAX(odometroCierre) AS odoMax, fecha " &
                                "FROM cierre_turno WHERE fecha >= @fDesde AND fecha <= @fHasta " &
                                "GROUP BY despachador, fecha ORDER BY fecha ASC"
                            Using cmdOdo As New MySqlCommand(sqlOdo, conLocal)
                                cmdOdo.Parameters.AddWithValue("@fDesde", fechaDesdePk.Value.Date.ToString("yyyy-MM-dd"))
                                cmdOdo.Parameters.AddWithValue("@fHasta", fechaHastaPk.Value.Date.ToString("yyyy-MM-dd"))
                                Dim odoTexto As New System.Text.StringBuilder()
                                Using readerOdo As MySqlDataReader = cmdOdo.ExecuteReader()
                                    While readerOdo.Read()
                                        Dim desp As String = readerOdo("despachador").ToString()
                                        Dim odoMin As Double = If(readerOdo("odoMin") IsNot DBNull.Value, Convert.ToDouble(readerOdo("odoMin")), 0)
                                        Dim odoMax As Double = If(readerOdo("odoMax") IsNot DBNull.Value, Convert.ToDouble(readerOdo("odoMax")), 0)
                                        Dim fechaOdo As String = Convert.ToDateTime(readerOdo("fecha")).ToString("dd/MM/yyyy")
                                        If odoTexto.Length > 0 Then odoTexto.Append("  |  ")
                                        odoTexto.Append(String.Format("{0} ({1}): Inicio {2:N2} -> Cierre {3:N2}", desp, fechaOdo, odoMin, odoMax))
                                    End While
                                End Using
                                If odoTexto.Length > 0 Then lblOdometro.Text = "Odometro: " & odoTexto.ToString()
                            End Using
                        Catch
                        End Try
                    End If

                    ' Ajustar anchos de columnas
                    configurarColumnas()
                End Using
            End Using

        Catch ex As Exception
            MessageBox.Show("Error al cargar datos: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub configurarColumnas()
        If reporteDgv.Columns.Count > 0 Then
            reporteDgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None
            reporteDgv.Columns("Comprobante").Width = 95
            reporteDgv.Columns("Boletas").Width = 85
            reporteDgv.Columns("Fecha").Width = 95
            reporteDgv.Columns("Placa").Width = 95
            reporteDgv.Columns("Contenedor").Width = 115
            reporteDgv.Columns("Galones").Width = 90
            reporteDgv.Columns("Total").Width = 95
            reporteDgv.Columns("Cod. Cliente").Width = 105
            reporteDgv.Columns("Periodo").Width = 80
            reporteDgv.Columns("Semana").Width = 75
            reporteDgv.Columns("Valor").Width = 90

            ' Formato numerico
            reporteDgv.Columns("Galones").DefaultCellStyle.Format = "N2"
            reporteDgv.Columns("Total").DefaultCellStyle.Format = "N2"
            reporteDgv.Columns("Valor").DefaultCellStyle.Format = "N2"

            ' Alineacion derecha para columnas numericas
            reporteDgv.Columns("Galones").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            reporteDgv.Columns("Total").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            reporteDgv.Columns("Valor").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            reporteDgv.Columns("Comprobante").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            reporteDgv.Columns("Boletas").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            reporteDgv.Columns("Periodo").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            reporteDgv.Columns("Semana").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            reporteDgv.Columns("Fecha").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            ' Ocultar columnas marcadoras
            If reporteDgv.Columns.Contains("EsSubtotal") Then
                reporteDgv.Columns("EsSubtotal").Visible = False
            End If
            If reporteDgv.Columns.Contains("GrupoColor") Then
                reporteDgv.Columns("GrupoColor").Visible = False
            End If
        End If
    End Sub

    Private Function agregarSubtotales(dt As DataTable) As DataTable
        If dt.Rows.Count = 0 Then Return dt

        ' Agregar columnas marcadoras
        If Not dt.Columns.Contains("EsSubtotal") Then
            dt.Columns.Add("EsSubtotal", GetType(Boolean))
            For Each row As DataRow In dt.Rows
                row("EsSubtotal") = False
            Next
        End If
        If Not dt.Columns.Contains("GrupoColor") Then
            dt.Columns.Add("GrupoColor", GetType(Integer))
            For Each row As DataRow In dt.Rows
                row("GrupoColor") = 0
            Next
        End If

        ' Ordenar por Cod. Cliente
        dt.DefaultView.Sort = "Cod. Cliente ASC"
        Dim dtSorted As DataTable = dt.DefaultView.ToTable()

        ' Crear tabla resultado con mismo esquema
        Dim dtResult As DataTable = dtSorted.Clone()

        Dim currentCliente As String = ""
        Dim sumaGalones As Double = 0
        Dim sumaTotal As Double = 0
        Dim granTotalGalones As Double = 0
        Dim granTotalTotal As Double = 0
        Dim grupoIndex As Integer = -1

        For i As Integer = 0 To dtSorted.Rows.Count - 1
            Dim row As DataRow = dtSorted.Rows(i)
            Dim cliente As String = If(row("Cod. Cliente") IsNot DBNull.Value, row("Cod. Cliente").ToString().Trim(), "")

            ' Si cambio el cliente, insertar subtotal del grupo anterior
            If cliente <> currentCliente AndAlso currentCliente <> "" Then
                Dim subRow As DataRow = dtResult.NewRow()
                For Each col As DataColumn In dtResult.Columns
                    subRow(col) = DBNull.Value
                Next
                subRow("Galones") = sumaGalones
                subRow("Total") = sumaTotal
                'subRow("Cod. Cliente") = "Codigo: " & currentCliente
                subRow("EsSubtotal") = True
                subRow("GrupoColor") = grupoIndex Mod 3
                dtResult.Rows.Add(subRow)
                sumaGalones = 0
                sumaTotal = 0
            End If

            ' Nuevo grupo
            If cliente <> currentCliente Then
                grupoIndex += 1
            End If

            ' Agregar fila de datos
            dtResult.ImportRow(row)
            dtResult.Rows(dtResult.Rows.Count - 1)("GrupoColor") = grupoIndex Mod 3
            currentCliente = cliente

            ' Acumular
            Dim gal As Double = 0
            Dim tot As Double = 0
            If row("Galones") IsNot DBNull.Value Then Double.TryParse(row("Galones").ToString(), gal)
            If row("Total") IsNot DBNull.Value Then Double.TryParse(row("Total").ToString(), tot)
            sumaGalones += gal
            sumaTotal += tot
            granTotalGalones += gal
            granTotalTotal += tot
        Next

        ' Subtotal del ultimo grupo
        If currentCliente <> "" Then
            Dim subRow As DataRow = dtResult.NewRow()
            For Each col As DataColumn In dtResult.Columns
                subRow(col) = DBNull.Value
            Next
            subRow("Galones") = sumaGalones
            subRow("Total") = sumaTotal
            subRow("Cod. Cliente") = "SUBTOTAL: " & currentCliente
            subRow("EsSubtotal") = True
            subRow("GrupoColor") = grupoIndex Mod 3
            dtResult.Rows.Add(subRow)
        End If

        ' GRAN TOTAL
        Dim granRow As DataRow = dtResult.NewRow()
        For Each col As DataColumn In dtResult.Columns
            granRow(col) = DBNull.Value
        Next
        granRow("Galones") = granTotalGalones
        granRow("Total") = granTotalTotal
        granRow("Cod. Cliente") = "GRAN TOTAL"
        granRow("EsSubtotal") = True
        granRow("GrupoColor") = -1
        dtResult.Rows.Add(granRow)

        Return dtResult
    End Function

    ' Paleta de colores por grupo (ciclo de 3)
    Private ReadOnly coloresSuaves() As Color = {
        Color.FromArgb(255, 243, 224),  ' #FFF3E0 naranja suave
        Color.FromArgb(227, 242, 253),  ' #E3F2FD azul celeste
        Color.FromArgb(232, 245, 233)   ' #E8F5E9 verde suave
    }
    Private ReadOnly coloresIntensos() As Color = {
        Color.FromArgb(255, 224, 178),  ' #FFE0B2 naranja medio
        Color.FromArgb(187, 222, 251),  ' #BBDEFB azul medio
        Color.FromArgb(200, 230, 201)   ' #C8E6C9 verde medio
    }
    Private ReadOnly coloresTextoSub() As Color = {
        Color.FromArgb(80, 60, 0),      ' marron oscuro
        Color.FromArgb(0, 40, 80),      ' azul oscuro
        Color.FromArgb(0, 60, 20)       ' verde oscuro
    }

    Private Sub reporteDgv_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles reporteDgv.CellFormatting
        If e.RowIndex < 0 Then Return
        Dim dgv As DataGridView = CType(sender, DataGridView)
        If Not dgv.Columns.Contains("GrupoColor") Then Return

        Dim grupoVal As Object = dgv.Rows(e.RowIndex).Cells("GrupoColor").Value
        If grupoVal Is Nothing OrElse grupoVal Is DBNull.Value Then Return
        Dim grupoColor As Integer = CInt(grupoVal)

        Dim esSubtotal As Object = dgv.Rows(e.RowIndex).Cells("EsSubtotal").Value
        Dim esSub As Boolean = (esSubtotal IsNot Nothing AndAlso esSubtotal IsNot DBNull.Value AndAlso CBool(esSubtotal))

        If grupoColor = -1 Then
            ' GRAN TOTAL: fondo naranja oscuro
            e.CellStyle.BackColor = Color.FromArgb(255, 183, 77)  ' #FFB74D
            e.CellStyle.ForeColor = Color.Black
            e.CellStyle.Font = New Font(dgv.Font, FontStyle.Bold)
        ElseIf esSub Then
            ' SUBTOTAL: color intenso del grupo
            e.CellStyle.BackColor = coloresIntensos(grupoColor)
            e.CellStyle.ForeColor = coloresTextoSub(grupoColor)
            e.CellStyle.Font = New Font(dgv.Font, FontStyle.Bold)
        Else
            ' Fila de datos: color suave del grupo
            e.CellStyle.BackColor = coloresSuaves(grupoColor)
        End If
    End Sub

    Private Sub buscarBtn_Click(sender As Object, e As EventArgs) Handles buscarBtn.Click
        cargarDatos()
    End Sub

    Private Sub ordenarBtn_Click(sender As Object, e As EventArgs) Handles ordenarBtn.Click
        If reporteDgv.DataSource IsNot Nothing Then
            Dim dt As DataTable = CType(reporteDgv.DataSource, DataTable)

            ' Filtrar solo datos reales (sin subtotales)
            Dim dtSinSub As DataTable = dt.Clone()
            For Each row As DataRow In dt.Rows
                If row("EsSubtotal") IsNot DBNull.Value AndAlso CBool(row("EsSubtotal")) = False Then
                    dtSinSub.ImportRow(row)
                End If
            Next

            ' Quitar columnas marcadoras para que agregarSubtotales las re-cree
            dtSinSub.Columns.Remove("EsSubtotal")
            dtSinSub.Columns.Remove("GrupoColor")

            ' Re-agregar subtotales (ya ordena por Cod. Cliente internamente)
            Dim dtConSub As DataTable = agregarSubtotales(dtSinSub)
            reporteDgv.DataSource = dtConSub
            configurarColumnas()
        End If
    End Sub

    Private Sub limpiarBtn_Click(sender As Object, e As EventArgs) Handles limpiarBtn.Click
        ' Limpiar filtros
        chkUsarFecha.Checked = False
        fechaDesdePk.Value = DateTime.Today
        fechaHastaPk.Value = DateTime.Today
        codClienteTb.Text = ""
        placaTb.Text = ""
        boletaTb.Text = ""

        ' Recargar datos sin filtros
        cargarDatos()
    End Sub

    Private Sub chkUsarFecha_CheckedChanged(sender As Object, e As EventArgs) Handles chkUsarFecha.CheckedChanged
        fechaDesdePk.Enabled = chkUsarFecha.Checked
        fechaHastaPk.Enabled = chkUsarFecha.Checked
    End Sub

    Private Sub exportarBtn_Click(sender As Object, e As EventArgs) Handles exportarBtn.Click
        If reporteDgv.Rows.Count = 0 Then
            MessageBox.Show("No hay datos para exportar.", "Aviso")
            Return
        End If

        Using saveDialog As New SaveFileDialog()
            saveDialog.Filter = "Archivo Excel (*.xlsx)|*.xlsx|Archivo CSV (*.csv)|*.csv"
            saveDialog.FileName = "Reporte_Facturas_" & DateTime.Now.ToString("yyyyMMdd_HHmmss")
            saveDialog.Title = "Exportar Reporte de Facturas"

            If saveDialog.ShowDialog() = DialogResult.OK Then
                Try
                    If saveDialog.FileName.EndsWith(".csv") Then
                        ExportarCSV(saveDialog.FileName)
                    Else
                        ExportarExcel(saveDialog.FileName)
                    End If

                    MessageBox.Show("Archivo exportado correctamente:" & vbCrLf & saveDialog.FileName, "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    ' Preguntar si desea abrir el archivo
                    Dim result As DialogResult = MessageBox.Show("Desea abrir el archivo?", "Abrir archivo", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
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
        For Each col As DataGridViewColumn In reporteDgv.Columns
            If col.Visible Then
                headers.Add("""" & col.HeaderText & """")
            End If
        Next
        sb.AppendLine(String.Join(",", headers))

        ' Datos (solo columnas visibles)
        For Each row As DataGridViewRow In reporteDgv.Rows
            If Not row.IsNewRow Then
                Dim valores As New List(Of String)
                For Each cell As DataGridViewCell In row.Cells
                    If reporteDgv.Columns(cell.ColumnIndex).Visible Then
                        Dim valor As String = If(cell.Value IsNot Nothing, cell.Value.ToString(), "")
                        valor = """" & valor.Replace("""", """""") & """"
                        valores.Add(valor)
                    End If
                Next
                sb.AppendLine(String.Join(",", valores))
            End If
        Next

        ' Guardar archivo con encoding UTF-8 con BOM para que Excel reconozca caracteres especiales
        File.WriteAllText(rutaArchivo, sb.ToString(), Encoding.UTF8)
    End Sub

    Private Sub ExportarExcel(rutaArchivo As String)
        Using workbook As New XLWorkbook()
            Dim ws As IXLWorksheet = workbook.Worksheets.Add("Facturas")

            ' Columnas visibles (excluir EsSubtotal)
            Dim colsVisibles As New List(Of Integer)
            For col As Integer = 0 To reporteDgv.Columns.Count - 1
                If reporteDgv.Columns(col).Visible Then
                    colsVisibles.Add(col)
                End If
            Next
            Dim numColsVisibles As Integer = colsVisibles.Count

            ' ========== TITULO DEL REPORTE ==========
            ws.Cell(1, 1).SetValue("REPORTE DE FACTURAS")
            ws.Range(1, 1, 1, numColsVisibles).Merge()
            With ws.Cell(1, 1).Style
                .Font.Bold = True
                .Font.FontSize = 16
                .Font.FontColor = XLColor.White
                .Fill.BackgroundColor = XLColor.FromHtml("#6A7EA8")
                .Alignment.Horizontal = XLAlignmentHorizontalValues.Center
            End With
            ws.Row(1).Height = 30

            ' ========== INFORMACION DE FILTROS ==========
            Dim infoFila As Integer = 2
            Dim filtrosAplicados As String = "Filtros: "
            If chkUsarFecha.Checked Then
                filtrosAplicados &= "Fecha " & fechaDesdePk.Value.ToString("dd/MM/yyyy") & " - " & fechaHastaPk.Value.ToString("dd/MM/yyyy") & " | "
            End If
            If codClienteTb.Text.Trim() <> "" Then
                filtrosAplicados &= "Cod. Cliente: " & codClienteTb.Text.Trim() & " | "
            End If
            If placaTb.Text.Trim() <> "" Then
                filtrosAplicados &= "Placa: " & placaTb.Text.Trim() & " | "
            End If
            If boletaTb.Text.Trim() <> "" Then
                filtrosAplicados &= "Boleta: " & boletaTb.Text.Trim() & " | "
            End If
            If filtrosAplicados = "Filtros: " Then
                filtrosAplicados = "Sin filtros aplicados"
            Else
                filtrosAplicados = filtrosAplicados.TrimEnd(" | ".ToCharArray())
            End If

            ws.Cell(infoFila, 1).SetValue(filtrosAplicados)
            ws.Range(infoFila, 1, infoFila, numColsVisibles).Merge()
            With ws.Cell(infoFila, 1).Style
                .Font.Italic = True
                .Font.FontSize = 10
                .Font.FontColor = XLColor.DarkGray
            End With

            ' Fecha de generacion
            infoFila += 1
            ws.Cell(infoFila, 1).SetValue("Generado: " & DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"))
            ws.Range(infoFila, 1, infoFila, numColsVisibles).Merge()
            With ws.Cell(infoFila, 1).Style
                .Font.Italic = True
                .Font.FontSize = 10
                .Font.FontColor = XLColor.DarkGray
            End With

            ' ========== ENCABEZADOS DE COLUMNAS ==========
            Dim headerRow As Integer = infoFila + 2
            Dim excelColH As Integer = 1
            For Each col As Integer In colsVisibles
                Dim cell As IXLCell = ws.Cell(headerRow, excelColH)
                cell.SetValue(reporteDgv.Columns(col).HeaderText)
                With cell.Style
                    .Font.Bold = True
                    .Font.FontColor = XLColor.White
                    .Fill.BackgroundColor = XLColor.FromHtml("#4A5A78")
                    .Alignment.Horizontal = XLAlignmentHorizontalValues.Center
                    .Border.OutsideBorder = XLBorderStyleValues.Thin
                    .Border.OutsideBorderColor = XLColor.Black
                End With
                excelColH += 1
            Next
            ws.Row(headerRow).Height = 22

            ' ========== DATOS ==========
            ' Colores Excel por grupo
            Dim exColoresSuaves() As String = {"#FFF3E0", "#E3F2FD", "#E8F5E9"}
            Dim exColoresIntensos() As String = {"#FFE0B2", "#BBDEFB", "#C8E6C9"}
            Dim exColoresBorde() As String = {"#E0A040", "#64B5F6", "#66BB6A"}

            Dim dataRowStart As Integer = headerRow + 1
            Dim totalGalones As Double = 0
            Dim totalValor As Double = 0
            Dim excelRowActual As Integer = dataRowStart

            For row As Integer = 0 To reporteDgv.Rows.Count - 1
                If Not reporteDgv.Rows(row).IsNewRow Then
                    ' Detectar tipo de fila y grupo
                    Dim esSubtotal As Boolean = False
                    Dim grupoColor As Integer = 0
                    If reporteDgv.Columns.Contains("EsSubtotal") Then
                        Dim subVal As Object = reporteDgv.Rows(row).Cells("EsSubtotal").Value
                        If subVal IsNot Nothing AndAlso subVal IsNot DBNull.Value Then
                            esSubtotal = CBool(subVal)
                        End If
                    End If
                    If reporteDgv.Columns.Contains("GrupoColor") Then
                        Dim grpVal As Object = reporteDgv.Rows(row).Cells("GrupoColor").Value
                        If grpVal IsNot Nothing AndAlso grpVal IsNot DBNull.Value Then
                            grupoColor = CInt(grpVal)
                        End If
                    End If
                    Dim esGranTotal As Boolean = (grupoColor = -1)

                    Dim excelCol As Integer = 1
                    For Each col As Integer In colsVisibles
                        Dim cell As IXLCell = ws.Cell(excelRowActual, excelCol)
                        Dim valor As Object = reporteDgv.Rows(row).Cells(col).Value
                        Dim headerName As String = reporteDgv.Columns(col).HeaderText

                        ' Establecer valor
                        If valor IsNot Nothing AndAlso Not String.IsNullOrEmpty(valor.ToString()) Then
                            If headerName = "Galones" OrElse headerName = "Total" OrElse headerName = "Valor" Then
                                Dim numVal As Double
                                If Double.TryParse(valor.ToString(), numVal) Then
                                    cell.SetValue(numVal)
                                    cell.Style.NumberFormat.Format = "#,##0.00"
                                    If Not esSubtotal Then
                                        If headerName = "Galones" Then totalGalones += numVal
                                        If headerName = "Total" Then totalValor += numVal
                                    End If
                                Else
                                    cell.SetValue(valor.ToString())
                                End If
                            ElseIf headerName = "Comprobante" OrElse headerName = "Boletas" OrElse headerName = "Periodo" OrElse headerName = "Semana" Then
                                Dim intVal As Integer
                                If Integer.TryParse(valor.ToString(), intVal) Then
                                    cell.SetValue(intVal)
                                Else
                                    cell.SetValue(valor.ToString())
                                End If
                            Else
                                cell.SetValue(valor.ToString())
                            End If
                        End If

                        ' Estilos de celda
                        With cell.Style
                            .Border.OutsideBorder = XLBorderStyleValues.Thin
                            .Border.OutsideBorderColor = XLColor.LightGray

                            If esGranTotal Then
                                .Fill.BackgroundColor = XLColor.FromHtml("#FFB74D")
                                .Font.Bold = True
                                .Font.FontSize = 11
                                .Border.OutsideBorder = XLBorderStyleValues.Medium
                                .Border.OutsideBorderColor = XLColor.Black
                            ElseIf esSubtotal Then
                                .Fill.BackgroundColor = XLColor.FromHtml(exColoresIntensos(grupoColor))
                                .Font.Bold = True
                                .Border.OutsideBorder = XLBorderStyleValues.Thin
                                .Border.OutsideBorderColor = XLColor.FromHtml(exColoresBorde(grupoColor))
                            Else
                                .Fill.BackgroundColor = XLColor.FromHtml(exColoresSuaves(grupoColor))
                            End If

                            If headerName = "Galones" OrElse headerName = "Total" OrElse headerName = "Valor" OrElse headerName = "Comprobante" OrElse headerName = "Boletas" OrElse headerName = "Periodo" OrElse headerName = "Semana" Then
                                .Alignment.Horizontal = XLAlignmentHorizontalValues.Right
                            ElseIf headerName = "Fecha" OrElse headerName = "Contenedor" OrElse headerName = "Cod. Cliente" OrElse headerName = "Placa" Then
                                .Alignment.Horizontal = XLAlignmentHorizontalValues.Center
                            End If
                        End With

                        excelCol += 1
                    Next

                    excelRowActual += 1
                End If
            Next

            ' ========== RESUMEN ESTADISTICO ==========
            Dim summaryRow As Integer = excelRowActual + 1
            ws.Cell(summaryRow, 1).SetValue("RESUMEN")
            With ws.Cell(summaryRow, 1).Style
                .Font.Bold = True
                .Font.FontSize = 12
                .Fill.BackgroundColor = XLColor.FromHtml("#6A7EA8")
                .Font.FontColor = XLColor.White
            End With
            ws.Range(summaryRow, 1, summaryRow, 4).Merge()

            ' Mostrar cod. cliente si esta filtrado
            If codClienteTb.Text.Trim() <> "" Then
                summaryRow += 1
                ws.Cell(summaryRow, 1).SetValue("Cod. Cliente:")
                ws.Cell(summaryRow, 2).SetValue(codClienteTb.Text.Trim())
                ws.Cell(summaryRow, 1).Style.Font.Bold = True
                ws.Cell(summaryRow, 2).Style.Font.FontColor = XLColor.FromHtml("#2E86AB")
            End If

            ' Mostrar placa si esta filtrada
            If placaTb.Text.Trim() <> "" Then
                summaryRow += 1
                ws.Cell(summaryRow, 1).SetValue("Placa:")
                ws.Cell(summaryRow, 2).SetValue(placaTb.Text.Trim())
                ws.Cell(summaryRow, 1).Style.Font.Bold = True
            End If

            ' Mostrar boleta si esta filtrada
            If boletaTb.Text.Trim() <> "" Then
                summaryRow += 1
                ws.Cell(summaryRow, 1).SetValue("Boleta:")
                ws.Cell(summaryRow, 2).SetValue(boletaTb.Text.Trim())
                ws.Cell(summaryRow, 1).Style.Font.Bold = True
            End If

            ' Mostrar rango de fechas si esta filtrado
            If chkUsarFecha.Checked Then
                summaryRow += 1
                ws.Cell(summaryRow, 1).SetValue("Fecha Desde:")
                ws.Cell(summaryRow, 2).SetValue(fechaDesdePk.Value.ToString("dd/MM/yyyy"))
                ws.Cell(summaryRow, 1).Style.Font.Bold = True

                summaryRow += 1
                ws.Cell(summaryRow, 1).SetValue("Fecha Hasta:")
                ws.Cell(summaryRow, 2).SetValue(fechaHastaPk.Value.ToString("dd/MM/yyyy"))
                ws.Cell(summaryRow, 1).Style.Font.Bold = True
            End If

            ' Linea separadora
            summaryRow += 1

            summaryRow += 1
            ws.Cell(summaryRow, 1).SetValue("Total Registros:")
            ' Contar solo registros reales (sin subtotales)
            Dim registrosRealesExcel As Integer = 0
            For Each dgvRow As DataGridViewRow In reporteDgv.Rows
                If Not dgvRow.IsNewRow Then
                    Dim subV As Object = dgvRow.Cells("EsSubtotal").Value
                    If subV Is Nothing OrElse subV Is DBNull.Value OrElse CBool(subV) = False Then
                        registrosRealesExcel += 1
                    End If
                End If
            Next
            ws.Cell(summaryRow, 2).SetValue(registrosRealesExcel)
            ws.Cell(summaryRow, 1).Style.Font.Bold = True

            summaryRow += 1
            ws.Cell(summaryRow, 1).SetValue("Total Galones:")
            ws.Cell(summaryRow, 2).SetValue(totalGalones)
            ws.Cell(summaryRow, 2).Style.NumberFormat.Format = "#,##0.00"
            ws.Cell(summaryRow, 1).Style.Font.Bold = True

            summaryRow += 1
            ws.Cell(summaryRow, 1).SetValue("Total Valor:")
            ws.Cell(summaryRow, 2).SetValue(totalValor)
            ws.Cell(summaryRow, 2).Style.NumberFormat.Format = "#,##0.00"
            ws.Cell(summaryRow, 1).Style.Font.Bold = True

            ' ========== MEDICION DE TANQUE ==========
            summaryRow += 2
            ws.Cell(summaryRow, 1).SetValue("MEDICION DE TANQUE")
            With ws.Cell(summaryRow, 1).Style
                .Font.Bold = True
                .Font.FontSize = 12
                .Fill.BackgroundColor = XLColor.FromHtml("#6A7EA8")
                .Font.FontColor = XLColor.White
            End With
            ws.Range(summaryRow, 1, summaryRow, 4).Merge()

            ' Consultar cierre_turno para odometro
            Dim odoInicioMed As Double = 0
            Dim odoFinalMed As Double = 0
            Dim hayOdometro As Boolean = False

            Try
                Using conMed As MySqlConnection = ModuloConexion.ObtenerConexion()
                    conMed.Open()
                    Dim sqlMed As New System.Text.StringBuilder()
                    sqlMed.Append("SELECT MIN(odometroInicio) AS odoMin, MAX(odometroCierre) AS odoMax FROM cierre_turno WHERE 1=1 ")
                    Dim cmdMed As New MySqlCommand()
                    cmdMed.Connection = conMed

                    If chkUsarFecha.Checked Then
                        sqlMed.Append("AND fecha >= @fDesde AND fecha <= @fHasta ")
                        cmdMed.Parameters.AddWithValue("@fDesde", fechaDesdePk.Value.Date.ToString("yyyy-MM-dd"))
                        cmdMed.Parameters.AddWithValue("@fHasta", fechaHastaPk.Value.Date.ToString("yyyy-MM-dd"))
                    Else
                        sqlMed.Append("AND periodo = @per AND semana = @sem ")
                        cmdMed.Parameters.AddWithValue("@per", ModuloConexion.PeriodoSesion)
                        cmdMed.Parameters.AddWithValue("@sem", ModuloConexion.SemanaSesion)
                    End If

                    cmdMed.CommandText = sqlMed.ToString()
                    Using drMed As MySqlDataReader = cmdMed.ExecuteReader()
                        If drMed.Read() Then
                            If drMed("odoMin") IsNot DBNull.Value Then odoInicioMed = Convert.ToDouble(drMed("odoMin"))
                            If drMed("odoMax") IsNot DBNull.Value Then odoFinalMed = Convert.ToDouble(drMed("odoMax"))
                            hayOdometro = (odoInicioMed > 0 OrElse odoFinalMed > 0)
                        End If
                    End Using
                End Using
            Catch
            End Try

            Dim totalDispensado As Double = odoFinalMed - odoInicioMed
            Dim consumoOdometro As Double = totalGalones
            Dim diferenciaMed As Double = totalDispensado - consumoOdometro

            summaryRow += 1
            ws.Cell(summaryRow, 1).SetValue("Odometro Inicial:")
            ws.Cell(summaryRow, 1).Style.Font.Bold = True
            If hayOdometro Then
                ws.Cell(summaryRow, 2).SetValue(odoInicioMed)
                ws.Cell(summaryRow, 2).Style.NumberFormat.Format = "#,##0.00"
            Else
                ws.Cell(summaryRow, 2).SetValue("Sin medicion")
            End If

            summaryRow += 1
            ws.Cell(summaryRow, 1).SetValue("Odometro Final:")
            ws.Cell(summaryRow, 1).Style.Font.Bold = True
            If hayOdometro Then
                ws.Cell(summaryRow, 2).SetValue(odoFinalMed)
                ws.Cell(summaryRow, 2).Style.NumberFormat.Format = "#,##0.00"
            Else
                ws.Cell(summaryRow, 2).SetValue("Sin medicion")
            End If

            summaryRow += 1
            ws.Cell(summaryRow, 1).SetValue("Total Dispensado:")
            ws.Cell(summaryRow, 1).Style.Font.Bold = True
            ws.Cell(summaryRow, 2).SetValue(totalDispensado)
            ws.Cell(summaryRow, 2).Style.NumberFormat.Format = "#,##0.00"

            summaryRow += 1
            ws.Cell(summaryRow, 1).SetValue("Consumo segun Odometro:")
            ws.Cell(summaryRow, 1).Style.Font.Bold = True
            ws.Cell(summaryRow, 2).SetValue(consumoOdometro)
            ws.Cell(summaryRow, 2).Style.NumberFormat.Format = "#,##0.00"

            summaryRow += 1
            ws.Cell(summaryRow, 1).SetValue("Diferencia:")
            ws.Cell(summaryRow, 1).Style.Font.Bold = True
            ws.Cell(summaryRow, 2).SetValue(diferenciaMed)
            ws.Cell(summaryRow, 2).Style.NumberFormat.Format = "#,##0.00"
            ws.Cell(summaryRow, 2).Style.Font.Bold = True
            If diferenciaMed < 0 Then
                ws.Cell(summaryRow, 2).Style.Font.FontColor = XLColor.FromHtml("#C62828")
            ElseIf diferenciaMed = 0 Then
                ws.Cell(summaryRow, 2).Style.Font.FontColor = XLColor.FromHtml("#1565C0")
            End If

            ' ========== ODOMETRO POR TURNO ==========
            If chkUsarFecha.Checked Then
                Try
                    Using conOdo As MySqlConnection = ModuloConexion.ObtenerConexion()
                        conOdo.Open()
                        Dim sqlOdo As String = "SELECT despachador, MIN(odometroInicio) AS odoMin, MAX(odometroCierre) AS odoMax, fecha " &
                            "FROM cierre_turno WHERE fecha >= @fDesde AND fecha <= @fHasta " &
                            "GROUP BY despachador, fecha ORDER BY fecha ASC"

                        Using cmdOdo As New MySqlCommand(sqlOdo, conOdo)
                            cmdOdo.Parameters.AddWithValue("@fDesde", fechaDesdePk.Value.Date.ToString("yyyy-MM-dd"))
                            cmdOdo.Parameters.AddWithValue("@fHasta", fechaHastaPk.Value.Date.ToString("yyyy-MM-dd"))

                            Using readerOdo As MySqlDataReader = cmdOdo.ExecuteReader()
                                If readerOdo.HasRows Then
                                    summaryRow += 2
                                    ws.Cell(summaryRow, 1).SetValue("ODOMETRO POR TURNO")
                                    With ws.Cell(summaryRow, 1).Style
                                        .Font.Bold = True
                                        .Font.FontSize = 12
                                        .Fill.BackgroundColor = XLColor.FromHtml("#2E7D32")
                                        .Font.FontColor = XLColor.White
                                    End With
                                    ws.Range(summaryRow, 1, summaryRow, 4).Merge()

                                    summaryRow += 1
                                    ws.Cell(summaryRow, 1).SetValue("Despachador") : ws.Cell(summaryRow, 1).Style.Font.Bold = True
                                    ws.Cell(summaryRow, 2).SetValue("Fecha") : ws.Cell(summaryRow, 2).Style.Font.Bold = True
                                    ws.Cell(summaryRow, 3).SetValue("Odo. Inicio") : ws.Cell(summaryRow, 3).Style.Font.Bold = True
                                    ws.Cell(summaryRow, 4).SetValue("Odo. Cierre") : ws.Cell(summaryRow, 4).Style.Font.Bold = True

                                    Dim totalOdometro As Double = 0

                                    While readerOdo.Read()
                                        summaryRow += 1
                                        ws.Cell(summaryRow, 1).SetValue(readerOdo("despachador").ToString())
                                        ws.Cell(summaryRow, 2).SetValue(Convert.ToDateTime(readerOdo("fecha")).ToString("dd/MM/yyyy"))
                                        Dim odoMin As Double = If(readerOdo("odoMin") IsNot DBNull.Value, Convert.ToDouble(readerOdo("odoMin")), 0)
                                        Dim odoMax As Double = If(readerOdo("odoMax") IsNot DBNull.Value, Convert.ToDouble(readerOdo("odoMax")), 0)
                                        ws.Cell(summaryRow, 3).SetValue(odoMin) : ws.Cell(summaryRow, 3).Style.NumberFormat.Format = "#,##0.00"
                                        ws.Cell(summaryRow, 4).SetValue(odoMax) : ws.Cell(summaryRow, 4).Style.NumberFormat.Format = "#,##0.00"
                                        totalOdometro += (odoMax - odoMin)
                                    End While

                                    summaryRow += 1
                                    ws.Cell(summaryRow, 1).SetValue("Total segun Odometro:")
                                    ws.Cell(summaryRow, 1).Style.Font.Bold = True
                                    ws.Cell(summaryRow, 2).SetValue(totalOdometro)
                                    ws.Cell(summaryRow, 2).Style.NumberFormat.Format = "#,##0.00"
                                    ws.Cell(summaryRow, 2).Style.Font.Bold = True

                                    summaryRow += 1
                                    ws.Cell(summaryRow, 1).SetValue("Total Galones Vendidos:")
                                    ws.Cell(summaryRow, 1).Style.Font.Bold = True
                                    ws.Cell(summaryRow, 2).SetValue(totalGalones)
                                    ws.Cell(summaryRow, 2).Style.NumberFormat.Format = "#,##0.00"
                                    ws.Cell(summaryRow, 2).Style.Font.Bold = True

                                    summaryRow += 1
                                    Dim variacionTurno As Double = totalOdometro - totalGalones
                                    ws.Cell(summaryRow, 1).SetValue("Variacion:")
                                    ws.Cell(summaryRow, 1).Style.Font.Bold = True
                                    ws.Cell(summaryRow, 2).SetValue(variacionTurno)
                                    ws.Cell(summaryRow, 2).Style.NumberFormat.Format = "#,##0.00"
                                    ws.Cell(summaryRow, 2).Style.Font.Bold = True
                                    If variacionTurno < 0 Then
                                        ws.Cell(summaryRow, 2).Style.Font.FontColor = XLColor.FromHtml("#C62828")
                                    ElseIf variacionTurno = 0 Then
                                        ws.Cell(summaryRow, 2).Style.Font.FontColor = XLColor.FromHtml("#1565C0")
                                    End If
                                End If
                            End Using
                        End Using
                    End Using
                Catch
                End Try
            End If

            ' ========== AJUSTAR ANCHOS DE COLUMNAS ==========
            ws.Columns().AdjustToContents()

            For col As Integer = 1 To numColsVisibles
                If ws.Column(col).Width < 10 Then
                    ws.Column(col).Width = 10
                ElseIf ws.Column(col).Width > 40 Then
                    ws.Column(col).Width = 40
                End If
            Next

            ' ========== CONFIGURAR IMPRESION ==========
            ws.PageSetup.PageOrientation = XLPageOrientation.Landscape
            ws.PageSetup.FitToPages(1, 0)

            ' Guardar archivo
            workbook.SaveAs(rutaArchivo)
        End Using
    End Sub

End Class
