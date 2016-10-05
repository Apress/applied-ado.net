Imports System.Data.SqlClient

Public Class Form1
  Inherits System.Windows.Forms.Form

  Private ConnectionString As String = "Integrated Security=SSPI;" & _
  "Initial Catalog=Northwind;Data Source=MCB;"
  Private conn As SqlConnection = Nothing
  Private sql As String = Nothing
  Private adapter As SqlDataAdapter = Nothing
  Private ds As DataSet = Nothing


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
  Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
  Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
  Friend WithEvents MainMenu1 As System.Windows.Forms.MainMenu
  Friend WithEvents MenuItem1 As System.Windows.Forms.MenuItem
  Friend WithEvents ListChangedEvents As System.Windows.Forms.MenuItem
  Friend WithEvents MenuItem2 As System.Windows.Forms.MenuItem
  Friend WithEvents ComboChangedEvents As System.Windows.Forms.MenuItem
  Friend WithEvents ListBox2 As System.Windows.Forms.ListBox
  Friend WithEvents ListBox3 As System.Windows.Forms.ListBox
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents Label3 As System.Windows.Forms.Label
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.ListBox1 = New System.Windows.Forms.ListBox()
    Me.ComboBox1 = New System.Windows.Forms.ComboBox()
    Me.MainMenu1 = New System.Windows.Forms.MainMenu()
    Me.MenuItem1 = New System.Windows.Forms.MenuItem()
    Me.ListChangedEvents = New System.Windows.Forms.MenuItem()
    Me.MenuItem2 = New System.Windows.Forms.MenuItem()
    Me.ComboChangedEvents = New System.Windows.Forms.MenuItem()
    Me.ListBox2 = New System.Windows.Forms.ListBox()
    Me.ListBox3 = New System.Windows.Forms.ListBox()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.Label3 = New System.Windows.Forms.Label()
    Me.SuspendLayout()
    '
    'ListBox1
    '
    Me.ListBox1.Location = New System.Drawing.Point(8, 72)
    Me.ListBox1.Name = "ListBox1"
    Me.ListBox1.Size = New System.Drawing.Size(96, 173)
    Me.ListBox1.TabIndex = 1
    '
    'ComboBox1
    '
    Me.ComboBox1.Location = New System.Drawing.Point(8, 8)
    Me.ComboBox1.Name = "ComboBox1"
    Me.ComboBox1.Size = New System.Drawing.Size(208, 21)
    Me.ComboBox1.TabIndex = 2
    Me.ComboBox1.Text = "ComboBox1"
    '
    'MainMenu1
    '
    Me.MainMenu1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem1, Me.MenuItem2})
    '
    'MenuItem1
    '
    Me.MenuItem1.Index = 0
    Me.MenuItem1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.ListChangedEvents})
    Me.MenuItem1.Text = "ListBox"
    '
    'ListChangedEvents
    '
    Me.ListChangedEvents.Index = 0
    Me.ListChangedEvents.Text = "Changed Events"
    '
    'MenuItem2
    '
    Me.MenuItem2.Index = 1
    Me.MenuItem2.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.ComboChangedEvents})
    Me.MenuItem2.Text = "ComboBox"
    '
    'ComboChangedEvents
    '
    Me.ComboChangedEvents.Index = 0
    Me.ComboChangedEvents.Text = "Changed Events"
    '
    'ListBox2
    '
    Me.ListBox2.Location = New System.Drawing.Point(104, 72)
    Me.ListBox2.Name = "ListBox2"
    Me.ListBox2.Size = New System.Drawing.Size(104, 173)
    Me.ListBox2.TabIndex = 3
    '
    'ListBox3
    '
    Me.ListBox3.Location = New System.Drawing.Point(208, 72)
    Me.ListBox3.Name = "ListBox3"
    Me.ListBox3.Size = New System.Drawing.Size(160, 173)
    Me.ListBox3.TabIndex = 4
    '
    'Label1
    '
    Me.Label1.Location = New System.Drawing.Point(8, 48)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(96, 16)
    Me.Label1.TabIndex = 5
    Me.Label1.Text = "First Name"
    '
    'Label2
    '
    Me.Label2.Location = New System.Drawing.Point(112, 48)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(80, 23)
    Me.Label2.TabIndex = 6
    Me.Label2.Text = "Last Name"
    '
    'Label3
    '
    Me.Label3.Location = New System.Drawing.Point(216, 48)
    Me.Label3.Name = "Label3"
    Me.Label3.TabIndex = 7
    Me.Label3.Text = "Title"
    '
    'Form1
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(376, 249)
    Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label3, Me.Label2, Me.Label1, Me.ListBox3, Me.ListBox2, Me.ComboBox1, Me.ListBox1})
    Me.Menu = Me.MainMenu1
    Me.Name = "Form1"
    Me.Text = "ListBox and ComboBox Data Binding"
    Me.ResumeLayout(False)

  End Sub

#End Region

  Private Sub Form1_Load(ByVal sender As System.Object, _
  ByVal e As System.EventArgs) Handles MyBase.Load
    FillDataSet()
    BindListControls()
  End Sub

  ' Fill DataSEt
  Private Sub FillDataSet()
    ds = New DataSet()
    sql = "SELECT * FROM Employees"
    ds = New DataSet("Employees")
    conn = New SqlConnection()
    conn.ConnectionString = ConnectionString
    adapter = New SqlDataAdapter(sql, conn)
    adapter.Fill(ds, "Employees")
    conn.Close()
    conn.Dispose()
  End Sub
  ' Bind data with controls
  Private Sub BindListControls()
    ComboBox1.DataSource = ds.Tables(0)
    ComboBox1.DisplayMember = "EmployeeID"
    ListBox1.DataSource = ds.Tables(0)
    ListBox1.DisplayMember = "FirstName"
    ListBox2.DataSource = ds.Tables(0)
    ListBox2.DisplayMember = "LastName"
    ListBox3.DataSource = ds.Tables(0)
    ListBox3.DisplayMember = "Title"
  End Sub

  Private Sub ComboDataSourceChangedMethod(ByVal sender As Object, _
  ByVal cevent As EventArgs) Handles ListBox1.DataSourceChanged
    MessageBox.Show("Data Source changed")
  End Sub
  Private Sub DisplayMemberChangedMethod(ByVal sender As Object, _
  ByVal cevent As EventArgs) Handles ListBox1.DisplayMemberChanged
    MessageBox.Show("Display Member changed")
  End Sub
  Private Sub ValueMemberChangedMethod(ByVal sender As Object, _
  ByVal cevent As EventArgs) Handles ListBox1.ValueMemberChanged
    MessageBox.Show("Value Member changed")
  End Sub
  Private Sub BindingContextChangedMethod(ByVal sender As Object, _
  ByVal cevent As EventArgs) Handles ListBox1.BindingContextChanged
    MessageBox.Show("Binding Context changed")
  End Sub

  Private Sub ListChangedEvents_Click(ByVal sender As System.Object, _
  ByVal e As System.EventArgs) Handles ListChangedEvents.Click
    Dim custDataSet As DataSet = New DataSet()
    sql = "SELECT CustomerID, ContactName, City FROM Customers"
    custDataSet = New DataSet("Customers")
    conn = New SqlConnection()
    conn.ConnectionString = ConnectionString
    adapter = New SqlDataAdapter(sql, conn)
    adapter.Fill(custDataSet, "Customers")
    ListBox1.DataSource = custDataSet.Tables(0)
    ListBox1.DisplayMember = "ContactName"
    ListBox1.ValueMember = "ContactName"
    conn.Close()
    conn.Dispose()
  End Sub

  Private Sub ComboChangedEvents_Click(ByVal sender As System.Object, _
  ByVal e As System.EventArgs) Handles ComboChangedEvents.Click

  End Sub
End Class
