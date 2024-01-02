using TicTacToe.Models;

namespace TicTacToe.GameObjects
{
    public class Board6 : Board
    {
        private IWinningStrategy winningStrategy;

        public Board6()
        {
            Set(6);
            winningStrategy = new SixBySixWinningStrategy();
        }

        public bool IsSixInRow
        {
            get
            {
                return winningStrategy.IsSixInRow(Pieces);
            }
        }

        public override bool GameEnded => this.IsSixInRow;
    }
}
