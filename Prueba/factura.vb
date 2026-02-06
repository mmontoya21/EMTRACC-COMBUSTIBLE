Imports System.Data
Imports MySql.Data.MySqlClient
Imports MySql.Data
Imports System.Drawing
Imports System.Drawing.Printing

Public Class factura
    Dim con As New MySqlConnection
    Dim cm As New MySqlCommand
    Dim guardar As New MySqlCommand
    Dim adaptador As New MySqlDataAdapter
    Dim datos As DataSet
    Dim dr As MySqlDataReader
    Private m_tmr As Timer
    Public img As Image

    Private isMouseDown As Boolean = True
    Private mouseOffset As Point

    Dim colorFondo = Color.FromArgb(106, 126, 168)
    Dim colorTextbox = Color.FromArgb(240, 210, 249)


    Private Sub factura_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Try
            System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("es-HN")
            System.Threading.Thread.CurrentThread.CurrentCulture.DateTimeFormat.ShortDatePattern = "yyyy/MM/dd"
            System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencyDecimalSeparator = "."
            System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencyGroupSeparator = ","
            System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator = "."
            System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.NumberGroupSeparator = ","

            conectar()
            act()
            listadoCamDgv()
            CamDgv.BackgroundColor = colorFondo
            CamDgv.RowsDefaultCellStyle.BackColor = Color.Bisque
            CamDgv.AlternatingRowsDefaultCellStyle.BackColor = Color.Lavender

            PanelP.Enabled = False
        Catch ex As Exception
            MessageBox.Show("Error al cargar el formulario: " & ex.Message, "Error")
        End Try

    End Sub

    Private Sub factura_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        ' Cerrar la conexión al cerrar el formulario
        Try
            If con IsNot Nothing AndAlso con.State = ConnectionState.Open Then
                con.Close()
            End If
        Catch ex As Exception
            ' Ignorar errores al cerrar
        End Try
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

    Private Sub act()
        Me.NuevoBtn.Enabled = True
        Me.EditarBtn.Enabled = False
        Me.GuardarBtn.Enabled = False
        Me.ModificarBtn.Enabled = False
        Me.CancelarBtn.Enabled = False
        Me.EliminarBtn.Enabled = False
        Me.PreviaBtn.Enabled = False
    End Sub
    Private Sub NuevoBtn_Click(sender As Object, e As EventArgs) Handles NuevoBtn.Click '============  NUEVO  ===========
        Try
            limpiar()
            PanelP.Enabled = True
            GuardarBtn.Enabled = True
            CamDgv.Enabled = False
            CancelarBtn.Enabled = True
            Me.PreviaBtn.Enabled = True
            NuevoBtn.Enabled = False
            tipoPagTb.Text = "CONTADO"

            ' Usar conexión local para evitar conflicto con DataReaders abiertos
            Dim ultimaFactura As String = ""
            Using conLocal As MySqlConnection = ModuloConexion.ObtenerConexion()
                conLocal.Open()
                Dim query As String = "SELECT nFactura FROM factura ORDER BY idFactura DESC LIMIT 1"
                Using comando As New MySqlCommand(query, conLocal)
                    Using lector As MySqlDataReader = comando.ExecuteReader()
                        If lector.Read() Then
                            ultimaFactura = lector("nFactura").ToString()
                        End If
                    End Using
                End Using
            End Using

            ' Asignar valores después de cerrar la conexión local
            If Not String.IsNullOrEmpty(ultimaFactura) Then
                CodproBTb.Text = ultimaFactura
                Dim nfacta As Double = Double.Parse(ultimaFactura)
                nFacTb.Text = nfacta + 1
                amplitud()
            Else
                nFacTb.Text = 1
                amplitud()
            End If

            Me.cant1Tb.Text = 0
            Me.cant2Tb.Text = 0
            Me.preUni1Tb.Text = 0
            Me.preUni2Tb.Text = 0
            Me.tota1Tb.Text = 0
            Me.tota2Tb.Text = 0

            Me.facTotTb.Text = 0
            Me.facExeTb.Text = 0
            Me.facCanTB.Text = 0

            Me.desc1Tb.Text = "Diessel"
            Me.desc2Tb.Text = "Diessel"

        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "Error")
        End Try

    End Sub
    Sub limpiar()

        Me.nFacTb.Text = ""
        Me.fechaPk.Text = ""
        Me.propTb.Text = ""
        Me.empTb.Text = ""
        Me.rtnTb.Text = ""
        Me.tipoPagTb.Text = ""
        Me.facCanTB.Text = ""
        Me.facExeTb.Text = ""
        Me.facTotTb.Text = ""
        Me.comentaTb.Text = ""
        Me.cant1Tb.Text = ""
        Me.cant2Tb.Text = ""
        Me.desc1Tb.Text = ""
        Me.desc2Tb.Text = ""
        Me.tota1Tb.Text = ""
        Me.tota2Tb.Text = ""
        Me.perMesCB.Text = ""
        Me.perSemCB.Text = ""
        Me.preUni1Tb.Text = ""
        Me.preUni2Tb.Text = ""
        Me.codPropTb.Text = ""
    End Sub

    Private Sub EditarBtn_Click(sender As Object, e As EventArgs) Handles EditarBtn.Click  '============  EDITAR  ===========

        PanelP.Enabled = True
        GuardarBtn.Enabled = False
        ModificarBtn.Enabled = True
        CamDgv.Enabled = False
        CancelarBtn.Enabled = True
        GuardarBtn.Visible = False
        ModificarBtn.Visible = True

    End Sub

    Private Sub GuardarBtn_Click(sender As Object, e As EventArgs) Handles GuardarBtn.Click '============  GUARDADO  ===========
        Try
            Me.PreviaBtn.Enabled = False

            If con.State = ConnectionState.Closed Then con.Open()

            Dim fe As Date = fechaPk.Value.ToString("yyyy-MM-dd")

            Dim ccant1Tb As Double = 0
            Double.TryParse(cant1Tb.Text, ccant1Tb)

            Dim ccant2Tb As Double = 0
            Double.TryParse(cant2Tb.Text, ccant2Tb)

            Dim ctota1Tb As Double = 0
            Double.TryParse(tota1Tb.Text, ctota1Tb)

            Dim ctota2Tb As Double = 0
            Double.TryParse(tota2Tb.Text, ctota2Tb)

            Dim cfacExeTb As Double = 0
            Double.TryParse(facExeTb.Text, cfacExeTb)

            Dim cfacTotTb As Double = 0
            Double.TryParse(facTotTb.Text, cfacTotTb)

            Dim cfacCanTB As Double = 0
            Double.TryParse(facCanTB.Text, cfacCanTB)

            Dim cpreUni1Tb As Double = 0
            Double.TryParse(preUni1Tb.Text, cpreUni1Tb)

            Dim cpreUni2Tb As Double = 0
            Double.TryParse(preUni2Tb.Text, cpreUni2Tb)

            Using cmd As New MySqlCommand("INSERT INTO factura (nFactura, Fecha, propietario, Empresa, rtn, tipoPag, facCantidad, facExe, facTotal, comentario, cantd1, cantd2, descrip1, descrip2, total1, total2, perMes, PerSem, preUni1, preUni2, codProp) VALUES(@nFactura, @Fecha, @propietario, @Empresa, @rtn, @tipoPag, @facCantidad, @facExe, @facTotal, @comentario, @cantd1, @cantd2, @descrip1, @descrip2, @total1, @total2, @perMes, @PerSem, @preUni1Tb, @preUni2Tb, @codProp)", con)

                cmd.Parameters.AddWithValue("@nFactura", nFacTb.Text)
                cmd.Parameters.AddWithValue("@Fecha", fe)
                cmd.Parameters.AddWithValue("@propietario", propTb.Text)
                cmd.Parameters.AddWithValue("@Empresa", empTb.Text)
                cmd.Parameters.AddWithValue("@rtn", rtnTb.Text)
                cmd.Parameters.AddWithValue("@tipoPag", tipoPagTb.Text)
                cmd.Parameters.AddWithValue("@facCantidad", cfacCanTB)
                cmd.Parameters.AddWithValue("@facExe", cfacExeTb)
                cmd.Parameters.AddWithValue("@facTotal", cfacTotTb)
                cmd.Parameters.AddWithValue("@comentario", comentaTb.Text)
                cmd.Parameters.AddWithValue("@cantd1", ccant1Tb)
                cmd.Parameters.AddWithValue("@cantd2", ccant2Tb)
                cmd.Parameters.AddWithValue("@descrip1", desc1Tb.Text)
                cmd.Parameters.AddWithValue("@descrip2", desc2Tb.Text)
                cmd.Parameters.AddWithValue("@total1", ctota1Tb)
                cmd.Parameters.AddWithValue("@total2", ctota2Tb)
                cmd.Parameters.AddWithValue("@perMes", perMesCB.Text)
                cmd.Parameters.AddWithValue("@PerSem", perSemCB.Text)
                cmd.Parameters.AddWithValue("@preUni1Tb", cpreUni1Tb)
                cmd.Parameters.AddWithValue("@preUni2Tb", cpreUni2Tb)
                cmd.Parameters.AddWithValue("@codProp", codPropTb.Text)

                cmd.ExecuteNonQuery()
            End Using

            MsgBox("Registro guardado")

            limpiar()
            act()

            CamDgv.Enabled = True
            listadoCamDgv()

            PanelP.Enabled = False
            CamDgv.Enabled = True
            Me.GuardarBtn.Visible = True

            If CamDgv.Rows.Count > 0 Then
                CamDgv.CurrentCell = CamDgv.Rows(CamDgv.Rows.Count - 1).Cells(0)
            End If

        Catch ex As Exception
            MessageBox.Show("Error al guardar: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub ModificarBtn_Click(sender As Object, e As EventArgs) Handles ModificarBtn.Click '============  MODIFICAR  ===========
        actual()
        act()
        PanelP.Enabled = False
        CamDgv.Enabled = True
        Me.GuardarBtn.Visible = True
        listadoCamDgv()
    End Sub

    Public Sub actual()
        Try
            If con.State = ConnectionState.Closed Then con.Open()

            Dim fe As Date = fechaPk.Value.ToString("yyyy-MM-dd")
            Dim facTotVal As String = facTotTb.Text.Replace(",", "")
            Dim tota1Val As String = tota1Tb.Text.Replace(",", "")
            Dim tota2Val As String = tota2Tb.Text.Replace(",", "")

            Using cmd As New MySqlCommand("UPDATE factura SET nFactura = @nFactura, propietario = @propietario, Empresa = @Empresa, rtn = @rtn, tipoPag = @tipoPag, facCantidad = @facCantidad, facExe = @facExe, facTotal = @facTotal, comentario = @comentario, cantd1 = @cantd1, cantd2 = @cantd2, descrip1 = @descrip1, descrip2 = @descrip2, total1 = @total1, total2 = @total2, perMes = @perMes, PerSem = @PerSem, preUni1 = @preUni1, preUni2 = @preUni2, fecha = @fecha, codProp = @codProp WHERE idfactura = @idfactura", con)
                cmd.Parameters.AddWithValue("@nFactura", nFacTb.Text)
                cmd.Parameters.AddWithValue("@propietario", propTb.Text)
                cmd.Parameters.AddWithValue("@Empresa", empTb.Text)
                cmd.Parameters.AddWithValue("@rtn", rtnTb.Text)
                cmd.Parameters.AddWithValue("@tipoPag", tipoPagTb.Text)
                cmd.Parameters.AddWithValue("@facCantidad", facCanTB.Text)
                cmd.Parameters.AddWithValue("@facExe", facExeTb.Text)
                cmd.Parameters.AddWithValue("@facTotal", facTotVal)
                cmd.Parameters.AddWithValue("@comentario", comentaTb.Text)
                cmd.Parameters.AddWithValue("@cantd1", cant1Tb.Text)
                cmd.Parameters.AddWithValue("@cantd2", cant2Tb.Text)
                cmd.Parameters.AddWithValue("@descrip1", desc1Tb.Text)
                cmd.Parameters.AddWithValue("@descrip2", desc2Tb.Text)
                cmd.Parameters.AddWithValue("@total1", tota1Val)
                cmd.Parameters.AddWithValue("@total2", tota2Val)
                cmd.Parameters.AddWithValue("@perMes", perMesCB.Text)
                cmd.Parameters.AddWithValue("@PerSem", perSemCB.Text)
                cmd.Parameters.AddWithValue("@preUni1", preUni1Tb.Text)
                cmd.Parameters.AddWithValue("@preUni2", preUni2Tb.Text)
                cmd.Parameters.AddWithValue("@fecha", fe)
                cmd.Parameters.AddWithValue("@codProp", codPropTb.Text)
                cmd.Parameters.AddWithValue("@idfactura", propBusqTB.Text)
                cmd.ExecuteNonQuery()
            End Using
            MsgBox("Registro Actualizado")
        Catch ex As Exception
            MessageBox.Show("Error al actualizar: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub EliminarBtn_Click(sender As Object, e As EventArgs) Handles EliminarBtn.Click '============  ELIMINAR  ===========
        Try
            Dim opc As DialogResult = MsgBox("¿Desea Eliminar este registro?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Eliminar")
            If opc = Windows.Forms.DialogResult.Yes Then

                If con.State = ConnectionState.Closed Then con.Open()

                Using cmd As New MySqlCommand("DELETE FROM factura WHERE idfactura = @idfactura", con)
                    cmd.Parameters.AddWithValue("@idfactura", Conversion.Int(Me.buscartxt.Text))
                    cmd.ExecuteNonQuery()
                End Using

                MsgBox("Registro eliminado correctamente", MsgBoxStyle.Information, "Éxito")
                listadoCamDgv()
            End If
        Catch ex As Exception
            MessageBox.Show("Error al eliminar: " & ex.Message & Chr(13) & "Favor escoger de nuevo el registro y eliminarlo", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try

        act()
    End Sub
    Private Sub listadoCamDgv() 'Muestra los datos
        Try
            If con.State = ConnectionState.Closed Then con.Open()

            Dim table As New DataTable()
            Dim adaptadoListado As New MySqlDataAdapter("SELECT idFactura, codProp, empresa, propietario, nfactura FROM factura", con)
            adaptadoListado.Fill(table)

            CamDgv.DataSource = table

            ListadoD()
        Catch ex As Exception
            MessageBox.Show("Error al cargar datos: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If con.State = ConnectionState.Open Then con.Close()
        End Try

    End Sub
    Private Sub ListadoD()
        CamDgv.Columns(0).HeaderText = "Id"
        CamDgv.Columns(0).Width = 1

        CamDgv.Columns(1).HeaderText = "Código"
        CamDgv.Columns(1).Width = 50

        CamDgv.Columns(2).HeaderText = "Empresa"
        CamDgv.Columns(2).Width = 175

        CamDgv.Columns(3).HeaderText = "Propietario"
        CamDgv.Columns(3).Width = 175

        CamDgv.Columns(4).HeaderText = "Factura"
        CamDgv.Columns(4).Width = 100

    End Sub
    Private Sub calcularletras()  '============  CALCULO DE LETRAS   =============
        pLetras.Text = ""
        If IsNumeric(facTotTb.Text) Then
            pLetras.Text = LETRAS(facTotTb.Text)
            ' Else
            '     MessageBox.Show("Ingrese por favor números", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
        'facTotTb.Focus()
        facTotTb.SelectionStart = 0
        facTotTb.SelectionLength = facTotTb.ToString.Length
    End Sub
    Private Sub amplitud()    '============  NÚMERO DE FACTURA   =============
        Dim tam As String = (nFacTb.Text)

        If Len(CStr(tam)) = 1 Then
            tam = "0000000" & tam
            nFacTb.Text = tam
        End If
        If Len(CStr(tam)) = 2 Then
            tam = "000000" & tam
            nFacTb.Text = tam
        End If
        If Len(CStr(tam)) = 3 Then
            tam = "00000" & tam
            nFacTb.Text = tam
        End If
        If Len(CStr(tam)) = 4 Then
            tam = "0000" & tam
            nFacTb.Text = tam
        End If
        If Len(CStr(tam)) = 5 Then
            tam = "000" & tam
            nFacTb.Text = tam
        End If
        If Len(CStr(tam)) = 6 Then
            tam = "00" & tam
            nFacTb.Text = tam
        End If
        If Len(CStr(tam)) = 7 Then
            tam = "0" & tam
            nFacTb.Text = tam
        End If
        If Len(CStr(tam)) = 8 Then
            tam = "" & tam
            nFacTb.Text = tam
        End If
    End Sub

    Private Sub ButtonX5_Click(sender As Object, e As EventArgs)
        Me.propTb.Text = propietario.nPropietarioTb.Text
    End Sub
    Public Sub LoadImage()
        img = Image.FromFile("C:\emtracc\camion.jpg") ' Cambia la ruta según tu imagen
    End Sub
    Private Sub PrintFactura_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles PrintFactura.PrintPage
        ' Usar conexión local para no interferir con la conexión del formulario
        Using conLocal As MySqlConnection = ModuloConexion.ObtenerConexion()
            Try
                conLocal.Open()

                ' Consulta para obtener el último registro (campo nFactura)
                Dim query As String = "SELECT nEmpre, nPropie, nombLocal, dire1, dire2 ,dire3, local, rtn, correoE, cai, tel1, cel2, fax, ochoDig, rangoIni, rangoFin, fechaLimit FROM empresa"
                Using comando As New MySqlCommand(query, conLocal)
                    Using lector As MySqlDataReader = comando.ExecuteReader()


            ' Verificar si hay registros
            ' If lector.Read() Then

            Dim ConteoL As Integer = Integer.Parse(CodproBTb.Text) ' Conteo Lineas, baja automaticamente la lineas de Productos
            ConteoL = (ConteoL * 23)
            Dim LIM = 0
            Dim L As String = "L. "

            Dim i As Integer = 0
            Dim displayRectangle As New Rectangle(New Point(5, 5), New Size(240, 200)) ' Como la columna es de un rango de 240, el centrado en el texto debe de ser la mitad o sea 120

            Dim format1 As New StringFormat(StringFormatFlags.NoClip)
            Dim format2 As New StringFormat(format1)

            format1.LineAlignment = StringAlignment.Near
            format1.Alignment = StringAlignment.Center
            format2.LineAlignment = StringAlignment.Center
            format2.Alignment = StringAlignment.Far

            While lector.Read()

                Dim caiP As String = lector("cai").ToString()
                Dim ochoDigP As String = lector("ochoDig").ToString()
                Dim rangoIniP As String = lector("rangoIni").ToString()
                Dim rangoFinP As String = lector("rangoFin").ToString()
                Dim FechaLimitP As String = lector("fechaLimit").ToString()

                Dim nEmpreP As String = lector("nEmpre").ToString()
                Dim dire1P As String = lector("dire1").ToString()
                Dim dire2P As String = lector("dire2").ToString()
                Dim dire3P As String = lector("dire3").ToString()
                Dim tel1P As String = lector("tel1").ToString()
                Dim rtnP As String = lector("rtn").ToString()
                Dim CorreoEP As String = lector("CorreoE").ToString()


                Dim fe As String = fechaPk.Value.ToString("dd-MM-yyyy")

                img = Image.FromFile("C:\emtracc\camion.jpg") ' Cambia la ruta según tu imagen
                '''''
                If img IsNot Nothing Then
                    ' Dibujar la imagen en la página (ajustar posición y tamaño según sea necesario)
                    e.Graphics.DrawImage(img, 5, 5, 250, 100) ' Usa valores fijos como prueba
                    'e.Graphics.DrawImage(img, 50.0F, 50.0F, CType(img.Width / 2, Single), CType(img.Height / 2, Single))
                End If

                'e.Graphics.DrawRectangle(Pens.White, displayRectangle)

                Dim prFont As New Font("Calibri", 5.5, FontStyle.Bold, GraphicsUnit.Point)
                Dim DFont2 As New Font("Calibri", 8, FontStyle.Bold, GraphicsUnit.Point)
                Dim mFont As New Font("Calibri", 8, GraphicsUnit.Point)
                Dim GFont As New Font("Calibri", 11, GraphicsUnit.Point)
                Dim uFont As New Font("Calibri", 10, FontStyle.Bold, GraphicsUnit.Point)
                Dim mFont2 As New Font("Calibri", 10, FontStyle.Bold, GraphicsUnit.Point)
                Dim mGFont As New Font("Calibri", 16, GraphicsUnit.Point)
                Dim mFont3 As New Font("Calibri", 6, GraphicsUnit.Point)

                Dim tGFont As New Font("Calibri", 12, FontStyle.Underline, GraphicsUnit.Point)
                Dim mFont1 As New Font("Calibri", 8, FontStyle.Bold, GraphicsUnit.Point)

                Dim DFont As New Font("Calibri", 13, FontStyle.Bold, GraphicsUnit.Point)


                Dim cFont As New Font("Arial Black", 6, GraphicsUnit.Point)
                Dim nFont As New Font("Verdana", 8, GraphicsUnit.Point)
                Dim sFont As New Font("Verdana", 4, GraphicsUnit.Point)
                Dim BIGFont As New Font("Verdana", 10, FontStyle.Bold, GraphicsUnit.Point)
                Dim BIGFont2 As New Font("Verdana", 16, FontStyle.Bold, GraphicsUnit.Point)
                Dim BIGFont3 As New Font("Verdana", 12, FontStyle.Bold, GraphicsUnit.Point)


                ' Dim sf As New StringFormat()
                ' sf.Trimming = StringTrimming.EllipsisWord

                ' e.Graphics.DrawString("fecha      Hora", prFont, Brushes.Black, 580, 30)
                ' e.Graphics.DrawString(Label46.Text, prFont, Brushes.Black, 650, 50)

                ' Dim DR As New StringFormat With {.Alignment = StringAlignment.Far} ' Alineamiento a la derecha

                'e.Graphics.DrawString(nEmpreP, DFont2, Brushes.Black, RectangleF.op_Implicit(displayRectangle), format1) 'NOMBRE EMPRESA
                e.Graphics.DrawString(nEmpreP, BIGFont, Brushes.Black, 270, 20)
                e.Graphics.DrawString("BOMBA DE PATIO", BIGFont2, Brushes.Black, 400, 40)

                e.Graphics.DrawString("CAI: " & caiP, GFont, Brushes.Black, 10, 120)
                e.Graphics.DrawString("Fecha Límite de emisión: " & FechaLimitP, GFont, Brushes.Black, 10, 135)
                e.Graphics.DrawString("Rango Inicial: " & rangoIniP, GFont, Brushes.Black, 10, 150)
                e.Graphics.DrawString("Rango Final: " & rangoFinP, GFont, Brushes.Black, 10, 165)
                e.Graphics.DrawString("FECHA: " & fe, GFont, Brushes.Black, 10, 180)


                e.Graphics.DrawString(dire1P, GFont, Brushes.Black, 470, 120)
                e.Graphics.DrawString(dire2P, GFont, Brushes.Black, 470, 135)
                e.Graphics.DrawString(dire3P, GFont, Brushes.Black, 470, 150)
                e.Graphics.DrawString(rtnP, GFont, Brushes.Black, 470, 165)
                e.Graphics.DrawString(tel1P, GFont, Brushes.Black, 470, 180)
                e.Graphics.DrawString(CorreoEP, GFont, Brushes.Black, 470, 195)

                e.Graphics.DrawString("TIPO FACTURA:" & tipoPagTb.Text, GFont, Brushes.Black, 10, 210)
                e.Graphics.DrawString("FACTURA N°: " & ochoDigP & nFacTb.Text, BIGFont3, Brushes.Black, 10, 250)

                e.Graphics.DrawString("EMPRESA: " & empTb.Text, DFont, Brushes.Black, 10, 300)
                e.Graphics.DrawString("PROPIETARIO: " & propTb.Text, DFont, Brushes.Black, 10, 320)
                e.Graphics.DrawString("RTN: " & rtnTb.Text, DFont, Brushes.Black, 10, 340)

                e.Graphics.DrawString("PERIODO:  " & perMesCB.Text & " - " & perSemCB.Text, DFont, Brushes.Black, 470, 300)



                e.Graphics.DrawString("Descripción ", DFont, Brushes.Black, 10, 400)
                e.Graphics.DrawString(desc1Tb.Text, GFont, Brushes.Black, 15, 425)
                e.Graphics.DrawString(desc2Tb.Text, GFont, Brushes.Black, 15, 445)

                e.Graphics.DrawString("Cantd. ", DFont, Brushes.Black, 390, 400)
                e.Graphics.DrawString(cant1Tb.Text, GFont, Brushes.Black, 395, 425)
                e.Graphics.DrawString(cant2Tb.Text, GFont, Brushes.Black, 395, 445)

                e.Graphics.DrawString("Precio Unit. ", DFont, Brushes.Black, 495, 400)
                e.Graphics.DrawString("L. " & preUni1Tb.Text, GFont, Brushes.Black, 500, 425)
                e.Graphics.DrawString("L. " & preUni2Tb.Text, GFont, Brushes.Black, 500, 445)

                e.Graphics.DrawString("ISV ", DFont, Brushes.Black, 650, 400)
                e.Graphics.DrawString("L. 0.00 ", GFont, Brushes.Black, 655, 425)
                e.Graphics.DrawString("L. 0.00 ", GFont, Brushes.Black, 655, 445)

                e.Graphics.DrawString("Total ", DFont, Brushes.Black, 725, 400)
                e.Graphics.DrawString("L. " & tota1Tb.Text, GFont, Brushes.Black, 730, 425)
                e.Graphics.DrawString("L. " & tota2Tb.Text, GFont, Brushes.Black, 730, 445)

                e.Graphics.DrawString("____________________________________________________________________________________________________", DFont, Brushes.Black, 10, 400)
                e.Graphics.DrawString("____________________________________________________________________________________________________", DFont, Brushes.Black, 10, 405)



                e.Graphics.DrawString("____________________________________________________________________________________________________", DFont, Brushes.Black, 10, 475)
                e.Graphics.DrawString("OBSERVACIONES ", DFont, Brushes.Black, 10, 495)

                Dim xRect As New Rectangle(10, 525, 800, 405)
                e.Graphics.DrawString(comentaTb.Text, New Font("Arial", 10), Brushes.Black, xRect)

                'e.Graphics.DrawString(comentaTb.Text, DFont, Brushes.Black, 10, 525)


                e.Graphics.DrawString("Registro SAG: N/A Nº Orden Exenta: N/A Nº Registro exonerado: N/A ", nFont, Brushes.Black, 10, 800)
                e.Graphics.DrawString(pLetras.Text, nFont, Brushes.Black, 10, 770)

                e.Graphics.DrawString("Exento: ", DFont, Brushes.Black, 650, 800, format2)
                e.Graphics.DrawString("L. " & facTotTb.Text, DFont, Brushes.Black, 660, 787)

                e.Graphics.DrawString("Exonerado: ", DFont, Brushes.Black, 650, 820, format2)
                e.Graphics.DrawString("L. " & "0.00 ", DFont, Brushes.Black, 660, 807)

                e.Graphics.DrawString("Gravado al 15%: ", DFont, Brushes.Black, 650, 840, format2)
                e.Graphics.DrawString("L. " & "0.00 ", DFont, Brushes.Black, 660, 827)

                e.Graphics.DrawString("Gravado al 18%: ", DFont, Brushes.Black, 650, 860, format2)
                e.Graphics.DrawString("L. " & "0.00 ", DFont, Brushes.Black, 660, 847)

                e.Graphics.DrawString("ISV 15%: ", DFont, Brushes.Black, 650, 880, format2)
                e.Graphics.DrawString("L. " & "0.00 ", DFont, Brushes.Black, 660, 867)

                e.Graphics.DrawString("ISV 18%: ", DFont, Brushes.Black, 650, 900, format2)
                e.Graphics.DrawString("L. " & "0.00 ", DFont, Brushes.Black, 660, 887)

                e.Graphics.DrawString("TOTAL: ", BIGFont2, Brushes.Black, 650, 930, format2)
                e.Graphics.DrawString("L. " & facTotTb.Text, BIGFont2, Brushes.Black, 660, 917)

                e.Graphics.DrawString("____________________________________________________________________________________________________", DFont, Brushes.Black, 10, 1010)
                e.Graphics.DrawString("ORIGINAL: Cliente", DFont, Brushes.Black, 10, 1030)
                e.Graphics.DrawString("COPIA: Obligatorio Tributario Emisor", GFont, Brushes.Black, 10, 1050)

                        End While
                    End Using
                End Using

            Catch ex As Exception
                MessageBox.Show("Error: " & ex.Message)
            End Try
        End Using
    End Sub

    Private Sub ButtonX4_Click(sender As Object, e As EventArgs) Handles PreviaBtn.Click
        Try
            PanelP.Enabled = True

            PrintFactura.PrinterSettings.Copies = 2

            ' Mostrar vista previa
            PrintPreviewFactura.Document = PrintFactura
            PrintPreviewFactura.ShowDialog()

            CancelarBtn.Enabled = True
        Catch ex As Exception
            MessageBox.Show("Error en vista previa: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub CancelarBtn_Click(sender As Object, e As EventArgs) Handles CancelarBtn.Click
        Me.PreviaBtn.Enabled = False
        NuevoBtn.Enabled = True
        GuardarBtn.Enabled = False
        PanelP.Enabled = False
        CancelarBtn.Enabled = False
        CamDgv.Enabled = True
    End Sub

    Private Sub preUni1Tb_TextChanged(sender As Object, e As EventArgs) Handles preUni1Tb.TextChanged
        sumas()
    End Sub
    Private Sub preUni2Tb_TextChanged(sender As Object, e As EventArgs) Handles preUni2Tb.TextChanged
        sumas()
    End Sub

    Private Sub cant1Tb_TextChanged(sender As Object, e As EventArgs) Handles cant1Tb.TextChanged
        sumas()
    End Sub
    Private Sub cant2Tb_TextChanged(sender As Object, e As EventArgs) Handles cant2Tb.TextChanged
        sumas()
    End Sub
    Private Sub sumas()
        Try
            Dim preu2 As Double = 0
            Dim preu1 As Double = 0
            Dim cant1 As Double = 0
            Dim cant2 As Double = 0

            Double.TryParse(preUni2Tb.Text, preu2)
            Double.TryParse(preUni1Tb.Text, preu1)
            Double.TryParse(cant1Tb.Text, cant1)
            Double.TryParse(cant2Tb.Text, cant2)

            tota1Tb.Text = Format(preu1 * cant1, "#,##0.00")
            tota2Tb.Text = Format(preu2 * cant2, "#,##0.00")

            Dim tot1 As Double = 0
            Dim tot2 As Double = 0
            Double.TryParse(tota1Tb.Text, tot1)
            Double.TryParse(tota2Tb.Text, tot2)

            facTotTb.Text = Format(tot1 + tot2, "#,##0.00")

            facCanTB.Text = Format(cant1 + cant2, "#,##0.00")

            calcularletras()

        Catch ex As Exception
            ' Error silencioso en cálculos - no mostrar al usuario
        End Try

    End Sub

    Private Sub ButtonX2_Click(sender As Object, e As EventArgs) Handles ButtonX2.Click
        seleccion()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

    End Sub

    Public Sub seleccion()
        Try
            Dim lista As Integer = 0

            If CodBusqTB.Text <> "" Then
                If con.State = ConnectionState.Closed Then con.Open()
                Dim cmd As New MySqlCommand("SELECT * FROM propietario WHERE codProp = @codProp", con)
                cmd.Parameters.AddWithValue("@codProp", CodBusqTB.Text)
                adaptador = New MySqlDataAdapter(cmd)
                datos = New DataSet
                adaptador.Fill(datos, "propietario")
                lista = datos.Tables("propietario").Rows.Count
            End If

            If lista <> 0 Then
                empTb.Text = datos.Tables("propietario").Rows(0).Item("nEmpresa").ToString
                propTb.Text = datos.Tables("propietario").Rows(0).Item("nPropietario").ToString
                rtnTb.Text = datos.Tables("propietario").Rows(0).Item("RTN").ToString
                codPropTb.Text = datos.Tables("propietario").Rows(0).Item("codProp").ToString
            Else
                MsgBox("Datos no encontrados")
            End If
        Catch ex As Exception
            MessageBox.Show("Error al buscar: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Sub seleccion2()
        Try
            Dim lista As Integer = 0

            If propBusqTB.Text <> "" Then
                If con.State = ConnectionState.Closed Then con.Open()
                Dim cmd As New MySqlCommand("SELECT * FROM factura WHERE codProp = @codProp", con)
                cmd.Parameters.AddWithValue("@codProp", propBusqTB.Text)
                adaptador = New MySqlDataAdapter(cmd)
                datos = New DataSet
                adaptador.Fill(datos, "factura")
                lista = datos.Tables("factura").Rows.Count
            End If

            If lista <> 0 Then
                llenado()
            Else
                MsgBox("Datos no encontrados")
            End If
        Catch ex As Exception
            MessageBox.Show("Error al buscar factura: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Sub seleccion3()
        Try
            Dim lista As Integer = 0

            If propBusqTB.Text <> "" Then
                If con.State = ConnectionState.Closed Then con.Open()
                Dim cmd As New MySqlCommand("SELECT * FROM factura WHERE idFactura = @idFactura", con)
                cmd.Parameters.AddWithValue("@idFactura", propBusqTB.Text)
                adaptador = New MySqlDataAdapter(cmd)
                datos = New DataSet
                adaptador.Fill(datos, "factura")
                lista = datos.Tables("factura").Rows.Count
            End If

            If lista <> 0 Then
                llenado()
            Else
                MsgBox("Datos no encontrados")
            End If
        Catch ex As Exception
            MessageBox.Show("Error al buscar factura: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Sub llenado()
        nFacTb.Text = datos.Tables("factura").Rows(0).Item("nFactura").ToString
        fechaPk.Text = datos.Tables("factura").Rows(0).Item("fecha").ToString
        propTb.Text = datos.Tables("factura").Rows(0).Item("propietario").ToString
        empTb.Text = datos.Tables("factura").Rows(0).Item("empresa").ToString
        rtnTb.Text = datos.Tables("factura").Rows(0).Item("rtn").ToString
        tipoPagTb.Text = datos.Tables("factura").Rows(0).Item("tipoPag").ToString
        facCanTB.Text = datos.Tables("factura").Rows(0).Item("facCantidad").ToString
        facExeTb.Text = datos.Tables("factura").Rows(0).Item("facExe").ToString
        facTotTb.Text = datos.Tables("factura").Rows(0).Item("facTotal").ToString.Replace(",", "")
        comentaTb.Text = datos.Tables("factura").Rows(0).Item("comentario").ToString
        cant1Tb.Text = datos.Tables("factura").Rows(0).Item("cantd1").ToString
        cant2Tb.Text = datos.Tables("factura").Rows(0).Item("cantd2").ToString
        desc1Tb.Text = datos.Tables("factura").Rows(0).Item("descrip1").ToString
        desc2Tb.Text = datos.Tables("factura").Rows(0).Item("descrip2").ToString
        tota1Tb.Text = datos.Tables("factura").Rows(0).Item("total1").ToString.Replace(",", "")
        tota2Tb.Text = datos.Tables("factura").Rows(0).Item("total2").ToString.Replace(",", "")
        perMesCB.Text = datos.Tables("factura").Rows(0).Item("perMes").ToString
        perSemCB.Text = datos.Tables("factura").Rows(0).Item("PerSem").ToString
        preUni1Tb.Text = datos.Tables("factura").Rows(0).Item("preUni1").ToString
        preUni2Tb.Text = datos.Tables("factura").Rows(0).Item("preUni2").ToString
        codPropTb.Text = datos.Tables("factura").Rows(0).Item("codProp").ToString



    End Sub
    Private Sub CodproBTb_TextChanged(sender As Object, e As EventArgs) Handles CodproBTb.TextChanged

        codCamDgv()

    End Sub
    Private Sub codCamDgv() 'Autobusqueda Codigo
        Try
            If con.State = ConnectionState.Closed Then con.Open()

            Dim table As New DataTable()
            Dim cmd As New MySqlCommand("SELECT * FROM factura WHERE codProp LIKE @codProp", con)
            cmd.Parameters.AddWithValue("@codProp", "%" & CodproBTb.Text & "%")
            Dim adaptadoListado As New MySqlDataAdapter(cmd)
            adaptadoListado.Fill(table)

            CamDgv.DataSource = table

            ListadoD()

        Catch ex As Exception
            MessageBox.Show("Error en búsqueda: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If con.State = ConnectionState.Open Then con.Close()
        End Try

    End Sub

    Private Sub ButtonX4_Click_1(sender As Object, e As EventArgs) Handles DelBtn.Click
        CodBusqTB.Text = ""
        empTb.Text = ""
        propTb.Text = ""
        rtnTb.Text = ""
    End Sub

    Private Sub ButtonX5_Click_1(sender As Object, e As EventArgs) Handles ButtonX5.Click
        seleccion2()
    End Sub
    Private Sub ButtonX7_Click(sender As Object, e As EventArgs) Handles ButtonX7.Click
        limpiar()
    End Sub

    Private Sub CamDgv_Click(sender As Object, e As EventArgs) Handles CamDgv.Click
        Try
            NuevoBtn.PerformClick()
            CancelarBtn.PerformClick()
            limpiar()

            If Me.CamDgv.RowCount = 0 Then
                MessageBox.Show("No hay datos a mostrar")
            Else
                Dim i As Integer = Me.CamDgv.CurrentRow.Index
                Me.propBusqTB.Text = Me.CamDgv.Item(0, i).Value.ToString()

                Dim y As Integer = Me.CamDgv.CurrentRow.Index
                Dim idcod As Integer = Convert.ToInt32(Me.CamDgv.Item(0, y).Value)
                propBusqTB.Text = idcod.ToString()
                buscartxt.Text = idcod.ToString()
                seleccion3()
                Me.EditarBtn.Enabled = True
                Me.EliminarBtn.Enabled = True
                PreviaBtn.Enabled = True
            End If
        Catch ex As Exception
            MessageBox.Show("Error al seleccionar registro: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        facTotTb.Text = facTotTb.Text.Replace(",", "")
    End Sub
    Private Sub PrintPreviewFactura_Leave(sender As Object, e As EventArgs) Handles PrintPreviewFactura.Leave
        Me.CancelarBtn.PerformClick()
    End Sub
    Private Sub PrintPreviewFactura_FormClosed(sender As Object, e As FormClosedEventArgs) Handles PrintPreviewFactura.FormClosed
        Me.PanelP.Enabled = False
        Me.CancelarBtn.PerformClick()
        medicion.CancelarBtn.Enabled = False
    End Sub

    Private Sub CodBusqTB_KeyDown(sender As Object, e As KeyEventArgs) Handles CodBusqTB.KeyDown
        If e.KeyCode = Keys.Enter Then
            seleccion()
        End If
        If e.KeyCode = Keys.Delete Then
            DelBtn.PerformClick()
        End If
    End Sub

    Private Sub btnPaste_Click(sender As Object, e As EventArgs) Handles btnPaste.Click
        If Clipboard.ContainsText() Then
            comentaTb.Text = Clipboard.GetText()
        End If
    End Sub

    Private Sub ButtonX4_Click_2(sender As Object, e As EventArgs) Handles ButtonX4.Click
        comentaTb.Text = ""
    End Sub

    Private Sub cant1Tb_KeyDown(sender As Object, e As KeyEventArgs) Handles cant1Tb.KeyDown
        Try
            Select Case e.KeyData
                Case Keys.Enter
                    desc1Tb.Select()
                Case Keys.Tab
                    desc1Tb.Select()
            End Select
        Catch
        End Try
    End Sub

    Private Sub desc1Tb_KeyDown(sender As Object, e As KeyEventArgs) Handles desc1Tb.KeyDown
        Try
            Select Case e.KeyData
                Case Keys.Enter
                    preUni1Tb.Select()
                Case Keys.Tab
                    preUni1Tb.Select()
            End Select
        Catch
        End Try
    End Sub

    Private Sub preUni1Tb_KeyDown(sender As Object, e As KeyEventArgs) Handles preUni1Tb.KeyDown
        Try
            Select Case e.KeyData
                Case Keys.Enter
                    tota1Tb.Select()
                Case Keys.Tab
                    tota1Tb.Select()
            End Select
        Catch
        End Try
    End Sub

    Private Sub tota1Tb_KeyDown(sender As Object, e As KeyEventArgs) Handles tota1Tb.KeyDown
        Try
            Select Case e.KeyData
                Case Keys.Enter
                    cant2Tb.Select()
                Case Keys.Tab
                    cant2Tb.Select()
            End Select
        Catch
        End Try
    End Sub

    Private Sub cant2Tb_KeyDown(sender As Object, e As KeyEventArgs) Handles cant2Tb.KeyDown
        Try
            Select Case e.KeyData
                Case Keys.Enter
                    desc2Tb.Select()
                Case Keys.Tab
                    desc2Tb.Select()
            End Select
        Catch
        End Try
    End Sub

    Private Sub desc2Tb_KeyDown(sender As Object, e As KeyEventArgs) Handles desc2Tb.KeyDown
        Try
            Select Case e.KeyData
                Case Keys.Enter
                    preUni2Tb.Select()
                Case Keys.Tab
                    preUni2Tb.Select()
            End Select
        Catch
        End Try
    End Sub

    Private Sub preUni2Tb_KeyDown(sender As Object, e As KeyEventArgs) Handles preUni2Tb.KeyDown
        Try
            Select Case e.KeyData
                Case Keys.Enter
                    tota2Tb.Select()
                Case Keys.Tab
                    tota2Tb.Select()
            End Select
        Catch
        End Try
    End Sub

    Private Sub tota2Tb_KeyDown(sender As Object, e As KeyEventArgs) Handles tota2Tb.KeyDown
        Try
            Select Case e.KeyData
                Case Keys.Enter
                    cant1Tb.Select()
                Case Keys.Tab
                    cant1Tb.Select()
            End Select
        Catch
        End Try
    End Sub

    Private Sub cant1Tb_Enter(sender As Object, e As EventArgs) Handles cant1Tb.Enter
        cant1Tb.BackColor = Color.Yellow
        cant1Tb.ForeColor = Color.Black
    End Sub

    Private Sub cant1Tb_Leave(sender As Object, e As EventArgs) Handles cant1Tb.Leave
        cant1Tb.BackColor = Color.White
        cant1Tb.ForeColor = Color.Black
    End Sub

    Private Sub desc1Tb_Enter(sender As Object, e As EventArgs) Handles desc1Tb.Enter
        desc1Tb.BackColor = Color.Yellow
        desc1Tb.ForeColor = Color.Black
    End Sub

    Private Sub desc1Tb_Leave(sender As Object, e As EventArgs) Handles desc1Tb.Leave
        desc1Tb.BackColor = Color.White
        desc1Tb.ForeColor = Color.Black
    End Sub

    Private Sub preUni1Tb_Enter(sender As Object, e As EventArgs) Handles preUni1Tb.Enter
        preUni1Tb.BackColor = Color.Yellow
        preUni1Tb.ForeColor = Color.Black
    End Sub

    Private Sub preUni1Tb_Leave(sender As Object, e As EventArgs) Handles preUni1Tb.Leave
        preUni1Tb.BackColor = Color.White
        preUni1Tb.ForeColor = Color.Black
    End Sub

    Private Sub tota1Tb_Enter(sender As Object, e As EventArgs) Handles tota1Tb.Enter
        tota1Tb.BackColor = Color.Yellow
        tota1Tb.ForeColor = Color.Black
    End Sub
    Private Sub tota1Tb_Leave(sender As Object, e As EventArgs) Handles tota1Tb.Leave
        tota1Tb.BackColor = Color.White
        tota1Tb.ForeColor = Color.Black
    End Sub
    Private Sub cant12b_Enter(sender As Object, e As EventArgs) Handles cant2Tb.Enter
        cant2Tb.BackColor = Color.Yellow
        cant2Tb.ForeColor = Color.Black
    End Sub

    Private Sub cant2Tb_Leave(sender As Object, e As EventArgs) Handles cant2Tb.Leave
        cant2Tb.BackColor = Color.White
        cant2Tb.ForeColor = Color.Black
    End Sub

    Private Sub desc2Tb_Enter(sender As Object, e As EventArgs) Handles desc2Tb.Enter
        desc2Tb.BackColor = Color.Yellow
        desc2Tb.ForeColor = Color.Black
    End Sub

    Private Sub desc2Tb_Leave(sender As Object, e As EventArgs) Handles desc2Tb.Leave
        desc2Tb.BackColor = Color.White
        desc2Tb.ForeColor = Color.Black
    End Sub

    Private Sub preUni2Tb_Enter(sender As Object, e As EventArgs) Handles preUni2Tb.Enter
        preUni2Tb.BackColor = Color.Yellow
        preUni2Tb.ForeColor = Color.Black
    End Sub

    Private Sub preUni2Tb_Leave(sender As Object, e As EventArgs) Handles preUni2Tb.Leave
        preUni2Tb.BackColor = Color.White
        preUni2Tb.ForeColor = Color.Black
    End Sub

    Private Sub tota2Tb_Enter(sender As Object, e As EventArgs) Handles tota2Tb.Enter
        tota2Tb.BackColor = Color.Yellow
        tota2Tb.ForeColor = Color.Black
    End Sub

    Private Sub tota2Tb_Leave(sender As Object, e As EventArgs) Handles tota2Tb.Leave
        tota2Tb.BackColor = Color.White
        tota2Tb.ForeColor = Color.Black
    End Sub

    Private Sub ImprimirBt_Click(sender As Object, e As EventArgs) Handles ImprimirBt.Click

    End Sub

    Private Sub PrintPreviewFactura_Load(sender As Object, e As EventArgs) Handles PrintPreviewFactura.Load

    End Sub
End Class