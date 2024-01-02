
using TicTacToe.Controllers;
using TicTacToe.GameObjects;
using TicTacToe.Interfaces;
using TicTacToe.Models.Flyweight;
using TicTacToe.Models.Flyweight;

namespace TicTacToe.Models
{
    public class Player1Factory : GameFactory
    {
        public Player1Factory(Mediator Hub) : base(Hub)
        {
            hub = Hub;
        }


        public override Obstacle CreateObstacle()
        {
            return new Obstacle("W");
        }

        public override Piece CreatePiece(Player player)
        {
            return PieceFactory.GetPiece("X");
        }

        public override IComment CreateComment()
        {
            return new Comment("#");
        }

        public override void SendMessage()
        {
            throw new NotImplementedException();
        }

    }
}

