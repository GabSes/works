using Microsoft.AspNetCore.Components.RenderTree;
using System.Drawing;
using TicTacToe.Interfaces;

public class MegaBoard : AbstractGameBoard
{
    public MegaBoard(AbstractBoardRenderer renderer) : base(renderer, 9) { }

    public override string Display()
    {
        return renderer.RenderBoard(size);
    }
}