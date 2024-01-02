using Microsoft.AspNetCore.Components.RenderTree;
using System.Drawing;
using TicTacToe.Interfaces;

namespace TicTacToe.Models
{
    public class NormalBoardThree : AbstractGameBoard
    {
        public NormalBoardThree(AbstractBoardRenderer renderer) : base(renderer, 3) { }

        public override string Display()
        {
            return renderer.RenderBoard(size);
        }
    }
}
