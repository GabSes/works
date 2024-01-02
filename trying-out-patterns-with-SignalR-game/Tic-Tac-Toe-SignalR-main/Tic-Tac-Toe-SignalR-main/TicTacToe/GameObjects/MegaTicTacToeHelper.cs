using TicTacToe.GameObjects;
using TicTacToe.Models;

public class MegaTicTacToeHelper
{
    private readonly ThreeByThreeWinningStrategy _strategy;
    private readonly Proxy[,] _megaBoard;

    public Proxy[,] BoardState => _megaBoard;

    public MegaTicTacToeHelper(Proxy[,] megaBoard)
    {
        if (megaBoard.GetLength(0) != 9 || megaBoard.GetLength(1) != 9)
            throw new ArgumentException("The board must be 9x9.");

        _strategy = new ThreeByThreeWinningStrategy();
        _megaBoard = megaBoard;
    }

    private Proxy[,] ExtractSubBoard(int rowOffset, int colOffset)
    {
        Proxy[,] subBoard = new Proxy[3, 3];
        for (int row = 0; row < 3; row++)
        {
            for (int col = 0; col < 3; col++)
            {
                subBoard[row, col] = _megaBoard[row + rowOffset, col + colOffset];
            }
        }
        return subBoard;
    }

    public bool IsGameOver()
    {
        Proxy[,] megaResultBoard = new Proxy[3, 3];

        // Check each 3x3 board and set the result in megaResultBoard
        for (int megaRow = 0; megaRow < 3; megaRow++)
        {
            for (int megaCol = 0; megaCol < 3; megaCol++)
            {
                Proxy[,] subBoard = ExtractSubBoard(megaRow * 3, megaCol * 3);
                if (_strategy.IsGameOver(subBoard))
                {
                    Proxy winner = new Proxy();
                    winner.requestUpdate(_strategy.IsThreeInRow(subBoard) ? subBoard[1, 1].requestValue() : "");
                    megaResultBoard[megaRow, megaCol] = winner;
                }
                else
                {
                    megaResultBoard[megaRow, megaCol] = new Proxy(); // empty cell
                }
            }
        }

        // Now, use the ThreeByThreeWinningStrategy to check the megaResultBoard
        return _strategy.IsGameOver(megaResultBoard);
    }

    public bool MakeMove(int row, int col, string player)
    {
        if (string.IsNullOrWhiteSpace(player) || (player != "X" && player != "O"))
            throw new ArgumentException("Invalid player. Only 'X' or 'O' allowed.");

        if (_megaBoard[row, col] == null || string.IsNullOrWhiteSpace(_megaBoard[row, col].requestValue()))
        {
            _megaBoard[row, col] = new Proxy();
            _megaBoard[row, col].requestUpdate(player);
            return true; // Move was successful
        }
        return false; // Cell already occupied
    }
}
