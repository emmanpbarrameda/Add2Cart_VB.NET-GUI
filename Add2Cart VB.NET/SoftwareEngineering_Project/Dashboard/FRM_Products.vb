Imports MySql.Data.MySqlClient

Public Class FRM_Products

    'layout table
    Private Sub LayoutTable()
        'For i As Integer = 0 To SellerTable.ColumnCount - 1
        '    SellerTable.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        'Next

        DataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells)

        'reset the scroll view
        DataGridView1.HorizontalScrollingOffset = 0

    End Sub


    'set table view ALL
    Private Sub LoadTableDataFromMySQL_ALL()
        Try

            BTN_Refresh.Text = "REFRESH ALL"

            'reset the Table First
            DataGridView1.DataSource = Nothing

            'get data from database
            OpenConnection()
            cmd.Connection = conn

            Dim queryString As String = "SELECT * FROM tbl_products"

            cmd.CommandText = queryString

            Dim dataAdapter As New MySqlDataAdapter(queryString, conn)
            Dim dataTable As New DataTable()
            dataAdapter.Fill(dataTable)

            If dataTable.Rows.Count > 0 Then
                DataGridView1.DataSource = dataTable
                'Console.WriteLine("Data found ")
            Else
                ''SystemMsgBox.ShowErrorPopup("No records found.")
            End If

            CloseConnection()

        Catch ex As Exception
            'if error:
            DataGridView1.DataSource = Nothing
            Console.WriteLine("Failed to fetch table data from MySQL Server: " + ex.Message)
            MsgBox(ex)
            CloseConnection()
        End Try
    End Sub


    'set table data from SELECTED/SEARCH
    Private Sub LoadTableDataFromMySQL_SELECTED()
        Try

            BTN_Refresh.Text = "REFRESH"

            'reset the Table First
            DataGridView1.DataSource = Nothing

            'get data from database
            OpenConnection()
            cmd.Connection = conn

            'Dim queryString As String = "SELECT * FROM tbl_users WHERE USERTYPE LIKE '%SELLER%'"
            Dim queryString As String = "SELECT * FROM tbl_products WHERE ID LIKE '" & TXT_ProductID.Text & "'"

            cmd.CommandText = queryString

            Dim dataAdapter As New MySqlDataAdapter(queryString, conn)
            Dim dataTable As New DataTable()
            dataAdapter.Fill(dataTable)

            DataGridView1.DataSource = dataTable
            CloseConnection()

        Catch ex As Exception

            'if error:
            DataGridView1.DataSource = Nothing
            Console.WriteLine("Failed to fetch table data from MySQL Server: " + ex.Message)
            MsgBox(ex.Message)
            CloseConnection()
        End Try
    End Sub



    Private Sub AutoNumberNo()

        ' Open the connection
        OpenConnection()
        cmd.Connection = conn

        Dim temp As Object = Nothing
        Dim tempAssigned As Boolean = False
        Try

            cmd.CommandText = "SELECT MAX(id) FROM tbl_products"

            dr = cmd.ExecuteReader
            If dr.HasRows Then
                dr.Read()
                temp = dr(0)
                If Not IsDBNull(temp) Then
                    temp = Convert.ToInt32(temp) + 1
                    tempAssigned = True
                Else
                    temp = 1
                    tempAssigned = True
                End If
            Else
                temp = 1
                tempAssigned = True
            End If

            dr.Close()
            CloseConnection()

        Catch ex As Exception
            MsgBox(ex)
            dr.Close()
            CloseConnection()
        End Try

        dr.Close()
        CloseConnection()


        If tempAssigned Then
            TXT_ProductID.Text = temp.ToString() ' result will appear in textbox txtId
        Else
            ' Handle case where temp is not assigned a valid value
            ' For example, display an error message or use a default value
        End If

    End Sub



    'clear and reset items
    Private Sub ClearAndRefresh()

        AutoNumberNo() 'refresh auto number

        'refresh table
        LayoutTable()
        LoadTableDataFromMySQL_ALL()

        'reset items
        TXT_Search.Focus()
        TXT_Search.Text = ""

        'reset items
        TXT_ProductName.Text = ""
        TXT_PriceRange.Text = ""
        NMRC_Quantity.Value = 0

        'disable update/delete btn
        BTN_Update.Enabled = False
        BTN_Delete.Enabled = False
        BTN_Add.Enabled = True

    End Sub


    'enable update&delete btn
    Private Sub EnableUpdateDelete()
        BTN_Update.Enabled = True
        BTN_Delete.Enabled = True
        BTN_Add.Enabled = False
    End Sub


    Private Sub FRM_Products_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'clear the txtboxes and refresh 
        ClearAndRefresh()

    End Sub






    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        'click cell
        If e.RowIndex >= 0 Then
            Dim row As DataGridViewRow
            row = DataGridView1.Rows(e.RowIndex)

            'convert the click to data
            TXT_Search.Text = row.Cells("id").Value
            TXT_ProductID.Text = row.Cells("id").Value
            TXT_ProductName.Text = row.Cells("PRODUCTNAME").Value
            TXT_PriceRange.Text = row.Cells("PRICERANGE").Value
            NMRC_Quantity.Value = row.Cells("QUANTITY").Value

            'enable update/delete btn
            EnableUpdateDelete()
        End If

        'set table data from SELECTED/SEARCH
        LoadTableDataFromMySQL_SELECTED()

    End Sub



    Private Sub TXT_Search_KeyDown(sender As Object, e As KeyEventArgs) Handles TXT_Search.KeyDown

        If e.KeyCode = Keys.Enter Then 'if Enter key is pressed
            BTN_Search.PerformClick() 'perform click on the search button
        End If
    End Sub


    Private Sub TXT_Search_TextChanged(sender As Object, e As EventArgs) Handles TXT_Search.TextChanged
        'disable/enable a button based on whether a textbox is empty or not
        If String.IsNullOrEmpty(TXT_Search.Text) Then 'empty
            BTN_Search.Enabled = False
            ClearAndRefresh() 'clear textboxes if button is disabled

        Else
            BTN_Search.Enabled = True 'not empty
        End If

    End Sub




    Private Sub BTN_Add_Click(sender As Object, e As EventArgs) Handles BTN_Add.Click

        'check TextBox if empty
        If TXT_ProductID.Text = "" Or TXT_ProductName.Text = "" Or TXT_PriceRange.Text = "" Or NMRC_Quantity.Value = 0 Then
            MessageBox.Show("One of the Required field is empty!", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        'check if there any duplication on username
        If TXT_ProductName.Text <> TXT_ProductNameDUMMY.Text Then
            OpenConnection()
            cmd.Connection = conn
            cmd.CommandText = "SELECT * from tbl_products where PRODUCTNAME = '" & TXT_ProductName.Text & "' "
            cmd.ExecuteNonQuery()

            dr = cmd.ExecuteReader
            If dr.HasRows Then
                MsgBox("Product Name Already Exist!")
                TXT_ProductName.Focus()
                dr.Close()
                CloseConnection()
                Exit Sub
            End If
            CloseConnection()
        End If

        'btn add
        Try
            OpenConnection()
            cmd.Connection = conn
            cmd.CommandText = "insert into tbl_products (id, PRODUCTNAME, PRICERANGE, QUANTITY) values(@productid, @productname, @pricerange, @quantity)"

            With cmd.Parameters
                .Clear()
                .AddWithValue("productid", TXT_ProductID.Text)
                .AddWithValue("productname", TXT_ProductName.Text)
                .AddWithValue("pricerange", TXT_PriceRange.Text)
                .AddWithValue("quantity", NMRC_Quantity.Value)
                cmd.ExecuteNonQuery()
            End With

            MsgBox("Record has been Saved!")
            CloseConnection()

            ClearAndRefresh()

            Application.Restart()

        Catch ex As Exception 'catch error
            MsgBox(ex)
            CloseConnection()
        End Try
    End Sub



    Private Sub BTN_Update_Click(sender As Object, e As EventArgs) Handles BTN_Update.Click
        'check TextBox if empty
        If TXT_ProductID.Text = "" Or TXT_ProductName.Text = "" Or TXT_PriceRange.Text = "" Or NMRC_Quantity.Value = 0 Then
            MessageBox.Show("One of the Required field is empty!", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        'update data using ID
        Try
            OpenConnection()
            cmd.Connection = conn
            cmd.CommandText = "UPDATE tbl_products SET PRODUCTNAME = @productname, PRICERANGE = @pricerange, QUANTITY = @quantity WHERE ID = @id"

            With cmd.Parameters
                .Clear()
                .AddWithValue("id", TXT_ProductID.Text)
                .AddWithValue("productname", TXT_ProductName.Text)
                .AddWithValue("pricerange", TXT_PriceRange.Text)
                .AddWithValue("quantity", NMRC_Quantity.Value)
                cmd.ExecuteNonQuery()
            End With

            MsgBox("Record of " + TXT_ProductName.Text + " has been updated!")
            CloseConnection()

            ClearAndRefresh()

        Catch ex As Exception 'catch error
            MsgBox(ex)
            CloseConnection()
        End Try
    End Sub

    Private Sub BTN_Delete_Click(sender As Object, e As EventArgs) Handles BTN_Delete.Click

        'confirmation first
        Dim result As DialogResult = MessageBox.Show("Are you sure you want to delete the record for product " & TXT_ProductName.Text & "?", "Confirmation", MessageBoxButtons.YesNo)

        'delete data using ID
        If result = DialogResult.Yes Then
            Try
                OpenConnection()
                cmd.Connection = conn
                cmd.CommandText = "DELETE FROM tbl_products WHERE id = @id"

                With cmd.Parameters
                    .Clear()
                    .AddWithValue("id", TXT_ProductID.Text)
                    cmd.ExecuteNonQuery()
                End With

                MsgBox("Record for product " + TXT_ProductName.Text + " (ID " + TXT_ProductID.Text + ") has been deleted!")
                CloseConnection()

                ClearAndRefresh()

            Catch ex As Exception 'catch error
                MsgBox(ex)
                CloseConnection()
            End Try
        Else
            ' Do nothing if user selects "No"
        End If

    End Sub


    Private Sub BTN_Clear_Click(sender As Object, e As EventArgs) Handles BTN_Clear.Click
        ClearAndRefresh() 'clear textbox
    End Sub


    Private Sub BTN_Refresh_Click(sender As Object, e As EventArgs) Handles BTN_Refresh.Click

        If BTN_Refresh.Text = "REFRESH" Then ' refresh SELECTED Table data
            LayoutTable()
            LoadTableDataFromMySQL_SELECTED()

        ElseIf BTN_Refresh.Text = "REFRESH ALL" Then ' refresh ALL Table data
            LayoutTable()
            LoadTableDataFromMySQL_ALL()
        End If
    End Sub

    Private Sub BTN_Search_Click(sender As Object, e As EventArgs) Handles BTN_Search.Click

        OpenConnection()
        cmd.Connection = conn
        cmd.CommandText = "SELECT * FROM tbl_products WHERE id = @id OR PRODUCTNAME = @PRODUCTNAME"

        With cmd.Parameters
            .Clear()
            .AddWithValue("id", TXT_Search.Text) 'find data based from search (using id)
            .AddWithValue("PRODUCTNAME", TXT_Search.Text) 'find data from search (using product name)
            cmd.ExecuteNonQuery()
        End With

        ' Execute the query and read the result
        dr = cmd.ExecuteReader()

        ' Retrieve values from database
        If dr.Read() Then

            Dim id As String = dr("id").ToString()
            Dim productname As String = dr("PRODUCTNAME").ToString()
            Dim pricerange As String = dr("PRICERANGE").ToString()
            Dim quantity As String = dr("QUANTITY").ToString()

            ' Paste the values into textboxes
            TXT_ProductID.Text = id
            TXT_ProductName.Text = productname
            TXT_PriceRange.Text = pricerange
            NMRC_Quantity.Value = quantity

            'close all connections
            dr.Close()
            CloseConnection()

            'Call the function to load SELECTED data to the table
            LoadTableDataFromMySQL_SELECTED()

            'enable update/delete btn
            EnableUpdateDelete()

        Else ' no values found

            dr.Close()
            CloseConnection()

            Dim dataTable As DataTable = DataGridView1.DataSource

            If dataTable Is Nothing OrElse dataTable.Rows.Count = 0 Then
                LoadTableDataFromMySQL_ALL() ' Call the function to load ALL data to the table
            End If

            MsgBox("No matching record found.")
            TXT_Search.Text = "" 'clear search txtbox if nothing

        End If

        dr.Close()
        CloseConnection()

    End Sub
End Class