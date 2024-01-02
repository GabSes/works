using TicTacToe.GameObjects;

namespace TicTacToe.Models;


public class BoardCreator
{

    /// <summary>
    /// create specific board
    /// </summary>
    /// <param name="type">dimensions for the board</param>
    /// <returns></returns>
    public static Board factoryMethod(int type)
    {
        if(type == 3)
        {
            return new Board3();
        }
        else if (type == 4)
        {
            return new Board4();
        }
        else
        {
            return null; // wanted type is not implemented
        }
    }
}