using Moq;
using TicTacToe.Models;
using Xunit;

namespace TestProject3.Models
{
    public class GameSubjectTests
    {
        private MockRepository mockRepository;

        public GameSubjectTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);
        }

        private GameSubject CreateGameSubject()
        {
            return new GameSubject();
        }

        [Fact]
        public void getState_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var gameSubject = this.CreateGameSubject();

            // Act
            var result = gameSubject.getState();

            // Assert
            Assert.True(result); // Assuming the initial state is true
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public void setState_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var gameSubject = this.CreateGameSubject();
            bool value = false;

            // Act
            gameSubject.setState(value);

            // Assert
            Assert.False(gameSubject.getState()); // Check if state is set correctly
            this.mockRepository.VerifyAll();
        }
    }
}