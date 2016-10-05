Imports System.Data
Imports System.Data.SqlClient
Imports System.Xml

Module Module1
  Sub Main()
    ' Create a Connection Object
    Dim ConnectionString As String = "Integrated Security=SSPI;" & _
     "Initial Catalog=Northwind;Data Source=MCB;"
    Dim conn As SqlConnection = New SqlConnection()
    conn.ConnectionString = ConnectionString
    ' Open the connection
    If conn.State <> ConnectionState.Open Then
      conn.Open()
    End If
    Dim sql As String = "SELECT * FROM Customers"
    Dim da As SqlDataAdapter = New SqlDataAdapter(sql, conn)
    ' Create and fill a DataSet
    Dim ds As DataSet = New DataSet()
    da.Fill(ds)
    ' Now use SxlDataDocument's Save method to save data as an XML file
    Dim doc As XmlDataDocument = New XmlDataDocument(ds)
    doc.Save("C:\\XmlDataDoc.xml")
    ' Close and dispose the connection
    If conn.State <> ConnectionState.Open Then
      conn.Open()
      conn.Dispose()
    End If
  End Sub
End Module
