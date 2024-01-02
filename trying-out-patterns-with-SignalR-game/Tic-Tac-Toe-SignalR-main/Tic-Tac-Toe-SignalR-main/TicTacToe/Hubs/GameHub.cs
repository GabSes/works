using Microsoft.AspNetCore.SignalR;
using TicTacToe.Models;
using Newtonsoft.Json;
using TicTacToe.GameObjects;
using TicTacToe.Patterns.ForPrototype;
using TicTacToe.Controllers;
using TicTacToe.Patterns.Facade;
using TicTacToe.Interfaces;

namespace TicTacToe.Hubs
{
    public class GameHub : Hub
	{
		/// <summary>
		/// The starting point for a client looking to join a new game.
		/// Player either starts a game with a waiting opponent or joins the waiting pool.
		/// </summary>
		/// <param name="username">The friendly name that the user has chosen.</param>
		/// <returns>A Task to track the asynchronous method execution.</returns>
		public async Task JoinGame(string username, string roomName)
		{
            if (GameState.Instance.IsUsernameTaken(username))
            {
                await Clients.Caller.SendAsync("usernameTaken");
                return;
            }

            if (!GameState.Instance.CanEnterRoom(roomName))
			{
				await Clients.Caller.SendAsync("cannotEnterRoom");
				return;
			}
           
			Player joiningPlayer = GameState.Instance.CreatePlayer(username, roomName, this.Context.ConnectionId);
			await Clients.Caller.SendAsync("playerJoined", joiningPlayer);

            // Find any pending games if any
            Player opponent = GameState.Instance.GetWaitingOpponent(roomName);//add parameter roomName
            Player2Factory factory = new Player2Factory(new ConcreteMediator());
            if (opponent == null)
			{
				//No waiting players so enter the waiting pool
				//GameState.Instance.AddToWaitingPool(joiningPlayer);//add parameter roomName
				//await this.Clients.Caller.SendAsync("waitingList");
            }else
			{
				// Join hosted game
				Game joiningGame = GameState.Instance.GetGame(roomName);
				if(joiningGame == null)
				{
                    await Clients.Caller.SendAsync("couldNotJoinGame");
                    return;
				}
				else
				{
					joiningPlayer.Piece = factory.CreatePiece(joiningPlayer);
					joiningGame.Player2 = joiningPlayer;

					//GamePrototype gp = new GamePrototype(joiningGame);//this is for prototype. comment this.

                    await Groups.AddToGroupAsync(Context.ConnectionId, joiningGame.GameRoomName);
                    await Clients.Group(joiningGame.GameRoomName).SendAsync("startGame", JsonConvert.SerializeObject(joiningGame));
					//await Clients.Group(joiningGame.GameRoomName).SendAsync("showCloneDiff", JsonConvert.SerializeObject(gp));//this is for prototype. comment this.
                }
            }
        }

        /// <summary>
        /// Client is hosting the game and is put into waiting list.
        /// </summary>
        /// <param name="username">User chosen username.</param>
        /// <param name="roomName">User chosen room name.</param>
		/// <param name="boardSize">User chosen board size.</>
		/// <param name="obstacles">User chosen if there should be obstacles.</>
        /// <returns>A Task to track the asynchronous method execution.</returns>
        public async Task HostGame(string username, string roomName, int boardSize, bool obstacles)
		{
			if (GameState.Instance.IsRoomNameTaken(roomName))
			{
                await Clients.Caller.SendAsync("roomnameTaken");
                return;
            }

            Player joiningPlayer = GameState.Instance.CreatePlayer(username, roomName, this.Context.ConnectionId);
            await Clients.Caller.SendAsync("playerJoined", joiningPlayer);

            // No waiting players so enter the waiting pool
            GameState.Instance.AddToWaitingPool(joiningPlayer);//add parameter roomName
            await Clients.Caller.SendAsync("waitingList");

			// An opponent was found so join a new game and start the game
			// Opponent is first player since they were waiting first
            Game newGame = await GameState.Instance.CreateGame(joiningPlayer, this.Groups, roomName, boardSize, obstacles);//add parameter roomName
            await Groups.AddToGroupAsync(Context.ConnectionId, newGame.GameRoomName);//add parameter roomName
			await Clients.Caller.SendAsync("startHost");
        }

        /// <summary>
        /// Client has requested to place a piece down in the following position.
        /// </summary>
        /// <param name="row">The row part of the position.</param>
        /// <param name="col">The column part of the position.</param>
        /// <returns>A Task to track the asynchronous method execution.<</returns>
        public async Task PlacePiece(int row, int col)
        {
			Player playerMakingTurn = GameState.Instance.GetPlayer(playerId: this.Context.ConnectionId);
			TicTacToeFacade facade = new TicTacToeFacade(GameState.Instance, new BoardCreator(), new Game(new Player1Factory(new ConcreteMediator()), new Player("1", "2", "3"), "xxxxnono", 3, false));
			//Game game = GameState.Instance.GetGame(playerMakingTurn);
			Game game = facade.GetGame(playerMakingTurn);

			if(game == null)
			{
				await Clients.Caller.SendAsync("gameEnded");
				return;
			}

			// TODO: should the game check if it is the players turn?
			if (!game.WhoseTurn.Equals(playerMakingTurn))
			{
                await Clients.Caller.SendAsync("notPlayersTurn");
                return;
			}

			if (!game.IsValidMove(row, col))
			{
                await Clients.Caller.SendAsync("notValidMove");
                return;
			}

			// Notify everyone of the valid move. Only send what is necessary (instead of sending whole board)
			game.PlacePiece(row, col);
            await Groups.AddToGroupAsync(Context.ConnectionId, game.GameRoomName);
            
			ConcreteMediator mediator = new ConcreteMediator();
			mediator.setHandler(new BoardSizeHandler(mediator));
			string[] chain = mediator.callHandler( new Player("","", "") ,new string[] { game.BoardSize().ToString(), col.ToString(), row.ToString(), game.ToggleObstacles.ToString() }).Split(':');

            await Clients.Group(game.GameRoomName).SendAsync("piecePlaced", row, col, playerMakingTurn.Piece.Value, playerMakingTurn.Piece.Value, chain[0], chain[1], chain[2], chain[3]);

            // check if game is over (won or tie)
            if (!game.IsOver)
			{
				// Update the turn like normal if the game is still ongoing
                await Groups.AddToGroupAsync(Context.ConnectionId, game.GameRoomName);
                await Clients.Group(game.GameRoomName).SendAsync("updateTurn", JsonConvert.SerializeObject(game));
            }
			else
			{
				// Determine how the game is over in order to display correct message to client
				if (game.IsTie)
				{
					// Cat's game
                    await Groups.AddToGroupAsync(Context.ConnectionId, game.GameRoomName);
                    await Clients.Group(game.GameRoomName).SendAsync("tieGame");
                }
				else
				{
					// Player outright won
                    await Groups.AddToGroupAsync(Context.ConnectionId, game.GameRoomName);
                    await Clients.Group(game.GameRoomName).SendAsync("winner", playerMakingTurn.Name);
                }

				// Remove the game (in any game over scenario) to reclaim resources
				GameState.Instance.RemoveGame(game.GameRoomName);
			}
		}

		// <summary>
		// A player that is leaving should end that game and notify the opponent.
		// </summary>
		// <param name = "stopCalled" ></ param >

		// < returns ></ returns >

		public override async Task OnDisconnectedAsync(Exception exception)
		{
			Player leavingPlayer = GameState.Instance.GetPlayer(playerId: this.Context.ConnectionId);
            // Only handle cases where user was a player in a game or waiting for an opponent
            if (leavingPlayer != null)
			{
				Game ongoingGame = GameState.Instance.GetGame(leavingPlayer);
				if (ongoingGame != null)
				{
					await Groups.AddToGroupAsync(Context.ConnectionId, ongoingGame.GameRoomName);
					await Clients.Group(ongoingGame.GameRoomName).SendAsync("opponentLeft");
					GameState.Instance.RemoveGame(ongoingGame.GameRoomName);
				}
			}

			await base.OnDisconnectedAsync(exception);
		}
	}
}
