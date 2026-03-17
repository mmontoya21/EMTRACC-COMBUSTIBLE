<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class factura
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(factura))
        Me.CancelarBtn = New DevComponents.DotNetBar.ButtonX()
        Me.EliminarBtn = New DevComponents.DotNetBar.ButtonX()
        Me.EditarBtn = New DevComponents.DotNetBar.ButtonX()
        Me.NuevoBtn = New DevComponents.DotNetBar.ButtonX()
        Me.GuardarBtn = New DevComponents.DotNetBar.ButtonX()
        Me.ModificarBtn = New DevComponents.DotNetBar.ButtonX()
        Me.PanelP = New System.Windows.Forms.Panel()
        Me.LabelX22 = New DevComponents.DotNetBar.LabelX()
        Me.comenta2Tb = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.LabelX17 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX11 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX20 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX16 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX21 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX13 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.ButtonX4 = New DevComponents.DotNetBar.ButtonX()
        Me.btnPaste = New DevComponents.DotNetBar.ButtonX()
        Me.codPropTb = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.preUni2Tb = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.preUni1Tb = New DevComponents.DotNetBar.Controls.TextBoxX()
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
        Me.ButtonX1 = New DevComponents.DotNetBar.ButtonX()
        Me.LabelX18 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX19 = New DevComponents.DotNetBar.LabelX()
        Me.pLetras = New DevComponents.DotNetBar.LabelX()
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX()
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
        Me.nFacTb = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX7 = New DevComponents.DotNetBar.LabelX()
        Me.desc1Tb = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.facCanTB = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.rtnTb = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.propTb = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.ButtonX2 = New DevComponents.DotNetBar.ButtonX()
        Me.buscartxt = New DevComponents.DotNetBar.LabelX()
        Me.propBusqTB = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.CodBusqTB = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.ButtonX6 = New DevComponents.DotNetBar.ButtonX()
        Me.LabelX14 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX15 = New DevComponents.DotNetBar.LabelX()
        Me.ImprimirBt = New DevComponents.DotNetBar.ButtonX()
        Me.PreviaBtn = New DevComponents.DotNetBar.ButtonX()
        Me.FactDgv = New System.Windows.Forms.DataGridView()
        Me.CodproBTb = New System.Windows.Forms.TextBox()
        Me.PrintFactura = New System.Drawing.Printing.PrintDocument()
        Me.PrintPreviewFactura = New System.Windows.Forms.PrintPreviewDialog()
        Me.DelBtn = New DevComponents.DotNetBar.ButtonX()
        Me.ButtonX5 = New DevComponents.DotNetBar.ButtonX()
        Me.ButtonX7 = New DevComponents.DotNetBar.ButtonX()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.PrintDocumento = New System.Drawing.Printing.PrintDocument()
        Me.PrintPreviewDocumento = New System.Windows.Forms.PrintPreviewDialog()
        Me.LabelX23 = New DevComponents.DotNetBar.LabelX()
        Me.lblDesde = New System.Windows.Forms.Label()
        Me.fechaDesdePk = New System.Windows.Forms.DateTimePicker()
        Me.lblHasta = New System.Windows.Forms.Label()
        Me.fechaHastaPk = New System.Windows.Forms.DateTimePicker()
        Me.buscarFechaBtn = New System.Windows.Forms.Button()
        Me.limpiarFechaBtn = New System.Windows.Forms.Button()
        Me.lblReporte = New System.Windows.Forms.Label()
        Me.chkUsarFechaR = New System.Windows.Forms.CheckBox()
        Me.lblFechaDesdeR = New System.Windows.Forms.Label()
        Me.fechaDesdeRPk = New System.Windows.Forms.DateTimePicker()
        Me.lblFechaHastaR = New System.Windows.Forms.Label()
        Me.fechaHastaRPk = New System.Windows.Forms.DateTimePicker()
        Me.lblCodClienteR = New System.Windows.Forms.Label()
        Me.codClienteRTb = New System.Windows.Forms.TextBox()
        Me.lblPlacaR = New System.Windows.Forms.Label()
        Me.placaRTb = New System.Windows.Forms.TextBox()
        Me.lblBoletaR = New System.Windows.Forms.Label()
        Me.boletaRTb = New System.Windows.Forms.TextBox()
        Me.buscarRBtn = New System.Windows.Forms.Button()
        Me.ordenarRBtn = New System.Windows.Forms.Button()
        Me.exportarRBtn = New System.Windows.Forms.Button()
        Me.limpiarRBtn = New System.Windows.Forms.Button()
        Me.reporteDGV = New System.Windows.Forms.DataGridView()
        Me.lblTotalR = New System.Windows.Forms.Label()
        Me.PanelP.SuspendLayout()
        CType(Me.fechaPk, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FactDgv, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.reporteDGV, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'CancelarBtn
        '
        Me.CancelarBtn.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.CancelarBtn.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.CancelarBtn.Font = New System.Drawing.Font("Comic Sans MS", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CancelarBtn.Location = New System.Drawing.Point(434, 13)
        Me.CancelarBtn.Name = "CancelarBtn"
        Me.CancelarBtn.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor(2, 2, 2, 10)
        Me.CancelarBtn.Size = New System.Drawing.Size(82, 33)
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
        Me.EliminarBtn.Font = New System.Drawing.Font("Comic Sans MS", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EliminarBtn.Location = New System.Drawing.Point(345, 13)
        Me.EliminarBtn.Name = "EliminarBtn"
        Me.EliminarBtn.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor(2, 2, 10, 2)
        Me.EliminarBtn.Size = New System.Drawing.Size(83, 34)
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
        Me.EditarBtn.Font = New System.Drawing.Font("Comic Sans MS", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EditarBtn.Location = New System.Drawing.Point(125, 13)
        Me.EditarBtn.Name = "EditarBtn"
        Me.EditarBtn.Size = New System.Drawing.Size(82, 33)
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
        Me.NuevoBtn.Font = New System.Drawing.Font("Comic Sans MS", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NuevoBtn.Location = New System.Drawing.Point(37, 13)
        Me.NuevoBtn.Name = "NuevoBtn"
        Me.NuevoBtn.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor(2, 2, 10, 2)
        Me.NuevoBtn.Size = New System.Drawing.Size(82, 33)
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
        Me.GuardarBtn.Font = New System.Drawing.Font("Comic Sans MS", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GuardarBtn.Location = New System.Drawing.Point(212, 13)
        Me.GuardarBtn.Name = "GuardarBtn"
        Me.GuardarBtn.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor(2, 2, 2, 10)
        Me.GuardarBtn.Size = New System.Drawing.Size(82, 33)
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
        Me.ModificarBtn.Font = New System.Drawing.Font("Comic Sans MS", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ModificarBtn.Location = New System.Drawing.Point(212, 13)
        Me.ModificarBtn.Name = "ModificarBtn"
        Me.ModificarBtn.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor(2, 2, 2, 10)
        Me.ModificarBtn.Size = New System.Drawing.Size(82, 33)
        Me.ModificarBtn.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ModificarBtn.Symbol = ""
        Me.ModificarBtn.SymbolSize = 12.0!
        Me.ModificarBtn.TabIndex = 27
        Me.ModificarBtn.Text = "Modificar"
        '
        'PanelP
        '
        Me.PanelP.Controls.Add(Me.LabelX22)
        Me.PanelP.Controls.Add(Me.comenta2Tb)
        Me.PanelP.Controls.Add(Me.Button3)
        Me.PanelP.Controls.Add(Me.LabelX17)
        Me.PanelP.Controls.Add(Me.LabelX11)
        Me.PanelP.Controls.Add(Me.LabelX20)
        Me.PanelP.Controls.Add(Me.LabelX16)
        Me.PanelP.Controls.Add(Me.LabelX21)
        Me.PanelP.Controls.Add(Me.LabelX13)
        Me.PanelP.Controls.Add(Me.LabelX1)
        Me.PanelP.Controls.Add(Me.ButtonX4)
        Me.PanelP.Controls.Add(Me.btnPaste)
        Me.PanelP.Controls.Add(Me.codPropTb)
        Me.PanelP.Controls.Add(Me.preUni2Tb)
        Me.PanelP.Controls.Add(Me.preUni1Tb)
        Me.PanelP.Controls.Add(Me.fechaPk)
        Me.PanelP.Controls.Add(Me.Line2)
        Me.PanelP.Controls.Add(Me.Line1)
        Me.PanelP.Controls.Add(Me.perSemCB)
        Me.PanelP.Controls.Add(Me.perMesCB)
        Me.PanelP.Controls.Add(Me.tipoPagTb)
        Me.PanelP.Controls.Add(Me.ButtonX1)
        Me.PanelP.Controls.Add(Me.LabelX18)
        Me.PanelP.Controls.Add(Me.LabelX19)
        Me.PanelP.Controls.Add(Me.pLetras)
        Me.PanelP.Controls.Add(Me.LabelX4)
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
        Me.PanelP.Controls.Add(Me.nFacTb)
        Me.PanelP.Controls.Add(Me.LabelX7)
        Me.PanelP.Controls.Add(Me.desc1Tb)
        Me.PanelP.Controls.Add(Me.facCanTB)
        Me.PanelP.Controls.Add(Me.rtnTb)
        Me.PanelP.Controls.Add(Me.propTb)
        Me.PanelP.Location = New System.Drawing.Point(12, 88)
        Me.PanelP.Name = "PanelP"
        Me.PanelP.Size = New System.Drawing.Size(792, 718)
        Me.PanelP.TabIndex = 30
        '
        'LabelX22
        '
        '
        '
        '
        Me.LabelX22.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX22.Font = New System.Drawing.Font("Comic Sans MS", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX22.ForeColor = System.Drawing.Color.DarkBlue
        Me.LabelX22.Location = New System.Drawing.Point(9, 365)
        Me.LabelX22.Name = "LabelX22"
        Me.LabelX22.Size = New System.Drawing.Size(186, 23)
        Me.LabelX22.TabIndex = 30
        Me.LabelX22.Text = "Listado gas despachado"
        Me.LabelX22.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'comenta2Tb
        '
        Me.comenta2Tb.AcceptsTab = True
        Me.comenta2Tb.BackColor = System.Drawing.Color.SteelBlue
        '
        '
        '
        Me.comenta2Tb.Border.BackColor = System.Drawing.Color.SteelBlue
        Me.comenta2Tb.Border.BackColor2 = System.Drawing.Color.SteelBlue
        Me.comenta2Tb.Border.BorderBottomWidth = 2
        Me.comenta2Tb.Border.BorderColor = System.Drawing.Color.White
        Me.comenta2Tb.Border.BorderLeftWidth = 2
        Me.comenta2Tb.Border.BorderRightWidth = 2
        Me.comenta2Tb.Border.BorderTopWidth = 2
        Me.comenta2Tb.Border.Class = "TextBoxBorder"
        Me.comenta2Tb.Border.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.comenta2Tb.FocusHighlightColor = System.Drawing.Color.RoyalBlue
        Me.comenta2Tb.FocusHighlightEnabled = True
        Me.comenta2Tb.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.comenta2Tb.ForeColor = System.Drawing.Color.White
        Me.comenta2Tb.Location = New System.Drawing.Point(6, 383)
        Me.comenta2Tb.Multiline = True
        Me.comenta2Tb.Name = "comenta2Tb"
        Me.comenta2Tb.PreventEnterBeep = True
        Me.comenta2Tb.Size = New System.Drawing.Size(773, 327)
        Me.comenta2Tb.TabIndex = 47
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(494, 320)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(76, 39)
        Me.Button3.TabIndex = 46
        Me.Button3.Text = "Previa Movimientos"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'LabelX17
        '
        '
        '
        '
        Me.LabelX17.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX17.Font = New System.Drawing.Font("Comic Sans MS", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX17.ForeColor = System.Drawing.Color.DarkBlue
        Me.LabelX17.Location = New System.Drawing.Point(587, 175)
        Me.LabelX17.Name = "LabelX17"
        Me.LabelX17.Size = New System.Drawing.Size(54, 23)
        Me.LabelX17.TabIndex = 30
        Me.LabelX17.Text = "Total"
        '
        'LabelX11
        '
        '
        '
        '
        Me.LabelX11.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX11.Font = New System.Drawing.Font("Comic Sans MS", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX11.ForeColor = System.Drawing.Color.DarkBlue
        Me.LabelX11.Location = New System.Drawing.Point(65, 175)
        Me.LabelX11.Name = "LabelX11"
        Me.LabelX11.Size = New System.Drawing.Size(78, 23)
        Me.LabelX11.TabIndex = 30
        Me.LabelX11.Text = "Cantidad"
        '
        'LabelX20
        '
        '
        '
        '
        Me.LabelX20.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX20.Font = New System.Drawing.Font("Comic Sans MS", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX20.ForeColor = System.Drawing.Color.DarkBlue
        Me.LabelX20.Location = New System.Drawing.Point(456, 175)
        Me.LabelX20.Name = "LabelX20"
        Me.LabelX20.Size = New System.Drawing.Size(114, 23)
        Me.LabelX20.TabIndex = 30
        Me.LabelX20.Text = "Precio Unit."
        '
        'LabelX16
        '
        '
        '
        '
        Me.LabelX16.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX16.Font = New System.Drawing.Font("Comic Sans MS", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX16.ForeColor = System.Drawing.Color.DarkBlue
        Me.LabelX16.Location = New System.Drawing.Point(171, 175)
        Me.LabelX16.Name = "LabelX16"
        Me.LabelX16.Size = New System.Drawing.Size(114, 23)
        Me.LabelX16.TabIndex = 30
        Me.LabelX16.Text = "Descripción"
        '
        'LabelX21
        '
        '
        '
        '
        Me.LabelX21.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX21.Font = New System.Drawing.Font("Comic Sans MS", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX21.ForeColor = System.Drawing.Color.DarkBlue
        Me.LabelX21.Location = New System.Drawing.Point(22, 112)
        Me.LabelX21.Name = "LabelX21"
        Me.LabelX21.Size = New System.Drawing.Size(36, 23)
        Me.LabelX21.TabIndex = 30
        Me.LabelX21.Text = "Cod."
        '
        'LabelX13
        '
        '
        '
        '
        Me.LabelX13.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX13.Font = New System.Drawing.Font("Comic Sans MS", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX13.ForeColor = System.Drawing.Color.DarkBlue
        Me.LabelX13.Location = New System.Drawing.Point(16, 53)
        Me.LabelX13.Name = "LabelX13"
        Me.LabelX13.Size = New System.Drawing.Size(82, 23)
        Me.LabelX13.TabIndex = 31
        Me.LabelX13.Text = "Empresa"
        '
        'LabelX1
        '
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Font = New System.Drawing.Font("Comic Sans MS", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX1.ForeColor = System.Drawing.Color.DarkBlue
        Me.LabelX1.Location = New System.Drawing.Point(9, 3)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(89, 23)
        Me.LabelX1.TabIndex = 31
        Me.LabelX1.Text = "Factura N°"
        '
        'ButtonX4
        '
        Me.ButtonX4.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX4.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX4.Location = New System.Drawing.Point(423, 291)
        Me.ButtonX4.Name = "ButtonX4"
        Me.ButtonX4.Size = New System.Drawing.Size(100, 23)
        Me.ButtonX4.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonX4.TabIndex = 45
        Me.ButtonX4.Text = "Borrar Comentario"
        '
        'btnPaste
        '
        Me.btnPaste.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnPaste.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnPaste.Location = New System.Drawing.Point(284, 291)
        Me.btnPaste.Name = "btnPaste"
        Me.btnPaste.Size = New System.Drawing.Size(132, 23)
        Me.btnPaste.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnPaste.TabIndex = 44
        Me.btnPaste.Text = "Pegar Datos de Excel"
        '
        'codPropTb
        '
        Me.codPropTb.BackColor = System.Drawing.Color.SteelBlue
        '
        '
        '
        Me.codPropTb.Border.BackColor = System.Drawing.Color.SteelBlue
        Me.codPropTb.Border.BackColor2 = System.Drawing.Color.SteelBlue
        Me.codPropTb.Border.BorderBottomWidth = 2
        Me.codPropTb.Border.BorderColor = System.Drawing.SystemColors.Window
        Me.codPropTb.Border.BorderLeftWidth = 2
        Me.codPropTb.Border.BorderRightWidth = 2
        Me.codPropTb.Border.BorderTopWidth = 2
        Me.codPropTb.Border.Class = "TextBoxBorder"
        Me.codPropTb.Border.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.codPropTb.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.codPropTb.Location = New System.Drawing.Point(22, 130)
        Me.codPropTb.MaxLength = 60
        Me.codPropTb.Name = "codPropTb"
        Me.codPropTb.PreventEnterBeep = True
        Me.codPropTb.Size = New System.Drawing.Size(127, 30)
        Me.codPropTb.TabIndex = 43
        '
        'preUni2Tb
        '
        Me.preUni2Tb.BackColor = System.Drawing.Color.SteelBlue
        '
        '
        '
        Me.preUni2Tb.Border.BackColor = System.Drawing.Color.SteelBlue
        Me.preUni2Tb.Border.BackColor2 = System.Drawing.Color.SteelBlue
        Me.preUni2Tb.Border.BorderBottomWidth = 2
        Me.preUni2Tb.Border.BorderColor = System.Drawing.SystemColors.Window
        Me.preUni2Tb.Border.BorderLeftWidth = 2
        Me.preUni2Tb.Border.BorderRightWidth = 2
        Me.preUni2Tb.Border.BorderTopWidth = 2
        Me.preUni2Tb.Border.Class = "TextBoxBorder"
        Me.preUni2Tb.Border.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.preUni2Tb.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.preUni2Tb.Location = New System.Drawing.Point(454, 231)
        Me.preUni2Tb.Name = "preUni2Tb"
        Me.preUni2Tb.PreventEnterBeep = True
        Me.preUni2Tb.Size = New System.Drawing.Size(120, 30)
        Me.preUni2Tb.TabIndex = 42
        '
        'preUni1Tb
        '
        Me.preUni1Tb.BackColor = System.Drawing.Color.SteelBlue
        '
        '
        '
        Me.preUni1Tb.Border.BackColor = System.Drawing.Color.SteelBlue
        Me.preUni1Tb.Border.BackColor2 = System.Drawing.Color.SteelBlue
        Me.preUni1Tb.Border.BorderBottomWidth = 2
        Me.preUni1Tb.Border.BorderColor = System.Drawing.SystemColors.Window
        Me.preUni1Tb.Border.BorderLeftWidth = 2
        Me.preUni1Tb.Border.BorderRightWidth = 2
        Me.preUni1Tb.Border.BorderTopWidth = 2
        Me.preUni1Tb.Border.Class = "TextBoxBorder"
        Me.preUni1Tb.Border.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.preUni1Tb.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.preUni1Tb.Location = New System.Drawing.Point(454, 195)
        Me.preUni1Tb.Name = "preUni1Tb"
        Me.preUni1Tb.PreventEnterBeep = True
        Me.preUni1Tb.Size = New System.Drawing.Size(120, 30)
        Me.preUni1Tb.TabIndex = 42
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
        Me.fechaPk.Location = New System.Drawing.Point(564, 27)
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
        Me.Line2.ForeColor = System.Drawing.Color.DarkSlateBlue
        Me.Line2.Location = New System.Drawing.Point(3, 158)
        Me.Line2.Name = "Line2"
        Me.Line2.Size = New System.Drawing.Size(736, 13)
        Me.Line2.TabIndex = 40
        Me.Line2.Text = "Line2"
        Me.Line2.Thickness = 2
        '
        'Line1
        '
        Me.Line1.ForeColor = System.Drawing.Color.DarkSlateBlue
        Me.Line1.Location = New System.Drawing.Point(6, 111)
        Me.Line1.Name = "Line1"
        Me.Line1.Size = New System.Drawing.Size(733, 10)
        Me.Line1.TabIndex = 39
        Me.Line1.Text = "Line1"
        Me.Line1.Thickness = 2
        '
        'perSemCB
        '
        Me.perSemCB.BackColor = System.Drawing.Color.SteelBlue
        Me.perSemCB.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.perSemCB.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.perSemCB.FormattingEnabled = True
        Me.perSemCB.Items.AddRange(New Object() {"01", "02", "03", "04", "05"})
        Me.perSemCB.Location = New System.Drawing.Point(669, 127)
        Me.perSemCB.Name = "perSemCB"
        Me.perSemCB.Size = New System.Drawing.Size(64, 26)
        Me.perSemCB.TabIndex = 37
        '
        'perMesCB
        '
        Me.perMesCB.BackColor = System.Drawing.Color.SteelBlue
        Me.perMesCB.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.perMesCB.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.perMesCB.FormattingEnabled = True
        Me.perMesCB.Items.AddRange(New Object() {"01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12"})
        Me.perMesCB.Location = New System.Drawing.Point(459, 127)
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
        Me.tipoPagTb.Location = New System.Drawing.Point(564, 83)
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
        'ButtonX1
        '
        Me.ButtonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX1.Location = New System.Drawing.Point(10, 195)
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
        Me.LabelX18.Font = New System.Drawing.Font("Comic Sans MS", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX18.ForeColor = System.Drawing.Color.DarkBlue
        Me.LabelX18.Location = New System.Drawing.Point(8, 297)
        Me.LabelX18.Name = "LabelX18"
        Me.LabelX18.Size = New System.Drawing.Size(115, 23)
        Me.LabelX18.TabIndex = 30
        Me.LabelX18.Text = "Observaciones"
        Me.LabelX18.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'LabelX19
        '
        '
        '
        '
        Me.LabelX19.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX19.Font = New System.Drawing.Font("Comic Sans MS", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX19.ForeColor = System.Drawing.Color.DarkBlue
        Me.LabelX19.Location = New System.Drawing.Point(6, 267)
        Me.LabelX19.Name = "LabelX19"
        Me.LabelX19.Size = New System.Drawing.Size(117, 23)
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
        Me.pLetras.Location = New System.Drawing.Point(129, 267)
        Me.pLetras.Name = "pLetras"
        Me.pLetras.Size = New System.Drawing.Size(631, 23)
        Me.pLetras.TabIndex = 30
        Me.pLetras.Text = "-"
        '
        'LabelX4
        '
        '
        '
        '
        Me.LabelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX4.Font = New System.Drawing.Font("Comic Sans MS", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX4.ForeColor = System.Drawing.Color.DarkBlue
        Me.LabelX4.Location = New System.Drawing.Point(584, 292)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Size = New System.Drawing.Size(72, 23)
        Me.LabelX4.TabIndex = 30
        Me.LabelX4.Text = "Cantidad"
        '
        'LabelX10
        '
        '
        '
        '
        Me.LabelX10.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX10.Font = New System.Drawing.Font("Comic Sans MS", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX10.ForeColor = System.Drawing.Color.DarkBlue
        Me.LabelX10.Location = New System.Drawing.Point(377, 55)
        Me.LabelX10.Name = "LabelX10"
        Me.LabelX10.Size = New System.Drawing.Size(36, 23)
        Me.LabelX10.TabIndex = 30
        Me.LabelX10.Text = "RTN"
        '
        'LabelX3
        '
        '
        '
        '
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX3.Font = New System.Drawing.Font("Comic Sans MS", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX3.ForeColor = System.Drawing.Color.DarkBlue
        Me.LabelX3.Location = New System.Drawing.Point(207, 1)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(99, 23)
        Me.LabelX3.TabIndex = 30
        Me.LabelX3.Text = "Propietario"
        '
        'tota2Tb
        '
        Me.tota2Tb.BackColor = System.Drawing.Color.SteelBlue
        '
        '
        '
        Me.tota2Tb.Border.BackColor = System.Drawing.Color.SteelBlue
        Me.tota2Tb.Border.BackColor2 = System.Drawing.Color.SteelBlue
        Me.tota2Tb.Border.BorderBottomWidth = 2
        Me.tota2Tb.Border.BorderColor = System.Drawing.SystemColors.Window
        Me.tota2Tb.Border.BorderLeftWidth = 2
        Me.tota2Tb.Border.BorderRightWidth = 2
        Me.tota2Tb.Border.BorderTopWidth = 2
        Me.tota2Tb.Border.Class = "TextBoxBorder"
        Me.tota2Tb.Border.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.tota2Tb.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tota2Tb.Location = New System.Drawing.Point(580, 231)
        Me.tota2Tb.MaxLength = 6
        Me.tota2Tb.Name = "tota2Tb"
        Me.tota2Tb.PreventEnterBeep = True
        Me.tota2Tb.Size = New System.Drawing.Size(173, 30)
        Me.tota2Tb.TabIndex = 29
        '
        'cant2Tb
        '
        Me.cant2Tb.BackColor = System.Drawing.Color.SteelBlue
        '
        '
        '
        Me.cant2Tb.Border.BackColor = System.Drawing.Color.SteelBlue
        Me.cant2Tb.Border.BackColor2 = System.Drawing.Color.SteelBlue
        Me.cant2Tb.Border.BorderBottomWidth = 2
        Me.cant2Tb.Border.BorderColor = System.Drawing.SystemColors.Window
        Me.cant2Tb.Border.BorderLeftWidth = 2
        Me.cant2Tb.Border.BorderRightWidth = 2
        Me.cant2Tb.Border.BorderTopWidth = 2
        Me.cant2Tb.Border.Class = "TextBoxBorder"
        Me.cant2Tb.Border.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.cant2Tb.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cant2Tb.Location = New System.Drawing.Point(59, 231)
        Me.cant2Tb.MaxLength = 6
        Me.cant2Tb.Name = "cant2Tb"
        Me.cant2Tb.PreventEnterBeep = True
        Me.cant2Tb.Size = New System.Drawing.Size(94, 30)
        Me.cant2Tb.TabIndex = 29
        '
        'facExeTb
        '
        Me.facExeTb.BackColor = System.Drawing.Color.SteelBlue
        '
        '
        '
        Me.facExeTb.Border.BackColor = System.Drawing.Color.SteelBlue
        Me.facExeTb.Border.BackColor2 = System.Drawing.Color.SteelBlue
        Me.facExeTb.Border.BorderBottomWidth = 2
        Me.facExeTb.Border.BorderColor = System.Drawing.SystemColors.Window
        Me.facExeTb.Border.BorderLeftWidth = 2
        Me.facExeTb.Border.BorderRightWidth = 2
        Me.facExeTb.Border.BorderTopWidth = 2
        Me.facExeTb.Border.Class = "TextBoxBorder"
        Me.facExeTb.Border.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.facExeTb.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.facExeTb.Location = New System.Drawing.Point(685, 316)
        Me.facExeTb.MaxLength = 20
        Me.facExeTb.Name = "facExeTb"
        Me.facExeTb.PreventEnterBeep = True
        Me.facExeTb.Size = New System.Drawing.Size(94, 30)
        Me.facExeTb.TabIndex = 29
        '
        'LabelX5
        '
        '
        '
        '
        Me.LabelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX5.Font = New System.Drawing.Font("Comic Sans MS", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX5.ForeColor = System.Drawing.Color.DarkBlue
        Me.LabelX5.Location = New System.Drawing.Point(690, 296)
        Me.LabelX5.Name = "LabelX5"
        Me.LabelX5.Size = New System.Drawing.Size(54, 23)
        Me.LabelX5.TabIndex = 31
        Me.LabelX5.Text = "Exento"
        '
        'desc2Tb
        '
        Me.desc2Tb.BackColor = System.Drawing.Color.SteelBlue
        '
        '
        '
        Me.desc2Tb.Border.BackColor = System.Drawing.Color.SteelBlue
        Me.desc2Tb.Border.BackColor2 = System.Drawing.Color.SteelBlue
        Me.desc2Tb.Border.BorderBottomWidth = 2
        Me.desc2Tb.Border.BorderColor = System.Drawing.SystemColors.Window
        Me.desc2Tb.Border.BorderLeftWidth = 2
        Me.desc2Tb.Border.BorderRightWidth = 2
        Me.desc2Tb.Border.BorderTopWidth = 2
        Me.desc2Tb.Border.Class = "TextBoxBorder"
        Me.desc2Tb.Border.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.desc2Tb.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.desc2Tb.Location = New System.Drawing.Point(164, 231)
        Me.desc2Tb.MaxLength = 45
        Me.desc2Tb.Name = "desc2Tb"
        Me.desc2Tb.PreventEnterBeep = True
        Me.desc2Tb.Size = New System.Drawing.Size(284, 30)
        Me.desc2Tb.TabIndex = 29
        '
        'facTotTb
        '
        Me.facTotTb.BackColor = System.Drawing.Color.SteelBlue
        '
        '
        '
        Me.facTotTb.Border.BackColor = System.Drawing.Color.SteelBlue
        Me.facTotTb.Border.BackColor2 = System.Drawing.Color.SteelBlue
        Me.facTotTb.Border.BorderBottomWidth = 2
        Me.facTotTb.Border.BorderColor = System.Drawing.SystemColors.Window
        Me.facTotTb.Border.BorderLeftWidth = 2
        Me.facTotTb.Border.BorderRightWidth = 2
        Me.facTotTb.Border.BorderTopWidth = 2
        Me.facTotTb.Border.Class = "TextBoxBorder"
        Me.facTotTb.Border.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.facTotTb.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.facTotTb.Location = New System.Drawing.Point(644, 352)
        Me.facTotTb.MaxLength = 20
        Me.facTotTb.Name = "facTotTb"
        Me.facTotTb.PreventEnterBeep = True
        Me.facTotTb.Size = New System.Drawing.Size(135, 30)
        Me.facTotTb.TabIndex = 29
        '
        'LabelX8
        '
        '
        '
        '
        Me.LabelX8.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX8.Font = New System.Drawing.Font("Comic Sans MS", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX8.ForeColor = System.Drawing.Color.DarkBlue
        Me.LabelX8.Location = New System.Drawing.Point(587, 356)
        Me.LabelX8.Name = "LabelX8"
        Me.LabelX8.Size = New System.Drawing.Size(51, 23)
        Me.LabelX8.TabIndex = 31
        Me.LabelX8.Text = "Total"
        '
        'LabelX12
        '
        '
        '
        '
        Me.LabelX12.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX12.Font = New System.Drawing.Font("Comic Sans MS", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX12.ForeColor = System.Drawing.Color.DarkBlue
        Me.LabelX12.Location = New System.Drawing.Point(603, 130)
        Me.LabelX12.Name = "LabelX12"
        Me.LabelX12.Size = New System.Drawing.Size(60, 23)
        Me.LabelX12.TabIndex = 31
        Me.LabelX12.Text = "Semana"
        '
        'LabelX9
        '
        '
        '
        '
        Me.LabelX9.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX9.Font = New System.Drawing.Font("Comic Sans MS", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX9.ForeColor = System.Drawing.Color.DarkBlue
        Me.LabelX9.Location = New System.Drawing.Point(407, 128)
        Me.LabelX9.Name = "LabelX9"
        Me.LabelX9.Size = New System.Drawing.Size(46, 23)
        Me.LabelX9.TabIndex = 31
        Me.LabelX9.Text = "Mes"
        '
        'LabelX6
        '
        '
        '
        '
        Me.LabelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX6.Font = New System.Drawing.Font("Comic Sans MS", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX6.ForeColor = System.Drawing.Color.DarkBlue
        Me.LabelX6.Location = New System.Drawing.Point(268, 129)
        Me.LabelX6.Name = "LabelX6"
        Me.LabelX6.Size = New System.Drawing.Size(61, 23)
        Me.LabelX6.TabIndex = 31
        Me.LabelX6.Text = "Periodo"
        '
        'LabelX2
        '
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.Font = New System.Drawing.Font("Comic Sans MS", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX2.ForeColor = System.Drawing.Color.DarkBlue
        Me.LabelX2.Location = New System.Drawing.Point(562, 59)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(86, 23)
        Me.LabelX2.TabIndex = 31
        Me.LabelX2.Text = "Tipo Pago"
        '
        'comentaTb
        '
        Me.comentaTb.BackColor = System.Drawing.Color.SteelBlue
        '
        '
        '
        Me.comentaTb.Border.BackColor = System.Drawing.Color.SteelBlue
        Me.comentaTb.Border.BackColor2 = System.Drawing.Color.SteelBlue
        Me.comentaTb.Border.BorderBottomWidth = 2
        Me.comentaTb.Border.BorderColor = System.Drawing.SystemColors.Window
        Me.comentaTb.Border.BorderLeftWidth = 2
        Me.comentaTb.Border.BorderRightWidth = 2
        Me.comentaTb.Border.BorderTopWidth = 2
        Me.comentaTb.Border.Class = "TextBoxBorder"
        Me.comentaTb.Border.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.comentaTb.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.comentaTb.Location = New System.Drawing.Point(5, 316)
        Me.comentaTb.MaxLength = 2000
        Me.comentaTb.Multiline = True
        Me.comentaTb.Name = "comentaTb"
        Me.comentaTb.PreventEnterBeep = True
        Me.comentaTb.Size = New System.Drawing.Size(483, 43)
        Me.comentaTb.TabIndex = 32
        '
        'empTb
        '
        Me.empTb.BackColor = System.Drawing.Color.SteelBlue
        '
        '
        '
        Me.empTb.Border.BackColor = System.Drawing.Color.SteelBlue
        Me.empTb.Border.BackColor2 = System.Drawing.Color.SteelBlue
        Me.empTb.Border.BorderBottomWidth = 2
        Me.empTb.Border.BorderColor = System.Drawing.SystemColors.Window
        Me.empTb.Border.BorderLeftWidth = 2
        Me.empTb.Border.BorderRightWidth = 2
        Me.empTb.Border.BorderTopWidth = 2
        Me.empTb.Border.Class = "TextBoxBorder"
        Me.empTb.Border.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.empTb.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.empTb.Location = New System.Drawing.Point(10, 73)
        Me.empTb.MaxLength = 25
        Me.empTb.Name = "empTb"
        Me.empTb.PreventEnterBeep = True
        Me.empTb.Size = New System.Drawing.Size(320, 30)
        Me.empTb.TabIndex = 29
        '
        'tota1Tb
        '
        Me.tota1Tb.BackColor = System.Drawing.Color.SteelBlue
        '
        '
        '
        Me.tota1Tb.Border.BackColor = System.Drawing.Color.SteelBlue
        Me.tota1Tb.Border.BackColor2 = System.Drawing.Color.SteelBlue
        Me.tota1Tb.Border.BorderBottomWidth = 2
        Me.tota1Tb.Border.BorderColor = System.Drawing.SystemColors.Window
        Me.tota1Tb.Border.BorderLeftWidth = 2
        Me.tota1Tb.Border.BorderRightWidth = 2
        Me.tota1Tb.Border.BorderTopWidth = 2
        Me.tota1Tb.Border.Class = "TextBoxBorder"
        Me.tota1Tb.Border.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.tota1Tb.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tota1Tb.Location = New System.Drawing.Point(580, 195)
        Me.tota1Tb.MaxLength = 15
        Me.tota1Tb.Name = "tota1Tb"
        Me.tota1Tb.PreventEnterBeep = True
        Me.tota1Tb.Size = New System.Drawing.Size(173, 30)
        Me.tota1Tb.TabIndex = 32
        '
        'cant1Tb
        '
        Me.cant1Tb.BackColor = System.Drawing.Color.SteelBlue
        '
        '
        '
        Me.cant1Tb.Border.BackColor = System.Drawing.Color.SteelBlue
        Me.cant1Tb.Border.BackColor2 = System.Drawing.Color.SteelBlue
        Me.cant1Tb.Border.BorderBottomWidth = 2
        Me.cant1Tb.Border.BorderColor = System.Drawing.SystemColors.Window
        Me.cant1Tb.Border.BorderLeftWidth = 2
        Me.cant1Tb.Border.BorderRightWidth = 2
        Me.cant1Tb.Border.BorderTopWidth = 2
        Me.cant1Tb.Border.Class = "TextBoxBorder"
        Me.cant1Tb.Border.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.cant1Tb.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cant1Tb.Location = New System.Drawing.Point(59, 195)
        Me.cant1Tb.MaxLength = 15
        Me.cant1Tb.Name = "cant1Tb"
        Me.cant1Tb.PreventEnterBeep = True
        Me.cant1Tb.Size = New System.Drawing.Size(94, 30)
        Me.cant1Tb.TabIndex = 32
        '
        'nFacTb
        '
        Me.nFacTb.BackColor = System.Drawing.Color.SteelBlue
        '
        '
        '
        Me.nFacTb.Border.BackColor = System.Drawing.Color.SteelBlue
        Me.nFacTb.Border.BackColor2 = System.Drawing.Color.SteelBlue
        Me.nFacTb.Border.BorderBottomWidth = 2
        Me.nFacTb.Border.BorderColor = System.Drawing.SystemColors.Window
        Me.nFacTb.Border.BorderLeftWidth = 2
        Me.nFacTb.Border.BorderRightWidth = 2
        Me.nFacTb.Border.BorderTopWidth = 2
        Me.nFacTb.Border.Class = "TextBoxBorder"
        Me.nFacTb.Border.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.nFacTb.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nFacTb.Location = New System.Drawing.Point(9, 21)
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
        Me.LabelX7.Font = New System.Drawing.Font("Comic Sans MS", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX7.ForeColor = System.Drawing.Color.DarkBlue
        Me.LabelX7.Location = New System.Drawing.Point(562, 2)
        Me.LabelX7.Name = "LabelX7"
        Me.LabelX7.Size = New System.Drawing.Size(54, 23)
        Me.LabelX7.TabIndex = 31
        Me.LabelX7.Text = "Fecha"
        '
        'desc1Tb
        '
        Me.desc1Tb.BackColor = System.Drawing.Color.SteelBlue
        '
        '
        '
        Me.desc1Tb.Border.BackColor = System.Drawing.Color.SteelBlue
        Me.desc1Tb.Border.BackColor2 = System.Drawing.Color.SteelBlue
        Me.desc1Tb.Border.BorderBottomWidth = 2
        Me.desc1Tb.Border.BorderColor = System.Drawing.SystemColors.Window
        Me.desc1Tb.Border.BorderLeftWidth = 2
        Me.desc1Tb.Border.BorderRightWidth = 2
        Me.desc1Tb.Border.BorderTopWidth = 2
        Me.desc1Tb.Border.Class = "TextBoxBorder"
        Me.desc1Tb.Border.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.desc1Tb.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.desc1Tb.Location = New System.Drawing.Point(164, 195)
        Me.desc1Tb.MaxLength = 45
        Me.desc1Tb.Name = "desc1Tb"
        Me.desc1Tb.PreventEnterBeep = True
        Me.desc1Tb.Size = New System.Drawing.Size(284, 30)
        Me.desc1Tb.TabIndex = 32
        '
        'facCanTB
        '
        Me.facCanTB.BackColor = System.Drawing.Color.SteelBlue
        '
        '
        '
        Me.facCanTB.Border.BackColor = System.Drawing.Color.SteelBlue
        Me.facCanTB.Border.BackColor2 = System.Drawing.Color.SteelBlue
        Me.facCanTB.Border.BorderBottomWidth = 2
        Me.facCanTB.Border.BorderColor = System.Drawing.SystemColors.Window
        Me.facCanTB.Border.BorderLeftWidth = 2
        Me.facCanTB.Border.BorderRightWidth = 2
        Me.facCanTB.Border.BorderTopWidth = 2
        Me.facCanTB.Border.Class = "TextBoxBorder"
        Me.facCanTB.Border.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.facCanTB.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.facCanTB.Location = New System.Drawing.Point(580, 316)
        Me.facCanTB.MaxLength = 20
        Me.facCanTB.Name = "facCanTB"
        Me.facCanTB.PreventEnterBeep = True
        Me.facCanTB.Size = New System.Drawing.Size(94, 30)
        Me.facCanTB.TabIndex = 32
        '
        'rtnTb
        '
        Me.rtnTb.BackColor = System.Drawing.Color.SteelBlue
        '
        '
        '
        Me.rtnTb.Border.BackColor = System.Drawing.Color.SteelBlue
        Me.rtnTb.Border.BackColor2 = System.Drawing.Color.SteelBlue
        Me.rtnTb.Border.BorderBottomWidth = 2
        Me.rtnTb.Border.BorderColor = System.Drawing.SystemColors.Window
        Me.rtnTb.Border.BorderLeftWidth = 2
        Me.rtnTb.Border.BorderRightWidth = 2
        Me.rtnTb.Border.BorderTopWidth = 2
        Me.rtnTb.Border.Class = "TextBoxBorder"
        Me.rtnTb.Border.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.rtnTb.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rtnTb.Location = New System.Drawing.Point(377, 73)
        Me.rtnTb.MaxLength = 16
        Me.rtnTb.Name = "rtnTb"
        Me.rtnTb.PreventEnterBeep = True
        Me.rtnTb.Size = New System.Drawing.Size(144, 30)
        Me.rtnTb.TabIndex = 32
        '
        'propTb
        '
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
        Me.propTb.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.propTb.Location = New System.Drawing.Point(202, 19)
        Me.propTb.MaxLength = 30
        Me.propTb.Name = "propTb"
        Me.propTb.PreventEnterBeep = True
        Me.propTb.Size = New System.Drawing.Size(320, 30)
        Me.propTb.TabIndex = 32
        '
        'ButtonX2
        '
        Me.ButtonX2.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX2.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX2.Location = New System.Drawing.Point(129, 59)
        Me.ButtonX2.Name = "ButtonX2"
        Me.ButtonX2.Size = New System.Drawing.Size(32, 26)
        Me.ButtonX2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonX2.Symbol = ""
        Me.ButtonX2.SymbolColor = System.Drawing.Color.Green
        Me.ButtonX2.TabIndex = 34
        '
        'buscartxt
        '
        '
        '
        '
        Me.buscartxt.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.buscartxt.Location = New System.Drawing.Point(239, 62)
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
        Me.propBusqTB.Location = New System.Drawing.Point(901, 36)
        Me.propBusqTB.Name = "propBusqTB"
        Me.propBusqTB.PreventEnterBeep = True
        Me.propBusqTB.Size = New System.Drawing.Size(75, 20)
        Me.propBusqTB.TabIndex = 35
        '
        'CodBusqTB
        '
        Me.CodBusqTB.BackColor = System.Drawing.Color.SteelBlue
        '
        '
        '
        Me.CodBusqTB.Border.BackColor = System.Drawing.Color.SteelBlue
        Me.CodBusqTB.Border.BackColor2 = System.Drawing.Color.SteelBlue
        Me.CodBusqTB.Border.Class = "TextBoxBorder"
        Me.CodBusqTB.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.CodBusqTB.Location = New System.Drawing.Point(23, 66)
        Me.CodBusqTB.Name = "CodBusqTB"
        Me.CodBusqTB.PreventEnterBeep = True
        Me.CodBusqTB.Size = New System.Drawing.Size(100, 20)
        Me.CodBusqTB.TabIndex = 34
        '
        'ButtonX6
        '
        Me.ButtonX6.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX6.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX6.Location = New System.Drawing.Point(638, 59)
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
        Me.LabelX14.Location = New System.Drawing.Point(820, 13)
        Me.LabelX14.Name = "LabelX14"
        Me.LabelX14.Size = New System.Drawing.Size(75, 23)
        Me.LabelX14.TabIndex = 31
        Me.LabelX14.Text = "Código"
        '
        'LabelX15
        '
        '
        '
        '
        Me.LabelX15.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX15.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX15.ForeColor = System.Drawing.Color.DarkBlue
        Me.LabelX15.Location = New System.Drawing.Point(24, 45)
        Me.LabelX15.Name = "LabelX15"
        Me.LabelX15.Size = New System.Drawing.Size(44, 23)
        Me.LabelX15.TabIndex = 32
        Me.LabelX15.Text = "Código"
        '
        'ImprimirBt
        '
        Me.ImprimirBt.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ImprimirBt.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ImprimirBt.Font = New System.Drawing.Font("Comic Sans MS", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImprimirBt.Location = New System.Drawing.Point(572, 13)
        Me.ImprimirBt.Name = "ImprimirBt"
        Me.ImprimirBt.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor(10, 10, 2, 2)
        Me.ImprimirBt.Size = New System.Drawing.Size(98, 33)
        Me.ImprimirBt.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ImprimirBt.Symbol = ""
        Me.ImprimirBt.TabIndex = 37
        Me.ImprimirBt.Text = "Imprimir"
        '
        'PreviaBtn
        '
        Me.PreviaBtn.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.PreviaBtn.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.PreviaBtn.Font = New System.Drawing.Font("Comic Sans MS", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PreviaBtn.Location = New System.Drawing.Point(674, 13)
        Me.PreviaBtn.Name = "PreviaBtn"
        Me.PreviaBtn.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor(2, 2, 10, 10)
        Me.PreviaBtn.Size = New System.Drawing.Size(98, 33)
        Me.PreviaBtn.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.PreviaBtn.Symbol = ""
        Me.PreviaBtn.TabIndex = 38
        Me.PreviaBtn.Text = "Previa"
        '
        'FactDgv
        '
        Me.FactDgv.AllowUserToAddRows = False
        Me.FactDgv.AllowUserToDeleteRows = False
        Me.FactDgv.AllowUserToOrderColumns = True
        Me.FactDgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.FactDgv.DefaultCellStyle = DataGridViewCellStyle1
        Me.FactDgv.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.FactDgv.Location = New System.Drawing.Point(820, 59)
        Me.FactDgv.Name = "FactDgv"
        Me.FactDgv.ReadOnly = True
        Me.FactDgv.RowHeadersVisible = False
        Me.FactDgv.Size = New System.Drawing.Size(609, 398)
        Me.FactDgv.TabIndex = 39
        '
        'CodproBTb
        '
        Me.CodproBTb.Location = New System.Drawing.Point(820, 37)
        Me.CodproBTb.Name = "CodproBTb"
        Me.CodproBTb.Size = New System.Drawing.Size(75, 20)
        Me.CodproBTb.TabIndex = 41
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
        'DelBtn
        '
        Me.DelBtn.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.DelBtn.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.DelBtn.Location = New System.Drawing.Point(167, 59)
        Me.DelBtn.Name = "DelBtn"
        Me.DelBtn.Size = New System.Drawing.Size(30, 26)
        Me.DelBtn.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.DelBtn.Symbol = ""
        Me.DelBtn.TabIndex = 43
        '
        'ButtonX5
        '
        Me.ButtonX5.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX5.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX5.Location = New System.Drawing.Point(982, 30)
        Me.ButtonX5.Name = "ButtonX5"
        Me.ButtonX5.Size = New System.Drawing.Size(32, 26)
        Me.ButtonX5.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonX5.Symbol = ""
        Me.ButtonX5.SymbolColor = System.Drawing.Color.Green
        Me.ButtonX5.TabIndex = 44
        '
        'ButtonX7
        '
        Me.ButtonX7.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX7.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX7.Location = New System.Drawing.Point(784, 32)
        Me.ButtonX7.Name = "ButtonX7"
        Me.ButtonX7.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor(2)
        Me.ButtonX7.Size = New System.Drawing.Size(30, 26)
        Me.ButtonX7.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonX7.Symbol = ""
        Me.ButtonX7.TabIndex = 45
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(553, 59)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 46
        Me.Button2.Text = "Button2"
        Me.Button2.UseVisualStyleBackColor = True
        Me.Button2.Visible = False
        '
        'PrintDocumento
        '
        '
        'PrintPreviewDocumento
        '
        Me.PrintPreviewDocumento.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.PrintPreviewDocumento.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.PrintPreviewDocumento.ClientSize = New System.Drawing.Size(400, 300)
        Me.PrintPreviewDocumento.Enabled = True
        Me.PrintPreviewDocumento.Icon = CType(resources.GetObject("PrintPreviewDocumento.Icon"), System.Drawing.Icon)
        Me.PrintPreviewDocumento.Name = "PrintPreviewDocumento"
        Me.PrintPreviewDocumento.Visible = False
        '
        'LabelX23
        '
        '
        '
        '
        Me.LabelX23.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX23.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX23.Location = New System.Drawing.Point(901, 14)
        Me.LabelX23.Name = "LabelX23"
        Me.LabelX23.Size = New System.Drawing.Size(75, 23)
        Me.LabelX23.TabIndex = 31
        Me.LabelX23.Text = "Factura"
        '
        'lblDesde
        '
        Me.lblDesde.AutoSize = True
        Me.lblDesde.BackColor = System.Drawing.Color.Transparent
        Me.lblDesde.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblDesde.ForeColor = System.Drawing.Color.White
        Me.lblDesde.Location = New System.Drawing.Point(1028, 19)
        Me.lblDesde.Name = "lblDesde"
        Me.lblDesde.Size = New System.Drawing.Size(43, 15)
        Me.lblDesde.TabIndex = 42
        Me.lblDesde.Text = "Desde:"
        '
        'fechaDesdePk
        '
        Me.fechaDesdePk.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.fechaDesdePk.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.fechaDesdePk.Location = New System.Drawing.Point(1031, 33)
        Me.fechaDesdePk.Name = "fechaDesdePk"
        Me.fechaDesdePk.Size = New System.Drawing.Size(120, 23)
        Me.fechaDesdePk.TabIndex = 43
        '
        'lblHasta
        '
        Me.lblHasta.AutoSize = True
        Me.lblHasta.BackColor = System.Drawing.Color.Transparent
        Me.lblHasta.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblHasta.ForeColor = System.Drawing.Color.White
        Me.lblHasta.Location = New System.Drawing.Point(1154, 13)
        Me.lblHasta.Name = "lblHasta"
        Me.lblHasta.Size = New System.Drawing.Size(40, 15)
        Me.lblHasta.TabIndex = 44
        Me.lblHasta.Text = "Hasta:"
        '
        'fechaHastaPk
        '
        Me.fechaHastaPk.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.fechaHastaPk.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.fechaHastaPk.Location = New System.Drawing.Point(1157, 33)
        Me.fechaHastaPk.Name = "fechaHastaPk"
        Me.fechaHastaPk.Size = New System.Drawing.Size(120, 23)
        Me.fechaHastaPk.TabIndex = 45
        '
        'buscarFechaBtn
        '
        Me.buscarFechaBtn.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.buscarFechaBtn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.buscarFechaBtn.FlatAppearance.BorderSize = 0
        Me.buscarFechaBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.buscarFechaBtn.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.buscarFechaBtn.ForeColor = System.Drawing.Color.White
        Me.buscarFechaBtn.Location = New System.Drawing.Point(1283, 31)
        Me.buscarFechaBtn.Name = "buscarFechaBtn"
        Me.buscarFechaBtn.Size = New System.Drawing.Size(70, 27)
        Me.buscarFechaBtn.TabIndex = 46
        Me.buscarFechaBtn.Text = "Buscar"
        Me.buscarFechaBtn.UseVisualStyleBackColor = False
        '
        'limpiarFechaBtn
        '
        Me.limpiarFechaBtn.BackColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(55, Byte), Integer), CType(CType(55, Byte), Integer))
        Me.limpiarFechaBtn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.limpiarFechaBtn.FlatAppearance.BorderSize = 0
        Me.limpiarFechaBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.limpiarFechaBtn.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.limpiarFechaBtn.ForeColor = System.Drawing.Color.White
        Me.limpiarFechaBtn.Location = New System.Drawing.Point(1359, 30)
        Me.limpiarFechaBtn.Name = "limpiarFechaBtn"
        Me.limpiarFechaBtn.Size = New System.Drawing.Size(70, 27)
        Me.limpiarFechaBtn.TabIndex = 47
        Me.limpiarFechaBtn.Text = "Todos"
        Me.limpiarFechaBtn.UseVisualStyleBackColor = False
        '
        'lblReporte
        '
        Me.lblReporte.AutoSize = True
        Me.lblReporte.BackColor = System.Drawing.Color.Transparent
        Me.lblReporte.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold)
        Me.lblReporte.ForeColor = System.Drawing.Color.White
        Me.lblReporte.Location = New System.Drawing.Point(820, 464)
        Me.lblReporte.Name = "lblReporte"
        Me.lblReporte.Size = New System.Drawing.Size(56, 17)
        Me.lblReporte.TabIndex = 48
        Me.lblReporte.Text = "Reporte"
        '
        'chkUsarFechaR
        '
        Me.chkUsarFechaR.AutoSize = True
        Me.chkUsarFechaR.BackColor = System.Drawing.Color.Transparent
        Me.chkUsarFechaR.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.chkUsarFechaR.ForeColor = System.Drawing.Color.White
        Me.chkUsarFechaR.Location = New System.Drawing.Point(895, 464)
        Me.chkUsarFechaR.Name = "chkUsarFechaR"
        Me.chkUsarFechaR.Size = New System.Drawing.Size(109, 19)
        Me.chkUsarFechaR.TabIndex = 49
        Me.chkUsarFechaR.Text = "Filtrar por fecha"
        Me.chkUsarFechaR.UseVisualStyleBackColor = False
        '
        'lblFechaDesdeR
        '
        Me.lblFechaDesdeR.AutoSize = True
        Me.lblFechaDesdeR.BackColor = System.Drawing.Color.Transparent
        Me.lblFechaDesdeR.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblFechaDesdeR.ForeColor = System.Drawing.Color.White
        Me.lblFechaDesdeR.Location = New System.Drawing.Point(1010, 464)
        Me.lblFechaDesdeR.Name = "lblFechaDesdeR"
        Me.lblFechaDesdeR.Size = New System.Drawing.Size(42, 15)
        Me.lblFechaDesdeR.TabIndex = 50
        Me.lblFechaDesdeR.Text = "Desde:"
        '
        'fechaDesdeRPk
        '
        Me.fechaDesdeRPk.CalendarMonthBackground = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.fechaDesdeRPk.Enabled = False
        Me.fechaDesdeRPk.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.fechaDesdeRPk.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.fechaDesdeRPk.Location = New System.Drawing.Point(1055, 462)
        Me.fechaDesdeRPk.Name = "fechaDesdeRPk"
        Me.fechaDesdeRPk.Size = New System.Drawing.Size(110, 23)
        Me.fechaDesdeRPk.TabIndex = 51
        '
        'lblFechaHastaR
        '
        Me.lblFechaHastaR.AutoSize = True
        Me.lblFechaHastaR.BackColor = System.Drawing.Color.Transparent
        Me.lblFechaHastaR.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblFechaHastaR.ForeColor = System.Drawing.Color.White
        Me.lblFechaHastaR.Location = New System.Drawing.Point(1170, 464)
        Me.lblFechaHastaR.Name = "lblFechaHastaR"
        Me.lblFechaHastaR.Size = New System.Drawing.Size(40, 15)
        Me.lblFechaHastaR.TabIndex = 52
        Me.lblFechaHastaR.Text = "Hasta:"
        '
        'fechaHastaRPk
        '
        Me.fechaHastaRPk.CalendarMonthBackground = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.fechaHastaRPk.Enabled = False
        Me.fechaHastaRPk.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.fechaHastaRPk.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.fechaHastaRPk.Location = New System.Drawing.Point(1210, 462)
        Me.fechaHastaRPk.Name = "fechaHastaRPk"
        Me.fechaHastaRPk.Size = New System.Drawing.Size(110, 23)
        Me.fechaHastaRPk.TabIndex = 53
        '
        'lblCodClienteR
        '
        Me.lblCodClienteR.AutoSize = True
        Me.lblCodClienteR.BackColor = System.Drawing.Color.Transparent
        Me.lblCodClienteR.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblCodClienteR.ForeColor = System.Drawing.Color.White
        Me.lblCodClienteR.Location = New System.Drawing.Point(820, 492)
        Me.lblCodClienteR.Name = "lblCodClienteR"
        Me.lblCodClienteR.Size = New System.Drawing.Size(32, 15)
        Me.lblCodClienteR.TabIndex = 54
        Me.lblCodClienteR.Text = "Cod:"
        '
        'codClienteRTb
        '
        Me.codClienteRTb.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.codClienteRTb.Location = New System.Drawing.Point(852, 488)
        Me.codClienteRTb.Name = "codClienteRTb"
        Me.codClienteRTb.Size = New System.Drawing.Size(75, 23)
        Me.codClienteRTb.TabIndex = 55
        '
        'lblPlacaR
        '
        Me.lblPlacaR.AutoSize = True
        Me.lblPlacaR.BackColor = System.Drawing.Color.Transparent
        Me.lblPlacaR.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblPlacaR.ForeColor = System.Drawing.Color.White
        Me.lblPlacaR.Location = New System.Drawing.Point(933, 492)
        Me.lblPlacaR.Name = "lblPlacaR"
        Me.lblPlacaR.Size = New System.Drawing.Size(38, 15)
        Me.lblPlacaR.TabIndex = 56
        Me.lblPlacaR.Text = "Placa:"
        '
        'placaRTb
        '
        Me.placaRTb.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.placaRTb.Location = New System.Drawing.Point(972, 488)
        Me.placaRTb.Name = "placaRTb"
        Me.placaRTb.Size = New System.Drawing.Size(75, 23)
        Me.placaRTb.TabIndex = 57
        '
        'lblBoletaR
        '
        Me.lblBoletaR.AutoSize = True
        Me.lblBoletaR.BackColor = System.Drawing.Color.Transparent
        Me.lblBoletaR.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblBoletaR.ForeColor = System.Drawing.Color.White
        Me.lblBoletaR.Location = New System.Drawing.Point(1053, 492)
        Me.lblBoletaR.Name = "lblBoletaR"
        Me.lblBoletaR.Size = New System.Drawing.Size(43, 15)
        Me.lblBoletaR.TabIndex = 58
        Me.lblBoletaR.Text = "Boleta:"
        '
        'boletaRTb
        '
        Me.boletaRTb.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.boletaRTb.Location = New System.Drawing.Point(1099, 488)
        Me.boletaRTb.Name = "boletaRTb"
        Me.boletaRTb.Size = New System.Drawing.Size(75, 23)
        Me.boletaRTb.TabIndex = 59
        '
        'buscarRBtn
        '
        Me.buscarRBtn.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.buscarRBtn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.buscarRBtn.FlatAppearance.BorderSize = 0
        Me.buscarRBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.buscarRBtn.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold)
        Me.buscarRBtn.ForeColor = System.Drawing.Color.White
        Me.buscarRBtn.Location = New System.Drawing.Point(1182, 486)
        Me.buscarRBtn.Name = "buscarRBtn"
        Me.buscarRBtn.Size = New System.Drawing.Size(55, 25)
        Me.buscarRBtn.TabIndex = 60
        Me.buscarRBtn.Text = "Buscar"
        Me.buscarRBtn.UseVisualStyleBackColor = False
        '
        'ordenarRBtn
        '
        Me.ordenarRBtn.BackColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(55, Byte), Integer), CType(CType(55, Byte), Integer))
        Me.ordenarRBtn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ordenarRBtn.FlatAppearance.BorderSize = 0
        Me.ordenarRBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ordenarRBtn.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold)
        Me.ordenarRBtn.ForeColor = System.Drawing.Color.White
        Me.ordenarRBtn.Location = New System.Drawing.Point(1241, 486)
        Me.ordenarRBtn.Name = "ordenarRBtn"
        Me.ordenarRBtn.Size = New System.Drawing.Size(58, 25)
        Me.ordenarRBtn.TabIndex = 61
        Me.ordenarRBtn.Text = "Ordenar"
        Me.ordenarRBtn.UseVisualStyleBackColor = False
        '
        'exportarRBtn
        '
        Me.exportarRBtn.BackColor = System.Drawing.Color.FromArgb(CType(CType(16, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(62, Byte), Integer))
        Me.exportarRBtn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.exportarRBtn.FlatAppearance.BorderSize = 0
        Me.exportarRBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.exportarRBtn.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold)
        Me.exportarRBtn.ForeColor = System.Drawing.Color.White
        Me.exportarRBtn.Location = New System.Drawing.Point(1303, 486)
        Me.exportarRBtn.Name = "exportarRBtn"
        Me.exportarRBtn.Size = New System.Drawing.Size(62, 25)
        Me.exportarRBtn.TabIndex = 62
        Me.exportarRBtn.Text = "Exportar"
        Me.exportarRBtn.UseVisualStyleBackColor = False
        '
        'limpiarRBtn
        '
        Me.limpiarRBtn.BackColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(55, Byte), Integer), CType(CType(55, Byte), Integer))
        Me.limpiarRBtn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.limpiarRBtn.FlatAppearance.BorderSize = 0
        Me.limpiarRBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.limpiarRBtn.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold)
        Me.limpiarRBtn.ForeColor = System.Drawing.Color.White
        Me.limpiarRBtn.Location = New System.Drawing.Point(1369, 486)
        Me.limpiarRBtn.Name = "limpiarRBtn"
        Me.limpiarRBtn.Size = New System.Drawing.Size(55, 25)
        Me.limpiarRBtn.TabIndex = 63
        Me.limpiarRBtn.Text = "Limpiar"
        Me.limpiarRBtn.UseVisualStyleBackColor = False
        '
        'reporteDGV
        '
        Me.reporteDGV.AllowUserToAddRows = False
        Me.reporteDGV.AllowUserToDeleteRows = False
        Me.reporteDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.reporteDGV.Location = New System.Drawing.Point(820, 515)
        Me.reporteDGV.Name = "reporteDGV"
        Me.reporteDGV.ReadOnly = True
        Me.reporteDGV.RowHeadersVisible = False
        Me.reporteDGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.reporteDGV.Size = New System.Drawing.Size(882, 270)
        Me.reporteDGV.TabIndex = 64
        '
        'lblTotalR
        '
        Me.lblTotalR.AutoSize = True
        Me.lblTotalR.BackColor = System.Drawing.Color.Transparent
        Me.lblTotalR.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblTotalR.ForeColor = System.Drawing.Color.White
        Me.lblTotalR.Location = New System.Drawing.Point(820, 790)
        Me.lblTotalR.Name = "lblTotalR"
        Me.lblTotalR.Size = New System.Drawing.Size(99, 15)
        Me.lblTotalR.TabIndex = 65
        Me.lblTotalR.Text = "Total registros: 0"
        '
        'factura
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.SteelBlue
        Me.ClientSize = New System.Drawing.Size(1714, 818)
        Me.Controls.Add(Me.lblTotalR)
        Me.Controls.Add(Me.reporteDGV)
        Me.Controls.Add(Me.limpiarRBtn)
        Me.Controls.Add(Me.exportarRBtn)
        Me.Controls.Add(Me.ordenarRBtn)
        Me.Controls.Add(Me.buscarRBtn)
        Me.Controls.Add(Me.boletaRTb)
        Me.Controls.Add(Me.lblBoletaR)
        Me.Controls.Add(Me.placaRTb)
        Me.Controls.Add(Me.lblPlacaR)
        Me.Controls.Add(Me.codClienteRTb)
        Me.Controls.Add(Me.lblCodClienteR)
        Me.Controls.Add(Me.fechaHastaRPk)
        Me.Controls.Add(Me.lblFechaHastaR)
        Me.Controls.Add(Me.fechaDesdeRPk)
        Me.Controls.Add(Me.lblFechaDesdeR)
        Me.Controls.Add(Me.chkUsarFechaR)
        Me.Controls.Add(Me.lblReporte)
        Me.Controls.Add(Me.limpiarFechaBtn)
        Me.Controls.Add(Me.buscarFechaBtn)
        Me.Controls.Add(Me.fechaHastaPk)
        Me.Controls.Add(Me.lblHasta)
        Me.Controls.Add(Me.fechaDesdePk)
        Me.Controls.Add(Me.lblDesde)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.ButtonX7)
        Me.Controls.Add(Me.ButtonX5)
        Me.Controls.Add(Me.DelBtn)
        Me.Controls.Add(Me.CodproBTb)
        Me.Controls.Add(Me.FactDgv)
        Me.Controls.Add(Me.PreviaBtn)
        Me.Controls.Add(Me.ImprimirBt)
        Me.Controls.Add(Me.buscartxt)
        Me.Controls.Add(Me.propBusqTB)
        Me.Controls.Add(Me.CodBusqTB)
        Me.Controls.Add(Me.ButtonX2)
        Me.Controls.Add(Me.ButtonX6)
        Me.Controls.Add(Me.LabelX23)
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
        CType(Me.FactDgv, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.reporteDGV, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents CodBusqTB As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents ButtonX6 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents LabelX14 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX15 As DevComponents.DotNetBar.LabelX
    Friend WithEvents ImprimirBt As DevComponents.DotNetBar.ButtonX
    Friend WithEvents PreviaBtn As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Line2 As DevComponents.DotNetBar.Controls.Line
    Friend WithEvents Line1 As DevComponents.DotNetBar.Controls.Line
    Friend WithEvents LabelX19 As DevComponents.DotNetBar.LabelX
    Friend WithEvents pLetras As DevComponents.DotNetBar.LabelX
    Friend WithEvents FactDgv As System.Windows.Forms.DataGridView
    Friend WithEvents CodproBTb As TextBox
    Friend WithEvents PrintFactura As Printing.PrintDocument
    Friend WithEvents PrintPreviewFactura As PrintPreviewDialog
    Friend WithEvents fechaPk As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents preUni2Tb As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents preUni1Tb As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX20 As DevComponents.DotNetBar.LabelX
    Friend WithEvents codPropTb As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX21 As DevComponents.DotNetBar.LabelX
    Friend WithEvents DelBtn As DevComponents.DotNetBar.ButtonX
    Friend WithEvents ButtonX5 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents ButtonX7 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Button2 As Button
    Friend WithEvents btnPaste As DevComponents.DotNetBar.ButtonX
    Friend WithEvents ButtonX4 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Button3 As Button
    Friend WithEvents PrintDocumento As Printing.PrintDocument
    Friend WithEvents LabelX22 As DevComponents.DotNetBar.LabelX
    Friend WithEvents comenta2Tb As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents PrintPreviewDocumento As PrintPreviewDialog
    Friend WithEvents LabelX23 As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblDesde As System.Windows.Forms.Label
    Friend WithEvents fechaDesdePk As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblHasta As System.Windows.Forms.Label
    Friend WithEvents fechaHastaPk As System.Windows.Forms.DateTimePicker
    Friend WithEvents buscarFechaBtn As System.Windows.Forms.Button
    Friend WithEvents limpiarFechaBtn As System.Windows.Forms.Button
    Friend WithEvents lblReporte As System.Windows.Forms.Label
    Friend WithEvents chkUsarFechaR As System.Windows.Forms.CheckBox
    Friend WithEvents lblFechaDesdeR As System.Windows.Forms.Label
    Friend WithEvents fechaDesdeRPk As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblFechaHastaR As System.Windows.Forms.Label
    Friend WithEvents fechaHastaRPk As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblCodClienteR As System.Windows.Forms.Label
    Friend WithEvents codClienteRTb As System.Windows.Forms.TextBox
    Friend WithEvents lblPlacaR As System.Windows.Forms.Label
    Friend WithEvents placaRTb As System.Windows.Forms.TextBox
    Friend WithEvents lblBoletaR As System.Windows.Forms.Label
    Friend WithEvents boletaRTb As System.Windows.Forms.TextBox
    Friend WithEvents buscarRBtn As System.Windows.Forms.Button
    Friend WithEvents ordenarRBtn As System.Windows.Forms.Button
    Friend WithEvents exportarRBtn As System.Windows.Forms.Button
    Friend WithEvents limpiarRBtn As System.Windows.Forms.Button
    Friend WithEvents reporteDGV As System.Windows.Forms.DataGridView
    Friend WithEvents lblTotalR As System.Windows.Forms.Label
End Class
