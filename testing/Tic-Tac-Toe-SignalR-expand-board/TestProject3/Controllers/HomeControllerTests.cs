using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Diagnostics;
using TicTacToe.Controllers;
using TicTacToe.Models;
using Xunit;

namespace TestProject3.Controllers
{
    public class HomeControllerTests
    {
        private MockRepository mockRepository;

        private Mock<ILogger<HomeController>> mockLogger;

        public HomeControllerTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);

            this.mockLogger = this.mockRepository.Create<ILogger<HomeController>>();
        }

        private HomeController CreateHomeController()
        {
            return new HomeController(
                this.mockLogger.Object);
        }

        [Fact]
        public void Index_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var homeController = this.CreateHomeController();

            // Act
            var result = homeController.Index();

            // Assert
            Assert.NotNull(result);
            Assert.IsType<ViewResult>(result);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public void Privacy_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var homeController = this.CreateHomeController();

            // Act
            var result = homeController.Privacy();

            // Assert
            Assert.NotNull(result);
            Assert.IsType<ViewResult>(result);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public void Error_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var homeController = this.CreateHomeController();

            // Simulate the scenario where Activity.Current is null
            Activity.Current = new Activity("dummyActivity").Start();

            // Act
            var result = homeController.Error();

            // Assert
            Assert.NotNull(result);
            Assert.IsType<ViewResult>(result);

            // Ensure that the ErrorViewModel is correctly constructed
            var viewResult = result as ViewResult;
            Assert.NotNull(viewResult.Model);
            Assert.IsType<ErrorViewModel>(viewResult.Model);

            // Optional: Assert specific properties of the ErrorViewModel if needed
            var errorViewModel = viewResult.Model as ErrorViewModel;
            Assert.NotNull(errorViewModel.RequestId);

            this.mockRepository.VerifyAll();
        }




    }
}
