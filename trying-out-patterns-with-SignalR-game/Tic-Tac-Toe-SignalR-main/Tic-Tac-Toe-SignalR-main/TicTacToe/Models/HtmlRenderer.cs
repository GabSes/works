using System.Text;
using TicTacToe.Interfaces;
using TicTacToe.Patterns.Bridge;

namespace TicTacToe.Models
{
    public class HtmlRenderer : AbstractBoardRenderer
    {
        public override string RenderBoard(int size)
        {
            StringBuilder sb = new StringBuilder();
            Interfaces.Shape shape;
            string shapeDescription;

            if (size == 3)
            {
                shape = new Square(new Red());
                shapeDescription = shape.Draw();

                sb.AppendLine("Three lines of verse,");
                sb.AppendLine("Simple and terse,");
                sb.AppendLine($"A tic-tac-toe, just like {shapeDescription},");
                sb.AppendLine("Standing out, vibrant and rare.");
            }
            else if (size == 4)
            {
                shape = new Rectangle(new Blue());
                shapeDescription = shape.Draw();

                sb.AppendLine("Four lines to the core,");
                sb.AppendLine("Each deeper than the one before,");
                sb.AppendLine($"A journey like {shapeDescription},");
                sb.AppendLine("Stretching wide, without any angle.");
            }
            else if (size == 9)
            {
                shape = new Triangle(new Green());
                shapeDescription = shape.Draw();

                sb.AppendLine("Nine lines, so divine,");
                sb.AppendLine("Woven tightly, so fine,");
                sb.AppendLine($"Like {shapeDescription}, tall and lean,");
                sb.AppendLine("A mega board, where legends convene,");
                sb.AppendLine("Each cell, its own sign,");
                sb.AppendLine("In this game, fortunes align,");
                sb.AppendLine("Victory, the ultimate shine,");
                sb.AppendLine("In this grid, players entwine,");
                sb.AppendLine("Tic-tac-toe, an ancient sign.");
            }

            return sb.ToString();
        }
    }
}
