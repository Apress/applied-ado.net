Imports System.Xml
Module Module1

  Sub Main()
    Dim reader As XmlTextReader = New XmlTextReader("C:\\books.xml")
    While reader.Read()
      Console.WriteLine(reader.Name)
      reader.MoveToContent()
      Console.WriteLine(reader.Name)
    End While
  End Sub

End Module
