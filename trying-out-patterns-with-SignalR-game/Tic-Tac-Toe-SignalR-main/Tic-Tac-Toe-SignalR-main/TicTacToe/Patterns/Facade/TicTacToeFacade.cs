using TicTacToe.GameObjects;
using TicTacToe.Hubs;
using TicTacToe.Interfaces;
using TicTacToe.Models;
using TicTacToe.Models.Builder;

namespace TicTacToe.Patterns.Facade
{
    public class TicTacToeFacade
    {
        private GameState GameState;
        private BoardCreator BoardCreator;
        private IPrototype<Game> Prototype;
        public TicTacToeFacade(GameState gameState, BoardCreator boardCreator, IPrototype<Game> prototype)
        {
            this.GameState = gameState;
            this.BoardCreator = boardCreator;
            this.Prototype = prototype;
        }

        /// <summary>
        /// TicTacToe Facade method that gets game that player ir playing
        /// </summary>
        /// <param name="player">player of the game</param>
        /// <returns>Game</returns>
        public Game GetGame(Player player)
        {
            return this.GameState.GetGame(player);
        }

        /// <summary>
        /// TicTacToe Facade method that builds board
        /// </summary>
        /// <param name="type">size of the board</param>
        /// <returns>Board</returns>
        public ITicTacToeBoard BuildBoard(int type)
        {
            return BoardCreator.FactoryMethod(type);
        }

        /// <summary>
        /// TicTacToe Facade method that gets game deep and shallow copies
        /// </summary>
        /// <returns>Deep copy, Shallow copy</returns>
        public (Game, Game) DeepAndShallowCopies()
        {
            return (Prototype.DeepCopy(), Prototype.ShallowCopy());
        }
    }
}
