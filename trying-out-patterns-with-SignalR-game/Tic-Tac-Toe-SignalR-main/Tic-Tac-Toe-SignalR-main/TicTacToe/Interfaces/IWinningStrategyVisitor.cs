using TicTacToe.Models.Strategy;
using TicTacToe.Models;

namespace TicTacToe.Interfaces
{
    public interface IWinningStrategyVisitor
    {
        bool Visit(ThreeByThreeWinningStrategy strategy);
        bool Visit(FourByFourWinningStrategy strategy);
        bool Visit(FiveByFiveWinningStrategy strategy);

    }
}
