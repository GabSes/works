using TicTacToe.Models.Memento;
using TicTacToe.Patterns.Iterator;
using TicTacToe.Patterns.Template;

namespace TicTacToe.Hubs
{
    public class ChatState
    {
        private static ChatState? _instance;
        private static readonly object mLock = new object();
        private static readonly object messageLock = new object();

        private readonly MessagesCollection _messages = new MessagesCollection();

        private ChatState() { }
        public static ChatState? Instance
        {
            get
            {
                lock (mLock)
                {
                    if (_instance == null)
                        _instance = new ChatState();
                }

                return _instance;
            }
        }

        public void AddMessage(Message msg)
        {
            lock (messageLock)
            {
                _messages.AddItem(msg);
            }
        }

        public object GetMessage()
        {
            lock (messageLock)
            {
                return _messages.GetEnumerator().Current;
            }
        }

        public MessagesCollection GetMessages()
        {
            lock (messageLock)
            {
                return _messages;
            }
        }

        public bool RemoveMessage(string senderName, string content)
        {
            lock (messageLock)
            {
                // Find the message to remove
                Message messageToRemove = null;
                foreach (var msg in _messages.getItems())
                {
                    if (msg.SenderName == senderName && msg.Text == content)
                    {
                        messageToRemove = msg;
                        break;
                    }
                }

                // Remove the message if found
                if (messageToRemove != null)
                {
                    _messages.getItems().Remove(messageToRemove);
                    return true;
                }
                return false;
            }
        }
    }
}
