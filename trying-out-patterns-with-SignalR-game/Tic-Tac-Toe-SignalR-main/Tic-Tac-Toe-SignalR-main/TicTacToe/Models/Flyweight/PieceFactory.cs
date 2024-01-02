using TicTacToe.GameObjects;

namespace TicTacToe.Models.Flyweight
{
    public static class PieceFactory
    {
        private static readonly Dictionary<string, Piece> pieces = new Dictionary<string, Piece>();

        public static Piece GetPiece(string pieceType)
        {
            if (!pieces.ContainsKey(pieceType))
            {
                pieces[pieceType] = new Piece(pieceType);
            }
            return pieces[pieceType];
        }
    }
}
