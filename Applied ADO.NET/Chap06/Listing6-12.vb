Imports System.Xml
Module Module1
  Sub Main()
    Dim reader As XmlTextReader = _
    New XmlTextReader("C:\\books.xml")
    While reader.Read()
      ' Look for a node with name bookstore
      If reader.Name <> "bookstore" Then
        reader.Skip()
      Else
        Console.WriteLine("Name: " + reader.Name)
        Console.WriteLine("Level of the node: " + reader.Depth.ToString())
        Console.WriteLine("Value: " + reader.Value)
      End If
    End While
    reader.Close()
  End Sub
End Module
