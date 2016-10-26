
Imports System.Data.SqlClient

Partial Class _Default
    Inherits System.Web.UI.Page


    Dim conStr As SqlConnection
    Dim cmd As SqlCommand
    Dim dr As SqlDataReader


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

            Dim connectionStr = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\Daniel\Documents\Visual Studio 2015\WebSites\TalkzApp\App_Data\TalkzApp.mdf"";Integrated Security=True"
            Dim result = helpFunctions.VerifyUser(connectionStr, email, password)

            If result Then
                Response.Redirect("main.aspx", False)
                validationFeedback.Value = "Successful Login"
            Else
                validationFeedback.Value = "New user? Create an account today"
            End If

        Else
            validationFeedback.Value = "Please enter a valid email/password"
        End If


    End Sub


    Protected Sub createAccLbl_Click(sender As Object, e As EventArgs) Handles createAccLbl.Click

        'Set variable for both email and password
        Dim email As String = emailTxt.Text
        Dim password As String = passwordTxt.Text
        Dim connectionStr = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\Daniel\Documents\Visual Studio 2015\WebSites\TalkzApp\App_Data\TalkzApp.mdf"";Integrated Security=True"

        Dim result = helpFunctions.VerifyUser(connectionStr, email, password)


    End Sub

End Class
