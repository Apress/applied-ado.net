Imports System.Xml
Module Module1
  Sub Main()
    Dim doc As XmlDocument = New XmlDocument()
    doc.LoadXml("<book genre='programming'>" & _
            "<title>ADO.NET Programming</title>" & _
            "</book>")
    ' Get the root node
    Dim root As XmlNode = doc.DocumentElement
    ' Create a new node.
    Dim newbook As XmlElement = doc.CreateElement("price")
    newbook.InnerText = "44.95"
    'Add the node to the document.
    root.AppendChild(newbook)
    doc.Save(Console.Out)


  End Sub
End Module
