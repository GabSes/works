using TicTacToe.Interfaces;
using TicTacToe.Models;
using TicTacToe.Models.Strategy;

namespace TicTacToe.GameObjects;


public class Board3 : Board, IWinningStrategyVisitor
{
    private IWinningStrategy winningStrategy;

    public Board3()
    {
        Set(3);
        winningStrategy = new ThreeByThreeWinningStrategy();
    }

    public bool IsThreeInRow
    {
        get
        {
            return winningStrategy.IsThreeInRow(Pieces);
        }
    }

    public override bool GameEnded => this.IsThreeInRow;

    public bool Visit(ThreeByThreeWinningStrategy strategy)
    {
        Proxy[,] pieces = strategy.Pieces;

        // Check for the additional condition of having marked squares at each corner
        bool additionalCondition =
            (pieces[0, 0] != null && pieces[0, 0].requestValue() == "X") &&
            (pieces[0, 2] != null && pieces[0, 2].requestValue() == "X") &&
            (pieces[2, 0] != null && pieces[2, 0].requestValue() == "X") &&
            (pieces[2, 2] != null && pieces[2, 2].requestValue() == "X");

        // Return true if either standard three-in-a-row or additional condition is met
        return additionalCondition || IsThreeInRow;
    }

    public bool Visit(FourByFourWinningStrategy strategy)
    {
        return false;
    }
    public bool Visit(FiveByFiveWinningStrategy strategy)
    {
        return false;
    }
}