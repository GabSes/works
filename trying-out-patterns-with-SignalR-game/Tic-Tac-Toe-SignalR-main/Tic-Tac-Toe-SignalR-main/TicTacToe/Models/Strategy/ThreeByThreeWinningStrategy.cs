using System;
using TicTacToe.GameObjects;
using TicTacToe.Interfaces;
using TicTacToe.Patterns.state;

namespace TicTacToe.Models
{
    public class ThreeByThreeWinningStrategy : IWinningStrategy
    {
        public Proxy[,] Pieces { get; private set; }
        private IWinningState currentState;

        public ThreeByThreeWinningStrategy()
        {
            currentState = new ThreeInRowState();
        }

        public void ChangeState(IWinningState newState)
        {
            currentState = newState;
        }
        public bool IsThreeInRow(Proxy[,] pieces) => currentState.IsInRow(pieces);
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
            return IsThreeInRow(Pieces) || IsBoardFull(Pieces);
        }
        public bool IsFourInRow(Proxy[,] Pieces)
        {
            // Implement a method that always returns false for a 3x3 board.
            return false;
        }
        public bool IsFiveInRow(Proxy[,] Pieces)
        {

            return false;
        }
        public bool IsSixInRow(Proxy[,] Pieces)
        {

            return false;
        }
        public bool Accept(IWinningStrategyVisitor visitor)
        {
            return visitor.Visit(this);
        }

    }
}

