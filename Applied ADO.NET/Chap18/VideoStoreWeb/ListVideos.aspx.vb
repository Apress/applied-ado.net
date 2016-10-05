Imports VideoStoreDataModel.EnterpriseVB.VideoStore.Data


Public Class ListVideos
    Inherits System.Web.UI.Page

    Protected WithEvents SaveButton As System.Web.UI.WebControls.Button
    Protected WithEvents CancelButton As System.Web.UI.WebControls.Button
    Protected WithEvents VideoTapeEditor As System.Web.UI.HtmlControls.HtmlTable
    Protected WithEvents VideoTitleField As System.Web.UI.WebControls.TextBox
    Protected WithEvents VideoDescriptionField As System.Web.UI.WebControls.TextBox
    Protected WithEvents AddNewButton As System.Web.UI.WebControls.LinkButton
    Protected WithEvents Table1 As System.Web.UI.HtmlControls.HtmlTable
    Protected WithEvents VideoListGrid As System.Web.UI.WebControls.DataGrid
    Protected WithEvents CheckOutButton As System.Web.UI.WebControls.Button
    Protected WithEvents CheckedOutLabel As System.Web.UI.WebControls.Label
    Protected WithEvents CheckedOutDataGrid As System.Web.UI.WebControls.DataGrid
    Protected SelectedUser As User

    
#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

    Public Property SelectedVideoTapeID() As Decimal
        Get
            If (("" + ViewState("SelectedVideoTapeID")) Is "") Then
                Return -1
            End If
            Return Convert.ToDecimal("" + ViewState("SelectedVideoTapeID"))
        End Get
        Set(ByVal Value As Decimal)
            ViewState("SelectedVideoTapeID") = "" + Value
        End Set
    End Property
    Public Property SelectedUserID() As Decimal
        Get
            If (("" + ViewState("SelectedUserID")) Is "") Then
                Return -1
            End If
            Return Convert.ToDecimal("" + ViewState("SelectedUserID"))
        End Get
        Set(ByVal Value As Decimal)
            ViewState("SelectedUserID") = "" + Value
        End Set
    End Property


    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim UserDAC As New UserDataAccess()
        If (Request("UserID") <> "") Then
            SelectedUserID = Convert.ToDecimal(Request("UserID").ToString())
        End If
        SelectedUser = UserDAC.GetUserByID(Me.SelectedUserID)
        'DisplaySelectedVideoTape()
        If (Not IsPostBack) Then
            Me.VideoTapeEditor.Visible = False
        End If
        RebindListingGrid()
    End Sub

    Sub VideoListGrid_Command(ByVal sender As Object, ByVal e As DataGridCommandEventArgs) Handles VideoListGrid.ItemCommand
        If (e.CommandName Is "Edit") Then
            Me.SelectedVideoTapeID = Convert.ToDecimal(e.Item.Cells(0).Text)
            DisplaySelectedVideoTape()
        End If
    End Sub

    Sub CheckedOutGrid_Command(ByVal sender As Object, ByVal e As DataGridCommandEventArgs) Handles CheckedOutDataGrid.ItemCommand
        Dim usrDAC As New UserDataAccess()
        Dim vDAC As New VideoTapeDataAccess()
        Dim vciDAC As New VideoCheckInCheckOut(usrDAC.connectionString)
        vciDAC.CheckInVideoFromUser(usrDAC.GetUserByID(1), vDAC.GetVideoTapeByID(Convert.ToDecimal(e.Item.Cells(0).Text)))
        RebindListingGrid()
    End Sub

    Private Sub RebindListingGrid()
        Dim vDAC As New VideoTapeDataAccess()
        Dim vciDAC As New VideoCheckInCheckOut(vDAC.connectionString)
        Dim vTapes() As VideoTape
        vTapes = vciDAC.GetVideoTapesCheckedIn() 'vDAC.GetAllVideoTapes()
        VideoListGrid.DataSource = vTapes
        VideoListGrid.DataBind()


        Dim usrDAC As New UserDataAccess()
        Dim checkedOut() As VideoTape
        checkedOut = vciDAC.GetVideoTapesCheckedOutToUser(usrDAC.GetUserByID(Me.SelectedUserID))
        CheckedOutDataGrid.DataSource = checkedOut
        CheckedOutDataGrid.DataBind()
    End Sub

    Private Sub DisplaySelectedVideoTape()
        If (Me.SelectedVideoTapeID = -1) Then
            VideoTapeEditor.Visible = False
            Return
        End If
        VideoTapeEditor.Visible = True
        Dim vDAC As New VideoTapeDataAccess()
        Dim vTape As VideoTape
        If (Me.SelectedVideoTapeID = -2) Then
            vTape = New VideoTape()
        Else
            vTape = vDAC.GetVideoTapeByID(Me.SelectedVideoTapeID)
        End If
        Me.VideoTitleField.Text = vTape.Title
        Me.VideoDescriptionField.Text = vTape.Description

        Dim vciDAC As New VideoCheckInCheckOut(vDAC.connectionString)
        If (vciDAC.IsVideoCheckedOut(vTape)) Then
            Me.CheckedOutLabel.Text = "Currently Checked Out"
            Me.CheckOutButton.Enabled = False
        Else
            Me.CheckedOutLabel.Text = "Currently Checked In"
            Me.CheckOutButton.Enabled = True
        End If
    End Sub
    Private Sub VideoListGrid_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VideoListGrid.SelectedIndexChanged

    End Sub

    Private Sub CancelButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CancelButton.Click
        Me.SelectedVideoTapeID = -1
        DisplaySelectedVideoTape()
    End Sub

    Private Sub SaveButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveButton.Click
        Dim vDAC As New VideoTapeDataAccess()
        Dim vTape As VideoTape
        If (Me.SelectedVideoTapeID = -2) Then
            vTape = New VideoTape()
        Else
            vTape = vDAC.GetVideoTapeByID(Me.SelectedVideoTapeID)
        End If
        vTape.Title = Me.VideoTitleField.Text
        vTape.Description = Me.VideoDescriptionField.Text
        vDAC.SetVideoTape(vTape)
        Me.SelectedVideoTapeID = -1
        DisplaySelectedVideoTape()
        RebindListingGrid()
    End Sub

    Private Sub AddNewButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddNewButton.Click
        Me.SelectedVideoTapeID = -2
        DisplaySelectedVideoTape()
    End Sub

    Private Sub CheckOutButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckOutButton.Click
        Dim usrDAC As New UserDataAccess()
        Dim vciDAC As New VideoCheckInCheckOut(usrDAC.connectionString)
        Dim vDAC As New VideoTapeDataAccess()

        vciDAC.CheckOutVideoToUser(usrDAC.GetUserByID(1), SelectedUser, vDAC.GetVideoTapeByID(Me.SelectedVideoTapeID))
        RebindListingGrid()
        DisplaySelectedVideoTape()
    End Sub
End Class
