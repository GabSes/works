using TicTacToe.Models;
using TicTacToe.Models.Memento;

namespace TicTacToe.Patterns.Template
{
    public abstract class Message : MessageTemplate
    {
        public string SendTime { get; set; }
        public string SenderName { get; set; }
        public string Image { get; set; }
        public string Text { get; set; }
        public override sealed Message BuildMessage(MessageData message)
        {
            if (hasImage())
            {
                return new GifMessage(message);
            }
            else
            {
                return new TextMessage(message);
            }
        }

        public MessageMemento SaveToMemento()
        {
            return new MessageMemento(this.Text, this.SenderName);
        }

        public void RestoreFromMemento(MessageMemento memento)
        {
            this.Text = memento.Content;
            this.SenderName = memento.SenderName;
        }

        protected abstract bool hasImage();
    }
}
