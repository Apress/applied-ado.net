Imports System.Data
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
  Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
  Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
  Friend WithEvents Button1 As System.Windows.Forms.Button
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
  Friend WithEvents Button2 As System.Windows.Forms.Button
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.TextBox1 = New System.Windows.Forms.TextBox()
    Me.ComboBox1 = New System.Windows.Forms.ComboBox()
    Me.Button1 = New System.Windows.Forms.Button()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.ListBox1 = New System.Windows.Forms.ListBox()
    Me.Button2 = New System.Windows.Forms.Button()
    Me.SuspendLayout()
    '
    'TextBox1
    '
    Me.TextBox1.Location = New System.Drawing.Point(24, 48)
    Me.TextBox1.Name = "TextBox1"
    Me.TextBox1.Size = New System.Drawing.Size(144, 20)
    Me.TextBox1.TabIndex = 0
    Me.TextBox1.Text = "TextBox1"
    '
    'ComboBox1
    '
    Me.ComboBox1.Location = New System.Drawing.Point(200, 48)
    Me.ComboBox1.Name = "ComboBox1"
    Me.ComboBox1.Size = New System.Drawing.Size(112, 21)
    Me.ComboBox1.TabIndex = 2
    Me.ComboBox1.Text = "ComboBox1"
    '
    'Button1
    '
    Me.Button1.Location = New System.Drawing.Point(24, 16)
    Me.Button1.Name = "Button1"
    Me.Button1.Size = New System.Drawing.Size(136, 24)
    Me.Button1.TabIndex = 3
    Me.Button1.Text = "Button1"
    '
    'Label1
    '
    Me.Label1.Location = New System.Drawing.Point(24, 104)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(144, 24)
    Me.Label1.TabIndex = 4
    Me.Label1.Text = "Label1"
    '
    'ListBox1
    '
    Me.ListBox1.Location = New System.Drawing.Point(24, 144)
    Me.ListBox1.Name = "ListBox1"
    Me.ListBox1.Size = New System.Drawing.Size(144, 95)
    Me.ListBox1.TabIndex = 5
    '
    'Button2
    '
    Me.Button2.Location = New System.Drawing.Point(200, 160)
    Me.Button2.Name = "Button2"
    Me.Button2.Size = New System.Drawing.Size(104, 32)
    Me.Button2.TabIndex = 6
    Me.Button2.Text = "Save Changes"
    '
    'Form1
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(320, 273)
    Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.Button2, Me.ListBox1, Me.Label1, Me.Button1, Me.ComboBox1, Me.TextBox1})
    Me.Name = "Form1"
    Me.Text = "Form1"
    Me.ResumeLayout(False)

  End Sub

#End Region

  Private Sub Form1_Load(ByVal sender As System.Object, _
  ByVal e As System.EventArgs) Handles MyBase.Load

    Dim ds As DataSet = New DataSet()
    sql = "SELECT * FROM Employees"
    ds = New DataSet("Employees")
    conn = New SqlConnection(ConnectionString)
    conn.Open()

    adapter = New SqlDataAdapter(sql, conn)
    adapter.Fill(ds, "Employees")
    Dim bind1 As Binding
    bind1 = New Binding("Text", ds, "Employees.FirstName")
    TextBox1.DataBindings.Add(bind1)
    ComboBox1.DataBindings.Add _
 (New Binding("Text", ds, "Employees.EmployeeID"))
    Label1.DataBindings.Add(New Binding("Text", ds, "Employees.City"))
    Button1.DataBindings.Add(New Binding("Text", ds, "Employees.Country"))
    ListBox1.DataSource = ds.Tables(0).DefaultView
    ListBox1.DisplayMember = "Title"

    conn.Close()
    conn.Dispose()
  End Sub
  
End Class
