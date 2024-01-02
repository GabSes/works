using Moq;
using TicTacToe.GameObjects;
using TicTacToe.Models;
using Xunit;

namespace TestProject3.GameObjects
{
    public class Board4Tests
    {
        private MockRepository mockRepository;

        public Board4Tests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);
        }

        private Board4 CreateBoard4()
        {
            return new Board4();
        }

        [Fact]
        public void IsFourInRow_Property_ReturnsCorrectValue()
        {
            // Arrange
            var board4 = this.CreateBoard4();

            // Act
            var result = board4.IsFourInRow;

            // Assert
            Assert.False(result); // Assuming the initial state is not four in a row
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public void GameEnded_Property_ReturnsCorrectValue()
        {
            // Arrange
            var board4 = this.CreateBoard4();

            // Act
            var result = board4.GameEnded;

            // Assert
            Assert.False(result); // Assuming the initial state is not four in a row
            this.mockRepository.VerifyAll();
        }
    }
}