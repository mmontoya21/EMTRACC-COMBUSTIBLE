Imports System.Data
Imports MySql.Data.MySqlClient
Public Class rutas
    Dim adaptador As New MySqlDataAdapter
    Dim datos As DataSet
    Dim con As New MySqlConnection

    Private Sub rutas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        conectar()
        act()
        listadoCamDgv()
        EstilizarDataGridView(CamDGV)
        PanelP.Enabled = False
    End Sub

    Private Sub act()
        Me.NuevoBtn.Enabled = True
        Me.EditarBtn.Enabled = False
        Me.GuardarBtn.Enabled = False
        Me.ModificarBtn.Enabled = False
        Me.CancelarBtn.Enabled = False
        Me.EliminarBtn.Enabled = False
        If ModuloConexion.EsSoloLectura() Then NuevoBtn.Enabled = False
    End Sub

    Private Sub conectar()
        con = ModuloConexion.ObtenerConexion()
        Try
            If con.State = ConnectionState.Closed Then
                con.Open()
            End If
        Catch ex As Exception
            MsgBox("No se conecto por: " & ex.Message)
        End Try
    End Sub

    Private Sub AbrirConexion()
        Try
            If con.State = ConnectionState.Closed Then
                con.Open()
            End If
        Catch ex As Exception
            MessageBox.Show("Error al abrir conexión: " & ex.Message, "Error")
        End Try
    End Sub

    Private Sub CerrarConexion()
        Try
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
        Catch ex As Exception
            MessageBox.Show("Error al cerrar conexión: " & ex.Message, "Error")
        End Try
    End Sub

    Private Sub listadoCamDgv()
        Try
            Dim table As New DataTable()
            AbrirConexion()
            Using adaptadoListado As New MySqlDataAdapter("SELECT idrut, rutas, kilom FROM rutas", con)
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
        If CamDGV.Columns.Count >= 3 Then
            CamDGV.Columns(0).HeaderText = "Id"
            CamDGV.Columns(0).Width = 50
            CamDGV.Columns(1).HeaderText = "Ruta"
            CamDGV.Columns(1).Width = 300
            CamDGV.Columns(2).HeaderText = "Kilómetros"
            CamDGV.Columns(2).Width = 100
        End If
    End Sub

    Sub limpiar()
        Me.rutaTb.Text = ""
        Me.kilomTb.Text = ""
    End Sub

    ' ============ NUEVO ===========
    Private Sub NuevoBtn_Click(sender As Object, e As EventArgs) Handles NuevoBtn.Click
        limpiar()
        PanelP.Enabled = True
        GuardarBtn.Enabled = True
        CamDGV.Enabled = False
        CancelarBtn.Enabled = True
        NuevoBtn.Enabled = False
    End Sub

    ' ============ GUARDAR ===========
    Private Sub GuardarBtn_Click(sender As Object, e As EventArgs) Handles GuardarBtn.Click
        If rutaTb.Text.Trim() = "" Then
            MsgBox("Ingrese el nombre de la ruta", MsgBoxStyle.Exclamation, "Validación")
            Return
        End If
        Try
            AbrirConexion()
            Using guardarCmd As New MySqlCommand("INSERT INTO rutas (rutas, kilom) VALUES(@rutas, @kilom)", con)
                guardarCmd.Parameters.AddWithValue("@rutas", rutaTb.Text)
                guardarCmd.Parameters.AddWithValue("@kilom", kilomTb.Text)
                guardarCmd.ExecuteNonQuery()
                MsgBox("Registro guardado")
            End Using
            limpiar()
            act()
            CamDGV.Enabled = True
            PanelP.Enabled = False
            listadoCamDgv()
        Catch ex As Exception
            MsgBox("Elemento no pudo ser almacenado: " & ex.Message)
        Finally
            CerrarConexion()
        End Try
    End Sub

    ' ============ EDITAR ===========
    Private Sub EditarBtn_Click(sender As Object, e As EventArgs) Handles EditarBtn.Click
        PanelP.Enabled = True
        CamDGV.Enabled = False
        GuardarBtn.Enabled = False
        GuardarBtn.Visible = False
        ModificarBtn.Enabled = True
        EditarBtn.Enabled = False
        CancelarBtn.Enabled = True
        NuevoBtn.Enabled = False
        EliminarBtn.Enabled = False
    End Sub

    ' ============ MODIFICAR ===========
    Private Sub ModificarBtn_Click(sender As Object, e As EventArgs) Handles ModificarBtn.Click
        Try
            AbrirConexion()
            Using actCmd As New MySqlCommand("UPDATE rutas SET rutas=@rutas, kilom=@kilom WHERE idrut=@id", con)
                actCmd.Parameters.AddWithValue("@rutas", rutaTb.Text)
                actCmd.Parameters.AddWithValue("@kilom", kilomTb.Text)
                actCmd.Parameters.AddWithValue("@id", Conversion.Int(buscartxt.Text))
                actCmd.ExecuteNonQuery()
            End Using
            MsgBox("Registro Actualizado")
        Catch ex As Exception
            MessageBox.Show("Error al actualizar: " & ex.Message, "Error")
        Finally
            CerrarConexion()
        End Try
        act()
        PanelP.Enabled = False
        CamDGV.Enabled = True
        GuardarBtn.Visible = True
        listadoCamDgv()
    End Sub

    ' ============ ELIMINAR ===========
    Private Sub EliminarBtn_Click(sender As Object, e As EventArgs) Handles EliminarBtn.Click
        Try
            Dim opc As DialogResult = MessageBox.Show("¿Desea Eliminar este registro?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If opc = Windows.Forms.DialogResult.Yes Then
                If String.IsNullOrEmpty(buscartxt.Text) Then
                    MessageBox.Show("No se ha seleccionado un registro para eliminar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return
                End If
                AbrirConexion()
                Using eli As New MySqlCommand("DELETE FROM rutas WHERE idrut = @idRut", con)
                    eli.Parameters.AddWithValue("@idRut", Conversion.Int(buscartxt.Text))
                    eli.ExecuteNonQuery()
                    MessageBox.Show("Registro eliminado correctamente", "Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End Using
                limpiar()
                act()
                PanelP.Enabled = False
                listadoCamDgv()
            End If
        Catch ex As Exception
            MessageBox.Show("Error al eliminar registro: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Finally
            CerrarConexion()
        End Try
    End Sub

    ' ============ CANCELAR ===========
    Private Sub CancelarBtn_Click(sender As Object, e As EventArgs) Handles CancelarBtn.Click
        act()
        PanelP.Enabled = False
        CamDGV.Enabled = True
        GuardarBtn.Visible = True
    End Sub

    ' ============ SELECCION EN DGV ===========
    Private Sub CamDGV_Click(sender As Object, e As EventArgs) Handles CamDGV.Click
        If CamDGV.RowCount = 0 Then
            MessageBox.Show("No hay datos a mostrar")
        Else
            Dim i As Integer = CamDGV.CurrentRow.Index
            buscartxt.Text = CamDGV.Item(0, i).Value.ToString()
            Seleccion()
            EditarBtn.Enabled = Not ModuloConexion.EsSoloLectura()
            EliminarBtn.Enabled = Not ModuloConexion.EsSoloLectura()
        End If
    End Sub

    Public Sub Seleccion()
        Try
            AbrirConexion()
            Dim consulta As String = "SELECT * FROM rutas WHERE idrut = @id"
            Using cmd As New MySqlCommand(consulta, con)
                cmd.Parameters.AddWithValue("@id", buscartxt.Text)
                Using reader As MySqlDataReader = cmd.ExecuteReader()
                    If reader.Read() Then
                        rutaTb.Text = reader("rutas").ToString()
                        kilomTb.Text = reader("kilom").ToString()
                        PanelP.Enabled = True
                    Else
                        MsgBox("Datos no encontrados")
                    End If
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error al seleccionar: " & ex.Message, "Error")
        Finally
            CerrarConexion()
        End Try
    End Sub

    ' ============ BUSCAR ===========
    Private Sub buscarBtn_Click(sender As Object, e As EventArgs) Handles buscarBtn.Click
        Try
            Dim table As New DataTable()
            AbrirConexion()
            If rutaBusqTB.Text.Trim() = "" Then
                Using adapt As New MySqlDataAdapter("SELECT idrut, rutas, kilom FROM rutas", con)
                    adapt.Fill(table)
                End Using
            Else
                Using cmd As New MySqlCommand("SELECT idrut, rutas, kilom FROM rutas WHERE rutas LIKE @busqueda", con)
                    cmd.Parameters.AddWithValue("@busqueda", "%" & rutaBusqTB.Text.Trim() & "%")
                    Using adapt As New MySqlDataAdapter(cmd)
                        adapt.Fill(table)
                    End Using
                End Using
            End If
            CamDGV.DataSource = table
            ListadoD()
        Catch ex As Exception
            MessageBox.Show("Error al buscar: " & ex.Message, "Error")
        Finally
            CerrarConexion()
        End Try
    End Sub

    Private Sub rutaBusqTB_KeyDown(sender As Object, e As KeyEventArgs) Handles rutaBusqTB.KeyDown
        If e.KeyCode = Keys.Enter Then
            buscarBtn_Click(sender, e)
        End If
    End Sub

    Private Sub CamDGV_MouseLeave(sender As Object, e As EventArgs) Handles CamDGV.MouseLeave
        PanelP.Enabled = False
    End Sub

    Private Sub CamDGV_MouseEnter(sender As Object, e As EventArgs) Handles CamDGV.MouseEnter
        PanelP.Enabled = True
    End Sub
End Class
