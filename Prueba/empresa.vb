Imports System.Data
Imports MySql.Data.MySqlClient
Imports MySql.Data
Public Class empresa
    Dim con As New MySqlConnection
    Dim cm As New MySqlCommand
    Dim guardar As New MySqlCommand
    Dim adaptador As New MySqlDataAdapter
    Dim datos As DataSet
    Dim dr As MySqlDataReader
    Private m_tmr As Timer
    Private isMouseDown As Boolean = False
    Private mouseOffset As Point


    Private Sub empresa_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim colorFondo = Color.FromArgb(106, 126, 168)
        Dim colorTextbox = Color.FromArgb(240, 210, 249)

        conectar()
        act()
        'listadoCamDgv()
        'CamDGV.BackgroundColor = colorFondo
        'CamDGV.RowsDefaultCellStyle.BackColor = Color.Bisque
        'CamDGV.AlternatingRowsDefaultCellStyle.BackColor = Color.Lavender
        seleccion()
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
        'Me.EditarBtn.Enabled = False
        Me.GuardarBtn.Enabled = False
        Me.ModificarBtn.Enabled = False
        Me.CancelarBtn.Enabled = False
        Me.EliminarBtn.Enabled = False
    End Sub
    Sub limpiar()
        Me.nEmpreTb.Text = ""
        Me.nPropieTb.Text = ""
        Me.dire1Tb.Text = ""
        Me.dire2Tb.Text = ""
        Me.dire3Tb.Text = ""
        Me.localTb.Text = ""
        Me.rtnTb.Text = ""
        Me.correoETb.Text = ""
        Me.caiTb.Text = ""
        Me.tel1Tb.Text = ""
        Me.cel2Tb.Text = ""
        Me.ochodigTb.Text = ""
        Me.rangoIniTb.Text = ""
        Me.rangoFinTb.Text = ""
        Me.fechaLimitTb.Text = ""
        Me.otros1Tb.Text = ""
        Me.otros2Tb.Text = ""
    End Sub
    Private Sub NuevoBtn_Click(sender As Object, e As EventArgs) Handles NuevoBtn.Click '============  NUEVO  ===========
        limpiar()
        PanelP.Enabled = True
        GuardarBtn.Enabled = True
        CancelarBtn.Enabled = True
    End Sub

    Private Sub EditarBtn_Click(sender As Object, e As EventArgs) Handles EditarBtn.Click '============  EDITAR  ===========
        PanelP.Enabled = True

        Me.GuardarBtn.Enabled = False
        Me.GuardarBtn.Visible = False
        Me.ModificarBtn.Enabled = True
        Me.EditarBtn.Enabled = False
        Me.CancelarBtn.Enabled = True
        Me.NuevoBtn.Enabled = False
        Me.EliminarBtn.Enabled = False
    End Sub

    Private Sub GuardarBtn_Click(sender As Object, e As EventArgs) Handles GuardarBtn.Click '============  GUARDAR  ===========
        con.Close()
        con.Open()
        Try

            guardar = New MySqlCommand("INSERT INTO empresa (nEmpre, nPropie, nombLocal, dire1, dire2, dire3, local, rtn, correoE, cai, tel1, cel2, fax, ochoDig, rangoIni, rangoFin, fechaLimit, otros1, otros2)" & Chr(13) &
            "VALUES(@nEmpre, @nPropie, @nombLocal, @dire1, @dire2, @dire3, @local, @rtn, @correoE, @cai, @tel1, @cel2, @fax, @ochoDig, @rangoIni, @rangoFin, @fechaLimit, @otros1, @otros2)", con)

            guardar.Parameters.AddWithValue("@nEmpre", nEmpreTb.Text)
            guardar.Parameters.AddWithValue("@nPropie", nPropieTb.Text)
            guardar.Parameters.AddWithValue("@nombLocal", nombLocalTb.Text)
            guardar.Parameters.AddWithValue("@dire1", dire1Tb.Text)
            guardar.Parameters.AddWithValue("@dire2", dire2Tb.Text)
            guardar.Parameters.AddWithValue("@dire3", dire3Tb.Text)
            guardar.Parameters.AddWithValue("@local", localTb.Text)
            guardar.Parameters.AddWithValue("@rtn", rtnTb.Text)
            guardar.Parameters.AddWithValue("@correoE", correoETb.Text)
            guardar.Parameters.AddWithValue("@cai", caiTb.Text)
            guardar.Parameters.AddWithValue("@tel1", tel1Tb.Text)
            guardar.Parameters.AddWithValue("@cel2", cel2Tb.Text)
            guardar.Parameters.AddWithValue("@fax", faxTb.Text)
            guardar.Parameters.AddWithValue("@ochoDig", ochodigTb.Text)
            guardar.Parameters.AddWithValue("@rangoIni", rangoIniTb.Text)
            guardar.Parameters.AddWithValue("@rangoFin", rangoFinTb.Text)
            guardar.Parameters.AddWithValue("@fechaLimit", fechaLimitTb.Text)
            guardar.Parameters.AddWithValue("@otros1", otros1Tb.Text)
            guardar.Parameters.AddWithValue("@otros2", otros2Tb.Text)

            guardar.ExecuteNonQuery()
            MsgBox("Registo guardado")

        Catch ex As Exception
            MsgBox("Elemento no pudo se almacenado", ex.StackTrace)
        End Try

        limpiar()

        act()
    End Sub

    Private Sub EliminarBtn_Click(sender As Object, e As EventArgs) Handles EliminarBtn.Click '============  ELIMINAR  ===========
        Try

            Dim opc As DialogResult = MsgBox("¿Desea Eliminar este registro?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Eliminar")
            If opc = Windows.Forms.DialogResult.Yes Then

                Dim eliminar As String

                eliminar = "DELETE FROM empresa WHERE nEmpre = '" & Conversion.Int(Me.nEmpreTb.Text) & "'"
                Dim eli As New MySqlCommand(eliminar, con)
                eli.ExecuteNonQuery()
            End If
        Catch
            MessageBox.Show("Actualización Base de Datos, " & Chr(13) & "favor escoger de nuevo el registro y eliminarlo", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)

        End Try

        act()
    End Sub

    Private Sub CancelarBtn_Click(sender As Object, e As EventArgs) Handles CancelarBtn.Click '============  CANCELAR  ===========
        act()
        PanelP.Enabled = False
        Me.GuardarBtn.Visible = True
    End Sub

    Private Sub ModificarBtn_Click(sender As Object, e As EventArgs) Handles ModificarBtn.Click '============  MODIFICAR  ===========
        actual()
        act()
        PanelP.Enabled = False

        Me.GuardarBtn.Visible = True

    End Sub
    Public Sub actual()
        Dim actualizar As String
        actualizar = "UPDATE empresa SET nEmpre = '" & nEmpreTb.Text & "' ,nPropie = '" & nPropieTb.Text & "' ,nombLocal = '" & nombLocalTb.Text & "' ,dire1 = '" & dire1Tb.Text & "' ,dire2 = '" & dire2Tb.Text & "' ,dire3 = '" & dire3Tb.Text & "' ,local = '" & localTb.Text & "' ,rtn = '" & rtnTb.Text & "' ,correoE = '" & correoETb.Text & "' ,cai = '" & caiTb.Text & "' ,tel1 = '" & tel1Tb.Text & "' ,cel2 = '" & cel2Tb.Text & "' ,fax = '" & faxTb.Text & "' ,ochoDig = '" & ochodigTb.Text & "' ,rangoIni = '" & rangoIniTb.Text & "' ,rangoFin = '" & rangoFinTb.Text & "' ,fechaLimit = '" & fechaLimitTb.Text & "' ,otros1 = '" & otros1Tb.Text & "' ,otros2 = '" & otros2Tb.Text & "'"
        Dim act As New MySqlCommand(actualizar, con)
        act.ExecuteNonQuery()
        MsgBox("Registo Actualizado")
    End Sub
    Public Sub seleccion()
        Dim consulta As String
        Dim lista As Byte


        consulta = "SELECT * FROM empresa LIMIT 0,1"
        adaptador = New MySqlDataAdapter(consulta, con)
            datos = New DataSet
            adaptador.Fill(datos, "empresa")
        lista = datos.Tables("empresa").Rows.Count

        If lista <> 0 Then
            nEmpreTb.Text = datos.Tables("empresa").Rows(0).Item("nEmpre").ToString
            nPropieTb.Text = datos.Tables("empresa").Rows(0).Item("nPropie").ToString
            nombLocalTb.Text = datos.Tables("empresa").Rows(0).Item("nombLocal").ToString
            dire1Tb.Text = datos.Tables("empresa").Rows(0).Item("dire1").ToString
            dire2Tb.Text = datos.Tables("empresa").Rows(0).Item("dire2").ToString
            dire3Tb.Text = datos.Tables("empresa").Rows(0).Item("dire3").ToString
            localTb.Text = datos.Tables("empresa").Rows(0).Item("local").ToString
            rtnTb.Text = datos.Tables("empresa").Rows(0).Item("rtn").ToString
            correoETb.Text = datos.Tables("empresa").Rows(0).Item("correoE").ToString
            caiTb.Text = datos.Tables("empresa").Rows(0).Item("cai").ToString
            tel1Tb.Text = datos.Tables("empresa").Rows(0).Item("tel1").ToString
            cel2Tb.Text = datos.Tables("empresa").Rows(0).Item("cel2").ToString
            faxTb.Text = datos.Tables("empresa").Rows(0).Item("fax").ToString
            ochodigTb.Text = datos.Tables("empresa").Rows(0).Item("ochoDig").ToString
            rangoIniTb.Text = datos.Tables("empresa").Rows(0).Item("rangoIni").ToString
            rangoFinTb.Text = datos.Tables("empresa").Rows(0).Item("rangoFin").ToString
            fechaLimitTb.Text = datos.Tables("empresa").Rows(0).Item("fechaLimit").ToString
            otros1Tb.Text = datos.Tables("empresa").Rows(0).Item("otros1").ToString
            otros2Tb.Text = datos.Tables("empresa").Rows(0).Item("otros2").ToString


        Else
            MsgBox("Datos no encontrados")
        End If
        'listadoCamDgv()
    End Sub
End Class