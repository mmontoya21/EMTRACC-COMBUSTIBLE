<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class acceso
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.CancelarBtn = New DevComponents.DotNetBar.ButtonX()
        Me.EliminarBtn = New DevComponents.DotNetBar.ButtonX()
        Me.EditarBtn = New DevComponents.DotNetBar.ButtonX()
        Me.NuevoBtn = New DevComponents.DotNetBar.ButtonX()
        Me.GuardarBtn = New DevComponents.DotNetBar.ButtonX()
        Me.ModificarBtn = New DevComponents.DotNetBar.ButtonX()
        Me.PanelP = New System.Windows.Forms.Panel()
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX10 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX8 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.ApelTbx = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.nombTbx = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX7 = New DevComponents.DotNetBar.LabelX()
        Me.clavTbx = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.usuaTbx = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.tipoTbx = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.statTbx = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.ACTIVO = New DevComponents.Editors.ComboItem()
        Me.INACTIVO = New DevComponents.Editors.ComboItem()
        Me.Admin = New DevComponents.Editors.ComboItem()
        Me.Sup = New DevComponents.Editors.ComboItem()
        Me.Age = New DevComponents.Editors.ComboItem()
        Me.Vis = New DevComponents.Editors.ComboItem()
        Me.Cont = New DevComponents.Editors.ComboItem()
        Me.fechDpk = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.CamDGV = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.buscartxt = New DevComponents.DotNetBar.LabelX()
        Me.ButtonX1 = New DevComponents.DotNetBar.ButtonX()
        Me.PanelP.SuspendLayout()
        CType(Me.fechDpk, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CamDGV, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'CancelarBtn
        '
        Me.CancelarBtn.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.CancelarBtn.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.CancelarBtn.Location = New System.Drawing.Point(643, 12)
        Me.CancelarBtn.Name = "CancelarBtn"
        Me.CancelarBtn.Size = New System.Drawing.Size(82, 40)
        Me.CancelarBtn.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.CancelarBtn.Symbol = ""
        Me.CancelarBtn.SymbolSize = 12.0!
        Me.CancelarBtn.TabIndex = 26
        Me.CancelarBtn.Text = "Cancelar"
        '
        'EliminarBtn
        '
        Me.EliminarBtn.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.EliminarBtn.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.EliminarBtn.Location = New System.Drawing.Point(555, 12)
        Me.EliminarBtn.Name = "EliminarBtn"
        Me.EliminarBtn.Size = New System.Drawing.Size(82, 40)
        Me.EliminarBtn.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.EliminarBtn.Symbol = ""
        Me.EliminarBtn.SymbolColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.EliminarBtn.SymbolSize = 12.0!
        Me.EliminarBtn.TabIndex = 25
        Me.EliminarBtn.Text = "Eliminar"
        '
        'EditarBtn
        '
        Me.EditarBtn.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.EditarBtn.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.EditarBtn.Location = New System.Drawing.Point(116, 11)
        Me.EditarBtn.Name = "EditarBtn"
        Me.EditarBtn.Size = New System.Drawing.Size(82, 40)
        Me.EditarBtn.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.EditarBtn.Symbol = ""
        Me.EditarBtn.SymbolSize = 12.0!
        Me.EditarBtn.TabIndex = 23
        Me.EditarBtn.Text = "Editar"
        '
        'NuevoBtn
        '
        Me.NuevoBtn.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.NuevoBtn.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.NuevoBtn.Location = New System.Drawing.Point(28, 11)
        Me.NuevoBtn.Name = "NuevoBtn"
        Me.NuevoBtn.Size = New System.Drawing.Size(82, 38)
        Me.NuevoBtn.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.NuevoBtn.Symbol = ""
        Me.NuevoBtn.SymbolSize = 12.0!
        Me.NuevoBtn.TabIndex = 22
        Me.NuevoBtn.Text = " Nuevo"
        '
        'GuardarBtn
        '
        Me.GuardarBtn.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.GuardarBtn.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.GuardarBtn.Location = New System.Drawing.Point(204, 11)
        Me.GuardarBtn.Name = "GuardarBtn"
        Me.GuardarBtn.Size = New System.Drawing.Size(82, 40)
        Me.GuardarBtn.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.GuardarBtn.Symbol = ""
        Me.GuardarBtn.SymbolColor = System.Drawing.Color.Green
        Me.GuardarBtn.SymbolSize = 12.0!
        Me.GuardarBtn.TabIndex = 24
        Me.GuardarBtn.Text = "Guardar"
        '
        'ModificarBtn
        '
        Me.ModificarBtn.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ModificarBtn.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ModificarBtn.Location = New System.Drawing.Point(204, 12)
        Me.ModificarBtn.Name = "ModificarBtn"
        Me.ModificarBtn.Size = New System.Drawing.Size(82, 38)
        Me.ModificarBtn.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ModificarBtn.Symbol = ""
        Me.ModificarBtn.SymbolSize = 12.0!
        Me.ModificarBtn.TabIndex = 27
        Me.ModificarBtn.Text = "Modificar"
        '
        'PanelP
        '
        Me.PanelP.Controls.Add(Me.ButtonX1)
        Me.PanelP.Controls.Add(Me.fechDpk)
        Me.PanelP.Controls.Add(Me.statTbx)
        Me.PanelP.Controls.Add(Me.tipoTbx)
        Me.PanelP.Controls.Add(Me.LabelX4)
        Me.PanelP.Controls.Add(Me.LabelX10)
        Me.PanelP.Controls.Add(Me.LabelX3)
        Me.PanelP.Controls.Add(Me.LabelX8)
        Me.PanelP.Controls.Add(Me.LabelX2)
        Me.PanelP.Controls.Add(Me.ApelTbx)
        Me.PanelP.Controls.Add(Me.nombTbx)
        Me.PanelP.Controls.Add(Me.LabelX7)
        Me.PanelP.Controls.Add(Me.clavTbx)
        Me.PanelP.Controls.Add(Me.LabelX1)
        Me.PanelP.Controls.Add(Me.usuaTbx)
        Me.PanelP.Location = New System.Drawing.Point(25, 75)
        Me.PanelP.Name = "PanelP"
        Me.PanelP.Size = New System.Drawing.Size(700, 166)
        Me.PanelP.TabIndex = 30
        '
        'LabelX4
        '
        '
        '
        '
        Me.LabelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX4.Font = New System.Drawing.Font("Comic Sans MS", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX4.Location = New System.Drawing.Point(13, 118)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Size = New System.Drawing.Size(77, 23)
        Me.LabelX4.TabIndex = 30
        Me.LabelX4.Text = "Tipo"
        Me.LabelX4.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'LabelX10
        '
        '
        '
        '
        Me.LabelX10.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX10.Font = New System.Drawing.Font("Comic Sans MS", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX10.Location = New System.Drawing.Point(309, 56)
        Me.LabelX10.Name = "LabelX10"
        Me.LabelX10.Size = New System.Drawing.Size(83, 23)
        Me.LabelX10.TabIndex = 30
        Me.LabelX10.Text = "Clave"
        Me.LabelX10.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'LabelX3
        '
        '
        '
        '
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX3.Font = New System.Drawing.Font("Comic Sans MS", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX3.Location = New System.Drawing.Point(13, 56)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(77, 23)
        Me.LabelX3.TabIndex = 30
        Me.LabelX3.Text = "Usuario"
        Me.LabelX3.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'LabelX8
        '
        '
        '
        '
        Me.LabelX8.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX8.Font = New System.Drawing.Font("Comic Sans MS", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX8.Location = New System.Drawing.Point(309, 116)
        Me.LabelX8.Name = "LabelX8"
        Me.LabelX8.Size = New System.Drawing.Size(83, 23)
        Me.LabelX8.TabIndex = 31
        Me.LabelX8.Text = "Estatus"
        Me.LabelX8.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'LabelX2
        '
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.Font = New System.Drawing.Font("Comic Sans MS", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX2.Location = New System.Drawing.Point(13, 90)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(77, 23)
        Me.LabelX2.TabIndex = 31
        Me.LabelX2.Text = "Fecha"
        Me.LabelX2.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'ApelTbx
        '
        '
        '
        '
        Me.ApelTbx.Border.Class = "TextBoxBorder"
        Me.ApelTbx.Border.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.ApelTbx.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.ApelTbx.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ApelTbx.Location = New System.Drawing.Point(398, 13)
        Me.ApelTbx.MaxLength = 30
        Me.ApelTbx.Name = "ApelTbx"
        Me.ApelTbx.PreventEnterBeep = True
        Me.ApelTbx.Size = New System.Drawing.Size(173, 30)
        Me.ApelTbx.TabIndex = 1
        '
        'nombTbx
        '
        '
        '
        '
        Me.nombTbx.Border.Class = "TextBoxBorder"
        Me.nombTbx.Border.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.nombTbx.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.nombTbx.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nombTbx.Location = New System.Drawing.Point(96, 13)
        Me.nombTbx.MaxLength = 30
        Me.nombTbx.Name = "nombTbx"
        Me.nombTbx.PreventEnterBeep = True
        Me.nombTbx.Size = New System.Drawing.Size(173, 30)
        Me.nombTbx.TabIndex = 0
        '
        'LabelX7
        '
        '
        '
        '
        Me.LabelX7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX7.Font = New System.Drawing.Font("Comic Sans MS", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX7.Location = New System.Drawing.Point(309, 18)
        Me.LabelX7.Name = "LabelX7"
        Me.LabelX7.Size = New System.Drawing.Size(83, 23)
        Me.LabelX7.TabIndex = 31
        Me.LabelX7.Text = "Apellido"
        Me.LabelX7.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'clavTbx
        '
        '
        '
        '
        Me.clavTbx.Border.Class = "TextBoxBorder"
        Me.clavTbx.Border.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.clavTbx.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.clavTbx.Location = New System.Drawing.Point(398, 49)
        Me.clavTbx.MaxLength = 200
        Me.clavTbx.Name = "clavTbx"
        Me.clavTbx.PreventEnterBeep = True
        Me.clavTbx.Size = New System.Drawing.Size(207, 30)
        Me.clavTbx.TabIndex = 3
        Me.clavTbx.UseSystemPasswordChar = True
        '
        'LabelX1
        '
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Font = New System.Drawing.Font("Comic Sans MS", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX1.Location = New System.Drawing.Point(13, 18)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(77, 23)
        Me.LabelX1.TabIndex = 31
        Me.LabelX1.Text = "Nombre"
        Me.LabelX1.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'usuaTbx
        '
        '
        '
        '
        Me.usuaTbx.Border.Class = "TextBoxBorder"
        Me.usuaTbx.Border.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.usuaTbx.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.usuaTbx.Location = New System.Drawing.Point(96, 49)
        Me.usuaTbx.MaxLength = 20
        Me.usuaTbx.Name = "usuaTbx"
        Me.usuaTbx.PreventEnterBeep = True
        Me.usuaTbx.Size = New System.Drawing.Size(207, 30)
        Me.usuaTbx.TabIndex = 2
        '
        'tipoTbx
        '
        Me.tipoTbx.DisplayMember = "Text"
        Me.tipoTbx.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.tipoTbx.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tipoTbx.FormattingEnabled = True
        Me.tipoTbx.ItemHeight = 20
        Me.tipoTbx.Items.AddRange(New Object() {Me.Admin, Me.Sup, Me.Age, Me.Vis, Me.Cont})
        Me.tipoTbx.Location = New System.Drawing.Point(96, 119)
        Me.tipoTbx.MaxLength = 20
        Me.tipoTbx.Name = "tipoTbx"
        Me.tipoTbx.Size = New System.Drawing.Size(207, 26)
        Me.tipoTbx.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.tipoTbx.TabIndex = 5
        '
        'statTbx
        '
        Me.statTbx.DisplayMember = "Text"
        Me.statTbx.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.statTbx.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.statTbx.FormattingEnabled = True
        Me.statTbx.ItemHeight = 20
        Me.statTbx.Items.AddRange(New Object() {Me.ACTIVO, Me.INACTIVO})
        Me.statTbx.Location = New System.Drawing.Point(398, 119)
        Me.statTbx.MaxLength = 20
        Me.statTbx.Name = "statTbx"
        Me.statTbx.Size = New System.Drawing.Size(207, 26)
        Me.statTbx.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.statTbx.TabIndex = 6
        '
        'ACTIVO
        '
        Me.ACTIVO.FontStyle = System.Drawing.FontStyle.Bold
        Me.ACTIVO.ForeColor = System.Drawing.Color.Blue
        Me.ACTIVO.ImagePosition = System.Windows.Forms.HorizontalAlignment.Center
        Me.ACTIVO.Text = "ACTIVO"
        Me.ACTIVO.Value = "ACTIVO"
        '
        'INACTIVO
        '
        Me.INACTIVO.FontStyle = System.Drawing.FontStyle.Bold
        Me.INACTIVO.ForeColor = System.Drawing.Color.Red
        Me.INACTIVO.ImagePosition = System.Windows.Forms.HorizontalAlignment.Center
        Me.INACTIVO.Text = "INACTIVO"
        Me.INACTIVO.Value = "INACTIVO"
        '
        'Admin
        '
        Me.Admin.Text = "ADMINISTRADOR"
        '
        'Sup
        '
        Me.Sup.Text = "SUPERVISOR"
        '
        'Age
        '
        Me.Age.Text = "AGENTE"
        '
        'Vis
        '
        Me.Vis.Text = "VISOR"
        '
        'Cont
        '
        Me.Cont.Text = "CONTROL"
        '
        'fechDpk
        '
        '
        '
        '
        Me.fechDpk.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.fechDpk.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.fechDpk.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.fechDpk.ButtonDropDown.Visible = True
        Me.fechDpk.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fechDpk.IsPopupCalendarOpen = False
        Me.fechDpk.Location = New System.Drawing.Point(96, 86)
        '
        '
        '
        '
        '
        '
        Me.fechDpk.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.fechDpk.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.fechDpk.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.fechDpk.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.fechDpk.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.fechDpk.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.fechDpk.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.fechDpk.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.fechDpk.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.fechDpk.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.fechDpk.MonthCalendar.DisplayMonth = New Date(2024, 12, 1, 0, 0, 0, 0)
        '
        '
        '
        Me.fechDpk.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.fechDpk.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.fechDpk.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.fechDpk.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.fechDpk.MonthCalendar.TodayButtonVisible = True
        Me.fechDpk.Name = "fechDpk"
        Me.fechDpk.Size = New System.Drawing.Size(207, 26)
        Me.fechDpk.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.fechDpk.TabIndex = 4
        '
        'CamDGV
        '
        Me.CamDGV.AllowUserToAddRows = False
        Me.CamDGV.AllowUserToDeleteRows = False
        Me.CamDGV.BackgroundColor = System.Drawing.SystemColors.ActiveCaption
        Me.CamDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.CamDGV.DefaultCellStyle = DataGridViewCellStyle1
        Me.CamDGV.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.CamDGV.Location = New System.Drawing.Point(25, 281)
        Me.CamDGV.Name = "CamDGV"
        Me.CamDGV.ReadOnly = True
        Me.CamDGV.RowHeadersVisible = False
        Me.CamDGV.Size = New System.Drawing.Size(700, 243)
        Me.CamDGV.TabIndex = 31
        '
        'buscartxt
        '
        '
        '
        '
        Me.buscartxt.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.buscartxt.Location = New System.Drawing.Point(35, 252)
        Me.buscartxt.Name = "buscartxt"
        Me.buscartxt.Size = New System.Drawing.Size(75, 23)
        Me.buscartxt.TabIndex = 32
        Me.buscartxt.Text = "-"
        '
        'ButtonX1
        '
        Me.ButtonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX1.Location = New System.Drawing.Point(607, 49)
        Me.ButtonX1.Name = "ButtonX1"
        Me.ButtonX1.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor(4)
        Me.ButtonX1.Size = New System.Drawing.Size(33, 30)
        Me.ButtonX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonX1.Symbol = ""
        Me.ButtonX1.TabIndex = 32
        '
        'acceso
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.ClientSize = New System.Drawing.Size(737, 536)
        Me.Controls.Add(Me.buscartxt)
        Me.Controls.Add(Me.CamDGV)
        Me.Controls.Add(Me.PanelP)
        Me.Controls.Add(Me.CancelarBtn)
        Me.Controls.Add(Me.EliminarBtn)
        Me.Controls.Add(Me.EditarBtn)
        Me.Controls.Add(Me.NuevoBtn)
        Me.Controls.Add(Me.GuardarBtn)
        Me.Controls.Add(Me.ModificarBtn)
        Me.Name = "acceso"
        Me.Text = "acceso"
        Me.PanelP.ResumeLayout(False)
        CType(Me.fechDpk, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CamDGV, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents CancelarBtn As DevComponents.DotNetBar.ButtonX
    Friend WithEvents EliminarBtn As DevComponents.DotNetBar.ButtonX
    Friend WithEvents EditarBtn As DevComponents.DotNetBar.ButtonX
    Friend WithEvents NuevoBtn As DevComponents.DotNetBar.ButtonX
    Friend WithEvents GuardarBtn As DevComponents.DotNetBar.ButtonX
    Friend WithEvents ModificarBtn As DevComponents.DotNetBar.ButtonX
    Friend WithEvents PanelP As Panel
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX10 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX8 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents ApelTbx As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents nombTbx As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX7 As DevComponents.DotNetBar.LabelX
    Friend WithEvents clavTbx As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents usuaTbx As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents statTbx As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents ACTIVO As DevComponents.Editors.ComboItem
    Friend WithEvents INACTIVO As DevComponents.Editors.ComboItem
    Friend WithEvents tipoTbx As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents Admin As DevComponents.Editors.ComboItem
    Friend WithEvents Sup As DevComponents.Editors.ComboItem
    Friend WithEvents Age As DevComponents.Editors.ComboItem
    Friend WithEvents Vis As DevComponents.Editors.ComboItem
    Friend WithEvents Cont As DevComponents.Editors.ComboItem
    Friend WithEvents fechDpk As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents CamDGV As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents buscartxt As DevComponents.DotNetBar.LabelX
    Friend WithEvents ButtonX1 As DevComponents.DotNetBar.ButtonX
End Class
