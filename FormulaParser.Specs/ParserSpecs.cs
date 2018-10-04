using DeepEqual.Syntax;
using Xunit;

namespace FormulaParser.Specs
{
    public class ParserSpecs
    {
        [Fact]
        public void Simple()
        {
            AssertParse("(3+4)*12", new OperatorNode(Operator.Multiply, new OperatorNode(Operator.Add, 3, 4), (ConstantNode) 12));
        }

        [Fact]
        public void SimpleWithOtherPrecedence()
        {
            AssertParse("3+4*12", new OperatorNode(Operator.Add, (ConstantNode)3, new OperatorNode(Operator.Multiply, 4, 12)));
        }

        [Fact]
        public void Call()
        {
            AssertParse("SWAP(3, 5)", new Call("SWAP", (ConstantNode)3, (ConstantNode)5));
        }

        [Fact]
        public void Symbols()
        {
            AssertParse("7*INDEX", new OperatorNode(Operator.Multiply, (ConstantNode)7, new IdentifierNode("INDEX")));
        }

        [Fact]
        public void NestedCall()
        {
            AssertParse("SWAP(3, AVG(3,4,5,6))", new Call("SWAP", (ConstantNode)3, new Call("AVG", (ConstantNode)3, (ConstantNode)4, (ConstantNode)5, (ConstantNode)6)));
        }

        private static void AssertParse(string input, Expression expectation)
        {
            var source = input;
            var parser = new FormulaParser();
            var expr = parser.Parse(source);
            var expected = expectation;

            expr.ShouldDeepEqual(expected);
        }
    }
}