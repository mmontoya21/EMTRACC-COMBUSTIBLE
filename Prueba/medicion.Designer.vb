<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class medicion
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
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.fechaTb = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.galonesCalcTb = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.pglCalTb = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX()
        Me.galonesMedTb = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX5 = New DevComponents.DotNetBar.LabelX()
        Me.pglMedTb = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.MedDGV = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.buscartxt = New DevComponents.DotNetBar.LabelX()
        Me.lblTotales = New DevComponents.DotNetBar.LabelX()
        Me.PanelGrafica = New System.Windows.Forms.Panel()
        Me.lblTituloGrafica = New DevComponents.DotNetBar.LabelX()
        Me.PanelP.SuspendLayout()
        CType(Me.MedDGV, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.CancelarBtn.SymbolSize = 12.0!
        Me.CancelarBtn.TabIndex = 43
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
        Me.EliminarBtn.SymbolColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.EliminarBtn.SymbolSize = 12.0!
        Me.EliminarBtn.TabIndex = 42
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
        Me.EditarBtn.SymbolSize = 12.0!
        Me.EditarBtn.TabIndex = 40
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
        Me.NuevoBtn.SymbolSize = 12.0!
        Me.NuevoBtn.TabIndex = 39
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
        Me.GuardarBtn.SymbolColor = System.Drawing.Color.Green
        Me.GuardarBtn.SymbolSize = 12.0!
        Me.GuardarBtn.TabIndex = 41
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
        Me.ModificarBtn.SymbolSize = 12.0!
        Me.ModificarBtn.TabIndex = 44
        Me.ModificarBtn.Text = "Modificar"
        '
        'PanelP
        '
        Me.PanelP.Controls.Add(Me.LabelX1)
        Me.PanelP.Controls.Add(Me.fechaTb)
        Me.PanelP.Controls.Add(Me.LabelX2)
        Me.PanelP.Controls.Add(Me.galonesCalcTb)
        Me.PanelP.Controls.Add(Me.LabelX3)
        Me.PanelP.Controls.Add(Me.pglCalTb)
        Me.PanelP.Controls.Add(Me.LabelX4)
        Me.PanelP.Controls.Add(Me.galonesMedTb)
        Me.PanelP.Controls.Add(Me.LabelX5)
        Me.PanelP.Controls.Add(Me.pglMedTb)
        Me.PanelP.Location = New System.Drawing.Point(17, 55)
        Me.PanelP.Name = "PanelP"
        Me.PanelP.Size = New System.Drawing.Size(1020, 100)
        Me.PanelP.TabIndex = 45
        '
        'LabelX1
        '
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Font = New System.Drawing.Font("Comic Sans MS", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX1.FontBold = True
        Me.LabelX1.ForeColor = System.Drawing.Color.DarkBlue
        Me.LabelX1.Location = New System.Drawing.Point(10, 10)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(60, 23)
        Me.LabelX1.TabIndex = 0
        Me.LabelX1.Text = "Fecha"
        '
        'fechaTb
        '
        Me.fechaTb.AcceptsTab = True
        Me.fechaTb.BackColor = System.Drawing.Color.SteelBlue
        '
        '
        '
        Me.fechaTb.Border.BackColor = System.Drawing.Color.SteelBlue
        Me.fechaTb.Border.BackColor2 = System.Drawing.Color.SteelBlue
        Me.fechaTb.Border.BorderBottomWidth = 2
        Me.fechaTb.Border.BorderColor = System.Drawing.Color.White
        Me.fechaTb.Border.BorderLeftWidth = 2
        Me.fechaTb.Border.BorderRightWidth = 2
        Me.fechaTb.Border.BorderTopWidth = 2
        Me.fechaTb.Border.Class = "TextBoxBorder"
        Me.fechaTb.Border.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.fechaTb.FocusHighlightColor = System.Drawing.Color.Yellow
        Me.fechaTb.FocusHighlightEnabled = True
        Me.fechaTb.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fechaTb.ForeColor = System.Drawing.Color.White
        Me.fechaTb.Location = New System.Drawing.Point(10, 35)
        Me.fechaTb.MaxLength = 15
        Me.fechaTb.Name = "fechaTb"
        Me.fechaTb.PreventEnterBeep = True
        Me.fechaTb.Size = New System.Drawing.Size(140, 32)
        Me.fechaTb.TabIndex = 1
        '
        'LabelX2
        '
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.Font = New System.Drawing.Font("Comic Sans MS", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX2.FontBold = True
        Me.LabelX2.ForeColor = System.Drawing.Color.DarkBlue
        Me.LabelX2.Location = New System.Drawing.Point(170, 10)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(120, 23)
        Me.LabelX2.TabIndex = 2
        Me.LabelX2.Text = "Galones Calc"
        '
        'galonesCalcTb
        '
        Me.galonesCalcTb.AcceptsTab = True
        Me.galonesCalcTb.BackColor = System.Drawing.Color.SteelBlue
        '
        '
        '
        Me.galonesCalcTb.Border.BackColor = System.Drawing.Color.SteelBlue
        Me.galonesCalcTb.Border.BackColor2 = System.Drawing.Color.SteelBlue
        Me.galonesCalcTb.Border.BorderBottomWidth = 2
        Me.galonesCalcTb.Border.BorderColor = System.Drawing.Color.White
        Me.galonesCalcTb.Border.BorderLeftWidth = 2
        Me.galonesCalcTb.Border.BorderRightWidth = 2
        Me.galonesCalcTb.Border.BorderTopWidth = 2
        Me.galonesCalcTb.Border.Class = "TextBoxBorder"
        Me.galonesCalcTb.Border.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.galonesCalcTb.FocusHighlightColor = System.Drawing.Color.Yellow
        Me.galonesCalcTb.FocusHighlightEnabled = True
        Me.galonesCalcTb.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.galonesCalcTb.ForeColor = System.Drawing.Color.White
        Me.galonesCalcTb.Location = New System.Drawing.Point(170, 35)
        Me.galonesCalcTb.Name = "galonesCalcTb"
        Me.galonesCalcTb.PreventEnterBeep = True
        Me.galonesCalcTb.Size = New System.Drawing.Size(140, 32)
        Me.galonesCalcTb.TabIndex = 3
        '
        'LabelX3
        '
        '
        '
        '
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX3.Font = New System.Drawing.Font("Comic Sans MS", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX3.FontBold = True
        Me.LabelX3.ForeColor = System.Drawing.Color.DarkBlue
        Me.LabelX3.Location = New System.Drawing.Point(330, 10)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(120, 23)
        Me.LabelX3.TabIndex = 4
        Me.LabelX3.Text = "PGL Calc"
        '
        'pglCalTb
        '
        Me.pglCalTb.AcceptsTab = True
        Me.pglCalTb.BackColor = System.Drawing.Color.SteelBlue
        '
        '
        '
        Me.pglCalTb.Border.BackColor = System.Drawing.Color.SteelBlue
        Me.pglCalTb.Border.BackColor2 = System.Drawing.Color.SteelBlue
        Me.pglCalTb.Border.BorderBottomWidth = 2
        Me.pglCalTb.Border.BorderColor = System.Drawing.Color.White
        Me.pglCalTb.Border.BorderLeftWidth = 2
        Me.pglCalTb.Border.BorderRightWidth = 2
        Me.pglCalTb.Border.BorderTopWidth = 2
        Me.pglCalTb.Border.Class = "TextBoxBorder"
        Me.pglCalTb.Border.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.pglCalTb.FocusHighlightColor = System.Drawing.Color.Yellow
        Me.pglCalTb.FocusHighlightEnabled = True
        Me.pglCalTb.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pglCalTb.ForeColor = System.Drawing.Color.White
        Me.pglCalTb.Location = New System.Drawing.Point(330, 35)
        Me.pglCalTb.Name = "pglCalTb"
        Me.pglCalTb.PreventEnterBeep = True
        Me.pglCalTb.Size = New System.Drawing.Size(140, 32)
        Me.pglCalTb.TabIndex = 5
        '
        'LabelX4
        '
        '
        '
        '
        Me.LabelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX4.Font = New System.Drawing.Font("Comic Sans MS", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX4.FontBold = True
        Me.LabelX4.ForeColor = System.Drawing.Color.DarkBlue
        Me.LabelX4.Location = New System.Drawing.Point(490, 10)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Size = New System.Drawing.Size(120, 23)
        Me.LabelX4.TabIndex = 6
        Me.LabelX4.Text = "Galones Med"
        '
        'galonesMedTb
        '
        Me.galonesMedTb.AcceptsTab = True
        Me.galonesMedTb.BackColor = System.Drawing.Color.SteelBlue
        '
        '
        '
        Me.galonesMedTb.Border.BackColor = System.Drawing.Color.SteelBlue
        Me.galonesMedTb.Border.BackColor2 = System.Drawing.Color.SteelBlue
        Me.galonesMedTb.Border.BorderBottomWidth = 2
        Me.galonesMedTb.Border.BorderColor = System.Drawing.Color.White
        Me.galonesMedTb.Border.BorderLeftWidth = 2
        Me.galonesMedTb.Border.BorderRightWidth = 2
        Me.galonesMedTb.Border.BorderTopWidth = 2
        Me.galonesMedTb.Border.Class = "TextBoxBorder"
        Me.galonesMedTb.Border.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.galonesMedTb.FocusHighlightColor = System.Drawing.Color.Yellow
        Me.galonesMedTb.FocusHighlightEnabled = True
        Me.galonesMedTb.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.galonesMedTb.ForeColor = System.Drawing.Color.White
        Me.galonesMedTb.Location = New System.Drawing.Point(490, 35)
        Me.galonesMedTb.Name = "galonesMedTb"
        Me.galonesMedTb.PreventEnterBeep = True
        Me.galonesMedTb.Size = New System.Drawing.Size(140, 32)
        Me.galonesMedTb.TabIndex = 7
        '
        'LabelX5
        '
        '
        '
        '
        Me.LabelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX5.Font = New System.Drawing.Font("Comic Sans MS", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX5.FontBold = True
        Me.LabelX5.ForeColor = System.Drawing.Color.DarkBlue
        Me.LabelX5.Location = New System.Drawing.Point(650, 10)
        Me.LabelX5.Name = "LabelX5"
        Me.LabelX5.Size = New System.Drawing.Size(120, 23)
        Me.LabelX5.TabIndex = 8
        Me.LabelX5.Text = "PGL Med"
        '
        'pglMedTb
        '
        Me.pglMedTb.AcceptsTab = True
        Me.pglMedTb.BackColor = System.Drawing.Color.SteelBlue
        '
        '
        '
        Me.pglMedTb.Border.BackColor = System.Drawing.Color.SteelBlue
        Me.pglMedTb.Border.BackColor2 = System.Drawing.Color.SteelBlue
        Me.pglMedTb.Border.BorderBottomWidth = 2
        Me.pglMedTb.Border.BorderColor = System.Drawing.Color.White
        Me.pglMedTb.Border.BorderLeftWidth = 2
        Me.pglMedTb.Border.BorderRightWidth = 2
        Me.pglMedTb.Border.BorderTopWidth = 2
        Me.pglMedTb.Border.Class = "TextBoxBorder"
        Me.pglMedTb.Border.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.pglMedTb.FocusHighlightColor = System.Drawing.Color.Yellow
        Me.pglMedTb.FocusHighlightEnabled = True
        Me.pglMedTb.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pglMedTb.ForeColor = System.Drawing.Color.White
        Me.pglMedTb.Location = New System.Drawing.Point(650, 35)
        Me.pglMedTb.Name = "pglMedTb"
        Me.pglMedTb.PreventEnterBeep = True
        Me.pglMedTb.Size = New System.Drawing.Size(140, 32)
        Me.pglMedTb.TabIndex = 9
        '
        'MedDGV
        '
        Me.MedDGV.AllowUserToAddRows = False
        Me.MedDGV.AllowUserToDeleteRows = False
        Me.MedDGV.AllowUserToOrderColumns = True
        Me.MedDGV.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.MedDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Comic Sans MS", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.MedDGV.DefaultCellStyle = DataGridViewCellStyle1
        Me.MedDGV.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.MedDGV.Location = New System.Drawing.Point(12, 190)
        Me.MedDGV.Name = "MedDGV"
        Me.MedDGV.ReadOnly = True
        Me.MedDGV.RowHeadersVisible = False
        Me.MedDGV.Size = New System.Drawing.Size(713, 380)
        Me.MedDGV.TabIndex = 46
        '
        'buscartxt
        '
        '
        '
        '
        Me.buscartxt.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.buscartxt.Font = New System.Drawing.Font("Comic Sans MS", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.buscartxt.ForeColor = System.Drawing.Color.White
        Me.buscartxt.Location = New System.Drawing.Point(500, 15)
        Me.buscartxt.Name = "buscartxt"
        Me.buscartxt.Size = New System.Drawing.Size(75, 23)
        Me.buscartxt.TabIndex = 47
        Me.buscartxt.Text = "-"
        Me.buscartxt.Visible = False
        '
        'lblTotales
        '
        '
        '
        '
        Me.lblTotales.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblTotales.Font = New System.Drawing.Font("Comic Sans MS", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotales.ForeColor = System.Drawing.Color.White
        Me.lblTotales.Location = New System.Drawing.Point(12, 163)
        Me.lblTotales.Name = "lblTotales"
        Me.lblTotales.Size = New System.Drawing.Size(500, 23)
        Me.lblTotales.TabIndex = 48
        Me.lblTotales.Text = "Registros: 0"
        '
        'lblTituloGrafica
        '
        '
        '
        '
        Me.lblTituloGrafica.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblTituloGrafica.Font = New System.Drawing.Font("Comic Sans MS", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTituloGrafica.ForeColor = System.Drawing.Color.White
        Me.lblTituloGrafica.Location = New System.Drawing.Point(735, 163)
        Me.lblTituloGrafica.Name = "lblTituloGrafica"
        Me.lblTituloGrafica.Size = New System.Drawing.Size(300, 23)
        Me.lblTituloGrafica.TabIndex = 50
        Me.lblTituloGrafica.Text = "Ultima Medicion"
        '
        'PanelGrafica
        '
        Me.PanelGrafica.BackColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.PanelGrafica.Location = New System.Drawing.Point(735, 190)
        Me.PanelGrafica.Name = "PanelGrafica"
        Me.PanelGrafica.Size = New System.Drawing.Size(300, 380)
        Me.PanelGrafica.TabIndex = 49
        '
        'medicion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.SteelBlue
        Me.ClientSize = New System.Drawing.Size(1055, 585)
        Me.Controls.Add(Me.lblTituloGrafica)
        Me.Controls.Add(Me.PanelGrafica)
        Me.Controls.Add(Me.lblTotales)
        Me.Controls.Add(Me.buscartxt)
        Me.Controls.Add(Me.MedDGV)
        Me.Controls.Add(Me.PanelP)
        Me.Controls.Add(Me.CancelarBtn)
        Me.Controls.Add(Me.EliminarBtn)
        Me.Controls.Add(Me.EditarBtn)
        Me.Controls.Add(Me.NuevoBtn)
        Me.Controls.Add(Me.GuardarBtn)
        Me.Controls.Add(Me.ModificarBtn)
        Me.Name = "medicion"
        Me.Text = "Medicion de Tanque"
        Me.PanelP.ResumeLayout(False)
        CType(Me.MedDGV, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents fechaTb As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents galonesCalcTb As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents pglCalTb As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Friend WithEvents galonesMedTb As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX5 As DevComponents.DotNetBar.LabelX
    Friend WithEvents pglMedTb As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents MedDGV As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents buscartxt As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblTotales As DevComponents.DotNetBar.LabelX
    Friend WithEvents PanelGrafica As Panel
    Friend WithEvents lblTituloGrafica As DevComponents.DotNetBar.LabelX
End Class
