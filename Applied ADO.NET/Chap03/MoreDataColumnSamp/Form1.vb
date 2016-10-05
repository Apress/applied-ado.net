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
  Friend WithEvents ColumnMapping As System.Windows.Forms.MenuItem
  Friend WithEvents DataGrid1 As System.Windows.Forms.DataGrid
  Friend WithEvents ExtendedProperties As System.Windows.Forms.MenuItem
  Friend WithEvents Ordinal As System.Windows.Forms.MenuItem
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.MainMenu1 = New System.Windows.Forms.MainMenu()
    Me.MenuItem1 = New System.Windows.Forms.MenuItem()
    Me.ColumnMapping = New System.Windows.Forms.MenuItem()
    Me.ExtendedProperties = New System.Windows.Forms.MenuItem()
    Me.DataGrid1 = New System.Windows.Forms.DataGrid()
    Me.Ordinal = New System.Windows.Forms.MenuItem()
    CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'MainMenu1
    '
    Me.MainMenu1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem1})
    '
    'MenuItem1
    '
    Me.MenuItem1.Index = 0
    Me.MenuItem1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.ColumnMapping, Me.ExtendedProperties, Me.Ordinal})
    Me.MenuItem1.Text = "DataColumn"
    '
    'ColumnMapping
    '
    Me.ColumnMapping.Index = 0
    Me.ColumnMapping.Text = "ColumnMapping"
    '
    'ExtendedProperties
    '
    Me.ExtendedProperties.Index = 1
    Me.ExtendedProperties.Text = "ExtendedProperties"
    '
    'DataGrid1
    '
    Me.DataGrid1.DataMember = ""
    Me.DataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText
    Me.DataGrid1.Location = New System.Drawing.Point(16, 16)
    Me.DataGrid1.Name = "DataGrid1"
    Me.DataGrid1.Size = New System.Drawing.Size(312, 240)
    Me.DataGrid1.TabIndex = 0
    '
    'Ordinal
    '
    Me.Ordinal.Index = 2
    Me.Ordinal.Text = "Ordinal"
    '
    'Form1
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(344, 273)
    Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.DataGrid1})
    Me.Menu = Me.MainMenu1
    Me.Name = "Form1"
    Me.Text = "Form1"
    CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)

  End Sub

#End Region

  Private Sub ColumnMapping_Click(ByVal sender As System.Object, _
  ByVal e As System.EventArgs) Handles ColumnMapping.Click

    Dim custTable As DataTable = New DataTable("Customers")
    Dim nameCol As DataColumn = New DataColumn("Name", _
      Type.GetType("System.Int32"), MappingType.Attribute)
    nameCol.DataType = Type.GetType("System.String")
    nameCol.ColumnMapping = MappingType.Element
    custTable.Columns.Add(nameCol)
    DataGrid1.DataSource = custTable

  End Sub

  Private Sub ExtendedProperties_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExtendedProperties.Click
    Dim custTable As DataTable = New DataTable("Customers")
    Dim nameCol As DataColumn = New DataColumn("Name", _
      Type.GetType("System.Int32"), MappingType.Attribute)
    ' Add custom properties
    nameCol.DataType = Type.GetType("System.String")
    nameCol.ExtendedProperties.Add("Description", "The Name Column")
    nameCol.ExtendedProperties.Add("Author", "Mahesh Chand")
    nameCol.ExtendedProperties.Add("UserId", "MCB")
    nameCol.ExtendedProperties.Add("PWD", "Password")
    custTable.Columns.Add(nameCol)
    ' Remove Author property
    nameCol.ExtendedProperties.Remove("Author")
    ' Read custom properties
    Dim str As String
    Dim i As Integer
    str = nameCol.ExtendedProperties("Description").ToString()
    str = str + ", " + nameCol.ExtendedProperties("UserId").ToString()
    str = str + ", " + nameCol.ExtendedProperties("PWD").ToString()
    MessageBox.Show(str)

  End Sub

  Private Sub Ordinal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Ordinal.Click
    Dim custTable As DataTable = New DataTable("Customers")
    Dim nameCol As DataColumn = New DataColumn("Name", _
      Type.GetType("System.Int32"), MappingType.Attribute)
    custTable.Columns.Add(nameCol)
    nameCol = New DataColumn()
    nameCol.DataType = Type.GetType("System.String")
    nameCol.Caption = "New Column"
    nameCol.ColumnName = "Col2"
    nameCol.MaxLength = 240
    custTable.Columns.Add(nameCol)
    Dim str As String
    str = "Ordinal " + nameCol.Ordinal.ToString()
    str = str + " ,Length " + nameCol.MaxLength.ToString()
    MessageBox.Show(str)
  End Sub
End Class
