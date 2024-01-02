using TicTacToe.Interfaces;
using TicTacToe.Models;
using TicTacToe.Models.Strategy;

namespace TicTacToe.GameObjects
{
    public class Board5 : Board, IWinningStrategyVisitor
    {
        private IWinningStrategy winningStrategy;

        public Board5()
        {
            Set(5);
            winningStrategy = new FiveByFiveWinningStrategy();
        }

        public bool IsFiveInRow
        {
            get
            {
                return winningStrategy.IsFiveInRow(Pieces);
            }
        }

        public override bool GameEnded
        {
            get
            {
                return this.winningStrategy.IsFiveInRow(Pieces);
            }
        }
        public bool Visit(FiveByFiveWinningStrategy strategy)
        {
            Proxy[,] pieces = strategy.Pieces;

            // Check for the additional condition of having marked squares at each corner
            bool additionalCondition =
                (pieces[0, 0] != null && pieces[0, 0].requestValue() == "X") &&
                (pieces[0, 2] != null && pieces[0, 2].requestValue() == "X") &&
                (pieces[2, 0] != null && pieces[2, 0].requestValue() == "X") &&
                (pieces[2, 2] != null && pieces[2, 2].requestValue() == "X");

            // Return true if either standard three-in-a-row or additional condition is met
            return additionalCondition || IsFiveInRow;
        }
        public bool Visit(FourByFourWinningStrategy strategy)
        {
            return false;
        }
        public bool Visit(ThreeByThreeWinningStrategy strategy)
        {
            return false;
        }
    }
}
