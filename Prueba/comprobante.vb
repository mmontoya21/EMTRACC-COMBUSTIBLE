Imports System.Data
Imports MySql.Data.MySqlClient
Imports MySql.Data
Public Class comprobante
    Dim cm As New MySqlCommand
    Dim guardar As New MySqlCommand
    Dim adaptador As New MySqlDataAdapter
    Dim datos As DataSet
    Dim dr As MySqlDataReader
    Private m_tmr As Timer
    Public img As Image
    Dim con As New MySqlConnection

    Dim colorFondo = Color.FromArgb(106, 126, 168)
    Dim colorTextbox = Color.FromArgb(240, 210, 249)

    ' Bandera para evitar cascada de eventos TextChanged
    Private actualizandoProgramaticamente As Boolean = False
    ' Bandera para evitar que los filtros se ejecuten durante la carga
    Private cargandoFormulario As Boolean = True

    Private Sub comprobante_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        On Error Resume Next

        cargandoFormulario = True

        System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("es-HN")
        System.Threading.Thread.CurrentThread.CurrentCulture.DateTimeFormat.ShortDatePattern = "yyyy/MM/dd"
        System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencyDecimalSeparator = "."
        System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencyGroupSeparator = ","
        System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator = "."
        System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.NumberGroupSeparator = ","

        conectar()

        cargarDespachadores()

        act()
        listadoCamDgv()

        cargandoFormulario = False
        EstilizarDataGridView(CamDGV)

        Me.BackColor = Color.SteelBlue

        PanelP.Enabled = False

        Rutas()
        PPropietario()
        PPlaca()

    End Sub
    Private Sub act()
        Me.NuevoBtn.Enabled = True
        Me.EditarBtn.Enabled = False
        Me.GuardarBtn.Enabled = False
        Me.ModificarBtn.Enabled = False
        Me.CancelarBtn.Enabled = False
        Me.EliminarBtn.Enabled = False
    End Sub
    Private Sub conectar()
        con = ModuloConexion.ObtenerConexion()
        Try
            If con.State = ConnectionState.Closed Then
                con.Open()
            End If
            MessageBox.Show("El sistema está conectado", "Combustible")
        Catch ex As Exception
            MsgBox("No se conecto por: " & ex.Message)
        End Try
    End Sub

    Private Sub listadoCamDgv() 'Muestra los datos
        Try
            If con.State = ConnectionState.Closed Then con.Open()

            Dim table As New DataTable()
            Dim adaptadoListado As New MySqlDataAdapter("SELECT idcprbnt, nCompro, nBoleta, DATE_FORMAT(fecha, '%d/%m/%Y') AS fecha, nombDesp, propCbz, placaCbz, periodo, semana, ruta, galDesp, valor FROM comprobante ORDER BY fecha DESC, nCompro DESC", con)
            adaptadoListado.Fill(table)

            CamDGV.DataSource = table

            ListadoD()

            ' Calcular totales
            Dim totalRegistros As Integer = table.Rows.Count
            Dim totalGalones As Double = 0
            Dim totalVenta As Double = 0
            For Each row As DataRow In table.Rows
                Dim gal As Double = 0
                Dim val As Double = 0
                If row("galDesp") IsNot DBNull.Value Then
                    gal = Convert.ToDouble(row("galDesp"))
                    totalGalones += gal
                End If
                If row("valor") IsNot DBNull.Value Then
                    val = Convert.ToDouble(row("valor"))
                End If
                totalVenta += gal * val
            Next

            ' Mostrar totales en los labels
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
        CamDGV.Columns(1).Width = 75

        CamDGV.Columns(2).HeaderText = "Boleta"
        CamDGV.Columns(2).Width = 70

        CamDGV.Columns(3).HeaderText = "Fecha"
        CamDGV.Columns(3).Width = 80

        CamDGV.Columns(4).HeaderText = "Despachador"
        CamDGV.Columns(4).Width = 150

        CamDGV.Columns(5).HeaderText = "Propietario"
        CamDGV.Columns(5).Width = 200

        CamDGV.Columns(6).HeaderText = "Placa"
        CamDGV.Columns(6).Width = 80

        CamDGV.Columns(7).HeaderText = "Per"
        CamDGV.Columns(7).Width = 35

        CamDGV.Columns(8).HeaderText = "Sem"
        CamDGV.Columns(8).Width = 35

        CamDGV.Columns(9).HeaderText = "Ruta"
        CamDGV.Columns(9).Width = 250

        ' Ocultar columnas galDesp y valor (usadas solo para calcular totales)
        If CamDGV.Columns.Count > 10 Then
            CamDGV.Columns(10).Visible = False
        End If
        If CamDGV.Columns.Count > 11 Then
            CamDGV.Columns(11).Visible = False
        End If
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
    Private Sub NuevoBtn_Click(sender As Object, e As EventArgs) Handles NuevoBtn.Click   '============  NUEVO  ===========
        Try
            ' Verificar si la conexión es válida, si no, obtener una nueva
            If con Is Nothing OrElse con.State = ConnectionState.Broken Then
                con = ModuloConexion.ObtenerConexion()
            End If
            If con.State = ConnectionState.Closed Then con.Open()

            ' Guardar valores antes de limpiar
            Dim despAnterior As String = nombDespTb.Text
            Dim periodoAnterior As String = periodoTb.Text
            Dim semanaAnterior As String = semanaTb.Text

            limpiar()

            ' Restaurar despachador, periodo y semana
            nombDespTb.Text = despAnterior
            periodoTb.Text = periodoAnterior
            semanaTb.Text = semanaAnterior

            ' Obtener el precio actual de combustible (solo el activo)
            Try
                Dim sqlValor As String = "SELECT valorCombustible FROM valorComb WHERE activo = 1 ORDER BY fecha DESC LIMIT 1"
                Using cmdValor As New MySqlCommand(sqlValor, con)
                    Dim resultado = cmdValor.ExecuteScalar()
                    If resultado IsNot Nothing AndAlso Not IsDBNull(resultado) Then
                        valorTb.Text = Convert.ToDecimal(resultado).ToString("N2")
                    End If
                End Using
            Catch
                ' Si falla, dejar vacío (comportamiento actual)
            End Try

            Dim ultimo As Integer = 0
            Dim query As String = "SELECT nCompro FROM comprobante ORDER BY idcprbnt DESC LIMIT 1"

            Using cmd As New MySqlCommand(query, con)
                Using dr As MySqlDataReader = cmd.ExecuteReader()
                    If dr.Read() Then
                        ultimo = Convert.ToInt32(dr("nCompro"))
                    End If
                End Using
            End Using



            If ultimo > 0 Then
                'codiPropTb.Text = ultimo.ToString()
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
        ' nComproTb.Focus()
        fechaPkd.Text = Today
        galDespTb.Focus()

    End Sub

    Private Sub EditarBtn_Click(sender As Object, e As EventArgs) Handles EditarBtn.Click  '============  EDITAR  ===========
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

    Private Sub GuardarBtn_Click(sender As Object, e As EventArgs) Handles GuardarBtn.Click '============  GUARDAR  ===========
        If con.State = ConnectionState.Closed Then
            con.Open()
        End If

        Dim fe As Date = fechaPkd.Value.ToString("yyyy-MM-dd")

        Dim combD As Double = 0
        Double.TryParse(galDespTb.Text, combD)

        Dim valorC As Double = 0
        Double.TryParse(valorTb.Text, valorC)

        Try

            guardar = New MySqlCommand("INSERT INTO comprobante (nCompro, nBoleta, galDesp, valor, placaCbz, nConte, propCbz, ruta, nombCond, nombDesp, fecha, periodo, semana, proxSem, codiProp)" & Chr(13) &
            "VALUES(@nCompro, @nBoleta, @galDesp, @valor, @placaCbz, @nConte, @propCbz, @ruta, @nombCond, @nombDesp, @fecha, @periodo, @semana, @proxSem, @codiProp)", con)


            guardar.Parameters.AddWithValue("@nCompro", nComproTb.Text)
            guardar.Parameters.AddWithValue("@nBoleta", nBoletaTb.Text)
            guardar.Parameters.AddWithValue("@galDesp", combD)
            guardar.Parameters.AddWithValue("@valor", valorC)
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

            If placaCbzTb.Text <> "" Then
                guardar.ExecuteNonQuery()
                MsgBox("Registo guardado")

                ' Guardar valores antes de limpiar
                Dim despAnterior As String = nombDespTb.Text
                Dim periodoAnterior As String = periodoTb.Text
                Dim semanaAnterior As String = semanaTb.Text

                limpiar()

                ' Restaurar despachador, periodo y semana
                nombDespTb.Text = despAnterior
                periodoTb.Text = periodoAnterior
                semanaTb.Text = semanaAnterior

                act()
                CamDGV.Enabled = True
                listadoCamDgv()
            Else
                MessageBox.Show("La casilla de Placa debe de ser llenada", "Combustible")
            End If

        Catch ex As Exception
            MsgBox("Elemento no pudo se almacenado", ex.StackTrace)
        End Try


    End Sub
    Private Sub amplitud()    '============  NÚMERO DE FACTURA   =============
        Dim tam As String = (nComproTb.Text)

        If Len(CStr(tam)) = 1 Then
            tam = "0000000" & tam
            nComproTb.Text = tam
        End If
        If Len(CStr(tam)) = 2 Then
            tam = "000000" & tam
            nComproTb.Text = tam
        End If
        If Len(CStr(tam)) = 3 Then
            tam = "00000" & tam
            nComproTb.Text = tam
        End If
        If Len(CStr(tam)) = 4 Then
            tam = "0000" & tam
            nComproTb.Text = tam
        End If
        If Len(CStr(tam)) = 5 Then
            tam = "000" & tam
            nComproTb.Text = tam
        End If
        If Len(CStr(tam)) = 6 Then
            tam = "00" & tam
            nComproTb.Text = tam
        End If
        If Len(CStr(tam)) = 7 Then
            tam = "0" & tam
            nComproTb.Text = tam
        End If
        If Len(CStr(tam)) = 8 Then
            tam = "" & tam
            nComproTb.Text = tam
        End If
    End Sub
    Private Sub ModificarBtn_Click(sender As Object, e As EventArgs) Handles ModificarBtn.Click '============  ACTUALIZAR  ===========
        actual()
        act()
        PanelP.Enabled = False
        CamDGV.Enabled = True
        Me.GuardarBtn.Visible = True
        listadoCamDgv()
    End Sub
    Public Sub actual()

        If con.State = ConnectionState.Closed Then
            con.Open()
        End If

        Dim fe As Date = fechaPkd.Value.ToString("yyyy-MM-dd")
        galDespTb.Text = galDespTb.Text.Replace(",", "")
        valorTb.Text = valorTb.Text.Replace(",", "")

        Dim actualizar As String
        actualizar = "UPDATE comprobante SET nCompro = '" & nComproTb.Text & "', nBoleta = '" & nBoletaTb.Text & "', galDesp = '" & galDespTb.Text & "', valor = '" & valorTb.Text & "', placaCbz = '" & placaCbzTb.Text & "', nConte = '" & nConteTb.Text & "',propCbz = '" & propCbzTb.Text & "', ruta = '" & rutaTb.Text & "', nombCond = '" & nombCondTb.Text & "', nombDesp = '" & nombDespTb.Text & "', fecha = '" & fe & "', periodo = '" & periodoTb.Text & "', semana = '" & semanaTb.Text & "', proxSem = '" & proxSemTb.Text & "', codiProp = '" & codiPropTb.Text & "' WHERE idcprbnt = '" & buscartxt.Text & "'"

        Dim act As New MySqlCommand(actualizar, con)
        act.ExecuteNonQuery()
        MsgBox("Registo Actualizado")
    End Sub

    Private Sub EliminarBtn_Click(sender As Object, e As EventArgs) Handles EliminarBtn.Click '============  ELIMINAR  ===========
        Try

            Dim opc As DialogResult = MsgBox("¿Desea Eliminar este registro?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Eliminar")
            If opc = Windows.Forms.DialogResult.Yes Then

                Dim eliminar As String

                eliminar = "DELETE FROM placas WHERE idplaca = '" & Conversion.Int(Me.buscartxt.Text) & "'"
                Dim eli As New MySqlCommand(eliminar, con)
                eli.ExecuteNonQuery()

                listadoCamDgv()

            End If
        Catch
            MessageBox.Show("Actualización Base de Datos, " & Chr(13) & "favor escoger de nuevo el registro y eliminarlo", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)

        End Try

        act()
    End Sub

    Private Sub CancelarBtn_Click(sender As Object, e As EventArgs) Handles CancelarBtn.Click  '============  CANCELAR  ===========
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
            PanelP.Enabled = True 'Para que se vea el Panel
            Dim y As Integer = Me.CamDGV.CurrentRow.Index
            Dim idcod As Integer = Me.CamDGV.Item(0, y).Value
            buscartxt.Text = idcod
            Seleccion()
            calcularletras()
            calcularTotalVenta()
            Me.EditarBtn.Enabled = True
            Me.EliminarBtn.Enabled = True
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

        Else
            MsgBox("Datos no encontrados")
        End If
    End Sub

    Private Sub placaBusqTB_TextChanged(sender As Object, e As EventArgs) Handles placaBusqTB.TextChanged
        ' Evitar ejecucion durante la carga del formulario o actualizacion programatica
        If cargandoFormulario OrElse actualizandoProgramaticamente Then Return
        ' Usar el metodo unificado de busqueda con filtros
        buscarConFiltros()
    End Sub

    Private Sub boletBusqTB_TextChanged(sender As Object, e As EventArgs) Handles boletBusqTB.TextChanged
        ' Evitar ejecucion durante la carga del formulario
        If cargandoFormulario Then Return
        ' Usar el metodo unificado de busqueda con filtros
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

            'placaCbzTb.AutoCompleteMode = AutoCompleteMode.Suggest
            'placaCbzTb.AutoCompleteSource = autoCompleteSource.cu
            rutaTb.AutoCompleteCustomSource = autoCompleteSource
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        Finally
            If con.State = ConnectionState.Open Then con.Close()
        End Try
    End Sub
    Public Sub PPropietario()
        If con.State = ConnectionState.Closed Then
            con.Open()
        End If
        Try
            Dim query As String = "SELECT propietario FROM placa;"

            Dim autoCompleteSource As New AutoCompleteStringCollection()


            Using cmd As New MySqlCommand(query, con)
                'con.Open()
                Dim reader As MySqlDataReader = cmd.ExecuteReader()

                While reader.Read()
                    autoCompleteSource.Add(reader("propietario").ToString())
                End While

                reader.Close()
            End Using

            'placaCbzTb.AutoCompleteMode = AutoCompleteMode.Suggest
            'placaCbzTb.AutoCompleteSource = autoCompleteSource.cu
            propCbzTb.AutoCompleteCustomSource = autoCompleteSource
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        Finally
            If con.State = ConnectionState.Open Then con.Close()
        End Try
    End Sub
    Public Sub PPlaca()
        If con.State = ConnectionState.Closed Then
            con.Open()
        End If
        Try
            Dim query As String = "SELECT placa FROM placa;"

            Dim autoCompleteSource As New AutoCompleteStringCollection()


            Using cmd As New MySqlCommand(query, con)
                'con.Open()
                Dim reader As MySqlDataReader = cmd.ExecuteReader()

                While reader.Read()
                    autoCompleteSource.Add(reader("placa").ToString())
                End While

                reader.Close()
            End Using

            'placaCbzTb.AutoCompleteMode = AutoCompleteMode.Suggest
            'placaCbzTb.AutoCompleteSource = autoCompleteSource.cu
            placaCbzTb.AutoCompleteCustomSource = autoCompleteSource
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
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
        Dim consulta As String
        Dim lista As Byte

        If propCbzTb.Text <> "" Then
            consulta = "SELECT * FROM placa WHERE propietario  = '" & propCbzTb.Text & "'"
            adaptador = New MySqlDataAdapter(consulta, con)
            datos = New DataSet
            adaptador.Fill(datos, "propietario")
            lista = datos.Tables("propietario").Rows.Count
        End If

        If lista <> 0 Then
            codiPropTb.Text = datos.Tables("propietario").Rows(0).Item("codigoPro").ToString
        Else
            MsgBox("Datos no encontrados")
        End If
    End Sub
    Private Sub codiPropTb_TextChanged(sender As Object, e As EventArgs) Handles codiPropTb.TextChanged
        ' Si estamos actualizando programaticamente, no ejecutar para evitar cascada
        If actualizandoProgramaticamente Then Return

        Try
            ' Limpiar lista antes de recargar
            placaCbzTb2.Items.Clear()
            If con.State = ConnectionState.Closed Then con.Open()
            ' Solo buscar si hay algo escrito
            If codiPropTb.Text.Trim() <> "" Then
                ' Buscar placas relacionadas
                Dim sql As String = "SELECT placa FROM placa WHERE codigoPro LIKE @codi"
                Using cmd As New MySqlCommand(sql, con)
                    cmd.Parameters.AddWithValue("@codi", "%" & codiPropTb.Text & "%")
                    Using drLocal As MySqlDataReader = cmd.ExecuteReader()
                        While drLocal.Read()
                            placaCbzTb2.Items.Add(drLocal("placa").ToString())
                        End While
                    End Using
                End Using

                ' Buscar propietario y llenar propCbzTb
                Dim sqlProp As String = "SELECT nPropietario FROM propietario WHERE codProp = @codProp"
                Using cmdProp As New MySqlCommand(sqlProp, con)
                    cmdProp.Parameters.AddWithValue("@codProp", codiPropTb.Text.Trim())
                    Using drProp As MySqlDataReader = cmdProp.ExecuteReader()
                        If drProp.Read() Then
                            propCbzTb.Text = drProp("nPropietario").ToString()
                        Else
                            propCbzTb.Text = ""
                        End If
                    End Using
                End Using
            Else
                ' Si el campo está vacío, limpiar propCbzTb
                propCbzTb.Text = ""
            End If

        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        Finally
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
        End Try
    End Sub
    Private Sub placaCbzTb2_ItemClick(sender As Object, e As EventArgs) Handles placaCbzTb2.ItemClick

        placaCbzTb.Text = placaCbzTb2.SelectedItem.ToString()

    End Sub

    Private Sub comprobante_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        'If e.KeyCode = Keys.Enter Then
        ' Mover al siguiente control
        'SelectNextControl(ActiveControl, True, True, True, True)
        'e.SuppressKeyPress = True ' Evita que el sistema suene o muestre el beep
        'End If
    End Sub

    Private Sub calcularletras()  '============  CALCULO DE LETRAS   =============
        pLetras.Text = ""
        If IsNumeric(galDespTb.Text) Then
            pLetras.Text = LETRAS(galDespTb.Text)
            ' Else
            '     MessageBox.Show("Ingrese por favor números", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
        'facTotTb.Focus()
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
        PrintComprobante.Print()
    End Sub
    Private Sub ImprimirBt2_Click(sender As Object, e As EventArgs) Handles ImprimirBt2.Click
        PrintDocumento.Print()
    End Sub

    Private Sub PrintComprobante_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles PrintComprobante.PrintPage
        ' Usar conexión local para no interferir con la conexión del formulario
        Using conLocal As MySqlConnection = ModuloConexion.ObtenerConexion()
            Try
                conLocal.Open()

                Dim query As String = "SELECT nEmpre, rtn FROM empresa LIMIT 1"
                Using comando As New MySqlCommand(query, conLocal)
                    Using lector As MySqlDataReader = comando.ExecuteReader()
                        If lector.Read() Then
                            Dim nEmpreP As String = lector("nEmpre").ToString()
                            Dim rtnP As String = lector("rtn").ToString()

                            ' Cerrar lector antes de dibujar (ya tenemos los datos)
                            lector.Close()

                            Dim fe As String = fechaPkd.Value.ToString("dd-MM-yyyy")

                            ' Cargar imagen
                            Dim imgLocal As Image = Nothing
                            Try
                                imgLocal = Image.FromFile("C:\emtracc\camion.jpg")
                                e.Graphics.DrawImage(imgLocal, 5, 5, 250, 100)
                            Catch
                                ' Si no se encuentra la imagen, continuar sin ella
                            Finally
                                If imgLocal IsNot Nothing Then imgLocal.Dispose()
                            End Try

                            ' Definir fuentes
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

                            ' Dibujar comprobante
                            e.Graphics.DrawString(nEmpreP, uFont, Brushes.Black, RectangleF.op_Implicit(displayRectangle), format1)
                            e.Graphics.DrawString("RTN: " & rtnP, mFont4, Brushes.Black, 60, 135)
                            e.Graphics.DrawString("__________________________", DFont, Brushes.Black, 10, 135)
                            e.Graphics.DrawString("COMPROBANTE DE DESPACHO DE COMBUSTIBLE", GFont2, Brushes.Black, RectangleF.op_Implicit(displayRectangle2), format1)
                            e.Graphics.DrawString("__________________________", DFont, Brushes.Black, 10, 180)

                            e.Graphics.DrawString("FECHA:" & fe, mFont2, Brushes.Black, 120, 200)
                            e.Graphics.DrawString("Comprobante N°: " & nComproTb.Text, GFont2, Brushes.Black, 25, 220)
                            e.Graphics.DrawString("____________________", DFont, Brushes.Black, 35, 222)

                            e.Graphics.DrawString("Próxima Semana: " & proxSemTb.Text, mFont2, Brushes.Black, 10, 245)
                            e.Graphics.DrawString("Galones Despachados: " & galDespTb.Text, mFont2, Brushes.Black, 10, 260)
                            e.Graphics.DrawString("" & pLetras.Text, mFont, Brushes.Black, 10, 275)

                            e.Graphics.DrawString("=== Propietario Cabezal ===", mFont2, Brushes.Black, 50, 295)
                            e.Graphics.DrawString(propCbzTb.Text, mFont2, Brushes.Black, 10, 310)

                            e.Graphics.DrawString("Cabezal:   " & placaCbzTb.Text, mFont2, Brushes.Black, 30, 325)
                            e.Graphics.DrawString("Contenedor:   " & nConteTb.Text, mFont2, Brushes.Black, 30, 340)
                            e.Graphics.DrawString("N° Boleta: " & nBoletaTb.Text, mFont2, Brushes.Black, 30, 355)

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

                            ' Liberar fuentes
                            mFont.Dispose()
                            mFont2.Dispose()
                            mFont4.Dispose()
                            GFont2.Dispose()
                            uFont.Dispose()
                            DFont.Dispose()
                            format1.Dispose()
                        End If
                    End Using
                End Using

            Catch ex As Exception
                MessageBox.Show("Error: " & ex.Message)
            End Try
        End Using
    End Sub

    Private Sub PrintDocumento_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles PrintDocumento.PrintPage
        ' Usar conexión local para no interferir con la conexión del formulario
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

                            ' Definir fuentes
                            Dim mFont As New Font("Calibri", 8, GraphicsUnit.Point)
                            Dim mFont2 As New Font("Calibri", 10, FontStyle.Bold, GraphicsUnit.Point)
                            Dim mFont4 As New Font("Calibri", 9, FontStyle.Bold, GraphicsUnit.Point)
                            Dim GFont2 As New Font("Calibri", 12, FontStyle.Bold, GraphicsUnit.Point)
                            Dim uFont As New Font("Calibri", 10, FontStyle.Bold, GraphicsUnit.Point)
                            Dim DFont As New Font("Calibri", 13, FontStyle.Bold, GraphicsUnit.Point)

                            Dim format1 As New StringFormat(StringFormatFlags.NoClip)
                            format1.LineAlignment = StringAlignment.Near
                            format1.Alignment = StringAlignment.Center

                            ' Cargar imagen
                            Dim imgLocal As Image = Nothing
                            Try
                                imgLocal = Image.FromFile("C:\emtracc\camion.jpg")
                                e.Graphics.DrawImage(imgLocal, 5, 5, 250, 100)
                            Catch
                                ' Si no se encuentra la imagen, continuar sin ella
                            Finally
                                If imgLocal IsNot Nothing Then imgLocal.Dispose()
                            End Try

                            ' Dibujar comprobante (logo ocupa y=5 a y=105)
                            Dim y As Integer = 110
                            Dim rectEmpresa As New Rectangle(New Point(5, y), New Size(240, 35))
                            e.Graphics.DrawString(nEmpreP, uFont, Brushes.Black, RectangleF.op_Implicit(rectEmpresa), format1)

                            y = 145
                            e.Graphics.DrawString("RTN: " & rtnP, mFont4, Brushes.Black, 60, y)
                            y = 155
                            e.Graphics.DrawString("__________________________", DFont, Brushes.Black, 10, y)

                            y = 172
                            Dim rectTitulo As New Rectangle(New Point(5, y), New Size(240, 35))
                            e.Graphics.DrawString("COMPROBANTE DE DESPACHO DE COMBUSTIBLE", GFont2, Brushes.Black, RectangleF.op_Implicit(rectTitulo), format1)

                            y = 200
                            e.Graphics.DrawString("__________________________", DFont, Brushes.Black, 10, y)

                            y = 222
                            e.Graphics.DrawString("FECHA:" & fe, mFont2, Brushes.Black, 120, y)

                            y = 237
                            e.Graphics.DrawString("Periodo - Semana " & periodoTb.Text & "-" & semanaTb.Text, GFont2, Brushes.Black, 40, y)

                            y = 257
                            e.Graphics.DrawString("Comprobante N°: " & nComproTb.Text, GFont2, Brushes.Black, 25, y)
                            e.Graphics.DrawString("____________________", DFont, Brushes.Black, 35, y + 2)

                            y = 277
                            e.Graphics.DrawString("=== Propietario Cabezal ===", mFont2, Brushes.Black, 50, y)
                            y = 292
                            e.Graphics.DrawString(propCbzTb.Text, mFont2, Brushes.Black, 10, y)
                            y = 307
                            e.Graphics.DrawString("Cabezal:   " & placaCbzTb.Text, mFont2, Brushes.Black, 30, y)
                            y = 322
                            e.Graphics.DrawString("Contenedor:   " & nConteTb.Text, mFont2, Brushes.Black, 30, y)
                            y = 337
                            e.Graphics.DrawString("N° Boleta: " & nBoletaTb.Text, mFont2, Brushes.Black, 30, y)
                            y = 352
                            e.Graphics.DrawString("Ruta: " & rutaTb.Text, mFont4, Brushes.Black, 10, y)
                            y = 360
                            e.Graphics.DrawString("_____________________________", DFont, Brushes.Black, 10, y)

                            y = 380
                            e.Graphics.DrawString("=== Nombre Conductor ===", mFont2, Brushes.Black, 50, y)
                            y = 395
                            e.Graphics.DrawString(nombCondTb.Text, mFont2, Brushes.Black, 10, y)
                            y = 396
                            e.Graphics.DrawString("_____________________________", DFont, Brushes.Black, 10, y)

                            y = 423
                            e.Graphics.DrawString("=== Nombre Despachador ===", mFont2, Brushes.Black, 50, y)
                            y = 438
                            e.Graphics.DrawString(nombDespTb.Text, mFont2, Brushes.Black, 10, y)
                            y = 442
                            e.Graphics.DrawString("_____________________________", DFont, Brushes.Black, 10, y)

                            y = 466
                            e.Graphics.DrawString("Galones Despachados: " & galDespTb.Text, mFont2, Brushes.Black, 10, y)
                            y = 481
                            e.Graphics.DrawString("Precio: " & valorTb.Text, mFont2, Brushes.Black, 10, y)
                            y = 496
                            e.Graphics.DrawString(totVtalb.Text, mFont2, Brushes.Black, 10, y)
                            y = 510
                            e.Graphics.DrawString("_____________________________", DFont, Brushes.Black, 10, y)

                            ' Liberar fuentes
                            mFont.Dispose()
                            mFont2.Dispose()
                            mFont4.Dispose()
                            GFont2.Dispose()
                            uFont.Dispose()
                            DFont.Dispose()
                            format1.Dispose()
                        End If
                    End Using
                End Using

            Catch ex As Exception
                MessageBox.Show("Error: " & ex.Message)
            End Try
        End Using
    End Sub

    Private Sub PreviaBtn_Click(sender As Object, e As EventArgs) Handles PreviaBtn.Click
        Try
            PrintPreviewComprobante.PrintPreviewControl.Zoom = 1.3
            PrintPreviewComprobante.Height = 700
            PrintPreviewComprobante.Width = 500

            PanelP.Enabled = True

            PrintComprobante.PrinterSettings.Copies = 1 'Cantidad de Impresiones

            ' Mostrar vista previa
            PrintPreviewComprobante.Document = PrintComprobante
            PrintPreviewComprobante.ShowDialog()

            CancelarBtn.Enabled = True
        Catch ex As Exception
            MessageBox.Show("Error al mostrar vista previa del comprobante: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
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

    Private Sub periodoTb_SelectedIndexChanged(sender As Object, e As EventArgs) Handles periodoTb.SelectedIndexChanged

    End Sub

    Private Sub placaCbzTb_TextChanged(sender As Object, e As EventArgs) Handles placaCbzTb.TextChanged
        Try
            ' Activar bandera para evitar cascada de eventos
            actualizandoProgramaticamente = True

            If String.IsNullOrWhiteSpace(placaCbzTb.Text) Then
                propCbzTb.Text = ""
                codiPropTb.Text = ""
                actualizandoProgramaticamente = False
                Return
            End If

            ' Solo buscar si tiene al menos 3 caracteres (evita busquedas innecesarias)
            If placaCbzTb.Text.Trim().Length < 3 Then
                actualizandoProgramaticamente = False
                Return
            End If

            ' Variables para almacenar los valores
            Dim codigoPro As String = ""
            Dim propietarioNombre As String = ""
            Dim codPropResult As String = ""
            Dim nPropietarioResult As String = ""
            Dim encontroPlaca As Boolean = False
            Dim encontroPropietario As Boolean = False

            If con.State = ConnectionState.Closed Then
                con.Open()
            End If

            ' Primera consulta: buscar placa (primero exacta, luego con LIKE)
            Dim placaBuscada As String = placaCbzTb.Text.Trim().ToUpper()

            ' Intentar busqueda exacta primero
            Dim sqlPlaca As String = "SELECT codigoPro, propietario FROM placa WHERE UPPER(TRIM(placa)) = @placa"
            Using cmdPlaca As New MySqlCommand(sqlPlaca, con)
                cmdPlaca.Parameters.AddWithValue("@placa", placaBuscada)
                Using drPlaca As MySqlDataReader = cmdPlaca.ExecuteReader()
                    If drPlaca.Read() Then
                        codigoPro = If(drPlaca("codigoPro") IsNot DBNull.Value, drPlaca("codigoPro").ToString().Trim(), "")
                        propietarioNombre = If(drPlaca("propietario") IsNot DBNull.Value, drPlaca("propietario").ToString().Trim(), "")
                        encontroPlaca = True
                    End If
                End Using
            End Using

            ' Si no encontró exacta, buscar con LIKE
            If Not encontroPlaca Then
                Dim sqlPlacaLike As String = "SELECT codigoPro, propietario FROM placa WHERE UPPER(placa) LIKE @placa LIMIT 1"
                Using cmdPlacaLike As New MySqlCommand(sqlPlacaLike, con)
                    cmdPlacaLike.Parameters.AddWithValue("@placa", "%" & placaBuscada & "%")
                    Using drPlacaLike As MySqlDataReader = cmdPlacaLike.ExecuteReader()
                        If drPlacaLike.Read() Then
                            codigoPro = If(drPlacaLike("codigoPro") IsNot DBNull.Value, drPlacaLike("codigoPro").ToString().Trim(), "")
                            propietarioNombre = If(drPlacaLike("propietario") IsNot DBNull.Value, drPlacaLike("propietario").ToString().Trim(), "")
                            encontroPlaca = True
                        End If
                    End Using
                End Using
            End If

            ' Segunda consulta: buscar propietario
            If encontroPlaca Then
                ' Primero intentar por codigoPro si no está vacío
                If codigoPro <> "" Then
                    Dim sqlPropietario As String = "SELECT codProp, nPropietario FROM propietario WHERE UPPER(TRIM(codProp)) = @codProp"
                    Using cmdPropietario As New MySqlCommand(sqlPropietario, con)
                        cmdPropietario.Parameters.AddWithValue("@codProp", codigoPro.ToUpper())
                        Using drPropietario As MySqlDataReader = cmdPropietario.ExecuteReader()
                            If drPropietario.Read() Then
                                nPropietarioResult = drPropietario("nPropietario").ToString()
                                codPropResult = drPropietario("codProp").ToString()
                                encontroPropietario = True
                            End If
                        End Using
                    End Using
                End If

                ' Si no encontró por codProp, buscar por nombre de propietario
                If Not encontroPropietario AndAlso propietarioNombre <> "" Then
                    Dim sqlPropietario2 As String = "SELECT codProp, nPropietario FROM propietario WHERE UPPER(TRIM(nPropietario)) = @nPropietario"
                    Using cmdPropietario2 As New MySqlCommand(sqlPropietario2, con)
                        cmdPropietario2.Parameters.AddWithValue("@nPropietario", propietarioNombre.ToUpper())
                        Using drPropietario2 As MySqlDataReader = cmdPropietario2.ExecuteReader()
                            If drPropietario2.Read() Then
                                nPropietarioResult = drPropietario2("nPropietario").ToString()
                                codPropResult = drPropietario2("codProp").ToString()
                                encontroPropietario = True
                            End If
                        End Using
                    End Using
                End If

                ' Si aún no encuentra, buscar con LIKE en nombre
                If Not encontroPropietario AndAlso propietarioNombre <> "" Then
                    Dim sqlPropietario3 As String = "SELECT codProp, nPropietario FROM propietario WHERE UPPER(nPropietario) LIKE @nPropietario LIMIT 1"
                    Using cmdPropietario3 As New MySqlCommand(sqlPropietario3, con)
                        cmdPropietario3.Parameters.AddWithValue("@nPropietario", "%" & propietarioNombre.ToUpper() & "%")
                        Using drPropietario3 As MySqlDataReader = cmdPropietario3.ExecuteReader()
                            If drPropietario3.Read() Then
                                nPropietarioResult = drPropietario3("nPropietario").ToString()
                                codPropResult = drPropietario3("codProp").ToString()
                                encontroPropietario = True
                            End If
                        End Using
                    End Using
                End If
            End If

            ' Asignar valores a los TextBox
            If encontroPropietario Then
                propCbzTb.Text = nPropietarioResult
                codiPropTb.Text = codPropResult
            ElseIf encontroPlaca AndAlso propietarioNombre <> "" Then
                ' Si encontró la placa pero no el propietario en la tabla propietario,
                ' usar el nombre guardado directamente en la tabla placa
                propCbzTb.Text = propietarioNombre
                codiPropTb.Text = codigoPro
            Else
                propCbzTb.Text = ""
                codiPropTb.Text = ""
            End If

        Catch ex As Exception
            MessageBox.Show("Error al buscar datos de la placa: " & ex.Message, "Error")
        Finally
            actualizandoProgramaticamente = False
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
        End Try
    End Sub

    Private Sub PanelP_Paint(sender As Object, e As PaintEventArgs) Handles PanelP.Paint

    End Sub

    ' ============ NUEVOS METODOS PARA FILTROS ============

    Private Sub cargarDespachadores()
        Try
            If con.State = ConnectionState.Closed Then con.Open()

            despachadorCb.Items.Clear()
            despachadorCb.Items.Add("-- Todos --")

            Dim sql As String = "SELECT DISTINCT nombDesp FROM comprobante WHERE nombDesp IS NOT NULL AND nombDesp <> '' ORDER BY nombDesp"
            Using cmd As New MySqlCommand(sql, con)
                Using dr As MySqlDataReader = cmd.ExecuteReader()
                    While dr.Read()
                        despachadorCb.Items.Add(dr("nombDesp").ToString())
                    End While
                End Using
            End Using

            despachadorCb.SelectedIndex = 0

        Catch ex As Exception
            MessageBox.Show("Error al cargar despachadores: " & ex.Message, "Error")
        Finally
            If con.State = ConnectionState.Open Then con.Close()
        End Try
    End Sub

    Private Sub buscarConFiltros()
        Try
            If con.State = ConnectionState.Closed Then con.Open()

            Dim sql As New System.Text.StringBuilder()
            sql.Append("SELECT idcprbnt, nCompro, nBoleta, DATE_FORMAT(fecha, '%d/%m/%Y') AS fecha, nombDesp, propCbz, placaCbz, periodo, semana, ruta, galDesp, valor ")
            sql.Append("FROM comprobante WHERE 1=1 ")

            Dim cmd As New MySqlCommand()
            cmd.Connection = con

            ' Filtro por placa
            If placaBusqTB.Text.Trim() <> "" Then
                sql.Append("AND placaCbz LIKE @placa ")
                cmd.Parameters.AddWithValue("@placa", "%" & placaBusqTB.Text.Trim() & "%")
            End If

            ' Filtro por boleta
            If boletBusqTB.Text.Trim() <> "" Then
                sql.Append("AND nBoleta LIKE @boleta ")
                cmd.Parameters.AddWithValue("@boleta", "%" & boletBusqTB.Text.Trim() & "%")
            End If

            ' Filtro por fecha
            If chkUsarFecha.Checked Then
                sql.Append("AND DATE(fecha) >= @fechaDesde AND DATE(fecha) <= @fechaHasta ")
                cmd.Parameters.AddWithValue("@fechaDesde", fechaDesdePk.Value.ToString("yyyy-MM-dd"))
                cmd.Parameters.AddWithValue("@fechaHasta", fechaHastaPk.Value.ToString("yyyy-MM-dd"))
            End If

            ' Filtro por despachador
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

            ' Calcular totales
            Dim totalRegistros As Integer = dt.Rows.Count
            Dim totalGalones As Double = 0
            Dim totalVenta As Double = 0
            For Each row As DataRow In dt.Rows
                Dim gal As Double = 0
                Dim val As Double = 0
                If row("galDesp") IsNot DBNull.Value Then
                    gal = Convert.ToDouble(row("galDesp"))
                    totalGalones += gal
                End If
                If row("valor") IsNot DBNull.Value Then
                    val = Convert.ToDouble(row("valor"))
                End If
                totalVenta += gal * val
            Next

            ' Mostrar totales en los labels
            lblTotales.Text = String.Format("Registros: {0}  |  Total Galones: {1:N2}", totalRegistros, totalGalones)
            totVtalb.Text = String.Format("Total Venta: L. {0:N2}", totalVenta)

        Catch ex As Exception
            MessageBox.Show("Error al buscar: " & ex.Message, "Error")
        Finally
            If con.State = ConnectionState.Open Then con.Close()
        End Try
    End Sub

    ' ============ EVENTOS DE FILTROS ============

    Private Sub chkUsarFecha_CheckedChanged(sender As Object, e As EventArgs) Handles chkUsarFecha.CheckedChanged
        fechaDesdePk.Enabled = chkUsarFecha.Checked
        fechaHastaPk.Enabled = chkUsarFecha.Checked
    End Sub

    Private Sub buscarBtn_Click(sender As Object, e As EventArgs) Handles buscarBtn.Click
        buscarConFiltros()
    End Sub

    Private Sub despachadorCb_SelectedIndexChanged(sender As Object, e As EventArgs) Handles despachadorCb.SelectedIndexChanged
        ' Evitar ejecucion durante la carga del formulario
        If cargandoFormulario Then Return
        ' Filtrar automaticamente al cambiar despachador
        buscarConFiltros()
    End Sub

    Private Sub PreviaBtn2_Click(sender As Object, e As EventArgs) Handles PreviaBtn2.Click
        Try
            PrintPreviewDocumento.PrintPreviewControl.Zoom = 1.3
            PrintPreviewDocumento.Height = 700
            PrintPreviewDocumento.Width = 500

            PanelP.Enabled = True

            PrintDocumento.PrinterSettings.Copies = 1 'Cantidad de Impresiones

            ' Mostrar vista previa
            PrintPreviewDocumento.Document = PrintDocumento
            PrintPreviewDocumento.ShowDialog()

            CancelarBtn.Enabled = True
        Catch ex As Exception
            MessageBox.Show("Error al mostrar vista previa del documento: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


End Class