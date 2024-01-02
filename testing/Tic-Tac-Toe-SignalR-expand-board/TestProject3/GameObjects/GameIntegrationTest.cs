using TicTacToe.GameObjects;
using TicTacToe.Models;
using Xunit;

namespace TicTacToe.Tests
{
    public class GameIntegrationTests
    {
        [Fact]
        public void PlayGame_ShouldReachEndGame()
        {
            // Arrange
            Player player1 = new Player("Player1", "Room1", "1");
            Player player2 = new Player("Player2", "Room1", "2");
            Player1Factory player1Factory = new Player1Factory();
            Player2Factory player2Factory = new Player2Factory();

            // Create the game
            Game game = new Game(player1Factory, player2Factory, player1, player2, "Room1", 3, false);

            // Act
            // Simulate a sequence of moves that leads to the end of the game
            game.PlacePiece(0, 0); // Player 1
            game.PlacePiece(1, 1); // Player 2
            game.PlacePiece(0, 1); // Player 1
            game.PlacePiece(1, 0); // Player 2
            game.PlacePiece(0, 2); // Player 1

            // Assert
            // Check the game status or any other relevant assertions
            Assert.True(game.IsOver);
            Assert.False(game.IsTie);


            // Additional assertions based on the expected outcome
        }

        [Fact]
        public void BoardCreator_CreateBoard_ShouldReturnCorrectBoardType()
        {
            // Arrange
            Board board3 = BoardCreator.factoryMethod(3);
            Board board4 = BoardCreator.factoryMethod(4);

            // Assert
            Assert.IsType<Board3>(board3);
            Assert.IsType<Board4>(board4);
        }
    }
}