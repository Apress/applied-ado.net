Imports VideoStoreDataModel.EnterpriseVB.VideoStore.Data

Public Class WebForm1
    Inherits System.Web.UI.Page
    Protected WithEvents VideoTapesGrid As System.Web.UI.WebControls.DataGrid
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


    Public Property SelectedCategoryID() As Integer
        Get
            If (("" + ViewState("SelCatID")) = "") Then
                Return -1
            End If
            Return Convert.ToInt32("" + ViewState("SelCatID"))
        End Get
        Set(ByVal Value As Integer)
            ViewState("SelCatID") = "" + Value.ToString()
        End Set
    End Property
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DisplayCategoryTree()
    End Sub

    Private Sub DisplayCategoryTree()
        CategoryTree.Rows.Clear()
        Dim dac As New VideoCategoryDataAccess()
        Dim category As VideoCategory
        category = dac.GetCategoryTree(1)
        Dim depth As Integer
        depth = GetDepth(category, 0)
        RenderTree(category, depth, 0)

        If (SelectedCategoryID <> -1) Then
            Dim cCat As VideoCategory
            cCat = category.FindCategoryByID(SelectedCategoryID)
            VideoTapesGrid.DataSource = cCat.Videos
            VideoTapesGrid.DataBind()
        End If
    End Sub
    Public Function RenderTree(ByRef cat As VideoCategory, ByVal depth As Integer, ByVal currentDepth As Integer)
        Dim tr As New TableRow()

        Dim i As Integer
        For i = 0 To currentDepth
            Dim spacerCell As New TableCell()
            spacerCell.Text = "&nbsp;"
            spacerCell.Width = Unit.Pixel(10)
            spacerCell.Height = Unit.Pixel(10)
            spacerCell.BorderWidth = Unit.Pixel(0)
            tr.Cells.Add(spacerCell)
        Next

        Dim descCell As New TableCell()
        descCell.ColumnSpan = (depth - currentDepth) + 1

        Dim lb As New LinkButton()
        lb.Text = cat.Description
        lb.ID = "CAT" + cat.CategoryID.ToString()
        AddHandler lb.Click, AddressOf Category_Selected

        descCell.Controls.Add(lb)
        If (Me.SelectedCategoryID = cat.CategoryID) Then
            descCell.BackColor = Color.Yellow
        Else
            descCell.BackColor = Color.White
        End If
        descCell.Style.Add("white-space", "nowrap")

        tr.Cells.Add(descCell)
        CategoryTree.Rows.Add(tr)

        currentDepth = currentDepth + 1
        For i = 0 To cat.CountSubCategories() - 1
            RenderTree(cat.GetSubCategory(i), depth, currentDepth)
        Next

    End Function

    Public Sub Category_Selected(ByVal sender As Object, ByVal e As EventArgs)
        Me.SelectedCategoryID = Convert.ToInt32((CType(sender, LinkButton)).ID.Substring(3))
        Me.DisplayCategoryTree()
    End Sub

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
