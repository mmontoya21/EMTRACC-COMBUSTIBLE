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
    Private Sub comprobante_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        On Error Resume Next

        System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("es-HN")
        System.Threading.Thread.CurrentThread.CurrentCulture.DateTimeFormat.ShortDatePattern = "yyyy/MM/dd"
        System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencyDecimalSeparator = "."
        System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencyGroupSeparator = ","
        System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator = "."
        System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.NumberGroupSeparator = ","

        conectar()


        act()
        listadoCamDgv()
        CamDGV.BackgroundColor = colorFondo
        CamDGV.RowsDefaultCellStyle.BackColor = Color.Bisque
        CamDGV.AlternatingRowsDefaultCellStyle.BackColor = Color.Lavender

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

        Dim servidor As String = "localhost"
        'Dim servidor As String = "192.168.68.101"
        Dim baseDatos As String = "givemefuel"
        Dim userid As String = "root"
        Dim clave As String = ""


        'EMTRACC NUBE
        'con.ConnectionString = "Server=193.203.166.219   ; Database=u282951626_emtraccF; Uid=u282951626_mmontoya; Pwd=Paradoja25"

        'con.ConnectionString = "Server=185.224.137.172; Database=u282951626_eda; Uid=u282951626_edauser; Pwd=@Paradoja18"

        con.ConnectionString = "Server=" & servidor & "; Database=" & baseDatos & "; Uid = " & userid & "; Pwd = " & clave

        Try

            con.Open()

            'MsgBox("El sistema se conectó")
            MessageBox.Show("El sistema esá conectado", "Combustible")

        Catch ex As Exception
            MsgBox("No se conecto por: " & ex.Message)

        End Try


    End Sub

    Private Sub listadoCamDgv() 'Muestra los datos
        Dim table As New DataTable()
        Dim adaptadoListado As New MySqlDataAdapter("SELECT idcprbnt, nCompro, nBoleta, propCbz, placaCbz, periodo, semana, ruta FROM comprobante", con)
        adaptadoListado.Fill(table)

        CamDGV.DataSource = table

        ListadoD()

    End Sub
    Private Sub ListadoD()
        CamDGV.Columns(0).HeaderText = "Id"
        CamDGV.Columns(0).Width = 1

        CamDGV.Columns(1).HeaderText = "Comprobante"
        CamDGV.Columns(1).Width = 75

        CamDGV.Columns(2).HeaderText = "Boleta"
        CamDGV.Columns(2).Width = 75

        CamDGV.Columns(3).HeaderText = "Propietario"
        CamDGV.Columns(3).Width = 300

        CamDGV.Columns(4).HeaderText = "Placa"
        CamDGV.Columns(4).Width = 100

        CamDGV.Columns(5).HeaderText = "Per"
        CamDGV.Columns(5).Width = 40

        CamDGV.Columns(6).HeaderText = "Sem"
        CamDGV.Columns(6).Width = 40

        CamDGV.Columns(7).HeaderText = "Ruta"
        CamDGV.Columns(7).Width = 300
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
        If con.State = ConnectionState.Closed Then
            con.Open()
        End If

        Try

            ' Consulta para obtener el último registro (campo nFactura)
            Dim query As String = "SELECT nCompro FROM comprobante ORDER BY idcprbnt DESC LIMIT 1"
            Dim comando As New MySqlCommand(query, con)
            Dim lector As MySqlDataReader = comando.ExecuteReader()


            'lector.Close()

            ' Verificar si hay registros
            If lector.Read() Then
                ' Asignar el valor de nFactura al TextBox
                codiPropTb.Text = lector("nCompro").ToString()

                Dim nfacta As Double = Double.Parse(codiPropTb.Text)
                nComproTb.Text = nfacta + 1 ' Suma factura
                amplitud()
            Else
                nComproTb.Text = 1
                amplitud()
            End If

            lector.Close()
            ''
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        Finally
            ' Cerrar la conexión
            con.Close()
        End Try

        limpiar()
        PanelP.Enabled = True
        GuardarBtn.Enabled = True
        CamDGV.Enabled = False
        CancelarBtn.Enabled = True
        NuevoBtn.Enabled = False
        nComproTb.Focus()
        fechaPkd.Text = Today
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

        'Try

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


        guardar.ExecuteNonQuery()
        MsgBox("Registo guardado")

        'Catch ex As Exception
        'MsgBox("Elemento no pudo se almacenado", ex.StackTrace)
        'End Try

        limpiar()

        act()

        CamDGV.Enabled = True
        listadoCamDgv()
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
            Me.placaBusqTB.Text = Me.CamDGV.Item(4, i).Value
            PanelP.Enabled = True 'Para que se vea el Panel
            Dim y As Integer = Me.CamDGV.CurrentRow.Index
            Dim idcod As Integer = Me.CamDGV.Item(0, y).Value
            buscartxt.Text = idcod
            Seleccion()
            calcularletras()
            Me.EditarBtn.Enabled = True
            Me.EliminarBtn.Enabled = True
        End If
    End Sub
    Public Sub Seleccion()
        Dim consulta As String
        Dim lista As Byte

        If placaBusqTB.Text <> "" Then
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
        listadoCamDgv()
    End Sub

    Private Sub placaBusqTB_TextChanged(sender As Object, e As EventArgs) Handles placaBusqTB.TextChanged
        Dim table As New DataTable()
        Dim adaptadoListado As New MySqlDataAdapter("SELECT idcprbnt, nCompro, nBoleta, propCbz, placaCbz, periodo, semana, ruta FROM comprobante WHERE placaCbz LIKE '%" & placaBusqTB.Text & "%'", con)
        adaptadoListado.Fill(table)

        CamDGV.DataSource = table

        ListadoD()
    End Sub

    Private Sub boletBusqTB_TextChanged(sender As Object, e As EventArgs) Handles boletBusqTB.TextChanged
        Dim table As New DataTable()
        Dim adaptadoListado As New MySqlDataAdapter("SELECT idcprbnt, nCompro, nBoleta, propCbz, placaCbz, periodo, semana, ruta FROM comprobante WHERE nBoleta LIKE '%" & boletBusqTB.Text & "%'", con)
        adaptadoListado.Fill(table)

        CamDGV.DataSource = table

        ListadoD()
    End Sub
    Public Sub Rutas()

        Try
            Dim query As String = "SELECT rutas FROM rutas;"

            Dim autoCompleteSource As New AutoCompleteStringCollection()


            Using cmd As New MySqlCommand(query, con)
                'con.Open()
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
            conexion.Close()
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
            conexion.Close()
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
            conexion.Close()
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
            consulta = "SELECT * FROM placa WHERE propietario  = '%" & propCbzTb.Text & "%'"
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
        Try
            ' Limpiar lista antes de recargar
            placaCbzTb2.Items.Clear()

            ' Solo buscar si hay algo escrito
            If codiPropTb.Text.Trim() <> "" Then
                'con.Open()
                Dim sql As String = "SELECT placa FROM placa WHERE codigoPro LIKE @codi"
                Dim cmd As New MySqlCommand(sql, con)
                cmd.Parameters.AddWithValue("@codi", "%" & codiPropTb.Text & "%")

                Dim dr As MySqlDataReader = cmd.ExecuteReader()
                While dr.Read()
                    placaCbzTb2.Items.Add(dr("placa").ToString())
                End While
                dr.Close()
            End If

        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        Finally
            If con.State = ConnectionState.Open Then
                conexion.Close()
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
        If IsNumeric(valorTb.Text) Then
            pLetras.Text = LETRAS(valorTb.Text)
            ' Else
            '     MessageBox.Show("Ingrese por favor números", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
        'facTotTb.Focus()
        valorTb.SelectionStart = 0
        valorTb.SelectionLength = valorTb.ToString.Length
    End Sub
    Private Sub valorTb_Leave(sender As Object, e As EventArgs) Handles valorTb.Leave
        calcularletras()
    End Sub

    Private Sub ButtonX6_Click(sender As Object, e As EventArgs) Handles ButtonX6.Click
        listadoCamDgv()
    End Sub
End Class