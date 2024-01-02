$(function () {
    //jquery variables
    const textInput = $('#messageInput');
    const chat = $('#chat');
    const sendMessageBtn = $('#sendMessageBtn');
    const undoMessageBtn = $('#undoMessageBtn');
    const username = $('#username');
    const messagesQueue = [];

    var chatHub = new signalR.HubConnectionBuilder()
        .configureLogging(signalR.LogLevel.Information)
        .withUrl("/chatHub")
        .build();

    sendMessageBtn.attr('disabled', 'disabled');

    chatHub.start().then(function () {
        sendMessageBtn.removeAttr('disabled');
    }).catch(function (err) {
        return console.log(err.toString());
    });

    //when message is received then add message to chat
    chatHub.on('ReceiveMessage', function (message) {
        chatHub.invoke('AddMessageToHistory', message);
        addMessageToChat(message);
    });

    chatHub.on('MessageUndone', function (message) {
        undoMessage();
    });

    //Send message
    $('#messageInput').on('keydown', (e) => {
        if (e.code === 'Enter') {
            sendMessage();
        }
    });

    sendMessageBtn.on('click', () => {
        sendMessage();
    });


    function sendMessage() {
        messagesQueue.push(textInput.val());
        let text = messagesQueue.shift() || "";
        if (text.trim() === "") return;

        if (username.val().trim() === "") {
            $('#usernameStatus').addClass("text-danger");
            return;
        } else {
            $('#usernameStatus').removeClass("text-danger");
        }
        var currentDate = new Date();

        var options = {
            year: 'numeric',
            month: 'long',
            day: 'numeric',
            hour: '2-digit',
            minute: '2-digit',
            second: '2-digit',
        };

        var formattedDate = currentDate.toLocaleString('en-US', options);
        let msg = { SendTime: formattedDate, SenderName: username.val(), Image: null, Text: textInput.val() };
        textInput.val("");

        chatHub.invoke('SendMessage', JSON.stringify(msg));
    }

    undoMessageBtn.on('click', () => {
        undoMessage();
    });

    function undoMessage() {
        chatHub.invoke('UndoLastMessage')
            .then(() => {
                // Remove or alter the last message in the chat UI
                //chat.children().first().remove();
            })
            .catch(function (err) {
                console.error(err.toString());
            });
    }

    function addMessageToChat(message) {
        if (message != null) {
            var messageTemplate = 
                `<div class="chat-message-left pb-4">
                    <div class="flex-shrink-1 bg-light rounded py-2 px-3 mr-3">
                        <div class="font-weight-bold mb-1">
                            <div class="text-muted small" style="display:inline;">(${message.sendTime})</div>
                            <span class="bold">${message.senderName}</span>: ${message.text}
                        </div>
                    </div>
                </div>`;

            chat.prepend(messageTemplate);
        }
    }
});