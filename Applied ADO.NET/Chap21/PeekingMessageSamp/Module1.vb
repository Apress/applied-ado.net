Imports System
Imports System.Messaging
Module Module1

  Sub Main()
    NotifyArrived()
    SendMessage()
    PeekFirstMessage()
  End Sub

  Public Sub NotifyArrived()
    Dim myQueue As New MessageQueue(".\monitoredQueue")
    myQueue.MessageReadPropertyFilter.ClearAll()
    Dim emptyMessage As Message = myQueue.Peek()
    Console.WriteLine("A message has arrived in the queue.")
  End Sub 
  
  Public Sub SendMessage()
    Dim sentOrder As New Order()
    sentOrder.orderId = 3
    sentOrder.orderTime = DateTime.Now
    Dim myQueue As New MessageQueue(".\myQueue")
    myQueue.Send(sentOrder)
  End Sub 'SendMessage

  Public Sub PeekFirstMessage()
    Dim myQueue As New MessageQueue(".\myQueue")
    myQueue.Formatter = New XmlMessageFormatter(New Type() _
        {GetType(MyProject.Order)})
    Try

      Dim myMessage As Message = myQueue.Peek()
      Dim myOrder As Order = CType(myMessage.Body, Order)

      Console.WriteLine(("Order ID: " + _
          myOrder.orderId.ToString()))
      Console.WriteLine(("Sent: " + _
          myOrder.orderTime.ToString()))

    Catch m As MessageQueueException

    Catch e As InvalidOperationException
      Console.WriteLine(e.Message)
      ' Catch other exceptions as necessary.

    End Try

    Return

  End Sub 'PeekFirstMessage 




End Module
