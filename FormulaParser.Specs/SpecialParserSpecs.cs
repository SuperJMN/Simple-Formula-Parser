using DeepEqual.Syntax;
using FormulaParser.Complete;
using FormulaParser.Semicomplete;
using Superpower;
using Xunit;

namespace FormulaParser.Specs
{
    public class SpecialParserSpecs
    {
        [Fact]
        public void TermTest()
        {
            var tokenList = Tokenizer.Create().Tokenize("3+HOLA");
            var p = FullParserDefinitions.Expression.Parse(tokenList);
        }
        
        [Fact]
        public void Boolean()
        {
            var tokenList = Tokenizer.Create().Tokenize("4>3");
            var p = SemiFullParserDefinitions.Expression.Parse(tokenList);
        }
    }
}