
Imports System.Data.SqlClient

Partial Class _Default
    Inherits System.Web.UI.Page

    Dim cmd As SqlCommand
    Dim dr As SqlDataReader
    Dim connectionStr As String = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\Daniel\Documents\Visual Studio 2015\WebSites\TalkzApp\App_Data\TalkzApp.mdf"";Integrated Security=True"


    Protected Sub loginBtn_Click(sender As Object, e As EventArgs) Handles loginBtn.Click
        'Clear feedbackLabel
        validationFeedback.Value = ""

        'Set variable for both email and password
        Dim email As String = emailTxt.Text
        Dim password As String = passwordTxt.Text

        'Validate
        Dim emailValidationResult = helpFunctions.ValidateEmail(email)
        Dim passwordValidationResult = helpFunctions.ValidatePassword(password)
        Dim checkedInput = helpFunctions.ValidateUserInputLogin(emailValidationResult, passwordValidationResult)

        If checkedInput Then

            Dim result = helpFunctions.VerifyUser(connectionStr, email, password)

            If result Then
                Response.Redirect("main.aspx", False)
                validationFeedback.Value = "Successful Login"
            Else
                validationFeedback.Value = "New user? Create an account today"
            End If

        Else
            validationFeedback.Value = "Please enter a valid email/password (Password must be atleast 8 characters long)"
        End If


    End Sub


    Protected Sub createAccLbl_Click(sender As Object, e As EventArgs) Handles createAccLbl.Click

        'Clear feedbackLabel
        validationFeedback.Value = ""

        'Set variable for both email and password
        Dim email As String = emailTxt.Text
        Dim password As String = passwordTxt.Text

        'Validate
        Dim emailValidationResult = helpFunctions.ValidateEmail(email)
        Dim passwordValidationResult = helpFunctions.ValidatePassword(password)
        Dim checkedInput = helpFunctions.ValidateUserInputLogin(emailValidationResult, passwordValidationResult)

        If checkedInput Then

            Dim result = helpFunctions.VerifyUserEmail(connectionStr, email)

            If result Then
                validationFeedback.Value = "This email is already registered with an account"
            Else
                'Create new account 
                Dim usersIP = helpFunctions.GetUsersIP()
                Dim created = helpFunctions.createNewAccount(connectionStr, email, password, usersIP)
                If created Then
                    validationFeedback.Value = "Your new account is ready! You can now login"
                Else
                    validationFeedback.Value = "Error creating the account, please open a new support ticket"
                End If
            End If

        Else
            validationFeedback.Value = "Please enter a valid email/password (Password must be atleast 8 characters long)"
        End If


    End Sub

End Class
