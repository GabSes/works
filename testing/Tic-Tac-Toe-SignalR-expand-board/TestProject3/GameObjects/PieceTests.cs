using System;
using Moq;
using TicTacToe.GameObjects;
using Xunit;

namespace TestProject3.GameObjects
{
    public class PieceTests
    {
        private MockRepository mockRepository;

        public PieceTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);
        }

        private Piece CreatePiece(string value)
        {
            return new Piece(value);
        }

        [Fact]
        public void ToString_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var piece = this.CreatePiece("X"); // Set an appropriate value for the piece

            // Act
            var result = piece.ToString();

            // Assert
            Assert.Equal("X", result);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public void GetStatus_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var piece = this.CreatePiece("O"); // Set an appropriate value for the piece

            // Act
            var result = piece.getStatus();

            // Assert
            Assert.Equal("piece", result);
            this.mockRepository.VerifyAll();
        }
    }
}