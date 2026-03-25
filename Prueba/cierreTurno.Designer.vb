<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class cierreTurno
    Inherits System.Windows.Forms.Form

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

    Private components As System.ComponentModel.IContainer

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.panelHeader = New System.Windows.Forms.Panel()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.panelResumen = New System.Windows.Forms.Panel()
        Me.lblDespachadorLbl = New System.Windows.Forms.Label()
        Me.lblDespachador = New System.Windows.Forms.Label()
        Me.lblTurnoLbl = New System.Windows.Forms.Label()
        Me.lblTurno = New System.Windows.Forms.Label()
        Me.lblFechaLbl = New System.Windows.Forms.Label()
        Me.lblFecha = New System.Windows.Forms.Label()
        Me.lblPeriodoLbl = New System.Windows.Forms.Label()
        Me.lblPeriodo = New System.Windows.Forms.Label()
        Me.lblOdometroInicio = New System.Windows.Forms.Label()
        Me.panelTotales = New System.Windows.Forms.Panel()
        Me.lblComprobantesLbl = New System.Windows.Forms.Label()
        Me.lblComprobantes = New System.Windows.Forms.Label()
        Me.lblGalonesLbl = New System.Windows.Forms.Label()
        Me.lblGalones = New System.Windows.Forms.Label()
        Me.lblMontoLbl = New System.Windows.Forms.Label()
        Me.lblMonto = New System.Windows.Forms.Label()
        Me.dgvDetalle = New System.Windows.Forms.DataGridView()
        Me.panelCierre = New System.Windows.Forms.Panel()
        Me.lblTanqueInfo = New System.Windows.Forms.Label()
        Me.lblMedicionLbl = New System.Windows.Forms.Label()
        Me.txtMedicionTanque = New System.Windows.Forms.TextBox()
        Me.lblOdoCierreLbl = New System.Windows.Forms.Label()
        Me.txtOdometroCierre = New System.Windows.Forms.TextBox()
        Me.lblObsLbl = New System.Windows.Forms.Label()
        Me.txtObservaciones = New System.Windows.Forms.TextBox()
        Me.btnCerrarTurno = New System.Windows.Forms.Button()
        Me.btnRefrescar = New System.Windows.Forms.Button()

        CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panelHeader.SuspendLayout()
        Me.panelResumen.SuspendLayout()
        Me.panelTotales.SuspendLayout()
        Me.panelCierre.SuspendLayout()
        Me.SuspendLayout()

        Dim bgDark As Color = Color.FromArgb(24, 32, 50)
        Dim bgPanel As Color = Color.FromArgb(30, 42, 66)
        Dim txtWhite As Color = Color.White
        Dim txtLight As Color = Color.FromArgb(180, 200, 230)
        Dim txtGold As Color = Color.FromArgb(255, 215, 80)
        Dim accentGreen As Color = Color.FromArgb(80, 200, 120)
        Dim fontLbl As Font = New Font("Segoe UI", 10.0!, FontStyle.Regular)
        Dim fontVal As Font = New Font("Segoe UI Semibold", 12.0!, FontStyle.Bold)
        Dim fontBig As Font = New Font("Segoe UI", 14.0!, FontStyle.Bold)

        ' Header
        Me.panelHeader.BackColor = Color.FromArgb(18, 26, 42)
        Me.panelHeader.Dock = DockStyle.Top
        Me.panelHeader.Height = 45
        Me.panelHeader.Controls.Add(Me.lblTitulo)

        Me.lblTitulo.Text = "CIERRE DE TURNO"
        Me.lblTitulo.Font = New Font("Segoe UI", 16.0!, FontStyle.Bold)
        Me.lblTitulo.ForeColor = txtGold
        Me.lblTitulo.Location = New Point(15, 8)
        Me.lblTitulo.AutoSize = True

        ' Resumen panel
        Me.panelResumen.BackColor = bgPanel
        Me.panelResumen.Dock = DockStyle.Top
        Me.panelResumen.Height = 70
        Me.panelResumen.Padding = New Padding(15, 8, 15, 8)

        Me.lblDespachadorLbl.Text = "Despachador:" : Me.lblDespachadorLbl.ForeColor = txtLight : Me.lblDespachadorLbl.Font = fontLbl
        Me.lblDespachadorLbl.Location = New Point(15, 10) : Me.lblDespachadorLbl.AutoSize = True
        Me.lblDespachador.Text = "-" : Me.lblDespachador.ForeColor = txtWhite : Me.lblDespachador.Font = fontVal
        Me.lblDespachador.Location = New Point(120, 8) : Me.lblDespachador.AutoSize = True

        Me.lblTurnoLbl.Text = "Turno:" : Me.lblTurnoLbl.ForeColor = txtLight : Me.lblTurnoLbl.Font = fontLbl
        Me.lblTurnoLbl.Location = New Point(15, 38) : Me.lblTurnoLbl.AutoSize = True
        Me.lblTurno.Text = "-" : Me.lblTurno.ForeColor = txtGold : Me.lblTurno.Font = fontVal
        Me.lblTurno.Location = New Point(70, 36) : Me.lblTurno.AutoSize = True

        Me.lblFechaLbl.Text = "Fecha:" : Me.lblFechaLbl.ForeColor = txtLight : Me.lblFechaLbl.Font = fontLbl
        Me.lblFechaLbl.Location = New Point(450, 10) : Me.lblFechaLbl.AutoSize = True
        Me.lblFecha.Text = "-" : Me.lblFecha.ForeColor = txtWhite : Me.lblFecha.Font = fontVal
        Me.lblFecha.Location = New Point(505, 8) : Me.lblFecha.AutoSize = True

        Me.lblPeriodoLbl.Text = "Periodo:" : Me.lblPeriodoLbl.ForeColor = txtLight : Me.lblPeriodoLbl.Font = fontLbl
        Me.lblPeriodoLbl.Location = New Point(450, 38) : Me.lblPeriodoLbl.AutoSize = True
        Me.lblPeriodo.Text = "-" : Me.lblPeriodo.ForeColor = txtWhite : Me.lblPeriodo.Font = fontVal
        Me.lblPeriodo.Location = New Point(515, 36) : Me.lblPeriodo.AutoSize = True

        ' Odometro inicio label
        Me.lblOdometroInicio.Text = "Odometro Inicio: -"
        Me.lblOdometroInicio.ForeColor = Color.FromArgb(80, 255, 160)
        Me.lblOdometroInicio.Font = New Font("Segoe UI Semibold", 11.0!, FontStyle.Bold)
        Me.lblOdometroInicio.Location = New Point(250, 36)
        Me.lblOdometroInicio.AutoSize = True

        Me.panelResumen.Height = 70
        Me.panelResumen.Controls.AddRange(New Control() {
            Me.lblDespachadorLbl, Me.lblDespachador, Me.lblTurnoLbl, Me.lblTurno,
            Me.lblFechaLbl, Me.lblFecha, Me.lblPeriodoLbl, Me.lblPeriodo,
            Me.lblOdometroInicio
        })

        ' Totales panel
        Me.panelTotales.BackColor = Color.FromArgb(25, 38, 60)
        Me.panelTotales.Dock = DockStyle.Top
        Me.panelTotales.Height = 55
        Me.panelTotales.Padding = New Padding(15, 8, 15, 8)

        Me.lblComprobantesLbl.Text = "Comprobantes:" : Me.lblComprobantesLbl.ForeColor = txtLight : Me.lblComprobantesLbl.Font = fontLbl
        Me.lblComprobantesLbl.Location = New Point(15, 16) : Me.lblComprobantesLbl.AutoSize = True
        Me.lblComprobantes.Text = "0" : Me.lblComprobantes.ForeColor = accentGreen : Me.lblComprobantes.Font = fontBig
        Me.lblComprobantes.Location = New Point(135, 12) : Me.lblComprobantes.AutoSize = True

        Me.lblGalonesLbl.Text = "Total Galones:" : Me.lblGalonesLbl.ForeColor = txtLight : Me.lblGalonesLbl.Font = fontLbl
        Me.lblGalonesLbl.Location = New Point(230, 16) : Me.lblGalonesLbl.AutoSize = True
        Me.lblGalones.Text = "0.00" : Me.lblGalones.ForeColor = accentGreen : Me.lblGalones.Font = fontBig
        Me.lblGalones.Location = New Point(350, 12) : Me.lblGalones.AutoSize = True

        Me.lblMontoLbl.Text = "Total Monto:" : Me.lblMontoLbl.ForeColor = txtLight : Me.lblMontoLbl.Font = fontLbl
        Me.lblMontoLbl.Location = New Point(480, 16) : Me.lblMontoLbl.AutoSize = True
        Me.lblMonto.Text = "L. 0.00" : Me.lblMonto.ForeColor = txtGold : Me.lblMonto.Font = fontBig
        Me.lblMonto.Location = New Point(590, 12) : Me.lblMonto.AutoSize = True

        Me.panelTotales.Controls.AddRange(New Control() {
            Me.lblComprobantesLbl, Me.lblComprobantes, Me.lblGalonesLbl, Me.lblGalones,
            Me.lblMontoLbl, Me.lblMonto
        })

        ' DataGridView
        Me.dgvDetalle.Dock = DockStyle.Fill
        Me.dgvDetalle.BackgroundColor = bgDark
        Me.dgvDetalle.BorderStyle = BorderStyle.None
        Me.dgvDetalle.AllowUserToAddRows = False
        Me.dgvDetalle.ReadOnly = True
        Me.dgvDetalle.RowHeadersVisible = False
        Me.dgvDetalle.SelectionMode = DataGridViewSelectionMode.FullRowSelect

        ' Cierre panel (bottom)
        Me.panelCierre.BackColor = Color.FromArgb(18, 26, 42)
        Me.panelCierre.Dock = DockStyle.Bottom
        Me.panelCierre.Height = 135
        Me.panelCierre.Padding = New Padding(15, 8, 15, 8)

        Me.lblTanqueInfo.Text = "Info tanque: -"
        Me.lblTanqueInfo.ForeColor = txtLight : Me.lblTanqueInfo.Font = fontLbl
        Me.lblTanqueInfo.Location = New Point(15, 8) : Me.lblTanqueInfo.AutoSize = True

        Me.lblMedicionLbl.Text = "Medicion Tanque (galones):"
        Me.lblMedicionLbl.ForeColor = txtGold : Me.lblMedicionLbl.Font = New Font("Segoe UI Semibold", 10.0!, FontStyle.Bold)
        Me.lblMedicionLbl.Location = New Point(15, 35) : Me.lblMedicionLbl.AutoSize = True

        Me.txtMedicionTanque.BackColor = Color.FromArgb(40, 55, 82)
        Me.txtMedicionTanque.ForeColor = txtWhite
        Me.txtMedicionTanque.Font = New Font("Segoe UI", 14.0!, FontStyle.Bold)
        Me.txtMedicionTanque.BorderStyle = BorderStyle.FixedSingle
        Me.txtMedicionTanque.Location = New Point(230, 30)
        Me.txtMedicionTanque.Size = New Size(150, 34)

        Me.lblOdoCierreLbl.Text = "Odometro Cierre (gal):"
        Me.lblOdoCierreLbl.ForeColor = Color.FromArgb(80, 255, 160)
        Me.lblOdoCierreLbl.Font = New Font("Segoe UI Semibold", 10.0!, FontStyle.Bold)
        Me.lblOdoCierreLbl.Location = New Point(400, 35) : Me.lblOdoCierreLbl.AutoSize = True

        Me.txtOdometroCierre.BackColor = Color.FromArgb(40, 55, 82)
        Me.txtOdometroCierre.ForeColor = Color.FromArgb(80, 255, 160)
        Me.txtOdometroCierre.Font = New Font("Segoe UI", 14.0!, FontStyle.Bold)
        Me.txtOdometroCierre.BorderStyle = BorderStyle.FixedSingle
        Me.txtOdometroCierre.Location = New Point(580, 30)
        Me.txtOdometroCierre.Size = New Size(150, 34)

        Me.lblObsLbl.Text = "Observaciones:"
        Me.lblObsLbl.ForeColor = txtLight : Me.lblObsLbl.Font = fontLbl
        Me.lblObsLbl.Location = New Point(15, 70) : Me.lblObsLbl.AutoSize = True

        Me.txtObservaciones.BackColor = Color.FromArgb(40, 55, 82)
        Me.txtObservaciones.ForeColor = txtWhite
        Me.txtObservaciones.Font = New Font("Segoe UI", 10.0!)
        Me.txtObservaciones.BorderStyle = BorderStyle.FixedSingle
        Me.txtObservaciones.Location = New Point(120, 67)
        Me.txtObservaciones.Size = New Size(340, 28)

        Me.btnRefrescar.Text = "Refrescar"
        Me.btnRefrescar.BackColor = Color.FromArgb(50, 80, 130)
        Me.btnRefrescar.ForeColor = txtWhite
        Me.btnRefrescar.FlatStyle = FlatStyle.Flat
        Me.btnRefrescar.Font = New Font("Segoe UI Semibold", 10.0!, FontStyle.Bold)
        Me.btnRefrescar.Location = New Point(480, 90)
        Me.btnRefrescar.Size = New Size(120, 35)

        Me.btnCerrarTurno.Text = "CERRAR TURNO"
        Me.btnCerrarTurno.BackColor = Color.FromArgb(200, 60, 60)
        Me.btnCerrarTurno.ForeColor = txtWhite
        Me.btnCerrarTurno.FlatStyle = FlatStyle.Flat
        Me.btnCerrarTurno.Font = New Font("Segoe UI", 12.0!, FontStyle.Bold)
        Me.btnCerrarTurno.Location = New Point(610, 85)
        Me.btnCerrarTurno.Size = New Size(180, 40)

        Me.panelCierre.Controls.AddRange(New Control() {
            Me.lblTanqueInfo, Me.lblMedicionLbl, Me.txtMedicionTanque,
            Me.lblOdoCierreLbl, Me.txtOdometroCierre,
            Me.lblObsLbl, Me.txtObservaciones, Me.btnRefrescar, Me.btnCerrarTurno
        })

        ' Form
        Me.AutoScaleDimensions = New SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = AutoScaleMode.Font
        Me.BackColor = bgDark
        Me.ClientSize = New Size(800, 550)
        Me.Font = New Font("Segoe UI", 9.0!)
        Me.MinimumSize = New Size(700, 450)
        Me.Name = "cierreTurno"
        Me.Text = "Cierre de Turno"

        Me.Controls.Add(Me.dgvDetalle)
        Me.Controls.Add(Me.panelTotales)
        Me.Controls.Add(Me.panelResumen)
        Me.Controls.Add(Me.panelHeader)
        Me.Controls.Add(Me.panelCierre)

        CType(Me.dgvDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panelHeader.ResumeLayout(False)
        Me.panelHeader.PerformLayout()
        Me.panelResumen.ResumeLayout(False)
        Me.panelResumen.PerformLayout()
        Me.panelTotales.ResumeLayout(False)
        Me.panelTotales.PerformLayout()
        Me.panelCierre.ResumeLayout(False)
        Me.panelCierre.PerformLayout()
        Me.ResumeLayout(False)
    End Sub

    Friend WithEvents panelHeader As Panel
    Friend WithEvents lblTitulo As Label
    Friend WithEvents panelResumen As Panel
    Friend WithEvents lblDespachadorLbl As Label
    Friend WithEvents lblDespachador As Label
    Friend WithEvents lblTurnoLbl As Label
    Friend WithEvents lblTurno As Label
    Friend WithEvents lblFechaLbl As Label
    Friend WithEvents lblFecha As Label
    Friend WithEvents lblPeriodoLbl As Label
    Friend WithEvents lblPeriodo As Label
    Friend WithEvents panelTotales As Panel
    Friend WithEvents lblComprobantesLbl As Label
    Friend WithEvents lblComprobantes As Label
    Friend WithEvents lblGalonesLbl As Label
    Friend WithEvents lblGalones As Label
    Friend WithEvents lblMontoLbl As Label
    Friend WithEvents lblMonto As Label
    Friend WithEvents dgvDetalle As DataGridView
    Friend WithEvents panelCierre As Panel
    Friend WithEvents lblTanqueInfo As Label
    Friend WithEvents lblMedicionLbl As Label
    Friend WithEvents txtMedicionTanque As TextBox
    Friend WithEvents lblObsLbl As Label
    Friend WithEvents txtObservaciones As TextBox
    Friend WithEvents btnCerrarTurno As Button
    Friend WithEvents btnRefrescar As Button
    Friend WithEvents lblOdometroInicio As Label
    Friend WithEvents lblOdoCierreLbl As Label
    Friend WithEvents txtOdometroCierre As TextBox
End Class
