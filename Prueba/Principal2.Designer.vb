<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Principal2
    Inherits System.Windows.Forms.Form

    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    Private components As System.ComponentModel.IContainer

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.PanelMenu = New System.Windows.Forms.Panel()
        Me.BtnExit = New DevComponents.DotNetBar.ButtonX()
        Me.BtnHelp = New DevComponents.DotNetBar.ButtonX()
        Me.BtnTools = New DevComponents.DotNetBar.ButtonX()
        Me.BtnEqualizer = New DevComponents.DotNetBar.ButtonX()
        Me.PanelSubMenu = New System.Windows.Forms.Panel()
        Me.BtnValorComb = New DevComponents.DotNetBar.ButtonX()
        Me.BtnReporte = New DevComponents.DotNetBar.ButtonX()
        Me.BtnConsumo = New DevComponents.DotNetBar.ButtonX()
        Me.BtnFactura = New DevComponents.DotNetBar.ButtonX()
        Me.BtnPlaylist = New DevComponents.DotNetBar.ButtonX()
        Me.BtnMedia = New DevComponents.DotNetBar.ButtonX()
        Me.PanelLogo = New System.Windows.Forms.Panel()
        Me.LabelLogo = New DevComponents.DotNetBar.LabelX()
        Me.PictureBoxLogo = New System.Windows.Forms.PictureBox()
        Me.PanelMain = New System.Windows.Forms.Panel()
        Me.PanelForm = New System.Windows.Forms.Panel()
        Me.LabelTitulo = New DevComponents.DotNetBar.LabelX()
        Me.PanelBottom = New System.Windows.Forms.Panel()
        Me.LabelStatus = New DevComponents.DotNetBar.LabelX()
        Me.PanelMenu.SuspendLayout()
        Me.PanelSubMenu.SuspendLayout()
        Me.PanelLogo.SuspendLayout()
        CType(Me.PictureBoxLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelMain.SuspendLayout()
        Me.PanelForm.SuspendLayout()
        Me.PanelBottom.SuspendLayout()
        Me.SuspendLayout()
        '
        'PanelMenu
        '
        Me.PanelMenu.BackColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.PanelMenu.Controls.Add(Me.BtnExit)
        Me.PanelMenu.Controls.Add(Me.BtnHelp)
        Me.PanelMenu.Controls.Add(Me.BtnTools)
        Me.PanelMenu.Controls.Add(Me.BtnEqualizer)
        Me.PanelMenu.Controls.Add(Me.PanelSubMenu)
        Me.PanelMenu.Controls.Add(Me.BtnPlaylist)
        Me.PanelMenu.Controls.Add(Me.BtnMedia)
        Me.PanelMenu.Controls.Add(Me.PanelLogo)
        Me.PanelMenu.Dock = System.Windows.Forms.DockStyle.Left
        Me.PanelMenu.Location = New System.Drawing.Point(0, 0)
        Me.PanelMenu.Name = "PanelMenu"
        Me.PanelMenu.Size = New System.Drawing.Size(200, 561)
        Me.PanelMenu.TabIndex = 0
        '
        'BtnExit
        '
        Me.BtnExit.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.BtnExit.BackColor = System.Drawing.Color.Transparent
        Me.BtnExit.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat
        Me.BtnExit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnExit.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BtnExit.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnExit.Location = New System.Drawing.Point(0, 521)
        Me.BtnExit.Name = "BtnExit"
        Me.BtnExit.Size = New System.Drawing.Size(200, 40)
        Me.BtnExit.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.BtnExit.SymbolColor = System.Drawing.Color.Salmon
        Me.BtnExit.SymbolSize = 14.0!
        Me.BtnExit.TabIndex = 7
        Me.BtnExit.Text = "   Salir"
        Me.BtnExit.TextAlignment = DevComponents.DotNetBar.eButtonTextAlignment.Left
        '
        'BtnHelp
        '
        Me.BtnHelp.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.BtnHelp.BackColor = System.Drawing.Color.Transparent
        Me.BtnHelp.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat
        Me.BtnHelp.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnHelp.Dock = System.Windows.Forms.DockStyle.Top
        Me.BtnHelp.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnHelp.Location = New System.Drawing.Point(0, 380)
        Me.BtnHelp.Name = "BtnHelp"
        Me.BtnHelp.Size = New System.Drawing.Size(200, 40)
        Me.BtnHelp.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.BtnHelp.SymbolColor = System.Drawing.Color.DeepSkyBlue
        Me.BtnHelp.SymbolSize = 14.0!
        Me.BtnHelp.TabIndex = 6
        Me.BtnHelp.Text = "   Accesos"
        Me.BtnHelp.TextAlignment = DevComponents.DotNetBar.eButtonTextAlignment.Left
        '
        'BtnTools
        '
        Me.BtnTools.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.BtnTools.BackColor = System.Drawing.Color.Transparent
        Me.BtnTools.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat
        Me.BtnTools.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnTools.Dock = System.Windows.Forms.DockStyle.Top
        Me.BtnTools.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnTools.Location = New System.Drawing.Point(0, 340)
        Me.BtnTools.Name = "BtnTools"
        Me.BtnTools.Size = New System.Drawing.Size(200, 40)
        Me.BtnTools.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.BtnTools.SymbolColor = System.Drawing.Color.DeepSkyBlue
        Me.BtnTools.SymbolSize = 14.0!
        Me.BtnTools.TabIndex = 5
        Me.BtnTools.Text = "   Empresa"
        Me.BtnTools.TextAlignment = DevComponents.DotNetBar.eButtonTextAlignment.Left
        '
        'BtnEqualizer
        '
        Me.BtnEqualizer.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.BtnEqualizer.BackColor = System.Drawing.Color.Transparent
        Me.BtnEqualizer.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat
        Me.BtnEqualizer.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnEqualizer.Dock = System.Windows.Forms.DockStyle.Top
        Me.BtnEqualizer.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnEqualizer.Location = New System.Drawing.Point(0, 300)
        Me.BtnEqualizer.Name = "BtnEqualizer"
        Me.BtnEqualizer.Size = New System.Drawing.Size(200, 40)
        Me.BtnEqualizer.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.BtnEqualizer.SymbolColor = System.Drawing.Color.DeepSkyBlue
        Me.BtnEqualizer.SymbolSize = 14.0!
        Me.BtnEqualizer.TabIndex = 4
        Me.BtnEqualizer.Text = "   Medicion"
        Me.BtnEqualizer.TextAlignment = DevComponents.DotNetBar.eButtonTextAlignment.Left
        '
        'PanelSubMenu
        '
        Me.PanelSubMenu.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(65, Byte), Integer))
        Me.PanelSubMenu.Controls.Add(Me.BtnValorComb)
        Me.PanelSubMenu.Controls.Add(Me.BtnReporte)
        Me.PanelSubMenu.Controls.Add(Me.BtnConsumo)
        Me.PanelSubMenu.Controls.Add(Me.BtnFactura)
        Me.PanelSubMenu.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelSubMenu.Location = New System.Drawing.Point(0, 180)
        Me.PanelSubMenu.Name = "PanelSubMenu"
        Me.PanelSubMenu.Size = New System.Drawing.Size(200, 120)
        Me.PanelSubMenu.TabIndex = 3
        Me.PanelSubMenu.Visible = False
        '
        'BtnValorComb
        '
        Me.BtnValorComb.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.BtnValorComb.BackColor = System.Drawing.Color.Transparent
        Me.BtnValorComb.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat
        Me.BtnValorComb.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnValorComb.Dock = System.Windows.Forms.DockStyle.Top
        Me.BtnValorComb.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnValorComb.Location = New System.Drawing.Point(0, 90)
        Me.BtnValorComb.Name = "BtnValorComb"
        Me.BtnValorComb.Size = New System.Drawing.Size(200, 30)
        Me.BtnValorComb.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.BtnValorComb.TabIndex = 3
        Me.BtnValorComb.Text = "       Valor Combustible"
        Me.BtnValorComb.TextAlignment = DevComponents.DotNetBar.eButtonTextAlignment.Left
        '
        'BtnReporte
        '
        Me.BtnReporte.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.BtnReporte.BackColor = System.Drawing.Color.Transparent
        Me.BtnReporte.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat
        Me.BtnReporte.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnReporte.Dock = System.Windows.Forms.DockStyle.Top
        Me.BtnReporte.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnReporte.Location = New System.Drawing.Point(0, 60)
        Me.BtnReporte.Name = "BtnReporte"
        Me.BtnReporte.Size = New System.Drawing.Size(200, 30)
        Me.BtnReporte.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.BtnReporte.TabIndex = 2
        Me.BtnReporte.Text = "       Reporte"
        Me.BtnReporte.TextAlignment = DevComponents.DotNetBar.eButtonTextAlignment.Left
        '
        'BtnConsumo
        '
        Me.BtnConsumo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.BtnConsumo.BackColor = System.Drawing.Color.Transparent
        Me.BtnConsumo.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat
        Me.BtnConsumo.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnConsumo.Dock = System.Windows.Forms.DockStyle.Top
        Me.BtnConsumo.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnConsumo.Location = New System.Drawing.Point(0, 30)
        Me.BtnConsumo.Name = "BtnConsumo"
        Me.BtnConsumo.Size = New System.Drawing.Size(200, 30)
        Me.BtnConsumo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.BtnConsumo.TabIndex = 1
        Me.BtnConsumo.Text = "       Consumo"
        Me.BtnConsumo.TextAlignment = DevComponents.DotNetBar.eButtonTextAlignment.Left
        '
        'BtnFactura
        '
        Me.BtnFactura.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.BtnFactura.BackColor = System.Drawing.Color.Transparent
        Me.BtnFactura.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat
        Me.BtnFactura.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnFactura.Dock = System.Windows.Forms.DockStyle.Top
        Me.BtnFactura.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnFactura.Location = New System.Drawing.Point(0, 0)
        Me.BtnFactura.Name = "BtnFactura"
        Me.BtnFactura.Size = New System.Drawing.Size(200, 30)
        Me.BtnFactura.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.BtnFactura.TabIndex = 0
        Me.BtnFactura.Text = "       Factura"
        Me.BtnFactura.TextAlignment = DevComponents.DotNetBar.eButtonTextAlignment.Left
        '
        'BtnPlaylist
        '
        Me.BtnPlaylist.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.BtnPlaylist.BackColor = System.Drawing.Color.Transparent
        Me.BtnPlaylist.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat
        Me.BtnPlaylist.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnPlaylist.Dock = System.Windows.Forms.DockStyle.Top
        Me.BtnPlaylist.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnPlaylist.Location = New System.Drawing.Point(0, 140)
        Me.BtnPlaylist.Name = "BtnPlaylist"
        Me.BtnPlaylist.Size = New System.Drawing.Size(200, 40)
        Me.BtnPlaylist.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.BtnPlaylist.SymbolColor = System.Drawing.Color.DeepSkyBlue
        Me.BtnPlaylist.SymbolSize = 14.0!
        Me.BtnPlaylist.TabIndex = 2
        Me.BtnPlaylist.Text = "   Gestion"
        Me.BtnPlaylist.TextAlignment = DevComponents.DotNetBar.eButtonTextAlignment.Left
        '
        'BtnMedia
        '
        Me.BtnMedia.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.BtnMedia.BackColor = System.Drawing.Color.Transparent
        Me.BtnMedia.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat
        Me.BtnMedia.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnMedia.Dock = System.Windows.Forms.DockStyle.Top
        Me.BtnMedia.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnMedia.Location = New System.Drawing.Point(0, 100)
        Me.BtnMedia.Name = "BtnMedia"
        Me.BtnMedia.Size = New System.Drawing.Size(200, 40)
        Me.BtnMedia.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.BtnMedia.SymbolColor = System.Drawing.Color.DeepSkyBlue
        Me.BtnMedia.SymbolSize = 14.0!
        Me.BtnMedia.TabIndex = 1
        Me.BtnMedia.Text = "   Comprobante"
        Me.BtnMedia.TextAlignment = DevComponents.DotNetBar.eButtonTextAlignment.Left
        '
        'PanelLogo
        '
        Me.PanelLogo.BackColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.PanelLogo.Controls.Add(Me.LabelLogo)
        Me.PanelLogo.Controls.Add(Me.PictureBoxLogo)
        Me.PanelLogo.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelLogo.Location = New System.Drawing.Point(0, 0)
        Me.PanelLogo.Name = "PanelLogo"
        Me.PanelLogo.Size = New System.Drawing.Size(200, 100)
        Me.PanelLogo.TabIndex = 0
        '
        'LabelLogo
        '
        Me.LabelLogo.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelLogo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelLogo.Font = New System.Drawing.Font("Segoe UI", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelLogo.ForeColor = System.Drawing.Color.DeepSkyBlue
        Me.LabelLogo.Location = New System.Drawing.Point(65, 35)
        Me.LabelLogo.Name = "LabelLogo"
        Me.LabelLogo.Size = New System.Drawing.Size(130, 30)
        Me.LabelLogo.TabIndex = 1
        Me.LabelLogo.Text = "EMTRACC"
        '
        'PictureBoxLogo
        '
        Me.PictureBoxLogo.BackColor = System.Drawing.Color.Transparent
        Me.PictureBoxLogo.Location = New System.Drawing.Point(12, 20)
        Me.PictureBoxLogo.Name = "PictureBoxLogo"
        Me.PictureBoxLogo.Size = New System.Drawing.Size(50, 60)
        Me.PictureBoxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBoxLogo.TabIndex = 0
        Me.PictureBoxLogo.TabStop = False
        '
        'PanelMain
        '
        Me.PanelMain.BackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(75, Byte), Integer))
        Me.PanelMain.Controls.Add(Me.PanelForm)
        Me.PanelMain.Controls.Add(Me.PanelBottom)
        Me.PanelMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelMain.Location = New System.Drawing.Point(200, 0)
        Me.PanelMain.Name = "PanelMain"
        Me.PanelMain.Size = New System.Drawing.Size(684, 561)
        Me.PanelMain.TabIndex = 1
        '
        'PanelForm
        '
        Me.PanelForm.BackColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(75, Byte), Integer))
        Me.PanelForm.Controls.Add(Me.LabelTitulo)
        Me.PanelForm.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelForm.Location = New System.Drawing.Point(0, 0)
        Me.PanelForm.Name = "PanelForm"
        Me.PanelForm.Size = New System.Drawing.Size(684, 531)
        Me.PanelForm.TabIndex = 1
        '
        'LabelTitulo
        '
        Me.LabelTitulo.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.LabelTitulo.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelTitulo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelTitulo.Font = New System.Drawing.Font("Segoe UI", 36.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelTitulo.ForeColor = System.Drawing.Color.DeepSkyBlue
        Me.LabelTitulo.Location = New System.Drawing.Point(192, 215)
        Me.LabelTitulo.Name = "LabelTitulo"
        Me.LabelTitulo.Size = New System.Drawing.Size(300, 70)
        Me.LabelTitulo.TabIndex = 0
        Me.LabelTitulo.Text = "EMTRACC"
        Me.LabelTitulo.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'PanelBottom
        '
        Me.PanelBottom.BackColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.PanelBottom.Controls.Add(Me.LabelStatus)
        Me.PanelBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelBottom.Location = New System.Drawing.Point(0, 531)
        Me.PanelBottom.Name = "PanelBottom"
        Me.PanelBottom.Size = New System.Drawing.Size(684, 30)
        Me.PanelBottom.TabIndex = 0
        '
        'LabelStatus
        '
        Me.LabelStatus.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelStatus.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelStatus.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelStatus.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelStatus.ForeColor = System.Drawing.Color.LightGray
        Me.LabelStatus.Location = New System.Drawing.Point(0, 0)
        Me.LabelStatus.Name = "LabelStatus"
        Me.LabelStatus.Size = New System.Drawing.Size(684, 30)
        Me.LabelStatus.TabIndex = 0
        Me.LabelStatus.Text = "   Sistema listo"
        '
        'Principal2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(884, 561)
        Me.Controls.Add(Me.PanelMain)
        Me.Controls.Add(Me.PanelMenu)
        Me.MinimumSize = New System.Drawing.Size(900, 600)
        Me.Name = "Principal2"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "EMTRACC - Sistema de Control de Combustible"
        Me.PanelMenu.ResumeLayout(False)
        Me.PanelSubMenu.ResumeLayout(False)
        Me.PanelLogo.ResumeLayout(False)
        CType(Me.PictureBoxLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelMain.ResumeLayout(False)
        Me.PanelForm.ResumeLayout(False)
        Me.PanelBottom.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelMenu As Panel
    Friend WithEvents PanelLogo As Panel
    Friend WithEvents PictureBoxLogo As PictureBox
    Friend WithEvents LabelLogo As DevComponents.DotNetBar.LabelX
    Friend WithEvents BtnMedia As DevComponents.DotNetBar.ButtonX
    Friend WithEvents BtnPlaylist As DevComponents.DotNetBar.ButtonX
    Friend WithEvents PanelSubMenu As Panel
    Friend WithEvents BtnFactura As DevComponents.DotNetBar.ButtonX
    Friend WithEvents BtnConsumo As DevComponents.DotNetBar.ButtonX
    Friend WithEvents BtnReporte As DevComponents.DotNetBar.ButtonX
    Friend WithEvents BtnValorComb As DevComponents.DotNetBar.ButtonX
    Friend WithEvents BtnEqualizer As DevComponents.DotNetBar.ButtonX
    Friend WithEvents BtnTools As DevComponents.DotNetBar.ButtonX
    Friend WithEvents BtnHelp As DevComponents.DotNetBar.ButtonX
    Friend WithEvents BtnExit As DevComponents.DotNetBar.ButtonX
    Friend WithEvents PanelMain As Panel
    Friend WithEvents PanelForm As Panel
    Friend WithEvents PanelBottom As Panel
    Friend WithEvents LabelStatus As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelTitulo As DevComponents.DotNetBar.LabelX
End Class
