using System;
using Moq;
using TicTacToe.GameObjects;
using TicTacToe.Models;
using Xunit;

namespace TestProject3.Models
{
    public class ThreeByThreeWinningStrategyTests
    {
        private MockRepository mockRepository;

        public ThreeByThreeWinningStrategyTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);
        }

        private ThreeByThreeWinningStrategy CreateThreeByThreeWinningStrategy()
        {
            return new ThreeByThreeWinningStrategy();
        }

        [Fact]
        public void IsThreeInRow_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var threeByThreeWinningStrategy = this.CreateThreeByThreeWinningStrategy();
            Cell[,] Pieces = new Cell[3, 3];

            // Set up the Pieces array with your desired values for testing

            // Act
            var result = threeByThreeWinningStrategy.IsThreeInRow(Pieces);

            // Assert
            Assert.False(result); // Modify this based on your test scenario
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public void IsBoardFull_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var threeByThreeWinningStrategy = this.CreateThreeByThreeWinningStrategy();
            Cell[,] Pieces = new Cell[3, 3];

            // Set up the Pieces array with your desired values for testing

            // Act
            var result = threeByThreeWinningStrategy.IsBoardFull(Pieces);

            // Assert
            Assert.False(result); // Modify this based on your test scenario
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public void IsGameOver_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var threeByThreeWinningStrategy = this.CreateThreeByThreeWinningStrategy();
            Cell[,] Pieces = new Cell[3, 3];

            // Set up the Pieces array with your desired values for testing

            // Act
            var result = threeByThreeWinningStrategy.IsGameOver(Pieces);

            // Assert
            Assert.False(result); // Modify this based on your test scenario
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public void IsFourInRow_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var threeByThreeWinningStrategy = this.CreateThreeByThreeWinningStrategy();
            Cell[,] Pieces = new Cell[3, 3];

            // Act
            var result = threeByThreeWinningStrategy.IsFourInRow(Pieces);

            // Assert
            Assert.False(result); // Modify this based on your test scenario
            this.mockRepository.VerifyAll();
        }
        [Fact]
        public void IsThreeInRow_WinningForwardDiagonal_ReturnsTrue()
        {
            // Arrange
            var threeByThreeWinningStrategy = this.CreateThreeByThreeWinningStrategy();
            Cell[,] Pieces = new Cell[3, 3];

            // Create a winning forward-diagonal with initialized Cell objects
            Pieces[0, 0] = new Cell("X");
            Pieces[1, 1] = new Cell("X");
            Pieces[2, 2] = new Cell("X");

            // Act
            var result = threeByThreeWinningStrategy.IsThreeInRow(Pieces);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void IsThreeInRow_WinningBackwardDiagonal_ReturnsTrue()
        {
            // Arrange
            var threeByThreeWinningStrategy = this.CreateThreeByThreeWinningStrategy();
            Cell[,] Pieces = new Cell[3, 3];

            // Create a winning backward-diagonal with initialized Cell objects
            Pieces[0, 2] = new Cell("X");
            Pieces[1, 1] = new Cell("X");
            Pieces[2, 0] = new Cell("X");

            // Act
            var result = threeByThreeWinningStrategy.IsThreeInRow(Pieces);

            // Assert
            Assert.True(result);
        }
        [Fact]
        public void IsBoardFull_FullBoard_ReturnsTrue()
        {
            // Arrange
            var threeByThreeWinningStrategy = this.CreateThreeByThreeWinningStrategy();
            Cell[,] Pieces = new Cell[3, 3];

            // Fill the board with initialized Cell objects
            for (int row = 0; row < Pieces.GetLength(0); row++)
            {
                for (int col = 0; col < Pieces.GetLength(1); col++)
                {
                    Pieces[row, col] = new Cell("X");
                }
            }

            // Act
            var result = threeByThreeWinningStrategy.IsBoardFull(Pieces);

            // Assert
            Assert.True(result);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public void IsThreeInRow_WinningRow_ReturnsTrue()
        {
            // Arrange
            var threeByThreeWinningStrategy = this.CreateThreeByThreeWinningStrategy();
            Cell[,] Pieces = new Cell[3, 3];

            // Create a winning row with initialized Cell objects
            Pieces[0, 0] = new Cell("X");
            Pieces[0, 1] = new Cell("X");
            Pieces[0, 2] = new Cell("X");

            // Act
            var result = threeByThreeWinningStrategy.IsThreeInRow(Pieces);

            // Assert
            Assert.True(result);
            this.mockRepository.VerifyAll();
        }
        [Fact]
        public void IsThreeInRow_WinningSpecificColumn_ReturnsTrue()
        {
            // Arrange
            var threeByThreeWinningStrategy = this.CreateThreeByThreeWinningStrategy();
            Cell[,] Pieces = new Cell[3, 3];

            // Create a winning column with initialized Cell objects
            Pieces[0, 0] = new Cell("X");
            Pieces[1, 0] = new Cell("X");
            Pieces[2, 0] = new Cell("X");

            // Act
            var result = threeByThreeWinningStrategy.IsThreeInRow(Pieces);

            // Assert
            Assert.True(result);
            this.mockRepository.VerifyAll();
        }

    }
}
