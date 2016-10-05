Imports System.Data
Imports System.Data.SqlClient

Public Class Form1
  Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

  Public Sub New()
    MyBase.New()

    'This call is required by the Windows Form Designer.
    InitializeComponent()

    'Add any initialization after the InitializeComponent() call

  End Sub

  'Form overrides dispose to clean up the component list.
  Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
    If disposing Then
      If Not (components Is Nothing) Then
        components.Dispose()
      End If
    End If
    MyBase.Dispose(disposing)
  End Sub

  'Required by the Windows Form Designer
  Private components As System.ComponentModel.IContainer

  'NOTE: The following procedure is required by the Windows Form Designer
  'It can be modified using the Windows Form Designer.  
  'Do not modify it using the code editor.
  Friend WithEvents DataGrid1 As System.Windows.Forms.DataGrid
  Friend WithEvents Button1 As System.Windows.Forms.Button
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.DataGrid1 = New System.Windows.Forms.DataGrid()
    Me.Button1 = New System.Windows.Forms.Button()
    CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'DataGrid1
    '
    Me.DataGrid1.DataMember = ""
    Me.DataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText
    Me.DataGrid1.Location = New System.Drawing.Point(8, 40)
    Me.DataGrid1.Name = "DataGrid1"
    Me.DataGrid1.Size = New System.Drawing.Size(304, 232)
    Me.DataGrid1.TabIndex = 0
    '
    'Button1
    '
    Me.Button1.Location = New System.Drawing.Point(160, 0)
    Me.Button1.Name = "Button1"
    Me.Button1.Size = New System.Drawing.Size(80, 32)
    Me.Button1.TabIndex = 1
    Me.Button1.Text = "Fill"
    '
    'Form1
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(320, 273)
    Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.Button1, Me.DataGrid1})
    Me.Name = "Form1"
    Me.Text = "Form1"
    CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)

  End Sub

#End Region

  Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

    ' Create a Connection Object
    Dim ConnectionString As String
    Dim sql As String

    ConnectionString = "Integrated Security=SSPI; Initial Catalog=Northwind;Data Source=localhost;"

    Dim myConnection As SqlConnection = New SqlConnection()
    myConnection.ConnectionString = ConnectionString
    sql = "SELECT CustomerID, ContactName, ContactTitle FROM Customers"
    Dim adapter As SqlDataAdapter = New SqlDataAdapter(sql, myConnection)
    ' Construct the DataSet and fill it
    Dim dtSet As DataSet = New DataSet("Customers")
    adapter.Fill(dtSet, "Customers")
    ' Bind the Listbox to the DataSet
    DataGrid1.DataSource = dtSet.DefaultViewManager

  End Sub
End Class



