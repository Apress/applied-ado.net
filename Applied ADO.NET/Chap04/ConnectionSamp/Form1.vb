Imports System.Data
Imports System.Data.Common
Imports System.Data.SqlClient
Imports System.Data.OleDb

Public Class Form1
  Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

  Public Sub New()
    MyBase.New()

    'This call is required by the Windows Form Designer.
    InitializeComponent()

    'Add any initialization after the InitializeComponent() call

  End Sub

  'Form overrides dispose to clean up the component list.
  Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
    If disposing Then
      If Not (components Is Nothing) Then
        components.Dispose()
      End If
    End If
    MyBase.Dispose(disposing)
  End Sub

  'Required by the Windows Form Designer
  Private components As System.ComponentModel.IContainer

  'NOTE: The following procedure is required by the Windows Form Designer
  'It can be modified using the Windows Form Designer.  
  'Do not modify it using the code editor.
  Friend WithEvents MainMenu1 As System.Windows.Forms.MainMenu
  Friend WithEvents MenuItem1 As System.Windows.Forms.MenuItem
  Friend WithEvents OpenAndClose As System.Windows.Forms.MenuItem
  Friend WithEvents OleDbProperties As System.Windows.Forms.MenuItem
  Friend WithEvents SqlClientProperties As System.Windows.Forms.MenuItem
  Friend WithEvents SqlServerUsingOleDb As System.Windows.Forms.MenuItem
  Friend WithEvents MenuItem2 As System.Windows.Forms.MenuItem
  Friend WithEvents TwoConnections As System.Windows.Forms.MenuItem
  Friend WithEvents ReleaseObjectPool As System.Windows.Forms.MenuItem
  Friend WithEvents CreateCommandMenu As System.Windows.Forms.MenuItem
  Friend WithEvents ChangeDatabaseMenu As System.Windows.Forms.MenuItem
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.MainMenu1 = New System.Windows.Forms.MainMenu()
    Me.MenuItem1 = New System.Windows.Forms.MenuItem()
    Me.OpenAndClose = New System.Windows.Forms.MenuItem()
    Me.OleDbProperties = New System.Windows.Forms.MenuItem()
    Me.SqlClientProperties = New System.Windows.Forms.MenuItem()
    Me.SqlServerUsingOleDb = New System.Windows.Forms.MenuItem()
    Me.MenuItem2 = New System.Windows.Forms.MenuItem()
    Me.TwoConnections = New System.Windows.Forms.MenuItem()
    Me.ReleaseObjectPool = New System.Windows.Forms.MenuItem()
    Me.CreateCommandMenu = New System.Windows.Forms.MenuItem()
    Me.ChangeDatabaseMenu = New System.Windows.Forms.MenuItem()
    '
    'MainMenu1
    '
    Me.MainMenu1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem1, Me.MenuItem2})
    '
    'MenuItem1
    '
    Me.MenuItem1.Index = 0
    Me.MenuItem1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.OpenAndClose, Me.OleDbProperties, Me.SqlClientProperties, Me.SqlServerUsingOleDb})
    Me.MenuItem1.Text = "Connection"
    '
    'OpenAndClose
    '
    Me.OpenAndClose.Index = 0
    Me.OpenAndClose.Text = "Open and Close"
    '
    'OleDbProperties
    '
    Me.OleDbProperties.Index = 1
    Me.OleDbProperties.Text = "OleDb"
    '
    'SqlClientProperties
    '
    Me.SqlClientProperties.Index = 2
    Me.SqlClientProperties.Text = "SqlClient"
    '
    'SqlServerUsingOleDb
    '
    Me.SqlServerUsingOleDb.Index = 3
    Me.SqlServerUsingOleDb.Text = "SQlServer using OleDb DataProvider"
    '
    'MenuItem2
    '
    Me.MenuItem2.Index = 1
    Me.MenuItem2.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.TwoConnections, Me.ReleaseObjectPool, Me.CreateCommandMenu, Me.ChangeDatabaseMenu})
    Me.MenuItem2.Text = "Connection Pooling"
    '
    'TwoConnections
    '
    Me.TwoConnections.Index = 0
    Me.TwoConnections.Text = "Two Connections"
    '
    'ReleaseObjectPool
    '
    Me.ReleaseObjectPool.Index = 1
    Me.ReleaseObjectPool.Text = "ReleaseObjectPool"
    '
    'CreateCommandMenu
    '
    Me.CreateCommandMenu.Index = 2
    Me.CreateCommandMenu.Text = "CreateCommand"
    '
    'ChangeDatabaseMenu
    '
    Me.ChangeDatabaseMenu.Index = 3
    Me.ChangeDatabaseMenu.Text = "ChangeDatabase"
    '
    'Form1
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(328, 273)
    Me.Menu = Me.MainMenu1
    Me.Name = "Form1"
    Me.Text = "Form1"

  End Sub

#End Region

  Private Sub OpenAndClose_Click(ByVal sender As System.Object, _
 ByVal e As System.EventArgs) Handles OpenAndClose.Click
    Dim connString As String = "user id=sa;password=password;" & _
    "initial catalog=northwind;data source=Northwind;Connect Timeout=30"
    Dim conn1 As SqlConnection = New SqlConnection(connString)
    Dim conn2 As SqlConnection = New SqlConnection()
    conn2.ConnectionString = connString

  End Sub

  Private Sub OleDbProperties_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OleDbProperties.Click
    ' Create a Connection Object
    Dim ConnectionString As String = "Provider=Microsoft.Jet.OLEDB.4.0;" & _
                "Data Source=c:\\Northwind.mdb"
    Dim conn As OleDbConnection = New OleDbConnection(ConnectionString)
    ' Open the connection
    If conn.State <> ConnectionState.Open Then
      conn.Open()
      MessageBox.Show("Connection state: " + conn.State.ToString())
    End If
    ' Show the connection properties
    MessageBox.Show("Connection String :" + conn.ConnectionString & _
                ", DataSource :" + conn.DataSource.ToString() & _
                ", Provider :" + conn.Provider.ToString() & _
                "," + conn.ServerVersion.ToString() & _
                "," + conn.ConnectionTimeout.ToString())

    ' Close the connection
    If conn.State = ConnectionState.Open Then
      conn.Close()
      MessageBox.Show("Connection state: " + conn.State.ToString())
    End If
    ' Dispose the connection
    If (Not conn Is Nothing) Then
      conn.Dispose()
    End If

  End Sub

  Private Sub SqlClientProperties_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SqlClientProperties.Click


    ' Create a Connection Object
    Dim ConnectionString As String = "Integrated Security=SSPI;" & _
                "Initial Catalog=Northwind;Data Source=MCB;"
    Dim conn As SqlConnection = New SqlConnection(ConnectionString)
    ' Open the connection
    If conn.State <> ConnectionState.Open Then
      conn.Open()
      MessageBox.Show("Connection state: " + conn.State.ToString())
    End If
    ' Show the connection properties
    MessageBox.Show("Connection String :" + conn.ConnectionString & _
                ", Workstation Id:" + conn.WorkstationId.ToString() & _
                ", Packet Size :" + conn.PacketSize.ToString() & _
                ", Server Version " + conn.ServerVersion.ToString() & _
                ", DataSource :" + conn.DataSource.ToString() & _
                ", Server Version:" + conn.ServerVersion.ToString() & _
                ", Connection Time Out:" + conn.ConnectionTimeout.ToString())

    ' Close the connection
    If conn.State = ConnectionState.Open Then
      conn.Close()
      MessageBox.Show("Connection state: " + conn.State.ToString())
    End If
    ' Dispose the connection
    If (Not conn Is Nothing) Then
      conn.Dispose()
    End If
  End Sub

  Private Sub SqlServerUsingOleDb_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SqlServerUsingOleDb.Click

    ' Create a Connection Object
    Dim ConnectionString As String = "Provider=SQLOLEDB.1;" & _
          "Integrated Security=SSPI;" & _
          "Persist Security Info=false;" & _
          "Initial Catalog=Northwind;" & _
          "Data Source=MCB;"
    Dim conn As OleDbConnection = New OleDbConnection(ConnectionString)
    ' Open the connection
    If conn.State <> ConnectionState.Open Then
      conn.Open()
      MessageBox.Show("Connection state: " + conn.State.ToString())
    End If
    ' Show the connection properties
    MessageBox.Show("Connection String :" + conn.ConnectionString & _
                        ", Server Version " + conn.ServerVersion.ToString() & _
                ", DataSource :" + conn.DataSource.ToString() & _
                ", Server Version:" + conn.ServerVersion.ToString() & _
                ", Connection Time Out:" + conn.ConnectionTimeout.ToString())

    ' Close the connection
    If conn.State = ConnectionState.Open Then
      conn.Close()
      MessageBox.Show("Connection state: " + conn.State.ToString())
    End If
    ' Dispose the connection
    If (Not conn Is Nothing) Then
      conn.Dispose()
    End If
  End Sub

  Private Sub TwoConnections_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TwoConnections.Click

    ' Create a Connection Object
    Dim ConnectionString1 As String = "Integrated Security=SSPI;" & _
    "Initial Catalog=Northwind;" & _
    "Data Source=MCB;"
    Dim conn1 As SqlConnection = New SqlConnection(ConnectionString1)
    ' Create a Connection Object
    Dim ConnectionString2 As String = "Integrated Security=SSPI;" & _
        "Initial Catalog=Pubs;" & _
        "Data Source=MCB;"
    Dim conn2 As SqlConnection = New SqlConnection(ConnectionString2)
    ' Open connections
    conn1.Open()
    conn2.Open()
    MessageBox.Show("Connection1 " + conn1.State.ToString())
    MessageBox.Show("Connection2 " + conn2.State.ToString())
    ' some code
    conn1.Close()
    conn2.Close()
    MessageBox.Show("Connection1 " + conn1.State.ToString())
    MessageBox.Show("Connection2 " + conn2.State.ToString())
    ' Dispose the connection
    If (Not conn1 Is Nothing) Then
      conn1.Dispose()
    End If
    ' Dispose the connection
    If (Not conn2 Is Nothing) Then
      conn2.Dispose()
    End If

  End Sub

  Private Sub ReleaseObjectPool_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReleaseObjectPool.Click

    ' Connection and SQL strings
    Dim ConnectionString As String = "Provider=Microsoft.Jet.OLEDB.4.0;" & _
    "Data Source=c:\\Northwind.mdb"
    Dim SQL As String = "SELECT OrderID, Customer, CustomerID FROM Orders"
    ' Create connection object
    Dim conn As OleDbConnection = New OleDbConnection(ConnectionString)
    conn.Open()
    ' do something
    conn.Close()
    OleDbConnection.ReleaseObjectPool()
    ' Dispose the connection
    If (Not conn Is Nothing) Then
      conn.Dispose()
    End If

  End Sub

  Private Sub CreateCommandMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CreateCommandMenu.Click
    ' Create a Connection Object
    Dim ConnectionString As String = "Integrated Security=SSPI;" & _
                "Initial Catalog=Northwind;Data Source=MCB;"
    Dim conn As SqlConnection = New SqlConnection(ConnectionString)
    ' Open the connection
    If conn.State <> ConnectionState.Open Then
      conn.Open()
    End If
    Dim cmd As SqlCommand = conn.CreateCommand()
    ' Do something with the command
    cmd.CommandText = "SELECT * FROM Customers"
    MessageBox.Show(cmd.CommandText.ToString())

    ' Close the connection
    If conn.State = ConnectionState.Open Then
      conn.Close()
    End If
    ' Dispose the connection
    If (Not conn Is Nothing) Then
      conn.Dispose()
    End If
  End Sub

  Private Sub ChangeDatabaseMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChangeDatabaseMenu.Click
    ' Create a Connection Object
    Dim ConnectionString As String = "Integrated Security=SSPI;" & _
                "Initial Catalog=Northwind;Data Source=MCB;"
    Dim conn As SqlConnection = New SqlConnection(ConnectionString)
    ' Open the connection
    If conn.State <> ConnectionState.Open Then
      conn.Open()
    End If
    conn.ChangeDatabase("pubs")
    ' Do something with the command
    MessageBox.Show(conn.Database.ToString())

    ' Close the connection
    If conn.State = ConnectionState.Open Then
      conn.Close()
    End If
    ' Dispose the connection
    If (Not conn Is Nothing) Then
      conn.Dispose()
    End If
  End Sub
End Class
