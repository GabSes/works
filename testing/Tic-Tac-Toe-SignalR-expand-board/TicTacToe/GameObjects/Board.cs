using TicTacToe.Interfaces;

namespace TicTacToe.GameObjects
{
    /// <summary>
    /// Represents a Tic-Tac-Toe board and where players have placed their pieces.
    /// </summary>
    public class Board
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
        public virtual bool GameEnded { get; }
        public Board()
        {
            // TODO: Make the dimensions of the board constants
            Pieces = new Cell[BoardSize, BoardSize];
            Cell cell = new Cell();
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
        public Cell[,] Pieces { get; private set; }

        protected void Set(int n)
        {
            BoardSize = n;
            Pieces = new Cell[n, n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Pieces[i, j] = new Cell();
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
        public void PlacePiece(int row, int col, string pieceToPlace)
        {
            Pieces[row, col].Set(pieceToPlace);
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
                    piecesList.Add(Pieces[i, j].Value);
                }
            }

            return string.Join(", ", piecesList);
        }
        public class BoardBuilder : IBoardBuilder
        {
            private Board board;

            public BoardBuilder()
            {
                board = new Board();
            }

            public IBoardBuilder SetDimensions(int dimensions)
            {
                board.Set(dimensions);
                return this;
            }

            public IBoardBuilder WithCustomConfigurations()
            {
                // Add any custom configurations here
                return this;
            }

            public Board Build()
            {
                return board;
            }
        }

    }
}