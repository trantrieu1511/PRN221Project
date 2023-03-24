"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/notificationHub").build();


connection.on("Load", function () {
    location.href = '/TaskBoard'
});

connection.on("LoadMEDashboard", function () {
    location.href = '/EmployeeDashboard'
});

connection.start().then(function () {
    console.log('connected to hub');
}).catch(function (err) {
    return console.error(err.toString());



});

connection.on("OnConnected", function () {
    OnConnected();
});

function OnConnected() {
    var username = $('#hfUsername').val();
    console.log(username);
    connection.invoke("SaveUserConnection", username).catch(function (err) {
        return console.error(err.toString());
    })
}

connection.on("ReceivedNotification", function (message) {
    // alert(message);
    DisplayGeneralNotification(message, 'General Message');
});

connection.on("ReceivedPersonalNotification", function (message, username) {
    // alert(message + ' - ' + username);
    DisplayPersonalNotification(message, 'hey ' + username);
});

function DisplayGeneralNotification(message, title) {
    setTimeout(function () {
        toastr.options = {
            closeButton: true,
            progressBar: true,
            showMethod: 'slideDown',
            timeOut: 55000
            
        };
        toastr.success(message, title);

    }, 1300);
}

function DisplayPersonalNotification(message, title) {
    setTimeout(function () {
        toastr.options = {
            closeButton: true,
            progressBar: true,
            showMethod: 'slideDown',
            timeOut: 55000
        };
        toastr.success(message, title);

    }, 1300);
}
