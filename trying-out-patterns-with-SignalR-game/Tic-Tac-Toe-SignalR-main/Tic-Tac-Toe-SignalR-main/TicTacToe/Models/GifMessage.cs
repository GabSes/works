using System.Reflection.Metadata;
using TicTacToe.Patterns.Template;

namespace TicTacToe.Models
{
    public class GifMessage : Message
    {
        public GifMessage() { }
        public GifMessage(MessageData message) 
        {
            this.SendTime = message.SendTime;
            this.SenderName = message.SenderName;
            this.Image = message.Image;
        }

        protected override bool hasImage()
        {
            return true;
        }

        public override string ToString()
        {
            return String.Format("Send Time:{0} | Sender name:{1} | Text:{2}", this.SendTime, this.SenderName, this.Image);
        }
    }
}
