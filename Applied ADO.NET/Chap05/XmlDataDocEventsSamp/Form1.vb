Imports System.Xml

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
  Friend WithEvents XmlDataDocumentBtn As System.Windows.Forms.Button
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.XmlDataDocumentBtn = New System.Windows.Forms.Button()
    Me.SuspendLayout()
    '
    'XmlDataDocumentBtn
    '
    Me.XmlDataDocumentBtn.Location = New System.Drawing.Point(56, 88)
    Me.XmlDataDocumentBtn.Name = "XmlDataDocumentBtn"
    Me.XmlDataDocumentBtn.Size = New System.Drawing.Size(200, 40)
    Me.XmlDataDocumentBtn.TabIndex = 0
    Me.XmlDataDocumentBtn.Text = "XmlDataDocument Event"
    '
    'Form1
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(292, 273)
    Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.XmlDataDocumentBtn})
    Me.Name = "Form1"
    Me.Text = "Form1"
    Me.ResumeLayout(False)

  End Sub

#End Region

  Private Sub XmlDataDocumentBtn_Click(ByVal sender As System.Object, _
  ByVal e As System.EventArgs) Handles XmlDataDocumentBtn.Click
    Dim xmlDoc As XmlDocument = New XmlDocument()
    xmlDoc.LoadXml("<Record> Some Value </Record>")
    ' Add event handlers
    AddHandler xmlDoc.NodeChanged, AddressOf NodeChangedEvent_Handler
    AddHandler xmlDoc.NodeInserted, AddressOf NodeInsertedEvent_Handler
    AddHandler xmlDoc.NodeRemoved, AddressOf NodeRemovedEvent_Handler

    Dim root As XmlElement = xmlDoc.DocumentElement
    Dim str As String = root.ToString()
    Dim xmlDocFragment As XmlDocumentFragment = xmlDoc.CreateDocumentFragment()
    xmlDocFragment.InnerXml = _
    "<Fragment><SomeData>Fragment Data</SomeData></Fragment>"
    ' Replace Node
    Dim rootNode As XmlElement = xmlDoc.DocumentElement
    rootNode.ReplaceChild(xmlDocFragment, rootNode.LastChild)
    ' Remove Node
    Dim node As XmlNode = xmlDoc.LastChild
    xmlDoc.RemoveChild(node)
    ' Remove event handlers
    RemoveHandler xmlDoc.NodeChanged, AddressOf NodeChangedEvent_Handler
    RemoveHandler xmlDoc.NodeInserted, AddressOf NodeInsertedEvent_Handler
    RemoveHandler xmlDoc.NodeRemoved, AddressOf NodeRemovedEvent_Handler
  End Sub

  ' NodeChanged event handler
  Public Sub NodeChangedEvent_Handler(ByVal src As Object, _
  ByVal args As XmlNodeChangedEventArgs)
    MessageBox.Show("Node Changed Event Fired for node " + args.Node.Name)
    If args.Node.Value <> Nothing Then
      MessageBox.Show(args.Node.Value)
    End If
  End Sub

  ' NodeInserted event handler
  Public Sub NodeInsertedEvent_Handler(ByVal src As Object, _
  ByVal args As XmlNodeChangedEventArgs)
    MessageBox.Show("Node Inserted Event Fired for node " + args.Node.Name)
    If args.Node.Value <> Nothing Then
      MessageBox.Show(args.Node.Value)
    End If
  End Sub

  ' Node Removed event handler
  Public Sub NodeRemovedEvent_Handler(ByVal src As Object, _
  ByVal args As XmlNodeChangedEventArgs)
    MessageBox.Show("Node Removed Event Fired for node " + args.Node.Name)
    If args.Node.Value <> Nothing Then
      MessageBox.Show(args.Node.Value)
    End If
  End Sub

End Class
