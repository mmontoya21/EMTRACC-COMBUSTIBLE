<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class comprobante
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
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.nComproTb = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.PreviaBtn = New DevComponents.DotNetBar.ButtonX()
        Me.ImprimirBt = New DevComponents.DotNetBar.ButtonX()
        Me.CancelarBtn = New DevComponents.DotNetBar.ButtonX()
        Me.EliminarBtn = New DevComponents.DotNetBar.ButtonX()
        Me.EditarBtn = New DevComponents.DotNetBar.ButtonX()
        Me.NuevoBtn = New DevComponents.DotNetBar.ButtonX()
        Me.GuardarBtn = New DevComponents.DotNetBar.ButtonX()
        Me.ModificarBtn = New DevComponents.DotNetBar.ButtonX()
        Me.LabelX23 = New DevComponents.DotNetBar.LabelX()
        Me.CamDGV = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.LabelX9 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX14 = New DevComponents.DotNetBar.LabelX()
        Me.buscartxt = New DevComponents.DotNetBar.LabelX()
        Me.boletBusqTB = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.placaBusqTB = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.galDespTb = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.nombDespTb = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.nBoletaTb = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.codiPropTb = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.rutaTb = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.nConteTb = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.propCbzTb = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.valorTb = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.nombCondTb = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.placaCbzTb = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX10 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX16 = New DevComponents.DotNetBar.LabelX()
        Me.pLetras = New DevComponents.DotNetBar.LabelX()
        Me.LabelX21 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX22 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX11 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX6 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX19 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX12 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX5 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX7 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX8 = New DevComponents.DotNetBar.LabelX()
        Me.fechaPkd = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.LabelX13 = New DevComponents.DotNetBar.LabelX()
        Me.semanaTb = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.S1 = New DevComponents.Editors.ComboItem()
        Me.S2 = New DevComponents.Editors.ComboItem()
        Me.S3 = New DevComponents.Editors.ComboItem()
        Me.S4 = New DevComponents.Editors.ComboItem()
        Me.S5 = New DevComponents.Editors.ComboItem()
        Me.proxSemTb = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.Si = New DevComponents.Editors.ComboItem()
        Me.No = New DevComponents.Editors.ComboItem()
        Me.periodoTb = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.ComboItem1 = New DevComponents.Editors.ComboItem()
        Me.ComboItem2 = New DevComponents.Editors.ComboItem()
        Me.ComboItem3 = New DevComponents.Editors.ComboItem()
        Me.ComboItem4 = New DevComponents.Editors.ComboItem()
        Me.ComboItem5 = New DevComponents.Editors.ComboItem()
        Me.placaCbzTb2 = New DevComponents.DotNetBar.ListBoxAdv()
        Me.PanelP = New System.Windows.Forms.Panel()
        Me.ButtonX6 = New DevComponents.DotNetBar.ButtonX()
        Me.ComboItem6 = New DevComponents.Editors.ComboItem()
        Me.ComboItem7 = New DevComponents.Editors.ComboItem()
        Me.ComboItem8 = New DevComponents.Editors.ComboItem()
        Me.ComboItem9 = New DevComponents.Editors.ComboItem()
        Me.ComboItem10 = New DevComponents.Editors.ComboItem()
        Me.ComboItem11 = New DevComponents.Editors.ComboItem()
        Me.ComboItem12 = New DevComponents.Editors.ComboItem()
        Me.ComboItem13 = New DevComponents.Editors.ComboItem()
        CType(Me.CamDGV, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.fechaPkd, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelP.SuspendLayout()
        Me.SuspendLayout()
        '
        'nComproTb
        '
        Me.nComproTb.AcceptsTab = True
        Me.nComproTb.BackColor = System.Drawing.Color.SteelBlue
        '
        '
        '
        Me.nComproTb.Border.BackColor = System.Drawing.Color.SteelBlue
        Me.nComproTb.Border.BackColor2 = System.Drawing.Color.SteelBlue
        Me.nComproTb.Border.BorderBottomWidth = 2
        Me.nComproTb.Border.BorderColor = System.Drawing.Color.White
        Me.nComproTb.Border.BorderLeftWidth = 2
        Me.nComproTb.Border.BorderRightWidth = 2
        Me.nComproTb.Border.BorderTopWidth = 2
        Me.nComproTb.Border.Class = "TextBoxBorder"
        Me.nComproTb.Border.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.nComproTb.FocusHighlightColor = System.Drawing.Color.Yellow
        Me.nComproTb.FocusHighlightEnabled = True
        Me.nComproTb.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nComproTb.ForeColor = System.Drawing.Color.Black
        Me.nComproTb.Location = New System.Drawing.Point(847, 12)
        Me.nComproTb.MaxLength = 25
        Me.nComproTb.Name = "nComproTb"
        Me.nComproTb.PreventEnterBeep = True
        Me.nComproTb.Size = New System.Drawing.Size(173, 34)
        Me.nComproTb.TabIndex = 0
        '
        'PreviaBtn
        '
        Me.PreviaBtn.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.PreviaBtn.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.PreviaBtn.Font = New System.Drawing.Font("Comic Sans MS", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PreviaBtn.Location = New System.Drawing.Point(893, 325)
        Me.PreviaBtn.Name = "PreviaBtn"
        Me.PreviaBtn.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor(2, 2, 10, 10)
        Me.PreviaBtn.Size = New System.Drawing.Size(85, 49)
        Me.PreviaBtn.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.PreviaBtn.Symbol = ""
        Me.PreviaBtn.TabIndex = 46
        Me.PreviaBtn.Text = "Vista Previa"
        '
        'ImprimirBt
        '
        Me.ImprimirBt.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ImprimirBt.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ImprimirBt.Font = New System.Drawing.Font("Comic Sans MS", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImprimirBt.Location = New System.Drawing.Point(784, 325)
        Me.ImprimirBt.Name = "ImprimirBt"
        Me.ImprimirBt.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor(10, 10, 2, 2)
        Me.ImprimirBt.Size = New System.Drawing.Size(98, 49)
        Me.ImprimirBt.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ImprimirBt.Symbol = ""
        Me.ImprimirBt.TabIndex = 45
        Me.ImprimirBt.Text = "Imprimir"
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
        Me.CancelarBtn.Symbol = ""
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
        Me.EliminarBtn.Symbol = ""
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
        Me.EditarBtn.Symbol = ""
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
        Me.NuevoBtn.Symbol = ""
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
        Me.GuardarBtn.Symbol = ""
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
        Me.ModificarBtn.Symbol = ""
        Me.ModificarBtn.SymbolSize = 12.0!
        Me.ModificarBtn.TabIndex = 44
        Me.ModificarBtn.Text = "Modificar"
        '
        'LabelX23
        '
        '
        '
        '
        Me.LabelX23.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX23.Font = New System.Drawing.Font("Comic Sans MS", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX23.ForeColor = System.Drawing.Color.DarkBlue
        Me.LabelX23.Location = New System.Drawing.Point(717, 15)
        Me.LabelX23.Name = "LabelX23"
        Me.LabelX23.Size = New System.Drawing.Size(124, 23)
        Me.LabelX23.TabIndex = 31
        Me.LabelX23.Text = "Comprobante N°"
        '
        'CamDGV
        '
        Me.CamDGV.AllowUserToAddRows = False
        Me.CamDGV.AllowUserToDeleteRows = False
        Me.CamDGV.AllowUserToOrderColumns = True
        Me.CamDGV.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.CamDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Comic Sans MS", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.CamDGV.DefaultCellStyle = DataGridViewCellStyle4
        Me.CamDGV.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.CamDGV.Location = New System.Drawing.Point(12, 380)
        Me.CamDGV.Name = "CamDGV"
        Me.CamDGV.ReadOnly = True
        Me.CamDGV.RowHeadersVisible = False
        Me.CamDGV.Size = New System.Drawing.Size(1020, 279)
        Me.CamDGV.TabIndex = 47
        '
        'LabelX9
        '
        '
        '
        '
        Me.LabelX9.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX9.Font = New System.Drawing.Font("Comic Sans MS", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX9.FontBold = True
        Me.LabelX9.ForeColor = System.Drawing.Color.DarkBlue
        Me.LabelX9.Location = New System.Drawing.Point(135, 326)
        Me.LabelX9.Name = "LabelX9"
        Me.LabelX9.Size = New System.Drawing.Size(75, 23)
        Me.LabelX9.TabIndex = 48
        Me.LabelX9.Text = "Boleta"
        '
        'LabelX14
        '
        '
        '
        '
        Me.LabelX14.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX14.Font = New System.Drawing.Font("Comic Sans MS", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX14.FontBold = True
        Me.LabelX14.ForeColor = System.Drawing.Color.DarkBlue
        Me.LabelX14.Location = New System.Drawing.Point(26, 326)
        Me.LabelX14.Name = "LabelX14"
        Me.LabelX14.Size = New System.Drawing.Size(44, 23)
        Me.LabelX14.TabIndex = 49
        Me.LabelX14.Text = "Placa"
        '
        'buscartxt
        '
        '
        '
        '
        Me.buscartxt.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.buscartxt.Font = New System.Drawing.Font("Comic Sans MS", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.buscartxt.ForeColor = System.Drawing.Color.White
        Me.buscartxt.Location = New System.Drawing.Point(280, 343)
        Me.buscartxt.Name = "buscartxt"
        Me.buscartxt.Size = New System.Drawing.Size(75, 23)
        Me.buscartxt.TabIndex = 52
        Me.buscartxt.Text = "-"
        '
        'boletBusqTB
        '
        Me.boletBusqTB.BackColor = System.Drawing.Color.SteelBlue
        '
        '
        '
        Me.boletBusqTB.Border.BorderBottomWidth = 2
        Me.boletBusqTB.Border.BorderLeftWidth = 2
        Me.boletBusqTB.Border.BorderRightWidth = 2
        Me.boletBusqTB.Border.BorderTopWidth = 2
        Me.boletBusqTB.Border.Class = "TextBoxBorder"
        Me.boletBusqTB.Border.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.boletBusqTB.Font = New System.Drawing.Font("Comic Sans MS", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.boletBusqTB.ForeColor = System.Drawing.Color.White
        Me.boletBusqTB.Location = New System.Drawing.Point(135, 340)
        Me.boletBusqTB.Name = "boletBusqTB"
        Me.boletBusqTB.PreventEnterBeep = True
        Me.boletBusqTB.Size = New System.Drawing.Size(139, 34)
        Me.boletBusqTB.TabIndex = 51
        '
        'placaBusqTB
        '
        Me.placaBusqTB.BackColor = System.Drawing.Color.SteelBlue
        '
        '
        '
        Me.placaBusqTB.Border.BorderBottomWidth = 2
        Me.placaBusqTB.Border.BorderLeftWidth = 2
        Me.placaBusqTB.Border.BorderRightWidth = 2
        Me.placaBusqTB.Border.BorderTopWidth = 2
        Me.placaBusqTB.Border.Class = "TextBoxBorder"
        Me.placaBusqTB.Border.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.placaBusqTB.Font = New System.Drawing.Font("Comic Sans MS", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.placaBusqTB.ForeColor = System.Drawing.Color.White
        Me.placaBusqTB.Location = New System.Drawing.Point(25, 340)
        Me.placaBusqTB.Name = "placaBusqTB"
        Me.placaBusqTB.PreventEnterBeep = True
        Me.placaBusqTB.Size = New System.Drawing.Size(100, 34)
        Me.placaBusqTB.TabIndex = 50
        '
        'galDespTb
        '
        Me.galDespTb.AcceptsTab = True
        Me.galDespTb.BackColor = System.Drawing.Color.SteelBlue
        '
        '
        '
        Me.galDespTb.Border.BackColor = System.Drawing.Color.SteelBlue
        Me.galDespTb.Border.BackColor2 = System.Drawing.Color.SteelBlue
        Me.galDespTb.Border.BorderBottomWidth = 2
        Me.galDespTb.Border.BorderColor = System.Drawing.Color.White
        Me.galDespTb.Border.BorderLeftWidth = 2
        Me.galDespTb.Border.BorderRightWidth = 2
        Me.galDespTb.Border.BorderTopWidth = 2
        Me.galDespTb.Border.Class = "TextBoxBorder"
        Me.galDespTb.Border.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.galDespTb.FocusHighlightColor = System.Drawing.Color.Yellow
        Me.galDespTb.FocusHighlightEnabled = True
        Me.galDespTb.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.galDespTb.ForeColor = System.Drawing.Color.Black
        Me.galDespTb.Location = New System.Drawing.Point(5, 24)
        Me.galDespTb.MaxLength = 25
        Me.galDespTb.Name = "galDespTb"
        Me.galDespTb.PreventEnterBeep = True
        Me.galDespTb.Size = New System.Drawing.Size(207, 34)
        Me.galDespTb.TabIndex = 1
        '
        'nombDespTb
        '
        Me.nombDespTb.AcceptsTab = True
        Me.nombDespTb.AutoCompleteCustomSource.AddRange(New String() {"ELI EMANUEL ANTUNEZ GALDAMEZ", "KEVIN JOEL REYES HERNANDEZ"})
        Me.nombDespTb.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.nombDespTb.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.nombDespTb.BackColor = System.Drawing.Color.SteelBlue
        '
        '
        '
        Me.nombDespTb.Border.BackColor = System.Drawing.Color.SteelBlue
        Me.nombDespTb.Border.BackColor2 = System.Drawing.Color.SteelBlue
        Me.nombDespTb.Border.BorderBottomWidth = 2
        Me.nombDespTb.Border.BorderColor = System.Drawing.Color.White
        Me.nombDespTb.Border.BorderLeftWidth = 2
        Me.nombDespTb.Border.BorderRightWidth = 2
        Me.nombDespTb.Border.BorderTopWidth = 2
        Me.nombDespTb.Border.Class = "TextBoxBorder"
        Me.nombDespTb.Border.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.nombDespTb.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.nombDespTb.FocusHighlightColor = System.Drawing.Color.Yellow
        Me.nombDespTb.FocusHighlightEnabled = True
        Me.nombDespTb.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nombDespTb.ForeColor = System.Drawing.Color.Black
        Me.nombDespTb.Location = New System.Drawing.Point(8, 172)
        Me.nombDespTb.MaxLength = 80
        Me.nombDespTb.Name = "nombDespTb"
        Me.nombDespTb.PreventEnterBeep = True
        Me.nombDespTb.Size = New System.Drawing.Size(327, 34)
        Me.nombDespTb.TabIndex = 10
        '
        'nBoletaTb
        '
        Me.nBoletaTb.AcceptsTab = True
        Me.nBoletaTb.BackColor = System.Drawing.Color.SteelBlue
        '
        '
        '
        Me.nBoletaTb.Border.BackColor = System.Drawing.Color.SteelBlue
        Me.nBoletaTb.Border.BackColor2 = System.Drawing.Color.SteelBlue
        Me.nBoletaTb.Border.BorderBottomWidth = 2
        Me.nBoletaTb.Border.BorderColor = System.Drawing.Color.White
        Me.nBoletaTb.Border.BorderLeftWidth = 2
        Me.nBoletaTb.Border.BorderRightWidth = 2
        Me.nBoletaTb.Border.BorderTopWidth = 2
        Me.nBoletaTb.Border.Class = "TextBoxBorder"
        Me.nBoletaTb.Border.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.nBoletaTb.FocusHighlightColor = System.Drawing.Color.Yellow
        Me.nBoletaTb.FocusHighlightEnabled = True
        Me.nBoletaTb.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nBoletaTb.ForeColor = System.Drawing.Color.Black
        Me.nBoletaTb.Location = New System.Drawing.Point(835, 22)
        Me.nBoletaTb.MaxLength = 25
        Me.nBoletaTb.Name = "nBoletaTb"
        Me.nBoletaTb.PreventEnterBeep = True
        Me.nBoletaTb.Size = New System.Drawing.Size(173, 34)
        Me.nBoletaTb.TabIndex = 4
        '
        'codiPropTb
        '
        Me.codiPropTb.AcceptsTab = True
        Me.codiPropTb.BackColor = System.Drawing.Color.SteelBlue
        '
        '
        '
        Me.codiPropTb.Border.BackColor = System.Drawing.Color.SteelBlue
        Me.codiPropTb.Border.BackColor2 = System.Drawing.Color.SteelBlue
        Me.codiPropTb.Border.BorderBottomWidth = 2
        Me.codiPropTb.Border.BorderColor = System.Drawing.Color.White
        Me.codiPropTb.Border.BorderLeftWidth = 2
        Me.codiPropTb.Border.BorderRightWidth = 2
        Me.codiPropTb.Border.BorderTopWidth = 2
        Me.codiPropTb.Border.Class = "TextBoxBorder"
        Me.codiPropTb.Border.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.codiPropTb.FocusHighlightColor = System.Drawing.Color.Blue
        Me.codiPropTb.FocusHighlightEnabled = True
        Me.codiPropTb.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.codiPropTb.ForeColor = System.Drawing.Color.Yellow
        Me.codiPropTb.Location = New System.Drawing.Point(369, 90)
        Me.codiPropTb.MaxLength = 25
        Me.codiPropTb.Name = "codiPropTb"
        Me.codiPropTb.PreventEnterBeep = True
        Me.codiPropTb.Size = New System.Drawing.Size(155, 34)
        Me.codiPropTb.TabIndex = 6
        '
        'rutaTb
        '
        Me.rutaTb.AcceptsTab = True
        Me.rutaTb.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.rutaTb.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.rutaTb.BackColor = System.Drawing.Color.SteelBlue
        '
        '
        '
        Me.rutaTb.Border.BackColor = System.Drawing.Color.SteelBlue
        Me.rutaTb.Border.BackColor2 = System.Drawing.Color.SteelBlue
        Me.rutaTb.Border.BorderBottomWidth = 2
        Me.rutaTb.Border.BorderColor = System.Drawing.Color.White
        Me.rutaTb.Border.BorderLeftWidth = 2
        Me.rutaTb.Border.BorderRightWidth = 2
        Me.rutaTb.Border.BorderTopWidth = 2
        Me.rutaTb.Border.Class = "TextBoxBorder"
        Me.rutaTb.Border.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.rutaTb.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.rutaTb.FocusHighlightColor = System.Drawing.Color.Yellow
        Me.rutaTb.FocusHighlightEnabled = True
        Me.rutaTb.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rutaTb.ForeColor = System.Drawing.Color.Black
        Me.rutaTb.Location = New System.Drawing.Point(680, 151)
        Me.rutaTb.MaxLength = 45
        Me.rutaTb.Name = "rutaTb"
        Me.rutaTb.PreventEnterBeep = True
        Me.rutaTb.Size = New System.Drawing.Size(326, 31)
        Me.rutaTb.TabIndex = 9
        '
        'nConteTb
        '
        Me.nConteTb.AcceptsTab = True
        Me.nConteTb.BackColor = System.Drawing.Color.SteelBlue
        '
        '
        '
        Me.nConteTb.Border.BackColor = System.Drawing.Color.SteelBlue
        Me.nConteTb.Border.BackColor2 = System.Drawing.Color.SteelBlue
        Me.nConteTb.Border.BorderBottomWidth = 2
        Me.nConteTb.Border.BorderColor = System.Drawing.Color.White
        Me.nConteTb.Border.BorderLeftWidth = 2
        Me.nConteTb.Border.BorderRightWidth = 2
        Me.nConteTb.Border.BorderTopWidth = 2
        Me.nConteTb.Border.Class = "TextBoxBorder"
        Me.nConteTb.Border.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.nConteTb.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.nConteTb.FocusHighlightColor = System.Drawing.Color.Yellow
        Me.nConteTb.FocusHighlightEnabled = True
        Me.nConteTb.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nConteTb.ForeColor = System.Drawing.Color.Black
        Me.nConteTb.Location = New System.Drawing.Point(799, 90)
        Me.nConteTb.MaxLength = 25
        Me.nConteTb.Name = "nConteTb"
        Me.nConteTb.PreventEnterBeep = True
        Me.nConteTb.Size = New System.Drawing.Size(207, 34)
        Me.nConteTb.TabIndex = 8
        '
        'propCbzTb
        '
        Me.propCbzTb.AcceptsTab = True
        Me.propCbzTb.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.propCbzTb.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.propCbzTb.BackColor = System.Drawing.Color.SteelBlue
        '
        '
        '
        Me.propCbzTb.Border.BackColor = System.Drawing.Color.SteelBlue
        Me.propCbzTb.Border.BackColor2 = System.Drawing.Color.SteelBlue
        Me.propCbzTb.Border.BorderBottomWidth = 2
        Me.propCbzTb.Border.BorderColor = System.Drawing.Color.White
        Me.propCbzTb.Border.BorderLeftWidth = 2
        Me.propCbzTb.Border.BorderRightWidth = 2
        Me.propCbzTb.Border.BorderTopWidth = 2
        Me.propCbzTb.Border.Class = "TextBoxBorder"
        Me.propCbzTb.Border.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.propCbzTb.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.propCbzTb.FocusHighlightColor = System.Drawing.Color.Blue
        Me.propCbzTb.FocusHighlightEnabled = True
        Me.propCbzTb.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.propCbzTb.ForeColor = System.Drawing.Color.Yellow
        Me.propCbzTb.Location = New System.Drawing.Point(5, 82)
        Me.propCbzTb.MaxLength = 80
        Me.propCbzTb.Name = "propCbzTb"
        Me.propCbzTb.PreventEnterBeep = True
        Me.propCbzTb.Size = New System.Drawing.Size(340, 34)
        Me.propCbzTb.TabIndex = 5
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
        Me.valorTb.Location = New System.Drawing.Point(218, 24)
        Me.valorTb.MaxLength = 25
        Me.valorTb.Name = "valorTb"
        Me.valorTb.PreventEnterBeep = True
        Me.valorTb.Size = New System.Drawing.Size(173, 34)
        Me.valorTb.TabIndex = 2
        '
        'nombCondTb
        '
        Me.nombCondTb.AcceptsTab = True
        Me.nombCondTb.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.nombCondTb.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.nombCondTb.BackColor = System.Drawing.Color.SteelBlue
        '
        '
        '
        Me.nombCondTb.Border.BackColor = System.Drawing.Color.SteelBlue
        Me.nombCondTb.Border.BackColor2 = System.Drawing.Color.SteelBlue
        Me.nombCondTb.Border.BorderBottomWidth = 2
        Me.nombCondTb.Border.BorderColor = System.Drawing.Color.White
        Me.nombCondTb.Border.BorderLeftWidth = 2
        Me.nombCondTb.Border.BorderRightWidth = 2
        Me.nombCondTb.Border.BorderTopWidth = 2
        Me.nombCondTb.Border.Class = "TextBoxBorder"
        Me.nombCondTb.Border.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.nombCondTb.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.nombCondTb.FocusHighlightColor = System.Drawing.Color.Yellow
        Me.nombCondTb.FocusHighlightEnabled = True
        Me.nombCondTb.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nombCondTb.ForeColor = System.Drawing.Color.Black
        Me.nombCondTb.Location = New System.Drawing.Point(8, 231)
        Me.nombCondTb.MaxLength = 80
        Me.nombCondTb.Name = "nombCondTb"
        Me.nombCondTb.PreventEnterBeep = True
        Me.nombCondTb.Size = New System.Drawing.Size(327, 34)
        Me.nombCondTb.TabIndex = 11
        '
        'placaCbzTb
        '
        Me.placaCbzTb.AcceptsTab = True
        Me.placaCbzTb.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.placaCbzTb.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.placaCbzTb.BackColor = System.Drawing.Color.SteelBlue
        '
        '
        '
        Me.placaCbzTb.Border.BackColor = System.Drawing.Color.SteelBlue
        Me.placaCbzTb.Border.BackColor2 = System.Drawing.Color.SteelBlue
        Me.placaCbzTb.Border.BorderBottomWidth = 2
        Me.placaCbzTb.Border.BorderColor = System.Drawing.Color.White
        Me.placaCbzTb.Border.BorderLeftWidth = 2
        Me.placaCbzTb.Border.BorderRightWidth = 2
        Me.placaCbzTb.Border.BorderTopWidth = 2
        Me.placaCbzTb.Border.Class = "TextBoxBorder"
        Me.placaCbzTb.Border.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.placaCbzTb.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.placaCbzTb.ForeColor = System.Drawing.Color.Yellow
        Me.placaCbzTb.Location = New System.Drawing.Point(537, 90)
        Me.placaCbzTb.MaxLength = 25
        Me.placaCbzTb.Name = "placaCbzTb"
        Me.placaCbzTb.PreventEnterBeep = True
        Me.placaCbzTb.ReadOnly = True
        Me.placaCbzTb.Size = New System.Drawing.Size(127, 37)
        Me.placaCbzTb.TabIndex = 29
        Me.placaCbzTb.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'LabelX3
        '
        '
        '
        '
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX3.Font = New System.Drawing.Font("Comic Sans MS", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX3.ForeColor = System.Drawing.Color.DarkBlue
        Me.LabelX3.Location = New System.Drawing.Point(8, 4)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(122, 23)
        Me.LabelX3.TabIndex = 30
        Me.LabelX3.Text = "Gas despachado"
        '
        'LabelX10
        '
        '
        '
        '
        Me.LabelX10.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX10.Font = New System.Drawing.Font("Comic Sans MS", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX10.ForeColor = System.Drawing.Color.DarkBlue
        Me.LabelX10.Location = New System.Drawing.Point(16, 152)
        Me.LabelX10.Name = "LabelX10"
        Me.LabelX10.Size = New System.Drawing.Size(182, 23)
        Me.LabelX10.TabIndex = 30
        Me.LabelX10.Text = "Nombre desplachador"
        '
        'LabelX16
        '
        '
        '
        '
        Me.LabelX16.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX16.Font = New System.Drawing.Font("Comic Sans MS", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX16.ForeColor = System.Drawing.Color.DarkBlue
        Me.LabelX16.Location = New System.Drawing.Point(369, 194)
        Me.LabelX16.Name = "LabelX16"
        Me.LabelX16.Size = New System.Drawing.Size(59, 23)
        Me.LabelX16.TabIndex = 30
        Me.LabelX16.Text = "Periodo"
        '
        'pLetras
        '
        Me.pLetras.BackColor = System.Drawing.Color.LightSteelBlue
        '
        '
        '
        Me.pLetras.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.pLetras.Font = New System.Drawing.Font("Comic Sans MS", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pLetras.ForeColor = System.Drawing.Color.DarkMagenta
        Me.pLetras.Location = New System.Drawing.Point(402, 38)
        Me.pLetras.Name = "pLetras"
        Me.pLetras.Size = New System.Drawing.Size(415, 23)
        Me.pLetras.TabIndex = 30
        Me.pLetras.Text = "-"
        '
        'LabelX21
        '
        '
        '
        '
        Me.LabelX21.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX21.Font = New System.Drawing.Font("Comic Sans MS", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX21.ForeColor = System.Drawing.Color.DarkBlue
        Me.LabelX21.Location = New System.Drawing.Point(402, 3)
        Me.LabelX21.Name = "LabelX21"
        Me.LabelX21.Size = New System.Drawing.Size(140, 23)
        Me.LabelX21.TabIndex = 30
        Me.LabelX21.Text = "Valores en letras"
        '
        'LabelX22
        '
        '
        '
        '
        Me.LabelX22.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX22.Font = New System.Drawing.Font("Comic Sans MS", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX22.ForeColor = System.Drawing.Color.DarkBlue
        Me.LabelX22.Location = New System.Drawing.Point(591, 9)
        Me.LabelX22.Name = "LabelX22"
        Me.LabelX22.Size = New System.Drawing.Size(59, 23)
        Me.LabelX22.TabIndex = 30
        Me.LabelX22.Text = "Fecha"
        '
        'LabelX11
        '
        '
        '
        '
        Me.LabelX11.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX11.Font = New System.Drawing.Font("Comic Sans MS", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX11.ForeColor = System.Drawing.Color.DarkBlue
        Me.LabelX11.Location = New System.Drawing.Point(434, 194)
        Me.LabelX11.Name = "LabelX11"
        Me.LabelX11.Size = New System.Drawing.Size(78, 23)
        Me.LabelX11.TabIndex = 30
        Me.LabelX11.Text = "Semana"
        '
        'LabelX6
        '
        '
        '
        '
        Me.LabelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX6.Font = New System.Drawing.Font("Comic Sans MS", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX6.ForeColor = System.Drawing.Color.DarkBlue
        Me.LabelX6.Location = New System.Drawing.Point(803, 70)
        Me.LabelX6.Name = "LabelX6"
        Me.LabelX6.Size = New System.Drawing.Size(124, 23)
        Me.LabelX6.TabIndex = 30
        Me.LabelX6.Text = "N° Contenedor"
        '
        'LabelX19
        '
        '
        '
        '
        Me.LabelX19.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX19.Font = New System.Drawing.Font("Comic Sans MS", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX19.ForeColor = System.Drawing.Color.DarkBlue
        Me.LabelX19.Location = New System.Drawing.Point(8, 62)
        Me.LabelX19.Name = "LabelX19"
        Me.LabelX19.Size = New System.Drawing.Size(106, 23)
        Me.LabelX19.TabIndex = 30
        Me.LabelX19.Text = "Propietario"
        '
        'LabelX12
        '
        '
        '
        '
        Me.LabelX12.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX12.Font = New System.Drawing.Font("Comic Sans MS", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX12.ForeColor = System.Drawing.Color.DarkBlue
        Me.LabelX12.Location = New System.Drawing.Point(369, 138)
        Me.LabelX12.Name = "LabelX12"
        Me.LabelX12.Size = New System.Drawing.Size(120, 23)
        Me.LabelX12.TabIndex = 30
        Me.LabelX12.Text = "Próxima semana"
        '
        'LabelX1
        '
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Font = New System.Drawing.Font("Comic Sans MS", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX1.ForeColor = System.Drawing.Color.DarkBlue
        Me.LabelX1.Location = New System.Drawing.Point(835, 2)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(54, 23)
        Me.LabelX1.TabIndex = 31
        Me.LabelX1.Text = "Boleta"
        '
        'LabelX2
        '
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.Font = New System.Drawing.Font("Comic Sans MS", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX2.ForeColor = System.Drawing.Color.DarkBlue
        Me.LabelX2.Location = New System.Drawing.Point(222, 4)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(54, 23)
        Me.LabelX2.TabIndex = 31
        Me.LabelX2.Text = "Valor"
        '
        'LabelX5
        '
        '
        '
        '
        Me.LabelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX5.Font = New System.Drawing.Font("Comic Sans MS", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX5.ForeColor = System.Drawing.Color.DarkBlue
        Me.LabelX5.Location = New System.Drawing.Point(543, 70)
        Me.LabelX5.Name = "LabelX5"
        Me.LabelX5.Size = New System.Drawing.Size(111, 23)
        Me.LabelX5.TabIndex = 31
        Me.LabelX5.Text = "Placa Cabezal"
        '
        'LabelX7
        '
        '
        '
        '
        Me.LabelX7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX7.Font = New System.Drawing.Font("Comic Sans MS", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX7.ForeColor = System.Drawing.Color.DarkBlue
        Me.LabelX7.Location = New System.Drawing.Point(375, 70)
        Me.LabelX7.Name = "LabelX7"
        Me.LabelX7.Size = New System.Drawing.Size(149, 23)
        Me.LabelX7.TabIndex = 31
        Me.LabelX7.Text = "Código Propietario"
        '
        'LabelX8
        '
        '
        '
        '
        Me.LabelX8.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX8.Font = New System.Drawing.Font("Comic Sans MS", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX8.ForeColor = System.Drawing.Color.DarkBlue
        Me.LabelX8.Location = New System.Drawing.Point(16, 211)
        Me.LabelX8.Name = "LabelX8"
        Me.LabelX8.Size = New System.Drawing.Size(159, 23)
        Me.LabelX8.TabIndex = 31
        Me.LabelX8.Text = "Nombre Conductor"
        '
        'fechaPkd
        '
        '
        '
        '
        Me.fechaPkd.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.fechaPkd.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.fechaPkd.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.fechaPkd.ButtonDropDown.Visible = True
        Me.fechaPkd.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fechaPkd.IsPopupCalendarOpen = False
        Me.fechaPkd.Location = New System.Drawing.Point(656, 6)
        '
        '
        '
        '
        '
        '
        Me.fechaPkd.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.fechaPkd.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.fechaPkd.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.fechaPkd.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.fechaPkd.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.fechaPkd.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.fechaPkd.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.fechaPkd.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.fechaPkd.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.fechaPkd.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.fechaPkd.MonthCalendar.DisplayMonth = New Date(2025, 8, 1, 0, 0, 0, 0)
        '
        '
        '
        Me.fechaPkd.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.fechaPkd.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.fechaPkd.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.fechaPkd.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.fechaPkd.MonthCalendar.TodayButtonVisible = True
        Me.fechaPkd.Name = "fechaPkd"
        Me.fechaPkd.Size = New System.Drawing.Size(161, 29)
        Me.fechaPkd.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.fechaPkd.TabIndex = 3
        '
        'LabelX13
        '
        '
        '
        '
        Me.LabelX13.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX13.Font = New System.Drawing.Font("Comic Sans MS", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX13.ForeColor = System.Drawing.Color.DarkBlue
        Me.LabelX13.Location = New System.Drawing.Point(683, 131)
        Me.LabelX13.Name = "LabelX13"
        Me.LabelX13.Size = New System.Drawing.Size(90, 23)
        Me.LabelX13.TabIndex = 31
        Me.LabelX13.Text = "Ruta"
        '
        'semanaTb
        '
        Me.semanaTb.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.semanaTb.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.semanaTb.DisplayMember = "Text"
        Me.semanaTb.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.semanaTb.Font = New System.Drawing.Font("Comic Sans MS", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.semanaTb.FormattingEnabled = True
        Me.semanaTb.ItemHeight = 24
        Me.semanaTb.Items.AddRange(New Object() {Me.S1, Me.S2, Me.S3, Me.S4, Me.S5})
        Me.semanaTb.Location = New System.Drawing.Point(435, 214)
        Me.semanaTb.Name = "semanaTb"
        Me.semanaTb.Size = New System.Drawing.Size(59, 30)
        Me.semanaTb.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.semanaTb.TabIndex = 14
        '
        'S1
        '
        Me.S1.Text = "1"
        '
        'S2
        '
        Me.S2.Text = "2"
        '
        'S3
        '
        Me.S3.Text = "3"
        '
        'S4
        '
        Me.S4.Text = "4"
        '
        'S5
        '
        Me.S5.Text = "5"
        '
        'proxSemTb
        '
        Me.proxSemTb.AutoCompleteCustomSource.AddRange(New String() {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12"})
        Me.proxSemTb.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.proxSemTb.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.proxSemTb.DisplayMember = "Text"
        Me.proxSemTb.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.proxSemTb.Font = New System.Drawing.Font("Comic Sans MS", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.proxSemTb.FormattingEnabled = True
        Me.proxSemTb.ItemHeight = 24
        Me.proxSemTb.Items.AddRange(New Object() {Me.Si, Me.No})
        Me.proxSemTb.Location = New System.Drawing.Point(369, 158)
        Me.proxSemTb.Name = "proxSemTb"
        Me.proxSemTb.Size = New System.Drawing.Size(56, 30)
        Me.proxSemTb.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.proxSemTb.TabIndex = 12
        '
        'Si
        '
        Me.Si.Text = "SI"
        '
        'No
        '
        Me.No.Text = "NO"
        '
        'periodoTb
        '
        Me.periodoTb.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.periodoTb.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.periodoTb.DisplayMember = "Text"
        Me.periodoTb.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.periodoTb.Font = New System.Drawing.Font("Comic Sans MS", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.periodoTb.FormattingEnabled = True
        Me.periodoTb.ItemHeight = 24
        Me.periodoTb.Items.AddRange(New Object() {Me.ComboItem1, Me.ComboItem2, Me.ComboItem3, Me.ComboItem4, Me.ComboItem5, Me.ComboItem6, Me.ComboItem7, Me.ComboItem8, Me.ComboItem9, Me.ComboItem10, Me.ComboItem11, Me.ComboItem12, Me.ComboItem13})
        Me.periodoTb.Location = New System.Drawing.Point(369, 214)
        Me.periodoTb.Name = "periodoTb"
        Me.periodoTb.Size = New System.Drawing.Size(59, 30)
        Me.periodoTb.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.periodoTb.TabIndex = 13
        '
        'ComboItem1
        '
        Me.ComboItem1.Text = "1"
        '
        'ComboItem2
        '
        Me.ComboItem2.Text = "2"
        '
        'ComboItem3
        '
        Me.ComboItem3.Text = "3"
        '
        'ComboItem4
        '
        Me.ComboItem4.Text = "4"
        '
        'ComboItem5
        '
        Me.ComboItem5.Text = "5"
        '
        'placaCbzTb2
        '
        Me.placaCbzTb2.AutoScroll = True
        '
        '
        '
        Me.placaCbzTb2.BackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarStripeColor
        Me.placaCbzTb2.BackgroundStyle.Class = "ListBoxAdv"
        Me.placaCbzTb2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.placaCbzTb2.ContainerControlProcessDialogKey = True
        Me.placaCbzTb2.DragDropSupport = True
        Me.placaCbzTb2.Font = New System.Drawing.Font("Comic Sans MS", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.placaCbzTb2.ItemSpacing = 2
        Me.placaCbzTb2.Location = New System.Drawing.Point(543, 125)
        Me.placaCbzTb2.Name = "placaCbzTb2"
        Me.placaCbzTb2.Size = New System.Drawing.Size(118, 119)
        Me.placaCbzTb2.TabIndex = 7
        Me.placaCbzTb2.Text = "ListBoxAdv1"
        '
        'PanelP
        '
        Me.PanelP.Controls.Add(Me.placaCbzTb2)
        Me.PanelP.Controls.Add(Me.periodoTb)
        Me.PanelP.Controls.Add(Me.proxSemTb)
        Me.PanelP.Controls.Add(Me.semanaTb)
        Me.PanelP.Controls.Add(Me.LabelX13)
        Me.PanelP.Controls.Add(Me.fechaPkd)
        Me.PanelP.Controls.Add(Me.LabelX8)
        Me.PanelP.Controls.Add(Me.LabelX7)
        Me.PanelP.Controls.Add(Me.LabelX5)
        Me.PanelP.Controls.Add(Me.LabelX2)
        Me.PanelP.Controls.Add(Me.LabelX1)
        Me.PanelP.Controls.Add(Me.LabelX12)
        Me.PanelP.Controls.Add(Me.LabelX19)
        Me.PanelP.Controls.Add(Me.LabelX6)
        Me.PanelP.Controls.Add(Me.LabelX11)
        Me.PanelP.Controls.Add(Me.LabelX22)
        Me.PanelP.Controls.Add(Me.LabelX21)
        Me.PanelP.Controls.Add(Me.pLetras)
        Me.PanelP.Controls.Add(Me.LabelX16)
        Me.PanelP.Controls.Add(Me.LabelX10)
        Me.PanelP.Controls.Add(Me.LabelX3)
        Me.PanelP.Controls.Add(Me.placaCbzTb)
        Me.PanelP.Controls.Add(Me.nombCondTb)
        Me.PanelP.Controls.Add(Me.valorTb)
        Me.PanelP.Controls.Add(Me.propCbzTb)
        Me.PanelP.Controls.Add(Me.nConteTb)
        Me.PanelP.Controls.Add(Me.rutaTb)
        Me.PanelP.Controls.Add(Me.codiPropTb)
        Me.PanelP.Controls.Add(Me.nBoletaTb)
        Me.PanelP.Controls.Add(Me.nombDespTb)
        Me.PanelP.Controls.Add(Me.galDespTb)
        Me.PanelP.Location = New System.Drawing.Point(12, 51)
        Me.PanelP.Name = "PanelP"
        Me.PanelP.Size = New System.Drawing.Size(1020, 268)
        Me.PanelP.TabIndex = 1
        '
        'ButtonX6
        '
        Me.ButtonX6.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX6.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX6.Location = New System.Drawing.Point(996, 326)
        Me.ButtonX6.Name = "ButtonX6"
        Me.ButtonX6.Size = New System.Drawing.Size(36, 48)
        Me.ButtonX6.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonX6.Symbol = ""
        Me.ButtonX6.SymbolSize = 10.0!
        Me.ButtonX6.TabIndex = 53
        '
        'ComboItem6
        '
        Me.ComboItem6.Text = "6"
        '
        'ComboItem7
        '
        Me.ComboItem7.Text = "7"
        '
        'ComboItem8
        '
        Me.ComboItem8.Text = "8"
        '
        'ComboItem9
        '
        Me.ComboItem9.Text = "9"
        '
        'ComboItem10
        '
        Me.ComboItem10.Text = "10"
        '
        'ComboItem11
        '
        Me.ComboItem11.Text = "11"
        '
        'ComboItem12
        '
        Me.ComboItem12.Text = "12"
        '
        'ComboItem13
        '
        Me.ComboItem13.Text = "13"
        '
        'comprobante
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.SteelBlue
        Me.ClientSize = New System.Drawing.Size(1050, 661)
        Me.Controls.Add(Me.ButtonX6)
        Me.Controls.Add(Me.LabelX9)
        Me.Controls.Add(Me.LabelX14)
        Me.Controls.Add(Me.buscartxt)
        Me.Controls.Add(Me.boletBusqTB)
        Me.Controls.Add(Me.placaBusqTB)
        Me.Controls.Add(Me.CamDGV)
        Me.Controls.Add(Me.PreviaBtn)
        Me.Controls.Add(Me.ImprimirBt)
        Me.Controls.Add(Me.CancelarBtn)
        Me.Controls.Add(Me.EliminarBtn)
        Me.Controls.Add(Me.EditarBtn)
        Me.Controls.Add(Me.NuevoBtn)
        Me.Controls.Add(Me.GuardarBtn)
        Me.Controls.Add(Me.ModificarBtn)
        Me.Controls.Add(Me.PanelP)
        Me.Controls.Add(Me.LabelX23)
        Me.Controls.Add(Me.nComproTb)
        Me.KeyPreview = True
        Me.Name = "comprobante"
        Me.Text = "comprobante"
        CType(Me.CamDGV, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.fechaPkd, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelP.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents nComproTb As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents PreviaBtn As DevComponents.DotNetBar.ButtonX
    Friend WithEvents ImprimirBt As DevComponents.DotNetBar.ButtonX
    Friend WithEvents CancelarBtn As DevComponents.DotNetBar.ButtonX
    Friend WithEvents EliminarBtn As DevComponents.DotNetBar.ButtonX
    Friend WithEvents EditarBtn As DevComponents.DotNetBar.ButtonX
    Friend WithEvents NuevoBtn As DevComponents.DotNetBar.ButtonX
    Friend WithEvents GuardarBtn As DevComponents.DotNetBar.ButtonX
    Friend WithEvents ModificarBtn As DevComponents.DotNetBar.ButtonX
    Friend WithEvents LabelX23 As DevComponents.DotNetBar.LabelX
    Friend WithEvents CamDGV As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents LabelX9 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX14 As DevComponents.DotNetBar.LabelX
    Friend WithEvents buscartxt As DevComponents.DotNetBar.LabelX
    Friend WithEvents boletBusqTB As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents placaBusqTB As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents galDespTb As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents nombDespTb As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents nBoletaTb As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents codiPropTb As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents rutaTb As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents nConteTb As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents propCbzTb As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents valorTb As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents nombCondTb As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents placaCbzTb As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX10 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX16 As DevComponents.DotNetBar.LabelX
    Friend WithEvents pLetras As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX21 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX22 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX11 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX6 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX19 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX12 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX5 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX7 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX8 As DevComponents.DotNetBar.LabelX
    Friend WithEvents fechaPkd As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents LabelX13 As DevComponents.DotNetBar.LabelX
    Friend WithEvents semanaTb As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents S1 As DevComponents.Editors.ComboItem
    Friend WithEvents S2 As DevComponents.Editors.ComboItem
    Friend WithEvents S3 As DevComponents.Editors.ComboItem
    Friend WithEvents S4 As DevComponents.Editors.ComboItem
    Friend WithEvents S5 As DevComponents.Editors.ComboItem
    Friend WithEvents proxSemTb As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents Si As DevComponents.Editors.ComboItem
    Friend WithEvents No As DevComponents.Editors.ComboItem
    Friend WithEvents periodoTb As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents ComboItem1 As DevComponents.Editors.ComboItem
    Friend WithEvents ComboItem2 As DevComponents.Editors.ComboItem
    Friend WithEvents ComboItem3 As DevComponents.Editors.ComboItem
    Friend WithEvents ComboItem4 As DevComponents.Editors.ComboItem
    Friend WithEvents ComboItem5 As DevComponents.Editors.ComboItem
    Friend WithEvents placaCbzTb2 As DevComponents.DotNetBar.ListBoxAdv
    Friend WithEvents PanelP As Panel
    Friend WithEvents ButtonX6 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents ComboItem6 As DevComponents.Editors.ComboItem
    Friend WithEvents ComboItem7 As DevComponents.Editors.ComboItem
    Friend WithEvents ComboItem8 As DevComponents.Editors.ComboItem
    Friend WithEvents ComboItem9 As DevComponents.Editors.ComboItem
    Friend WithEvents ComboItem10 As DevComponents.Editors.ComboItem
    Friend WithEvents ComboItem11 As DevComponents.Editors.ComboItem
    Friend WithEvents ComboItem12 As DevComponents.Editors.ComboItem
    Friend WithEvents ComboItem13 As DevComponents.Editors.ComboItem
End Class
