Imports System.Data
Imports System.Xml
Imports System.IO

Module Module1
  Sub Main()
    try
      Dim ds As DataSet = New DataSet("DS")
      ds.Namespace = "StdNamespace"
      Dim stdTable As DataTable = New DataTable("Students")
      Dim col1 As DataColumn = New DataColumn("Name")
      Dim col2 As DataColumn = New DataColumn("Address")
      stdTable.Columns.Add(col1)
      stdTable.Columns.Add(col2)
      ds.Tables.Add(stdTable)
      ' Add Student Data to the table
      Dim NewRow As DataRow = stdTable.NewRow()
      NewRow("Name") = "Melnaie Talmadge"
      NewRow("Address") = "Meadowlake Dr, Dtown"
      stdTable.Rows.Add(NewRow)
      NewRow = stdTable.NewRow()
      NewRow("Name") = "Amy Talmadge"
      NewRow("Address") = "Herndon, VA"
      stdTable.Rows.Add(NewRow)
      ds.AcceptChanges()
      Dim writer As XmlTextWriter = New XmlTextWriter(Console.Out)
      ds.WriteXmlSchema(writer)

    Catch exp As Exception
      Console.WriteLine("Exception: {0}", exp.ToString())
    End Try
  End Sub
End Module
