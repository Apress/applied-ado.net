Imports System
Imports System.IO
Imports System.Xml
Imports Microsoft.Data.SqlXml

Module Module1

  Sub Main()
    ExecuteStreamMethod()
    ' ExecuteToStreamMethod()
    ' SqlParamExecuteMethod()
    ' ExecuteNonQueryMethod()
  End Sub

  Public Sub ExecuteStreamMethod()
    Dim connectionString As String = _
      "provider=sqloledb;server=mcb;database=Northwind;uid=sa;password=;"
    Dim sql As String = _
    "SELECT FirstName, Title, Address FROM Employees WHERE " & _
    "LastName = 'Fuller' FOR XML AUTO"
    Dim cmd As SqlXmlCommand = New SqlXmlCommand(connectionString)
    cmd.CommandText = sql
    Try
      Dim st As Stream = cmd.ExecuteStream()
      Dim stReader As StreamReader = New StreamReader(st)
      Console.WriteLine(stReader.ReadToEnd())
    Catch exp As Exception
      Console.WriteLine(exp.Message)
    End Try
  End Sub

  Public Sub ExecuteToStreamMethod()
    Dim connectionString As String = _
     "provider=sqloledb;server=mcb;database=Northwind;uid=sa;password=;"
    Dim sql As String = _
    "SELECT FirstName, Title, Address FROM Employees WHERE " & _
    "LastName = 'Fuller' FOR XML AUTO"
    Dim cmd As SqlXmlCommand = New SqlXmlCommand(connectionString)
    cmd.CommandText = sql
    Try
      Dim memStream As MemoryStream = New MemoryStream()
      Dim stReader As StreamReader = New StreamReader(memStream)
      cmd.ExecuteToStream(memStream)
      memStream.Position = 0
      Console.WriteLine(stReader.ReadToEnd())
    Catch exp As Exception
      Console.WriteLine(exp.Message)
    End Try
  End Sub

  Public Sub ExecuteNonQueryMethod()
    Dim connectionString As String = _
     "provider=sqloledb;server=mcb;database=Northwind;uid=sa;password=;"
    Dim sql As String = _
    "DELETE Employees WHERE LastName = 'tel'"
    Dim cmd As SqlXmlCommand = New SqlXmlCommand(connectionString)
    cmd.CommandText = sql
    Try
      cmd.ExecuteNonQuery()
    Catch exp As Exception
      Console.WriteLine(exp.Message)
    End Try
  End Sub

  Public Sub SqlParamExecuteMethod()
    Dim connectionString As String = _
     "provider=sqloledb;server=mcb;database=Northwind;uid=sa;password=;"
    Dim sql As String = _
    "SELECT FirstName, Title, Address FROM Employees " & _
    "FOR XML AUTO"
    Dim cmd As SqlXmlCommand = New SqlXmlCommand(connectionString)
    cmd.CommandText = sql
    Try
      Dim param As SqlXmlParameter
      param = cmd.CreateParameter()
      param.Name = "LastName"
      param.Value = "Fuller"
      Dim st As Stream = cmd.ExecuteStream()
      Dim stReader As StreamReader = New StreamReader(st)
      Console.WriteLine(stReader.ReadToEnd())
    Catch exp As Exception
      Console.WriteLine(exp.Message)
    End Try
  End Sub

End Module



