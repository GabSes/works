using System.Diagnostics;
using TicTacToe.Patterns.Template;

namespace TicTacToe.Models.Memento
{
    public class ChatCaretaker
    {
        private Stack<MessageMemento> messageHistory = new Stack<MessageMemento>();

        public ChatCaretaker()
        {
            Debug.WriteLine("ChatCaretaker instance created."); // Log instance creation
        }


        public void SaveMessage(Message message)
        {
            messageHistory.Push(message.SaveToMemento());
            var test = messageHistory.Count;
            var x = test;
        }

        public MessageMemento GetLastMessage()
        {
            var count = messageHistory.Count;
            return messageHistory.Count > 0 ? messageHistory.Pop() : null;
        }
    }
}
