using System;
using Moq;
using TicTacToe.GameObjects;
using TicTacToe.Models;
using Xunit;

namespace TestProject3.Models
{
    public class Player1FactoryTests
    {
        private MockRepository mockRepository;

        public Player1FactoryTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);
        }

        private Player1Factory CreateFactory()
        {
            return new Player1Factory();
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
            Assert.Equal("W", result.ToString()); // Using ToString() for comparison
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public void CreatePiece_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var factory = this.CreateFactory();
            Player player = null;

            // Act
            var result = factory.CreatePiece(player);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("X", result.ToString()); // Using ToString() for comparison
            this.mockRepository.VerifyAll();
        }
    }
}