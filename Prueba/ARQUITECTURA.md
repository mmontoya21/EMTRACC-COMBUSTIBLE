# Documentación Arquitectónica - EMTRACC COMBUSTIBLE

**Versión:** 1.0  
**Fecha:** 2024  
**Lenguaje:** Español

---

## Tabla de Contenidos

1. [Resumen Ejecutivo](#1-resumen-ejecutivo)
2. [Stack Tecnológico](#2-stack-tecnológico)
3. [Arquitectura General](#3-arquitectura-general)
4. [Estructura del Proyecto](#4-estructura-del-proyecto)
5. [Convenciones y Estándares](#5-convenciones-y-estándares)
6. [Guía para Agentes de IA](#6-guía-para-agentes-de-ia)
7. [Reglas Operativas para IA](#7-reglas-operativas-para-ia)
8. [Patrones de Diseño Identificados](#8-patrones-de-diseño-identificados)
9. [Flujos Críticos del Sistema](#9-flujos-críticos-del-sistema)

---

## 1. Resumen Ejecutivo

### 1.1 Descripción del Proyecto

EMTRACC COMBUSTIBLE es una aplicación de escritorio Windows Forms desarrollada en VB.NET para la gestión de combustible, facturación y registro de comprobantes de despacho. La aplicación permite gestionar:

- **Entidades principales:** Camiones, Placas, Propietarios, Empresas, Facturas, Comprobantes, Tanques, Consumos, Mediciones, Transportistas, Accesos
- **Funcionalidades:** CRUD completo, generación de comprobantes impresos, gestión de usuarios con autenticación SHA256

### 1.2 Características Clave

- Aplicación monolítica de escritorio
- Base de datos MySQL remota/local
- Interfaz gráfica con DevComponents DotNetBar
- Impresión de comprobantes y facturas
- Sistema de autenticación con hash SHA256

---

## 2. Stack Tecnológico

### 2.1 Lenguaje y Framework Principal

- **Lenguaje:** Visual Basic .NET (VB.NET)
- **Framework:** .NET Framework 4.7.2
- **Plataforma:** Windows Forms (WinForms)
- **Runtime:** Windows (WinExe)

### 2.2 Base de Datos

- **Motor:** MySQL Server
- **Conector:** MySQL Connector/NET 9.0 (MySql.Data.dll)
- **Versión mínima:** MySQL 5.7+ (inferida)

### 2.3 Librerías Externas

- **DevComponents.DotNetBar2** (v12.5.0.2): Componentes de UI avanzados
- **DevComponents.DotNetBar.Schedule** (v10.4.0.1): Componentes de calendario
- **MySql.Data** (v9.0.0.0): Conector oficial de MySQL para .NET

### 2.4 Namespaces Principales Utilizados

```vb
Imports System.Data
Imports MySql.Data.MySqlClient
Imports MySql.Data
Imports System.Drawing
Imports System.Drawing.Printing
Imports System.Security.Cryptography
Imports System.Text
```

---

## 3. Arquitectura General

### 3.1 Tipo de Arquitectura

**Arquitectura Monolítica - Modelo Form-Based CRUD**

La aplicación sigue un modelo tradicional de aplicación de escritorio donde:

- Cada formulario (`Form`) representa una entidad de negocio
- Cada formulario contiene su propia lógica de acceso a datos
- No existe separación explícita de capas (presentación, lógica, datos)
- Conexiones a base de datos se gestionan a nivel de formulario

```
┌─────────────────────────────────────────────────────────────┐
│                    APLICACIÓN MONOLÍTICA                     │
├─────────────────────────────────────────────────────────────┤
│                                                               │
│  ┌──────────┐  ┌──────────┐  ┌──────────┐  ┌──────────┐   │
│  │ Principal│  │ Factura  │  │Comprobante│ │ Empresa  │   │
│  │  Form    │  │  Form    │  │   Form    │ │  Form    │   │
│  └────┬─────┘  └────┬─────┘  └────┬─────┘  └────┬─────┘   │
│       │             │              │              │          │
│       │             │              │              │          │
│       └─────────────┴──────────────┴──────────────┘          │
│                         │                                     │
│                         ▼                                     │
│              ┌───────────────────────┐                       │
│              │  MySQL Database       │                       │
│              │  (Remoto/Local)       │                       │
│              └───────────────────────┘                       │
│                                                               │
└─────────────────────────────────────────────────────────────┘
```

### 3.2 Punto de Entrada

- **Clase principal:** `Prueba.My.MyApplication`
- **Formulario inicial:** `Principal.vb`
- **Namespace raíz:** `Prueba`

### 3.3 Patrón de Navegación

El formulario `Principal` actúa como contenedor (MDI-like) que carga formularios hijos mediante el método `abrirformulario()`:

```vb
Public Sub abrirformulario(frmh As Object)
    ' Elimina formulario anterior si existe
    If (PanelForm.Controls.Count > 0) Then
        PanelForm.Controls.RemoveAt(0)
    End If
    
    Dim frm As Form
    frm = frmh
    frm.TopLevel = False
    frm.Dock = DockStyle.Fill
    PanelForm.Controls.Add(frm)
    frm.Show()
End Sub
```

---

## 4. Estructura del Proyecto

### 4.1 Organización de Archivos

```
Prueba/
│
├── Principal.vb                    # Formulario contenedor principal
│   └── Principal.Designer.vb
│
├── [Entidades CRUD]                # Formularios de gestión
│   ├── acceso.vb                   # Gestión de usuarios/accesos
│   ├── camiones.vb                 # Gestión de camiones
│   ├── comprobante.vb              # Gestión de comprobantes
│   ├── conexion.vb                 # Gestión de conexiones BD
│   ├── consumo.vb                  # Gestión de consumos
│   ├── empresa.vb                  # Gestión de empresas
│   ├── factura.vb                  # Gestión de facturas
│   ├── medicion.vb                 # Gestión de mediciones
│   ├── placa.vb                    # Gestión de placas
│   ├── propietario.vb              # Gestión de propietarios
│   ├── tanque.vb                   # Gestión de tanques
│   └── transportistas.vb           # Gestión de transportistas
│
├── Aletras.vb                      # Módulo utilitario: conversión números a letras
│
├── My Project/                     # Configuración del proyecto VB.NET
│   ├── Application.Designer.vb
│   ├── AssemblyInfo.vb
│   ├── Resources.Designer.vb
│   └── Settings.Designer.vb
│
├── App.config                      # Configuración de runtime
├── combustible.vbproj              # Archivo de proyecto
│
└── bin/                            # Archivos compilados
    └── Debug/
```

### 4.2 Descripción de Módulos Principales

#### 4.2.1 Principal.vb
- **Propósito:** Formulario contenedor y menú principal
- **Responsabilidades:**
  - Navegación entre formularios
  - Gestión de ventana (minimizar, maximizar, cerrar, arrastrar)
  - Contenedor para formularios hijos

#### 4.2.2 Formularios CRUD (acceso, camiones, comprobante, etc.)
- **Propósito:** Gestión completa de entidades (Create, Read, Update, Delete)
- **Patrón común:** Todos siguen la misma estructura:
  - `conectar()`: Establece conexión a MySQL
  - `act()`: Configura estado inicial de botones
  - `limpiar()`: Limpia campos del formulario
  - `listadoCamDgv()`: Carga datos en DataGridView
  - `NuevoBtn_Click()`: Inicia modo creación
  - `GuardarBtn_Click()`: Inserta nuevo registro
  - `EditarBtn_Click()`: Inicia modo edición
  - `ModificarBtn_Click()`: Actualiza registro existente
  - `EliminarBtn_Click()`: Elimina registro

#### 4.2.3 Aletras.vb
- **Propósito:** Módulo utilitario para conversión numérica
- **Función principal:** `LETRAS(ByVal NUMERO As String) As String`
- **Uso:** Convierte números a su representación en letras (ej: "123" → "CIENTO VEINTITRÉS")

---

## 5. Convenciones y Estándares

### 5.1 Convenciones de Naming

#### 5.1.1 Clases y Archivos
- **Formularios:** Nombres en singular, PascalCase
  - Ejemplos: `comprobante.vb`, `factura.vb`, `empresa.vb`
- **Clases:** Mismo nombre que el archivo
  - Ejemplo: Archivo `comprobante.vb` contiene clase `Public Class comprobante`

#### 5.1.2 Variables y Campos
- **Variables locales:** camelCase (VB.NET permite, pero no se usa consistentemente)
- **Campos de clase:** Nombres descriptivos, generalmente camelCase
  - Ejemplos: `con`, `cm`, `guardar`, `adaptador`, `datos`, `dr`
- **Controles de UI:** Sufijos descriptivos
  - `TextBox`: `...Tb`, `...Tbx` (ej: `nComproTb`, `usuaTbx`)
  - `Button`: `...Btn`, `...Bt` (ej: `NuevoBtn`, `GuardarBtn`, `camiBt`)
  - `DataGridView`: `CamDGV`, `CamDgv`
  - `Panel`: `PanelP`, `Panel1`
  - `DateTimePicker`: `...Pkd`, `...Pk` (ej: `fechaPkd`, `fechDpk`)

#### 5.1.3 Métodos
- **Eventos:** `[Control]_[Evento]` (ej: `NuevoBtn_Click`, `factura_Load`)
- **Métodos privados:** PascalCase descriptivo
  - Ejemplos: `conectar()`, `limpiar()`, `act()`, `listadoCamDgv()`
- **Comentarios de secciones:** `'============ NOMBRE ===========`
  - Ejemplo: `'============ GUARDAR ===========`

### 5.2 Convenciones de Código

#### 5.2.1 Acceso a Datos
- **Conexión:** Variable `con` tipo `MySqlConnection`
- **Comandos:** 
  - `cm`: `MySqlCommand` (lecturas)
  - `guardar`: `MySqlCommand` (inserciones)
- **Adaptadores:** `adaptador` tipo `MySqlDataAdapter`
- **Resultados:** `datos` tipo `DataSet`, `dr` tipo `MySqlDataReader`

#### 5.2.2 Manejo de Errores
- **Patrón:** Try-Catch básico
- **Mensajes:** `MsgBox()` para errores y confirmaciones
- **Logging:** No hay sistema de logging estructurado
- **Errores comunes:** Se capturan con `Catch ex As Exception`

```vb
Try
    ' Código operativo
    guardar.ExecuteNonQuery()
    MsgBox("Registo guardado")
Catch ex As Exception
    MsgBox("Elemento no pudo se almacenado", ex.StackTrace)
End Try
```

#### 5.2.3 Conexión a Base de Datos

**Patrón común en cada formulario:**

```vb
Private Sub conectar()
    Dim servidor As String = "localhost"
    Dim baseDatos As String = "givemefuel"
    Dim userid As String = "root"
    Dim clave As String = ""

    ' Conexión activa (comentada local):
    con.ConnectionString = "Server=193.203.166.219; Database=u282951626_emtraccF; Uid=u282951626_mmontoya; Pwd=Paradoja25"
    
    Try
        con.Open()
        MessageBox.Show("El sistema esá conectado", "Combustible")
    Catch ex As Exception
        MsgBox("No se conecto por: " & ex.Message)
    End Try
End Sub
```

**⚠️ IMPORTANTE:** Cada formulario gestiona su propia conexión. No hay conexión compartida o pool de conexiones.

#### 5.2.4 Estado de Formularios (Patrón `act()`)

Método estándar para configurar estado inicial de botones:

```vb
Private Sub act()
    Me.NuevoBtn.Enabled = True
    Me.EditarBtn.Enabled = False
    Me.GuardarBtn.Enabled = False
    Me.ModificarBtn.Enabled = False
    Me.CancelarBtn.Enabled = False
    Me.EliminarBtn.Enabled = False
End Sub
```

#### 5.2.5 Colores Consistentes

```vb
Dim colorFondo = Color.FromArgb(106, 126, 168)      ' Azul grisáceo
Dim colorTextbox = Color.FromArgb(240, 210, 249)    ' Rosa claro
```

### 5.3 Configuración y Secretos

#### 5.3.1 Cadena de Conexión
- **Ubicación:** Hardcodeada en cada formulario dentro de `conectar()`
- **Seguridad:** ⚠️ Credenciales expuestas en código fuente
- **Ambientes:** Se comentan/descomentan conexiones locales vs remotas

#### 5.3.2 Variables de Entorno
- **No se utilizan variables de entorno**
- **No existe App.config personalizado** (solo configuración de runtime estándar)

#### 5.3.3 Configuración de Cultura
- **Localización:** Español (Honduras: `es-HN`, Colombia: `es-CO`)
- **Formato de fecha:** `yyyy/MM/dd`
- **Formato numérico:** Decimal `.`, Miles `,`

```vb
System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("es-HN")
System.Threading.Thread.CurrentThread.CurrentCulture.DateTimeFormat.ShortDatePattern = "yyyy/MM/dd"
System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencyDecimalSeparator = "."
System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.NumberGroupSeparator = ","
```

---

## 6. Guía para Agentes de IA

### 6.1 Cómo Leer y Entender el Proyecto Rápidamente

#### 6.1.1 Pasos de Análisis Inicial

1. **Leer `Principal.vb`:**
   - Identifica la estructura de navegación
   - Comprende cómo se cargan los formularios hijos

2. **Revisar un formulario CRUD completo (ej: `comprobante.vb`):**
   - Analiza el patrón `Load → conectar → act → listadoCamDgv`
   - Estudia los métodos: `limpiar()`, `act()`, `conectar()`
   - Revisa los eventos CRUD: `NuevoBtn_Click`, `GuardarBtn_Click`, `EditarBtn_Click`, `ModificarBtn_Click`, `EliminarBtn_Click`

3. **Identificar dependencias:**
   - Revisar `combustible.vbproj` para librerías externas
   - Verificar `Imports` al inicio de cada archivo

4. **Buscar utilidades:**
   - Revisar `Aletras.vb` para funciones compartidas
   - Buscar módulos globales (ej: `Module Globales` en `propietario.vb`)

#### 6.1.2 Estructura Típica de un Formulario CRUD

```vb
Public Class [NombreEntidad]
    ' === DECLARACIONES ===
    Dim con As New MySqlConnection
    Dim cm As New MySqlCommand
    Dim guardar As New MySqlCommand
    Dim adaptador As New MySqlDataAdapter
    Dim datos As DataSet
    Dim dr As MySqlDataReader
    
    ' === EVENTOS DE CARGA ===
    Private Sub [Entidad]_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        conectar()
        act()
        listadoCamDgv()
        PanelP.Enabled = False
    End Sub
    
    ' === CONEXIÓN ===
    Private Sub conectar()
        ' Configuración de conexión MySQL
    End Sub
    
    ' === ESTADO INICIAL ===
    Private Sub act()
        ' Configuración de botones
    End Sub
    
    ' === LIMPIEZA ===
    Sub limpiar()
        ' Limpia todos los campos
    End Sub
    
    ' === CRUD OPERATIONS ===
    Private Sub NuevoBtn_Click(...)     ' Inicia modo creación
    Private Sub GuardarBtn_Click(...)   ' INSERT
    Private Sub EditarBtn_Click(...)    ' Inicia modo edición
    Private Sub ModificarBtn_Click(...) ' UPDATE
    Private Sub EliminarBtn_Click(...)  ' DELETE
    Private Sub CancelarBtn_Click(...)  ' Cancela operación
    
    ' === LISTADO ===
    Private Sub listadoCamDgv()         ' Carga datos en DataGridView
    Private Sub ListadoD()              ' Configura columnas del DataGridView
End Class
```

### 6.2 Dónde NO Hacer Cambios Sin Justificación Explícita

#### 6.2.1 Archivos Protegidos

- **❌ NO modificar sin autorización:**
  - `Principal.vb`: Lógica de navegación central
  - `My Project/*.Designer.vb`: Archivos generados automáticamente
  - `*.Designer.vb`: Archivos de diseño de formularios (cambios manuales pueden perderse)

- **⚠️ Modificar con precaución:**
  - Método `abrirformulario()` en `Principal.vb`: Cambios afectan toda la navegación
  - Método `conectar()` en múltiples formularios: Cambios requieren actualizar todos los formularios

#### 6.2.2 Patrones Establecidos

- **❌ NO cambiar:**
  - Estructura de métodos CRUD estándar (`NuevoBtn_Click`, `GuardarBtn_Click`, etc.)
  - Nombres de variables comunes (`con`, `cm`, `guardar`, `adaptador`, `datos`)
  - Convención de nombres de controles (`...Btn`, `...Tb`, `CamDGV`)

### 6.3 Cómo Agregar Nuevas Funcionalidades

#### 6.3.1 Agregar un Nuevo Formulario CRUD

**Paso 1:** Crear archivos del formulario
- `[nombre].vb`
- `[nombre].Designer.vb`
- `[nombre].resx`

**Paso 2:** Implementar estructura básica

```vb
Imports System.Data
Imports MySql.Data.MySqlClient
Imports MySql.Data

Public Class [nombre]
    Dim con As New MySqlConnection
    Dim cm As New MySqlCommand
    Dim guardar As New MySqlCommand
    Dim adaptador As New MySqlDataAdapter
    Dim datos As DataSet
    Dim dr As MySqlDataReader
    
    Dim colorFondo = Color.FromArgb(106, 126, 168)
    Dim colorTextbox = Color.FromArgb(240, 210, 249)
    
    Private Sub [nombre]_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        conectar()
        act()
        listadoCamDgv()
        PanelP.Enabled = False
    End Sub
    
    Private Sub conectar()
        ' [Implementar conexión siguiendo patrón estándar]
    End Sub
    
    Private Sub act()
        Me.NuevoBtn.Enabled = True
        Me.EditarBtn.Enabled = False
        Me.GuardarBtn.Enabled = False
        Me.ModificarBtn.Enabled = False
        Me.CancelarBtn.Enabled = False
        Me.EliminarBtn.Enabled = False
    End Sub
    
    Sub limpiar()
        ' [Limpiar todos los campos del formulario]
    End Sub
    
    ' [Implementar métodos CRUD siguiendo patrón estándar]
End Class
```

**Paso 3:** Agregar botón en `Principal.vb`
```vb
Private Sub ButtonX[N]_Click(sender As Object, e As EventArgs) Handles ButtonX[N].Click
    abrirformulario(New [nombre])
    Panel1.Visible = False
End Sub
```

**Paso 4:** Agregar referencia en `combustible.vbproj`
- Agregar `<Compile Include="[nombre].vb">` y `<Compile Include="[nombre].Designer.vb">`
- Agregar `<EmbeddedResource Include="[nombre].resx">`

#### 6.3.2 Agregar Nuevo Método a Formulario Existente

**Reglas:**
1. Seguir convenciones de naming existentes
2. Usar `Try-Catch` para manejo de errores
3. Verificar estado de conexión antes de operaciones BD: `If con.State = ConnectionState.Closed Then con.Open()`
4. Cerrar conexiones adecuadamente (preferiblemente con `Using` o en `Finally`)

**Ejemplo:**
```vb
Private Sub NuevoMetodo_Click(sender As Object, e As EventArgs) Handles NuevoMetodo.Click
    If con.State = ConnectionState.Closed Then
        con.Open()
    End If
    
    Try
        ' Lógica del método
    Catch ex As Exception
        MsgBox("Error: " & ex.Message)
    Finally
        If con.State = ConnectionState.Open Then con.Close()
    End Try
End Sub
```

#### 6.3.3 Agregar Nueva Función Utilitaria

**Ubicación preferida:** Crear nuevo módulo o agregar a `Aletras.vb` si es relacionada

**Estructura:**
```vb
Module [NombreModulo]
    Public Function [NombreFuncion]([parámetros]) As [tipoRetorno]
        Try
            ' Lógica
        Catch ex As Exception
            ' Manejo de error
            Return [valorPorDefecto]
        End Try
    End Function
End Module
```

### 6.4 Patrones que Deben Respetarse Obligatoriamente

#### 6.4.1 Patrón de Conexión

```vb
Private Sub conectar()
    ' Variables locales para configuración (opcional, puede estar hardcodeado)
    Dim servidor As String = "localhost"
    Dim baseDatos As String = "givemefuel"
    Dim userid As String = "root"
    Dim clave As String = ""
    
    ' Conexión activa (puede ser remota)
    con.ConnectionString = "Server=193.203.166.219; Database=u282951626_emtraccF; Uid=u282951626_mmontoya; Pwd=Paradoja25"
    
    Try
        con.Open()
        MessageBox.Show("El sistema esá conectado", "Combustible")
    Catch ex As Exception
        MsgBox("No se conecto por: " & ex.Message)
    End Try
End Sub
```

#### 6.4.2 Patrón de Inserción (INSERT)

```vb
Private Sub GuardarBtn_Click(sender As Object, e As EventArgs) Handles GuardarBtn.Click
    If con.State = ConnectionState.Closed Then
        con.Open()
    End If
    
    Try
        guardar = New MySqlCommand("INSERT INTO tabla (campo1, campo2, campo3) VALUES(@campo1, @campo2, @campo3)", con)
        
        guardar.Parameters.AddWithValue("@campo1", valor1)
        guardar.Parameters.AddWithValue("@campo2", valor2)
        guardar.Parameters.AddWithValue("@campo3", valor3)
        
        guardar.ExecuteNonQuery()
        MsgBox("Registo guardado")
        
        limpiar()
        act()
        CamDGV.Enabled = True
        listadoCamDgv()
    Catch ex As Exception
        MsgBox("Elemento no pudo se almacenado", ex.StackTrace)
    End Try
End Sub
```

**⚠️ IMPORTANTE:** Usar siempre parámetros (`@parametro`) para prevenir SQL Injection. NO usar concatenación de strings.

#### 6.4.3 Patrón de Actualización (UPDATE)

**Método 1: Con parámetros (RECOMENDADO)**
```vb
Public Sub actual()
    If con.State = ConnectionState.Closed Then
        con.Open()
    End If
    
    Try
        Dim actualizar As String = "UPDATE tabla SET campo1 = @campo1, campo2 = @campo2 WHERE id = @id"
        Dim act As New MySqlCommand(actualizar, con)
        act.Parameters.AddWithValue("@campo1", valor1)
        act.Parameters.AddWithValue("@campo2", valor2)
        act.Parameters.AddWithValue("@id", id)
        act.ExecuteNonQuery()
        MsgBox("Registo Actualizado")
    Catch ex As Exception
        MsgBox("Error: " & ex.Message)
    End Try
End Sub
```

**Método 2: Concatenación (EXISTENTE pero NO RECOMENDADO)**
```vb
' ⚠️ Patrón existente pero vulnerable a SQL Injection
actualizar = "UPDATE tabla SET campo1 = '" & valor1 & "', campo2 = '" & valor2 & "' WHERE id = '" & id & "'"
Dim act As New MySqlCommand(actualizar, con)
act.ExecuteNonQuery()
```

#### 6.4.4 Patrón de Consulta (SELECT)

```vb
Private Sub listadoCamDgv()
    Dim table As New DataTable()
    Dim adaptadoListado As New MySqlDataAdapter("SELECT campo1, campo2, campo3 FROM tabla", con)
    adaptadoListado.Fill(table)
    
    CamDGV.DataSource = table
    ListadoD()
End Sub

Private Sub ListadoD()
    CamDGV.Columns(0).HeaderText = "Campo 1"
    CamDGV.Columns(0).Width = 100
    CamDGV.Columns(1).HeaderText = "Campo 2"
    CamDGV.Columns(1).Width = 150
    ' ...
End Sub
```

#### 6.4.5 Patrón de Selección de Registro

```vb
Public Sub Seleccion()
    Dim consulta As String
    Dim lista As Byte
    
    If buscartxt.Text <> "" Then
        consulta = "SELECT * FROM tabla WHERE id = '" & buscartxt.Text & "'"
        adaptador = New MySqlDataAdapter(consulta, con)
        datos = New DataSet
        adaptador.Fill(datos, "tabla")
        lista = datos.Tables("tabla").Rows.Count
    End If
    
    If lista <> 0 Then
        campo1Tb.Text = datos.Tables("tabla").Rows(0).Item("campo1").ToString
        campo2Tb.Text = datos.Tables("tabla").Rows(0).Item("campo2").ToString
        ' ...
    Else
        MsgBox("Datos no encontrados")
    End If
End Sub
```

### 6.5 Anti-Patrones que Deben Evitarse

#### 6.5.1 ❌ NO Hacer: Concatenación de SQL

```vb
' ❌ MAL - Vulnerable a SQL Injection
Dim query As String = "SELECT * FROM usuarios WHERE nombre = '" & nombreTb.Text & "'"

' ✅ BIEN - Usar parámetros
Dim query As String = "SELECT * FROM usuarios WHERE nombre = @nombre"
cmd.Parameters.AddWithValue("@nombre", nombreTb.Text)
```

#### 6.5.2 ❌ NO Hacer: Credenciales Hardcodeadas en Producción

```vb
' ❌ MAL - Credenciales expuestas
con.ConnectionString = "Server=server; Database=db; Uid=user; Pwd=password123"

' ⚠️ MEJOR - Usar variables (aún no ideal, pero mejor)
' ✅ IDEAL - Usar configuración externa (recomendado implementar)
```

#### 6.5.3 ❌ NO Hacer: Múltiples Conexiones Abiertas

```vb
' ❌ MAL - Abre conexión sin verificar
con.Open()
' ... código ...
con.Open() ' Puede fallar si ya está abierta

' ✅ BIEN - Verificar estado
If con.State = ConnectionState.Closed Then
    con.Open()
End If
```

#### 6.5.4 ❌ NO Hacer: Ignorar Errores con `On Error Resume Next`

```vb
' ❌ MAL - Oculta errores
On Error Resume Next
' Código que puede fallar

' ✅ BIEN - Manejar errores explícitamente
Try
    ' Código
Catch ex As Exception
    MsgBox("Error: " & ex.Message)
End Try
```

#### 6.5.5 ❌ NO Hacer: No Cerrar Conexiones

```vb
' ❌ MAL - Conexión queda abierta
con.Open()
' ... operaciones ...
' No se cierra

' ✅ BIEN - Usar Using o Finally
Using cmd As New MySqlCommand(query, con)
    ' Operaciones
End Using

' O
Try
    con.Open()
    ' Operaciones
Finally
    If con.State = ConnectionState.Open Then con.Close()
End Try
```

#### 6.5.6 ❌ NO Hacer: Variables con Nombres Inconsistentes

```vb
' ❌ MAL - No seguir convención
Dim connection As New MySqlConnection
Dim command As New MySqlCommand

' ✅ BIEN - Usar nombres estándar
Dim con As New MySqlConnection
Dim cm As New MySqlCommand
```

---

## 7. Reglas Operativas para IA

### 7.1 Archivos que DEBEN Revisarse Antes de Proponer Cambios

#### 7.1.1 Antes de Modificar Cualquier Formulario CRUD

1. **Revisar `comprobante.vb` o `factura.vb`:**
   - Son ejemplos completos del patrón CRUD estándar
   - Contienen ejemplos de operaciones complejas (impresión, cálculos)

2. **Revisar `Principal.vb`:**
   - Si el cambio afecta navegación o estructura general

3. **Revisar `combustible.vbproj`:**
   - Si se agregan nuevos archivos o referencias

#### 7.1.2 Antes de Modificar Conexiones a BD

1. **Revisar TODOS los archivos `.vb`:**
   - Buscar todas las instancias de `conectar()`
   - Verificar si hay un patrón común que deba mantenerse

2. **Buscar referencias a `con`:**
   ```bash
   grep -r "Dim con As New MySqlConnection"
   ```

### 7.2 Cómo Validar que un Cambio es Coherente con la Arquitectura

#### 7.2.1 Checklist de Validación

- [ ] ¿El código sigue las convenciones de naming establecidas?
- [ ] ¿Se utiliza el patrón de conexión estándar?
- [ ] ¿Los métodos CRUD siguen la estructura esperada?
- [ ] ¿Se usa `Try-Catch` para manejo de errores?
- [ ] ¿Se verifica el estado de la conexión antes de usarla?
- [ ] ¿Se usan parámetros en consultas SQL (no concatenación)?
- [ ] ¿Los colores y estilos UI son consistentes?
- [ ] ¿Se respeta el patrón `act()` para estado de botones?

#### 7.2.2 Validación de Tipos de Datos

**Para campos numéricos en BD:**
- Si el campo es `INT` → Convertir a `Integer` antes de enviar
- Si el campo es `DECIMAL` → Convertir a `Double` antes de enviar
- Si el campo es `VARCHAR` → Enviar como `String` (`.Text`)

**Ejemplo de conversión:**
```vb
' Para campos DECIMAL
Dim valorC As Double = 0
Double.TryParse(valorTb.Text, valorC)
guardar.Parameters.AddWithValue("@valor", valorC)

' Para campos VARCHAR (NO convertir a Integer)
guardar.Parameters.AddWithValue("@periodo", periodoTb.Text)
```

### 7.3 Cómo Documentar Cambios Realizados

#### 7.3.1 Comentarios en Código

```vb
' ============ DESCRIPCIÓN DE LA SECCIÓN ===========
Private Sub NuevoMetodo_Click(sender As Object, e As EventArgs) Handles NuevoMetodo.Click
    ' Descripción breve de lo que hace el método
    ' Autor: [nombre o IA]
    ' Fecha: [fecha]
    ' Razón: [por qué se agregó o modificó]
    
    ' Implementación
End Sub
```

#### 7.3.2 Mensajes de Commit (si se usa Git)

Formato sugerido:
```
[CATEGORÍA] Descripción breve

Descripción detallada del cambio:
- Qué se cambió
- Por qué se cambió
- Impacto esperado

Archivos modificados:
- archivo1.vb
- archivo2.vb
```

Categorías: `[FIX]`, `[FEAT]`, `[REFACTOR]`, `[DOC]`, `[SECURITY]`

### 7.4 Cómo Minimizar Deuda Técnica

#### 7.4.1 Prioridades de Mejora (No Bloquear Funcionalidad Nueva)

1. **Alto Impacto, Bajo Esfuerzo:**
   - Agregar verificación de estado de conexión antes de abrir
   - Usar parámetros en lugar de concatenación SQL (cuando se modifique código existente)

2. **Medio Impacto, Medio Esfuerzo:**
   - Centralizar configuración de conexión (crear clase `DatabaseConnection`)
   - Implementar logging estructurado

3. **Bajo Impacto, Alto Esfuerzo (Refactorización Mayor):**
   - Separar lógica de negocio de formularios
   - Implementar capa de acceso a datos (Repository Pattern)
   - Migrar a Entity Framework o similar

#### 7.4.2 Regla de Oro

> **Al modificar código existente, mejorarlo ligeramente sin cambiar su estructura fundamental. Al agregar código nuevo, seguir mejores prácticas.**

**Ejemplo:**
```vb
' Código existente (concatenación SQL):
actualizar = "UPDATE tabla SET campo = '" & valor & "' WHERE id = '" & id & "'"

' ✅ MEJORA al modificar (usar parámetros):
Dim actualizar As String = "UPDATE tabla SET campo = @campo WHERE id = @id"
Dim cmd As New MySqlCommand(actualizar, con)
cmd.Parameters.AddWithValue("@campo", valor)
cmd.Parameters.AddWithValue("@id", id)
cmd.ExecuteNonQuery()
```

---

## 8. Patrones de Diseño Identificados

### 8.1 Patrones Implementados

#### 8.1.1 Form-Based CRUD Pattern
- **Descripción:** Cada formulario encapsula toda la lógica CRUD para una entidad
- **Ubicación:** Todos los formularios de gestión
- **Características:**
  - Lógica de presentación y datos en la misma clase
  - Métodos estándar: `limpiar()`, `act()`, `listadoCamDgv()`
  - Eventos estándar: `NuevoBtn_Click`, `GuardarBtn_Click`, etc.

#### 8.1.2 Singleton-like Connection (Implícito)
- **Descripción:** Cada formulario mantiene una única instancia de conexión
- **Variable:** `Dim con As New MySqlConnection`
- **Nota:** No es un Singleton verdadero, cada formulario tiene su propia instancia

#### 8.1.3 Template Method (Implícito)
- **Descripción:** Métodos como `act()`, `limpiar()`, `conectar()` siguen una estructura similar en todos los formularios
- **Variación:** Cada formulario implementa detalles específicos

### 8.2 Patrones NO Utilizados (Oportunidades de Mejora)

- ❌ **Repository Pattern:** No existe capa de abstracción de datos
- ❌ **Service Layer:** Lógica de negocio mezclada con presentación
- ❌ **Dependency Injection:** Dependencias hardcodeadas
- ❌ **Unit of Work:** Cada operación gestiona su propia transacción
- ❌ **Factory Pattern:** Instancias creadas directamente con `New`

---

## 9. Flujos Críticos del Sistema

### 9.1 Flujo de Inicio de Aplicación

```
1. MyApplication.Startup
   ↓
2. Principal_Load
   ↓
3. [Usuario selecciona opción de menú]
   ↓
4. Principal.abrirformulario(New [Formulario])
   ↓
5. [Formulario]_Load
   ↓
6. conectar() → con.Open()
   ↓
7. act() → Configura estado inicial
   ↓
8. listadoCamDgv() → Carga datos iniciales
```

### 9.2 Flujo CRUD Completo

#### 9.2.1 Crear Registro

```
Usuario: Click en "Nuevo"
   ↓
NuevoBtn_Click()
   ↓
limpiar() → Limpia campos
PanelP.Enabled = True
GuardarBtn.Enabled = True
CamDGV.Enabled = False
   ↓
Usuario: Llena campos y click en "Guardar"
   ↓
GuardarBtn_Click()
   ↓
Verificar: con.State
   ↓
Crear: MySqlCommand con parámetros
   ↓
guardar.Parameters.AddWithValue(...)
   ↓
guardar.ExecuteNonQuery()
   ↓
MsgBox("Registo guardado")
   ↓
limpiar()
act()
listadoCamDgv()
```

#### 9.2.2 Editar Registro

```
Usuario: Selecciona registro en DataGridView
   ↓
CamDGV_Click()
   ↓
Seleccion() → Carga datos en formulario
   ↓
Usuario: Click en "Editar"
   ↓
EditarBtn_Click()
   ↓
PanelP.Enabled = True
GuardarBtn.Visible = False
ModificarBtn.Enabled = True
   ↓
Usuario: Modifica campos y click en "Modificar"
   ↓
ModificarBtn_Click()
   ↓
actual() → UPDATE con parámetros
   ↓
MsgBox("Registo Actualizado")
   ↓
act()
listadoCamDgv()
```

### 9.3 Flujo de Autenticación (acceso.vb)

```
acceso_Load()
   ↓
conectar()
   ↓
Usuario: Ingresa credenciales
   ↓
[Evento de Login]
   ↓
ComputeSHA256(clave) → Hash de contraseña
   ↓
SELECT * FROM accesos WHERE usuario = @usuario AND clave = @hash
   ↓
Validar credenciales
   ↓
[Acceso concedido o denegado]
```

### 9.4 Flujo de Impresión (factura.vb, comprobante.vb)

```
Usuario: Click en "Vista Previa" o "Imprimir"
   ↓
PreviaBtn_Click() / ImprimirBt_Click()
   ↓
Print[Documento].PrinterSettings.Copies = 1
   ↓
PrintPreview[Documento].Document = Print[Documento]
   ↓
Print[Documento]_PrintPage()
   ↓
SELECT datos de empresa/configuración
   ↓
e.Graphics.DrawString(...) → Dibuja cada elemento
   ↓
[Vista previa o impresión]
```

---

## 10. Dependencias y Consideraciones Especiales

### 10.1 Dependencias Externas Requeridas

- **MySQL Server:** Debe estar accesible (local o remoto)
- **MySQL Connector/NET 9.0:** Debe estar instalado en `Program Files (x86)\MySQL\MySQL Connector NET 9.0\`
- **DevComponents DotNetBar:** DLLs en `bin\Debug\` o `bin\Release\`
- **.NET Framework 4.7.2:** Runtime requerido

### 10.2 Consideraciones de Despliegue

- La aplicación compila a ejecutable standalone (`Prueba.exe`)
- Requiere DLLs de terceros en la carpeta `bin`
- Conexiones a BD están hardcodeadas (considerar configuración externa para producción)
- No hay sistema de instalador (considerar crear Setup.exe)

### 10.3 Limitaciones Conocidas

1. **Conexiones múltiples:** Cada formulario abre su propia conexión (no hay pooling eficiente)
2. **Sin transacciones:** Cada operación es independiente
3. **Sin validación centralizada:** Validaciones dispersas en cada formulario
4. **Credenciales expuestas:** Cadenas de conexión con credenciales en código
5. **Sin logging estructurado:** Solo `MsgBox` para errores
6. **Sin tests:** No hay pruebas unitarias o de integración

---

## 11. Glosario de Términos del Proyecto

- **CamDGV / CamDgv:** DataGridView principal para mostrar listados
- **PanelP:** Panel principal que contiene los controles de edición
- **buscartxt:** TextBox oculto que almacena el ID del registro seleccionado
- **act():** Método que configura el estado inicial de los botones CRUD
- **conectar():** Método que establece conexión a MySQL
- **limpiar():** Método que vacía todos los campos del formulario
- **listadoCamDgv():** Método que carga datos en el DataGridView
- **Seleccion():** Método que carga datos de un registro seleccionado en los controles

---

## 12. Contacto y Mantenimiento

**Nota para Agentes de IA:**

Al realizar cambios en este proyecto:

1. **Siempre** revisar este documento primero
2. **Siempre** seguir los patrones establecidos
3. **Siempre** usar parámetros en consultas SQL
4. **Nunca** exponer credenciales en código (aunque el código actual lo hace, mejorar cuando sea posible)
5. **Siempre** validar tipos de datos antes de enviar a BD
6. **Siempre** verificar estado de conexión antes de operaciones BD

---

**Fin del Documento**
