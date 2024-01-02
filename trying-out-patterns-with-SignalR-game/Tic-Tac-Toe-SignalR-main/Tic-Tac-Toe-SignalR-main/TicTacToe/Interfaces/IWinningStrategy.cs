using TicTacToe.GameObjects;
using TicTacToe.Interfaces;
using TicTacToe.Models;
public interface IWinningStrategy
{
    bool Accept(IWinningStrategyVisitor visitor);
    bool IsThreeInRow(Proxy[,] Pieces); // For 3x3 board
    bool IsFourInRow(Proxy[,] Pieces);  // For 4x4 board
    bool IsFiveInRow(Proxy[,] Pieces);  // For 5x5 board
    bool IsSixInRow(Proxy[,] Pieces);  // For 6x6 board
}
