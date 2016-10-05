Imports System.Data
Imports System.Data.SqlClient
Imports System.Xml
Imports System.Xml.XPath

Module Module1
  Sub Main()
    ' Load books.xml document
    Dim xmlDoc As XmlDocument = New XmlDocument()
    xmlDoc.Load("c:\\books.xml")
    ' Create XPathNavigator object by calling CreateNavigator of XmlDocument
    Dim nav As XPathNavigator = xmlDoc.CreateNavigator()
    ' Look for author's first name
    Console.WriteLine("Author First Name")
    Dim itrator As XPathNodeIterator = _
    nav.Select("descendant::first-name")
    While itrator.MoveNext()
      Console.WriteLine(itrator.Current.Value.ToString())
    End While

  End Sub


End Module
