using TicTacToe.GameObjects;

public abstract class Mediator
{
    protected GameFactory factory {get; set;}

    protected Handler handler {get; set;}

    public void setFactory(GameFactory Factory)
    {
       factory = Factory; 
    }

    public void setHandler(Handler Handler)
    {
        handler = Handler;
    }

    public abstract Piece callFactory(Player player, string[] info);

    public abstract string callHandler(Player player, string[] info);
}