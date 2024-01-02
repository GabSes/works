
using TicTacToe.Interfaces;
using TicTacToe.Controllers;
using TicTacToe.GameObjects;
using TicTacToe.Models.DecoratorPattern;
using TicTacToe.Models.Flyweight;

namespace TicTacToe.Models
{
    public class Player2Factory : GameFactory
    {
        public Player2Factory(Mediator Hub) : base(Hub)
        {
            hub = Hub;
        }

        public override Obstacle CreateObstacle()
        {
            return new Obstacle("B");
        }

        public override Piece CreatePiece(Player player)
        {
            return PieceFactory.GetPiece("O");
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
