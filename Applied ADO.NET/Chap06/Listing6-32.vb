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

    ' Moce to root node
    nav.MoveToRoot()
    Dim name As String = nav.Name
    Console.WriteLine("Root node info: ")
    Console.WriteLine("Base URI" + nav.BaseURI.ToString())
    Console.WriteLine("Name: " + nav.Name.ToString())
    Console.WriteLine("Node Type: " + nav.NodeType.ToString())
    Console.WriteLine("Node Value: " + nav.Value.ToString())

    If nav.HasChildren Then
      nav.MoveToFirstChild()
      GetNodeInfo(nav)
    End If


  End Sub
  Public Sub GetNodeInfo(ByVal nav1 As XPathNavigator)
    Console.WriteLine("Name: " + nav1.Name.ToString())
    Console.WriteLine("Node Type: " + nav1.NodeType.ToString())
    Console.WriteLine("Node Value: " + nav1.Value.ToString())

    ' If node has children, move to fist child.
    If nav1.HasChildren Then
      nav1.MoveToFirstChild()

      While nav1.MoveToNext()
        GetNodeInfo(nav1)
        nav1.MoveToParent()
      End While
    Else
      nav1.MoveToNext()
      GetNodeInfo(nav1)
    End If

  End Sub


End Module
