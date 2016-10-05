Public Class WebForm1
    Inherits System.Web.UI.Page
  Protected WithEvents GetPropsBtn As System.Web.UI.WebControls.Button
  Protected WithEvents Label1 As System.Web.UI.WebControls.Label
  Protected WithEvents Calendar1 As System.Web.UI.WebControls.Calendar

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

  Private Sub Page_Load(ByVal sender As System.Object, _
  ByVal e As System.EventArgs) Handles MyBase.Load
    ' Set VisibleDate to Dec 01, 2002
    Calendar1.ShowTitle = True
    Calendar1.ShowGridLines = False
    Calendar1.ShowNextPrevMonth = True
    Calendar1.VisibleDate = New Date(2002, 12, 1)
    Calendar1.NextMonthText = "Next"
    Calendar1.PrevMonthText = "Back"
    Calendar1.FirstDayOfWeek = _
    System.Web.UI.WebControls.FirstDayOfWeek.Friday
    Calendar1.ShowDayHeader = True
    Calendar1.TitleFormat = TitleFormat.MonthYear
  End Sub

  Private Sub GetPropsBtn_Click(ByVal sender As System.Object, _
  ByVal e As System.EventArgs) Handles GetPropsBtn.Click
    Label1.Text = "The selected date is " & _
    Calendar1.SelectedDate.ToShortDateString()
  End Sub

  Public Sub Calendar1_VisibleMonthChanged(ByVal sender As Object, _
   ByVal e As System.Web.UI.WebControls.MonthChangedEventArgs) _
   Handles Calendar1.VisibleMonthChanged
    Calendar1.SelectedDates.Clear()
    Calendar1.SelectedDates.Add _
    (New DateTime(e.NewDate.Year, e.NewDate.Month, 15))
    Calendar1.SelectedDates.Add _
    (New DateTime(e.NewDate.Year, e.NewDate.Month, 25))
  End Sub


End Class
