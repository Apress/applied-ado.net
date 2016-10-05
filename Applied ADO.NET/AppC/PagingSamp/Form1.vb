Imports System.Data.SqlClient


Public Class Form1
    Inherits System.Windows.Forms.Form

    ' Defined variables 
  Shared pageSize As Integer = 5
  Shared curIndex As Integer = 0
  Shared str As String = Nothing
  Shared sql As String = Nothing
  Shared connectionString As String = _
  "Data Source=MCB;Initial Catalog=Northwind;user id=sa;password="
  Shared conn As SqlConnection = Nothing
  Shared adapter As SqlDataAdapter = Nothing
  Shared ds As DataSet = Nothing
  Shared totalRecords As Integer = 0
  Shared totalPages As Integer = 0
  Shared selectTop As Boolean = False
  Shared firstVisibleCustomer As String = ""
  Shared lastVisibleCustomer As String = ""
  Shared custTable As DataTable = Nothing
  Shared currentPage As Integer = 0

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
  Friend WithEvents PrePageBtn As System.Windows.Forms.Button
  Friend WithEvents NextPageBtn As System.Windows.Forms.Button
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
  Friend WithEvents LoadPageBtn As System.Windows.Forms.Button
  Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.DataGrid1 = New System.Windows.Forms.DataGrid()
    Me.PrePageBtn = New System.Windows.Forms.Button()
    Me.NextPageBtn = New System.Windows.Forms.Button()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.TextBox1 = New System.Windows.Forms.TextBox()
    Me.LoadPageBtn = New System.Windows.Forms.Button()
    Me.CheckBox1 = New System.Windows.Forms.CheckBox()
    CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'DataGrid1
    '
    Me.DataGrid1.DataMember = ""
    Me.DataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText
    Me.DataGrid1.Location = New System.Drawing.Point(16, 80)
    Me.DataGrid1.Name = "DataGrid1"
    Me.DataGrid1.Size = New System.Drawing.Size(464, 264)
    Me.DataGrid1.TabIndex = 0
    '
    'PrePageBtn
    '
    Me.PrePageBtn.Location = New System.Drawing.Point(248, 48)
    Me.PrePageBtn.Name = "PrePageBtn"
    Me.PrePageBtn.Size = New System.Drawing.Size(112, 32)
    Me.PrePageBtn.TabIndex = 1
    Me.PrePageBtn.Text = "<< Previous Page"
    '
    'NextPageBtn
    '
    Me.NextPageBtn.Location = New System.Drawing.Point(368, 48)
    Me.NextPageBtn.Name = "NextPageBtn"
    Me.NextPageBtn.Size = New System.Drawing.Size(112, 32)
    Me.NextPageBtn.TabIndex = 2
    Me.NextPageBtn.Text = "Next Page >>"
    '
    'Label1
    '
    Me.Label1.Location = New System.Drawing.Point(16, 8)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(72, 24)
    Me.Label1.TabIndex = 3
    Me.Label1.Text = "Page Size:"
    '
    'TextBox1
    '
    Me.TextBox1.Location = New System.Drawing.Point(104, 8)
    Me.TextBox1.Name = "TextBox1"
    Me.TextBox1.Size = New System.Drawing.Size(88, 20)
    Me.TextBox1.TabIndex = 4
    Me.TextBox1.Text = ""
    '
    'LoadPageBtn
    '
    Me.LoadPageBtn.Location = New System.Drawing.Point(24, 48)
    Me.LoadPageBtn.Name = "LoadPageBtn"
    Me.LoadPageBtn.Size = New System.Drawing.Size(88, 32)
    Me.LoadPageBtn.TabIndex = 5
    Me.LoadPageBtn.Text = "Load Page"
    '
    'CheckBox1
    '
    Me.CheckBox1.Location = New System.Drawing.Point(256, 8)
    Me.CheckBox1.Name = "CheckBox1"
    Me.CheckBox1.TabIndex = 6
    Me.CheckBox1.Text = "SELECT TOP"
    '
    'Form1
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(496, 357)
    Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.CheckBox1, Me.LoadPageBtn, Me.TextBox1, Me.Label1, Me.NextPageBtn, Me.PrePageBtn, Me.DataGrid1})
    Me.Name = "Form1"
    Me.Text = "Paging Sample"
    CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)

  End Sub

#End Region


  Private Sub Form1_Load(ByVal sender As System.Object, _
 ByVal e As System.EventArgs) Handles MyBase.Load
    TextBox1.Text = "5"
  End Sub


  Function GetPagedData(ByVal da As SqlDataAdapter, _
  ByVal idx As Integer, ByVal size As Integer) As DataSet
    Dim ds As DataSet = New DataSet()
    Try
      da.Fill(ds, idx, size, "Orders")
    Catch e As Exception
      MessageBox.Show(e.Message.ToString())
    End Try
    Return ds
  End Function

  Private Sub LoadPageBtn_Click(ByVal sender As System.Object, _
  ByVal e As System.EventArgs) Handles LoadPageBtn.Click
    pageSize = Convert.ToInt32(TextBox1.Text.ToString())
    ' Create and open a connection
    conn = New SqlConnection(connectionString)
    conn.Open()
    ' Find out total number of records
    Dim cmd As SqlCommand = New SqlCommand()
    ' Assign the SQL Insert statement we want to execute to the CommandText
    cmd.CommandText = "SELECT Count(*) FROM Customers"
    cmd.Connection = conn
    ' Call ExecuteNonQuery on the Command Object to execute insert
    totalRecords = cmd.ExecuteScalar()
    ' Create data adapter
    sql = "SELECT CustomerID, CompanyName, ContactName " & _
    "FROM Customers ORDER BY CustomerID"
    adapter = New SqlDataAdapter(sql, conn)
    ds = New DataSet()

    ' If SELECT TOP check box is checked
    If CheckBox1.Checked Then
      selectTop = True
    Else
      selectTop = False
    End If

    ' if SELECT TOP is checked
    If selectTop Then
      GetTopData("", 0)
      DataGrid1.DataSource = custTable
    Else
      ds = GetPagedData(adapter, curIndex, pageSize)
      curIndex = curIndex + pageSize
      DataGrid1.DataSource = ds.DefaultViewManager
    End If
  End Sub

  ' Get a page using SELECT TOP statement
  Public Shared Sub GetTopData(ByVal selectCmd As String, ByVal type As Integer)
    ' First time load first TOP pages
    If (selectCmd.Equals(String.Empty)) Then
      selectCmd = "SELECT TOP " & pageSize & " CustomerID, CompanyName, " & _
      " ContactName FROM Customers ORDER BY CustomerID"
    End If

    totalPages = CInt(Math.Ceiling(CDbl(totalRecords) / pageSize))
    adapter.SelectCommand.CommandText = selectCmd
    Dim tmpTable As DataTable = New DataTable("Customers")
    Dim recordsAffected As Integer = adapter.Fill(tmpTable)
    ' If the table does not exist, create it.
    If custTable Is Nothing Then custTable = tmpTable.Clone()
    ' Refresh the table if at least one record is returned.
    If recordsAffected > 0 Then
      Select Case type
        Case 1
          currentPage = currentPage + 1
        Case 2
          currentPage = currentPage - 1
        Case Else
          currentPage = 1
      End Select
      ' Clear the rows and add new results.
      custTable.Rows.Clear()
      ' Import rows from temp tabke to custTable
      Dim myRow As DataRow
      For Each myRow In tmpTable.Rows
        custTable.ImportRow(myRow)
      Next
      ' Preserve the first and last primary key values.
      Dim ordRows() As DataRow = custTable.Select("", "CustomerID ASC")
      firstVisibleCustomer = ordRows(0)(0).ToString()
      lastVisibleCustomer = ordRows(custTable.Rows.Count - 1)(0).ToString()
    End If
  End Sub

  ' Previous page button click
  Private Sub PrePageBtn_Click(ByVal sender As System.Object, _
  ByVal e As System.EventArgs) Handles PrePageBtn.Click
    ' if SELECT TOP is checked
    If selectTop Then
      sql = "SELECT TOP " & pageSize & " CustomerID, CompanyName, " & _
      " ContactName FROM Customers " & _
      "WHERE CustomerID < '" & firstVisibleCustomer & "' ORDER BY CustomerID"
      GetTopData(sql, 1)
    Else
      ds = GetPagedData(adapter, curIndex, pageSize)
      curIndex = curIndex - pageSize
      DataGrid1.DataSource = ds.DefaultViewManager
    End If

  End Sub

  ' Next page button click
  Private Sub NextPageBtn_Click(ByVal sender As System.Object, _
  ByVal e As System.EventArgs) Handles NextPageBtn.Click
    ' if SELECT TOP is checked
    If selectTop Then
      sql = "SELECT TOP " & pageSize & " CustomerID, CompanyName, " & _
      " ContactName FROM Customers " & _
      "WHERE CustomerID > '" & lastVisibleCustomer & "' ORDER BY CustomerID"
      GetTopData(sql, 2)
    Else
      ds = GetPagedData(adapter, curIndex, pageSize)
      curIndex = curIndex + pageSize
      DataGrid1.DataSource = ds.DefaultViewManager
    End If
  End Sub

End Class
