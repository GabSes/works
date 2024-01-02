
using TicTacToe.GameObjects;
using TicTacToe.Controllers;
using TicTacToe.Interfaces;
using TicTacToe.Models.DecoratorPattern;


public abstract class GameFactory : Colleague
{


    protected GameFactory(Mediator Hub) : base(Hub)
    {
        hub = Hub;
    }

    
    public override (string, Piece) ReceiveMessage(Player player, string[] info)
    {
        return ("", CreatePiece(player));
    }

    public abstract Piece CreatePiece(Player player);
    public abstract Obstacle CreateObstacle();
    public abstract IComment CreateComment();
}