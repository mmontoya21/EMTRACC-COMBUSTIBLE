<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class placa
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
        Me.buscartxt = New DevComponents.DotNetBar.LabelX()
        Me.propBusqTB = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.placaBusqTB = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.ButtonX6 = New DevComponents.DotNetBar.ButtonX()
        Me.LabelX10 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX9 = New DevComponents.DotNetBar.LabelX()
        Me.CamDGV = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.BalloonTip1 = New DevComponents.DotNetBar.BalloonTip()
        Me.codTb = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.propTb = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.placaTb = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.obserTb = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX6 = New DevComponents.DotNetBar.LabelX()
        Me.PanelP = New System.Windows.Forms.Panel()
        CType(Me.CamDGV, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelP.SuspendLayout()
        Me.SuspendLayout()
        '
        'CancelarBtn
        '
        Me.CancelarBtn.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.CancelarBtn.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.CancelarBtn.Font = New System.Drawing.Font("Comic Sans MS", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CancelarBtn.Location = New System.Drawing.Point(639, 12)
        Me.CancelarBtn.Name = "CancelarBtn"
        Me.CancelarBtn.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor(2, 2, 2, 10)
        Me.CancelarBtn.Size = New System.Drawing.Size(82, 33)
        Me.CancelarBtn.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.CancelarBtn.Symbol = ""
        Me.CancelarBtn.SymbolSize = 12.0!
        Me.CancelarBtn.TabIndex = 20
        Me.CancelarBtn.Text = "Cancelar"
        '
        'EliminarBtn
        '
        Me.EliminarBtn.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.EliminarBtn.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.EliminarBtn.Font = New System.Drawing.Font("Comic Sans MS", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EliminarBtn.Location = New System.Drawing.Point(551, 12)
        Me.EliminarBtn.Name = "EliminarBtn"
        Me.EliminarBtn.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor(2, 2, 10, 2)
        Me.EliminarBtn.Size = New System.Drawing.Size(82, 33)
        Me.EliminarBtn.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.EliminarBtn.Symbol = ""
        Me.EliminarBtn.SymbolColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.EliminarBtn.SymbolSize = 12.0!
        Me.EliminarBtn.TabIndex = 19
        Me.EliminarBtn.Text = "Eliminar"
        '
        'EditarBtn
        '
        Me.EditarBtn.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.EditarBtn.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.EditarBtn.Font = New System.Drawing.Font("Comic Sans MS", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EditarBtn.Location = New System.Drawing.Point(114, 12)
        Me.EditarBtn.Name = "EditarBtn"
        Me.EditarBtn.Size = New System.Drawing.Size(82, 33)
        Me.EditarBtn.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.EditarBtn.Symbol = ""
        Me.EditarBtn.SymbolSize = 12.0!
        Me.EditarBtn.TabIndex = 17
        Me.EditarBtn.Text = "Editar"
        '
        'NuevoBtn
        '
        Me.NuevoBtn.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.BalloonTip1.SetBalloonCaption(Me.NuevoBtn, "Nuevo Registro")
        Me.BalloonTip1.SetBalloonText(Me.NuevoBtn, "Crea un nuevo registro.")
        Me.NuevoBtn.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.NuevoBtn.Font = New System.Drawing.Font("Comic Sans MS", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NuevoBtn.Location = New System.Drawing.Point(26, 12)
        Me.NuevoBtn.Name = "NuevoBtn"
        Me.NuevoBtn.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor(2, 2, 10, 2)
        Me.NuevoBtn.Size = New System.Drawing.Size(82, 31)
        Me.NuevoBtn.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.NuevoBtn.Symbol = ""
        Me.NuevoBtn.SymbolSize = 12.0!
        Me.NuevoBtn.TabIndex = 16
        Me.NuevoBtn.Text = " Nuevo"
        '
        'GuardarBtn
        '
        Me.GuardarBtn.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.GuardarBtn.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.GuardarBtn.Font = New System.Drawing.Font("Comic Sans MS", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GuardarBtn.Location = New System.Drawing.Point(202, 12)
        Me.GuardarBtn.Name = "GuardarBtn"
        Me.GuardarBtn.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor(2, 2, 2, 10)
        Me.GuardarBtn.Size = New System.Drawing.Size(103, 33)
        Me.GuardarBtn.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.GuardarBtn.Symbol = ""
        Me.GuardarBtn.SymbolColor = System.Drawing.Color.Green
        Me.GuardarBtn.SymbolSize = 12.0!
        Me.GuardarBtn.TabIndex = 18
        Me.GuardarBtn.Text = "Guardar"
        '
        'ModificarBtn
        '
        Me.ModificarBtn.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ModificarBtn.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ModificarBtn.Font = New System.Drawing.Font("Comic Sans MS", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ModificarBtn.Location = New System.Drawing.Point(201, 13)
        Me.ModificarBtn.Name = "ModificarBtn"
        Me.ModificarBtn.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor(2, 2, 2, 10)
        Me.ModificarBtn.Size = New System.Drawing.Size(103, 31)
        Me.ModificarBtn.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ModificarBtn.Symbol = ""
        Me.ModificarBtn.SymbolSize = 12.0!
        Me.ModificarBtn.TabIndex = 21
        Me.ModificarBtn.Text = "Modificar"
        '
        'buscartxt
        '
        '
        '
        '
        Me.buscartxt.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.buscartxt.Font = New System.Drawing.Font("Comic Sans MS", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.buscartxt.ForeColor = System.Drawing.Color.White
        Me.buscartxt.Location = New System.Drawing.Point(254, 365)
        Me.buscartxt.Name = "buscartxt"
        Me.buscartxt.Size = New System.Drawing.Size(75, 23)
        Me.buscartxt.TabIndex = 28
        Me.buscartxt.Text = "-"
        '
        'propBusqTB
        '
        Me.propBusqTB.BackColor = System.Drawing.Color.SteelBlue
        '
        '
        '
        Me.propBusqTB.Border.BorderBottomWidth = 2
        Me.propBusqTB.Border.BorderLeftWidth = 2
        Me.propBusqTB.Border.BorderRightWidth = 2
        Me.propBusqTB.Border.BorderTopWidth = 2
        Me.propBusqTB.Border.Class = "TextBoxBorder"
        Me.propBusqTB.Border.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.propBusqTB.Font = New System.Drawing.Font("Comic Sans MS", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.propBusqTB.ForeColor = System.Drawing.Color.White
        Me.propBusqTB.Location = New System.Drawing.Point(148, 361)
        Me.propBusqTB.Name = "propBusqTB"
        Me.propBusqTB.PreventEnterBeep = True
        Me.propBusqTB.Size = New System.Drawing.Size(100, 34)
        Me.propBusqTB.TabIndex = 27
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
        Me.placaBusqTB.Location = New System.Drawing.Point(38, 361)
        Me.placaBusqTB.Name = "placaBusqTB"
        Me.placaBusqTB.PreventEnterBeep = True
        Me.placaBusqTB.Size = New System.Drawing.Size(100, 34)
        Me.placaBusqTB.TabIndex = 26
        '
        'ButtonX6
        '
        Me.ButtonX6.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX6.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX6.Location = New System.Drawing.Point(653, 358)
        Me.ButtonX6.Name = "ButtonX6"
        Me.ButtonX6.Size = New System.Drawing.Size(36, 23)
        Me.ButtonX6.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonX6.Symbol = ""
        Me.ButtonX6.SymbolSize = 10.0!
        Me.ButtonX6.TabIndex = 25
        '
        'LabelX10
        '
        '
        '
        '
        Me.LabelX10.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX10.Font = New System.Drawing.Font("Comic Sans MS", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX10.FontBold = True
        Me.LabelX10.ForeColor = System.Drawing.Color.DarkBlue
        Me.LabelX10.Location = New System.Drawing.Point(148, 347)
        Me.LabelX10.Name = "LabelX10"
        Me.LabelX10.Size = New System.Drawing.Size(75, 23)
        Me.LabelX10.TabIndex = 23
        Me.LabelX10.Text = "Código"
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
        Me.LabelX9.Location = New System.Drawing.Point(39, 347)
        Me.LabelX9.Name = "LabelX9"
        Me.LabelX9.Size = New System.Drawing.Size(44, 23)
        Me.LabelX9.TabIndex = 24
        Me.LabelX9.Text = "Placa"
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
        Me.CamDGV.Location = New System.Drawing.Point(38, 403)
        Me.CamDGV.Name = "CamDGV"
        Me.CamDGV.ReadOnly = True
        Me.CamDGV.RowHeadersVisible = False
        Me.CamDGV.Size = New System.Drawing.Size(695, 197)
        Me.CamDGV.TabIndex = 29
        '
        'BalloonTip1
        '
        Me.BalloonTip1.AlertAnimationDuration = 50
        Me.BalloonTip1.InitialDelay = 50
        Me.BalloonTip1.ShowBalloonOnFocus = True
        '
        'codTb
        '
        Me.codTb.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.codTb.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.codTb.BackColor = System.Drawing.Color.SteelBlue
        Me.BalloonTip1.SetBalloonText(Me.codTb, "Para buscar un código, escriba los primeros digitos y luego escoja el que busca e" &
        "n el listado.")
        '
        '
        '
        Me.codTb.Border.BackColor = System.Drawing.Color.SteelBlue
        Me.codTb.Border.BackColor2 = System.Drawing.Color.SteelBlue
        Me.codTb.Border.BorderBottomWidth = 2
        Me.codTb.Border.BorderColor = System.Drawing.SystemColors.Window
        Me.codTb.Border.BorderLeftWidth = 2
        Me.codTb.Border.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.codTb.Border.BorderRightWidth = 2
        Me.codTb.Border.BorderTopWidth = 2
        Me.codTb.Border.Class = "TextBoxBorder"
        Me.codTb.Border.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.codTb.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.codTb.ForeColor = System.Drawing.Color.White
        Me.codTb.Location = New System.Drawing.Point(12, 27)
        Me.codTb.MaxLength = 6
        Me.codTb.Name = "codTb"
        Me.codTb.PreventEnterBeep = True
        Me.codTb.Size = New System.Drawing.Size(173, 30)
        Me.codTb.TabIndex = 0
        '
        'propTb
        '
        Me.propTb.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.propTb.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.propTb.BackColor = System.Drawing.Color.SteelBlue
        '
        '
        '
        Me.propTb.Border.BackColor = System.Drawing.Color.SteelBlue
        Me.propTb.Border.BackColor2 = System.Drawing.Color.SteelBlue
        Me.propTb.Border.BorderBottomWidth = 2
        Me.propTb.Border.BorderColor = System.Drawing.SystemColors.Window
        Me.propTb.Border.BorderLeftWidth = 2
        Me.propTb.Border.BorderRightWidth = 2
        Me.propTb.Border.BorderTopWidth = 2
        Me.propTb.Border.Class = "TextBoxBorder"
        Me.propTb.Border.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.propTb.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.propTb.ForeColor = System.Drawing.Color.White
        Me.propTb.Location = New System.Drawing.Point(216, 27)
        Me.propTb.MaxLength = 30
        Me.propTb.Name = "propTb"
        Me.propTb.PreventEnterBeep = True
        Me.propTb.Size = New System.Drawing.Size(340, 30)
        Me.propTb.TabIndex = 1
        '
        'placaTb
        '
        Me.placaTb.BackColor = System.Drawing.Color.SteelBlue
        '
        '
        '
        Me.placaTb.Border.BorderBottomWidth = 2
        Me.placaTb.Border.BorderColor = System.Drawing.SystemColors.Window
        Me.placaTb.Border.BorderLeftWidth = 2
        Me.placaTb.Border.BorderRightWidth = 2
        Me.placaTb.Border.BorderTopWidth = 2
        Me.placaTb.Border.Class = "TextBoxBorder"
        Me.placaTb.Border.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.placaTb.Font = New System.Drawing.Font("Comic Sans MS", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.placaTb.ForeColor = System.Drawing.Color.White
        Me.placaTb.Location = New System.Drawing.Point(12, 74)
        Me.placaTb.MaxLength = 15
        Me.placaTb.Name = "placaTb"
        Me.placaTb.PreventEnterBeep = True
        Me.placaTb.Size = New System.Drawing.Size(207, 34)
        Me.placaTb.TabIndex = 2
        '
        'LabelX3
        '
        '
        '
        '
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX3.Font = New System.Drawing.Font("Comic Sans MS", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX3.ForeColor = System.Drawing.Color.DarkBlue
        Me.LabelX3.Location = New System.Drawing.Point(16, 61)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(54, 23)
        Me.LabelX3.TabIndex = 1
        Me.LabelX3.Text = "Placa"
        '
        'obserTb
        '
        Me.obserTb.BackColor = System.Drawing.Color.SteelBlue
        '
        '
        '
        Me.obserTb.Border.BorderBottomWidth = 2
        Me.obserTb.Border.BorderColor = System.Drawing.SystemColors.Window
        Me.obserTb.Border.BorderLeftWidth = 2
        Me.obserTb.Border.BorderRightWidth = 2
        Me.obserTb.Border.BorderTopWidth = 2
        Me.obserTb.Border.Class = "TextBoxBorder"
        Me.obserTb.Border.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.obserTb.Font = New System.Drawing.Font("Comic Sans MS", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.obserTb.ForeColor = System.Drawing.Color.White
        Me.obserTb.Location = New System.Drawing.Point(12, 126)
        Me.obserTb.MaxLength = 200
        Me.obserTb.Multiline = True
        Me.obserTb.Name = "obserTb"
        Me.obserTb.PreventEnterBeep = True
        Me.obserTb.Size = New System.Drawing.Size(683, 131)
        Me.obserTb.TabIndex = 3
        '
        'LabelX1
        '
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Font = New System.Drawing.Font("Comic Sans MS", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX1.ForeColor = System.Drawing.Color.DarkBlue
        Me.LabelX1.Location = New System.Drawing.Point(12, 7)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(60, 23)
        Me.LabelX1.TabIndex = 1
        Me.LabelX1.Text = "Código"
        '
        'LabelX2
        '
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.Font = New System.Drawing.Font("Comic Sans MS", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX2.ForeColor = System.Drawing.Color.DarkBlue
        Me.LabelX2.Location = New System.Drawing.Point(216, 8)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(97, 23)
        Me.LabelX2.TabIndex = 1
        Me.LabelX2.Text = "Propietario"
        '
        'LabelX6
        '
        '
        '
        '
        Me.LabelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX6.Font = New System.Drawing.Font("Comic Sans MS", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX6.ForeColor = System.Drawing.Color.DarkBlue
        Me.LabelX6.Location = New System.Drawing.Point(17, 110)
        Me.LabelX6.Name = "LabelX6"
        Me.LabelX6.Size = New System.Drawing.Size(115, 23)
        Me.LabelX6.TabIndex = 1
        Me.LabelX6.Text = "Observaciones"
        '
        'PanelP
        '
        Me.PanelP.Controls.Add(Me.LabelX1)
        Me.PanelP.Controls.Add(Me.LabelX3)
        Me.PanelP.Controls.Add(Me.LabelX6)
        Me.PanelP.Controls.Add(Me.obserTb)
        Me.PanelP.Controls.Add(Me.LabelX2)
        Me.PanelP.Controls.Add(Me.codTb)
        Me.PanelP.Controls.Add(Me.propTb)
        Me.PanelP.Controls.Add(Me.placaTb)
        Me.PanelP.Location = New System.Drawing.Point(26, 74)
        Me.PanelP.Name = "PanelP"
        Me.PanelP.Size = New System.Drawing.Size(707, 267)
        Me.PanelP.TabIndex = 22
        '
        'placa
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.SteelBlue
        Me.ClientSize = New System.Drawing.Size(744, 604)
        Me.Controls.Add(Me.LabelX10)
        Me.Controls.Add(Me.LabelX9)
        Me.Controls.Add(Me.CamDGV)
        Me.Controls.Add(Me.buscartxt)
        Me.Controls.Add(Me.propBusqTB)
        Me.Controls.Add(Me.placaBusqTB)
        Me.Controls.Add(Me.ButtonX6)
        Me.Controls.Add(Me.PanelP)
        Me.Controls.Add(Me.CancelarBtn)
        Me.Controls.Add(Me.EliminarBtn)
        Me.Controls.Add(Me.EditarBtn)
        Me.Controls.Add(Me.NuevoBtn)
        Me.Controls.Add(Me.GuardarBtn)
        Me.Controls.Add(Me.ModificarBtn)
        Me.Name = "placa"
        Me.Text = "Placa"
        CType(Me.CamDGV, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelP.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents CancelarBtn As DevComponents.DotNetBar.ButtonX
    Friend WithEvents EliminarBtn As DevComponents.DotNetBar.ButtonX
    Friend WithEvents EditarBtn As DevComponents.DotNetBar.ButtonX
    Friend WithEvents NuevoBtn As DevComponents.DotNetBar.ButtonX
    Friend WithEvents GuardarBtn As DevComponents.DotNetBar.ButtonX
    Friend WithEvents ModificarBtn As DevComponents.DotNetBar.ButtonX
    Friend WithEvents buscartxt As DevComponents.DotNetBar.LabelX
    Friend WithEvents propBusqTB As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents placaBusqTB As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents ButtonX6 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents LabelX10 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX9 As DevComponents.DotNetBar.LabelX
    Friend WithEvents CamDGV As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents BalloonTip1 As DevComponents.DotNetBar.BalloonTip
    Friend WithEvents codTb As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents propTb As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents placaTb As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents obserTb As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX6 As DevComponents.DotNetBar.LabelX
    Friend WithEvents PanelP As Panel
End Class
