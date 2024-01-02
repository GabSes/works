using System.Data;
using TicTacToe.Interfaces;
using TicTacToe.Models;

namespace TicTacToe.GameObjects
{
    public class Obstacle : Cell, IObserver, IObstacle
    {

        public GameSubject instance { get; set; } // game instance

        public bool Active { get; private set; } // state if obstacle is active or not


        /// <summary>
        /// check if game is still ongoing
        /// </summary>
        public bool observerState
        {
            get
            { // game hasn't ended?
                return instance.getState();
            }
        }


        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="value">obstacle type</param>
        public Obstacle(string value) : base(value)
        {

            Set(value);
            Active = true;
        }


        /// <summary>
        /// get cell type
        /// </summary>
        /// <returns>cell type as string</returns>
        public string getStatus()
        {
            return "obstacle";
        }

        /// <summary>
        /// return obstacle type
        /// </summary>
        /// <returns>obstacle type</returns>
        public override string ToString()
        {
            return Value;
        }


        /// <summary>
        /// change activity of obstacle
        /// </summary>
        /// <param name="change">activity of obstacle</param>
        public void Update()
        {
            Active = observerState;
        }

        public string Block()
        {
            return "I Block";
        }
    }
}
