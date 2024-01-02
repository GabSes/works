using TicTacToe.GameObjects;

namespace TicTacToe.Patterns.ForPrototype
{
    public class GamePrototype
    {
        public string OriginalPlayer1Room { get; set; }
        public string OriginalPlayer2Room { get; set; }
        /// <summary>
        /// Shallow copy of the game
        /// </summary>
        public Game GameShallowCopy { get; set; }
        /// <summary>
        /// Deep copy of the game
        /// </summary>
        public Game GameDeepCopy { get; set; }
        /// <summary>
        /// Original game object
        /// </summary>
        public Game GameOriginal { get; set; }
        public GamePrototype(Game original)
        {
            this.GameOriginal = original;
            this.OriginalPlayer1Room = original.Player1.PlayingRoomName;
            this.OriginalPlayer2Room = original.Player2.PlayingRoomName;

            this.GameShallowCopy = GameOriginal.ShallowCopy();
            this.GameDeepCopy = GameOriginal.DeepCopy();

            //change for shallow copy
            GameShallowCopy.Player1.PlayingRoomName = "Shallow Copy";

            //change for deep copy
            GameDeepCopy.Player2.PlayingRoomName = "Deep Copy";
        }
    }
}
