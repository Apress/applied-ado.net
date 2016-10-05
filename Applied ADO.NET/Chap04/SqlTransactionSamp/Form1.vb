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
  Friend WithEvents Button2 As System.Windows.Forms.Button
  Friend WithEvents DataGrid1 As System.Windows.Forms.DataGrid
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.Button1 = New System.Windows.Forms.Button()
    Me.Button2 = New System.Windows.Forms.Button()
    Me.SuspendLayout()
    '
    'Button1
    '
    Me.Button1.Location = New System.Drawing.Point(48, 24)
    Me.Button1.Name = "Button1"
    Me.Button1.Size = New System.Drawing.Size(176, 40)
    Me.Button1.TabIndex = 0
    Me.Button1.Text = "SavePoints Test"
    '
    'Button2
    '
    Me.Button2.Location = New System.Drawing.Point(48, 96)
    Me.Button2.Name = "Button2"
    Me.Button2.Size = New System.Drawing.Size(184, 40)
    Me.Button2.TabIndex = 1
    Me.Button2.Text = "Execute Batches"
    '
    'Form1
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(292, 165)
    Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.Button2, Me.Button1})
    Me.Name = "Form1"
    Me.Text = "Form1"
    Me.ResumeLayout(False)

  End Sub

#End Region

  Private Sub Button1_Click(ByVal sender As System.Object, _
  ByVal e As System.EventArgs) Handles Button1.Click
    Dim ConnectionString As String = "Integrated Security=SSPI;" & _
    "Initial Catalog=Northwind;Data Source=MCB;"
    Dim conn As SqlConnection = New SqlConnection(ConnectionString)
    Dim tran As SqlTransaction = Nothing

    Try
      conn.Open()
      tran = conn.BeginTransaction("Transaction1")
      Dim cmd As SqlCommand = New SqlCommand( _
      "INSERT INTO Customers (CustomerID, ContactName, CompanyName)" & _
             "VALUES (516, 'Tim Howard', 'FireCon')", conn, tran)
      ' Call Save method
      tran.Save("save1")
      cmd.ExecuteNonQuery()
      MessageBox.Show("Tim is in the Database")
      cmd.CommandText = _
      "INSERT INTO Customers (CustomerID, ContactName, CompanyName)" & _
      "VALUES (517, 'Bob Hope', 'Hollywood')"
      ' Call Save again
      tran.Save("save2")
      cmd.ExecuteNonQuery()
      MessageBox.Show("Bob is in the Database")
      cmd.CommandText = _
      "INSERT INTO Customers(CustomerID, ContactName, CompanyName)" & _
      "VALUES (518, 'Fred Astaire', 'Hollywood')"
      MessageBox.Show("Fred is in the Database")
      ' Save
      tran.Save("save3")
      cmd.ExecuteNonQuery()
      ' rollback
      tran.Rollback("save2")
      ' Commit the transaction
      tran.Commit()
      MessageBox.Show("Transaction Rolledback, only Tim Made it.")
      conn.Close()
      conn.Dispose()
    Catch exp As Exception
      If tran Is Nothing Then
        tran.Rollback()
      End If
      MessageBox.Show(exp.Message.ToString() & _
           "Transaction Rolledback, Tim didn't make it.")
    Finally
      conn.Close()
      conn.Dispose()
    End Try
  End Sub

  Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

    Dim ConnectionString As String = "Integrated Security=SSPI;" & _
   "Initial Catalog=Northwind;Data Source=MCB;"
    Dim conn As SqlConnection = New SqlConnection(ConnectionString)

    ' Open the connection
    conn.Open()
    ' Create SqlCommand and SqlTransaction objects
    Dim myCommand As New SqlCommand()
    Dim trans As SqlTransaction = Nothing
    ' Create a local transaction using BeginTransaction
    ' All changes inside this transaction will be saves or rollback
    ' after a call of Commit or Rollback
    trans = conn.BeginTransaction()
    myCommand.Connection = conn
    myCommand.Transaction = trans

    Try
      myCommand.CommandText = _
      "INSERT INTO Employees (FirstName, LastName, Address, City) " & _
      " VALUES ('Sundar', 'Lal','234 Lane, Rose Blvd', 'Chester')"
      myCommand.ExecuteNonQuery()
      myCommand.CommandText = _
      "INSERT INTO Employees (FirstName, LastName, Address, City) " & _
      " VALUES ('Dinesh', 'Chand', '23rd Streed, Old Road', 'Delhi')"
      myCommand.ExecuteNonQuery()
      myCommand.CommandText = _
     "INSERT INTO Employees (FirstName, LastName, Address, City) " & _
     " VALUES ('Rajesh', 'Kumar', '278 Meadowlake Drive', 'Downingtown')"
      myCommand.ExecuteNonQuery()
      If MessageBox.Show("Save Changes?", "SqlTransaction Commit Rollback", _
      MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) _
      = MessageBoxDefaultButton.Button1 Then
        ' Commit transaction and save changes
        trans.Commit()
      Else
        ' Rollback transaction
        trans.Rollback()
      End If
    Catch exp As Exception
      Dim str As String = "Message :" + exp.Message
      str = str + "Source :" + exp.Source
      MessageBox.Show(str)
    Finally
      conn.Close()
      conn.Dispose()
    End Try

  End Sub

  Private Sub Form1_Load(ByVal sender As System.Object, _
  ByVal e As System.EventArgs) Handles MyBase.Load

  End Sub
End Class
