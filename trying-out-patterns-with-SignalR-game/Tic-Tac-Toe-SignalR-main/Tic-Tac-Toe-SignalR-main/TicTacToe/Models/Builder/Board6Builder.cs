using TicTacToe.GameObjects;
using TicTacToe.Interfaces;

namespace TicTacToe.Models.Builder
{
    public class Board6Builder : IBoardBuilder
    {
        private Board6 board;

        public Board6Builder()
        {
            board = new Board6();
        }

        public IBoardBuilder SetDimensions(int dimensions)
        {

            return this;
        }

        public IBoardBuilder WithCustomConfigurations()
        {

            return this;
        }

        public Board Build()
        {

            return board;
        }
    }
}
