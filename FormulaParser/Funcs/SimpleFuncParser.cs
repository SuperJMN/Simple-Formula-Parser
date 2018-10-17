using Superpower;

namespace FormulaParser.Funcs
{
    public class SimpleFuncParser
    {
        private readonly Tokenizer<FormulaToken> tokenizer;

        public SimpleFuncParser()
        {
            tokenizer = Tokenizer.Create();
        }

        public Expression Parse(string input)
        {            
            return SimpleFuncParserDefinitions.Root.Parse(tokenizer.Tokenize(input));
        }
    }
}