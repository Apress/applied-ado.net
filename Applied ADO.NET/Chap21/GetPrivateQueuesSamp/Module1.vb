Imports System.Messaging

Module Module1
  Sub Main()
    Dim queList As MessageQueue() = _
     MessageQueue.GetPrivateQueuesByMachine(".")
    Dim que As MessageQueue
    For Each que In queList
      Console.WriteLine(que.Path)
    Next que
  End Sub
End Module
