using TicTacToe.GameObjects;
using TicTacToe.Interfaces;
using TicTacToe.Patterns.state;

namespace TicTacToe.Models.Strategy
{
    public class FiveByFiveWinningStrategy : IWinningStrategy
    {
        private IWinningState currentState;
        public Proxy[,] Pieces { get; private set; }
        public FiveByFiveWinningStrategy()
        {
            currentState = new FiveInRowState();
        }

        public void ChangeState(IWinningState newState)
        {
            currentState = newState;
        }
        public bool IsFiveInRow(Proxy[,] pieces) => currentState.IsInRow(pieces);


        public bool IsBoardFull(Proxy[,] Pieces)
        {
            for (int row = 0; row < Pieces.GetLength(0); row++)
            {
                for (int col = 0; col < Pieces.GetLength(1); col++)
                {
                    if (Pieces[row, col] == null || string.IsNullOrWhiteSpace(Pieces[row, col].requestValue()))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public bool IsGameOver(Proxy[,] Pieces)
        {
            return IsFiveInRow(Pieces) || IsBoardFull(Pieces);
        }
        public bool IsThreeInRow(Proxy[,] pieces)
        {
            // Implement a method that always returns false for a 3x3 board.
            return false;
        }
        public bool IsFourInRow(Proxy[,] pieces)
        {

            return false;
        }
        public bool IsSixInRow(Proxy[,] pieces)
        {
            return false;
        }

        public bool Accept(IWinningStrategyVisitor visitor)
        {
            return visitor.Visit(this);
        }
    }

}
