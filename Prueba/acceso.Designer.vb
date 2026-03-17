<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class acceso
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(acceso))
        Me.CancelarBtn = New System.Windows.Forms.Button()
        Me.EliminarBtn = New System.Windows.Forms.Button()
        Me.EditarBtn = New System.Windows.Forms.Button()
        Me.NuevoBtn = New System.Windows.Forms.Button()
        Me.GuardarBtn = New System.Windows.Forms.Button()
        Me.ModificarBtn = New System.Windows.Forms.Button()
        Me.PanelP = New System.Windows.Forms.Panel()
        Me.ButtonX1 = New System.Windows.Forms.Button()
        Me.fechDpk = New System.Windows.Forms.DateTimePicker()
        Me.statTbx = New System.Windows.Forms.ComboBox()
        Me.tipoTbx = New System.Windows.Forms.ComboBox()
        Me.LabelX4 = New System.Windows.Forms.Label()
        Me.LabelX10 = New System.Windows.Forms.Label()
        Me.LabelX3 = New System.Windows.Forms.Label()
        Me.LabelX8 = New System.Windows.Forms.Label()
        Me.LabelX2 = New System.Windows.Forms.Label()
        Me.ApelTbx = New System.Windows.Forms.TextBox()
        Me.nombTbx = New System.Windows.Forms.TextBox()
        Me.LabelX7 = New System.Windows.Forms.Label()
        Me.clavTbx = New System.Windows.Forms.TextBox()
        Me.LabelX1 = New System.Windows.Forms.Label()
        Me.usuaTbx = New System.Windows.Forms.TextBox()
        Me.AcceDGV = New System.Windows.Forms.DataGridView()
        Me.buscartxt = New System.Windows.Forms.Label()
        Me.PanelPermisos = New System.Windows.Forms.Panel()
        Me.LblPermisos = New System.Windows.Forms.Label()
        Me.chkCamiones = New System.Windows.Forms.CheckBox()
        Me.chkPlacas = New System.Windows.Forms.CheckBox()
        Me.chkTransportistas = New System.Windows.Forms.CheckBox()
        Me.chkTanque = New System.Windows.Forms.CheckBox()
        Me.chkEmpresa = New System.Windows.Forms.CheckBox()
        Me.chkAccesos = New System.Windows.Forms.CheckBox()
        Me.chkMedicion = New System.Windows.Forms.CheckBox()
        Me.chkComprobante = New System.Windows.Forms.CheckBox()
        Me.chkFactura = New System.Windows.Forms.CheckBox()
        Me.chkPropietario = New System.Windows.Forms.CheckBox()
        Me.chkConsumo = New System.Windows.Forms.CheckBox()
        Me.chkReporte = New System.Windows.Forms.CheckBox()
        Me.chkValorComb = New System.Windows.Forms.CheckBox()
        Me.chkRutas = New System.Windows.Forms.CheckBox()
        Me.chkReporteFact = New System.Windows.Forms.CheckBox()
        Me.PanelP.SuspendLayout()
        CType(Me.AcceDGV, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelPermisos.SuspendLayout()
        Me.SuspendLayout()
        '
        'NuevoBtn
        '
        Me.NuevoBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.NuevoBtn.FlatAppearance.BorderSize = 1
        Me.NuevoBtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(80, Byte), Integer), CType(CType(80, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.NuevoBtn.BackColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(55, Byte), Integer), CType(CType(55, Byte), Integer))
        Me.NuevoBtn.ForeColor = System.Drawing.Color.White
        Me.NuevoBtn.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
        Me.NuevoBtn.Location = New System.Drawing.Point(16, 16)
        Me.NuevoBtn.Name = "NuevoBtn"
        Me.NuevoBtn.Size = New System.Drawing.Size(88, 40)
        Me.NuevoBtn.TabIndex = 22
        Me.NuevoBtn.Text = "Nuevo"
        Me.NuevoBtn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.NuevoBtn.UseVisualStyleBackColor = False
        '
        'EditarBtn
        '
        Me.EditarBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.EditarBtn.FlatAppearance.BorderSize = 1
        Me.EditarBtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(80, Byte), Integer), CType(CType(80, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.EditarBtn.BackColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(55, Byte), Integer), CType(CType(55, Byte), Integer))
        Me.EditarBtn.ForeColor = System.Drawing.Color.White
        Me.EditarBtn.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
        Me.EditarBtn.Location = New System.Drawing.Point(112, 16)
        Me.EditarBtn.Name = "EditarBtn"
        Me.EditarBtn.Size = New System.Drawing.Size(88, 40)
        Me.EditarBtn.TabIndex = 23
        Me.EditarBtn.Text = "Editar"
        Me.EditarBtn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.EditarBtn.UseVisualStyleBackColor = False
        '
        'GuardarBtn
        '
        Me.GuardarBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GuardarBtn.FlatAppearance.BorderSize = 1
        Me.GuardarBtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(16, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(62, Byte), Integer))
        Me.GuardarBtn.BackColor = System.Drawing.Color.FromArgb(CType(CType(16, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(62, Byte), Integer))
        Me.GuardarBtn.ForeColor = System.Drawing.Color.White
        Me.GuardarBtn.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
        Me.GuardarBtn.Location = New System.Drawing.Point(208, 16)
        Me.GuardarBtn.Name = "GuardarBtn"
        Me.GuardarBtn.Size = New System.Drawing.Size(120, 40)
        Me.GuardarBtn.TabIndex = 24
        Me.GuardarBtn.Text = "Guardar"
        Me.GuardarBtn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.GuardarBtn.UseVisualStyleBackColor = False
        '
        'ModificarBtn
        '
        Me.ModificarBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ModificarBtn.FlatAppearance.BorderSize = 1
        Me.ModificarBtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.ModificarBtn.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.ModificarBtn.ForeColor = System.Drawing.Color.Black
        Me.ModificarBtn.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
        Me.ModificarBtn.Location = New System.Drawing.Point(208, 16)
        Me.ModificarBtn.Name = "ModificarBtn"
        Me.ModificarBtn.Size = New System.Drawing.Size(120, 40)
        Me.ModificarBtn.TabIndex = 27
        Me.ModificarBtn.Text = "Modificar"
        Me.ModificarBtn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ModificarBtn.UseVisualStyleBackColor = False
        '
        'EliminarBtn
        '
        Me.EliminarBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.EliminarBtn.FlatAppearance.BorderSize = 1
        Me.EliminarBtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(232, Byte), Integer), CType(CType(17, Byte), Integer), CType(CType(35, Byte), Integer))
        Me.EliminarBtn.BackColor = System.Drawing.Color.FromArgb(CType(CType(232, Byte), Integer), CType(CType(17, Byte), Integer), CType(CType(35, Byte), Integer))
        Me.EliminarBtn.ForeColor = System.Drawing.Color.White
        Me.EliminarBtn.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
        Me.EliminarBtn.Location = New System.Drawing.Point(568, 16)
        Me.EliminarBtn.Name = "EliminarBtn"
        Me.EliminarBtn.Size = New System.Drawing.Size(88, 40)
        Me.EliminarBtn.TabIndex = 25
        Me.EliminarBtn.Text = "Eliminar"
        Me.EliminarBtn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.EliminarBtn.UseVisualStyleBackColor = False
        '
        'CancelarBtn
        '
        Me.CancelarBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CancelarBtn.FlatAppearance.BorderSize = 1
        Me.CancelarBtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(80, Byte), Integer), CType(CType(80, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.CancelarBtn.BackColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(55, Byte), Integer), CType(CType(55, Byte), Integer))
        Me.CancelarBtn.ForeColor = System.Drawing.Color.White
        Me.CancelarBtn.Font = New System.Drawing.Font("Segoe UI", 9.5!, System.Drawing.FontStyle.Bold)
        Me.CancelarBtn.Location = New System.Drawing.Point(664, 16)
        Me.CancelarBtn.Name = "CancelarBtn"
        Me.CancelarBtn.Size = New System.Drawing.Size(88, 40)
        Me.CancelarBtn.TabIndex = 26
        Me.CancelarBtn.Text = "Cancelar"
        Me.CancelarBtn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CancelarBtn.UseVisualStyleBackColor = False
        '
        'PanelP
        '
        Me.PanelP.BackColor = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(44, Byte), Integer), CType(CType(44, Byte), Integer))
        Me.PanelP.Controls.Add(Me.ButtonX1)
        Me.PanelP.Controls.Add(Me.fechDpk)
        Me.PanelP.Controls.Add(Me.statTbx)
        Me.PanelP.Controls.Add(Me.tipoTbx)
        Me.PanelP.Controls.Add(Me.LabelX4)
        Me.PanelP.Controls.Add(Me.LabelX10)
        Me.PanelP.Controls.Add(Me.LabelX3)
        Me.PanelP.Controls.Add(Me.LabelX8)
        Me.PanelP.Controls.Add(Me.LabelX2)
        Me.PanelP.Controls.Add(Me.ApelTbx)
        Me.PanelP.Controls.Add(Me.nombTbx)
        Me.PanelP.Controls.Add(Me.LabelX7)
        Me.PanelP.Controls.Add(Me.clavTbx)
        Me.PanelP.Controls.Add(Me.LabelX1)
        Me.PanelP.Controls.Add(Me.usuaTbx)
        Me.PanelP.Location = New System.Drawing.Point(16, 72)
        Me.PanelP.Name = "PanelP"
        Me.PanelP.Size = New System.Drawing.Size(768, 200)
        Me.PanelP.TabIndex = 30
        '
        'ButtonX1
        '
        Me.ButtonX1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonX1.FlatAppearance.BorderSize = 0
        Me.ButtonX1.BackColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(55, Byte), Integer), CType(CType(55, Byte), Integer))
        Me.ButtonX1.ForeColor = System.Drawing.Color.White
        Me.ButtonX1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ButtonX1.Location = New System.Drawing.Point(686, 52)
        Me.ButtonX1.Name = "ButtonX1"
        Me.ButtonX1.Size = New System.Drawing.Size(34, 32)
        Me.ButtonX1.TabIndex = 32
        Me.ButtonX1.Text = "👁"
        Me.ButtonX1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonX1.UseVisualStyleBackColor = False
        '
        'fechDpk
        '
        Me.fechDpk.Font = New System.Drawing.Font("Segoe UI", 11.0!)
        Me.fechDpk.Format = System.Windows.Forms.DateTimePickerFormat.Short
        Me.fechDpk.Location = New System.Drawing.Point(100, 96)
        Me.fechDpk.Name = "fechDpk"
        Me.fechDpk.Size = New System.Drawing.Size(260, 27)
        Me.fechDpk.TabIndex = 4
        '
        'statTbx
        '
        Me.statTbx.BackColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(55, Byte), Integer), CType(CType(55, Byte), Integer))
        Me.statTbx.ForeColor = System.Drawing.Color.White
        Me.statTbx.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.statTbx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.statTbx.Font = New System.Drawing.Font("Segoe UI", 11.0!)
        Me.statTbx.FormattingEnabled = True
        Me.statTbx.Items.AddRange(New Object() {"ACTIVO", "INACTIVO"})
        Me.statTbx.Location = New System.Drawing.Point(460, 136)
        Me.statTbx.Name = "statTbx"
        Me.statTbx.Size = New System.Drawing.Size(260, 28)
        Me.statTbx.TabIndex = 6
        '
        'tipoTbx
        '
        Me.tipoTbx.BackColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(55, Byte), Integer), CType(CType(55, Byte), Integer))
        Me.tipoTbx.ForeColor = System.Drawing.Color.White
        Me.tipoTbx.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.tipoTbx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.tipoTbx.Font = New System.Drawing.Font("Segoe UI", 11.0!)
        Me.tipoTbx.FormattingEnabled = True
        Me.tipoTbx.Items.AddRange(New Object() {"SUPERADMIN", "ADMIN", "USUARIO", "TEST"})
        Me.tipoTbx.Location = New System.Drawing.Point(100, 136)
        Me.tipoTbx.Name = "tipoTbx"
        Me.tipoTbx.Size = New System.Drawing.Size(260, 28)
        Me.tipoTbx.TabIndex = 5
        '
        'LabelX4
        '
        Me.LabelX4.AutoSize = False
        Me.LabelX4.Font = New System.Drawing.Font("Segoe UI Semibold", 11.0!, System.Drawing.FontStyle.Bold)
        Me.LabelX4.ForeColor = System.Drawing.Color.White
        Me.LabelX4.Location = New System.Drawing.Point(16, 138)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Size = New System.Drawing.Size(80, 24)
        Me.LabelX4.TabIndex = 30
        Me.LabelX4.Text = "Tipo"
        Me.LabelX4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LabelX10
        '
        Me.LabelX10.AutoSize = False
        Me.LabelX10.Font = New System.Drawing.Font("Segoe UI Semibold", 11.0!, System.Drawing.FontStyle.Bold)
        Me.LabelX10.ForeColor = System.Drawing.Color.White
        Me.LabelX10.Location = New System.Drawing.Point(376, 56)
        Me.LabelX10.Name = "LabelX10"
        Me.LabelX10.Size = New System.Drawing.Size(80, 24)
        Me.LabelX10.TabIndex = 30
        Me.LabelX10.Text = "Clave"
        Me.LabelX10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LabelX3
        '
        Me.LabelX3.AutoSize = False
        Me.LabelX3.Font = New System.Drawing.Font("Segoe UI Semibold", 11.0!, System.Drawing.FontStyle.Bold)
        Me.LabelX3.ForeColor = System.Drawing.Color.White
        Me.LabelX3.Location = New System.Drawing.Point(16, 56)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(80, 24)
        Me.LabelX3.TabIndex = 30
        Me.LabelX3.Text = "Usuario"
        Me.LabelX3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LabelX8
        '
        Me.LabelX8.AutoSize = False
        Me.LabelX8.Font = New System.Drawing.Font("Segoe UI Semibold", 11.0!, System.Drawing.FontStyle.Bold)
        Me.LabelX8.ForeColor = System.Drawing.Color.White
        Me.LabelX8.Location = New System.Drawing.Point(376, 138)
        Me.LabelX8.Name = "LabelX8"
        Me.LabelX8.Size = New System.Drawing.Size(80, 24)
        Me.LabelX8.TabIndex = 31
        Me.LabelX8.Text = "Estatus"
        Me.LabelX8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LabelX2
        '
        Me.LabelX2.AutoSize = False
        Me.LabelX2.Font = New System.Drawing.Font("Segoe UI Semibold", 11.0!, System.Drawing.FontStyle.Bold)
        Me.LabelX2.ForeColor = System.Drawing.Color.White
        Me.LabelX2.Location = New System.Drawing.Point(16, 98)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(80, 24)
        Me.LabelX2.TabIndex = 31
        Me.LabelX2.Text = "Fecha"
        Me.LabelX2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ApelTbx
        '
        Me.ApelTbx.BackColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(55, Byte), Integer), CType(CType(55, Byte), Integer))
        Me.ApelTbx.ForeColor = System.Drawing.Color.White
        Me.ApelTbx.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ApelTbx.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.ApelTbx.Font = New System.Drawing.Font("Segoe UI", 11.0!)
        Me.ApelTbx.Location = New System.Drawing.Point(460, 12)
        Me.ApelTbx.MaxLength = 30
        Me.ApelTbx.Name = "ApelTbx"
        Me.ApelTbx.Size = New System.Drawing.Size(260, 27)
        Me.ApelTbx.TabIndex = 1
        '
        'nombTbx
        '
        Me.nombTbx.BackColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(55, Byte), Integer), CType(CType(55, Byte), Integer))
        Me.nombTbx.ForeColor = System.Drawing.Color.White
        Me.nombTbx.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nombTbx.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.nombTbx.Font = New System.Drawing.Font("Segoe UI", 11.0!)
        Me.nombTbx.Location = New System.Drawing.Point(100, 12)
        Me.nombTbx.MaxLength = 30
        Me.nombTbx.Name = "nombTbx"
        Me.nombTbx.Size = New System.Drawing.Size(260, 27)
        Me.nombTbx.TabIndex = 0
        '
        'LabelX7
        '
        Me.LabelX7.AutoSize = False
        Me.LabelX7.Font = New System.Drawing.Font("Segoe UI Semibold", 11.0!, System.Drawing.FontStyle.Bold)
        Me.LabelX7.ForeColor = System.Drawing.Color.White
        Me.LabelX7.Location = New System.Drawing.Point(376, 16)
        Me.LabelX7.Name = "LabelX7"
        Me.LabelX7.Size = New System.Drawing.Size(80, 24)
        Me.LabelX7.TabIndex = 31
        Me.LabelX7.Text = "Apellido"
        Me.LabelX7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'clavTbx
        '
        Me.clavTbx.BackColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(55, Byte), Integer), CType(CType(55, Byte), Integer))
        Me.clavTbx.ForeColor = System.Drawing.Color.White
        Me.clavTbx.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.clavTbx.Font = New System.Drawing.Font("Segoe UI", 11.0!)
        Me.clavTbx.Location = New System.Drawing.Point(460, 52)
        Me.clavTbx.MaxLength = 200
        Me.clavTbx.Name = "clavTbx"
        Me.clavTbx.Size = New System.Drawing.Size(220, 27)
        Me.clavTbx.TabIndex = 3
        Me.clavTbx.UseSystemPasswordChar = True
        '
        'LabelX1
        '
        Me.LabelX1.AutoSize = False
        Me.LabelX1.Font = New System.Drawing.Font("Segoe UI Semibold", 11.0!, System.Drawing.FontStyle.Bold)
        Me.LabelX1.ForeColor = System.Drawing.Color.White
        Me.LabelX1.Location = New System.Drawing.Point(16, 16)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(80, 24)
        Me.LabelX1.TabIndex = 31
        Me.LabelX1.Text = "Nombre"
        Me.LabelX1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'usuaTbx
        '
        Me.usuaTbx.BackColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(55, Byte), Integer), CType(CType(55, Byte), Integer))
        Me.usuaTbx.ForeColor = System.Drawing.Color.White
        Me.usuaTbx.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.usuaTbx.Font = New System.Drawing.Font("Segoe UI", 11.0!)
        Me.usuaTbx.Location = New System.Drawing.Point(100, 52)
        Me.usuaTbx.MaxLength = 20
        Me.usuaTbx.Name = "usuaTbx"
        Me.usuaTbx.Size = New System.Drawing.Size(260, 27)
        Me.usuaTbx.TabIndex = 2
        '
        'AcceDGV
        '
        Me.AcceDGV.AllowUserToAddRows = False
        Me.AcceDGV.AllowUserToDeleteRows = False
        Me.AcceDGV.AllowUserToResizeRows = False
        Me.AcceDGV.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(32, Byte), Integer), CType(CType(32, Byte), Integer))
        Me.AcceDGV.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.AcceDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(44, Byte), Integer), CType(CType(44, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(96, Byte), Integer), CType(CType(205, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.AcceDGV.DefaultCellStyle = DataGridViewCellStyle1
        Me.AcceDGV.GridColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.AcceDGV.Location = New System.Drawing.Point(16, 420)
        Me.AcceDGV.MultiSelect = False
        Me.AcceDGV.Name = "AcceDGV"
        Me.AcceDGV.ReadOnly = True
        Me.AcceDGV.RowHeadersVisible = False
        Me.AcceDGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.AcceDGV.Size = New System.Drawing.Size(768, 416)
        Me.AcceDGV.TabIndex = 31
        '
        'buscartxt
        '
        Me.buscartxt.Location = New System.Drawing.Point(680, 176)
        Me.buscartxt.Name = "buscartxt"
        Me.buscartxt.Size = New System.Drawing.Size(80, 24)
        Me.buscartxt.TabIndex = 32
        Me.buscartxt.Text = "-"
        Me.buscartxt.Visible = False
        '
        'PanelPermisos
        '
        Me.PanelPermisos.BackColor = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(44, Byte), Integer), CType(CType(44, Byte), Integer))
        Me.PanelPermisos.Controls.Add(Me.LblPermisos)
        Me.PanelPermisos.Controls.Add(Me.buscartxt)
        Me.PanelPermisos.Controls.Add(Me.chkCamiones)
        Me.PanelPermisos.Controls.Add(Me.chkPlacas)
        Me.PanelPermisos.Controls.Add(Me.chkTransportistas)
        Me.PanelPermisos.Controls.Add(Me.chkTanque)
        Me.PanelPermisos.Controls.Add(Me.chkEmpresa)
        Me.PanelPermisos.Controls.Add(Me.chkAccesos)
        Me.PanelPermisos.Controls.Add(Me.chkMedicion)
        Me.PanelPermisos.Controls.Add(Me.chkComprobante)
        Me.PanelPermisos.Controls.Add(Me.chkFactura)
        Me.PanelPermisos.Controls.Add(Me.chkPropietario)
        Me.PanelPermisos.Controls.Add(Me.chkConsumo)
        Me.PanelPermisos.Controls.Add(Me.chkReporte)
        Me.PanelPermisos.Controls.Add(Me.chkValorComb)
        Me.PanelPermisos.Controls.Add(Me.chkRutas)
        Me.PanelPermisos.Controls.Add(Me.chkReporteFact)
        Me.PanelPermisos.Location = New System.Drawing.Point(16, 284)
        Me.PanelPermisos.Name = "PanelPermisos"
        Me.PanelPermisos.Size = New System.Drawing.Size(768, 120)
        Me.PanelPermisos.TabIndex = 33
        '
        'LblPermisos
        '
        Me.LblPermisos.AutoSize = True
        Me.LblPermisos.BackColor = System.Drawing.Color.Transparent
        Me.LblPermisos.Font = New System.Drawing.Font("Segoe UI Semibold", 10.0!, System.Drawing.FontStyle.Bold)
        Me.LblPermisos.ForeColor = System.Drawing.Color.FromArgb(CType(CType(96, Byte), Integer), CType(CType(205, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.LblPermisos.Location = New System.Drawing.Point(16, 8)
        Me.LblPermisos.Name = "LblPermisos"
        Me.LblPermisos.Size = New System.Drawing.Size(143, 19)
        Me.LblPermisos.TabIndex = 0
        Me.LblPermisos.Text = "Permisos de Modulos"
        '
        'chkCamiones
        '
        Me.chkCamiones.AutoSize = True
        Me.chkCamiones.BackColor = System.Drawing.Color.Transparent
        Me.chkCamiones.Checked = True
        Me.chkCamiones.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkCamiones.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.chkCamiones.ForeColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.chkCamiones.Location = New System.Drawing.Point(16, 36)
        Me.chkCamiones.Name = "chkCamiones"
        Me.chkCamiones.Size = New System.Drawing.Size(79, 19)
        Me.chkCamiones.TabIndex = 1
        Me.chkCamiones.Tag = "camiones"
        Me.chkCamiones.Text = "Camiones"
        Me.chkCamiones.UseVisualStyleBackColor = False
        '
        'chkPlacas
        '
        Me.chkPlacas.AutoSize = True
        Me.chkPlacas.BackColor = System.Drawing.Color.Transparent
        Me.chkPlacas.Checked = True
        Me.chkPlacas.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkPlacas.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.chkPlacas.ForeColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.chkPlacas.Location = New System.Drawing.Point(166, 36)
        Me.chkPlacas.Name = "chkPlacas"
        Me.chkPlacas.Size = New System.Drawing.Size(59, 19)
        Me.chkPlacas.TabIndex = 2
        Me.chkPlacas.Tag = "placa"
        Me.chkPlacas.Text = "Placas"
        Me.chkPlacas.UseVisualStyleBackColor = False
        '
        'chkTransportistas
        '
        Me.chkTransportistas.AutoSize = True
        Me.chkTransportistas.BackColor = System.Drawing.Color.Transparent
        Me.chkTransportistas.Checked = True
        Me.chkTransportistas.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkTransportistas.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.chkTransportistas.ForeColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.chkTransportistas.Location = New System.Drawing.Point(316, 36)
        Me.chkTransportistas.Name = "chkTransportistas"
        Me.chkTransportistas.Size = New System.Drawing.Size(99, 19)
        Me.chkTransportistas.TabIndex = 3
        Me.chkTransportistas.Tag = "transportistas"
        Me.chkTransportistas.Text = "Transportistas"
        Me.chkTransportistas.UseVisualStyleBackColor = False
        '
        'chkTanque
        '
        Me.chkTanque.AutoSize = True
        Me.chkTanque.BackColor = System.Drawing.Color.Transparent
        Me.chkTanque.Checked = True
        Me.chkTanque.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkTanque.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.chkTanque.ForeColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.chkTanque.Location = New System.Drawing.Point(466, 36)
        Me.chkTanque.Name = "chkTanque"
        Me.chkTanque.Size = New System.Drawing.Size(65, 19)
        Me.chkTanque.TabIndex = 4
        Me.chkTanque.Tag = "tanque"
        Me.chkTanque.Text = "Tanque"
        Me.chkTanque.UseVisualStyleBackColor = False
        '
        'chkEmpresa
        '
        Me.chkEmpresa.AutoSize = True
        Me.chkEmpresa.BackColor = System.Drawing.Color.Transparent
        Me.chkEmpresa.Checked = True
        Me.chkEmpresa.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkEmpresa.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.chkEmpresa.ForeColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.chkEmpresa.Location = New System.Drawing.Point(616, 36)
        Me.chkEmpresa.Name = "chkEmpresa"
        Me.chkEmpresa.Size = New System.Drawing.Size(71, 19)
        Me.chkEmpresa.TabIndex = 5
        Me.chkEmpresa.Tag = "empresa"
        Me.chkEmpresa.Text = "Empresa"
        Me.chkEmpresa.UseVisualStyleBackColor = False
        '
        'chkAccesos
        '
        Me.chkAccesos.AutoSize = True
        Me.chkAccesos.BackColor = System.Drawing.Color.Transparent
        Me.chkAccesos.Checked = True
        Me.chkAccesos.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkAccesos.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.chkAccesos.ForeColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.chkAccesos.Location = New System.Drawing.Point(16, 62)
        Me.chkAccesos.Name = "chkAccesos"
        Me.chkAccesos.Size = New System.Drawing.Size(69, 19)
        Me.chkAccesos.TabIndex = 6
        Me.chkAccesos.Tag = "acceso"
        Me.chkAccesos.Text = "Accesos"
        Me.chkAccesos.UseVisualStyleBackColor = False
        '
        'chkMedicion
        '
        Me.chkMedicion.AutoSize = True
        Me.chkMedicion.BackColor = System.Drawing.Color.Transparent
        Me.chkMedicion.Checked = True
        Me.chkMedicion.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkMedicion.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.chkMedicion.ForeColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.chkMedicion.Location = New System.Drawing.Point(166, 62)
        Me.chkMedicion.Name = "chkMedicion"
        Me.chkMedicion.Size = New System.Drawing.Size(76, 19)
        Me.chkMedicion.TabIndex = 7
        Me.chkMedicion.Tag = "medicion"
        Me.chkMedicion.Text = "Medicion"
        Me.chkMedicion.UseVisualStyleBackColor = False
        '
        'chkComprobante
        '
        Me.chkComprobante.AutoSize = True
        Me.chkComprobante.BackColor = System.Drawing.Color.Transparent
        Me.chkComprobante.Checked = True
        Me.chkComprobante.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkComprobante.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.chkComprobante.ForeColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.chkComprobante.Location = New System.Drawing.Point(316, 62)
        Me.chkComprobante.Name = "chkComprobante"
        Me.chkComprobante.Size = New System.Drawing.Size(100, 19)
        Me.chkComprobante.TabIndex = 8
        Me.chkComprobante.Tag = "comprobante"
        Me.chkComprobante.Text = "Comprobante"
        Me.chkComprobante.UseVisualStyleBackColor = False
        '
        'chkFactura
        '
        Me.chkFactura.AutoSize = True
        Me.chkFactura.BackColor = System.Drawing.Color.Transparent
        Me.chkFactura.Checked = True
        Me.chkFactura.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkFactura.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.chkFactura.ForeColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.chkFactura.Location = New System.Drawing.Point(466, 62)
        Me.chkFactura.Name = "chkFactura"
        Me.chkFactura.Size = New System.Drawing.Size(65, 19)
        Me.chkFactura.TabIndex = 9
        Me.chkFactura.Tag = "factura"
        Me.chkFactura.Text = "Factura"
        Me.chkFactura.UseVisualStyleBackColor = False
        '
        'chkPropietario
        '
        Me.chkPropietario.AutoSize = True
        Me.chkPropietario.BackColor = System.Drawing.Color.Transparent
        Me.chkPropietario.Checked = True
        Me.chkPropietario.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkPropietario.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.chkPropietario.ForeColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.chkPropietario.Location = New System.Drawing.Point(616, 62)
        Me.chkPropietario.Name = "chkPropietario"
        Me.chkPropietario.Size = New System.Drawing.Size(84, 19)
        Me.chkPropietario.TabIndex = 10
        Me.chkPropietario.Tag = "propietario"
        Me.chkPropietario.Text = "Propietario"
        Me.chkPropietario.UseVisualStyleBackColor = False
        '
        'chkConsumo
        '
        Me.chkConsumo.AutoSize = True
        Me.chkConsumo.BackColor = System.Drawing.Color.Transparent
        Me.chkConsumo.Checked = True
        Me.chkConsumo.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkConsumo.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.chkConsumo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.chkConsumo.Location = New System.Drawing.Point(16, 88)
        Me.chkConsumo.Name = "chkConsumo"
        Me.chkConsumo.Size = New System.Drawing.Size(78, 19)
        Me.chkConsumo.TabIndex = 11
        Me.chkConsumo.Tag = "consumo"
        Me.chkConsumo.Text = "Consumo"
        Me.chkConsumo.UseVisualStyleBackColor = False
        '
        'chkReporte
        '
        Me.chkReporte.AutoSize = True
        Me.chkReporte.BackColor = System.Drawing.Color.Transparent
        Me.chkReporte.Checked = True
        Me.chkReporte.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkReporte.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.chkReporte.ForeColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.chkReporte.Location = New System.Drawing.Point(166, 88)
        Me.chkReporte.Name = "chkReporte"
        Me.chkReporte.Size = New System.Drawing.Size(67, 19)
        Me.chkReporte.TabIndex = 12
        Me.chkReporte.Tag = "reporte"
        Me.chkReporte.Text = "Reporte"
        Me.chkReporte.UseVisualStyleBackColor = False
        '
        'chkValorComb
        '
        Me.chkValorComb.AutoSize = True
        Me.chkValorComb.BackColor = System.Drawing.Color.Transparent
        Me.chkValorComb.Checked = True
        Me.chkValorComb.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkValorComb.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.chkValorComb.ForeColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.chkValorComb.Location = New System.Drawing.Point(316, 88)
        Me.chkValorComb.Name = "chkValorComb"
        Me.chkValorComb.Size = New System.Drawing.Size(91, 19)
        Me.chkValorComb.TabIndex = 13
        Me.chkValorComb.Tag = "valorComb"
        Me.chkValorComb.Text = "Valor Comb."
        Me.chkValorComb.UseVisualStyleBackColor = False
        '
        'chkRutas
        '
        Me.chkRutas.AutoSize = True
        Me.chkRutas.BackColor = System.Drawing.Color.Transparent
        Me.chkRutas.Checked = True
        Me.chkRutas.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkRutas.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.chkRutas.ForeColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.chkRutas.Location = New System.Drawing.Point(466, 88)
        Me.chkRutas.Name = "chkRutas"
        Me.chkRutas.Size = New System.Drawing.Size(55, 19)
        Me.chkRutas.TabIndex = 14
        Me.chkRutas.Tag = "rutas"
        Me.chkRutas.Text = "Rutas"
        Me.chkRutas.UseVisualStyleBackColor = False
        '
        'chkReporteFact
        '
        Me.chkReporteFact.AutoSize = True
        Me.chkReporteFact.BackColor = System.Drawing.Color.Transparent
        Me.chkReporteFact.Checked = True
        Me.chkReporteFact.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkReporteFact.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.chkReporteFact.ForeColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.chkReporteFact.Location = New System.Drawing.Point(616, 88)
        Me.chkReporteFact.Name = "chkReporteFact"
        Me.chkReporteFact.Size = New System.Drawing.Size(91, 19)
        Me.chkReporteFact.TabIndex = 15
        Me.chkReporteFact.Tag = "reporteFact"
        Me.chkReporteFact.Text = "Rep. Factura"
        Me.chkReporteFact.UseVisualStyleBackColor = False
        '
        'acceso
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(32, Byte), Integer), CType(CType(32, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(800, 850)
        Me.Controls.Add(Me.PanelPermisos)
        Me.Controls.Add(Me.AcceDGV)
        Me.Controls.Add(Me.PanelP)
        Me.Controls.Add(Me.CancelarBtn)
        Me.Controls.Add(Me.EliminarBtn)
        Me.Controls.Add(Me.EditarBtn)
        Me.Controls.Add(Me.NuevoBtn)
        Me.Controls.Add(Me.GuardarBtn)
        Me.Controls.Add(Me.ModificarBtn)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Name = "acceso"
        Me.Text = "acceso"
        Me.PanelP.ResumeLayout(False)
        Me.PanelP.PerformLayout()
        CType(Me.AcceDGV, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelPermisos.ResumeLayout(False)
        Me.PanelPermisos.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents CancelarBtn As System.Windows.Forms.Button
    Friend WithEvents EliminarBtn As System.Windows.Forms.Button
    Friend WithEvents EditarBtn As System.Windows.Forms.Button
    Friend WithEvents NuevoBtn As System.Windows.Forms.Button
    Friend WithEvents GuardarBtn As System.Windows.Forms.Button
    Friend WithEvents ModificarBtn As System.Windows.Forms.Button
    Friend WithEvents PanelP As System.Windows.Forms.Panel
    Friend WithEvents LabelX4 As System.Windows.Forms.Label
    Friend WithEvents LabelX10 As System.Windows.Forms.Label
    Friend WithEvents LabelX3 As System.Windows.Forms.Label
    Friend WithEvents LabelX8 As System.Windows.Forms.Label
    Friend WithEvents LabelX2 As System.Windows.Forms.Label
    Friend WithEvents ApelTbx As System.Windows.Forms.TextBox
    Friend WithEvents nombTbx As System.Windows.Forms.TextBox
    Friend WithEvents LabelX7 As System.Windows.Forms.Label
    Friend WithEvents clavTbx As System.Windows.Forms.TextBox
    Friend WithEvents LabelX1 As System.Windows.Forms.Label
    Friend WithEvents usuaTbx As System.Windows.Forms.TextBox
    Friend WithEvents statTbx As System.Windows.Forms.ComboBox
    Friend WithEvents tipoTbx As System.Windows.Forms.ComboBox
    Friend WithEvents fechDpk As System.Windows.Forms.DateTimePicker
    Friend WithEvents AcceDGV As System.Windows.Forms.DataGridView
    Friend WithEvents buscartxt As System.Windows.Forms.Label
    Friend WithEvents ButtonX1 As System.Windows.Forms.Button
    Friend WithEvents PanelPermisos As System.Windows.Forms.Panel
    Friend WithEvents LblPermisos As System.Windows.Forms.Label
    Friend WithEvents chkCamiones As System.Windows.Forms.CheckBox
    Friend WithEvents chkPlacas As System.Windows.Forms.CheckBox
    Friend WithEvents chkTransportistas As System.Windows.Forms.CheckBox
    Friend WithEvents chkTanque As System.Windows.Forms.CheckBox
    Friend WithEvents chkEmpresa As System.Windows.Forms.CheckBox
    Friend WithEvents chkAccesos As System.Windows.Forms.CheckBox
    Friend WithEvents chkMedicion As System.Windows.Forms.CheckBox
    Friend WithEvents chkComprobante As System.Windows.Forms.CheckBox
    Friend WithEvents chkFactura As System.Windows.Forms.CheckBox
    Friend WithEvents chkPropietario As System.Windows.Forms.CheckBox
    Friend WithEvents chkConsumo As System.Windows.Forms.CheckBox
    Friend WithEvents chkReporte As System.Windows.Forms.CheckBox
    Friend WithEvents chkValorComb As System.Windows.Forms.CheckBox
    Friend WithEvents chkRutas As System.Windows.Forms.CheckBox
    Friend WithEvents chkReporteFact As System.Windows.Forms.CheckBox
End Class
