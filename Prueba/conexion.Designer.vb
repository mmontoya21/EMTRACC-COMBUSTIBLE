<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class conexion
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(conexion))
        Me.BalloonTip1 = New DevComponents.DotNetBar.BalloonTip()
        Me.srvTb = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.userTb = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.bdTb = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.passTb = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX6 = New DevComponents.DotNetBar.LabelX()
        Me.GuardarBtn = New DevComponents.DotNetBar.ButtonX()
        Me.NuevoBtn = New DevComponents.DotNetBar.ButtonX()
        Me.EditarBtn = New DevComponents.DotNetBar.ButtonX()
        Me.EliminarBtn = New DevComponents.DotNetBar.ButtonX()
        Me.CancelarBtn = New DevComponents.DotNetBar.ButtonX()
        Me.CamDGV = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.ButtonX6 = New DevComponents.DotNetBar.ButtonX()
        Me.placaBusqTB = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.propBusqTB = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX9 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX10 = New DevComponents.DotNetBar.LabelX()
        Me.buscartxt = New DevComponents.DotNetBar.LabelX()
        Me.ModificarBtn = New DevComponents.DotNetBar.ButtonX()
        Me.PanelP = New System.Windows.Forms.Panel()
        Me.ButtonX1 = New DevComponents.DotNetBar.ButtonX()
        Me.ButtonX2 = New DevComponents.DotNetBar.ButtonX()
        CType(Me.CamDGV, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelP.SuspendLayout()
        Me.SuspendLayout()
        '
        'srvTb
        '
        '
        '
        '
        Me.srvTb.Border.Class = "TextBoxBorder"
        Me.srvTb.Border.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.srvTb.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.srvTb.Location = New System.Drawing.Point(117, 27)
        Me.srvTb.MaxLength = 90
        Me.srvTb.Name = "srvTb"
        Me.srvTb.PreventEnterBeep = True
        Me.srvTb.Size = New System.Drawing.Size(173, 30)
        Me.srvTb.TabIndex = 0
        '
        'userTb
        '
        '
        '
        '
        Me.userTb.Border.Class = "TextBoxBorder"
        Me.userTb.Border.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.userTb.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.userTb.Location = New System.Drawing.Point(449, 26)
        Me.userTb.MaxLength = 90
        Me.userTb.Name = "userTb"
        Me.userTb.PreventEnterBeep = True
        Me.userTb.Size = New System.Drawing.Size(207, 30)
        Me.userTb.TabIndex = 1
        '
        'bdTb
        '
        '
        '
        '
        Me.bdTb.Border.Class = "TextBoxBorder"
        Me.bdTb.Border.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.bdTb.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bdTb.Location = New System.Drawing.Point(117, 63)
        Me.bdTb.MaxLength = 90
        Me.bdTb.Name = "bdTb"
        Me.bdTb.PreventEnterBeep = True
        Me.bdTb.Size = New System.Drawing.Size(207, 30)
        Me.bdTb.TabIndex = 2
        '
        'LabelX1
        '
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX1.Location = New System.Drawing.Point(45, 26)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(65, 23)
        Me.LabelX1.TabIndex = 1
        Me.LabelX1.Text = "Servidor"
        Me.LabelX1.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'LabelX2
        '
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX2.Location = New System.Drawing.Point(368, 33)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(75, 23)
        Me.LabelX2.TabIndex = 1
        Me.LabelX2.Text = "Usuario"
        Me.LabelX2.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'LabelX3
        '
        '
        '
        '
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX3.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX3.Location = New System.Drawing.Point(17, 65)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(93, 23)
        Me.LabelX3.TabIndex = 1
        Me.LabelX3.Text = "Base datos"
        Me.LabelX3.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'passTb
        '
        '
        '
        '
        Me.passTb.Border.Class = "TextBoxBorder"
        Me.passTb.Border.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.passTb.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.passTb.Location = New System.Drawing.Point(449, 62)
        Me.passTb.MaxLength = 90
        Me.passTb.Name = "passTb"
        Me.passTb.PreventEnterBeep = True
        Me.passTb.Size = New System.Drawing.Size(207, 30)
        Me.passTb.TabIndex = 3
        '
        'LabelX6
        '
        '
        '
        '
        Me.LabelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX6.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX6.Location = New System.Drawing.Point(381, 62)
        Me.LabelX6.Name = "LabelX6"
        Me.LabelX6.Size = New System.Drawing.Size(62, 23)
        Me.LabelX6.TabIndex = 1
        Me.LabelX6.Text = "Clave"
        Me.LabelX6.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'GuardarBtn
        '
        Me.GuardarBtn.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.GuardarBtn.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.GuardarBtn.Location = New System.Drawing.Point(192, 12)
        Me.GuardarBtn.Name = "GuardarBtn"
        Me.GuardarBtn.Size = New System.Drawing.Size(82, 40)
        Me.GuardarBtn.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.GuardarBtn.Symbol = ""
        Me.GuardarBtn.SymbolColor = System.Drawing.Color.Green
        Me.GuardarBtn.SymbolSize = 12.0!
        Me.GuardarBtn.TabIndex = 10
        Me.GuardarBtn.Text = "Guardar"
        '
        'NuevoBtn
        '
        Me.NuevoBtn.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.NuevoBtn.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.NuevoBtn.Location = New System.Drawing.Point(17, 12)
        Me.NuevoBtn.Name = "NuevoBtn"
        Me.NuevoBtn.Size = New System.Drawing.Size(82, 38)
        Me.NuevoBtn.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.NuevoBtn.Symbol = ""
        Me.NuevoBtn.SymbolSize = 12.0!
        Me.NuevoBtn.TabIndex = 8
        Me.NuevoBtn.Text = " Nuevo"
        '
        'EditarBtn
        '
        Me.EditarBtn.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.EditarBtn.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.EditarBtn.Location = New System.Drawing.Point(105, 12)
        Me.EditarBtn.Name = "EditarBtn"
        Me.EditarBtn.Size = New System.Drawing.Size(82, 40)
        Me.EditarBtn.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.EditarBtn.Symbol = ""
        Me.EditarBtn.SymbolSize = 12.0!
        Me.EditarBtn.TabIndex = 9
        Me.EditarBtn.Text = "Editar"
        '
        'EliminarBtn
        '
        Me.EliminarBtn.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.EliminarBtn.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.EliminarBtn.Location = New System.Drawing.Point(313, 12)
        Me.EliminarBtn.Name = "EliminarBtn"
        Me.EliminarBtn.Size = New System.Drawing.Size(82, 40)
        Me.EliminarBtn.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.EliminarBtn.Symbol = ""
        Me.EliminarBtn.SymbolColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.EliminarBtn.SymbolSize = 12.0!
        Me.EliminarBtn.TabIndex = 11
        Me.EliminarBtn.Text = "Eliminar"
        '
        'CancelarBtn
        '
        Me.CancelarBtn.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.CancelarBtn.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.CancelarBtn.Location = New System.Drawing.Point(401, 12)
        Me.CancelarBtn.Name = "CancelarBtn"
        Me.CancelarBtn.Size = New System.Drawing.Size(82, 40)
        Me.CancelarBtn.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.CancelarBtn.Symbol = ""
        Me.CancelarBtn.SymbolSize = 12.0!
        Me.CancelarBtn.TabIndex = 12
        Me.CancelarBtn.Text = "Cancelar"
        '
        'CamDGV
        '
        Me.CamDGV.AllowUserToAddRows = False
        Me.CamDGV.AllowUserToDeleteRows = False
        Me.CamDGV.AllowUserToOrderColumns = True
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
        Me.CamDGV.Location = New System.Drawing.Point(17, 211)
        Me.CamDGV.Name = "CamDGV"
        Me.CamDGV.ReadOnly = True
        Me.CamDGV.RowHeadersVisible = False
        Me.CamDGV.Size = New System.Drawing.Size(695, 99)
        Me.CamDGV.TabIndex = 13
        '
        'ButtonX6
        '
        Me.ButtonX6.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX6.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX6.Location = New System.Drawing.Point(637, 178)
        Me.ButtonX6.Name = "ButtonX6"
        Me.ButtonX6.Size = New System.Drawing.Size(36, 23)
        Me.ButtonX6.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonX6.Symbol = ""
        Me.ButtonX6.SymbolSize = 10.0!
        Me.ButtonX6.TabIndex = 8
        '
        'placaBusqTB
        '
        '
        '
        '
        Me.placaBusqTB.Border.Class = "TextBoxBorder"
        Me.placaBusqTB.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.placaBusqTB.Location = New System.Drawing.Point(48, 185)
        Me.placaBusqTB.Name = "placaBusqTB"
        Me.placaBusqTB.PreventEnterBeep = True
        Me.placaBusqTB.Size = New System.Drawing.Size(100, 20)
        Me.placaBusqTB.TabIndex = 9
        '
        'propBusqTB
        '
        '
        '
        '
        Me.propBusqTB.Border.Class = "TextBoxBorder"
        Me.propBusqTB.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.propBusqTB.Location = New System.Drawing.Point(156, 252)
        Me.propBusqTB.Name = "propBusqTB"
        Me.propBusqTB.PreventEnterBeep = True
        Me.propBusqTB.Size = New System.Drawing.Size(100, 20)
        Me.propBusqTB.TabIndex = 10
        '
        'LabelX9
        '
        '
        '
        '
        Me.LabelX9.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX9.Location = New System.Drawing.Point(25, 182)
        Me.LabelX9.Name = "LabelX9"
        Me.LabelX9.Size = New System.Drawing.Size(44, 23)
        Me.LabelX9.TabIndex = 1
        Me.LabelX9.Text = "ID"
        '
        'LabelX10
        '
        '
        '
        '
        Me.LabelX10.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX10.Location = New System.Drawing.Point(158, 232)
        Me.LabelX10.Name = "LabelX10"
        Me.LabelX10.Size = New System.Drawing.Size(75, 23)
        Me.LabelX10.TabIndex = 1
        Me.LabelX10.Text = "Propietario"
        '
        'buscartxt
        '
        '
        '
        '
        Me.buscartxt.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.buscartxt.Location = New System.Drawing.Point(262, 252)
        Me.buscartxt.Name = "buscartxt"
        Me.buscartxt.Size = New System.Drawing.Size(75, 23)
        Me.buscartxt.TabIndex = 14
        Me.buscartxt.Text = "-"
        '
        'ModificarBtn
        '
        Me.ModificarBtn.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ModificarBtn.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ModificarBtn.Location = New System.Drawing.Point(192, 13)
        Me.ModificarBtn.Name = "ModificarBtn"
        Me.ModificarBtn.Size = New System.Drawing.Size(82, 38)
        Me.ModificarBtn.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ModificarBtn.Symbol = ""
        Me.ModificarBtn.SymbolSize = 12.0!
        Me.ModificarBtn.TabIndex = 15
        Me.ModificarBtn.Text = "Modificar"
        '
        'PanelP
        '
        Me.PanelP.Controls.Add(Me.LabelX2)
        Me.PanelP.Controls.Add(Me.LabelX6)
        Me.PanelP.Controls.Add(Me.LabelX3)
        Me.PanelP.Controls.Add(Me.passTb)
        Me.PanelP.Controls.Add(Me.LabelX1)
        Me.PanelP.Controls.Add(Me.bdTb)
        Me.PanelP.Controls.Add(Me.userTb)
        Me.PanelP.Controls.Add(Me.srvTb)
        Me.PanelP.Location = New System.Drawing.Point(17, 58)
        Me.PanelP.Name = "PanelP"
        Me.PanelP.Size = New System.Drawing.Size(695, 114)
        Me.PanelP.TabIndex = 16
        '
        'ButtonX1
        '
        Me.ButtonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX1.Location = New System.Drawing.Point(649, 12)
        Me.ButtonX1.Name = "ButtonX1"
        Me.ButtonX1.Size = New System.Drawing.Size(49, 37)
        Me.ButtonX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonX1.Symbol = "58940"
        Me.ButtonX1.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
        Me.ButtonX1.TabIndex = 17
        '
        'ButtonX2
        '
        Me.ButtonX2.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX2.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX2.Location = New System.Drawing.Point(568, 21)
        Me.ButtonX2.Name = "ButtonX2"
        Me.ButtonX2.Size = New System.Drawing.Size(75, 23)
        Me.ButtonX2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonX2.TabIndex = 18
        Me.ButtonX2.Text = "LLENADO"
        '
        'conexion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.ClientSize = New System.Drawing.Size(732, 322)
        Me.Controls.Add(Me.CamDGV)
        Me.Controls.Add(Me.ButtonX2)
        Me.Controls.Add(Me.ButtonX1)
        Me.Controls.Add(Me.PanelP)
        Me.Controls.Add(Me.buscartxt)
        Me.Controls.Add(Me.propBusqTB)
        Me.Controls.Add(Me.placaBusqTB)
        Me.Controls.Add(Me.ButtonX6)
        Me.Controls.Add(Me.CancelarBtn)
        Me.Controls.Add(Me.EliminarBtn)
        Me.Controls.Add(Me.EditarBtn)
        Me.Controls.Add(Me.NuevoBtn)
        Me.Controls.Add(Me.GuardarBtn)
        Me.Controls.Add(Me.LabelX10)
        Me.Controls.Add(Me.LabelX9)
        Me.Controls.Add(Me.ModificarBtn)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "conexion"
        Me.Text = "Conexión"
        CType(Me.CamDGV, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelP.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents BalloonTip1 As DevComponents.DotNetBar.BalloonTip
    Friend WithEvents srvTb As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents userTb As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents bdTb As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents passTb As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX6 As DevComponents.DotNetBar.LabelX
    Friend WithEvents GuardarBtn As DevComponents.DotNetBar.ButtonX
    Friend WithEvents NuevoBtn As DevComponents.DotNetBar.ButtonX
    Friend WithEvents EditarBtn As DevComponents.DotNetBar.ButtonX
    Friend WithEvents EliminarBtn As DevComponents.DotNetBar.ButtonX
    Friend WithEvents CancelarBtn As DevComponents.DotNetBar.ButtonX
    Friend WithEvents CamDGV As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents ButtonX6 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents placaBusqTB As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents propBusqTB As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX9 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX10 As DevComponents.DotNetBar.LabelX
    Friend WithEvents buscartxt As DevComponents.DotNetBar.LabelX
    Friend WithEvents ModificarBtn As DevComponents.DotNetBar.ButtonX
    Friend WithEvents PanelP As Panel
    Friend WithEvents ButtonX1 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents ButtonX2 As DevComponents.DotNetBar.ButtonX
End Class
