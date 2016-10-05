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
  Friend WithEvents SqlConnection1 As System.Data.SqlClient.SqlConnection
  Friend WithEvents OpenBtn As System.Windows.Forms.Button
  Friend WithEvents CloseBtn As System.Windows.Forms.Button
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.SqlConnection1 = New System.Data.SqlClient.SqlConnection()
    Me.OpenBtn = New System.Windows.Forms.Button()
    Me.CloseBtn = New System.Windows.Forms.Button()
    Me.SuspendLayout()
    '
    'SqlConnection1
    '
    '
    'OpenBtn
    '
    Me.OpenBtn.Location = New System.Drawing.Point(80, 32)
    Me.OpenBtn.Name = "OpenBtn"
    Me.OpenBtn.Size = New System.Drawing.Size(144, 32)
    Me.OpenBtn.TabIndex = 0
    Me.OpenBtn.Text = "Open"
    '
    'CloseBtn
    '
    Me.CloseBtn.Location = New System.Drawing.Point(80, 88)
    Me.CloseBtn.Name = "CloseBtn"
    Me.CloseBtn.Size = New System.Drawing.Size(144, 32)
    Me.CloseBtn.TabIndex = 1
    Me.CloseBtn.Text = "Close"
    '
    'Form1
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(328, 273)
    Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.CloseBtn, Me.OpenBtn})
    Me.Name = "Form1"
    Me.Text = "Form1"
    Me.ResumeLayout(False)

  End Sub

#End Region


  ' The InfoMessage event handler
  Private Sub SqlConnection1_InfoMessage(ByVal sender As System.Object, _
  ByVal e As System.Data.SqlClient.SqlInfoMessageEventArgs) _
  Handles SqlConnection1.InfoMessage
    Dim err As SqlError
    For Each err In e.Errors
      MessageBox.Show(err.Source.ToString() + err.State.ToString() & _
       err.Source.ToString() + err.Message.ToString())
    Next
  End Sub
  'The state change event handler
  Private Sub SqlConnection1_StateChange(ByVal sender As System.Object, _
  ByVal e As System.Data.StateChangeEventArgs) _
  Handles SqlConnection1.StateChange
    MessageBox.Show("Original State: " + e.OriginalState.ToString() & _
       ", Current State :" + e.CurrentState.ToString())
  End Sub

  ' Open button click event handler
  Private Sub OpenBtn_Click(ByVal sender As System.Object, _
  ByVal e As System.EventArgs) Handles OpenBtn.Click
    ' Create a Connection Object
    Dim ConnectionString As String = "Integrated Security=SSPI;" & _
     "Initial Catalog=Northwind;Data Source=MCB;"
    SqlConnection1.ConnectionString = ConnectionString
    ' Open the connection
    If SqlConnection1.State <> ConnectionState.Open Then
      SqlConnection1.Open()
    End If
  End Sub
  ' Close button click event handler
  Private Sub CloseBtn_Click(ByVal sender As System.Object, _
  ByVal e As System.EventArgs) Handles CloseBtn.Click
    Try
      SqlConnection1.Close()
    Catch exp As SqlException
      MessageBox.Show(exp.Message.ToString())
    End Try
  End Sub
End Class
