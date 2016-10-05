Imports System.Data.SqlClient
Imports System.Web.Services

<WebService(Namespace:="http://tempuri.org/", _
   Description:="Working with Orders in Northwind")> _
Public Class OrderRetrivalService
  Inherits System.Web.Services.WebService

  Shared ConnectionString As String = "user id=sa;password=;" & _
      "Initial Catalog=Northwind;" & _
      "Data Source=MCB;"
  Shared conn As SqlConnection = Nothing
  Shared adapter As SqlDataAdapter = Nothing
  Shared sql As String = Nothing
  Shared ds As DataSet = Nothing

#Region " Web Services Designer Generated Code "

  Public Sub New()
    MyBase.New()

    'This call is required by the Web Services Designer.
    InitializeComponent()

    'Add your own initialization code after the InitializeComponent() call

  End Sub

  'Required by the Web Services Designer
  Private components As System.ComponentModel.IContainer

  'NOTE: The following procedure is required by the Web Services Designer
  'It can be modified using the Web Services Designer.  
  'Do not modify it using the code editor.
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    components = New System.ComponentModel.Container()
  End Sub

  Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
    'CODEGEN: This procedure is required by the Web Services Designer
    'Do not modify it using the code editor.
    If disposing Then
      If Not (components Is Nothing) Then
        components.Dispose()
      End If
    End If
    MyBase.Dispose(disposing)
  End Sub

#End Region


  <WebMethod(Description:="Retrieve an order from Northwind ")> _
 Public Function GetOrderFromDatabase( _
 ByVal orderID As Integer) As DataSet
    Dim str As String = orderID.ToString()
    ds = New DataSet()
    ' Create a new connection
    conn = New SqlConnection(ConnectionString)
    sql = "SELECT * FROM Orders WHERE OrderID = " + str
    ' Open the connection
    If (conn.State <> ConnectionState.Open) Then
      conn.Open()
    End If
    ' Create a DataAdapter
    Dim adapter As SqlDataAdapter = New SqlDataAdapter(sql, conn)
    adapter.Fill(ds)
    '  Close the connection
    If (conn.State = ConnectionState.Open) Then
      conn.Close()
    End If
    ' Return DataSet
    Return ds
  End Function

  <WebMethod(Description:="Inser Order from an Array")> _
Public Function InsertOrder(ByVal OrderInfo As String()) As Integer
    ' Create a new connection
    conn = New SqlConnection(ConnectionString)
    ' Open the connection
    If (conn.State <> ConnectionState.Open) Then
      conn.Open()
    End If
    'Create a DataSet
    ds = New DataSet()
    sql = "SELECT * FROM Orders ORDER BY OrderID"
    ' Create a data adapter with already opened connection
    Dim adapter As SqlDataAdapter = New SqlDataAdapter(sql, conn)
    ' Fill DataSEt
    adapter.Fill(ds, "Orders")
    ' Get the last row
    Dim drLast As DataRow = _
    ds.Tables(0).Rows(ds.Tables(0).Rows.Count - 1)
    Dim LastOrderID As Integer = Convert.ToInt32(drLast("OrderID"))
    ' Create a new DataRow
    Dim row As DataRow = ds.Tables(0).NewRow()
    ' Set data row values
    row("OrderID") = LastOrderID + 1
    row("OrderDate") = Convert.ToDateTime(OrderInfo(0))
    row("ShipName") = OrderInfo(1)
    row("ShipAddress") = OrderInfo(2)
    row("ShipCity") = OrderInfo(3)
    row("ShipCountry") = OrderInfo(4)
    row("ShipPostalCode") = OrderInfo(5)
    ' Add DataRow to the collection
    ds.Tables(0).Rows.Add(row)
    ' Save changes back to data source
    adapter.Update(ds, "Orders")
    ' Return OrderID
    Return row("OrderID")
  End Function

  ' SaveChanges method saves a DataSet 
  <WebMethod(Description:="Save Changes method")> _
Public Function SaveChanges(ByVal changedDS As DataSet) As Integer
    ' Open connection if already not open
    If conn.State <> ConnectionState.Open Then
      conn.Open()
    End If
    ' Data is modified
    Dim affectedRows As Integer = 0
    affectedRows = adapter.Update(changedDS, "Orders")
    ' Accept changes and refresh the DataGrid
    ds.AcceptChanges()
    ' Close and dispose connection
    If conn.State = ConnectionState.Open Then
      conn.Close()
      conn.Dispose()
    End If
    Return affectedRows
  End Function

  ' SaveChanges method saves a DataSet 
  <WebMethod(Description:="Exceute SQL Statement")> _
Public Function ExecuteQuery(ByVal sql As String) As Integer
    Dim affectedRows As Integer = 0
    ' Open connection if already not open
    If conn.State <> ConnectionState.Open Then
      conn.Open()
    End If
    ' Create a SqlCommand and execute it
    Dim cmd As SqlCommand = New SqlCommand()
    cmd.Connection = conn
    cmd.CommandText = sql
    affectedRows = cmd.ExecuteNonQuery()
    ' Close and dispose connection
    If conn.State = ConnectionState.Open Then
      conn.Close()
    End If
    Return affectedRows
  End Function

End Class
