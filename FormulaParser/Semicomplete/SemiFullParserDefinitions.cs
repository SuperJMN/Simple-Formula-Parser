using Superpower;
using Superpower.Parsers;

namespace FormulaParser.Semicomplete
{
    public static class SemiFullParserDefinitions
    {
        private static readonly TokenListParser<FormulaToken, string> Identifier =
            Token.EqualTo(FormulaToken.Identifier).Select(token => token.ToStringValue());

        private static readonly TokenListParser<FormulaToken, Operator> Add = Token.EqualTo(FormulaToken.Plus).Value(Operator.Add);
        private static readonly TokenListParser<FormulaToken, Operator> Subtract = Token.EqualTo(FormulaToken.Minus).Value(Operator.Subtract);
        private static readonly TokenListParser<FormulaToken, Operator> Multiply = Token.EqualTo(FormulaToken.Asterisk).Value(Operator.Multiply);
        private static readonly TokenListParser<FormulaToken, Operator> Divide = Token.EqualTo(FormulaToken.Slash).Value(Operator.Divide);

        private static readonly TokenListParser<FormulaToken, Expression> Number = Token.EqualTo(FormulaToken.Number).Apply(Numerics.DecimalDecimal)
            .Select(d => (Expression)new ConstantNode(d));

        private static readonly TokenListParser<FormulaToken, Expression> IdentifierNode = Identifier.Select(s => (Expression)new IdentifierNode(s));

        private static readonly TokenListParser<FormulaToken, Expression> Literal =
            Number.Or(IdentifierNode);

        private static readonly TokenListParser<FormulaToken, Expression> FunctionCall =
            from name in Identifier
            from parameters in Parameters.BetweenParenthesis()
            select (Expression)new Call(name, parameters);

        private static readonly TokenListParser<FormulaToken, Expression> Item = Literal;

        private static readonly TokenListParser<FormulaToken, Expression> Factor =
            Parse.Ref(() => Expression).BetweenParenthesis()
                .Or(Item);

        private static readonly TokenListParser<FormulaToken, Expression> Operand = Factor.Named("expression");

        private static readonly TokenListParser<FormulaToken, Expression> Term = Parse.Chain(Multiply.Or(Divide), Operand, MakeBinary);

        private static readonly TokenListParser<FormulaToken, Expression> Comparand = Parse.Chain(Add.Or(Subtract), Term, MakeBinary);

        public static readonly TokenListParser<FormulaToken, Expression> Expression = Comparand;

        public static readonly TokenListParser<FormulaToken, Expression> Parameter = FunctionCall.Try().Or(Expression);

        private static readonly TokenListParser<FormulaToken, Expression[]> Parameters =
            Parameter.ManyDelimitedBy(Token.EqualTo(FormulaToken.Semicolon));

        public static readonly TokenListParser<FormulaToken, Expression> Parser = FunctionCall.AtEnd();            

        private static Expression MakeBinary(Operator operatorName, Expression leftOperand, Expression rightOperand)
        {
            return new OperatorNode(operatorName, leftOperand, rightOperand);
        }
    }
}