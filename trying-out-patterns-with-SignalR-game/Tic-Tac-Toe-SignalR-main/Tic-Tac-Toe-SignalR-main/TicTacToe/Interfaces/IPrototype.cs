using TicTacToe.GameObjects;

namespace TicTacToe.Interfaces
{
    public interface IPrototype<T>
    {
        public T ShallowCopy();
        public T DeepCopy();
    }
}
