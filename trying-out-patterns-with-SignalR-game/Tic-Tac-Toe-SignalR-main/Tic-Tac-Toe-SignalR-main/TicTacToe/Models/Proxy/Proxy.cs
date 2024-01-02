using TicTacToe.GameObjects;
using TicTacToe.Interfaces;

public class Proxy: ISubject
{
    private ISubject realSubject {get; set;}

    public Proxy()
    {
        realSubject = new Cell();
    }
    public Proxy(ISubject c)
    {
        realSubject = c;
    }

    public string requestValue()
    {
        return realSubject.requestValue();
    }

    public void requestUpdate(string value)
    {
        realSubject.requestUpdate(value);
    }
}