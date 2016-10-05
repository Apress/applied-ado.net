Imports System.Data.SqlClient

Public Class Form1
  Inherits System.Windows.Forms.Form

  ' Developer defined variables
  Private conn As SqlConnection = Nothing
  Private connectionString As String = _
   "Integrated Security=SSPI;Initial Catalog=Northwind;Data Source=MCB;"
  Private sql As String = Nothing
  Private recordSet As CustRecordSet = Nothing


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
  Friend WithEvents MoveFirstBtn As System.Windows.Forms.Button
  Friend WithEvents MovePrevBtn As System.Windows.Forms.Button
  Friend WithEvents MoveNextBtn As System.Windows.Forms.Button
  Friend WithEvents MoveLastBtn As System.Windows.Forms.Button
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.DataGrid1 = New System.Windows.Forms.DataGrid()
    Me.MoveFirstBtn = New System.Windows.Forms.Button()
    Me.MovePrevBtn = New System.Windows.Forms.Button()
    Me.MoveNextBtn = New System.Windows.Forms.Button()
    Me.MoveLastBtn = New System.Windows.Forms.Button()
    CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'DataGrid1
    '
    Me.DataGrid1.DataMember = ""
    Me.DataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText
    Me.DataGrid1.Location = New System.Drawing.Point(8, 40)
    Me.DataGrid1.Name = "DataGrid1"
    Me.DataGrid1.Size = New System.Drawing.Size(384, 232)
    Me.DataGrid1.TabIndex = 0
    '
    'MoveFirstBtn
    '
    Me.MoveFirstBtn.Location = New System.Drawing.Point(8, 8)
    Me.MoveFirstBtn.Name = "MoveFirstBtn"
    Me.MoveFirstBtn.Size = New System.Drawing.Size(88, 24)
    Me.MoveFirstBtn.TabIndex = 1
    Me.MoveFirstBtn.Text = "Move First"
    '
    'MovePrevBtn
    '
    Me.MovePrevBtn.Location = New System.Drawing.Point(96, 8)
    Me.MovePrevBtn.Name = "MovePrevBtn"
    Me.MovePrevBtn.Size = New System.Drawing.Size(96, 24)
    Me.MovePrevBtn.TabIndex = 2
    Me.MovePrevBtn.Text = "Move Previous"
    '
    'MoveNextBtn
    '
    Me.MoveNextBtn.Location = New System.Drawing.Point(224, 8)
    Me.MoveNextBtn.Name = "MoveNextBtn"
    Me.MoveNextBtn.Size = New System.Drawing.Size(80, 24)
    Me.MoveNextBtn.TabIndex = 3
    Me.MoveNextBtn.Text = "Move Next"
    '
    'MoveLastBtn
    '
    Me.MoveLastBtn.Location = New System.Drawing.Point(304, 8)
    Me.MoveLastBtn.Name = "MoveLastBtn"
    Me.MoveLastBtn.Size = New System.Drawing.Size(72, 24)
    Me.MoveLastBtn.TabIndex = 4
    Me.MoveLastBtn.Text = "Move Last"
    '
    'Form1
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(392, 273)
    Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.MoveLastBtn, Me.MoveNextBtn, Me.MovePrevBtn, Me.MoveFirstBtn, Me.DataGrid1})
    Me.Name = "Form1"
    Me.Text = "DataGrid Navigation System"
    CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)

  End Sub

#End Region

  ' form load 
  Private Sub Form1_Load(ByVal sender As System.Object, _
  ByVal e As System.EventArgs) Handles MyBase.Load
    FillDataGrid()
  End Sub
  ' Fill DataGrid
  Private Sub FillDataGrid()
    sql = "SELECT * FROM Customers"
    conn = New SqlConnection(connectionString)
    recordSet = New CustRecordSet()
    recordSet.CreateRecordSet(conn, sql, DataGrid1, Me, "Customers")
  End Sub
  ' Move First button click
  Private Sub MoveFirstBtn_Click(ByVal sender As System.Object, _
  ByVal e As System.EventArgs) Handles MoveFirstBtn.Click
    recordSet.FirstRecord()
  End Sub
  ' Move Previous button click
  Private Sub MovePrevBtn_Click(ByVal sender As System.Object, _
  ByVal e As System.EventArgs) Handles MovePrevBtn.Click
    recordSet.PrevRecord()
  End Sub
  ' Move next button click 
  Private Sub MoveNextBtn_Click(ByVal sender As System.Object, _
  ByVal e As System.EventArgs) Handles MoveNextBtn.Click
    recordSet.NextRecord()
  End Sub
  ' Move last button click 
  Private Sub MoveLastBtn_Click(ByVal sender As System.Object, _
  ByVal e As System.EventArgs) Handles MoveLastBtn.Click
    recordSet.LastRecord()
  End Sub

End Class



