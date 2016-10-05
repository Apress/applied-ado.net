Imports System
Imports System.Data
Imports System.IO
Imports Microsoft.Data.SqlXml

Class Form1
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
  Friend WithEvents FillDataBtn As System.Windows.Forms.Button
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.DataGrid1 = New System.Windows.Forms.DataGrid()
    Me.FillDataBtn = New System.Windows.Forms.Button()
    CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'DataGrid1
    '
    Me.DataGrid1.DataMember = ""
    Me.DataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText
    Me.DataGrid1.Location = New System.Drawing.Point(8, 88)
    Me.DataGrid1.Name = "DataGrid1"
    Me.DataGrid1.Size = New System.Drawing.Size(408, 216)
    Me.DataGrid1.TabIndex = 0
    '
    'FillDataBtn
    '
    Me.FillDataBtn.Location = New System.Drawing.Point(16, 16)
    Me.FillDataBtn.Name = "FillDataBtn"
    Me.FillDataBtn.Size = New System.Drawing.Size(80, 24)
    Me.FillDataBtn.TabIndex = 1
    Me.FillDataBtn.Text = "Fill Data"
    '
    'Form1
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(432, 317)
    Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.FillDataBtn, Me.DataGrid1})
    Me.Name = "Form1"
    Me.Text = "SqlXmlDataAdapter Sample"
    CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)

  End Sub

#End Region

  Private Sub FillDataBtn_Click(ByVal sender As System.Object, _
  ByVal e As System.EventArgs) Handles FillDataBtn.Click
    Dim connectionString As String = _
    "provider=sqloledb;server=mcb;database=Northwind;uid=sa;password=;"
    Dim row As DataRow
    Dim adapter As SqlXmlAdapter
    Dim cmd As SqlXmlCommand = New SqlXmlCommand(connectionString)
    cmd.RootTag = "ROOT"
    cmd.CommandText = "EmployeeElement"
    cmd.CommandType = SqlXmlCommandType.XPath
    cmd.SchemaPath = "xmlDoc.xml"
    Dim ds As DataSet = New DataSet()
    adapter = New SqlXmlAdapter(cmd)
    adapter.Fill(ds)
    row = ds.Tables(0).Rows(0)
    row("FName") = "New FName"
    row("LName") = "New LName"
    adapter.Update(ds)
    DataGrid1.DataSource = ds.Tables(0)
  End Sub
End Class
