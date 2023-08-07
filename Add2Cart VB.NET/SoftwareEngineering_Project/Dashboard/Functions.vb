Public Class Functions

    'copy data from textbox to textbox
    Public Shared Sub CopyNumericData(textBox1 As TextBox, textBox2 As TextBox)
        ' Get numeric data from first TextBox
        Dim numericData As Double = Double.Parse(textBox1.Text)

        ' Set the value of the second TextBox to the numeric data
        textBox2.Text = numericData.ToString()
    End Sub



    Public Shared Sub ResetComboBox(ByVal comboBox As ComboBox)
        comboBox.SelectedItem = Nothing
        comboBox.SelectedIndex = -1
    End Sub



    'usage:
    ' InputValidator.ValidateNumericTextbox(myTextBox, 12)
    ' InputValidator.ValidateAlphanumericTextbox(myTextBox, "_-", 12)
    'put that on load

    Public Shared Sub ValidateNumericTextbox(ByVal textbox As TextBox, ByVal maxLength As Integer)
        AddHandler textbox.KeyPress, Sub(sender As Object, e As KeyPressEventArgs)
                                         If Not Char.IsNumber(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
                                             e.Handled = True
                                         End If
                                         If textbox.TextLength >= maxLength AndAlso Not Char.IsControl(e.KeyChar) Then
                                             e.Handled = True
                                         End If
                                     End Sub
    End Sub



    Public Shared Sub ValidateAlphanumericTextbox(ByVal textbox As TextBox, ByVal allowedChars As String, ByVal maxLength As Integer)
        AddHandler textbox.KeyPress, Sub(sender As Object, e As KeyPressEventArgs)
                                         If Not Char.IsLetterOrDigit(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) AndAlso Not allowedChars.Contains(e.KeyChar) Then
                                             e.Handled = True
                                         End If
                                         If textbox.TextLength >= maxLength AndAlso Not Char.IsControl(e.KeyChar) Then
                                             e.Handled = True
                                         End If
                                     End Sub
    End Sub





    Public Shared Sub ComboBox_MySQL_PopulateProductName(ByVal comboBox As ComboBox, ByVal columnName As String, ByVal row As String, ByVal table As String)

        'Clear the ComboBox before populating it
        'comboBox.Items.Clear()
        Functions.ResetComboBox(comboBox) 'reset combobox


        Try
            'Open the database connection
            OpenConnection()
            cmd.Connection = conn

            'Create a new MySqlCommand object with the SQL SELECT statement to retrieve the data
            If row = "ALL" Then
                cmd.CommandText = "SELECT " & columnName & " FROM " & table & ""
            Else
                cmd.CommandText = "SELECT " & columnName & " FROM " & table & " LIMIT " & (row - 1) & ",1"
            End If

            ' Execute the query and read the result
            dr = cmd.ExecuteReader()

            'Add the "None" item to the ComboBox
            comboBox.Items.Add("None")

            'Loop through the data and add non-empty values to the ComboBox
            While dr.Read()
                Dim value As String = dr(columnName).ToString()
                If Not String.IsNullOrEmpty(value) Then
                    comboBox.Items.Add(value)
                End If
            End While

        Catch ex As Exception
            'SystemMsgBox.ShowErrorExceptionPopup(ex)

        Finally
            'Close the data reader and the database connection
            If dr IsNot Nothing Then
                dr.Close()
            End If

            CloseConnection()
        End Try

    End Sub




End Class
