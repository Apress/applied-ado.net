Imports System.IO
Module Module1
  Sub Main()
    Dim filename As String = "c:\\abc.txt"
    Dim counter As Int16 = 10

    Try
      Dim Stream As System.IO.StreamReader = _
      File.OpenText(filename)
    Catch When counter > 5
      Console.WriteLine("Custom Error: Counter Out of Range")
    Finally
      ' Close and dispose objects here of first Try
      ' block here
    End Try
  End Sub
End Module

