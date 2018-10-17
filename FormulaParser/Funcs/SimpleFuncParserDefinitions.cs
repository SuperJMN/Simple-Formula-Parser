using Superpower;
using Superpower.Parsers;

namespace FormulaParser.Funcs
{
    public static class SimpleFuncParserDefinitions
    {
        private static readonly TokenListParser<FormulaToken, string> Identifier =
            Token.EqualTo(FormulaToken.Identifier).Select(token => token.ToStringValue());

        private static readonly TokenListParser<FormulaToken, Expression> Number = Token.EqualTo(FormulaToken.Number).Apply(Numerics.DecimalDecimal)
            .Select(d => (Expression)new ConstantNode(d));

        private static readonly TokenListParser<FormulaToken, Expression> IdentifierNode = Identifier.Select(s => (Expression)new IdentifierNode(s));

        private static readonly TokenListParser<FormulaToken, Expression> Literal =
            Number.Or(IdentifierNode);

        private static readonly TokenListParser<FormulaToken, Expression> FunctionCall =
            from name in Identifier
            from parameters in Parameters.BetweenParenthesis()
            select (Expression)new Call(name, parameters);

        private static readonly TokenListParser<FormulaToken, Expression> Item = FunctionCall.Try().Or(Literal);

        public static readonly TokenListParser<FormulaToken, Expression> Root = FunctionCall;

        private static readonly TokenListParser<FormulaToken, Expression[]> Parameters =
            Item.ManyDelimitedBy(Token.EqualTo(FormulaToken.Semicolon));        
    }
}