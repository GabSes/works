using Moq;
using System.Reflection;
using TicTacToe.GameObjects;
using TicTacToe.Models;
using Xunit;

namespace TestProject3.Models
{
    public class SubjectTests
    {
        private MockRepository mockRepository;

        public SubjectTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);
        }

        private Subject CreateSubject()
        {
            return new Subject();
        }

        [Fact]
        public void Attach_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var subject = this.CreateSubject();
            var unit = new Mock<Obstacle>("TestObstacle").Object;

            // Act
            subject.Attach(unit);

            // Assert
            Assert.Contains(unit, subject.observers);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public void Detach_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var subject = this.CreateSubject();
            var unit = new Mock<Obstacle>("TestObstacle").Object;
            subject.Attach(unit);

            // Act
            subject.Detach(unit);

            // Assert
            Assert.DoesNotContain(unit, subject.observers);
            this.mockRepository.VerifyAll();
        }

      

    }
}
