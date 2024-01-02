using TicTacToe.Interfaces;
namespace TicTacToe.Models.DecoratorPattern
{
    public class ConcreteDecoratorO : Decorator
    {
        public ConcreteDecoratorO(Component c) : base(c)
        {

        }

        public override string operation()
        {
            return base.wrappee.operation();
        }

        public override string specificOperation()
        {
            return "green";
        }

    }
}