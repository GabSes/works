using TicTacToe.GameObjects;
using TicTacToe.Interfaces;

namespace TicTacToe.Models
{
    public class Subject
    {
        protected List<IObserver> observers;

        /// <summary>
        /// constructor
        /// </summary>
        public Subject()
        {
            observers = new List<IObserver>();
        }


        /// <summary>
        /// add obstacle to a game instace
        /// </summary>
        /// <param name="unit">specific obstacle to be added</param>
        public void Attach(IObserver unit)
        {
            observers.Add(unit);
        }

        /// <summary>
        /// remove obstacle from game instance
        /// </summary>
        /// <param name="unit">specific obstacle to be removed</param>
        public void Detach(IObserver unit)
        {
            observers.Remove(unit);
        }

        /// <summary>
        /// regulate game instance obstacle activity
        /// </summary>
        /// <param name="change">change to obstacle activity</param>
        public void Notify()
        {
            for(int i = 0; i < observers.Count; i++)
            {
                observers[i].Update();
            }
        }
    }
}