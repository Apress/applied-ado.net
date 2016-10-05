Imports System.Data.SqlClient

Public Class Form1
  Inherits System.Windows.Forms.Form

  Private ConnectionString As String = "user id=sa;password=;" & _
      "Initial Catalog=Northwind;" & _
      "Data Source=MCB;"
  Private conn As SqlConnection = Nothing
  Private adapter As SqlDataAdapter = Nothing
  Private sql As String = Nothing

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
  Friend WithEvents Button1 As System.Windows.Forms.Button
  Friend WithEvents Button2 As System.Windows.Forms.Button
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.DataGrid1 = New System.Windows.Forms.DataGrid()
    Me.Button1 = New System.Windows.Forms.Button()
    Me.Button2 = New System.Windows.Forms.Button()
    CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'DataGrid1
    '
    Me.DataGrid1.DataMember = ""
    Me.DataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText
    Me.DataGrid1.Location = New System.Drawing.Point(0, 88)
    Me.DataGrid1.Name = "DataGrid1"
    Me.DataGrid1.Size = New System.Drawing.Size(376, 200)
    Me.DataGrid1.TabIndex = 0
    '
    'Button1
    '
    Me.Button1.Location = New System.Drawing.Point(8, 16)
    Me.Button1.Name = "Button1"
    Me.Button1.Size = New System.Drawing.Size(96, 32)
    Me.Button1.TabIndex = 1
    Me.Button1.Text = "Delete Row"
    '
    'Button2
    '
    Me.Button2.Location = New System.Drawing.Point(176, 16)
    Me.Button2.Name = "Button2"
    Me.Button2.Size = New System.Drawing.Size(96, 32)
    Me.Button2.TabIndex = 2
    Me.Button2.Text = "Update Data"
    '
    'Form1
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(384, 293)
    Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.Button2, Me.Button1, Me.DataGrid1})
    Me.Name = "Form1"
    Me.Text = "Form1"
    CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)

  End Sub

#End Region



  Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

    ' Create a new connection
    conn = New SqlConnection(ConnectionString)
    ' Open the connection
    If (conn.State <> ConnectionState.Open) Then
      conn.Open()
    End If
    'Create a DataSet
    Dim ds As DataSet = New DataSet()
    sql = "SELECT * FROM Orders ORDER BY OrderID"
    ' Create a data adapter with already opened connection
    Dim adapter As SqlDataAdapter = New SqlDataAdapter(sql, conn)
    ' Fill DataSEt
    adapter.Fill(ds, "Orders")
    ' DataTable
    Dim dt As DataTable = ds.Tables("Orders")
    ' Get the Row you want to edit based on the OrderID
    Dim seearchStr As Object = OrderInfo(0)
    Dim row As DataRow = dt.Rows.Find(seearchStr)
    ' Display column 1 of the found row.
    If Not (row Is Nothing) Then
      ' Error Message
    End If
    ' Set data row values
    row("OrderDate") = Convert.ToDateTime(OrderInfo(1))
    row("ShipName") = OrderInfo(2)
    row("ShipAddress") = OrderInfo(3)
    row("ShipCity") = OrderInfo(4)
    row("ShipCountry") = OrderInfo(5)
    row("ShipPostalCode") = OrderInfo(6)
    ' Add DataRow to the collection
    ds.Tables(0).AcceptChanges()
    ' Save changes back to data source
    adapter.Update(ds, "Orders")

  End Sub

  Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click


    ' Create a new connection
    conn = New SqlConnection(ConnectionString)
    ' Open the connection
    If (conn.State <> ConnectionState.Open) Then
      conn.Open()
    End If
    Dim order As String = orderID.ToString()
    sql = "DELETE * FROM Orders WHERE OrderID=" + order
    ' Create a SqlCommand
    Dim cmd As SqlCommand = New SqlCommand(sql)
    cmd.Connection = conn
    Try
      ' Execute command
      cmd.ExecuteNonQuery()
    Catch exp As Exception
      ' Write your message here
    End Try
  End Sub

  Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    Dim ds As DataSet = New DataSet()
    ' Create a new connection
    conn = New SqlConnection(ConnectionString)
    sql = "SELECT * FROM Orders"
    ' Open the connection
    If (conn.State <> ConnectionState.Open) Then
      conn.Open()
    End If
    ' Create a DataAdapter
    Dim adapter As SqlDataAdapter = New SqlDataAdapter(sql, conn)
    adapter.Fill(ds)

    DataGrid1.DataSource = ds.DefaultViewManager

    '  Close the connection
    If (conn.State = ConnectionState.Open) Then
      conn.Close()
      conn.Dispose()
    End If
    ' Return DataSet

  End Sub
End Class
