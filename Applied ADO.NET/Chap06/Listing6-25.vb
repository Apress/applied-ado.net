Imports System.Xml
Imports System.Xml.Xsl
Imports System.Xml.XPath


Module Module1
  Sub Main()
    'Create a new XslTransform object and load the stylesheet
    Dim xslt As XslTransform = New XslTransform()
    xslt.Load("c:\\books.xsl")
    'Create a new XPathDocument and load the XML data to be transformed.
    Dim mydata As XPathDocument = New XPathDocument("c:\\books.xml")
    'Create an XmlTextWriter which outputs to the console.
    Dim writer As XmlWriter = New XmlTextWriter(Console.Out)
    'Transform the data and send the output to the console.
    xslt.Transform(mydata, Nothing, writer)



  End Sub
End Module
