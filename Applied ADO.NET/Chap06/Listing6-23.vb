Imports System.Xml
Module Module1
  Sub Main()
    Dim xmlDoc As XmlDocument = New XmlDocument()
    xmlDoc.Load("c:\\books.xml")
    Dim xmlDocFragment As XmlDocumentFragment = xmlDoc.CreateDocumentFragment()
    xmlDocFragment.InnerXml = _
    "<Fragment><SomeData>Fragment Data</SomeData></Fragment>"
    Dim aNode As XmlNode = xmlDoc.DocumentElement.FirstChild
    aNode.InsertAfter(xmlDocFragment, aNode.LastChild)
    xmlDoc.Save(Console.Out)

  End Sub
End Module
