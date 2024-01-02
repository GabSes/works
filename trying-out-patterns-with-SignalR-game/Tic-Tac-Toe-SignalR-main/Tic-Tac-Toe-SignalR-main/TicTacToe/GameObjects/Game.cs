using TicTacToe.Hubs;
using TicTacToe.Interfaces;
using TicTacToe.Models;
using TicTacToe.Models.DecoratorPattern;
using TicTacToe.Patterns.Facade;

namespace TicTacToe.GameObjects
{
    public class Game : IPrototype<Game>
    {
        private bool isFirstPlayersTurn;

        /// <summary>
        /// Creates a new game object. For actual game
        /// </summary>
        /// <param name="player1">The first player to join the game.</param>
        /// <param name="player2">The second player to join the game.</param>
        public Game(GameFactory player1Factory, Player player1, string roomName, int boardSize, bool obstacles)
        {
            Player1 = player1;
            GameRoomName = roomName;
            ToggleObstacles = obstacles;
            //uncomment this after showing Facade is working
            BoardCreator hold = new BoardCreator();
            //Board = hold.FactoryMethod(boardSize);
            TicTacToeFacade facade = new TicTacToeFacade(GameState.Instance, hold, this);
            Board = facade.BuildBoard(boardSize);

            isFirstPlayersTurn = true;

            // Link the players to the game as well
            Player1.PlayingRoomName = GameRoomName;
            Player1.Piece = player1Factory.CreatePiece(player1);
        }

        /// <summary>
        /// Creates a new game object. For Prototype
        /// </summary>
        /// <param name="player1">The first player to join the game.</param>
        /// <param name="player2">The second player to join the game.</param>
        public Game(GameFactory gameFactory1, GameFactory gameFactory2, Player player1, Player player2, string roomName, int boardSize, bool obstacles)
        {
            Player1 = player1;
            Player2 = player2;
            GameRoomName = roomName;
            ToggleObstacles = obstacles;
            //uncomment this after showing Facade is working
            BoardCreator hold = new BoardCreator();
            //Board = hold.FactoryMethod(boardSize);
            TicTacToeFacade facade = new TicTacToeFacade(GameState.Instance, hold, this);
            Board = facade.BuildBoard(boardSize);

            isFirstPlayersTurn = true;

            // Link the players to the game as well
            Player1.PlayingRoomName = GameRoomName;
            Player1.Piece = gameFactory1.CreatePiece(player1);

            if (Player2 != null)
            {
                Player2.PlayingRoomName = GameRoomName;
                Player2.Piece = gameFactory2.CreatePiece(player1);
            }
        }

        /// <summary>
        /// A unique identifier for this game.
        /// </summary>
        //public string Id { get; set; }

        /// <summary>
        /// Game room name identifier.
        /// </summary>
        public string GameRoomName { get; set; }

        /// <summary>
        /// One of two partipants of the game.
        /// </summary>
        public Player? Player1 { get; set; }

        /// <summary>
        /// One of two participants of the game.
        /// </summary>
        public Player? Player2 { get; set; }

        /// <summary>
        /// The board that represents the tic-tac-toe game.
        /// </summary>
        public ITicTacToeBoard Board { get; set; }

        /// <summary>
        /// Checks if obstacles are on for that game
        /// </summary>
        public bool ToggleObstacles { get; set; }

        /// <summary>
        /// Returns which player is currently allowed to place a piece down.
        /// </summary>
        public Player WhoseTurn
        {
            get
            {
                return isFirstPlayersTurn ? Player1 : Player2;
            }
        }

        /// <summary>
        /// Returns whether the game is ongoing or has completed.
        /// Over states include either a tie or a player has won.
        /// </summary>
        public bool IsOver
        {
            get
            {
                return IsTie || Board.GameEnded;
            }
        }

        /// <summary>
        /// Returns whether the game is a tie.
        /// </summary>
        public bool IsTie
        {
            get
            {
                return !Board.AreSpacesLeft;
            }
        }

        /// <summary>
        /// Places a piece on the board. The game knows whose turn it is so no need
        /// to identify the player. Will also update whose turn it is.
        /// </summary>
        /// <param name="row">The row where the piece will be placed.</param>
        /// <param name="col">The column where the piece will be placed.</param>
        public void PlacePiece(int row, int col)
        {
            Piece pieceToPlace = isFirstPlayersTurn ? Player1.Piece : Player2.Piece;
            Board.PlacePiece(row, col, pieceToPlace);

            isFirstPlayersTurn = !isFirstPlayersTurn;
        }

        /// <summary>
        /// Returns whether or not the specified move is valid.
        /// A move is invalid if there is already a piece placed in the location or
        /// the move is off the board.
        /// </summary>
        /// <param name="row">The row position of the move.</param>
        /// <param name="col">The column position of the move.</param>
        /// <returns>true if the move is valid; otherwise false.</returns>
        public bool IsValidMove(int row, int col)
        {
            // TODO: Make the board dimensions public properties
            bool cond1 = row < Board.Pieces.GetLength(0);
            bool cond2 = col < Board.Pieces.GetLength(1);
            bool cond3 = string.IsNullOrWhiteSpace(Board.Pieces[row, col].requestValue());


            return
                cond1 &&
                cond2 &&
                cond3;
        }

        public override string ToString()
        {
            return string.Format("(Id={0}, Player1={1}, Player2={2}, Board={3})",
                GameRoomName, Player1, Player2, Board);
        }

        public Game ShallowCopy()
        {
            return (Game)this.MemberwiseClone();
        }

        public Game DeepCopy()
        {
            GameFactory player1Factory = new Player1Factory(new ConcreteMediator());
            GameFactory player2Factory = new Player2Factory(new ConcreteMediator());
            Player player1 = new Player(Player1.Name, Player1.PlayingRoomName, Player1.Id);
            player1.Piece = this.Player1.Piece;
            Player player2 = new Player(Player2.Name, Player2.PlayingRoomName, Player2.Id);
            player2.Piece = this.Player2.Piece;
            return new Game(player1Factory, player2Factory, player1, player2, this.GameRoomName, this.Board.BoardSize, this.ToggleObstacles);
        }

        public int BoardSize()
        {
            return Board.BoardSize;
        }
    }
}