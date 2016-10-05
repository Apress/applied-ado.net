Imports VideoStoreDataModel.EnterpriseVB.VideoStore.Data

Public Class ChoosePerson
    Inherits System.Web.UI.Page
        Protected WithEvents SaveButton As System.Web.UI.WebControls.Button
    Protected WithEvents CancelButton As System.Web.UI.WebControls.Button
    Protected WithEvents CheckOutVideosButton As System.Web.UI.WebControls.Button
    Protected WithEvents FirstNameField As System.Web.UI.WebControls.TextBox
    Protected WithEvents LastNameField As System.Web.UI.WebControls.TextBox
    Protected WithEvents ChooseUserDataGrid As System.Web.UI.WebControls.DataGrid

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
        RebindListingGrid()
        If (Not IsPostBack) Then
            Me.SaveButton.Enabled = False
            Me.CancelButton.Enabled = False
            Me.CheckOutVideosButton.Enabled = False
        End If
    End Sub

    Private Sub RebindListingGrid()
        Dim uDAC As New UserDataAccess()
        Dim users() As User
        users = uDAC.GetAllUsers()
        ChooseUserDataGrid.DataSource = users
        ChooseUserDataGrid.DataBind()
    End Sub

    Protected Sub ChooseUser_Command(ByVal sender As Object, ByVal e As DataGridCommandEventArgs) Handles ChooseUserDataGrid.ItemCommand
        SetSelectedUserID(e.Item.Cells(0).Text)

        'Response.Write("GOT:" + sender.GetType().ToString())
    End Sub

    Protected Sub SetSelectedUserID(ByVal userID As Decimal)
        Me.SelectedUserID = userID
        Dim UserDAC As New UserDataAccess()
        Dim usr As User
        usr = UserDAC.GetUserByID(SelectedUserID)
        Me.FirstNameField.Text = usr.FirstName
        Me.LastNameField.Text = usr.LastName
        Me.SaveButton.Enabled = True
        Me.CancelButton.Enabled = True
        Me.CheckOutVideosButton.Enabled = True
    End Sub

    Private Sub SaveButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveButton.Click
        Dim UserDAC As New UserDataAccess()
        Dim usr As User
        usr = UserDAC.GetUserByID(SelectedUserID)
        usr.FirstName = Me.FirstNameField.Text
        usr.LastName = Me.LastNameField.Text
        UserDAC.SetUser(usr)
        RebindListingGrid()
    End Sub

    Private Sub CancelButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CancelButton.Click
        Me.SelectedUserID = -1
        Me.FirstNameField.Text = ""
        Me.LastNameField.Text = ""
        Me.SaveButton.Enabled = False
        Me.CancelButton.Enabled = False
        Me.CheckOutVideosButton.Enabled = False
    End Sub

    Private Sub CheckOutVideosButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckOutVideosButton.Click
        Response.Redirect("ListVideos.aspx?UserID=" + Me.SelectedUserID.ToString())
    End Sub
End Class
