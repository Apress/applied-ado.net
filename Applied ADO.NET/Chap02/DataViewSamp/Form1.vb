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
  Friend WithEvents SqlSelectCommand1 As System.Data.SqlClient.SqlCommand
  Friend WithEvents SqlInsertCommand1 As System.Data.SqlClient.SqlCommand
  Friend WithEvents SqlUpdateCommand1 As System.Data.SqlClient.SqlCommand
  Friend WithEvents SqlDeleteCommand1 As System.Data.SqlClient.SqlCommand
  Friend WithEvents SqlConnection1 As System.Data.SqlClient.SqlConnection
  Friend WithEvents SqlDataAdapter1 As System.Data.SqlClient.SqlDataAdapter
  Friend WithEvents DataSet11 As DataViewSamp.DataSet1
  Friend WithEvents DataView1 As System.Data.DataView
  Friend WithEvents DataGrid1 As System.Windows.Forms.DataGrid
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.SqlSelectCommand1 = New System.Data.SqlClient.SqlCommand()
    Me.SqlConnection1 = New System.Data.SqlClient.SqlConnection()
    Me.SqlInsertCommand1 = New System.Data.SqlClient.SqlCommand()
    Me.SqlUpdateCommand1 = New System.Data.SqlClient.SqlCommand()
    Me.SqlDeleteCommand1 = New System.Data.SqlClient.SqlCommand()
    Me.SqlDataAdapter1 = New System.Data.SqlClient.SqlDataAdapter()
    Me.DataSet11 = New DataViewSamp.DataSet1()
    Me.DataView1 = New System.Data.DataView()
    Me.DataGrid1 = New System.Windows.Forms.DataGrid()
    CType(Me.DataSet11, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.DataView1, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'SqlSelectCommand1
    '
    Me.SqlSelectCommand1.CommandText = "SELECT EmployeeID, LastName, FirstName, Title, TitleOfCourtesy, BirthDate, HireDa" & _
    "te, Address, City, Region, PostalCode, Country, HomePhone, Extension, Photo, Not" & _
    "es, ReportsTo, PhotoPath FROM Employees"
    Me.SqlSelectCommand1.Connection = Me.SqlConnection1
    '
    'SqlConnection1
    '
    Me.SqlConnection1.ConnectionString = "data source=localhost;initial catalog=Northwind;integrated security=SSPI;persist " & _
    "security info=False;workstation id=MCB;packet size=4096"
    '
    'SqlInsertCommand1
    '
    Me.SqlInsertCommand1.CommandText = "INSERT INTO Employees(LastName, FirstName, Title, TitleOfCourtesy, BirthDate, Hir" & _
    "eDate, Address, City, Region, PostalCode, Country, HomePhone, Extension, Photo, " & _
    "Notes, ReportsTo, PhotoPath) VALUES (@LastName, @FirstName, @Title, @TitleOfCour" & _
    "tesy, @BirthDate, @HireDate, @Address, @City, @Region, @PostalCode, @Country, @H" & _
    "omePhone, @Extension, @Photo, @Notes, @ReportsTo, @PhotoPath); SELECT EmployeeID" & _
    ", LastName, FirstName, Title, TitleOfCourtesy, BirthDate, HireDate, Address, Cit" & _
    "y, Region, PostalCode, Country, HomePhone, Extension, Photo, Notes, ReportsTo, P" & _
    "hotoPath FROM Employees WHERE (EmployeeID = @@IDENTITY)"
    Me.SqlInsertCommand1.Connection = Me.SqlConnection1
    Me.SqlInsertCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@LastName", System.Data.SqlDbType.NVarChar, 20, "LastName"))
    Me.SqlInsertCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@FirstName", System.Data.SqlDbType.NVarChar, 10, "FirstName"))
    Me.SqlInsertCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Title", System.Data.SqlDbType.NVarChar, 30, "Title"))
    Me.SqlInsertCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@TitleOfCourtesy", System.Data.SqlDbType.NVarChar, 25, "TitleOfCourtesy"))
    Me.SqlInsertCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@BirthDate", System.Data.SqlDbType.DateTime, 8, "BirthDate"))
    Me.SqlInsertCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@HireDate", System.Data.SqlDbType.DateTime, 8, "HireDate"))
    Me.SqlInsertCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Address", System.Data.SqlDbType.NVarChar, 60, "Address"))
    Me.SqlInsertCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@City", System.Data.SqlDbType.NVarChar, 15, "City"))
    Me.SqlInsertCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Region", System.Data.SqlDbType.NVarChar, 15, "Region"))
    Me.SqlInsertCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@PostalCode", System.Data.SqlDbType.NVarChar, 10, "PostalCode"))
    Me.SqlInsertCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Country", System.Data.SqlDbType.NVarChar, 15, "Country"))
    Me.SqlInsertCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@HomePhone", System.Data.SqlDbType.NVarChar, 24, "HomePhone"))
    Me.SqlInsertCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Extension", System.Data.SqlDbType.NVarChar, 4, "Extension"))
    Me.SqlInsertCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Photo", System.Data.SqlDbType.VarBinary, 2147483647, "Photo"))
    Me.SqlInsertCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Notes", System.Data.SqlDbType.NVarChar, 1073741823, "Notes"))
    Me.SqlInsertCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@ReportsTo", System.Data.SqlDbType.Int, 4, "ReportsTo"))
    Me.SqlInsertCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@PhotoPath", System.Data.SqlDbType.NVarChar, 255, "PhotoPath"))
    '
    'SqlUpdateCommand1
    '
    Me.SqlUpdateCommand1.CommandText = "UPDATE Employees SET LastName = @LastName, FirstName = @FirstName, Title = @Title" & _
    ", TitleOfCourtesy = @TitleOfCourtesy, BirthDate = @BirthDate, HireDate = @HireDa" & _
    "te, Address = @Address, City = @City, Region = @Region, PostalCode = @PostalCode" & _
    ", Country = @Country, HomePhone = @HomePhone, Extension = @Extension, Photo = @P" & _
    "hoto, Notes = @Notes, ReportsTo = @ReportsTo, PhotoPath = @PhotoPath WHERE (Empl" & _
    "oyeeID = @Original_EmployeeID) AND (Address = @Original_Address OR @Original_Add" & _
    "ress IS NULL AND Address IS NULL) AND (BirthDate = @Original_BirthDate OR @Origi" & _
    "nal_BirthDate IS NULL AND BirthDate IS NULL) AND (City = @Original_City OR @Orig" & _
    "inal_City IS NULL AND City IS NULL) AND (Country = @Original_Country OR @Origina" & _
    "l_Country IS NULL AND Country IS NULL) AND (Extension = @Original_Extension OR @" & _
    "Original_Extension IS NULL AND Extension IS NULL) AND (FirstName = @Original_Fir" & _
    "stName) AND (HireDate = @Original_HireDate OR @Original_HireDate IS NULL AND Hir" & _
    "eDate IS NULL) AND (HomePhone = @Original_HomePhone OR @Original_HomePhone IS NU" & _
    "LL AND HomePhone IS NULL) AND (LastName = @Original_LastName) AND (PhotoPath = @" & _
    "Original_PhotoPath OR @Original_PhotoPath IS NULL AND PhotoPath IS NULL) AND (Po" & _
    "stalCode = @Original_PostalCode OR @Original_PostalCode IS NULL AND PostalCode I" & _
    "S NULL) AND (Region = @Original_Region OR @Original_Region IS NULL AND Region IS" & _
    " NULL) AND (ReportsTo = @Original_ReportsTo OR @Original_ReportsTo IS NULL AND R" & _
    "eportsTo IS NULL) AND (Title = @Original_Title OR @Original_Title IS NULL AND Ti" & _
    "tle IS NULL) AND (TitleOfCourtesy = @Original_TitleOfCourtesy OR @Original_Title" & _
    "OfCourtesy IS NULL AND TitleOfCourtesy IS NULL); SELECT EmployeeID, LastName, Fi" & _
    "rstName, Title, TitleOfCourtesy, BirthDate, HireDate, Address, City, Region, Pos" & _
    "talCode, Country, HomePhone, Extension, Photo, Notes, ReportsTo, PhotoPath FROM " & _
    "Employees WHERE (EmployeeID = @EmployeeID)"
    Me.SqlUpdateCommand1.Connection = Me.SqlConnection1
    Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@LastName", System.Data.SqlDbType.NVarChar, 20, "LastName"))
    Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@FirstName", System.Data.SqlDbType.NVarChar, 10, "FirstName"))
    Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Title", System.Data.SqlDbType.NVarChar, 30, "Title"))
    Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@TitleOfCourtesy", System.Data.SqlDbType.NVarChar, 25, "TitleOfCourtesy"))
    Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@BirthDate", System.Data.SqlDbType.DateTime, 8, "BirthDate"))
    Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@HireDate", System.Data.SqlDbType.DateTime, 8, "HireDate"))
    Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Address", System.Data.SqlDbType.NVarChar, 60, "Address"))
    Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@City", System.Data.SqlDbType.NVarChar, 15, "City"))
    Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Region", System.Data.SqlDbType.NVarChar, 15, "Region"))
    Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@PostalCode", System.Data.SqlDbType.NVarChar, 10, "PostalCode"))
    Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Country", System.Data.SqlDbType.NVarChar, 15, "Country"))
    Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@HomePhone", System.Data.SqlDbType.NVarChar, 24, "HomePhone"))
    Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Extension", System.Data.SqlDbType.NVarChar, 4, "Extension"))
    Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Photo", System.Data.SqlDbType.VarBinary, 2147483647, "Photo"))
    Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Notes", System.Data.SqlDbType.NVarChar, 1073741823, "Notes"))
    Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@ReportsTo", System.Data.SqlDbType.Int, 4, "ReportsTo"))
    Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@PhotoPath", System.Data.SqlDbType.NVarChar, 255, "PhotoPath"))
    Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_EmployeeID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "EmployeeID", System.Data.DataRowVersion.Original, Nothing))
    Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_Address", System.Data.SqlDbType.NVarChar, 60, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Address", System.Data.DataRowVersion.Original, Nothing))
    Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_BirthDate", System.Data.SqlDbType.DateTime, 8, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "BirthDate", System.Data.DataRowVersion.Original, Nothing))
    Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_City", System.Data.SqlDbType.NVarChar, 15, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "City", System.Data.DataRowVersion.Original, Nothing))
    Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_Country", System.Data.SqlDbType.NVarChar, 15, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Country", System.Data.DataRowVersion.Original, Nothing))
    Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_Extension", System.Data.SqlDbType.NVarChar, 4, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Extension", System.Data.DataRowVersion.Original, Nothing))
    Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_FirstName", System.Data.SqlDbType.NVarChar, 10, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "FirstName", System.Data.DataRowVersion.Original, Nothing))
    Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_HireDate", System.Data.SqlDbType.DateTime, 8, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "HireDate", System.Data.DataRowVersion.Original, Nothing))
    Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_HomePhone", System.Data.SqlDbType.NVarChar, 24, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "HomePhone", System.Data.DataRowVersion.Original, Nothing))
    Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_LastName", System.Data.SqlDbType.NVarChar, 20, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "LastName", System.Data.DataRowVersion.Original, Nothing))
    Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_PhotoPath", System.Data.SqlDbType.NVarChar, 255, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "PhotoPath", System.Data.DataRowVersion.Original, Nothing))
    Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_PostalCode", System.Data.SqlDbType.NVarChar, 10, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "PostalCode", System.Data.DataRowVersion.Original, Nothing))
    Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_Region", System.Data.SqlDbType.NVarChar, 15, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Region", System.Data.DataRowVersion.Original, Nothing))
    Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_ReportsTo", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ReportsTo", System.Data.DataRowVersion.Original, Nothing))
    Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_Title", System.Data.SqlDbType.NVarChar, 30, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Title", System.Data.DataRowVersion.Original, Nothing))
    Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_TitleOfCourtesy", System.Data.SqlDbType.NVarChar, 25, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "TitleOfCourtesy", System.Data.DataRowVersion.Original, Nothing))
    Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@EmployeeID", System.Data.SqlDbType.Int, 4, "EmployeeID"))
    '
    'SqlDeleteCommand1
    '
    Me.SqlDeleteCommand1.CommandText = "DELETE FROM Employees WHERE (EmployeeID = @Original_EmployeeID) AND (Address = @O" & _
    "riginal_Address OR @Original_Address IS NULL AND Address IS NULL) AND (BirthDate" & _
    " = @Original_BirthDate OR @Original_BirthDate IS NULL AND BirthDate IS NULL) AND" & _
    " (City = @Original_City OR @Original_City IS NULL AND City IS NULL) AND (Country" & _
    " = @Original_Country OR @Original_Country IS NULL AND Country IS NULL) AND (Exte" & _
    "nsion = @Original_Extension OR @Original_Extension IS NULL AND Extension IS NULL" & _
    ") AND (FirstName = @Original_FirstName) AND (HireDate = @Original_HireDate OR @O" & _
    "riginal_HireDate IS NULL AND HireDate IS NULL) AND (HomePhone = @Original_HomePh" & _
    "one OR @Original_HomePhone IS NULL AND HomePhone IS NULL) AND (LastName = @Origi" & _
    "nal_LastName) AND (PhotoPath = @Original_PhotoPath OR @Original_PhotoPath IS NUL" & _
    "L AND PhotoPath IS NULL) AND (PostalCode = @Original_PostalCode OR @Original_Pos" & _
    "talCode IS NULL AND PostalCode IS NULL) AND (Region = @Original_Region OR @Origi" & _
    "nal_Region IS NULL AND Region IS NULL) AND (ReportsTo = @Original_ReportsTo OR @" & _
    "Original_ReportsTo IS NULL AND ReportsTo IS NULL) AND (Title = @Original_Title O" & _
    "R @Original_Title IS NULL AND Title IS NULL) AND (TitleOfCourtesy = @Original_Ti" & _
    "tleOfCourtesy OR @Original_TitleOfCourtesy IS NULL AND TitleOfCourtesy IS NULL)"
    Me.SqlDeleteCommand1.Connection = Me.SqlConnection1
    Me.SqlDeleteCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_EmployeeID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "EmployeeID", System.Data.DataRowVersion.Original, Nothing))
    Me.SqlDeleteCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_Address", System.Data.SqlDbType.NVarChar, 60, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Address", System.Data.DataRowVersion.Original, Nothing))
    Me.SqlDeleteCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_BirthDate", System.Data.SqlDbType.DateTime, 8, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "BirthDate", System.Data.DataRowVersion.Original, Nothing))
    Me.SqlDeleteCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_City", System.Data.SqlDbType.NVarChar, 15, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "City", System.Data.DataRowVersion.Original, Nothing))
    Me.SqlDeleteCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_Country", System.Data.SqlDbType.NVarChar, 15, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Country", System.Data.DataRowVersion.Original, Nothing))
    Me.SqlDeleteCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_Extension", System.Data.SqlDbType.NVarChar, 4, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Extension", System.Data.DataRowVersion.Original, Nothing))
    Me.SqlDeleteCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_FirstName", System.Data.SqlDbType.NVarChar, 10, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "FirstName", System.Data.DataRowVersion.Original, Nothing))
    Me.SqlDeleteCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_HireDate", System.Data.SqlDbType.DateTime, 8, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "HireDate", System.Data.DataRowVersion.Original, Nothing))
    Me.SqlDeleteCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_HomePhone", System.Data.SqlDbType.NVarChar, 24, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "HomePhone", System.Data.DataRowVersion.Original, Nothing))
    Me.SqlDeleteCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_LastName", System.Data.SqlDbType.NVarChar, 20, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "LastName", System.Data.DataRowVersion.Original, Nothing))
    Me.SqlDeleteCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_PhotoPath", System.Data.SqlDbType.NVarChar, 255, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "PhotoPath", System.Data.DataRowVersion.Original, Nothing))
    Me.SqlDeleteCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_PostalCode", System.Data.SqlDbType.NVarChar, 10, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "PostalCode", System.Data.DataRowVersion.Original, Nothing))
    Me.SqlDeleteCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_Region", System.Data.SqlDbType.NVarChar, 15, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Region", System.Data.DataRowVersion.Original, Nothing))
    Me.SqlDeleteCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_ReportsTo", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ReportsTo", System.Data.DataRowVersion.Original, Nothing))
    Me.SqlDeleteCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_Title", System.Data.SqlDbType.NVarChar, 30, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Title", System.Data.DataRowVersion.Original, Nothing))
    Me.SqlDeleteCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_TitleOfCourtesy", System.Data.SqlDbType.NVarChar, 25, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "TitleOfCourtesy", System.Data.DataRowVersion.Original, Nothing))
    '
    'SqlDataAdapter1
    '
    Me.SqlDataAdapter1.DeleteCommand = Me.SqlDeleteCommand1
    Me.SqlDataAdapter1.InsertCommand = Me.SqlInsertCommand1
    Me.SqlDataAdapter1.SelectCommand = Me.SqlSelectCommand1
    Me.SqlDataAdapter1.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "Employees", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("EmployeeID", "EmployeeID"), New System.Data.Common.DataColumnMapping("LastName", "LastName"), New System.Data.Common.DataColumnMapping("FirstName", "FirstName"), New System.Data.Common.DataColumnMapping("Title", "Title"), New System.Data.Common.DataColumnMapping("TitleOfCourtesy", "TitleOfCourtesy"), New System.Data.Common.DataColumnMapping("BirthDate", "BirthDate"), New System.Data.Common.DataColumnMapping("HireDate", "HireDate"), New System.Data.Common.DataColumnMapping("Address", "Address"), New System.Data.Common.DataColumnMapping("City", "City"), New System.Data.Common.DataColumnMapping("Region", "Region"), New System.Data.Common.DataColumnMapping("PostalCode", "PostalCode"), New System.Data.Common.DataColumnMapping("Country", "Country"), New System.Data.Common.DataColumnMapping("HomePhone", "HomePhone"), New System.Data.Common.DataColumnMapping("Extension", "Extension"), New System.Data.Common.DataColumnMapping("Photo", "Photo"), New System.Data.Common.DataColumnMapping("Notes", "Notes"), New System.Data.Common.DataColumnMapping("ReportsTo", "ReportsTo"), New System.Data.Common.DataColumnMapping("PhotoPath", "PhotoPath")})})
    Me.SqlDataAdapter1.UpdateCommand = Me.SqlUpdateCommand1
    '
    'DataSet11
    '
    Me.DataSet11.DataSetName = "DataSet1"
    Me.DataSet11.Locale = New System.Globalization.CultureInfo("en-US")
    Me.DataSet11.Namespace = "http://www.tempuri.org/DataSet1.xsd"
    '
    'DataView1
    '
    Me.DataView1.RowFilter = "Country='USA'"
    Me.DataView1.Sort = "FirstName ASC"
    Me.DataView1.Table = Me.DataSet11.Employees
    '
    'DataGrid1
    '
    Me.DataGrid1.DataMember = ""
    Me.DataGrid1.DataSource = Me.DataView1
    Me.DataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText
    Me.DataGrid1.Location = New System.Drawing.Point(16, 8)
    Me.DataGrid1.Name = "DataGrid1"
    Me.DataGrid1.Size = New System.Drawing.Size(464, 256)
    Me.DataGrid1.TabIndex = 0
    '
    'Form1
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(488, 273)
    Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.DataGrid1})
    Me.Name = "Form1"
    Me.Text = "Form1"
    CType(Me.DataSet11, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.DataView1, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)

  End Sub

#End Region

  Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    SqlDataAdapter1.Fill(DataSet11)
  End Sub
End Class
