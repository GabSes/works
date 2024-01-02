namespace TicTacToe.Patterns.state
{
    public class FiveInRowState : IWinningState
    {
        public bool IsInRow(Proxy[,] pieces)
        {
            return CheckRows(pieces) || CheckColumns(pieces) || CheckDiagonals(pieces);
        }

        private bool CheckRows(Proxy[,] pieces)
        {
            int rows = pieces.GetLength(0);
            int cols = pieces.GetLength(1);

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col <= cols - 5; col++)
                {
                    if (CheckConsecutive(pieces[row, col], pieces[row, col + 1], pieces[row, col + 2], pieces[row, col + 3], pieces[row, col + 4]))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private bool CheckColumns(Proxy[,] pieces)
        {
            int rows = pieces.GetLength(0);
            int cols = pieces.GetLength(1);

            for (int col = 0; col < cols; col++)
            {
                for (int row = 0; row <= rows - 5; row++)
                {
                    if (CheckConsecutive(pieces[row, col], pieces[row + 1, col], pieces[row + 2, col], pieces[row + 3, col], pieces[row + 4, col]))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private bool CheckDiagonals(Proxy[,] pieces)
        {
            int rows = pieces.GetLength(0);
            int cols = pieces.GetLength(1);

            for (int row = 0; row <= rows - 5; row++)
            {
                for (int col = 0; col <= cols - 5; col++)
                {
                    // Check diagonal from upper left to lower right
                    if (CheckConsecutive(pieces[row, col], pieces[row + 1, col + 1], pieces[row + 2, col + 2], pieces[row + 3, col + 3], pieces[row + 4, col + 4]))
                    {
                        return true;
                    }

                    // Check diagonal from upper right to lower left
                    if (CheckConsecutive(pieces[row, col + 4], pieces[row + 1, col + 3], pieces[row + 2, col + 2], pieces[row + 3, col + 1], pieces[row + 4, col]))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private bool CheckConsecutive(params Proxy[] values)
        {
            // Check if all values are non-null, non-empty, and equal
            return values.All(value => value != null && !string.IsNullOrWhiteSpace(value.requestValue()) && value.requestValue() == values[0].requestValue());
        }

    }
}
