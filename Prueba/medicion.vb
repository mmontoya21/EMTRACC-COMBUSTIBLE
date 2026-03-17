Imports System.Data
Imports MySql.Data.MySqlClient
Public Class medicion
    Dim adaptador As New MySqlDataAdapter
    Dim datos As DataSet
    Dim con As New MySqlConnection

    ' Valores para la grafica
    Private ultimoGalInicio As Double = 0
    Private ultimoGalEsperado As Double = 0
    Private ultimoGalFinal As Double = 0
    Private ultimoCapacidad As Double = 0
    Private ultimaDiferencia As Double = 0

    Private Sub medicion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        conectar()
        act()
        listadoMedDgv()

        EstilizarDataGridView(MedDGV)

        Me.BackColor = Color.SteelBlue
        PanelP.Enabled = False

        ' Pre-llenar periodo y semana desde la sesion
        If ModuloConexion.PeriodoSesion <> "" Then
            periodoCb.Text = ModuloConexion.PeriodoSesion
        End If
        If ModuloConexion.SemanaSesion <> "" Then
            semanaCb.Text = ModuloConexion.SemanaSesion
        End If

        AddHandler PanelGrafica.Paint, AddressOf PanelGrafica_Paint
        cargarUltimaMedicion()
    End Sub

    Private Sub act()
        Me.NuevoBtn.Enabled = True
        Me.EditarBtn.Enabled = False
        Me.GuardarBtn.Enabled = False
        Me.ModificarBtn.Enabled = False
        Me.CancelarBtn.Enabled = False
        Me.EliminarBtn.Enabled = False
        Me.CalcularBtn.Enabled = False
        If ModuloConexion.EsSoloLectura() Then NuevoBtn.Enabled = False
    End Sub

    Private Sub conectar()
        con = ModuloConexion.ObtenerConexion()
        Try
            If con.State = ConnectionState.Closed Then
                con.Open()
            End If
        Catch ex As Exception
            MsgBox("No se conecto por: " & ex.Message)
        End Try
    End Sub

    Private Sub listadoMedDgv()
        Try
            If con.State = ConnectionState.Closed Then con.Open()

            Dim table As New DataTable()
            Dim sql As String = "SELECT idMedida, DATE_FORMAT(fecha, '%d/%m/%Y') AS fecha, periodo, semana, " &
                "galonesCalc, galonesMed, galDespachados, galEsperados, diferencia " &
                "FROM tanquemed ORDER BY idMedida DESC"
            Dim adaptadorListado As New MySqlDataAdapter(sql, con)
            adaptadorListado.Fill(table)

            MedDGV.DataSource = table
            ListadoD()

            Dim totalRegistros As Integer = table.Rows.Count
            lblTotales.Text = String.Format("Registros: {0}", totalRegistros)

        Catch ex As Exception
            MessageBox.Show("Error al cargar datos: " & ex.Message, "Error")
        Finally
            If con.State = ConnectionState.Open Then con.Close()
        End Try
    End Sub

    Private Sub ListadoD()
        If MedDGV.Columns.Count < 9 Then Exit Sub

        MedDGV.Columns(0).HeaderText = "Id"
        MedDGV.Columns(0).Width = 40

        MedDGV.Columns(1).HeaderText = "Fecha"
        MedDGV.Columns(1).Width = 80

        MedDGV.Columns(2).HeaderText = "Per"
        MedDGV.Columns(2).Width = 35

        MedDGV.Columns(3).HeaderText = "Sem"
        MedDGV.Columns(3).Width = 35

        MedDGV.Columns(4).HeaderText = "Gal. Inicio"
        MedDGV.Columns(4).Width = 80

        MedDGV.Columns(5).HeaderText = "Gal. Final"
        MedDGV.Columns(5).Width = 80

        MedDGV.Columns(6).HeaderText = "Despachados"
        MedDGV.Columns(6).Width = 80

        MedDGV.Columns(7).HeaderText = "Esperados"
        MedDGV.Columns(7).Width = 75

        MedDGV.Columns(8).HeaderText = "Diferencia"
        MedDGV.Columns(8).Width = 75
    End Sub

    Sub limpiar()
        Me.fechaTb.Text = ""
        Me.galonesCalcTb.Text = ""
        Me.pglCalTb.Text = ""
        Me.galonesMedTb.Text = ""
        Me.pglMedTb.Text = ""
        Me.periodoCb.SelectedIndex = -1
        Me.semanaCb.SelectedIndex = -1
        Me.capacidadTb.Text = ""
        Me.galRecibidosTb.Text = ""
        Me.galDespachadosTb.Text = ""
        Me.galEsperadosTb.Text = ""
        Me.diferenciaTb.Text = ""
        Me.diferenciaTb.ForeColor = Color.White
        Me.observacionesTb.Text = ""
    End Sub

    Private Sub NuevoBtn_Click(sender As Object, e As EventArgs) Handles NuevoBtn.Click
        limpiar()
        fechaTb.Text = Today.ToString("yyyy/MM/dd")

        ' Pre-llenar periodo y semana desde la sesion
        If ModuloConexion.PeriodoSesion <> "" Then
            periodoCb.Text = ModuloConexion.PeriodoSesion
        End If
        If ModuloConexion.SemanaSesion <> "" Then
            semanaCb.Text = ModuloConexion.SemanaSesion
        End If

        ' Pre-llenar capacidad del ultimo registro
        cargarUltimaCapacidad()

        PanelP.Enabled = True
        GuardarBtn.Enabled = True
        CalcularBtn.Enabled = True
        MedDGV.Enabled = False
        CancelarBtn.Enabled = True
        NuevoBtn.Enabled = False
        galonesCalcTb.Focus()
    End Sub

    Private Sub EditarBtn_Click(sender As Object, e As EventArgs) Handles EditarBtn.Click
        PanelP.Enabled = True
        Me.MedDGV.Enabled = False
        Me.GuardarBtn.Enabled = False
        Me.GuardarBtn.Visible = False
        Me.ModificarBtn.Enabled = True
        Me.ModificarBtn.Visible = True
        Me.EditarBtn.Enabled = False
        Me.CancelarBtn.Enabled = True
        Me.NuevoBtn.Enabled = False
        Me.EliminarBtn.Enabled = False
        Me.CalcularBtn.Enabled = True
    End Sub

    Private Sub GuardarBtn_Click(sender As Object, e As EventArgs) Handles GuardarBtn.Click
        If con.State = ConnectionState.Closed Then con.Open()

        Dim galCalc As Double = 0 : Double.TryParse(galonesCalcTb.Text, galCalc)
        Dim pglC As Double = 0 : Double.TryParse(pglCalTb.Text, pglC)
        Dim galMed As Double = 0 : Double.TryParse(galonesMedTb.Text, galMed)
        Dim pglM As Double = 0 : Double.TryParse(pglMedTb.Text, pglM)
        Dim capTanque As Double = 0 : Double.TryParse(capacidadTb.Text, capTanque)
        Dim galRec As Double = 0 : Double.TryParse(galRecibidosTb.Text, galRec)
        Dim galDesp As Double = 0 : Double.TryParse(galDespachadosTb.Text, galDesp)
        Dim galEsp As Double = 0 : Double.TryParse(galEsperadosTb.Text, galEsp)
        Dim diff As Double = 0 : Double.TryParse(diferenciaTb.Text, diff)

        Try
            Dim sql As String = "INSERT INTO tanquemed (fecha, galonesCalc, pglCal, galonesMed, pglMed, " &
                "periodo, semana, capacidadTanque, galRecibidos, galDespachados, galEsperados, diferencia, observaciones) " &
                "VALUES(@fecha, @galonesCalc, @pglCal, @galonesMed, @pglMed, " &
                "@periodo, @semana, @capacidadTanque, @galRecibidos, @galDespachados, @galEsperados, @diferencia, @observaciones)"
            Dim guardar As New MySqlCommand(sql, con)

            guardar.Parameters.AddWithValue("@fecha", fechaTb.Text)
            guardar.Parameters.AddWithValue("@galonesCalc", galCalc)
            guardar.Parameters.AddWithValue("@pglCal", pglC)
            guardar.Parameters.AddWithValue("@galonesMed", galMed)
            guardar.Parameters.AddWithValue("@pglMed", pglM)
            guardar.Parameters.AddWithValue("@periodo", If(periodoCb.SelectedIndex >= 0, CInt(periodoCb.Text), CObj(DBNull.Value)))
            guardar.Parameters.AddWithValue("@semana", If(semanaCb.SelectedIndex >= 0, CInt(semanaCb.Text), CObj(DBNull.Value)))
            guardar.Parameters.AddWithValue("@capacidadTanque", capTanque)
            guardar.Parameters.AddWithValue("@galRecibidos", galRec)
            guardar.Parameters.AddWithValue("@galDespachados", galDesp)
            guardar.Parameters.AddWithValue("@galEsperados", galEsp)
            guardar.Parameters.AddWithValue("@diferencia", diff)
            guardar.Parameters.AddWithValue("@observaciones", observacionesTb.Text)

            guardar.ExecuteNonQuery()
            MsgBox("Registro guardado")

            limpiar()
            act()
            MedDGV.Enabled = True
            listadoMedDgv()
            cargarUltimaMedicion()

        Catch ex As Exception
            MsgBox("Elemento no pudo ser almacenado: " & ex.Message)
        Finally
            If con.State = ConnectionState.Open Then con.Close()
        End Try
    End Sub

    Private Sub ModificarBtn_Click(sender As Object, e As EventArgs) Handles ModificarBtn.Click
        If con.State = ConnectionState.Closed Then con.Open()

        Dim galCalc As Double = 0 : Double.TryParse(galonesCalcTb.Text, galCalc)
        Dim pglC As Double = 0 : Double.TryParse(pglCalTb.Text, pglC)
        Dim galMed As Double = 0 : Double.TryParse(galonesMedTb.Text, galMed)
        Dim pglM As Double = 0 : Double.TryParse(pglMedTb.Text, pglM)
        Dim capTanque As Double = 0 : Double.TryParse(capacidadTb.Text, capTanque)
        Dim galRec As Double = 0 : Double.TryParse(galRecibidosTb.Text, galRec)
        Dim galDesp As Double = 0 : Double.TryParse(galDespachadosTb.Text, galDesp)
        Dim galEsp As Double = 0 : Double.TryParse(galEsperadosTb.Text, galEsp)
        Dim diff As Double = 0 : Double.TryParse(diferenciaTb.Text, diff)

        Try
            Dim sql As String = "UPDATE tanquemed SET fecha=@fecha, galonesCalc=@galonesCalc, pglCal=@pglCal, " &
                "galonesMed=@galonesMed, pglMed=@pglMed, periodo=@periodo, semana=@semana, " &
                "capacidadTanque=@capacidadTanque, galRecibidos=@galRecibidos, galDespachados=@galDespachados, " &
                "galEsperados=@galEsperados, diferencia=@diferencia, observaciones=@observaciones " &
                "WHERE idMedida = @id"
            Dim actualizar As New MySqlCommand(sql, con)

            actualizar.Parameters.AddWithValue("@fecha", fechaTb.Text)
            actualizar.Parameters.AddWithValue("@galonesCalc", galCalc)
            actualizar.Parameters.AddWithValue("@pglCal", pglC)
            actualizar.Parameters.AddWithValue("@galonesMed", galMed)
            actualizar.Parameters.AddWithValue("@pglMed", pglM)
            actualizar.Parameters.AddWithValue("@periodo", If(periodoCb.SelectedIndex >= 0, CInt(periodoCb.Text), CObj(DBNull.Value)))
            actualizar.Parameters.AddWithValue("@semana", If(semanaCb.SelectedIndex >= 0, CInt(semanaCb.Text), CObj(DBNull.Value)))
            actualizar.Parameters.AddWithValue("@capacidadTanque", capTanque)
            actualizar.Parameters.AddWithValue("@galRecibidos", galRec)
            actualizar.Parameters.AddWithValue("@galDespachados", galDesp)
            actualizar.Parameters.AddWithValue("@galEsperados", galEsp)
            actualizar.Parameters.AddWithValue("@diferencia", diff)
            actualizar.Parameters.AddWithValue("@observaciones", observacionesTb.Text)
            actualizar.Parameters.AddWithValue("@id", buscartxt.Text)

            actualizar.ExecuteNonQuery()
            MsgBox("Registro Actualizado")

            act()
            PanelP.Enabled = False
            MedDGV.Enabled = True
            Me.GuardarBtn.Visible = True
            listadoMedDgv()
            cargarUltimaMedicion()

        Catch ex As Exception
            MsgBox("Error al actualizar: " & ex.Message)
        Finally
            If con.State = ConnectionState.Open Then con.Close()
        End Try
    End Sub

    Private Sub EliminarBtn_Click(sender As Object, e As EventArgs) Handles EliminarBtn.Click
        Try
            Dim opc As DialogResult = MsgBox("¿Desea Eliminar este registro?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Eliminar")
            If opc = Windows.Forms.DialogResult.Yes Then
                If con.State = ConnectionState.Closed Then con.Open()

                Dim eliminar As String = "DELETE FROM tanquemed WHERE idMedida = @id"
                Dim eli As New MySqlCommand(eliminar, con)
                eli.Parameters.AddWithValue("@id", buscartxt.Text)
                eli.ExecuteNonQuery()

                limpiar()
                listadoMedDgv()
                cargarUltimaMedicion()
            End If
        Catch ex As Exception
            MessageBox.Show("Error al eliminar: " & ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Finally
            If con.State = ConnectionState.Open Then con.Close()
        End Try

        act()
        PanelP.Enabled = False
    End Sub

    Private Sub CancelarBtn_Click(sender As Object, e As EventArgs) Handles CancelarBtn.Click
        act()
        PanelP.Enabled = False
        MedDGV.Enabled = True
        Me.GuardarBtn.Visible = True
    End Sub

    Private Sub MedDGV_Click(sender As Object, e As EventArgs) Handles MedDGV.Click
        If Me.MedDGV.RowCount = 0 Then
            MessageBox.Show("No hay datos a mostrar")
        Else
            Dim y As Integer = Me.MedDGV.CurrentRow.Index
            Dim idcod As Integer = Me.MedDGV.Item(0, y).Value
            buscartxt.Text = idcod
            Seleccion()
            Me.EditarBtn.Enabled = Not ModuloConexion.EsSoloLectura()
            Me.EliminarBtn.Enabled = Not ModuloConexion.EsSoloLectura()
        End If
    End Sub

    Public Sub Seleccion()
        Try
            If con.State = ConnectionState.Closed Then con.Open()

            If buscartxt.Text <> "" Then
                Dim consulta As String = "SELECT * FROM tanquemed WHERE idMedida = @id"
                Dim cmd As New MySqlCommand(consulta, con)
                cmd.Parameters.AddWithValue("@id", buscartxt.Text)

                datos = New DataSet
                adaptador = New MySqlDataAdapter(cmd)
                adaptador.Fill(datos, "medicion")

                If datos.Tables("medicion").Rows.Count <> 0 Then
                    Dim row As DataRow = datos.Tables("medicion").Rows(0)
                    fechaTb.Text = row("fecha").ToString()
                    galonesCalcTb.Text = row("galonesCalc").ToString()
                    pglCalTb.Text = row("pglCal").ToString()
                    galonesMedTb.Text = row("galonesMed").ToString()
                    pglMedTb.Text = row("pglMed").ToString()

                    ' Campos nuevos (manejar DBNull para registros antiguos)
                    If row.Table.Columns.Contains("periodo") AndAlso row("periodo") IsNot DBNull.Value Then
                        periodoCb.Text = row("periodo").ToString()
                    Else
                        periodoCb.SelectedIndex = -1
                    End If
                    If row.Table.Columns.Contains("semana") AndAlso row("semana") IsNot DBNull.Value Then
                        semanaCb.Text = row("semana").ToString()
                    Else
                        semanaCb.SelectedIndex = -1
                    End If
                    If row.Table.Columns.Contains("capacidadTanque") AndAlso row("capacidadTanque") IsNot DBNull.Value Then
                        capacidadTb.Text = row("capacidadTanque").ToString()
                    Else
                        capacidadTb.Text = ""
                    End If
                    If row.Table.Columns.Contains("galRecibidos") AndAlso row("galRecibidos") IsNot DBNull.Value Then
                        galRecibidosTb.Text = row("galRecibidos").ToString()
                    Else
                        galRecibidosTb.Text = ""
                    End If
                    If row.Table.Columns.Contains("galDespachados") AndAlso row("galDespachados") IsNot DBNull.Value Then
                        galDespachadosTb.Text = row("galDespachados").ToString()
                    Else
                        galDespachadosTb.Text = ""
                    End If
                    If row.Table.Columns.Contains("galEsperados") AndAlso row("galEsperados") IsNot DBNull.Value Then
                        galEsperadosTb.Text = row("galEsperados").ToString()
                    Else
                        galEsperadosTb.Text = ""
                    End If
                    If row.Table.Columns.Contains("diferencia") AndAlso row("diferencia") IsNot DBNull.Value Then
                        diferenciaTb.Text = row("diferencia").ToString()
                    Else
                        diferenciaTb.Text = ""
                    End If
                    If row.Table.Columns.Contains("observaciones") AndAlso row("observaciones") IsNot DBNull.Value Then
                        observacionesTb.Text = row("observaciones").ToString()
                    Else
                        observacionesTb.Text = ""
                    End If

                    ' Colorear la diferencia
                    colorearDiferencia()
                Else
                    MsgBox("Datos no encontrados")
                End If
            End If

        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        Finally
            If con.State = ConnectionState.Open Then con.Close()
        End Try
    End Sub

    ' ============ AUTO-CALCULO ============

    Private Sub CalcularBtn_Click(sender As Object, e As EventArgs) Handles CalcularBtn.Click
        If periodoCb.SelectedIndex < 0 OrElse semanaCb.SelectedIndex < 0 Then
            MessageBox.Show("Seleccione Periodo y Semana para calcular los galones despachados.", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Try
            If con.State = ConnectionState.Closed Then con.Open()

            Dim sql As String = "SELECT COALESCE(SUM(galDesp), 0) FROM comprobante WHERE periodo = @periodo AND semana = @semana AND (anulado = 0 OR anulado IS NULL)"
            Using cmd As New MySqlCommand(sql, con)
                cmd.Parameters.AddWithValue("@periodo", periodoCb.Text)
                cmd.Parameters.AddWithValue("@semana", semanaCb.Text)
                Dim totalDesp As Double = Convert.ToDouble(cmd.ExecuteScalar())
                galDespachadosTb.Text = totalDesp.ToString("N2")
            End Using

            calcularCamposDerivados()

        Catch ex As Exception
            MessageBox.Show("Error al calcular galones despachados: " & ex.Message, "Error")
        Finally
            If con.State = ConnectionState.Open Then con.Close()
        End Try
    End Sub

    Private Sub calcularCamposDerivados()
        Dim galInicio As Double = 0
        Dim galRecibidos As Double = 0
        Dim galDespachados As Double = 0
        Dim galFinal As Double = 0

        Double.TryParse(galonesCalcTb.Text, galInicio)
        Double.TryParse(galRecibidosTb.Text, galRecibidos)
        Double.TryParse(galDespachadosTb.Text, galDespachados)
        Double.TryParse(galonesMedTb.Text, galFinal)

        ' Formula: Esperado = Inicio + Recibidos - Despachados
        Dim esperado As Double = galInicio + galRecibidos - galDespachados
        galEsperadosTb.Text = esperado.ToString("N2")

        ' Diferencia = Final Real - Esperado
        Dim diff As Double = galFinal - esperado
        diferenciaTb.Text = diff.ToString("N2")

        colorearDiferencia()
    End Sub

    Private Sub colorearDiferencia()
        Dim diff As Double = 0
        Dim cap As Double = 0
        Double.TryParse(diferenciaTb.Text, diff)
        Double.TryParse(capacidadTb.Text, cap)

        If diff >= 0 Then
            diferenciaTb.ForeColor = Color.LightGreen
        ElseIf cap > 0 AndAlso Math.Abs(diff) <= (cap * 0.02) Then
            diferenciaTb.ForeColor = Color.Yellow
        Else
            diferenciaTb.ForeColor = Color.FromArgb(255, 100, 100)
        End If
    End Sub

    ' Recalcular automaticamente cuando cambian los campos relevantes
    Private Sub galonesCalcTb_TextChanged(sender As Object, e As EventArgs) Handles galonesCalcTb.TextChanged
        calcularCamposDerivados()
    End Sub

    Private Sub galRecibidosTb_TextChanged(sender As Object, e As EventArgs) Handles galRecibidosTb.TextChanged
        calcularCamposDerivados()
    End Sub

    Private Sub galonesMedTb_TextChanged(sender As Object, e As EventArgs) Handles galonesMedTb.TextChanged
        calcularCamposDerivados()
    End Sub

    ' ============ HELPERS ============

    Private Sub cargarUltimaCapacidad()
        Try
            If con.State = ConnectionState.Closed Then con.Open()
            Dim sql As String = "SELECT capacidadTanque FROM tanquemed WHERE capacidadTanque > 0 ORDER BY idMedida DESC LIMIT 1"
            Using cmd As New MySqlCommand(sql, con)
                Dim resultado = cmd.ExecuteScalar()
                If resultado IsNot Nothing AndAlso Not IsDBNull(resultado) Then
                    capacidadTb.Text = Convert.ToDouble(resultado).ToString("N2")
                End If
            End Using
        Catch
            ' Si falla, dejar vacio
        Finally
            If con.State = ConnectionState.Open Then con.Close()
        End Try
    End Sub

    Private Sub cargarUltimaMedicion()
        Try
            If con.State = ConnectionState.Closed Then con.Open()

            Dim sql As String = "SELECT galonesCalc, galonesMed, galEsperados, capacidadTanque, diferencia " &
                "FROM tanquemed ORDER BY idMedida DESC LIMIT 1"
            Using cmd As New MySqlCommand(sql, con)
                Using dr As MySqlDataReader = cmd.ExecuteReader()
                    If dr.Read() Then
                        ultimoGalInicio = If(dr("galonesCalc") IsNot DBNull.Value, Convert.ToDouble(dr("galonesCalc")), 0)
                        ultimoGalFinal = If(dr("galonesMed") IsNot DBNull.Value, Convert.ToDouble(dr("galonesMed")), 0)
                        ultimoGalEsperado = If(dr("galEsperados") IsNot DBNull.Value, Convert.ToDouble(dr("galEsperados")), 0)
                        ultimoCapacidad = If(dr("capacidadTanque") IsNot DBNull.Value, Convert.ToDouble(dr("capacidadTanque")), 0)
                        ultimaDiferencia = If(dr("diferencia") IsNot DBNull.Value, Convert.ToDouble(dr("diferencia")), 0)
                    End If
                End Using
            End Using

            PanelGrafica.Invalidate()

        Catch
            ' Si falla, dejar en 0
        Finally
            If con.State = ConnectionState.Open Then con.Close()
        End Try
    End Sub

    ' ============ PANEL GRAFICO GDI+ ============

    Private Sub PanelGrafica_Paint(sender As Object, e As PaintEventArgs)
        Dim g As Graphics = e.Graphics
        g.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
        g.TextRenderingHint = Drawing.Text.TextRenderingHint.ClearTypeGridFit

        Dim w As Integer = PanelGrafica.Width
        Dim h As Integer = PanelGrafica.Height

        ' Fondo oscuro
        g.Clear(Color.FromArgb(45, 55, 72))

        ' Fuentes
        Dim fuenteEscala As New Font("Calibri", 7)
        Dim fuenteLabel As New Font("Calibri", 8, FontStyle.Bold)
        Dim fuenteValor As New Font("Calibri", 10, FontStyle.Bold)
        Dim fuenteTitulo As New Font("Calibri", 9, FontStyle.Bold)
        Dim fuenteFormula As New Font("Calibri", 7.5)
        Dim brushEscala As New SolidBrush(Color.FromArgb(160, 170, 190))
        Dim penLinea As New Pen(Color.FromArgb(70, 80, 100), 1)

        ' ======= SECCION 1: INDICADOR DE TANQUE (izquierda) =======
        Dim tankX As Integer = 25
        Dim tankY As Integer = 30
        Dim tankW As Integer = 70
        Dim tankH As Integer = 170
        Dim tankPercent As Double = 0

        If ultimoCapacidad > 0 Then
            tankPercent = Math.Min(Math.Max((ultimoGalFinal / ultimoCapacidad) * 100, 0), 100)
        End If

        ' Titulo del tanque
        g.DrawString("Nivel Tanque", fuenteTitulo, Brushes.White, tankX - 5, 10)

        ' Contorno del tanque
        Dim tankRect As New Rectangle(tankX, tankY, tankW, tankH)
        g.DrawRectangle(New Pen(Color.FromArgb(150, 160, 180), 2), tankRect)

        ' Llenado del tanque
        Dim fillH As Integer = CInt((tankPercent / 100.0) * tankH)
        If fillH > 0 Then
            Dim fillRect As New Rectangle(tankX + 2, tankY + tankH - fillH, tankW - 4, fillH)

            ' Color segun nivel: verde >50%, amarillo 25-50%, rojo <25%
            Dim fillColorTop As Color
            Dim fillColorBot As Color
            If tankPercent > 50 Then
                fillColorTop = Color.FromArgb(52, 199, 89)
                fillColorBot = Color.FromArgb(20, 140, 50)
            ElseIf tankPercent > 25 Then
                fillColorTop = Color.FromArgb(255, 204, 0)
                fillColorBot = Color.FromArgb(200, 150, 0)
            Else
                fillColorTop = Color.FromArgb(255, 69, 58)
                fillColorBot = Color.FromArgb(180, 40, 30)
            End If

            Using fillBrush As New Drawing2D.LinearGradientBrush(fillRect, fillColorTop, fillColorBot, Drawing2D.LinearGradientMode.Vertical)
                g.FillRectangle(fillBrush, fillRect)
            End Using
        End If

        ' Texto de porcentaje debajo del tanque
        Dim pctText As String = tankPercent.ToString("N1") & "%"
        Dim pctSize As SizeF = g.MeasureString(pctText, fuenteValor)
        g.DrawString(pctText, fuenteValor, Brushes.White, tankX + (tankW - pctSize.Width) / 2, tankY + tankH + 5)

        ' Texto de galones
        Dim galText As String = ultimoGalFinal.ToString("N0") & " gal"
        Dim galSize As SizeF = g.MeasureString(galText, fuenteLabel)
        g.DrawString(galText, fuenteLabel, brushEscala, tankX + (tankW - galSize.Width) / 2, tankY + tankH + 22)

        ' Texto de capacidad
        If ultimoCapacidad > 0 Then
            Dim capText As String = "de " & ultimoCapacidad.ToString("N0")
            Dim capSize As SizeF = g.MeasureString(capText, fuenteEscala)
            g.DrawString(capText, fuenteEscala, brushEscala, tankX + (tankW - capSize.Width) / 2, tankY + tankH + 38)
        End If

        ' ======= SECCION 2: BARRAS COMPARATIVAS (derecha) =======
        Dim barAreaX As Integer = 140
        Dim barAreaY As Integer = 30
        Dim barAreaW As Integer = w - barAreaX - 15
        Dim barAreaH As Integer = 170

        ' Titulo
        g.DrawString("Comparativo Semanal", fuenteTitulo, Brushes.White, barAreaX, 10)

        ' Escala automatica
        Dim maxVal As Double = Math.Max(Math.Max(ultimoGalInicio, ultimoGalEsperado), ultimoGalFinal)
        If maxVal <= 0 Then maxVal = 100

        ' Lineas de escala
        For i As Integer = 0 To 4
            Dim fraction As Double = i / 4.0
            Dim yPos As Integer = barAreaY + barAreaH - CInt(fraction * barAreaH)
            g.DrawLine(penLinea, barAreaX, yPos, barAreaX + barAreaW, yPos)
            Dim scaleVal As String = (maxVal * fraction).ToString("N0")
            Dim svSize As SizeF = g.MeasureString(scaleVal, fuenteEscala)
            g.DrawString(scaleVal, fuenteEscala, brushEscala, barAreaX - svSize.Width - 2, yPos - 6)
        Next

        ' Configuracion de barras
        Dim barWidth As Integer = 55
        Dim gap As Integer = CInt((barAreaW - barWidth * 3) / 4)

        ' Barra 1: Galones Inicio (Azul)
        DibujarBarra(g, barAreaX + gap, barAreaY, barWidth, barAreaH, ultimoGalInicio, maxVal,
                     Color.FromArgb(66, 133, 244), Color.FromArgb(30, 80, 180),
                     "Inicio", fuenteLabel, fuenteValor)

        ' Barra 2: Galones Esperados (Naranja)
        DibujarBarra(g, barAreaX + gap * 2 + barWidth, barAreaY, barWidth, barAreaH, ultimoGalEsperado, maxVal,
                     Color.FromArgb(255, 167, 38), Color.FromArgb(200, 120, 0),
                     "Esperado", fuenteLabel, fuenteValor)

        ' Barra 3: Galones Final (Verde si positivo, Rojo si negativo)
        Dim barColor1 As Color = If(ultimaDiferencia >= 0, Color.FromArgb(52, 199, 89), Color.FromArgb(255, 69, 58))
        Dim barColor2 As Color = If(ultimaDiferencia >= 0, Color.FromArgb(20, 140, 50), Color.FromArgb(180, 40, 30))
        DibujarBarra(g, barAreaX + gap * 3 + barWidth * 2, barAreaY, barWidth, barAreaH, ultimoGalFinal, maxVal,
                     barColor1, barColor2,
                     "Real", fuenteLabel, fuenteValor)

        ' Linea base
        g.DrawLine(New Pen(Color.FromArgb(100, 110, 130), 2), barAreaX, barAreaY + barAreaH, barAreaX + barAreaW, barAreaY + barAreaH)

        ' ======= SECCION 3: RECONCILIACION (abajo) =======
        Dim formulaY As Integer = barAreaY + barAreaH + 50

        g.DrawString("Reconciliacion:", fuenteTitulo, Brushes.White, 15, formulaY)

        Dim formulaText As String = String.Format(
            "Inicio: {0:N2}  +  Recibidos  -  Despachados  =  Esperado: {1:N2}",
            ultimoGalInicio, ultimoGalEsperado)
        g.DrawString(formulaText, fuenteFormula, brushEscala, 15, formulaY + 18)

        Dim formulaText2 As String = String.Format("Medicion Real: {0:N2}", ultimoGalFinal)
        g.DrawString(formulaText2, fuenteFormula, brushEscala, 15, formulaY + 34)

        ' Diferencia con color
        Dim diffColor As Color = If(ultimaDiferencia >= 0, Color.LightGreen, Color.FromArgb(255, 100, 100))
        Dim diffSymbol As String = If(ultimaDiferencia >= 0, "+", "")
        Dim diffText As String = "Dif: " & diffSymbol & ultimaDiferencia.ToString("N2") & " gal"
        g.DrawString(diffText, fuenteTitulo, New SolidBrush(diffColor), w - 160, formulaY)

        ' Liberar recursos
        fuenteEscala.Dispose()
        fuenteLabel.Dispose()
        fuenteValor.Dispose()
        fuenteTitulo.Dispose()
        fuenteFormula.Dispose()
        brushEscala.Dispose()
        penLinea.Dispose()
    End Sub

    Private Sub DibujarBarra(g As Graphics, x As Integer, areaY As Integer, barW As Integer,
                              areaH As Integer, value As Double, maxVal As Double,
                              color1 As Color, color2 As Color, label As String,
                              fntLabel As Font, fntValue As Font)

        Dim normalizedH As Integer = If(maxVal > 0, CInt((value / maxVal) * areaH), 0)
        normalizedH = Math.Max(normalizedH, 0)
        Dim barY As Integer = areaY + areaH - normalizedH

        If normalizedH > 0 Then
            Dim barRect As New Rectangle(x, barY, barW, normalizedH)
            Using brush As New Drawing2D.LinearGradientBrush(barRect, color1, color2, Drawing2D.LinearGradientMode.Vertical)
                g.FillRectangle(brush, barRect)
            End Using
            g.DrawRectangle(New Pen(Color.FromArgb(Math.Max(color2.R - 10, 0), Math.Max(color2.G - 10, 0), color2.B), 1), barRect)
        End If

        ' Valor encima de la barra
        Dim strVal As String = value.ToString("N0")
        Dim szVal As SizeF = g.MeasureString(strVal, fntValue)
        g.DrawString(strVal, fntValue, Brushes.White, x + (barW - szVal.Width) / 2, barY - szVal.Height - 2)

        ' Etiqueta debajo de la barra
        Dim szLbl As SizeF = g.MeasureString(label, fntLabel)
        g.DrawString(label, fntLabel, Brushes.White, x + (barW - szLbl.Width) / 2, areaY + areaH + 5)
    End Sub

End Class
