Imports VideoStoreDataModel.EnterpriseVB.VideoStore.Data

Module VideoCheckInCheckOutTestCase

    Sub Main()

        Dim vDAC As New VideoTapeDataAccess()
        Dim uDAC As New UserDataAccess()
        Dim vciDAC As New VideoCheckInCheckOut(vDac.connectionString)
        Dim tTape As VideoTape
        tTape = vDAC.GetVideoTapeByID(1)
        Console.WriteLine("Is Tape Checked Out:" + vciDAC.IsVideoCheckedOut(tTape).ToString())

        Dim tUser As User
        tUser = uDAC.GetUserByID(1)
        Console.WriteLine("Checking out video.")
        vciDAC.CheckOutVideoToUser(tUser, tUser, tTape)
        Console.WriteLine("Is Tape Checked Out:" + vciDAC.IsVideoCheckedOut(tTape).ToString())

        Dim tapes() As VideoTape
        tapes = vciDAC.GetVideoTapesCheckedOutToUser(tUser)

        Console.WriteLine("Tapes Currently Checked Out To User:")
        DisplayTapeArray(tapes)
        Console.WriteLine("Tapes Not Currently Checked Out To Anyone")
        tapes = vciDAC.GetVideoTapesCheckedIn()
        DisplayTapeArray(tapes)
        vciDAC.CheckInVideoFromUser(tUser, tTape)

        Console.WriteLine("Video Checked In")
        Console.WriteLine("Is Tape Checked Out:" + vciDAC.IsVideoCheckedOut(tTape).ToString())

        tapes = vciDAC.GetVideoTapesCheckedOutToUser(tUser)

        Console.WriteLine("Tapes Currently Checked Out To User:")
        DisplayTapeArray(tapes)
        Console.WriteLine("Tapes Not Currently Checked Out To Anyone")
        tapes = vciDAC.GetVideoTapesCheckedIn()
        DisplayTapeArray(tapes)

        Console.WriteLine("Press Any Key To Quit...")
        Console.ReadLine()

    End Sub


    Sub DisplayTapeArray(ByRef tapes() As VideoTape)
        Dim i As Integer
        For i = 0 To tapes.Length - 1
            Console.WriteLine("TAPE:" + tapes(i).Title)
        Next
    End Sub
End Module
