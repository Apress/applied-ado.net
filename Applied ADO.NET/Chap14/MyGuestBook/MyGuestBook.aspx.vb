Imports System.Data.OleDb

Public Class WebForm1
  Inherits System.Web.UI.Page
  Protected WithEvents NameTextBox As System.Web.UI.WebControls.TextBox
  Protected WithEvents AddressTextBox As System.Web.UI.WebControls.TextBox
  Protected WithEvents EmailTextBox As System.Web.UI.WebControls.TextBox
  Protected WithEvents CommentsTextBox As System.Web.UI.WebControls.TextBox
  Protected WithEvents Button1 As System.Web.UI.WebControls.Button
  Protected WithEvents Button2 As System.Web.UI.WebControls.Button

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
    ' set Access connection and select strings 
    Dim strDSN As String = "Provider=Microsoft.Jet.OLEDB.4.0;" & _
          "Data Source=C:\\GuestBook.mdb"
    Dim strSQL As String = "INSERT INTO Guest" & _
               "(Name, Address, Email, Comments )" & _
               "VALUES('" + NameTextBox.Text.ToString() + "','" & _
                AddressTextBox.Text.ToString() + "','" & _
                EmailTextBox.Text.ToString() & _
                "','" + CommentsTextBox.Text.ToString() + "')"

    ' create OleDbDataAdapter
    Dim conn As OleDbConnection = New OleDbConnection(strDSN)
    ' Create OleDbCommand and call ExecuteNonQuery to execute 
    ' a SQL statement
    Dim myCmd As OleDbCommand = New OleDbCommand(strSQL, conn)
    Try
      conn.Open()
      myCmd.ExecuteNonQuery()
    Catch exp As Exception
      Console.WriteLine("Error: {0}", exp.Message)
    Finally
      conn.Close()
      conn.Dispose()
    End Try
    ' Open Thanks.aspx page after adding entries to the guest book
    Response.Redirect("Thanks.aspx")
  End Sub

  Private Sub Button2_Click(ByVal sender As System.Object, _
  ByVal e As System.EventArgs) Handles Button2.Click
    ' View CiewGuestBook.aspx page
    Response.Redirect("ViewGuestBook.aspx")
  End Sub
End Class
