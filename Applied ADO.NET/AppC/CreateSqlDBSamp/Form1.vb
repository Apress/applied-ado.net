Imports System.Data.SqlClient

Public Class Form1
  Inherits System.Windows.Forms.Form

  Private ConnectionString As String = _
  "Integrated Security=SSPI; Initial Catalog=mcbDB;Data Source=MCB;"
  Private sql As String = Nothing
  Private conn As SqlConnection = Nothing
  Private reader As SqlDataReader = Nothing
  Private cmd As SqlCommand = Nothing



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
  Friend WithEvents CreateDatabase As System.Windows.Forms.Button
  Friend WithEvents CreateTable As System.Windows.Forms.Button
  Friend WithEvents CreateSP As System.Windows.Forms.Button
  Friend WithEvents CreateView As System.Windows.Forms.Button
  Friend WithEvents AlterTable As System.Windows.Forms.Button
  Friend WithEvents ViewData As System.Windows.Forms.Button
  Friend WithEvents ViewView As System.Windows.Forms.Button
  Friend WithEvents ViewSP As System.Windows.Forms.Button
  Friend WithEvents DataGrid1 As System.Windows.Forms.DataGrid
  Friend WithEvents CreateOthers As System.Windows.Forms.Button
  Friend WithEvents DropTable As System.Windows.Forms.Button
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.CreateDatabase = New System.Windows.Forms.Button()
    Me.CreateTable = New System.Windows.Forms.Button()
    Me.CreateSP = New System.Windows.Forms.Button()
    Me.CreateView = New System.Windows.Forms.Button()
    Me.AlterTable = New System.Windows.Forms.Button()
    Me.ViewData = New System.Windows.Forms.Button()
    Me.ViewView = New System.Windows.Forms.Button()
    Me.ViewSP = New System.Windows.Forms.Button()
    Me.DataGrid1 = New System.Windows.Forms.DataGrid()
    Me.CreateOthers = New System.Windows.Forms.Button()
    Me.DropTable = New System.Windows.Forms.Button()
    CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'CreateDatabase
    '
    Me.CreateDatabase.Location = New System.Drawing.Point(8, 8)
    Me.CreateDatabase.Name = "CreateDatabase"
    Me.CreateDatabase.Size = New System.Drawing.Size(112, 32)
    Me.CreateDatabase.TabIndex = 0
    Me.CreateDatabase.Text = "Create Database"
    '
    'CreateTable
    '
    Me.CreateTable.Location = New System.Drawing.Point(136, 8)
    Me.CreateTable.Name = "CreateTable"
    Me.CreateTable.Size = New System.Drawing.Size(88, 32)
    Me.CreateTable.TabIndex = 1
    Me.CreateTable.Text = "Create Table"
    '
    'CreateSP
    '
    Me.CreateSP.Location = New System.Drawing.Point(232, 8)
    Me.CreateSP.Name = "CreateSP"
    Me.CreateSP.Size = New System.Drawing.Size(88, 32)
    Me.CreateSP.TabIndex = 2
    Me.CreateSP.Text = "Create SP"
    '
    'CreateView
    '
    Me.CreateView.Location = New System.Drawing.Point(336, 8)
    Me.CreateView.Name = "CreateView"
    Me.CreateView.Size = New System.Drawing.Size(88, 32)
    Me.CreateView.TabIndex = 3
    Me.CreateView.Text = "Create View"
    '
    'AlterTable
    '
    Me.AlterTable.Location = New System.Drawing.Point(440, 8)
    Me.AlterTable.Name = "AlterTable"
    Me.AlterTable.Size = New System.Drawing.Size(80, 32)
    Me.AlterTable.TabIndex = 4
    Me.AlterTable.Text = "Alter Table"
    '
    'ViewData
    '
    Me.ViewData.Location = New System.Drawing.Point(8, 56)
    Me.ViewData.Name = "ViewData"
    Me.ViewData.Size = New System.Drawing.Size(96, 32)
    Me.ViewData.TabIndex = 5
    Me.ViewData.Text = "View Data"
    '
    'ViewView
    '
    Me.ViewView.Location = New System.Drawing.Point(120, 56)
    Me.ViewView.Name = "ViewView"
    Me.ViewView.Size = New System.Drawing.Size(104, 32)
    Me.ViewView.TabIndex = 6
    Me.ViewView.Text = "View View"
    '
    'ViewSP
    '
    Me.ViewSP.Location = New System.Drawing.Point(248, 56)
    Me.ViewSP.Name = "ViewSP"
    Me.ViewSP.Size = New System.Drawing.Size(96, 32)
    Me.ViewSP.TabIndex = 7
    Me.ViewSP.Text = "View SP"
    '
    'DataGrid1
    '
    Me.DataGrid1.DataMember = ""
    Me.DataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText
    Me.DataGrid1.Location = New System.Drawing.Point(8, 104)
    Me.DataGrid1.Name = "DataGrid1"
    Me.DataGrid1.Size = New System.Drawing.Size(376, 224)
    Me.DataGrid1.TabIndex = 8
    '
    'CreateOthers
    '
    Me.CreateOthers.Location = New System.Drawing.Point(400, 96)
    Me.CreateOthers.Name = "CreateOthers"
    Me.CreateOthers.Size = New System.Drawing.Size(112, 32)
    Me.CreateOthers.TabIndex = 9
    Me.CreateOthers.Text = "Create Others"
    '
    'DropTable
    '
    Me.DropTable.Location = New System.Drawing.Point(400, 144)
    Me.DropTable.Name = "DropTable"
    Me.DropTable.Size = New System.Drawing.Size(112, 32)
    Me.DropTable.TabIndex = 10
    Me.DropTable.Text = "Drop Table"
    '
    'Form1
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(528, 341)
    Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.DropTable, Me.CreateOthers, Me.DataGrid1, Me.ViewSP, Me.ViewView, Me.ViewData, Me.AlterTable, Me.CreateView, Me.CreateSP, Me.CreateTable, Me.CreateDatabase})
    Me.Name = "Form1"
    Me.Text = "Form1"
    CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)

  End Sub

#End Region


  Private Sub CreateDatabase_Click(ByVal sender As System.Object, _
  ByVal e As System.EventArgs) Handles CreateDatabase.Click
    Me.Cursor.Current = Cursors.WaitCursor
    ' Construct a CREATE DATABASE command and execute it
    sql = "CREATE DATABASE mydb ON PRIMARY" & _
          "(Name=test_data, filename = 'C:\\mysql\\mydb_data.mdf', size=3," & _
          "maxsize=5, filegrowth=10%)log on" & _
          "(name=mydbb_log, filename='C:\\mysql\\mydb_log.ldf',size=3," & _
          "maxsize=20,filegrowth=1)"
    ExecuteSQLStmt(sql)
    Me.Cursor.Current = Cursors.Default
  End Sub

  Private Sub CreateTable_Click(ByVal sender As System.Object, _
  ByVal e As System.EventArgs) Handles CreateTable.Click

    sql = "CREATE TABLE myTable" & _
          "(myId INTEGER CONSTRAINT PKeyMyId PRIMARY KEY," & _
          "myName CHAR(50), myAddress CHAR(255), myBalance FLOAT)"

    ExecuteSQLStmt(sql)

    Try
      cmd.ExecuteNonQuery()

      ' Adding records the table
      sql = "INSERT INTO myTable(myId, myName, myAddress, myBalance) " & _
                    "VALUES (1001, 'Puneet Nehra', 'A 449 Sect 19, DELHI', 23.98 ) "
      ExecuteSQLStmt(sql)

      sql = "INSERT INTO myTable(myId, myName, myAddress, myBalance) " & _
                    "VALUES (1002, 'Anoop Singh', 'Lodi Road, DELHI', 353.64) "
      ExecuteSQLStmt(sql)

      sql = "INSERT INTO myTable(myId, myName, myAddress, myBalance) " & _
                    "VALUES (1003, 'Rakesh M', 'Nag Chowk, Jabalpur M.P.', 43.43) "
      ExecuteSQLStmt(sql)

      sql = "INSERT INTO myTable(myId, myName, myAddress, myBalance) " & _
                    "VALUES (1004, 'Madan Kesh', '4th Street, Lane 3, DELHI', 23.00) "
      ExecuteSQLStmt(sql)

    Catch ae As SqlException
      MessageBox.Show(ae.Message.ToString())
    End Try

  End Sub

  Private Sub CreateSP_Click(ByVal sender As System.Object, _
  ByVal e As System.EventArgs) Handles CreateSP.Click
    sql = "CREATE PROCEDURE myProc AS" & _
                " SELECT myName, myAddress FROM myTable GO"
    ExecuteSQLStmt(sql)

  End Sub

  Private Sub CreateView_Click(ByVal sender As System.Object, _
  ByVal e As System.EventArgs) Handles CreateView.Click
    sql = "CREATE VIEW myView AS SELECT myName FROM myTable"
    ExecuteSQLStmt(sql)
  End Sub

  Private Sub AlterTable_Click(ByVal sender As System.Object, _
  ByVal e As System.EventArgs) Handles AlterTable.Click
    sql = "ALTER TABLE MyTable ALTER COLUMN myName CHAR(100) NOT NULL"
    ExecuteSQLStmt(sql)
  End Sub

  Private Sub ViewData_Click(ByVal sender As System.Object, _
  ByVal e As System.EventArgs) Handles ViewData.Click
    ' Open the connection
    If conn.State = ConnectionState.Open Then
      conn.Close()
    End If
    conn.ConnectionString = ConnectionString
    Try
      conn.Open()
      ' Create a data adapter
      Dim da As SqlDataAdapter = _
      New SqlDataAdapter("SELECT * FROM myTable", conn)
      ' Create DataSet, fill it and view in data grid
      Dim ds As DataSet = New DataSet("myTable")
      da.Fill(ds, "myTable")
      DataGrid1.DataSource = ds.Tables("myTable").DefaultView
    Catch exp As SqlException
      MessageBox.Show(exp.Message.ToString())
    Finally
      conn.Close()
      conn.Dispose()
    End Try

  End Sub

  Private Sub ViewView_Click(ByVal sender As System.Object, _
  ByVal e As System.EventArgs) Handles ViewView.Click
    ' Open the connection
    If conn.State = ConnectionState.Open Then
      conn.Close()
    End If
    conn.ConnectionString = ConnectionString
    Try
      conn.Open()
      ' Create a data adapter
      Dim da As SqlDataAdapter = _
      New SqlDataAdapter("SELECT * FROM myView", conn)
      ' Create DataSet, fill it and view in data grid
      Dim ds As DataSet = New DataSet()
      da.Fill(ds)
      DataGrid1.DataSource = ds.DefaultViewManager
    Catch exp As SqlException
      MessageBox.Show(exp.Message.ToString())
    Finally
      conn.Close()
      conn.Dispose()
    End Try
  End Sub

  Private Sub ViewSP_Click(ByVal sender As System.Object, _
  ByVal e As System.EventArgs) Handles ViewSP.Click
    ' Open the connection
    If conn.State = ConnectionState.Open Then
      conn.Close()
    End If
    conn.ConnectionString = ConnectionString
    Try
      conn.Open()
      ' Create a data adapter
      Dim da As SqlDataAdapter = New SqlDataAdapter("myProc", conn)
      ' Create DataSet, fill it and view in data grid
      Dim ds As DataSet = New DataSet("SP")
      da.Fill(ds, "SP")
      DataGrid1.DataSource = ds.DefaultViewManager
    Catch exp As SqlException
      MessageBox.Show(exp.Message.ToString())
    Finally
      conn.Close()
      conn.Dispose()
    End Try
  End Sub

  Private Sub CreateOthers_Click(ByVal sender As System.Object, _
  ByVal e As System.EventArgs) Handles CreateOthers.Click
    sql = "CREATE UNIQUE CLUSTERED INDEX " & _
                "myIdx ON myTable(myName)"
    ExecuteSQLStmt(sql)

    sql = "CREATE RULE myRule " & _
                "AS @myBalance >= 32 AND @myBalance < 60"
    ExecuteSQLStmt(sql)

  End Sub

  Private Sub DropTable_Click(ByVal sender As System.Object, _
  ByVal e As System.EventArgs) Handles DropTable.Click
    sql = "DROP TABLE MyTable"
    ExecuteSQLStmt(sql)
  End Sub

  Private Sub ExecuteSQLStmt(ByVal sql As String)
    ' Open the connection
    conn = New SqlConnection()
    If conn.State = ConnectionState.Open Then
      conn.Close()
    End If
    conn.ConnectionString = ConnectionString
    conn.Open()
    cmd = New SqlCommand(sql, conn)
    Try
      cmd.ExecuteNonQuery()
    Catch ae As SqlException
      MessageBox.Show(ae.Message.ToString())
    Finally
      conn.Close()
      conn.Dispose()
    End Try
  End Sub
End Class
