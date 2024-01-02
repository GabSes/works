using System;
using Moq;
using TicTacToe.GameObjects;
using TicTacToe.Models;
using Xunit;

namespace TestProject3.GameObjects
{
    public class Board3Tests
    {
        private MockRepository mockRepository;

        public Board3Tests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);
        }

        private Board3 CreateBoard3()
        {
            return new Board3();
        }

        [Fact]
        public void IsThreeInRow_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var mockWinningStrategy = new Mock<IWinningStrategy>();
            var board3 = new Board3
            {
                winningStrategy = mockWinningStrategy.Object
            };

            // Set up the mock to return a specific value for IsThreeInRow
            mockWinningStrategy.Setup(ws => ws.IsThreeInRow(It.IsAny<Cell[,]>())).Returns(true);

            // Act
            var result = board3.IsThreeInRow;

            // Assert
            Assert.True(result);
            mockRepository.VerifyAll();
        }

        [Fact]
        public void GameEnded_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var mockWinningStrategy = new Mock<IWinningStrategy>();
            var board3 = new Board3
            {
                winningStrategy = mockWinningStrategy.Object
            };

            // Set up the mock to return a specific value for IsThreeInRow
            mockWinningStrategy.Setup(ws => ws.IsThreeInRow(It.IsAny<Cell[,]>())).Returns(true);

            // Act
            var result = board3.GameEnded;

            // Assert
            Assert.True(result);
            mockRepository.VerifyAll();
        }
    }
}