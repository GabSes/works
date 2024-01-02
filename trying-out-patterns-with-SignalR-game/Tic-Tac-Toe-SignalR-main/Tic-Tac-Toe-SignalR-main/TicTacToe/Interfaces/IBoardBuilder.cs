using TicTacToe.GameObjects;

namespace TicTacToe.Interfaces
{
    public interface IBoardBuilder
    {
        IBoardBuilder SetDimensions(int dimensions);
        IBoardBuilder WithCustomConfigurations();
        Board Build();
    }
}
