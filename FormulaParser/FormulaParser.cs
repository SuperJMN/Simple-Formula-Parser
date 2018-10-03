using Superpower;

namespace FormulaParser
{
    public class FormulaParser
    {
        private readonly Tokenizer<FormulaToken> tokenizer;

        public FormulaParser()
        {
            tokenizer = Tokenizer.Create();
        }

        public Expression Parse(string input)
        {            
            return Parsers.Expression.Parse(tokenizer.Tokenize(input));
        }
    }
}