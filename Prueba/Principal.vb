Imports System.Data
Imports MySql.Data.MySqlClient
Imports MySql.Data
Public Class Principal
    Private isDragging As Boolean = False
    Private startPoint As Point


    Dim con As New MySqlConnection
    Dim cm As New MySqlCommand
    Dim guardar As New MySqlCommand
    Dim adaptador As New MySqlDataAdapter
    Dim datos As DataSet
    Private Sub Principal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        resBt.Visible = False

        camiBt.BackColor = Color.FromArgb(153, 180, 209)
    End Sub
    Public Sub conectar()
        Dim servidor As String = "localhost"
        Dim baseDatos As String = "givemefuel"
        Dim userid As String = "root"
        Dim clave As String = ""

        con.ConnectionString = "Server=" & servidor & "; Database=" & baseDatos & "; Uid = " & userid & "; Pwd = " & clave

        Try
            con.Open()
            MsgBox("La Wea se conectó")
        Catch ex As Exception
            MsgBox("No se conecto por: " & ex.Message)
        End Try

    End Sub
    Public Sub abrirformulario(frmh As Object)
        If (PanelForm.Controls.Count > 0) Then
            PanelForm.Controls.RemoveAt(0)

            Dim frm As Form
            frm = frmh
            frm.TopLevel = False
            frm.Dock = DockStyle.Fill
            PanelForm.Controls.Add(frm)
            PanelForm.Tag = frm
            frm.Show()

        Else
            Dim frm As Form
            frm = frmh
            frm.TopLevel = False
            frm.Dock = DockStyle.Fill
            PanelForm.Controls.Add(frm)
            PanelForm.Tag = frm
            frm.Show()
        End If
    End Sub

    Private Sub ButtonX1_Click(sender As Object, e As EventArgs) Handles camiBt.Click
        'ajusteBtn.Visible = True
        'ajustes2btn.Visible = False

        abrirformulario(New camiones)
        Panel1.Visible = False
    End Sub

    Private Sub ButtonX2_Click(sender As Object, e As EventArgs) Handles ButtonX2.Click
        'ajusteBtn.Visible = True
        'ajustes2btn.Visible = False

        abrirformulario(New placa)
        Panel1.Visible = False
    End Sub
    Private Sub ButtonX8_Click(sender As Object, e As EventArgs) Handles ButtonX8.Click
        'ajusteBtn.Visible = True
        'ajustes2btn.Visible = False

        abrirformulario(New transportistas)
        Panel1.Visible = False
    End Sub
    Private Sub ButtonX3_Click(sender As Object, e As EventArgs) Handles ButtonX3.Click
        'ajusteBtn.Visible = True
        'ajustes2btn.Visible = False

        abrirformulario(New tanque)
        Panel1.Visible = False
    End Sub
    Private Sub ButtonX5_Click(sender As Object, e As EventArgs) Handles ButtonX5.Click
        'ajusteBtn.Visible = True
        'ajustes2btn.Visible = False

        abrirformulario(New empresa)
        Panel1.Visible = False
    End Sub

    Private Sub ButtonX6_Click(sender As Object, e As EventArgs) Handles ButtonX6.Click
        'ajusteBtn.Visible = True
        'ajustes2btn.Visible = False

        abrirformulario(New acceso)
        Panel1.Visible = False
    End Sub
    Private Sub ButtonX7_Click(sender As Object, e As EventArgs) Handles ButtonX7.Click
        'ajusteBtn.Visible = True
        'ajustes2btn.Visible = False

        abrirformulario(New medicion)
        Panel1.Visible = False
    End Sub

    Private Sub ButtonX9_Click(sender As Object, e As EventArgs) Handles ButtonX9.Click
        'ajusteBtn.Visible = True
        'ajustes2btn.Visible = False

        abrirformulario(New comprobante)
        Panel1.Visible = False
    End Sub

    Private Sub ButtonX4_Click_1(sender As Object, e As EventArgs) Handles ButtonX4.Click
        'ajusteBtn.Visible = True
        'ajustes2btn.Visible = False

        abrirformulario(New factura)
        Panel1.Visible = False
    End Sub
    ' Evento MouseDown del panel
    Private Sub PanelUp_MouseDown(sender As Object, e As MouseEventArgs) Handles PanelUp.MouseDown
        If e.Button = MouseButtons.Left Then
            isDragging = True
            startPoint = New Point(e.X, e.Y)
        End If
    End Sub

    ' Evento MouseMove del panel
    Private Sub PanelUp_MouseMove(sender As Object, e As MouseEventArgs) Handles PanelUp.MouseMove
        If isDragging Then
            Dim screenPos As Point = PanelUp.PointToScreen(New Point(e.X, e.Y))
            Me.Location = New Point(screenPos.X - startPoint.X, screenPos.Y - startPoint.Y)
        End If
    End Sub

    ' Evento MouseUp del panel
    Private Sub PanelUp_MouseUp(sender As Object, e As MouseEventArgs) Handles PanelUp.MouseUp
        isDragging = False
    End Sub

    Private Sub closeBt_Click(sender As Object, e As EventArgs) Handles closeBt.Click
        Me.Close()
    End Sub
    Private Sub minBt_Click(sender As Object, e As EventArgs) Handles minBt.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub ButtonX4_Click(sender As Object, e As EventArgs) Handles resBt.Click
        Me.WindowState = FormWindowState.Normal
        maxBt.Visible = True
        resBt.Visible = False
    End Sub

    Private Sub maxBt_Click(sender As Object, e As EventArgs) Handles maxBt.Click
        Me.WindowState = FormWindowState.Maximized
        resBt.Visible = True
        maxBt.Visible = False
    End Sub

    Private Sub ButtonX1_Click_1(sender As Object, e As EventArgs) Handles ButtonX1.Click
        If Panel1.Visible = True Then
            Panel1.Visible = False
        Else
            Panel1.Visible = True
        End If
    End Sub


End Class