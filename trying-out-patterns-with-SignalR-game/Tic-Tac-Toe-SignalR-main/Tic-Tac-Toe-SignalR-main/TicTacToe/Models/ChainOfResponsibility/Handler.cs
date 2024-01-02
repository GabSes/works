using TicTacToe.GameObjects;
using TicTacToe.Interfaces;


public abstract class Handler: Colleague
{
    protected Handler(Mediator Hub) : base(Hub)
    {
        hub = Hub;
    }

    private Handler successor {get; set;}

    public abstract string handleRequest(string[] info);
}
