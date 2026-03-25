Imports System.Data
Imports MySql.Data.MySqlClient
Imports MySql.Data
Public Class comprobantePlus
    Dim cm As New MySqlCommand
    Dim guardar As New MySqlCommand
    Dim adaptador As New MySqlDataAdapter
    Dim datos As DataSet
    Dim dr As MySqlDataReader
    Private m_tmr As Timer
    Public img As Image
    Dim con As New MySqlConnection

    ' Estado de anulacion del registro seleccionado
    Private registroAnulado As Boolean = False

    ' Bandera para evitar cascada de eventos TextChanged
    Private actualizandoProgramaticamente As Boolean = False
    ' Bandera para evitar que los filtros se ejecuten durante la carga
    Private cargandoFormulario As Boolean = True

    ' Cache local para evitar consultas repetidas a la nube
    Private cachePlacasPorPropietario As New Dictionary(Of String, List(Of String))
    Private cachePlacasPorCodigo As New Dictionary(Of String, List(Of String))
    Private cachePropietarioPorCodigo As New Dictionary(Of String, String)
    Private cacheCodigoPorPropietario As New Dictionary(Of String, String)
    Private cachePlacaInfo As New Dictionary(Of String, String())

    Private Sub comprobantePlus_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        On Error Resume Next

        cargandoFormulario = True

        System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("es-HN")
        System.Threading.Thread.CurrentThread.CurrentCulture.DateTimeFormat.ShortDatePattern = "yyyy/MM/dd"
        System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencyDecimalSeparator = "."
        System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencyGroupSeparator = ","
        System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator = "."
        System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.NumberGroupSeparator = ","

        conectar()
        EnsureAnuladoColumn()
        EnsureLogTable()

        cargarDespachadores()

        act()
        listadoCamDgv()

        cargandoFormulario = False
        EstilizarDataGridView(CamDGV)

        PanelP.Enabled = False

        Rutas()
        CargarCachePlacas()
        PConductores()

        cargarNivelTanque()

        AddHandler CamDGV.CellFormatting, AddressOf CamDGV_CellFormatting

    End Sub

    Private Sub CamDGV_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs)
        If e.RowIndex < 0 Then Return
        Dim dgv As DataGridView = CType(sender, DataGridView)
        If Not dgv.Columns.Contains("anulado") Then Return

        Dim anuladoVal As Object = dgv.Rows(e.RowIndex).Cells("anulado").Value
        If anuladoVal IsNot Nothing AndAlso anuladoVal IsNot DBNull.Value AndAlso Convert.ToInt32(anuladoVal) = 1 Then
            e.CellStyle.BackColor = Color.FromArgb(60, 60, 60)
            e.CellStyle.ForeColor = Color.FromArgb(180, 180, 180)
            e.CellStyle.Font = New Font(dgv.Font, FontStyle.Strikeout)
            e.CellStyle.SelectionBackColor = Color.FromArgb(80, 80, 80)
            e.CellStyle.SelectionForeColor = Color.FromArgb(200, 200, 200)
        End If
    End Sub

    Private Sub act()
        Me.NuevoBtn.Enabled = True
        Me.EditarBtn.Enabled = False
        Me.GuardarBtn.Enabled = False
        Me.ModificarBtn.Enabled = False
        Me.ModificarBtn.Visible = False
        Me.GuardarBtn.Visible = True
        Me.CancelarBtn.Enabled = False
        Me.EliminarBtn.Enabled = False
        Me.AnularBtn.Enabled = False
        Me.AnularBtn.Text = "Anular"
        If ModuloConexion.EsSoloLectura() Then NuevoBtn.Enabled = False
    End Sub
    Private Sub conectar()
        con = ModuloConexion.ObtenerConexion()
        Try
            If con.State = ConnectionState.Closed Then
                con.Open()
            End If
            MessageBox.Show("El sistema esta conectado", "Combustible")
        Catch ex As Exception
            MsgBox("No se conecto por: " & ex.Message)
        End Try
    End Sub

    Private Sub EnsureAnuladoColumn()
        Try
            Using conLocal As MySqlConnection = ModuloConexion.ObtenerConexion()
                conLocal.Open()
                Using cmd As New MySqlCommand("ALTER TABLE comprobante ADD COLUMN anulado TINYINT(1) NOT NULL DEFAULT 0", conLocal)
                    cmd.ExecuteNonQuery()
                End Using
            End Using
        Catch
            ' Columna ya existe
        End Try
    End Sub

    ' ============ LOG DE EVENTOS ============
    Private Sub EnsureLogTable()
        Try
            Using conLocal As MySqlConnection = ModuloConexion.ObtenerConexion()
                conLocal.Open()
                Dim sql As String = "CREATE TABLE IF NOT EXISTS log_comprobante (" &
                    "id INT AUTO_INCREMENT PRIMARY KEY, " &
                    "idcprbnt VARCHAR(20), " &
                    "accion VARCHAR(50) NOT NULL, " &
                    "usuario VARCHAR(100), " &
                    "detalle TEXT, " &
                    "fecha_hora DATETIME DEFAULT CURRENT_TIMESTAMP)"
                Using cmd As New MySqlCommand(sql, conLocal)
                    cmd.ExecuteNonQuery()
                End Using
            End Using
        Catch
        End Try
    End Sub

    Private Sub RegistrarLog(accion As String, idcprbnt As String, detalle As String)
        Try
            Using conLocal As MySqlConnection = ModuloConexion.ObtenerConexion()
                conLocal.Open()
                Using cmd As New MySqlCommand("INSERT INTO log_comprobante (idcprbnt, accion, usuario, detalle) VALUES(@idcprbnt, @accion, @usuario, @detalle)", conLocal)
                    cmd.Parameters.AddWithValue("@idcprbnt", idcprbnt)
                    cmd.Parameters.AddWithValue("@accion", accion)
                    cmd.Parameters.AddWithValue("@usuario", ModuloConexion.DespachadorSesion)
                    cmd.Parameters.AddWithValue("@detalle", detalle)
                    cmd.ExecuteNonQuery()
                End Using
            End Using
        Catch
        End Try
    End Sub

    Private Sub listadoCamDgvPorFecha(fecha As Date)
        Try
            If con.State = ConnectionState.Closed Then con.Open()

            Dim table As New DataTable()
            Dim sql As String = "SELECT idcprbnt, nCompro, nBoleta, DATE_FORMAT(fecha, '%d/%m/%Y') AS fecha, nombDesp, propCbz, placaCbz, periodo, semana, ruta, galDesp, valor, total, COALESCE(anulado, 0) AS anulado FROM comprobante WHERE DATE(fecha) = @fecha ORDER BY nCompro DESC"
            Using cmd As New MySqlCommand(sql, con)
                cmd.Parameters.AddWithValue("@fecha", fecha.ToString("yyyy-MM-dd"))
                Dim adapter As New MySqlDataAdapter(cmd)
                adapter.Fill(table)
            End Using

            CamDGV.DataSource = table
            ListadoD()

            Dim totalRegistros As Integer = 0
            Dim totalGalones As Double = 0
            Dim totalVenta As Double = 0
            For Each row As DataRow In table.Rows
                Dim esAnulado As Boolean = (row.Table.Columns.Contains("anulado") AndAlso row("anulado") IsNot DBNull.Value AndAlso Convert.ToInt32(row("anulado")) = 1)
                If Not esAnulado Then
                    totalRegistros += 1
                    If row("galDesp") IsNot DBNull.Value Then totalGalones += Convert.ToDouble(row("galDesp"))
                    If row("total") IsNot DBNull.Value Then totalVenta += Convert.ToDouble(row("total"))
                End If
            Next

            lblTotales.Text = String.Format("Registros: {0}  |  Total Galones: {1:N2}", totalRegistros, totalGalones)
            totVtalb.Text = String.Format("Total Venta: L. {0:N2}", totalVenta)

        Catch ex As Exception
            MessageBox.Show("Error al cargar datos: " & ex.Message, "Error")
        Finally
            If con.State = ConnectionState.Open Then con.Close()
        End Try
    End Sub

    Private Sub listadoCamDgv()
        Try
            If con.State = ConnectionState.Closed Then con.Open()

            Dim table As New DataTable()
            Dim adaptadoListado As New MySqlDataAdapter("SELECT idcprbnt, nCompro, nBoleta, DATE_FORMAT(fecha, '%d/%m/%Y') AS fecha, nombDesp, propCbz, placaCbz, periodo, semana, ruta, galDesp, valor, total, COALESCE(anulado, 0) AS anulado FROM comprobante ORDER BY fecha DESC, nCompro DESC", con)
            adaptadoListado.Fill(table)

            CamDGV.DataSource = table
            ListadoD()

            Dim totalRegistros As Integer = 0
            Dim totalGalones As Double = 0
            Dim totalVenta As Double = 0
            For Each row As DataRow In table.Rows
                Dim esAnulado As Boolean = (row.Table.Columns.Contains("anulado") AndAlso row("anulado") IsNot DBNull.Value AndAlso Convert.ToInt32(row("anulado")) = 1)
                If Not esAnulado Then
                    totalRegistros += 1
                    If row("galDesp") IsNot DBNull.Value Then totalGalones += Convert.ToDouble(row("galDesp"))
                    If row("total") IsNot DBNull.Value Then totalVenta += Convert.ToDouble(row("total"))
                End If
            Next

            lblTotales.Text = String.Format("Registros: {0}  |  Total Galones: {1:N2}", totalRegistros, totalGalones)
            totVtalb.Text = String.Format("Total Venta: L. {0:N2}", totalVenta)

        Catch ex As Exception
            MessageBox.Show("Error al cargar datos: " & ex.Message, "Error")
        Finally
            If con.State = ConnectionState.Open Then con.Close()
        End Try
    End Sub

    Private Sub ListadoD()
        If CamDGV.Columns.Count < 10 Then Exit Sub

        CamDGV.Columns(0).HeaderText = "Id"
        CamDGV.Columns(0).Width = 1

        CamDGV.Columns(1).HeaderText = "Comprobante"
        CamDGV.Columns(1).Width = 85

        CamDGV.Columns(2).HeaderText = "Boleta"
        CamDGV.Columns(2).Width = 70

        CamDGV.Columns(3).HeaderText = "Fecha"
        CamDGV.Columns(3).Width = 85

        CamDGV.Columns(4).HeaderText = "Despachador"
        CamDGV.Columns(4).Width = 160

        CamDGV.Columns(5).HeaderText = "Propietario"
        CamDGV.Columns(5).Width = 200

        CamDGV.Columns(6).HeaderText = "Placa"
        CamDGV.Columns(6).Width = 85

        CamDGV.Columns(7).HeaderText = "Per"
        CamDGV.Columns(7).Width = 40

        CamDGV.Columns(8).HeaderText = "Sem"
        CamDGV.Columns(8).Width = 40

        CamDGV.Columns(9).HeaderText = "Ruta"
        CamDGV.Columns(9).Width = 250

        If CamDGV.Columns.Count > 10 Then CamDGV.Columns(10).Visible = False
        If CamDGV.Columns.Count > 11 Then CamDGV.Columns(11).Visible = False
        If CamDGV.Columns.Count > 12 Then CamDGV.Columns(12).Visible = False
        If CamDGV.Columns.Count > 13 Then CamDGV.Columns(13).Visible = False
    End Sub

    Sub limpiar()
        Me.nComproTb.Text = ""
        Me.nBoletaTb.Text = ""
        Me.galDespTb.Text = ""
        Me.valorTb.Text = ""
        Me.placaCbzTb.Text = ""
        Me.nConteTb.Text = ""
        Me.propCbzTb.Text = ""
        Me.rutaTb.Text = ""
        Me.nombCondTb.Text = ""
        Me.nombDespTb.Text = ""
        Me.fechaPkd.Text = ""
        Me.periodoTb.Text = ""
        Me.semanaTb.Text = ""
        Me.proxSemTb.Text = ""
        Me.codiPropTb.Text = ""
        Me.pLetras.Text = ""
    End Sub

    Private Sub NuevoBtn_Click(sender As Object, e As EventArgs) Handles NuevoBtn.Click
        Try
            If con Is Nothing OrElse con.State = ConnectionState.Broken Then
                con = ModuloConexion.ObtenerConexion()
            End If
            If con.State = ConnectionState.Closed Then con.Open()

            actualizandoProgramaticamente = True
            limpiar()

            nombDespTb.Text = ModuloConexion.DespachadorSesion
            periodoTb.Text = ModuloConexion.PeriodoSesion
            semanaTb.Text = ModuloConexion.SemanaSesion
            actualizandoProgramaticamente = False

            Try
                Dim sqlValor As String = "SELECT valorCombustible FROM valorComb WHERE activo = 1 ORDER BY fecha DESC LIMIT 1"
                Using cmdValor As New MySqlCommand(sqlValor, con)
                    Dim resultado = cmdValor.ExecuteScalar()
                    If resultado IsNot Nothing AndAlso Not IsDBNull(resultado) Then
                        valorTb.Text = Convert.ToDecimal(resultado).ToString("N2")
                    End If
                End Using
            Catch
            End Try

            Dim ultimo As Integer = 0
            Dim query As String = "SELECT MAX(CAST(nCompro AS UNSIGNED)) AS maxCompro FROM comprobante"

            Using cmd As New MySqlCommand(query, con)
                Dim resultado = cmd.ExecuteScalar()
                If resultado IsNot Nothing AndAlso Not IsDBNull(resultado) Then
                    Integer.TryParse(resultado.ToString(), ultimo)
                End If
            End Using

            If ultimo > 0 Then
                nComproTb.Text = (ultimo + 1).ToString()
            Else
                nComproTb.Text = "1"
            End If

            amplitud()

        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        Finally
            If con.State <> ConnectionState.Closed Then con.Close()
        End Try

        PanelP.Enabled = True
        GuardarBtn.Enabled = True
        CamDGV.Enabled = False
        CancelarBtn.Enabled = True
        NuevoBtn.Enabled = False
        fechaPkd.Text = Today
        galDespTb.Focus()
    End Sub

    Private Sub EditarBtn_Click(sender As Object, e As EventArgs) Handles EditarBtn.Click
        PanelP.Enabled = True
        Me.CamDGV.Enabled = False
        Me.GuardarBtn.Enabled = False
        Me.GuardarBtn.Visible = False
        Me.ModificarBtn.Enabled = True
        Me.ModificarBtn.Visible = True
        Me.EditarBtn.Enabled = False
        Me.CancelarBtn.Enabled = True
        Me.NuevoBtn.Enabled = False
        Me.EliminarBtn.Enabled = False
    End Sub

    Private Sub GuardarBtn_Click(sender As Object, e As EventArgs) Handles GuardarBtn.Click
        If con.State = ConnectionState.Closed Then
            con.Open()
        End If

        Dim fe As Date = fechaPkd.Value.ToString("yyyy-MM-dd")

        Dim combD As Double = 0
        Double.TryParse(galDespTb.Text, combD)

        Dim valorC As Double = 0
        Double.TryParse(valorTb.Text, valorC)

        Try
            Dim totalVenta As Double = combD * valorC

            guardar = New MySqlCommand("INSERT INTO comprobante (nCompro, nBoleta, galDesp, valor, total, placaCbz, nConte, propCbz, ruta, nombCond, nombDesp, fecha, periodo, semana, proxSem, codiProp, turno)" & Chr(13) &
            "VALUES(@nCompro, @nBoleta, @galDesp, @valor, @total, @placaCbz, @nConte, @propCbz, @ruta, @nombCond, @nombDesp, @fecha, @periodo, @semana, @proxSem, @codiProp, @turno)", con)

            guardar.Parameters.AddWithValue("@nCompro", nComproTb.Text)
            guardar.Parameters.AddWithValue("@nBoleta", nBoletaTb.Text)
            guardar.Parameters.AddWithValue("@galDesp", combD)
            guardar.Parameters.AddWithValue("@valor", valorC)
            guardar.Parameters.AddWithValue("@total", totalVenta)
            guardar.Parameters.AddWithValue("@placaCbz", placaCbzTb.Text)
            guardar.Parameters.AddWithValue("@nConte", nConteTb.Text)
            guardar.Parameters.AddWithValue("@propCbz", propCbzTb.Text)
            guardar.Parameters.AddWithValue("@ruta", rutaTb.Text)
            guardar.Parameters.AddWithValue("@nombCond", nombCondTb.Text)
            guardar.Parameters.AddWithValue("@nombDesp", nombDespTb.Text)
            guardar.Parameters.AddWithValue("@fecha", fe)
            guardar.Parameters.AddWithValue("@periodo", periodoTb.Text)
            guardar.Parameters.AddWithValue("@semana", semanaTb.Text)
            guardar.Parameters.AddWithValue("@proxSem", proxSemTb.Text)
            guardar.Parameters.AddWithValue("@codiProp", codiPropTb.Text)
            guardar.Parameters.AddWithValue("@turno", If(ModuloConexion.TurnoSesion <> "", ModuloConexion.TurnoSesion, CObj(DBNull.Value)))

            If placaCbzTb.Text <> "" Then
                guardar.ExecuteNonQuery()
                RegistrarLog("CREAR", nComproTb.Text, "Placa: " & placaCbzTb.Text & " | Gal: " & galDespTb.Text & " | Prop: " & propCbzTb.Text)
                MsgBox("Registro almacenado. Se procedera a imprimir.")

                PrintComprobante.Print()
                PrintDocumento.Print()

                actualizandoProgramaticamente = True
                limpiar()

                nombDespTb.Text = ModuloConexion.DespachadorSesion
                periodoTb.Text = ModuloConexion.PeriodoSesion
                semanaTb.Text = ModuloConexion.SemanaSesion
                actualizandoProgramaticamente = False

                act()
                CamDGV.Enabled = True
                listadoCamDgvPorFecha(fe)

                actualizarTanquemed()
                cargarNivelTanque()
            Else
                MessageBox.Show("La casilla de Placa debe de ser llenada", "Combustible")
            End If

        Catch ex As Exception
            MsgBox("Elemento no pudo se almacenado", ex.StackTrace)
        End Try
    End Sub

    Private Sub amplitud()
        Dim tam As String = nComproTb.Text
        nComproTb.Text = tam.PadLeft(8, "0"c)
    End Sub

    Private Sub ModificarBtn_Click(sender As Object, e As EventArgs) Handles ModificarBtn.Click
        actual()
        act()
        PanelP.Enabled = False
        CamDGV.Enabled = True
        Me.GuardarBtn.Visible = True
        listadoCamDgv()

        actualizarTanquemed()
        cargarNivelTanque()
    End Sub

    Public Sub actual()
        Try
            If con.State = ConnectionState.Closed Then
                con.Open()
            End If

            Dim fe As Date = fechaPkd.Value.ToString("yyyy-MM-dd")
            galDespTb.Text = galDespTb.Text.Replace(",", "")
            valorTb.Text = valorTb.Text.Replace(",", "")

            Dim combD As Double = 0
            Dim valorC As Double = 0
            Double.TryParse(galDespTb.Text, combD)
            Double.TryParse(valorTb.Text, valorC)
            Dim totalVenta As Double = combD * valorC

            Dim actualizar As String = "UPDATE comprobante SET nCompro = @nCompro, nBoleta = @nBoleta, galDesp = @galDesp, valor = @valor, total = @total, placaCbz = @placaCbz, nConte = @nConte, propCbz = @propCbz, ruta = @ruta, nombCond = @nombCond, nombDesp = @nombDesp, fecha = @fecha, periodo = @periodo, semana = @semana, proxSem = @proxSem, codiProp = @codiProp, turno = @turno WHERE idcprbnt = @idcprbnt"

            Using cmd As New MySqlCommand(actualizar, con)
                cmd.Parameters.AddWithValue("@nCompro", nComproTb.Text)
                cmd.Parameters.AddWithValue("@nBoleta", nBoletaTb.Text)
                cmd.Parameters.AddWithValue("@galDesp", combD)
                cmd.Parameters.AddWithValue("@valor", valorC)
                cmd.Parameters.AddWithValue("@total", totalVenta)
                cmd.Parameters.AddWithValue("@placaCbz", placaCbzTb.Text)
                cmd.Parameters.AddWithValue("@nConte", nConteTb.Text)
                cmd.Parameters.AddWithValue("@propCbz", propCbzTb.Text)
                cmd.Parameters.AddWithValue("@ruta", rutaTb.Text)
                cmd.Parameters.AddWithValue("@nombCond", nombCondTb.Text)
                cmd.Parameters.AddWithValue("@nombDesp", nombDespTb.Text)
                cmd.Parameters.AddWithValue("@fecha", fe)
                cmd.Parameters.AddWithValue("@periodo", periodoTb.Text)
                cmd.Parameters.AddWithValue("@semana", semanaTb.Text)
                cmd.Parameters.AddWithValue("@proxSem", proxSemTb.Text)
                cmd.Parameters.AddWithValue("@codiProp", codiPropTb.Text)
                cmd.Parameters.AddWithValue("@turno", If(ModuloConexion.TurnoSesion <> "", ModuloConexion.TurnoSesion, CObj(DBNull.Value)))
                cmd.Parameters.AddWithValue("@idcprbnt", buscartxt.Text)
                cmd.ExecuteNonQuery()
            End Using
            RegistrarLog("EDITAR", buscartxt.Text, "Placa: " & placaCbzTb.Text & " | Gal: " & galDespTb.Text & " | Prop: " & propCbzTb.Text)
            MsgBox("Registo Actualizado")
        Catch ex As Exception
            MessageBox.Show("Error al actualizar: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub EliminarBtn_Click(sender As Object, e As EventArgs) Handles EliminarBtn.Click
        Try
            If buscartxt.Text = "" OrElse buscartxt.Text = "-" Then
                MessageBox.Show("Seleccione un registro para eliminar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            Dim opc As DialogResult = MessageBox.Show("Desea Eliminar este registro permanentemente?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If opc = DialogResult.Yes Then
                Using conLocal As MySqlConnection = ModuloConexion.ObtenerConexion()
                    conLocal.Open()
                    Using eli As New MySqlCommand("DELETE FROM comprobante WHERE idcprbnt = @id", conLocal)
                        eli.Parameters.AddWithValue("@id", buscartxt.Text)
                        eli.ExecuteNonQuery()
                    End Using
                End Using

                RegistrarLog("ELIMINAR", buscartxt.Text, "Placa: " & placaCbzTb.Text & " | Prop: " & propCbzTb.Text)
                MessageBox.Show("Registro eliminado correctamente.", "Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Information)

                limpiar()
                act()
                PanelP.Enabled = False
                CamDGV.Enabled = True
                listadoCamDgv()

                actualizarTanquemed()
                cargarNivelTanque()
            End If
        Catch ex As Exception
            MessageBox.Show("Error al eliminar: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
    End Sub

    Private Sub AnularBtn_Click(sender As Object, e As EventArgs) Handles AnularBtn.Click
        Try
            If buscartxt.Text = "" OrElse buscartxt.Text = "-" Then
                MessageBox.Show("Seleccione un registro.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            If registroAnulado Then
                Dim tipoUsr As String = ModuloConexion.TipoUsuarioSesion.ToUpper()
                If tipoUsr <> "ADMIN" AndAlso tipoUsr <> "SUPERADMIN" Then
                    MessageBox.Show("Solo un usuario ADMIN puede quitar la anulacion.", "Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return
                End If

                Dim opc As DialogResult = MessageBox.Show("Desea quitar la anulacion de este comprobante?" & vbCrLf &
                    "El registro volvera a sumar en reportes y calculos.",
                    "Desanular Comprobante", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

                If opc = DialogResult.Yes Then
                    Using conLocal As MySqlConnection = ModuloConexion.ObtenerConexion()
                        conLocal.Open()
                        Using cmd As New MySqlCommand("UPDATE comprobante SET anulado = 0 WHERE idcprbnt = @id", conLocal)
                            cmd.Parameters.AddWithValue("@id", buscartxt.Text)
                            cmd.ExecuteNonQuery()
                        End Using
                    End Using

                    RegistrarLog("DESANULAR", buscartxt.Text, "Comprobante reactivado")
                    MessageBox.Show("Comprobante reactivado correctamente.", "Desanulado", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    limpiar()
                    act()
                    PanelP.Enabled = False
                    CamDGV.Enabled = True
                    listadoCamDgv()

                    actualizarTanquemed()
                    cargarNivelTanque()
                End If
            Else
                Dim opc As DialogResult = MessageBox.Show("Esta seguro que desea anular este comprobante?" & vbCrLf &
                    "El registro se conservara pero no sumara en reportes ni calculos.",
                    "Anular Comprobante", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

                If opc = DialogResult.Yes Then
                    Using conLocal As MySqlConnection = ModuloConexion.ObtenerConexion()
                        conLocal.Open()
                        Using cmd As New MySqlCommand("UPDATE comprobante SET anulado = 1, galDesp = 0, total = 0, valor = 0 WHERE idcprbnt = @id", conLocal)
                            cmd.Parameters.AddWithValue("@id", buscartxt.Text)
                            cmd.ExecuteNonQuery()
                        End Using
                    End Using

                    RegistrarLog("ANULAR", buscartxt.Text, "Comprobante anulado")
                    MessageBox.Show("Comprobante anulado correctamente.", "Anulado", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    limpiar()
                    act()
                    PanelP.Enabled = False
                    CamDGV.Enabled = True
                    listadoCamDgv()

                    actualizarTanquemed()
                    cargarNivelTanque()
                End If
            End If

        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub CancelarBtn_Click(sender As Object, e As EventArgs) Handles CancelarBtn.Click
        act()
        PanelP.Enabled = False
        CamDGV.Enabled = True
        Me.GuardarBtn.Visible = True
    End Sub

    Private Sub CamDGV_Click(sender As Object, e As EventArgs) Handles CamDGV.Click
        If Me.CamDGV.RowCount = 0 Then
            MessageBox.Show("No hay datos a mostrar")
        Else
            Dim i As Integer = Me.CamDGV.CurrentRow.Index
            PanelP.Enabled = True
            Dim y As Integer = Me.CamDGV.CurrentRow.Index
            Dim idcod As Integer = Me.CamDGV.Item(0, y).Value
            buscartxt.Text = idcod
            Seleccion()
            calcularletras()
            cargarTotalDesdeRegistro()
            Me.EditarBtn.Enabled = Not ModuloConexion.EsSoloLectura()
            Dim tipoUsr As String = ModuloConexion.TipoUsuarioSesion.ToUpper()
            Dim esAdmin As Boolean = (tipoUsr = "ADMIN" OrElse tipoUsr = "SUPERADMIN")
            Me.EliminarBtn.Enabled = esAdmin
            If registroAnulado Then
                Me.AnularBtn.Text = "Desanular"
                Me.AnularBtn.Enabled = esAdmin
            Else
                Me.AnularBtn.Text = "Anular"
                Me.AnularBtn.Enabled = Not ModuloConexion.EsSoloLectura()
            End If
        End If
    End Sub

    Public Sub Seleccion()
        Dim consulta As String
        Dim lista As Byte

        If buscartxt.Text <> "" Then
            consulta = "SELECT * FROM comprobante WHERE idcprbnt = '" & buscartxt.Text & "'"
            adaptador = New MySqlDataAdapter(consulta, con)
            datos = New DataSet
            adaptador.Fill(datos, "placa")
            lista = datos.Tables("placa").Rows.Count
        End If

        If lista <> 0 Then
            nComproTb.Text = datos.Tables("placa").Rows(0).Item("nCompro").ToString
            nBoletaTb.Text = datos.Tables("placa").Rows(0).Item("nBoleta").ToString
            galDespTb.Text = datos.Tables("placa").Rows(0).Item("galDesp").ToString
            valorTb.Text = datos.Tables("placa").Rows(0).Item("valor").ToString
            placaCbzTb.Text = datos.Tables("placa").Rows(0).Item("placaCbz").ToString
            nConteTb.Text = datos.Tables("placa").Rows(0).Item("nConte").ToString
            propCbzTb.Text = datos.Tables("placa").Rows(0).Item("propCbz").ToString
            rutaTb.Text = datos.Tables("placa").Rows(0).Item("ruta").ToString
            nombCondTb.Text = datos.Tables("placa").Rows(0).Item("nombCond").ToString
            nombDespTb.Text = datos.Tables("placa").Rows(0).Item("nombDesp").ToString
            fechaPkd.Text = datos.Tables("placa").Rows(0).Item("fecha").ToString
            periodoTb.Text = datos.Tables("placa").Rows(0).Item("periodo").ToString
            semanaTb.Text = datos.Tables("placa").Rows(0).Item("semana").ToString
            proxSemTb.Text = datos.Tables("placa").Rows(0).Item("proxSem").ToString
            codiPropTb.Text = datos.Tables("placa").Rows(0).Item("codiProp").ToString

            If datos.Tables("placa").Columns.Contains("anulado") AndAlso
               datos.Tables("placa").Rows(0).Item("anulado") IsNot DBNull.Value Then
                registroAnulado = (Convert.ToInt32(datos.Tables("placa").Rows(0).Item("anulado")) = 1)
            Else
                registroAnulado = False
            End If

            If registroAnulado Then
                pLetras.Text = "ANULADO"
            End If
        Else
            MsgBox("Datos no encontrados")
        End If
    End Sub

    Private Sub placaBusqTB_TextChanged(sender As Object, e As EventArgs) Handles placaBusqTB.TextChanged
        If cargandoFormulario OrElse actualizandoProgramaticamente Then Return
        buscarConFiltros()
    End Sub

    Private Sub boletBusqTB_TextChanged(sender As Object, e As EventArgs) Handles boletBusqTB.TextChanged
        If cargandoFormulario Then Return
        buscarConFiltros()
    End Sub

    Public Sub Rutas()
        Try
            If con.State = ConnectionState.Closed Then con.Open()
            Dim query As String = "SELECT rutas FROM rutas;"
            Dim autoCompleteSource As New AutoCompleteStringCollection()
            Using cmd As New MySqlCommand(query, con)
                Dim reader As MySqlDataReader = cmd.ExecuteReader()
                While reader.Read()
                    autoCompleteSource.Add(reader("rutas").ToString())
                End While
                reader.Close()
            End Using
            rutaTb.AutoCompleteCustomSource = autoCompleteSource
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        Finally
            If con.State = ConnectionState.Open Then con.Close()
        End Try
    End Sub

    Public Sub PConductores()
        Try
            If con.State = ConnectionState.Closed Then con.Open()
            Dim query As String = "SELECT DISTINCT nombCond FROM comprobante WHERE nombCond IS NOT NULL AND nombCond <> '' ORDER BY nombCond"
            Dim autoCompleteSource As New AutoCompleteStringCollection()
            Using cmd As New MySqlCommand(query, con)
                Dim reader As MySqlDataReader = cmd.ExecuteReader()
                While reader.Read()
                    autoCompleteSource.Add(reader("nombCond").ToString())
                End While
                reader.Close()
            End Using
            nombCondTb.AutoCompleteCustomSource = autoCompleteSource
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        Finally
            If con.State = ConnectionState.Open Then con.Close()
        End Try
    End Sub

    Public Sub CargarCachePlacas()
        cachePlacasPorPropietario.Clear()
        cachePlacasPorCodigo.Clear()
        cachePropietarioPorCodigo.Clear()
        cacheCodigoPorPropietario.Clear()
        cachePlacaInfo.Clear()

        Dim autoCompleteProp As New AutoCompleteStringCollection()
        Dim autoCompletePlaca As New AutoCompleteStringCollection()

        Try
            If con.State = ConnectionState.Closed Then con.Open()

            Dim sqlPlacas As String = "SELECT codigoPro, placa, propietario FROM placa WHERE activo = 1"
            Using cmd As New MySqlCommand(sqlPlacas, con)
                Using reader As MySqlDataReader = cmd.ExecuteReader()
                    While reader.Read()
                        Dim codigo As String = If(reader("codigoPro") IsNot DBNull.Value, reader("codigoPro").ToString().Trim(), "")
                        Dim placa As String = If(reader("placa") IsNot DBNull.Value, reader("placa").ToString().Trim(), "")
                        Dim prop As String = If(reader("propietario") IsNot DBNull.Value, reader("propietario").ToString().Trim(), "")

                        If prop <> "" Then
                            If Not cachePlacasPorPropietario.ContainsKey(prop.ToUpper()) Then
                                cachePlacasPorPropietario(prop.ToUpper()) = New List(Of String)
                            End If
                            If placa <> "" Then cachePlacasPorPropietario(prop.ToUpper()).Add(placa)
                        End If

                        If codigo <> "" Then
                            If Not cachePlacasPorCodigo.ContainsKey(codigo) Then
                                cachePlacasPorCodigo(codigo) = New List(Of String)
                            End If
                            If placa <> "" Then cachePlacasPorCodigo(codigo).Add(placa)
                        End If

                        If prop <> "" AndAlso codigo <> "" Then
                            cacheCodigoPorPropietario(prop.ToUpper()) = codigo
                        End If

                        If placa <> "" Then
                            cachePlacaInfo(placa.ToUpper()) = {codigo, prop}
                        End If

                        If prop <> "" AndAlso Not autoCompleteProp.Contains(prop) Then autoCompleteProp.Add(prop)
                        If placa <> "" AndAlso Not autoCompletePlaca.Contains(placa) Then autoCompletePlaca.Add(placa)
                    End While
                End Using
            End Using

            Dim sqlProp As String = "SELECT codProp, nPropietario FROM propietario"
            Using cmd As New MySqlCommand(sqlProp, con)
                Using reader As MySqlDataReader = cmd.ExecuteReader()
                    While reader.Read()
                        Dim codProp As String = If(reader("codProp") IsNot DBNull.Value, reader("codProp").ToString().Trim(), "")
                        Dim nProp As String = If(reader("nPropietario") IsNot DBNull.Value, reader("nPropietario").ToString().Trim(), "")
                        If codProp <> "" AndAlso nProp <> "" Then
                            cachePropietarioPorCodigo(codProp) = nProp
                        End If
                    End While
                End Using
            End Using

            propCbzTb.AutoCompleteCustomSource = autoCompleteProp
            placaCbzTb.AutoCompleteCustomSource = autoCompletePlaca

        Catch ex As Exception
            MessageBox.Show("Error cargando cache: " & ex.Message)
        Finally
            If con.State = ConnectionState.Open Then con.Close()
        End Try
    End Sub

    Private Sub propCbzTb_KeyDown(sender As Object, e As KeyEventArgs) Handles propCbzTb.KeyDown
        If e.KeyCode = Keys.Enter Then
            Seleccion2()
        End If
        If e.KeyCode = Keys.Delete Then
            propCbzTb.Text = ""
        End If
    End Sub

    Public Sub Seleccion2()
        If propCbzTb.Text = "" Then Return

        Dim textoBusqueda As String = propCbzTb.Text.Trim().ToUpper()
        Dim codigoEncontrado As String = ""

        If cacheCodigoPorPropietario.ContainsKey(textoBusqueda) Then
            codigoEncontrado = cacheCodigoPorPropietario(textoBusqueda)
        Else
            For Each kvp In cacheCodigoPorPropietario
                If kvp.Key.Contains(textoBusqueda) Then
                    codigoEncontrado = kvp.Value
                    Exit For
                End If
            Next
        End If

        If codigoEncontrado <> "" Then
            codiPropTb.Text = codigoEncontrado
        Else
            MsgBox("Datos no encontrados")
        End If
    End Sub

    Private Sub codiPropTb_TextChanged(sender As Object, e As EventArgs) Handles codiPropTb.TextChanged
        If actualizandoProgramaticamente Then Return

        Try
            placaCbzTb2.Items.Clear()

            If codiPropTb.Text.Trim() <> "" Then
                Dim codigo As String = codiPropTb.Text.Trim()

                For Each kvp In cachePlacasPorCodigo
                    If kvp.Key.Contains(codigo) Then
                        For Each placa In kvp.Value
                            placaCbzTb2.Items.Add(placa)
                        Next
                    End If
                Next

                If cachePropietarioPorCodigo.ContainsKey(codigo) Then
                    propCbzTb.Text = cachePropietarioPorCodigo(codigo)
                Else
                    propCbzTb.Text = ""
                End If
            Else
                propCbzTb.Text = ""
            End If

        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        End Try
    End Sub

    Private Sub placaCbzTb2_ItemClick(sender As Object, e As EventArgs) Handles placaCbzTb2.ItemClick
        placaCbzTb.Text = placaCbzTb2.SelectedItem.ToString()
    End Sub

    Private Sub calcularletras()
        pLetras.Text = ""
        If IsNumeric(galDespTb.Text) Then
            pLetras.Text = LETRAS(galDespTb.Text)
        End If
        galDespTb.SelectionStart = 0
        galDespTb.SelectionLength = galDespTb.ToString.Length
    End Sub

    Private Sub valorTb_Leave(sender As Object, e As EventArgs) Handles valorTb.Leave
        calcularletras()
    End Sub

    Private Sub ButtonX6_Click(sender As Object, e As EventArgs) Handles ButtonX6.Click
        listadoCamDgv()
    End Sub

    Private Sub ImprimirBt_Click(sender As Object, e As EventArgs) Handles ImprimirBt.Click
        ' (sin guarda de mouse)
        PrintComprobante.Print()
    End Sub

    Private Sub ImprimirBt2_Click(sender As Object, e As EventArgs) Handles ImprimirBt2.Click
        ' (sin guarda de mouse)
        PrintDocumento.Print()
    End Sub

    Private Sub PrintComprobante_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles PrintComprobante.PrintPage
        Using conLocal As MySqlConnection = ModuloConexion.ObtenerConexion()
            Try
                conLocal.Open()
                Dim query As String = "SELECT nEmpre, rtn FROM empresa LIMIT 1"
                Using comando As New MySqlCommand(query, conLocal)
                    Using lector As MySqlDataReader = comando.ExecuteReader()
                        If lector.Read() Then
                            Dim nEmpreP As String = lector("nEmpre").ToString()
                            Dim rtnP As String = lector("rtn").ToString()
                            lector.Close()

                            Dim fe As String = fechaPkd.Value.ToString("dd-MM-yyyy")

                            Dim imgLocal As Image = Nothing
                            Try
                                imgLocal = Image.FromFile("C:\emtracc\camion.jpg")
                                e.Graphics.DrawImage(imgLocal, 5, 5, 250, 100)
                            Catch
                            Finally
                                If imgLocal IsNot Nothing Then imgLocal.Dispose()
                            End Try

                            Dim mFont As New Font("Calibri", 8, GraphicsUnit.Point)
                            Dim mFont2 As New Font("Calibri", 10, FontStyle.Bold, GraphicsUnit.Point)
                            Dim mFont4 As New Font("Calibri", 9, FontStyle.Bold, GraphicsUnit.Point)
                            Dim GFont2 As New Font("Calibri", 12, FontStyle.Bold, GraphicsUnit.Point)
                            Dim uFont As New Font("Calibri", 10, FontStyle.Bold, GraphicsUnit.Point)
                            Dim DFont As New Font("Calibri", 13, FontStyle.Bold, GraphicsUnit.Point)

                            Dim displayRectangle As New Rectangle(New Point(5, 100), New Size(240, 200))
                            Dim displayRectangle2 As New Rectangle(New Point(5, 155), New Size(240, 200))

                            Dim format1 As New StringFormat(StringFormatFlags.NoClip)
                            format1.LineAlignment = StringAlignment.Near
                            format1.Alignment = StringAlignment.Center

                            e.Graphics.DrawString(nEmpreP, uFont, Brushes.Black, RectangleF.op_Implicit(displayRectangle), format1)
                            e.Graphics.DrawString("RTN: " & rtnP, mFont4, Brushes.Black, 60, 135)
                            e.Graphics.DrawString("__________________________", DFont, Brushes.Black, 10, 135)
                            e.Graphics.DrawString("COMPROBANTE DE DESPACHO DE COMBUSTIBLE", GFont2, Brushes.Black, RectangleF.op_Implicit(displayRectangle2), format1)
                            e.Graphics.DrawString("__________________________", DFont, Brushes.Black, 10, 180)

                            e.Graphics.DrawString("FECHA:" & fe, mFont2, Brushes.Black, 120, 200)
                            e.Graphics.DrawString("Comprobante N: " & nComproTb.Text, GFont2, Brushes.Black, 25, 220)
                            e.Graphics.DrawString("____________________", DFont, Brushes.Black, 35, 222)

                            e.Graphics.DrawString("Proxima Semana: " & proxSemTb.Text, mFont2, Brushes.Black, 10, 245)
                            e.Graphics.DrawString("Galones Despachados: " & galDespTb.Text, mFont2, Brushes.Black, 10, 260)
                            e.Graphics.DrawString("" & pLetras.Text, mFont, Brushes.Black, 10, 275)

                            e.Graphics.DrawString("=== Propietario Cabezal ===", mFont2, Brushes.Black, 50, 295)
                            e.Graphics.DrawString(propCbzTb.Text, mFont2, Brushes.Black, 10, 310)

                            e.Graphics.DrawString("Cabezal:   " & placaCbzTb.Text, mFont2, Brushes.Black, 30, 325)
                            e.Graphics.DrawString("Contenedor:   " & nConteTb.Text, mFont2, Brushes.Black, 30, 340)
                            e.Graphics.DrawString("N Boleta: " & nBoletaTb.Text, mFont2, Brushes.Black, 30, 355)

                            e.Graphics.DrawString("Ruta: " & rutaTb.Text, mFont4, Brushes.Black, 10, 385)
                            e.Graphics.DrawString("_____________________________", DFont, Brushes.Black, 10, 390)

                            e.Graphics.DrawString("=== Nombre Conductor ===", mFont2, Brushes.Black, 50, 410)
                            e.Graphics.DrawString(nombCondTb.Text, mFont2, Brushes.Black, 10, 425)

                            e.Graphics.DrawString("__________________________", mFont2, Brushes.Black, 30, 485)
                            e.Graphics.DrawString("Firma Conductor", mFont2, Brushes.Black, 70, 500)
                            e.Graphics.DrawString("_____________________________", DFont, Brushes.Black, 10, 505)

                            e.Graphics.DrawString("=== Nombre Despachador ===", mFont2, Brushes.Black, 50, 540)
                            e.Graphics.DrawString(nombDespTb.Text, mFont2, Brushes.Black, 10, 555)

                            e.Graphics.DrawString("__________________________", mFont2, Brushes.Black, 30, 610)
                            e.Graphics.DrawString("Firma Despachador", mFont2, Brushes.Black, 65, 630)

                            e.Graphics.DrawString("Periodo - Semana " & periodoTb.Text & "-" & semanaTb.Text, GFont2, Brushes.Black, 40, 660)
                            e.Graphics.DrawString("_____________________________", DFont, Brushes.Black, 10, 670)

                            mFont.Dispose() : mFont2.Dispose() : mFont4.Dispose()
                            GFont2.Dispose() : uFont.Dispose() : DFont.Dispose() : format1.Dispose()
                        End If
                    End Using
                End Using
            Catch ex As Exception
                MessageBox.Show("Error: " & ex.Message)
            End Try
        End Using
    End Sub

    Private Sub PrintDocumento_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles PrintDocumento.PrintPage
        Using conLocal As MySqlConnection = ModuloConexion.ObtenerConexion()
            Try
                conLocal.Open()
                Dim query As String = "SELECT nEmpre, rtn FROM empresa LIMIT 1"
                Using comando As New MySqlCommand(query, conLocal)
                    Using lector As MySqlDataReader = comando.ExecuteReader()
                        If lector.Read() Then
                            Dim nEmpreP As String = lector("nEmpre").ToString()
                            Dim rtnP As String = lector("rtn").ToString()
                            lector.Close()

                            Dim fe As String = fechaPkd.Value.ToString("dd-MM-yyyy")

                            Dim mFont As New Font("Calibri", 8, GraphicsUnit.Point)
                            Dim mFont2 As New Font("Calibri", 10, FontStyle.Bold, GraphicsUnit.Point)
                            Dim mFont4 As New Font("Calibri", 9, FontStyle.Bold, GraphicsUnit.Point)
                            Dim GFont2 As New Font("Calibri", 12, FontStyle.Bold, GraphicsUnit.Point)
                            Dim uFont As New Font("Calibri", 10, FontStyle.Bold, GraphicsUnit.Point)
                            Dim DFont As New Font("Calibri", 13, FontStyle.Bold, GraphicsUnit.Point)

                            Dim format1 As New StringFormat(StringFormatFlags.NoClip)
                            format1.LineAlignment = StringAlignment.Near
                            format1.Alignment = StringAlignment.Center

                            Dim imgLocal As Image = Nothing
                            Try
                                imgLocal = Image.FromFile("C:\emtracc\camion.jpg")
                                e.Graphics.DrawImage(imgLocal, 5, 5, 250, 100)
                            Catch
                            Finally
                                If imgLocal IsNot Nothing Then imgLocal.Dispose()
                            End Try

                            Dim y As Integer = 110
                            Dim rectEmpresa As New Rectangle(New Point(5, y), New Size(240, 35))
                            e.Graphics.DrawString(nEmpreP, uFont, Brushes.Black, RectangleF.op_Implicit(rectEmpresa), format1)

                            y = 145 : e.Graphics.DrawString("RTN: " & rtnP, mFont4, Brushes.Black, 60, y)
                            y = 155 : e.Graphics.DrawString("__________________________", DFont, Brushes.Black, 10, y)

                            y = 172
                            Dim rectTitulo As New Rectangle(New Point(5, y), New Size(240, 35))
                            e.Graphics.DrawString("COMPROBANTE DE DESPACHO DE COMBUSTIBLE", GFont2, Brushes.Black, RectangleF.op_Implicit(rectTitulo), format1)

                            y = 200 : e.Graphics.DrawString("__________________________", DFont, Brushes.Black, 10, y)
                            y = 222 : e.Graphics.DrawString("FECHA:" & fe, mFont2, Brushes.Black, 120, y)
                            y = 237 : e.Graphics.DrawString("Periodo - Semana " & periodoTb.Text & "-" & semanaTb.Text, GFont2, Brushes.Black, 40, y)
                            y = 257 : e.Graphics.DrawString("Comprobante N: " & nComproTb.Text, GFont2, Brushes.Black, 25, y)
                            e.Graphics.DrawString("____________________", DFont, Brushes.Black, 35, y + 2)

                            y = 277 : e.Graphics.DrawString("=== Propietario Cabezal ===", mFont2, Brushes.Black, 50, y)
                            y = 292 : e.Graphics.DrawString(propCbzTb.Text, mFont2, Brushes.Black, 10, y)
                            y = 306 : e.Graphics.DrawString("Cod. Propietario: " & codiPropTb.Text, mFont2, Brushes.Black, 30, y)
                            y = 322 : e.Graphics.DrawString("Cabezal:   " & placaCbzTb.Text, mFont2, Brushes.Black, 30, y)
                            y = 337 : e.Graphics.DrawString("Contenedor:   " & nConteTb.Text, mFont2, Brushes.Black, 30, y)
                            y = 352 : e.Graphics.DrawString("N Boleta: " & nBoletaTb.Text, mFont2, Brushes.Black, 30, y)

                            y = 366 : e.Graphics.DrawString("Ruta: " & rutaTb.Text, mFont4, Brushes.Black, 10, y)
                            e.Graphics.DrawString("_____________________________", DFont, Brushes.Black, 10, y)
                            y = 386 : e.Graphics.DrawString("=== Nombre Conductor ===", mFont2, Brushes.Black, 50, y)
                            y = 401 : e.Graphics.DrawString(nombCondTb.Text, mFont2, Brushes.Black, 10, y)
                            e.Graphics.DrawString("_____________________________", DFont, Brushes.Black, 10, y)

                            y = 429 : e.Graphics.DrawString("=== Nombre Despachador ===", mFont2, Brushes.Black, 50, y)
                            y = 444 : e.Graphics.DrawString(nombDespTb.Text, mFont2, Brushes.Black, 10, y)
                            y = 448 : e.Graphics.DrawString("_____________________________", DFont, Brushes.Black, 10, y)

                            y = 472 : e.Graphics.DrawString("Galones Despachados: " & galDespTb.Text, mFont2, Brushes.Black, 10, y)
                            y = 487 : e.Graphics.DrawString("Precio: " & valorTb.Text, mFont2, Brushes.Black, 10, y)
                            y = 502 : e.Graphics.DrawString(totVtalb.Text, mFont2, Brushes.Black, 10, y)
                            y = 516 : e.Graphics.DrawString("_____________________________", DFont, Brushes.Black, 10, y)

                            mFont.Dispose() : mFont2.Dispose() : mFont4.Dispose()
                            GFont2.Dispose() : uFont.Dispose() : DFont.Dispose() : format1.Dispose()
                        End If
                    End Using
                End Using
            Catch ex As Exception
                MessageBox.Show("Error: " & ex.Message)
            End Try
        End Using
    End Sub

    Private Sub PreviaBtn_Click(sender As Object, e As EventArgs) Handles PreviaBtn.Click
        ' (sin guarda de mouse)
        Try
            PrintPreviewComprobante.PrintPreviewControl.Zoom = 1.3
            PrintPreviewComprobante.Height = 700
            PrintPreviewComprobante.Width = 500
            PanelP.Enabled = True
            PrintComprobante.PrinterSettings.Copies = 1
            PrintPreviewComprobante.Document = PrintComprobante
            PrintPreviewComprobante.ShowDialog()
            CancelarBtn.Enabled = True
        Catch ex As Exception
            MessageBox.Show("Error al mostrar vista previa del comprobante: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub PreviaBtn2_Click(sender As Object, e As EventArgs) Handles PreviaBtn2.Click
        ' (sin guarda de mouse)
        Try
            PrintPreviewDocumento.PrintPreviewControl.Zoom = 1.3
            PrintPreviewDocumento.Height = 700
            PrintPreviewDocumento.Width = 500
            PanelP.Enabled = True
            PrintDocumento.PrinterSettings.Copies = 1
            PrintPreviewDocumento.Document = PrintDocumento
            PrintPreviewDocumento.ShowDialog()
            CancelarBtn.Enabled = True
        Catch ex As Exception
            MessageBox.Show("Error al mostrar vista previa del documento: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub galDespTb_Leave(sender As Object, e As EventArgs) Handles galDespTb.Leave
        calcularletras()
    End Sub

    Private Sub galDespTb_TextChanged(sender As Object, e As EventArgs) Handles galDespTb.TextChanged
        calcularTotalVenta()
    End Sub

    Private Sub valorTb_TextChanged(sender As Object, e As EventArgs) Handles valorTb.TextChanged
        calcularTotalVenta()
    End Sub

    Private Sub calcularTotalVenta()
        Dim gal As Double = 0
        Dim val As Double = 0
        Double.TryParse(galDespTb.Text, gal)
        Double.TryParse(valorTb.Text, val)
        totVtalb.Text = String.Format("Total Venta: L. {0:N2}", gal * val)
    End Sub

    Private Sub cargarTotalDesdeRegistro()
        Try
            If datos IsNot Nothing AndAlso datos.Tables("placa") IsNot Nothing AndAlso datos.Tables("placa").Rows.Count > 0 Then
                Dim totalVal As Object = datos.Tables("placa").Rows(0).Item("total")
                If totalVal IsNot Nothing AndAlso Not IsDBNull(totalVal) Then
                    totVtalb.Text = String.Format("Total Venta: L. {0:N2}", Convert.ToDouble(totalVal))
                Else
                    calcularTotalVenta()
                End If
            Else
                calcularTotalVenta()
            End If
        Catch
            calcularTotalVenta()
        End Try
    End Sub

    Private Sub placaCbzTb_TextChanged(sender As Object, e As EventArgs) Handles placaCbzTb.TextChanged
        If actualizandoProgramaticamente Then Return
        Try
            actualizandoProgramaticamente = True

            If String.IsNullOrWhiteSpace(placaCbzTb.Text) Then
                propCbzTb.Text = ""
                codiPropTb.Text = ""
                actualizandoProgramaticamente = False
                Return
            End If

            If placaCbzTb.Text.Trim().Length < 3 Then
                actualizandoProgramaticamente = False
                Return
            End If

            Dim placaBuscada As String = placaCbzTb.Text.Trim().ToUpper()
            Dim codigoPro As String = ""
            Dim propietarioNombre As String = ""
            Dim encontro As Boolean = False

            If cachePlacaInfo.ContainsKey(placaBuscada) Then
                codigoPro = cachePlacaInfo(placaBuscada)(0)
                propietarioNombre = cachePlacaInfo(placaBuscada)(1)
                encontro = True
            Else
                For Each kvp In cachePlacaInfo
                    If kvp.Key.Contains(placaBuscada) Then
                        codigoPro = kvp.Value(0)
                        propietarioNombre = kvp.Value(1)
                        encontro = True
                        Exit For
                    End If
                Next
            End If

            If encontro AndAlso codigoPro <> "" Then
                If cachePropietarioPorCodigo.ContainsKey(codigoPro) Then
                    propCbzTb.Text = cachePropietarioPorCodigo(codigoPro)
                Else
                    propCbzTb.Text = propietarioNombre
                End If
                codiPropTb.Text = codigoPro
            Else
                propCbzTb.Text = ""
                codiPropTb.Text = ""
            End If

        Catch ex As Exception
            MessageBox.Show("Error al buscar datos de la placa: " & ex.Message, "Error")
        Finally
            actualizandoProgramaticamente = False
        End Try
    End Sub

    ' ============ FILTROS ============

    Private Sub cargarDespachadores()
        Try
            Using conLocal As MySqlConnection = ModuloConexion.ObtenerConexion()
                conLocal.Open()

                despachadorCb.Items.Clear()
                despachadorCb.Items.Add("-- Todos --")

                Dim sql As String = "SELECT DISTINCT nombDesp FROM comprobante WHERE nombDesp IS NOT NULL AND nombDesp <> '' ORDER BY nombDesp"
                Using cmd As New MySqlCommand(sql, conLocal)
                    Using dr As MySqlDataReader = cmd.ExecuteReader()
                        While dr.Read()
                            despachadorCb.Items.Add(dr("nombDesp").ToString())
                        End While
                    End Using
                End Using

                despachadorCb.SelectedIndex = 0
            End Using

        Catch ex As Exception
            MessageBox.Show("Error al cargar despachadores: " & ex.Message, "Error")
        End Try
    End Sub

    Private Sub buscarConFiltros()
        Try
            If con.State = ConnectionState.Closed Then con.Open()

            Dim sql As New System.Text.StringBuilder()
            sql.Append("SELECT idcprbnt, nCompro, nBoleta, DATE_FORMAT(fecha, '%d/%m/%Y') AS fecha, nombDesp, propCbz, placaCbz, periodo, semana, ruta, galDesp, valor, total, COALESCE(anulado, 0) AS anulado ")
            sql.Append("FROM comprobante WHERE 1=1 ")

            Dim cmd As New MySqlCommand()
            cmd.Connection = con

            If placaBusqTB.Text.Trim() <> "" Then
                sql.Append("AND placaCbz LIKE @placa ")
                cmd.Parameters.AddWithValue("@placa", "%" & placaBusqTB.Text.Trim() & "%")
            End If

            If boletBusqTB.Text.Trim() <> "" Then
                sql.Append("AND nBoleta LIKE @boleta ")
                cmd.Parameters.AddWithValue("@boleta", "%" & boletBusqTB.Text.Trim() & "%")
            End If

            If chkUsarFecha.Checked Then
                sql.Append("AND DATE(fecha) >= @fechaDesde AND DATE(fecha) <= @fechaHasta ")
                cmd.Parameters.AddWithValue("@fechaDesde", fechaDesdePk.Value.ToString("yyyy-MM-dd"))
                cmd.Parameters.AddWithValue("@fechaHasta", fechaHastaPk.Value.ToString("yyyy-MM-dd"))
            End If

            If despachadorCb.SelectedIndex > 0 Then
                sql.Append("AND nombDesp = @despachador ")
                cmd.Parameters.AddWithValue("@despachador", despachadorCb.SelectedItem.ToString())
            End If

            sql.Append("ORDER BY fecha DESC, nCompro DESC")
            cmd.CommandText = sql.ToString()

            Dim adapter As New MySqlDataAdapter(cmd)
            Dim dt As New DataTable()
            adapter.Fill(dt)

            CamDGV.DataSource = dt
            ListadoD()

            Dim totalRegistros As Integer = 0
            Dim totalGalones As Double = 0
            Dim totalVenta As Double = 0
            For Each row As DataRow In dt.Rows
                Dim esAnulado As Boolean = (row.Table.Columns.Contains("anulado") AndAlso row("anulado") IsNot DBNull.Value AndAlso Convert.ToInt32(row("anulado")) = 1)
                If Not esAnulado Then
                    totalRegistros += 1
                    If row("galDesp") IsNot DBNull.Value Then totalGalones += Convert.ToDouble(row("galDesp"))
                    If row("total") IsNot DBNull.Value Then totalVenta += Convert.ToDouble(row("total"))
                End If
            Next

            lblTotales.Text = String.Format("Registros: {0}  |  Total Galones: {1:N2}", totalRegistros, totalGalones)
            totVtalb.Text = String.Format("Total Venta: L. {0:N2}", totalVenta)

        Catch ex As Exception
            MessageBox.Show("Error al buscar: " & ex.Message, "Error")
        Finally
            If con.State = ConnectionState.Open Then con.Close()
        End Try
    End Sub

    Private Sub chkUsarFecha_CheckedChanged(sender As Object, e As EventArgs) Handles chkUsarFecha.CheckedChanged
        fechaDesdePk.Enabled = chkUsarFecha.Checked
        fechaHastaPk.Enabled = chkUsarFecha.Checked
    End Sub

    Private Sub buscarBtn_Click(sender As Object, e As EventArgs) Handles buscarBtn.Click
        buscarConFiltros()
    End Sub

    Private Sub despachadorCb_SelectedIndexChanged(sender As Object, e As EventArgs) Handles despachadorCb.SelectedIndexChanged
        If cargandoFormulario Then Return
        buscarConFiltros()
    End Sub

    ' ============ NIVEL DE TANQUE ============

    Private Sub cargarNivelTanque()
        Try
            Dim periodo As String = ModuloConexion.PeriodoSesion
            Dim semana As String = ModuloConexion.SemanaSesion

            If String.IsNullOrEmpty(periodo) OrElse String.IsNullOrEmpty(semana) Then
                lblNivelTanque.Text = "Tanque: sin periodo/semana"
                lblNivelTanque.ForeColor = Color.Gray
                Return
            End If

            Using conLocal As MySqlConnection = ModuloConexion.ObtenerConexion()
                conLocal.Open()

                Dim sqlTanque As String = "SELECT galonesCalc, galRecibidos, capacidadTanque FROM tanquemed WHERE periodo = @periodo AND semana = @semana ORDER BY idMedida DESC LIMIT 1"
                Dim galInicio As Double = 0
                Dim galRecibidos As Double = 0
                Dim capacidad As Double = 0
                Dim encontro As Boolean = False

                Using cmd As New MySqlCommand(sqlTanque, conLocal)
                    cmd.Parameters.AddWithValue("@periodo", periodo)
                    cmd.Parameters.AddWithValue("@semana", semana)
                    Using drLocal As MySqlDataReader = cmd.ExecuteReader()
                        If drLocal.Read() Then
                            If drLocal("galonesCalc") IsNot DBNull.Value Then galInicio = Convert.ToDouble(drLocal("galonesCalc"))
                            If drLocal("galRecibidos") IsNot DBNull.Value Then galRecibidos = Convert.ToDouble(drLocal("galRecibidos"))
                            If drLocal("capacidadTanque") IsNot DBNull.Value Then capacidad = Convert.ToDouble(drLocal("capacidadTanque"))
                            encontro = True
                        End If
                    End Using
                End Using

                If Not encontro Then
                    lblNivelTanque.Text = "Tanque: sin medicion P" & periodo & "-S" & semana
                    lblNivelTanque.ForeColor = Color.Gray
                    Return
                End If

                Dim sqlDesp As String = "SELECT COALESCE(SUM(galDesp), 0) FROM comprobante WHERE periodo = @periodo AND semana = @semana AND (anulado = 0 OR anulado IS NULL)"
                Dim totalDespachado As Double = 0

                Using cmdDesp As New MySqlCommand(sqlDesp, conLocal)
                    cmdDesp.Parameters.AddWithValue("@periodo", periodo)
                    cmdDesp.Parameters.AddWithValue("@semana", semana)
                    totalDespachado = Convert.ToDouble(cmdDesp.ExecuteScalar())
                End Using

                Dim nivelActual As Double = galInicio + galRecibidos - totalDespachado

                If capacidad > 0 Then
                    Dim porcentaje As Double = (nivelActual / capacidad) * 100
                    lblNivelTanque.Text = String.Format("Tanque: {0:N2} gal ({1:N0}%)", nivelActual, porcentaje)

                    If porcentaje > 50 Then
                        lblNivelTanque.ForeColor = Color.LightGreen
                    ElseIf porcentaje > 25 Then
                        lblNivelTanque.ForeColor = Color.Yellow
                    Else
                        lblNivelTanque.ForeColor = Color.OrangeRed
                    End If
                Else
                    lblNivelTanque.Text = String.Format("Tanque: {0:N2} gal", nivelActual)
                    lblNivelTanque.ForeColor = Color.LightGreen
                End If

            End Using

        Catch ex As Exception
            lblNivelTanque.Text = "Tanque: error"
            lblNivelTanque.ForeColor = Color.Gray
        End Try
    End Sub

    Private Sub actualizarTanquemed()
        Try
            Dim periodo As String = ModuloConexion.PeriodoSesion
            Dim semana As String = ModuloConexion.SemanaSesion

            If String.IsNullOrEmpty(periodo) OrElse String.IsNullOrEmpty(semana) Then Return

            Using conLocal As MySqlConnection = ModuloConexion.ObtenerConexion()
                conLocal.Open()

                Dim sqlCheck As String = "SELECT idMedida, galonesCalc, galRecibidos, galonesMed FROM tanquemed WHERE periodo = @periodo AND semana = @semana ORDER BY idMedida DESC LIMIT 1"
                Dim idMedida As Integer = 0
                Dim galInicio As Double = 0
                Dim galRecibidosVal As Double = 0
                Dim galFinal As Double = 0

                Using cmdCheck As New MySqlCommand(sqlCheck, conLocal)
                    cmdCheck.Parameters.AddWithValue("@periodo", periodo)
                    cmdCheck.Parameters.AddWithValue("@semana", semana)
                    Using drCheck As MySqlDataReader = cmdCheck.ExecuteReader()
                        If drCheck.Read() Then
                            idMedida = Convert.ToInt32(drCheck("idMedida"))
                            If drCheck("galonesCalc") IsNot DBNull.Value Then galInicio = Convert.ToDouble(drCheck("galonesCalc"))
                            If drCheck("galRecibidos") IsNot DBNull.Value Then galRecibidosVal = Convert.ToDouble(drCheck("galRecibidos"))
                            If drCheck("galonesMed") IsNot DBNull.Value Then galFinal = Convert.ToDouble(drCheck("galonesMed"))
                        Else
                            Return
                        End If
                    End Using
                End Using

                Dim sqlDesp As String = "SELECT COALESCE(SUM(galDesp), 0) FROM comprobante WHERE periodo = @periodo AND semana = @semana AND (anulado = 0 OR anulado IS NULL)"
                Dim totalDespachado As Double = 0

                Using cmdDesp As New MySqlCommand(sqlDesp, conLocal)
                    cmdDesp.Parameters.AddWithValue("@periodo", periodo)
                    cmdDesp.Parameters.AddWithValue("@semana", semana)
                    totalDespachado = Convert.ToDouble(cmdDesp.ExecuteScalar())
                End Using

                Dim galEsperados As Double = galInicio + galRecibidosVal - totalDespachado
                Dim diferencia As Double = galFinal - galEsperados

                Dim sqlUpdate As String = "UPDATE tanquemed SET galDespachados = @galDesp, galEsperados = @galEsp, diferencia = @dif WHERE idMedida = @id"
                Using cmdUpdate As New MySqlCommand(sqlUpdate, conLocal)
                    cmdUpdate.Parameters.AddWithValue("@galDesp", totalDespachado)
                    cmdUpdate.Parameters.AddWithValue("@galEsp", galEsperados)
                    cmdUpdate.Parameters.AddWithValue("@dif", diferencia)
                    cmdUpdate.Parameters.AddWithValue("@id", idMedida)
                    cmdUpdate.ExecuteNonQuery()
                End Using

            End Using

        Catch ex As Exception
        End Try
    End Sub

End Class
