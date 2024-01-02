using TicTacToe.GameObjects;
using TicTacToe.Interfaces;


public class CollumnHandler: Handler
{
    private Handler successor {get; set;}

    public CollumnHandler(Mediator Hub): base(Hub)
    {
        successor = new RowHandler(Hub);
    }

    public override string handleRequest(string[] info)
    {
        if(info.Length != 0)
        {
            string font;
            if(info[0] == "0")
                font = "Arial";
            else if(info[0] == "2")
                font = "Times New Roman";
            else
                font = "Courier New";
            return font + ":" + successor.handleRequest(info.Skip(1).ToArray());
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