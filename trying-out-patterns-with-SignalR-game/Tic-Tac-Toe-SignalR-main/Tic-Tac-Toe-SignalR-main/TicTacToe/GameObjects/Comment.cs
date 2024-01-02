using TicTacToe.Interfaces;

namespace TicTacToe.GameObjects
{
    public class Comment : Cell, IComment
    {

        public Comment(string value) : base(value)
        {
            Set(value);
        }

        public override string ToString()
        {
            return Value;
        }

        public string getStatus()
        {
            return "comment";
        }

        string IComment.Comment()
        {
            return "Comment";
        }
    }
}
