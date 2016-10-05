Imports System.Xml
Module Module1
  Sub Main()
    Dim reader As XmlTextReader = _
    New XmlTextReader("C:\\books.xml")
    reader.MoveToContent()
    reader.MoveToFirstAttribute()
    Console.WriteLine("First Attribute Value" + reader.Value)
    Console.WriteLine("First Attribute Name" + reader.Name)
    While reader.Read()
      If reader.HasAttributes Then
        Console.WriteLine(reader.Name + " Attribute")
        Dim i As Integer
        Dim counter As Integer = reader.AttributeCount - 1

        For i = 0 To counter
          reader.MoveToAttribute(i)
          Console.WriteLine("Name: " + reader.Name)
        Next i
        reader.MoveToElement()
      End If
    End While
    reader.Close()
  End Sub
End Module
