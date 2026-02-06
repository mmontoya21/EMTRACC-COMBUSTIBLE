<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class rutas
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

    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.CamDGV = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.PanelP = New System.Windows.Forms.Panel()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.rutaTb = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.kilomTb = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.NuevoBtn = New DevComponents.DotNetBar.ButtonX()
        Me.GuardarBtn = New DevComponents.DotNetBar.ButtonX()
        Me.EditarBtn = New DevComponents.DotNetBar.ButtonX()
        Me.ModificarBtn = New DevComponents.DotNetBar.ButtonX()
        Me.EliminarBtn = New DevComponents.DotNetBar.ButtonX()
        Me.CancelarBtn = New DevComponents.DotNetBar.ButtonX()
        Me.buscartxt = New DevComponents.DotNetBar.LabelX()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.rutaBusqTB = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.buscarBtn = New DevComponents.DotNetBar.ButtonX()
        CType(Me.CamDGV, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelP.SuspendLayout()
        Me.SuspendLayout()
        '
        'CamDGV
        '
        Me.CamDGV.AllowUserToAddRows = False
        Me.CamDGV.AllowUserToDeleteRows = False
        Me.CamDGV.AllowUserToResizeRows = False
        Me.CamDGV.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(114, Byte), Integer))
        Me.CamDGV.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.CamDGV.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.CamDGV.ColumnHeadersDefaultCellStyle.Font = New System.Drawing.Font("Segoe UI Semibold", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CamDGV.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White
        Me.CamDGV.ColumnHeadersDefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.CamDGV.ColumnHeadersHeight = 35
        Me.CamDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.CamDGV.DefaultCellStyle.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CamDGV.DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.CamDGV.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(70, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.CamDGV.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White
        Me.CamDGV.EnableHeadersVisualStyles = False
        Me.CamDGV.GridColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.CamDGV.Location = New System.Drawing.Point(15, 65)
        Me.CamDGV.MultiSelect = False
        Me.CamDGV.Name = "CamDGV"
        Me.CamDGV.ReadOnly = True
        Me.CamDGV.RowHeadersVisible = False
        Me.CamDGV.RowTemplate.Height = 28
        Me.CamDGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.CamDGV.Size = New System.Drawing.Size(560, 450)
        Me.CamDGV.TabIndex = 0
        '
        'PanelP
        '
        Me.PanelP.BackColor = System.Drawing.Color.FromArgb(CType(CType(25, Byte), Integer), CType(CType(55, Byte), Integer), CType(CType(105, Byte), Integer))
        Me.PanelP.Controls.Add(Me.LabelX1)
        Me.PanelP.Controls.Add(Me.rutaTb)
        Me.PanelP.Controls.Add(Me.LabelX2)
        Me.PanelP.Controls.Add(Me.kilomTb)
        Me.PanelP.Location = New System.Drawing.Point(590, 65)
        Me.PanelP.Name = "PanelP"
        Me.PanelP.Size = New System.Drawing.Size(340, 170)
        Me.PanelP.TabIndex = 1
        '
        'LabelX1
        '
        Me.LabelX1.BackColor = System.Drawing.Color.Transparent
        Me.LabelX1.Font = New System.Drawing.Font("Segoe UI Semibold", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(180, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.LabelX1.Location = New System.Drawing.Point(15, 25)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(80, 25)
        Me.LabelX1.TabIndex = 0
        Me.LabelX1.Text = "Ruta:"
        '
        'rutaTb
        '
        Me.rutaTb.BackColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(75, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.rutaTb.Border.BackColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(75, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.rutaTb.Border.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(75, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.rutaTb.Border.BorderBottomWidth = 2
        Me.rutaTb.Border.BorderColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(160, Byte), Integer), CType(CType(230, Byte), Integer))
        Me.rutaTb.Border.BorderLeftWidth = 2
        Me.rutaTb.Border.BorderRightWidth = 2
        Me.rutaTb.Border.BorderTopWidth = 2
        Me.rutaTb.Border.Class = "TextBoxBorder"
        Me.rutaTb.Border.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.rutaTb.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(70, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.rutaTb.FocusHighlightEnabled = True
        Me.rutaTb.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rutaTb.ForeColor = System.Drawing.Color.White
        Me.rutaTb.Location = New System.Drawing.Point(100, 22)
        Me.rutaTb.MaxLength = 200
        Me.rutaTb.Name = "rutaTb"
        Me.rutaTb.PreventEnterBeep = True
        Me.rutaTb.Size = New System.Drawing.Size(220, 30)
        Me.rutaTb.TabIndex = 1
        '
        'LabelX2
        '
        Me.LabelX2.BackColor = System.Drawing.Color.Transparent
        Me.LabelX2.Font = New System.Drawing.Font("Segoe UI Semibold", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(180, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.LabelX2.Location = New System.Drawing.Point(15, 75)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(80, 25)
        Me.LabelX2.TabIndex = 2
        Me.LabelX2.Text = "Kilómetros:"
        '
        'kilomTb
        '
        Me.kilomTb.BackColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(75, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.kilomTb.Border.BackColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(75, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.kilomTb.Border.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(75, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.kilomTb.Border.BorderBottomWidth = 2
        Me.kilomTb.Border.BorderColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(160, Byte), Integer), CType(CType(230, Byte), Integer))
        Me.kilomTb.Border.BorderLeftWidth = 2
        Me.kilomTb.Border.BorderRightWidth = 2
        Me.kilomTb.Border.BorderTopWidth = 2
        Me.kilomTb.Border.Class = "TextBoxBorder"
        Me.kilomTb.Border.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.kilomTb.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(70, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.kilomTb.FocusHighlightEnabled = True
        Me.kilomTb.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.kilomTb.ForeColor = System.Drawing.Color.White
        Me.kilomTb.Location = New System.Drawing.Point(100, 72)
        Me.kilomTb.MaxLength = 6
        Me.kilomTb.Name = "kilomTb"
        Me.kilomTb.PreventEnterBeep = True
        Me.kilomTb.Size = New System.Drawing.Size(130, 30)
        Me.kilomTb.TabIndex = 3
        '
        'NuevoBtn
        '
        Me.NuevoBtn.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.NuevoBtn.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueWithBackground
        Me.NuevoBtn.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NuevoBtn.Location = New System.Drawing.Point(590, 255)
        Me.NuevoBtn.Name = "NuevoBtn"
        Me.NuevoBtn.Size = New System.Drawing.Size(105, 38)
        Me.NuevoBtn.TabIndex = 4
        Me.NuevoBtn.Text = "Nuevo"
        '
        'GuardarBtn
        '
        Me.GuardarBtn.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.GuardarBtn.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueWithBackground
        Me.GuardarBtn.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GuardarBtn.Location = New System.Drawing.Point(705, 255)
        Me.GuardarBtn.Name = "GuardarBtn"
        Me.GuardarBtn.Size = New System.Drawing.Size(105, 38)
        Me.GuardarBtn.TabIndex = 5
        Me.GuardarBtn.Text = "Guardar"
        '
        'EditarBtn
        '
        Me.EditarBtn.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.EditarBtn.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueWithBackground
        Me.EditarBtn.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EditarBtn.Location = New System.Drawing.Point(820, 255)
        Me.EditarBtn.Name = "EditarBtn"
        Me.EditarBtn.Size = New System.Drawing.Size(105, 38)
        Me.EditarBtn.TabIndex = 6
        Me.EditarBtn.Text = "Editar"
        '
        'ModificarBtn
        '
        Me.ModificarBtn.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ModificarBtn.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueWithBackground
        Me.ModificarBtn.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ModificarBtn.Location = New System.Drawing.Point(590, 303)
        Me.ModificarBtn.Name = "ModificarBtn"
        Me.ModificarBtn.Size = New System.Drawing.Size(105, 38)
        Me.ModificarBtn.TabIndex = 7
        Me.ModificarBtn.Text = "Modificar"
        '
        'EliminarBtn
        '
        Me.EliminarBtn.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.EliminarBtn.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueWithBackground
        Me.EliminarBtn.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EliminarBtn.Location = New System.Drawing.Point(705, 303)
        Me.EliminarBtn.Name = "EliminarBtn"
        Me.EliminarBtn.Size = New System.Drawing.Size(105, 38)
        Me.EliminarBtn.TabIndex = 8
        Me.EliminarBtn.Text = "Eliminar"
        '
        'CancelarBtn
        '
        Me.CancelarBtn.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.CancelarBtn.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueWithBackground
        Me.CancelarBtn.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CancelarBtn.Location = New System.Drawing.Point(820, 303)
        Me.CancelarBtn.Name = "CancelarBtn"
        Me.CancelarBtn.Size = New System.Drawing.Size(105, 38)
        Me.CancelarBtn.TabIndex = 9
        Me.CancelarBtn.Text = "Cancelar"
        '
        'buscartxt
        '
        Me.buscartxt.BackColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(90, Byte), Integer))
        Me.buscartxt.ForeColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(90, Byte), Integer))
        Me.buscartxt.Location = New System.Drawing.Point(590, 490)
        Me.buscartxt.Name = "buscartxt"
        Me.buscartxt.Size = New System.Drawing.Size(75, 23)
        Me.buscartxt.TabIndex = 10
        Me.buscartxt.Visible = False
        '
        'LabelX3
        '
        Me.LabelX3.BackColor = System.Drawing.Color.Transparent
        Me.LabelX3.Font = New System.Drawing.Font("Segoe UI Semibold", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(180, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.LabelX3.Location = New System.Drawing.Point(15, 18)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(120, 25)
        Me.LabelX3.TabIndex = 11
        Me.LabelX3.Text = "Buscar Ruta:"
        '
        'rutaBusqTB
        '
        Me.rutaBusqTB.BackColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(75, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.rutaBusqTB.Border.BackColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(75, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.rutaBusqTB.Border.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(75, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.rutaBusqTB.Border.BorderBottomWidth = 2
        Me.rutaBusqTB.Border.BorderColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(160, Byte), Integer), CType(CType(230, Byte), Integer))
        Me.rutaBusqTB.Border.BorderLeftWidth = 2
        Me.rutaBusqTB.Border.BorderRightWidth = 2
        Me.rutaBusqTB.Border.BorderTopWidth = 2
        Me.rutaBusqTB.Border.Class = "TextBoxBorder"
        Me.rutaBusqTB.Border.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.rutaBusqTB.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(70, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.rutaBusqTB.FocusHighlightEnabled = True
        Me.rutaBusqTB.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rutaBusqTB.ForeColor = System.Drawing.Color.White
        Me.rutaBusqTB.Location = New System.Drawing.Point(140, 15)
        Me.rutaBusqTB.MaxLength = 200
        Me.rutaBusqTB.Name = "rutaBusqTB"
        Me.rutaBusqTB.PreventEnterBeep = True
        Me.rutaBusqTB.Size = New System.Drawing.Size(300, 30)
        Me.rutaBusqTB.TabIndex = 12
        '
        'buscarBtn
        '
        Me.buscarBtn.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.buscarBtn.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueWithBackground
        Me.buscarBtn.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.buscarBtn.Location = New System.Drawing.Point(450, 12)
        Me.buscarBtn.Name = "buscarBtn"
        Me.buscarBtn.Size = New System.Drawing.Size(105, 35)
        Me.buscarBtn.TabIndex = 13
        Me.buscarBtn.Text = "Buscar"
        '
        'rutas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(90, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(950, 540)
        Me.Controls.Add(Me.buscarBtn)
        Me.Controls.Add(Me.rutaBusqTB)
        Me.Controls.Add(Me.LabelX3)
        Me.Controls.Add(Me.buscartxt)
        Me.Controls.Add(Me.CancelarBtn)
        Me.Controls.Add(Me.EliminarBtn)
        Me.Controls.Add(Me.ModificarBtn)
        Me.Controls.Add(Me.EditarBtn)
        Me.Controls.Add(Me.GuardarBtn)
        Me.Controls.Add(Me.NuevoBtn)
        Me.Controls.Add(Me.PanelP)
        Me.Controls.Add(Me.CamDGV)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "rutas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Rutas"
        CType(Me.CamDGV, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelP.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents CamDGV As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents PanelP As System.Windows.Forms.Panel
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents rutaTb As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents kilomTb As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents NuevoBtn As DevComponents.DotNetBar.ButtonX
    Friend WithEvents GuardarBtn As DevComponents.DotNetBar.ButtonX
    Friend WithEvents EditarBtn As DevComponents.DotNetBar.ButtonX
    Friend WithEvents ModificarBtn As DevComponents.DotNetBar.ButtonX
    Friend WithEvents EliminarBtn As DevComponents.DotNetBar.ButtonX
    Friend WithEvents CancelarBtn As DevComponents.DotNetBar.ButtonX
    Friend WithEvents buscartxt As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents rutaBusqTB As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents buscarBtn As DevComponents.DotNetBar.ButtonX
End Class
