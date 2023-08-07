Imports MySql.Data.MySqlClient

Module MySQLConnectionLink

    Public conn As New MySqlConnection
    Public cmd As New MySqlCommand
    Public dr As MySqlDataReader

    Public ConnectionStringLink As String = "Server=localhost;User Id=root;Password=password;Database=ciello_db;"


    'open connection
    Sub OpenConnection()

        Try

            If conn.State <> ConnectionState.Open Then
                conn.ConnectionString = ConnectionStringLink
                conn.Open()
            End If

        Catch ex As Exception
            Console.WriteLine("Failed to connect to MySQL Server: " + ex.Message)
            Console.WriteLine()
            MsgBox(ex.Message)
            conn.Close()
        End Try




    End Sub


    'close mysql connection
    Sub CloseConnection()
        If conn.State = ConnectionState.Open Then
            conn.Close()
            Console.WriteLine("MySQL Connection closed")
        End If
    End Sub

End Module
