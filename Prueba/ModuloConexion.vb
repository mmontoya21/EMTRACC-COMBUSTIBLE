Imports System.Configuration
Imports MySql.Data.MySqlClient

''' <summary>
''' Modulo centralizado para gestionar la conexion a la base de datos MySQL.
''' Las credenciales se leen desde App.config para mayor seguridad.
''' </summary>
Module ModuloConexion

    ' Variables de sesión (se llenan en login, se usan en comprobante)
    Public PeriodoSesion As String = ""
    Public SemanaSesion As String = ""
    Public DespachadorSesion As String = ""
    Public TipoUsuarioSesion As String = ""
    Public TurnoSesion As String = ""
    Public IdTurnoSesion As Integer = 0
    Public OdometroInicioTurno As Double = 0

    ''' <summary>
    ''' Crea las tablas de turnos si no existen y agrega columna turno a comprobante
    ''' </summary>
    Public Sub EnsureTurnoTables()
        Try
            Using con As MySqlConnection = ObtenerConexion()
                con.Open()

                Dim sqlTurnos As String = "CREATE TABLE IF NOT EXISTS turnos (" &
                    "idTurno INT AUTO_INCREMENT PRIMARY KEY, " &
                    "nombre VARCHAR(50) NOT NULL, " &
                    "horaInicio TIME NOT NULL, " &
                    "horaFin TIME NOT NULL, " &
                    "activo TINYINT(1) DEFAULT 1)"
                Using cmd As New MySqlCommand(sqlTurnos, con)
                    cmd.ExecuteNonQuery()
                End Using

                ' Insertar turnos por defecto si la tabla esta vacia
                Dim sqlCount As String = "SELECT COUNT(*) FROM turnos"
                Using cmd As New MySqlCommand(sqlCount, con)
                    If Convert.ToInt32(cmd.ExecuteScalar()) = 0 Then
                        Dim sqlInsert As String = "INSERT INTO turnos (nombre, horaInicio, horaFin) VALUES " &
                            "('Manana', '06:00:00', '14:00:00'), " &
                            "('Tarde', '14:00:00', '22:00:00'), " &
                            "('Noche', '22:00:00', '06:00:00')"
                        Using cmdIns As New MySqlCommand(sqlInsert, con)
                            cmdIns.ExecuteNonQuery()
                        End Using
                    End If
                End Using

                Dim sqlCierre As String = "CREATE TABLE IF NOT EXISTS cierre_turno (" &
                    "idCierre INT AUTO_INCREMENT PRIMARY KEY, " &
                    "idTurno INT NOT NULL, " &
                    "despachador VARCHAR(100) NOT NULL, " &
                    "fecha DATE NOT NULL, " &
                    "periodo VARCHAR(5), " &
                    "semana VARCHAR(5), " &
                    "turnoNombre VARCHAR(50), " &
                    "totalComprobantes INT DEFAULT 0, " &
                    "totalGalones DOUBLE DEFAULT 0, " &
                    "totalMonto DOUBLE DEFAULT 0, " &
                    "odometroInicio DOUBLE DEFAULT 0, " &
                    "odometroCierre DOUBLE DEFAULT 0, " &
                    "medicionTanque DOUBLE DEFAULT 0, " &
                    "observaciones TEXT, " &
                    "fechaHoraCierre DATETIME DEFAULT CURRENT_TIMESTAMP)"
                Using cmd As New MySqlCommand(sqlCierre, con)
                    cmd.ExecuteNonQuery()
                End Using

                ' Agregar columna turno a comprobante si no existe
                Try
                    Using cmd As New MySqlCommand("ALTER TABLE comprobante ADD COLUMN turno VARCHAR(50) DEFAULT NULL", con)
                        cmd.ExecuteNonQuery()
                    End Using
                Catch
                    ' Ya existe
                End Try

                ' Agregar columnas odometro a cierre_turno si no existen
                Try
                    Using cmd As New MySqlCommand("ALTER TABLE cierre_turno ADD COLUMN odometroInicio DOUBLE DEFAULT 0", con)
                        cmd.ExecuteNonQuery()
                    End Using
                Catch
                End Try
                Try
                    Using cmd As New MySqlCommand("ALTER TABLE cierre_turno ADD COLUMN odometroCierre DOUBLE DEFAULT 0", con)
                        cmd.ExecuteNonQuery()
                    End Using
                Catch
                End Try
                Try
                    Using cmd As New MySqlCommand("ALTER TABLE cierre_turno ADD COLUMN medicionTanque DOUBLE DEFAULT 0", con)
                        cmd.ExecuteNonQuery()
                    End Using
                Catch
                End Try

                ' Tabla apertura_turno para detectar turnos no cerrados
                Dim sqlApertura As String = "CREATE TABLE IF NOT EXISTS apertura_turno (" &
                    "id INT AUTO_INCREMENT PRIMARY KEY, " &
                    "despachador VARCHAR(100) NOT NULL, " &
                    "idTurno INT NOT NULL, " &
                    "turnoNombre VARCHAR(50), " &
                    "odometroInicio DOUBLE DEFAULT 0, " &
                    "periodo VARCHAR(5), " &
                    "semana VARCHAR(5), " &
                    "fechaHora DATETIME DEFAULT CURRENT_TIMESTAMP, " &
                    "cerrado TINYINT(1) DEFAULT 0)"
                Using cmd As New MySqlCommand(sqlApertura, con)
                    cmd.ExecuteNonQuery()
                End Using

            End Using
        Catch
            ' No bloquear si falla
        End Try
    End Sub

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

    ''' <summary>
    ''' Indica si el usuario actual es de tipo TEST (solo lectura)
    ''' </summary>
    Public Function EsSoloLectura() As Boolean
        Return TipoUsuarioSesion.ToUpper() = "TEST"
    End Function

    ''' <summary>
    ''' Deshabilita los botones de CRUD para usuarios TEST (solo lectura)
    ''' </summary>
    Public Sub AplicarSoloLectura(ParamArray botones() As Button)
        If EsSoloLectura() Then
            For Each btn In botones
                btn.Enabled = False
            Next
        End If
    End Sub

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
