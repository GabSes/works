using TicTacToe.Controllers;
using TicTacToe.Interfaces;
using TicTacToe.Models.DecoratorPattern;


namespace TicTacToe.GameObjects
{
    public class MegaBoardAdapter : ITicTacToeBoard
    {
        private MegaTicTacToeHelper _adapter;

        public MegaBoardAdapter(Proxy[,] megaBoard)
        {
            _adapter = new MegaTicTacToeHelper(megaBoard);
        }

        public bool GameEnded => _adapter.IsGameOver();
        public Proxy[,] Pieces
        {
            get
            {
                // Assuming MegaTicTacToeHelper has a method to retrieve the board
                return _adapter.BoardState;
            }
        }

        public bool AreSpacesLeft
        {
            get
            {
                // Iterating through each cell to see if any cell is empty
                for (int i = 0; i < BoardSize; i++)
                {
                    for (int j = 0; j < BoardSize; j++)
                    {
                        if (string.IsNullOrWhiteSpace(Pieces[i, j].requestValue()))
                        {
                            return true;
                        }
                    }
                }
                return false;
            }
        }

        public int BoardSize
        {
            get
            {
                // Assuming the board is square
                return Pieces.GetLength(0);
            }
        }

        public void PlacePiece(int row, int col, Piece pieceToPlace)
        {
            _adapter.MakeMove(row, col, pieceToPlace.Value);
        }
    }
}
