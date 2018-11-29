﻿using System;
using DeepEqual.Syntax;
using FormulaParser.Semicomplete;
using Superpower;
using Xunit;

namespace FormulaParser.Specs
{
    public class SemiFullParserSpecs
    {
        [Fact]
        public void UniqueCallTest()
        {
            AssertParse("SUM(2;4)", new Call("SUM", new ConstantNode(2), new ConstantNode(4)));
        }

        [Fact]
        public void CallOfExpression()
        {
            AssertParse("SUM(3+4)", new Call("SUM", new OperatorNode(Operators.Add, new ConstantNode(3), new ConstantNode(4))));
        }

        [Fact]
        public void CallOfIdentifierNodes()
        {
            AssertParse("SUM(A;B)", new Call("SUM", new IdentifierNode("A"), new IdentifierNode("B")));
        }

        [Fact]
        public void SimpleNestedCall()
        {
            AssertParse("CALL(A;CALL(B))",
                new Call("CALL", new IdentifierNode("A"),
                    new Call("CALL", new IdentifierNode("B"))));                    
        }

        [Fact]
        public void NestedCall()
        {
            AssertParse("SUM(A;AVG(3+2;5))",
                new Call("SUM", new IdentifierNode("A"),
                    new Call("AVG", new OperatorNode(Operators.Add, new ConstantNode(3), new ConstantNode(2)), new ConstantNode(5))));
        }

        [Fact]
        public void ComplexNestedCalls()
        {
            var one = "AVG(a;b;3+4)";
            var two= $"SUM({one})";
            var three = $"SUM(AB;123+3)";

            Expression nodeTree = new Call("SUM", new IdentifierNode("AB"), new OperatorNode(Operators.Add, new ConstantNode(123), new ConstantNode(3)));
            Expression[] nodeOne = { new Call("AVG", new IdentifierNode("a"), new IdentifierNode("b"), new OperatorNode(Operators.Add, new ConstantNode(3), new ConstantNode(4)))};
            Expression[] nodeTwo = { new Call("SUM", nodeOne), };
            var root = new Call("SUM", nodeTree, new Call("AVG", nodeTwo));
            var result = $"SUM({three};AVG({two}))"; 
            AssertParse(result, root);
        }

        [Fact]
        public void MixedExpressionAndCallTest()
        {
            AssertThrows<ParseException>("SUM(3+4)+5");
        }

        [Fact]
        public void Expression()
        {
            AssertThrows<ParseException>("5+4/INDEX");
        }

        [Fact]
        public void OppositeMixedCallTest()
        {
            AssertThrows<ParseException>("5+SUM(1)");
        }

        [Fact]
        public void TwoFormulas()
        {
            Expression one = new IdentifierNode("Consumo de gas");
            Expression two = new OperatorNode(Operators.Add, new IdentifierNode("ME_USO_1.09"), new ConstantNode(50));
            AssertParse("TWOFORMULAS(Consumo de gas; ME_USO_1.09 +50)", new Call("TWOFORMULAS", one, two));
        }

        [Fact]
        public void Logic()
        {
            AssertParse("4 > 3", new OperatorNode(Operators.Gt, 4, 3));
        }

        private static void AssertThrows<TEx>(string source) where TEx: Exception
        {
            var parser = new SemiFullParser();
            Assert.Throws<TEx>(() =>
            {
                var expression = parser.Parse(source);
                return expression;
            });
        }

        private static void AssertParse(string input, Expression expectation)
        {
            var source = input;
            var parser = new SemiFullParser();
            var expr = parser.Parse(source);
            var expected = expectation;

            expr.ShouldDeepEqual(expected);
        }
    }
}
