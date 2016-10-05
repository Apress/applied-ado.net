Imports System.Xml
Module Module1

  Sub Main()
    Dim DecCounter As Integer = 0
    Dim PICounter As Integer = 0
    Dim DocCounter As Integer = 0
    Dim CommentCounter As Integer = 0
    Dim ElementCounter As Integer = 0
    Dim AttributeCounter As Integer = 0
    Dim TextCounter As Integer = 0
    Dim WhitespaceCounter As Integer = 0
    Dim reader As XmlTextReader = New XmlTextReader("C:\\books.xml")
    While reader.Read()

      Dim nodetype As XmlNodeType = reader.NodeType
      Select Case nodetype
        Case XmlNodeType.XmlDeclaration
          DecCounter = DecCounter + 1
          Exit Select
        Case XmlNodeType.ProcessingInstruction
          PICounter = PICounter + 1
          Exit Select
        Case XmlNodeType.DocumentType
          DocCounter = DocCounter + 1
          Exit Select
        Case XmlNodeType.Comment
          CommentCounter = CommentCounter + 1
          Exit Select
        Case XmlNodeType.Element
          ElementCounter = ElementCounter + 1
          If reader.HasAttributes Then
            AttributeCounter += reader.AttributeCount
          End If
          Exit Select
        Case XmlNodeType.Text
          TextCounter = TextCounter + 1
          Exit Select
        Case XmlNodeType.Whitespace
          WhitespaceCounter = WhitespaceCounter + 1
          Exit Select
      End Select
    End While
    ' Print the info
    Console.WriteLine("White Spaces:" + WhitespaceCounter.ToString())
    Console.WriteLine("Process Instructions:" + PICounter.ToString())
    Console.WriteLine("Declaration:" + DecCounter.ToString())
    Console.WriteLine("White Spaces:" + DocCounter.ToString())
    Console.WriteLine("Comments:" + CommentCounter.ToString())
    Console.WriteLine("Attributes:" + AttributeCounter.ToString())


  End Sub

End Module
