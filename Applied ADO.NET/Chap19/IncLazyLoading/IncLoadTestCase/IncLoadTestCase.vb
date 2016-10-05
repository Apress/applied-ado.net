Imports VideoStoreDataModel.EnterpriseVB.VideoStore.Data

Module IncLoadTestCase

    Sub Main()

        Console.WriteLine("Starting IncLoadTestCase")
        Dim iLoadCat As New VideoCategoryIndexer(3, New SqlClient.SqlConnection(VideoCategoryDataAccess.connectionString))
        Console.WriteLine("Loaded " + iLoadCat.LoadedCount.ToString() + " out of " + iLoadCat.Count().ToString() + ".")

        Console.WriteLine("Displaying First 10")
        Dim i As Integer
        For i = 0 To iLoadCat.LoadedCount - 1
            Console.WriteLine("Item:" + iLoadCat.Videos(i).Title)
        Next

        Console.WriteLine("Displaying All")
        For i = 0 To iLoadCat.Count() - 1
            Console.WriteLine("Item:" + iLoadCat.Videos(i).Title)
        Next

        Console.WriteLine("Test Complete.")

        Console.WriteLine("Press enter key to quit.")
        Console.ReadLine()

    End Sub

End Module