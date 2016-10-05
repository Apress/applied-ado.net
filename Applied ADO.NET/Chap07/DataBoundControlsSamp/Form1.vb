Imports System.Data.SqlClient
Imports System.Globalization


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
  Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
  Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
  Friend WithEvents LoadBtn As System.Windows.Forms.Button
  Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents Label3 As System.Windows.Forms.Label
  Friend WithEvents MoveFirstBtn As System.Windows.Forms.Button
  Friend WithEvents MovePrevBtn As System.Windows.Forms.Button
  Friend WithEvents MoveNextBtn As System.Windows.Forms.Button
  Friend WithEvents MoveLastBtn As System.Windows.Forms.Button
  Friend WithEvents Label4 As System.Windows.Forms.Label
  Friend WithEvents Button1 As System.Windows.Forms.Button
  Friend WithEvents Label5 As System.Windows.Forms.Label
  Friend WithEvents Label6 As System.Windows.Forms.Label
  Friend WithEvents Button2 As System.Windows.Forms.Button
  Friend WithEvents RemoveBtn As System.Windows.Forms.Button
  Friend WithEvents BindingManagerBaseBtn As System.Windows.Forms.Button
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.TextBox1 = New System.Windows.Forms.TextBox()
    Me.ListBox1 = New System.Windows.Forms.ListBox()
    Me.ComboBox1 = New System.Windows.Forms.ComboBox()
    Me.LoadBtn = New System.Windows.Forms.Button()
    Me.TextBox2 = New System.Windows.Forms.TextBox()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.Label3 = New System.Windows.Forms.Label()
    Me.MoveFirstBtn = New System.Windows.Forms.Button()
    Me.MovePrevBtn = New System.Windows.Forms.Button()
    Me.MoveNextBtn = New System.Windows.Forms.Button()
    Me.MoveLastBtn = New System.Windows.Forms.Button()
    Me.Label4 = New System.Windows.Forms.Label()
    Me.Button1 = New System.Windows.Forms.Button()
    Me.Label5 = New System.Windows.Forms.Label()
    Me.Label6 = New System.Windows.Forms.Label()
    Me.Button2 = New System.Windows.Forms.Button()
    Me.RemoveBtn = New System.Windows.Forms.Button()
    Me.BindingManagerBaseBtn = New System.Windows.Forms.Button()
    Me.SuspendLayout()
    '
    'TextBox1
    '
    Me.TextBox1.Location = New System.Drawing.Point(104, 136)
    Me.TextBox1.Name = "TextBox1"
    Me.TextBox1.Size = New System.Drawing.Size(160, 20)
    Me.TextBox1.TabIndex = 0
    Me.TextBox1.Text = ""
    '
    'ListBox1
    '
    Me.ListBox1.Location = New System.Drawing.Point(8, 176)
    Me.ListBox1.Name = "ListBox1"
    Me.ListBox1.Size = New System.Drawing.Size(176, 121)
    Me.ListBox1.TabIndex = 1
    '
    'ComboBox1
    '
    Me.ComboBox1.Location = New System.Drawing.Point(16, 136)
    Me.ComboBox1.Name = "ComboBox1"
    Me.ComboBox1.Size = New System.Drawing.Size(80, 21)
    Me.ComboBox1.TabIndex = 2
    '
    'LoadBtn
    '
    Me.LoadBtn.Location = New System.Drawing.Point(8, 8)
    Me.LoadBtn.Name = "LoadBtn"
    Me.LoadBtn.Size = New System.Drawing.Size(112, 24)
    Me.LoadBtn.TabIndex = 4
    Me.LoadBtn.Text = "Load Data"
    '
    'TextBox2
    '
    Me.TextBox2.Location = New System.Drawing.Point(280, 136)
    Me.TextBox2.Name = "TextBox2"
    Me.TextBox2.Size = New System.Drawing.Size(160, 20)
    Me.TextBox2.TabIndex = 5
    Me.TextBox2.Text = ""
    '
    'Label1
    '
    Me.Label1.Location = New System.Drawing.Point(16, 112)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(80, 16)
    Me.Label1.TabIndex = 6
    Me.Label1.Text = "Employee ID:"
    '
    'Label2
    '
    Me.Label2.Location = New System.Drawing.Point(112, 112)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(160, 16)
    Me.Label2.TabIndex = 7
    Me.Label2.Text = "First Name:"
    '
    'Label3
    '
    Me.Label3.Location = New System.Drawing.Point(288, 112)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(100, 16)
    Me.Label3.TabIndex = 8
    Me.Label3.Text = "Last Name:"
    '
    'MoveFirstBtn
    '
    Me.MoveFirstBtn.Location = New System.Drawing.Point(24, 304)
    Me.MoveFirstBtn.Name = "MoveFirstBtn"
    Me.MoveFirstBtn.Size = New System.Drawing.Size(40, 24)
    Me.MoveFirstBtn.TabIndex = 9
    Me.MoveFirstBtn.Text = "<<"
    '
    'MovePrevBtn
    '
    Me.MovePrevBtn.Location = New System.Drawing.Point(72, 304)
    Me.MovePrevBtn.Name = "MovePrevBtn"
    Me.MovePrevBtn.Size = New System.Drawing.Size(40, 24)
    Me.MovePrevBtn.TabIndex = 10
    Me.MovePrevBtn.Text = "<"
    '
    'MoveNextBtn
    '
    Me.MoveNextBtn.Location = New System.Drawing.Point(336, 304)
    Me.MoveNextBtn.Name = "MoveNextBtn"
    Me.MoveNextBtn.Size = New System.Drawing.Size(48, 24)
    Me.MoveNextBtn.TabIndex = 11
    Me.MoveNextBtn.Text = ">"
    '
    'MoveLastBtn
    '
    Me.MoveLastBtn.Location = New System.Drawing.Point(392, 304)
    Me.MoveLastBtn.Name = "MoveLastBtn"
    Me.MoveLastBtn.Size = New System.Drawing.Size(48, 24)
    Me.MoveLastBtn.TabIndex = 12
    Me.MoveLastBtn.Text = ">>"
    '
    'Label4
    '
    Me.Label4.Location = New System.Drawing.Point(280, 184)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(120, 24)
    Me.Label4.TabIndex = 13
    Me.Label4.Text = "Label4"
    '
    'Button1
    '
    Me.Button1.Location = New System.Drawing.Point(208, 248)
    Me.Button1.Name = "Button1"
    Me.Button1.Size = New System.Drawing.Size(152, 32)
    Me.Button1.TabIndex = 14
    Me.Button1.Text = "Button1"
    '
    'Label5
    '
    Me.Label5.Location = New System.Drawing.Point(208, 184)
    Me.Label5.Name = "Label5"
    Me.Label5.Size = New System.Drawing.Size(64, 24)
    Me.Label5.TabIndex = 15
    Me.Label5.Text = "City:"
    '
    'Label6
    '
    Me.Label6.Location = New System.Drawing.Point(208, 224)
    Me.Label6.Name = "Label6"
    Me.Label6.TabIndex = 16
    Me.Label6.Text = "Country:"
    '
    'Button2
    '
    Me.Button2.Location = New System.Drawing.Point(128, 8)
    Me.Button2.Name = "Button2"
    Me.Button2.Size = New System.Drawing.Size(152, 24)
    Me.Button2.TabIndex = 17
    Me.Button2.Text = "ReadBindingMember Info"
    '
    'RemoveBtn
    '
    Me.RemoveBtn.Location = New System.Drawing.Point(296, 8)
    Me.RemoveBtn.Name = "RemoveBtn"
    Me.RemoveBtn.Size = New System.Drawing.Size(72, 24)
    Me.RemoveBtn.TabIndex = 18
    Me.RemoveBtn.Text = "Remove"
    '
    'BindingManagerBaseBtn
    '
    Me.BindingManagerBaseBtn.Location = New System.Drawing.Point(8, 40)
    Me.BindingManagerBaseBtn.Name = "BindingManagerBaseBtn"
    Me.BindingManagerBaseBtn.Size = New System.Drawing.Size(152, 24)
    Me.BindingManagerBaseBtn.TabIndex = 19
    Me.BindingManagerBaseBtn.Text = "BindingManagerBase"
    '
    'Form1
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(464, 341)
    Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.BindingManagerBaseBtn, Me.RemoveBtn, Me.Button2, Me.Label6, Me.Label5, Me.Button1, Me.Label4, Me.MoveLastBtn, Me.MoveNextBtn, Me.MovePrevBtn, Me.MoveFirstBtn, Me.Label3, Me.Label2, Me.Label1, Me.TextBox2, Me.LoadBtn, Me.ComboBox1, Me.ListBox1, Me.TextBox1})
    Me.Name = "Form1"
    Me.Text = "Simple Data Binding Application"
    Me.ResumeLayout(False)

  End Sub

#End Region

  Private Sub LoadBtn_Click(ByVal sender As System.Object, _
  ByVal e As System.EventArgs) Handles LoadBtn.Click
    LoadData()
  End Sub

  Private Sub LoadData()
    Dim ds As DataSet = New DataSet()
    ds = GetDataSet("Employees")
    Dim bind1 As Binding
    bind1 = New Binding("Text", ds, "Employees.FirstName")
    TextBox1.DataBindings.Add(bind1)
    TextBox2.DataBindings.Add _
 (New Binding("Text", ds, "Employees.LastName"))
    ComboBox1.DataBindings.Add _
   (New Binding("Text", ds, "Employees.EmployeeID"))
    Label4.DataBindings.Add(New Binding("Text", ds, "Employees.City"))
    Button1.DataBindings.Add(New Binding("Text", ds, "Employees.Country"))
    ListBox1.DataSource = ds.Tables(0).DefaultView
    ListBox1.DisplayMember = "Title"

    ' Get a DataSet with Customers Table
    'Dim bind2 As Binding = New Binding _
    '("Text", ds, "customers.custToOrders.OrderAmount")
    ' AddHandler bind1.Format, AddressOf DecimalToCurrencyString
    ' AddHandler bind1.Parse, AddressOf CurrencyStringToDecimal
  End Sub

  Private Sub DecimalToCurrencyString(ByVal sender As Object, _
  ByVal cevent As ConvertEventArgs)
    If Not cevent.DesiredType Is GetType(String) Then
      Exit Sub
    End If
    cevent.Value = CType(cevent.Value, Decimal).ToString("c")
  End Sub

  Private Sub CurrencyStringToDecimal(ByVal sender As Object, _
  ByVal cevent As ConvertEventArgs)
    If Not cevent.DesiredType Is GetType(Decimal) Then
      Exit Sub
    End If
    cevent.Value = Decimal.Parse(cevent.Value.ToString, _
    NumberStyles.Currency, Nothing)
  End Sub

  Private Sub Button2_Click(ByVal sender As System.Object, _
  ByVal e As System.EventArgs) Handles Button2.Click
    Dim str As String
    Dim curControl As Control
    Dim curBinding As Binding
    For Each curControl In Me.Controls
      For Each curBinding In curControl.DataBindings
        Dim bInfo As BindingMemberInfo = _
curBinding.BindingMemberInfo
        str = "Control: " + curControl.Name
        str += ", BindingPath: " + bInfo.BindingPath
        str += ", BindingField: " + bInfo.BindingField
        str += ", BindingMember: " + bInfo.BindingMember
        MessageBox.Show(str)
      Next curBinding
    Next curControl

    If (TextBox1.DataBindings(0).IsBinding) Then
      Dim ds As DataSet = _
      CType(TextBox1.DataBindings(0).DataSource, DataSet)
      str = "DataSource : " + ds.Tables(0).TableName
      str += ", Property Name: " + _
      TextBox1.DataBindings(0).PropertyName
      MessageBox.Show(str)
    End If
  End Sub


  ' object based on various parameters.
  Public Function GetDataSet(ByVal tableName As String) As DataSet
    sql = "SELECT * FROM " + tableName
    ds = New DataSet(tableName)
    conn = New SqlConnection()
    conn.ConnectionString = ConnectionString
    adapter = New SqlDataAdapter(sql, conn)
    adapter.Fill(ds, tableName)
    Return ds
  End Function

  Private Sub MoveFirstBtn_Click(ByVal sender As System.Object, _
  ByVal e As System.EventArgs) Handles MoveFirstBtn.Click
    Me.BindingContext(Me.ds, "Employees").Position = 0
  End Sub

  Private Sub MovePrevBtn_Click(ByVal sender As System.Object, _
  ByVal e As System.EventArgs) Handles MovePrevBtn.Click
    Dim idx As Int32 = _
       Me.BindingContext(Me.ds, "Employees").Position
    Me.BindingContext(Me.ds, "Employees").Position = idx - 1
  End Sub

  Private Sub MoveNextBtn_Click(ByVal sender As System.Object, _
  ByVal e As System.EventArgs) Handles MoveNextBtn.Click
    Dim idx As Int32 = _
       Me.BindingContext(Me.ds, "Employees").Position
    Me.BindingContext(Me.ds, "Employees").Position = idx + 1
  End Sub

  Private Sub MoveLastBtn_Click(ByVal sender As System.Object, _
  ByVal e As System.EventArgs) Handles MoveLastBtn.Click
    Me.BindingContext(Me.ds, "Employees").Position = _
    Me.BindingContext(Me.ds, "Employees").Count - 1
  End Sub

  Private Sub RemoveBtn_Click(ByVal sender As System.Object, _
  ByVal e As System.EventArgs) Handles RemoveBtn.Click
    MessageBox.Show("Total Bindings: " + _
    Button1.DataBindings.Count.ToString())
    TextBox1.DataBindings.RemoveAt(0)
    TextBox2.DataBindings.Clear()
  End Sub


  Private Sub BindingManagerBaseBtn_Click(ByVal sender As System.Object, _
  ByVal e As System.EventArgs) Handles BindingManagerBaseBtn.Click
    ' Get the BindingManagerBase
    Dim bindingBase As BindingManagerBase = _
       Me.BindingContext(ds, "Employees")
    Dim bindingObj As Binding
    ' Read each Binding object from the collection
    For Each bindingObj In bindingBase.Bindings
      MessageBox.Show(bindingObj.Control.Name)
    Next bindingObj
  End Sub

 
End Class
