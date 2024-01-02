using Moq;
using TicTacToe.Models;
using Xunit;

namespace TestProject3.Models
{
    public class ErrorViewModelTests
    {
        [Fact]
        public void ShowRequestId_RequestIdNotNull_ReturnsTrue()
        {
            // Arrange
            var viewModel = new ErrorViewModel { RequestId = "123" };

            // Act
            var result = viewModel.ShowRequestId;

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void ShowRequestId_RequestIdNull_ReturnsFalse()
        {
            // Arrange
            var viewModel = new ErrorViewModel { RequestId = null };

            // Act
            var result = viewModel.ShowRequestId;

            // Assert
            Assert.False(result);
        }
    }
}