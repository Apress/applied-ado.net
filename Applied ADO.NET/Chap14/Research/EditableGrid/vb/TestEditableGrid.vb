' TestEditableGrid.vb - code-behind file
Imports System
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Text
Imports System.Data
Imports System.Data.OleDb
Imports BWSLib.Controls

Namespace BWSLib 

	Public class MyPage 
        Inherits Page 
		' Declare as Public or Protected members all 
		' the controls in the layoutBin
		Protected grid as MyEditableGrid
		Protected m_connString as String


		' Page OnLoad
		Protected Sub Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
			m_connString = "PROVIDER=Microsoft.Jet.OLEDB.4.0;DATA SOURCE={0};"
			m_connString = String.Format(m_connString, Server.MapPath("myemployees.mdb"))
			
			If Not IsPostBack Then
				' Load data and refresh the view
				DataFromSourceToMemory()
				UpdateDataView()
			End If 
		End sub


		' DataFromSourceToMemory
		Private Sub DataFromSourceToMemory()
			' Gets rows from the data source
			Dim oDS As DataSet = PhysicalDataRead()
	
			' Stores it in the Cache cache
			Cache("MyData") = oDS
		End Sub


		' PhysicalDataRead
		Private Function PhysicalDataRead() As DataSet
			' Command  and connection string
			Dim strCmd As String = "SELECT * FROM Employees"
		
			Dim da As OleDbDataAdapter = New OleDbDataAdapter(strCmd, m_connString)
			Dim ds As DataSet = New DataSet()
			da.Fill(ds, "Employees")

			Return ds
		End Function


		' Returns data
		Private Function GetData() As DataView
			' Retrieves the data
			Dim ds As DataSet = CType(Cache("MyData"), DataSet)
			Dim dv As DataView = ds.Tables("Employees").DefaultView

			Return dv
		End Function



		' Refresh the UI
		Private Sub UpdateDataView()
			grid.DataSource = GetData()
			grid.DataBind()
		End Sub



		'''''''''''    EVENT HANDLERS   


		' EVENT HANDLER: SaveData
		Public Sub SaveData(sender As Object, e As DataGridCommandEventArgs)
            Dim sb As StringBuilder = New StringBuilder("")
			sb.Append("UPDATE Employees SET ")
			sb.Append("firstname='{0}',")
			sb.Append("lastname='{1}',")
			sb.Append("title='{2}',")
			sb.Append("country='{3}' ")
			sb.Append("WHERE employeeid={4}")
			Dim cmd As String = sb.ToString()
			
			Dim fName As TextBox = CType(e.Item.Cells(1).Controls(0), TextBox)
			Dim lName As TextBox = CType(e.Item.Cells(2).Controls(0), TextBox)
			Dim position As TextBox = CType(e.Item.Cells(3).Controls(0), TextBox)
			Dim country As TextBox = CType(e.Item.Cells(4).Controls(0), TextBox)
	
			cmd = String.Format(cmd, fName.Text, lName.Text, position.Text, country.Text, grid.DataKeys(e.Item.ItemIndex))

			' Executes the command
			Dim conn As OleDbConnection = New OleDbConnection(m_connString)
			Dim c As OleDbCommand = New OleDbCommand(cmd, conn)
			c.Connection.Open()
			c.ExecuteNonQuery()
			c.Connection.Close()

			DataFromSourceToMemory()
		End Sub


		' EVENT HANDLER: InsertData
		Public Sub InsertData(sender As Object, e As DataGridCommandEventArgs)
			Dim sb As StringBuilder = New StringBuilder("")
			sb.Append("INSERT INTO Employees (firstname, lastname, title, country) VALUES(")
			sb.Append("'{0}', '{1}', '{2}', '{3}')")
			Dim cmd As String = sb.ToString()	

			Dim fName As TextBox = CType(e.Item.Cells(1).Controls(0), TextBox)
			Dim lName As TextBox = CType(e.Item.Cells(2).Controls(0), TextBox)
			Dim position As TextBox = CType(e.Item.Cells(3).Controls(0), TextBox)
			Dim country As TextBox = CType(e.Item.Cells(4).Controls(0), TextBox)
	
			cmd = String.Format(cmd, fName.Text, lName.Text, position.Text, country.Text) 

			' Executes the command
			Dim conn As OleDbConnection = New OleDbConnection(m_connString)
			Dim c As OleDbCommand = New OleDbCommand(cmd, conn)
			c.Connection.Open()
			c.ExecuteNonQuery()
			c.Connection.Close()

			DataFromSourceToMemory()
		End Sub


		' EVENT HANDLER: DeleteData
		Public Sub DeleteData(sender As Object, e As DataGridCommandEventArgs)
			Dim cmd As String = "DELETE FROM Employees WHERE employeeid={0}"
			cmd = String.Format(cmd, grid.DataKeys(e.Item.ItemIndex))

			' Executes the command
			Dim conn As OleDbConnection = New OleDbConnection(m_connString)
			Dim c As OleDbCommand = New OleDbCommand(cmd, conn)
			c.Connection.Open()
			c.ExecuteNonQuery()
			c.Connection.Close()

			DataFromSourceToMemory()
		End Sub


		' EVENT HANDLER: OnInsert
		Public Sub OnInsert(sender As Object, e As EventArgs)
			grid.AddNewRow = true
			UpdateDataView()
		End Sub


		' EVENT HANDLER: InitRow
		Public Sub InitRow(sender As Object, e As DataGridInitRowEventArgs)
			e.Row("LastName") = "Esposito"
		End Sub
	

		' EVENT HANDLER: UpdateView
		Public Sub UpdateView(sender As Object, e As EventArgs)
			UpdateDataView()
		End Sub

	End Class
End Namespace
