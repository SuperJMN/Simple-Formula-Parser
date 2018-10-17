using Superpower;

namespace FormulaParser.Complete
{
    public class FullParser
    {
        private readonly Tokenizer<FormulaToken> tokenizer;

        public FullParser()
        {
            tokenizer = Tokenizer.Create();
        }

        public Expression Parse(string input)
        {            
            return FullParserDefinitions.Expression.Parse(tokenizer.Tokenize(input));
        }
    }
}