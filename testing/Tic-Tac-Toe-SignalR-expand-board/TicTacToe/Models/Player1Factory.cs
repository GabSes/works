using TicTacToe.GameObjects;

namespace TicTacToe.Models
{
    public class Player1Factory : GameFactory
    {
        public override Obstacle CreateObstacle()
        {
            return new Obstacle("W");
        }

        public override Piece CreatePiece(Player player)
        {
            return new Piece("X");
        }
    }
}
