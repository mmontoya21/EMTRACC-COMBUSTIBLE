<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class login
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(login))
        Me.PanelP = New System.Windows.Forms.Panel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.verClaveBtn = New DevComponents.DotNetBar.ButtonX()
        Me.ingresarBtn = New DevComponents.DotNetBar.ButtonX()
        Me.claveTbx = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.usuarioTbx = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelClave = New DevComponents.DotNetBar.LabelX()
        Me.LabelUsuario = New DevComponents.DotNetBar.LabelX()
        Me.LabelSubtitulo = New DevComponents.DotNetBar.LabelX()
        Me.LabelTitulo = New DevComponents.DotNetBar.LabelX()
        Me.LabelPeriodo = New DevComponents.DotNetBar.LabelX()
        Me.LabelSemana = New DevComponents.DotNetBar.LabelX()
        Me.periodoCbx = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.P1 = New DevComponents.Editors.ComboItem()
        Me.P2 = New DevComponents.Editors.ComboItem()
        Me.P3 = New DevComponents.Editors.ComboItem()
        Me.P4 = New DevComponents.Editors.ComboItem()
        Me.P5 = New DevComponents.Editors.ComboItem()
        Me.P6 = New DevComponents.Editors.ComboItem()
        Me.P7 = New DevComponents.Editors.ComboItem()
        Me.P8 = New DevComponents.Editors.ComboItem()
        Me.P9 = New DevComponents.Editors.ComboItem()
        Me.P10 = New DevComponents.Editors.ComboItem()
        Me.P11 = New DevComponents.Editors.ComboItem()
        Me.P12 = New DevComponents.Editors.ComboItem()
        Me.P13 = New DevComponents.Editors.ComboItem()
        Me.semanaCbx = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.Sem1 = New DevComponents.Editors.ComboItem()
        Me.Sem2 = New DevComponents.Editors.ComboItem()
        Me.Sem3 = New DevComponents.Editors.ComboItem()
        Me.Sem4 = New DevComponents.Editors.ComboItem()
        Me.Sem5 = New DevComponents.Editors.ComboItem()
        Me.LabelTurno = New DevComponents.DotNetBar.LabelX()
        Me.turnoCbx = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.LabelOdometro = New DevComponents.DotNetBar.LabelX()
        Me.odometroTbx = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.PanelP.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelP
        '
        Me.PanelP.BackColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.PanelP.Controls.Add(Me.PictureBox1)
        Me.PanelP.Controls.Add(Me.verClaveBtn)
        Me.PanelP.Controls.Add(Me.ingresarBtn)
        Me.PanelP.Controls.Add(Me.claveTbx)
        Me.PanelP.Controls.Add(Me.usuarioTbx)
        Me.PanelP.Controls.Add(Me.LabelClave)
        Me.PanelP.Controls.Add(Me.LabelUsuario)
        Me.PanelP.Controls.Add(Me.LabelSubtitulo)
        Me.PanelP.Controls.Add(Me.LabelTitulo)
        Me.PanelP.Controls.Add(Me.LabelPeriodo)
        Me.PanelP.Controls.Add(Me.LabelSemana)
        Me.PanelP.Controls.Add(Me.periodoCbx)
        Me.PanelP.Controls.Add(Me.semanaCbx)
        Me.PanelP.Controls.Add(Me.LabelTurno)
        Me.PanelP.Controls.Add(Me.turnoCbx)
        Me.PanelP.Controls.Add(Me.LabelOdometro)
        Me.PanelP.Controls.Add(Me.odometroTbx)
        Me.PanelP.Location = New System.Drawing.Point(30, 30)
        Me.PanelP.Name = "PanelP"
        Me.PanelP.Size = New System.Drawing.Size(340, 560)
        Me.PanelP.TabIndex = 0
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.Prueba.My.Resources.Resources.truckyellow
        Me.PictureBox1.Location = New System.Drawing.Point(104, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(136, 126)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 8
        Me.PictureBox1.TabStop = False
        '
        'verClaveBtn
        '
        Me.verClaveBtn.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.verClaveBtn.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.verClaveBtn.Location = New System.Drawing.Point(279, 267)
        Me.verClaveBtn.Name = "verClaveBtn"
        Me.verClaveBtn.Size = New System.Drawing.Size(30, 27)
        Me.verClaveBtn.Symbol = "58391"
        Me.verClaveBtn.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
        Me.verClaveBtn.TabIndex = 6
        '
        'ingresarBtn
        '
        Me.ingresarBtn.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ingresarBtn.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.ingresarBtn.Location = New System.Drawing.Point(29, 500)
        Me.ingresarBtn.Name = "ingresarBtn"
        Me.ingresarBtn.Size = New System.Drawing.Size(280, 40)
        Me.ingresarBtn.TabIndex = 10
        Me.ingresarBtn.Text = "Ingresar"
        '
        'claveTbx
        '
        Me.claveTbx.BackColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(75, Byte), Integer), CType(CType(130, Byte), Integer))
        '
        '
        '
        Me.claveTbx.Border.BackColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(75, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.claveTbx.Border.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(75, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.claveTbx.Border.BorderBottomWidth = 2
        Me.claveTbx.Border.BorderColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(160, Byte), Integer), CType(CType(230, Byte), Integer))
        Me.claveTbx.Border.BorderLeftWidth = 2
        Me.claveTbx.Border.BorderRightWidth = 2
        Me.claveTbx.Border.BorderTopWidth = 2
        Me.claveTbx.Border.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.claveTbx.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(70, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.claveTbx.FocusHighlightEnabled = True
        Me.claveTbx.Font = New System.Drawing.Font("Segoe UI", 11.0!)
        Me.claveTbx.ForeColor = System.Drawing.Color.White
        Me.claveTbx.Location = New System.Drawing.Point(29, 267)
        Me.claveTbx.Name = "claveTbx"
        Me.claveTbx.PreventEnterBeep = True
        Me.claveTbx.Size = New System.Drawing.Size(245, 27)
        Me.claveTbx.TabIndex = 5
        Me.claveTbx.UseSystemPasswordChar = True
        '
        'usuarioTbx
        '
        Me.usuarioTbx.BackColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(75, Byte), Integer), CType(CType(130, Byte), Integer))
        '
        '
        '
        Me.usuarioTbx.Border.BackColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(75, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.usuarioTbx.Border.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(75, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.usuarioTbx.Border.BorderBottomWidth = 2
        Me.usuarioTbx.Border.BorderColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(160, Byte), Integer), CType(CType(230, Byte), Integer))
        Me.usuarioTbx.Border.BorderLeftWidth = 2
        Me.usuarioTbx.Border.BorderRightWidth = 2
        Me.usuarioTbx.Border.BorderTopWidth = 2
        Me.usuarioTbx.Border.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.usuarioTbx.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(70, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.usuarioTbx.FocusHighlightEnabled = True
        Me.usuarioTbx.Font = New System.Drawing.Font("Segoe UI", 11.0!)
        Me.usuarioTbx.ForeColor = System.Drawing.Color.White
        Me.usuarioTbx.Location = New System.Drawing.Point(29, 197)
        Me.usuarioTbx.Name = "usuarioTbx"
        Me.usuarioTbx.PreventEnterBeep = True
        Me.usuarioTbx.Size = New System.Drawing.Size(280, 27)
        Me.usuarioTbx.TabIndex = 3
        '
        'LabelClave
        '
        Me.LabelClave.AutoSize = True
        Me.LabelClave.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelClave.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelClave.Font = New System.Drawing.Font("Segoe UI Semibold", 11.0!, System.Drawing.FontStyle.Bold)
        Me.LabelClave.ForeColor = System.Drawing.Color.FromArgb(CType(CType(180, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.LabelClave.Location = New System.Drawing.Point(29, 242)
        Me.LabelClave.Name = "LabelClave"
        Me.LabelClave.Size = New System.Drawing.Size(78, 22)
        Me.LabelClave.TabIndex = 4
        Me.LabelClave.Text = "Contraseña"
        '
        'LabelUsuario
        '
        Me.LabelUsuario.AutoSize = True
        Me.LabelUsuario.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelUsuario.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelUsuario.Font = New System.Drawing.Font("Segoe UI Semibold", 11.0!, System.Drawing.FontStyle.Bold)
        Me.LabelUsuario.ForeColor = System.Drawing.Color.FromArgb(CType(CType(180, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.LabelUsuario.Location = New System.Drawing.Point(29, 172)
        Me.LabelUsuario.Name = "LabelUsuario"
        Me.LabelUsuario.Size = New System.Drawing.Size(53, 22)
        Me.LabelUsuario.TabIndex = 2
        Me.LabelUsuario.Text = "Usuario"
        '
        'LabelSubtitulo
        '
        Me.LabelSubtitulo.AutoSize = True
        Me.LabelSubtitulo.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelSubtitulo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelSubtitulo.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.LabelSubtitulo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(180, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.LabelSubtitulo.Location = New System.Drawing.Point(95, 149)
        Me.LabelSubtitulo.Name = "LabelSubtitulo"
        Me.LabelSubtitulo.Size = New System.Drawing.Size(145, 20)
        Me.LabelSubtitulo.TabIndex = 1
        Me.LabelSubtitulo.Text = "Sistema de Combustible"
        '
        'LabelTitulo
        '
        Me.LabelTitulo.AutoSize = True
        Me.LabelTitulo.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelTitulo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelTitulo.Font = New System.Drawing.Font("Segoe UI", 20.0!, System.Drawing.FontStyle.Bold)
        Me.LabelTitulo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(80, Byte), Integer), CType(CType(140, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.LabelTitulo.Location = New System.Drawing.Point(104, 115)
        Me.LabelTitulo.Name = "LabelTitulo"
        Me.LabelTitulo.Size = New System.Drawing.Size(127, 40)
        Me.LabelTitulo.TabIndex = 0
        Me.LabelTitulo.Text = "EMTRACC"
        '
        'LabelPeriodo
        '
        Me.LabelPeriodo.AutoSize = True
        Me.LabelPeriodo.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelPeriodo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelPeriodo.Font = New System.Drawing.Font("Segoe UI Semibold", 11.0!, System.Drawing.FontStyle.Bold)
        Me.LabelPeriodo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(180, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.LabelPeriodo.Location = New System.Drawing.Point(29, 310)
        Me.LabelPeriodo.Name = "LabelPeriodo"
        Me.LabelPeriodo.Size = New System.Drawing.Size(54, 22)
        Me.LabelPeriodo.TabIndex = 9
        Me.LabelPeriodo.Text = "Período"
        '
        'LabelSemana
        '
        Me.LabelSemana.AutoSize = True
        Me.LabelSemana.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelSemana.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelSemana.Font = New System.Drawing.Font("Segoe UI Semibold", 11.0!, System.Drawing.FontStyle.Bold)
        Me.LabelSemana.ForeColor = System.Drawing.Color.FromArgb(CType(CType(180, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.LabelSemana.Location = New System.Drawing.Point(170, 310)
        Me.LabelSemana.Name = "LabelSemana"
        Me.LabelSemana.Size = New System.Drawing.Size(55, 22)
        Me.LabelSemana.TabIndex = 10
        Me.LabelSemana.Text = "Semana"
        '
        'periodoCbx
        '
        Me.periodoCbx.DisplayMember = "Text"
        Me.periodoCbx.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.periodoCbx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.periodoCbx.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.periodoCbx.ForeColor = System.Drawing.Color.Black
        Me.periodoCbx.FormattingEnabled = True
        Me.periodoCbx.ItemHeight = 21
        Me.periodoCbx.Items.AddRange(New Object() {Me.P1, Me.P2, Me.P3, Me.P4, Me.P5, Me.P6, Me.P7, Me.P8, Me.P9, Me.P10, Me.P11, Me.P12, Me.P13})
        Me.periodoCbx.Location = New System.Drawing.Point(29, 335)
        Me.periodoCbx.Name = "periodoCbx"
        Me.periodoCbx.Size = New System.Drawing.Size(130, 27)
        Me.periodoCbx.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.periodoCbx.TabIndex = 7
        '
        'P1
        '
        Me.P1.FontStyle = System.Drawing.FontStyle.Bold
        Me.P1.ForeColor = System.Drawing.Color.Black
        Me.P1.Text = "1"
        '
        'P2
        '
        Me.P2.FontStyle = System.Drawing.FontStyle.Bold
        Me.P2.ForeColor = System.Drawing.Color.Black
        Me.P2.Text = "2"
        '
        'P3
        '
        Me.P3.FontStyle = System.Drawing.FontStyle.Bold
        Me.P3.ForeColor = System.Drawing.Color.Black
        Me.P3.Text = "3"
        '
        'P4
        '
        Me.P4.FontStyle = System.Drawing.FontStyle.Bold
        Me.P4.ForeColor = System.Drawing.Color.Black
        Me.P4.Text = "4"
        '
        'P5
        '
        Me.P5.FontStyle = System.Drawing.FontStyle.Bold
        Me.P5.ForeColor = System.Drawing.Color.Black
        Me.P5.Text = "5"
        '
        'P6
        '
        Me.P6.FontStyle = System.Drawing.FontStyle.Bold
        Me.P6.ForeColor = System.Drawing.Color.Black
        Me.P6.Text = "6"
        '
        'P7
        '
        Me.P7.FontStyle = System.Drawing.FontStyle.Bold
        Me.P7.ForeColor = System.Drawing.Color.Black
        Me.P7.Text = "7"
        '
        'P8
        '
        Me.P8.FontStyle = System.Drawing.FontStyle.Bold
        Me.P8.ForeColor = System.Drawing.Color.Black
        Me.P8.Text = "8"
        '
        'P9
        '
        Me.P9.FontStyle = System.Drawing.FontStyle.Bold
        Me.P9.ForeColor = System.Drawing.Color.Black
        Me.P9.Text = "9"
        '
        'P10
        '
        Me.P10.FontStyle = System.Drawing.FontStyle.Bold
        Me.P10.ForeColor = System.Drawing.Color.Black
        Me.P10.Text = "10"
        '
        'P11
        '
        Me.P11.FontStyle = System.Drawing.FontStyle.Bold
        Me.P11.ForeColor = System.Drawing.Color.Black
        Me.P11.Text = "11"
        '
        'P12
        '
        Me.P12.FontStyle = System.Drawing.FontStyle.Bold
        Me.P12.ForeColor = System.Drawing.Color.Black
        Me.P12.Text = "12"
        '
        'P13
        '
        Me.P13.FontStyle = System.Drawing.FontStyle.Bold
        Me.P13.ForeColor = System.Drawing.Color.Black
        Me.P13.Text = "13"
        '
        'semanaCbx
        '
        Me.semanaCbx.DisplayMember = "Text"
        Me.semanaCbx.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.semanaCbx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.semanaCbx.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.semanaCbx.ForeColor = System.Drawing.Color.Black
        Me.semanaCbx.FormattingEnabled = True
        Me.semanaCbx.ItemHeight = 21
        Me.semanaCbx.Items.AddRange(New Object() {Me.Sem1, Me.Sem2, Me.Sem3, Me.Sem4, Me.Sem5})
        Me.semanaCbx.Location = New System.Drawing.Point(170, 335)
        Me.semanaCbx.Name = "semanaCbx"
        Me.semanaCbx.Size = New System.Drawing.Size(130, 27)
        Me.semanaCbx.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.semanaCbx.TabIndex = 8
        '
        'Sem1
        '
        Me.Sem1.FontStyle = System.Drawing.FontStyle.Bold
        Me.Sem1.ForeColor = System.Drawing.Color.Black
        Me.Sem1.Text = "1"
        '
        'Sem2
        '
        Me.Sem2.FontStyle = System.Drawing.FontStyle.Bold
        Me.Sem2.ForeColor = System.Drawing.Color.Black
        Me.Sem2.Text = "2"
        '
        'Sem3
        '
        Me.Sem3.FontStyle = System.Drawing.FontStyle.Bold
        Me.Sem3.ForeColor = System.Drawing.Color.Black
        Me.Sem3.Text = "3"
        '
        'Sem4
        '
        Me.Sem4.FontStyle = System.Drawing.FontStyle.Bold
        Me.Sem4.ForeColor = System.Drawing.Color.Black
        Me.Sem4.Text = "4"
        '
        'Sem5
        '
        Me.Sem5.FontStyle = System.Drawing.FontStyle.Bold
        Me.Sem5.ForeColor = System.Drawing.Color.Black
        Me.Sem5.Text = "5"
        '
        'LabelTurno
        '
        Me.LabelTurno.AutoSize = True
        Me.LabelTurno.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelTurno.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelTurno.Font = New System.Drawing.Font("Segoe UI Semibold", 11.0!, System.Drawing.FontStyle.Bold)
        Me.LabelTurno.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.LabelTurno.Location = New System.Drawing.Point(29, 375)
        Me.LabelTurno.Name = "LabelTurno"
        Me.LabelTurno.Size = New System.Drawing.Size(46, 22)
        Me.LabelTurno.TabIndex = 11
        Me.LabelTurno.Text = "Turno (Despachador)"
        Me.LabelTurno.Visible = True
        '
        'turnoCbx
        '
        Me.turnoCbx.DisplayMember = "Text"
        Me.turnoCbx.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.turnoCbx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.turnoCbx.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.turnoCbx.ForeColor = System.Drawing.Color.Black
        Me.turnoCbx.FormattingEnabled = True
        Me.turnoCbx.ItemHeight = 21
        Me.turnoCbx.Location = New System.Drawing.Point(29, 400)
        Me.turnoCbx.Name = "turnoCbx"
        Me.turnoCbx.Size = New System.Drawing.Size(280, 27)
        Me.turnoCbx.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.turnoCbx.TabIndex = 9
        Me.turnoCbx.Visible = True
        '
        'LabelOdometro
        '
        Me.LabelOdometro.AutoSize = True
        Me.LabelOdometro.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelOdometro.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelOdometro.Font = New System.Drawing.Font("Segoe UI Semibold", 11.0!, System.Drawing.FontStyle.Bold)
        Me.LabelOdometro.ForeColor = System.Drawing.Color.FromArgb(CType(CType(80, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.LabelOdometro.Location = New System.Drawing.Point(29, 435)
        Me.LabelOdometro.Name = "LabelOdometro"
        Me.LabelOdometro.Size = New System.Drawing.Size(200, 22)
        Me.LabelOdometro.TabIndex = 12
        Me.LabelOdometro.Text = "Odometro Inicio (gal)"
        Me.LabelOdometro.Visible = True
        '
        'odometroTbx
        '
        Me.odometroTbx.BackColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(75, Byte), Integer), CType(CType(130, Byte), Integer))
        '
        '
        '
        Me.odometroTbx.Border.BackColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(75, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.odometroTbx.Border.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(75, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.odometroTbx.Border.BorderBottomWidth = 2
        Me.odometroTbx.Border.BorderColor = System.Drawing.Color.FromArgb(CType(CType(80, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.odometroTbx.Border.BorderLeftWidth = 2
        Me.odometroTbx.Border.BorderRightWidth = 2
        Me.odometroTbx.Border.BorderTopWidth = 2
        Me.odometroTbx.Border.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.odometroTbx.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(70, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.odometroTbx.FocusHighlightEnabled = True
        Me.odometroTbx.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold)
        Me.odometroTbx.ForeColor = System.Drawing.Color.FromArgb(CType(CType(80, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.odometroTbx.Location = New System.Drawing.Point(29, 458)
        Me.odometroTbx.Name = "odometroTbx"
        Me.odometroTbx.PreventEnterBeep = True
        Me.odometroTbx.Size = New System.Drawing.Size(280, 32)
        Me.odometroTbx.TabIndex = 10
        Me.odometroTbx.Visible = True
        '
        'login
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(22, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(397, 630)
        Me.Controls.Add(Me.PanelP)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "login"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "EMTRACC - Inicio de Sesión"
        Me.PanelP.ResumeLayout(False)
        Me.PanelP.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelP As Panel
    Friend WithEvents LabelTitulo As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelSubtitulo As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelUsuario As DevComponents.DotNetBar.LabelX
    Friend WithEvents usuarioTbx As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelClave As DevComponents.DotNetBar.LabelX
    Friend WithEvents claveTbx As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents verClaveBtn As DevComponents.DotNetBar.ButtonX
    Friend WithEvents ingresarBtn As DevComponents.DotNetBar.ButtonX
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents LabelPeriodo As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelSemana As DevComponents.DotNetBar.LabelX
    Friend WithEvents periodoCbx As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents semanaCbx As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents P1 As DevComponents.Editors.ComboItem
    Friend WithEvents P2 As DevComponents.Editors.ComboItem
    Friend WithEvents P3 As DevComponents.Editors.ComboItem
    Friend WithEvents P4 As DevComponents.Editors.ComboItem
    Friend WithEvents P5 As DevComponents.Editors.ComboItem
    Friend WithEvents P6 As DevComponents.Editors.ComboItem
    Friend WithEvents P7 As DevComponents.Editors.ComboItem
    Friend WithEvents P8 As DevComponents.Editors.ComboItem
    Friend WithEvents P9 As DevComponents.Editors.ComboItem
    Friend WithEvents P10 As DevComponents.Editors.ComboItem
    Friend WithEvents P11 As DevComponents.Editors.ComboItem
    Friend WithEvents P12 As DevComponents.Editors.ComboItem
    Friend WithEvents P13 As DevComponents.Editors.ComboItem
    Friend WithEvents Sem1 As DevComponents.Editors.ComboItem
    Friend WithEvents Sem2 As DevComponents.Editors.ComboItem
    Friend WithEvents Sem3 As DevComponents.Editors.ComboItem
    Friend WithEvents Sem4 As DevComponents.Editors.ComboItem
    Friend WithEvents Sem5 As DevComponents.Editors.ComboItem
    Friend WithEvents LabelTurno As DevComponents.DotNetBar.LabelX
    Friend WithEvents turnoCbx As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents LabelOdometro As DevComponents.DotNetBar.LabelX
    Friend WithEvents odometroTbx As DevComponents.DotNetBar.Controls.TextBoxX
End Class
