Imports System.Xml
Module Module1
  Sub Main()

    ' Create a new file c:\xmlWriterTest.xml
    Dim writer As XmlTextWriter = _
    New XmlTextWriter("C:\\xmlWriterTest.xml", Nothing)
    ' Opens the document 
    writer.WriteStartDocument()
    ' Write comments
    writer.WriteComment("This program uses XmlTextWriter.")
    writer.WriteComment("Developed By: Mahesh Chand.")
    writer.WriteComment("================================")
    ' Write first element
    writer.WriteStartElement("root")
    writer.WriteStartElement("r", "RECORD", "urn:record")
    ' Write next element
    writer.WriteStartElement("FirstName", "")
    writer.WriteString("Mahesh")
    writer.WriteEndElement()
    ' Write one more element
    writer.WriteStartElement("LastName", "")
    writer.WriteString("Chand")
    writer.WriteEndElement()
    ' Create an XmlTextReader to read books.xml 
    Dim reader As XmlTextReader = New XmlTextReader("c:\\books.xml")
    While reader.Read()
      If reader.NodeType = XmlNodeType.Element Then
        ' Add node.xml to xmlWriterTest.xml usign WriteNode
        writer.WriteNode(reader, True)
      End If
    End While
    ' Ends the document.
    writer.WriteEndDocument()
    writer.Close()

  End Sub

End Module
