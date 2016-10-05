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
  Friend WithEvents MergetFailedEventBtn As System.Windows.Forms.Button
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.MergetFailedEventBtn = New System.Windows.Forms.Button()
    Me.SuspendLayout()
    '
    'MergetFailedEventBtn
    '
    Me.MergetFailedEventBtn.Location = New System.Drawing.Point(56, 56)
    Me.MergetFailedEventBtn.Name = "MergetFailedEventBtn"
    Me.MergetFailedEventBtn.Size = New System.Drawing.Size(200, 32)
    Me.MergetFailedEventBtn.TabIndex = 0
    Me.MergetFailedEventBtn.Text = "MergetFailedEvent Button"
    '
    'Form1
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(292, 273)
    Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.MergetFailedEventBtn})
    Me.Name = "Form1"
    Me.Text = "Form1"
    Me.ResumeLayout(False)

  End Sub

#End Region

  Private Sub MergetFailedEventBtn_Click(ByVal sender As System.Object, _
  ByVal e As System.EventArgs) Handles MergetFailedEventBtn.Click
    Dim ConnectionString As String = "Integrated Security=SSPI;" & _
    "Initial Catalog=Northwind;Data Source=MCB;"
    Dim conn As SqlConnection = New SqlConnection()
    conn.ConnectionString = ConnectionString
    Dim sql As String = "SELECT * FROM Employees"
    Dim da As SqlDataAdapter = New SqlDataAdapter(sql, conn)
    Dim ds1 As DataSet = New DataSet()
    da.Fill(ds1)
    sql = "SELECT * FROM Customers"
    da = New SqlDataAdapter(sql, conn)
    Dim ds2 As DataSet = New DataSet()
    da.Fill(ds2)
    ' Add MergeFailed Event handler
    AddHandler ds1.MergeFailed, New MergeFailedEventHandler _
    (AddressOf DataSetMergeFailed)
    ds1.Merge(ds2)
    ' Remove the MergeFailed handler
    RemoveHandler ds1.MergeFailed, AddressOf DataSetMergeFailed
    conn.Close()
    conn.Dispose()
  End Sub
  ' MergeFailed event handler
  Private Shared Sub DataSetMergeFailed(ByVal sender As Object, _
  ByVal args As MergeFailedEventArgs)
    MessageBox.Show("Merge failed for table " & args.Table.TableName & _
    "Conflict = " & args.Conflict)
  End Sub


End Class
