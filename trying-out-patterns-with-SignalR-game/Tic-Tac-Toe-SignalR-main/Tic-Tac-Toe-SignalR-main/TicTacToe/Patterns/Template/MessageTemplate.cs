namespace TicTacToe.Patterns.Template
{
    public abstract class MessageTemplate
    {
        public abstract Message BuildMessage(MessageData message);
    }
}
