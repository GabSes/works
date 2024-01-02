namespace TicTacToe.GameObjects
{
    public class Cell
    {
        public string Value { get; private set; }

        /// <summary>
        /// constructor
        /// </summary>
        public Cell()
        {
            Value = "";
        }

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="value"></param>
        public Cell(string value)
        {
            Value = value;
        }

        /// <summary>
        /// sets value outside contructor
        /// </summary>
        /// <param name="value">cell value</param>
        public void Set(string value)
        {
            Value = value;
        }


        /// <summary>
        /// get status if cell is itself or it's child classes
        /// </summary>
        /// <returns>status that it's Cell class</returns>
        public string getStatus()
        {
            return "general";
        }

        /// <summary>
        /// get cell value
        /// </summary>
        /// <returns>cell value</returns>
        public override string ToString()
        {
            return Value;
        }
    }
}