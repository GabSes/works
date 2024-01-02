using TicTacToe.Models;

namespace TicTacToe.GameObjects
{
    public class Board4 : Board
    {
        private IWinningStrategy winningStrategy;

        public Board4()
        {
            Set(4);
            winningStrategy = new FourByFourWinningStrategy();
        }

        public bool IsFourInRow
        {
            get
            {
                return winningStrategy.IsFourInRow(Pieces);
            }
        }

        public override bool GameEnded
        {
            get
            {
                return this.winningStrategy.IsFourInRow(Pieces);
            }
        }
    }
}