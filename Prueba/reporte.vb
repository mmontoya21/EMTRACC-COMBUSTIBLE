Imports System.Data
Imports MySql.Data.MySqlClient
Imports System.Text
Imports System.IO
Imports ClosedXML.Excel

Public Class reporte
    Dim con As New MySqlConnection

    Private Sub reporte_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        conectar()
        cargarCombos()
        cargarDatos()

        ' Estilos del DataGridView
        reporteDgv.RowsDefaultCellStyle.BackColor = Color.Bisque
        reporteDgv.AlternatingRowsDefaultCellStyle.BackColor = Color.Lavender
    End Sub

    Private Sub conectar()
        con = ModuloConexion.ObtenerConexion()
        Try
            If con.State = ConnectionState.Closed Then
                con.Open()
            End If
        Catch ex As Exception
            MessageBox.Show("Error de conexion: " & ex.Message, "Error")
        End Try
    End Sub

    Private Sub cargarCombos()
        Try
            ' Cargar despachadores unicos de la tabla comprobante
            despachadorCb.Items.Clear()
            despachadorCb.Items.Add("-- Todos --")

            Dim sqlDesp As String = "SELECT DISTINCT nombDesp FROM comprobante WHERE nombDesp IS NOT NULL AND nombDesp <> '' ORDER BY nombDesp"
            Using cmd As New MySqlCommand(sqlDesp, con)
                Using dr As MySqlDataReader = cmd.ExecuteReader()
                    While dr.Read()
                        despachadorCb.Items.Add(dr("nombDesp").ToString())
                    End While
                End Using
            End Using
            despachadorCb.SelectedIndex = 0

            ' Cargar periodos
            periodoCb.Items.Clear()
            periodoCb.Items.Add("-- Todos --")
            For i As Integer = 1 To 12
                periodoCb.Items.Add(i.ToString())
            Next
            periodoCb.SelectedIndex = 0

            ' Cargar semanas
            semanaCb.Items.Clear()
            semanaCb.Items.Add("-- Todas --")
            For i As Integer = 1 To 53
                semanaCb.Items.Add(i.ToString())
            Next
            semanaCb.SelectedIndex = 0

        Catch ex As Exception
            MessageBox.Show("Error al cargar combos: " & ex.Message, "Error")
        End Try
    End Sub

    Private Sub cargarDatos()
        Try
            If con.State = ConnectionState.Closed Then
                con.Open()
            End If

            ' Construir query con filtros dinamicos
            Dim sql As New StringBuilder()
            sql.Append("SELECT nCompro AS 'Comprobante', nBoleta AS 'Boleta', DATE_FORMAT(fecha, '%d/%m/%Y') AS 'Fecha', ")
            sql.Append("placaCbz AS 'Placa', nConte AS 'Contenedor', codiProp AS 'Cod.Prop', propCbz AS 'Propietario', galDesp AS 'Galones', ")
            sql.Append("valor AS 'Valor', total AS 'Total', ruta AS 'Ruta', nombCond AS 'Conductor', ")
            sql.Append("nombDesp AS 'Despachador', periodo AS 'Periodo', semana AS 'Semana', ")
            sql.Append("COALESCE(anulado, 0) AS 'anulado' ")
            sql.Append("FROM comprobante WHERE 1=1 ")

            Dim cmd As New MySqlCommand()
            cmd.Connection = con

            ' Filtro por fecha
            If chkUsarFecha.Checked Then
                sql.Append("AND fecha >= @fechaDesde AND fecha <= @fechaHasta ")
                cmd.Parameters.AddWithValue("@fechaDesde", fechaDesdePk.Value.Date)
                cmd.Parameters.AddWithValue("@fechaHasta", fechaHastaPk.Value.Date)
            End If

            ' Filtro por despachador
            If despachadorCb.SelectedIndex > 0 Then
                sql.Append("AND nombDesp = @despachador ")
                cmd.Parameters.AddWithValue("@despachador", despachadorCb.SelectedItem.ToString())
            End If

            ' Filtro por periodo
            If periodoCb.SelectedIndex > 0 Then
                sql.Append("AND periodo = @periodo ")
                cmd.Parameters.AddWithValue("@periodo", periodoCb.SelectedItem.ToString())
            End If

            ' Filtro por semana
            If semanaCb.SelectedIndex > 0 Then
                sql.Append("AND semana = @semana ")
                cmd.Parameters.AddWithValue("@semana", semanaCb.SelectedItem.ToString())
            End If

            sql.Append("ORDER BY nCompro ASC")

            cmd.CommandText = sql.ToString()

            Dim adapter As New MySqlDataAdapter(cmd)
            Dim dt As New DataTable()
            adapter.Fill(dt)

            reporteDgv.DataSource = dt

            ' Calcular totales (excluyendo anulados)
            Dim totalGal As Double = 0
            Dim totalMonto As Double = 0
            Dim totalAnulados As Integer = 0
            For Each row As DataRow In dt.Rows
                Dim esAnulado As Boolean = (dt.Columns.Contains("anulado") AndAlso
                    row("anulado") IsNot DBNull.Value AndAlso Convert.ToInt32(row("anulado")) = 1)
                If esAnulado Then
                    totalAnulados += 1
                Else
                    If row("Galones") IsNot DBNull.Value Then
                        totalGal += Convert.ToDouble(row("Galones"))
                    End If
                    If row("Total") IsNot DBNull.Value Then
                        totalMonto += Convert.ToDouble(row("Total"))
                    End If
                End If
            Next

            ' Actualizar contador con resumen
            LblTotal.Text = String.Format("Registros: {0}  |  Anulados: {1}  |  Total Galones: {2:N2}  |  Monto Total: L. {3:N2}", dt.Rows.Count, totalAnulados, totalGal, totalMonto)

            ' Consultar odometro de cierre_turno
            lblOdometro.Text = ""
            If chkUsarFecha.Checked OrElse despachadorCb.SelectedIndex > 0 Then
                Try
                    Dim sqlOdo As New StringBuilder()
                    sqlOdo.Append("SELECT despachador, turnoNombre, MIN(odometroInicio) AS odoMin, MAX(odometroCierre) AS odoMax, fecha ")
                    sqlOdo.Append("FROM cierre_turno WHERE 1=1 ")

                    Dim cmdOdo As New MySqlCommand()
                    cmdOdo.Connection = con
                    If con.State = ConnectionState.Closed Then con.Open()

                    If chkUsarFecha.Checked Then
                        sqlOdo.Append("AND fecha >= @fDesde AND fecha <= @fHasta ")
                        cmdOdo.Parameters.AddWithValue("@fDesde", fechaDesdePk.Value.Date.ToString("yyyy-MM-dd"))
                        cmdOdo.Parameters.AddWithValue("@fHasta", fechaHastaPk.Value.Date.ToString("yyyy-MM-dd"))
                    End If
                    If despachadorCb.SelectedIndex > 0 Then
                        sqlOdo.Append("AND despachador = @desp ")
                        cmdOdo.Parameters.AddWithValue("@desp", despachadorCb.SelectedItem.ToString().ToUpper())
                    End If

                    sqlOdo.Append("GROUP BY despachador, fecha ORDER BY fecha ASC")
                    cmdOdo.CommandText = sqlOdo.ToString()

                    Dim odoTexto As New StringBuilder()
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

                    If odoTexto.Length > 0 Then
                        lblOdometro.Text = "Odometro: " & odoTexto.ToString()
                    End If
                Catch
                    ' Si falla la consulta de odometro, no bloquear
                End Try
            End If

            ' Ajustar anchos de columnas
            configurarColumnas()

        Catch ex As Exception
            MessageBox.Show("Error al cargar datos: " & ex.Message, "Error")
        Finally
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
        End Try
    End Sub

    Private Sub configurarColumnas()
        If reporteDgv.Columns.Count > 0 Then
            If reporteDgv.Columns.Contains("anulado") Then
                reporteDgv.Columns("anulado").Visible = False
            End If
            reporteDgv.Columns("Comprobante").Width = 80
            reporteDgv.Columns("Boleta").Width = 70
            reporteDgv.Columns("Fecha").Width = 80
            reporteDgv.Columns("Placa").Width = 80
            reporteDgv.Columns("Contenedor").Width = 90
            reporteDgv.Columns("Cod.Prop").Width = 70
            reporteDgv.Columns("Propietario").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            reporteDgv.Columns("Galones").Width = 70
            reporteDgv.Columns("Valor").Width = 70
            reporteDgv.Columns("Total").Width = 90
            reporteDgv.Columns("Ruta").Width = 150
            reporteDgv.Columns("Conductor").Width = 120
            reporteDgv.Columns("Despachador").Width = 100
            reporteDgv.Columns("Periodo").Width = 55
            reporteDgv.Columns("Semana").Width = 55
        End If
    End Sub

    Private Sub buscarBtn_Click(sender As Object, e As EventArgs) Handles buscarBtn.Click
        cargarDatos()
    End Sub

    Private Sub limpiarBtn_Click(sender As Object, e As EventArgs) Handles limpiarBtn.Click
        ' Limpiar filtros
        chkUsarFecha.Checked = False
        fechaDesdePk.Value = DateTime.Today
        fechaHastaPk.Value = DateTime.Today
        despachadorCb.SelectedIndex = 0
        periodoCb.SelectedIndex = 0
        semanaCb.SelectedIndex = 0

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
            saveDialog.FileName = "Reporte_Comprobantes_" & DateTime.Now.ToString("yyyyMMdd_HHmmss")
            saveDialog.Title = "Exportar Reporte"

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

        ' Encabezados
        Dim headers As New List(Of String)
        For Each col As DataGridViewColumn In reporteDgv.Columns
            headers.Add("""" & col.HeaderText & """")
        Next
        sb.AppendLine(String.Join(",", headers))

        ' Datos
        For Each row As DataGridViewRow In reporteDgv.Rows
            If Not row.IsNewRow Then
                Dim valores As New List(Of String)
                For Each cell As DataGridViewCell In row.Cells
                    Dim valor As String = If(cell.Value IsNot Nothing, cell.Value.ToString(), "")
                    ' Escapar comillas dobles y envolver en comillas
                    valor = """" & valor.Replace("""", """""") & """"
                    valores.Add(valor)
                Next
                sb.AppendLine(String.Join(",", valores))
            End If
        Next

        ' Guardar archivo con encoding UTF-8 con BOM para que Excel reconozca caracteres especiales
        File.WriteAllText(rutaArchivo, sb.ToString(), Encoding.UTF8)
    End Sub

    Private Sub ExportarExcel(rutaArchivo As String)
        Using workbook As New XLWorkbook()
            Dim ws As IXLWorksheet = workbook.Worksheets.Add("Comprobantes")

            ' ========== TITULO DEL REPORTE ==========
            ws.Cell(1, 1).SetValue("REPORTE DE COMPROBANTES DE COMBUSTIBLE")
            ws.Range(1, 1, 1, reporteDgv.Columns.Count).Merge()
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
            If despachadorCb.SelectedIndex > 0 Then
                filtrosAplicados &= "Despachador: " & despachadorCb.SelectedItem.ToString() & " | "
            End If
            If periodoCb.SelectedIndex > 0 Then
                filtrosAplicados &= "Periodo: " & periodoCb.SelectedItem.ToString() & " | "
            End If
            If semanaCb.SelectedIndex > 0 Then
                filtrosAplicados &= "Semana: " & semanaCb.SelectedItem.ToString() & " | "
            End If
            If filtrosAplicados = "Filtros: " Then
                filtrosAplicados = "Sin filtros aplicados"
            Else
                filtrosAplicados = filtrosAplicados.TrimEnd(" | ".ToCharArray())
            End If

            ws.Cell(infoFila, 1).SetValue(filtrosAplicados)
            ws.Range(infoFila, 1, infoFila, reporteDgv.Columns.Count).Merge()
            With ws.Cell(infoFila, 1).Style
                .Font.Italic = True
                .Font.FontSize = 10
                .Font.FontColor = XLColor.DarkGray
            End With

            ' Fecha de generacion
            infoFila += 1
            ws.Cell(infoFila, 1).SetValue("Generado: " & DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"))
            ws.Range(infoFila, 1, infoFila, reporteDgv.Columns.Count).Merge()
            With ws.Cell(infoFila, 1).Style
                .Font.Italic = True
                .Font.FontSize = 10
                .Font.FontColor = XLColor.DarkGray
            End With

            ' ========== ENCABEZADOS DE COLUMNAS ==========
            Dim headerRow As Integer = infoFila + 2
            For col As Integer = 0 To reporteDgv.Columns.Count - 1
                Dim cell As IXLCell = ws.Cell(headerRow, col + 1)
                cell.SetValue(reporteDgv.Columns(col).HeaderText)
                With cell.Style
                    .Font.Bold = True
                    .Font.FontColor = XLColor.White
                    .Fill.BackgroundColor = XLColor.FromHtml("#4A5A78")
                    .Alignment.Horizontal = XLAlignmentHorizontalValues.Center
                    .Border.OutsideBorder = XLBorderStyleValues.Thin
                    .Border.OutsideBorderColor = XLColor.Black
                End With
            Next
            ws.Row(headerRow).Height = 22

            ' ========== DATOS ==========
            Dim dataRowStart As Integer = headerRow + 1
            Dim totalGalones As Double = 0
            Dim totalValor As Double = 0
            Dim totalAnuladosExcel As Integer = 0

            For row As Integer = 0 To reporteDgv.Rows.Count - 1
                If Not reporteDgv.Rows(row).IsNewRow Then
                    Dim excelRow As Integer = dataRowStart + row
                    Dim isAlternate As Boolean = (row Mod 2 = 1)

                    ' Detectar si la fila esta anulada
                    Dim filaAnulada As Boolean = False
                    If reporteDgv.Columns.Contains("anulado") Then
                        Dim anuladoVal = reporteDgv.Rows(row).Cells("anulado").Value
                        filaAnulada = (anuladoVal IsNot Nothing AndAlso Not IsDBNull(anuladoVal) AndAlso Convert.ToInt32(anuladoVal) = 1)
                    End If
                    If filaAnulada Then totalAnuladosExcel += 1

                    For col As Integer = 0 To reporteDgv.Columns.Count - 1
                        If Not reporteDgv.Columns(col).Visible Then Continue For

                        Dim cell As IXLCell = ws.Cell(excelRow, col + 1)
                        Dim valor As Object = reporteDgv.Rows(row).Cells(col).Value
                        Dim headerName As String = reporteDgv.Columns(col).HeaderText

                        ' Establecer valor
                        If valor IsNot Nothing AndAlso Not String.IsNullOrEmpty(valor.ToString()) Then
                            If headerName = "Galones" OrElse headerName = "Valor" OrElse headerName = "Total" Then
                                Dim numVal As Double
                                If Double.TryParse(valor.ToString(), numVal) Then
                                    cell.SetValue(numVal)
                                    cell.Style.NumberFormat.Format = "#,##0.00"
                                    If Not filaAnulada Then
                                        If headerName = "Galones" Then
                                            totalGalones += numVal
                                        ElseIf headerName = "Total" Then
                                            totalValor += numVal
                                        End If
                                    End If
                                Else
                                    cell.SetValue(valor.ToString())
                                End If
                            ElseIf headerName = "Comprobante" OrElse headerName = "Boleta" OrElse headerName = "Periodo" OrElse headerName = "Semana" Then
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
                            If filaAnulada Then
                                .Fill.BackgroundColor = XLColor.FromHtml("#FFC8C8")
                                .Font.FontColor = XLColor.DarkRed
                            ElseIf isAlternate Then
                                .Fill.BackgroundColor = XLColor.FromHtml("#F0F0F5")
                            Else
                                .Fill.BackgroundColor = XLColor.White
                            End If
                            If headerName = "Galones" OrElse headerName = "Valor" OrElse headerName = "Total" OrElse headerName = "Comprobante" OrElse headerName = "Boleta" OrElse headerName = "Periodo" OrElse headerName = "Semana" Then
                                .Alignment.Horizontal = XLAlignmentHorizontalValues.Right
                            ElseIf headerName = "Fecha" OrElse headerName = "Contenedor" OrElse headerName = "Cod.Prop" OrElse headerName = "Placa" Then
                                .Alignment.Horizontal = XLAlignmentHorizontalValues.Center
                            End If
                        End With
                    Next
                End If
            Next

            ' ========== FILA DE TOTALES ==========
            Dim totalRow As Integer = dataRowStart + reporteDgv.Rows.Count
            Dim galonesColIndex As Integer = -1
            Dim valorColIndex As Integer = -1
            Dim totalColIndex As Integer = -1

            For col As Integer = 0 To reporteDgv.Columns.Count - 1
                If reporteDgv.Columns(col).HeaderText = "Galones" Then
                    galonesColIndex = col + 1
                ElseIf reporteDgv.Columns(col).HeaderText = "Valor" Then
                    valorColIndex = col + 1
                ElseIf reporteDgv.Columns(col).HeaderText = "Total" Then
                    totalColIndex = col + 1
                End If
            Next

            ' Etiqueta TOTAL
            ws.Cell(totalRow, 1).SetValue("TOTAL")
            With ws.Cell(totalRow, 1).Style
                .Font.Bold = True
                .Fill.BackgroundColor = XLColor.FromHtml("#4A5A78")
                .Font.FontColor = XLColor.White
            End With

            ' Merge hasta la columna antes de Galones o Valor
            Dim mergeEnd As Integer = Math.Max(1, Math.Min(galonesColIndex, valorColIndex) - 1)
            If mergeEnd > 1 Then
                ws.Range(totalRow, 1, totalRow, mergeEnd).Merge()
            End If

            ' Estilo para toda la fila de totales
            For col As Integer = 1 To reporteDgv.Columns.Count
                Dim cell As IXLCell = ws.Cell(totalRow, col)
                With cell.Style
                    .Border.OutsideBorder = XLBorderStyleValues.Medium
                    .Border.OutsideBorderColor = XLColor.Black
                    If col <> 1 Then
                        .Fill.BackgroundColor = XLColor.FromHtml("#E8E8F0")
                    End If
                End With
            Next

            ' Valores totales
            If galonesColIndex > 0 Then
                Dim cellGal As IXLCell = ws.Cell(totalRow, galonesColIndex)
                cellGal.SetValue(totalGalones)
                With cellGal.Style
                    .NumberFormat.Format = "#,##0.00"
                    .Font.Bold = True
                    .Fill.BackgroundColor = XLColor.FromHtml("#D4E6F1")
                    .Alignment.Horizontal = XLAlignmentHorizontalValues.Right
                End With
            End If

            If totalColIndex > 0 Then
                Dim cellTot As IXLCell = ws.Cell(totalRow, totalColIndex)
                cellTot.SetValue(totalValor)
                With cellTot.Style
                    .NumberFormat.Format = "#,##0.00"
                    .Font.Bold = True
                    .Fill.BackgroundColor = XLColor.FromHtml("#D5F5E3")
                    .Alignment.Horizontal = XLAlignmentHorizontalValues.Right
                End With
            End If

            ' ========== RESUMEN ESTADISTICO ==========
            Dim summaryRow As Integer = totalRow + 2
            ws.Cell(summaryRow, 1).SetValue("RESUMEN")
            With ws.Cell(summaryRow, 1).Style
                .Font.Bold = True
                .Font.FontSize = 12
                .Fill.BackgroundColor = XLColor.FromHtml("#6A7EA8")
                .Font.FontColor = XLColor.White
            End With
            ws.Range(summaryRow, 1, summaryRow, 4).Merge()

            ' Mostrar despachador si esta filtrado
            If despachadorCb.SelectedIndex > 0 Then
                summaryRow += 1
                ws.Cell(summaryRow, 1).SetValue("Despachador:")
                ws.Cell(summaryRow, 1).Style.Font.Bold = True
                ws.Cell(summaryRow, 2).SetValue(despachadorCb.SelectedItem.ToString())
                ws.Range(summaryRow, 2, summaryRow, 4).Merge()
                ws.Cell(summaryRow, 2).Style.Font.FontColor = XLColor.FromHtml("#2E86AB")
                ws.Cell(summaryRow, 2).Style.Font.Bold = True
                ws.Cell(summaryRow, 2).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center
            End If

            ' Mostrar periodo si esta filtrado
            If periodoCb.SelectedIndex > 0 Then
                summaryRow += 1
                ws.Cell(summaryRow, 1).SetValue("Periodo:")
                ws.Cell(summaryRow, 2).SetValue(periodoCb.SelectedItem.ToString())
                ws.Cell(summaryRow, 1).Style.Font.Bold = True
            End If

            ' Mostrar semana si esta filtrada
            If semanaCb.SelectedIndex > 0 Then
                summaryRow += 1
                ws.Cell(summaryRow, 1).SetValue("Semana:")
                ws.Cell(summaryRow, 2).SetValue(semanaCb.SelectedItem.ToString())
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
            ws.Cell(summaryRow, 2).SetValue(reporteDgv.Rows.Count)
            ws.Cell(summaryRow, 1).Style.Font.Bold = True

            summaryRow += 1
            ws.Cell(summaryRow, 1).SetValue("Registros Anulados:")
            ws.Cell(summaryRow, 2).SetValue(totalAnuladosExcel)
            ws.Cell(summaryRow, 1).Style.Font.Bold = True
            ws.Cell(summaryRow, 2).Style.Font.FontColor = XLColor.Red

            summaryRow += 1
            ws.Cell(summaryRow, 1).SetValue("Total Galones:")
            ws.Cell(summaryRow, 2).SetValue(totalGalones)
            ws.Cell(summaryRow, 2).Style.NumberFormat.Format = "#,##0.00"
            ws.Cell(summaryRow, 1).Style.Font.Bold = True

            summaryRow += 1
            ws.Cell(summaryRow, 1).SetValue("Monto Total:")
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
                    End If
                    If despachadorCb.SelectedIndex > 0 Then
                        sqlMed.Append("AND despachador = @desp ")
                        cmdMed.Parameters.AddWithValue("@desp", despachadorCb.SelectedItem.ToString().ToUpper())
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
            If chkUsarFecha.Checked OrElse despachadorCb.SelectedIndex > 0 Then
                Try
                    Using conOdo As MySqlConnection = ModuloConexion.ObtenerConexion()
                        conOdo.Open()
                        Dim sqlOdo As New System.Text.StringBuilder()
                        sqlOdo.Append("SELECT despachador, MIN(odometroInicio) AS odoMin, MAX(odometroCierre) AS odoMax, fecha ")
                        sqlOdo.Append("FROM cierre_turno WHERE 1=1 ")

                        Dim cmdOdo As New MySqlCommand()
                        cmdOdo.Connection = conOdo

                        If chkUsarFecha.Checked Then
                            sqlOdo.Append("AND fecha >= @fDesde AND fecha <= @fHasta ")
                            cmdOdo.Parameters.AddWithValue("@fDesde", fechaDesdePk.Value.Date.ToString("yyyy-MM-dd"))
                            cmdOdo.Parameters.AddWithValue("@fHasta", fechaHastaPk.Value.Date.ToString("yyyy-MM-dd"))
                        End If
                        If despachadorCb.SelectedIndex > 0 Then
                            sqlOdo.Append("AND despachador = @desp ")
                            cmdOdo.Parameters.AddWithValue("@desp", despachadorCb.SelectedItem.ToString().ToUpper())
                        End If

                        sqlOdo.Append("GROUP BY despachador, fecha ORDER BY fecha ASC")
                        cmdOdo.CommandText = sqlOdo.ToString()

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
                Catch
                End Try
            End If

            ' ========== AJUSTAR ANCHOS DE COLUMNAS ==========
            ws.Columns().AdjustToContents()

            For col As Integer = 1 To reporteDgv.Columns.Count
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

    Private Sub reporteDgv_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles reporteDgv.CellFormatting
        Dim dgv As DataGridView = CType(sender, DataGridView)
        If dgv.Columns.Contains("anulado") AndAlso e.RowIndex >= 0 Then
            Dim anuladoVal = dgv.Rows(e.RowIndex).Cells("anulado").Value
            If anuladoVal IsNot Nothing AndAlso Not IsDBNull(anuladoVal) AndAlso Convert.ToInt32(anuladoVal) = 1 Then
                e.CellStyle.BackColor = Color.FromArgb(255, 200, 200)
                e.CellStyle.ForeColor = Color.DarkRed
            End If
        End If
    End Sub

    Private Sub reporte_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Try
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
        Catch ex As Exception
            ' Ignorar errores al cerrar
        End Try
    End Sub
End Class
