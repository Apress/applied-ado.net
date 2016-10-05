Imports System
Imports System.Messaging

Module Module1

  Sub Main()
    SendTransactionalMessages()
    RecieveTransactionalMessages()
  End Sub

  Public Sub SendTransactionalMessages()
    Dim mq As MessageQueue = New MessageQueue()
    mq = MessageQueue.Create(".\Private$\mcbTQ", True)
    Dim tran As MessageQueueTransaction = _
    New MessageQueueTransaction()
    Try
      Dim msg1 As Message = New Message()
      Dim msg2 As Message = New Message()
      msg1.Priority = MessagePriority.High
      msg1.Body = "Body of first message"
      msg1.Label = "First Message"
      msg2.Priority = MessagePriority.Normal
      msg2.Label = "Second Message"
      msg2.Body = "Body of second message"
      tran.Begin()
      mq.Send(msg1, tran)
      mq.Send(msg2, "Message2", tran)
      mq.Send("Body of third message", "Message3", tran)
      tran.Commit()
      Console.WriteLine("Transaction committed!")
    Catch
      tran.Abort()
      Console.WriteLine("Transaction Aborted!")
    End Try
  End Sub

  Public Sub RecieveTransactionalMessages()
    Dim mq As MessageQueue = New MessageQueue()
    mq.Path = ".\Private$\mcbTQ"
    Dim tran As MessageQueueTransaction = _
    New MessageQueueTransaction()
    Try
      tran.Begin()
      Dim messages() As System.Messaging.Message
      messages = mq.GetAllMessages()
      ' Need a formatter to get the text of the message body.
      Dim stringFormatter As System.Messaging.XmlMessageFormatter = _
         New System.Messaging.XmlMessageFormatter(New String() _
         {"System.String"})
      Dim index As Integer
      Dim msg As System.Messaging.Message

      For index = 0 To messages.Length - 1
        messages(index).Formatter = stringFormatter
        msg = messages(index)
        Console.WriteLine(msg.Label + "," + msg.Body)
      Next
      tran.Commit()
      Console.WriteLine("Transaction committed!")
    Catch
      tran.Abort()
      Console.WriteLine("Transaction Aborted!")
    End Try
  End Sub

End Module
