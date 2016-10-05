Imports System.Xml
Module Module1
  Sub Main()
    Dim xmlDoc As XmlDocument = New XmlDocument()
    xmlDoc.Load("c:\\books.xml")
    Dim NewElem As XmlElement = xmlDoc.CreateElement("NewElement")
    Dim NewAttr As XmlAttribute = xmlDoc.CreateAttribute("NewAttribute")
    NewElem.SetAttributeNode(NewAttr)
    'add the new element to the document
    Dim root As XmlElement = xmlDoc.DocumentElement
    root.AppendChild(NewElem)
    xmlDoc.Save(Console.Out)


  End Sub
End Module
