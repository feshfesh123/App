var connection = new signalR.HubConnectionBuilder()
    .withUrl('/gameHub')
    .build();

connection.on('receive', (userJoined) => {
    console.log(message);
});

connection.start().catch(function (err) {
    return console.error(err.toString());
});

$("#test").click(function () {
    connection.invoke('join', userName);
});