Imports System.Drawing.Printing
Imports System.Runtime.InteropServices

Public Class FRM_Cashier_Dashboard

    'fields
    Private leftBorderBTN As Panel
    Private currentChildForm As Form
    Public Const WM_NCLBUTTONDOWN As Integer = &HA1
    Public Const HT_CAPTION As Integer = &H2

    Private IsFormBeingDragged As Boolean = False
    Private MouseDownX As Integer
    Private MouseDownY As Integer

    Private NONE_VAR As String = "None"

    Private totalQuantityChange As Integer = 0
    Private originalPrice As Decimal

    Private cartTable As New DataTable()
    Private transactionTable As New DataTable()

    'constructor
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        leftBorderBTN = New Panel()
        leftBorderBTN.Size = New Size(7, 50)

        PNL_Menu.Controls.Add(leftBorderBTN)

        'Form Settings
        Me.Text = String.Empty
        Me.ControlBox = False
        Me.DoubleBuffered = True
        Me.MaximizedBounds = Screen.PrimaryScreen.WorkingArea


    End Sub



    'update the price automatically
    Private Sub PriceUpdate()

        If CBO_ProductName.SelectedItem.ToString() = NONE_VAR Then
            ' Do something if "None" is selected
        Else

            OpenConnection()
            cmd.Connection = conn
            cmd.CommandText = "SELECT PRICERANGE FROM tbl_products WHERE PRODUCTNAME = @PRODUCTNAME"

            With cmd.Parameters
                .Clear()
                .AddWithValue("PRODUCTNAME", CBO_ProductName.Text)
            End With

            ' Execute the query and read the result
            Dim result As Object = cmd.ExecuteScalar()

            ' Check if a result was returned and assign it to the variable
            If result IsNot Nothing AndAlso Not IsDBNull(result) Then
                originalPrice = CDec(result)
            End If

            ' Close the DataReader
            cmd.Cancel()
            CloseConnection()
        End If

    End Sub


    'desigm the Columns of Cart Table
    Private Sub LoadCartTableColumns()
        ' Add columns to the DataTable
        cartTable.Columns.Add("PRODUCT NAME")
        cartTable.Columns.Add("ITEM PRICE", GetType(Decimal))
        cartTable.Columns.Add("QUANTITY", GetType(Integer))
        cartTable.Columns.Add("TOTAL ITEM PRICE", GetType(Decimal))

        ' Set the DataSource of the DataGridView to the DataTable
        CartDataGridView.DataSource = cartTable

    End Sub



    'desigm the Columns of Cart Table
    Private Sub LoadTransactionTableColumns()
        ' Add columns to the DataTable
        transactionTable.Columns.Add("TRANSACTION ID")
        transactionTable.Columns.Add("CUSTOMER NAME")
        transactionTable.Columns.Add("PAYMENT TYPE")
        transactionTable.Columns.Add("OVERALL TOTAL", GetType(Decimal))
        transactionTable.Columns.Add("TENDERED", GetType(Decimal))
        transactionTable.Columns.Add("CHANGE", GetType(Decimal))
        transactionTable.Columns.Add("DATE")

        ' Set the DataSource of the DataGridView to the DataTable
        TransactionDataGridView.DataSource = transactionTable
    End Sub


    'reset the items
    Private Sub ResetCartTXTs_AfterAdd2Cart()

        CBO_ProductName.SelectedIndex = 0

        'reset the NMRC_Quantity with the public variable,
        'if the data of ComboBox is changed
        totalQuantityChange = 0
        NMRC_Quantity.Value = 0

        TXT_Stocks.Text = ""
        TXT_ItemPrice.Text = "0.00"
        TXT_TotalItemPrice.Text = "0.00"

        BTN_UpdateCartItem.Enabled = False
        BTN_DeleteCartItem.Enabled = False
        BTN_DoneCartEditing.Enabled = False
        BTN_AddToCart.Enabled = True
        CBO_ProductName.Enabled = True
        BTN_CheckOut.Enabled = True

        'add data on TotalCheckOutAutomatically
        Load_TotalCheckoutAmount()

    End Sub


    'enable update&delete btn
    Private Sub EnableUpdateDelete()

        'add data on TotalCheckOutAutomatically
        Load_TotalCheckoutAmount()

        BTN_UpdateCartItem.Enabled = True
        BTN_DeleteCartItem.Enabled = True
        BTN_DoneCartEditing.Enabled = True
        BTN_AddToCart.Enabled = False
        BTN_CheckOut.Enabled = False

        CBO_ProductName.Enabled = False

    End Sub


    Private Sub ResetTables()
        ''clear the table

        'for reset of the TransactionDataGridView
        For Each row As DataGridViewRow In TransactionDataGridView.Rows
            TransactionDataGridView.Rows.Remove(row)
        Next

        For i As Integer = TransactionDataGridView.Rows.Count - 1 To 0 Step -1
            TransactionDataGridView.Rows.RemoveAt(i)
        Next


        'for reset of the CartDataGridView
        For i As Integer = CartDataGridView.Rows.Count - 1 To 0 Step -1
            Dim row As DataGridViewRow = CartDataGridView.Rows(i)
            CartDataGridView.Rows.Remove(row)
        Next

        'for reset of the CartDataGridView_COPY
        CartDataGridView_COPY.Rows.Clear()

        'For Each row As DataGridViewRow In CartDataGridView_COPY.Rows
        '    CartDataGridView_COPY.Rows.Remove(row)
        'Next
    End Sub




    'on every add to cart, the stocks will update automatically
    Private Sub UpdateStocks()

        'update data using ID
        Try
            OpenConnection()
            cmd.Connection = conn
            cmd.CommandText = "UPDATE tbl_products SET QUANTITY = @quantity WHERE PRODUCTNAME = '" & CBO_ProductName.Text & "' "

            With cmd.Parameters
                .Clear()
                .AddWithValue("quantity", TXT_Stocks.Text)
                cmd.ExecuteNonQuery()
            End With

            Console.WriteLine("Stock of Product: " + CBO_ProductName.Text + " has been updated to " + TXT_Stocks.Text + " stock(s).")
            CloseConnection()

        Catch ex As Exception 'catch error
            MsgBox(ex)
            CloseConnection()
        End Try

    End Sub


    'update the TXT_TotalAmountCheckOut
    Private Sub Load_TotalCheckoutAmount()

        Dim total As Decimal = 0

        For Each row As DataGridViewRow In CartDataGridView.Rows
            total += CDec(row.Cells("TOTAL ITEM PRICE").Value)
        Next

        TXT_TotalAmountCheckOut.Text = total.ToString("N2")
    End Sub



    'reset pay tab
    Private Sub ResetPay()
        ''TXT_TransactionID.Text = ""
        TXT_CustomerName.Text = ""
        TXT_Cash.Text = "0.00"
        TXT_Change.Text = "0.00"
    End Sub


    'copy the cart to duplicated table
    Private Sub CartDataGridView_COPYTBLDATA()

        CartDataGridView_COPY.Rows.Clear()


        'clear
        'For Each row As DataGridViewRow In CartDataGridView_COPY.Rows
        '    CartDataGridView_COPY.Rows.Remove(row)
        'Next


        ' Copy the columns from DataGridView1 to DataGridView2
        For Each column As DataGridViewColumn In CartDataGridView.Columns
            CartDataGridView_COPY.Columns.Add(column.Clone())
        Next

        ' Copy the rows from DataGridView1 to DataGridView2
        For Each row As DataGridViewRow In CartDataGridView.Rows
            ' Clone the row to preserve cell formatting
            Dim newRow As DataGridViewRow = CType(row.Clone(), DataGridViewRow)

            ' Copy the cell values from DataGridView1 to DataGridView2
            For i As Integer = 0 To row.Cells.Count - 1
                newRow.Cells(i).Value = row.Cells(i).Value
            Next

            ' Add the new row to DataGridView2
            CartDataGridView_COPY.Rows.Add(newRow)
        Next
    End Sub


    'random transaction id
    Private Function GenerateRandomNumber() As Integer
        Dim random As New Random()
        Dim randomNumber As Integer = random.Next(10000, 99999)

        ' Check if the number already exists in the database
        OpenConnection()
        cmd.Connection = conn
        cmd.CommandText = "SELECT COUNT(*) FROM tbl_transactions WHERE id = " & randomNumber
        Dim count As Integer = Convert.ToInt32(cmd.ExecuteScalar())
        CloseConnection()

        ' If the number already exists, recursively call the function again until a unique number is generated
        If count > 0 Then
            randomNumber = GenerateRandomNumber()
        End If

        Return randomNumber
    End Function

    Private Sub AutoNumberNo_TransactionID()
        ' Generate a unique random number
        Dim temp As Integer = GenerateRandomNumber()

        ' Set the generated number to the textbox
        TXT_TransactionID.Text = temp.ToString()
    End Sub




    'transactions to tbl_transactions db
    Private Sub SaveTransaction()
        'btn add

        Try
            OpenConnection()
            cmd.Connection = conn
            cmd.CommandText = "INSERT INTO tbl_transactions (id, CUSTOMERNAME, OVERALLTOTAL, TENDERED, CHANGEMONEY, DATE) VALUES (@id, @customername, @overalltotal, @tendered, @changemoney, @date)"

            With cmd.Parameters
                .Clear()
                .AddWithValue("id", TXT_TransactionID.Text)
                .AddWithValue("customername", TXT_CustomerName.Text)
                .AddWithValue("overalltotal", TXT_OverallTotal.Text)
                .AddWithValue("tendered", TXT_Cash.Text)
                .AddWithValue("changemoney", TXT_Change.Text)
                .AddWithValue("date", Date.Today)
                cmd.ExecuteNonQuery()
            End With

            MsgBox("Transaction Saved!")
            CloseConnection()

        Catch ex As Exception 'catch error
            Console.WriteLine(ex)
            MsgBox(ex)
            CloseConnection()
        End Try

    End Sub


    Private Sub FRM_Cashier_Dashboard_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        If WindowState = FormWindowState.Maximized Then
            FormBorderStyle = FormBorderStyle.None
        Else
            FormBorderStyle = FormBorderStyle.Fixed3D
        End If
    End Sub

    Private Sub PNL_Menu_Paint(sender As Object, e As PaintEventArgs) Handles PNL_Menu.Paint

    End Sub

    Private Sub ICON_Close_Click(sender As Object, e As EventArgs)

        ' Prompt the user to confirm that they want to exit the application
        Dim result As DialogResult = MessageBox.Show("Are you sure you want to exit?", "Confirm Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        ' If the user clicks "Yes", exit the application
        If result = DialogResult.Yes Then
            ' Check if there are any open forms other than the current form
            For Each form As Form In Application.OpenForms
                If form IsNot Me Then
                    ' If there is another form open, just close this form
                    Application.Exit()
                    Return
                End If
            Next

            ' If this is the last form open, exit the application
            Application.Exit()
        End If

    End Sub

    Private Sub ICON_Minimize_Click(sender As Object, e As EventArgs)
        WindowState = FormWindowState.Minimized
    End Sub


    'Drag Form
    <DllImportAttribute("user32.dll")>
    Public Shared Function SendMessage(ByVal hWnd As IntPtr, ByVal Msg As Integer, ByVal wParam As Integer, ByVal lParam As Integer) As Integer
    End Function

    <DllImportAttribute("user32.dll")>
    Public Shared Function ReleaseCapture() As Boolean
    End Function

    Private Sub ICON_Center_Click(sender As Object, e As EventArgs)
        Me.CenterToScreen()
    End Sub

    Private Sub BTN_Logout_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub FRM_Cashier_Dashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'set limit
        Functions.ValidateNumericTextbox(TXT_Cash, 10)

        'add the None and Product Items
        Functions.ComboBox_MySQL_PopulateProductName(CBO_ProductName, "PRODUCTNAME", "ALL", "tbl_products")

        'load the cart & transaction tables design columns
        LoadCartTableColumns()
        'enable and load this
        LoadTransactionTableColumns()

        TABPAGE_Pay.Enabled = False

    End Sub

    Private Sub Guna2DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)

    End Sub

    Private Sub CBO_ProductName_SelectedIndexChanged(sender As Object, e As EventArgs)


    End Sub


    Private Sub NMRC_Quantity_ValueChanged(sender As Object, e As EventArgs)


    End Sub

    Private Sub BTN_AddToCart_Click(sender As Object, e As EventArgs)


    End Sub

    Private Sub Cart_GridView_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles CartDataGridView.CellContentClick
        'click cell
        If e.RowIndex >= 0 Then
            Dim row As DataGridViewRow
            row = CartDataGridView.Rows(e.RowIndex)

            'convert the click to data
            CBO_ProductName.Text = row.Cells("PRODUCT NAME").Value
            NMRC_Quantity.Value = row.Cells("QUANTITY").Value
            TXT_ItemPrice.Text = row.Cells("ITEM PRICE").Value
            TXT_TotalItemPrice.Text = row.Cells("TOTAL ITEM PRICE").Value

            'enable update/delete btn
            EnableUpdateDelete()

        End If
    End Sub

    Private Sub BTN_CancelCartEditing_Click(sender As Object, e As EventArgs)


    End Sub

    Private Sub BTN_UpdateCartItem_Click(sender As Object, e As EventArgs)

    End Sub


    Private Sub Cart_GridView_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles CartDataGridView.CellValueChanged
        If e.ColumnIndex = CartDataGridView.Columns("TOTAL ITEM PRICE").Index Then
            Load_TotalCheckoutAmount()
        End If
    End Sub

    Private Sub PrintDocument1_PrintPage(sender As Object, e As PrintPageEventArgs)
        Dim bm As New Bitmap(Me.TransactionDataGridView.Width, Me.TransactionDataGridView.Height)
        TransactionDataGridView.DrawToBitmap(bm, New Rectangle(0, 0, Me.TransactionDataGridView.Width, Me.TransactionDataGridView.Height))
        e.Graphics.DrawImage(bm, 0, 0)
    End Sub

    Private Sub PrintDocument1_PrintPage_1(sender As Object, e As PrintPageEventArgs)

        Dim bm As New Bitmap(Me.TransactionDataGridView.Width, Me.TransactionDataGridView.Height)
        TransactionDataGridView.DrawToBitmap(bm, New Rectangle(30, 30, Me.TransactionDataGridView.Width, Me.TransactionDataGridView.Height))
        e.Graphics.DrawImage(bm, 0, 0)

    End Sub

    Private Sub PNL_TitleBar_MouseDown(sender As Object, e As MouseEventArgs) Handles PNL_TitleBar.MouseDown
        If e.Button = MouseButtons.Left Then
            IsFormBeingDragged = True
            MouseDownX = e.X
            MouseDownY = e.Y
        End If
    End Sub

    Private Sub PNL_TitleBar_MouseMove(sender As Object, e As MouseEventArgs) Handles PNL_TitleBar.MouseMove
        If IsFormBeingDragged Then

            Dim temp As Point = New Point()

            temp.X = Me.Location.X + (e.X - MouseDownX)
            temp.Y = Me.Location.Y + (e.Y - MouseDownY)
            Me.Location = temp
            temp = Nothing
        End If
    End Sub

    Private Sub PNL_TitleBar_MouseUp(sender As Object, e As MouseEventArgs) Handles PNL_TitleBar.MouseUp
        If e.Button = MouseButtons.Left Then
            IsFormBeingDragged = False
        End If
    End Sub

    Private Sub CBO_ProductName_SelectedIndexChanged_1(sender As Object, e As EventArgs) Handles CBO_ProductName.SelectedIndexChanged

        'if the selected item is NONE then, reset
        If CBO_ProductName.SelectedItem = NONE_VAR Or CBO_ProductName.SelectedItem = "" Then
            ResetCartTXTs_AfterAdd2Cart()
            NMRC_Quantity.Enabled = False
        Else

            NMRC_Quantity.Enabled = True

            OpenConnection()
            cmd.Connection = conn
            cmd.CommandText = "SELECT * FROM tbl_products WHERE PRODUCTNAME = @PRODUCTNAME"

            With cmd.Parameters
                .Clear()
                .AddWithValue("PRODUCTNAME", CBO_ProductName.Text) 'find data from search (using product name)
                cmd.ExecuteNonQuery()
            End With

            ' Execute the query and read the result
            dr = cmd.ExecuteReader()

            ' Retrieve values from database
            If dr.Read() Then

                Dim quantity As String = dr("QUANTITY").ToString()
                Dim price As String = dr("PRICERANGE").ToString()

                ' Paste the values into textboxes
                TXT_Stocks.Text = quantity
                TXT_ItemPrice.Text = price

                'close all connections
                dr.Close()
                CloseConnection()

                'reset the NMRC_Quantity with the public variable,
                'if the data of ComboBox is changed
                totalQuantityChange = 0
                NMRC_Quantity.Value = 0
                TXT_TotalItemPrice.Text = "0.00"

            Else ' no values found

                'reset the NMRC_Quantity with the public variable,
                'if the data of ComboBox is changed
                totalQuantityChange = 0
                NMRC_Quantity.Value = 0
                TXT_TotalItemPrice.Text = "0.00"


                dr.Close()
                CloseConnection()

            End If

            dr.Close()
            CloseConnection()

        End If


        'check if out of stock
        If NMRC_Quantity.Value = 0 AndAlso TXT_Stocks.Text = "0" Then
            MsgBox("Item " + CBO_ProductName.Text + " is Out of Stock!")
            Exit Sub
        End If


    End Sub

    Private Sub NMRC_Quantity_ValueChanged_1(sender As Object, e As EventArgs) Handles NMRC_Quantity.ValueChanged

        PriceUpdate()

        'set the original price if not set already
        If originalPrice = 0 Then
            originalPrice = Decimal.Parse(TXT_TotalItemPrice.Text)
        End If

        ' Get the current stock value from TXT_Stocks
        Dim currentStocks As Integer = Integer.Parse(TXT_Stocks.Text)

        ' Get the new quantity value from NMRC_Quantity
        Dim newQuantity As Integer = CInt(NMRC_Quantity.Value)

        ' Check if the new quantity value is negative and adjust it to zero
        If newQuantity < 0 Then
            newQuantity = 0
            NMRC_Quantity.Value = newQuantity
            Return
        End If

        ' Calculate the quantity change
        Dim quantityChange As Integer = newQuantity - totalQuantityChange

        ' Check if the quantity change is zero
        If quantityChange = 0 Then
            Return
        End If

        ' Calculate the new stock value based on the quantity change
        Dim newStocks As Integer = currentStocks - quantityChange


        ' Check if the new stock value is negative
        If newStocks < 0 Then
            ' Check if the current stock is already zero

            If currentStocks = 0 Then
                ' If it is, set the quantity value to zero and return without updating the stock value
                newQuantity = 0
                NMRC_Quantity.Value = newQuantity
                Return
            End If

            ' Display an error message and set the quantity value to the maximum available stock
            'MessageBox.Show("Out of stock")
            newQuantity = currentStocks
            NMRC_Quantity.Value = newQuantity
            totalQuantityChange = newQuantity
            newStocks = 0
        End If


        ' Update the total quantity change
        totalQuantityChange = newQuantity

        ' Calculate the new price value based on the new quantity
        Dim newPrice As Decimal
        If newQuantity <= 1 Then
            newPrice = originalPrice
        Else
            newPrice = originalPrice * newQuantity
        End If

        ' Update TXT_Price with the new price value
        If NMRC_Quantity.Value = 0 Then
            ' If the value of NMRC_Quantity is zero, set the price to ZERO
            TXT_TotalItemPrice.Text = "0"
        Else
            TXT_TotalItemPrice.Text = newPrice.ToString()
        End If


        ' Update TXT_Stocks with the new stock value
        TXT_Stocks.Text = newStocks.ToString()


    End Sub

    Private Sub BTN_AddToCart_Click_1(sender As Object, e As EventArgs) Handles BTN_AddToCart.Click

        'check if out of stock
        If NMRC_Quantity.Value = 0 AndAlso TXT_Stocks.Text = "0" Then
            MsgBox("Item " + CBO_ProductName.Text + " is Out of Stock!")
            Exit Sub
        End If

        'check TextBox if empty
        If CBO_ProductName.Text = "" Or CBO_ProductName.Text = NONE_VAR Or NMRC_Quantity.Value = 0 Or TXT_ItemPrice.Text = "" Or TXT_TotalItemPrice.Text = "0" Then
            MessageBox.Show("One of the Required Cart Information is empty!", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            NMRC_Quantity.Focus()
            Exit Sub
        End If

        ' Create a new cartTable with the data for the new item
        Dim newRow As DataRow = cartTable.NewRow()
        newRow("PRODUCT NAME") = CBO_ProductName.Text
        newRow("ITEM PRICE") = Decimal.Parse(TXT_ItemPrice.Text)
        newRow("QUANTITY") = NMRC_Quantity.Value
        newRow("TOTAL ITEM PRICE") = Decimal.Parse(TXT_TotalItemPrice.Text)

        ' Add the new row to the cartTable
        cartTable.Rows.Add(newRow)

        'on every add to cart, the stocks will update automatically
        UpdateStocks()

        'reset txt items
        ResetCartTXTs_AfterAdd2Cart()

    End Sub

    Private Sub BTN_UpdateCartItem_Click_1(sender As Object, e As EventArgs) Handles BTN_UpdateCartItem.Click

        ' Check if the item is already in the cart
        Dim existingRow As DataRow = cartTable.AsEnumerable().FirstOrDefault(Function(row) row("PRODUCT NAME"))

        'check if table is empty or not
        If CartDataGridView.RowCount = 0 OrElse CartDataGridView.ColumnCount = 0 Then
            MsgBox("Table is empty.")
            BTN_DoneCartEditing.PerformClick()
            Exit Sub
        End If

        'check if out of stock
        If NMRC_Quantity.Value = 0 AndAlso TXT_Stocks.Text = "0" Then
            MsgBox("Item " + CBO_ProductName.Text + " is Out of Stock! " & vbNewLine & "You cannot update this item, due to lack of stock.")
            Exit Sub
        End If

        'check TextBox if empty
        If CBO_ProductName.Text = "" Or CBO_ProductName.Text = NONE_VAR Or NMRC_Quantity.Value = 0 Or TXT_ItemPrice.Text = "" Or TXT_TotalItemPrice.Text = "0" Then
            MessageBox.Show("One of the Required Cart Information is empty!", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            NMRC_Quantity.Focus()
            Exit Sub
        End If

        ' Check if a row is selected
        If CartDataGridView.SelectedCells.Count = 0 Then
            MsgBox("Please select a data in rows or columns to update!")
            Exit Sub
        End If

        If existingRow IsNot Nothing Then
            ' If the item is already in the cart, update the quantity and total item price
            existingRow("QUANTITY") = NMRC_Quantity.Value
            existingRow("TOTAL ITEM PRICE") = Decimal.Parse(TXT_TotalItemPrice.Text)
        Else
            ' If the item is not already in the cart, create a new row with the data for the new item and add it to the cartTable
            Dim newRow As DataRow = cartTable.NewRow()
            newRow("PRODUCT NAME") = CBO_ProductName.Text
            newRow("ITEM PRICE") = Decimal.Parse(TXT_ItemPrice.Text)
            newRow("QUANTITY") = NMRC_Quantity.Value
            newRow("TOTAL ITEM PRICE") = Decimal.Parse(TXT_TotalItemPrice.Text)
            cartTable.Rows.Add(newRow)
        End If

        MsgBox("Cart Item " + CBO_ProductName.Text + " is Updated Sucessfully!")

        ' Update the stocks and reset the cart text boxes
        UpdateStocks()
        ResetCartTXTs_AfterAdd2Cart()

    End Sub

    Private Sub BTN_DeleteCartItem_Click(sender As Object, e As EventArgs) Handles BTN_DeleteCartItem.Click

        'check if table is empty or not
        If CartDataGridView.RowCount = 0 OrElse CartDataGridView.ColumnCount = 0 Then
            MsgBox("Table is empty.")
            BTN_DoneCartEditing.PerformClick()
            Exit Sub
        End If

        ' Check if a row is selected
        If CartDataGridView.SelectedCells.Count = 0 Then
            MsgBox("Please select a data in rows or columns to update!")
            Exit Sub
        End If

        Try
            OpenConnection()
            Dim selectedRow As DataGridViewRow = CartDataGridView.SelectedCells(0).OwningRow
            Dim productNameVAR As String = selectedRow.Cells("PRODUCT NAME").Value.ToString() 'get the product NAME value from the selected row
            Dim selectedQuantity As Integer = CInt(selectedRow.Cells("QUANTITY").Value) 'get the quantity column on the selected row

            'revert the QUANTITY VALUE back to database
            cmd.Connection = conn
            cmd.CommandText = "UPDATE tbl_products SET QUANTITY = QUANTITY + @selectedQuantity WHERE PRODUCTNAME = @productName"
            With cmd.Parameters
                .Clear()
                .AddWithValue("selectedQuantity", selectedQuantity)
                .AddWithValue("productName", productNameVAR)
                cmd.ExecuteNonQuery()
            End With

            'remove the selected row from the Cart_GridView
            CartDataGridView.Rows.RemoveAt(selectedRow.Index)

            'cancel editing if empty
            If CartDataGridView.RowCount = 0 OrElse CartDataGridView.ColumnCount = 0 Then
                BTN_DoneCartEditing.PerformClick()
            End If

            Console.WriteLine("Stocks of Product " & ProductName & " has been reverted back to the database, due to removal on Cart Table")
            CloseConnection()
        Catch ex As Exception 'catch error
            MsgBox(ex)
            CloseConnection()
        End Try

    End Sub

    Private Sub BTN_DoneCartEditing_Click(sender As Object, e As EventArgs) Handles BTN_DoneCartEditing.Click

        'Reset items
        ResetCartTXTs_AfterAdd2Cart()

        ' Deselect the selected row
        CartDataGridView.ClearSelection()


    End Sub

    Private Sub TXT_TotalAmountCheckOut2_TextChanged(sender As Object, e As EventArgs) Handles TXT_TotalAmountCheckOut.TextChanged

        If BTN_CheckOut.Enabled = True Or TXT_TotalAmountCheckOut.Text = "0" Or TXT_TotalAmountCheckOut.Text = "0.00" Or TXT_TotalAmountCheckOut.Text = "" Then
            BTN_CheckOut.Enabled = False
        Else
            BTN_CheckOut.Enabled = True
        End If

    End Sub

    Private Sub BTN_CheckOut2_Click(sender As Object, e As EventArgs) Handles BTN_CheckOut.Click


        If TXT_TotalAmountCheckOut.Text = "0" Or TXT_TotalAmountCheckOut.Text = "0.00" Or TXT_TotalAmountCheckOut.Text = "" Then
            MsgBox("Total Checkout Amount is Empty!")

        Else


            'load transaction id number

            AutoNumberNo_TransactionID()

            'set text to TXT_TotalAmountCheckOut from TXT_OverallTotal
            Functions.CopyNumericData(TXT_TotalAmountCheckOut, TXT_OverallTotal)


            'copy tbl items to duplicate
            CartDataGridView_COPYTBLDATA()

            'Reset checkout items
            ResetCartTXTs_AfterAdd2Cart()

            'enable the  checkout tab
            TABPAGE_Checkout.Enabled = False

            'enable the pay tab
            TABPAGE_Pay.Enabled = True

            'open payment tab
            TABCONTROL_Main.SelectedIndex = 1

            'Focus
            TXT_CustomerName.Focus()

            'disable this buttons
            BTN_DoneTransaction.Enabled = False

        End If

    End Sub

    Private Sub TXT_Tendered2_TextChanged(sender As Object, e As EventArgs) Handles TXT_Cash.TextChanged

        'important variables
        Dim payment1 As Double = Val(TXT_Cash.Text)
        Dim total1 As Double = Val(TXT_OverallTotal.Text)
        Dim change1 As Double = Val(TXT_Change.Text)

        Dim payment2 As Double = Math.Abs(payment1)
        Dim total2 As Double = Math.Abs(total1)
        Dim change2 As Double = Math.Abs(change1)


        'payment greater than total
        If payment2 >= total2 Then
            TXT_Change.Text = payment2 - total2

        ElseIf change2 < payment2 Then
            TXT_Change.Text = 0

        Else
            TXT_Change.Text = 0
        End If

    End Sub

    Private Sub BTN_LoadTransaction_Click(sender As Object, e As EventArgs) Handles BTN_Pay.Click

        'check TextBox if empty
        If TXT_CustomerName.Text = "" Or TXT_OverallTotal.Text = "0.00" Or TXT_OverallTotal.Text = "" Or TXT_Cash.Text = "0.00" Or TXT_Cash.Text = "" Then
            MessageBox.Show("One of the Required Transaction Information is empty!", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            TXT_CustomerName.Focus()
            Exit Sub
        End If

        'if total is less than tendered
        If Val(TXT_OverallTotal.Text) > Val(TXT_Cash.Text) Then
            MsgBox("Invalid!")
            TXT_Cash.Focus()
            Exit Sub
        End If

        ' Create a new cartTable with the data for the new item
        Dim newRow As DataRow = transactionTable.NewRow()
        newRow("TRANSACTION ID") = TXT_TransactionID.Text
        newRow("CUSTOMER NAME") = TXT_CustomerName.Text
        newRow("OVERALL TOTAL") = Decimal.Parse(TXT_OverallTotal.Text)
        newRow("TENDERED") = Decimal.Parse(TXT_Cash.Text)
        newRow("CHANGE") = Decimal.Parse(TXT_Change.Text)

        newRow("DATE") = Date.Today


        ' Add the new row to the cartTable
        transactionTable.Rows.Add(newRow)

        'reset txt items
        ResetCartTXTs_AfterAdd2Cart()

        'save transaction to database
        SaveTransaction()
        'popup also from SaveTransaction function

        'reset pay tab
        ResetPay()

        TXT_OverallTotal.Text = "0.00"

        BTN_Pay.Enabled = False
        BTN_DoneTransaction.Enabled = True
        'BTN_Print.Enabled = True

        ResetTables()

    End Sub

    Private Sub BTN_DoneTransaction_Click(sender As Object, e As EventArgs) Handles BTN_DoneTransaction.Click

        BTN_Pay.Enabled = True
        BTN_DoneTransaction.Enabled = False
        'BTN_Print.Enabled = False

        'Reset checkout items
        ResetCartTXTs_AfterAdd2Cart()

        'enable the  checkout tab
        TABPAGE_Checkout.Enabled = True

        'enable the pay tab
        TABPAGE_Pay.Enabled = False

        'open payment tab
        TABCONTROL_Main.SelectedIndex = 0

        'Focus
        CBO_ProductName.Focus()

    End Sub

    Private Sub BTN_ManageProducts_Click(sender As Object, e As EventArgs) Handles BTN_ManageProducts.Click

        FRM_Products.ShowDialog()

    End Sub

    Private Sub BTN_Exit_Click(sender As Object, e As EventArgs) Handles BTN_Exit.Click
        Application.Exit()
    End Sub

    Private Sub BTN_ManageReports_Click(sender As Object, e As EventArgs) Handles BTN_ManageReports.Click

        FRM_Report.ShowDialog()

    End Sub
End Class