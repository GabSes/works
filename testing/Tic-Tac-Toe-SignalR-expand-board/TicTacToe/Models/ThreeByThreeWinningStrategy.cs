using System;
using TicTacToe.GameObjects;

namespace TicTacToe.Models
{
    public class ThreeByThreeWinningStrategy : IWinningStrategy
    {
        public bool IsThreeInRow(Cell[,] Pieces)
        {
            // Check all rows
            for (int row = 0; row < Pieces.GetLength(0); row++)
            {
                if (Pieces[row, 0] != null && !string.IsNullOrWhiteSpace(Pieces[row, 0].Value) &&
                    Pieces[row, 0].Value == Pieces[row, 1].Value &&
                    Pieces[row, 1].Value == Pieces[row, 2].Value)
                {
                    return true;
                }
            }

            // Check all columns
            for (int col = 0; col < Pieces.GetLength(1); col++)
            {
                if (Pieces[0, col] != null && !string.IsNullOrWhiteSpace(Pieces[0, col].Value) &&
                    Pieces[0, col].Value == Pieces[1, col].Value &&
                    Pieces[1, col].Value == Pieces[2, col].Value)
                {
                    return true;
                }
            }

            // Check forward-diagonal
            if (Pieces[1, 1] != null && !string.IsNullOrWhiteSpace(Pieces[1, 1].Value) &&
                Pieces[2, 0].Value == Pieces[1, 1].Value &&
                Pieces[1, 1].Value == Pieces[0, 2].Value)
            {
                return true;
            }

            // Check backward-diagonal
            if (Pieces[1, 1] != null && !string.IsNullOrWhiteSpace(Pieces[1, 1].Value) &&
                Pieces[0, 0].Value == Pieces[1, 1].Value &&
                Pieces[1, 1].Value == Pieces[2, 2].Value)
            {
                return true;
            }

            return false;
        }

        public bool IsBoardFull(Cell[,] Pieces)
        {
            for (int row = 0; row < Pieces.GetLength(0); row++)
            {
                for (int col = 0; col < Pieces.GetLength(1); col++)
                {
                    if (Pieces[row, col] == null || string.IsNullOrWhiteSpace(Pieces[row, col].Value))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public bool IsGameOver(Cell[,] Pieces)
        {
            return IsThreeInRow(Pieces) || IsBoardFull(Pieces);
        }
        public bool IsFourInRow(Cell[,] Pieces)
        {
            // Implement a method that always returns false for a 3x3 board.
            return false;
        }
    }
}

