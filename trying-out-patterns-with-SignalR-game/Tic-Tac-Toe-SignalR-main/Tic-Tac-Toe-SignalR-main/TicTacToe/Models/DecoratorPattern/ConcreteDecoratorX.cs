using TicTacToe.Interfaces;
namespace TicTacToe.Models.DecoratorPattern
{
    public class ConcreteDecoratorX : Decorator
    {
        public ConcreteDecoratorX(Component c) : base(c)
        {
            
        }

        public override string operation()
        {
            return base.wrappee.operation();
        }

        public override string specificOperation()
        {
            return "red";
        }

    }
}

