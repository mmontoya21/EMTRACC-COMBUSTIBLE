Imports System.Data
Imports MySql.Data.MySqlClient
Public Class medicion
    Dim adaptador As New MySqlDataAdapter
    Dim datos As DataSet
    Dim con As New MySqlConnection

    Dim colorFondo = Color.FromArgb(106, 126, 168)

    ' Valores de la ultima medicion para la grafica
    Private ultimoGalonesCalc As Double = 0
    Private ultimoPglCal As Double = 0

    Private Sub medicion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        conectar()
        act()
        listadoMedDgv()

        EstilizarDataGridView(MedDGV)

        Me.BackColor = Color.SteelBlue
        PanelP.Enabled = False

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
            Dim adaptadorListado As New MySqlDataAdapter("SELECT idMedida, fecha, galonesCalc, pglCal, galonesMed, pglMed FROM tanquemed ORDER BY idMedida DESC", con)
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
        If MedDGV.Columns.Count < 6 Then Exit Sub

        MedDGV.Columns(0).HeaderText = "Id"
        MedDGV.Columns(0).Width = 50

        MedDGV.Columns(1).HeaderText = "Fecha"
        MedDGV.Columns(1).Width = 120

        MedDGV.Columns(2).HeaderText = "Galones Calc"
        MedDGV.Columns(2).Width = 120

        MedDGV.Columns(3).HeaderText = "PGL Calc"
        MedDGV.Columns(3).Width = 120

        MedDGV.Columns(4).HeaderText = "Galones Med"
        MedDGV.Columns(4).Width = 120

        MedDGV.Columns(5).HeaderText = "PGL Med"
        MedDGV.Columns(5).Width = 120
    End Sub

    Sub limpiar()
        Me.fechaTb.Text = ""
        Me.galonesCalcTb.Text = ""
        Me.pglCalTb.Text = ""
        Me.galonesMedTb.Text = ""
        Me.pglMedTb.Text = ""
    End Sub

    Private Sub NuevoBtn_Click(sender As Object, e As EventArgs) Handles NuevoBtn.Click
        limpiar()
        fechaTb.Text = Today.ToString("yyyy/MM/dd")
        PanelP.Enabled = True
        GuardarBtn.Enabled = True
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
    End Sub

    Private Sub GuardarBtn_Click(sender As Object, e As EventArgs) Handles GuardarBtn.Click
        If con.State = ConnectionState.Closed Then con.Open()

        Dim galCalc As Double = 0
        Double.TryParse(galonesCalcTb.Text, galCalc)

        Dim pglC As Double = 0
        Double.TryParse(pglCalTb.Text, pglC)

        Dim galMed As Double = 0
        Double.TryParse(galonesMedTb.Text, galMed)

        Dim pglM As Double = 0
        Double.TryParse(pglMedTb.Text, pglM)

        Try
            Dim guardar As New MySqlCommand("INSERT INTO tanquemed (fecha, galonesCalc, pglCal, galonesMed, pglMed) VALUES(@fecha, @galonesCalc, @pglCal, @galonesMed, @pglMed)", con)

            guardar.Parameters.AddWithValue("@fecha", fechaTb.Text)
            guardar.Parameters.AddWithValue("@galonesCalc", galCalc)
            guardar.Parameters.AddWithValue("@pglCal", pglC)
            guardar.Parameters.AddWithValue("@galonesMed", galMed)
            guardar.Parameters.AddWithValue("@pglMed", pglM)

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

        Dim galCalc As Double = 0
        Double.TryParse(galonesCalcTb.Text, galCalc)

        Dim pglC As Double = 0
        Double.TryParse(pglCalTb.Text, pglC)

        Dim galMed As Double = 0
        Double.TryParse(galonesMedTb.Text, galMed)

        Dim pglM As Double = 0
        Double.TryParse(pglMedTb.Text, pglM)

        Try
            Dim actualizar As New MySqlCommand("UPDATE tanquemed SET fecha = @fecha, galonesCalc = @galonesCalc, pglCal = @pglCal, galonesMed = @galonesMed, pglMed = @pglMed WHERE idMedida = @id", con)

            actualizar.Parameters.AddWithValue("@fecha", fechaTb.Text)
            actualizar.Parameters.AddWithValue("@galonesCalc", galCalc)
            actualizar.Parameters.AddWithValue("@pglCal", pglC)
            actualizar.Parameters.AddWithValue("@galonesMed", galMed)
            actualizar.Parameters.AddWithValue("@pglMed", pglM)
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
            Me.EditarBtn.Enabled = True
            Me.EliminarBtn.Enabled = True
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
                    fechaTb.Text = datos.Tables("medicion").Rows(0).Item("fecha").ToString
                    galonesCalcTb.Text = datos.Tables("medicion").Rows(0).Item("galonesCalc").ToString
                    pglCalTb.Text = datos.Tables("medicion").Rows(0).Item("pglCal").ToString
                    galonesMedTb.Text = datos.Tables("medicion").Rows(0).Item("galonesMed").ToString
                    pglMedTb.Text = datos.Tables("medicion").Rows(0).Item("pglMed").ToString
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

    Private Sub cargarUltimaMedicion()
        Try
            If con.State = ConnectionState.Closed Then con.Open()

            Dim sql As String = "SELECT galonesCalc, pglCal FROM tanquemed ORDER BY idMedida DESC LIMIT 1"
            Using cmd As New MySqlCommand(sql, con)
                Using dr As MySqlDataReader = cmd.ExecuteReader()
                    If dr.Read() Then
                        If dr("galonesCalc") IsNot DBNull.Value Then
                            ultimoGalonesCalc = Convert.ToDouble(dr("galonesCalc"))
                        End If
                        If dr("pglCal") IsNot DBNull.Value Then
                            ultimoPglCal = Convert.ToDouble(dr("pglCal"))
                        End If
                    End If
                End Using
            End Using

            PanelGrafica.Invalidate()

        Catch ex As Exception
            ' Si falla, dejar en 0
        Finally
            If con.State = ConnectionState.Open Then con.Close()
        End Try
    End Sub

    Private Sub PanelGrafica_Paint(sender As Object, e As PaintEventArgs)
        Dim g As Graphics = e.Graphics
        g.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
        g.TextRenderingHint = Drawing.Text.TextRenderingHint.ClearTypeGridFit

        Dim w As Integer = PanelGrafica.Width
        Dim h As Integer = PanelGrafica.Height

        ' Fondo del panel
        g.Clear(Color.FromArgb(45, 55, 72))

        ' Margenes
        Dim margenIzq As Integer = 50
        Dim margenDer As Integer = 20
        Dim margenTop As Integer = 20
        Dim margenBot As Integer = 60
        Dim areaH As Integer = h - margenTop - margenBot
        Dim areaW As Integer = w - margenIzq - margenDer

        ' Dibujar lineas de escala (0, 25, 50, 75, 100)
        Dim fuenteEscala As New Font("Calibri", 8)
        Dim fuenteLabel As New Font("Comic Sans MS", 9, FontStyle.Bold)
        Dim fuenteValor As New Font("Calibri", 11, FontStyle.Bold)
        Dim brushEscala As New SolidBrush(Color.FromArgb(160, 170, 190))
        Dim penLinea As New Pen(Color.FromArgb(70, 80, 100), 1)

        For i As Integer = 0 To 4
            Dim valor As Integer = i * 25
            Dim yPos As Integer = margenTop + areaH - CInt((valor / 100.0) * areaH)
            g.DrawLine(penLinea, margenIzq, yPos, w - margenDer, yPos)
            g.DrawString(valor.ToString(), fuenteEscala, brushEscala, 5, yPos - 7)
        Next

        ' Ancho de barras
        Dim barWidth As Integer = 80
        Dim espacio As Integer = CInt((areaW - barWidth * 2) / 3)

        ' Barra 1: Galones Calculados
        Dim valGal As Double = Math.Min(Math.Max(ultimoGalonesCalc, 0), 100)
        Dim barH1 As Integer = CInt((valGal / 100.0) * areaH)
        Dim x1 As Integer = margenIzq + espacio
        Dim y1 As Integer = margenTop + areaH - barH1

        ' Gradiente azul
        If barH1 > 0 Then
            Dim rectBar1 As New Rectangle(x1, y1, barWidth, barH1)
            Using brush1 As New Drawing2D.LinearGradientBrush(rectBar1, Color.FromArgb(66, 133, 244), Color.FromArgb(30, 80, 180), Drawing2D.LinearGradientMode.Vertical)
                g.FillRectangle(brush1, rectBar1)
            End Using
            ' Borde
            g.DrawRectangle(New Pen(Color.FromArgb(20, 60, 140), 1), rectBar1)
        End If

        ' Valor encima de la barra
        Dim strGal As String = ultimoGalonesCalc.ToString("N2")
        Dim szGal As SizeF = g.MeasureString(strGal, fuenteValor)
        g.DrawString(strGal, fuenteValor, Brushes.White, x1 + (barWidth - szGal.Width) / 2, y1 - szGal.Height - 3)

        ' Label debajo
        Dim lblGal As String = "Galones" & vbCrLf & "Calc"
        Dim szLblGal As SizeF = g.MeasureString(lblGal, fuenteLabel)
        g.DrawString(lblGal, fuenteLabel, Brushes.White, x1 + (barWidth - szLblGal.Width) / 2, margenTop + areaH + 5)

        ' Barra 2: PGL Calculadas
        Dim valPgl As Double = Math.Min(Math.Max(ultimoPglCal, 0), 100)
        Dim barH2 As Integer = CInt((valPgl / 100.0) * areaH)
        Dim x2 As Integer = margenIzq + espacio * 2 + barWidth
        Dim y2 As Integer = margenTop + areaH - barH2

        ' Gradiente verde
        If barH2 > 0 Then
            Dim rectBar2 As New Rectangle(x2, y2, barWidth, barH2)
            Using brush2 As New Drawing2D.LinearGradientBrush(rectBar2, Color.FromArgb(52, 199, 89), Color.FromArgb(20, 140, 50), Drawing2D.LinearGradientMode.Vertical)
                g.FillRectangle(brush2, rectBar2)
            End Using
            g.DrawRectangle(New Pen(Color.FromArgb(15, 110, 35), 1), rectBar2)
        End If

        ' Valor encima de la barra
        Dim strPgl As String = ultimoPglCal.ToString("N2")
        Dim szPgl As SizeF = g.MeasureString(strPgl, fuenteValor)
        g.DrawString(strPgl, fuenteValor, Brushes.White, x2 + (barWidth - szPgl.Width) / 2, y2 - szPgl.Height - 3)

        ' Label debajo
        Dim lblPgl As String = "PGL" & vbCrLf & "Calc"
        Dim szLblPgl As SizeF = g.MeasureString(lblPgl, fuenteLabel)
        g.DrawString(lblPgl, fuenteLabel, Brushes.White, x2 + (barWidth - szLblPgl.Width) / 2, margenTop + areaH + 5)

        ' Linea base
        g.DrawLine(New Pen(Color.FromArgb(100, 110, 130), 2), margenIzq, margenTop + areaH, w - margenDer, margenTop + areaH)

        ' Liberar recursos
        fuenteEscala.Dispose()
        fuenteLabel.Dispose()
        fuenteValor.Dispose()
        brushEscala.Dispose()
        penLinea.Dispose()
    End Sub

End Class
