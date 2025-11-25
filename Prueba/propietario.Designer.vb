<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class propietario
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.codProTb = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.nPropietarioTb = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.RTNTb = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.nEmpresaTb = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Tel2Tb = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.correoETb = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.DireccionTb = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Tel1TB = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.CancelarBtn = New DevComponents.DotNetBar.ButtonX()
        Me.EliminarBtn = New DevComponents.DotNetBar.ButtonX()
        Me.EditarBtn = New DevComponents.DotNetBar.ButtonX()
        Me.NuevoBtn = New DevComponents.DotNetBar.ButtonX()
        Me.GuardarBtn = New DevComponents.DotNetBar.ButtonX()
        Me.ModificarBtn = New DevComponents.DotNetBar.ButtonX()
        Me.CamDGV = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.PanelP = New System.Windows.Forms.Panel()
        Me.buscartxt = New DevComponents.DotNetBar.LabelX()
        Me.propBusqTB = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.placaBusqTB = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.ButtonX6 = New DevComponents.DotNetBar.ButtonX()
        Me.LabelX10 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX9 = New DevComponents.DotNetBar.LabelX()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        CType(Me.CamDGV, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelP.SuspendLayout()
        Me.SuspendLayout()
        '
        'codProTb
        '
        '
        '
        '
        Me.codProTb.Border.Class = "TextBoxBorder"
        Me.codProTb.Border.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.codProTb.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.codProTb.Location = New System.Drawing.Point(102, 10)
        Me.codProTb.MaxLength = 10
        Me.codProTb.Name = "codProTb"
        Me.codProTb.PreventEnterBeep = True
        Me.codProTb.Size = New System.Drawing.Size(152, 30)
        Me.codProTb.TabIndex = 1
        '
        'nPropietarioTb
        '
        '
        '
        '
        Me.nPropietarioTb.Border.Class = "TextBoxBorder"
        Me.nPropietarioTb.Border.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.nPropietarioTb.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.nPropietarioTb.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nPropietarioTb.Location = New System.Drawing.Point(102, 46)
        Me.nPropietarioTb.MaxLength = 80
        Me.nPropietarioTb.Name = "nPropietarioTb"
        Me.nPropietarioTb.PreventEnterBeep = True
        Me.nPropietarioTb.Size = New System.Drawing.Size(372, 30)
        Me.nPropietarioTb.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(6, 3)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(93, 44)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Código Propietario"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'RTNTb
        '
        '
        '
        '
        Me.RTNTb.Border.Class = "TextBoxBorder"
        Me.RTNTb.Border.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.RTNTb.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RTNTb.Location = New System.Drawing.Point(322, 10)
        Me.RTNTb.MaxLength = 15
        Me.RTNTb.Name = "RTNTb"
        Me.RTNTb.PreventEnterBeep = True
        Me.RTNTb.Size = New System.Drawing.Size(152, 30)
        Me.RTNTb.TabIndex = 2
        '
        'nEmpresaTb
        '
        '
        '
        '
        Me.nEmpresaTb.Border.Class = "TextBoxBorder"
        Me.nEmpresaTb.Border.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.nEmpresaTb.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.nEmpresaTb.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nEmpresaTb.Location = New System.Drawing.Point(102, 82)
        Me.nEmpresaTb.MaxLength = 80
        Me.nEmpresaTb.Name = "nEmpresaTb"
        Me.nEmpresaTb.PreventEnterBeep = True
        Me.nEmpresaTb.Size = New System.Drawing.Size(372, 30)
        Me.nEmpresaTb.TabIndex = 4
        '
        'Tel2Tb
        '
        '
        '
        '
        Me.Tel2Tb.Border.Class = "TextBoxBorder"
        Me.Tel2Tb.Border.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Tel2Tb.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Tel2Tb.Location = New System.Drawing.Point(322, 118)
        Me.Tel2Tb.MaxLength = 12
        Me.Tel2Tb.Name = "Tel2Tb"
        Me.Tel2Tb.PreventEnterBeep = True
        Me.Tel2Tb.Size = New System.Drawing.Size(152, 30)
        Me.Tel2Tb.TabIndex = 6
        '
        'correoETb
        '
        '
        '
        '
        Me.correoETb.Border.Class = "TextBoxBorder"
        Me.correoETb.Border.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.correoETb.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.correoETb.Location = New System.Drawing.Point(102, 154)
        Me.correoETb.MaxLength = 50
        Me.correoETb.Name = "correoETb"
        Me.correoETb.PreventEnterBeep = True
        Me.correoETb.Size = New System.Drawing.Size(173, 30)
        Me.correoETb.TabIndex = 7
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(14, 88)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(85, 24)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Empresa"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'DireccionTb
        '
        '
        '
        '
        Me.DireccionTb.Border.Class = "TextBoxBorder"
        Me.DireccionTb.Border.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.DireccionTb.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DireccionTb.Location = New System.Drawing.Point(102, 190)
        Me.DireccionTb.MaxLength = 300
        Me.DireccionTb.Multiline = True
        Me.DireccionTb.Name = "DireccionTb"
        Me.DireccionTb.PreventEnterBeep = True
        Me.DireccionTb.Size = New System.Drawing.Size(364, 115)
        Me.DireccionTb.TabIndex = 8
        '
        'Tel1TB
        '
        '
        '
        '
        Me.Tel1TB.Border.Class = "TextBoxBorder"
        Me.Tel1TB.Border.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.Tel1TB.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Tel1TB.Location = New System.Drawing.Point(102, 118)
        Me.Tel1TB.MaxLength = 12
        Me.Tel1TB.Name = "Tel1TB"
        Me.Tel1TB.PreventEnterBeep = True
        Me.Tel1TB.Size = New System.Drawing.Size(148, 30)
        Me.Tel1TB.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(18, 54)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(81, 17)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Propietario"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(276, 16)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(42, 19)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "RTN"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(14, 150)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(85, 37)
        Me.Label5.TabIndex = 15
        Me.Label5.Text = "Correo Electrónico"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(14, 195)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(85, 17)
        Me.Label6.TabIndex = 13
        Me.Label6.Text = "Dirección"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label8
        '
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(63, 120)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(36, 30)
        Me.Label8.TabIndex = 12
        Me.Label8.Text = "Tel 1"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(268, 118)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(48, 30)
        Me.Label7.TabIndex = 16
        Me.Label7.Text = "Tel. 2"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'CancelarBtn
        '
        Me.CancelarBtn.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.CancelarBtn.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.CancelarBtn.Location = New System.Drawing.Point(374, 12)
        Me.CancelarBtn.Name = "CancelarBtn"
        Me.CancelarBtn.Size = New System.Drawing.Size(82, 40)
        Me.CancelarBtn.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.CancelarBtn.Symbol = ""
        Me.CancelarBtn.SymbolSize = 12.0!
        Me.CancelarBtn.TabIndex = 32
        Me.CancelarBtn.Text = "Cancelar"
        '
        'EliminarBtn
        '
        Me.EliminarBtn.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.EliminarBtn.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.EliminarBtn.Location = New System.Drawing.Point(286, 12)
        Me.EliminarBtn.Name = "EliminarBtn"
        Me.EliminarBtn.Size = New System.Drawing.Size(82, 40)
        Me.EliminarBtn.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.EliminarBtn.Symbol = ""
        Me.EliminarBtn.SymbolColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.EliminarBtn.SymbolSize = 12.0!
        Me.EliminarBtn.TabIndex = 31
        Me.EliminarBtn.Text = "Eliminar"
        '
        'EditarBtn
        '
        Me.EditarBtn.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.EditarBtn.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.EditarBtn.Location = New System.Drawing.Point(98, 12)
        Me.EditarBtn.Name = "EditarBtn"
        Me.EditarBtn.Size = New System.Drawing.Size(82, 40)
        Me.EditarBtn.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.EditarBtn.Symbol = ""
        Me.EditarBtn.SymbolSize = 12.0!
        Me.EditarBtn.TabIndex = 29
        Me.EditarBtn.Text = "Editar"
        '
        'NuevoBtn
        '
        Me.NuevoBtn.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.NuevoBtn.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.NuevoBtn.Location = New System.Drawing.Point(10, 12)
        Me.NuevoBtn.Name = "NuevoBtn"
        Me.NuevoBtn.Size = New System.Drawing.Size(82, 38)
        Me.NuevoBtn.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.NuevoBtn.Symbol = ""
        Me.NuevoBtn.SymbolSize = 12.0!
        Me.NuevoBtn.TabIndex = 28
        Me.NuevoBtn.Text = " Nuevo"
        '
        'GuardarBtn
        '
        Me.GuardarBtn.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.GuardarBtn.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.GuardarBtn.Location = New System.Drawing.Point(185, 12)
        Me.GuardarBtn.Name = "GuardarBtn"
        Me.GuardarBtn.Size = New System.Drawing.Size(82, 40)
        Me.GuardarBtn.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.GuardarBtn.Symbol = ""
        Me.GuardarBtn.SymbolColor = System.Drawing.Color.Green
        Me.GuardarBtn.SymbolSize = 12.0!
        Me.GuardarBtn.TabIndex = 30
        Me.GuardarBtn.Text = "Guardar"
        '
        'ModificarBtn
        '
        Me.ModificarBtn.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ModificarBtn.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ModificarBtn.Location = New System.Drawing.Point(185, 13)
        Me.ModificarBtn.Name = "ModificarBtn"
        Me.ModificarBtn.Size = New System.Drawing.Size(82, 38)
        Me.ModificarBtn.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ModificarBtn.Symbol = ""
        Me.ModificarBtn.SymbolSize = 12.0!
        Me.ModificarBtn.TabIndex = 33
        Me.ModificarBtn.Text = "Modificar"
        '
        'CamDGV
        '
        Me.CamDGV.AllowUserToAddRows = False
        Me.CamDGV.AllowUserToDeleteRows = False
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
        Me.CamDGV.Location = New System.Drawing.Point(503, 70)
        Me.CamDGV.Name = "CamDGV"
        Me.CamDGV.ReadOnly = True
        Me.CamDGV.RowHeadersVisible = False
        Me.CamDGV.Size = New System.Drawing.Size(803, 490)
        Me.CamDGV.TabIndex = 34
        '
        'PanelP
        '
        Me.PanelP.Controls.Add(Me.Label7)
        Me.PanelP.Controls.Add(Me.Label5)
        Me.PanelP.Controls.Add(Me.Label6)
        Me.PanelP.Controls.Add(Me.Label8)
        Me.PanelP.Controls.Add(Me.Label4)
        Me.PanelP.Controls.Add(Me.Tel2Tb)
        Me.PanelP.Controls.Add(Me.correoETb)
        Me.PanelP.Controls.Add(Me.Label3)
        Me.PanelP.Controls.Add(Me.Label2)
        Me.PanelP.Controls.Add(Me.DireccionTb)
        Me.PanelP.Controls.Add(Me.Tel1TB)
        Me.PanelP.Controls.Add(Me.nEmpresaTb)
        Me.PanelP.Controls.Add(Me.RTNTb)
        Me.PanelP.Controls.Add(Me.Label1)
        Me.PanelP.Controls.Add(Me.nPropietarioTb)
        Me.PanelP.Controls.Add(Me.codProTb)
        Me.PanelP.Location = New System.Drawing.Point(10, 60)
        Me.PanelP.Name = "PanelP"
        Me.PanelP.Size = New System.Drawing.Size(487, 500)
        Me.PanelP.TabIndex = 35
        '
        'buscartxt
        '
        '
        '
        '
        Me.buscartxt.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.buscartxt.Location = New System.Drawing.Point(720, 41)
        Me.buscartxt.Name = "buscartxt"
        Me.buscartxt.Size = New System.Drawing.Size(75, 23)
        Me.buscartxt.TabIndex = 41
        Me.buscartxt.Text = "-"
        '
        'propBusqTB
        '
        '
        '
        '
        Me.propBusqTB.Border.Class = "TextBoxBorder"
        Me.propBusqTB.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.propBusqTB.Location = New System.Drawing.Point(614, 44)
        Me.propBusqTB.Name = "propBusqTB"
        Me.propBusqTB.PreventEnterBeep = True
        Me.propBusqTB.Size = New System.Drawing.Size(100, 20)
        Me.propBusqTB.TabIndex = 40
        '
        'placaBusqTB
        '
        '
        '
        '
        Me.placaBusqTB.Border.Class = "TextBoxBorder"
        Me.placaBusqTB.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.placaBusqTB.Location = New System.Drawing.Point(504, 44)
        Me.placaBusqTB.Name = "placaBusqTB"
        Me.placaBusqTB.PreventEnterBeep = True
        Me.placaBusqTB.Size = New System.Drawing.Size(100, 20)
        Me.placaBusqTB.TabIndex = 39
        '
        'ButtonX6
        '
        Me.ButtonX6.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX6.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX6.Location = New System.Drawing.Point(837, 41)
        Me.ButtonX6.Name = "ButtonX6"
        Me.ButtonX6.Size = New System.Drawing.Size(36, 23)
        Me.ButtonX6.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonX6.Symbol = ""
        Me.ButtonX6.SymbolSize = 10.0!
        Me.ButtonX6.TabIndex = 38
        '
        'LabelX10
        '
        '
        '
        '
        Me.LabelX10.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX10.Location = New System.Drawing.Point(614, 24)
        Me.LabelX10.Name = "LabelX10"
        Me.LabelX10.Size = New System.Drawing.Size(75, 23)
        Me.LabelX10.TabIndex = 36
        Me.LabelX10.Text = "Propietario"
        '
        'LabelX9
        '
        '
        '
        '
        Me.LabelX9.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX9.Location = New System.Drawing.Point(505, 24)
        Me.LabelX9.Name = "LabelX9"
        Me.LabelX9.Size = New System.Drawing.Size(62, 23)
        Me.LabelX9.TabIndex = 37
        Me.LabelX9.Text = "Cóodigo"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(916, 44)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 42
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Location = New System.Drawing.Point(767, 148)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(8, 20)
        Me.DateTimePicker1.TabIndex = 43
        '
        'propietario
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.ClientSize = New System.Drawing.Size(1328, 572)
        Me.Controls.Add(Me.DateTimePicker1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.buscartxt)
        Me.Controls.Add(Me.propBusqTB)
        Me.Controls.Add(Me.placaBusqTB)
        Me.Controls.Add(Me.ButtonX6)
        Me.Controls.Add(Me.LabelX10)
        Me.Controls.Add(Me.LabelX9)
        Me.Controls.Add(Me.PanelP)
        Me.Controls.Add(Me.CamDGV)
        Me.Controls.Add(Me.CancelarBtn)
        Me.Controls.Add(Me.EliminarBtn)
        Me.Controls.Add(Me.EditarBtn)
        Me.Controls.Add(Me.NuevoBtn)
        Me.Controls.Add(Me.GuardarBtn)
        Me.Controls.Add(Me.ModificarBtn)
        Me.Name = "propietario"
        Me.Text = "=== Propietario ==="
        CType(Me.CamDGV, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelP.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents codProTb As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents nPropietarioTb As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Label1 As Label
    Friend WithEvents RTNTb As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents nEmpresaTb As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Tel2Tb As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents correoETb As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Label2 As Label
    Friend WithEvents DireccionTb As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Tel1TB As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents CancelarBtn As DevComponents.DotNetBar.ButtonX
    Friend WithEvents EliminarBtn As DevComponents.DotNetBar.ButtonX
    Friend WithEvents EditarBtn As DevComponents.DotNetBar.ButtonX
    Friend WithEvents NuevoBtn As DevComponents.DotNetBar.ButtonX
    Friend WithEvents GuardarBtn As DevComponents.DotNetBar.ButtonX
    Friend WithEvents ModificarBtn As DevComponents.DotNetBar.ButtonX
    Friend WithEvents CamDGV As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents PanelP As Panel
    Friend WithEvents buscartxt As DevComponents.DotNetBar.LabelX
    Friend WithEvents propBusqTB As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents placaBusqTB As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents ButtonX6 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents LabelX10 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX9 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Button1 As Button
    Friend WithEvents DateTimePicker1 As DateTimePicker
End Class
