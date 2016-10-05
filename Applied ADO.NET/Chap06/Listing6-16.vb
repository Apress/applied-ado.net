Imports System.Xml
Module Module1
  Sub Main()
    Dim xmlDoc As XmlDocument = New XmlDocument()
    Dim filename As String = "C:\\books.xml"
    xmlDoc.Load(filename)
   
    'Create a document fragment.
    Dim docFrag As XmlDocumentFragment = xmlDoc.CreateDocumentFragment()
    'Set the contents of the document fragment.
    docFrag.InnerXml = "<Record> write something</Record>"
    'Display the document fragment.
    Console.WriteLine(docFrag.InnerXml)

  End Sub
End Module
