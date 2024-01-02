namespace TicTacToe.Patterns.Interpreter
{
    public abstract class Expression
    {
        public abstract string Interpret(Context context);
    }
}
