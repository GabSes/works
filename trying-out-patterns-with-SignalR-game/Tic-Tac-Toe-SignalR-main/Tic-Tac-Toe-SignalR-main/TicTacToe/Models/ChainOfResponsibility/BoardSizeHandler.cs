using TicTacToe.GameObjects;
using TicTacToe.Interfaces;


public class BoardSizeHandler: Handler
{
    private Handler successor {get; set;}

    public BoardSizeHandler(Mediator Hub) : base(Hub)
    {
        successor = new CollumnHandler(Hub);
    }

    public override string handleRequest(string[] info)
    {
        if(info.Length != 0)
        {
            string color;
            if(info[0] == "3")
                color = "black";
            else if(info[0] == "4")
                color = "blue";
            else
                color = "white";
            return color + ":" + successor.handleRequest(info.Skip(1).ToArray());
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
        return (handleRequest(info), new Piece(""));
    }
}