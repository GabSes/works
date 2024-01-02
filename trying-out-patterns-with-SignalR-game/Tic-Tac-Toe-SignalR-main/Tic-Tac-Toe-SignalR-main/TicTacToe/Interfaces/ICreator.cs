using TicTacToe.GameObjects;
using TicTacToe.Interfaces;

public interface ICreator
{
    public ITicTacToeBoard FactoryMethod(int type);
}