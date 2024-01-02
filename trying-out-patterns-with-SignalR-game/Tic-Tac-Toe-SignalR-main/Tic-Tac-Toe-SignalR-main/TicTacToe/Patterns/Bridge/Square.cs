using TicTacToe.Interfaces;


namespace TicTacToe.Patterns.Bridge
{
    public class Square : Interfaces.Shape
    {
        private Color color;

        public Square(Color color)
        {
            this.color = color;
        }

        public override string Draw()
        {
            return $"a {color.Fill()} square";
        }
    }
}
