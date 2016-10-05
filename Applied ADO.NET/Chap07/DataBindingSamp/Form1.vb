Imports System.Data.SqlClient

' Custom Recordset class provides functionality to 
' navigate through records of a Table
Public Class CustomRecordset
  ' Change the connection string for your SQL Server, 
  ' user id and password
  Private ConnectionString As String = "Integrated Security=SSPI;" & _
     "Initial Catalog=Northwind;Data Source=MCB;"
  Private conn As SqlConnection = Nothing
  Private sql As String = "SELECT * FROM Customers"
  Private adapter As SqlDataAdapter = Nothing
  Private ds As DataSet = Nothing

  ' CustomRecord default constructor
  Public Sub CustomRecordset()
  End Sub

  Public Sub ConnectDataSource()
    Me.ds = New DataSet("Customers")
    Me.conn = New SqlConnection()
    Me.conn.ConnectionString = Me.ConnectionString
    Me.adapter = New SqlDataAdapter(sql, conn)
    Me.adapter.Fill(Me.ds, "Customers")
  End Sub
  ' CustomRecord constructor with Connection string
  Public Sub CustomRecordset(ByVal connStr As String)
    Me.conn = New SqlConnection(connStr)
    Me.adapter = New SqlDataAdapter(Me.sql, Me.conn)
    Me.adapter.Fill(Me.ds, "Customers")
  End Sub
  ' CustomRecord constructor with Connection string
  ' & SQL statement
  Public Sub CustomRecordset(ByVal connStr As String, _
  ByVal sqlStmt As String)
    Me.conn = New SqlConnection(connStr)
    Me.adapter = New SqlDataAdapter(sqlStmt, conn)
    Me.adapter.Fill(ds, "Customers")
  End Sub
  ' Bind data to a DataGrid control
  Public Sub BindDataSet(ByVal dtGrid As DataGrid)
    dtGrid.DataSource = Me.ds
    dtGrid.DataMember = "Customers"
  End Sub
  ' Bind data to a DataGrid control
  Public Sub BindDataView(ByVal dtGrid As DataGrid, _
  ByVal tableName As String)
    Dim dtTable As DataTable = Me.ds.Tables(tableName)
    Dim dv As DataView = New DataView(dtTable)
    dtGrid.DataSource = dv
  End Sub
  ' Bind all tables of a DataSet 
  Public Sub BindDataViewManager(ByVal dtGrid As DataGrid)
    dtGrid.DataSource = Me.ds.DefaultViewManager
  End Sub
  ' MoveNext method sets Position to +1
  Public Sub MoveNextRecord(ByVal form As Form)
    Dim idx As Int32 = _
    form.BindingContext(Me.ds, "Customers").Position
    form.BindingContext(Me.ds, "Customers").Position = idx + 1
  End Sub
  ' MoveNext method sets Position to -1
  Public Sub MovePrevRecord(ByVal form As Form)
    Dim idx As Int32 = _
    form.BindingContext(Me.ds, "Customers").Position
    form.BindingContext(Me.ds, "Customers").Position = idx - 1
  End Sub
  ' MoveFirst sets Position to 0
  Public Sub MoveFirstRecord(ByVal form As Form)
    form.BindingContext(Me.ds, "Customers").Position = 0
  End Sub
  ' MoveLast method sets Position to Count-1 
  Public Sub MoveLastRecord(ByVal form As Form)
    form.BindingContext(Me.ds, "Customers").Position = _
    form.BindingContext(Me.ds, "Customers").Count - 1
  End Sub

  ' SaveChanges from DataGrid to data source
  Public Sub SaveChanges()
    If (ds Is Nothing) Then
      Return
    End If
    ' Save changes
    adapter.Update(ds, "Customers")
  End Sub

  ' Suspend binding
  Public Sub SuspendBinding(ByVal form As Form)
    form.BindingContext(ds, "Customers").SuspendBinding()
  End Sub
  ' Resume binding
  Public Sub ResumeBinding(ByVal form As Form)
    form.BindingContext(ds, "Customers").ResumeBinding()
  End Sub
  ' Disconnect Grid 
  Public Sub DisconnectGrid(ByVal dtGrid As DataGrid)
    dtGrid.DataSource = Nothing
    dtGrid.DataMember = Nothing
    dtGrid.Refresh()
  End Sub

  ' Release Connection
  Public Sub ReleaseResources()
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
End Class



Public Class Form1
  Inherits System.Windows.Forms.Form

  Dim ConnectionString As String = "Integrated Security=SSPI;" & _
    "Initial Catalog=Northwind;Data Source=MCB;"
  Private conn As SqlConnection = Nothing
  Private sql As String = "SELECT * FROM Customers"
  Private adapter As SqlDataAdapter = Nothing
  Private ds As DataSet = Nothing
  Private dv As DataView
  Private curManager As CurrencyManager

  Private dsOrders As DataSet
  Private dsCustomers As DataSet


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
  Friend WithEvents MenuItem2 As System.Windows.Forms.MenuItem
  Friend WithEvents MenuItem3 As System.Windows.Forms.MenuItem
  Friend WithEvents ListProperty As System.Windows.Forms.MenuItem
  Friend WithEvents BindControlsMenu As System.Windows.Forms.MenuItem
  Friend WithEvents DataGrid1 As System.Windows.Forms.DataGrid
  Friend WithEvents CustomRecordset As System.Windows.Forms.MenuItem
  Friend WithEvents MoveFirstBtn As System.Windows.Forms.Button
  Friend WithEvents MovePrevBtn As System.Windows.Forms.Button
  Friend WithEvents MoveNextBtn As System.Windows.Forms.Button
  Friend WithEvents MoveLastBtn As System.Windows.Forms.Button
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.MainMenu1 = New System.Windows.Forms.MainMenu()
    Me.MenuItem1 = New System.Windows.Forms.MenuItem()
    Me.BindControlsMenu = New System.Windows.Forms.MenuItem()
    Me.CustomRecordset = New System.Windows.Forms.MenuItem()
    Me.MenuItem2 = New System.Windows.Forms.MenuItem()
    Me.ListProperty = New System.Windows.Forms.MenuItem()
    Me.MenuItem3 = New System.Windows.Forms.MenuItem()
    Me.DataGrid1 = New System.Windows.Forms.DataGrid()
    Me.MoveFirstBtn = New System.Windows.Forms.Button()
    Me.MovePrevBtn = New System.Windows.Forms.Button()
    Me.MoveNextBtn = New System.Windows.Forms.Button()
    Me.MoveLastBtn = New System.Windows.Forms.Button()
    CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'MainMenu1
    '
    Me.MainMenu1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem1, Me.MenuItem2, Me.MenuItem3})
    '
    'MenuItem1
    '
    Me.MenuItem1.Index = 0
    Me.MenuItem1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.BindControlsMenu, Me.CustomRecordset})
    Me.MenuItem1.Text = "Bindings"
    '
    'BindControlsMenu
    '
    Me.BindControlsMenu.Index = 0
    Me.BindControlsMenu.Text = "Bind Controls"
    '
    'CustomRecordset
    '
    Me.CustomRecordset.Index = 1
    Me.CustomRecordset.Text = "Custom Recordset"
    '
    'MenuItem2
    '
    Me.MenuItem2.Index = 1
    Me.MenuItem2.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.ListProperty})
    Me.MenuItem2.Text = "CurrencyManager"
    '
    'ListProperty
    '
    Me.ListProperty.Index = 0
    Me.ListProperty.Text = "List Property"
    '
    'MenuItem3
    '
    Me.MenuItem3.Index = 2
    Me.MenuItem3.Text = "PropertyManager"
    '
    'DataGrid1
    '
    Me.DataGrid1.DataMember = ""
    Me.DataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText
    Me.DataGrid1.Location = New System.Drawing.Point(8, 160)
    Me.DataGrid1.Name = "DataGrid1"
    Me.DataGrid1.Size = New System.Drawing.Size(408, 168)
    Me.DataGrid1.TabIndex = 2
    '
    'MoveFirstBtn
    '
    Me.MoveFirstBtn.Location = New System.Drawing.Point(16, 128)
    Me.MoveFirstBtn.Name = "MoveFirstBtn"
    Me.MoveFirstBtn.Size = New System.Drawing.Size(32, 24)
    Me.MoveFirstBtn.TabIndex = 9
    Me.MoveFirstBtn.Text = "<<"
    '
    'MovePrevBtn
    '
    Me.MovePrevBtn.Location = New System.Drawing.Point(48, 128)
    Me.MovePrevBtn.Name = "MovePrevBtn"
    Me.MovePrevBtn.Size = New System.Drawing.Size(32, 24)
    Me.MovePrevBtn.TabIndex = 10
    Me.MovePrevBtn.Text = "<"
    '
    'MoveNextBtn
    '
    Me.MoveNextBtn.Location = New System.Drawing.Point(80, 128)
    Me.MoveNextBtn.Name = "MoveNextBtn"
    Me.MoveNextBtn.Size = New System.Drawing.Size(32, 24)
    Me.MoveNextBtn.TabIndex = 11
    Me.MoveNextBtn.Text = ">"
    '
    'MoveLastBtn
    '
    Me.MoveLastBtn.Location = New System.Drawing.Point(112, 128)
    Me.MoveLastBtn.Name = "MoveLastBtn"
    Me.MoveLastBtn.Size = New System.Drawing.Size(32, 24)
    Me.MoveLastBtn.TabIndex = 12
    Me.MoveLastBtn.Text = ">>"
    '
    'Form1
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(432, 337)
    Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.MoveLastBtn, Me.MoveNextBtn, Me.MovePrevBtn, Me.MoveFirstBtn, Me.DataGrid1})
    Me.Menu = Me.MainMenu1
    Me.Name = "Form1"
    Me.Text = "Form1"
    CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)

  End Sub

#End Region

  Private Sub Form1_Load(ByVal sender As System.Object, _
  ByVal e As System.EventArgs) Handles MyBase.Load

  End Sub

  Private Sub ListProperty_Click(ByVal sender As System.Object, _
  ByVal e As System.EventArgs) Handles ListProperty.Click


  End Sub

  Private Sub BindControlsMenu_Click(ByVal sender As System.Object, _
  ByVal e As System.EventArgs) Handles BindControlsMenu.Click

    Dim ConnectionString As String = "Integrated Security=SSPI;" & _
    "Initial Catalog=Northwind;Data Source=MCB;"
    Dim conn As SqlConnection = Nothing
    Dim sql As String = "SELECT * FROM Customers"
    Dim adapter As SqlDataAdapter = Nothing
    Dim ds As DataSet = Nothing
    Dim dv As DataView
    conn = New SqlConnection(ConnectionString)
    adapter = New SqlDataAdapter(sql, conn)
    ds = New DataSet()
    adapter.Fill(ds)
    dv = New DataView(ds.Tables("Customers"))
    DataGrid1.DataSource = dv
    Dim curManager1 As CurrencyManager = DataGrid1.BindingContext(dv)
    curManager = curManager1
    MessageBox.Show(curManager1.Count.ToString())
    Dim list As IList = curManager1.List
    Dim dv1 As DataView = CType(curManager1.List, DataView)
    dv.AllowNew = False
    ' Get Form's BindingContext
    Dim ds1 As DataSet = New DataSet()
    sql = "SELECT * FROM Customers"
    Dim adapter1 As SqlDataAdapter = New SqlDataAdapter(sql, conn)
    adapter.Fill(ds1, "Customers")
    Dim curManager2 As CurrencyManager = Me.BindingContext(ds1)
    ' curManager2.AddNew()

    Dim table As DataTable = ds.Tables(0)
    ' Bind a TextBox control to a DataTable column in a DataSet.
    Dim curManager3 = CType(Me.BindingContext(table), CurrencyManager)
    ' Set the initial Position of the control.

    dsCustomers = New DataSet()
    Dim da1 As SqlDataAdapter = New SqlDataAdapter( _
    "SELECT * FROM Customers", conn)
    da1.Fill(dsCustomers)

    dsOrders = New DataSet()
    Dim da2 As SqlDataAdapter = New SqlDataAdapter( _
    "SELECT * FROM Orders", conn)
    da1.Fill(dsOrders)

    conn.Close()
    conn.Dispose()

  End Sub

  Private Sub GetBindingManagerBases()
    Dim cmOrders As BindingManagerBase
    Dim cmProducts As BindingManagerBase
    ' Get the BindingManagerBase objects for each data source.
    cmOrders = Me.BindingContext(dsOrders, "Orders")
    cmProducts = Me.BindingContext(dsCustomers, "Customers")
  End Sub

  Private Sub GetBindingManagerBase()
    Dim BMB As BindingManagerBase
    BMB = Me.BindingContext(ds.Tables("Customers"))
  End Sub


  Private Sub CustomRecordset_Click(ByVal sender As System.Object, _
  ByVal e As System.EventArgs) Handles CustomRecordset.Click
    Dim ConnectionString As String = "Integrated Security=SSPI;" & _
    "Initial Catalog=Northwind;Data Source=MCB;"
    Dim conn As SqlConnection = Nothing
    Dim sql As String = "SELECT * FROM Customers"
    Dim adapter As SqlDataAdapter = Nothing
    conn = New SqlConnection(ConnectionString)
    adapter = New SqlDataAdapter(sql, conn)
    ds = New DataSet()
    adapter.Fill(ds)
    DataGrid1.DataSource = ds.Tables(0)
  End Sub



  Private Sub MoveFirstBtn_Click(ByVal sender As System.Object, _
  ByVal e As System.EventArgs) Handles MoveFirstBtn.Click
    Dim recSet As CustomRecordset = New CustomRecordset()
    recSet.MoveFirstRecord(Me)
  End Sub

  Private Sub MovePrevBtn_Click(ByVal sender As System.Object, _
  ByVal e As System.EventArgs) Handles MovePrevBtn.Click
    Dim recSet As CustomRecordset = New CustomRecordset()
    recSet.MovePrevRecord(Me)
  End Sub

  Private Sub MoveNextBtn_Click(ByVal sender As System.Object, _
  ByVal e As System.EventArgs) Handles MoveNextBtn.Click
    Dim recSet As CustomRecordset = New CustomRecordset()
    recSet.MoveNextRecord(Me)
  End Sub

  Private Sub MoveLastBtn_Click(ByVal sender As System.Object, _
  ByVal e As System.EventArgs) Handles MoveLastBtn.Click
    Me.BindingContext(Me.ds, "Customers").Position = _
    Me.BindingContext(Me.ds, "Customers").Count - 1
  End Sub
End Class
