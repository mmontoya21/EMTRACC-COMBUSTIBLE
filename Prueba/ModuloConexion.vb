Imports System.Configuration
Imports MySql.Data.MySqlClient

''' <summary>
''' Modulo centralizado para gestionar la conexion a la base de datos MySQL.
''' Las credenciales se leen desde App.config para mayor seguridad.
''' </summary>
Module ModuloConexion

    ''' <summary>
    ''' Obtiene una nueva instancia de conexion MySQL con la cadena de conexion del App.config
    ''' </summary>
    ''' <returns>Nueva instancia de MySqlConnection configurada</returns>
    Public Function ObtenerConexion() As MySqlConnection
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("MySqlConexion").ConnectionString
        Return New MySqlConnection(connectionString)
    End Function

    ''' <summary>
    ''' Obtiene la cadena de conexion directamente (para casos especiales)
    ''' </summary>
    ''' <returns>Cadena de conexion desde App.config</returns>
    Public Function ObtenerCadenaConexion() As String
        Return ConfigurationManager.ConnectionStrings("MySqlConexion").ConnectionString
    End Function

    Public Sub EstilizarDataGridView(dgv As DataGridView)
        ' Fondo
        dgv.BackgroundColor = Color.FromArgb(20, 30, 48)
        dgv.BorderStyle = BorderStyle.None
        dgv.GridColor = Color.FromArgb(40, 55, 80)

        ' Headers
        dgv.EnableHeadersVisualStyles = False
        dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(15, 25, 40)
        dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
        dgv.ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI Semibold", 9.75, FontStyle.Bold)
        dgv.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(15, 25, 40)
        dgv.ColumnHeadersHeight = 34
        dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing

        ' Filas
        dgv.DefaultCellStyle.Font = New Font("Segoe UI", 9.75, FontStyle.Regular)
        dgv.DefaultCellStyle.ForeColor = Color.FromArgb(200, 215, 240)
        dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(50, 100, 180)
        dgv.DefaultCellStyle.SelectionForeColor = Color.White
        dgv.RowsDefaultCellStyle.BackColor = Color.FromArgb(25, 40, 65)
        dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(35, 52, 85)
        dgv.RowTemplate.Height = 28

        ' General
        dgv.RowHeadersVisible = False
        dgv.AllowUserToAddRows = False
        dgv.AllowUserToDeleteRows = False
        dgv.AllowUserToResizeRows = False
        dgv.ReadOnly = True
        dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgv.MultiSelect = False
    End Sub

End Module
