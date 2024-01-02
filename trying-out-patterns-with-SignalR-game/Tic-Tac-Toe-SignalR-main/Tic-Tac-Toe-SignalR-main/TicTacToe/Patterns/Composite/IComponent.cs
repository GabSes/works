namespace TicTacToe.Patterns.Composite
{
    public interface IComponent
    {
        void Display(int indentationLevel);
        string GetValue();
    }
}
