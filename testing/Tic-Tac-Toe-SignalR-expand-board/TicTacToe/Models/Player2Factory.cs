using TicTacToe.GameObjects;

namespace TicTacToe.Models
{
    public class Player2Factory : GameFactory
    {
        public override Obstacle CreateObstacle()
        {
            return new Obstacle("B");
        }

        public override Piece CreatePiece(Player player)
        {
            return new Piece("O");
        }
    }
}
