using TicTacToe.Interfaces;

namespace TicTacToe.Patterns.Bridge
{
    public class Red : Color
    {
        public override string Fill()
        {
            return "red";
        }
    }
}
