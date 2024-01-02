using System;
using Moq;
using TicTacToe.GameObjects;
using Xunit;

namespace TestProject3.GameObjects
{
    public class BoardTests
    {
        private MockRepository mockRepository;

        public BoardTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);
        }

        private Board CreateBoard()
        {
            return new Board();
        }

        [Fact]
        public void PlacePiece_WithValidInput_PiecePlacedSuccessfully()
        {
            // Arrange
            var board = this.CreateBoard();
            int row = 0;
            int col = 0;
            string pieceToPlace = "X"; // Set an appropriate piece value for testing

            // Act
            board.Set(3); // Set dimensions before placing a piece
            board.PlacePiece(row, col, pieceToPlace);

            // Assert
            Assert.Equal(pieceToPlace, board.Pieces[row, col].Value); // Check that the piece is placed correctly

            // Additional assertions to check array bounds
            Assert.InRange(row, 0, board.BoardSize - 1); // Check that row is within a valid range
            Assert.InRange(col, 0, board.BoardSize - 1); // Check that col is within a valid range

            Assert.Equal(1, board.totalPiecesPlaced); // Check that TotalPiecesPlaced is incremented
            Assert.True(board.AreSpacesLeft); // Check that there are still spaces left on the board
        }


        [Fact]
        public void PlacePiece_WithInvalidInput_ThrowsException()
        {
            // Arrange
            var board = this.CreateBoard();
            int row = -1;
            int col = 0;
            string pieceToPlace = "X"; // Set an appropriate piece value for testing

            // Act and Assert
            Assert.Throws<IndexOutOfRangeException>(() => board.PlacePiece(row, col, pieceToPlace));
        }

        [Fact]
        public void ToString_ReturnsCorrectStringRepresentation()
        {
            // Arrange
            var board = this.CreateBoard();

            // Act
            var result = board.ToString();

            // Assert
            // Check that each piece value is present in the result
            foreach (var cellValue in board.Pieces)
            {
                Assert.Contains(cellValue.Value, result);
            }
        }

        [Fact]
        public void SetDimensions_WithValidInput_SetsDimensionsSuccessfully()
        {
            // Arrange
            var board = this.CreateBoard();
            int dimensions = 4; // Set an appropriate dimension value for testing

            // Act
            board.Set(dimensions);

            // Assert
            Assert.Equal(dimensions, board.BoardSize); // Check that BoardSize is set correctly
            Assert.Equal(dimensions * dimensions, board.Pieces.Length); // Check that Pieces array is initialized with the correct size
        }

        [Fact]
        public void AreSpacesLeft_WithEmptyBoard_ReturnsTrue()
        {
            // Arrange
            var board = this.CreateBoard();
            int row = 0;
            int col = 0;
            string pieceToPlace = "X"; // Set an appropriate piece value for testing

            // Act
            board.Set(3); // Set dimensions before placing a piece
            board.PlacePiece(row, col, pieceToPlace);
            var result = board.AreSpacesLeft;

            // Assert
            Assert.True(result, $"Expected AreSpacesLeft to be true, but it was false. Pieces placed: {board.totalPiecesPlaced}, Board size: {board.BoardSize}");
        }



        [Fact]
        public void AreSpacesLeft_WithFullBoard_ReturnsFalse()
        {
            // Arrange
            var board = this.CreateBoard();
            FillBoard(board);

            // Act
            var result = board.AreSpacesLeft;

            // Assert
            Assert.False(result); // After filling the board, there should be no spaces left
        }

        private void FillBoard(Board board)
        {
            // Helper method to fill the board with pieces
            for (int i = 0; i < board.BoardSize; i++)
            {
                for (int j = 0; j < board.BoardSize; j++)
                {
                    board.PlacePiece(i, j, "X");
                }
            }
        }
        [Fact]
        public void ToString_ReturnsCorrectStringRepresentationAfterPlacingPieces()
        {
            // Arrange
            var board = this.CreateBoard();
            int row = 0;
            int col = 0;
            string pieceToPlace = "X";

            // Act
            board.Set(3); // Ensure the board is properly initialized
            board.PlacePiece(row, col, pieceToPlace);
            var result = board.ToString();

            // Assert
            Assert.Contains(pieceToPlace, result);
        }


        [Fact]
        public void ToString_ReturnsCorrectStringRepresentationAfterReset()
        {
            // Arrange
            var board = this.CreateBoard();
            int row = 0;
            int col = 0;
            string pieceToPlace = "X";
            board.Set(3);
            board.PlacePiece(row, col, pieceToPlace);

            // Act
            board.Set(3); // Reset the board
            var result = board.ToString();

            // Assert
            var cellDefault = new Cell().Value; // Use the default value of Cell
            Assert.Equal($"{cellDefault}, {cellDefault}, {cellDefault}, {cellDefault}, {cellDefault}, {cellDefault}, {cellDefault}, {cellDefault}, {cellDefault}", result);
        }



        [Fact]
        public void Constructor_InitializesBoardWithCorrectValues()
        {
            // Arrange
            int boardSize = 3; // Choose an appropriate board size
            var board = new Board();

            // Act
            board.Set(boardSize);

            // Assert
            Assert.Equal(boardSize, board.BoardSize); // Check if BoardSize is set correctly

            // Assuming the default cell value is an empty string, check if all cells are initialized with the correct value
            for (int i = 0; i < boardSize; i++)
            {
                for (int j = 0; j < boardSize; j++)
                {
                    Assert.Equal("", board.Pieces[i, j].Value); // Modify this if your default cell value is different
                }
            }

            // Additional check to ensure that Pieces array is initialized with individual cell instances
            var distinctCellInstances = new HashSet<Cell>();
            for (int i = 0; i < boardSize; i++)
            {
                for (int j = 0; j < boardSize; j++)
                {
                    distinctCellInstances.Add(board.Pieces[i, j]);
                }
            }

            Assert.Equal(boardSize * boardSize, distinctCellInstances.Count); // All cells should be distinct instances
        }

        [Fact]
        public void GameEnded_WhenGameIsNotOver_ReturnsFalse()
        {
            // Arrange
            var board = this.CreateBoard();
            board.Set(3); // Set dimensions
            board.PlacePiece(0, 0, "X");

            // Act
            var result = board.GameEnded;

            // Assert
            Assert.False(result);
        }

      

    }
}
