/// <reference path="jquery-3.1.1.intellisense.js" />
/// <reference path="functions.js" />
/// <reference path="jquery-ui-1.12.1.js" />


$(function () {

    //DOM
    var validationFeedbackLbl = $("#mainContent_validationFeedback");
    var loginBtn = $("#mainContent_loginBtn");


    //Check for value change in feedback field
    var validationFeed = validationFeedbackLbl.val();

    switch (validationFeed) {
        case "Successful Login":
            toastNotification("default-toast", validationFeed, 3000, "green");
            break;
        case "Please enter a valid email/password (Password must be atleast 8 characters long)":
            toastNotification("default-toast", validationFeed, 3000, "red");
            break;
        case "New user? Create an account today":
            toastNotification("default-toast", validationFeed, 3000, "#E65100");
            break;
        case "Your new account is ready! You can now login":
            toastNotification("default-toast", validationFeed, 3000, "green");
            break;
        case "Error creating the account, please open a new support ticket":
            toastNotification("default-toast", validationFeed, 3000, "red");
            break;
        case "This email is already registered with an account":
            toastNotification("default-toast", validationFeed, 3000, "#E65100");
            break;
        default:

    }



})