Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.Common

Namespace EnterpriseVB.VideoStore.Data


    Public Class VideoCategory

        Protected data As DataTable
        Protected index As Integer
        Protected subCategories As New ArrayList()
        Protected vids As VideoTape()


        Protected Friend ReadOnly Property MyData() As DataRow()
            Get
                Dim myRow() As DataRow = {Me.data.Rows(index)}
                Return myRow
            End Get
        End Property

        Public ReadOnly Property Videos() As VideoTape()
            Get
                If (vids Is Nothing) Then
                    Dim vDAC As New VideoTapeDataAccess()
                    vids = vDAC.GetAllVideoTapesInCategory(Me.CategoryID)
                End If
                Return vids
            End Get
        End Property

        Public Sub New(ByRef data As VideoCategoryData, ByVal index As Integer)
            Me.data = data
            Me.index = index
        End Sub
        Public Sub New()
            Me.data = New VideoCategoryData()
            data.Rows.Add(data.NewRow())
            Me.index = 0
            vids = Nothing
        End Sub

        Public Function FindCategoryByID(ByVal catID As Integer) As VideoCategory
            Return Me.FindCategoryByID(Me, catID)
        End Function

        Friend Function FindCategoryByID(ByRef cat As VideoCategory, ByVal catID As Integer) As VideoCategory

            If (catID = cat.CategoryID) Then
                Return cat
            End If

            Dim i As Integer
            For i = 0 To cat.CountSubCategories() - 1
                If (FindCategoryByID(cat.GetSubCategory(i), catID) Is Nothing) Then
                Else
                    Return cat.GetSubCategory(i)
                End If
            Next
            Return Nothing
        End Function

        Public Function GetColumn(ByRef ColumnName As String) As Object
            Return data.Rows(index)(ColumnName)
        End Function

        Public Function SetColumn(ByRef ColumnName As String, ByRef ColumnValue As Object)
            data.Rows(index)(ColumnName) = ColumnValue
        End Function

        Public Property CategoryID() As Int32
            Get
                If (GetColumn("CategoryID").GetType() Is Type.GetType("System.DBNull")) Then
                    Return -1
                End If
                Return CType(GetColumn("CategoryID"), Int32)
            End Get
            Set(ByVal Value As Int32)
                SetColumn("CategoryID", Value)
            End Set
        End Property

        Public Property Description() As String
            Get
                Return "" + GetColumn("Description")
            End Get
            Set(ByVal Value As String)
                SetColumn("Description", Value)
            End Set
        End Property

        Public Property ParentCategoryID() As Int32
            Get
                If (GetColumn("ParentCategoryID").GetType() Is Type.GetType("System.DBNull")) Then
                    Return -1
                End If
                Return CType(GetColumn("ParentCategoryID"), Decimal)
            End Get
            Set(ByVal Value As Int32)
                SetColumn("ParentCategoryID", Value)
            End Set
        End Property

        Public Property RootCategoryID() As Int32
            Get
                If (GetColumn("RootCategoryID").GetType() Is Type.GetType("System.DBNull")) Then
                    Return -1
                End If
                Return CType(GetColumn("RootCategoryID"), Int32)
            End Get
            Set(ByVal Value As Int32)
                SetColumn("RootCategoryID", Value)
            End Set
        End Property

        Public Function AddSubCategory(ByRef subCat As VideoCategory)
            Me.subCategories.Add(subCat)
        End Function

        Public Function CountSubCategories() As Int32
            Return Me.subCategories.Count
        End Function

        Public Function GetSubCategory(ByVal i As Int32) As VideoCategory
            Return CType(Me.subCategories(i), VideoCategory)
        End Function


    End Class

    Public Class VideoCategoryData
        Inherits DataTable

        Public Sub New()
            MyBase.New("VideoCategory")
            Me.Columns.Add("CategoryID", Type.GetType("System.Int32"))
            Me.Columns.Add("Description", Type.GetType("System.String"))
            Me.Columns.Add("ParentCategoryID", Type.GetType("System.Int32"))
            Me.Columns.Add("RootCategoryID", Type.GetType("System.Int32"))
        End Sub
    End Class

    Public Class VideoCategoryDataAccess

        Public connectionString As String
        Protected adapter As SqlDataAdapter
        Protected loadAll As SqlDataAdapter

        Public Sub New()
            connectionString = "Password=1deadrat;User ID=sa;" + _
    "Initial Catalog=VideoStore2;Data Source=grimsaado2k;" + _
    "Workstation ID=GRIMSAADO2K;"


            adapter = New SqlDataAdapter()
            adapter.SelectCommand = New SqlCommand("sp_VideoCategoryGetTree", New SqlConnection(connectionString))
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure
            adapter.SelectCommand.Parameters.Add _
            ("@RootCategoryID", SqlDbType.Decimal, 0, "RootCategoryID")

        End Sub

        Public Function GetCategoryTree(ByVal rootCategoryID As Int32) As VideoCategory
            Dim data As New VideoCategoryData()
            adapter.SelectCommand.Parameters("@RootCategoryID").Value = rootCategoryID
            adapter.Fill(data)

            Dim categories As VideoCategory()
            categories = GetVideoCategoryArrayFromData(data)

            Dim i As Integer
            Dim x As Integer

            If (categories.Length = 0) Then
                Return Nothing
            End If

            For i = 0 To categories.Length - 1
                For x = 0 To categories.Length - 1
                    If (categories(i).CategoryID = categories(x).ParentCategoryID) Then
                        categories(i).AddSubCategory(categories(x))
                    End If
                Next
            Next
            Return categories(0)
        End Function

        Public Shared Function GetVideoCategoryArrayFromData(ByRef data As VideoCategoryData) As VideoCategory()
            Dim vArray(data.Rows.Count - 1) As VideoCategory
            Dim i As Integer
            For i = 0 To (data.Rows.Count - 1)
                vArray(i) = New VideoCategory(data, i)
            Next i
            Return vArray
        End Function


    End Class

End Namespace
