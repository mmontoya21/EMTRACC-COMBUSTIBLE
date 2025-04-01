<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class factura
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(factura))
        Me.CancelarBtn = New DevComponents.DotNetBar.ButtonX()
        Me.EliminarBtn = New DevComponents.DotNetBar.ButtonX()
        Me.EditarBtn = New DevComponents.DotNetBar.ButtonX()
        Me.NuevoBtn = New DevComponents.DotNetBar.ButtonX()
        Me.GuardarBtn = New DevComponents.DotNetBar.ButtonX()
        Me.ModificarBtn = New DevComponents.DotNetBar.ButtonX()
        Me.PanelP = New System.Windows.Forms.Panel()
        Me.fechaPk = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.Line2 = New DevComponents.DotNetBar.Controls.Line()
        Me.Line1 = New DevComponents.DotNetBar.Controls.Line()
        Me.perSemCB = New System.Windows.Forms.ComboBox()
        Me.perMesCB = New System.Windows.Forms.ComboBox()
        Me.tipoPagTb = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.Contado = New DevComponents.Editors.ComboItem()
        Me.Credito = New DevComponents.Editors.ComboItem()
        Me.Tarjeta = New DevComponents.Editors.ComboItem()
        Me.Transferencia = New DevComponents.Editors.ComboItem()
        Me.ButtonX2 = New DevComponents.DotNetBar.ButtonX()
        Me.ButtonX1 = New DevComponents.DotNetBar.ButtonX()
        Me.LabelX18 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX17 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX19 = New DevComponents.DotNetBar.LabelX()
        Me.pLetras = New DevComponents.DotNetBar.LabelX()
        Me.LabelX11 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX16 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX10 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.tota2Tb = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.cant2Tb = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.facExeTb = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX5 = New DevComponents.DotNetBar.LabelX()
        Me.desc2Tb = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.facTotTb = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX8 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX12 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX9 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX6 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.comentaTb = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.empTb = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.tota1Tb = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.cant1Tb = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX13 = New DevComponents.DotNetBar.LabelX()
        Me.nFacTb = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX7 = New DevComponents.DotNetBar.LabelX()
        Me.desc1Tb = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.facCanTB = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.rtnTb = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.propTb = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.buscartxt = New DevComponents.DotNetBar.LabelX()
        Me.propBusqTB = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.placaBusqTB = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.ButtonX6 = New DevComponents.DotNetBar.ButtonX()
        Me.LabelX14 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX15 = New DevComponents.DotNetBar.LabelX()
        Me.ButtonX3 = New DevComponents.DotNetBar.ButtonX()
        Me.PreviaBtn = New DevComponents.DotNetBar.ButtonX()
        Me.CamDgv = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.ButtonX5 = New DevComponents.DotNetBar.ButtonX()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.PrintFactura = New System.Drawing.Printing.PrintDocument()
        Me.PrintPreviewFactura = New System.Windows.Forms.PrintPreviewDialog()
        Me.preUni1Tb = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.preUni2Tb = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.PanelP.SuspendLayout()
        CType(Me.fechaPk, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CamDgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'CancelarBtn
        '
        Me.CancelarBtn.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.CancelarBtn.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.CancelarBtn.Location = New System.Drawing.Point(535, 13)
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
        Me.EliminarBtn.Location = New System.Drawing.Point(447, 13)
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
        Me.EditarBtn.Location = New System.Drawing.Point(125, 12)
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
        Me.NuevoBtn.Location = New System.Drawing.Point(37, 12)
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
        Me.GuardarBtn.Location = New System.Drawing.Point(212, 12)
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
        Me.ModificarBtn.Location = New System.Drawing.Point(212, 13)
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
        Me.PanelP.Controls.Add(Me.preUni2Tb)
        Me.PanelP.Controls.Add(Me.preUni1Tb)
        Me.PanelP.Controls.Add(Me.fechaPk)
        Me.PanelP.Controls.Add(Me.Line2)
        Me.PanelP.Controls.Add(Me.Line1)
        Me.PanelP.Controls.Add(Me.perSemCB)
        Me.PanelP.Controls.Add(Me.perMesCB)
        Me.PanelP.Controls.Add(Me.tipoPagTb)
        Me.PanelP.Controls.Add(Me.ButtonX2)
        Me.PanelP.Controls.Add(Me.ButtonX1)
        Me.PanelP.Controls.Add(Me.LabelX18)
        Me.PanelP.Controls.Add(Me.LabelX17)
        Me.PanelP.Controls.Add(Me.LabelX19)
        Me.PanelP.Controls.Add(Me.pLetras)
        Me.PanelP.Controls.Add(Me.LabelX11)
        Me.PanelP.Controls.Add(Me.LabelX4)
        Me.PanelP.Controls.Add(Me.LabelX16)
        Me.PanelP.Controls.Add(Me.LabelX10)
        Me.PanelP.Controls.Add(Me.LabelX3)
        Me.PanelP.Controls.Add(Me.tota2Tb)
        Me.PanelP.Controls.Add(Me.cant2Tb)
        Me.PanelP.Controls.Add(Me.facExeTb)
        Me.PanelP.Controls.Add(Me.LabelX5)
        Me.PanelP.Controls.Add(Me.desc2Tb)
        Me.PanelP.Controls.Add(Me.facTotTb)
        Me.PanelP.Controls.Add(Me.LabelX8)
        Me.PanelP.Controls.Add(Me.LabelX12)
        Me.PanelP.Controls.Add(Me.LabelX9)
        Me.PanelP.Controls.Add(Me.LabelX6)
        Me.PanelP.Controls.Add(Me.LabelX2)
        Me.PanelP.Controls.Add(Me.comentaTb)
        Me.PanelP.Controls.Add(Me.empTb)
        Me.PanelP.Controls.Add(Me.tota1Tb)
        Me.PanelP.Controls.Add(Me.cant1Tb)
        Me.PanelP.Controls.Add(Me.LabelX13)
        Me.PanelP.Controls.Add(Me.nFacTb)
        Me.PanelP.Controls.Add(Me.LabelX7)
        Me.PanelP.Controls.Add(Me.desc1Tb)
        Me.PanelP.Controls.Add(Me.facCanTB)
        Me.PanelP.Controls.Add(Me.rtnTb)
        Me.PanelP.Controls.Add(Me.LabelX1)
        Me.PanelP.Controls.Add(Me.propTb)
        Me.PanelP.Location = New System.Drawing.Point(12, 116)
        Me.PanelP.Name = "PanelP"
        Me.PanelP.Size = New System.Drawing.Size(804, 523)
        Me.PanelP.TabIndex = 30
        '
        'fechaPk
        '
        '
        '
        '
        Me.fechaPk.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.fechaPk.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.fechaPk.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.fechaPk.ButtonDropDown.Visible = True
        Me.fechaPk.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fechaPk.IsPopupCalendarOpen = False
        Me.fechaPk.Location = New System.Drawing.Point(601, 17)
        '
        '
        '
        '
        '
        '
        Me.fechaPk.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.fechaPk.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.fechaPk.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.fechaPk.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.fechaPk.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.fechaPk.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.fechaPk.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.fechaPk.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.fechaPk.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.fechaPk.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.fechaPk.MonthCalendar.DisplayMonth = New Date(2025, 3, 1, 0, 0, 0, 0)
        '
        '
        '
        Me.fechaPk.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.fechaPk.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.fechaPk.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.fechaPk.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.fechaPk.MonthCalendar.TodayButtonVisible = True
        Me.fechaPk.Name = "fechaPk"
        Me.fechaPk.Size = New System.Drawing.Size(175, 26)
        Me.fechaPk.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.fechaPk.TabIndex = 41
        '
        'Line2
        '
        Me.Line2.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Line2.Location = New System.Drawing.Point(521, 167)
        Me.Line2.Name = "Line2"
        Me.Line2.Size = New System.Drawing.Size(264, 8)
        Me.Line2.TabIndex = 40
        Me.Line2.Text = "Line2"
        '
        'Line1
        '
        Me.Line1.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Line1.Location = New System.Drawing.Point(521, 90)
        Me.Line1.Name = "Line1"
        Me.Line1.Size = New System.Drawing.Size(264, 8)
        Me.Line1.TabIndex = 39
        Me.Line1.Text = "Line1"
        '
        'perSemCB
        '
        Me.perSemCB.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.perSemCB.FormattingEnabled = True
        Me.perSemCB.Items.AddRange(New Object() {"1", "2", "3", "4", "5"})
        Me.perSemCB.Location = New System.Drawing.Point(712, 135)
        Me.perSemCB.Name = "perSemCB"
        Me.perSemCB.Size = New System.Drawing.Size(64, 26)
        Me.perSemCB.TabIndex = 37
        '
        'perMesCB
        '
        Me.perMesCB.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.perMesCB.FormattingEnabled = True
        Me.perMesCB.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12"})
        Me.perMesCB.Location = New System.Drawing.Point(712, 103)
        Me.perMesCB.Name = "perMesCB"
        Me.perMesCB.Size = New System.Drawing.Size(64, 26)
        Me.perMesCB.TabIndex = 36
        '
        'tipoPagTb
        '
        Me.tipoPagTb.DisplayMember = "Text"
        Me.tipoPagTb.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.tipoPagTb.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tipoPagTb.FormattingEnabled = True
        Me.tipoPagTb.ItemHeight = 18
        Me.tipoPagTb.Items.AddRange(New Object() {Me.Contado, Me.Credito, Me.Tarjeta, Me.Transferencia})
        Me.tipoPagTb.Location = New System.Drawing.Point(603, 58)
        Me.tipoPagTb.Name = "tipoPagTb"
        Me.tipoPagTb.Size = New System.Drawing.Size(173, 24)
        Me.tipoPagTb.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.tipoPagTb.TabIndex = 35
        '
        'Contado
        '
        Me.Contado.FontSize = 10.0!
        Me.Contado.Text = "CONTADO"
        '
        'Credito
        '
        Me.Credito.FontSize = 10.0!
        Me.Credito.Text = "CREDITO"
        '
        'Tarjeta
        '
        Me.Tarjeta.FontSize = 10.0!
        Me.Tarjeta.Text = "TARJETA CREDITO"
        '
        'Transferencia
        '
        Me.Transferencia.FontSize = 10.0!
        Me.Transferencia.Text = "TRANSFERENCIA BANCARIA"
        '
        'ButtonX2
        '
        Me.ButtonX2.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX2.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX2.Location = New System.Drawing.Point(435, 50)
        Me.ButtonX2.Name = "ButtonX2"
        Me.ButtonX2.Size = New System.Drawing.Size(45, 30)
        Me.ButtonX2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonX2.Symbol = ""
        Me.ButtonX2.SymbolColor = System.Drawing.Color.Green
        Me.ButtonX2.TabIndex = 34
        '
        'ButtonX1
        '
        Me.ButtonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX1.Location = New System.Drawing.Point(42, 211)
        Me.ButtonX1.Name = "ButtonX1"
        Me.ButtonX1.Size = New System.Drawing.Size(43, 30)
        Me.ButtonX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonX1.Symbol = ""
        Me.ButtonX1.TabIndex = 33
        '
        'LabelX18
        '
        '
        '
        '
        Me.LabelX18.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX18.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX18.Location = New System.Drawing.Point(3, 315)
        Me.LabelX18.Name = "LabelX18"
        Me.LabelX18.Size = New System.Drawing.Size(86, 23)
        Me.LabelX18.TabIndex = 30
        Me.LabelX18.Text = "Comentario"
        Me.LabelX18.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'LabelX17
        '
        '
        '
        '
        Me.LabelX17.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX17.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX17.Location = New System.Drawing.Point(640, 186)
        Me.LabelX17.Name = "LabelX17"
        Me.LabelX17.Size = New System.Drawing.Size(54, 23)
        Me.LabelX17.TabIndex = 30
        Me.LabelX17.Text = "Total"
        '
        'LabelX19
        '
        '
        '
        '
        Me.LabelX19.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX19.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX19.Location = New System.Drawing.Point(11, 283)
        Me.LabelX19.Name = "LabelX19"
        Me.LabelX19.Size = New System.Drawing.Size(96, 23)
        Me.LabelX19.TabIndex = 30
        Me.LabelX19.Text = "Cantd. Letras:"
        Me.LabelX19.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'pLetras
        '
        '
        '
        '
        Me.pLetras.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.pLetras.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pLetras.ForeColor = System.Drawing.Color.Maroon
        Me.pLetras.Location = New System.Drawing.Point(109, 283)
        Me.pLetras.Name = "pLetras"
        Me.pLetras.Size = New System.Drawing.Size(676, 23)
        Me.pLetras.TabIndex = 30
        Me.pLetras.Text = "-"
        '
        'LabelX11
        '
        '
        '
        '
        Me.LabelX11.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX11.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX11.Location = New System.Drawing.Point(107, 186)
        Me.LabelX11.Name = "LabelX11"
        Me.LabelX11.Size = New System.Drawing.Size(78, 23)
        Me.LabelX11.TabIndex = 30
        Me.LabelX11.Text = "Cantidad"
        '
        'LabelX4
        '
        '
        '
        '
        Me.LabelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX4.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX4.Location = New System.Drawing.Point(630, 326)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Size = New System.Drawing.Size(72, 23)
        Me.LabelX4.TabIndex = 30
        Me.LabelX4.Text = "Cantidad"
        '
        'LabelX16
        '
        '
        '
        '
        Me.LabelX16.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX16.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX16.Location = New System.Drawing.Point(222, 186)
        Me.LabelX16.Name = "LabelX16"
        Me.LabelX16.Size = New System.Drawing.Size(114, 23)
        Me.LabelX16.TabIndex = 30
        Me.LabelX16.Text = "Descripción"
        '
        'LabelX10
        '
        '
        '
        '
        Me.LabelX10.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX10.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX10.Location = New System.Drawing.Point(42, 121)
        Me.LabelX10.Name = "LabelX10"
        Me.LabelX10.Size = New System.Drawing.Size(54, 23)
        Me.LabelX10.TabIndex = 30
        Me.LabelX10.Text = "RTN"
        Me.LabelX10.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'LabelX3
        '
        '
        '
        '
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX3.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX3.Location = New System.Drawing.Point(14, 84)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(82, 23)
        Me.LabelX3.TabIndex = 30
        Me.LabelX3.Text = "Propietario"
        Me.LabelX3.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'tota2Tb
        '
        '
        '
        '
        Me.tota2Tb.Border.Class = "TextBoxBorder"
        Me.tota2Tb.Border.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.tota2Tb.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tota2Tb.Location = New System.Drawing.Point(612, 247)
        Me.tota2Tb.MaxLength = 6
        Me.tota2Tb.Name = "tota2Tb"
        Me.tota2Tb.PreventEnterBeep = True
        Me.tota2Tb.Size = New System.Drawing.Size(173, 30)
        Me.tota2Tb.TabIndex = 29
        '
        'cant2Tb
        '
        '
        '
        '
        Me.cant2Tb.Border.Class = "TextBoxBorder"
        Me.cant2Tb.Border.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.cant2Tb.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cant2Tb.Location = New System.Drawing.Point(91, 247)
        Me.cant2Tb.MaxLength = 6
        Me.cant2Tb.Name = "cant2Tb"
        Me.cant2Tb.PreventEnterBeep = True
        Me.cant2Tb.Size = New System.Drawing.Size(94, 30)
        Me.cant2Tb.TabIndex = 29
        '
        'facExeTb
        '
        '
        '
        '
        Me.facExeTb.Border.Class = "TextBoxBorder"
        Me.facExeTb.Border.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.facExeTb.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.facExeTb.Location = New System.Drawing.Point(626, 406)
        Me.facExeTb.MaxLength = 20
        Me.facExeTb.Name = "facExeTb"
        Me.facExeTb.PreventEnterBeep = True
        Me.facExeTb.Size = New System.Drawing.Size(112, 30)
        Me.facExeTb.TabIndex = 29
        '
        'LabelX5
        '
        '
        '
        '
        Me.LabelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX5.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX5.Location = New System.Drawing.Point(631, 386)
        Me.LabelX5.Name = "LabelX5"
        Me.LabelX5.Size = New System.Drawing.Size(54, 23)
        Me.LabelX5.TabIndex = 31
        Me.LabelX5.Text = "Exento"
        '
        'desc2Tb
        '
        '
        '
        '
        Me.desc2Tb.Border.Class = "TextBoxBorder"
        Me.desc2Tb.Border.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.desc2Tb.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.desc2Tb.Location = New System.Drawing.Point(196, 247)
        Me.desc2Tb.MaxLength = 45
        Me.desc2Tb.Name = "desc2Tb"
        Me.desc2Tb.PreventEnterBeep = True
        Me.desc2Tb.Size = New System.Drawing.Size(284, 30)
        Me.desc2Tb.TabIndex = 29
        '
        'facTotTb
        '
        '
        '
        '
        Me.facTotTb.Border.Class = "TextBoxBorder"
        Me.facTotTb.Border.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.facTotTb.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.facTotTb.Location = New System.Drawing.Point(626, 471)
        Me.facTotTb.MaxLength = 20
        Me.facTotTb.Name = "facTotTb"
        Me.facTotTb.PreventEnterBeep = True
        Me.facTotTb.Size = New System.Drawing.Size(112, 30)
        Me.facTotTb.TabIndex = 29
        '
        'LabelX8
        '
        '
        '
        '
        Me.LabelX8.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX8.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX8.Location = New System.Drawing.Point(632, 446)
        Me.LabelX8.Name = "LabelX8"
        Me.LabelX8.Size = New System.Drawing.Size(54, 23)
        Me.LabelX8.TabIndex = 31
        Me.LabelX8.Text = "Total"
        '
        'LabelX12
        '
        '
        '
        '
        Me.LabelX12.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX12.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX12.Location = New System.Drawing.Point(620, 138)
        Me.LabelX12.Name = "LabelX12"
        Me.LabelX12.Size = New System.Drawing.Size(86, 23)
        Me.LabelX12.TabIndex = 31
        Me.LabelX12.Text = "Semana"
        Me.LabelX12.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'LabelX9
        '
        '
        '
        '
        Me.LabelX9.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX9.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX9.Location = New System.Drawing.Point(620, 104)
        Me.LabelX9.Name = "LabelX9"
        Me.LabelX9.Size = New System.Drawing.Size(86, 23)
        Me.LabelX9.TabIndex = 31
        Me.LabelX9.Text = "Mes"
        Me.LabelX9.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'LabelX6
        '
        '
        '
        '
        Me.LabelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX6.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX6.Location = New System.Drawing.Point(511, 103)
        Me.LabelX6.Name = "LabelX6"
        Me.LabelX6.Size = New System.Drawing.Size(86, 23)
        Me.LabelX6.TabIndex = 31
        Me.LabelX6.Text = "Periodo"
        Me.LabelX6.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'LabelX2
        '
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX2.Location = New System.Drawing.Point(511, 57)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(86, 23)
        Me.LabelX2.TabIndex = 31
        Me.LabelX2.Text = "Tipo Pago"
        Me.LabelX2.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'comentaTb
        '
        '
        '
        '
        Me.comentaTb.Border.Class = "TextBoxBorder"
        Me.comentaTb.Border.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.comentaTb.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.comentaTb.Location = New System.Drawing.Point(91, 315)
        Me.comentaTb.MaxLength = 600
        Me.comentaTb.Multiline = True
        Me.comentaTb.Name = "comentaTb"
        Me.comentaTb.PreventEnterBeep = True
        Me.comentaTb.Size = New System.Drawing.Size(515, 197)
        Me.comentaTb.TabIndex = 32
        '
        'empTb
        '
        '
        '
        '
        Me.empTb.Border.Class = "TextBoxBorder"
        Me.empTb.Border.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.empTb.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.empTb.Location = New System.Drawing.Point(109, 50)
        Me.empTb.MaxLength = 25
        Me.empTb.Name = "empTb"
        Me.empTb.PreventEnterBeep = True
        Me.empTb.Size = New System.Drawing.Size(320, 30)
        Me.empTb.TabIndex = 29
        '
        'tota1Tb
        '
        '
        '
        '
        Me.tota1Tb.Border.Class = "TextBoxBorder"
        Me.tota1Tb.Border.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.tota1Tb.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tota1Tb.Location = New System.Drawing.Point(612, 211)
        Me.tota1Tb.MaxLength = 15
        Me.tota1Tb.Name = "tota1Tb"
        Me.tota1Tb.PreventEnterBeep = True
        Me.tota1Tb.Size = New System.Drawing.Size(173, 30)
        Me.tota1Tb.TabIndex = 32
        '
        'cant1Tb
        '
        '
        '
        '
        Me.cant1Tb.Border.Class = "TextBoxBorder"
        Me.cant1Tb.Border.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.cant1Tb.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cant1Tb.Location = New System.Drawing.Point(91, 211)
        Me.cant1Tb.MaxLength = 15
        Me.cant1Tb.Name = "cant1Tb"
        Me.cant1Tb.PreventEnterBeep = True
        Me.cant1Tb.Size = New System.Drawing.Size(94, 30)
        Me.cant1Tb.TabIndex = 32
        '
        'LabelX13
        '
        '
        '
        '
        Me.LabelX13.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX13.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX13.Location = New System.Drawing.Point(14, 48)
        Me.LabelX13.Name = "LabelX13"
        Me.LabelX13.Size = New System.Drawing.Size(82, 23)
        Me.LabelX13.TabIndex = 31
        Me.LabelX13.Text = "Empresa"
        Me.LabelX13.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'nFacTb
        '
        '
        '
        '
        Me.nFacTb.Border.Class = "TextBoxBorder"
        Me.nFacTb.Border.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.nFacTb.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nFacTb.Location = New System.Drawing.Point(109, 14)
        Me.nFacTb.MaxLength = 6
        Me.nFacTb.Name = "nFacTb"
        Me.nFacTb.PreventEnterBeep = True
        Me.nFacTb.Size = New System.Drawing.Size(186, 30)
        Me.nFacTb.TabIndex = 29
        '
        'LabelX7
        '
        '
        '
        '
        Me.LabelX7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX7.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX7.Location = New System.Drawing.Point(532, 12)
        Me.LabelX7.Name = "LabelX7"
        Me.LabelX7.Size = New System.Drawing.Size(54, 23)
        Me.LabelX7.TabIndex = 31
        Me.LabelX7.Text = "Fecha"
        Me.LabelX7.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'desc1Tb
        '
        '
        '
        '
        Me.desc1Tb.Border.Class = "TextBoxBorder"
        Me.desc1Tb.Border.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.desc1Tb.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.desc1Tb.Location = New System.Drawing.Point(196, 211)
        Me.desc1Tb.MaxLength = 45
        Me.desc1Tb.Name = "desc1Tb"
        Me.desc1Tb.PreventEnterBeep = True
        Me.desc1Tb.Size = New System.Drawing.Size(284, 30)
        Me.desc1Tb.TabIndex = 32
        '
        'facCanTB
        '
        '
        '
        '
        Me.facCanTB.Border.Class = "TextBoxBorder"
        Me.facCanTB.Border.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.facCanTB.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.facCanTB.Location = New System.Drawing.Point(626, 350)
        Me.facCanTB.MaxLength = 20
        Me.facCanTB.Name = "facCanTB"
        Me.facCanTB.PreventEnterBeep = True
        Me.facCanTB.Size = New System.Drawing.Size(112, 30)
        Me.facCanTB.TabIndex = 32
        '
        'rtnTb
        '
        '
        '
        '
        Me.rtnTb.Border.Class = "TextBoxBorder"
        Me.rtnTb.Border.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.rtnTb.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rtnTb.Location = New System.Drawing.Point(109, 121)
        Me.rtnTb.MaxLength = 16
        Me.rtnTb.Name = "rtnTb"
        Me.rtnTb.PreventEnterBeep = True
        Me.rtnTb.Size = New System.Drawing.Size(207, 30)
        Me.rtnTb.TabIndex = 32
        '
        'LabelX1
        '
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX1.Location = New System.Drawing.Point(14, 14)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(82, 23)
        Me.LabelX1.TabIndex = 31
        Me.LabelX1.Text = "Factura N°"
        Me.LabelX1.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'propTb
        '
        '
        '
        '
        Me.propTb.Border.Class = "TextBoxBorder"
        Me.propTb.Border.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.propTb.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.propTb.Location = New System.Drawing.Point(109, 86)
        Me.propTb.MaxLength = 30
        Me.propTb.Name = "propTb"
        Me.propTb.PreventEnterBeep = True
        Me.propTb.Size = New System.Drawing.Size(320, 30)
        Me.propTb.TabIndex = 32
        '
        'buscartxt
        '
        '
        '
        '
        Me.buscartxt.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.buscartxt.Location = New System.Drawing.Point(239, 90)
        Me.buscartxt.Name = "buscartxt"
        Me.buscartxt.Size = New System.Drawing.Size(75, 23)
        Me.buscartxt.TabIndex = 36
        Me.buscartxt.Text = "-"
        '
        'propBusqTB
        '
        '
        '
        '
        Me.propBusqTB.Border.Class = "TextBoxBorder"
        Me.propBusqTB.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.propBusqTB.Location = New System.Drawing.Point(133, 90)
        Me.propBusqTB.Name = "propBusqTB"
        Me.propBusqTB.PreventEnterBeep = True
        Me.propBusqTB.Size = New System.Drawing.Size(100, 20)
        Me.propBusqTB.TabIndex = 35
        '
        'placaBusqTB
        '
        '
        '
        '
        Me.placaBusqTB.Border.Class = "TextBoxBorder"
        Me.placaBusqTB.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.placaBusqTB.Location = New System.Drawing.Point(23, 90)
        Me.placaBusqTB.Name = "placaBusqTB"
        Me.placaBusqTB.PreventEnterBeep = True
        Me.placaBusqTB.Size = New System.Drawing.Size(100, 20)
        Me.placaBusqTB.TabIndex = 34
        '
        'ButtonX6
        '
        Me.ButtonX6.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX6.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX6.Location = New System.Drawing.Point(638, 87)
        Me.ButtonX6.Name = "ButtonX6"
        Me.ButtonX6.Size = New System.Drawing.Size(36, 23)
        Me.ButtonX6.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonX6.Symbol = ""
        Me.ButtonX6.SymbolSize = 10.0!
        Me.ButtonX6.TabIndex = 33
        '
        'LabelX14
        '
        '
        '
        '
        Me.LabelX14.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX14.Location = New System.Drawing.Point(133, 70)
        Me.LabelX14.Name = "LabelX14"
        Me.LabelX14.Size = New System.Drawing.Size(75, 23)
        Me.LabelX14.TabIndex = 31
        Me.LabelX14.Text = "Propietario"
        '
        'LabelX15
        '
        '
        '
        '
        Me.LabelX15.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX15.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX15.Location = New System.Drawing.Point(24, 70)
        Me.LabelX15.Name = "LabelX15"
        Me.LabelX15.Size = New System.Drawing.Size(44, 23)
        Me.LabelX15.TabIndex = 32
        Me.LabelX15.Text = "Código"
        '
        'ButtonX3
        '
        Me.ButtonX3.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX3.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX3.Location = New System.Drawing.Point(734, 11)
        Me.ButtonX3.Name = "ButtonX3"
        Me.ButtonX3.Size = New System.Drawing.Size(82, 39)
        Me.ButtonX3.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonX3.Symbol = ""
        Me.ButtonX3.TabIndex = 37
        Me.ButtonX3.Text = "Imprimir"
        '
        'PreviaBtn
        '
        Me.PreviaBtn.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.PreviaBtn.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.PreviaBtn.Location = New System.Drawing.Point(734, 52)
        Me.PreviaBtn.Name = "PreviaBtn"
        Me.PreviaBtn.Size = New System.Drawing.Size(82, 39)
        Me.PreviaBtn.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.PreviaBtn.Symbol = ""
        Me.PreviaBtn.TabIndex = 38
        Me.PreviaBtn.Text = "Previa"
        '
        'CamDgv
        '
        Me.CamDgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.CamDgv.DefaultCellStyle = DataGridViewCellStyle1
        Me.CamDgv.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.CamDgv.Location = New System.Drawing.Point(822, 116)
        Me.CamDgv.Name = "CamDgv"
        Me.CamDgv.Size = New System.Drawing.Size(460, 523)
        Me.CamDgv.TabIndex = 39
        '
        'ButtonX5
        '
        Me.ButtonX5.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX5.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX5.Location = New System.Drawing.Point(895, 29)
        Me.ButtonX5.Name = "ButtonX5"
        Me.ButtonX5.Size = New System.Drawing.Size(75, 23)
        Me.ButtonX5.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonX5.TabIndex = 40
        Me.ButtonX5.Text = "ButtonX5"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(823, 92)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(100, 20)
        Me.TextBox1.TabIndex = 41
        '
        'PrintFactura
        '
        '
        'PrintPreviewFactura
        '
        Me.PrintPreviewFactura.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.PrintPreviewFactura.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.PrintPreviewFactura.ClientSize = New System.Drawing.Size(400, 300)
        Me.PrintPreviewFactura.Enabled = True
        Me.PrintPreviewFactura.Icon = CType(resources.GetObject("PrintPreviewFactura.Icon"), System.Drawing.Icon)
        Me.PrintPreviewFactura.Name = "PrintPreviewFactura"
        Me.PrintPreviewFactura.Visible = False
        '
        'preUni1Tb
        '
        '
        '
        '
        Me.preUni1Tb.Border.Class = "TextBoxBorder"
        Me.preUni1Tb.Border.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.preUni1Tb.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.preUni1Tb.Location = New System.Drawing.Point(486, 211)
        Me.preUni1Tb.Name = "preUni1Tb"
        Me.preUni1Tb.PreventEnterBeep = True
        Me.preUni1Tb.Size = New System.Drawing.Size(120, 30)
        Me.preUni1Tb.TabIndex = 42
        '
        'preUni2Tb
        '
        '
        '
        '
        Me.preUni2Tb.Border.Class = "TextBoxBorder"
        Me.preUni2Tb.Border.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.preUni2Tb.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.preUni2Tb.Location = New System.Drawing.Point(486, 247)
        Me.preUni2Tb.Name = "preUni2Tb"
        Me.preUni2Tb.PreventEnterBeep = True
        Me.preUni2Tb.Size = New System.Drawing.Size(120, 30)
        Me.preUni2Tb.TabIndex = 42
        '
        'factura
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1294, 649)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.ButtonX5)
        Me.Controls.Add(Me.CamDgv)
        Me.Controls.Add(Me.PreviaBtn)
        Me.Controls.Add(Me.ButtonX3)
        Me.Controls.Add(Me.buscartxt)
        Me.Controls.Add(Me.propBusqTB)
        Me.Controls.Add(Me.placaBusqTB)
        Me.Controls.Add(Me.ButtonX6)
        Me.Controls.Add(Me.LabelX14)
        Me.Controls.Add(Me.LabelX15)
        Me.Controls.Add(Me.PanelP)
        Me.Controls.Add(Me.CancelarBtn)
        Me.Controls.Add(Me.EliminarBtn)
        Me.Controls.Add(Me.EditarBtn)
        Me.Controls.Add(Me.NuevoBtn)
        Me.Controls.Add(Me.GuardarBtn)
        Me.Controls.Add(Me.ModificarBtn)
        Me.Name = "factura"
        Me.Text = "factura"
        Me.PanelP.ResumeLayout(False)
        CType(Me.fechaPk, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CamDgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents CancelarBtn As DevComponents.DotNetBar.ButtonX
    Friend WithEvents EliminarBtn As DevComponents.DotNetBar.ButtonX
    Friend WithEvents EditarBtn As DevComponents.DotNetBar.ButtonX
    Friend WithEvents NuevoBtn As DevComponents.DotNetBar.ButtonX
    Friend WithEvents GuardarBtn As DevComponents.DotNetBar.ButtonX
    Friend WithEvents ModificarBtn As DevComponents.DotNetBar.ButtonX
    Friend WithEvents PanelP As Panel
    Friend WithEvents LabelX18 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX17 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX11 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX16 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX10 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents tota2Tb As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents cant2Tb As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents facExeTb As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX5 As DevComponents.DotNetBar.LabelX
    Friend WithEvents desc2Tb As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents facTotTb As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX8 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents comentaTb As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents empTb As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents tota1Tb As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents cant1Tb As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX13 As DevComponents.DotNetBar.LabelX
    Friend WithEvents nFacTb As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX7 As DevComponents.DotNetBar.LabelX
    Friend WithEvents desc1Tb As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents facCanTB As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents rtnTb As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents propTb As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents ButtonX2 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents ButtonX1 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents tipoPagTb As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents Contado As DevComponents.Editors.ComboItem
    Friend WithEvents Credito As DevComponents.Editors.ComboItem
    Friend WithEvents Tarjeta As DevComponents.Editors.ComboItem
    Friend WithEvents Transferencia As DevComponents.Editors.ComboItem
    Friend WithEvents perSemCB As ComboBox
    Friend WithEvents perMesCB As ComboBox
    Friend WithEvents LabelX12 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX9 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX6 As DevComponents.DotNetBar.LabelX
    Friend WithEvents buscartxt As DevComponents.DotNetBar.LabelX
    Friend WithEvents propBusqTB As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents placaBusqTB As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents ButtonX6 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents LabelX14 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX15 As DevComponents.DotNetBar.LabelX
    Friend WithEvents ButtonX3 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents PreviaBtn As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Line2 As DevComponents.DotNetBar.Controls.Line
    Friend WithEvents Line1 As DevComponents.DotNetBar.Controls.Line
    Friend WithEvents LabelX19 As DevComponents.DotNetBar.LabelX
    Friend WithEvents pLetras As DevComponents.DotNetBar.LabelX
    Friend WithEvents CamDgv As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents ButtonX5 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents PrintFactura As Printing.PrintDocument
    Friend WithEvents PrintPreviewFactura As PrintPreviewDialog
    Friend WithEvents fechaPk As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents preUni2Tb As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents preUni1Tb As DevComponents.DotNetBar.Controls.TextBoxX
End Class
