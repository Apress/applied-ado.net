Public Class WebForm1
    Inherits System.Web.UI.Page
  Protected WithEvents Button1 As System.Web.UI.WebControls.Button
  Protected WithEvents LinkButton1 As System.Web.UI.WebControls.LinkButton
  Protected WithEvents ImageButton1 As System.Web.UI.WebControls.ImageButton

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
    ImageButton1.ImageUrl = _
    "http://www.c-sharpcorner.com/images/csLogo102.gif"
    ImageButton1.ImageAlign = ImageAlign.Baseline
  End Sub

  Private Sub LinkButton1_Click(ByVal sender As System.Object, _
  ByVal e As System.EventArgs) Handles LinkButton1.Click
    Response.Write("LinkButton clicked")
  End Sub
End Class
