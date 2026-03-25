<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class comprobantePlus
    Inherits System.Windows.Forms.Form

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

    Private components As System.ComponentModel.IContainer

    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(comprobantePlus))

        ' ========== CONTROLES ==========
        Me.ToolbarPanel = New System.Windows.Forms.Panel()
        Me.NuevoBtn = New DevComponents.DotNetBar.ButtonX()
        Me.EditarBtn = New DevComponents.DotNetBar.ButtonX()
        Me.GuardarBtn = New DevComponents.DotNetBar.ButtonX()
        Me.ModificarBtn = New DevComponents.DotNetBar.ButtonX()
        Me.EliminarBtn = New DevComponents.DotNetBar.ButtonX()
        Me.CancelarBtn = New DevComponents.DotNetBar.ButtonX()
        Me.AnularBtn = New DevComponents.DotNetBar.ButtonX()
        Me.lblNivelTanque = New DevComponents.DotNetBar.LabelX()
        Me.LabelX23 = New DevComponents.DotNetBar.LabelX()
        Me.nComproTb = New DevComponents.DotNetBar.Controls.TextBoxX()

        Me.PanelP = New System.Windows.Forms.Panel()
        Me.panelDatosIzq = New System.Windows.Forms.Panel()
        Me.panelDatosDer = New System.Windows.Forms.Panel()

        Me.galDespTb = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.valorTb = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.nBoletaTb = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.fechaPkd = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.placaCbzTb = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.codiPropTb = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.propCbzTb = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.nConteTb = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.rutaTb = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.nombDespTb = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.nombCondTb = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.periodoTb = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.semanaTb = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.proxSemTb = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.placaCbzTb2 = New DevComponents.DotNetBar.ListBoxAdv()
        Me.pLetras = New DevComponents.DotNetBar.LabelX()
        Me.totVtalb = New DevComponents.DotNetBar.LabelX()
        Me.buscartxt = New DevComponents.DotNetBar.LabelX()

        Me.LabelGalDesp = New System.Windows.Forms.Label()
        Me.LabelValor = New System.Windows.Forms.Label()
        Me.LabelBoleta = New System.Windows.Forms.Label()
        Me.LabelFecha = New System.Windows.Forms.Label()
        Me.LabelPlaca = New System.Windows.Forms.Label()
        Me.LabelCodProp = New System.Windows.Forms.Label()
        Me.LabelPropietario = New System.Windows.Forms.Label()
        Me.LabelContenedor = New System.Windows.Forms.Label()
        Me.LabelRuta = New System.Windows.Forms.Label()
        Me.LabelDespachador = New System.Windows.Forms.Label()
        Me.LabelConductor = New System.Windows.Forms.Label()
        Me.LabelPeriodo = New System.Windows.Forms.Label()
        Me.LabelSemana = New System.Windows.Forms.Label()
        Me.LabelProxSem = New System.Windows.Forms.Label()
        Me.LabelLetras = New System.Windows.Forms.Label()

        Me.ComboItem1 = New DevComponents.Editors.ComboItem()
        Me.ComboItem2 = New DevComponents.Editors.ComboItem()
        Me.ComboItem3 = New DevComponents.Editors.ComboItem()
        Me.ComboItem4 = New DevComponents.Editors.ComboItem()
        Me.ComboItem5 = New DevComponents.Editors.ComboItem()
        Me.ComboItem6 = New DevComponents.Editors.ComboItem()
        Me.ComboItem7 = New DevComponents.Editors.ComboItem()
        Me.ComboItem8 = New DevComponents.Editors.ComboItem()
        Me.ComboItem9 = New DevComponents.Editors.ComboItem()
        Me.ComboItem10 = New DevComponents.Editors.ComboItem()
        Me.ComboItem11 = New DevComponents.Editors.ComboItem()
        Me.ComboItem12 = New DevComponents.Editors.ComboItem()
        Me.ComboItem13 = New DevComponents.Editors.ComboItem()
        Me.S1 = New DevComponents.Editors.ComboItem()
        Me.S2 = New DevComponents.Editors.ComboItem()
        Me.S3 = New DevComponents.Editors.ComboItem()
        Me.S4 = New DevComponents.Editors.ComboItem()
        Me.S5 = New DevComponents.Editors.ComboItem()
        Me.Si = New DevComponents.Editors.ComboItem()
        Me.No = New DevComponents.Editors.ComboItem()

        Me.FilterPanel = New System.Windows.Forms.Panel()
        Me.LabelX14 = New System.Windows.Forms.Label()
        Me.placaBusqTB = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX9 = New System.Windows.Forms.Label()
        Me.boletBusqTB = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.chkUsarFecha = New System.Windows.Forms.CheckBox()
        Me.LabelFechaDesde = New System.Windows.Forms.Label()
        Me.fechaDesdePk = New System.Windows.Forms.DateTimePicker()
        Me.LabelFechaHasta = New System.Windows.Forms.Label()
        Me.fechaHastaPk = New System.Windows.Forms.DateTimePicker()
        Me.LabelDesp = New System.Windows.Forms.Label()
        Me.despachadorCb = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.buscarBtn = New DevComponents.DotNetBar.ButtonX()
        Me.ButtonX6 = New DevComponents.DotNetBar.ButtonX()
        Me.lblTotales = New DevComponents.DotNetBar.LabelX()

        Me.CamDGV = New System.Windows.Forms.DataGridView()

        Me.PrintPanel = New System.Windows.Forms.Panel()
        Me.ImprimirBt = New DevComponents.DotNetBar.ButtonX()
        Me.PreviaBtn = New DevComponents.DotNetBar.ButtonX()
        Me.ImprimirBt2 = New DevComponents.DotNetBar.ButtonX()
        Me.PreviaBtn2 = New DevComponents.DotNetBar.ButtonX()

        Me.PrintComprobante = New System.Drawing.Printing.PrintDocument()
        Me.PrintPreviewComprobante = New System.Windows.Forms.PrintPreviewDialog()
        Me.PrintDocumento = New System.Drawing.Printing.PrintDocument()
        Me.PrintPreviewDocumento = New System.Windows.Forms.PrintPreviewDialog()
        Me.BalloonTip1 = New DevComponents.DotNetBar.BalloonTip()

        CType(Me.CamDGV, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.fechaPkd, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolbarPanel.SuspendLayout()
        Me.PanelP.SuspendLayout()
        Me.panelDatosIzq.SuspendLayout()
        Me.panelDatosDer.SuspendLayout()
        Me.FilterPanel.SuspendLayout()
        Me.PrintPanel.SuspendLayout()
        Me.SuspendLayout()

        ' =====================================================
        ' COLOR PALETTE
        ' =====================================================
        Dim bgDark As Color = Color.FromArgb(24, 32, 50)
        Dim bgPanel As Color = Color.FromArgb(30, 42, 66)
        Dim bgInput As Color = Color.FromArgb(40, 55, 82)
        Dim borderClr As Color = Color.FromArgb(60, 80, 120)
        Dim accentBlue As Color = Color.FromArgb(70, 130, 220)
        Dim txtWhite As Color = Color.White
        Dim txtLight As Color = Color.FromArgb(180, 200, 230)
        Dim txtGold As Color = Color.FromArgb(255, 215, 80)
        Dim fontLabel As Font = New Font("Segoe UI", 9.0!, FontStyle.Regular)
        Dim fontInput As Font = New Font("Segoe UI Semibold", 11.0!, FontStyle.Bold)
        Dim fontInputSm As Font = New Font("Segoe UI Semibold", 10.0!, FontStyle.Bold)
        Dim fontBtn As Font = New Font("Segoe UI Semibold", 9.75!, FontStyle.Bold)
        Dim fontPlaca As Font = New Font("Segoe UI", 18.0!, FontStyle.Bold)

        ' =====================================================
        ' TOOLBAR PANEL (top bar with buttons)
        ' =====================================================
        Me.ToolbarPanel.BackColor = Color.FromArgb(18, 26, 42)
        Me.ToolbarPanel.Dock = DockStyle.Top
        Me.ToolbarPanel.Height = 50
        Me.ToolbarPanel.Padding = New Padding(8, 8, 8, 8)
        Me.ToolbarPanel.Controls.AddRange(New Control() {Me.NuevoBtn, Me.EditarBtn, Me.GuardarBtn, Me.ModificarBtn, Me.EliminarBtn, Me.CancelarBtn, Me.AnularBtn, Me.lblNivelTanque, Me.LabelX23, Me.nComproTb})

        ' -- Buttons --
        Dim btnY As Integer = 8
        Dim btnH As Integer = 34
        Dim btnW As Integer = 90

        Me.NuevoBtn.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.NuevoBtn.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.NuevoBtn.Font = fontBtn
        Me.NuevoBtn.Location = New Point(10, btnY)
        Me.NuevoBtn.Size = New Size(btnW, btnH)
        Me.NuevoBtn.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.NuevoBtn.Symbol = ChrW(&HF067)
        Me.NuevoBtn.SymbolSize = 11.0!
        Me.NuevoBtn.TabIndex = 0
        Me.NuevoBtn.Text = " Nuevo"
        Me.NuevoBtn.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor(6)

        Me.EditarBtn.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.EditarBtn.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.EditarBtn.Font = fontBtn
        Me.EditarBtn.Location = New Point(106, btnY)
        Me.EditarBtn.Size = New Size(btnW, btnH)
        Me.EditarBtn.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.EditarBtn.Symbol = ChrW(&HF044)
        Me.EditarBtn.SymbolSize = 11.0!
        Me.EditarBtn.TabIndex = 1
        Me.EditarBtn.Text = " Editar"
        Me.EditarBtn.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor(6)

        Me.GuardarBtn.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.GuardarBtn.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.GuardarBtn.Font = fontBtn
        Me.GuardarBtn.Location = New Point(202, btnY)
        Me.GuardarBtn.Size = New Size(btnW + 10, btnH)
        Me.GuardarBtn.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.GuardarBtn.Symbol = ChrW(&HF0C7)
        Me.GuardarBtn.SymbolColor = Color.FromArgb(80, 200, 120)
        Me.GuardarBtn.SymbolSize = 11.0!
        Me.GuardarBtn.TabIndex = 2
        Me.GuardarBtn.Text = " Guardar"
        Me.GuardarBtn.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor(6)

        Me.ModificarBtn.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ModificarBtn.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ModificarBtn.Font = fontBtn
        Me.ModificarBtn.Location = New Point(202, btnY)
        Me.ModificarBtn.Size = New Size(btnW + 10, btnH)
        Me.ModificarBtn.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ModificarBtn.Symbol = ChrW(&HF00C)
        Me.ModificarBtn.SymbolSize = 11.0!
        Me.ModificarBtn.TabIndex = 3
        Me.ModificarBtn.Text = " Modificar"
        Me.ModificarBtn.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor(6)

        Me.EliminarBtn.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.EliminarBtn.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.EliminarBtn.Font = fontBtn
        Me.EliminarBtn.Location = New Point(318, btnY)
        Me.EliminarBtn.Size = New Size(btnW, btnH)
        Me.EliminarBtn.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.EliminarBtn.Symbol = ChrW(&HF1F8)
        Me.EliminarBtn.SymbolColor = Color.FromArgb(220, 80, 80)
        Me.EliminarBtn.SymbolSize = 11.0!
        Me.EliminarBtn.TabIndex = 4
        Me.EliminarBtn.Text = " Eliminar"
        Me.EliminarBtn.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor(6)

        Me.CancelarBtn.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.CancelarBtn.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.CancelarBtn.Font = fontBtn
        Me.CancelarBtn.Location = New Point(414, btnY)
        Me.CancelarBtn.Size = New Size(btnW, btnH)
        Me.CancelarBtn.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.CancelarBtn.Symbol = ChrW(&HF00D)
        Me.CancelarBtn.SymbolSize = 11.0!
        Me.CancelarBtn.TabIndex = 5
        Me.CancelarBtn.Text = " Cancelar"
        Me.CancelarBtn.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor(6)

        Me.AnularBtn.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.AnularBtn.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.AnularBtn.Font = fontBtn
        Me.AnularBtn.Location = New Point(510, btnY)
        Me.AnularBtn.Size = New Size(btnW, btnH)
        Me.AnularBtn.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.AnularBtn.SymbolColor = Color.FromArgb(200, 60, 60)
        Me.AnularBtn.SymbolSize = 11.0!
        Me.AnularBtn.TabIndex = 6
        Me.AnularBtn.Text = "Anular"
        Me.AnularBtn.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor(6)

        ' Nivel tanque label (right side of toolbar)
        Me.lblNivelTanque.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblNivelTanque.Font = New Font("Segoe UI", 11.0!, FontStyle.Bold)
        Me.lblNivelTanque.ForeColor = Color.LightGreen
        Me.lblNivelTanque.Location = New Point(620, 12)
        Me.lblNivelTanque.Name = "lblNivelTanque"
        Me.lblNivelTanque.AutoSize = True
        Me.lblNivelTanque.Anchor = AnchorStyles.Top Or AnchorStyles.Left
        Me.lblNivelTanque.TabIndex = 65
        Me.lblNivelTanque.Text = "Tanque: -- gal"

        ' Comprobante N label + textbox (right side of toolbar)
        Me.LabelX23.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX23.Font = New Font("Segoe UI", 11.0!, FontStyle.Bold)
        Me.LabelX23.ForeColor = txtGold
        Me.LabelX23.Location = New Point(830, 14)
        Me.LabelX23.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        Me.LabelX23.AutoSize = True
        Me.LabelX23.Text = "Comprobante N:"

        Me.nComproTb.BackColor = bgInput
        Me.nComproTb.Border.BackColor = bgInput
        Me.nComproTb.Border.BackColor2 = bgInput
        Me.nComproTb.Border.BorderBottomWidth = 2
        Me.nComproTb.Border.BorderColor = accentBlue
        Me.nComproTb.Border.BorderLeftWidth = 2
        Me.nComproTb.Border.BorderRightWidth = 2
        Me.nComproTb.Border.BorderTopWidth = 2
        Me.nComproTb.Border.Class = "TextBoxBorder"
        Me.nComproTb.Border.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.nComproTb.FocusHighlightColor = Color.FromArgb(60, 90, 140)
        Me.nComproTb.FocusHighlightEnabled = True
        Me.nComproTb.Font = New Font("Segoe UI", 12.0!, FontStyle.Bold)
        Me.nComproTb.ForeColor = txtGold
        Me.nComproTb.Location = New Point(972, 9)
        Me.nComproTb.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        Me.nComproTb.MaxLength = 10
        Me.nComproTb.Name = "nComproTb"
        Me.nComproTb.PreventEnterBeep = True
        Me.nComproTb.Size = New Size(150, 32)
        Me.nComproTb.TabIndex = 7

        ' =====================================================
        ' MAIN DATA PANEL (PanelP) - split into left/right
        ' =====================================================
        Me.PanelP.BackColor = bgPanel
        Me.PanelP.Dock = DockStyle.Top
        Me.PanelP.Height = 260
        Me.PanelP.Padding = New Padding(10, 6, 10, 6)
        Me.PanelP.Controls.AddRange(New Control() {Me.panelDatosIzq, Me.panelDatosDer})

        ' ---- LEFT PANEL: Despacho data ----
        Me.panelDatosIzq.BackColor = Color.Transparent
        Me.panelDatosIzq.Dock = DockStyle.Left
        Me.panelDatosIzq.Width = 530
        Me.panelDatosIzq.Padding = New Padding(4)

        ' Row 1: Gas despachado | Valor | Boleta | Fecha
        Me.LabelGalDesp.Text = "Gas Despachado"
        Me.LabelGalDesp.ForeColor = txtLight
        Me.LabelGalDesp.Font = fontLabel
        Me.LabelGalDesp.Location = New Point(6, 4)
        Me.LabelGalDesp.AutoSize = True

        Me.galDespTb.AcceptsTab = True
        Me.galDespTb.BackColor = bgInput
        Me.galDespTb.Border.BackColor = bgInput
        Me.galDespTb.Border.BackColor2 = bgInput
        Me.galDespTb.Border.BorderBottomWidth = 2
        Me.galDespTb.Border.BorderColor = borderClr
        Me.galDespTb.Border.BorderLeftWidth = 1
        Me.galDespTb.Border.BorderRightWidth = 1
        Me.galDespTb.Border.BorderTopWidth = 1
        Me.galDespTb.Border.Class = "TextBoxBorder"
        Me.galDespTb.Border.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.galDespTb.FocusHighlightColor = Color.FromArgb(50, 80, 130)
        Me.galDespTb.FocusHighlightEnabled = True
        Me.galDespTb.Font = fontInput
        Me.galDespTb.ForeColor = txtWhite
        Me.galDespTb.Location = New Point(6, 22)
        Me.galDespTb.MaxLength = 25
        Me.galDespTb.Name = "galDespTb"
        Me.galDespTb.PreventEnterBeep = True
        Me.galDespTb.Size = New Size(130, 30)
        Me.galDespTb.TabIndex = 1

        Me.LabelValor.Text = "Valor"
        Me.LabelValor.ForeColor = txtLight
        Me.LabelValor.Font = fontLabel
        Me.LabelValor.Location = New Point(142, 4)
        Me.LabelValor.AutoSize = True

        Me.valorTb.AcceptsTab = True
        Me.valorTb.BackColor = bgInput
        Me.valorTb.Border.BackColor = bgInput
        Me.valorTb.Border.BackColor2 = bgInput
        Me.valorTb.Border.BorderBottomWidth = 2
        Me.valorTb.Border.BorderColor = borderClr
        Me.valorTb.Border.BorderLeftWidth = 1
        Me.valorTb.Border.BorderRightWidth = 1
        Me.valorTb.Border.BorderTopWidth = 1
        Me.valorTb.Border.Class = "TextBoxBorder"
        Me.valorTb.Border.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.valorTb.FocusHighlightColor = Color.FromArgb(50, 80, 130)
        Me.valorTb.FocusHighlightEnabled = True
        Me.valorTb.Font = fontInput
        Me.valorTb.ForeColor = txtWhite
        Me.valorTb.Location = New Point(142, 22)
        Me.valorTb.MaxLength = 25
        Me.valorTb.Name = "valorTb"
        Me.valorTb.PreventEnterBeep = True
        Me.valorTb.Size = New Size(110, 30)
        Me.valorTb.TabIndex = 2

        Me.LabelFecha.Text = "Fecha"
        Me.LabelFecha.ForeColor = txtLight
        Me.LabelFecha.Font = fontLabel
        Me.LabelFecha.Location = New Point(370, 4)
        Me.LabelFecha.AutoSize = True

        Me.fechaPkd.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.fechaPkd.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.fechaPkd.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.fechaPkd.ButtonDropDown.Visible = True
        Me.fechaPkd.Font = New Font("Segoe UI", 11.0!, FontStyle.Regular)
        Me.fechaPkd.IsPopupCalendarOpen = False
        Me.fechaPkd.Location = New Point(370, 22)
        Me.fechaPkd.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.fechaPkd.MonthCalendar.CalendarDimensions = New Size(1, 1)
        Me.fechaPkd.MonthCalendar.ClearButtonVisible = True
        Me.fechaPkd.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.fechaPkd.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.fechaPkd.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.fechaPkd.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.fechaPkd.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.fechaPkd.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.fechaPkd.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.fechaPkd.MonthCalendar.DisplayMonth = New Date(2025, 8, 1, 0, 0, 0, 0)
        Me.fechaPkd.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.fechaPkd.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.fechaPkd.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.fechaPkd.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.fechaPkd.MonthCalendar.TodayButtonVisible = True
        Me.fechaPkd.Name = "fechaPkd"
        Me.fechaPkd.Size = New Size(148, 28)
        Me.fechaPkd.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.fechaPkd.TabIndex = 3

        Me.LabelBoleta.Text = "N Boleta"
        Me.LabelBoleta.ForeColor = txtLight
        Me.LabelBoleta.Font = fontLabel
        Me.LabelBoleta.Location = New Point(258, 4)
        Me.LabelBoleta.AutoSize = True

        Me.nBoletaTb.AcceptsTab = True
        Me.nBoletaTb.BackColor = bgInput
        Me.nBoletaTb.Border.BackColor = bgInput
        Me.nBoletaTb.Border.BackColor2 = bgInput
        Me.nBoletaTb.Border.BorderBottomWidth = 2
        Me.nBoletaTb.Border.BorderColor = borderClr
        Me.nBoletaTb.Border.BorderLeftWidth = 1
        Me.nBoletaTb.Border.BorderRightWidth = 1
        Me.nBoletaTb.Border.BorderTopWidth = 1
        Me.nBoletaTb.Border.Class = "TextBoxBorder"
        Me.nBoletaTb.Border.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.nBoletaTb.FocusHighlightColor = Color.FromArgb(50, 80, 130)
        Me.nBoletaTb.FocusHighlightEnabled = True
        Me.nBoletaTb.Font = fontInput
        Me.nBoletaTb.ForeColor = txtWhite
        Me.nBoletaTb.Location = New Point(258, 22)
        Me.nBoletaTb.MaxLength = 10
        Me.nBoletaTb.Name = "nBoletaTb"
        Me.nBoletaTb.PreventEnterBeep = True
        Me.nBoletaTb.Size = New Size(106, 30)
        Me.nBoletaTb.TabIndex = 4

        ' Row 2: Placa (big) | Cod. Propietario | Propietario | Contenedor
        Me.LabelPlaca.Text = "Placa Cabezal"
        Me.LabelPlaca.ForeColor = txtGold
        Me.LabelPlaca.Font = New Font("Segoe UI Semibold", 9.0!, FontStyle.Bold)
        Me.LabelPlaca.Location = New Point(6, 56)
        Me.LabelPlaca.AutoSize = True

        Me.placaCbzTb.AcceptsTab = True
        Me.placaCbzTb.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        Me.placaCbzTb.AutoCompleteSource = AutoCompleteSource.CustomSource
        Me.placaCbzTb.BackColor = bgInput
        Me.placaCbzTb.Border.BackColor = bgInput
        Me.placaCbzTb.Border.BackColor2 = bgInput
        Me.placaCbzTb.Border.BorderBottomWidth = 3
        Me.placaCbzTb.Border.BorderColor = txtGold
        Me.placaCbzTb.Border.BorderLeftWidth = 2
        Me.placaCbzTb.Border.BorderRightWidth = 2
        Me.placaCbzTb.Border.BorderTopWidth = 2
        Me.placaCbzTb.Border.Class = "TextBoxBorder"
        Me.placaCbzTb.Border.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.placaCbzTb.CharacterCasing = CharacterCasing.Upper
        Me.placaCbzTb.Font = fontPlaca
        Me.placaCbzTb.ForeColor = txtGold
        Me.placaCbzTb.Location = New Point(6, 74)
        Me.placaCbzTb.MaxLength = 25
        Me.placaCbzTb.Name = "placaCbzTb"
        Me.placaCbzTb.PreventEnterBeep = True
        Me.placaCbzTb.Size = New Size(170, 42)
        Me.placaCbzTb.TabIndex = 5
        Me.placaCbzTb.TextAlign = HorizontalAlignment.Center

        Me.placaCbzTb2.AutoScroll = True
        Me.placaCbzTb2.BackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarStripeColor
        Me.placaCbzTb2.BackgroundStyle.Class = "ListBoxAdv"
        Me.placaCbzTb2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.placaCbzTb2.CheckStateMember = Nothing
        Me.placaCbzTb2.ContainerControlProcessDialogKey = True
        Me.placaCbzTb2.DragDropSupport = True
        Me.placaCbzTb2.Font = New Font("Segoe UI", 12.0!, FontStyle.Bold)
        Me.placaCbzTb2.ItemSpacing = 2
        Me.placaCbzTb2.Location = New Point(6, 118)
        Me.placaCbzTb2.Name = "placaCbzTb2"
        Me.placaCbzTb2.Size = New Size(120, 90)
        Me.placaCbzTb2.TabIndex = 6

        Me.LabelCodProp.Text = "Cod. Propietario"
        Me.LabelCodProp.ForeColor = txtLight
        Me.LabelCodProp.Font = fontLabel
        Me.LabelCodProp.Location = New Point(182, 56)
        Me.LabelCodProp.AutoSize = True

        Me.codiPropTb.AcceptsTab = True
        Me.codiPropTb.BackColor = bgInput
        Me.codiPropTb.Border.BackColor = bgInput
        Me.codiPropTb.Border.BackColor2 = bgInput
        Me.codiPropTb.Border.BorderBottomWidth = 2
        Me.codiPropTb.Border.BorderColor = accentBlue
        Me.codiPropTb.Border.BorderLeftWidth = 1
        Me.codiPropTb.Border.BorderRightWidth = 1
        Me.codiPropTb.Border.BorderTopWidth = 1
        Me.codiPropTb.Border.Class = "TextBoxBorder"
        Me.codiPropTb.Border.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.codiPropTb.FocusHighlightColor = Color.FromArgb(30, 60, 120)
        Me.codiPropTb.FocusHighlightEnabled = True
        Me.codiPropTb.Font = fontInput
        Me.codiPropTb.ForeColor = Color.FromArgb(120, 200, 255)
        Me.codiPropTb.Location = New Point(182, 74)
        Me.codiPropTb.MaxLength = 25
        Me.codiPropTb.Name = "codiPropTb"
        Me.codiPropTb.PreventEnterBeep = True
        Me.codiPropTb.Size = New Size(130, 30)
        Me.codiPropTb.TabIndex = 7

        Me.LabelPropietario.Text = "Propietario"
        Me.LabelPropietario.ForeColor = txtLight
        Me.LabelPropietario.Font = fontLabel
        Me.LabelPropietario.Location = New Point(318, 56)
        Me.LabelPropietario.AutoSize = True

        Me.propCbzTb.AcceptsTab = True
        Me.propCbzTb.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        Me.propCbzTb.AutoCompleteSource = AutoCompleteSource.CustomSource
        Me.propCbzTb.BackColor = bgInput
        Me.BalloonTip1.SetBalloonCaption(Me.propCbzTb, "Propietario")
        Me.BalloonTip1.SetBalloonText(Me.propCbzTb, "Ingrese el nombre del propietario")
        Me.propCbzTb.Border.BackColor = bgInput
        Me.propCbzTb.Border.BackColor2 = bgInput
        Me.propCbzTb.Border.BorderBottomWidth = 2
        Me.propCbzTb.Border.BorderColor = borderClr
        Me.propCbzTb.Border.BorderLeftWidth = 1
        Me.propCbzTb.Border.BorderRightWidth = 1
        Me.propCbzTb.Border.BorderTopWidth = 1
        Me.propCbzTb.Border.Class = "TextBoxBorder"
        Me.propCbzTb.Border.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.propCbzTb.CharacterCasing = CharacterCasing.Upper
        Me.propCbzTb.FocusHighlightColor = Color.FromArgb(30, 60, 120)
        Me.propCbzTb.FocusHighlightEnabled = True
        Me.propCbzTb.Font = fontInputSm
        Me.propCbzTb.ForeColor = Color.FromArgb(120, 200, 255)
        Me.propCbzTb.Location = New Point(318, 74)
        Me.propCbzTb.MaxLength = 80
        Me.propCbzTb.Name = "propCbzTb"
        Me.propCbzTb.PreventEnterBeep = True
        Me.propCbzTb.Size = New Size(200, 30)
        Me.propCbzTb.TabIndex = 8

        ' Row 3: Contenedor
        Me.LabelContenedor.Text = "N Contenedor"
        Me.LabelContenedor.ForeColor = txtLight
        Me.LabelContenedor.Font = fontLabel
        Me.LabelContenedor.Location = New Point(182, 108)
        Me.LabelContenedor.AutoSize = True

        Me.nConteTb.AcceptsTab = True
        Me.nConteTb.BackColor = bgInput
        Me.nConteTb.Border.BackColor = bgInput
        Me.nConteTb.Border.BackColor2 = bgInput
        Me.nConteTb.Border.BorderBottomWidth = 2
        Me.nConteTb.Border.BorderColor = borderClr
        Me.nConteTb.Border.BorderLeftWidth = 1
        Me.nConteTb.Border.BorderRightWidth = 1
        Me.nConteTb.Border.BorderTopWidth = 1
        Me.nConteTb.Border.Class = "TextBoxBorder"
        Me.nConteTb.Border.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.nConteTb.CharacterCasing = CharacterCasing.Upper
        Me.nConteTb.FocusHighlightColor = Color.FromArgb(50, 80, 130)
        Me.nConteTb.FocusHighlightEnabled = True
        Me.nConteTb.Font = fontInput
        Me.nConteTb.ForeColor = txtWhite
        Me.nConteTb.Location = New Point(182, 126)
        Me.nConteTb.MaxLength = 10
        Me.nConteTb.Name = "nConteTb"
        Me.nConteTb.PreventEnterBeep = True
        Me.nConteTb.Size = New Size(170, 30)
        Me.nConteTb.TabIndex = 9

        ' Row 3 continued: Ruta
        Me.LabelRuta.Text = "Ruta"
        Me.LabelRuta.ForeColor = txtLight
        Me.LabelRuta.Font = fontLabel
        Me.LabelRuta.Location = New Point(358, 108)
        Me.LabelRuta.AutoSize = True

        Me.rutaTb.AcceptsTab = True
        Me.rutaTb.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        Me.rutaTb.AutoCompleteSource = AutoCompleteSource.CustomSource
        Me.rutaTb.BackColor = bgInput
        Me.rutaTb.Border.BackColor = bgInput
        Me.rutaTb.Border.BackColor2 = bgInput
        Me.rutaTb.Border.BorderBottomWidth = 2
        Me.rutaTb.Border.BorderColor = borderClr
        Me.rutaTb.Border.BorderLeftWidth = 1
        Me.rutaTb.Border.BorderRightWidth = 1
        Me.rutaTb.Border.BorderTopWidth = 1
        Me.rutaTb.Border.Class = "TextBoxBorder"
        Me.rutaTb.Border.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.rutaTb.CharacterCasing = CharacterCasing.Upper
        Me.rutaTb.FocusHighlightColor = Color.FromArgb(50, 80, 130)
        Me.rutaTb.FocusHighlightEnabled = True
        Me.rutaTb.Font = fontInputSm
        Me.rutaTb.ForeColor = txtWhite
        Me.rutaTb.Location = New Point(358, 126)
        Me.rutaTb.MaxLength = 80
        Me.rutaTb.Name = "rutaTb"
        Me.rutaTb.PreventEnterBeep = True
        Me.rutaTb.Size = New Size(160, 30)
        Me.rutaTb.TabIndex = 10

        ' Letras label + Total label
        Me.LabelLetras.Text = "Valor en letras"
        Me.LabelLetras.ForeColor = txtLight
        Me.LabelLetras.Font = fontLabel
        Me.LabelLetras.Location = New Point(6, 162)
        Me.LabelLetras.AutoSize = True

        Me.pLetras.BackColor = Color.Transparent
        Me.pLetras.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.pLetras.Font = New Font("Segoe UI", 9.0!, FontStyle.Italic)
        Me.pLetras.ForeColor = Color.FromArgb(180, 140, 255)
        Me.pLetras.Location = New Point(6, 178)
        Me.pLetras.Name = "pLetras"
        Me.pLetras.Size = New Size(510, 22)
        Me.pLetras.TabIndex = 30
        Me.pLetras.Text = "-"

        Me.totVtalb.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.totVtalb.Font = New Font("Segoe UI", 12.0!, FontStyle.Bold)
        Me.totVtalb.ForeColor = Color.FromArgb(80, 255, 160)
        Me.totVtalb.Location = New Point(6, 204)
        Me.totVtalb.Name = "totVtalb"
        Me.totVtalb.AutoSize = True
        Me.totVtalb.TabIndex = 63
        Me.totVtalb.Text = "Total Venta: L. 0.00"

        Me.buscartxt.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.buscartxt.Font = New Font("Segoe UI", 8.0!)
        Me.buscartxt.ForeColor = bgPanel
        Me.buscartxt.Location = New Point(6, 230)
        Me.buscartxt.Name = "buscartxt"
        Me.buscartxt.Size = New Size(75, 18)
        Me.buscartxt.TabIndex = 52
        Me.buscartxt.Text = "-"
        Me.buscartxt.Visible = False

        ' Add controls to left panel
        Me.panelDatosIzq.Controls.AddRange(New Control() {
            Me.LabelGalDesp, Me.galDespTb, Me.LabelValor, Me.valorTb,
            Me.LabelBoleta, Me.nBoletaTb, Me.LabelFecha, Me.fechaPkd,
            Me.LabelPlaca, Me.placaCbzTb, Me.placaCbzTb2,
            Me.LabelCodProp, Me.codiPropTb, Me.LabelPropietario, Me.propCbzTb,
            Me.LabelContenedor, Me.nConteTb, Me.LabelRuta, Me.rutaTb,
            Me.LabelLetras, Me.pLetras, Me.totVtalb, Me.buscartxt
        })

        ' ---- RIGHT PANEL: Persona data + Periodo ----
        Me.panelDatosDer.BackColor = Color.Transparent
        Me.panelDatosDer.Dock = DockStyle.Fill
        Me.panelDatosDer.Padding = New Padding(10, 0, 4, 0)

        Me.LabelDespachador.Text = "Nombre Despachador"
        Me.LabelDespachador.ForeColor = txtLight
        Me.LabelDespachador.Font = fontLabel
        Me.LabelDespachador.Location = New Point(14, 4)
        Me.LabelDespachador.AutoSize = True

        Me.nombDespTb.AcceptsTab = True
        Me.nombDespTb.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        Me.nombDespTb.AutoCompleteSource = AutoCompleteSource.CustomSource
        Me.nombDespTb.BackColor = bgInput
        Me.nombDespTb.Border.BackColor = bgInput
        Me.nombDespTb.Border.BackColor2 = bgInput
        Me.nombDespTb.Border.BorderBottomWidth = 2
        Me.nombDespTb.Border.BorderColor = borderClr
        Me.nombDespTb.Border.BorderLeftWidth = 1
        Me.nombDespTb.Border.BorderRightWidth = 1
        Me.nombDespTb.Border.BorderTopWidth = 1
        Me.nombDespTb.Border.Class = "TextBoxBorder"
        Me.nombDespTb.Border.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.nombDespTb.CharacterCasing = CharacterCasing.Upper
        Me.nombDespTb.FocusHighlightColor = Color.FromArgb(50, 80, 130)
        Me.nombDespTb.FocusHighlightEnabled = True
        Me.nombDespTb.Font = fontInputSm
        Me.nombDespTb.ForeColor = txtWhite
        Me.nombDespTb.Location = New Point(14, 22)
        Me.nombDespTb.MaxLength = 80
        Me.nombDespTb.Name = "nombDespTb"
        Me.nombDespTb.PreventEnterBeep = True
        Me.nombDespTb.Size = New Size(350, 30)
        Me.nombDespTb.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        Me.nombDespTb.TabIndex = 11

        Me.LabelConductor.Text = "Nombre Conductor"
        Me.LabelConductor.ForeColor = txtLight
        Me.LabelConductor.Font = fontLabel
        Me.LabelConductor.Location = New Point(14, 56)
        Me.LabelConductor.AutoSize = True

        Me.nombCondTb.AcceptsTab = True
        Me.nombCondTb.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        Me.nombCondTb.AutoCompleteSource = AutoCompleteSource.CustomSource
        Me.nombCondTb.BackColor = bgInput
        Me.nombCondTb.Border.BackColor = bgInput
        Me.nombCondTb.Border.BackColor2 = bgInput
        Me.nombCondTb.Border.BorderBottomWidth = 2
        Me.nombCondTb.Border.BorderColor = borderClr
        Me.nombCondTb.Border.BorderLeftWidth = 1
        Me.nombCondTb.Border.BorderRightWidth = 1
        Me.nombCondTb.Border.BorderTopWidth = 1
        Me.nombCondTb.Border.Class = "TextBoxBorder"
        Me.nombCondTb.Border.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.nombCondTb.CharacterCasing = CharacterCasing.Upper
        Me.nombCondTb.FocusHighlightColor = Color.FromArgb(50, 80, 130)
        Me.nombCondTb.FocusHighlightEnabled = True
        Me.nombCondTb.Font = fontInputSm
        Me.nombCondTb.ForeColor = txtWhite
        Me.nombCondTb.Location = New Point(14, 74)
        Me.nombCondTb.MaxLength = 80
        Me.nombCondTb.Name = "nombCondTb"
        Me.nombCondTb.PreventEnterBeep = True
        Me.nombCondTb.Size = New Size(350, 30)
        Me.nombCondTb.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        Me.nombCondTb.TabIndex = 12

        ' Periodo / Semana / Prox Sem
        Me.LabelPeriodo.Text = "Periodo"
        Me.LabelPeriodo.ForeColor = txtLight
        Me.LabelPeriodo.Font = fontLabel
        Me.LabelPeriodo.Location = New Point(14, 110)
        Me.LabelPeriodo.AutoSize = True

        Me.periodoTb.DisplayMember = "Text"
        Me.periodoTb.DrawMode = DrawMode.OwnerDrawFixed
        Me.periodoTb.Font = New Font("Segoe UI", 11.0!, FontStyle.Regular)
        Me.periodoTb.FormattingEnabled = True
        Me.periodoTb.ItemHeight = 22
        Me.periodoTb.Items.AddRange(New Object() {Me.ComboItem1, Me.ComboItem2, Me.ComboItem3, Me.ComboItem4, Me.ComboItem5, Me.ComboItem6, Me.ComboItem7, Me.ComboItem8, Me.ComboItem9, Me.ComboItem10, Me.ComboItem11, Me.ComboItem12, Me.ComboItem13})
        Me.periodoTb.Location = New Point(14, 128)
        Me.periodoTb.Name = "periodoTb"
        Me.periodoTb.Size = New Size(65, 28)
        Me.periodoTb.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.periodoTb.TabIndex = 13

        Me.LabelSemana.Text = "Semana"
        Me.LabelSemana.ForeColor = txtLight
        Me.LabelSemana.Font = fontLabel
        Me.LabelSemana.Location = New Point(86, 110)
        Me.LabelSemana.AutoSize = True

        Me.semanaTb.DisplayMember = "Text"
        Me.semanaTb.DrawMode = DrawMode.OwnerDrawFixed
        Me.semanaTb.Font = New Font("Segoe UI", 11.0!, FontStyle.Regular)
        Me.semanaTb.FormattingEnabled = True
        Me.semanaTb.ItemHeight = 22
        Me.semanaTb.Items.AddRange(New Object() {Me.S1, Me.S2, Me.S3, Me.S4, Me.S5})
        Me.semanaTb.Location = New Point(86, 128)
        Me.semanaTb.Name = "semanaTb"
        Me.semanaTb.Size = New Size(60, 28)
        Me.semanaTb.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.semanaTb.TabIndex = 14

        Me.LabelProxSem.Text = "Prox. Sem"
        Me.LabelProxSem.ForeColor = txtLight
        Me.LabelProxSem.Font = fontLabel
        Me.LabelProxSem.Location = New Point(154, 110)
        Me.LabelProxSem.AutoSize = True

        Me.proxSemTb.DisplayMember = "Text"
        Me.proxSemTb.DrawMode = DrawMode.OwnerDrawFixed
        Me.proxSemTb.Font = New Font("Segoe UI", 11.0!, FontStyle.Regular)
        Me.proxSemTb.FormattingEnabled = True
        Me.proxSemTb.ItemHeight = 22
        Me.proxSemTb.Items.AddRange(New Object() {Me.Si, Me.No})
        Me.proxSemTb.Location = New Point(154, 128)
        Me.proxSemTb.Name = "proxSemTb"
        Me.proxSemTb.Size = New Size(60, 28)
        Me.proxSemTb.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.proxSemTb.TabIndex = 15

        Me.panelDatosDer.Controls.AddRange(New Control() {
            Me.LabelDespachador, Me.nombDespTb,
            Me.LabelConductor, Me.nombCondTb,
            Me.LabelPeriodo, Me.periodoTb,
            Me.LabelSemana, Me.semanaTb,
            Me.LabelProxSem, Me.proxSemTb
        })

        ' ComboItem values
        Me.ComboItem1.Text = "1" : Me.ComboItem2.Text = "2" : Me.ComboItem3.Text = "3"
        Me.ComboItem4.Text = "4" : Me.ComboItem5.Text = "5" : Me.ComboItem6.Text = "6"
        Me.ComboItem7.Text = "7" : Me.ComboItem8.Text = "8" : Me.ComboItem9.Text = "9"
        Me.ComboItem10.Text = "10" : Me.ComboItem11.Text = "11" : Me.ComboItem12.Text = "12"
        Me.ComboItem13.Text = "13"
        Me.S1.Text = "1" : Me.S2.Text = "2" : Me.S3.Text = "3" : Me.S4.Text = "4" : Me.S5.Text = "5"
        Me.Si.Text = "SI" : Me.No.Text = "NO"

        ' =====================================================
        ' FILTER PANEL
        ' =====================================================
        Me.FilterPanel.BackColor = Color.FromArgb(22, 30, 48)
        Me.FilterPanel.Dock = DockStyle.Top
        Me.FilterPanel.Height = 42
        Me.FilterPanel.Padding = New Padding(8, 6, 8, 6)

        Me.LabelX14.Text = "Placa:"
        Me.LabelX14.ForeColor = txtLight
        Me.LabelX14.Font = fontLabel
        Me.LabelX14.Location = New Point(10, 12)
        Me.LabelX14.AutoSize = True

        Me.placaBusqTB.BackColor = bgInput
        Me.placaBusqTB.Border.BorderBottomWidth = 2 : Me.placaBusqTB.Border.BorderLeftWidth = 1
        Me.placaBusqTB.Border.BorderRightWidth = 1 : Me.placaBusqTB.Border.BorderTopWidth = 1
        Me.placaBusqTB.Border.BorderColor = borderClr
        Me.placaBusqTB.Border.Class = "TextBoxBorder"
        Me.placaBusqTB.Border.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.placaBusqTB.Font = fontInputSm
        Me.placaBusqTB.ForeColor = txtWhite
        Me.placaBusqTB.Location = New Point(52, 7)
        Me.placaBusqTB.Name = "placaBusqTB"
        Me.placaBusqTB.PreventEnterBeep = True
        Me.placaBusqTB.Size = New Size(95, 28)

        Me.LabelX9.Text = "Boleta:"
        Me.LabelX9.ForeColor = txtLight
        Me.LabelX9.Font = fontLabel
        Me.LabelX9.Location = New Point(155, 12)
        Me.LabelX9.AutoSize = True

        Me.boletBusqTB.BackColor = bgInput
        Me.boletBusqTB.Border.BorderBottomWidth = 2 : Me.boletBusqTB.Border.BorderLeftWidth = 1
        Me.boletBusqTB.Border.BorderRightWidth = 1 : Me.boletBusqTB.Border.BorderTopWidth = 1
        Me.boletBusqTB.Border.BorderColor = borderClr
        Me.boletBusqTB.Border.Class = "TextBoxBorder"
        Me.boletBusqTB.Border.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.boletBusqTB.Font = fontInputSm
        Me.boletBusqTB.ForeColor = txtWhite
        Me.boletBusqTB.Location = New Point(202, 7)
        Me.boletBusqTB.Name = "boletBusqTB"
        Me.boletBusqTB.PreventEnterBeep = True
        Me.boletBusqTB.Size = New Size(95, 28)

        Me.chkUsarFecha.Text = "Fecha"
        Me.chkUsarFecha.ForeColor = txtLight
        Me.chkUsarFecha.Font = New Font("Segoe UI Semibold", 9.0!, FontStyle.Bold)
        Me.chkUsarFecha.Location = New Point(310, 10)
        Me.chkUsarFecha.AutoSize = True
        Me.chkUsarFecha.FlatStyle = FlatStyle.Flat

        Me.LabelFechaDesde.Text = "De:"
        Me.LabelFechaDesde.ForeColor = txtLight
        Me.LabelFechaDesde.Font = fontLabel
        Me.LabelFechaDesde.Location = New Point(375, 12)
        Me.LabelFechaDesde.AutoSize = True

        Me.fechaDesdePk.Enabled = False
        Me.fechaDesdePk.Format = DateTimePickerFormat.Short
        Me.fechaDesdePk.Location = New Point(398, 9)
        Me.fechaDesdePk.Size = New Size(105, 23)

        Me.LabelFechaHasta.Text = "A:"
        Me.LabelFechaHasta.ForeColor = txtLight
        Me.LabelFechaHasta.Font = fontLabel
        Me.LabelFechaHasta.Location = New Point(510, 12)
        Me.LabelFechaHasta.AutoSize = True

        Me.fechaHastaPk.Enabled = False
        Me.fechaHastaPk.Format = DateTimePickerFormat.Short
        Me.fechaHastaPk.Location = New Point(528, 9)
        Me.fechaHastaPk.Size = New Size(105, 23)

        Me.LabelDesp.Text = "Despachador:"
        Me.LabelDesp.ForeColor = txtLight
        Me.LabelDesp.Font = fontLabel
        Me.LabelDesp.Location = New Point(642, 12)
        Me.LabelDesp.AutoSize = True

        Me.despachadorCb.DisplayMember = "Text"
        Me.despachadorCb.DrawMode = DrawMode.OwnerDrawFixed
        Me.despachadorCb.DropDownStyle = ComboBoxStyle.DropDownList
        Me.despachadorCb.Font = New Font("Segoe UI", 9.0!, FontStyle.Regular)
        Me.despachadorCb.FormattingEnabled = True
        Me.despachadorCb.ItemHeight = 17
        Me.despachadorCb.Location = New Point(724, 8)
        Me.despachadorCb.Size = New Size(140, 23)
        Me.despachadorCb.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled

        Me.buscarBtn.AccessibleRole = AccessibleRole.PushButton
        Me.buscarBtn.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.buscarBtn.Font = fontBtn
        Me.buscarBtn.Location = New Point(875, 6)
        Me.buscarBtn.Size = New Size(80, 30)
        Me.buscarBtn.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.buscarBtn.Text = "Buscar"
        Me.buscarBtn.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor(4)

        Me.ButtonX6.AccessibleRole = AccessibleRole.PushButton
        Me.ButtonX6.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX6.Location = New Point(960, 6)
        Me.ButtonX6.Size = New Size(30, 30)
        Me.ButtonX6.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonX6.Symbol = ChrW(&HF021)
        Me.ButtonX6.SymbolSize = 10.0!
        Me.ButtonX6.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor(4)

        Me.lblTotales.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblTotales.Font = New Font("Segoe UI Semibold", 10.0!, FontStyle.Bold)
        Me.lblTotales.ForeColor = txtGold
        Me.lblTotales.Location = New Point(1000, 10)
        Me.lblTotales.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        Me.lblTotales.AutoSize = True
        Me.lblTotales.Text = "Registros: 0  |  Total Galones: 0.00"

        Me.FilterPanel.Controls.AddRange(New Control() {
            Me.LabelX14, Me.placaBusqTB, Me.LabelX9, Me.boletBusqTB,
            Me.chkUsarFecha, Me.LabelFechaDesde, Me.fechaDesdePk,
            Me.LabelFechaHasta, Me.fechaHastaPk, Me.LabelDesp, Me.despachadorCb,
            Me.buscarBtn, Me.ButtonX6, Me.lblTotales
        })

        ' =====================================================
        ' DATAGRIDVIEW
        ' =====================================================
        DataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = Color.FromArgb(25, 40, 65)
        DataGridViewCellStyle1.Font = New Font("Segoe UI", 9.75!, FontStyle.Regular)
        DataGridViewCellStyle1.ForeColor = Color.FromArgb(200, 215, 240)
        DataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(50, 100, 180)
        DataGridViewCellStyle1.SelectionForeColor = Color.White
        DataGridViewCellStyle1.WrapMode = DataGridViewTriState.False

        Me.CamDGV.AllowUserToAddRows = False
        Me.CamDGV.AllowUserToDeleteRows = False
        Me.CamDGV.AllowUserToOrderColumns = True
        Me.CamDGV.BorderStyle = BorderStyle.None
        Me.CamDGV.BackgroundColor = Color.FromArgb(20, 30, 48)
        Me.CamDGV.GridColor = Color.FromArgb(40, 55, 80)
        Me.CamDGV.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.CamDGV.DefaultCellStyle = DataGridViewCellStyle1
        Me.CamDGV.Dock = DockStyle.Fill
        Me.CamDGV.Name = "CamDGV"
        Me.CamDGV.ReadOnly = True
        Me.CamDGV.RowHeadersVisible = False
        Me.CamDGV.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        Me.CamDGV.MultiSelect = False
        Me.CamDGV.TabIndex = 47

        ' =====================================================
        ' PRINT PANEL (bottom)
        ' =====================================================
        Me.PrintPanel.BackColor = Color.FromArgb(18, 26, 42)
        Me.PrintPanel.Dock = DockStyle.Bottom
        Me.PrintPanel.Height = 40
        Me.PrintPanel.Padding = New Padding(8, 4, 8, 4)

        Me.ImprimirBt.AccessibleRole = AccessibleRole.PushButton
        Me.ImprimirBt.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ImprimirBt.Font = fontBtn
        Me.ImprimirBt.Location = New Point(10, 4)
        Me.ImprimirBt.Size = New Size(160, 32)
        Me.ImprimirBt.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ImprimirBt.Symbol = ChrW(&HF02F)
        Me.ImprimirBt.SymbolSize = 10.0!
        Me.ImprimirBt.Text = " Imprimir Comprob."
        Me.ImprimirBt.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor(4)

        Me.PreviaBtn.AccessibleRole = AccessibleRole.PushButton
        Me.PreviaBtn.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.PreviaBtn.Font = fontBtn
        Me.PreviaBtn.Location = New Point(176, 4)
        Me.PreviaBtn.Size = New Size(160, 32)
        Me.PreviaBtn.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.PreviaBtn.Symbol = ChrW(&HF06E)
        Me.PreviaBtn.SymbolSize = 10.0!
        Me.PreviaBtn.Text = " Vista Previa Comp."
        Me.PreviaBtn.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor(4)

        Me.ImprimirBt2.AccessibleRole = AccessibleRole.PushButton
        Me.ImprimirBt2.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ImprimirBt2.Font = fontBtn
        Me.ImprimirBt2.Location = New Point(350, 4)
        Me.ImprimirBt2.Size = New Size(155, 32)
        Me.ImprimirBt2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ImprimirBt2.Symbol = ChrW(&HF02F)
        Me.ImprimirBt2.SymbolSize = 10.0!
        Me.ImprimirBt2.Text = " Imprimir Doc."
        Me.ImprimirBt2.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor(4)

        Me.PreviaBtn2.AccessibleRole = AccessibleRole.PushButton
        Me.PreviaBtn2.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.PreviaBtn2.Font = fontBtn
        Me.PreviaBtn2.Location = New Point(511, 4)
        Me.PreviaBtn2.Size = New Size(155, 32)
        Me.PreviaBtn2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.PreviaBtn2.Symbol = ChrW(&HF06E)
        Me.PreviaBtn2.SymbolSize = 10.0!
        Me.PreviaBtn2.Text = " Vista Previa Doc."
        Me.PreviaBtn2.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor(4)

        Me.PrintPanel.Controls.AddRange(New Control() {Me.ImprimirBt, Me.PreviaBtn, Me.ImprimirBt2, Me.PreviaBtn2})

        ' =====================================================
        ' PRINT PREVIEW DIALOGS
        ' =====================================================
        Me.PrintPreviewComprobante.AutoScrollMargin = New Size(0, 0)
        Me.PrintPreviewComprobante.AutoScrollMinSize = New Size(0, 0)
        Me.PrintPreviewComprobante.ClientSize = New Size(400, 300)
        Me.PrintPreviewComprobante.Enabled = True
        Me.PrintPreviewComprobante.Name = "PrintPreviewComprobante"
        Me.PrintPreviewComprobante.Visible = False

        Me.PrintPreviewDocumento.AutoScrollMargin = New Size(0, 0)
        Me.PrintPreviewDocumento.AutoScrollMinSize = New Size(0, 0)
        Me.PrintPreviewDocumento.ClientSize = New Size(400, 300)
        Me.PrintPreviewDocumento.Enabled = True
        Me.PrintPreviewDocumento.Name = "PrintPreviewDocumento"
        Me.PrintPreviewDocumento.Visible = False

        ' =====================================================
        ' FORM
        ' =====================================================
        Me.AutoScaleDimensions = New SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = AutoScaleMode.Font
        Me.BackColor = Color.FromArgb(20, 30, 48)
        Me.ClientSize = New Size(1200, 750)
        Me.Font = New Font("Segoe UI", 9.0!)
        Me.MinimumSize = New Size(900, 550)

        ' Order matters: bottom-up for docked controls
        Me.Controls.Add(Me.CamDGV)        ' Fill
        Me.Controls.Add(Me.FilterPanel)    ' Top (above grid)
        Me.Controls.Add(Me.PanelP)         ' Top (above filter)
        Me.Controls.Add(Me.ToolbarPanel)   ' Top (above panel)
        Me.Controls.Add(Me.PrintPanel)     ' Bottom

        Me.KeyPreview = True
        Me.Name = "comprobantePlus"
        Me.Text = "Comprobante Plus"

        CType(Me.CamDGV, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.fechaPkd, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolbarPanel.ResumeLayout(False)
        Me.PanelP.ResumeLayout(False)
        Me.panelDatosIzq.ResumeLayout(False)
        Me.panelDatosIzq.PerformLayout()
        Me.panelDatosDer.ResumeLayout(False)
        Me.panelDatosDer.PerformLayout()
        Me.FilterPanel.ResumeLayout(False)
        Me.FilterPanel.PerformLayout()
        Me.PrintPanel.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    ' ========== CONTROL DECLARATIONS ==========
    Friend WithEvents ToolbarPanel As Panel
    Friend WithEvents NuevoBtn As DevComponents.DotNetBar.ButtonX
    Friend WithEvents EditarBtn As DevComponents.DotNetBar.ButtonX
    Friend WithEvents GuardarBtn As DevComponents.DotNetBar.ButtonX
    Friend WithEvents ModificarBtn As DevComponents.DotNetBar.ButtonX
    Friend WithEvents EliminarBtn As DevComponents.DotNetBar.ButtonX
    Friend WithEvents CancelarBtn As DevComponents.DotNetBar.ButtonX
    Friend WithEvents AnularBtn As DevComponents.DotNetBar.ButtonX
    Friend WithEvents lblNivelTanque As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX23 As DevComponents.DotNetBar.LabelX
    Friend WithEvents nComproTb As DevComponents.DotNetBar.Controls.TextBoxX

    Friend WithEvents PanelP As Panel
    Friend WithEvents panelDatosIzq As Panel
    Friend WithEvents panelDatosDer As Panel

    Friend WithEvents galDespTb As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents valorTb As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents nBoletaTb As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents fechaPkd As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents placaCbzTb As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents codiPropTb As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents propCbzTb As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents nConteTb As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents rutaTb As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents nombDespTb As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents nombCondTb As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents periodoTb As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents semanaTb As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents proxSemTb As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents placaCbzTb2 As DevComponents.DotNetBar.ListBoxAdv
    Friend WithEvents pLetras As DevComponents.DotNetBar.LabelX
    Friend WithEvents totVtalb As DevComponents.DotNetBar.LabelX
    Friend WithEvents buscartxt As DevComponents.DotNetBar.LabelX

    Friend WithEvents LabelGalDesp As Label
    Friend WithEvents LabelValor As Label
    Friend WithEvents LabelBoleta As Label
    Friend WithEvents LabelFecha As Label
    Friend WithEvents LabelPlaca As Label
    Friend WithEvents LabelCodProp As Label
    Friend WithEvents LabelPropietario As Label
    Friend WithEvents LabelContenedor As Label
    Friend WithEvents LabelRuta As Label
    Friend WithEvents LabelDespachador As Label
    Friend WithEvents LabelConductor As Label
    Friend WithEvents LabelPeriodo As Label
    Friend WithEvents LabelSemana As Label
    Friend WithEvents LabelProxSem As Label
    Friend WithEvents LabelLetras As Label

    Friend WithEvents ComboItem1 As DevComponents.Editors.ComboItem
    Friend WithEvents ComboItem2 As DevComponents.Editors.ComboItem
    Friend WithEvents ComboItem3 As DevComponents.Editors.ComboItem
    Friend WithEvents ComboItem4 As DevComponents.Editors.ComboItem
    Friend WithEvents ComboItem5 As DevComponents.Editors.ComboItem
    Friend WithEvents ComboItem6 As DevComponents.Editors.ComboItem
    Friend WithEvents ComboItem7 As DevComponents.Editors.ComboItem
    Friend WithEvents ComboItem8 As DevComponents.Editors.ComboItem
    Friend WithEvents ComboItem9 As DevComponents.Editors.ComboItem
    Friend WithEvents ComboItem10 As DevComponents.Editors.ComboItem
    Friend WithEvents ComboItem11 As DevComponents.Editors.ComboItem
    Friend WithEvents ComboItem12 As DevComponents.Editors.ComboItem
    Friend WithEvents ComboItem13 As DevComponents.Editors.ComboItem
    Friend WithEvents S1 As DevComponents.Editors.ComboItem
    Friend WithEvents S2 As DevComponents.Editors.ComboItem
    Friend WithEvents S3 As DevComponents.Editors.ComboItem
    Friend WithEvents S4 As DevComponents.Editors.ComboItem
    Friend WithEvents S5 As DevComponents.Editors.ComboItem
    Friend WithEvents Si As DevComponents.Editors.ComboItem
    Friend WithEvents No As DevComponents.Editors.ComboItem

    Friend WithEvents FilterPanel As Panel
    Friend WithEvents LabelX14 As Label
    Friend WithEvents placaBusqTB As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX9 As Label
    Friend WithEvents boletBusqTB As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents chkUsarFecha As CheckBox
    Friend WithEvents LabelFechaDesde As Label
    Friend WithEvents fechaDesdePk As DateTimePicker
    Friend WithEvents LabelFechaHasta As Label
    Friend WithEvents fechaHastaPk As DateTimePicker
    Friend WithEvents LabelDesp As Label
    Friend WithEvents despachadorCb As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents buscarBtn As DevComponents.DotNetBar.ButtonX
    Friend WithEvents ButtonX6 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents lblTotales As DevComponents.DotNetBar.LabelX

    Friend WithEvents CamDGV As DataGridView

    Friend WithEvents PrintPanel As Panel
    Friend WithEvents ImprimirBt As DevComponents.DotNetBar.ButtonX
    Friend WithEvents PreviaBtn As DevComponents.DotNetBar.ButtonX
    Friend WithEvents ImprimirBt2 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents PreviaBtn2 As DevComponents.DotNetBar.ButtonX

    Friend WithEvents PrintComprobante As Printing.PrintDocument
    Friend WithEvents PrintPreviewComprobante As PrintPreviewDialog
    Friend WithEvents PrintDocumento As Printing.PrintDocument
    Friend WithEvents PrintPreviewDocumento As PrintPreviewDialog
    Friend WithEvents BalloonTip1 As DevComponents.DotNetBar.BalloonTip

End Class
