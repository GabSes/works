using TicTacToe.GameObjects;

namespace TicTacToe.Models
{
    public class Subject
    {
        public List<Obstacle> observers;

        /// <summary>
        /// constructor
        /// </summary>
        public Subject()
        {
            observers = new List<Obstacle>();
        }


        /// <summary>
        /// add obstacle to a game instace
        /// </summary>
        /// <param name="unit">specific obstacle to be added</param>
        public void Attach(Obstacle unit)
        {
            observers.Add(unit);
        }

        /// <summary>
        /// remove obstacle from game instance
        /// </summary>
        /// <param name="unit">specific obstacle to be removed</param>
        public void Detach(Obstacle unit)
        {
            observers.Remove(unit);
        }

        /// <summary>
        /// regulate game instance obstacle activity
        /// </summary>
        /// <param name="change">change to obstacle activity</param>
        public void Notify(bool change)
        {
            for(int i = 0; i < observers.Count; i++)
            {
                observers[i].Update(change);
            }
        }
    }
}