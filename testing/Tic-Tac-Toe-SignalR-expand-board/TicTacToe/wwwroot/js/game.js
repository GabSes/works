$(function () {
    // by default, the FindGame button should be disabled until a connection to the Hub is made
    // but the username textbox is enabled until the game has started
    disableInput();
    $('#username').removeAttr('disabled');

    // CLIENT STATE
    // The ID of this player
    let playerId;

    // Create a SignalR connection instance
    var gameHub = new signalR.HubConnectionBuilder()
        .configureLogging(signalR.LogLevel.Information)
        .withUrl("/gameHub") // Use the correct URL for your SignalR hub
        .build();

    // Start the connection
    gameHub.start()
        .then(() => {
            // Connection is successfully established
            // Enable the FindGame button
            enableInput();
        })
        .catch(error => {
            console.error(error);
        });

    // CLIENT METHODS
    // Prevent players from joining again
    gameHub.on("playerJoined", (player) => {
        playerId = player['id'];
        $('#usernameStatus').removeClass("text-danger");
        //disableInput();
    });

    // The username is already taken
    gameHub.on("usernameTaken", () => {
        $('#usernameStatus').html("The username is already taken.");
        $('#usernameStatus').addClass("text-danger");
        enableInput();
    });

    gameHub.on("roomnameTaken", () => {
        $('#gameStatus').html("The room name already exists.");
        $('#gameStatus').addClass('text-danger');
        enableInput();
    });

    gameHub.on("cannotEnterRoom", () => {
        $('#gameStatus').html("The room is already full or it does not exist.");
        $('#gameStatus').addClass('text-danger');
        enableInput();
    });

    // The opponent left, so the game is over and allow the player to find a new game
    gameHub.on("opponentLeft", () => {
        $('#gameStatus').html("Opponent has left. Game over.");
        endGame();
    });

    // Notify the player that they are in a waiting pool for another opponent
    gameHub.on("waitingList", () => {
        $('#gameStatus').html("Waiting for an opponent.");
    });

    gameHub.on("startHost", () => {
        $('#gameStatus').html("Waiting for an opponent.");
    });

    // Starts a new game by displaying the board and showing whose turn it is
    gameHub.on("startGame", (game) => {
        let jsonObject = JSON.parse(game);
        buildBoard(jsonObject['Board']);
        const opponent = getOpponent(jsonObject);
        displayOpponent(opponent);
        displayTurn(jsonObject.WhoseTurn, true);
    });

    // Handles the case where a user tried to place a piece not on their turn
    gameHub.on("notPlayersTurn", () => {
        $('#gameStatus').html("Please wait your turn.");
    });

    // Display a message if the move is not valid
    gameHub.on("notValidMove", () => {
        $('#gameStatus').html("Please choose another location.");
    });

    // A piece has been placed on the board
    gameHub.on("piecePlaced", (row, col, piece) => {
        $('td[id='+row + '-' + col+']').html(piece);
    });

    // TODO: can be combined with piecePlaced by having the server
    // send the whole game object, render the board and update in one method
    gameHub.on("updateTurn", (game) => {
        let jsonObject = JSON.parse(game);
        displayTurn(jsonObject.WhoseTurn);
    });

    // Handle the tie game - game over scenario
    gameHub.on("tieGame", () => {
        $('#gameStatus').html("Tie!");
        endGame();
    });

    // Handle the tie game - game over scenario
    gameHub.on("winner", (playerName) => {
        $('#gameStatus').html("Winner: " + playerName);
        endGame();
    });

    gameHub.on("couldNotJoinGame", () => {
        $('#gameStatus').html("Could not join game.");
    });

    gameHub.on("gameEnded", () => {
        $('#gameStatus').html("Game ended.");
    });

    //this is for prototype. comment to disable it
    gameHub.on("showCloneDiff", (gamePrototype) => {
        let objects = JSON.parse(gamePrototype);
        let text = `Before changes: </br> Player1 playing room: ${objects.OriginalPlayer1Room} </br> Player2 playing room: ${objects.OriginalPlayer2Room} </br>`;
        $('#deep').html("Deep Copy </br>" + text + `After changes: </br> Player1 playing room: ${objects.GameDeepCopy.Player1.PlayingRoomName} </br> Player2 playing room: ${objects.GameDeepCopy.Player2.PlayingRoomName}`);
        $('#original').html("Original </br>" + text + `After changes: </br> Player1 playing room: ${objects.GameOriginal.Player1.PlayingRoomName} </br> Player2 playing room: ${objects.GameOriginal.Player2.PlayingRoomName}`);
        $('#shallow').html("Shallow Copy </br>" + text + `After changes: </br> Player1 playing room: ${objects.GameShallowCopy.Player1.PlayingRoomName} </br> Player2 playing room: ${objects.GameShallowCopy.Player2.PlayingRoomName}`);
    });

    //-----------------------------------------------------------------------------------
    //                               JQUERY/FUNCTIONS
    //-----------------------------------------------------------------------------------
    $('#hostGame').click(() => {
        let result = removeWhiteSpace();
        let boardSize = parseInt($("#boardSize").val());
        let toggleObstacles = $("#obstacles").is(":checked") === "true" ? true : false;

        if (result[0]) {
            disableInput();
            gameHub.invoke("HostGame", result[1], result[2], boardSize, toggleObstacles);
        }
    });

    // CLIENT BEHAVIORS
    // Call the server to find a game if the button is clicked
    $('#joinGame').click(() => {
        let result = removeWhiteSpace();

        if (result[0]) {
            disableInput();
            gameHub.invoke("JoinGame", result[1], result[2]);
        }
    });

    // Removes whitespace from values to check if they are not empty
    function removeWhiteSpace() {
        const choseUsername = $('#username').val();
        const chosenRoomName = $('#roomName').val();
        let trimedRoomName = $.trim(chosenRoomName);
        let trimedUsername = $.trim(choseUsername);

        if (trimedRoomName.length == 0) {
            $('#roomNameStatus').html("Please enter not empty room name.");
            $('#roomNameStatus').addClass("text-danger");
            return [false];
        } else if (trimedUsername.length == 0) {
            $('#usernameStatus').html("Please enter not empty username.");
            $('#usernameStatus').addClass("text-danger");
            $('#roomNameStatus').html("");
            $('#roomNameStatus').removeClass("text-danger");
            return [false];
        } else {
            $('#roomNameStatus').html("");
            $('#usernameStatus').removeClass("text-danger");
            $('#usernameStatus').html("");
            return [true, choseUsername, chosenRoomName];
        }
    }
    
    // Enables username and Find Game inputs
    function enableInput() {
        $('#username').removeAttr('disabled');
        $('#joinGame').removeAttr('disabled');
        $('#roomName').removeAttr('disabled');
        $('#hostGame').removeAttr('disabled');
        $('#username').focus();
    }

    // Disables username and Find Game inputs
    function disableInput() {
        $('#username').attr('disabled', 'disabled');
        $('#roomName').attr('disabled', 'disabled');
        $('#hostGame').attr('disabled', 'disabled');
        $('#joinGame').attr('disabled', 'disabled');
    }

    // Game over business logic should disable board button handlers and
    // allow the player to join a new game
    function endGame() {
        // Remove click handlers from board positions
        $('td[id^=pos-]').off('click');
        enableInput();
    }

    // Display whose turn it is
    function displayTurn(playersTurn, isDisplayingOpponent) {
        let turnMessage = "";
        if (playerId == playersTurn.Id) {
            turnMessage = "Your turn";
        } else {
            turnMessage = playersTurn.Name + "\'s turn";
        }

        // Do not overwrite opponent's name if it is being displayed
        if (isDisplayingOpponent) {
            $('#gameStatus').html($('#gameStatus').html() + turnMessage);
        } else {
            $('#gameStatus').html(turnMessage);
        }
    }

    // Displays the opponent's name
    function displayOpponent(opponent) {
        $('#gameStatus').html("You are playing against: " + opponent.Name + "<br />");
    }
  
    // Build and display the board
    function buildBoard(board) {
        $("#board").html("");
        $('#tableHidden').removeAttr('hidden');
        let tr = document.createElement('tr');
        let boardSize = board.BoardSize
        let boardCells = boardSize * boardSize;

        for (let i = 0; i < boardCells; i++) {
            if (i % boardSize == 0 && i != 0) {
                $('#board').append(tr);
                tr = document.createElement('tr');
            }
            let td = document.createElement('td');
            td.id = (i % boardSize) + "-" + Math.floor(i / boardSize);
            tr.append(td);
        }
        $('#board').append(tr);
 
        // attach click handlers to each position
        $("td").click(function () {
            const id = this.id; // "pos-0-0"
            const parts = id.split("-"); // [pos, 0, 0]
            const row = parseInt(parts[0]);
            const col = parseInt(parts[1]);
            gameHub.invoke("PlacePiece", row, col);
        });
    }

    // Retrieves the opponent player from the game
    function getOpponent(game) {
        if (playerId == game.Player1.Id) {
            return game.Player2;
        } else {
            return game.Player1;
        }
    }
});
