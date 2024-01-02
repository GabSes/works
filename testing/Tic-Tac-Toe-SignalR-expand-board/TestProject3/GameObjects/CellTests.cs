using Moq;
using TicTacToe.GameObjects;
using Xunit;

namespace TestProject3.GameObjects
{
    public class CellTests
    {
        private MockRepository mockRepository;

        public CellTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);
        }

        private Cell CreateCell(string value = "")
        {
            return new Cell(value);
        }

        [Fact]
        public void Set_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var cell = this.CreateCell();
            string value = "X";

            // Act
            cell.Set(value);

            // Assert
            Assert.Equal(value, cell.Value);
            Assert.Equal("general", cell.getStatus());
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public void getStatus_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var cell = this.CreateCell();

            // Act
            var result = cell.getStatus();

            // Assert
            Assert.Equal("general", result);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public void ToString_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var cell = this.CreateCell("O");

            // Act
            var result = cell.ToString();

            // Assert
            Assert.Equal("O", result);
            Assert.Equal("general", cell.getStatus());
            this.mockRepository.VerifyAll();
        }
    }
}