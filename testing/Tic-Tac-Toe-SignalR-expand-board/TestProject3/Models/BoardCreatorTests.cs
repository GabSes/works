using Moq;
using TicTacToe.GameObjects;
using TicTacToe.Models;
using Xunit;

namespace TestProject3.Models
{
    public class BoardCreatorTests
    {
        [Fact]
        public void factoryMethod_CreateBoard3_ReturnsBoard3()
        {
            // Arrange
            var boardCreator = new BoardCreator();
            int type = 3;

            // Act
            var result = BoardCreator.factoryMethod(type);

            // Assert
            Assert.IsType<Board3>(result);
        }

        [Fact]
        public void factoryMethod_CreateBoard4_ReturnsBoard4()
        {
            // Arrange
            var boardCreator = new BoardCreator();
            int type = 4;

            // Act
            var result = BoardCreator.factoryMethod(type);

            // Assert
            Assert.IsType<Board4>(result);
        }

        [Fact]
        public void factoryMethod_InvalidType_ReturnsNull()
        {
            // Arrange
            var boardCreator = new BoardCreator();
            int type = 0;

            // Act
            var result = BoardCreator.factoryMethod(type);

            // Assert
            Assert.Null(result);
        }
    }
}