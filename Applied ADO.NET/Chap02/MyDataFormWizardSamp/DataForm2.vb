Public Class DataForm2
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
  Friend WithEvents OleDbSelectCommand1 As System.Data.OleDb.OleDbCommand
  Friend WithEvents OleDbInsertCommand1 As System.Data.OleDb.OleDbCommand
  Friend WithEvents OleDbUpdateCommand1 As System.Data.OleDb.OleDbCommand
  Friend WithEvents OleDbDeleteCommand1 As System.Data.OleDb.OleDbCommand
  Friend WithEvents OleDbSelectCommand2 As System.Data.OleDb.OleDbCommand
  Friend WithEvents OleDbInsertCommand2 As System.Data.OleDb.OleDbCommand
  Friend WithEvents OleDbUpdateCommand2 As System.Data.OleDb.OleDbCommand
  Friend WithEvents OleDbDeleteCommand2 As System.Data.OleDb.OleDbCommand
  Friend WithEvents objMyDS1 As MyDataFormWizardSamp.MyDS1
  Friend WithEvents OleDbConnection1 As System.Data.OleDb.OleDbConnection
  Friend WithEvents OleDbDataAdapter1 As System.Data.OleDb.OleDbDataAdapter
  Friend WithEvents OleDbDataAdapter2 As System.Data.OleDb.OleDbDataAdapter
  Friend WithEvents btnLoad As System.Windows.Forms.Button
  Friend WithEvents btnUpdate As System.Windows.Forms.Button
  Friend WithEvents btnCancelAll As System.Windows.Forms.Button
  Friend WithEvents lblCustomerID As System.Windows.Forms.Label
  Friend WithEvents lblCompanyName As System.Windows.Forms.Label
  Friend WithEvents lblContactName As System.Windows.Forms.Label
  Friend WithEvents lblContactTitle As System.Windows.Forms.Label
  Friend WithEvents lblAddress As System.Windows.Forms.Label
  Friend WithEvents lblCity As System.Windows.Forms.Label
  Friend WithEvents editCustomerID As System.Windows.Forms.TextBox
  Friend WithEvents editCompanyName As System.Windows.Forms.TextBox
  Friend WithEvents editContactName As System.Windows.Forms.TextBox
  Friend WithEvents editContactTitle As System.Windows.Forms.TextBox
  Friend WithEvents editAddress As System.Windows.Forms.TextBox
  Friend WithEvents editCity As System.Windows.Forms.TextBox
  Friend WithEvents lblRegion As System.Windows.Forms.Label
  Friend WithEvents lblPostalCode As System.Windows.Forms.Label
  Friend WithEvents lblCountry As System.Windows.Forms.Label
  Friend WithEvents lblPhone As System.Windows.Forms.Label
  Friend WithEvents lblFax As System.Windows.Forms.Label
  Friend WithEvents editRegion As System.Windows.Forms.TextBox
  Friend WithEvents editPostalCode As System.Windows.Forms.TextBox
  Friend WithEvents editCountry As System.Windows.Forms.TextBox
  Friend WithEvents editPhone As System.Windows.Forms.TextBox
  Friend WithEvents editFax As System.Windows.Forms.TextBox
  Friend WithEvents btnNavFirst As System.Windows.Forms.Button
  Friend WithEvents btnNavPrev As System.Windows.Forms.Button
  Friend WithEvents lblNavLocation As System.Windows.Forms.Label
  Friend WithEvents btnNavNext As System.Windows.Forms.Button
  Friend WithEvents btnLast As System.Windows.Forms.Button
  Friend WithEvents btnAdd As System.Windows.Forms.Button
  Friend WithEvents btnDelete As System.Windows.Forms.Button
  Friend WithEvents btnCancel As System.Windows.Forms.Button
  Friend WithEvents grdOrders As System.Windows.Forms.DataGrid
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.OleDbSelectCommand1 = New System.Data.OleDb.OleDbCommand()
    Me.OleDbInsertCommand1 = New System.Data.OleDb.OleDbCommand()
    Me.OleDbUpdateCommand1 = New System.Data.OleDb.OleDbCommand()
    Me.OleDbDeleteCommand1 = New System.Data.OleDb.OleDbCommand()
    Me.OleDbSelectCommand2 = New System.Data.OleDb.OleDbCommand()
    Me.OleDbInsertCommand2 = New System.Data.OleDb.OleDbCommand()
    Me.OleDbUpdateCommand2 = New System.Data.OleDb.OleDbCommand()
    Me.OleDbDeleteCommand2 = New System.Data.OleDb.OleDbCommand()
    Me.objMyDS1 = New MyDataFormWizardSamp.MyDS1()
    Me.OleDbConnection1 = New System.Data.OleDb.OleDbConnection()
    Me.OleDbDataAdapter1 = New System.Data.OleDb.OleDbDataAdapter()
    Me.OleDbDataAdapter2 = New System.Data.OleDb.OleDbDataAdapter()
    Me.btnLoad = New System.Windows.Forms.Button()
    Me.btnUpdate = New System.Windows.Forms.Button()
    Me.btnCancelAll = New System.Windows.Forms.Button()
    Me.lblCustomerID = New System.Windows.Forms.Label()
    Me.lblCompanyName = New System.Windows.Forms.Label()
    Me.lblContactName = New System.Windows.Forms.Label()
    Me.lblContactTitle = New System.Windows.Forms.Label()
    Me.lblAddress = New System.Windows.Forms.Label()
    Me.lblCity = New System.Windows.Forms.Label()
    Me.editCustomerID = New System.Windows.Forms.TextBox()
    Me.editCompanyName = New System.Windows.Forms.TextBox()
    Me.editContactName = New System.Windows.Forms.TextBox()
    Me.editContactTitle = New System.Windows.Forms.TextBox()
    Me.editAddress = New System.Windows.Forms.TextBox()
    Me.editCity = New System.Windows.Forms.TextBox()
    Me.lblRegion = New System.Windows.Forms.Label()
    Me.lblPostalCode = New System.Windows.Forms.Label()
    Me.lblCountry = New System.Windows.Forms.Label()
    Me.lblPhone = New System.Windows.Forms.Label()
    Me.lblFax = New System.Windows.Forms.Label()
    Me.editRegion = New System.Windows.Forms.TextBox()
    Me.editPostalCode = New System.Windows.Forms.TextBox()
    Me.editCountry = New System.Windows.Forms.TextBox()
    Me.editPhone = New System.Windows.Forms.TextBox()
    Me.editFax = New System.Windows.Forms.TextBox()
    Me.btnNavFirst = New System.Windows.Forms.Button()
    Me.btnNavPrev = New System.Windows.Forms.Button()
    Me.lblNavLocation = New System.Windows.Forms.Label()
    Me.btnNavNext = New System.Windows.Forms.Button()
    Me.btnLast = New System.Windows.Forms.Button()
    Me.btnAdd = New System.Windows.Forms.Button()
    Me.btnDelete = New System.Windows.Forms.Button()
    Me.btnCancel = New System.Windows.Forms.Button()
    Me.grdOrders = New System.Windows.Forms.DataGrid()
    CType(Me.objMyDS1, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.grdOrders, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'OleDbSelectCommand1
    '
    Me.OleDbSelectCommand1.CommandText = "SELECT CustomerID, CompanyName, ContactName, ContactTitle, Address, City, Region," & _
    " PostalCode, Country, Phone, Fax FROM Customers"
    Me.OleDbSelectCommand1.Connection = Me.OleDbConnection1
    '
    'OleDbInsertCommand1
    '
    Me.OleDbInsertCommand1.CommandText = "INSERT INTO Customers(CustomerID, CompanyName, ContactName, ContactTitle, Address" & _
    ", City, Region, PostalCode, Country, Phone, Fax) VALUES (?, ?, ?, ?, ?, ?, ?, ?," & _
    " ?, ?, ?); SELECT CustomerID, CompanyName, ContactName, ContactTitle, Address, C" & _
    "ity, Region, PostalCode, Country, Phone, Fax FROM Customers WHERE (CustomerID = " & _
    "?)"
    Me.OleDbInsertCommand1.Connection = Me.OleDbConnection1
    Me.OleDbInsertCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("CustomerID", System.Data.OleDb.OleDbType.VarWChar, 5, "CustomerID"))
    Me.OleDbInsertCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("CompanyName", System.Data.OleDb.OleDbType.VarWChar, 40, "CompanyName"))
    Me.OleDbInsertCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("ContactName", System.Data.OleDb.OleDbType.VarWChar, 30, "ContactName"))
    Me.OleDbInsertCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("ContactTitle", System.Data.OleDb.OleDbType.VarWChar, 30, "ContactTitle"))
    Me.OleDbInsertCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Address", System.Data.OleDb.OleDbType.VarWChar, 60, "Address"))
    Me.OleDbInsertCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("City", System.Data.OleDb.OleDbType.VarWChar, 15, "City"))
    Me.OleDbInsertCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Region", System.Data.OleDb.OleDbType.VarWChar, 15, "Region"))
    Me.OleDbInsertCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("PostalCode", System.Data.OleDb.OleDbType.VarWChar, 10, "PostalCode"))
    Me.OleDbInsertCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Country", System.Data.OleDb.OleDbType.VarWChar, 15, "Country"))
    Me.OleDbInsertCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Phone", System.Data.OleDb.OleDbType.VarWChar, 24, "Phone"))
    Me.OleDbInsertCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Fax", System.Data.OleDb.OleDbType.VarWChar, 24, "Fax"))
    Me.OleDbInsertCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Select_CustomerID", System.Data.OleDb.OleDbType.VarWChar, 5, "CustomerID"))
    '
    'OleDbUpdateCommand1
    '
    Me.OleDbUpdateCommand1.CommandText = "UPDATE Customers SET CustomerID = ?, CompanyName = ?, ContactName = ?, ContactTit" & _
    "le = ?, Address = ?, City = ?, Region = ?, PostalCode = ?, Country = ?, Phone = " & _
    "?, Fax = ? WHERE (CustomerID = ?) AND (Address = ? OR ? IS NULL AND Address IS N" & _
    "ULL) AND (City = ? OR ? IS NULL AND City IS NULL) AND (CompanyName = ?) AND (Con" & _
    "tactName = ? OR ? IS NULL AND ContactName IS NULL) AND (ContactTitle = ? OR ? IS" & _
    " NULL AND ContactTitle IS NULL) AND (Country = ? OR ? IS NULL AND Country IS NUL" & _
    "L) AND (Fax = ? OR ? IS NULL AND Fax IS NULL) AND (Phone = ? OR ? IS NULL AND Ph" & _
    "one IS NULL) AND (PostalCode = ? OR ? IS NULL AND PostalCode IS NULL) AND (Regio" & _
    "n = ? OR ? IS NULL AND Region IS NULL); SELECT CustomerID, CompanyName, ContactN" & _
    "ame, ContactTitle, Address, City, Region, PostalCode, Country, Phone, Fax FROM C" & _
    "ustomers WHERE (CustomerID = ?)"
    Me.OleDbUpdateCommand1.Connection = Me.OleDbConnection1
    Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("CustomerID", System.Data.OleDb.OleDbType.VarWChar, 5, "CustomerID"))
    Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("CompanyName", System.Data.OleDb.OleDbType.VarWChar, 40, "CompanyName"))
    Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("ContactName", System.Data.OleDb.OleDbType.VarWChar, 30, "ContactName"))
    Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("ContactTitle", System.Data.OleDb.OleDbType.VarWChar, 30, "ContactTitle"))
    Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Address", System.Data.OleDb.OleDbType.VarWChar, 60, "Address"))
    Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("City", System.Data.OleDb.OleDbType.VarWChar, 15, "City"))
    Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Region", System.Data.OleDb.OleDbType.VarWChar, 15, "Region"))
    Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("PostalCode", System.Data.OleDb.OleDbType.VarWChar, 10, "PostalCode"))
    Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Country", System.Data.OleDb.OleDbType.VarWChar, 15, "Country"))
    Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Phone", System.Data.OleDb.OleDbType.VarWChar, 24, "Phone"))
    Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Fax", System.Data.OleDb.OleDbType.VarWChar, 24, "Fax"))
    Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_CustomerID", System.Data.OleDb.OleDbType.VarWChar, 5, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "CustomerID", System.Data.DataRowVersion.Original, Nothing))
    Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Address", System.Data.OleDb.OleDbType.VarWChar, 60, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Address", System.Data.DataRowVersion.Original, Nothing))
    Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Address1", System.Data.OleDb.OleDbType.VarWChar, 60, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Address", System.Data.DataRowVersion.Original, Nothing))
    Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_City", System.Data.OleDb.OleDbType.VarWChar, 15, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "City", System.Data.DataRowVersion.Original, Nothing))
    Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_City1", System.Data.OleDb.OleDbType.VarWChar, 15, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "City", System.Data.DataRowVersion.Original, Nothing))
    Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_CompanyName", System.Data.OleDb.OleDbType.VarWChar, 40, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "CompanyName", System.Data.DataRowVersion.Original, Nothing))
    Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_ContactName", System.Data.OleDb.OleDbType.VarWChar, 30, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ContactName", System.Data.DataRowVersion.Original, Nothing))
    Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_ContactName1", System.Data.OleDb.OleDbType.VarWChar, 30, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ContactName", System.Data.DataRowVersion.Original, Nothing))
    Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_ContactTitle", System.Data.OleDb.OleDbType.VarWChar, 30, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ContactTitle", System.Data.DataRowVersion.Original, Nothing))
    Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_ContactTitle1", System.Data.OleDb.OleDbType.VarWChar, 30, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ContactTitle", System.Data.DataRowVersion.Original, Nothing))
    Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Country", System.Data.OleDb.OleDbType.VarWChar, 15, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Country", System.Data.DataRowVersion.Original, Nothing))
    Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Country1", System.Data.OleDb.OleDbType.VarWChar, 15, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Country", System.Data.DataRowVersion.Original, Nothing))
    Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Fax", System.Data.OleDb.OleDbType.VarWChar, 24, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Fax", System.Data.DataRowVersion.Original, Nothing))
    Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Fax1", System.Data.OleDb.OleDbType.VarWChar, 24, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Fax", System.Data.DataRowVersion.Original, Nothing))
    Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Phone", System.Data.OleDb.OleDbType.VarWChar, 24, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Phone", System.Data.DataRowVersion.Original, Nothing))
    Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Phone1", System.Data.OleDb.OleDbType.VarWChar, 24, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Phone", System.Data.DataRowVersion.Original, Nothing))
    Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_PostalCode", System.Data.OleDb.OleDbType.VarWChar, 10, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "PostalCode", System.Data.DataRowVersion.Original, Nothing))
    Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_PostalCode1", System.Data.OleDb.OleDbType.VarWChar, 10, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "PostalCode", System.Data.DataRowVersion.Original, Nothing))
    Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Region", System.Data.OleDb.OleDbType.VarWChar, 15, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Region", System.Data.DataRowVersion.Original, Nothing))
    Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Region1", System.Data.OleDb.OleDbType.VarWChar, 15, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Region", System.Data.DataRowVersion.Original, Nothing))
    Me.OleDbUpdateCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Select_CustomerID", System.Data.OleDb.OleDbType.VarWChar, 5, "CustomerID"))
    '
    'OleDbDeleteCommand1
    '
    Me.OleDbDeleteCommand1.CommandText = "DELETE FROM Customers WHERE (CustomerID = ?) AND (Address = ? OR ? IS NULL AND Ad" & _
    "dress IS NULL) AND (City = ? OR ? IS NULL AND City IS NULL) AND (CompanyName = ?" & _
    ") AND (ContactName = ? OR ? IS NULL AND ContactName IS NULL) AND (ContactTitle =" & _
    " ? OR ? IS NULL AND ContactTitle IS NULL) AND (Country = ? OR ? IS NULL AND Coun" & _
    "try IS NULL) AND (Fax = ? OR ? IS NULL AND Fax IS NULL) AND (Phone = ? OR ? IS N" & _
    "ULL AND Phone IS NULL) AND (PostalCode = ? OR ? IS NULL AND PostalCode IS NULL) " & _
    "AND (Region = ? OR ? IS NULL AND Region IS NULL)"
    Me.OleDbDeleteCommand1.Connection = Me.OleDbConnection1
    Me.OleDbDeleteCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_CustomerID", System.Data.OleDb.OleDbType.VarWChar, 5, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "CustomerID", System.Data.DataRowVersion.Original, Nothing))
    Me.OleDbDeleteCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Address", System.Data.OleDb.OleDbType.VarWChar, 60, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Address", System.Data.DataRowVersion.Original, Nothing))
    Me.OleDbDeleteCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Address1", System.Data.OleDb.OleDbType.VarWChar, 60, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Address", System.Data.DataRowVersion.Original, Nothing))
    Me.OleDbDeleteCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_City", System.Data.OleDb.OleDbType.VarWChar, 15, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "City", System.Data.DataRowVersion.Original, Nothing))
    Me.OleDbDeleteCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_City1", System.Data.OleDb.OleDbType.VarWChar, 15, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "City", System.Data.DataRowVersion.Original, Nothing))
    Me.OleDbDeleteCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_CompanyName", System.Data.OleDb.OleDbType.VarWChar, 40, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "CompanyName", System.Data.DataRowVersion.Original, Nothing))
    Me.OleDbDeleteCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_ContactName", System.Data.OleDb.OleDbType.VarWChar, 30, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ContactName", System.Data.DataRowVersion.Original, Nothing))
    Me.OleDbDeleteCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_ContactName1", System.Data.OleDb.OleDbType.VarWChar, 30, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ContactName", System.Data.DataRowVersion.Original, Nothing))
    Me.OleDbDeleteCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_ContactTitle", System.Data.OleDb.OleDbType.VarWChar, 30, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ContactTitle", System.Data.DataRowVersion.Original, Nothing))
    Me.OleDbDeleteCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_ContactTitle1", System.Data.OleDb.OleDbType.VarWChar, 30, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ContactTitle", System.Data.DataRowVersion.Original, Nothing))
    Me.OleDbDeleteCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Country", System.Data.OleDb.OleDbType.VarWChar, 15, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Country", System.Data.DataRowVersion.Original, Nothing))
    Me.OleDbDeleteCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Country1", System.Data.OleDb.OleDbType.VarWChar, 15, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Country", System.Data.DataRowVersion.Original, Nothing))
    Me.OleDbDeleteCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Fax", System.Data.OleDb.OleDbType.VarWChar, 24, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Fax", System.Data.DataRowVersion.Original, Nothing))
    Me.OleDbDeleteCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Fax1", System.Data.OleDb.OleDbType.VarWChar, 24, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Fax", System.Data.DataRowVersion.Original, Nothing))
    Me.OleDbDeleteCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Phone", System.Data.OleDb.OleDbType.VarWChar, 24, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Phone", System.Data.DataRowVersion.Original, Nothing))
    Me.OleDbDeleteCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Phone1", System.Data.OleDb.OleDbType.VarWChar, 24, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Phone", System.Data.DataRowVersion.Original, Nothing))
    Me.OleDbDeleteCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_PostalCode", System.Data.OleDb.OleDbType.VarWChar, 10, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "PostalCode", System.Data.DataRowVersion.Original, Nothing))
    Me.OleDbDeleteCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_PostalCode1", System.Data.OleDb.OleDbType.VarWChar, 10, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "PostalCode", System.Data.DataRowVersion.Original, Nothing))
    Me.OleDbDeleteCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Region", System.Data.OleDb.OleDbType.VarWChar, 15, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Region", System.Data.DataRowVersion.Original, Nothing))
    Me.OleDbDeleteCommand1.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Region1", System.Data.OleDb.OleDbType.VarWChar, 15, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Region", System.Data.DataRowVersion.Original, Nothing))
    '
    'OleDbSelectCommand2
    '
    Me.OleDbSelectCommand2.CommandText = "SELECT OrderID, CustomerID, EmployeeID, OrderDate, RequiredDate, ShippedDate, Shi" & _
    "pVia, Freight, ShipName, ShipAddress, ShipCity, ShipRegion, ShipPostalCode, Ship" & _
    "Country FROM Orders"
    Me.OleDbSelectCommand2.Connection = Me.OleDbConnection1
    '
    'OleDbInsertCommand2
    '
    Me.OleDbInsertCommand2.CommandText = "INSERT INTO Orders(CustomerID, EmployeeID, OrderDate, RequiredDate, ShippedDate, " & _
    "ShipVia, Freight, ShipName, ShipAddress, ShipCity, ShipRegion, ShipPostalCode, S" & _
    "hipCountry) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?); SELECT OrderID, Cust" & _
    "omerID, EmployeeID, OrderDate, RequiredDate, ShippedDate, ShipVia, Freight, Ship" & _
    "Name, ShipAddress, ShipCity, ShipRegion, ShipPostalCode, ShipCountry FROM Orders" & _
    " WHERE (OrderID = @@IDENTITY)"
    Me.OleDbInsertCommand2.Connection = Me.OleDbConnection1
    Me.OleDbInsertCommand2.Parameters.Add(New System.Data.OleDb.OleDbParameter("CustomerID", System.Data.OleDb.OleDbType.VarWChar, 5, "CustomerID"))
    Me.OleDbInsertCommand2.Parameters.Add(New System.Data.OleDb.OleDbParameter("EmployeeID", System.Data.OleDb.OleDbType.Integer, 4, "EmployeeID"))
    Me.OleDbInsertCommand2.Parameters.Add(New System.Data.OleDb.OleDbParameter("OrderDate", System.Data.OleDb.OleDbType.DBTimeStamp, 8, "OrderDate"))
    Me.OleDbInsertCommand2.Parameters.Add(New System.Data.OleDb.OleDbParameter("RequiredDate", System.Data.OleDb.OleDbType.DBTimeStamp, 8, "RequiredDate"))
    Me.OleDbInsertCommand2.Parameters.Add(New System.Data.OleDb.OleDbParameter("ShippedDate", System.Data.OleDb.OleDbType.DBTimeStamp, 8, "ShippedDate"))
    Me.OleDbInsertCommand2.Parameters.Add(New System.Data.OleDb.OleDbParameter("ShipVia", System.Data.OleDb.OleDbType.Integer, 4, "ShipVia"))
    Me.OleDbInsertCommand2.Parameters.Add(New System.Data.OleDb.OleDbParameter("Freight", System.Data.OleDb.OleDbType.Currency, 8, "Freight"))
    Me.OleDbInsertCommand2.Parameters.Add(New System.Data.OleDb.OleDbParameter("ShipName", System.Data.OleDb.OleDbType.VarWChar, 40, "ShipName"))
    Me.OleDbInsertCommand2.Parameters.Add(New System.Data.OleDb.OleDbParameter("ShipAddress", System.Data.OleDb.OleDbType.VarWChar, 60, "ShipAddress"))
    Me.OleDbInsertCommand2.Parameters.Add(New System.Data.OleDb.OleDbParameter("ShipCity", System.Data.OleDb.OleDbType.VarWChar, 15, "ShipCity"))
    Me.OleDbInsertCommand2.Parameters.Add(New System.Data.OleDb.OleDbParameter("ShipRegion", System.Data.OleDb.OleDbType.VarWChar, 15, "ShipRegion"))
    Me.OleDbInsertCommand2.Parameters.Add(New System.Data.OleDb.OleDbParameter("ShipPostalCode", System.Data.OleDb.OleDbType.VarWChar, 10, "ShipPostalCode"))
    Me.OleDbInsertCommand2.Parameters.Add(New System.Data.OleDb.OleDbParameter("ShipCountry", System.Data.OleDb.OleDbType.VarWChar, 15, "ShipCountry"))
    '
    'OleDbUpdateCommand2
    '
    Me.OleDbUpdateCommand2.CommandText = "UPDATE Orders SET CustomerID = ?, EmployeeID = ?, OrderDate = ?, RequiredDate = ?" & _
    ", ShippedDate = ?, ShipVia = ?, Freight = ?, ShipName = ?, ShipAddress = ?, Ship" & _
    "City = ?, ShipRegion = ?, ShipPostalCode = ?, ShipCountry = ? WHERE (OrderID = ?" & _
    ") AND (CustomerID = ? OR ? IS NULL AND CustomerID IS NULL) AND (EmployeeID = ? O" & _
    "R ? IS NULL AND EmployeeID IS NULL) AND (Freight = ? OR ? IS NULL AND Freight IS" & _
    " NULL) AND (OrderDate = ? OR ? IS NULL AND OrderDate IS NULL) AND (RequiredDate " & _
    "= ? OR ? IS NULL AND RequiredDate IS NULL) AND (ShipAddress = ? OR ? IS NULL AND" & _
    " ShipAddress IS NULL) AND (ShipCity = ? OR ? IS NULL AND ShipCity IS NULL) AND (" & _
    "ShipCountry = ? OR ? IS NULL AND ShipCountry IS NULL) AND (ShipName = ? OR ? IS " & _
    "NULL AND ShipName IS NULL) AND (ShipPostalCode = ? OR ? IS NULL AND ShipPostalCo" & _
    "de IS NULL) AND (ShipRegion = ? OR ? IS NULL AND ShipRegion IS NULL) AND (ShipVi" & _
    "a = ? OR ? IS NULL AND ShipVia IS NULL) AND (ShippedDate = ? OR ? IS NULL AND Sh" & _
    "ippedDate IS NULL); SELECT OrderID, CustomerID, EmployeeID, OrderDate, RequiredD" & _
    "ate, ShippedDate, ShipVia, Freight, ShipName, ShipAddress, ShipCity, ShipRegion," & _
    " ShipPostalCode, ShipCountry FROM Orders WHERE (OrderID = ?)"
    Me.OleDbUpdateCommand2.Connection = Me.OleDbConnection1
    Me.OleDbUpdateCommand2.Parameters.Add(New System.Data.OleDb.OleDbParameter("CustomerID", System.Data.OleDb.OleDbType.VarWChar, 5, "CustomerID"))
    Me.OleDbUpdateCommand2.Parameters.Add(New System.Data.OleDb.OleDbParameter("EmployeeID", System.Data.OleDb.OleDbType.Integer, 4, "EmployeeID"))
    Me.OleDbUpdateCommand2.Parameters.Add(New System.Data.OleDb.OleDbParameter("OrderDate", System.Data.OleDb.OleDbType.DBTimeStamp, 8, "OrderDate"))
    Me.OleDbUpdateCommand2.Parameters.Add(New System.Data.OleDb.OleDbParameter("RequiredDate", System.Data.OleDb.OleDbType.DBTimeStamp, 8, "RequiredDate"))
    Me.OleDbUpdateCommand2.Parameters.Add(New System.Data.OleDb.OleDbParameter("ShippedDate", System.Data.OleDb.OleDbType.DBTimeStamp, 8, "ShippedDate"))
    Me.OleDbUpdateCommand2.Parameters.Add(New System.Data.OleDb.OleDbParameter("ShipVia", System.Data.OleDb.OleDbType.Integer, 4, "ShipVia"))
    Me.OleDbUpdateCommand2.Parameters.Add(New System.Data.OleDb.OleDbParameter("Freight", System.Data.OleDb.OleDbType.Currency, 8, "Freight"))
    Me.OleDbUpdateCommand2.Parameters.Add(New System.Data.OleDb.OleDbParameter("ShipName", System.Data.OleDb.OleDbType.VarWChar, 40, "ShipName"))
    Me.OleDbUpdateCommand2.Parameters.Add(New System.Data.OleDb.OleDbParameter("ShipAddress", System.Data.OleDb.OleDbType.VarWChar, 60, "ShipAddress"))
    Me.OleDbUpdateCommand2.Parameters.Add(New System.Data.OleDb.OleDbParameter("ShipCity", System.Data.OleDb.OleDbType.VarWChar, 15, "ShipCity"))
    Me.OleDbUpdateCommand2.Parameters.Add(New System.Data.OleDb.OleDbParameter("ShipRegion", System.Data.OleDb.OleDbType.VarWChar, 15, "ShipRegion"))
    Me.OleDbUpdateCommand2.Parameters.Add(New System.Data.OleDb.OleDbParameter("ShipPostalCode", System.Data.OleDb.OleDbType.VarWChar, 10, "ShipPostalCode"))
    Me.OleDbUpdateCommand2.Parameters.Add(New System.Data.OleDb.OleDbParameter("ShipCountry", System.Data.OleDb.OleDbType.VarWChar, 15, "ShipCountry"))
    Me.OleDbUpdateCommand2.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_OrderID", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "OrderID", System.Data.DataRowVersion.Original, Nothing))
    Me.OleDbUpdateCommand2.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_CustomerID", System.Data.OleDb.OleDbType.VarWChar, 5, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "CustomerID", System.Data.DataRowVersion.Original, Nothing))
    Me.OleDbUpdateCommand2.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_CustomerID1", System.Data.OleDb.OleDbType.VarWChar, 5, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "CustomerID", System.Data.DataRowVersion.Original, Nothing))
    Me.OleDbUpdateCommand2.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_EmployeeID", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "EmployeeID", System.Data.DataRowVersion.Original, Nothing))
    Me.OleDbUpdateCommand2.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_EmployeeID1", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "EmployeeID", System.Data.DataRowVersion.Original, Nothing))
    Me.OleDbUpdateCommand2.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Freight", System.Data.OleDb.OleDbType.Currency, 8, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Freight", System.Data.DataRowVersion.Original, Nothing))
    Me.OleDbUpdateCommand2.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Freight1", System.Data.OleDb.OleDbType.Currency, 8, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Freight", System.Data.DataRowVersion.Original, Nothing))
    Me.OleDbUpdateCommand2.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_OrderDate", System.Data.OleDb.OleDbType.DBTimeStamp, 8, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "OrderDate", System.Data.DataRowVersion.Original, Nothing))
    Me.OleDbUpdateCommand2.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_OrderDate1", System.Data.OleDb.OleDbType.DBTimeStamp, 8, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "OrderDate", System.Data.DataRowVersion.Original, Nothing))
    Me.OleDbUpdateCommand2.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_RequiredDate", System.Data.OleDb.OleDbType.DBTimeStamp, 8, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "RequiredDate", System.Data.DataRowVersion.Original, Nothing))
    Me.OleDbUpdateCommand2.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_RequiredDate1", System.Data.OleDb.OleDbType.DBTimeStamp, 8, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "RequiredDate", System.Data.DataRowVersion.Original, Nothing))
    Me.OleDbUpdateCommand2.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_ShipAddress", System.Data.OleDb.OleDbType.VarWChar, 60, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ShipAddress", System.Data.DataRowVersion.Original, Nothing))
    Me.OleDbUpdateCommand2.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_ShipAddress1", System.Data.OleDb.OleDbType.VarWChar, 60, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ShipAddress", System.Data.DataRowVersion.Original, Nothing))
    Me.OleDbUpdateCommand2.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_ShipCity", System.Data.OleDb.OleDbType.VarWChar, 15, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ShipCity", System.Data.DataRowVersion.Original, Nothing))
    Me.OleDbUpdateCommand2.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_ShipCity1", System.Data.OleDb.OleDbType.VarWChar, 15, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ShipCity", System.Data.DataRowVersion.Original, Nothing))
    Me.OleDbUpdateCommand2.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_ShipCountry", System.Data.OleDb.OleDbType.VarWChar, 15, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ShipCountry", System.Data.DataRowVersion.Original, Nothing))
    Me.OleDbUpdateCommand2.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_ShipCountry1", System.Data.OleDb.OleDbType.VarWChar, 15, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ShipCountry", System.Data.DataRowVersion.Original, Nothing))
    Me.OleDbUpdateCommand2.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_ShipName", System.Data.OleDb.OleDbType.VarWChar, 40, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ShipName", System.Data.DataRowVersion.Original, Nothing))
    Me.OleDbUpdateCommand2.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_ShipName1", System.Data.OleDb.OleDbType.VarWChar, 40, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ShipName", System.Data.DataRowVersion.Original, Nothing))
    Me.OleDbUpdateCommand2.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_ShipPostalCode", System.Data.OleDb.OleDbType.VarWChar, 10, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ShipPostalCode", System.Data.DataRowVersion.Original, Nothing))
    Me.OleDbUpdateCommand2.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_ShipPostalCode1", System.Data.OleDb.OleDbType.VarWChar, 10, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ShipPostalCode", System.Data.DataRowVersion.Original, Nothing))
    Me.OleDbUpdateCommand2.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_ShipRegion", System.Data.OleDb.OleDbType.VarWChar, 15, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ShipRegion", System.Data.DataRowVersion.Original, Nothing))
    Me.OleDbUpdateCommand2.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_ShipRegion1", System.Data.OleDb.OleDbType.VarWChar, 15, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ShipRegion", System.Data.DataRowVersion.Original, Nothing))
    Me.OleDbUpdateCommand2.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_ShipVia", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ShipVia", System.Data.DataRowVersion.Original, Nothing))
    Me.OleDbUpdateCommand2.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_ShipVia1", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ShipVia", System.Data.DataRowVersion.Original, Nothing))
    Me.OleDbUpdateCommand2.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_ShippedDate", System.Data.OleDb.OleDbType.DBTimeStamp, 8, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ShippedDate", System.Data.DataRowVersion.Original, Nothing))
    Me.OleDbUpdateCommand2.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_ShippedDate1", System.Data.OleDb.OleDbType.DBTimeStamp, 8, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ShippedDate", System.Data.DataRowVersion.Original, Nothing))
    Me.OleDbUpdateCommand2.Parameters.Add(New System.Data.OleDb.OleDbParameter("Select_OrderID", System.Data.OleDb.OleDbType.Integer, 4, "OrderID"))
    '
    'OleDbDeleteCommand2
    '
    Me.OleDbDeleteCommand2.CommandText = "DELETE FROM Orders WHERE (OrderID = ?) AND (CustomerID = ? OR ? IS NULL AND Custo" & _
    "merID IS NULL) AND (EmployeeID = ? OR ? IS NULL AND EmployeeID IS NULL) AND (Fre" & _
    "ight = ? OR ? IS NULL AND Freight IS NULL) AND (OrderDate = ? OR ? IS NULL AND O" & _
    "rderDate IS NULL) AND (RequiredDate = ? OR ? IS NULL AND RequiredDate IS NULL) A" & _
    "ND (ShipAddress = ? OR ? IS NULL AND ShipAddress IS NULL) AND (ShipCity = ? OR ?" & _
    " IS NULL AND ShipCity IS NULL) AND (ShipCountry = ? OR ? IS NULL AND ShipCountry" & _
    " IS NULL) AND (ShipName = ? OR ? IS NULL AND ShipName IS NULL) AND (ShipPostalCo" & _
    "de = ? OR ? IS NULL AND ShipPostalCode IS NULL) AND (ShipRegion = ? OR ? IS NULL" & _
    " AND ShipRegion IS NULL) AND (ShipVia = ? OR ? IS NULL AND ShipVia IS NULL) AND " & _
    "(ShippedDate = ? OR ? IS NULL AND ShippedDate IS NULL)"
    Me.OleDbDeleteCommand2.Connection = Me.OleDbConnection1
    Me.OleDbDeleteCommand2.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_OrderID", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "OrderID", System.Data.DataRowVersion.Original, Nothing))
    Me.OleDbDeleteCommand2.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_CustomerID", System.Data.OleDb.OleDbType.VarWChar, 5, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "CustomerID", System.Data.DataRowVersion.Original, Nothing))
    Me.OleDbDeleteCommand2.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_CustomerID1", System.Data.OleDb.OleDbType.VarWChar, 5, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "CustomerID", System.Data.DataRowVersion.Original, Nothing))
    Me.OleDbDeleteCommand2.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_EmployeeID", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "EmployeeID", System.Data.DataRowVersion.Original, Nothing))
    Me.OleDbDeleteCommand2.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_EmployeeID1", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "EmployeeID", System.Data.DataRowVersion.Original, Nothing))
    Me.OleDbDeleteCommand2.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Freight", System.Data.OleDb.OleDbType.Currency, 8, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Freight", System.Data.DataRowVersion.Original, Nothing))
    Me.OleDbDeleteCommand2.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_Freight1", System.Data.OleDb.OleDbType.Currency, 8, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Freight", System.Data.DataRowVersion.Original, Nothing))
    Me.OleDbDeleteCommand2.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_OrderDate", System.Data.OleDb.OleDbType.DBTimeStamp, 8, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "OrderDate", System.Data.DataRowVersion.Original, Nothing))
    Me.OleDbDeleteCommand2.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_OrderDate1", System.Data.OleDb.OleDbType.DBTimeStamp, 8, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "OrderDate", System.Data.DataRowVersion.Original, Nothing))
    Me.OleDbDeleteCommand2.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_RequiredDate", System.Data.OleDb.OleDbType.DBTimeStamp, 8, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "RequiredDate", System.Data.DataRowVersion.Original, Nothing))
    Me.OleDbDeleteCommand2.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_RequiredDate1", System.Data.OleDb.OleDbType.DBTimeStamp, 8, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "RequiredDate", System.Data.DataRowVersion.Original, Nothing))
    Me.OleDbDeleteCommand2.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_ShipAddress", System.Data.OleDb.OleDbType.VarWChar, 60, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ShipAddress", System.Data.DataRowVersion.Original, Nothing))
    Me.OleDbDeleteCommand2.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_ShipAddress1", System.Data.OleDb.OleDbType.VarWChar, 60, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ShipAddress", System.Data.DataRowVersion.Original, Nothing))
    Me.OleDbDeleteCommand2.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_ShipCity", System.Data.OleDb.OleDbType.VarWChar, 15, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ShipCity", System.Data.DataRowVersion.Original, Nothing))
    Me.OleDbDeleteCommand2.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_ShipCity1", System.Data.OleDb.OleDbType.VarWChar, 15, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ShipCity", System.Data.DataRowVersion.Original, Nothing))
    Me.OleDbDeleteCommand2.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_ShipCountry", System.Data.OleDb.OleDbType.VarWChar, 15, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ShipCountry", System.Data.DataRowVersion.Original, Nothing))
    Me.OleDbDeleteCommand2.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_ShipCountry1", System.Data.OleDb.OleDbType.VarWChar, 15, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ShipCountry", System.Data.DataRowVersion.Original, Nothing))
    Me.OleDbDeleteCommand2.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_ShipName", System.Data.OleDb.OleDbType.VarWChar, 40, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ShipName", System.Data.DataRowVersion.Original, Nothing))
    Me.OleDbDeleteCommand2.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_ShipName1", System.Data.OleDb.OleDbType.VarWChar, 40, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ShipName", System.Data.DataRowVersion.Original, Nothing))
    Me.OleDbDeleteCommand2.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_ShipPostalCode", System.Data.OleDb.OleDbType.VarWChar, 10, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ShipPostalCode", System.Data.DataRowVersion.Original, Nothing))
    Me.OleDbDeleteCommand2.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_ShipPostalCode1", System.Data.OleDb.OleDbType.VarWChar, 10, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ShipPostalCode", System.Data.DataRowVersion.Original, Nothing))
    Me.OleDbDeleteCommand2.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_ShipRegion", System.Data.OleDb.OleDbType.VarWChar, 15, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ShipRegion", System.Data.DataRowVersion.Original, Nothing))
    Me.OleDbDeleteCommand2.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_ShipRegion1", System.Data.OleDb.OleDbType.VarWChar, 15, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ShipRegion", System.Data.DataRowVersion.Original, Nothing))
    Me.OleDbDeleteCommand2.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_ShipVia", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ShipVia", System.Data.DataRowVersion.Original, Nothing))
    Me.OleDbDeleteCommand2.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_ShipVia1", System.Data.OleDb.OleDbType.Integer, 4, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ShipVia", System.Data.DataRowVersion.Original, Nothing))
    Me.OleDbDeleteCommand2.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_ShippedDate", System.Data.OleDb.OleDbType.DBTimeStamp, 8, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ShippedDate", System.Data.DataRowVersion.Original, Nothing))
    Me.OleDbDeleteCommand2.Parameters.Add(New System.Data.OleDb.OleDbParameter("Original_ShippedDate1", System.Data.OleDb.OleDbType.DBTimeStamp, 8, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ShippedDate", System.Data.DataRowVersion.Original, Nothing))
    '
    'objMyDS1
    '
    Me.objMyDS1.DataSetName = "MyDS1"
    Me.objMyDS1.Locale = New System.Globalization.CultureInfo("en-US")
    Me.objMyDS1.Namespace = "http://www.tempuri.org/MyDS1.xsd"
    '
    'OleDbConnection1
    '
    Me.OleDbConnection1.ConnectionString = "Provider=SQLOLEDB.1;Integrated Security=SSPI;Persist Security Info=False;Initial " & _
    "Catalog=Northwind;Data Source=MCB;Use Procedure for Prepare=1;Auto Translate=Tru" & _
    "e;Packet Size=4096;Workstation ID=MCB;Use Encryption for Data=False;Tag with col" & _
    "umn collation when possible=False"
    '
    'OleDbDataAdapter1
    '
    Me.OleDbDataAdapter1.DeleteCommand = Me.OleDbDeleteCommand1
    Me.OleDbDataAdapter1.InsertCommand = Me.OleDbInsertCommand1
    Me.OleDbDataAdapter1.SelectCommand = Me.OleDbSelectCommand1
    Me.OleDbDataAdapter1.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "Customers", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("CustomerID", "CustomerID"), New System.Data.Common.DataColumnMapping("CompanyName", "CompanyName"), New System.Data.Common.DataColumnMapping("ContactName", "ContactName"), New System.Data.Common.DataColumnMapping("ContactTitle", "ContactTitle"), New System.Data.Common.DataColumnMapping("Address", "Address"), New System.Data.Common.DataColumnMapping("City", "City"), New System.Data.Common.DataColumnMapping("Region", "Region"), New System.Data.Common.DataColumnMapping("PostalCode", "PostalCode"), New System.Data.Common.DataColumnMapping("Country", "Country"), New System.Data.Common.DataColumnMapping("Phone", "Phone"), New System.Data.Common.DataColumnMapping("Fax", "Fax")})})
    Me.OleDbDataAdapter1.UpdateCommand = Me.OleDbUpdateCommand1
    '
    'OleDbDataAdapter2
    '
    Me.OleDbDataAdapter2.DeleteCommand = Me.OleDbDeleteCommand2
    Me.OleDbDataAdapter2.InsertCommand = Me.OleDbInsertCommand2
    Me.OleDbDataAdapter2.SelectCommand = Me.OleDbSelectCommand2
    Me.OleDbDataAdapter2.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "Orders", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("OrderID", "OrderID"), New System.Data.Common.DataColumnMapping("CustomerID", "CustomerID"), New System.Data.Common.DataColumnMapping("EmployeeID", "EmployeeID"), New System.Data.Common.DataColumnMapping("OrderDate", "OrderDate"), New System.Data.Common.DataColumnMapping("RequiredDate", "RequiredDate"), New System.Data.Common.DataColumnMapping("ShippedDate", "ShippedDate"), New System.Data.Common.DataColumnMapping("ShipVia", "ShipVia"), New System.Data.Common.DataColumnMapping("Freight", "Freight"), New System.Data.Common.DataColumnMapping("ShipName", "ShipName"), New System.Data.Common.DataColumnMapping("ShipAddress", "ShipAddress"), New System.Data.Common.DataColumnMapping("ShipCity", "ShipCity"), New System.Data.Common.DataColumnMapping("ShipRegion", "ShipRegion"), New System.Data.Common.DataColumnMapping("ShipPostalCode", "ShipPostalCode"), New System.Data.Common.DataColumnMapping("ShipCountry", "ShipCountry")})})
    Me.OleDbDataAdapter2.UpdateCommand = Me.OleDbUpdateCommand2
    '
    'btnLoad
    '
    Me.btnLoad.Location = New System.Drawing.Point(10, 10)
    Me.btnLoad.Name = "btnLoad"
    Me.btnLoad.TabIndex = 0
    Me.btnLoad.Text = "&Load"
    '
    'btnUpdate
    '
    Me.btnUpdate.Location = New System.Drawing.Point(365, 10)
    Me.btnUpdate.Name = "btnUpdate"
    Me.btnUpdate.TabIndex = 1
    Me.btnUpdate.Text = "&Update"
    '
    'btnCancelAll
    '
    Me.btnCancelAll.Location = New System.Drawing.Point(365, 43)
    Me.btnCancelAll.Name = "btnCancelAll"
    Me.btnCancelAll.TabIndex = 2
    Me.btnCancelAll.Text = "Ca&ncel All"
    '
    'lblCustomerID
    '
    Me.lblCustomerID.Location = New System.Drawing.Point(10, 76)
    Me.lblCustomerID.Name = "lblCustomerID"
    Me.lblCustomerID.TabIndex = 3
    Me.lblCustomerID.Text = "CustomerID"
    '
    'lblCompanyName
    '
    Me.lblCompanyName.Location = New System.Drawing.Point(10, 109)
    Me.lblCompanyName.Name = "lblCompanyName"
    Me.lblCompanyName.TabIndex = 4
    Me.lblCompanyName.Text = "CompanyName"
    '
    'lblContactName
    '
    Me.lblContactName.Location = New System.Drawing.Point(10, 142)
    Me.lblContactName.Name = "lblContactName"
    Me.lblContactName.TabIndex = 5
    Me.lblContactName.Text = "ContactName"
    '
    'lblContactTitle
    '
    Me.lblContactTitle.Location = New System.Drawing.Point(10, 175)
    Me.lblContactTitle.Name = "lblContactTitle"
    Me.lblContactTitle.TabIndex = 6
    Me.lblContactTitle.Text = "ContactTitle"
    '
    'lblAddress
    '
    Me.lblAddress.Location = New System.Drawing.Point(10, 208)
    Me.lblAddress.Name = "lblAddress"
    Me.lblAddress.TabIndex = 7
    Me.lblAddress.Text = "Address"
    '
    'lblCity
    '
    Me.lblCity.Location = New System.Drawing.Point(10, 241)
    Me.lblCity.Name = "lblCity"
    Me.lblCity.TabIndex = 8
    Me.lblCity.Text = "City"
    '
    'editCustomerID
    '
    Me.editCustomerID.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.objMyDS1, "Customers.CustomerID"))
    Me.editCustomerID.Location = New System.Drawing.Point(120, 76)
    Me.editCustomerID.Name = "editCustomerID"
    Me.editCustomerID.TabIndex = 9
    Me.editCustomerID.Text = ""
    '
    'editCompanyName
    '
    Me.editCompanyName.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.objMyDS1, "Customers.CompanyName"))
    Me.editCompanyName.Location = New System.Drawing.Point(120, 109)
    Me.editCompanyName.Name = "editCompanyName"
    Me.editCompanyName.TabIndex = 10
    Me.editCompanyName.Text = ""
    '
    'editContactName
    '
    Me.editContactName.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.objMyDS1, "Customers.ContactName"))
    Me.editContactName.Location = New System.Drawing.Point(120, 142)
    Me.editContactName.Name = "editContactName"
    Me.editContactName.TabIndex = 11
    Me.editContactName.Text = ""
    '
    'editContactTitle
    '
    Me.editContactTitle.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.objMyDS1, "Customers.ContactTitle"))
    Me.editContactTitle.Location = New System.Drawing.Point(120, 175)
    Me.editContactTitle.Name = "editContactTitle"
    Me.editContactTitle.TabIndex = 12
    Me.editContactTitle.Text = ""
    '
    'editAddress
    '
    Me.editAddress.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.objMyDS1, "Customers.Address"))
    Me.editAddress.Location = New System.Drawing.Point(120, 208)
    Me.editAddress.Name = "editAddress"
    Me.editAddress.TabIndex = 13
    Me.editAddress.Text = ""
    '
    'editCity
    '
    Me.editCity.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.objMyDS1, "Customers.City"))
    Me.editCity.Location = New System.Drawing.Point(120, 241)
    Me.editCity.Name = "editCity"
    Me.editCity.TabIndex = 14
    Me.editCity.Text = ""
    '
    'lblRegion
    '
    Me.lblRegion.Location = New System.Drawing.Point(230, 76)
    Me.lblRegion.Name = "lblRegion"
    Me.lblRegion.TabIndex = 15
    Me.lblRegion.Text = "Region"
    '
    'lblPostalCode
    '
    Me.lblPostalCode.Location = New System.Drawing.Point(230, 109)
    Me.lblPostalCode.Name = "lblPostalCode"
    Me.lblPostalCode.TabIndex = 16
    Me.lblPostalCode.Text = "PostalCode"
    '
    'lblCountry
    '
    Me.lblCountry.Location = New System.Drawing.Point(230, 142)
    Me.lblCountry.Name = "lblCountry"
    Me.lblCountry.TabIndex = 17
    Me.lblCountry.Text = "Country"
    '
    'lblPhone
    '
    Me.lblPhone.Location = New System.Drawing.Point(230, 175)
    Me.lblPhone.Name = "lblPhone"
    Me.lblPhone.TabIndex = 18
    Me.lblPhone.Text = "Phone"
    '
    'lblFax
    '
    Me.lblFax.Location = New System.Drawing.Point(230, 208)
    Me.lblFax.Name = "lblFax"
    Me.lblFax.TabIndex = 19
    Me.lblFax.Text = "Fax"
    '
    'editRegion
    '
    Me.editRegion.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.objMyDS1, "Customers.Region"))
    Me.editRegion.Location = New System.Drawing.Point(340, 76)
    Me.editRegion.Name = "editRegion"
    Me.editRegion.TabIndex = 20
    Me.editRegion.Text = ""
    '
    'editPostalCode
    '
    Me.editPostalCode.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.objMyDS1, "Customers.PostalCode"))
    Me.editPostalCode.Location = New System.Drawing.Point(340, 109)
    Me.editPostalCode.Name = "editPostalCode"
    Me.editPostalCode.TabIndex = 21
    Me.editPostalCode.Text = ""
    '
    'editCountry
    '
    Me.editCountry.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.objMyDS1, "Customers.Country"))
    Me.editCountry.Location = New System.Drawing.Point(340, 142)
    Me.editCountry.Name = "editCountry"
    Me.editCountry.TabIndex = 22
    Me.editCountry.Text = ""
    '
    'editPhone
    '
    Me.editPhone.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.objMyDS1, "Customers.Phone"))
    Me.editPhone.Location = New System.Drawing.Point(340, 175)
    Me.editPhone.Name = "editPhone"
    Me.editPhone.TabIndex = 23
    Me.editPhone.Text = ""
    '
    'editFax
    '
    Me.editFax.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.objMyDS1, "Customers.Fax"))
    Me.editFax.Location = New System.Drawing.Point(340, 208)
    Me.editFax.Name = "editFax"
    Me.editFax.TabIndex = 24
    Me.editFax.Text = ""
    '
    'btnNavFirst
    '
    Me.btnNavFirst.Location = New System.Drawing.Point(195, 274)
    Me.btnNavFirst.Name = "btnNavFirst"
    Me.btnNavFirst.Size = New System.Drawing.Size(40, 23)
    Me.btnNavFirst.TabIndex = 25
    Me.btnNavFirst.Text = "<<"
    '
    'btnNavPrev
    '
    Me.btnNavPrev.Location = New System.Drawing.Point(235, 274)
    Me.btnNavPrev.Name = "btnNavPrev"
    Me.btnNavPrev.Size = New System.Drawing.Size(35, 23)
    Me.btnNavPrev.TabIndex = 26
    Me.btnNavPrev.Text = "<"
    '
    'lblNavLocation
    '
    Me.lblNavLocation.BackColor = System.Drawing.Color.White
    Me.lblNavLocation.Location = New System.Drawing.Point(270, 274)
    Me.lblNavLocation.Name = "lblNavLocation"
    Me.lblNavLocation.Size = New System.Drawing.Size(95, 23)
    Me.lblNavLocation.TabIndex = 27
    Me.lblNavLocation.Text = "No Records"
    Me.lblNavLocation.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
    '
    'btnNavNext
    '
    Me.btnNavNext.Location = New System.Drawing.Point(365, 274)
    Me.btnNavNext.Name = "btnNavNext"
    Me.btnNavNext.Size = New System.Drawing.Size(35, 23)
    Me.btnNavNext.TabIndex = 28
    Me.btnNavNext.Text = ">"
    '
    'btnLast
    '
    Me.btnLast.Location = New System.Drawing.Point(400, 274)
    Me.btnLast.Name = "btnLast"
    Me.btnLast.Size = New System.Drawing.Size(40, 23)
    Me.btnLast.TabIndex = 29
    Me.btnLast.Text = ">>"
    '
    'btnAdd
    '
    Me.btnAdd.Location = New System.Drawing.Point(195, 307)
    Me.btnAdd.Name = "btnAdd"
    Me.btnAdd.TabIndex = 30
    Me.btnAdd.Text = "&Add"
    '
    'btnDelete
    '
    Me.btnDelete.Location = New System.Drawing.Point(280, 307)
    Me.btnDelete.Name = "btnDelete"
    Me.btnDelete.TabIndex = 31
    Me.btnDelete.Text = "&Delete"
    '
    'btnCancel
    '
    Me.btnCancel.Location = New System.Drawing.Point(365, 307)
    Me.btnCancel.Name = "btnCancel"
    Me.btnCancel.TabIndex = 32
    Me.btnCancel.Text = "&Cancel"
    '
    'grdOrders
    '
    Me.grdOrders.AllowNavigation = False
    Me.grdOrders.DataMember = "Customers.CustOrderRelation1"
    Me.grdOrders.DataSource = Me.objMyDS1
    Me.grdOrders.HeaderForeColor = System.Drawing.SystemColors.ControlText
    Me.grdOrders.Location = New System.Drawing.Point(10, 340)
    Me.grdOrders.Name = "grdOrders"
    Me.grdOrders.Size = New System.Drawing.Size(430, 292)
    Me.grdOrders.TabIndex = 33
    '
    'DataForm2
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(442, 615)
    Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnLoad, Me.btnUpdate, Me.btnCancelAll, Me.lblCustomerID, Me.lblCompanyName, Me.lblContactName, Me.lblContactTitle, Me.lblAddress, Me.lblCity, Me.editCustomerID, Me.editCompanyName, Me.editContactName, Me.editContactTitle, Me.editAddress, Me.editCity, Me.lblRegion, Me.lblPostalCode, Me.lblCountry, Me.lblPhone, Me.lblFax, Me.editRegion, Me.editPostalCode, Me.editCountry, Me.editPhone, Me.editFax, Me.btnNavFirst, Me.btnNavPrev, Me.lblNavLocation, Me.btnNavNext, Me.btnLast, Me.btnAdd, Me.btnDelete, Me.btnCancel, Me.grdOrders})
    Me.Name = "DataForm2"
    Me.Text = "DataForm2"
    CType(Me.objMyDS1, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.grdOrders, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)

  End Sub

#End Region

  Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
    Me.BindingContext(objMyDS1, "Customers").CancelCurrentEdit()
    Me.objMyDS1_PositionChanged()

  End Sub
  Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
    If (Me.BindingContext(objMyDS1, "Customers").Count > 0) Then
      Me.BindingContext(objMyDS1, "Customers").RemoveAt(Me.BindingContext(objMyDS1, "Customers").Position)
      Me.objMyDS1_PositionChanged()
    End If

  End Sub
  Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
    Try
      'Clear out the current edits
      Me.BindingContext(objMyDS1, "Customers").EndCurrentEdit()
      Me.BindingContext(objMyDS1, "Customers").AddNew()
    Catch eEndEdit As System.Exception
      System.Windows.Forms.MessageBox.Show(eEndEdit.Message)
    End Try
    Me.objMyDS1_PositionChanged()

  End Sub
  Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
    Try
      'Attempt to update the datasource.
      Me.UpdateDataSet()
    Catch eUpdate As System.Exception
      'Add your error handling code here.
      'Display error message, if any.
      System.Windows.Forms.MessageBox.Show(eUpdate.Message)
    End Try
    Me.objMyDS1_PositionChanged()

  End Sub
  Private Sub btnLoad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoad.Click
    Try
      'Attempt to load the dataset.
      Me.LoadDataSet()
    Catch eLoad As System.Exception
      'Add your error handling code here.
      'Display error message, if any.
      System.Windows.Forms.MessageBox.Show(eLoad.Message)
    End Try
    Me.objMyDS1_PositionChanged()

  End Sub
  Private Sub btnNavFirst_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNavFirst.Click
    Me.BindingContext(objMyDS1, "Customers").Position = 0
    Me.objMyDS1_PositionChanged()

  End Sub
  Private Sub btnLast_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLast.Click
    Me.BindingContext(objMyDS1, "Customers").Position = (Me.objMyDS1.Tables("Customers").Rows.Count - 1)
    Me.objMyDS1_PositionChanged()

  End Sub
  Private Sub btnNavPrev_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNavPrev.Click
    Me.BindingContext(objMyDS1, "Customers").Position = (Me.BindingContext(objMyDS1, "Customers").Position - 1)
    Me.objMyDS1_PositionChanged()

  End Sub
  Private Sub btnNavNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNavNext.Click
    Me.BindingContext(objMyDS1, "Customers").Position = (Me.BindingContext(objMyDS1, "Customers").Position + 1)
    Me.objMyDS1_PositionChanged()

  End Sub
  Private Sub objMyDS1_PositionChanged()
    Me.lblNavLocation.Text = (((Me.BindingContext(objMyDS1, "Customers").Position + 1).ToString + " of  ") _
                + Me.BindingContext(objMyDS1, "Customers").Count.ToString)

  End Sub
  Private Sub btnCancelAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelAll.Click
    Me.objMyDS1.RejectChanges()

  End Sub
  Public Sub UpdateDataSet()
    'Create a new dataset to hold the changes that have been made to the main dataset.
    Dim objDataSetChanges As MyDataFormWizardSamp.MyDS1 = New MyDataFormWizardSamp.MyDS1()
    'Stop any current edits.
    Me.BindingContext(objMyDS1, "Customers").EndCurrentEdit()
    Me.BindingContext(objMyDS1, "Orders").EndCurrentEdit()
    'Get the changes that have been made to the main dataset.
    objDataSetChanges = CType(objMyDS1.GetChanges, MyDataFormWizardSamp.MyDS1)
    'Check to see if any changes have been made.
    If (Not (objDataSetChanges) Is Nothing) Then
      Try
        'There are changes that need to be made, so attempt to update the datasource by
        'calling the update method and passing the dataset and any parameters.
        Me.UpdateDataSource(objDataSetChanges)
        objMyDS1.Merge(objDataSetChanges)
        objMyDS1.AcceptChanges()
      Catch eUpdate As System.Exception
        'Add your error handling code here.
        Throw eUpdate
      End Try
      'Add your code to check the returned dataset for any errors that may have been
      'pushed into the row object's error.
    End If

  End Sub
  Public Sub LoadDataSet()
    'Create a new dataset to hold the records returned from the call to FillDataSet.
    'A temporary dataset is used because filling the existing dataset would
    'require the databindings to be rebound.
    Dim objDataSetTemp As MyDataFormWizardSamp.MyDS1
    objDataSetTemp = New MyDataFormWizardSamp.MyDS1()
    Try
      'Attempt to fill the temporary dataset.
      Me.FillDataSet(objDataSetTemp)
    Catch eFillDataSet As System.Exception
      'Add your error handling code here.
      Throw eFillDataSet
    End Try
    Try
      'Empty the old records from the dataset.
      objMyDS1.Clear()
      'Merge the records into the main dataset.
      objMyDS1.Merge(objDataSetTemp)
    Catch eLoadMerge As System.Exception
      'Add your error handling code here.
      Throw eLoadMerge
    End Try

  End Sub
  Public Sub UpdateDataSource(ByVal ChangedRows As MyDataFormWizardSamp.MyDS1)
    Try
      'The data source only needs to be updated if there are changes pending.
      If (Not (ChangedRows) Is Nothing) Then
        'Open the connection.
        Me.OleDbConnection1.Open()
        'Attempt to update the data source.
        OleDbDataAdapter1.Update(ChangedRows)
        OleDbDataAdapter2.Update(ChangedRows)
      End If
    Catch updateException As System.Exception
      'Add your error handling code here.
      Throw updateException
    Finally
      'Close the connection whether or not the exception was thrown.
      Me.OleDbConnection1.Close()
    End Try

  End Sub
  Public Sub FillDataSet(ByVal dataSet As MyDataFormWizardSamp.MyDS1)
    'Turn off constraint checking before the dataset is filled.
    'This allows the adapters to fill the dataset without concern
    'for dependencies between the tables.
    dataSet.EnforceConstraints = False
    Try
      'Open the connection.
      Me.OleDbConnection1.Open()
      'Attempt to fill the dataset through the OleDbDataAdapter1.
      Me.OleDbDataAdapter1.Fill(dataSet)
      Me.OleDbDataAdapter2.Fill(dataSet)
    Catch fillException As System.Exception
      'Add your error handling code here.
      Throw fillException
    Finally
      'Turn constraint checking back on.
      dataSet.EnforceConstraints = True
      'Close the connection whether or not the exception was thrown.
      Me.OleDbConnection1.Close()
    End Try

  End Sub
End Class
