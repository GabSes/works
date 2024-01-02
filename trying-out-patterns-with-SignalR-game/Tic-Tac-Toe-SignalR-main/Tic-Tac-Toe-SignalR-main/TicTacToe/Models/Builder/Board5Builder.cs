using TicTacToe.GameObjects;
using TicTacToe.Interfaces;

namespace TicTacToe.Models.Builder
{
    public class Board5Builder : IBoardBuilder
    {
        private Board5 board;

        public Board5Builder()
        {
            board = new Board5();
        }

        public IBoardBuilder SetDimensions(int dimensions)
        {
            // Set dimensions and configure the board.
            return this;
        }

        public IBoardBuilder WithCustomConfigurations()
        {
            // Add custom configurations for a 5x5 board.
            return this;
        }

        public Board Build()
        {
            // Return the 5x5 board that has been configured.
            return board;
        }
    }
}
