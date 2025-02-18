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
        'CamDGV.Enabled = False
        CancelarBtn.Enabled = True
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

            guardar = New MySqlCommand("INSERT INTO camiones (nFactura, Fecha, Hora, propietario, Empresa, rtn, tipoPag, facCantidad, facExe, facTotal, comentario, cantd1, cantd2, descrip1, descrip2, total1, total2, perMes, PerSem)" & Chr(13) &
            "VALUES(@nFactura, @Fecha, @Hora, @propietario, @Empresa, @rtn, @tipoPag, @facCantidad, @facExe, @facTotal, @comentario, @cantd1, @cantd2, @descrip1, @descrip2, @total1, @total2, @perMes, @PerSem)", con)

            guardar.Parameters.AddWithValue("@nFactura", nFacTb.Text)
            guardar.Parameters.AddWithValue("@Fecha", fechaPk.Text)
            guardar.Parameters.AddWithValue("@propietario", propTb.Text)
            guardar.Parameters.AddWithValue("@Empresa", empTb.Text)
            guardar.Parameters.AddWithValue("@rtn", rtnTb.Text)
            guardar.Parameters.AddWithValue("@tipoPag", tipoPagTb.Text)
            guardar.Parameters.AddWithValue("@facCantidad", facCanTB.Text)
            guardar.Parameters.AddWithValue("@facExe", facExeTb.Text)
            guardar.Parameters.AddWithValue("@facTotal", facTotTb.Text)
            guardar.Parameters.AddWithValue("@comentario", comentaTb.Text)
            guardar.Parameters.AddWithValue("@cantd1", cant1Tb.Text)
            guardar.Parameters.AddWithValue("@cantd2", cant2Tb.Text)
            guardar.Parameters.AddWithValue("@descrip1", desc1Tb.Text)
            guardar.Parameters.AddWithValue("@descrip2", desc2Tb.Text)
            guardar.Parameters.AddWithValue("@total1", tota1Tb.Text)
            guardar.Parameters.AddWithValue("@total2", tota2Tb.Text)
            guardar.Parameters.AddWithValue("@perMes", perMesCB.Text)
            guardar.Parameters.AddWithValue("@PerSem", perSemCB.Text)


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

                'listadoCamDgv()

            End If
        Catch
            MessageBox.Show("Actualización Base de Datos, " & Chr(13) & "favor escoger de nuevo el registro y eliminarlo", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)

        End Try

        act()
    End Sub
End Class