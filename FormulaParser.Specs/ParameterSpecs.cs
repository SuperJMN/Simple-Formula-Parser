using DeepEqual.Syntax;
using FormulaParser.Semicomplete;
using Superpower;
using Xunit;

namespace FormulaParser.Specs
{
    public class ParameterSpecs
    {
        [Fact]
        public void Identifier()
        {
            AssertParse("A", new IdentifierNode("A"));
        }

        [Fact]
        public void Constant()
        {
            AssertParse("1", new ConstantNode(1));
        }

        [Fact]
        public void Call()
        {
            AssertParse("AVG(A)", new Call("AVG", new IdentifierNode("A")));
        }

        private static void AssertParse(string input, Expression expectation)
        {
            var source = input;
            
            var expr = SemiFullParserDefinitions.Parameter.Parse(Tokenizer.Create().Tokenize(source));
            var expected = expectation;

            expr.ShouldDeepEqual(expected);
        }
    }


}