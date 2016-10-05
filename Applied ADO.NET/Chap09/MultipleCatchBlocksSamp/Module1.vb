Imports System.IO
Module Module1
  Sub Main()
    Dim filename As String = "c:\\abc.txt"
    Dim Strings As New Collection()
    ' start first try block here
    Try
      Dim Stream As System.IO.StreamReader = _
      File.OpenText(filename)
      ' start second Try block here
      Try
        While True
          Strings.Add(Stream.ReadLine())
        End While
      Catch eosExp As System.IO.EndOfStreamException
        ' Write EndOfStream exception error
      Catch IOExp As System.IO.IOException
        ' IO Eception error
        Console.WriteLine(IOExp.Message)
        Strings = Nothing
      Finally
        ' Close and dispose objects here
        Stream.Close()
      End Try
      ' end second try bkock here

      ' catch of first Try block
    Catch exp As Exception
      Console.WriteLine(exp.Message)
    Finally
      ' Close and dispose objects here of first Try
      ' block here
    End Try
    ' end first try block here
  End Sub
End Module
