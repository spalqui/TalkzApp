Imports System.Data.SqlClient
Imports Microsoft.SqlServer
Imports Microsoft.VisualBasic

Public Class helpFunctions
    Public Shared Property Response As Object


    'VALIDATIONS


    'Validate user input email
    Public Shared Function ValidateEmail(ByVal email As String) As Boolean

        Dim result As Boolean = True

        Try
            Dim vEmailAddress As New Net.Mail.MailAddress(email)
        Catch ex As Exception
            Return False
        End Try

        Return result

    End Function


    'Validate user input password
    Public Shared Function ValidatePassword(ByVal password As String) As Boolean

        Dim result As Boolean = True

        If Len(password) < 8 Then
            Return False
        End If

        Return result

    End Function

    'Validate User Input LogIn
    Public Shared Function ValidateUserInputLogin(ByVal emailValidation As Boolean, passwordValidation As Boolean) As Boolean

        Dim result As Boolean = False

        If emailValidation = True And passwordValidation = True Then
            Return True
        End If

        Return result

    End Function




    'LOGIN

    'Check if DB return data
    Public Shared Function DBReturnCheck(ByVal connectionStr As String, sqlQuery As String) As Boolean

        Using connection As New SqlConnection(connectionStr)
            connection.Open()

            Dim command As New SqlCommand(sqlQuery, connection)
            Dim reader As SqlDataReader = command.ExecuteReader()
            While reader.Read()
                Return True
            End While

            Return False

        End Using

        Return False

    End Function

    'Check number of rows affected DB
    'Check if DB return data
    Public Shared Function DBReturnRowsAffected(ByVal connectionStr As String, sqlQuery As String) As Integer

        Using connection As New SqlConnection(connectionStr)
            connection.Open()

            Dim command As New SqlCommand(sqlQuery, connection)
            Dim rowsAffected As Integer = command.ExecuteNonQuery()
            If rowsAffected <> 0 Then
                Return rowsAffected
            End If

            Return 0

        End Using

        Return False

    End Function


    'Check User Details On DB
    Public Shared Function VerifyUser(ByVal connectionStr As String, email As String, password As String) As Boolean

        Dim sqlQuery As String = "SELECT * FROM users WHERE Email = '" & email & "' AND Password = '" & password & "';"
        Dim result = helpFunctions.DBReturnCheck(connectionStr, sqlQuery)
        If result Then
            Return True
        End If

        Return False

    End Function


    'Create new account 

    'Check if email exists
    Public Shared Function VerifyUserEmail(ByVal connectionStr As String, email As String) As Boolean

        Dim sqlQuery As String = "SELECT * FROM users WHERE Email = '" & email & "';"
        Dim result = helpFunctions.DBReturnCheck(connectionStr, sqlQuery)
        If result Then
            Return True
        End If

        Return False

    End Function

    'Register User
    Public Shared Function createNewAccount(ByVal connectionStr As String, email As String, password As String, usersIP As String) As Boolean

        Dim sqlQuery As String = "INSERT INTO dbo.users (Email, Password, IP) VALUES ('" + email + "', '" + password + "', '" + usersIP + "');"
        Dim rowsAffected = helpFunctions.DBReturnRowsAffected(connectionStr, sqlQuery)

        If rowsAffected > 0 Then
            Return True
        End If

        Return False

    End Function

    'Get User's IP
    Public Shared Function GetUsersIP() As String

        Dim context As System.Web.HttpContext = System.Web.HttpContext.Current
        Dim sIPAddress As String = context.Request.ServerVariables("HTTP_X_FORWARDED_FOR")
        If String.IsNullOrEmpty(sIPAddress) Then
            Return context.Request.ServerVariables("REMOTE_ADDR")
        Else
            Dim ipArray As String() = sIPAddress.Split(New [Char]() {","c})
            Return ipArray(0)
        End If

    End Function


End Class
