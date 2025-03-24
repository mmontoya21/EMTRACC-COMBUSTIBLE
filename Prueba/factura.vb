Imports System.Data
Imports MySql.Data.MySqlClient
Imports MySql.Data
Public Class factura
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
    Private Sub factura_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        conectar()
        act()
        'listadoCamDgv()
        'CamDGV.BackgroundColor = colorFondo
        'CamDGV.RowsDefaultCellStyle.BackColor = Color.Bisque
        'CamDGV.AlternatingRowsDefaultCellStyle.BackColor = Color.Lavender

        PanelP.Enabled = False
    End Sub

    Private Sub conectar()
        Dim servidor As String = "localhost"
        Dim baseDatos As String = "givemefuel"
        Dim userid As String = "root"
        Dim clave As String = ""


        'con.ConnectionString = "Server=168.119.90.215; Database=datasafe_eda; Uid=datasafe_edausr; Pwd=@Paradoja18"

        'con.ConnectionString = "Server=185.224.137.172; Database=u282951626_eda; Uid=u282951626_edauser; Pwd=@Paradoja18"

        con.ConnectionString = "Server=" & servidor & "; Database=" & baseDatos & "; Uid = " & userid & "; Pwd = " & clave

        Try

            con.Open()

            MsgBox("La Wea se conectó")

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
    End Sub
    Private Sub NuevoBtn_Click(sender As Object, e As EventArgs) Handles NuevoBtn.Click '============  NUEVO  ===========
        limpiar()
        PanelP.Enabled = True
        GuardarBtn.Enabled = True
        CamDgv.Enabled = False
        CancelarBtn.Enabled = True

        Try

            ' Consulta para obtener el último registro (campo nFactura)
            Dim query As String = "SELECT nFactura FROM factura ORDER BY idFactura DESC LIMIT 1"
            Dim comando As New MySqlCommand(query, con)
            Dim lector As MySqlDataReader = comando.ExecuteReader()

            ' Verificar si hay registros
            If lector.Read() Then
                ' Asignar el valor de nFactura al TextBox
                TextBox1.Text = lector("nFactura").ToString()

                Dim nfacta As Double = Double.Parse(TextBox1.Text)
                nFacTb.Text = nfacta + 1 ' Suma factura
                amplitud()
            Else
                nFacTb.Text = 1
                amplitud()
            End If

            lector.Close()

        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        Finally
            ' Cerrar la conexión
            con.Close()
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

    End Sub

    Private Sub EditarBtn_Click(sender As Object, e As EventArgs) Handles EditarBtn.Click  '============  EDITAR  ===========
        limpiar()
        PanelP.Enabled = True
        GuardarBtn.Enabled = True
        'CamDGV.Enabled = False
        CancelarBtn.Enabled = True
    End Sub

    Private Sub GuardarBtn_Click(sender As Object, e As EventArgs) Handles GuardarBtn.Click '============  GUARDADO  ===========
        con.Close()
        con.Open()
        Try
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

            Dim perMes = Val(perMesCB.Text)

            Dim perSem = Val(perSemCB.Text)

            guardar = New MySqlCommand("INSERT INTO camiones (nFactura, Fecha, Hora, propietario, Empresa, rtn, tipoPag, facCantidad, facExe, facTotal, comentario, cantd1, cantd2, descrip1, descrip2, total1, total2, perMes, PerSem)" & Chr(13) &
            "VALUES(@nFactura, @Fecha, @Hora, @propietario, @Empresa, @rtn, @tipoPag, @facCantidad, @facExe, @facTotal, @comentario, @cantd1, @cantd2, @descrip1, @descrip2, @total1, @total2, @perMes, @PerSem)", con)

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


            guardar.ExecuteNonQuery()
            MsgBox("Registo guardado")

        Catch ex As Exception
            MsgBox("Elemento no pudo se almacenado", ex.StackTrace)
        End Try

        limpiar()

        act()

        ' CamDGV.Enabled = True
        ' listadoCamDgv()

        'articulosPanel.Enabled = False
        'ItemDgv.Enabled = True
        'Me.GuardarBtn.Visible = True
    End Sub

    Private Sub ModificarBtn_Click(sender As Object, e As EventArgs) Handles ModificarBtn.Click '============  MODIFICAR  ===========
        actual()
        act()
        PanelP.Enabled = False
        'CamDGV.Enabled = True
        Me.GuardarBtn.Visible = True
        'listadoCamDgv()
    End Sub
    Public Sub actual()
        Dim actualizar As String
        actualizar = "UPDATE factura SET nFactura = '" & nFacTb.Text & "', propietario = '" & propTb.Text & "', Empresa = '" & empTb.Text & "', rtn = '" & rtnTb.Text & "', tipoPag = '" & tipoPagTb.Text & "', facCantidad = '" & facCanTB.Text & "', facExe = '" & facExeTb.Text & "', facTotal = '" & facTotTb.Text & "', comentario = '" & comentaTb.Text & "', cantd1 = '" & cant1Tb.Text & "', cantd2 = '" & cant2Tb.Text & "', descrip1 = '" & desc1Tb.Text & "', descrip2 = '" & desc2Tb.Text & "', total1 = '" & tota1Tb.Text & "', total2 = '" & tota2Tb.Text & "', perMes = '" & perMesCB.Text & "', PerSem = '" & perSemCB.Text & "'"

        Dim act As New MySqlCommand(actualizar, con)
        act.ExecuteNonQuery()
        MsgBox("Registo Actualizado")
    End Sub

    Private Sub EliminarBtn_Click(sender As Object, e As EventArgs) Handles EliminarBtn.Click '============  ELIMINAR  ===========
        Try

            Dim opc As DialogResult = MsgBox("¿Desea Eliminar este registro?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Eliminar")
            If opc = Windows.Forms.DialogResult.Yes Then

                Dim eliminar As String

                eliminar = "DELETE FROM factura WHERE idCamiones = '" & Conversion.Int(Me.buscartxt.Text) & "'"
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
        Dim adaptadoListado As New MySqlDataAdapter("SELECT idCamiones, placa, propietario, documentos, revision, contrato, codProp FROM camiones", con)
        adaptadoListado.Fill(table)

        CamDGV.DataSource = table

        ListadoD()

    End Sub
    Private Sub ListadoD()
        CamDGV.Columns(0).HeaderText = "Id"
        CamDGV.Columns(0).Width = 1

        CamDGV.Columns(1).HeaderText = "Placa"
        CamDGV.Columns(1).Width = 100

        CamDGV.Columns(2).HeaderText = "Propietario"
        CamDGV.Columns(2).Width = 175

        CamDGV.Columns(3).HeaderText = "Documentos"
        CamDGV.Columns(3).Width = 75

        CamDGV.Columns(4).HeaderText = "Revision"
        CamDGV.Columns(4).Width = 50

        CamDGV.Columns(5).HeaderText = "Contrato"
        CamDGV.Columns(5).Width = 175

        CamDGV.Columns(6).HeaderText = "Código Propietario"
        CamDGV.Columns(6).Width = 90
    End Sub
    Private Sub calcularletras()  '============  CALCULO DE LETRAS   =============
        pLetras.Text = ""
        If IsNumeric(facTotTb.Text) Then
            pLetras.Text = LETRAS(facTotTb.Text)
            ' Else
            '     MessageBox.Show("Ingrese por favor números", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
        facTotTb.Focus()
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

    Private Sub ButtonX5_Click(sender As Object, e As EventArgs) Handles ButtonX5.Click
        calcularletras
    End Sub

    Private Sub PrintFactura_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles PrintFactura.PrintPage

    End Sub

    Private Sub facTotTb_TextChanged(sender As Object, e As EventArgs) Handles facTotTb.TextChanged
        calcularletras()
    End Sub
End Class