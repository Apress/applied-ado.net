Imports System.Data.SqlClient
Imports System.Windows.Forms

Public Class Form1
  Inherits System.Windows.Forms.Form

  Private ConnectionString As String = "Integrated Security=SSPI;" & _
    "Initial Catalog=Northwind;Data Source=MCB;"
  Private conn As SqlConnection = Nothing
  Private sql As String = Nothing
  Private adapter As SqlDataAdapter = Nothing
  Private ds As DataSet = Nothing
  Private curColName As String = Nothing
  Private curColumnStyle As DataGridColumnStyle


  Friend WithEvents popUpMenu As ContextMenu
  Friend WithEvents sortAscMenu As MenuItem
  Friend WithEvents sortDescMenu As MenuItem
  Friend WithEvents findMenu As MenuItem
  Friend WithEvents hideMenu As MenuItem

  Friend WithEvents popUpMenu2 As ContextMenu
  Friend WithEvents moveFirstMenu As MenuItem
  Friend WithEvents moveNextMenu As MenuItem
  Friend WithEvents moveLastMenu As MenuItem
  Friend WithEvents movePrevMenu As MenuItem


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
  Friend WithEvents CreateDtGridMenu As System.Windows.Forms.MenuItem
  Friend WithEvents dtGrid As System.Windows.Forms.DataGrid
  Friend WithEvents NavigationMenu As System.Windows.Forms.MenuItem
  Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents allowNavigationCheckBox As System.Windows.Forms.CheckBox
  Friend WithEvents allowSortingCheckBox As System.Windows.Forms.CheckBox
  Friend WithEvents borderStyleCombo As System.Windows.Forms.ComboBox
  Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
  Friend WithEvents ColorPropBtn As System.Windows.Forms.Button
  Friend WithEvents CaptionPropBtn As System.Windows.Forms.Button
  Friend WithEvents ApplyBtn As System.Windows.Forms.Button
  Friend WithEvents flatModeCheckBox As System.Windows.Forms.CheckBox
  Friend WithEvents chVisibleCheckBox As System.Windows.Forms.CheckBox
  Friend WithEvents readOnlyCheckBox As System.Windows.Forms.CheckBox
  Friend WithEvents statusLabel As System.Windows.Forms.Label
  Friend WithEvents gridLinesCheckBox As System.Windows.Forms.CheckBox
  Friend WithEvents MenuItem2 As System.Windows.Forms.MenuItem
  Friend WithEvents ReshuffleCols As System.Windows.Forms.MenuItem
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.MainMenu1 = New System.Windows.Forms.MainMenu()
    Me.MenuItem1 = New System.Windows.Forms.MenuItem()
    Me.CreateDtGridMenu = New System.Windows.Forms.MenuItem()
    Me.NavigationMenu = New System.Windows.Forms.MenuItem()
    Me.MenuItem2 = New System.Windows.Forms.MenuItem()
    Me.ReshuffleCols = New System.Windows.Forms.MenuItem()
    Me.dtGrid = New System.Windows.Forms.DataGrid()
    Me.GroupBox1 = New System.Windows.Forms.GroupBox()
    Me.gridLinesCheckBox = New System.Windows.Forms.CheckBox()
    Me.readOnlyCheckBox = New System.Windows.Forms.CheckBox()
    Me.chVisibleCheckBox = New System.Windows.Forms.CheckBox()
    Me.flatModeCheckBox = New System.Windows.Forms.CheckBox()
    Me.allowSortingCheckBox = New System.Windows.Forms.CheckBox()
    Me.allowNavigationCheckBox = New System.Windows.Forms.CheckBox()
    Me.borderStyleCombo = New System.Windows.Forms.ComboBox()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.GroupBox2 = New System.Windows.Forms.GroupBox()
    Me.ColorPropBtn = New System.Windows.Forms.Button()
    Me.CaptionPropBtn = New System.Windows.Forms.Button()
    Me.ApplyBtn = New System.Windows.Forms.Button()
    Me.statusLabel = New System.Windows.Forms.Label()
    CType(Me.dtGrid, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.GroupBox1.SuspendLayout()
    Me.GroupBox2.SuspendLayout()
    Me.SuspendLayout()
    '
    'MainMenu1
    '
    Me.MainMenu1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem1, Me.MenuItem2})
    '
    'MenuItem1
    '
    Me.MenuItem1.Index = 0
    Me.MenuItem1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.CreateDtGridMenu, Me.NavigationMenu})
    Me.MenuItem1.Text = "DataGrid Basics"
    '
    'CreateDtGridMenu
    '
    Me.CreateDtGridMenu.Index = 0
    Me.CreateDtGridMenu.Text = "Fill DataGrid"
    '
    'NavigationMenu
    '
    Me.NavigationMenu.Index = 1
    Me.NavigationMenu.RadioCheck = True
    Me.NavigationMenu.Text = "Navigation Allowed"
    '
    'MenuItem2
    '
    Me.MenuItem2.Index = 1
    Me.MenuItem2.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.ReshuffleCols})
    Me.MenuItem2.Text = "Other Operations"
    '
    'ReshuffleCols
    '
    Me.ReshuffleCols.Index = 0
    Me.ReshuffleCols.Text = "Reshuffle Columns"
    '
    'dtGrid
    '
    Me.dtGrid.DataMember = ""
    Me.dtGrid.HeaderForeColor = System.Drawing.SystemColors.ControlText
    Me.dtGrid.Location = New System.Drawing.Point(8, 256)
    Me.dtGrid.Name = "dtGrid"
    Me.dtGrid.Size = New System.Drawing.Size(464, 160)
    Me.dtGrid.TabIndex = 0
    '
    'GroupBox1
    '
    Me.GroupBox1.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(192, Byte))
    Me.GroupBox1.Controls.AddRange(New System.Windows.Forms.Control() {Me.gridLinesCheckBox, Me.readOnlyCheckBox, Me.chVisibleCheckBox, Me.flatModeCheckBox, Me.allowSortingCheckBox, Me.allowNavigationCheckBox})
    Me.GroupBox1.Location = New System.Drawing.Point(8, 8)
    Me.GroupBox1.Name = "GroupBox1"
    Me.GroupBox1.Size = New System.Drawing.Size(216, 192)
    Me.GroupBox1.TabIndex = 1
    Me.GroupBox1.TabStop = False
    Me.GroupBox1.Text = "General Properties"
    '
    'gridLinesCheckBox
    '
    Me.gridLinesCheckBox.Location = New System.Drawing.Point(16, 144)
    Me.gridLinesCheckBox.Name = "gridLinesCheckBox"
    Me.gridLinesCheckBox.Size = New System.Drawing.Size(104, 16)
    Me.gridLinesCheckBox.TabIndex = 5
    Me.gridLinesCheckBox.Text = "Show Grid Lines"
    '
    'readOnlyCheckBox
    '
    Me.readOnlyCheckBox.Location = New System.Drawing.Point(16, 120)
    Me.readOnlyCheckBox.Name = "readOnlyCheckBox"
    Me.readOnlyCheckBox.Size = New System.Drawing.Size(104, 16)
    Me.readOnlyCheckBox.TabIndex = 4
    Me.readOnlyCheckBox.Text = "ReadOnly"
    '
    'chVisibleCheckBox
    '
    Me.chVisibleCheckBox.Location = New System.Drawing.Point(16, 96)
    Me.chVisibleCheckBox.Name = "chVisibleCheckBox"
    Me.chVisibleCheckBox.Size = New System.Drawing.Size(144, 16)
    Me.chVisibleCheckBox.TabIndex = 3
    Me.chVisibleCheckBox.Text = "ColumnHeaderVisible"
    '
    'flatModeCheckBox
    '
    Me.flatModeCheckBox.Location = New System.Drawing.Point(16, 72)
    Me.flatModeCheckBox.Name = "flatModeCheckBox"
    Me.flatModeCheckBox.Size = New System.Drawing.Size(104, 16)
    Me.flatModeCheckBox.TabIndex = 2
    Me.flatModeCheckBox.Text = "FlatMode"
    '
    'allowSortingCheckBox
    '
    Me.allowSortingCheckBox.Location = New System.Drawing.Point(16, 48)
    Me.allowSortingCheckBox.Name = "allowSortingCheckBox"
    Me.allowSortingCheckBox.Size = New System.Drawing.Size(104, 16)
    Me.allowSortingCheckBox.TabIndex = 1
    Me.allowSortingCheckBox.Text = "AllowSorting"
    '
    'allowNavigationCheckBox
    '
    Me.allowNavigationCheckBox.Location = New System.Drawing.Point(16, 24)
    Me.allowNavigationCheckBox.Name = "allowNavigationCheckBox"
    Me.allowNavigationCheckBox.Size = New System.Drawing.Size(112, 16)
    Me.allowNavigationCheckBox.TabIndex = 0
    Me.allowNavigationCheckBox.Text = "AllowNavigation"
    '
    'borderStyleCombo
    '
    Me.borderStyleCombo.Location = New System.Drawing.Point(88, 24)
    Me.borderStyleCombo.Name = "borderStyleCombo"
    Me.borderStyleCombo.Size = New System.Drawing.Size(128, 21)
    Me.borderStyleCombo.TabIndex = 3
    '
    'Label1
    '
    Me.Label1.Location = New System.Drawing.Point(16, 24)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(72, 16)
    Me.Label1.TabIndex = 2
    Me.Label1.Text = "BorderStyle"
    '
    'GroupBox2
    '
    Me.GroupBox2.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(192, Byte), CType(192, Byte))
    Me.GroupBox2.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label1, Me.borderStyleCombo})
    Me.GroupBox2.Location = New System.Drawing.Point(232, 8)
    Me.GroupBox2.Name = "GroupBox2"
    Me.GroupBox2.Size = New System.Drawing.Size(240, 72)
    Me.GroupBox2.TabIndex = 3
    Me.GroupBox2.TabStop = False
    Me.GroupBox2.Text = "Color and Style Properties"
    '
    'ColorPropBtn
    '
    Me.ColorPropBtn.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(224, Byte), CType(192, Byte))
    Me.ColorPropBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
    Me.ColorPropBtn.Location = New System.Drawing.Point(16, 224)
    Me.ColorPropBtn.Name = "ColorPropBtn"
    Me.ColorPropBtn.Size = New System.Drawing.Size(104, 23)
    Me.ColorPropBtn.TabIndex = 4
    Me.ColorPropBtn.Text = "Color Properties"
    '
    'CaptionPropBtn
    '
    Me.CaptionPropBtn.BackColor = System.Drawing.SystemColors.Info
    Me.CaptionPropBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
    Me.CaptionPropBtn.Location = New System.Drawing.Point(136, 224)
    Me.CaptionPropBtn.Name = "CaptionPropBtn"
    Me.CaptionPropBtn.Size = New System.Drawing.Size(112, 23)
    Me.CaptionPropBtn.TabIndex = 5
    Me.CaptionPropBtn.Text = "Caption Properties"
    '
    'ApplyBtn
    '
    Me.ApplyBtn.BackColor = System.Drawing.Color.Green
    Me.ApplyBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
    Me.ApplyBtn.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
    Me.ApplyBtn.Location = New System.Drawing.Point(320, 96)
    Me.ApplyBtn.Name = "ApplyBtn"
    Me.ApplyBtn.Size = New System.Drawing.Size(136, 48)
    Me.ApplyBtn.TabIndex = 6
    Me.ApplyBtn.Text = "Apply All Settings"
    '
    'statusLabel
    '
    Me.statusLabel.BackColor = System.Drawing.Color.Red
    Me.statusLabel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.statusLabel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
    Me.statusLabel.Location = New System.Drawing.Point(8, 424)
    Me.statusLabel.Name = "statusLabel"
    Me.statusLabel.Size = New System.Drawing.Size(464, 23)
    Me.statusLabel.TabIndex = 7
    Me.statusLabel.Text = "Label2"
    '
    'Form1
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.BackColor = System.Drawing.SystemColors.Desktop
    Me.ClientSize = New System.Drawing.Size(488, 441)
    Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.statusLabel, Me.ApplyBtn, Me.CaptionPropBtn, Me.ColorPropBtn, Me.GroupBox2, Me.GroupBox1, Me.dtGrid})
    Me.Menu = Me.MainMenu1
    Me.Name = "Form1"
    Me.Text = "Customize DataGrid Application"
    CType(Me.dtGrid, System.ComponentModel.ISupportInitialize).EndInit()
    Me.GroupBox1.ResumeLayout(False)
    Me.GroupBox2.ResumeLayout(False)
    Me.ResumeLayout(False)

  End Sub

#End Region

  Private Sub Form1_Load(ByVal sender As System.Object, _
  ByVal e As System.EventArgs) Handles MyBase.Load

    ' Read default properties of DataGrid and set
    ' controls' states
    allowSortingCheckBox.Checked = dtGrid.AllowSorting
    allowNavigationCheckBox.Checked = dtGrid.AllowNavigation
    flatModeCheckBox.Checked = dtGrid.FlatMode
    chVisibleCheckBox.Checked = dtGrid.ColumnHeadersVisible
    borderStyleCombo.Text = dtGrid.BorderStyle.ToString()
    readOnlyCheckBox.Checked = dtGrid.ReadOnly

    ' Add border styles to the Border style combo
    borderStyleCombo.Items.Add(BorderStyle.None)
    borderStyleCombo.Items.Add(BorderStyle.Fixed3D)
    borderStyleCombo.Items.Add(BorderStyle.FixedSingle)
  End Sub

  ' FillDataGrid: Fills DataGrid and add TableStyle
  Private Sub FillDataGrid()
    ds = New DataSet()
    ds = GetDataSet("Customers")
    dtGrid.SetDataBinding(ds, "Customers")
    ' By default there is no DataGridTableStyle object.
    ' Add all DataSet table's style to the DataGrid
    Dim dTable As DataTable
    For Each dTable In ds.Tables
      Dim dgStyle As DataGridTableStyle = New DataGridTableStyle()
      dgStyle.MappingName = dTable.TableName
      dtGrid.TableStyles.Add(dgStyle)
    Next
  End Sub

  ' DataSet Overloaded methods. They all return a DataSet 
  ' object based on various parameters.
  Public Function GetDataSet(ByVal sql As String, _
  ByVal tableName As String) As DataSet
    ds = New DataSet(tableName)
    conn = New SqlConnection()
    conn.ConnectionString = ConnectionString
    adapter = New SqlDataAdapter(sql, conn)
    adapter.Fill(ds, tableName)
    Return ds
  End Function
  ' object based on various parameters.
  Public Function GetDataSet(ByVal tableName As String) As DataSet
    sql = "SELECT * FROM " + tableName
    ds = New DataSet(tableName)
    conn = New SqlConnection()
    conn.ConnectionString = ConnectionString
    adapter = New SqlDataAdapter(sql, conn)
    adapter.Fill(ds, tableName)
    conn.Close()
    conn.Dispose()
    Return ds
  End Function

  ' DataReader Overloaded methods. They all return a DataSet 
  ' object based on various parameters.
  Public Function GetDataReader(ByVal sql As String) As SqlDataReader
    conn = New SqlConnection()
    conn.ConnectionString = ConnectionString
    sql = "SELECT * FROM " + sql
    Dim cmd As SqlCommand = New SqlCommand()
    cmd.CommandText = sql
    cmd.Connection = conn
    conn.Open()
    Dim reader As SqlDataReader = Nothing
    reader = cmd.ExecuteReader()
    conn.Close()
    conn.Dispose()
    Return reader
  End Function


  Private Sub CreateDtGridMenu_Click(ByVal sender As System.Object, _
  ByVal e As System.EventArgs) Handles CreateDtGridMenu.Click
    FillDataGrid()
  End Sub

  ' Change navigation using AllowNavigation property
  Private Sub NavigationMenu_Click(ByVal sender As System.Object, _
  ByVal e As System.EventArgs) Handles NavigationMenu.Click
    ' Change navigation. If its true, change it to false and 
    ' vice versa
    If dtGrid.AllowNavigation = True Then
      dtGrid.AllowNavigation = False
    Else
      dtGrid.AllowNavigation = True
    End If
  End Sub

  ' Allow navigation event
  Private Sub AllowNavigationEvent(ByVal sender As Object, _
  ByVal e As System.EventArgs) Handles dtGrid.AllowNavigationChanged
    Dim nav As Boolean = dtGrid.AllowNavigation
    Dim str As String = "AllowNavigationChanged event fired. "
    If (nav) Then
      str = str + "Navigation is allowed"
      NavigationMenu.Checked = True
    Else
      str = str + "Navigation is not allowed"
      NavigationMenu.Checked = False
    End If
    MessageBox.Show(str, "AllowNavigation")
  End Sub

  Private Sub ColorPropBtn_Click(ByVal sender As System.Object, _
ByVal e As System.EventArgs) Handles ColorPropBtn.Click
    ' Setting DataGrid's Color and font properties
    dtGrid.BackColor = Color.Beige
    dtGrid.ForeColor = Color.Black
    dtGrid.BackgroundColor = Color.Red
    dtGrid.SelectionBackColor = Color.Blue
    dtGrid.SelectionForeColor = Color.Yellow
    dtGrid.GridLineColor = Color.Blue
    dtGrid.HeaderBackColor = Color.Black
    dtGrid.HeaderForeColor = Color.Gold
    'dtGrid.AlternatingBackColor = Color.AliceBlue
    dtGrid.LinkColor = Color.Pink
    dtGrid.HeaderFont = New Font("Verdana", FontStyle.Bold)
    dtGrid.Font = New Font("Verdana", 8, FontStyle.Regular)
  End Sub

  Private Sub CaptionPropBtn_Click(ByVal sender As System.Object, _
  ByVal e As System.EventArgs) Handles CaptionPropBtn.Click
    dtGrid.CaptionText = "Customized DataGrid"
    dtGrid.CaptionBackColor = System.Drawing.Color.Green
    dtGrid.CaptionForeColor = System.Drawing.Color.Yellow
    dtGrid.CaptionFont = New Font("Verdana", 10, FontStyle.Bold)
  End Sub

  Private Sub ApplyBtn_Click(ByVal sender As System.Object, _
  ByVal e As System.EventArgs) Handles ApplyBtn.Click
    ' Apply other styles
    ' Allow Navigation
    If (allowNavigationCheckBox.Checked) Then
      dtGrid.AllowNavigation = True
    Else
      dtGrid.AllowNavigation = False
    End If
    ' Allow Sorting
    If (allowSortingCheckBox.Checked) Then
      dtGrid.AllowSorting = True
    Else
      dtGrid.AllowSorting = False
    End If
    ' FlatMode
    ' Allow Sorting
    If (flatModeCheckBox.Checked) Then
      dtGrid.FlatMode = True
    Else
      dtGrid.FlatMode = False
    End If
    ' Column Header Visible
    If (chVisibleCheckBox.Checked) Then
      dtGrid.ColumnHeadersVisible = True
    Else
      dtGrid.ColumnHeadersVisible = False
    End If
    ' Read Only
    If (readOnlyCheckBox.Checked) Then
      dtGrid.ReadOnly = True
    Else
      dtGrid.ReadOnly = False
    End If
    ' Show Grid Line Style
    If (gridLinesCheckBox.Checked) Then
      dtGrid.GridLineStyle = DataGridLineStyle.Solid
    Else
      dtGrid.GridLineStyle = DataGridLineStyle.None
    End If
    ' Border style
    If (borderStyleCombo.Text.Equals("None")) Then
      dtGrid.BorderStyle = BorderStyle.None
    ElseIf (borderStyleCombo.Text.Equals("Fixed3D")) Then
      dtGrid.BorderStyle = BorderStyle.Fixed3D
    Else
      dtGrid.BorderStyle = BorderStyle.FixedSingle
    End If

  End Sub

  Private Sub BorderStyleChangedHandler(ByVal sender As Object, _
  ByVal e As System.EventArgs) Handles dtGrid.BorderStyleChanged
    statusLabel.Text = "Status: BorderStyleChanged Event Fired"
  End Sub

  Private Sub BackColorChangedEventHandler(ByVal sender As Object, _
  ByVal e As System.EventArgs) Handles dtGrid.BackColorChanged
    statusLabel.Text = "Status: BackColorChanged Event Fired"
  End Sub

  Private Sub BackgroundColorChangedHandler(ByVal sender As Object, _
  ByVal e As System.EventArgs) Handles dtGrid.BackgroundColorChanged
    statusLabel.Text = "Status: BackgroundColorChanged Event Fired"
  End Sub

  Private Sub BackgroundImageChangedHandler(ByVal sender As Object, _
  ByVal e As System.EventArgs) Handles dtGrid.BackgroundImageChanged
    statusLabel.Text = "Status: BackgroundImageChanged Event Fired"
  End Sub

  Private Sub CaptionVisibleChangedHandler(ByVal sender As Object, _
  ByVal e As System.EventArgs) Handles dtGrid.CaptionVisibleChanged
    statusLabel.Text = "Status: CaptionVisibleChanged Event Fired"
  End Sub

  Private Sub FlatModeChangedHandler(ByVal sender As Object, _
  ByVal e As System.EventArgs) Handles dtGrid.FlatModeChanged
    statusLabel.Text = "Status: FlatModeChanged Event Fired"
  End Sub

  Private Sub FontChangedHandler(ByVal sender As Object, _
  ByVal e As System.EventArgs) Handles dtGrid.FontChanged
    statusLabel.Text = "Status: FontChanged Event Fired"
  End Sub

  Private Sub ForeColorChangedHandler(ByVal sender As Object, _
  ByVal e As System.EventArgs) Handles dtGrid.ForeColorChanged
    statusLabel.Text = "Status: ForeColorChanged Event Fired"
  End Sub

  Private Sub ReadOnlyChangedHandler(ByVal sender As Object, _
  ByVal e As System.EventArgs) Handles dtGrid.ReadOnlyChanged
    statusLabel.Text = "Status: ReadOnlyChanged Event Fired"
  End Sub

  ' DataGrid Mouse down event handler
  Private Sub dtGrid_MouseDown(ByVal sender As Object, _
  ByVal e As System.Windows.Forms.MouseEventArgs) Handles dtGrid.MouseDown
    Dim grid As DataGrid = CType(sender, DataGrid)
    Dim hti As DataGrid.HitTestInfo
    ' When right mouse button was clicked
    If (e.Button = MouseButtons.Right) Then
      hti = grid.HitTest(e.X, e.Y)
      Select Case hti.Type
        Case DataGrid.HitTestType.None
          MessageBox.Show("Background")
        Case DataGrid.HitTestType.Cell
          ' Add context menus
          popUpMenu2 = New ContextMenu()
          popUpMenu2.MenuItems.Add("Move First")
          popUpMenu2.MenuItems.Add("Move Previous")
          popUpMenu2.MenuItems.Add("Move Next")
          popUpMenu2.MenuItems.Add("Move Last")
          Me.ContextMenu = popUpMenu2
          Me.BackColor = Color.Sienna
          moveFirstMenu = Me.ContextMenu.MenuItems(0)
          moveNextMenu = Me.ContextMenu.MenuItems(1)
          movePrevMenu = Me.ContextMenu.MenuItems(2)
          moveLastMenu = Me.ContextMenu.MenuItems(3)

        Case DataGrid.HitTestType.ColumnHeader
          ' Add context menus
          popUpMenu = New ContextMenu()
          popUpMenu.MenuItems.Add("Sort ASC")
          popUpMenu.MenuItems.Add("Sort DESC")
          popUpMenu.MenuItems.Add("Find")
          popUpMenu.MenuItems.Add("Hide Column")
          Me.ContextMenu = popUpMenu
          Me.BackColor = Color.Sienna
          sortAscMenu = Me.ContextMenu.MenuItems(0)
          sortDescMenu = Me.ContextMenu.MenuItems(1)
          findMenu = Me.ContextMenu.MenuItems(2)
          hideMenu = Me.ContextMenu.MenuItems(3)
          ' Find the Column header name
          Dim gridStyle As DataGridTableStyle = _
          dtGrid.TableStyles("Customers")
          curColName = gridStyle.GridColumnStyles _
          (hti.Column).MappingName.ToString()
          curColumnStyle = gridStyle.GridColumnStyles(hti.Column)
        Case DataGrid.HitTestType.RowHeader
          MessageBox.Show("Row header " & hti.Row)
        Case DataGrid.HitTestType.ColumnResize
          MessageBox.Show("Column seperater " & hti.Column)
        Case DataGrid.HitTestType.RowResize
          MessageBox.Show("Row seperater " & hti.Row)
        Case DataGrid.HitTestType.Caption
          MessageBox.Show("Caption")
        Case DataGrid.HitTestType.ParentRows
          MessageBox.Show("Parent row")
      End Select
    End If
  End Sub

  Private Sub SortAscMenuHandler(ByVal sender As System.Object, _
ByVal e As System.EventArgs) Handles sortAscMenu.Click
    Dim dv As DataView = ds.Tables("Customers").DefaultView
    dv.Sort = curColName + " ASC"
    dtGrid.DataSource = dv
  End Sub
  Private Sub SortDescMenuHandler(ByVal sender As System.Object, _
  ByVal e As System.EventArgs) Handles sortDescMenu.Click
    Dim dv As DataView = ds.Tables("Customers").DefaultView
    dv.Sort = curColName + " DESC"
    dtGrid.DataSource = dv
  End Sub
  Private Sub FindMenuHandler(ByVal sender As System.Object, _
  ByVal e As System.EventArgs) Handles findMenu.Click
    MessageBox.Show("Find click")
  End Sub
  Private Sub hideMenuHandler(ByVal sender As System.Object, _
 ByVal e As System.EventArgs) Handles hideMenu.Click
    curColumnStyle.Width = 0
  End Sub

  ' MoveFirst menu handler
  Private Sub MoveFirstMenuHandler(ByVal sender As System.Object, _
 ByVal e As System.EventArgs) Handles moveFirstMenu.Click
    MessageBox.Show("Move first")
  End Sub
  ' MoveFirst menu handler
  Private Sub MoveNextMenuHandler(ByVal sender As System.Object, _
 ByVal e As System.EventArgs) Handles moveNextMenu.Click
    MessageBox.Show("Move next")
  End Sub
  ' MoveFirst menu handler
  Private Sub MovePrevMenuHandler(ByVal sender As System.Object, _
 ByVal e As System.EventArgs) Handles movePrevMenu.Click
    MessageBox.Show("Move prev")
  End Sub
  ' MoveFirst menu handler
  Private Sub MoveLastMenuHandler(ByVal sender As System.Object, _
 ByVal e As System.EventArgs) Handles moveLastMenu.Click
    MessageBox.Show("Move last")
  End Sub

  Private Sub ReshuffleCols_Click(ByVal sender As System.Object, _
  ByVal e As System.EventArgs) Handles ReshuffleCols.Click
  End Sub

  Private Sub ReloadDataBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

  End Sub
End Class
