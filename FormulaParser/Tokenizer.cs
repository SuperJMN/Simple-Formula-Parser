using Superpower;
using Superpower.Parsers;
using Superpower.Tokenizers;

namespace FormulaParser
{
    public static class Tokenizer
    {
        public static Tokenizer<FormulaToken> Create()
        {
            var stringParser = Span.Regex("[\\w\\s]*").Between(Character.EqualTo('"'), Character.EqualTo('"'));

            var tokenizer = new TokenizerBuilder<FormulaToken>()
                .Ignore(Span.WhiteSpace)
                .Match(Character.EqualTo('-'), FormulaToken.Minus)
                .Match(Character.EqualTo('+'), FormulaToken.Plus)
                .Match(Character.EqualTo('*'), FormulaToken.Asterisk)
                .Match(Character.EqualTo('/'), FormulaToken.Slash)
                .Match(Character.EqualTo(','), FormulaToken.Comma)
                .Match(Character.EqualTo('('), FormulaToken.LeftParenthesis)
                .Match(Character.EqualTo(')'), FormulaToken.RightParenthesis)
                .Match(Span.Regex(@"\d*"), FormulaToken.Number, true)
                .Match(Span.Regex(@"\w[\w\d]*"), FormulaToken.Identifier, true)
                .Build();

            return tokenizer;
        }
    }
}