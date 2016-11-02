/// <reference path="jquery-3.1.1.intellisense.js" />
//toast notification
function toastNotification(elementId, message, duration, background) {
    $("#" + elementId + "").stop().text(message).css("background-color", background).fadeIn(duration / 3).delay(duration / 3).fadeOut(duration / 3);
}

//redirect
function redirect(url) {
    $(location).attr("href", url);
}

//Send message details to backend
function sendMessageDataToBackEnd(messageData) {
    var person = {
        name: $("#id-name").val(),
        address: $("#id-address").val(),
        phone: $("#id-phone").val()
    }

    $.ajax({
        url: 'main.aspx/insertMessageToDB',
        type: 'post',
        dataType: 'json',
        data: messageData,
        success: function (data) {
            alert(data);
        },
        error: function () {
            alert("Error");
        }
        
    });
}


