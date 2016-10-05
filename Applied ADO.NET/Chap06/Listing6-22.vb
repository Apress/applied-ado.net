Imports System.Xml
Module Module1
  Sub Main()
    Dim filename As String = "C:\\books.xml"
    Dim xmlDoc As XmlDocument = New XmlDocument()
    xmlDoc.Load(filename)
    Dim root As XmlElement = xmlDoc.DocumentElement
    Dim xmlDocFragment As XmlDocumentFragment = xmlDoc.CreateDocumentFragment()
    xmlDocFragment.InnerXml = _
    "<Fragment><SomeData>Fragment Data</SomeData></Fragment>"
    Dim rootNode As XmlElement = xmlDoc.DocumentElement
    'Replace xmlDocFragment with rootNode.LastChild
    rootNode.ReplaceChild(xmlDocFragment, rootNode.LastChild)
    xmlDoc.Save(Console.Out)





  End Sub
End Module
