Public Class WebForm1
    Inherits System.Web.UI.Page
  Protected WithEvents Label1 As System.Web.UI.WebControls.Label
  Protected WithEvents Label2 As System.Web.UI.WebControls.Label
  Protected WithEvents Label3 As System.Web.UI.WebControls.Label
  Protected WithEvents Label4 As System.Web.UI.WebControls.Label
  Protected WithEvents Label5 As System.Web.UI.WebControls.Label
  Protected WithEvents Label6 As System.Web.UI.WebControls.Label
  Protected WithEvents TextBox1 As System.Web.UI.WebControls.TextBox
  Protected WithEvents TextBox2 As System.Web.UI.WebControls.TextBox
  Protected WithEvents TextBox3 As System.Web.UI.WebControls.TextBox
  Protected WithEvents TextBox4 As System.Web.UI.WebControls.TextBox
  Protected WithEvents TextBox5 As System.Web.UI.WebControls.TextBox
  Protected WithEvents TextBox6 As System.Web.UI.WebControls.TextBox
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

    Dim orderData() As String = New String(6) {}
    orderData(0) = TextBox1.Text
    orderData(1) = TextBox2.Text
    orderData(3) = TextBox4.Text
    orderData(4) = TextBox5.Text
    orderData(5) = TextBox6.Text
    ' Create Web serice instalce and call InsertOrder
    Dim myWebService As localhost.Service1 = New localhost.Service1()
    myWebService.InsertOrder(orderData)

  End Sub
End Class
