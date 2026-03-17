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

    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.CancelarBtn = New DevComponents.DotNetBar.ButtonX()
        Me.EliminarBtn = New DevComponents.DotNetBar.ButtonX()
        Me.EditarBtn = New DevComponents.DotNetBar.ButtonX()
        Me.NuevoBtn = New DevComponents.DotNetBar.ButtonX()
        Me.GuardarBtn = New DevComponents.DotNetBar.ButtonX()
        Me.ModificarBtn = New DevComponents.DotNetBar.ButtonX()
        Me.CalcularBtn = New DevComponents.DotNetBar.ButtonX()
        Me.PanelP = New System.Windows.Forms.Panel()
        Me.lblFecha = New DevComponents.DotNetBar.LabelX()
        Me.fechaTb = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.lblPeriodo = New DevComponents.DotNetBar.LabelX()
        Me.periodoCb = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.P1 = New DevComponents.Editors.ComboItem()
        Me.P2 = New DevComponents.Editors.ComboItem()
        Me.P3 = New DevComponents.Editors.ComboItem()
        Me.P4 = New DevComponents.Editors.ComboItem()
        Me.P5 = New DevComponents.Editors.ComboItem()
        Me.P6 = New DevComponents.Editors.ComboItem()
        Me.P7 = New DevComponents.Editors.ComboItem()
        Me.P8 = New DevComponents.Editors.ComboItem()
        Me.P9 = New DevComponents.Editors.ComboItem()
        Me.P10 = New DevComponents.Editors.ComboItem()
        Me.P11 = New DevComponents.Editors.ComboItem()
        Me.P12 = New DevComponents.Editors.ComboItem()
        Me.P13 = New DevComponents.Editors.ComboItem()
        Me.lblSemana = New DevComponents.DotNetBar.LabelX()
        Me.semanaCb = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.W1 = New DevComponents.Editors.ComboItem()
        Me.W2 = New DevComponents.Editors.ComboItem()
        Me.W3 = New DevComponents.Editors.ComboItem()
        Me.W4 = New DevComponents.Editors.ComboItem()
        Me.W5 = New DevComponents.Editors.ComboItem()
        Me.lblCapacidad = New DevComponents.DotNetBar.LabelX()
        Me.capacidadTb = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.lblGrupoInicial = New DevComponents.DotNetBar.LabelX()
        Me.lblGalInicio = New DevComponents.DotNetBar.LabelX()
        Me.galonesCalcTb = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.lblPglInicio = New DevComponents.DotNetBar.LabelX()
        Me.pglCalTb = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.lblGrupoFinal = New DevComponents.DotNetBar.LabelX()
        Me.lblGalFinal = New DevComponents.DotNetBar.LabelX()
        Me.galonesMedTb = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.lblPglFinal = New DevComponents.DotNetBar.LabelX()
        Me.pglMedTb = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.lblGalRecibidos = New DevComponents.DotNetBar.LabelX()
        Me.galRecibidosTb = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.lblGalDespachados = New DevComponents.DotNetBar.LabelX()
        Me.galDespachadosTb = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.lblGalEsperados = New DevComponents.DotNetBar.LabelX()
        Me.galEsperadosTb = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.lblDiferencia = New DevComponents.DotNetBar.LabelX()
        Me.diferenciaTb = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.lblObservaciones = New DevComponents.DotNetBar.LabelX()
        Me.observacionesTb = New DevComponents.DotNetBar.Controls.TextBoxX()
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
        'CalcularBtn
        '
        Me.CalcularBtn.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.CalcularBtn.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.CalcularBtn.Font = New System.Drawing.Font("Comic Sans MS", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CalcularBtn.Location = New System.Drawing.Point(490, 12)
        Me.CalcularBtn.Name = "CalcularBtn"
        Me.CalcularBtn.Size = New System.Drawing.Size(130, 33)
        Me.CalcularBtn.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.CalcularBtn.SymbolSize = 12.0!
        Me.CalcularBtn.TabIndex = 51
        Me.CalcularBtn.Text = "Calcular Desp."
        '
        'PanelP
        '
        Me.PanelP.Controls.Add(Me.galRecibidosTb)
        Me.PanelP.Controls.Add(Me.galDespachadosTb)
        Me.PanelP.Controls.Add(Me.galEsperadosTb)
        Me.PanelP.Controls.Add(Me.diferenciaTb)
        Me.PanelP.Controls.Add(Me.observacionesTb)
        Me.PanelP.Controls.Add(Me.lblFecha)
        Me.PanelP.Controls.Add(Me.fechaTb)
        Me.PanelP.Controls.Add(Me.lblPeriodo)
        Me.PanelP.Controls.Add(Me.periodoCb)
        Me.PanelP.Controls.Add(Me.lblSemana)
        Me.PanelP.Controls.Add(Me.semanaCb)
        Me.PanelP.Controls.Add(Me.lblCapacidad)
        Me.PanelP.Controls.Add(Me.capacidadTb)
        Me.PanelP.Controls.Add(Me.lblGrupoInicial)
        Me.PanelP.Controls.Add(Me.galonesCalcTb)
        Me.PanelP.Controls.Add(Me.pglCalTb)
        Me.PanelP.Controls.Add(Me.lblGrupoFinal)
        Me.PanelP.Controls.Add(Me.galonesMedTb)
        Me.PanelP.Controls.Add(Me.pglMedTb)
        Me.PanelP.Controls.Add(Me.lblGalRecibidos)
        Me.PanelP.Controls.Add(Me.lblGalDespachados)
        Me.PanelP.Controls.Add(Me.lblGalEsperados)
        Me.PanelP.Controls.Add(Me.lblDiferencia)
        Me.PanelP.Controls.Add(Me.lblObservaciones)
        Me.PanelP.Controls.Add(Me.lblGalInicio)
        Me.PanelP.Controls.Add(Me.lblPglInicio)
        Me.PanelP.Controls.Add(Me.lblGalFinal)
        Me.PanelP.Controls.Add(Me.lblPglFinal)
        Me.PanelP.Location = New System.Drawing.Point(17, 55)
        Me.PanelP.Name = "PanelP"
        Me.PanelP.Size = New System.Drawing.Size(1020, 235)
        Me.PanelP.TabIndex = 45
        '
        'lblFecha
        '
        '
        '
        '
        Me.lblFecha.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblFecha.Font = New System.Drawing.Font("Comic Sans MS", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFecha.FontBold = True
        Me.lblFecha.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblFecha.Location = New System.Drawing.Point(10, 5)
        Me.lblFecha.Name = "lblFecha"
        Me.lblFecha.Size = New System.Drawing.Size(60, 23)
        Me.lblFecha.TabIndex = 0
        Me.lblFecha.Text = "Fecha"
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
        Me.fechaTb.Location = New System.Drawing.Point(10, 28)
        Me.fechaTb.MaxLength = 15
        Me.fechaTb.Name = "fechaTb"
        Me.fechaTb.PreventEnterBeep = True
        Me.fechaTb.Size = New System.Drawing.Size(130, 32)
        Me.fechaTb.TabIndex = 1
        '
        'lblPeriodo
        '
        '
        '
        '
        Me.lblPeriodo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblPeriodo.Font = New System.Drawing.Font("Comic Sans MS", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPeriodo.FontBold = True
        Me.lblPeriodo.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblPeriodo.Location = New System.Drawing.Point(155, 5)
        Me.lblPeriodo.Name = "lblPeriodo"
        Me.lblPeriodo.Size = New System.Drawing.Size(80, 23)
        Me.lblPeriodo.TabIndex = 2
        Me.lblPeriodo.Text = "Periodo"
        '
        'periodoCb
        '
        Me.periodoCb.DisplayMember = "Text"
        Me.periodoCb.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.periodoCb.Font = New System.Drawing.Font("Comic Sans MS", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.periodoCb.FormattingEnabled = True
        Me.periodoCb.ItemHeight = 24
        Me.periodoCb.Items.AddRange(New Object() {Me.P1, Me.P2, Me.P3, Me.P4, Me.P5, Me.P6, Me.P7, Me.P8, Me.P9, Me.P10, Me.P11, Me.P12, Me.P13})
        Me.periodoCb.Location = New System.Drawing.Point(155, 28)
        Me.periodoCb.Name = "periodoCb"
        Me.periodoCb.Size = New System.Drawing.Size(80, 30)
        Me.periodoCb.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.periodoCb.TabIndex = 3
        '
        'P1
        '
        Me.P1.Text = "1"
        '
        'P2
        '
        Me.P2.Text = "2"
        '
        'P3
        '
        Me.P3.Text = "3"
        '
        'P4
        '
        Me.P4.Text = "4"
        '
        'P5
        '
        Me.P5.Text = "5"
        '
        'P6
        '
        Me.P6.Text = "6"
        '
        'P7
        '
        Me.P7.Text = "7"
        '
        'P8
        '
        Me.P8.Text = "8"
        '
        'P9
        '
        Me.P9.Text = "9"
        '
        'P10
        '
        Me.P10.Text = "10"
        '
        'P11
        '
        Me.P11.Text = "11"
        '
        'P12
        '
        Me.P12.Text = "12"
        '
        'P13
        '
        Me.P13.Text = "13"
        '
        'lblSemana
        '
        '
        '
        '
        Me.lblSemana.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblSemana.Font = New System.Drawing.Font("Comic Sans MS", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSemana.FontBold = True
        Me.lblSemana.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblSemana.Location = New System.Drawing.Point(250, 5)
        Me.lblSemana.Name = "lblSemana"
        Me.lblSemana.Size = New System.Drawing.Size(80, 23)
        Me.lblSemana.TabIndex = 4
        Me.lblSemana.Text = "Semana"
        '
        'semanaCb
        '
        Me.semanaCb.DisplayMember = "Text"
        Me.semanaCb.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.semanaCb.Font = New System.Drawing.Font("Comic Sans MS", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.semanaCb.FormattingEnabled = True
        Me.semanaCb.ItemHeight = 24
        Me.semanaCb.Items.AddRange(New Object() {Me.W1, Me.W2, Me.W3, Me.W4, Me.W5})
        Me.semanaCb.Location = New System.Drawing.Point(250, 28)
        Me.semanaCb.Name = "semanaCb"
        Me.semanaCb.Size = New System.Drawing.Size(80, 30)
        Me.semanaCb.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.semanaCb.TabIndex = 5
        '
        'W1
        '
        Me.W1.Text = "1"
        '
        'W2
        '
        Me.W2.Text = "2"
        '
        'W3
        '
        Me.W3.Text = "3"
        '
        'W4
        '
        Me.W4.Text = "4"
        '
        'W5
        '
        Me.W5.Text = "5"
        '
        'lblCapacidad
        '
        '
        '
        '
        Me.lblCapacidad.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblCapacidad.Font = New System.Drawing.Font("Comic Sans MS", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCapacidad.FontBold = True
        Me.lblCapacidad.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblCapacidad.Location = New System.Drawing.Point(345, 5)
        Me.lblCapacidad.Name = "lblCapacidad"
        Me.lblCapacidad.Size = New System.Drawing.Size(140, 23)
        Me.lblCapacidad.TabIndex = 6
        Me.lblCapacidad.Text = "Capacidad Tanque"
        '
        'capacidadTb
        '
        Me.capacidadTb.AcceptsTab = True
        Me.capacidadTb.BackColor = System.Drawing.Color.SteelBlue
        '
        '
        '
        Me.capacidadTb.Border.BackColor = System.Drawing.Color.SteelBlue
        Me.capacidadTb.Border.BackColor2 = System.Drawing.Color.SteelBlue
        Me.capacidadTb.Border.BorderBottomWidth = 2
        Me.capacidadTb.Border.BorderColor = System.Drawing.Color.White
        Me.capacidadTb.Border.BorderLeftWidth = 2
        Me.capacidadTb.Border.BorderRightWidth = 2
        Me.capacidadTb.Border.BorderTopWidth = 2
        Me.capacidadTb.Border.Class = "TextBoxBorder"
        Me.capacidadTb.Border.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.capacidadTb.FocusHighlightColor = System.Drawing.Color.Yellow
        Me.capacidadTb.FocusHighlightEnabled = True
        Me.capacidadTb.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.capacidadTb.ForeColor = System.Drawing.Color.White
        Me.capacidadTb.Location = New System.Drawing.Point(345, 28)
        Me.capacidadTb.Name = "capacidadTb"
        Me.capacidadTb.PreventEnterBeep = True
        Me.capacidadTb.Size = New System.Drawing.Size(120, 32)
        Me.capacidadTb.TabIndex = 7
        '
        'lblGrupoInicial
        '
        '
        '
        '
        Me.lblGrupoInicial.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblGrupoInicial.Font = New System.Drawing.Font("Comic Sans MS", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGrupoInicial.ForeColor = System.Drawing.Color.LightCyan
        Me.lblGrupoInicial.Location = New System.Drawing.Point(10, 65)
        Me.lblGrupoInicial.Name = "lblGrupoInicial"
        Me.lblGrupoInicial.Size = New System.Drawing.Size(250, 20)
        Me.lblGrupoInicial.TabIndex = 8
        Me.lblGrupoInicial.Text = "LECTURA INICIAL (Lunes)"
        '
        'lblGalInicio
        '
        '
        '
        '
        Me.lblGalInicio.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblGalInicio.Font = New System.Drawing.Font("Comic Sans MS", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGalInicio.FontBold = True
        Me.lblGalInicio.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblGalInicio.Location = New System.Drawing.Point(10, 87)
        Me.lblGalInicio.Name = "lblGalInicio"
        Me.lblGalInicio.Size = New System.Drawing.Size(130, 23)
        Me.lblGalInicio.TabIndex = 9
        Me.lblGalInicio.Text = "Galones Inicio"
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
        Me.galonesCalcTb.Location = New System.Drawing.Point(10, 108)
        Me.galonesCalcTb.Name = "galonesCalcTb"
        Me.galonesCalcTb.PreventEnterBeep = True
        Me.galonesCalcTb.Size = New System.Drawing.Size(130, 32)
        Me.galonesCalcTb.TabIndex = 10
        '
        'lblPglInicio
        '
        '
        '
        '
        Me.lblPglInicio.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblPglInicio.Font = New System.Drawing.Font("Comic Sans MS", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPglInicio.FontBold = True
        Me.lblPglInicio.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblPglInicio.Location = New System.Drawing.Point(155, 87)
        Me.lblPglInicio.Name = "lblPglInicio"
        Me.lblPglInicio.Size = New System.Drawing.Size(130, 23)
        Me.lblPglInicio.TabIndex = 11
        Me.lblPglInicio.Text = "Pulgadas Inicio"
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
        Me.pglCalTb.Location = New System.Drawing.Point(155, 108)
        Me.pglCalTb.Name = "pglCalTb"
        Me.pglCalTb.PreventEnterBeep = True
        Me.pglCalTb.Size = New System.Drawing.Size(130, 32)
        Me.pglCalTb.TabIndex = 12
        '
        'lblGrupoFinal
        '
        '
        '
        '
        Me.lblGrupoFinal.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblGrupoFinal.Font = New System.Drawing.Font("Comic Sans MS", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGrupoFinal.ForeColor = System.Drawing.Color.LightSalmon
        Me.lblGrupoFinal.Location = New System.Drawing.Point(345, 65)
        Me.lblGrupoFinal.Name = "lblGrupoFinal"
        Me.lblGrupoFinal.Size = New System.Drawing.Size(260, 20)
        Me.lblGrupoFinal.TabIndex = 13
        Me.lblGrupoFinal.Text = "LECTURA FINAL (Domingo)"
        '
        'lblGalFinal
        '
        '
        '
        '
        Me.lblGalFinal.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblGalFinal.Font = New System.Drawing.Font("Comic Sans MS", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGalFinal.FontBold = True
        Me.lblGalFinal.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblGalFinal.Location = New System.Drawing.Point(345, 87)
        Me.lblGalFinal.Name = "lblGalFinal"
        Me.lblGalFinal.Size = New System.Drawing.Size(130, 23)
        Me.lblGalFinal.TabIndex = 14
        Me.lblGalFinal.Text = "Galones Final"
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
        Me.galonesMedTb.Location = New System.Drawing.Point(345, 108)
        Me.galonesMedTb.Name = "galonesMedTb"
        Me.galonesMedTb.PreventEnterBeep = True
        Me.galonesMedTb.Size = New System.Drawing.Size(130, 32)
        Me.galonesMedTb.TabIndex = 15
        '
        'lblPglFinal
        '
        '
        '
        '
        Me.lblPglFinal.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblPglFinal.Font = New System.Drawing.Font("Comic Sans MS", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPglFinal.FontBold = True
        Me.lblPglFinal.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblPglFinal.Location = New System.Drawing.Point(490, 87)
        Me.lblPglFinal.Name = "lblPglFinal"
        Me.lblPglFinal.Size = New System.Drawing.Size(130, 23)
        Me.lblPglFinal.TabIndex = 16
        Me.lblPglFinal.Text = "Pulgadas Final"
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
        Me.pglMedTb.Location = New System.Drawing.Point(490, 108)
        Me.pglMedTb.Name = "pglMedTb"
        Me.pglMedTb.PreventEnterBeep = True
        Me.pglMedTb.Size = New System.Drawing.Size(130, 32)
        Me.pglMedTb.TabIndex = 17
        '
        'lblGalRecibidos
        '
        '
        '
        '
        Me.lblGalRecibidos.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblGalRecibidos.Font = New System.Drawing.Font("Comic Sans MS", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGalRecibidos.FontBold = True
        Me.lblGalRecibidos.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblGalRecibidos.Location = New System.Drawing.Point(10, 147)
        Me.lblGalRecibidos.Name = "lblGalRecibidos"
        Me.lblGalRecibidos.Size = New System.Drawing.Size(120, 23)
        Me.lblGalRecibidos.TabIndex = 18
        Me.lblGalRecibidos.Text = "Gal. Recibidos"
        '
        'galRecibidosTb
        '
        Me.galRecibidosTb.AcceptsTab = True
        Me.galRecibidosTb.BackColor = System.Drawing.Color.SteelBlue
        '
        '
        '
        Me.galRecibidosTb.Border.BackColor = System.Drawing.Color.SteelBlue
        Me.galRecibidosTb.Border.BackColor2 = System.Drawing.Color.SteelBlue
        Me.galRecibidosTb.Border.BorderBottomWidth = 2
        Me.galRecibidosTb.Border.BorderColor = System.Drawing.Color.White
        Me.galRecibidosTb.Border.BorderLeftWidth = 2
        Me.galRecibidosTb.Border.BorderRightWidth = 2
        Me.galRecibidosTb.Border.BorderTopWidth = 2
        Me.galRecibidosTb.Border.Class = "TextBoxBorder"
        Me.galRecibidosTb.Border.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.galRecibidosTb.FocusHighlightColor = System.Drawing.Color.Yellow
        Me.galRecibidosTb.FocusHighlightEnabled = True
        Me.galRecibidosTb.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.galRecibidosTb.ForeColor = System.Drawing.Color.White
        Me.galRecibidosTb.Location = New System.Drawing.Point(10, 168)
        Me.galRecibidosTb.Name = "galRecibidosTb"
        Me.galRecibidosTb.PreventEnterBeep = True
        Me.galRecibidosTb.Size = New System.Drawing.Size(120, 32)
        Me.galRecibidosTb.TabIndex = 19
        '
        'lblGalDespachados
        '
        '
        '
        '
        Me.lblGalDespachados.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblGalDespachados.Font = New System.Drawing.Font("Comic Sans MS", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGalDespachados.FontBold = True
        Me.lblGalDespachados.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblGalDespachados.Location = New System.Drawing.Point(145, 147)
        Me.lblGalDespachados.Name = "lblGalDespachados"
        Me.lblGalDespachados.Size = New System.Drawing.Size(130, 23)
        Me.lblGalDespachados.TabIndex = 20
        Me.lblGalDespachados.Text = "Gal. Despachados"
        '
        'galDespachadosTb
        '
        Me.galDespachadosTb.AcceptsTab = True
        Me.galDespachadosTb.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(80, Byte), Integer), CType(CType(110, Byte), Integer))
        '
        '
        '
        Me.galDespachadosTb.Border.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(80, Byte), Integer), CType(CType(110, Byte), Integer))
        Me.galDespachadosTb.Border.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(80, Byte), Integer), CType(CType(110, Byte), Integer))
        Me.galDespachadosTb.Border.BorderBottomWidth = 2
        Me.galDespachadosTb.Border.BorderColor = System.Drawing.Color.FromArgb(CType(CType(120, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(150, Byte), Integer))
        Me.galDespachadosTb.Border.BorderLeftWidth = 2
        Me.galDespachadosTb.Border.BorderRightWidth = 2
        Me.galDespachadosTb.Border.BorderTopWidth = 2
        Me.galDespachadosTb.Border.Class = "TextBoxBorder"
        Me.galDespachadosTb.Border.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.galDespachadosTb.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.galDespachadosTb.ForeColor = System.Drawing.Color.LightGray
        Me.galDespachadosTb.Location = New System.Drawing.Point(145, 168)
        Me.galDespachadosTb.Name = "galDespachadosTb"
        Me.galDespachadosTb.PreventEnterBeep = True
        Me.galDespachadosTb.ReadOnly = True
        Me.galDespachadosTb.Size = New System.Drawing.Size(120, 32)
        Me.galDespachadosTb.TabIndex = 21
        '
        'lblGalEsperados
        '
        '
        '
        '
        Me.lblGalEsperados.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblGalEsperados.Font = New System.Drawing.Font("Comic Sans MS", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGalEsperados.FontBold = True
        Me.lblGalEsperados.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblGalEsperados.Location = New System.Drawing.Point(280, 147)
        Me.lblGalEsperados.Name = "lblGalEsperados"
        Me.lblGalEsperados.Size = New System.Drawing.Size(120, 23)
        Me.lblGalEsperados.TabIndex = 22
        Me.lblGalEsperados.Text = "Gal. Esperados"
        '
        'galEsperadosTb
        '
        Me.galEsperadosTb.AcceptsTab = True
        Me.galEsperadosTb.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(80, Byte), Integer), CType(CType(110, Byte), Integer))
        '
        '
        '
        Me.galEsperadosTb.Border.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(80, Byte), Integer), CType(CType(110, Byte), Integer))
        Me.galEsperadosTb.Border.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(80, Byte), Integer), CType(CType(110, Byte), Integer))
        Me.galEsperadosTb.Border.BorderBottomWidth = 2
        Me.galEsperadosTb.Border.BorderColor = System.Drawing.Color.FromArgb(CType(CType(120, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(150, Byte), Integer))
        Me.galEsperadosTb.Border.BorderLeftWidth = 2
        Me.galEsperadosTb.Border.BorderRightWidth = 2
        Me.galEsperadosTb.Border.BorderTopWidth = 2
        Me.galEsperadosTb.Border.Class = "TextBoxBorder"
        Me.galEsperadosTb.Border.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.galEsperadosTb.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.galEsperadosTb.ForeColor = System.Drawing.Color.LightGray
        Me.galEsperadosTb.Location = New System.Drawing.Point(280, 168)
        Me.galEsperadosTb.Name = "galEsperadosTb"
        Me.galEsperadosTb.PreventEnterBeep = True
        Me.galEsperadosTb.ReadOnly = True
        Me.galEsperadosTb.Size = New System.Drawing.Size(120, 32)
        Me.galEsperadosTb.TabIndex = 23
        '
        'lblDiferencia
        '
        '
        '
        '
        Me.lblDiferencia.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblDiferencia.Font = New System.Drawing.Font("Comic Sans MS", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDiferencia.FontBold = True
        Me.lblDiferencia.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblDiferencia.Location = New System.Drawing.Point(415, 147)
        Me.lblDiferencia.Name = "lblDiferencia"
        Me.lblDiferencia.Size = New System.Drawing.Size(100, 23)
        Me.lblDiferencia.TabIndex = 24
        Me.lblDiferencia.Text = "Diferencia"
        '
        'diferenciaTb
        '
        Me.diferenciaTb.AcceptsTab = True
        Me.diferenciaTb.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(80, Byte), Integer), CType(CType(110, Byte), Integer))
        '
        '
        '
        Me.diferenciaTb.Border.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(80, Byte), Integer), CType(CType(110, Byte), Integer))
        Me.diferenciaTb.Border.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(80, Byte), Integer), CType(CType(110, Byte), Integer))
        Me.diferenciaTb.Border.BorderBottomWidth = 2
        Me.diferenciaTb.Border.BorderColor = System.Drawing.Color.FromArgb(CType(CType(120, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(150, Byte), Integer))
        Me.diferenciaTb.Border.BorderLeftWidth = 2
        Me.diferenciaTb.Border.BorderRightWidth = 2
        Me.diferenciaTb.Border.BorderTopWidth = 2
        Me.diferenciaTb.Border.Class = "TextBoxBorder"
        Me.diferenciaTb.Border.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.diferenciaTb.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.diferenciaTb.ForeColor = System.Drawing.Color.White
        Me.diferenciaTb.Location = New System.Drawing.Point(415, 168)
        Me.diferenciaTb.Name = "diferenciaTb"
        Me.diferenciaTb.PreventEnterBeep = True
        Me.diferenciaTb.ReadOnly = True
        Me.diferenciaTb.Size = New System.Drawing.Size(100, 32)
        Me.diferenciaTb.TabIndex = 25
        '
        'lblObservaciones
        '
        '
        '
        '
        Me.lblObservaciones.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblObservaciones.Font = New System.Drawing.Font("Comic Sans MS", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblObservaciones.FontBold = True
        Me.lblObservaciones.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblObservaciones.Location = New System.Drawing.Point(540, 147)
        Me.lblObservaciones.Name = "lblObservaciones"
        Me.lblObservaciones.Size = New System.Drawing.Size(120, 23)
        Me.lblObservaciones.TabIndex = 26
        Me.lblObservaciones.Text = "Observaciones"
        '
        'observacionesTb
        '
        Me.observacionesTb.AcceptsTab = True
        Me.observacionesTb.BackColor = System.Drawing.Color.SteelBlue
        '
        '
        '
        Me.observacionesTb.Border.BackColor = System.Drawing.Color.SteelBlue
        Me.observacionesTb.Border.BackColor2 = System.Drawing.Color.SteelBlue
        Me.observacionesTb.Border.BorderBottomWidth = 2
        Me.observacionesTb.Border.BorderColor = System.Drawing.Color.White
        Me.observacionesTb.Border.BorderLeftWidth = 2
        Me.observacionesTb.Border.BorderRightWidth = 2
        Me.observacionesTb.Border.BorderTopWidth = 2
        Me.observacionesTb.Border.Class = "TextBoxBorder"
        Me.observacionesTb.Border.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.observacionesTb.FocusHighlightColor = System.Drawing.Color.Yellow
        Me.observacionesTb.FocusHighlightEnabled = True
        Me.observacionesTb.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.observacionesTb.ForeColor = System.Drawing.Color.White
        Me.observacionesTb.Location = New System.Drawing.Point(540, 168)
        Me.observacionesTb.Name = "observacionesTb"
        Me.observacionesTb.PreventEnterBeep = True
        Me.observacionesTb.Size = New System.Drawing.Size(470, 32)
        Me.observacionesTb.TabIndex = 27
        '
        'MedDGV
        '
        Me.MedDGV.AllowUserToAddRows = False
        Me.MedDGV.AllowUserToDeleteRows = False
        Me.MedDGV.AllowUserToOrderColumns = True
        Me.MedDGV.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.MedDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Comic Sans MS", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.MedDGV.DefaultCellStyle = DataGridViewCellStyle2
        Me.MedDGV.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.MedDGV.Location = New System.Drawing.Point(14, 318)
        Me.MedDGV.Name = "MedDGV"
        Me.MedDGV.ReadOnly = True
        Me.MedDGV.RowHeadersVisible = False
        Me.MedDGV.Size = New System.Drawing.Size(580, 325)
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
        Me.buscartxt.Location = New System.Drawing.Point(640, 15)
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
        Me.lblTotales.Location = New System.Drawing.Point(14, 295)
        Me.lblTotales.Name = "lblTotales"
        Me.lblTotales.Size = New System.Drawing.Size(580, 23)
        Me.lblTotales.TabIndex = 48
        Me.lblTotales.Text = "Registros: 0"
        '
        'PanelGrafica
        '
        Me.PanelGrafica.BackColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.PanelGrafica.Location = New System.Drawing.Point(600, 318)
        Me.PanelGrafica.Name = "PanelGrafica"
        Me.PanelGrafica.Size = New System.Drawing.Size(435, 325)
        Me.PanelGrafica.TabIndex = 49
        '
        'lblTituloGrafica
        '
        '
        '
        '
        Me.lblTituloGrafica.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblTituloGrafica.Font = New System.Drawing.Font("Comic Sans MS", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTituloGrafica.ForeColor = System.Drawing.Color.White
        Me.lblTituloGrafica.Location = New System.Drawing.Point(600, 295)
        Me.lblTituloGrafica.Name = "lblTituloGrafica"
        Me.lblTituloGrafica.Size = New System.Drawing.Size(435, 23)
        Me.lblTituloGrafica.TabIndex = 50
        Me.lblTituloGrafica.Text = "Resumen de Medicion"
        '
        'medicion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.SteelBlue
        Me.ClientSize = New System.Drawing.Size(1055, 654)
        Me.Controls.Add(Me.lblTituloGrafica)
        Me.Controls.Add(Me.PanelGrafica)
        Me.Controls.Add(Me.lblTotales)
        Me.Controls.Add(Me.buscartxt)
        Me.Controls.Add(Me.MedDGV)
        Me.Controls.Add(Me.PanelP)
        Me.Controls.Add(Me.CalcularBtn)
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
    Friend WithEvents CalcularBtn As DevComponents.DotNetBar.ButtonX
    Friend WithEvents PanelP As Panel
    Friend WithEvents lblFecha As DevComponents.DotNetBar.LabelX
    Friend WithEvents fechaTb As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents lblPeriodo As DevComponents.DotNetBar.LabelX
    Friend WithEvents periodoCb As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents P1 As DevComponents.Editors.ComboItem
    Friend WithEvents P2 As DevComponents.Editors.ComboItem
    Friend WithEvents P3 As DevComponents.Editors.ComboItem
    Friend WithEvents P4 As DevComponents.Editors.ComboItem
    Friend WithEvents P5 As DevComponents.Editors.ComboItem
    Friend WithEvents P6 As DevComponents.Editors.ComboItem
    Friend WithEvents P7 As DevComponents.Editors.ComboItem
    Friend WithEvents P8 As DevComponents.Editors.ComboItem
    Friend WithEvents P9 As DevComponents.Editors.ComboItem
    Friend WithEvents P10 As DevComponents.Editors.ComboItem
    Friend WithEvents P11 As DevComponents.Editors.ComboItem
    Friend WithEvents P12 As DevComponents.Editors.ComboItem
    Friend WithEvents P13 As DevComponents.Editors.ComboItem
    Friend WithEvents lblSemana As DevComponents.DotNetBar.LabelX
    Friend WithEvents semanaCb As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents W1 As DevComponents.Editors.ComboItem
    Friend WithEvents W2 As DevComponents.Editors.ComboItem
    Friend WithEvents W3 As DevComponents.Editors.ComboItem
    Friend WithEvents W4 As DevComponents.Editors.ComboItem
    Friend WithEvents W5 As DevComponents.Editors.ComboItem
    Friend WithEvents lblCapacidad As DevComponents.DotNetBar.LabelX
    Friend WithEvents capacidadTb As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents lblGrupoInicial As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblGalInicio As DevComponents.DotNetBar.LabelX
    Friend WithEvents galonesCalcTb As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents lblPglInicio As DevComponents.DotNetBar.LabelX
    Friend WithEvents pglCalTb As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents lblGrupoFinal As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblGalFinal As DevComponents.DotNetBar.LabelX
    Friend WithEvents galonesMedTb As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents lblPglFinal As DevComponents.DotNetBar.LabelX
    Friend WithEvents pglMedTb As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents lblGalRecibidos As DevComponents.DotNetBar.LabelX
    Friend WithEvents galRecibidosTb As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents lblGalDespachados As DevComponents.DotNetBar.LabelX
    Friend WithEvents galDespachadosTb As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents lblGalEsperados As DevComponents.DotNetBar.LabelX
    Friend WithEvents galEsperadosTb As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents lblDiferencia As DevComponents.DotNetBar.LabelX
    Friend WithEvents diferenciaTb As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents lblObservaciones As DevComponents.DotNetBar.LabelX
    Friend WithEvents observacionesTb As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents MedDGV As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents buscartxt As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblTotales As DevComponents.DotNetBar.LabelX
    Friend WithEvents PanelGrafica As Panel
    Friend WithEvents lblTituloGrafica As DevComponents.DotNetBar.LabelX
End Class
