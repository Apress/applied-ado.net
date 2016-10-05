Imports System
Imports System.Messaging
Imports System.Threading


Module Module1

  Dim done As Boolean

  Sub Main()
    Dim mq As MessageQueue = _
    New MessageQueue(path:=".\private$\mcbQ")
    AddHandler mq.ReceiveCompleted, AddressOf MyReceiveCompleted
    mq.Purge()
    mq.BeginReceive()
    Do While Not done
      Console.WriteLine(mq.FormatName)
    Loop
    Console.WriteLine("Do you want to continue(y/n)?")
    If Console.ReadLine() = "n" Then

    End If

  End Sub

  Public Sub MyReceiveCompleted(ByVal [source] As _
             [Object], ByVal asyncResult As ReceiveCompletedEventArgs)

    Try
      Dim msg As Message
      Dim mq As MessageQueue = CType([source], MessageQueue)
      Console.WriteLine(mq.QueueName)
      msg = mq.EndReceive(asyncResult.AsyncResult)
      Console.WriteLine(mq.Label)
      done = True
      mq.BeginReceive()
    Catch

    End Try
  End Sub

End Module
