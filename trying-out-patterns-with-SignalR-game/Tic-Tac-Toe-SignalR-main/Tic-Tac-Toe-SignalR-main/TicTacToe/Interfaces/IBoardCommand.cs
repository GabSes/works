using TicTacToe.GameObjects;

namespace TicTacToe.Interfaces
{
    public interface IBoardCommand
    {
        void Execute(Board4 board);
        void Undo(Board4 board);
    }

}
