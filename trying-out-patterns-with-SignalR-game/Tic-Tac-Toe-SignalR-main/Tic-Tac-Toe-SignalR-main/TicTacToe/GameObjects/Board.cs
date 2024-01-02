using TicTacToe.Interfaces;
using TicTacToe.Models.DecoratorPattern;
using TicTacToe.Models.Flyweight;
using TicTacToe.Patterns.Composite;

namespace TicTacToe.GameObjects
{
    /// <summary>
    /// Represents a Tic-Tac-Toe board and where players have placed their pieces.
    /// </summary>
    public class Board : ITicTacToeBoard, IComponent
    {
        /// <summary>
        /// The number of pieces that have been placed on the board.
        /// </summary>
        private int totalPiecesPlaced { get; set; }
        /// <summary>
        /// Size of the board 3, 4, 5
        /// </summary>
        public int BoardSize { get; set; }
        /// <summary>
        /// Checks if game ended
        /// </summary>
        public virtual bool GameEnded => false;
        public Board()
        {
            // TODO: Make the dimensions of the board constants
            Pieces = new Proxy[BoardSize, BoardSize];
            Proxy cell = new Proxy();
            for (int i = 0; i < BoardSize; i++)
            {
                for (int j = 0; j < BoardSize; j++)
                {
                    Pieces[i, j] = cell;
                }
            }
        }

        /// <summary>
        /// Represents the pieces on the board.
        /// Must be publicly accessible to allow serialization.
        /// </summary>
        public Proxy[,] Pieces { get; private set; }

        protected void Set(int n)
        {
            BoardSize = n;
            Pieces = new Proxy[n, n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Pieces[i, j] = new Proxy();
                }
            }
        }

        /// <summary>
        /// Returns whether there are any positions left on the board.
        /// </summary>
        public bool AreSpacesLeft
        {
            get
            {
                return totalPiecesPlaced < Pieces.GetLength(0) * Pieces.GetLength(0);
            }
        }

        /// <summary>
        /// update a cell with wanted value
        /// </summary>
        /// <param name="row">cordinate 1</param>
        /// <param name="col">cordinate 2</param>
        /// <param name="pieceToPlace">value to be placed</param>
        public void PlacePiece(int row, int col, Piece pieceToPlace)
        {
            Pieces[row, col].requestUpdate(pieceToPlace.Value);
            totalPiecesPlaced++;
        }

        /// <summary>
        /// update a cell with wanted value
        /// </summary>
        /// <param name="row">cordinate 1</param>
        /// <param name="col">cordinate 2</param>
        /// <param name="pieceToPlace">value to be placed</param>
        public void PlacePiece(int row, int col, string pieceType)
        {
            Piece piece = PieceFactory.GetPiece(pieceType);
            Pieces[row, col].requestUpdate(piece.ToString());
            totalPiecesPlaced++;
        }

        /// <summary>
        /// get all Cell values as a single string
        /// </summary>
        /// <returns>Cell values as a single string</returns>
        public override string ToString()
        {
            List<string> piecesList = new List<string>();

            for (int i = 0; i < Pieces.GetLength(0); i++)
            {
                for (int j = 0; j < Pieces.GetLength(1); j++)
                {
                    piecesList.Add(Pieces[i, j].requestValue());
                }
            }

            return string.Join(", ", piecesList);
        }
        private IComponent[,] compositeCells;
        public void Display(int indentationLevel)
        {
            for (int i = 0; i < compositeCells.GetLength(0); i++)
            {
                for (int j = 0; j < compositeCells.GetLength(1); j++)
                {
                    compositeCells[i, j].Display(indentationLevel + 1);
                }
                Console.WriteLine();
            }
        }

        public string GetValue()
        {
            // Flatten the composite values into a single string
            List<string> compositeList = new List<string>();

            for (int i = 0; i < compositeCells.GetLength(0); i++)
            {
                for (int j = 0; j < compositeCells.GetLength(1); j++)
                {
                    compositeList.Add(compositeCells[i, j].GetValue());
                }
            }

            return string.Join(", ", compositeList);
        }

    }
}