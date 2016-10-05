Imports System.Xml
Module Module1
  Sub Main()
    Dim xmlDoc As XmlDocument = New XmlDocument()
    xmlDoc.LoadXml("<Record> Some Value </Record>")
    ' Adding a new comment node to the document
    Dim node1 As XmlNode = xmlDoc.CreateComment("DOM Testing Sample")
    xmlDoc.AppendChild(node1)
    ' Adding an FirstName to the document
    node1 = xmlDoc.CreateElement("FirstName")
    node1.InnerText = "Mahesh"
    xmlDoc.DocumentElement.AppendChild(node1)
    xmlDoc.Save(Console.Out)

  End Sub
End Module
