using System;
using Moq;
using TicTacToe.GameObjects;
using Xunit;

namespace TestProject3.GameObjects
{
    public class PlayerTests
    {
        private MockRepository mockRepository;

        public PlayerTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);
        }

        private Player CreatePlayer(string name, string roomName, string id)
        {
            return new Player(name, roomName, id);
        }

        [Fact]
        public void ToString_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var player = this.CreatePlayer("John Doe", "GameRoom1", "123");

            // Act
            var result = player.ToString();

            // Assert
            Assert.Equal("(Id=123, Name=John Doe, GameId=GameRoom1, Piece=)", result, ignoreCase: true);
            this.mockRepository.VerifyAll();
        }


        [Fact]
        public void Equals_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var player = this.CreatePlayer("John Doe", "GameRoom1", "123");
            object obj = new Player("John Doe", "GameRoom1", "123");

            // Act
            var result = player.Equals(obj);

            // Assert
            Assert.True(result);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public void GetHashCode_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var player = this.CreatePlayer("John Doe", "GameRoom1", "123");

            // Act
            var result = player.GetHashCode();

            // Assert
            Assert.Equal(player.Id.GetHashCode() * player.Name.GetHashCode(), result);
            this.mockRepository.VerifyAll();
        }
    }
}