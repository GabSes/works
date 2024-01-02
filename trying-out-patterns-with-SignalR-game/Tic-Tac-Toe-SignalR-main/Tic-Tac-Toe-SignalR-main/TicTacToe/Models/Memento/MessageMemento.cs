namespace TicTacToe.Models.Memento
{
    public class MessageMemento
    {
        public string Content { get; private set; }
        public string SenderName { get; private set; }

        public MessageMemento(string content, string senderName)
        {
            Content = content;
            SenderName = senderName;
        }
    }
}
