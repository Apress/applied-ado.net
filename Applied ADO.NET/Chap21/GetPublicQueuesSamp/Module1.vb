Imports System.Messaging

Module Module1
  Sub Main()
    ' GetPublicQueuesMethod()
    ' GetQueuesByCategoryMethod()
   
  End Sub

  Public Sub GetQueuesMethod()
    Try
      Dim queList As MessageQueue() = _
    MessageQueue.GetPublicQueues()
      Dim que As MessageQueue
      For Each que In queList
        Console.WriteLine(que.Path)
      Next que
    Catch exp As Exception
      Console.WriteLine(exp.Message)
    End Try
  End Sub


  Sub GetQueuesByCategoryMethod()
    Try
      Dim queList As MessageQueue() = _
    MessageQueue.GetPublicQueuesByCategory(New _
        Guid("{00000000-0000-0000-0000-000000000001}"))
      Dim que As MessageQueue
      For Each que In queList
        Console.WriteLine(que.Path)
      Next que
    Catch exp As Exception
      Console.WriteLine(exp.Message)
    End Try
  End Sub

  Public Sub GetQueuesByLabelMethod()
    Try
      Dim queList As MessageQueue() = _
    MessageQueue.GetPublicQueuesByLabel("LabelName")
      Dim que As MessageQueue
      For Each que In queList
        Console.WriteLine(que.Path)
      Next que
    Catch exp As Exception
      Console.WriteLine(exp.Message)
    End Try
  End Sub

  Public Sub GetQueuesByMachineMethod()
    Try
      Dim queList As MessageQueue() = _
    MessageQueue.GetPublicQueuesByMachine("MCB")
      Dim que As MessageQueue
      For Each que In queList
        Console.WriteLine(que.Path)
      Next que
    Catch exp As Exception
      Console.WriteLine(exp.Message)
    End Try
  End Sub



End Module