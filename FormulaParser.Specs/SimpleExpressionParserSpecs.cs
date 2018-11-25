using System;
using DeepEqual.Syntax;
using FormulaParser.Complete;
using FormulaParser.Expressions;
using Superpower;
using Xunit;

namespace FormulaParser.Specs
{
    public class SimpleExpressionParserSpecs
    {
        [Fact]
        public void Simple()
        {
            AssertParse("(3+4)*12", new OperatorNode(Operators.Multiply, new OperatorNode(Operators.Add, 3, 4), (ConstantNode) 12));
        }

        [Fact]
        public void SimpleWithOtherPrecedence()
        {
            AssertParse("3+4*12", new OperatorNode(Operators.Add, (ConstantNode)3, new OperatorNode(Operators.Multiply, 4, 12)));
        }

        [Fact]
        public void Call()
        {
            AssertThrows<ParseException>("SWAP(3;5)");
        }

        [Fact]
        public void Symbols()
        {
            AssertParse("7*INDEX", new OperatorNode(Operators.Multiply, (ConstantNode)7, new IdentifierNode("INDEX")));
        }

        [Fact]
        public void NestedCall()
        {
            AssertThrows<ParseException>("SWAP(3;AVG(3;4;5;6))");
        }

        private static void AssertParse(string input, Expression expectation)
        {
            var source = input;
            var parser = new SimpleExpressionParser();
            var expr = parser.Parse(source);
            var expected = expectation;

            expr.ShouldDeepEqual(expected);
        }

        private static void AssertThrows<TEx>(string source) where TEx: Exception
        {
            var parser = new SimpleExpressionParser();
            Assert.Throws<TEx>(() =>
            {
                var expression = parser.Parse(source);
                return expression;
            });
        }
    }
}