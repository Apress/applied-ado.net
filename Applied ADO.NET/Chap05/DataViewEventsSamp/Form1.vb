Imports System.Windows.Forms
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
  Friend WithEvents Button1 As System.Windows.Forms.Button
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.Button1 = New System.Windows.Forms.Button()
    Me.SuspendLayout()
    '
    'Button1
    '
    Me.Button1.Location = New System.Drawing.Point(72, 88)
    Me.Button1.Name = "Button1"
    Me.Button1.Size = New System.Drawing.Size(176, 40)
    Me.Button1.TabIndex = 0
    Me.Button1.Text = "DataView Event "
    '
    'Form1
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(292, 273)
    Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.Button1})
    Me.Name = "Form1"
    Me.Text = "Form1"
    Me.ResumeLayout(False)

  End Sub

#End Region

  Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    Dim ConnectionString As String = "Integrated Security=SSPI;" & _
   "Initial Catalog=Northwind;Data Source=MCB;"
    Dim conn As SqlConnection = New SqlConnection()
    conn.ConnectionString = ConnectionString
    ' Open the connection
    conn.Open()
    Dim sql As String = "SELECT EmployeeId, LastName, FirstName FROM Employees"
    ' Create a data adapter
    Dim da As SqlDataAdapter = New SqlDataAdapter(sql, conn)
    ' Create and Fill DataSet            
    Dim ds As DataSet = New DataSet()
    da.Fill(ds, "Employees")
    Dim dv As DataView = ds.Tables("Employees").DefaultView
    ' Add DataView Event Handlers
    AddHandler dv.ListChanged, New System.ComponentModel.ListChangedEventHandler _
    (AddressOf OnListChanged_Handler)

    ' Add a row to the DataView
    dv.AllowEdit = True
    Dim rw As DataRowView = dv.AddNew()
    rw.BeginEdit()
    rw("FirstName") = "FName"
    rw("LastName") = "LName"
    rw.EndEdit()
    ' Remove a row from the DataView
    If dv.Count > 0 Then
      dv.Delete(0)
      dv(0).Row.AcceptChanges()
    End If
    ' Close the connection
    conn.Close()
    conn.Dispose()
    ' Remove DataView Event Handlers
    RemoveHandler dv.ListChanged, AddressOf OnListChanged_Handler
  End Sub

  Public Sub OnListChanged_Handler(ByVal src As Object, _
   ByVal args As System.ComponentModel.ListChangedEventArgs)
    MessageBox.Show("ListChanged: Type = " + args.ListChangedType & _
    ", OldIndex = " + args.OldIndex & _
    ", NewIndex = " + args.NewIndex)
  End Sub


  Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

  End Sub
End Class
