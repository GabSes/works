using Moq;
using TicTacToe.GameObjects;
using TicTacToe.Models;

public class FourByFourWinningStrategyTests
{
    private MockRepository mockRepository;

    public FourByFourWinningStrategyTests()
    {
        this.mockRepository = new MockRepository(MockBehavior.Strict);
    }

    private FourByFourWinningStrategy CreateFourByFourWinningStrategy()
    {
        return new FourByFourWinningStrategy();
    }

    [Fact]
    public void IsFourInRow_NoWinningCondition_ReturnsFalse()
    {
        // Arrange
        var fourByFourWinningStrategy = this.CreateFourByFourWinningStrategy();
        Cell[,] Pieces = new Cell[4, 4];

        // Act
        var result = fourByFourWinningStrategy.IsFourInRow(Pieces);

        // Assert
        Assert.False(result);
        this.mockRepository.VerifyAll();
    }

    [Fact]
    public void IsFourInRow_WinningRow_ReturnsTrue()
    {
        // Arrange
        var fourByFourWinningStrategy = this.CreateFourByFourWinningStrategy();
        Cell[,] Pieces = new Cell[4, 4];

        // Create a winning row
        Pieces[0, 0] = new Cell("X");
        Pieces[0, 1] = new Cell("X");
        Pieces[0, 2] = new Cell("X");
        Pieces[0, 3] = new Cell("X");

        // Act
        var result = fourByFourWinningStrategy.IsFourInRow(Pieces);

        // Assert
        Assert.True(result);
        this.mockRepository.VerifyAll();
    }

    [Fact]
    public void IsFourInRow_WinningColumn_ReturnsTrue()
    {
        // Arrange
        var fourByFourWinningStrategy = this.CreateFourByFourWinningStrategy();
        Cell[,] Pieces = new Cell[4, 4];

        // Create a winning column with initialized Cell objects
        Pieces[0, 0] = new Cell("X");
        Pieces[1, 0] = new Cell("X");
        Pieces[2, 0] = new Cell("X");
        Pieces[3, 0] = new Cell("X");

        // Act
        var result = fourByFourWinningStrategy.IsFourInRow(Pieces);

        // Assert
        Assert.True(result);
        this.mockRepository.VerifyAll();
    }


    [Fact]
    public void IsBoardFull_EmptyBoard_ReturnsFalse()
    {
        // Arrange
        var fourByFourWinningStrategy = this.CreateFourByFourWinningStrategy();
        Cell[,] Pieces = new Cell[4, 4];

        // Act
        var result = fourByFourWinningStrategy.IsBoardFull(Pieces);

        // Assert
        Assert.False(result);
        this.mockRepository.VerifyAll();
    }

    // Similar tests for partially full and full boards

    [Fact]
    public void IsGameOver_NoWinningCondition_NotFull_ReturnsFalse()
    {
        // Arrange
        var fourByFourWinningStrategy = this.CreateFourByFourWinningStrategy();
        Cell[,] Pieces = new Cell[4, 4];

        // Act
        var result = fourByFourWinningStrategy.IsGameOver(Pieces);

        // Assert
        Assert.False(result);
        this.mockRepository.VerifyAll();
    }

    // Similar tests for winning condition and full board

    [Fact]
    public void IsThreeInRow_AnyBoard_ReturnsFalse()
    {
        // Arrange
        var fourByFourWinningStrategy = this.CreateFourByFourWinningStrategy();
        Cell[,] Pieces = new Cell[4, 4];

        // Act
        var result = fourByFourWinningStrategy.IsThreeInRow(Pieces);

        // Assert
        Assert.False(result);
        this.mockRepository.VerifyAll();
    }
    [Fact]
    public void IsFourInRow_WinningDiagonal_ReturnsTrue()
    {
        // Arrange
        var fourByFourWinningStrategy = this.CreateFourByFourWinningStrategy();
        Cell[,] Pieces = new Cell[4, 4];

        // Create a winning diagonal with initialized Cell objects
        Pieces[1, 1] = new Cell("X");
        Pieces[2, 0] = new Cell("X");
        Pieces[0, 2] = new Cell("X");
        Pieces[3, 3] = new Cell("X");

        // Act
        var result = fourByFourWinningStrategy.IsFourInRow(Pieces);

        // Assert
        Assert.True(result);
        this.mockRepository.VerifyAll();
    }
    [Fact]
    public void IsFourInRow_WinningBackwardDiagonal_ReturnsTrue()
    {
        // Arrange
        var fourByFourWinningStrategy = this.CreateFourByFourWinningStrategy();
        Cell[,] Pieces = new Cell[4, 4];

        // Create a winning backward-diagonal with initialized Cell objects
        Pieces[1, 2] = new Cell("X");
        Pieces[0, 3] = new Cell("X");
        Pieces[2, 1] = new Cell("X");
        Pieces[3, 0] = new Cell("X");

        // Act
        var result = fourByFourWinningStrategy.IsFourInRow(Pieces);

        // Assert
        Assert.True(result);
        this.mockRepository.VerifyAll();
    }
    [Fact]
    public void IsBoardFull_PartiallyFullBoard_ReturnsFalse()
    {
        // Arrange
        var fourByFourWinningStrategy = this.CreateFourByFourWinningStrategy();
        Cell[,] Pieces = new Cell[4, 4];

        // Create a partially full board
        Pieces[0, 0] = new Cell("X");
        Pieces[1, 1] = new Cell("O");

        // Act
        var result = fourByFourWinningStrategy.IsBoardFull(Pieces);

        // Assert
        Assert.False(result);
        this.mockRepository.VerifyAll();
    }

    [Fact]
    public void IsBoardFull_CompletelyFullBoard_ReturnsTrue()
    {
        // Arrange
        var fourByFourWinningStrategy = this.CreateFourByFourWinningStrategy();
        Cell[,] Pieces = new Cell[4, 4];

        // Fill the entire board
        for (int row = 0; row < Pieces.GetLength(0); row++)
        {
            for (int col = 0; col < Pieces.GetLength(1); col++)
            {
                Pieces[row, col] = new Cell("X");
            }
        }

        // Act
        var result = fourByFourWinningStrategy.IsBoardFull(Pieces);

        // Assert
        Assert.True(result);
        this.mockRepository.VerifyAll();
    }
}
