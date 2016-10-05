Imports System.Xml
Module Module1
  Sub Main()
    Dim writer As XmlTextWriter = _
    New XmlTextWriter("c:\\test.xml", Nothing)
    writer.WriteStartElement("MyTestElements")
    Dim bl As Boolean = True
    writer.WriteElementString("TestBoolean", XmlConvert.ToString(bl))
    Dim dt As DateTime = New DateTime(2000, 1, 1)
    writer.WriteElementString("TestDate", XmlConvert.ToString(dt))
    writer.WriteEndElement()
    writer.Flush()
    writer.Close()
  End Sub
End Module
