namespace TicTacToe.Patterns.state
{
    public interface IWinningState
    {
        bool IsInRow(Proxy[,] pieces);

    }
}
