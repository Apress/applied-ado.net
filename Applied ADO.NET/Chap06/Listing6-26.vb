Imports System.Data
Imports System.Xml
Imports System.IO

Module Module1
  Sub Main()
    try
    ' Create a DataSet, namespace and Student table 
    'with Name and Address columns
    Dim ds As DataSet = New DataSet("DS")
    ds.Namespace = "StdNamespace"
    Dim stdTable As DataTable = New DataTable("Student")
    Dim col1 As DataColumn = New DataColumn("Name")
    Dim col2 As DataColumn = New DataColumn("Address")
    stdTable.Columns.Add(col1)
    stdTable.Columns.Add(col2)
    ds.Tables.Add(stdTable)
    ' Add Student Data to the table
    Dim NewRow As DataRow = stdTable.NewRow()
      NewRow("Name") = "Melanie Talmadge"
    NewRow("Address") = "Meadowlake Dr, Dtown"
    stdTable.Rows.Add(NewRow)
    NewRow = stdTable.NewRow()
      NewRow("Name") = "Amy Talmadge"
      NewRow("Address") = "Herndon"
    stdTable.Rows.Add(NewRow)
    ds.AcceptChanges()
    ' Create a new StreamWriter
    ' I’ll save data in stdData.xml file 
    Dim writer As System.IO.StreamWriter = _
    New System.IO.StreamWriter("c:\\stdData.xml")
    ' Writer data to DataSet which actually creates the file
    ds.WriteXml(writer)
    writer.Close()
    Catch exp As Exception
      Console.WriteLine("Exception: {0}", exp.ToString())
    End Try
  End Sub
End Module
