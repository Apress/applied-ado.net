Imports System.Xml
Module Module1

  Sub Main()
    Dim reader As XmlTextReader = New XmlTextReader("C:\\books.xml")
    Console.WriteLine("General Information")
    Console.WriteLine("===================")
    Console.WriteLine(reader.Name)
    Console.WriteLine(reader.BaseURI)
    Console.WriteLine(reader.LocalName)
    reader.Close()

  End Sub

End Module
