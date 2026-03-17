Imports MySql.Data.MySqlClient
Imports System.Data

Public Class valorComb
    Dim con As MySqlConnection
    Dim cm As New MySqlCommand
    Dim guardar As New MySqlCommand
    Dim adaptador As New MySqlDataAdapter
    Dim datos As DataSet

    Private Sub valorComb_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim colorFondo = Color.FromArgb(106, 126, 168)

        System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("es-CO")
        System.Threading.Thread.CurrentThread.CurrentCulture.DateTimeFormat.ShortDatePattern = "yyyy/MM/dd"
        System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencyDecimalSeparator = "."
        System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencyGroupSeparator = ","
        System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator = "."
        System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.NumberGroupSeparator = ","

        conectar()
        act()
        cargarDatos()
        cargarPrecioActual()

        EstilizarDataGridView(CamDGV)

        PanelP.Enabled = False
    End Sub

    Public Sub conectar()
        con = ModuloConexion.ObtenerConexion()
        Try
            If con.State = ConnectionState.Closed Then
                con.Open()
            End If
        Catch ex As Exception
            MsgBox("No se conectó por: " & ex.Message)
        End Try
    End Sub

    Private Sub cargarDatos()
        Try
            Dim table As New DataTable()
            Dim sql As String = "SELECT valorId, valorCombustible, DATE_FORMAT(fecha, '%d/%m/%Y') AS fecha, descripcion, activo FROM valorComb ORDER BY fecha DESC"
            Dim adaptadorListado As New MySqlDataAdapter(sql, con)
            adaptadorListado.Fill(table)

            CamDGV.DataSource = table
            configurarColumnas()
        Catch ex As Exception
            MsgBox("Error al cargar datos: " & ex.Message)
        End Try
    End Sub

    Private Sub configurarColumnas()
        If CamDGV.Columns.Count > 0 Then
            CamDGV.Columns(0).HeaderText = "ID"
            CamDGV.Columns(0).Width = 50

            CamDGV.Columns(1).HeaderText = "Precio"
            CamDGV.Columns(1).Width = 100
            CamDGV.Columns(1).DefaultCellStyle.Format = "N2"

            CamDGV.Columns(2).HeaderText = "Fecha"
            CamDGV.Columns(2).Width = 100

            CamDGV.Columns(3).HeaderText = "Descripción"
            CamDGV.Columns(3).Width = 150

            CamDGV.Columns(4).HeaderText = "Activo"
            CamDGV.Columns(4).Width = 60
        End If
    End Sub

    Private Sub cargarPrecioActual()
        Try
            Dim sql As String = "SELECT valorCombustible FROM valorComb ORDER BY fecha DESC LIMIT 1"
            Dim cmd As New MySqlCommand(sql, con)
            Dim resultado = cmd.ExecuteScalar()

            If resultado IsNot Nothing AndAlso Not IsDBNull(resultado) Then
                LabelPrecioActual.Text = "Precio Actual: L. " & Convert.ToDecimal(resultado).ToString("N2")
            Else
                LabelPrecioActual.Text = "Precio Actual: No definido"
            End If
        Catch ex As Exception
            LabelPrecioActual.Text = "Precio Actual: Error"
        End Try
    End Sub

    Sub limpiar()
        Me.valorTb.Text = ""
        Me.descripcionTb.Text = ""
        Me.fechaDtp.Value = Today
        Me.buscartxt.Text = ""
        Me.activoChk.Checked = True
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

    Private Sub NuevoBtn_Click(sender As Object, e As EventArgs) Handles NuevoBtn.Click
        limpiar()
        valorTb.Focus()

        CamDGV.Enabled = False
        Me.GuardarBtn.Enabled = True
        Me.ModificarBtn.Enabled = False
        Me.EditarBtn.Enabled = False
        Me.CancelarBtn.Enabled = True
        Me.EliminarBtn.Enabled = False
        Me.NuevoBtn.Enabled = False

        PanelP.Enabled = True
    End Sub

    Private Sub EditarBtn_Click(sender As Object, e As EventArgs) Handles EditarBtn.Click
        PanelP.Enabled = True
        Me.CamDGV.Enabled = False
        Me.GuardarBtn.Enabled = False
        Me.GuardarBtn.Visible = False
        Me.ModificarBtn.Enabled = True
        Me.EditarBtn.Enabled = False
        Me.CancelarBtn.Enabled = True
        Me.NuevoBtn.Enabled = False
        Me.EliminarBtn.Enabled = False
    End Sub

    Private Sub CancelarBtn_Click(sender As Object, e As EventArgs) Handles CancelarBtn.Click
        act()
        PanelP.Enabled = False
        CamDGV.Enabled = True
        Me.GuardarBtn.Visible = True
        limpiar()
    End Sub

    Private Sub EliminarBtn_Click(sender As Object, e As EventArgs) Handles EliminarBtn.Click
        Try
            Dim opc As DialogResult = MsgBox("¿Desea Eliminar este registro?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Eliminar")
            If opc = Windows.Forms.DialogResult.Yes Then
                Dim sql As String = "DELETE FROM valorComb WHERE valorId = @id"
                Dim cmd As New MySqlCommand(sql, con)
                cmd.Parameters.AddWithValue("@id", Convert.ToInt32(Me.buscartxt.Text))
                cmd.ExecuteNonQuery()

                MsgBox("Registro eliminado")
                cargarDatos()
                cargarPrecioActual()
                limpiar()
            End If
        Catch ex As Exception
            MessageBox.Show("Error al eliminar: " & ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try

        act()
    End Sub

    Private Sub GuardarBtn_Click(sender As Object, e As EventArgs) Handles GuardarBtn.Click
        ' Validar que el precio no esté vacío
        If String.IsNullOrWhiteSpace(valorTb.Text) Then
            MsgBox("Debe ingresar el precio del combustible")
            valorTb.Focus()
            Return
        End If

        ' Validar que sea un número válido
        Dim precio As Decimal
        If Not Decimal.TryParse(valorTb.Text, precio) Then
            MsgBox("El precio debe ser un número válido")
            valorTb.Focus()
            Return
        End If

        If precio <= 0 Then
            MsgBox("El precio debe ser mayor a cero")
            valorTb.Focus()
            Return
        End If

        Try
            If con.State = ConnectionState.Closed Then
                con.Open()
            End If

            Dim fe As String = fechaDtp.Value.ToString("yyyy-MM-dd")

            guardar = New MySqlCommand("INSERT INTO valorComb (valorCombustible, fecha, descripcion, activo) VALUES(@valor, @fecha, @descripcion, @activo)", con)

            guardar.Parameters.AddWithValue("@valor", precio)
            guardar.Parameters.AddWithValue("@fecha", fe)
            guardar.Parameters.AddWithValue("@descripcion", descripcionTb.Text)
            guardar.Parameters.AddWithValue("@activo", If(activoChk.Checked, 1, 0))

            guardar.ExecuteNonQuery()
            MsgBox("Registro guardado")

        Catch ex As Exception
            MsgBox("Error al guardar: " & ex.Message)
        End Try

        limpiar()
        act()
        CamDGV.Enabled = True
        PanelP.Enabled = False
        cargarDatos()
        cargarPrecioActual()
    End Sub

    Private Sub ModificarBtn_Click(sender As Object, e As EventArgs) Handles ModificarBtn.Click
        ' Validar que el precio no esté vacío
        If String.IsNullOrWhiteSpace(valorTb.Text) Then
            MsgBox("Debe ingresar el precio del combustible")
            valorTb.Focus()
            Return
        End If

        ' Validar que sea un número válido
        Dim precio As Decimal
        If Not Decimal.TryParse(valorTb.Text, precio) Then
            MsgBox("El precio debe ser un número válido")
            valorTb.Focus()
            Return
        End If

        If precio <= 0 Then
            MsgBox("El precio debe ser mayor a cero")
            valorTb.Focus()
            Return
        End If

        Try
            If con.State = ConnectionState.Closed Then
                con.Open()
            End If

            Dim fe As String = fechaDtp.Value.ToString("yyyy-MM-dd")

            Dim sql As String = "UPDATE valorComb SET valorCombustible=@valor, fecha=@fecha, descripcion=@descripcion, activo=@activo WHERE valorId=@id"
            Dim cmd As New MySqlCommand(sql, con)
            cmd.Parameters.AddWithValue("@valor", precio)
            cmd.Parameters.AddWithValue("@fecha", fe)
            cmd.Parameters.AddWithValue("@descripcion", descripcionTb.Text)
            cmd.Parameters.AddWithValue("@activo", If(activoChk.Checked, 1, 0))
            cmd.Parameters.AddWithValue("@id", Convert.ToInt32(buscartxt.Text))

            cmd.ExecuteNonQuery()
            MsgBox("Registro Actualizado")

        Catch ex As Exception
            MsgBox("Error al actualizar: " & ex.Message)
        End Try

        limpiar()
        act()
        PanelP.Enabled = False
        CamDGV.Enabled = True
        Me.GuardarBtn.Visible = True
        cargarDatos()
        cargarPrecioActual()
    End Sub

    Private Sub CamDGV_Click(sender As Object, e As EventArgs) Handles CamDGV.Click
        If Me.CamDGV.RowCount = 0 Then
            MessageBox.Show("No hay datos a mostrar")
        Else
            Dim y As Integer = Me.CamDGV.CurrentRow.Index
            Dim idcod As Integer = Me.CamDGV.Item(0, y).Value
            buscartxt.Text = idcod.ToString()
            seleccion()
            Me.EditarBtn.Enabled = Not ModuloConexion.EsSoloLectura()
            Me.EliminarBtn.Enabled = Not ModuloConexion.EsSoloLectura()
        End If
    End Sub

    Public Sub seleccion()
        Dim consulta As String
        Dim lista As Integer

        If buscartxt.Text <> "" Then
            consulta = "SELECT * FROM valorComb WHERE valorId = @id"
            Dim cmd As New MySqlCommand(consulta, con)
            cmd.Parameters.AddWithValue("@id", Convert.ToInt32(buscartxt.Text))

            adaptador = New MySqlDataAdapter(cmd)
            datos = New DataSet
            adaptador.Fill(datos, "valorComb")
            lista = datos.Tables("valorComb").Rows.Count
        End If

        If lista <> 0 Then
            valorTb.Text = datos.Tables("valorComb").Rows(0).Item("valorCombustible").ToString
            descripcionTb.Text = datos.Tables("valorComb").Rows(0).Item("descripcion").ToString
            Try
                fechaDtp.Value = datos.Tables("valorComb").Rows(0).Item("fecha")
            Catch
                fechaDtp.Value = Today
            End Try
            Try
                activoChk.Checked = Convert.ToInt32(datos.Tables("valorComb").Rows(0).Item("activo")) = 1
            Catch
                activoChk.Checked = True
            End Try
        Else
            MsgBox("Datos no encontrados")
        End If
    End Sub

    ' Validar entrada numérica en el TextBox de precio
    Private Sub valorTb_KeyPress(sender As Object, e As KeyPressEventArgs) Handles valorTb.KeyPress
        ' Permitir números, punto decimal y tecla de retroceso
        If Not Char.IsDigit(e.KeyChar) AndAlso e.KeyChar <> "."c AndAlso e.KeyChar <> ControlChars.Back Then
            e.Handled = True
        End If

        ' Solo permitir un punto decimal
        If e.KeyChar = "."c AndAlso valorTb.Text.Contains(".") Then
            e.Handled = True
        End If
    End Sub
End Class
