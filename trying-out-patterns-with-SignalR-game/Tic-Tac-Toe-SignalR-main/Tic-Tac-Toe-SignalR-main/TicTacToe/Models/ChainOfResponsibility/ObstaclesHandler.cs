using TicTacToe.GameObjects;
using TicTacToe.Interfaces;


public class ObstaclesHandler: Handler
{
    private Handler successor {get; set;}

    public ObstaclesHandler(Mediator Hub): base(Hub)
    {
        hub= Hub;
    }

    public override string handleRequest(string[] info)
    {
        if(info.Length != 0)
        {
            string textDecoration;
            if(bool.Parse(info[0]))
                textDecoration = "line-through";
            else
                textDecoration = "underline";
            return textDecoration;
        }
        else
        {
            return "";
        }
    }

    public override void SendMessage()
    {
        throw new NotImplementedException();
    }

    public override (string, Piece) ReceiveMessage(Player player, string[] info)
    {
        throw new NotImplementedException();
    }
}