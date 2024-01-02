using TicTacToe.GameObjects;
using TicTacToe.Interfaces;
using TicTacToe.Patterns.state;

namespace TicTacToe.Models
{
    public class SixBySixWinningStrategy : IWinningStrategy
    {
        private IWinningState currentState;
        public Proxy[,] Pieces { get; private set; }
        public SixBySixWinningStrategy()
        {
            currentState = new SixInRowState();
        }
        public bool IsSixInRow(Proxy[,] pieces) => currentState.IsInRow(pieces);
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
            return IsSixInRow(Pieces) || IsBoardFull(Pieces);
        }
        public bool IsFourInRow(Proxy[,] Pieces)
        {

            return false;
        }
        public bool IsFiveInRow(Proxy[,] Pieces)
        {

            return false;
        }
        public bool IsThreeInRow(Proxy[,] Pieces)
        {
            // Implement a method that always returns false for a 3x3 board.
            return false;
        }
        public bool Accept(IWinningStrategyVisitor visitor)
        {
            return false;
        }
    }
}
