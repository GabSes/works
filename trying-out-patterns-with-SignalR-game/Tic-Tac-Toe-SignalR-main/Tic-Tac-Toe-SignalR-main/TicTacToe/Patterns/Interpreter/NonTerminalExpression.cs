namespace TicTacToe.Patterns.Interpreter
{
    public class NonTerminalExpression : Expression
    {
        private Expression expression1;
        private Expression expression2;

        public NonTerminalExpression(Expression expression1, Expression expression2)
        {
            this.expression1 = expression1;
            this.expression2 = expression2;
        }

        public override string Interpret(Context context)
        {
            return expression1.Interpret(context) + " | " + expression2.Interpret(context);
        }
    }
}
