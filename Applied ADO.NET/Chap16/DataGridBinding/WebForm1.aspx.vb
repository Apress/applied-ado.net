Public Class WebForm1
    Inherits System.Web.UI.Page
  Protected WithEvents MyDataGrid As System.Web.UI.WebControls.DataGrid
  Protected WithEvents au_id As System.Web.UI.HtmlControls.HtmlInputText
  Protected WithEvents au_lname As System.Web.UI.HtmlControls.HtmlInputText
  Protected WithEvents au_fname As System.Web.UI.HtmlControls.HtmlInputText
  Protected WithEvents phone As System.Web.UI.HtmlControls.HtmlInputText
  Protected WithEvents address As System.Web.UI.HtmlControls.HtmlInputText
  Protected WithEvents city As System.Web.UI.HtmlControls.HtmlInputText
  Protected WithEvents state As System.Web.UI.HtmlControls.HtmlSelect
  Protected WithEvents zip As System.Web.UI.HtmlControls.HtmlInputText
  Protected WithEvents contract As System.Web.UI.HtmlControls.HtmlSelect
  Protected WithEvents Submit1 As System.Web.UI.HtmlControls.HtmlInputButton

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

End Class
