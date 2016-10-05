Imports VideoStoreDataModel.EnterpriseVB.VideoStore.Data

Public Class WebForm1
    Inherits System.Web.UI.Page
    Protected WithEvents CategoryTree As System.Web.UI.WebControls.Table
    
#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
        Dim dac As New VideoCategoryDataAccess()
        Dim category As VideoCategory
        category = dac.GetCategoryTree(1)
        Dim depth As Integer
        depth = GetDepth(category, 0)
        RenderTree(category, depth, 0)
    End Sub

    Public Function RenderTree(ByRef cat As VideoCategory, ByVal depth As Integer, ByVal currentDepth As Integer)
        Dim tr As New TableRow()

        Dim i As Integer
        For i = 0 To currentDepth
            Dim spacerCell As New TableCell()
            spacerCell.Text = "&nbsp;"
            spacerCell.Width = Unit.Pixel(20)
            spacerCell.Height = Unit.Pixel(20)
            spacerCell.BorderWidth = Unit.Pixel(2)
            spacerCell.BorderStyle = BorderStyle.Solid
            spacerCell.BorderColor = Color.Black
            tr.Cells.Add(spacerCell)
        Next

        Dim descCell As New TableCell()
        descCell.ColumnSpan = (depth - currentDepth) + 1
        descCell.Text = cat.Description

        tr.Cells.Add(descCell)
        CategoryTree.Rows.Add(tr)

        currentDepth = currentDepth + 1
        For i = 0 To cat.CountSubCategories() - 1
            RenderTree(cat.GetSubCategory(i), depth, currentDepth)
        Next

    End Function


    Public Function GetDepth(ByVal cat As VideoCategory, ByVal depth As Integer) As Integer

        Dim tDepth As Integer
        Dim deepest As Integer
        deepest = depth

        Dim i As Integer
        For i = 0 To cat.CountSubCategories() - 1
            tDepth = GetDepth(cat.GetSubCategory(i), depth + 1)
            If (tDepth > deepest) Then
                deepest = tDepth
            End If
        Next
        Return deepest
    End Function

End Class
