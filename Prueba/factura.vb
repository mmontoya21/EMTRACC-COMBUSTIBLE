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

    Private isMouseDown As Boolean = False
    Private mouseOffset As Point

    Dim colorFondo = Color.FromArgb(106, 126, 168)
    Dim colorTextbox = Color.FromArgb(240, 210, 249)


    Private Sub factura_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        On Error Resume Next

        System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("es-CO")
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

    End Sub

    Private Sub conectar()
        'Dim servidor As String = "localhost"
        Dim servidor As String = "192.168.68.101"
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
        If con.State = ConnectionState.Closed Then
            con.Open()
        End If
        limpiar()
        PanelP.Enabled = True
        GuardarBtn.Enabled = True
        CamDgv.Enabled = False
        CancelarBtn.Enabled = True
        Me.PreviaBtn.Enabled = True
        NuevoBtn.Enabled = False
        tipoPagTb.Text = "CONTADO"

        Try

            ' Consulta para obtener el último registro (campo nFactura)
            Dim query As String = "SELECT nFactura FROM factura ORDER BY idFactura DESC LIMIT 1"
            Dim comando As New MySqlCommand(query, con)
            Dim lector As MySqlDataReader = comando.ExecuteReader()

            ' Verificar si hay registros
            If lector.Read() Then
                ' Asignar el valor de nFactura al TextBox
                CodproBTb.Text = lector("nFactura").ToString()

                Dim nfacta As Double = Double.Parse(CodproBTb.Text)
                nFacTb.Text = nfacta + 1 ' Suma factura
                amplitud()
            Else
                nFacTb.Text = 1
                amplitud()
            End If

            lector.Close()
            ''
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        Finally
            ' Cerrar la conexión
            con.Close()
        End Try

        Me.cant1Tb.Text = 0
        Me.cant2Tb.Text = 0
        Me.preUni1Tb.Text = 0
        Me.preUni2Tb.Text = 0
        Me.tota1Tb.Text = 0
        Me.tota2Tb.Text = 0

        Me.facTotTb.Text = 0
        Me.facExeTb.Text = 0
        Me.facCanTB.Text = 0

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

        Me.PreviaBtn.Enabled = False

        con.Close()
        con.Open()

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

        Dim perMes As Integer = 0
        Integer.TryParse(perMesCB.Text, perMes)

        Dim perSem As Integer = 0
        Integer.TryParse(perSemCB.Text, perSem)

        Dim cpreUni1Tb As Double = 0
        Double.TryParse(preUni1Tb.Text, cpreUni1Tb)

        Dim cpreUni2Tb As Double = 0
        Double.TryParse(preUni2Tb.Text, cpreUni2Tb)

        'Dim perMes = Val(perMesCB.Text)

        ' Dim perSem = Val(perSemCB.Text)
        Try
            guardar = New MySqlCommand("INSERT INTO factura (nFactura, Fecha, propietario, Empresa, rtn, tipoPag, facCantidad, facExe, facTotal, comentario, cantd1, cantd2, descrip1, descrip2, total1, total2, perMes, PerSem, preUni1, preUni2, codProp)" & Chr(13) &
            "VALUES(@nFactura, @Fecha, @propietario, @Empresa, @rtn, @tipoPag, @facCantidad, @facExe, @facTotal, @comentario, @cantd1, @cantd2, @descrip1, @descrip2, @total1, @total2, @perMes, @PerSem, @preUni1Tb, @preUni2Tb, @codProp)", con)


            guardar.Parameters.AddWithValue("@nFactura", nFacTb.Text)
            guardar.Parameters.AddWithValue("@Fecha", fe)
            guardar.Parameters.AddWithValue("@propietario", propTb.Text)
            guardar.Parameters.AddWithValue("@Empresa", empTb.Text)
            guardar.Parameters.AddWithValue("@rtn", rtnTb.Text)
            guardar.Parameters.AddWithValue("@tipoPag", tipoPagTb.Text)
            guardar.Parameters.AddWithValue("@facCantidad", cfacCanTB)
            guardar.Parameters.AddWithValue("@facExe", cfacExeTb)
            guardar.Parameters.AddWithValue("@facTotal", cfacTotTb)
            guardar.Parameters.AddWithValue("@comentario", comentaTb.Text)
            guardar.Parameters.AddWithValue("@cantd1", ccant1Tb)
            guardar.Parameters.AddWithValue("@cantd2", ccant2Tb)
            guardar.Parameters.AddWithValue("@descrip1", desc1Tb.Text)
            guardar.Parameters.AddWithValue("@descrip2", desc2Tb.Text)
            guardar.Parameters.AddWithValue("@total1", ctota1Tb)
            guardar.Parameters.AddWithValue("@total2", ctota2Tb)
            guardar.Parameters.AddWithValue("@perMes", perMes)
            guardar.Parameters.AddWithValue("@PerSem", perSem)
            guardar.Parameters.AddWithValue("@preUni1Tb", cpreUni1Tb)
            guardar.Parameters.AddWithValue("@preUni2Tb", cpreUni2Tb)
            guardar.Parameters.AddWithValue("@codProp", codPropTb.Text)

            guardar.ExecuteNonQuery()
            MsgBox("Registo guardado")

        Catch ex As Exception
            MsgBox("Elemento no pudo se almacenado", ex.StackTrace)
        End Try

        limpiar()

        act()

        CamDgv.Enabled = True
        listadoCamDgv()

        PanelP.Enabled = False
        CamDgv.Enabled = True
        Me.GuardarBtn.Visible = True
    End Sub

    Private Sub ModificarBtn_Click(sender As Object, e As EventArgs) Handles ModificarBtn.Click '============  MODIFICAR  ===========
        actual()
        act()
        PanelP.Enabled = False
        CamDgv.Enabled = True
        Me.GuardarBtn.Visible = True
        listadoCamDgv()
        con.Close()
    End Sub
    Public Sub actual()
        ' Try
        If con.State = ConnectionState.Closed Then
            con.Open()
        End If

        Dim fe As Date = fechaPk.Value.ToString("yyyy-MM-dd")
        facTotTb.Text = facTotTb.Text.Replace(",", "")
        tota1Tb.Text = tota1Tb.Text.Replace(",", "")
        tota2Tb.Text = tota2Tb.Text.Replace(",", "")

        Dim actualizar As String
        actualizar = "UPDATE factura SET nFactura = '" & nFacTb.Text & "', propietario = '" & propTb.Text & "', Empresa = '" & empTb.Text & "', rtn = '" & rtnTb.Text & "', tipoPag = '" & tipoPagTb.Text & "', facCantidad = '" & facCanTB.Text & "', facExe = '" & facExeTb.Text & "', facTotal = '" & facTotTb.Text & "', comentario = '" & comentaTb.Text & "', cantd1 = '" & cant1Tb.Text & "', cantd2 = '" & cant2Tb.Text & "', descrip1 = '" & desc1Tb.Text & "', descrip2 = '" & desc2Tb.Text & "', total1 = '" & tota1Tb.Text & "', total2 = '" & tota2Tb.Text & "', perMes = '" & perMesCB.Text & "', PerSem = '" & perSemCB.Text & "', preUni1 = '" & preUni1Tb.Text & "', preUni2 = '" & preUni2Tb.Text & "', fecha = '" & fe & "', codProp = '" & codPropTb.Text & "' WHERE idfactura = '" & propBusqTB.Text & "'"

        Dim act As New MySqlCommand(actualizar, con)
        act.ExecuteNonQuery()
        MsgBox("Registo Actualizado")
        'Catch
        'MsgBox("No deben haber registros vacios, colocar 0 en tal caso.")
        'End Try

    End Sub

    Private Sub EliminarBtn_Click(sender As Object, e As EventArgs) Handles EliminarBtn.Click '============  ELIMINAR  ===========
        Try

            Dim opc As DialogResult = MsgBox("¿Desea Eliminar este registro?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Eliminar")
            If opc = Windows.Forms.DialogResult.Yes Then

                Dim eliminar As String

                eliminar = "DELETE FROM factura WHERE idfactura = '" & Conversion.Int(Me.buscartxt.Text) & "'"
                Dim eli As New MySqlCommand(eliminar, con)
                eli.ExecuteNonQuery()

                listadoCamDgv()

            End If
        Catch
            MessageBox.Show("Actualización Base de Datos, " & Chr(13) & "favor escoger de nuevo el registro y eliminarlo", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)

        End Try

        act()
    End Sub
    Private Sub listadoCamDgv() 'Muestra los datos
        Dim table As New DataTable()
        Dim adaptadoListado As New MySqlDataAdapter("SELECT idFactura, codProp, empresa, propietario, nfactura FROM factura", con)
        adaptadoListado.Fill(table)

        CamDgv.DataSource = table

        ListadoD()

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
        con.Close()
        con.Open()

        Try

            ' Consulta para obtener el último registro (campo nFactura)
            Dim query As String = "SELECT nEmpre, nPropie, nombLocal, dire1, dire2 ,dire3, local, rtn, correoE, cai, tel1, cel2, fax, ochoDig, rangoIni, rangoFin, fechaLimit FROM empresa"
            Dim comando As New MySqlCommand(query, con)
            Dim lector As MySqlDataReader = comando.ExecuteReader()


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

                e.Graphics.DrawString("PERIODO " & perMesCB.Text & perSemCB.Text, DFont, Brushes.Black, 470, 300)



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
            lector.Close()

        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        Finally
            ' Cerrar la conexión

            con.Close()
        End Try
    End Sub
    Private Sub ButtonX4_Click(sender As Object, e As EventArgs) Handles PreviaBtn.Click
        PanelP.Enabled = True
        PrintPreviewFactura.Document = PrintFactura()
        PrintPreviewFactura.ShowDialog()
        CancelarBtn.Enabled = True
    End Sub

    Private Sub CancelarBtn_Click(sender As Object, e As EventArgs) Handles CancelarBtn.Click
        Me.PreviaBtn.Enabled = False
        NuevoBtn.Enabled = True
        GuardarBtn.Enabled = False
        PanelP.Enabled = False
        CancelarBtn.Enabled = False
        CamDgv.Enabled = True
        con.Close()
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
            Dim preu2 As Double = Double.Parse(preUni2Tb.Text)
            Dim preu1 As Double = Double.Parse(preUni1Tb.Text)
            Dim cant1 As Double = Double.Parse(cant1Tb.Text)
            Dim cant2 As Double = Double.Parse(cant2Tb.Text)

            tota1Tb.Text = Format(preu1 * cant1, "#,##0.00")
            tota2Tb.Text = Format(preu2 * cant2, "#,##0.00")

            Dim tot1 As Double = Double.Parse(tota1Tb.Text)
            Dim tot2 As Double = Double.Parse(tota2Tb.Text)

            facTotTb.Text = Format(tot1 + tot2, "#,##0.00")

            facCanTB.Text = Format(cant1 + cant2, "#,##0.00")

            calcularletras()

        Catch
        End Try

    End Sub

    Private Sub ButtonX2_Click(sender As Object, e As EventArgs) Handles ButtonX2.Click
        seleccion()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

    End Sub

    Public Sub seleccion()
        Dim consulta As String
        Dim lista As Byte

        If CodBusqTB.Text <> "" Then
            consulta = "SELECT * FROM propietario WHERE codProp = '" & CodBusqTB.Text & "'"
            adaptador = New MySqlDataAdapter(consulta, con)
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
        'listadoCamDgv()
    End Sub

    Public Sub seleccion2()
        Dim consulta As String
        Dim lista As Byte

        If propBusqTB.Text <> "" Then
            consulta = "SELECT * FROM factura WHERE codProp = '" & propBusqTB.Text & "'"
            adaptador = New MySqlDataAdapter(consulta, con)
            datos = New DataSet
            adaptador.Fill(datos, "factura")
            lista = datos.Tables("factura").Rows.Count
        End If

        If lista <> 0 Then

            llenado()


        Else
            MsgBox("Datos no encontrados")
        End If
        'listadoCamDgv()
    End Sub
    Public Sub seleccion3()
        Dim consulta As String
        Dim lista As Byte

        If propBusqTB.Text <> "" Then
            consulta = "SELECT * FROM factura WHERE idFactura = '" & propBusqTB.Text & "'"
            adaptador = New MySqlDataAdapter(consulta, con)
            datos = New DataSet
            adaptador.Fill(datos, "factura")
            lista = datos.Tables("factura").Rows.Count
        End If

        If lista <> 0 Then

            llenado()

        Else
            MsgBox("Datos no encontrados")
        End If
        'listadoCamDgv()
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

            Dim table As New DataTable()
            Dim adaptadoListado As New MySqlDataAdapter("SELECT * FROM factura WHERE codProp LIKE '%" & CodproBTb.Text & "%'", con)
            adaptadoListado.Fill(table)

            CamDgv.DataSource = table

            ListadoD()

        Catch
        End Try

    End Sub

    Private Sub ButtonX4_Click_1(sender As Object, e As EventArgs) Handles ButtonX4.Click
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
        limpiar()

        If Me.CamDgv.RowCount = 0 Then
            MessageBox.Show("No hay datos a mostrar")
        Else
            Dim i As Integer = Me.CamDgv.CurrentRow.Index
            Me.propBusqTB.Text = Me.CamDgv.Item(0, i).Value

            Dim y As Integer = Me.CamDgv.CurrentRow.Index
            Dim idcod As Integer = Me.CamDgv.Item(0, y).Value
            propBusqTB.Text = idcod
            seleccion3()
            Me.EditarBtn.Enabled = True
            Me.EliminarBtn.Enabled = True
            PreviaBtn.Enabled = True
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        facTotTb.Text = facTotTb.Text.Replace(",", "")
    End Sub
End Class