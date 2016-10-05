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
  Friend WithEvents OtpimisticConcurrencyBtn As System.Windows.Forms.Button
  Friend WithEvents PessimisticConcurrencyBtn As System.Windows.Forms.Button
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.OtpimisticConcurrencyBtn = New System.Windows.Forms.Button()
    Me.PessimisticConcurrencyBtn = New System.Windows.Forms.Button()
    Me.SuspendLayout()
    '
    'OtpimisticConcurrencyBtn
    '
    Me.OtpimisticConcurrencyBtn.Location = New System.Drawing.Point(80, 56)
    Me.OtpimisticConcurrencyBtn.Name = "OtpimisticConcurrencyBtn"
    Me.OtpimisticConcurrencyBtn.Size = New System.Drawing.Size(208, 40)
    Me.OtpimisticConcurrencyBtn.TabIndex = 0
    Me.OtpimisticConcurrencyBtn.Text = "Otpimistic Concurrency"
    '
    'PessimisticConcurrencyBtn
    '
    Me.PessimisticConcurrencyBtn.Location = New System.Drawing.Point(80, 128)
    Me.PessimisticConcurrencyBtn.Name = "PessimisticConcurrencyBtn"
    Me.PessimisticConcurrencyBtn.Size = New System.Drawing.Size(216, 40)
    Me.PessimisticConcurrencyBtn.TabIndex = 1
    Me.PessimisticConcurrencyBtn.Text = "Pessimistic Concurrency"
    '
    'Form1
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(368, 273)
    Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.PessimisticConcurrencyBtn, Me.OtpimisticConcurrencyBtn})
    Me.Name = "Form1"
    Me.Text = "Form1"
    Me.ResumeLayout(False)

  End Sub

#End Region

  Private Sub TestOptimisticConcurrency()
    Dim ConnectionString As String = "Integrated Security=SSPI;" & _
     "Initial Catalog=Northwind;Data Source=MCB;"
    Dim conn As SqlConnection = New SqlConnection(ConnectionString)
    conn.Open()
    Try
      Dim da As SqlDataAdapter = New SqlDataAdapter("SELECT * FROM Orders", conn)
      Dim ds As DataSet = New DataSet("test")
      Dim updateCmd As SqlCommand = New SqlCommand()
      updateCmd.CommandText = "UPDATE Orders SET CustomerID = @CustomerID," & _
      "OrderDate = @OrderDate, ShippedDate = @ShippedDate WHERE " & _
      "(OrderID = @Original_OrderID) AND (CustomerID = @Original_CustomerID " & _
      "OR @Original_CustomerID IS NULL AND CustomerID IS NULL) AND " & _
      "(OrderDate = @Original_OrderDate OR @Original_OrderDate " & _
      "IS NULL AND OrderDate IS NULL) AND (ShippedDate = " & _
      "@Original_ShippedDate OR @Original_ShippedDate IS NULL AND " & _
      "ShippedDate IS NULL); SELECT CustomerID, OrderDate, ShippedDate, " & _
      "OrderID FROM Orders WHERE (OrderID = @OrderID)"

      updateCmd.Connection = conn
      ' CustomerID parameter
      updateCmd.Parameters.Add(New SqlParameter _
          ("@CustomerID", SqlDbType.NVarChar, 5, "CustomerID"))
      ' OrderDate parameter
      updateCmd.Parameters.Add(New SqlParameter _
          ("@OrderDate", SqlDbType.DateTime, 8, "OrderDate"))
      ' ShippedDate parameter
      updateCmd.Parameters.Add(New SqlParameter _
          ("@ShippedDate", SqlDbType.DateTime, 8, "ShippedDate"))
      updateCmd.Parameters.Add(New SqlParameter _
          ("@Original_OrderID", SqlDbType.Int, 4, _
          ParameterDirection.Input, False, _
          (CType((0), System.Byte)), (CType((0), System.Byte)), _
          "OrderID", DataRowVersion.Original, Nothing))
      updateCmd.Parameters.Add(New SqlParameter _
          ("@Original_CustomerID", SqlDbType.NVarChar, _
          5, ParameterDirection.Input, False, (CType((0), System.Byte)), _
          (CType((0), System.Byte)), "CustomerID", _
          DataRowVersion.Original, Nothing))
      updateCmd.Parameters.Add(New SqlParameter _
           ("@Original_OrderDate", SqlDbType.DateTime, _
           8, ParameterDirection.Input, False, (CType((0), System.Byte)), _
           (CType((0), System.Byte)), "OrderDate", DataRowVersion.Original, Nothing))
      updateCmd.Parameters.Add(New SqlParameter _
         ("@Original_ShippedDate", SqlDbType.DateTime, _
         8, ParameterDirection.Input, False, (CType((0), System.Byte)), _
         (CType((0), System.Byte)), "ShippedDate", _
         DataRowVersion.Original, Nothing))

      updateCmd.Parameters.Add(New SqlParameter("@OrderID", _
      SqlDbType.Int, 4, "OrderID"))

      da.UpdateCommand = updateCmd
      da.Fill(ds, "Orders")
      ' update the row in the dataset
      ds.Tables("Orders").Rows(0).BeginEdit()
      ds.Tables("Orders").Rows(0)("OrderDate") = DateTime.Now
      ds.Tables("Orders").Rows(0)("ShipCity") = "Leone"
      ds.Tables("Orders").Rows(0).EndEdit()
      ' update the row in the data Source (Orders Table)
      da.Update(ds, "Orders")
      MessageBox.Show("Finished updating first row.")
      ' close connection
      conn.Close()
      conn.Dispose()
    Catch ex As SqlException
      ' close connection
      conn.Close()
      conn.Dispose()
      MessageBox.Show(ex.Message.ToString())
    End Try
  End Sub

  Private Sub TestPessimisticConcurrency()
    Dim ConnectionString As String = "Integrated Security=SSPI;" & _
    "Initial Catalog=Northwind;Data Source=MCB;"
    Dim conn As SqlConnection = New SqlConnection(ConnectionString)
    conn.Open()
    Try
      ' Create a transaction that locks the records of the query
      Dim tr As SqlTransaction = conn.BeginTransaction _
      (IsolationLevel.RepeatableRead, "test")
      ' Create a command that updates the order of 
      ' the database using the transaction\
      Dim cmd As SqlCommand = New SqlCommand("UPDATE Orders SET " & _
          "ShippedDate = '5/10/01', ShipCity = 'Columbus' WHERE " & _
          "OrderID = 10248", conn, tr)
      ' Execute the update
      cmd.ExecuteNonQuery()
      ' Generate message
      MessageBox.Show("Wait for keypress...")
      ' transaction is committed As tr.Commit()
      conn.Close()
    Catch ex As SqlException
      MessageBox.Show(ex.Message.ToString())
    End Try
  End Sub



  Private Sub OtpimisticConcurrencyBtn_Click(ByVal sender As System.Object, _
  ByVal e As System.EventArgs) Handles OtpimisticConcurrencyBtn.Click
    TestOptimisticConcurrency()
  End Sub

  Private Sub PessimisticConcurrencyBtn_Click(ByVal sender As System.Object, _
  ByVal e As System.EventArgs) Handles PessimisticConcurrencyBtn.Click
    TestPessimisticConcurrency()
  End Sub
End Class
