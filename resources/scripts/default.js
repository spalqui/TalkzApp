/// <reference path="jquery-3.1.1.intellisense.js" />
/// <reference path="functions.js" />

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
        case "Please enter a valid email/password":
            toastNotification("default-toast", validationFeed, 3000, "red");
            break;
        case "New user? Create an account today":
            toastNotification("default-toast", validationFeed, 3000, "#E65100");
            break;
        default:

    }



})