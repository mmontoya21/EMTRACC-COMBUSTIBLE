Imports System.Data
Imports MySql.Data.MySqlClient
Imports MySql.Data
Public Class placa
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
    Private Sub placa_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        conectar()
        propiet()
        placaAutoC()


        act()
        listadoCamDgv()
        EstilizarDataGridView(CamDGV)

        Me.BackColor = Color.SteelBlue

        PanelP.Enabled = False

    End Sub

    Private Sub placa_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        ' Cerrar la conexión al cerrar el formulario
        Try
            If con IsNot Nothing AndAlso con.State = ConnectionState.Open Then
                con.Close()
            End If
        Catch ex As Exception
            ' Ignorar errores al cerrar
        End Try
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
                MessageBox.Show("El sistema está conectado", "Combustible")
            End If
        Catch ex As Exception
            MsgBox("No se conecto por: " & ex.Message)
        End Try
    End Sub

    Private Sub AbrirConexion()
        Try
            ' Si la conexión es nula o está rota, obtener una nueva
            If con Is Nothing OrElse con.State = ConnectionState.Broken Then
                con = ModuloConexion.ObtenerConexion()
            End If
            ' Abrir si está cerrada
            If con.State = ConnectionState.Closed Then
                con.Open()
            End If
        Catch ex As Exception
            MessageBox.Show("Error al abrir conexión: " & ex.Message, "Error")
        End Try
    End Sub

    Private Sub CerrarConexion()
        Try
            If con IsNot Nothing AndAlso con.State = ConnectionState.Open Then
                con.Close()
            End If
        Catch ex As Exception
            MessageBox.Show("Error al cerrar conexión: " & ex.Message, "Error")
        End Try
    End Sub

    Private Sub VerificarConexion()
        Try
            ' Si la conexión es nula o está rota, obtener una nueva
            If con Is Nothing OrElse con.State = ConnectionState.Broken Then
                con = ModuloConexion.ObtenerConexion()
            End If
            ' Abrir si está cerrada
            If con.State = ConnectionState.Closed Then
                con.Open()
            End If
        Catch ex As Exception
            MessageBox.Show("Error al verificar conexión: " & ex.Message, "Error")
        End Try
    End Sub

    Public Sub placaAutoC()
        Try
            Dim query As String = "SELECT codProp FROM propietario;"
            Dim autoCompleteSource As New AutoCompleteStringCollection()

            AbrirConexion()
            Using cmd As New MySqlCommand(query, con)
                Using reader As MySqlDataReader = cmd.ExecuteReader()
                    While reader.Read()
                        autoCompleteSource.Add(reader("codProp").ToString())
                    End While
                End Using
            End Using

            codTb.AutoCompleteCustomSource = autoCompleteSource
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        Finally
            CerrarConexion()
        End Try
    End Sub
    Public Sub propiet()
        Try
            Dim query As String = "SELECT nPropietario FROM propietario;"
            Dim autoCompleteSource As New AutoCompleteStringCollection()

            AbrirConexion()
            Using cmd As New MySqlCommand(query, con)
                Using reader As MySqlDataReader = cmd.ExecuteReader()
                    While reader.Read()
                        autoCompleteSource.Add(reader("nPropietario").ToString())
                    End While
                End Using
            End Using

            propTb.AutoCompleteCustomSource = autoCompleteSource
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        Finally
            CerrarConexion()
        End Try
    End Sub
    Private Sub listadoCamDgv() 'Muestra los datos
        Try
            Dim table As New DataTable()
            AbrirConexion()
            Using adaptadoListado As New MySqlDataAdapter("SELECT idPlaca, codigoPro, placa, propietario,  observaciones FROM placa", con)
                adaptadoListado.Fill(table)
            End Using

            CamDGV.DataSource = table
            ListadoD()
        Catch ex As Exception
            MessageBox.Show("Error al cargar datos: " & ex.Message, "Error")
        Finally
            CerrarConexion()
        End Try
    End Sub
    Private Sub ListadoD()
        If CamDGV.Columns.Count < 5 Then Return

        CamDGV.Columns(0).HeaderText = "Id"
        CamDGV.Columns(0).Width = 1
        CamDGV.Columns(0).Visible = False

        CamDGV.Columns(1).HeaderText = "Código"
        CamDGV.Columns(1).Width = 100

        CamDGV.Columns(2).HeaderText = "Placa"
        CamDGV.Columns(2).Width = 100

        CamDGV.Columns(3).HeaderText = "Propietario"
        CamDGV.Columns(3).Width = 250

        CamDGV.Columns(4).HeaderText = "Observaciones"
        CamDGV.Columns(4).Width = 250
    End Sub
    Sub limpiar()
        Me.codTb.Text = ""
        Me.propTb.Text = ""
        Me.placaTb.Text = ""
        Me.obserTb.Text = ""
        Me.buscartxt.Text = ""
    End Sub
    Private Sub NuevoBtn_Click(sender As Object, e As EventArgs) Handles NuevoBtn.Click  '============  NUEVO  ===========
        limpiar()
        PanelP.Enabled = True
        GuardarBtn.Enabled = True
        CamDGV.Enabled = False
        CancelarBtn.Enabled = True
        NuevoBtn.Enabled = False

    End Sub
    Private Sub EditarBtn_Click(sender As Object, e As EventArgs) Handles EditarBtn.Click  '============ EDITAR  ===========
        PanelP.Enabled = True
        Me.CamDGV.Enabled = False
        Me.GuardarBtn.Enabled = False
        Me.GuardarBtn.Visible = False
        Me.ModificarBtn.Enabled = True
        Me.EditarBtn.Enabled = False
        Me.CancelarBtn.Enabled = True
        Me.NuevoBtn.Enabled = False
        Me.EliminarBtn.Enabled = False
        Me.ModificarBtn.Enabled = True
    End Sub
    Private Sub GuardarBtn_Click(sender As Object, e As EventArgs) Handles GuardarBtn.Click  '============ GUARDAR  ===========
        Try
            AbrirConexion()
            Using guardarCmd As New MySqlCommand("INSERT INTO placa (codigoPro, propietario, placa, observaciones)" & Chr(13) &
                "VALUES(@codigoPro, @propietario, @placa, @observaciones)", con)

                guardarCmd.Parameters.AddWithValue("@codigoPro", codTb.Text)
                guardarCmd.Parameters.AddWithValue("@propietario", propTb.Text)
                guardarCmd.Parameters.AddWithValue("@placa", placaTb.Text)
                guardarCmd.Parameters.AddWithValue("@observaciones", obserTb.Text)

                guardarCmd.ExecuteNonQuery()
                MsgBox("Registo guardado")
            End Using

            limpiar()
            act()
            CamDGV.Enabled = True
            listadoCamDgv()
        Catch ex As Exception
            MsgBox("Elemento no pudo se almacenado: " & ex.Message)
        Finally
            CerrarConexion()
        End Try
    End Sub
    Private Sub ModificarBtn_Click(sender As Object, e As EventArgs) Handles ModificarBtn.Click  '============ MODIFICAR  ===========
        actual()
        act()
        PanelP.Enabled = False
        CamDGV.Enabled = True
        Me.GuardarBtn.Visible = True
        listadoCamDgv()
    End Sub
    Public Sub actual()
        Try
            AbrirConexion()
            Using cmd As New MySqlCommand("UPDATE placa SET codigoPro = @codigoPro, propietario = @propietario, placa = @placa, observaciones = @observaciones WHERE idPlaca = @idPlaca", con)
                cmd.Parameters.AddWithValue("@codigoPro", codTb.Text)
                cmd.Parameters.AddWithValue("@propietario", propTb.Text)
                cmd.Parameters.AddWithValue("@placa", placaTb.Text)
                cmd.Parameters.AddWithValue("@observaciones", obserTb.Text)
                cmd.Parameters.AddWithValue("@idPlaca", buscartxt.Text)
                cmd.ExecuteNonQuery()
            End Using
            MsgBox("Registro Actualizado")
        Catch ex As Exception
            MessageBox.Show("Error al actualizar: " & ex.Message, "Error")
        Finally
            CerrarConexion()
        End Try
    End Sub
    Private Sub EliminarBtn_Click(sender As Object, e As EventArgs) Handles EliminarBtn.Click  '============ ELIMINAR  ===========
        Try
            Dim opc As DialogResult = MessageBox.Show("¿Desea Eliminar este registro?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If opc = Windows.Forms.DialogResult.Yes Then
                If String.IsNullOrEmpty(buscartxt.Text) Then
                    MessageBox.Show("No se ha seleccionado un registro para eliminar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return
                End If

                AbrirConexion()
                Dim eliminar As String = "DELETE FROM placa WHERE idPlaca = @idPlaca"
                Using eli As New MySqlCommand(eliminar, con)
                    eli.Parameters.AddWithValue("@idPlaca", Conversion.Int(Me.buscartxt.Text))
                    eli.ExecuteNonQuery()
                    MessageBox.Show("Registro eliminado correctamente", "Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End Using

                limpiar()
                act()
                listadoCamDgv()
            End If
        Catch ex As Exception
            MessageBox.Show("Error al eliminar registro: " & ex.Message & Chr(13) & "Favor escoger de nuevo el registro y eliminarlo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Finally
            CerrarConexion()
        End Try
    End Sub
    Private Sub CancelarBtn_Click(sender As Object, e As EventArgs) Handles CancelarBtn.Click  '============ CANCELAR  ===========
        act()
        PanelP.Enabled = False
        CamDGV.Enabled = True
        Me.GuardarBtn.Visible = True
    End Sub

    Public Sub Seleccion()
        Try
            Dim lista As Integer = 0

            If buscartxt.Text <> "" Then
                AbrirConexion()
                Dim cmd As New MySqlCommand("SELECT * FROM placa WHERE idPlaca = @idPlaca", con)
                cmd.Parameters.AddWithValue("@idPlaca", buscartxt.Text)
                adaptador = New MySqlDataAdapter(cmd)
                datos = New DataSet
                adaptador.Fill(datos, "placa")
                lista = datos.Tables("placa").Rows.Count
            End If

            If lista <> 0 Then
                codTb.Text = datos.Tables("placa").Rows(0).Item("codigoPro").ToString
                propTb.Text = datos.Tables("placa").Rows(0).Item("propietario").ToString
                placaTb.Text = datos.Tables("placa").Rows(0).Item("placa").ToString
                obserTb.Text = datos.Tables("placa").Rows(0).Item("observaciones").ToString
            Else
                MsgBox("Datos no encontrados")
            End If
        Catch ex As Exception
            MessageBox.Show("Error al seleccionar: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            CerrarConexion()
        End Try
    End Sub

    Private Sub propTb_KeyDown(sender As Object, e As KeyEventArgs) Handles propTb.KeyDown
        If e.KeyCode = Keys.Enter Then
            Seleccion2()
        End If
        If e.KeyCode = Keys.Delete Then
            propTb.Text = ""
        End If
    End Sub
    Public Sub Seleccion2()
        Try
            Dim lista As Integer = 0

            If propTb.Text <> "" Then
                AbrirConexion()
                Dim cmd As New MySqlCommand("SELECT * FROM propietario WHERE nPropietario = @nPropietario", con)
                cmd.Parameters.AddWithValue("@nPropietario", propTb.Text)
                adaptador = New MySqlDataAdapter(cmd)
                datos = New DataSet
                adaptador.Fill(datos, "propietario")
                lista = datos.Tables("propietario").Rows.Count
            End If

            If lista <> 0 Then
                codTb.Text = datos.Tables("propietario").Rows(0).Item("codProp").ToString
            Else
                MsgBox("Datos no encontrados")
            End If
        Catch ex As Exception
            MessageBox.Show("Error al buscar propietario: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            CerrarConexion()
        End Try
    End Sub
    Private Sub codTb_KeyDown(sender As Object, e As KeyEventArgs) Handles codTb.KeyDown
        If e.KeyCode = Keys.Enter Then
            Seleccion3()
        End If
        If e.KeyCode = Keys.Delete Then
            codTb.Text = ""
        End If
    End Sub
    Public Sub Seleccion3()
        Try
            Dim lista As Integer = 0

            If codTb.Text <> "" Then
                AbrirConexion()
                Dim cmd As New MySqlCommand("SELECT * FROM propietario WHERE codProp = @codProp", con)
                cmd.Parameters.AddWithValue("@codProp", codTb.Text)
                adaptador = New MySqlDataAdapter(cmd)
                datos = New DataSet
                adaptador.Fill(datos, "propietario")
                lista = datos.Tables("propietario").Rows.Count
            End If

            If lista <> 0 Then
                propTb.Text = datos.Tables("propietario").Rows(0).Item("nPropietario").ToString
            Else
                MsgBox("Datos no encontrados")
            End If
        Catch ex As Exception
            MessageBox.Show("Error al buscar código: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            CerrarConexion()
        End Try
    End Sub


    ' ============ MÉTODOS DE BÚSQUEDA ============
    Private Sub buscarPlacas()
        Try
            Dim filtro As String = ""
            Dim parametros As New List(Of MySqlParameter)()

            ' Construir filtro dinámico basado en los campos de búsqueda
            If Not String.IsNullOrEmpty(codBusqTB.Text.Trim()) Then
                filtro &= " codigoPro LIKE @codigo"
                parametros.Add(New MySqlParameter("@codigo", "%" & codBusqTB.Text.Trim() & "%"))
            End If

            If Not String.IsNullOrEmpty(propBusqTB.Text.Trim()) Then
                If filtro <> "" Then filtro &= " AND"
                filtro &= " propietario LIKE @propietario"
                parametros.Add(New MySqlParameter("@propietario", "%" & propBusqTB.Text.Trim() & "%"))
            End If

            If Not String.IsNullOrEmpty(placaBusqTB.Text.Trim()) Then
                If filtro <> "" Then filtro &= " AND"
                filtro &= " placa LIKE @placa"
                parametros.Add(New MySqlParameter("@placa", "%" & placaBusqTB.Text.Trim() & "%"))
            End If

            Dim consulta As String = "SELECT idPlaca, codigoPro, placa, propietario, observaciones FROM placa"
            If filtro <> "" Then
                consulta &= " WHERE" & filtro
            End If

            Dim table As New DataTable()
            AbrirConexion()
            Using cmd As New MySqlCommand(consulta, con)
                For Each param As MySqlParameter In parametros
                    cmd.Parameters.Add(param)
                Next
                Using adaptadorBusq As New MySqlDataAdapter(cmd)
                    adaptadorBusq.Fill(table)
                End Using
            End Using

            CamDGV.DataSource = table
            ListadoD()

        Catch ex As Exception
            MessageBox.Show("Error al buscar: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            CerrarConexion()
        End Try
    End Sub

    Private Sub codBusqTB_TextChanged(sender As Object, e As EventArgs) Handles codBusqTB.TextChanged
        buscarPlacas()
    End Sub

    Private Sub propBusqTB_TextChanged(sender As Object, e As EventArgs) Handles propBusqTB.TextChanged
        buscarPlacas()
    End Sub

    Private Sub placaBusqTB_TextChanged(sender As Object, e As EventArgs) Handles placaBusqTB.TextChanged
        buscarPlacas()
    End Sub

    Private Sub limpiarBusqueda()
        codBusqTB.Text = ""
        propBusqTB.Text = ""
        placaBusqTB.Text = ""
    End Sub

    Private Sub CamDGV_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles CamDGV.CellClick
        If e.RowIndex >= 0 AndAlso Me.CamDGV.RowCount > 0 Then
            Dim i As Integer = e.RowIndex
            ' Evitar triggear búsqueda al seleccionar
            RemoveHandler Me.placaBusqTB.TextChanged, AddressOf placaBusqTB_TextChanged
            Me.placaBusqTB.Text = Me.CamDGV.Item(2, i).Value.ToString()
            AddHandler Me.placaBusqTB.TextChanged, AddressOf placaBusqTB_TextChanged
            PanelP.Enabled = True
            Dim idcod As Integer = Convert.ToInt32(Me.CamDGV.Item(0, i).Value)
            buscartxt.Text = idcod.ToString()
            Seleccion()
            Me.EditarBtn.Enabled = True
            Me.EliminarBtn.Enabled = True
        End If
    End Sub

End Class