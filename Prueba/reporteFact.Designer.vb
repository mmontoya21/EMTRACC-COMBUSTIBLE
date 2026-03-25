<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class reporteFact
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
        Me.PanelFiltros = New System.Windows.Forms.Panel()
        Me.chkUsarFecha = New System.Windows.Forms.CheckBox()
        Me.LblTitulo = New System.Windows.Forms.Label()
        Me.LblFechaDesde = New System.Windows.Forms.Label()
        Me.LblFechaHasta = New System.Windows.Forms.Label()
        Me.LblCodCliente = New System.Windows.Forms.Label()
        Me.LblPlaca = New System.Windows.Forms.Label()
        Me.LblBoleta = New System.Windows.Forms.Label()
        Me.fechaDesdePk = New System.Windows.Forms.DateTimePicker()
        Me.fechaHastaPk = New System.Windows.Forms.DateTimePicker()
        Me.codClienteTb = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.placaTb = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.boletaTb = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.buscarBtn = New DevComponents.DotNetBar.ButtonX()
        Me.ordenarBtn = New DevComponents.DotNetBar.ButtonX()
        Me.exportarBtn = New DevComponents.DotNetBar.ButtonX()
        Me.limpiarBtn = New DevComponents.DotNetBar.ButtonX()
        Me.reporteDgv = New System.Windows.Forms.DataGridView()
        Me.LblTotal = New System.Windows.Forms.Label()
        Me.lblOdometro = New System.Windows.Forms.Label()
        Me.PanelFiltros.SuspendLayout()
        CType(Me.reporteDgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelFiltros
        '
        Me.PanelFiltros.BackColor = System.Drawing.Color.FromArgb(CType(CType(106, Byte), Integer), CType(CType(126, Byte), Integer), CType(CType(168, Byte), Integer))
        Me.PanelFiltros.Controls.Add(Me.chkUsarFecha)
        Me.PanelFiltros.Controls.Add(Me.LblTitulo)
        Me.PanelFiltros.Controls.Add(Me.LblFechaDesde)
        Me.PanelFiltros.Controls.Add(Me.LblFechaHasta)
        Me.PanelFiltros.Controls.Add(Me.LblCodCliente)
        Me.PanelFiltros.Controls.Add(Me.LblPlaca)
        Me.PanelFiltros.Controls.Add(Me.LblBoleta)
        Me.PanelFiltros.Controls.Add(Me.fechaDesdePk)
        Me.PanelFiltros.Controls.Add(Me.fechaHastaPk)
        Me.PanelFiltros.Controls.Add(Me.codClienteTb)
        Me.PanelFiltros.Controls.Add(Me.placaTb)
        Me.PanelFiltros.Controls.Add(Me.boletaTb)
        Me.PanelFiltros.Controls.Add(Me.buscarBtn)
        Me.PanelFiltros.Controls.Add(Me.ordenarBtn)
        Me.PanelFiltros.Controls.Add(Me.exportarBtn)
        Me.PanelFiltros.Controls.Add(Me.limpiarBtn)
        Me.PanelFiltros.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelFiltros.Location = New System.Drawing.Point(0, 0)
        Me.PanelFiltros.Name = "PanelFiltros"
        Me.PanelFiltros.Size = New System.Drawing.Size(1203, 120)
        Me.PanelFiltros.TabIndex = 0
        '
        'chkUsarFecha
        '
        Me.chkUsarFecha.AutoSize = True
        Me.chkUsarFecha.ForeColor = System.Drawing.Color.White
        Me.chkUsarFecha.Location = New System.Drawing.Point(17, 45)
        Me.chkUsarFecha.Name = "chkUsarFecha"
        Me.chkUsarFecha.Size = New System.Drawing.Size(99, 17)
        Me.chkUsarFecha.TabIndex = 1
        Me.chkUsarFecha.Text = "Filtrar por fecha"
        Me.chkUsarFecha.UseVisualStyleBackColor = True
        '
        'LblTitulo
        '
        Me.LblTitulo.AutoSize = True
        Me.LblTitulo.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold)
        Me.LblTitulo.ForeColor = System.Drawing.Color.White
        Me.LblTitulo.Location = New System.Drawing.Point(12, 9)
        Me.LblTitulo.Name = "LblTitulo"
        Me.LblTitulo.Size = New System.Drawing.Size(189, 25)
        Me.LblTitulo.TabIndex = 0
        Me.LblTitulo.Text = "Reporte de Facturas"
        '
        'LblFechaDesde
        '
        Me.LblFechaDesde.AutoSize = True
        Me.LblFechaDesde.ForeColor = System.Drawing.Color.White
        Me.LblFechaDesde.Location = New System.Drawing.Point(17, 70)
        Me.LblFechaDesde.Name = "LblFechaDesde"
        Me.LblFechaDesde.Size = New System.Drawing.Size(41, 13)
        Me.LblFechaDesde.TabIndex = 1
        Me.LblFechaDesde.Text = "Desde:"
        '
        'LblFechaHasta
        '
        Me.LblFechaHasta.AutoSize = True
        Me.LblFechaHasta.ForeColor = System.Drawing.Color.White
        Me.LblFechaHasta.Location = New System.Drawing.Point(140, 70)
        Me.LblFechaHasta.Name = "LblFechaHasta"
        Me.LblFechaHasta.Size = New System.Drawing.Size(38, 13)
        Me.LblFechaHasta.TabIndex = 3
        Me.LblFechaHasta.Text = "Hasta:"
        '
        'LblCodCliente
        '
        Me.LblCodCliente.AutoSize = True
        Me.LblCodCliente.ForeColor = System.Drawing.Color.White
        Me.LblCodCliente.Location = New System.Drawing.Point(270, 70)
        Me.LblCodCliente.Name = "LblCodCliente"
        Me.LblCodCliente.Size = New System.Drawing.Size(67, 13)
        Me.LblCodCliente.TabIndex = 5
        Me.LblCodCliente.Text = "Cod. Cliente:"
        '
        'LblPlaca
        '
        Me.LblPlaca.AutoSize = True
        Me.LblPlaca.ForeColor = System.Drawing.Color.White
        Me.LblPlaca.Location = New System.Drawing.Point(410, 70)
        Me.LblPlaca.Name = "LblPlaca"
        Me.LblPlaca.Size = New System.Drawing.Size(37, 13)
        Me.LblPlaca.TabIndex = 7
        Me.LblPlaca.Text = "Placa:"
        '
        'LblBoleta
        '
        Me.LblBoleta.AutoSize = True
        Me.LblBoleta.ForeColor = System.Drawing.Color.White
        Me.LblBoleta.Location = New System.Drawing.Point(550, 70)
        Me.LblBoleta.Name = "LblBoleta"
        Me.LblBoleta.Size = New System.Drawing.Size(40, 13)
        Me.LblBoleta.TabIndex = 9
        Me.LblBoleta.Text = "Boleta:"
        '
        'fechaDesdePk
        '
        Me.fechaDesdePk.Enabled = False
        Me.fechaDesdePk.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.fechaDesdePk.Location = New System.Drawing.Point(17, 86)
        Me.fechaDesdePk.Name = "fechaDesdePk"
        Me.fechaDesdePk.Size = New System.Drawing.Size(110, 20)
        Me.fechaDesdePk.TabIndex = 2
        '
        'fechaHastaPk
        '
        Me.fechaHastaPk.Enabled = False
        Me.fechaHastaPk.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.fechaHastaPk.Location = New System.Drawing.Point(140, 86)
        Me.fechaHastaPk.Name = "fechaHastaPk"
        Me.fechaHastaPk.Size = New System.Drawing.Size(110, 20)
        Me.fechaHastaPk.TabIndex = 4
        '
        'codClienteTb
        '
        Me.codClienteTb.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.codClienteTb.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.codClienteTb.Location = New System.Drawing.Point(270, 86)
        Me.codClienteTb.Name = "codClienteTb"
        Me.codClienteTb.Size = New System.Drawing.Size(120, 21)
        Me.codClienteTb.TabIndex = 6
        '
        'placaTb
        '
        Me.placaTb.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.placaTb.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.placaTb.Location = New System.Drawing.Point(410, 86)
        Me.placaTb.Name = "placaTb"
        Me.placaTb.Size = New System.Drawing.Size(120, 21)
        Me.placaTb.TabIndex = 8
        '
        'boletaTb
        '
        Me.boletaTb.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.boletaTb.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.boletaTb.Location = New System.Drawing.Point(550, 86)
        Me.boletaTb.Name = "boletaTb"
        Me.boletaTb.Size = New System.Drawing.Size(120, 21)
        Me.boletaTb.TabIndex = 10
        '
        'buscarBtn
        '
        Me.buscarBtn.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.buscarBtn.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.buscarBtn.Location = New System.Drawing.Point(700, 70)
        Me.buscarBtn.Name = "buscarBtn"
        Me.buscarBtn.Size = New System.Drawing.Size(100, 36)
        Me.buscarBtn.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.buscarBtn.SymbolSize = 12.0!
        Me.buscarBtn.TabIndex = 11
        Me.buscarBtn.Text = "Buscar"
        '
        'ordenarBtn
        '
        Me.ordenarBtn.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ordenarBtn.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ordenarBtn.Location = New System.Drawing.Point(810, 70)
        Me.ordenarBtn.Name = "ordenarBtn"
        Me.ordenarBtn.Size = New System.Drawing.Size(100, 36)
        Me.ordenarBtn.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ordenarBtn.SymbolSize = 12.0!
        Me.ordenarBtn.TabIndex = 16
        Me.ordenarBtn.Text = "Ordenar"
        '
        'exportarBtn
        '
        Me.exportarBtn.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.exportarBtn.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.exportarBtn.Location = New System.Drawing.Point(920, 70)
        Me.exportarBtn.Name = "exportarBtn"
        Me.exportarBtn.Size = New System.Drawing.Size(120, 36)
        Me.exportarBtn.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.exportarBtn.SymbolColor = System.Drawing.Color.Green
        Me.exportarBtn.SymbolSize = 12.0!
        Me.exportarBtn.TabIndex = 12
        Me.exportarBtn.Text = "Exportar Excel"
        '
        'limpiarBtn
        '
        Me.limpiarBtn.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.limpiarBtn.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.limpiarBtn.Location = New System.Drawing.Point(1050, 70)
        Me.limpiarBtn.Name = "limpiarBtn"
        Me.limpiarBtn.Size = New System.Drawing.Size(100, 36)
        Me.limpiarBtn.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.limpiarBtn.SymbolSize = 12.0!
        Me.limpiarBtn.TabIndex = 13
        Me.limpiarBtn.Text = "Limpiar"
        '
        'reporteDgv
        '
        Me.reporteDgv.AllowUserToAddRows = False
        Me.reporteDgv.AllowUserToDeleteRows = False
        Me.reporteDgv.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.reporteDgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.reporteDgv.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(106, Byte), Integer), CType(CType(126, Byte), Integer), CType(CType(168, Byte), Integer))
        Me.reporteDgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.reporteDgv.Location = New System.Drawing.Point(12, 126)
        Me.reporteDgv.Name = "reporteDgv"
        Me.reporteDgv.ReadOnly = True
        Me.reporteDgv.RowHeadersVisible = False
        Me.reporteDgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.reporteDgv.Size = New System.Drawing.Size(1179, 450)
        Me.reporteDgv.TabIndex = 14
        '
        'LblTotal
        '
        Me.LblTotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.LblTotal.AutoSize = True
        Me.LblTotal.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.LblTotal.ForeColor = System.Drawing.Color.White
        Me.LblTotal.Location = New System.Drawing.Point(12, 585)
        Me.LblTotal.Name = "LblTotal"
        Me.LblTotal.Size = New System.Drawing.Size(121, 19)
        Me.LblTotal.TabIndex = 15
        Me.LblTotal.Text = "Total registros: 0"
        '
        'lblOdometro
        '
        Me.lblOdometro.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblOdometro.AutoSize = True
        Me.lblOdometro.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblOdometro.ForeColor = System.Drawing.Color.FromArgb(80, 255, 160)
        Me.lblOdometro.Location = New System.Drawing.Point(12, 607)
        Me.lblOdometro.Name = "lblOdometro"
        Me.lblOdometro.Size = New System.Drawing.Size(10, 15)
        Me.lblOdometro.TabIndex = 16
        '
        'reporteFact
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.SteelBlue
        Me.ClientSize = New System.Drawing.Size(1203, 620)
        Me.Controls.Add(Me.lblOdometro)
        Me.Controls.Add(Me.LblTotal)
        Me.Controls.Add(Me.reporteDgv)
        Me.Controls.Add(Me.PanelFiltros)
        Me.Name = "reporteFact"
        Me.Text = "Reporte de Facturas"
        Me.PanelFiltros.ResumeLayout(False)
        Me.PanelFiltros.PerformLayout()
        CType(Me.reporteDgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents PanelFiltros As Panel
    Friend WithEvents LblTitulo As Label
    Friend WithEvents LblFechaDesde As Label
    Friend WithEvents LblFechaHasta As Label
    Friend WithEvents LblCodCliente As Label
    Friend WithEvents LblPlaca As Label
    Friend WithEvents LblBoleta As Label
    Friend WithEvents fechaDesdePk As DateTimePicker
    Friend WithEvents fechaHastaPk As DateTimePicker
    Friend WithEvents codClienteTb As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents placaTb As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents boletaTb As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents buscarBtn As DevComponents.DotNetBar.ButtonX
    Friend WithEvents ordenarBtn As DevComponents.DotNetBar.ButtonX
    Friend WithEvents exportarBtn As DevComponents.DotNetBar.ButtonX
    Friend WithEvents limpiarBtn As DevComponents.DotNetBar.ButtonX
    Friend WithEvents reporteDgv As DataGridView
    Friend WithEvents LblTotal As Label
    Friend WithEvents lblOdometro As Label
    Friend WithEvents chkUsarFecha As CheckBox
End Class
