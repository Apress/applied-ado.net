Imports ADODB
Imports ADOMD

Public Class Form1
  Inherits System.Windows.Forms.Form

  Private strConn As String
  Private dbConn As Connection
  Private dtCatalog As Catalog
  Private cubes As CubeDefs

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
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
  Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
  Friend WithEvents ListBox2 As System.Windows.Forms.ListBox
  Friend WithEvents Button1 As System.Windows.Forms.Button
  Friend WithEvents Button2 As System.Windows.Forms.Button
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.TextBox1 = New System.Windows.Forms.TextBox()
    Me.ListBox1 = New System.Windows.Forms.ListBox()
    Me.ListBox2 = New System.Windows.Forms.ListBox()
    Me.Button1 = New System.Windows.Forms.Button()
    Me.Button2 = New System.Windows.Forms.Button()
    Me.SuspendLayout()
    '
    'Label1
    '
    Me.Label1.Location = New System.Drawing.Point(8, 16)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(96, 24)
    Me.Label1.TabIndex = 0
    Me.Label1.Text = "Number of Cubes"
    '
    'TextBox1
    '
    Me.TextBox1.Location = New System.Drawing.Point(120, 16)
    Me.TextBox1.Name = "TextBox1"
    Me.TextBox1.Size = New System.Drawing.Size(80, 20)
    Me.TextBox1.TabIndex = 1
    Me.TextBox1.Text = "TextBox1"
    '
    'ListBox1
    '
    Me.ListBox1.Location = New System.Drawing.Point(16, 104)
    Me.ListBox1.Name = "ListBox1"
    Me.ListBox1.Size = New System.Drawing.Size(160, 199)
    Me.ListBox1.TabIndex = 2
    '
    'ListBox2
    '
    Me.ListBox2.Location = New System.Drawing.Point(192, 104)
    Me.ListBox2.Name = "ListBox2"
    Me.ListBox2.Size = New System.Drawing.Size(168, 199)
    Me.ListBox2.TabIndex = 3
    '
    'Button1
    '
    Me.Button1.Location = New System.Drawing.Point(16, 64)
    Me.Button1.Name = "Button1"
    Me.Button1.Size = New System.Drawing.Size(144, 32)
    Me.Button1.TabIndex = 4
    Me.Button1.Text = "Get Dimensions"
    '
    'Button2
    '
    Me.Button2.Location = New System.Drawing.Point(192, 64)
    Me.Button2.Name = "Button2"
    Me.Button2.Size = New System.Drawing.Size(144, 32)
    Me.Button2.TabIndex = 5
    Me.Button2.Text = "Get Dimension Members"
    '
    'Form1
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(368, 317)
    Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.Button2, Me.Button1, Me.ListBox2, Me.ListBox1, Me.TextBox1, Me.Label1})
    Me.Name = "Form1"
    Me.Text = "Form1"
    Me.ResumeLayout(False)

  End Sub

#End Region

  Private Sub Button1_Click(ByVal sender As System.Object, _
  ByVal e As System.EventArgs) Handles Button1.Click
    ' Get the selected cube
    Dim cube As CubeDef = cubes(ListBox1.SelectedItem.ToString())
    ' Get all the dimensions of the selecte cube
    Dim i As Integer
    For i = 0 To cube.Dimensions.Count - 1 Step i + 1
      Dim dimen As Dimension = cube.Dimensions(i)
      ListBox2.Items.Add(dimen.Name.ToString())
    Next
    ListBox2.SetSelected(0, True)

  End Sub

  Private Sub Button2_Click(ByVal sender As System.Object, _
  ByVal e As System.EventArgs) Handles Button2.Click
    ' Get the selected cube
    Dim cube As CubeDef = cubes(ListBox1.SelectedItem.ToString())
    ' Get the selected Dimension
    Dim dimen As Dimension = cube.Dimensions(ListBox2.SelectedItem.ToString())

    MessageBox.Show("Dimension Properties :: Name=" + dimen.Name.ToString() & _
       ", Description=" + dimen.Description.ToString() + ", Hierarchies=" & _
       dimen.UniqueName.ToString())
  End Sub

  Private Sub Form1_Load(ByVal sender As System.Object, _
  ByVal e As System.EventArgs) Handles MyBase.Load
    ' Construct connection string
    strConn = "Provider=msolap; Data Source = MCB;" & _
    "Initial Catalog = FoodMart 2000; User ID =sa; Pwd="
    ' Create and open a connection
    dbConn = New Connection()
    dbConn.Open(strConn, "", "", _
      CType(ConnectModeEnum.adModeUnknown, Integer))
    ' Create a Catalog object and set it's active connection 
    ' as connection
    dtCatalog = New Catalog()
    dtCatalog.ActiveConnection = CType(dbConn, Object)
    ' Get all cubes
    cubes = dtCatalog.CubeDefs
    ' Set text box text as total number of cubes
    TextBox1.Text = cubes.Count.ToString()
    Dim cube As CubeDef
    For Each cube In cubes
      Dim str As String = ""
      ListBox1.Items.Add(cube.Name.ToString())
      str = "Cube Name :" + cube.Name.ToString() + ", "
      str += "Description :" + cube.Description.ToString() + ", "
      str += "Dimensions :" + cube.Dimensions.Count.ToString()
    Next
    ListBox1.SetSelected(0, True)
  End Sub
End Class
