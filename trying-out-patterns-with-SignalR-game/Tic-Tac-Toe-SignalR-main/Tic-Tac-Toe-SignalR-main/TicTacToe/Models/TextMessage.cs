using TicTacToe.Patterns.Template;

namespace TicTacToe.Models
{
    public class TextMessage : Message
    {
        public TextMessage() { }
        public TextMessage(MessageData message)
        {
            this.SendTime = message.SendTime;
            this.SenderName = message.SenderName;
            this.Text = message.Text;
        }

        protected override bool hasImage()
        {
            return false;
        }

        public override string ToString()
        {
            return String.Format("Send Time:{0} | Sender name:{1} | Text:{2}", this.SendTime, this.SenderName, this.Text);
        }
    }
}
