Imports System.Data
Imports System.Data.SqlClient

Public Class WebForm2
  Inherits System.Web.UI.Page
  Protected WithEvents DropDownList1 As System.Web.UI.WebControls.DropDownList
  Protected WithEvents LoadDataBtn As System.Web.UI.WebControls.Button
  Protected WithEvents CheckBox1 As System.Web.UI.WebControls.CheckBox
  Protected WithEvents Label1 As System.Web.UI.WebControls.Label
  Protected WithEvents GetSelItem As System.Web.UI.WebControls.Button

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

  Private Sub Page_Load(ByVal sender As System.Object, _
  ByVal e As System.EventArgs) Handles MyBase.Load
    'Put user code to initialize the page here
    If Not IsPostBack Then
    End If
  End Sub

  Private Sub LoadDataBtn_Click(ByVal sender As System.Object, _
  ByVal e As System.EventArgs) Handles LoadDataBtn.Click
    Dim conn As SqlConnection = Nothing
    Dim adapter As SqlDataAdapter = Nothing
    Dim reader As SqlDataReader = Nothing
    Dim cmd As SqlCommand = Nothing
    Dim connectionString = _
    "Data Source=MCB;Initial Catalog=Northwind;user id=sa;password=;"
    conn = New SqlConnection(connectionString)
    conn.Open()
    Dim sql = "SELECT * FROM Categories"

    If CheckBox1.Checked Then
      ' Use DataReader
      cmd = New SqlCommand(sql, conn)
      reader = cmd.ExecuteReader()
      DropDownList1.DataSource = reader
      DropDownList1.DataTextField = "CategoryName"
      DropDownList1.DataBind()
      If Not reader.IsClosed Then
        reader.Close()
      End If
    Else
      ' Use DataSet
      adapter = New SqlDataAdapter(sql, conn)
      Dim ds As DataSet = New DataSet()
      adapter.Fill(ds)
      DropDownList1.DataSource = ds
      DropDownList1.DataTextField = "CategoryName"
      DropDownList1.DataBind()
    End If
  End Sub

  Private Sub GetSelItem_Click(ByVal sender As System.Object, _
  ByVal e As System.EventArgs) Handles GetSelItem.Click
    Label1.Text = "Selected Item: " & _
    DropDownList1.SelectedItem.Value
  End Sub
End Class
