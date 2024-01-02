using System;
using Moq;
using TicTacToe.GameObjects;
using TicTacToe.Models;
using Xunit;

namespace TestProject3.Models
{
    public class Player2FactoryTests
    {
        private MockRepository mockRepository;

        public Player2FactoryTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);
        }

        private Player2Factory CreateFactory()
        {
            return new Player2Factory();
        }

        [Fact]
        public void CreateObstacle_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var factory = this.CreateFactory();

            // Act
            var result = factory.CreateObstacle();

            // Assert
            Assert.NotNull(result);
            Assert.Equal("B", result.ToString()); // Using ToString() for comparison
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public void CreatePiece_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var factory = this.CreateFactory();
            Player player = new Player("TestPlayer", "Room1", "1");

            // Act
            var result = factory.CreatePiece(player);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("O", result.ToString()); // Using ToString() for comparison
            this.mockRepository.VerifyAll();
        }
    }
}