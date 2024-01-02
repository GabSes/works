namespace TicTacToe.Patterns.Interpreter
{
    public class Context
    {
        public string Sentence { get; private set; }

        public Context(string sentence)
        {
            Sentence = sentence;
        }
    }
}
