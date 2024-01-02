using Microsoft.AspNet.SignalR;
using TicTacToe.GameObjects;
using TicTacToe.Interfaces;


public abstract class Colleague
{
    public Mediator hub {get; set;}
    public Colleague(Mediator Hub)
    {
        hub = Hub;
    }
    public abstract void SendMessage();
    public abstract (string, Piece) ReceiveMessage(Player player, string[] info);
}