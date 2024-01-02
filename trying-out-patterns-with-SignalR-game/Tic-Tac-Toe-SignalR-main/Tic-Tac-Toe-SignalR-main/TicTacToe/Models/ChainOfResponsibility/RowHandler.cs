using TicTacToe.GameObjects;
using TicTacToe.Interfaces;


public class RowHandler: Handler
{
    private Handler successor {get; set;}

    public RowHandler(Mediator Hub) : base(Hub)
    {
        successor = new ObstaclesHandler(Hub);
        hub = Hub;
    }

    public override string handleRequest(string[] info)
    {
        if(info.Length != 0)
        {
            string fontSize;
            if(info[0] == "0")
                fontSize = "5px";
            else if(info[0] == "2")
                fontSize = "10px";
            else
                fontSize = "15px";
            return fontSize + ":" + successor.handleRequest(info.Skip(1).ToArray());
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