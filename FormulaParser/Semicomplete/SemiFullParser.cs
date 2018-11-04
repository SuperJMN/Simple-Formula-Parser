using Superpower;

namespace FormulaParser.Semicomplete
{
    public class SemiFullParser
    {
        private readonly Tokenizer<FormulaToken> tokenizer;

        public SemiFullParser()
        {
            tokenizer = Tokenizer.Create();
        }

        public Expression Parse(string input)
        {
            var tokenList = tokenizer.Tokenize(input);
            return SemiFullParserDefinitions.Parser.Parse(tokenList);
        }
    }
}