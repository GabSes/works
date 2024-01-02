using System;
using TicTacToe.GameObjects;
using TicTacToe.Models;
using Xunit;

namespace TicTacToe.Tests
{
    public class GameTests
    {
        [Fact]
        public void NewGame_ShouldHaveFirstPlayersTurnTrue()
        {
            // Arrange
            Player player1 = new Player("Player1", "Room1", "1");
            Player1Factory player1Factory = new Player1Factory();

            // Act
            Game game = new Game(player1Factory, player1, "Room1", 3, false);

            // Assert
            Assert.True(game.isFirstPlayersTurn);
        }

        [Fact]
        public void PlacePiece_ShouldAlternateTurns()
        {
            // Arrange
            Player player1 = new Player("Player1", "Room1", "1");
            Player player2 = new Player("Player2", "Room1", "2");
            Player1Factory player1Factory = new Player1Factory();
            Player2Factory player2Factory = new Player2Factory();

            // Act
            Game game = new Game(player1Factory, player2Factory, player1, player2, "Room1", 3, false);

            // Assert
            Assert.True(game.isFirstPlayersTurn);

            // Act
            game.PlacePiece(0, 0);

            // Assert
            Assert.False(game.isFirstPlayersTurn);

            // Act
            game.PlacePiece(1, 1);

            // Assert
            Assert.True(game.isFirstPlayersTurn);
        }

        [Fact]
        public void IsValidMove_ShouldReturnTrueForValidMove()
        {
            // Arrange
            Player player1 = new Player("Player1", "Room1", "1");
            Player1Factory player1Factory = new Player1Factory();

            // Act
            Game game = new Game(player1Factory, player1, "Room1", 3, false);

            // Assert
            Assert.True(game.IsValidMove(0, 0));
        }

        [Fact]
        public void IsValidMove_ShouldReturnFalseForInvalidMove()
        {
            // Arrange
            Player player1 = new Player("Player1", "Room1", "1");
            Player1Factory player1Factory = new Player1Factory();

            // Act
            Game game = new Game(player1Factory, player1, "Room1", 3, false);

            // Act
            game.PlacePiece(0, 0);

            // Assert
            Assert.False(game.IsValidMove(0, 0));
        }

        [Fact]
        public void ToString_ShouldReturnFormattedString()
        {
            // Arrange
            Player player1 = new Player("Player1", "Room1", "1");
            Player1Factory player1Factory = new Player1Factory();
            Game game = new Game(player1Factory, player1, "Room1", 3, false);

            // Act
            string result = game.ToString();

            // Assert
            Assert.Equal($"(Id={game.GameRoomName}, Player1={game.Player1}, Player2={game.Player2}, Board={game.Board})", result);
        }

        [Fact]
        public void ShallowCopy_ShouldReturnNewInstance()
        {
            // Arrange
            Player player1 = new Player("Player1", "Room1", "1");
            Player1Factory player1Factory = new Player1Factory();
            Game game = new Game(player1Factory, player1, "Room1", 3, false);

            // Act
            Game copy = game.ShallowCopy();

            // Assert
            Assert.NotSame(game, copy);
        }

        [Fact]
        public void ToggleObstacles_ShouldReturnSetValue()
        {
            // Arrange
            Player player1 = new Player("Player1", "Room1", "1");
            Player1Factory player1Factory = new Player1Factory();
            Game game = new Game(player1Factory, player1, "Room1", 3, false);

            // Act
            game.ToggleObstacles = true;

            // Assert
            Assert.True(game.ToggleObstacles);
        }

        [Fact]
        public void WhoseTurn_ShouldReturnCorrectPlayer()
        {
            // Arrange
            Player player1 = new Player("Player1", "Room1", "1");
            Player player2 = new Player("Player2", "Room1", "2");
            Player1Factory player1Factory = new Player1Factory();
            Player2Factory player2Factory = new Player2Factory();
            Game game = new Game(player1Factory, player2Factory, player1, player2, "Room1", 3, false);

            // Act
            Player currentTurnPlayer = game.WhoseTurn;

            // Assert
            Assert.Equal(player1, currentTurnPlayer);
        }


        [Fact]
        public void IsTie_ShouldReturnTrueWhenGameIsTie()
        {
            // Arrange
            Player player1 = new Player("Player1", "Room1", "1");
            Player player2 = new Player("Player2", "Room1", "2");
            Player1Factory player1Factory = new Player1Factory();
            Player2Factory player2Factory = new Player2Factory();
            Game game = new Game(player1Factory, player2Factory, player1, player2, "Room1", 3, false);

            // Act
            // Simulate a tie by filling the board without a winner
            game.PlacePiece(0, 0);
            game.PlacePiece(0, 1);
            game.PlacePiece(0, 2);
            game.PlacePiece(1, 0);
            game.PlacePiece(1, 1);
            game.PlacePiece(1, 2);
            game.PlacePiece(2, 0);
            game.PlacePiece(2, 1);
            game.PlacePiece(2, 2);

            // Assert
            Assert.True(game.IsTie);
        }
        [Fact]
        public void DeepCopy_ShouldReturnNewInstanceWithEqualProperties()
        {
            // Arrange
            Player1Factory player1Factory = new Player1Factory();
            Player2Factory player2Factory = new Player2Factory();
            Player player1 = new Player("Player1", "Room1", "1");
            player1.Piece = "X";
            Player player2 = new Player("Player2", "Room1", "2");
            player2.Piece = "O";

            Game game = new Game(player1Factory, player2Factory, player1, player2, "Room1", 3, false);

            // Act
            Game deepCopy = game.DeepCopy();

            // Assert
            Assert.NotSame(game, deepCopy);
            Assert.Equal(game.GameRoomName, deepCopy.GameRoomName);
            Assert.Equal(game.Player1.Name, deepCopy.Player1.Name);
            Assert.Equal(game.Player1.Piece, deepCopy.Player1.Piece);
            Assert.Equal(game.Player2.Name, deepCopy.Player2.Name);
            Assert.Equal(game.Player2.Piece, deepCopy.Player2.Piece);
            Assert.Equal(game.Board.BoardSize, deepCopy.Board.BoardSize);
            Assert.Equal(game.ToggleObstacles, deepCopy.ToggleObstacles);
        }
        [Fact]
        public void IsOver_ShouldReturnTrueWhenIsTie()
        {
            // Arrange
            Player1Factory player1Factory = new Player1Factory();
            Player player1 = new Player("Player1", "Room1", "1");
            Game game = new Game(player1Factory, player1, "Room1", 3, false);

            // Set up conditions for a tie
            game.Board.PlacePiece(0, 0, "X");
            game.Board.PlacePiece(0, 1, "O");
            game.Board.PlacePiece(0, 2, "X");
            game.Board.PlacePiece(1, 0, "O");
            game.Board.PlacePiece(1, 1, "X");
            game.Board.PlacePiece(1, 2, "O");
            game.Board.PlacePiece(2, 0, "O");
            game.Board.PlacePiece(2, 1, "X");
            game.Board.PlacePiece(2, 2, "O");

            // Act
            bool isOver = game.IsOver;

            // Assert
            Assert.True(isOver);
        }

       
    }
}
