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
  Friend WithEvents MainMenu1 As System.Windows.Forms.MainMenu
  Friend WithEvents MenuItem1 As System.Windows.Forms.MenuItem
  Friend WithEvents CloseMenu As System.Windows.Forms.MenuItem
  Friend WithEvents OpenSQLDbMenu As System.Windows.Forms.MenuItem
  Friend WithEvents StatusBar1 As System.Windows.Forms.StatusBar
  Friend WithEvents CreateAccessDBMenu As System.Windows.Forms.MenuItem
  Friend WithEvents CreateSqlDBMenu As System.Windows.Forms.MenuItem
  Friend WithEvents OpenAccessDBMenu As System.Windows.Forms.MenuItem
  Friend WithEvents ToolBar1 As System.Windows.Forms.ToolBar
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.MainMenu1 = New System.Windows.Forms.MainMenu()
    Me.MenuItem1 = New System.Windows.Forms.MenuItem()
    Me.OpenSQLDbMenu = New System.Windows.Forms.MenuItem()
    Me.CloseMenu = New System.Windows.Forms.MenuItem()
    Me.StatusBar1 = New System.Windows.Forms.StatusBar()
    Me.CreateAccessDBMenu = New System.Windows.Forms.MenuItem()
    Me.CreateSqlDBMenu = New System.Windows.Forms.MenuItem()
    Me.OpenAccessDBMenu = New System.Windows.Forms.MenuItem()
    Me.ToolBar1 = New System.Windows.Forms.ToolBar()
    Me.SuspendLayout()
    '
    'MainMenu1
    '
    Me.MainMenu1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem1})
    '
    'MenuItem1
    '
    Me.MenuItem1.Index = 0
    Me.MenuItem1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.OpenSQLDbMenu, Me.OpenAccessDBMenu, Me.CreateSqlDBMenu, Me.CreateAccessDBMenu, Me.CloseMenu})
    Me.MenuItem1.Text = "File"
    '
    'OpenSQLDbMenu
    '
    Me.OpenSQLDbMenu.Index = 0
    Me.OpenSQLDbMenu.Text = "Open SQL Server Database"
    '
    'CloseMenu
    '
    Me.CloseMenu.Index = 4
    Me.CloseMenu.Text = "Close"
    '
    'StatusBar1
    '
    Me.StatusBar1.Location = New System.Drawing.Point(0, 375)
    Me.StatusBar1.Name = "StatusBar1"
    Me.StatusBar1.Size = New System.Drawing.Size(624, 22)
    Me.StatusBar1.TabIndex = 0
    Me.StatusBar1.Text = "Current Status:"
    '
    'CreateAccessDBMenu
    '
    Me.CreateAccessDBMenu.Index = 3
    Me.CreateAccessDBMenu.Text = "Create Access Database"
    '
    'CreateSqlDBMenu
    '
    Me.CreateSqlDBMenu.Index = 2
    Me.CreateSqlDBMenu.Text = "Create SQL Server Database"
    '
    'OpenAccessDBMenu
    '
    Me.OpenAccessDBMenu.Index = 1
    Me.OpenAccessDBMenu.Text = "Open Access Database"
    '
    'ToolBar1
    '
    Me.ToolBar1.DropDownArrows = True
    Me.ToolBar1.Name = "ToolBar1"
    Me.ToolBar1.ShowToolTips = True
    Me.ToolBar1.Size = New System.Drawing.Size(624, 39)
    Me.ToolBar1.TabIndex = 1
    '
    'Form1
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
    Me.BackColor = System.Drawing.SystemColors.Desktop
    Me.ClientSize = New System.Drawing.Size(624, 397)
    Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.ToolBar1, Me.StatusBar1})
    Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
    Me.Menu = Me.MainMenu1
    Me.Name = "Form1"
    Me.Text = "ADO.NET Database Explorer Ver 1.0"
    Me.ResumeLayout(False)

  End Sub

#End Region

  Private Sub OpenSQLDbMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenSQLDbMenu.Click

  End Sub

  Private Sub OpenAccessDBMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenAccessDBMenu.Click

  End Sub

  Private Sub CreateSqlDBMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CreateSqlDBMenu.Click

  End Sub

  Private Sub CreateAccessDBMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CreateAccessDBMenu.Click

  End Sub

  Private Sub CloseMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CloseMenu.Click

  End Sub
End Class
