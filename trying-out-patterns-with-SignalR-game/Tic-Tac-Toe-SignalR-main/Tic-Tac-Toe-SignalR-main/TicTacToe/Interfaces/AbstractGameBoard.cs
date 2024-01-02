namespace TicTacToe.Interfaces
{
    public abstract class AbstractGameBoard
    {
        protected AbstractBoardRenderer renderer;
        protected int size;

        public AbstractGameBoard(AbstractBoardRenderer renderer, int size)
        {
            this.renderer = renderer;
            this.size = size;
        }

        public abstract string Display();
    }
}
