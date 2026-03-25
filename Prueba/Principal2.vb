Imports System.Data
Imports MySql.Data.MySqlClient

Public Class Principal2
    Private menuExpandido As Boolean = True
    Private menuOculto As Boolean = False

    Dim con As New MySqlConnection

    Private Sub Principal2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        PanelSubMenu.Visible = False
        LabelTitulo.Visible = True

        ' Agregar evento MouseMove a PanelMain para detectar acercamiento al borde izquierdo
        AddHandler PanelMain.MouseMove, AddressOf PanelMain_MouseMove
        AddHandler PanelForm.MouseMove, AddressOf PanelMain_MouseMove

        ' Agregar evento MouseLeave a PanelMenu para ocultar al alejarse
        AddHandler PanelMenu.MouseLeave, AddressOf PanelMenu_MouseLeave
    End Sub

    ' Ocultar el menu cuando el mouse sale del panel del menu
    Private Sub PanelMenu_MouseLeave(sender As Object, e As EventArgs)
        ' Verificar si el mouse realmente salio del area del menu
        Dim mousePos As Point = Me.PointToClient(Control.MousePosition)
        If Not PanelMenu.ClientRectangle.Contains(PanelMenu.PointToClient(Control.MousePosition)) Then
            ' Solo ocultar si hay un formulario abierto
            If PanelForm.Controls.Count > 0 AndAlso TypeOf PanelForm.Controls(0) Is Form Then
                OcultarMenu()
            End If
        End If
    End Sub

    ' Detectar cuando el mouse se acerca al borde izquierdo para mostrar el menu
    Private Sub PanelMain_MouseMove(sender As Object, e As MouseEventArgs)
        If menuOculto AndAlso e.X <= 10 Then
            MostrarMenu()
        End If
    End Sub

    ' Ocultar el menu
    Private Sub OcultarMenu()
        PanelMenu.Visible = False
        PanelSubMenu.Visible = False
        menuOculto = True
    End Sub

    ' Mostrar el menu
    Private Sub MostrarMenu()
        PanelMenu.Visible = True
        menuOculto = False
    End Sub

    ' Abrir formulario dentro del panel principal
    Public Sub AbrirFormulario(frmh As Object)
        If (PanelForm.Controls.Count > 0) Then
            PanelForm.Controls.RemoveAt(0)
        End If

        Dim frm As Form = frmh
        frm.TopLevel = False
        frm.Dock = DockStyle.Fill
        PanelForm.Controls.Add(frm)
        PanelForm.Tag = frm
        frm.Show()

        LabelTitulo.Visible = False
        LabelStatus.Text = "   " & frm.Text

        ' Ocultar el menu al abrir un formulario
        OcultarMenu()

        ' Agregar evento MouseMove al formulario hijo para detectar acercamiento al borde
        AddHandler frm.MouseMove, AddressOf FormHijo_MouseMove
    End Sub

    ' Detectar cuando el mouse se acerca al borde izquierdo en formularios hijos
    Private Sub FormHijo_MouseMove(sender As Object, e As MouseEventArgs)
        If menuOculto AndAlso e.X <= 10 Then
            MostrarMenu()
        End If
    End Sub

    ' Boton Comprobante
    Private Sub BtnMedia_Click(sender As Object, e As EventArgs) Handles BtnMedia.Click
        AbrirFormulario(New comprobante)
    End Sub

    ' Boton Gestion - Expande/Contrae submenu
    Private Sub BtnPlaylist_Click(sender As Object, e As EventArgs) Handles BtnPlaylist.Click
        PanelSubMenu.Visible = Not PanelSubMenu.Visible
        If PanelSubMenu.Visible Then
            BtnPlaylist.Symbol = ""
        Else
            BtnPlaylist.Symbol = ""
        End If
    End Sub

    ' Submenu - Factura
    Private Sub BtnFactura_Click(sender As Object, e As EventArgs) Handles BtnFactura.Click
        AbrirFormulario(New factura)
    End Sub

    ' Submenu - Consumo
    Private Sub BtnConsumo_Click(sender As Object, e As EventArgs) Handles BtnConsumo.Click
        AbrirFormulario(New consumo)
    End Sub

    ' Submenu - Reporte
    Private Sub BtnReporte_Click(sender As Object, e As EventArgs) Handles BtnReporte.Click
        AbrirFormulario(New reporte)
    End Sub

    ' Submenu - Valor Combustible
    Private Sub BtnValorComb_Click(sender As Object, e As EventArgs) Handles BtnValorComb.Click
        AbrirFormulario(New valorComb)
    End Sub

    ' Boton Medicion
    Private Sub BtnEqualizer_Click(sender As Object, e As EventArgs) Handles BtnEqualizer.Click
        AbrirFormulario(New medicion)
    End Sub

    ' Boton Empresa
    Private Sub BtnTools_Click(sender As Object, e As EventArgs) Handles BtnTools.Click
        AbrirFormulario(New empresa)
    End Sub

    ' Boton Accesos
    Private Sub BtnHelp_Click(sender As Object, e As EventArgs) Handles BtnHelp.Click
        AbrirFormulario(New acceso)
    End Sub

    ' Boton Salir
    Private Sub BtnExit_Click(sender As Object, e As EventArgs) Handles BtnExit.Click
        Dim opc As DialogResult = MsgBox("Desea salir del sistema?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Salir")
        If opc = Windows.Forms.DialogResult.Yes Then
            Me.Close()
        End If
    End Sub

    ' Doble click en el logo para abrir conexion
    Private Sub PictureBoxLogo_DoubleClick(sender As Object, e As EventArgs) Handles PictureBoxLogo.DoubleClick
        AbrirFormulario(New conexion)
    End Sub

    Private Sub PanelLogo_Paint(sender As Object, e As PaintEventArgs) Handles PanelLogo.Paint

    End Sub
End Class
