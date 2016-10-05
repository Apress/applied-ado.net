Imports System.Data
Imports System.Data.SqlClient

Public Class WebForm1
  Inherits System.Web.UI.Page
  Protected WithEvents RadioButtonList1 As System.Web.UI.WebControls.RadioButtonList
  Protected WithEvents CheckBox1 As System.Web.UI.WebControls.CheckBox
  Protected WithEvents LoadDataBtn As System.Web.UI.WebControls.Button
  Protected WithEvents Label1 As System.Web.UI.WebControls.Label
  Protected WithEvents GetSelBtn As System.Web.UI.WebControls.Button

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
      RadioButtonList1.DataSource = reader
      RadioButtonList1.DataTextField = "CategoryName"
      RadioButtonList1.DataBind()
      If Not reader.IsClosed Then
        reader.Close()
      End If
    Else
      ' Use DataSet
      adapter = New SqlDataAdapter(sql, conn)
      Dim ds As DataSet = New DataSet()
      adapter.Fill(ds)
      RadioButtonList1.DataSource = ds
      RadioButtonList1.DataTextField = "CategoryName"
      RadioButtonList1.DataBind()
    End If
  End Sub

  Private Sub GetSelBtn_Click(ByVal sender As System.Object, _
  ByVal e As System.EventArgs) Handles GetSelBtn.Click
    Label1.Text = "Selected Item: " & _
    RadioButtonList1.SelectedItem.Value
  End Sub
End Class
