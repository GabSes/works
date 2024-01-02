namespace TicTacToe.Patterns.Interpreter
{
    public class SubtractExpression : Expression
    {
        public SubtractExpression() { }
        public override string Interpret(Context context)
        {
            var split = context.Sentence.Split(" - ");

            for(int i = 0; i < split.Length-1; i++)
            {
                if (split[i].Equals(split[i + 1]))
                    split[i] = split[i + 1] = "";
            }

            string total = "";
            foreach(var item in split)
            {
                total += item;
            }

            return total;
        }
    }
}
