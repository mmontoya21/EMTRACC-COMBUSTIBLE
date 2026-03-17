Imports System.Data
Imports MySql.Data.MySqlClient
Imports MySql.Data
Public Class empresa
    Dim adaptador As New MySqlDataAdapter
    Dim datos As DataSet


    Private Sub empresa_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        EstilizarFormulario()
        act()
        seleccion()
        HabilitarTextBoxes(False)
    End Sub

    Private Sub EstilizarFormulario()
        ' === Colores base ===
        Dim fondoForm As Color = Color.FromArgb(15, 22, 40)
        Dim fondoPanel As Color = Color.FromArgb(20, 30, 48)
        Dim fondoTextbox As Color = Color.FromArgb(40, 75, 130)
        Dim colorTexto As Color = Color.FromArgb(200, 215, 240)
        Dim colorLabel As Color = Color.FromArgb(180, 210, 255)
        Dim colorBorde As Color = Color.FromArgb(100, 160, 230)
        Dim colorLinea As Color = Color.FromArgb(50, 100, 180)
        Dim colorFocus As Color = Color.FromArgb(70, 130, 200)

        ' === Formulario ===
        Me.BackColor = fondoForm
        Me.Text = "EMTRACC - Datos de Empresa"
        Me.FormBorderStyle = FormBorderStyle.FixedSingle
        Me.StartPosition = FormStartPosition.CenterScreen
        Label20.Text = "EMTRACC"
        Label20.ForeColor = Color.FromArgb(80, 140, 255)
        Label20.Font = New Font("Segoe UI", 12, FontStyle.Bold)

        ' === Panel principal ===
        PanelP.BackColor = fondoPanel

        ' === Lineas separadoras ===
        Line1.ForeColor = colorLinea
        Line2.ForeColor = colorLinea

        ' === Fuente moderna para labels ===
        Dim fuenteLabel As New Font("Segoe UI", 10, FontStyle.Regular)

        ' Estilizar todos los labels dentro del panel
        For Each ctrl As Control In PanelP.Controls
            If TypeOf ctrl Is Label Then
                Dim lbl = DirectCast(ctrl, Label)
                lbl.Font = fuenteLabel
                lbl.ForeColor = colorLabel
            End If
        Next

        ' === Estilizar TextBoxes ===
        For Each ctrl As Control In PanelP.Controls
            If TypeOf ctrl Is DevComponents.DotNetBar.Controls.TextBoxX Then
                Dim tb = DirectCast(ctrl, DevComponents.DotNetBar.Controls.TextBoxX)
                tb.BackColor = fondoTextbox
                tb.ForeColor = Color.White
                tb.Font = New Font("Segoe UI", 11)
                tb.Border.BackColor = fondoTextbox
                tb.Border.BackColor2 = fondoTextbox
                tb.Border.BorderColor = colorBorde
                tb.Border.BorderBottomWidth = 2
                tb.Border.BorderLeftWidth = 2
                tb.Border.BorderRightWidth = 2
                tb.Border.BorderTopWidth = 2
                tb.Border.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
                tb.FocusHighlightEnabled = True
                tb.FocusHighlightColor = colorFocus
            End If
        Next

        ' === Estilizar Botones ===
        Dim fuenteBtn As New Font("Segoe UI", 9.5, FontStyle.Bold)

        NuevoBtn.Font = fuenteBtn
        NuevoBtn.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueWithBackground
        NuevoBtn.Text = " Nuevo"

        EditarBtn.Font = fuenteBtn
        EditarBtn.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueWithBackground
        EditarBtn.Text = " Editar"

        GuardarBtn.Font = fuenteBtn
        GuardarBtn.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueWithBackground
        GuardarBtn.SymbolColor = Color.FromArgb(0, 200, 80)
        GuardarBtn.Text = " Guardar"

        ModificarBtn.Font = fuenteBtn
        ModificarBtn.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueWithBackground
        ModificarBtn.SymbolColor = Color.FromArgb(255, 180, 0)
        ModificarBtn.Text = " Modificar"

        EliminarBtn.Font = fuenteBtn
        EliminarBtn.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueWithBackground
        EliminarBtn.SymbolColor = Color.FromArgb(220, 50, 50)
        EliminarBtn.Text = " Eliminar"

        CancelarBtn.Font = fuenteBtn
        CancelarBtn.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueWithBackground
        CancelarBtn.Text = " Cancelar"
    End Sub
    Private Sub act()
        Me.NuevoBtn.Enabled = True
        Me.EditarBtn.Enabled = True
        Me.GuardarBtn.Enabled = False
        Me.GuardarBtn.Visible = True
        Me.ModificarBtn.Enabled = False
        Me.ModificarBtn.Visible = True
        Me.CancelarBtn.Enabled = False
        Me.EliminarBtn.Enabled = False
        If ModuloConexion.EsSoloLectura() Then
            NuevoBtn.Enabled = False
            EditarBtn.Enabled = False
        End If
    End Sub
    Private Sub HabilitarTextBoxes(habilitar As Boolean)
        For Each ctrl As Control In PanelP.Controls
            If TypeOf ctrl Is DevComponents.DotNetBar.Controls.TextBoxX Then
                ctrl.Enabled = habilitar
            End If
        Next
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
        Me.faxTb.Text = ""
    End Sub
    Private Sub NuevoBtn_Click(sender As Object, e As EventArgs) Handles NuevoBtn.Click '============  NUEVO  ===========
        limpiar()
        HabilitarTextBoxes(True)
        NuevoBtn.Enabled = False
        EditarBtn.Enabled = False
        GuardarBtn.Enabled = True
        GuardarBtn.Visible = True
        ModificarBtn.Visible = False
        CancelarBtn.Enabled = True
        EliminarBtn.Enabled = False
    End Sub

    Private Sub EditarBtn_Click(sender As Object, e As EventArgs) Handles EditarBtn.Click '============  EDITAR  ===========
        HabilitarTextBoxes(True)
        NuevoBtn.Enabled = False
        EditarBtn.Enabled = False
        GuardarBtn.Enabled = False
        GuardarBtn.Visible = False
        ModificarBtn.Enabled = True
        ModificarBtn.Visible = True
        CancelarBtn.Enabled = True
        EliminarBtn.Enabled = True
    End Sub

    Private Sub GuardarBtn_Click(sender As Object, e As EventArgs) Handles GuardarBtn.Click '============  GUARDAR  ===========
        Try
            Using conLocal As MySqlConnection = ModuloConexion.ObtenerConexion()
                conLocal.Open()
                Using cmd As New MySqlCommand("INSERT INTO empresa (nEmpre, nPropie, nombLocal, dire1, dire2, dire3, local, rtn, correoE, cai, tel1, cel2, fax, ochoDig, rangoIni, rangoFin, fechaLimit, otros1, otros2) VALUES(@nEmpre, @nPropie, @nombLocal, @dire1, @dire2, @dire3, @local, @rtn, @correoE, @cai, @tel1, @cel2, @fax, @ochoDig, @rangoIni, @rangoFin, @fechaLimit, @otros1, @otros2)", conLocal)

                    cmd.Parameters.AddWithValue("@nEmpre", nEmpreTb.Text)
                    cmd.Parameters.AddWithValue("@nPropie", nPropieTb.Text)
                    cmd.Parameters.AddWithValue("@nombLocal", nombLocalTb.Text)
                    cmd.Parameters.AddWithValue("@dire1", dire1Tb.Text)
                    cmd.Parameters.AddWithValue("@dire2", dire2Tb.Text)
                    cmd.Parameters.AddWithValue("@dire3", dire3Tb.Text)
                    cmd.Parameters.AddWithValue("@local", localTb.Text)
                    cmd.Parameters.AddWithValue("@rtn", rtnTb.Text)
                    cmd.Parameters.AddWithValue("@correoE", correoETb.Text)
                    cmd.Parameters.AddWithValue("@cai", caiTb.Text)
                    cmd.Parameters.AddWithValue("@tel1", tel1Tb.Text)
                    cmd.Parameters.AddWithValue("@cel2", cel2Tb.Text)
                    cmd.Parameters.AddWithValue("@fax", faxTb.Text)
                    cmd.Parameters.AddWithValue("@ochoDig", ochodigTb.Text)
                    cmd.Parameters.AddWithValue("@rangoIni", rangoIniTb.Text)
                    cmd.Parameters.AddWithValue("@rangoFin", rangoFinTb.Text)
                    cmd.Parameters.AddWithValue("@fechaLimit", fechaLimitTb.Text)
                    cmd.Parameters.AddWithValue("@otros1", otros1Tb.Text)
                    cmd.Parameters.AddWithValue("@otros2", otros2Tb.Text)

                    cmd.ExecuteNonQuery()
                End Using
            End Using
            MsgBox("Registro guardado")
        Catch ex As Exception
            MessageBox.Show("Error al guardar: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        limpiar()
        act()
        seleccion()
        HabilitarTextBoxes(False)
    End Sub

    Private Sub EliminarBtn_Click(sender As Object, e As EventArgs) Handles EliminarBtn.Click '============  ELIMINAR  ===========
        Try
            Dim opc As DialogResult = MsgBox("¿Desea Eliminar este registro?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Eliminar")
            If opc = Windows.Forms.DialogResult.Yes Then
                Using conLocal As MySqlConnection = ModuloConexion.ObtenerConexion()
                    conLocal.Open()
                    Using cmd As New MySqlCommand("DELETE FROM empresa WHERE nEmpre = @nEmpre", conLocal)
                        cmd.Parameters.AddWithValue("@nEmpre", nEmpreTb.Text)
                        cmd.ExecuteNonQuery()
                    End Using
                End Using
                MsgBox("Registro eliminado correctamente", MsgBoxStyle.Information, "Éxito")
            End If
        Catch ex As Exception
            MessageBox.Show("Error al eliminar: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        act()
    End Sub

    Private Sub CancelarBtn_Click(sender As Object, e As EventArgs) Handles CancelarBtn.Click '============  CANCELAR  ===========
        act()
        HabilitarTextBoxes(False)
        seleccion()
    End Sub

    Private Sub ModificarBtn_Click(sender As Object, e As EventArgs) Handles ModificarBtn.Click '============  MODIFICAR  ===========
        actual()
        act()
        HabilitarTextBoxes(False)
        seleccion()
    End Sub
    Public Sub actual()
        Try
            Using conLocal As MySqlConnection = ModuloConexion.ObtenerConexion()
                conLocal.Open()
                Using cmd As New MySqlCommand("UPDATE empresa SET nEmpre = @nEmpre, nPropie = @nPropie, nombLocal = @nombLocal, dire1 = @dire1, dire2 = @dire2, dire3 = @dire3, local = @local, rtn = @rtn, correoE = @correoE, cai = @cai, tel1 = @tel1, cel2 = @cel2, fax = @fax, ochoDig = @ochoDig, rangoIni = @rangoIni, rangoFin = @rangoFin, fechaLimit = @fechaLimit, otros1 = @otros1, otros2 = @otros2", conLocal)
                    cmd.Parameters.AddWithValue("@nEmpre", nEmpreTb.Text)
                    cmd.Parameters.AddWithValue("@nPropie", nPropieTb.Text)
                    cmd.Parameters.AddWithValue("@nombLocal", nombLocalTb.Text)
                    cmd.Parameters.AddWithValue("@dire1", dire1Tb.Text)
                    cmd.Parameters.AddWithValue("@dire2", dire2Tb.Text)
                    cmd.Parameters.AddWithValue("@dire3", dire3Tb.Text)
                    cmd.Parameters.AddWithValue("@local", localTb.Text)
                    cmd.Parameters.AddWithValue("@rtn", rtnTb.Text)
                    cmd.Parameters.AddWithValue("@correoE", correoETb.Text)
                    cmd.Parameters.AddWithValue("@cai", caiTb.Text)
                    cmd.Parameters.AddWithValue("@tel1", tel1Tb.Text)
                    cmd.Parameters.AddWithValue("@cel2", cel2Tb.Text)
                    cmd.Parameters.AddWithValue("@fax", faxTb.Text)
                    cmd.Parameters.AddWithValue("@ochoDig", ochodigTb.Text)
                    cmd.Parameters.AddWithValue("@rangoIni", rangoIniTb.Text)
                    cmd.Parameters.AddWithValue("@rangoFin", rangoFinTb.Text)
                    cmd.Parameters.AddWithValue("@fechaLimit", fechaLimitTb.Text)
                    cmd.Parameters.AddWithValue("@otros1", otros1Tb.Text)
                    cmd.Parameters.AddWithValue("@otros2", otros2Tb.Text)
                    cmd.ExecuteNonQuery()
                End Using
            End Using
            MsgBox("Registro Actualizado")
        Catch ex As Exception
            MessageBox.Show("Error al actualizar: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Sub seleccion()
        Try
            Using conLocal As MySqlConnection = ModuloConexion.ObtenerConexion()
                conLocal.Open()
                Using cmd As New MySqlCommand("SELECT * FROM empresa LIMIT 0,1", conLocal)
                    adaptador = New MySqlDataAdapter(cmd)
                    datos = New DataSet
                    adaptador.Fill(datos, "empresa")
                End Using
            End Using

            If datos.Tables("empresa").Rows.Count <> 0 Then
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
        Catch ex As Exception
            MessageBox.Show("Error al cargar empresa: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class