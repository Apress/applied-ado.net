Public Class WebForm1
    Inherits System.Web.UI.Page
  Protected WithEvents DataGrid1 As System.Web.UI.WebControls.DataGrid
  Protected WithEvents Label1 As System.Web.UI.WebControls.Label
  Protected WithEvents TextBox1 As System.Web.UI.WebControls.TextBox
  Protected WithEvents Button1 As System.Web.UI.WebControls.Button

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

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
    End Sub

  Private Sub Button1_Click(ByVal sender As System.Object, _
  ByVal e As System.EventArgs) Handles Button1.Click
    ' construct and call the web service with the order 
    'id in the textbox
    Dim myWebService As localhost.Service1 = New localhost.Service1()
    Dim ds As DataSet = myWebService.GetOrderFromDatabase _
    (Convert.ToInt32(Me.TextBox1.Text))
    ' bind the data to the grid
    DataGrid1.DataSource = ds
    DataGrid1.DataBind()
  End Sub
End Class
