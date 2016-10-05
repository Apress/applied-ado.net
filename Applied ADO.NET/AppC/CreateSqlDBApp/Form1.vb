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
  Friend WithEvents DataGrid1 As System.Windows.Forms.DataGrid
  Friend WithEvents CreateDbBtn As System.Windows.Forms.Button
  Friend WithEvents CreateTableBtn As System.Windows.Forms.Button
  Friend WithEvents CreateSPBtn As System.Windows.Forms.Button
  Friend WithEvents CreateViewBtn As System.Windows.Forms.Button
  Friend WithEvents AlterTableBtn As System.Windows.Forms.Button
  Friend WithEvents ViewDataBtn As System.Windows.Forms.Button
  Friend WithEvents ViewSPBtn As System.Windows.Forms.Button
  Friend WithEvents ViewVwBtn As System.Windows.Forms.Button
  Friend WithEvents CreateOtherBtn As System.Windows.Forms.Button
  Friend WithEvents DropTblBtn As System.Windows.Forms.Button
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.DataGrid1 = New System.Windows.Forms.DataGrid()
    Me.CreateDbBtn = New System.Windows.Forms.Button()
    Me.CreateTableBtn = New System.Windows.Forms.Button()
    Me.CreateSPBtn = New System.Windows.Forms.Button()
    Me.CreateViewBtn = New System.Windows.Forms.Button()
    Me.AlterTableBtn = New System.Windows.Forms.Button()
    Me.ViewDataBtn = New System.Windows.Forms.Button()
    Me.ViewSPBtn = New System.Windows.Forms.Button()
    Me.ViewVwBtn = New System.Windows.Forms.Button()
    Me.CreateOtherBtn = New System.Windows.Forms.Button()
    Me.DropTblBtn = New System.Windows.Forms.Button()
    CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'DataGrid1
    '
    Me.DataGrid1.DataMember = ""
    Me.DataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText
    Me.DataGrid1.Location = New System.Drawing.Point(0, 88)
    Me.DataGrid1.Name = "DataGrid1"
    Me.DataGrid1.Size = New System.Drawing.Size(344, 256)
    Me.DataGrid1.TabIndex = 0
    '
    'CreateDbBtn
    '
    Me.CreateDbBtn.Location = New System.Drawing.Point(8, 8)
    Me.CreateDbBtn.Name = "CreateDbBtn"
    Me.CreateDbBtn.Size = New System.Drawing.Size(104, 24)
    Me.CreateDbBtn.TabIndex = 1
    Me.CreateDbBtn.Text = "Create Database"
    '
    'CreateTableBtn
    '
    Me.CreateTableBtn.Location = New System.Drawing.Point(120, 8)
    Me.CreateTableBtn.Name = "CreateTableBtn"
    Me.CreateTableBtn.Size = New System.Drawing.Size(96, 24)
    Me.CreateTableBtn.TabIndex = 2
    Me.CreateTableBtn.Text = "Create Tables"
    '
    'CreateSPBtn
    '
    Me.CreateSPBtn.Location = New System.Drawing.Point(232, 8)
    Me.CreateSPBtn.Name = "CreateSPBtn"
    Me.CreateSPBtn.Size = New System.Drawing.Size(80, 24)
    Me.CreateSPBtn.TabIndex = 3
    Me.CreateSPBtn.Text = "Create SP"
    '
    'CreateViewBtn
    '
    Me.CreateViewBtn.Location = New System.Drawing.Point(328, 8)
    Me.CreateViewBtn.Name = "CreateViewBtn"
    Me.CreateViewBtn.Size = New System.Drawing.Size(80, 24)
    Me.CreateViewBtn.TabIndex = 4
    Me.CreateViewBtn.Text = "Create View"
    '
    'AlterTableBtn
    '
    Me.AlterTableBtn.Location = New System.Drawing.Point(424, 8)
    Me.AlterTableBtn.Name = "AlterTableBtn"
    Me.AlterTableBtn.Size = New System.Drawing.Size(80, 24)
    Me.AlterTableBtn.TabIndex = 5
    Me.AlterTableBtn.Text = "Alter Table"
    '
    'ViewDataBtn
    '
    Me.ViewDataBtn.Location = New System.Drawing.Point(16, 48)
    Me.ViewDataBtn.Name = "ViewDataBtn"
    Me.ViewDataBtn.Size = New System.Drawing.Size(88, 24)
    Me.ViewDataBtn.TabIndex = 6
    Me.ViewDataBtn.Text = "View Data"
    '
    'ViewSPBtn
    '
    Me.ViewSPBtn.Location = New System.Drawing.Point(128, 48)
    Me.ViewSPBtn.Name = "ViewSPBtn"
    Me.ViewSPBtn.Size = New System.Drawing.Size(88, 24)
    Me.ViewSPBtn.TabIndex = 7
    Me.ViewSPBtn.Text = "View SP"
    '
    'ViewVwBtn
    '
    Me.ViewVwBtn.Location = New System.Drawing.Point(240, 48)
    Me.ViewVwBtn.Name = "ViewVwBtn"
    Me.ViewVwBtn.Size = New System.Drawing.Size(88, 24)
    Me.ViewVwBtn.TabIndex = 8
    Me.ViewVwBtn.Text = "View View"
    '
    'CreateOtherBtn
    '
    Me.CreateOtherBtn.Location = New System.Drawing.Point(368, 56)
    Me.CreateOtherBtn.Name = "CreateOtherBtn"
    Me.CreateOtherBtn.Size = New System.Drawing.Size(128, 24)
    Me.CreateOtherBtn.TabIndex = 9
    Me.CreateOtherBtn.Text = "Create Other Objects"
    '
    'DropTblBtn
    '
    Me.DropTblBtn.Location = New System.Drawing.Point(368, 104)
    Me.DropTblBtn.Name = "DropTblBtn"
    Me.DropTblBtn.Size = New System.Drawing.Size(96, 24)
    Me.DropTblBtn.TabIndex = 10
    Me.DropTblBtn.Text = "Drop Table"
    '
    'Form1
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(504, 349)
    Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.DropTblBtn, Me.CreateOtherBtn, Me.ViewVwBtn, Me.ViewSPBtn, Me.ViewDataBtn, Me.AlterTableBtn, Me.CreateViewBtn, Me.CreateSPBtn, Me.CreateTableBtn, Me.CreateDbBtn, Me.DataGrid1})
    Me.Name = "Form1"
    Me.Text = "Create SQL Server Database and Objects"
    CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)

  End Sub

#End Region

End Class
