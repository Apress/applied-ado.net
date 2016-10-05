Imports VideoStoreDataModel.EnterpriseVB.VideoStore.Data

Module UserTestCase

    Sub Main()
        Dim uDAC As New UserDataAccess()
        Dim tUser As User
        Console.WriteLine("Loading User")
        tUser = uDAC.GetUserByID(1)
        Console.WriteLine("User Loaded:" + tUser.GetType().ToString())
        DisplayUser(tUser)
        Dim origFirstName = tUser.FirstName
        Dim origLastName = tUser.LastName

        tUser.FirstName = "TestFirst"
        tUser.LastName = "TestLast"

        uDAC.SetUser(tUser)

        tUser = uDAC.GetUserByID(1)
        Console.WriteLine("After alteration. FirstName=TestFirst LastName=TestLast")
        DisplayUser(tUser)
        Console.WriteLine("Restored to origional, should look like the first displayed user.")
        tUser.FirstName = origFirstName
        tUser.LastName = origLastName
        uDAC.SetUser(tUser)
        tUser = uDAC.GetUserByID(1)
        DisplayUser(tUser)

        Console.WriteLine("List all users")

        Dim tUsers() As User
        tUsers = uDAC.GetAllUsers()

        Dim i As Integer
        For i = 0 To tUsers.Length - 1
            DisplayUser(tUsers(i))
        Next
        Console.WriteLine("Press Any Key To Quit...")
        Console.ReadLine()
    End Sub

    Sub DisplayUser(ByRef tUser As User)
        Console.WriteLine("UserID:" + tUser.UserID.ToString())
        Console.WriteLine("FirstName" + tUser.FirstName)
        Console.WriteLine("LastName:" + tUser.LastName)
    End Sub

End Module
