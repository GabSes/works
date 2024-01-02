using TicTacToe.Interfaces;

namespace TicTacToe.Patterns.Bridge
{
    public class Rectangle : Interfaces.Shape
    {
        private Color color;

        public Rectangle(Color color)
        {
            this.color = color;
        }

        public override string Draw()
        {
            return $"a {color.Fill()} rectangle";
        }
    }
}
