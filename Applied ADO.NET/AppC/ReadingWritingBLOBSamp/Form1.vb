Imports System
Imports System.Data.OleDb
Imports System.IO


Public Class Form1
  Inherits System.Windows.Forms.Form


  ' User defined variables
  Private curImage As Image = Nothing
  Private curFileName As String = Nothing
  Private connectionString As String = _
    "Provider=Microsoft.Jet.OLEDB.4.0; " & _
    "Data Source=C:\\AppliedAdoNet.mdb"
  Private savedImageName As String _
    = "C:\\ImageFromDb.BMP"


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
  Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
  Friend WithEvents SaveImageBtn As System.Windows.Forms.Button
  Friend WithEvents BrowseBtn As System.Windows.Forms.Button
  Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
  Friend WithEvents UseReaderBtn As System.Windows.Forms.Button
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.TextBox1 = New System.Windows.Forms.TextBox()
    Me.BrowseBtn = New System.Windows.Forms.Button()
    Me.SaveImageBtn = New System.Windows.Forms.Button()
    Me.PictureBox1 = New System.Windows.Forms.PictureBox()
    Me.UseReaderBtn = New System.Windows.Forms.Button()
    Me.SuspendLayout()
    '
    'TextBox1
    '
    Me.TextBox1.Location = New System.Drawing.Point(8, 8)
    Me.TextBox1.Name = "TextBox1"
    Me.TextBox1.Size = New System.Drawing.Size(280, 20)
    Me.TextBox1.TabIndex = 0
    Me.TextBox1.Text = ""
    '
    'BrowseBtn
    '
    Me.BrowseBtn.Location = New System.Drawing.Point(296, 8)
    Me.BrowseBtn.Name = "BrowseBtn"
    Me.BrowseBtn.Size = New System.Drawing.Size(96, 24)
    Me.BrowseBtn.TabIndex = 1
    Me.BrowseBtn.Text = "Browse Image"
    '
    'SaveImageBtn
    '
    Me.SaveImageBtn.Location = New System.Drawing.Point(16, 40)
    Me.SaveImageBtn.Name = "SaveImageBtn"
    Me.SaveImageBtn.Size = New System.Drawing.Size(88, 24)
    Me.SaveImageBtn.TabIndex = 2
    Me.SaveImageBtn.Text = "Save Image"
    '
    'PictureBox1
    '
    Me.PictureBox1.Location = New System.Drawing.Point(16, 80)
    Me.PictureBox1.Name = "PictureBox1"
    Me.PictureBox1.Size = New System.Drawing.Size(400, 304)
    Me.PictureBox1.TabIndex = 4
    Me.PictureBox1.TabStop = False
    '
    'UseReaderBtn
    '
    Me.UseReaderBtn.Location = New System.Drawing.Point(144, 40)
    Me.UseReaderBtn.Name = "UseReaderBtn"
    Me.UseReaderBtn.Size = New System.Drawing.Size(112, 24)
    Me.UseReaderBtn.TabIndex = 5
    Me.UseReaderBtn.Text = "Read Image"
    '
    'Form1
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(432, 397)
    Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.UseReaderBtn, Me.PictureBox1, Me.SaveImageBtn, Me.BrowseBtn, Me.TextBox1})
    Me.Name = "Form1"
    Me.Text = "Reading & Writing BLOB Data"
    Me.ResumeLayout(False)

  End Sub

#End Region


  Private Sub BrowseBtn_Click(ByVal sender As System.Object, _
ByVal e As System.EventArgs) Handles BrowseBtn.Click
    Dim openDlg As OpenFileDialog = New OpenFileDialog()
    openDlg.Filter = "All Bitmap files|*.bmp"
    Dim filter As String = openDlg.Filter
    openDlg.Title = "Open a Bitmap File"
    If (openDlg.ShowDialog() = DialogResult.OK) Then
      curFileName = openDlg.FileName
      TextBox1.Text = curFileName
    End If
  End Sub

  Private Sub SaveImageBtn_Click(ByVal sender As System.Object, _
  ByVal e As System.EventArgs) Handles SaveImageBtn.Click

    If TextBox1.Text Is String.Empty Then
      MessageBox.Show("Browse a bitmap")
      Return
    End If
    ' Read a bitmap contents in a stream
    Dim fs As FileStream = New FileStream(curFileName, _
  FileMode.OpenOrCreate, FileAccess.Read)
    Dim rawData() As Byte = New Byte(fs.Length) {}
    fs.Read(rawData, 0, System.Convert.ToInt32(fs.Length))
    fs.Close()
    ' Construct a SQL string and a connection object
    Dim sql As String = "SELECT * FROM Users"
    Dim conn As OleDbConnection = New OleDbConnection()
    conn.ConnectionString = connectionString
    ' Open connection
    If conn.State <> ConnectionState.Open Then
      conn.Open()
    End If
    ' Create a data adapter and data set
    Dim adapter As OleDbDataAdapter = _
      New OleDbDataAdapter(sql, conn)
    Dim cmdBuilder As OleDbCommandBuilder = _
      New OleDbCommandBuilder(adapter)
    Dim ds As DataSet = New DataSet("Users")
    adapter.MissingSchemaAction = MissingSchemaAction.AddWithKey

    ' Fill data adapter
    adapter.Fill(ds, "Users")

    Dim userDes As String = _
      "Mahesh Chand is a founder of C# Corner "
    userDes += "Author: 1. A Programmer's Guide to ADO.NET;"
    userDes += ", 2. Applied ADO.NET. "

    ' Create a new row
    Dim row As DataRow = ds.Tables("Users").NewRow()
    row("UserName") = "Mahesh Chand"
    row("UserEmail") = "mcb@mindcracker.com"
    row("UserDescription") = userDes
    row("UserPhoto") = rawData
    ' Add row to the collection
    ds.Tables("Users").Rows.Add(row)
    ' Save changes to the database
    adapter.Update(ds, "Users")
    ' Clean up connection
    If conn Is Nothing Then
      If conn.State = ConnectionState.Open Then
        conn.Close()
      End If
      ' Dispose connection
      conn.Dispose()
    End If
    MessageBox.Show("Image Saved")
  End Sub

  Public Sub ReadImgUsingReader()


  End Sub

  Private Sub UseReaderBtn_Click(ByVal sender As System.Object, _
ByVal e As System.EventArgs) Handles UseReaderBtn.Click

    ' Construct a SQL string and a connection object
    Dim sql As String = "SELECT UserPhoto FROM Users"
    Dim conn As OleDbConnection = New OleDbConnection()
    conn.ConnectionString = connectionString
    ' Open connection
    If conn.State <> ConnectionState.Open Then
      conn.Open()
    End If

    Dim cmd As OleDbCommand = New OleDbCommand(sql, conn)
    Dim fs As FileStream
    Dim bw As BinaryWriter
    Dim bufferSize As Integer = 300000
    Dim outbyte(300000 - 1) As Byte
    Dim retval As Long
    Dim startIndex As Long = 0
    Dim pub_id As String = ""
    Dim reader As OleDbDataReader = _
        cmd.ExecuteReader(CommandBehavior.SequentialAccess)
    ' Read first record
    reader.Read()
    fs = New FileStream(savedImageName, _
    FileMode.OpenOrCreate, FileAccess.Write)
    bw = New BinaryWriter(fs)
    startIndex = 0
    retval = reader.GetBytes(0, 0, outbyte, 0, bufferSize)
    bw.Write(outbyte)
    bw.Flush()
    ' Close the output file.
    bw.Close()
    fs.Close()
    reader.Close()
    ' Display image 
    curImage = Image.FromFile(savedImageName)
    PictureBox1.Image = curImage
    PictureBox1.Invalidate()
    ' Clean up connection
    If conn.State = ConnectionState.Open Then
      conn.Close()
      ' Dispose connection
      conn.Dispose()
    End If
  End Sub
End Class
