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

    'Check User Details On DB
    Public Shared Function VerifyUser(ByVal connectionStr As String, email As String, password As String) As Boolean

        Dim sqlQuery As String = "SELECT * FROM users WHERE Email = '" & email & "' AND Password = '" & password & "';"

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





End Class
