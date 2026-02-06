<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class reporte
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
        Me.LblTitulo = New System.Windows.Forms.Label()
        Me.LblFechaDesde = New System.Windows.Forms.Label()
        Me.LblFechaHasta = New System.Windows.Forms.Label()
        Me.LblDespachador = New System.Windows.Forms.Label()
        Me.LblPeriodo = New System.Windows.Forms.Label()
        Me.LblSemana = New System.Windows.Forms.Label()
        Me.fechaDesdePk = New System.Windows.Forms.DateTimePicker()
        Me.fechaHastaPk = New System.Windows.Forms.DateTimePicker()
        Me.despachadorCb = New System.Windows.Forms.ComboBox()
        Me.periodoCb = New System.Windows.Forms.ComboBox()
        Me.semanaCb = New System.Windows.Forms.ComboBox()
        Me.buscarBtn = New DevComponents.DotNetBar.ButtonX()
        Me.exportarBtn = New DevComponents.DotNetBar.ButtonX()
        Me.limpiarBtn = New DevComponents.DotNetBar.ButtonX()
        Me.reporteDgv = New System.Windows.Forms.DataGridView()
        Me.LblTotal = New System.Windows.Forms.Label()
        Me.chkUsarFecha = New System.Windows.Forms.CheckBox()
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
        Me.PanelFiltros.Controls.Add(Me.LblDespachador)
        Me.PanelFiltros.Controls.Add(Me.LblPeriodo)
        Me.PanelFiltros.Controls.Add(Me.LblSemana)
        Me.PanelFiltros.Controls.Add(Me.fechaDesdePk)
        Me.PanelFiltros.Controls.Add(Me.fechaHastaPk)
        Me.PanelFiltros.Controls.Add(Me.despachadorCb)
        Me.PanelFiltros.Controls.Add(Me.periodoCb)
        Me.PanelFiltros.Controls.Add(Me.semanaCb)
        Me.PanelFiltros.Controls.Add(Me.buscarBtn)
        Me.PanelFiltros.Controls.Add(Me.exportarBtn)
        Me.PanelFiltros.Controls.Add(Me.limpiarBtn)
        Me.PanelFiltros.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelFiltros.Location = New System.Drawing.Point(0, 0)
        Me.PanelFiltros.Name = "PanelFiltros"
        Me.PanelFiltros.Size = New System.Drawing.Size(1132, 120)
        Me.PanelFiltros.TabIndex = 0
        '
        'LblTitulo
        '
        Me.LblTitulo.AutoSize = True
        Me.LblTitulo.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold)
        Me.LblTitulo.ForeColor = System.Drawing.Color.White
        Me.LblTitulo.Location = New System.Drawing.Point(12, 9)
        Me.LblTitulo.Name = "LblTitulo"
        Me.LblTitulo.Size = New System.Drawing.Size(252, 25)
        Me.LblTitulo.TabIndex = 0
        Me.LblTitulo.Text = "Reporte de Comprobantes"
        '
        'chkUsarFecha
        '
        Me.chkUsarFecha.AutoSize = True
        Me.chkUsarFecha.ForeColor = System.Drawing.Color.White
        Me.chkUsarFecha.Location = New System.Drawing.Point(17, 45)
        Me.chkUsarFecha.Name = "chkUsarFecha"
        Me.chkUsarFecha.Size = New System.Drawing.Size(104, 17)
        Me.chkUsarFecha.TabIndex = 1
        Me.chkUsarFecha.Text = "Filtrar por fecha"
        Me.chkUsarFecha.UseVisualStyleBackColor = True
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
        'fechaDesdePk
        '
        Me.fechaDesdePk.Format = System.Windows.Forms.DateTimePickerFormat.Short
        Me.fechaDesdePk.Location = New System.Drawing.Point(17, 86)
        Me.fechaDesdePk.Name = "fechaDesdePk"
        Me.fechaDesdePk.Size = New System.Drawing.Size(110, 20)
        Me.fechaDesdePk.TabIndex = 2
        Me.fechaDesdePk.Enabled = False
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
        'fechaHastaPk
        '
        Me.fechaHastaPk.Format = System.Windows.Forms.DateTimePickerFormat.Short
        Me.fechaHastaPk.Location = New System.Drawing.Point(140, 86)
        Me.fechaHastaPk.Name = "fechaHastaPk"
        Me.fechaHastaPk.Size = New System.Drawing.Size(110, 20)
        Me.fechaHastaPk.TabIndex = 4
        Me.fechaHastaPk.Enabled = False
        '
        'LblDespachador
        '
        Me.LblDespachador.AutoSize = True
        Me.LblDespachador.ForeColor = System.Drawing.Color.White
        Me.LblDespachador.Location = New System.Drawing.Point(270, 70)
        Me.LblDespachador.Name = "LblDespachador"
        Me.LblDespachador.Size = New System.Drawing.Size(71, 13)
        Me.LblDespachador.TabIndex = 5
        Me.LblDespachador.Text = "Despachador:"
        '
        'despachadorCb
        '
        Me.despachadorCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.despachadorCb.FormattingEnabled = True
        Me.despachadorCb.Location = New System.Drawing.Point(270, 86)
        Me.despachadorCb.Name = "despachadorCb"
        Me.despachadorCb.Size = New System.Drawing.Size(200, 21)
        Me.despachadorCb.TabIndex = 6
        '
        'LblPeriodo
        '
        Me.LblPeriodo.AutoSize = True
        Me.LblPeriodo.ForeColor = System.Drawing.Color.White
        Me.LblPeriodo.Location = New System.Drawing.Point(490, 70)
        Me.LblPeriodo.Name = "LblPeriodo"
        Me.LblPeriodo.Size = New System.Drawing.Size(46, 13)
        Me.LblPeriodo.TabIndex = 7
        Me.LblPeriodo.Text = "Periodo:"
        '
        'periodoCb
        '
        Me.periodoCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.periodoCb.FormattingEnabled = True
        Me.periodoCb.Location = New System.Drawing.Point(490, 86)
        Me.periodoCb.Name = "periodoCb"
        Me.periodoCb.Size = New System.Drawing.Size(80, 21)
        Me.periodoCb.TabIndex = 8
        '
        'LblSemana
        '
        Me.LblSemana.AutoSize = True
        Me.LblSemana.ForeColor = System.Drawing.Color.White
        Me.LblSemana.Location = New System.Drawing.Point(590, 70)
        Me.LblSemana.Name = "LblSemana"
        Me.LblSemana.Size = New System.Drawing.Size(52, 13)
        Me.LblSemana.TabIndex = 9
        Me.LblSemana.Text = "Semana:"
        '
        'semanaCb
        '
        Me.semanaCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.semanaCb.FormattingEnabled = True
        Me.semanaCb.Location = New System.Drawing.Point(590, 86)
        Me.semanaCb.Name = "semanaCb"
        Me.semanaCb.Size = New System.Drawing.Size(80, 21)
        Me.semanaCb.TabIndex = 10
        '
        'buscarBtn
        '
        Me.buscarBtn.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.buscarBtn.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.buscarBtn.Location = New System.Drawing.Point(700, 70)
        Me.buscarBtn.Name = "buscarBtn"
        Me.buscarBtn.Size = New System.Drawing.Size(100, 36)
        Me.buscarBtn.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.buscarBtn.Symbol = ""
        Me.buscarBtn.SymbolSize = 12.0!
        Me.buscarBtn.TabIndex = 11
        Me.buscarBtn.Text = "Buscar"
        '
        'exportarBtn
        '
        Me.exportarBtn.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.exportarBtn.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.exportarBtn.Location = New System.Drawing.Point(810, 70)
        Me.exportarBtn.Name = "exportarBtn"
        Me.exportarBtn.Size = New System.Drawing.Size(120, 36)
        Me.exportarBtn.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.exportarBtn.Symbol = ""
        Me.exportarBtn.SymbolColor = System.Drawing.Color.Green
        Me.exportarBtn.SymbolSize = 12.0!
        Me.exportarBtn.TabIndex = 12
        Me.exportarBtn.Text = "Exportar Excel"
        '
        'limpiarBtn
        '
        Me.limpiarBtn.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.limpiarBtn.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.limpiarBtn.Location = New System.Drawing.Point(940, 70)
        Me.limpiarBtn.Name = "limpiarBtn"
        Me.limpiarBtn.Size = New System.Drawing.Size(100, 36)
        Me.limpiarBtn.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.limpiarBtn.Symbol = ""
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
        Me.reporteDgv.Size = New System.Drawing.Size(1108, 450)
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
        Me.LblTotal.Size = New System.Drawing.Size(116, 19)
        Me.LblTotal.TabIndex = 15
        Me.LblTotal.Text = "Total registros: 0"
        '
        'reporte
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.SteelBlue
        Me.ClientSize = New System.Drawing.Size(1132, 620)
        Me.Controls.Add(Me.LblTotal)
        Me.Controls.Add(Me.reporteDgv)
        Me.Controls.Add(Me.PanelFiltros)
        Me.Name = "reporte"
        Me.Text = "Reporte de Comprobantes"
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
    Friend WithEvents LblDespachador As Label
    Friend WithEvents LblPeriodo As Label
    Friend WithEvents LblSemana As Label
    Friend WithEvents fechaDesdePk As DateTimePicker
    Friend WithEvents fechaHastaPk As DateTimePicker
    Friend WithEvents despachadorCb As ComboBox
    Friend WithEvents periodoCb As ComboBox
    Friend WithEvents semanaCb As ComboBox
    Friend WithEvents buscarBtn As DevComponents.DotNetBar.ButtonX
    Friend WithEvents exportarBtn As DevComponents.DotNetBar.ButtonX
    Friend WithEvents limpiarBtn As DevComponents.DotNetBar.ButtonX
    Friend WithEvents reporteDgv As DataGridView
    Friend WithEvents LblTotal As Label
    Friend WithEvents chkUsarFecha As CheckBox
End Class
