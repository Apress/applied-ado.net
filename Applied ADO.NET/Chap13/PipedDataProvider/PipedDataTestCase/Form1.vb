Imports PipedDataProvider.AppliedADO.DataProvider

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
    Friend WithEvents LoadButton As System.Windows.Forms.Button
    Friend WithEvents DisplayGrid As System.Windows.Forms.DataGrid

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.Container

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.DisplayGrid = New System.Windows.Forms.DataGrid()
        Me.LoadButton = New System.Windows.Forms.Button()
        CType(Me.DisplayGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DisplayGrid
        '
        Me.DisplayGrid.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.DisplayGrid.DataMember = ""
        Me.DisplayGrid.Location = New System.Drawing.Point(0, 24)
        Me.DisplayGrid.Name = "DisplayGrid"
        Me.DisplayGrid.Size = New System.Drawing.Size(532, 428)
        Me.DisplayGrid.TabIndex = 1
        '
        'LoadButton
        '
        Me.LoadButton.Name = "LoadButton"
        Me.LoadButton.TabIndex = 0
        Me.LoadButton.Text = "Load"
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(528, 453)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.DisplayGrid, Me.LoadButton})
        Me.Name = "Form1"
        Me.Text = "Form1"
        CType(Me.DisplayGrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub LoadButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LoadButton.Click
        Dim adapter As New PipedDataAdapter()
        adapter.SelectCommand = New PipedDataCommand("ALL", New PipedDataConnection("../../pipeddata.txt"))
        Dim reader As System.Data.IDataReader

        Dim data As New DataTable()
        adapter.Fill(data)
        DisplayGrid.DataSource = data
    End Sub
End Class
