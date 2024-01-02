using TicTacToe.GameObjects;
using TicTacToe.Interfaces;
using TicTacToe.Models.Builder;

namespace TicTacToe.Models;
public class BoardCreator : ICreator
{
    /// <summary>
    /// create specific board
    /// </summary>
    /// <param name="type">dimensions for the board</param>
    /// <returns></returns>
    public ITicTacToeBoard FactoryMethod(int type)
    {
        if(type == 3)
        {
            return new Board3();
        }
        else if (type == 4)
        {
            return new Board4();
        }
        else if (type == 5)
        {
            IBoardBuilder builder = new Board5Builder();
            return builder.Build();
        }
        else if (type == 6)
        {
            IBoardBuilder builder = new Board6Builder();
            return builder.Build();
        }
        else if (type == 9)
        {
            Proxy[,] megaBoard = new Proxy[9, 9];
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    megaBoard[i, j] = new Proxy(); // or initialize it with some default value if required
                }
            }
            return new MegaBoardAdapter(megaBoard);
        }
        else
        {
            return null; // wanted type is not implemented
        }
    }
}