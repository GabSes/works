using System;
using Moq;
using TicTacToe.GameObjects;
using TicTacToe.Models;
using Xunit;

namespace TestProject3.GameObjects
{
    public class ObstacleTests
    {
        private MockRepository mockRepository;

        public ObstacleTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);
        }

        private Obstacle CreateObstacle(string value)
        {
            return new Obstacle(value);
        }

        [Fact]
        public void GetStatus_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var obstacle = this.CreateObstacle("TypeA"); // Set an appropriate value for the obstacle type

            // Act
            var result = obstacle.getStatus();

            // Assert
            Assert.Equal("obstacle", result);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public void ToString_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var obstacle = this.CreateObstacle("TypeB"); // Set an appropriate value for the obstacle type

            // Act
            var result = obstacle.ToString();

            // Assert
            Assert.Equal("TypeB", result);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public void Update_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var obstacle = this.CreateObstacle("TypeC"); // Set an appropriate value for the obstacle type
            obstacle.instance = new GameSubject(); // Instantiate the GameSubject

            bool change = false;

            // Act
            obstacle.Update(change);

            // Assert
            Assert.Equal(change, obstacle.Active);
            this.mockRepository.VerifyAll();
        }

    }
}