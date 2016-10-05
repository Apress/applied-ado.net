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
  Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
  Friend WithEvents Button1 As System.Windows.Forms.Button
  Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
  Friend WithEvents GetTables As System.Windows.Forms.Button
  Friend WithEvents GetTableSchema As System.Windows.Forms.Button
  Friend WithEvents ListBox2 As System.Windows.Forms.ListBox
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.TextBox1 = New System.Windows.Forms.TextBox()
    Me.Button1 = New System.Windows.Forms.Button()
    Me.ListBox1 = New System.Windows.Forms.ListBox()
    Me.GetTables = New System.Windows.Forms.Button()
    Me.GetTableSchema = New System.Windows.Forms.Button()
    Me.ListBox2 = New System.Windows.Forms.ListBox()
    Me.SuspendLayout()
    '
    'TextBox1
    '
    Me.TextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.TextBox1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.TextBox1.Location = New System.Drawing.Point(8, 8)
    Me.TextBox1.Name = "TextBox1"
    Me.TextBox1.Size = New System.Drawing.Size(256, 21)
    Me.TextBox1.TabIndex = 0
    Me.TextBox1.Text = "TextBox1"
    '
    'Button1
    '
    Me.Button1.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(192, Byte))
    Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
    Me.Button1.Font = New System.Drawing.Font("Verdana", 8.0!, System.Drawing.FontStyle.Bold)
    Me.Button1.Location = New System.Drawing.Point(272, 8)
    Me.Button1.Name = "Button1"
    Me.Button1.Size = New System.Drawing.Size(144, 24)
    Me.Button1.TabIndex = 1
    Me.Button1.Text = "Browse Database"
    '
    'ListBox1
    '
    Me.ListBox1.BackColor = System.Drawing.SystemColors.Info
    Me.ListBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.ListBox1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.ListBox1.Location = New System.Drawing.Point(8, 88)
    Me.ListBox1.Name = "ListBox1"
    Me.ListBox1.Size = New System.Drawing.Size(128, 197)
    Me.ListBox1.TabIndex = 2
    '
    'GetTables
    '
    Me.GetTables.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    Me.GetTables.FlatStyle = System.Windows.Forms.FlatStyle.Flat
    Me.GetTables.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GetTables.Location = New System.Drawing.Point(8, 48)
    Me.GetTables.Name = "GetTables"
    Me.GetTables.Size = New System.Drawing.Size(128, 24)
    Me.GetTables.TabIndex = 3
    Me.GetTables.Text = "Get Tables"
    '
    'GetTableSchema
    '
    Me.GetTableSchema.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(224, Byte), CType(192, Byte))
    Me.GetTableSchema.FlatStyle = System.Windows.Forms.FlatStyle.Flat
    Me.GetTableSchema.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GetTableSchema.Location = New System.Drawing.Point(208, 48)
    Me.GetTableSchema.Name = "GetTableSchema"
    Me.GetTableSchema.Size = New System.Drawing.Size(152, 24)
    Me.GetTableSchema.TabIndex = 4
    Me.GetTableSchema.Text = "Get Table Schema"
    '
    'ListBox2
    '
    Me.ListBox2.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(192, Byte), CType(192, Byte))
    Me.ListBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.ListBox2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.ListBox2.Location = New System.Drawing.Point(144, 88)
    Me.ListBox2.Name = "ListBox2"
    Me.ListBox2.Size = New System.Drawing.Size(328, 197)
    Me.ListBox2.TabIndex = 5
    '
    'Form1
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(480, 301)
    Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.ListBox2, Me.GetTableSchema, Me.GetTables, Me.ListBox1, Me.Button1, Me.TextBox1})
    Me.Name = "Form1"
    Me.Text = "Database Schema Sample"
    Me.ResumeLayout(False)

  End Sub

#End Region

  Private dbName As String = ""

  Private Sub GetTableSchema_Click(ByVal sender As System.Object, _
  ByVal e As System.EventArgs) Handles GetTableSchema.Click
    ' Get the selected item text of list box
    Dim selTable As String = ListBox1.GetItemText(ListBox1.SelectedItem)
    ' Connection string
    Dim strDSN As String = "Provider=Microsoft.Jet.OLEDB.4.0;" & _
        "Data Source=" + dbName
    ' Create and open connection
    Dim conn As OleDbConnection = New OleDbConnection(strDSN)
    Try
      conn.Open()
      Dim strSQL As String = "SELECT * FROM " + selTable
      ' Create data adapter
      Dim adapter As OleDbDataAdapter = New OleDbDataAdapter(strSQL, conn)
      ' Create and fill data set
      Dim dtSet As DataSet = New DataSet()
      adapter.Fill(dtSet)
      Dim dt As DataTable = dtSet.Tables(0)

      ' Add items to the list box control
      ListBox2.Items.Add("Column Name, DataType, Unique," & _
               " AutoIncrement, AllowNull")
      ListBox2.Items.Add("=====================================")

      Dim i As Integer
      For i = 0 To dt.Columns.Count - 1
        Dim dc As DataColumn
        dc = dt.Columns(i)
        ListBox2.Items.Add(dc.ColumnName.ToString() + " , " + dc.DataType.ToString() & _
        " ," + dc.Unique.ToString() + " ," + dc.AutoIncrement.ToString() & _
         " ," + dc.AllowDBNull.ToString())
      Next

    Catch exp As Exception
      MessageBox.Show(exp.Message)
    Finally
      conn.Close()
      conn.Dispose()
    End Try
  End Sub

  Private Sub Browse_Click(ByVal sender As System.Object, _
  ByVal e As System.EventArgs) Handles Button1.Click
    Dim fdlg As OpenFileDialog = New OpenFileDialog()
    fdlg.Title = "C# Corner Open File Dialog"
    fdlg.InitialDirectory = "c:\\"
    fdlg.Filter = "All files (*.*)|*.mdb|" & _
  "MS-Access Database files (*.mdb)|*.mdb"
    fdlg.FilterIndex = 2
    fdlg.RestoreDirectory = True
    If fdlg.ShowDialog() = DialogResult.OK Then
      TextBox1.Text = fdlg.FileName
      dbName = fdlg.FileName
    End If
  End Sub

  Private Sub GetTables_Click(ByVal sender As System.Object, _
  ByVal e As System.EventArgs) Handles GetTables.Click

    ' Connection string
    Dim strDSN As String = "Provider=Microsoft.Jet.OLEDB.4.0;" & _
    "Data Source=" + dbName
    ' Create a connection and open it
    Dim conn As OleDbConnection = New OleDbConnection(strDSN)

    Try
      conn.Open()
      ' Call GetOleDbSchemaTable to get the schema data table
      Dim dt As DataTable = _
      conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, New Object() _
                    {Nothing, Nothing, Nothing, "TABLE"})
      ' Set DataSource and DisplayMember properties
      ' of the list box control
      ListBox1.DataSource = dt.DefaultView
      ListBox1.DisplayMember = "TABLE_NAME"

    Catch exp As Exception
      MessageBox.Show(exp.Message.ToString())
    Finally
      ' Close the connection
      conn.Close()
      conn.Dispose()
    End Try
  End Sub
End Class
