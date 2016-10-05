Imports VideoStoreDataModel.EnterpriseVB.VideoStore.Data

Module VideoTapeTestCase

    Sub Main()
        Dim vDAC As New VideoTapeDataAccess()
        Dim tVTape As VideoTape
        Console.WriteLine("Loading VideoTape")
        tVTape = vDAC.GetVideoTapeByID(1)
        Console.WriteLine("VideoTape Loaded:" + tVTape.GetType().ToString())
        DisplayVideoTape(tVTape)

        Dim origTitle = tVTape.Title
        Dim origDescription = tVTape.Description

        tVTape.Title = "TestTitle"
        tVTape.Description = "TestDescription"

        vDAC.SetVideoTape(tVTape)

        tVTape = vDAC.GetVideoTapeByID(1)
        Console.WriteLine("After alteration. Title=TestTitle  Description=TestDescription")
        DisplayVideoTape(tVTape)

        tVTape.Title = origTitle
        tVTape.Description = origDescription
        vDAC.SetVideoTape(tVTape)
        tVTape = vDAC.GetVideoTapeByID(1)
        Console.WriteLine("Restored to origional, should look like the first displayed VideoTape.")
        DisplayVideoTape(tVTape)
     
        Console.WriteLine("List all VideoTapes")

        Dim tVideos() As VideoTape
        tVideos = vDAC.GetAllVideoTapes()

        Dim i As Integer
        For i = 0 To tVideos.Length - 1
            DisplayVideoTape(tVideos(i))
        Next
        Console.WriteLine("Press Any Key To Quit...")
        Console.ReadLine()
    End Sub

    Sub DisplayVideoTape(ByRef tVTape As VideoTape)
        Console.WriteLine("---------------------------")
        Console.WriteLine("VideoTapeID:" + tVTape.VideoTapeID.ToString())
        Console.WriteLine("Title:" + tVTape.Title)
        Console.WriteLine("Description:" + tVTape.Description)
    End Sub

End Module
