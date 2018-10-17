using DeepEqual.Syntax;
using FormulaParser.Funcs;
using Xunit;

namespace FormulaParser.Specs
{
    public class SimpleFuncParserSpecs
    {
        [Fact]
        public void Test()
        {
            AssertParse("SUM(1;3)", new Call("SUM", new ConstantNode(1), new ConstantNode(3)));
        }

        private static void AssertParse(string input, Expression expectation)
        {
            var source = input;
            var parser = new SimpleFuncParser();
            var expr = parser.Parse(source);
            var expected = expectation;

            expr.ShouldDeepEqual(expected);
        }
    }
}