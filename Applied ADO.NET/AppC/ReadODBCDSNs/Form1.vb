Imports Microsoft.Win32

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
  Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.ListBox1 = New System.Windows.Forms.ListBox()
    Me.SuspendLayout()
    '
    'ListBox1
    '
    Me.ListBox1.Location = New System.Drawing.Point(16, 32)
    Me.ListBox1.Name = "ListBox1"
    Me.ListBox1.Size = New System.Drawing.Size(272, 225)
    Me.ListBox1.TabIndex = 0
    '
    'Form1
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(304, 273)
    Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.ListBox1})
    Me.Name = "Form1"
    Me.Text = "Form1"
    Me.ResumeLayout(False)

  End Sub

#End Region

  Private Sub Form1_Load(ByVal sender As System.Object, _
  ByVal e As System.EventArgs) Handles MyBase.Load
    ReadWriteRegistry()
    ReadODBCSNs()
  End Sub

  Public Sub ReadWriteRegistry()
    ' Create a new key under HKEY_LOCAL_MACHINE\Software as MCBInc 
    Dim key As RegistryKey = _
    Registry.LocalMachine.OpenSubKey("Software", True)
    ' Add one more sub key 
    Dim newkey As RegistryKey = key.CreateSubKey("MCBInc")
    ' Set value of sub key 
    newkey.SetValue("MCBInc", "NET Developer")
    ' Retrieve data from other part of the registry 
    ' find out your processor 
    Dim pRegKey As RegistryKey = Registry.LocalMachine
    Dim keyPath As String = _
      "HARDWARE\\DESCRIPTION\\System\\CentralProcessor\\0"
    pRegKey = pRegKey.OpenSubKey(keyPath)
    Dim val As Object = pRegKey.GetValue("VendorIdentifier")
    Console.WriteLine("The Processor of this machine is:" + val)
    ' Delete the key value 
    Dim delKey As RegistryKey = _
    Registry.LocalMachine.OpenSubKey("Software", True)
    delKey.DeleteSubKey("MCBInc")
  End Sub

  Private Sub ReadODBCSNs()
    Dim str As String
    Dim rootKey As RegistryKey, subKey As RegistryKey
    Dim dsnList() As String
    rootKey = Registry.LocalMachine
    str = "SOFTWARE\\ODBC\\ODBC.INI\\ODBC Data Sources"
    subKey = rootKey.OpenSubKey(str)
    dsnList = subKey.GetValueNames()
    ListBox1.Items.Add("System DSNs")
    ListBox1.Items.Add("================")
    Dim dsnName As String
    For Each dsnName In dsnList
      ListBox1.Items.Add(dsnName)
    Next
    subKey.Close()
    rootKey.Close()
    ' Load User DSNs
    rootKey = Registry.CurrentUser
    str = "SOFTWARE\\ODBC\\ODBC.INI\\ODBC Data Sources"
    subKey = rootKey.OpenSubKey(str)
    dsnList = subKey.GetValueNames()
    ListBox1.Items.Add("================")
    ListBox1.Items.Add("User DSNs")
    ListBox1.Items.Add("================")
    For Each dsnName In dsnList
      ListBox1.Items.Add(dsnName)
    Next
    subKey.Close()
    rootKey.Close()
  End Sub

End Class
