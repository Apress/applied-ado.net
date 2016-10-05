Imports System.IO
Module Module1
  Sub Main()
    Try
      File.Open("c:\\abc.txt", FileMode.Open)
    Catch exp As Exception
      Console.WriteLine("Exception Ocurred :" + exp.Message.ToString())
    End Try
  End Sub
End Module
