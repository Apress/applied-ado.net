Imports System.Xml
Module Module1
  Sub Main()
    Dim filename As String = "C:\\books.xml"
    Dim xmlDoc As XmlDocument = New XmlDocument()
    xmlDoc.Load(filename)
    Dim root As XmlElement = xmlDoc.DocumentElement


  End Sub
End Module
