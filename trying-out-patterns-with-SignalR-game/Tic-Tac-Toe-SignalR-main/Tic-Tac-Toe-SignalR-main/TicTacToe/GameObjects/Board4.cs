using TicTacToe.Interfaces;
using TicTacToe.Models;
using TicTacToe.Models.Strategy;

namespace TicTacToe.GameObjects
{
    public class Board4 : Board, IWinningStrategyVisitor
    {
        private IWinningStrategy winningStrategy;

        public Board4()
        {
            Set(4);
            winningStrategy = new FourByFourWinningStrategy();
        }

        public bool IsFourInRow
        {
            get
            {
                return winningStrategy.IsFourInRow(Pieces);
            }
        }

        public override bool GameEnded => this.IsFourInRow;
        private Stack<IBoardCommand> commandHistory = new Stack<IBoardCommand>();

        public void ExecuteCommand(IBoardCommand command)
        {
            command.Execute(this);
            commandHistory.Push(command);
        }

        public void UndoLastCommand()
        {
            if (commandHistory.Count > 0)
            {
                IBoardCommand lastCommand = commandHistory.Pop();
                lastCommand.Undo(this);
            }
        }
        public bool Visit(FourByFourWinningStrategy strategy)
        {
            Proxy[,] pieces = strategy.Pieces;

            // Check for the additional condition of having marked squares at each corner
            bool additionalCondition =
                (pieces[0, 0] != null && pieces[0, 0].requestValue() == "X") &&
                (pieces[0, 2] != null && pieces[0, 2].requestValue() == "X") &&
                (pieces[2, 0] != null && pieces[2, 0].requestValue() == "X") &&
                (pieces[2, 2] != null && pieces[2, 2].requestValue() == "X");

            // Return true if either standard three-in-a-row or additional condition is met
            return additionalCondition || IsFourInRow;
        }
        public bool Visit(ThreeByThreeWinningStrategy strategy)
        {
            return false;
        }
        public bool Visit(FiveByFiveWinningStrategy strategy)
        {
            return false;
        }
    }
}