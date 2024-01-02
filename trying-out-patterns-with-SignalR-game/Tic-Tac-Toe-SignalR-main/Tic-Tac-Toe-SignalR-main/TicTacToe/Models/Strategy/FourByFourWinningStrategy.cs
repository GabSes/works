using TicTacToe.GameObjects;
using TicTacToe.Interfaces;
using TicTacToe.Patterns.state;

namespace TicTacToe.Models
{
    public class FourByFourWinningStrategy : IWinningStrategy
    {
        public Proxy[,] Pieces { get; private set; }
        private IWinningState currentState;

        public FourByFourWinningStrategy()
        {
            currentState = new FourInRowState();
        }
        public bool IsFourInRow(Proxy[,] pieces) => currentState.IsInRow(pieces);
        public void ChangeState(IWinningState newState)
        {
            currentState = newState;
        }

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
            return IsFourInRow(Pieces) || IsBoardFull(Pieces);
        }
        public bool IsThreeInRow(Proxy[,] pieces)
        {
            // Implement a method that always returns false for a 3x3 board.
            return false;
        }
        public bool IsFiveInRow(Proxy[,] pieces)
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
