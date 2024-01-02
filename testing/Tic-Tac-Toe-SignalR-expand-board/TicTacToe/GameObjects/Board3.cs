using TicTacToe.Models;

namespace TicTacToe.GameObjects;


public class Board3 : Board
{
    public IWinningStrategy winningStrategy;

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

    public override bool GameEnded
    {
        get
        {
            return this.IsThreeInRow;
        }
    }
}