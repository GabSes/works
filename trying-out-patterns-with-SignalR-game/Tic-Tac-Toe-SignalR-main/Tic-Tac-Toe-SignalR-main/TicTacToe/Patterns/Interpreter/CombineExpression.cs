namespace TicTacToe.Patterns.Interpreter
{
    public class CombineExpression : Expression
    {
        public CombineExpression()
        {
        }
        public override string Interpret(Context context)
        {
            var split = context.Sentence.Split(" + ");
            string combined = "";

            foreach (var item in split)
            {
                combined += item;
            }

            return combined;
        }
    }
}
