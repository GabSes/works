using TicTacToe.Interfaces;

namespace TicTacToe.Patterns.Bridge
{
    public class Triangle : Interfaces.Shape
    {
        private Color color;

        public Triangle(Color color)
        {
            this.color = color;
        }

        public override string Draw()
        {
            return $"a {color.Fill()} triangle";
        }
    }
}
