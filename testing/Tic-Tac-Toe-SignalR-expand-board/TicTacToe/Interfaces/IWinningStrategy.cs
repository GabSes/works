using TicTacToe.GameObjects;

public interface IWinningStrategy
{
    bool IsThreeInRow(Cell[,] Pieces); // For 3x3 board
    bool IsFourInRow(Cell[,] Pieces);  // For 4x4 board
}
