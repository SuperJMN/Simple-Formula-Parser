using Superpower;
using Superpower.Parsers;

namespace FormulaParser
{
    public static class ParserMixin
    {
        public static TokenListParser<FormulaToken, T> BetweenParenthesis<T>(this TokenListParser<FormulaToken, T> self)
        {
            return self.Between(Token.EqualTo(FormulaToken.LeftParenthesis), Token.EqualTo(FormulaToken.RightParenthesis));
        }     
    }
}