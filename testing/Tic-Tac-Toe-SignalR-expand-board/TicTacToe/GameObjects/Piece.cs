namespace TicTacToe.GameObjects
{
    public class Piece : Cell
    {

        public Piece(string value) : base(value)
        {
            Set(value);
        }

        public override string ToString()
        {
            return Value;
        }

        public string getStatus()
        {
            return "piece";
        }
    }
}
