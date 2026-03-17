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
        Me.CamDGV = New System.Windows.Forms.DataGridView()
        Me.PanelBusqueda = New System.Windows.Forms.Panel()
        Me.LabelBusqCod = New DevComponents.DotNetBar.LabelX()
        Me.codBusqTB = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelBusqProp = New DevComponents.DotNetBar.LabelX()
        Me.propBusqTB = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelBusqPlaca = New DevComponents.DotNetBar.LabelX()
        Me.placaBusqTB = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.BloquearBtn = New DevComponents.DotNetBar.ButtonX()
        Me.ExportarExcelBtn = New DevComponents.DotNetBar.ButtonX()
        Me.buscartxt = New System.Windows.Forms.TextBox()
        Me.PanelP.SuspendLayout()
        CType(Me.CamDGV, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelBusqueda.SuspendLayout()
        Me.SuspendLayout()
        '
        'CancelarBtn
        '
        Me.CancelarBtn.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.CancelarBtn.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.CancelarBtn.Font = New System.Drawing.Font("Comic Sans MS", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CancelarBtn.Location = New System.Drawing.Point(534, 11)
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
        Me.EliminarBtn.Location = New System.Drawing.Point(446, 11)
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
        Me.BalloonTip1.SetBalloonCaption(Me.codTb, Nothing)
        Me.BalloonTip1.SetBalloonText(Me.codTb, "Para buscar un código, escriba los primeros digitos y luego escoja el que busca e" &
        "n el listado.")
        '
        '
        '
        Me.codTb.Border.BackColor = System.Drawing.Color.SteelBlue
        Me.codTb.Border.BackColor2 = System.Drawing.Color.SteelBlue
        Me.codTb.Border.BorderBottomWidth = 2
        Me.codTb.Border.BorderColor = System.Drawing.Color.White
        Me.codTb.Border.BorderLeftWidth = 2
        Me.codTb.Border.BorderRightWidth = 2
        Me.codTb.Border.BorderTopWidth = 2
        Me.codTb.Border.Class = "TextBoxBorder"
        Me.codTb.Border.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.codTb.FocusHighlightColor = System.Drawing.Color.Yellow
        Me.codTb.FocusHighlightEnabled = True
        Me.codTb.Font = New System.Drawing.Font("Comic Sans MS", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.codTb.ForeColor = System.Drawing.Color.Black
        Me.codTb.Location = New System.Drawing.Point(12, 27)
        Me.codTb.MaxLength = 6
        Me.codTb.Name = "codTb"
        Me.codTb.PreventEnterBeep = True
        Me.codTb.Size = New System.Drawing.Size(173, 34)
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
        Me.propTb.Border.BorderColor = System.Drawing.Color.White
        Me.propTb.Border.BorderLeftWidth = 2
        Me.propTb.Border.BorderRightWidth = 2
        Me.propTb.Border.BorderTopWidth = 2
        Me.propTb.Border.Class = "TextBoxBorder"
        Me.propTb.Border.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.propTb.FocusHighlightColor = System.Drawing.Color.Yellow
        Me.propTb.FocusHighlightEnabled = True
        Me.propTb.Font = New System.Drawing.Font("Comic Sans MS", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.propTb.ForeColor = System.Drawing.Color.Black
        Me.propTb.Location = New System.Drawing.Point(216, 27)
        Me.propTb.MaxLength = 30
        Me.propTb.Name = "propTb"
        Me.propTb.PreventEnterBeep = True
        Me.propTb.Size = New System.Drawing.Size(340, 34)
        Me.propTb.TabIndex = 1
        '
        'placaTb
        '
        Me.placaTb.BackColor = System.Drawing.Color.SteelBlue
        '
        '
        '
        Me.placaTb.Border.BackColor = System.Drawing.Color.SteelBlue
        Me.placaTb.Border.BackColor2 = System.Drawing.Color.SteelBlue
        Me.placaTb.Border.BorderBottomWidth = 2
        Me.placaTb.Border.BorderColor = System.Drawing.Color.White
        Me.placaTb.Border.BorderLeftWidth = 2
        Me.placaTb.Border.BorderRightWidth = 2
        Me.placaTb.Border.BorderTopWidth = 2
        Me.placaTb.Border.Class = "TextBoxBorder"
        Me.placaTb.Border.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.placaTb.FocusHighlightColor = System.Drawing.Color.Yellow
        Me.placaTb.FocusHighlightEnabled = True
        Me.placaTb.Font = New System.Drawing.Font("Comic Sans MS", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.placaTb.ForeColor = System.Drawing.Color.Black
        Me.placaTb.Location = New System.Drawing.Point(575, 21)
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
        Me.LabelX3.Location = New System.Drawing.Point(579, 8)
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
        Me.obserTb.Border.BackColor = System.Drawing.Color.SteelBlue
        Me.obserTb.Border.BackColor2 = System.Drawing.Color.SteelBlue
        Me.obserTb.Border.BorderBottomWidth = 2
        Me.obserTb.Border.BorderColor = System.Drawing.Color.White
        Me.obserTb.Border.BorderLeftWidth = 2
        Me.obserTb.Border.BorderRightWidth = 2
        Me.obserTb.Border.BorderTopWidth = 2
        Me.obserTb.Border.Class = "TextBoxBorder"
        Me.obserTb.Border.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.obserTb.FocusHighlightColor = System.Drawing.Color.Yellow
        Me.obserTb.FocusHighlightEnabled = True
        Me.obserTb.Font = New System.Drawing.Font("Comic Sans MS", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.obserTb.ForeColor = System.Drawing.Color.Black
        Me.obserTb.Location = New System.Drawing.Point(12, 82)
        Me.obserTb.MaxLength = 200
        Me.obserTb.Multiline = True
        Me.obserTb.Name = "obserTb"
        Me.obserTb.PreventEnterBeep = True
        Me.obserTb.Size = New System.Drawing.Size(770, 104)
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
        Me.LabelX6.Location = New System.Drawing.Point(17, 66)
        Me.LabelX6.Name = "LabelX6"
        Me.LabelX6.Size = New System.Drawing.Size(129, 23)
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
        Me.PanelP.Location = New System.Drawing.Point(26, 51)
        Me.PanelP.Name = "PanelP"
        Me.PanelP.Size = New System.Drawing.Size(797, 206)
        Me.PanelP.TabIndex = 22
        '
        'CamDGV
        '
        Me.CamDGV.AllowUserToAddRows = False
        Me.CamDGV.AllowUserToDeleteRows = False
        Me.CamDGV.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.CamDGV.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.CamDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(25, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(65, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(240, Byte), Integer))
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(180, Byte), Integer))
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.CamDGV.DefaultCellStyle = DataGridViewCellStyle1
        Me.CamDGV.GridColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(55, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.CamDGV.Location = New System.Drawing.Point(26, 337)
        Me.CamDGV.MultiSelect = False
        Me.CamDGV.Name = "CamDGV"
        Me.CamDGV.ReadOnly = True
        Me.CamDGV.RowHeadersVisible = False
        Me.CamDGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.CamDGV.Size = New System.Drawing.Size(797, 261)
        Me.CamDGV.TabIndex = 23
        '
        'PanelBusqueda
        '
        Me.PanelBusqueda.BackColor = System.Drawing.Color.SteelBlue
        Me.PanelBusqueda.Controls.Add(Me.BloquearBtn)
        Me.PanelBusqueda.Controls.Add(Me.LabelBusqCod)
        Me.PanelBusqueda.Controls.Add(Me.codBusqTB)
        Me.PanelBusqueda.Controls.Add(Me.LabelBusqProp)
        Me.PanelBusqueda.Controls.Add(Me.propBusqTB)
        Me.PanelBusqueda.Controls.Add(Me.LabelBusqPlaca)
        Me.PanelBusqueda.Controls.Add(Me.placaBusqTB)
        Me.PanelBusqueda.Location = New System.Drawing.Point(26, 263)
        Me.PanelBusqueda.Name = "PanelBusqueda"
        Me.PanelBusqueda.Size = New System.Drawing.Size(797, 68)
        Me.PanelBusqueda.TabIndex = 24
        '
        'LabelBusqCod
        '
        '
        '
        '
        Me.LabelBusqCod.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelBusqCod.Font = New System.Drawing.Font("Comic Sans MS", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelBusqCod.ForeColor = System.Drawing.Color.White
        Me.LabelBusqCod.Location = New System.Drawing.Point(10, 5)
        Me.LabelBusqCod.Name = "LabelBusqCod"
        Me.LabelBusqCod.Size = New System.Drawing.Size(100, 20)
        Me.LabelBusqCod.TabIndex = 0
        Me.LabelBusqCod.Text = "Buscar Código:"
        '
        'codBusqTB
        '
        Me.codBusqTB.BackColor = System.Drawing.Color.SteelBlue
        '
        '
        '
        Me.codBusqTB.Border.BorderBottomWidth = 2
        Me.codBusqTB.Border.BorderLeftWidth = 2
        Me.codBusqTB.Border.BorderRightWidth = 2
        Me.codBusqTB.Border.BorderTopWidth = 2
        Me.codBusqTB.Border.Class = "TextBoxBorder"
        Me.codBusqTB.Border.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.codBusqTB.Font = New System.Drawing.Font("Comic Sans MS", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.codBusqTB.ForeColor = System.Drawing.Color.Black
        Me.codBusqTB.Location = New System.Drawing.Point(10, 28)
        Me.codBusqTB.Name = "codBusqTB"
        Me.codBusqTB.PreventEnterBeep = True
        Me.codBusqTB.Size = New System.Drawing.Size(120, 34)
        Me.codBusqTB.TabIndex = 1
        '
        'LabelBusqProp
        '
        '
        '
        '
        Me.LabelBusqProp.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelBusqProp.Font = New System.Drawing.Font("Comic Sans MS", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelBusqProp.ForeColor = System.Drawing.Color.White
        Me.LabelBusqProp.Location = New System.Drawing.Point(145, 5)
        Me.LabelBusqProp.Name = "LabelBusqProp"
        Me.LabelBusqProp.Size = New System.Drawing.Size(120, 20)
        Me.LabelBusqProp.TabIndex = 2
        Me.LabelBusqProp.Text = "Buscar Propietario:"
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
        Me.propBusqTB.ForeColor = System.Drawing.Color.Black
        Me.propBusqTB.Location = New System.Drawing.Point(145, 28)
        Me.propBusqTB.Name = "propBusqTB"
        Me.propBusqTB.PreventEnterBeep = True
        Me.propBusqTB.Size = New System.Drawing.Size(280, 34)
        Me.propBusqTB.TabIndex = 3
        '
        'LabelBusqPlaca
        '
        '
        '
        '
        Me.LabelBusqPlaca.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelBusqPlaca.Font = New System.Drawing.Font("Comic Sans MS", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelBusqPlaca.ForeColor = System.Drawing.Color.White
        Me.LabelBusqPlaca.Location = New System.Drawing.Point(440, 5)
        Me.LabelBusqPlaca.Name = "LabelBusqPlaca"
        Me.LabelBusqPlaca.Size = New System.Drawing.Size(100, 20)
        Me.LabelBusqPlaca.TabIndex = 4
        Me.LabelBusqPlaca.Text = "Buscar Placa:"
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
        Me.placaBusqTB.ForeColor = System.Drawing.Color.Black
        Me.placaBusqTB.Location = New System.Drawing.Point(440, 28)
        Me.placaBusqTB.Name = "placaBusqTB"
        Me.placaBusqTB.PreventEnterBeep = True
        Me.placaBusqTB.Size = New System.Drawing.Size(150, 34)
        Me.placaBusqTB.TabIndex = 5
        '
        'BloquearBtn
        '
        Me.BloquearBtn.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.BloquearBtn.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.BloquearBtn.Font = New System.Drawing.Font("Comic Sans MS", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BloquearBtn.Location = New System.Drawing.Point(649, 18)
        Me.BloquearBtn.Name = "BloquearBtn"
        Me.BloquearBtn.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor(2, 2, 2, 10)
        Me.BloquearBtn.Size = New System.Drawing.Size(110, 33)
        Me.BloquearBtn.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.BloquearBtn.Symbol = ""
        Me.BloquearBtn.SymbolColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.BloquearBtn.SymbolSize = 24.0!
        Me.BloquearBtn.TabIndex = 20
        Me.BloquearBtn.Text = "Bloquear"
        '
        'ExportarExcelBtn
        '
        Me.ExportarExcelBtn.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ExportarExcelBtn.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ExportarExcelBtn.Font = New System.Drawing.Font("Comic Sans MS", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ExportarExcelBtn.Location = New System.Drawing.Point(636, 11)
        Me.ExportarExcelBtn.Name = "ExportarExcelBtn"
        Me.ExportarExcelBtn.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor(2, 2, 2, 10)
        Me.ExportarExcelBtn.Size = New System.Drawing.Size(130, 33)
        Me.ExportarExcelBtn.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ExportarExcelBtn.SymbolColor = System.Drawing.Color.Green
        Me.ExportarExcelBtn.SymbolSize = 12.0!
        Me.ExportarExcelBtn.TabIndex = 26
        Me.ExportarExcelBtn.Text = "Exportar Excel"
        '
        'buscartxt
        '
        Me.buscartxt.Location = New System.Drawing.Point(788, 23)
        Me.buscartxt.Name = "buscartxt"
        Me.buscartxt.Size = New System.Drawing.Size(20, 20)
        Me.buscartxt.TabIndex = 25
        Me.buscartxt.Visible = False
        '
        'placa
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.SteelBlue
        Me.ClientSize = New System.Drawing.Size(842, 604)
        Me.Controls.Add(Me.ExportarExcelBtn)
        Me.Controls.Add(Me.buscartxt)
        Me.Controls.Add(Me.PanelBusqueda)
        Me.Controls.Add(Me.CamDGV)
        Me.Controls.Add(Me.PanelP)
        Me.Controls.Add(Me.CancelarBtn)
        Me.Controls.Add(Me.EliminarBtn)
        Me.Controls.Add(Me.EditarBtn)
        Me.Controls.Add(Me.NuevoBtn)
        Me.Controls.Add(Me.GuardarBtn)
        Me.Controls.Add(Me.ModificarBtn)
        Me.Name = "placa"
        Me.Text = "Placa"
        Me.PanelP.ResumeLayout(False)
        CType(Me.CamDGV, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelBusqueda.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents CancelarBtn As DevComponents.DotNetBar.ButtonX
    Friend WithEvents EliminarBtn As DevComponents.DotNetBar.ButtonX
    Friend WithEvents EditarBtn As DevComponents.DotNetBar.ButtonX
    Friend WithEvents NuevoBtn As DevComponents.DotNetBar.ButtonX
    Friend WithEvents GuardarBtn As DevComponents.DotNetBar.ButtonX
    Friend WithEvents ModificarBtn As DevComponents.DotNetBar.ButtonX
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
    Friend WithEvents CamDGV As DataGridView
    Friend WithEvents PanelBusqueda As Panel
    Friend WithEvents codBusqTB As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents propBusqTB As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents placaBusqTB As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelBusqCod As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelBusqProp As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelBusqPlaca As DevComponents.DotNetBar.LabelX
    Friend WithEvents buscartxt As TextBox
    Friend WithEvents BloquearBtn As DevComponents.DotNetBar.ButtonX
    Friend WithEvents ExportarExcelBtn As DevComponents.DotNetBar.ButtonX
End Class
