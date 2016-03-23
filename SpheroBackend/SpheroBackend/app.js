/*function calcAngle(xDes, yDes, xCur, yCur)
{
	return Math.tan((yDes-yCur)/(xDes-xCur));
}

function calcPower(scale, xDes, yDes, xCur, yCur )
{
	return Math.sqrt(Math.pow(xDes-xCur,2)+Math.pow(yDes-yCur,2));
}

function rollTo(xDes, yDes)
{
	var angle=calcAngle(xDes, yDes,,);
	var power=calcPower(1, xDes, yDes,,);
	//roll( 
}
*/


"use strict";

var sphero = require("sphero");
var orb = sphero("COM4");
var azure = require("azure-storage");

var queueSvc = azure.createQueueService("spherogps", "WmRzzsQBg7huo47bUYxuZC9rW6KHyDxdyFRpIq7QmOXz+uqkGeoyHzqVjoeR8/eduGYt2gN3x2Z+hiv9hC2MRg==");
queueSvc.createQueueIfNotExists('spherocommands', function (error, result, response) {
    if (!error) {
    // Queue created or exists
    }
});
queueSvc.createQueueIfNotExists('spherotracking', function (error, result, response) {
    if (!error) {
    // Queue created or exists
    }
});

queueSvc.getMessages('spherocommands', { numOfMessages: 15, visibilityTimeout: 5 * 60 }, function (error, result, response) {
    if (!error) {
        // Messages retreived
        for (var index in result) {
            // text is available in result[index].messageText
            var message = result[index];
            console.log(message.messagetext);
            queueSvc.deleteMessage('spherocommands', message.messageid, message.popreceipt, function (error, response) {
                if (error) {
                    console.log('error: ' + error);
                }
                
            });
        }
    }
});





orb.connect(function () {
    orb.streamOdometer();
    
    orb.on("odometer", function (data) {
        console.log("::STREAMING ODOMETER::");
        //console.log("  data:", data);
        queueSvc.createMessage('spherotracking', data.xOdometer.value[0]+ ","+ data.yOdometer.value[0], function (error, result, response) {
            if (error) {
    // Message inserted
                console.log(error);
            }
        });
    });

 
});