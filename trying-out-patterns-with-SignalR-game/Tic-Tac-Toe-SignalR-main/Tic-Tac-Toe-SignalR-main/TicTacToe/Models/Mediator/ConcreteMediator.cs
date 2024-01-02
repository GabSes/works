using TicTacToe.GameObjects;

public class ConcreteMediator : Mediator
{
    private GameFactory factory {get; set;}

    private Handler handler {get; set;}

    public void setFactory(GameFactory Factory)
    {
       factory = Factory; 
    }

    public void setHandler(Handler Handler)
    {
        handler = Handler;
    }

    public override Piece callFactory(Player player, string[] info)
    {
        string ans;
        Piece hold;
        (ans, hold) = factory.ReceiveMessage(player, info);
        return hold;
    }

    public override string callHandler(Player player, string[] info)
    {
        string ans;
        Piece hold;
        (ans, hold) = handler.ReceiveMessage(player, info);
        return ans;
    }
}