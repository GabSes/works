using TicTacToe.Controllers;
using TicTacToe.GameObjects;
using TicTacToe.Models.DecoratorPattern;

namespace TicTacToe.Interfaces
{
    public interface ITicTacToeBoard
    {
        bool GameEnded { get; }
        void PlacePiece(int row, int col, Piece pieceToPlace);

        Proxy[,] Pieces { get; }
        bool AreSpacesLeft { get; }
        int BoardSize {  get; }
    }
}
