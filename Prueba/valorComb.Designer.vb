<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class valorComb
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.CancelarBtn = New DevComponents.DotNetBar.ButtonX()
        Me.EliminarBtn = New DevComponents.DotNetBar.ButtonX()
        Me.EditarBtn = New DevComponents.DotNetBar.ButtonX()
        Me.NuevoBtn = New DevComponents.DotNetBar.ButtonX()
        Me.GuardarBtn = New DevComponents.DotNetBar.ButtonX()
        Me.ModificarBtn = New DevComponents.DotNetBar.ButtonX()
        Me.PanelP = New System.Windows.Forms.Panel()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.valorTb = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.descripcionTb = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.fechaDtp = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.CamDGV = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.buscartxt = New DevComponents.DotNetBar.LabelX()
        Me.LabelTitulo = New DevComponents.DotNetBar.LabelX()
        Me.LabelPrecioActual = New DevComponents.DotNetBar.LabelX()
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX()
        Me.activoChk = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.PanelP.SuspendLayout()
        CType(Me.fechaDtp, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CamDGV, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'CancelarBtn
        '
        Me.CancelarBtn.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.CancelarBtn.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.CancelarBtn.Font = New System.Drawing.Font("Comic Sans MS", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CancelarBtn.Location = New System.Drawing.Point(387, 12)
        Me.CancelarBtn.Name = "CancelarBtn"
        Me.CancelarBtn.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor(2, 2, 2, 10)
        Me.CancelarBtn.Size = New System.Drawing.Size(82, 33)
        Me.CancelarBtn.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.CancelarBtn.Symbol = ""
        Me.CancelarBtn.SymbolSize = 12.0!
        Me.CancelarBtn.TabIndex = 26
        Me.CancelarBtn.Text = "Cancelar"
        '
        'EliminarBtn
        '
        Me.EliminarBtn.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.EliminarBtn.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.EliminarBtn.Font = New System.Drawing.Font("Comic Sans MS", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EliminarBtn.Location = New System.Drawing.Point(298, 12)
        Me.EliminarBtn.Name = "EliminarBtn"
        Me.EliminarBtn.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor(2, 2, 10, 2)
        Me.EliminarBtn.Size = New System.Drawing.Size(83, 34)
        Me.EliminarBtn.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.EliminarBtn.Symbol = ""
        Me.EliminarBtn.SymbolColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.EliminarBtn.SymbolSize = 12.0!
        Me.EliminarBtn.TabIndex = 25
        Me.EliminarBtn.Text = "Eliminar"
        '
        'EditarBtn
        '
        Me.EditarBtn.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.EditarBtn.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.EditarBtn.Font = New System.Drawing.Font("Comic Sans MS", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EditarBtn.Location = New System.Drawing.Point(105, 12)
        Me.EditarBtn.Name = "EditarBtn"
        Me.EditarBtn.Size = New System.Drawing.Size(82, 33)
        Me.EditarBtn.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.EditarBtn.Symbol = ""
        Me.EditarBtn.SymbolSize = 12.0!
        Me.EditarBtn.TabIndex = 23
        Me.EditarBtn.Text = "Editar"
        '
        'NuevoBtn
        '
        Me.NuevoBtn.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.NuevoBtn.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.NuevoBtn.Font = New System.Drawing.Font("Comic Sans MS", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NuevoBtn.Location = New System.Drawing.Point(17, 12)
        Me.NuevoBtn.Name = "NuevoBtn"
        Me.NuevoBtn.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor(2, 2, 10, 2)
        Me.NuevoBtn.Size = New System.Drawing.Size(82, 33)
        Me.NuevoBtn.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.NuevoBtn.Symbol = ""
        Me.NuevoBtn.SymbolSize = 12.0!
        Me.NuevoBtn.TabIndex = 22
        Me.NuevoBtn.Text = " Nuevo"
        '
        'GuardarBtn
        '
        Me.GuardarBtn.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.GuardarBtn.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.GuardarBtn.Font = New System.Drawing.Font("Comic Sans MS", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GuardarBtn.Location = New System.Drawing.Point(193, 12)
        Me.GuardarBtn.Name = "GuardarBtn"
        Me.GuardarBtn.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor(2, 2, 2, 10)
        Me.GuardarBtn.Size = New System.Drawing.Size(95, 33)
        Me.GuardarBtn.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.GuardarBtn.Symbol = ""
        Me.GuardarBtn.SymbolColor = System.Drawing.Color.Green
        Me.GuardarBtn.SymbolSize = 12.0!
        Me.GuardarBtn.TabIndex = 24
        Me.GuardarBtn.Text = "Guardar"
        '
        'ModificarBtn
        '
        Me.ModificarBtn.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ModificarBtn.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ModificarBtn.Font = New System.Drawing.Font("Comic Sans MS", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ModificarBtn.Location = New System.Drawing.Point(192, 12)
        Me.ModificarBtn.Name = "ModificarBtn"
        Me.ModificarBtn.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor(2, 2, 2, 10)
        Me.ModificarBtn.Size = New System.Drawing.Size(95, 33)
        Me.ModificarBtn.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ModificarBtn.Symbol = ""
        Me.ModificarBtn.SymbolSize = 12.0!
        Me.ModificarBtn.TabIndex = 27
        Me.ModificarBtn.Text = "Modificar"
        '
        'PanelP
        '
        Me.PanelP.Controls.Add(Me.fechaDtp)
        Me.PanelP.Controls.Add(Me.LabelX1)
        Me.PanelP.Controls.Add(Me.LabelX2)
        Me.PanelP.Controls.Add(Me.LabelX3)
        Me.PanelP.Controls.Add(Me.LabelX4)
        Me.PanelP.Controls.Add(Me.valorTb)
        Me.PanelP.Controls.Add(Me.descripcionTb)
        Me.PanelP.Controls.Add(Me.activoChk)
        Me.PanelP.Location = New System.Drawing.Point(12, 95)
        Me.PanelP.Name = "PanelP"
        Me.PanelP.Size = New System.Drawing.Size(640, 140)
        Me.PanelP.TabIndex = 30
        '
        'LabelX1
        '
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Font = New System.Drawing.Font("Comic Sans MS", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX1.ForeColor = System.Drawing.Color.DarkBlue
        Me.LabelX1.Location = New System.Drawing.Point(15, 10)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(140, 23)
        Me.LabelX1.TabIndex = 30
        Me.LabelX1.Text = "Valor Combustible"
        '
        'LabelX2
        '
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.Font = New System.Drawing.Font("Comic Sans MS", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX2.ForeColor = System.Drawing.Color.DarkBlue
        Me.LabelX2.Location = New System.Drawing.Point(320, 10)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(60, 23)
        Me.LabelX2.TabIndex = 31
        Me.LabelX2.Text = "Fecha"
        '
        'LabelX3
        '
        '
        '
        '
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX3.Font = New System.Drawing.Font("Comic Sans MS", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX3.ForeColor = System.Drawing.Color.DarkBlue
        Me.LabelX3.Location = New System.Drawing.Point(15, 75)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(100, 23)
        Me.LabelX3.TabIndex = 32
        Me.LabelX3.Text = "Descripcion"
        '
        'valorTb
        '
        Me.valorTb.AcceptsTab = True
        Me.valorTb.BackColor = System.Drawing.Color.SteelBlue
        '
        '
        '
        Me.valorTb.Border.BackColor = System.Drawing.Color.SteelBlue
        Me.valorTb.Border.BackColor2 = System.Drawing.Color.SteelBlue
        Me.valorTb.Border.BorderBottomWidth = 2
        Me.valorTb.Border.BorderColor = System.Drawing.Color.White
        Me.valorTb.Border.BorderLeftWidth = 2
        Me.valorTb.Border.BorderRightWidth = 2
        Me.valorTb.Border.BorderTopWidth = 2
        Me.valorTb.Border.Class = "TextBoxBorder"
        Me.valorTb.Border.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.valorTb.FocusHighlightColor = System.Drawing.Color.Yellow
        Me.valorTb.FocusHighlightEnabled = True
        Me.valorTb.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.valorTb.ForeColor = System.Drawing.Color.Black
        Me.valorTb.Location = New System.Drawing.Point(15, 35)
        Me.valorTb.MaxLength = 15
        Me.valorTb.Name = "valorTb"
        Me.valorTb.PreventEnterBeep = True
        Me.valorTb.Size = New System.Drawing.Size(180, 34)
        Me.valorTb.TabIndex = 0
        Me.valorTb.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'descripcionTb
        '
        Me.descripcionTb.AcceptsTab = True
        Me.descripcionTb.BackColor = System.Drawing.Color.SteelBlue
        '
        '
        '
        Me.descripcionTb.Border.BackColor = System.Drawing.Color.SteelBlue
        Me.descripcionTb.Border.BackColor2 = System.Drawing.Color.SteelBlue
        Me.descripcionTb.Border.BorderBottomWidth = 2
        Me.descripcionTb.Border.BorderColor = System.Drawing.Color.White
        Me.descripcionTb.Border.BorderLeftWidth = 2
        Me.descripcionTb.Border.BorderRightWidth = 2
        Me.descripcionTb.Border.BorderTopWidth = 2
        Me.descripcionTb.Border.Class = "TextBoxBorder"
        Me.descripcionTb.Border.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.descripcionTb.FocusHighlightColor = System.Drawing.Color.Yellow
        Me.descripcionTb.FocusHighlightEnabled = True
        Me.descripcionTb.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.descripcionTb.ForeColor = System.Drawing.Color.Black
        Me.descripcionTb.Location = New System.Drawing.Point(15, 100)
        Me.descripcionTb.MaxLength = 100
        Me.descripcionTb.Name = "descripcionTb"
        Me.descripcionTb.PreventEnterBeep = True
        Me.descripcionTb.Size = New System.Drawing.Size(610, 34)
        Me.descripcionTb.TabIndex = 2
        '
        'fechaDtp
        '
        '
        '
        '
        Me.fechaDtp.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.fechaDtp.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.fechaDtp.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.fechaDtp.ButtonDropDown.Visible = True
        Me.fechaDtp.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fechaDtp.Format = DevComponents.Editors.eDateTimePickerFormat.Short
        Me.fechaDtp.IsPopupCalendarOpen = False
        Me.fechaDtp.Location = New System.Drawing.Point(320, 35)
        '
        '
        '
        '
        '
        '
        Me.fechaDtp.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.fechaDtp.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.fechaDtp.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.fechaDtp.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.fechaDtp.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.fechaDtp.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.fechaDtp.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.fechaDtp.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.fechaDtp.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.fechaDtp.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.fechaDtp.MonthCalendar.DisplayMonth = New Date(2025, 1, 1, 0, 0, 0, 0)
        '
        '
        '
        Me.fechaDtp.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.fechaDtp.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.fechaDtp.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.fechaDtp.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.fechaDtp.MonthCalendar.TodayButtonVisible = True
        Me.fechaDtp.Name = "fechaDtp"
        Me.fechaDtp.Size = New System.Drawing.Size(180, 29)
        Me.fechaDtp.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.fechaDtp.TabIndex = 1
        '
        'LabelX4
        '
        '
        '
        '
        Me.LabelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX4.Font = New System.Drawing.Font("Comic Sans MS", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX4.ForeColor = System.Drawing.Color.DarkBlue
        Me.LabelX4.Location = New System.Drawing.Point(520, 10)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Size = New System.Drawing.Size(60, 23)
        Me.LabelX4.TabIndex = 35
        Me.LabelX4.Text = "Activo"
        '
        'activoChk
        '
        Me.activoChk.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.activoChk.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.activoChk.Checked = True
        Me.activoChk.CheckState = System.Windows.Forms.CheckState.Checked
        Me.activoChk.CheckValue = "Y"
        Me.activoChk.Font = New System.Drawing.Font("Comic Sans MS", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.activoChk.ForeColor = System.Drawing.Color.DarkBlue
        Me.activoChk.Location = New System.Drawing.Point(520, 35)
        Me.activoChk.Name = "activoChk"
        Me.activoChk.Size = New System.Drawing.Size(100, 30)
        Me.activoChk.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.activoChk.TabIndex = 36
        Me.activoChk.Text = "Si"
        '
        'CamDGV
        '
        Me.CamDGV.AllowUserToAddRows = False
        Me.CamDGV.AllowUserToDeleteRows = False
        Me.CamDGV.AllowUserToOrderColumns = True
        Me.CamDGV.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.CamDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Comic Sans MS", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.CamDGV.DefaultCellStyle = DataGridViewCellStyle1
        Me.CamDGV.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.CamDGV.Location = New System.Drawing.Point(12, 280)
        Me.CamDGV.Name = "CamDGV"
        Me.CamDGV.ReadOnly = True
        Me.CamDGV.RowHeadersVisible = False
        Me.CamDGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.CamDGV.Size = New System.Drawing.Size(640, 200)
        Me.CamDGV.TabIndex = 31
        '
        'buscartxt
        '
        '
        '
        '
        Me.buscartxt.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.buscartxt.Font = New System.Drawing.Font("Comic Sans MS", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.buscartxt.ForeColor = System.Drawing.Color.White
        Me.buscartxt.Location = New System.Drawing.Point(12, 251)
        Me.buscartxt.Name = "buscartxt"
        Me.buscartxt.Size = New System.Drawing.Size(75, 23)
        Me.buscartxt.TabIndex = 32
        Me.buscartxt.Text = "-"
        '
        'LabelTitulo
        '
        '
        '
        '
        Me.LabelTitulo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelTitulo.Font = New System.Drawing.Font("Comic Sans MS", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelTitulo.ForeColor = System.Drawing.Color.DarkBlue
        Me.LabelTitulo.Location = New System.Drawing.Point(12, 55)
        Me.LabelTitulo.Name = "LabelTitulo"
        Me.LabelTitulo.Size = New System.Drawing.Size(280, 30)
        Me.LabelTitulo.TabIndex = 33
        Me.LabelTitulo.Text = "Gestion de Precio de Combustible"
        '
        'LabelPrecioActual
        '
        '
        '
        '
        Me.LabelPrecioActual.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelPrecioActual.Font = New System.Drawing.Font("Comic Sans MS", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelPrecioActual.ForeColor = System.Drawing.Color.Yellow
        Me.LabelPrecioActual.Location = New System.Drawing.Point(420, 55)
        Me.LabelPrecioActual.Name = "LabelPrecioActual"
        Me.LabelPrecioActual.Size = New System.Drawing.Size(232, 30)
        Me.LabelPrecioActual.TabIndex = 34
        Me.LabelPrecioActual.Text = "Precio Actual: L. 0.00"
        Me.LabelPrecioActual.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'valorComb
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.SteelBlue
        Me.ClientSize = New System.Drawing.Size(664, 491)
        Me.Controls.Add(Me.LabelPrecioActual)
        Me.Controls.Add(Me.LabelTitulo)
        Me.Controls.Add(Me.buscartxt)
        Me.Controls.Add(Me.CamDGV)
        Me.Controls.Add(Me.PanelP)
        Me.Controls.Add(Me.CancelarBtn)
        Me.Controls.Add(Me.EliminarBtn)
        Me.Controls.Add(Me.EditarBtn)
        Me.Controls.Add(Me.NuevoBtn)
        Me.Controls.Add(Me.GuardarBtn)
        Me.Controls.Add(Me.ModificarBtn)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "valorComb"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Valor de Combustible"
        Me.PanelP.ResumeLayout(False)
        CType(Me.fechaDtp, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents valorTb As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents descripcionTb As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents fechaDtp As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents CamDGV As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents buscartxt As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelTitulo As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelPrecioActual As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Friend WithEvents activoChk As DevComponents.DotNetBar.Controls.CheckBoxX
End Class
