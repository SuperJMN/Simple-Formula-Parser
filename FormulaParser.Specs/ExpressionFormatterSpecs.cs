using FormulaParser.Expressions;
using Xunit;

namespace FormulaParser.Specs
{
    public class ExpressionFormatterSpecs
    {
        [Theory]
        [InlineData("3+4/5", "3+4/5")]
        [InlineData("1+2+3", "1+2+3")]
        [InlineData("(3+4)/5", "(3+4)/5")]
        [InlineData("(3+4-2)/5+1", "(3+4-2)/5+1")]
        [InlineData("(3+4-2)/(5+1)", "(3+4-2)/(5+1)")]
        public void SimpleTest(string input, string output)
        {
            AssertParse(input, output);
        }

        private static void AssertParse(string input, string expected)
        {
            var parser = new SimpleExpressionParser();
            var ast = parser.Parse(input);

            var sut = new ExpressionFormatter();
            ast.Accept(sut);
            Assert.Equal(expected, sut.GetResult());
        }
    }
}