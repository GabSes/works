using TicTacToe.GameObjects;

namespace TicTacToe.Models
{
    public class GameSubject :Subject
    {
        private bool state; //state of the game instance activity

        /// <summary>
        /// constructor
        /// </summary>
        public GameSubject() : base()
        {
            observers = new List<Obstacle>();
            state = true; 
        }


        /// <summary>
        /// get state if game is still active
        /// </summary>
        /// <returns>state if game is still active</returns>
        public bool getState()
        {
            return state;
        }

        /// <summary>
        /// set state to know if game is active
        /// </summary>
        /// <param name="value">state if game is still active</param>
        public void setState(bool value)
        {
            state = value;
        }
    }
}