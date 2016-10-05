Imports System.Data.SqlClient

Public Class Form1
  Inherits System.Windows.Forms.Form

  ' Create a Connection Object
  Private ConnectionString As String = "Integrated Security=SSPI;" & _
       "Initial Catalog=Northwind;Data Source=MCB;"
  Private SQL As String

  Dim dtSet As DataSet
  Dim dtRelation As DataRelation

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
  Friend WithEvents DataGrid1 As System.Windows.Forms.DataGrid
  Friend WithEvents MainMenu1 As System.Windows.Forms.MainMenu
  Friend WithEvents MenuItem1 As System.Windows.Forms.MenuItem
  Friend WithEvents CreateRelations As System.Windows.Forms.MenuItem
  Friend WithEvents Properties As System.Windows.Forms.MenuItem
  Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
  Friend WithEvents DataRelCollection As System.Windows.Forms.MenuItem
  Friend WithEvents RemoveRelation As System.Windows.Forms.MenuItem
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.DataGrid1 = New System.Windows.Forms.DataGrid()
    Me.MainMenu1 = New System.Windows.Forms.MainMenu()
    Me.MenuItem1 = New System.Windows.Forms.MenuItem()
    Me.CreateRelations = New System.Windows.Forms.MenuItem()
    Me.Properties = New System.Windows.Forms.MenuItem()
    Me.ListBox1 = New System.Windows.Forms.ListBox()
    Me.DataRelCollection = New System.Windows.Forms.MenuItem()
    Me.RemoveRelation = New System.Windows.Forms.MenuItem()
    CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'DataGrid1
    '
    Me.DataGrid1.DataMember = ""
    Me.DataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText
    Me.DataGrid1.Location = New System.Drawing.Point(160, 40)
    Me.DataGrid1.Name = "DataGrid1"
    Me.DataGrid1.Size = New System.Drawing.Size(264, 232)
    Me.DataGrid1.TabIndex = 0
    '
    'MainMenu1
    '
    Me.MainMenu1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem1})
    '
    'MenuItem1
    '
    Me.MenuItem1.Index = 0
    Me.MenuItem1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.CreateRelations, Me.Properties, Me.DataRelCollection, Me.RemoveRelation})
    Me.MenuItem1.Text = "Data Relations"
    '
    'CreateRelations
    '
    Me.CreateRelations.Index = 0
    Me.CreateRelations.Text = "Create"
    '
    'Properties
    '
    Me.Properties.Index = 1
    Me.Properties.Text = "Properties"
    '
    'ListBox1
    '
    Me.ListBox1.Location = New System.Drawing.Point(8, 40)
    Me.ListBox1.Name = "ListBox1"
    Me.ListBox1.Size = New System.Drawing.Size(144, 212)
    Me.ListBox1.TabIndex = 1
    '
    'DataRelCollection
    '
    Me.DataRelCollection.Index = 2
    Me.DataRelCollection.Text = "DataRelationCollection"
    '
    'RemoveRelation
    '
    Me.RemoveRelation.Index = 3
    Me.RemoveRelation.Text = "Remove Relation"
    '
    'Form1
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(432, 273)
    Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.ListBox1, Me.DataGrid1})
    Me.Menu = Me.MainMenu1
    Me.Name = "Form1"
    Me.Text = "Form1"
    CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)

  End Sub

#End Region

  Private Sub Form1_Load(ByVal sender As System.Object, _
  ByVal e As System.EventArgs) Handles MyBase.Load
    dtSet = New DataSet()

  End Sub

  Private Sub CreateRelations_Click(ByVal sender As System.Object, _
  ByVal e As System.EventArgs) Handles CreateRelations.Click
    ' Create a Connection Object
    Dim conn As SqlConnection = New SqlConnection(ConnectionString)
    SQL = "SELECT * FROM Customers"
    conn.Open()
    Dim adapter As SqlDataAdapter = New SqlDataAdapter(SQL, conn)
    Dim ds1 As DataSet = New DataSet("Customers")
    adapter.Fill(ds1, "Customers")
    SQL = "SELECT * FROM Orders"
    adapter = New SqlDataAdapter(SQL, conn)
    Dim ds2 As DataSet = New DataSet("Orders")
    adapter.Fill(ds2, "Orders")
    ds1.Merge(ds2)
    dtSet = ds1
    ' Get the DataColumn objects from Customers
    ' and Orders tables of a DataSet
    Dim parentCol As DataColumn = New DataColumn()
    Dim childCol As DataColumn = New DataColumn()
    'Retrieve columns from a DataSet
    parentCol = ds1.Tables("Customers").Columns("CustomerID")
    childCol = ds1.Tables("Orders").Columns("CustomerID")
    Dim bConstraints As Boolean
    bConstraints = True
    ' Create a DataRelation.
    Dim CustOrderRelation As DataRelation = _
    New DataRelation("CustOrdersRelation", parentCol, childCol, bConstraints)
    dtRelation = CustOrderRelation
    ' Add the relation to the DataSet.
    ds1.Relations.Add(CustOrderRelation)

    DataGrid1.DataSource = ds1.DefaultViewManager
    ' release objects
      conn.Close()
    conn.Dispose()
  End Sub

  Private Sub Properties_Click(ByVal sender As System.Object, _
  ByVal e As System.EventArgs) Handles Properties.Click
    ' Getting a DataRelation properties
    Dim dtSet As DataSet = dtRelation.DataSet
    ' Getting Tables
    Dim pTable As DataTable = dtRelation.ParentTable
    Dim chTable As DataTable = dtRelation.ChildTable
    ListBox1.Items.Add("Parent Table: " + pTable.TableName)
    ListBox1.Items.Add("Child Table: " + chTable.TableName)
    'Getting columns
    Dim parentCols() As DataColumn
    Dim childCols() As DataColumn
    parentCols = dtRelation.ParentColumns
    childCols = dtRelation.ChildColumns
    ' Print the ColumnName of each column.
    Dim i As Integer
    ListBox1.Items.Add("Parent Columns:")
    For i = 0 To parentCols.GetUpperBound(0)
      ListBox1.Items.Add(parentCols(i).ColumnName)
    Next i
    ListBox1.Items.Add("Child Columns:")
    For i = 0 To childCols.GetUpperBound(0)
      ListBox1.Items.Add(childCols(i).ColumnName)
    Next i
    ' Data relation name
    ListBox1.Items.Add("DataRelation Name:" + dtRelation.RelationName)

  End Sub

  Private Sub DataRelCollection_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DataRelCollection.Click

  End Sub

  Private Sub RemoveRelation_Click(ByVal sender As System.Object, _
  ByVal e As System.EventArgs) Handles RemoveRelation.Click
    Dim dtRelCollection As DataRelationCollection = dtSet.Relations
    If (dtRelCollection.Contains("CustOrdersRelation")) Then
      If (dtRelCollection.CanRemove(dtRelation)) Then
        dtRelCollection.Remove(dtRelation)
      End If
    End If
  End Sub
End Class
