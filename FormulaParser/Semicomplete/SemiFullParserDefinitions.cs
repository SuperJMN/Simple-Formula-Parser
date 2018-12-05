using Superpower;
using Superpower.Parsers;

namespace FormulaParser.Semicomplete
{
    public static class SemiFullParserDefinitions
    {
        private static readonly TokenListParser<FormulaToken, string> Identifier =
            Token.EqualTo(FormulaToken.Identifier).Select(token => token.ToStringValue());

        private static readonly TokenListParser<FormulaToken, Operator> Add = Token.EqualTo(FormulaToken.Plus).Value(Operators.Add);
        private static readonly TokenListParser<FormulaToken, Operator> Subtract = Token.EqualTo(FormulaToken.Minus).Value(Operators.Subtract);
        private static readonly TokenListParser<FormulaToken, Operator> Multiply = Token.EqualTo(FormulaToken.Asterisk).Value(Operators.Multiply);
        private static readonly TokenListParser<FormulaToken, Operator> Divide = Token.EqualTo(FormulaToken.Slash).Value(Operators.Divide);

        private static readonly TokenListParser<FormulaToken, Operator> Eq = Token.EqualTo(FormulaToken.Equal).Value(Operators.Eq);
        private static readonly TokenListParser<FormulaToken, Operator> Neq = Token.EqualTo(FormulaToken.NotEqual).Value(Operators.Neq);
        public static readonly TokenListParser<FormulaToken, Operator> Gt = Token.EqualTo(FormulaToken.Greater).Value(Operators.Gt);
        private static readonly TokenListParser<FormulaToken, Operator> Lt = Token.EqualTo(FormulaToken.Less).Value(Operators.Lt);
        private static readonly TokenListParser<FormulaToken, Operator> LtEq = Token.EqualTo(FormulaToken.LessEqual).Value(Operators.LtEq);
        private static readonly TokenListParser<FormulaToken, Operator> GtEq = Token.EqualTo(FormulaToken.GreaterEqual).Value(Operators.GtEq);

        private static readonly TokenListParser<FormulaToken, Expression> Number = Token.EqualTo(FormulaToken.Number).Apply(Numerics.DecimalDecimal)
            .Select(d => (Expression)new ConstantNode(d));

        private static readonly TokenListParser<FormulaToken, Expression> NegativeNumber =
            from minus in Subtract
            from number in Token.EqualTo(FormulaToken.Number).Apply(Numerics.DecimalDecimal)
            select (Expression) new ConstantNode(-number);

        private static readonly TokenListParser<FormulaToken, Expression> IdentifierNode = Identifier.Select(s => (Expression)new IdentifierNode(s.Trim()));

        private static readonly TokenListParser<FormulaToken, Expression> Literal =
            NegativeNumber.Or(Number).Or(IdentifierNode);

        private static readonly TokenListParser<FormulaToken, Expression> FunctionCall =
            from name in Identifier
            from parameters in Parameters.BetweenParenthesis()
            select (Expression)new Call(name, parameters);

        private static readonly TokenListParser<FormulaToken, Expression> Item = FunctionCall.Try().Or(Literal);

        private static readonly TokenListParser<FormulaToken, Expression> Factor =
            Parse.Ref(() => Expression).BetweenParenthesis()
                .Or(Item);

        private static readonly TokenListParser<FormulaToken, Expression> Operand = Factor.Named("expression");

        private static readonly TokenListParser<FormulaToken, Expression> Term = Parse.Chain(Multiply.Or(Divide), Operand, MakeBinary);

        private static readonly TokenListParser<FormulaToken, Expression> Comparand = Parse.Chain(Add.Or(Subtract), Term, MakeBinary);

        private static readonly TokenListParser<FormulaToken, Expression> Comparison = Parse.Chain(Eq.Or(Neq).Or(Gt).Or(Lt).Or(LtEq).Or(GtEq), Comparand, MakeBinary);

        public static readonly TokenListParser<FormulaToken, Expression> Expression = Comparison;

        public static readonly TokenListParser<FormulaToken, Expression> Parameter = Expression;

        private static readonly TokenListParser<FormulaToken, Expression[]> Parameters =
            Parameter.ManyDelimitedBy(Token.EqualTo(FormulaToken.Semicolon));

        public static readonly TokenListParser<FormulaToken, Expression> Parser = Parameter.AtEnd();            

        private static Expression MakeBinary(Operator operatorName, Expression leftOperand, Expression rightOperand)
        {
            return new OperatorNode(operatorName, leftOperand, rightOperand);
        }
    }
}