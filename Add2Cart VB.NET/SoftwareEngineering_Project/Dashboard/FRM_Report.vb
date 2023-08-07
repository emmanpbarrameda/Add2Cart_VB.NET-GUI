Imports System.IO
Imports Spire.Doc


Public Class FRM_Report


    Private Sub Fill_CBOFilter()

        Try

            OpenConnection()
            cmd.Connection = conn
            cmd.CommandText = "SELECT DISTINCT PAYMENTTYPE FROM tbl_transactions WHERE PAYMENTTYPE IS NOT NULL"

            ' Execute the query and read the result
            dr = cmd.ExecuteReader()

            'clear CBO_Filters
            CBO_Filters.Items.Clear()

            'Loop through the results and add them to the combobox
            While dr.Read()
                CBO_Filters.Items.Add(dr("PAYMENTTYPE"))
            End While

            'close connection
            dr.Close()
            CloseConnection()

        Catch ex As Exception
            MsgBox(ex)
        End Try

    End Sub




    'clear all filters
    Private Sub Clear_Filters()
        'get data from select ALL data and create report
        GetDataFrom_Filters("SELECT * FROM tbl_transactions")
        CBO_Filters.SelectedIndex = -1

    End Sub




    'fetch data from database, depends on mysqlcommand condition
    Private Sub GetDataFrom_Filters(ByVal mysqlcommand As String)

        Dim filePath As String = Path.Combine(Application.StartupPath, "ReportTemplate", "report_template.docx")
        Dim fieldValues As New List(Of List(Of String))()

        'Replace placeholders with desired values
        Dim placeholders As Dictionary(Of String, String) = New Dictionary(Of String, String) From {
                                            {"[TimeVariable]", Date.Today()},
                                            {"[SortedBy]", CBO_Filters.Text}
                                        }



        'select data from database
        Try
            OpenConnection()
            cmd.Connection = conn
            cmd.CommandText = mysqlcommand

            ' Execute the query and read the result
            dr = cmd.ExecuteReader()

            ' Retrieve column names
            Dim colNames As New List(Of String)
            For i As Integer = 0 To dr.FieldCount - 1
                colNames.Add(dr.GetName(i))
            Next

            ' Add column names as the first row in fieldValues list
            fieldValues.Add(colNames)

            ' Add rows to the table for each record in the result set
            While dr.Read()
                Dim rowValues As New List(Of String)()
                For i As Integer = 0 To dr.FieldCount - 1
                    rowValues.Add(dr.GetValue(i).ToString())
                Next
                fieldValues.Add(rowValues)
            End While

            'close connection
            dr.Close()
            CloseConnection()

        Catch ex As Exception
            MsgBox(ex)
            dr.Close()
            CloseConnection()
        End Try


        ' Start the printing process on a background thread
        Dim t As New Threading.Thread(Sub()

                                          Try
                                              Dim doc As New Document()
                                              doc.LoadFromFile(filePath)

                                              ' Get the table in the document
                                              Dim table As Table = doc.Sections(0).Tables(0)

                                              ' Add rows to the table for each record in the result set
                                              For Each rowValues In fieldValues
                                                  Dim row As New TableRow(doc)
                                                  For Each value In rowValues
                                                      Dim cell As New TableCell(doc)
                                                      cell.AddParagraph().AppendText(value)
                                                      row.Cells.Add(cell)
                                                  Next
                                                  table.Rows.Add(row)
                                              Next

                                              ' Replace placeholders with desired values
                                              For Each placeholder In placeholders
                                                  doc.Replace(placeholder.Key, placeholder.Value, False, True)
                                              Next

                                              Dim ms As New MemoryStream()
                                              doc.SaveToStream(ms, Spire.Doc.FileFormat.PDF)
                                              ms.Position = 0 'Reset the position to the beginning of the stream

                                              Dim saveFilePath As String = Path.Combine(Application.StartupPath, "generated-report.pdf")
                                              File.WriteAllBytes(saveFilePath, ms.ToArray())

                                              'Dim result As DialogResult = MessageBox.Show("Report Generated Successfully!" & vbCrLf & vbCrLf & "Do you want to View the Generated Report?", "VIEW GENERATED REPORT", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

                                              'If result = DialogResult.Yes Then
                                              '   Process.Start(saveFilePath)
                                              'End If

                                              doc.Close()
                                              ms.Close()
                                              ms.Dispose()

                                              'view on pdf viewer
                                              Invoke(Sub() PdfViewer1.Refresh())
                                              Invoke(Sub() PdfViewer1.LoadFromFile(saveFilePath))


                                          Catch ex As Exception
                                              'Handle any exceptions that occur during the printing process
                                              MsgBox(ex)
                                          End Try
                                      End Sub)
        t.IsBackground = True
        t.Start()

    End Sub




    Private Sub FRM_Report_Load(sender As Object, e As EventArgs) Handles Me.Load

        'get data from mysql, then paste to combobox
        Fill_CBOFilter()

        'clear all filters
        Clear_Filters()

    End Sub



    Private Sub CBO_Filters_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CBO_Filters.SelectedIndexChanged

        'get data from select data, DEPENDS ON CBO_FILTERS, and create report
        GetDataFrom_Filters("SELECT * FROM tbl_transactions WHERE PAYMENTTYPE = '" & CBO_Filters.Text & "'")

    End Sub



    Private Sub BTN_ClearFilters_Click(sender As Object, e As EventArgs) Handles BTN_ClearFilters.Click
        Clear_Filters()
    End Sub



End Class