var express = require('express');
var http = require('http');
var socketIO = require('socket.io');

var app = express();
var server = http.Server(app);
server.listen(5000);

var io = socketIO(server);

io.on('connection', function (socket) {
    console.log('client connected');

    socket.on('message.send',function(data){
        console.log(data.message);//message คือ key ที่ต้องการ
        
        socket.emit('message.send',data);

    });
});

console.log('server started');