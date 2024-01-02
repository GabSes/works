using Microsoft.AspNetCore.Components.RenderTree;
using System.Drawing;
using TicTacToe.Interfaces;

namespace TicTacToe.Models
{
    public class NormalBoardFour : AbstractGameBoard
    {
        public NormalBoardFour(AbstractBoardRenderer renderer) : base(renderer, 4) { }

        public override string Display()
        {
            return renderer.RenderBoard(size);
        }
    }
}
