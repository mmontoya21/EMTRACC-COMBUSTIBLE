Imports System.Data
Imports MySql.Data.MySqlClient
Imports MySql.Data
Imports System.Drawing
Imports System.Drawing.Printing
Imports System.Text
Imports System.IO
Imports ClosedXML.Excel

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

    ' Paleta de colores por grupo para reporteDGV (ciclo de 3)
    Private ReadOnly coloresSuaves() As Color = {
        Color.FromArgb(255, 243, 224),
        Color.FromArgb(227, 242, 253),
        Color.FromArgb(232, 245, 233)
    }
    Private ReadOnly coloresIntensos() As Color = {
        Color.FromArgb(255, 224, 178),
        Color.FromArgb(187, 222, 251),
        Color.FromArgb(200, 230, 201)
    }
    Private ReadOnly coloresTextoSub() As Color = {
        Color.FromArgb(80, 60, 0),
        Color.FromArgb(0, 40, 80),
        Color.FromArgb(0, 60, 20)
    }



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
            ModuloConexion.EstilizarDataGridView(FactDgv)
            ModuloConexion.EstilizarDataGridView(reporteDGV)
            cargarDatosReporte()

            desactivarPanel()
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

    Private Sub buscarFechaBtn_Click(sender As Object, e As EventArgs) Handles buscarFechaBtn.Click
        buscarPorFechas()
    End Sub

    Private Sub limpiarFechaBtn_Click(sender As Object, e As EventArgs) Handles limpiarFechaBtn.Click
        CodproBTb.Text = ""
        listadoCamDgv()
    End Sub

    Private Sub buscarPorFechas()
        Try
            Dim fechaDesde As Date = fechaDesdePk.Value.Date
            Dim fechaHasta As Date = fechaHastaPk.Value.Date

            If fechaDesde > fechaHasta Then
                MessageBox.Show("La fecha 'Desde' no puede ser mayor que 'Hasta'.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            Using conLocal As MySqlConnection = ModuloConexion.ObtenerConexion()
                conLocal.Open()

                Dim table As New DataTable()
                Dim sql As String = "SELECT idFactura, codProp, empresa, propietario, nfactura, fecha FROM factura WHERE fecha BETWEEN @fechaDesde AND @fechaHasta ORDER BY fecha DESC"
                Using cmd As New MySqlCommand(sql, conLocal)
                    cmd.Parameters.AddWithValue("@fechaDesde", fechaDesde.ToString("yyyy-MM-dd"))
                    cmd.Parameters.AddWithValue("@fechaHasta", fechaHasta.ToString("yyyy-MM-dd"))
                    Dim adaptadoListado As New MySqlDataAdapter(cmd)
                    adaptadoListado.Fill(table)
                End Using

                FactDgv.DataSource = table
            End Using

            ListadoD()

        Catch ex As Exception
            MessageBox.Show("Error en búsqueda por fecha: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
        If ModuloConexion.EsSoloLectura() Then NuevoBtn.Enabled = False
    End Sub

    Private Sub activarPanel()
        For Each ctrl As Control In PanelP.Controls
            If TypeOf ctrl Is DevComponents.DotNetBar.LabelX Then
                ctrl.ForeColor = Color.Black
            ElseIf TypeOf ctrl Is DevComponents.DotNetBar.Controls.TextBoxX Then
                CType(ctrl, DevComponents.DotNetBar.Controls.TextBoxX).ReadOnly = False
                ctrl.ForeColor = Color.Blue
            ElseIf TypeOf ctrl Is DevComponents.DotNetBar.Controls.ComboBoxEx Then
                ctrl.Enabled = True
                ctrl.ForeColor = Color.Blue
            ElseIf TypeOf ctrl Is ComboBox Then
                ctrl.Enabled = True
                ctrl.ForeColor = Color.Blue
            End If
        Next
    End Sub

    Private Sub desactivarPanel()
        For Each ctrl As Control In PanelP.Controls
            If TypeOf ctrl Is DevComponents.DotNetBar.LabelX Then
                ctrl.ForeColor = Color.Gold
            ElseIf TypeOf ctrl Is DevComponents.DotNetBar.Controls.TextBoxX Then
                CType(ctrl, DevComponents.DotNetBar.Controls.TextBoxX).ReadOnly = True
                ctrl.ForeColor = Color.Gold
            ElseIf TypeOf ctrl Is DevComponents.DotNetBar.Controls.ComboBoxEx Then
                ctrl.Enabled = False
                ctrl.ForeColor = Color.Gold
            ElseIf TypeOf ctrl Is ComboBox Then
                ctrl.Enabled = False
                ctrl.ForeColor = Color.Gold
            End If
        Next
    End Sub

    Private Sub NuevoBtn_Click(sender As Object, e As EventArgs) Handles NuevoBtn.Click '============  NUEVO  ===========
        Try
            limpiar()
            activarPanel()
            GuardarBtn.Enabled = True
            FactDgv.Enabled = False
            CancelarBtn.Enabled = True
            Me.PreviaBtn.Enabled = True
            NuevoBtn.Enabled = False
            EditarBtn.Enabled = False
            EliminarBtn.Enabled = False
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
        Me.comenta2Tb.Text = ""
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

        activarPanel()
        GuardarBtn.Enabled = False
        ModificarBtn.Enabled = True
        FactDgv.Enabled = False
        CancelarBtn.Enabled = True
        GuardarBtn.Visible = False
        ModificarBtn.Visible = True

    End Sub

    Private Sub GuardarBtn_Click(sender As Object, e As EventArgs) Handles GuardarBtn.Click '============  GUARDADO  ===========
        Try
            Me.PreviaBtn.Enabled = False

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

            Using conLocal As MySqlConnection = ModuloConexion.ObtenerConexion()
                conLocal.Open()
                Using cmd As New MySqlCommand("INSERT INTO factura (nFactura, Fecha, propietario, Empresa, rtn, tipoPag, facCantidad, facExe, facTotal, comentario, comentario2, cantd1, cantd2, descrip1, descrip2, total1, total2, perMes, PerSem, preUni1, preUni2, codProp) VALUES(@nFactura, @Fecha, @propietario, @Empresa, @rtn, @tipoPag, @facCantidad, @facExe, @facTotal, @comentario, @comentario2, @cantd1, @cantd2, @descrip1, @descrip2, @total1, @total2, @perMes, @PerSem, @preUni1Tb, @preUni2Tb, @codProp)", conLocal)

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
                    cmd.Parameters.AddWithValue("@comentario2", comenta2Tb.Text)
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
            End Using

            MsgBox("Registro guardado")

            Dim resultado As DialogResult = MessageBox.Show(
                "¿Desea imprimir la Factura y el Documento?",
                "Imprimir",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question)

            If resultado = DialogResult.Yes Then
                PrintFactura.PrinterSettings.Copies = 2
                PrintFactura.Print()

                PrintDocumento.PrinterSettings.Copies = 2
                PrintDocumento.Print()
            End If

            limpiar()
            act()

            FactDgv.Enabled = True
            listadoCamDgv()

            desactivarPanel()
            FactDgv.Enabled = True
            Me.GuardarBtn.Visible = True

            If FactDgv.Rows.Count > 0 Then
                For Each col As DataGridViewColumn In FactDgv.Columns
                    If col.Visible Then
                        FactDgv.CurrentCell = FactDgv.Rows(FactDgv.Rows.Count - 1).Cells(col.Index)
                        Exit For
                    End If
                Next
            End If

        Catch ex As Exception
            MessageBox.Show("Error al guardar: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub ModificarBtn_Click(sender As Object, e As EventArgs) Handles ModificarBtn.Click '============  MODIFICAR  ===========
        actual()
        act()
        desactivarPanel()
        FactDgv.Enabled = True
        Me.GuardarBtn.Visible = True
        listadoCamDgv()
    End Sub

    Public Sub actual()
        Try
            Dim fe As Date = fechaPk.Value.ToString("yyyy-MM-dd")
            Dim facTotVal As String = facTotTb.Text.Replace(",", "")
            Dim tota1Val As String = tota1Tb.Text.Replace(",", "")
            Dim tota2Val As String = tota2Tb.Text.Replace(",", "")

            Using conLocal As MySqlConnection = ModuloConexion.ObtenerConexion()
                conLocal.Open()
                Using cmd As New MySqlCommand("UPDATE factura SET nFactura = @nFactura, propietario = @propietario, Empresa = @Empresa, rtn = @rtn, tipoPag = @tipoPag, facCantidad = @facCantidad, facExe = @facExe, facTotal = @facTotal, comentario = @comentario, comentario2 = @comentario2, cantd1 = @cantd1, cantd2 = @cantd2, descrip1 = @descrip1, descrip2 = @descrip2, total1 = @total1, total2 = @total2, perMes = @perMes, PerSem = @PerSem, preUni1 = @preUni1, preUni2 = @preUni2, fecha = @fecha, codProp = @codProp WHERE idfactura = @idfactura", conLocal)
                    cmd.Parameters.AddWithValue("@nFactura", nFacTb.Text)
                    cmd.Parameters.AddWithValue("@propietario", propTb.Text)
                    cmd.Parameters.AddWithValue("@Empresa", empTb.Text)
                    cmd.Parameters.AddWithValue("@rtn", rtnTb.Text)
                    cmd.Parameters.AddWithValue("@tipoPag", tipoPagTb.Text)
                    cmd.Parameters.AddWithValue("@facCantidad", facCanTB.Text)
                    cmd.Parameters.AddWithValue("@facExe", facExeTb.Text)
                    cmd.Parameters.AddWithValue("@facTotal", facTotVal)
                    cmd.Parameters.AddWithValue("@comentario", comentaTb.Text)
                    cmd.Parameters.AddWithValue("@comentario2", comenta2Tb.Text)
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

                Using conLocal As MySqlConnection = ModuloConexion.ObtenerConexion()
                    conLocal.Open()
                    Using cmd As New MySqlCommand("DELETE FROM factura WHERE idfactura = @idfactura", conLocal)
                        cmd.Parameters.AddWithValue("@idfactura", Conversion.Int(Me.buscartxt.Text))
                        cmd.ExecuteNonQuery()
                    End Using
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
            Using conLocal As MySqlConnection = ModuloConexion.ObtenerConexion()
                conLocal.Open()

                Dim table As New DataTable()
                Dim adaptadoListado As New MySqlDataAdapter("SELECT idFactura, codProp, empresa, propietario, nfactura, fecha FROM factura", conLocal)
                adaptadoListado.Fill(table)

                FactDgv.DataSource = table
            End Using

            ListadoD()
        Catch ex As Exception
            MessageBox.Show("Error al cargar datos: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Private Sub ListadoD()
        If FactDgv.Columns.Count < 6 Then Exit Sub

        FactDgv.Columns(0).Visible = False

        FactDgv.Columns(1).HeaderText = "Cod. Prop."
        FactDgv.Columns(1).Width = 70

        FactDgv.Columns(2).HeaderText = "Empresa"
        FactDgv.Columns(2).Width = 155

        FactDgv.Columns(3).HeaderText = "Propietario"
        FactDgv.Columns(3).Width = 155

        FactDgv.Columns(4).HeaderText = "N° Factura"
        FactDgv.Columns(4).Width = 90

        FactDgv.Columns(5).HeaderText = "Fecha"
        FactDgv.Columns(5).Width = 85
        FactDgv.Columns(5).DefaultCellStyle.Format = "dd/MM/yyyy"

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

                        Dim ConteoL As Integer = 0
                        Integer.TryParse(CodproBTb.Text, ConteoL) ' Conteo Lineas, baja automaticamente la lineas de Productos
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
            activarPanel()

            PrintFactura.PrinterSettings.Copies = 2

            ' Mostrar vista previa
            PrintPreviewFactura.Document = PrintFactura
            PrintPreviewFactura.ShowDialog()

            CancelarBtn.Enabled = True
        Catch ex As Exception
            MessageBox.Show("Error en vista previa: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Try
            activarPanel()

            PrintDocumento.PrinterSettings.Copies = 2

            ' Mostrar vista previa
            PrintPreviewDocumento.Document = PrintDocumento
            PrintPreviewDocumento.ShowDialog()

            CancelarBtn.Enabled = True
        Catch ex As Exception
            MessageBox.Show("Error en vista previa: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub CancelarBtn_Click(sender As Object, e As EventArgs) Handles CancelarBtn.Click
        Me.PreviaBtn.Enabled = False
        NuevoBtn.Enabled = True
        GuardarBtn.Enabled = False
        GuardarBtn.Visible = True
        ModificarBtn.Enabled = False
        ModificarBtn.Visible = False
        desactivarPanel()
        CancelarBtn.Enabled = False
        FactDgv.Enabled = True
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


    Public Sub seleccion()
        Try
            Dim lista As Integer = 0

            If CodBusqTB.Text <> "" Then
                Using conLocal As MySqlConnection = ModuloConexion.ObtenerConexion()
                    conLocal.Open()
                    Dim cmd As New MySqlCommand("SELECT * FROM propietario WHERE codProp = @codProp", conLocal)
                    cmd.Parameters.AddWithValue("@codProp", CodBusqTB.Text)
                    adaptador = New MySqlDataAdapter(cmd)
                    datos = New DataSet
                    adaptador.Fill(datos, "propietario")
                    lista = datos.Tables("propietario").Rows.Count
                End Using
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
                Using conLocal As MySqlConnection = ModuloConexion.ObtenerConexion()
                    conLocal.Open()
                    Dim cmd As New MySqlCommand("SELECT * FROM factura WHERE codProp = @codProp", conLocal)
                    cmd.Parameters.AddWithValue("@codProp", propBusqTB.Text)
                    adaptador = New MySqlDataAdapter(cmd)
                    datos = New DataSet
                    adaptador.Fill(datos, "factura")
                    lista = datos.Tables("factura").Rows.Count
                End Using
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
                Using conLocal As MySqlConnection = ModuloConexion.ObtenerConexion()
                    conLocal.Open()
                    Using cmd As New MySqlCommand("SELECT * FROM factura WHERE idFactura = @idFactura", conLocal)
                        cmd.Parameters.AddWithValue("@idFactura", propBusqTB.Text)
                        adaptador = New MySqlDataAdapter(cmd)
                        datos = New DataSet
                        adaptador.Fill(datos, "factura")
                        lista = datos.Tables("factura").Rows.Count
                    End Using
                End Using
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
        comenta2Tb.Text = datos.Tables("factura").Rows(0).Item("comentario2").ToString
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
            Using conLocal As MySqlConnection = ModuloConexion.ObtenerConexion()
                conLocal.Open()

                Dim table As New DataTable()
                Using cmd As New MySqlCommand("SELECT idFactura, codProp, empresa, propietario, nfactura, fecha FROM factura WHERE codProp LIKE @codProp", conLocal)
                    cmd.Parameters.AddWithValue("@codProp", "%" & CodproBTb.Text & "%")
                    Dim adaptadoListado As New MySqlDataAdapter(cmd)
                    adaptadoListado.Fill(table)
                End Using

                FactDgv.DataSource = table
            End Using

            ListadoD()

        Catch ex As Exception
            MessageBox.Show("Error en búsqueda: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
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

    Private Sub CamDgv_Click(sender As Object, e As EventArgs) Handles FactDgv.Click
        Try
            If Me.FactDgv.RowCount = 0 Then
                MessageBox.Show("No hay datos a mostrar")
                Exit Sub
            End If

            If Me.FactDgv.CurrentRow Is Nothing Then Exit Sub

            Dim cellValue = Me.FactDgv.Item(0, Me.FactDgv.CurrentRow.Index).Value
            If cellValue Is Nothing OrElse IsDBNull(cellValue) Then Exit Sub

            Dim idcod As Integer = Convert.ToInt32(cellValue)

            limpiar()

            propBusqTB.Text = idcod.ToString()
            buscartxt.Text = idcod.ToString()
            seleccion3()

            ' Habilitar panel y botones para editar el registro seleccionado
            activarPanel()
            FactDgv.Enabled = True
            EditarBtn.Enabled = Not ModuloConexion.EsSoloLectura()
            EliminarBtn.Enabled = Not ModuloConexion.EsSoloLectura()
            PreviaBtn.Enabled = True
            CancelarBtn.Enabled = Not ModuloConexion.EsSoloLectura()
            ModificarBtn.Enabled = True
            ModificarBtn.Visible = True
            GuardarBtn.Enabled = False
            GuardarBtn.Visible = False
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
        desactivarPanel()
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
            comenta2Tb.Text = Clipboard.GetText()
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

    Private Sub PrintDocumento_PrintPage(sender As Object, e As PrintPageEventArgs) Handles PrintDocumento.PrintPage
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

                        Dim ConteoL As Integer = 0
                        Integer.TryParse(CodproBTb.Text, ConteoL) ' Conteo Lineas, baja automaticamente la lineas de Productos
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

                            e.Graphics.DrawString("TIPO FACTURA:" & tipoPagTb.Text, GFont, Brushes.Black, 10, 205)
                            e.Graphics.DrawString("FACTURA N°: " & ochoDigP & nFacTb.Text, BIGFont3, Brushes.Black, 10, 220)

                            e.Graphics.DrawString("EMPRESA: " & empTb.Text, DFont, Brushes.Black, 10, 250)
                            e.Graphics.DrawString("PROPIETARIO: " & propTb.Text, DFont, Brushes.Black, 10, 270)
                            e.Graphics.DrawString("RTN: " & rtnTb.Text, DFont, Brushes.Black, 10, 290)

                            e.Graphics.DrawString("PERIODO:  " & perMesCB.Text & " - " & perSemCB.Text, DFont, Brushes.Black, 470, 220)

                            e.Graphics.DrawString("TOTAL: ", BIGFont2, Brushes.Black, 660, 260, format2)
                            e.Graphics.DrawString("L. " & facTotTb.Text, BIGFont2, Brushes.Black, 670, 256)


                            e.Graphics.DrawString("____________________________________________________________________________________________________", DFont, Brushes.Black, 10, 300)
                            e.Graphics.DrawString("Descripción de entrega de combustible", DFont, Brushes.Black, 10, 320)

                            Dim xRect As New Rectangle(20, 345, 1020, 680)
                            e.Graphics.DrawString(comenta2Tb.Text, New Font("Arial", 8.5), Brushes.Black, xRect)

                            'e.Graphics.DrawString(comentaTb.Text, DFont, Brushes.Black, 10, 525)


                            'e.Graphics.DrawString("Registro SAG: N/A Nº Orden Exenta: N/A Nº Registro exonerado: N/A ", nFont, Brushes.Black, 10, 800)
                            'e.Graphics.DrawString(pLetras.Text, nFont, Brushes.Black, 10, 770)

                            'e.Graphics.DrawString("Exento: ", DFont, Brushes.Black, 650, 800, format2)
                            'e.Graphics.DrawString("L. " & facTotTb.Text, DFont, Brushes.Black, 660, 787)

                            'e.Graphics.DrawString("Exonerado: ", DFont, Brushes.Black, 650, 820, format2)
                            'e.Graphics.DrawString("L. " & "0.00 ", DFont, Brushes.Black, 660, 807)

                            'e.Graphics.DrawString("Gravado al 15%: ", DFont, Brushes.Black, 650, 840, format2)
                            'e.Graphics.DrawString("L. " & "0.00 ", DFont, Brushes.Black, 660, 827)

                            'e.Graphics.DrawString("Gravado al 18%: ", DFont, Brushes.Black, 650, 860, format2)
                            'e.Graphics.DrawString("L. " & "0.00 ", DFont, Brushes.Black, 660, 847)

                            'e.Graphics.DrawString("ISV 15%: ", DFont, Brushes.Black, 650, 880, format2)
                            'e.Graphics.DrawString("L. " & "0.00 ", DFont, Brushes.Black, 660, 867)

                            'e.Graphics.DrawString("ISV 18%: ", DFont, Brushes.Black, 650, 900, format2)
                            'e.Graphics.DrawString("L. " & "0.00 ", DFont, Brushes.Black, 660, 887)



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

    ' ==================== REPORTE DE COMPROBANTES ====================

    Private Sub cargarDatosReporte()
        Try
            Dim sql As New StringBuilder()
            sql.Append("SELECT DATE_FORMAT(fecha, '%d/%m/%Y') AS 'Fecha', ")
            sql.Append("placaCbz AS 'Placa', nConte AS 'Contenedor', galDesp AS 'Galones', ")
            sql.Append("total AS 'Total', codiProp AS 'Cod. Cliente', nBoleta AS 'Boletas', ")
            sql.Append("periodo AS 'Periodo', semana AS 'Semana', valor AS 'Valor' ")
            sql.Append("FROM comprobante WHERE (anulado = 0 OR anulado IS NULL) ")

            Using conLocal As MySqlConnection = ModuloConexion.ObtenerConexion()
                conLocal.Open()
                Using cmd As New MySqlCommand()
                    cmd.Connection = conLocal

                    If chkUsarFechaR.Checked Then
                        sql.Append("AND fecha >= @fechaDesde AND fecha <= @fechaHasta ")
                        cmd.Parameters.AddWithValue("@fechaDesde", fechaDesdeRPk.Value.Date)
                        cmd.Parameters.AddWithValue("@fechaHasta", fechaHastaRPk.Value.Date)
                    End If

                    If codClienteRTb.Text.Trim() <> "" Then
                        sql.Append("AND codiProp LIKE @codCliente ")
                        cmd.Parameters.AddWithValue("@codCliente", "%" & codClienteRTb.Text.Trim() & "%")
                    End If

                    If placaRTb.Text.Trim() <> "" Then
                        sql.Append("AND placaCbz LIKE @placa ")
                        cmd.Parameters.AddWithValue("@placa", "%" & placaRTb.Text.Trim() & "%")
                    End If

                    If boletaRTb.Text.Trim() <> "" Then
                        sql.Append("AND nBoleta LIKE @boleta ")
                        cmd.Parameters.AddWithValue("@boleta", "%" & boletaRTb.Text.Trim() & "%")
                    End If

                    sql.Append("ORDER BY fecha DESC, nBoleta ASC")
                    cmd.CommandText = sql.ToString()

                    Dim adapter As New MySqlDataAdapter(cmd)
                    Dim dt As New DataTable()
                    adapter.Fill(dt)

                    Dim registrosReales As Integer = dt.Rows.Count
                    dt = agregarSubtotalesReporte(dt)

                    reporteDGV.DataSource = dt
                    lblTotalR.Text = "Total registros: " & registrosReales.ToString()
                    configurarColumnasReporte()
                End Using
            End Using

        Catch ex As Exception
            MessageBox.Show("Error al cargar datos del reporte: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub configurarColumnasReporte()
        If reporteDGV.Columns.Count > 0 Then
            reporteDGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None
            reporteDGV.Columns("Fecha").Width = 80
            reporteDGV.Columns("Placa").Width = 80
            reporteDGV.Columns("Contenedor").Width = 90
            reporteDGV.Columns("Galones").Width = 70
            reporteDGV.Columns("Total").Width = 75
            reporteDGV.Columns("Cod. Cliente").Width = 80
            reporteDGV.Columns("Boletas").Width = 60
            reporteDGV.Columns("Periodo").Width = 55
            reporteDGV.Columns("Semana").Width = 55
            reporteDGV.Columns("Valor").Width = 70

            reporteDGV.Columns("Galones").DefaultCellStyle.Format = "N2"
            reporteDGV.Columns("Total").DefaultCellStyle.Format = "N2"
            reporteDGV.Columns("Valor").DefaultCellStyle.Format = "N2"

            reporteDGV.Columns("Galones").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            reporteDGV.Columns("Total").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            reporteDGV.Columns("Valor").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            reporteDGV.Columns("Boletas").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            reporteDGV.Columns("Periodo").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            reporteDGV.Columns("Semana").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            reporteDGV.Columns("Fecha").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            If reporteDGV.Columns.Contains("EsSubtotal") Then
                reporteDGV.Columns("EsSubtotal").Visible = False
            End If
            If reporteDGV.Columns.Contains("GrupoColor") Then
                reporteDGV.Columns("GrupoColor").Visible = False
            End If
        End If
    End Sub

    Private Function agregarSubtotalesReporte(dt As DataTable) As DataTable
        If dt.Rows.Count = 0 Then Return dt

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

        dt.DefaultView.Sort = "Cod. Cliente ASC"
        Dim dtSorted As DataTable = dt.DefaultView.ToTable()
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

            If cliente <> currentCliente AndAlso currentCliente <> "" Then
                Dim subRow As DataRow = dtResult.NewRow()
                For Each col As DataColumn In dtResult.Columns
                    subRow(col) = DBNull.Value
                Next
                subRow("Galones") = sumaGalones
                subRow("Total") = sumaTotal
                subRow("EsSubtotal") = True
                subRow("GrupoColor") = grupoIndex Mod 3
                dtResult.Rows.Add(subRow)
                sumaGalones = 0
                sumaTotal = 0
            End If

            If cliente <> currentCliente Then
                grupoIndex += 1
            End If

            dtResult.ImportRow(row)
            dtResult.Rows(dtResult.Rows.Count - 1)("GrupoColor") = grupoIndex Mod 3
            currentCliente = cliente

            Dim gal As Double = 0
            Dim tot As Double = 0
            If row("Galones") IsNot DBNull.Value Then Double.TryParse(row("Galones").ToString(), gal)
            If row("Total") IsNot DBNull.Value Then Double.TryParse(row("Total").ToString(), tot)
            sumaGalones += gal
            sumaTotal += tot
            granTotalGalones += gal
            granTotalTotal += tot
        Next

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

    Private Sub reporteDGV_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles reporteDGV.CellFormatting
        If e.RowIndex < 0 Then Return
        Dim dgv As DataGridView = CType(sender, DataGridView)
        If Not dgv.Columns.Contains("GrupoColor") Then Return

        Dim grupoVal As Object = dgv.Rows(e.RowIndex).Cells("GrupoColor").Value
        If grupoVal Is Nothing OrElse grupoVal Is DBNull.Value Then Return
        Dim grupoColor As Integer = CInt(grupoVal)

        Dim esSubtotal As Object = dgv.Rows(e.RowIndex).Cells("EsSubtotal").Value
        Dim esSub As Boolean = (esSubtotal IsNot Nothing AndAlso esSubtotal IsNot DBNull.Value AndAlso CBool(esSubtotal))

        If grupoColor = -1 Then
            e.CellStyle.BackColor = Color.FromArgb(255, 183, 77)
            e.CellStyle.ForeColor = Color.Black
            e.CellStyle.Font = New Font(dgv.Font, FontStyle.Bold)
        ElseIf esSub Then
            e.CellStyle.BackColor = coloresIntensos(grupoColor)
            e.CellStyle.ForeColor = coloresTextoSub(grupoColor)
            e.CellStyle.Font = New Font(dgv.Font, FontStyle.Bold)
        Else
            e.CellStyle.BackColor = coloresSuaves(grupoColor)
        End If
    End Sub

    Private Sub reporteDGV_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles reporteDGV.CellClick
        Try
            If e.RowIndex < 0 Then Return
            If reporteDGV.RowCount = 0 Then Return

            ' Ignorar filas de subtotal/gran total
            If reporteDGV.Columns.Contains("EsSubtotal") Then
                Dim esSubVal As Object = reporteDGV.Rows(e.RowIndex).Cells("EsSubtotal").Value
                If esSubVal IsNot Nothing AndAlso esSubVal IsNot DBNull.Value AndAlso CBool(esSubVal) Then
                    Return
                End If
            End If

            ' Obtener Cod. Cliente de la fila seleccionada
            Dim codCliente As String = ""
            If reporteDGV.Columns.Contains("Cod. Cliente") Then
                Dim val As Object = reporteDGV.Rows(e.RowIndex).Cells("Cod. Cliente").Value
                If val IsNot Nothing AndAlso val IsNot DBNull.Value Then
                    codCliente = val.ToString().Trim()
                End If
            End If

            If codCliente = "" Then Return

            ' Buscar en tabla propietario con ese código
            Using conLocal As MySqlConnection = ModuloConexion.ObtenerConexion()
                conLocal.Open()
                Using cmd As New MySqlCommand("SELECT codProp, nPropietario, nEmpresa, RTN FROM propietario WHERE codProp = @codProp", conLocal)
                    cmd.Parameters.AddWithValue("@codProp", codCliente)
                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        If reader.Read() Then
                            CodBusqTB.Text = reader("codProp").ToString()
                            codPropTb.Text = reader("codProp").ToString()
                            propTb.Text = reader("nPropietario").ToString()
                            empTb.Text = reader("nEmpresa").ToString()
                            rtnTb.Text = reader("RTN").ToString()
                        Else
                            MessageBox.Show("No se encontró propietario con código: " & codCliente, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If
                    End Using
                End Using
            End Using

            ' Llenar periodo y semana desde la fila del reporte
            Dim row As DataGridViewRow = reporteDGV.Rows(e.RowIndex)
            If reporteDGV.Columns.Contains("Periodo") Then
                Dim periodoVal As Object = row.Cells("Periodo").Value
                If periodoVal IsNot Nothing AndAlso periodoVal IsNot DBNull.Value Then
                    perMesCB.Text = periodoVal.ToString()
                End If
            End If
            If reporteDGV.Columns.Contains("Semana") Then
                Dim semanaVal As Object = row.Cells("Semana").Value
                If semanaVal IsNot Nothing AndAlso semanaVal IsNot DBNull.Value Then
                    perSemCB.Text = semanaVal.ToString()
                End If
            End If

            ' Llenar galones y total
            If reporteDGV.Columns.Contains("Galones") Then
                Dim galVal As Object = row.Cells("Galones").Value
                If galVal IsNot Nothing AndAlso galVal IsNot DBNull.Value Then
                    cant1Tb.Text = galVal.ToString()
                End If
            End If
            If reporteDGV.Columns.Contains("Total") Then
                Dim totVal As Object = row.Cells("Total").Value
                If totVal IsNot Nothing AndAlso totVal IsNot DBNull.Value Then
                    preUni1Tb.Text = totVal.ToString()
                End If
            End If

            ' Llenar comenta2Tb con todas las lineas del mismo propietario (sin subtotales)
            Dim sb As New StringBuilder()
            For Each dgvRow As DataGridViewRow In reporteDGV.Rows
                If dgvRow.IsNewRow Then Continue For

                ' Saltar subtotales/gran total
                If reporteDGV.Columns.Contains("EsSubtotal") Then
                    Dim esSubR As Object = dgvRow.Cells("EsSubtotal").Value
                    If esSubR IsNot Nothing AndAlso esSubR IsNot DBNull.Value AndAlso CBool(esSubR) Then
                        Continue For
                    End If
                End If

                ' Solo filas del mismo Cod. Cliente
                Dim codR As String = ""
                If dgvRow.Cells("Cod. Cliente").Value IsNot Nothing AndAlso dgvRow.Cells("Cod. Cliente").Value IsNot DBNull.Value Then
                    codR = dgvRow.Cells("Cod. Cliente").Value.ToString().Trim()
                End If

                If codR = codCliente Then
                    Dim fecha As String = If(dgvRow.Cells("Fecha").Value IsNot Nothing, dgvRow.Cells("Fecha").Value.ToString(), "")
                    Dim placa As String = If(dgvRow.Cells("Placa").Value IsNot Nothing, dgvRow.Cells("Placa").Value.ToString(), "")
                    Dim boleta As String = If(dgvRow.Cells("Boletas").Value IsNot Nothing, dgvRow.Cells("Boletas").Value.ToString(), "")

                    Dim galDbl As Double = 0
                    If dgvRow.Cells("Galones").Value IsNot Nothing AndAlso dgvRow.Cells("Galones").Value IsNot DBNull.Value Then
                        Double.TryParse(dgvRow.Cells("Galones").Value.ToString(), galDbl)
                    End If
                    Dim totDbl As Double = 0
                    If dgvRow.Cells("Total").Value IsNot Nothing AndAlso dgvRow.Cells("Total").Value IsNot DBNull.Value Then
                        Double.TryParse(dgvRow.Cells("Total").Value.ToString(), totDbl)
                    End If
                    Dim valDbl As Double = 0
                    If dgvRow.Cells("Valor").Value IsNot Nothing AndAlso dgvRow.Cells("Valor").Value IsNot DBNull.Value Then
                        Double.TryParse(dgvRow.Cells("Valor").Value.ToString(), valDbl)
                    End If

                    sb.AppendLine(fecha & vbTab & placa.PadRight(10) & vbTab & "Bol:" & boleta.PadRight(8) & vbTab & "Gal:" & galDbl.ToString("N2").PadLeft(8) & vbTab & "Tot:" & totDbl.ToString("N2").PadLeft(10) & vbTab & "Val:" & valDbl.ToString("N2").PadLeft(7))
                End If
            Next
            comenta2Tb.Text = sb.ToString().TrimEnd()

        Catch ex As Exception
            MessageBox.Show("Error al seleccionar del reporte: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub buscarRBtn_Click(sender As Object, e As EventArgs) Handles buscarRBtn.Click
        cargarDatosReporte()
    End Sub

    Private Sub ordenarRBtn_Click(sender As Object, e As EventArgs) Handles ordenarRBtn.Click
        If reporteDGV.DataSource IsNot Nothing Then
            Dim dt As DataTable = CType(reporteDGV.DataSource, DataTable)

            Dim dtSinSub As DataTable = dt.Clone()
            For Each row As DataRow In dt.Rows
                If row("EsSubtotal") IsNot DBNull.Value AndAlso CBool(row("EsSubtotal")) = False Then
                    dtSinSub.ImportRow(row)
                End If
            Next

            dtSinSub.Columns.Remove("EsSubtotal")
            dtSinSub.Columns.Remove("GrupoColor")

            Dim dtConSub As DataTable = agregarSubtotalesReporte(dtSinSub)
            reporteDGV.DataSource = dtConSub
            configurarColumnasReporte()
        End If
    End Sub

    Private Sub limpiarRBtn_Click(sender As Object, e As EventArgs) Handles limpiarRBtn.Click
        chkUsarFechaR.Checked = False
        fechaDesdeRPk.Value = DateTime.Today
        fechaHastaRPk.Value = DateTime.Today
        codClienteRTb.Text = ""
        placaRTb.Text = ""
        boletaRTb.Text = ""
        cargarDatosReporte()
    End Sub

    Private Sub chkUsarFechaR_CheckedChanged(sender As Object, e As EventArgs) Handles chkUsarFechaR.CheckedChanged
        fechaDesdeRPk.Enabled = chkUsarFechaR.Checked
        fechaHastaRPk.Enabled = chkUsarFechaR.Checked
    End Sub

    Private Sub exportarRBtn_Click(sender As Object, e As EventArgs) Handles exportarRBtn.Click
        If reporteDGV.Rows.Count = 0 Then
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
                        ExportarCSVReporte(saveDialog.FileName)
                    Else
                        ExportarExcelReporte(saveDialog.FileName)
                    End If

                    MessageBox.Show("Archivo exportado correctamente:" & vbCrLf & saveDialog.FileName, "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information)

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

    Private Sub ExportarCSVReporte(rutaArchivo As String)
        Dim sb As New StringBuilder()

        Dim headers As New List(Of String)
        For Each col As DataGridViewColumn In reporteDGV.Columns
            If col.Visible Then
                headers.Add("""" & col.HeaderText & """")
            End If
        Next
        sb.AppendLine(String.Join(",", headers))

        For Each row As DataGridViewRow In reporteDGV.Rows
            If Not row.IsNewRow Then
                Dim valores As New List(Of String)
                For Each cell As DataGridViewCell In row.Cells
                    If reporteDGV.Columns(cell.ColumnIndex).Visible Then
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

    Private Sub ExportarExcelReporte(rutaArchivo As String)
        Using workbook As New XLWorkbook()
            Dim ws As IXLWorksheet = workbook.Worksheets.Add("Facturas")

            Dim colsVisibles As New List(Of Integer)
            For col As Integer = 0 To reporteDGV.Columns.Count - 1
                If reporteDGV.Columns(col).Visible Then
                    colsVisibles.Add(col)
                End If
            Next
            Dim numColsVisibles As Integer = colsVisibles.Count

            ' Titulo
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

            ' Filtros
            Dim infoFila As Integer = 2
            Dim filtrosAplicados As String = "Filtros: "
            If chkUsarFechaR.Checked Then
                filtrosAplicados &= "Fecha " & fechaDesdeRPk.Value.ToString("dd/MM/yyyy") & " - " & fechaHastaRPk.Value.ToString("dd/MM/yyyy") & " | "
            End If
            If codClienteRTb.Text.Trim() <> "" Then
                filtrosAplicados &= "Cod. Cliente: " & codClienteRTb.Text.Trim() & " | "
            End If
            If placaRTb.Text.Trim() <> "" Then
                filtrosAplicados &= "Placa: " & placaRTb.Text.Trim() & " | "
            End If
            If boletaRTb.Text.Trim() <> "" Then
                filtrosAplicados &= "Boleta: " & boletaRTb.Text.Trim() & " | "
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

            infoFila += 1
            ws.Cell(infoFila, 1).SetValue("Generado: " & DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"))
            ws.Range(infoFila, 1, infoFila, numColsVisibles).Merge()
            With ws.Cell(infoFila, 1).Style
                .Font.Italic = True
                .Font.FontSize = 10
                .Font.FontColor = XLColor.DarkGray
            End With

            ' Encabezados
            Dim headerRow As Integer = infoFila + 2
            Dim excelColH As Integer = 1
            For Each col As Integer In colsVisibles
                Dim cell As IXLCell = ws.Cell(headerRow, excelColH)
                cell.SetValue(reporteDGV.Columns(col).HeaderText)
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

            ' Datos
            Dim exColoresSuaves() As String = {"#FFF3E0", "#E3F2FD", "#E8F5E9"}
            Dim exColoresIntensos() As String = {"#FFE0B2", "#BBDEFB", "#C8E6C9"}
            Dim exColoresBorde() As String = {"#E0A040", "#64B5F6", "#66BB6A"}

            Dim dataRowStart As Integer = headerRow + 1
            Dim totalGalones As Double = 0
            Dim totalValor As Double = 0
            Dim excelRowActual As Integer = dataRowStart

            For row As Integer = 0 To reporteDGV.Rows.Count - 1
                If Not reporteDGV.Rows(row).IsNewRow Then
                    Dim esSubtotal As Boolean = False
                    Dim grupoColor As Integer = 0
                    If reporteDGV.Columns.Contains("EsSubtotal") Then
                        Dim subVal As Object = reporteDGV.Rows(row).Cells("EsSubtotal").Value
                        If subVal IsNot Nothing AndAlso subVal IsNot DBNull.Value Then
                            esSubtotal = CBool(subVal)
                        End If
                    End If
                    If reporteDGV.Columns.Contains("GrupoColor") Then
                        Dim grpVal As Object = reporteDGV.Rows(row).Cells("GrupoColor").Value
                        If grpVal IsNot Nothing AndAlso grpVal IsNot DBNull.Value Then
                            grupoColor = CInt(grpVal)
                        End If
                    End If
                    Dim esGranTotal As Boolean = (grupoColor = -1)

                    Dim excelCol As Integer = 1
                    For Each col As Integer In colsVisibles
                        Dim cell As IXLCell = ws.Cell(excelRowActual, excelCol)
                        Dim valor As Object = reporteDGV.Rows(row).Cells(col).Value
                        Dim headerName As String = reporteDGV.Columns(col).HeaderText

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
                            ElseIf headerName = "Boletas" OrElse headerName = "Periodo" OrElse headerName = "Semana" Then
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

                            If headerName = "Galones" OrElse headerName = "Total" OrElse headerName = "Valor" OrElse headerName = "Boletas" OrElse headerName = "Periodo" OrElse headerName = "Semana" Then
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

            ' Resumen
            Dim summaryRow As Integer = excelRowActual + 1
            ws.Cell(summaryRow, 1).SetValue("RESUMEN")
            With ws.Cell(summaryRow, 1).Style
                .Font.Bold = True
                .Font.FontSize = 12
                .Fill.BackgroundColor = XLColor.FromHtml("#6A7EA8")
                .Font.FontColor = XLColor.White
            End With
            ws.Range(summaryRow, 1, summaryRow, 4).Merge()

            If codClienteRTb.Text.Trim() <> "" Then
                summaryRow += 1
                ws.Cell(summaryRow, 1).SetValue("Cod. Cliente:")
                ws.Cell(summaryRow, 2).SetValue(codClienteRTb.Text.Trim())
                ws.Cell(summaryRow, 1).Style.Font.Bold = True
                ws.Cell(summaryRow, 2).Style.Font.FontColor = XLColor.FromHtml("#2E86AB")
            End If

            If placaRTb.Text.Trim() <> "" Then
                summaryRow += 1
                ws.Cell(summaryRow, 1).SetValue("Placa:")
                ws.Cell(summaryRow, 2).SetValue(placaRTb.Text.Trim())
                ws.Cell(summaryRow, 1).Style.Font.Bold = True
            End If

            If boletaRTb.Text.Trim() <> "" Then
                summaryRow += 1
                ws.Cell(summaryRow, 1).SetValue("Boleta:")
                ws.Cell(summaryRow, 2).SetValue(boletaRTb.Text.Trim())
                ws.Cell(summaryRow, 1).Style.Font.Bold = True
            End If

            If chkUsarFechaR.Checked Then
                summaryRow += 1
                ws.Cell(summaryRow, 1).SetValue("Fecha Desde:")
                ws.Cell(summaryRow, 2).SetValue(fechaDesdeRPk.Value.ToString("dd/MM/yyyy"))
                ws.Cell(summaryRow, 1).Style.Font.Bold = True

                summaryRow += 1
                ws.Cell(summaryRow, 1).SetValue("Fecha Hasta:")
                ws.Cell(summaryRow, 2).SetValue(fechaHastaRPk.Value.ToString("dd/MM/yyyy"))
                ws.Cell(summaryRow, 1).Style.Font.Bold = True
            End If

            summaryRow += 2
            ws.Cell(summaryRow, 1).SetValue("Total Registros:")
            Dim registrosRealesExcel As Integer = 0
            For Each dgvRow As DataGridViewRow In reporteDGV.Rows
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

            ws.Columns().AdjustToContents()
            For col As Integer = 1 To numColsVisibles
                If ws.Column(col).Width < 10 Then
                    ws.Column(col).Width = 10
                ElseIf ws.Column(col).Width > 40 Then
                    ws.Column(col).Width = 40
                End If
            Next

            ws.PageSetup.PageOrientation = XLPageOrientation.Landscape
            ws.PageSetup.FitToPages(1, 0)

            workbook.SaveAs(rutaArchivo)
        End Using
    End Sub

End Class