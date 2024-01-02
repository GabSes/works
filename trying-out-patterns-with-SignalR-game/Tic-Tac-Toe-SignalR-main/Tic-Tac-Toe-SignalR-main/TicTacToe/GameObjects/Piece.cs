using TicTacToe.Interfaces;

namespace TicTacToe.GameObjects
{
    public class Piece
    {
        public string Value { get; private set; }

        public Piece(string value)
        {
            Value = value;
        }

        public override string ToString()
        {
            return Value;
        }
    }
}
