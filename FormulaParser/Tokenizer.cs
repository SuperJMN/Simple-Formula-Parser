using System.Text.RegularExpressions;
using Superpower;
using Superpower.Parsers;
using Superpower.Tokenizers;

namespace FormulaParser
{
    public static class Tokenizer
    {
        public static Tokenizer<FormulaToken> Create()
        {
            var tokenizer = new TokenizerBuilder<FormulaToken>()
                .Ignore(Span.WhiteSpace)
                .Match(Character.EqualTo('-'), FormulaToken.Minus)
                .Match(Character.EqualTo('+'), FormulaToken.Plus)
                .Match(Character.EqualTo('*'), FormulaToken.Asterisk)
                .Match(Character.EqualTo('/'), FormulaToken.Slash)
                .Match(Character.EqualTo(','), FormulaToken.Comma)
                .Match(Character.EqualTo('('), FormulaToken.LeftParenthesis)
                .Match(Character.EqualTo(')'), FormulaToken.RightParenthesis)
                .Match(Character.EqualTo(';'), FormulaToken.Semicolon)
                .Match(Span.Regex(@"^-?\d+(,\d+)*(\.\d+(e\d+)?)?"), FormulaToken.Number, true)
                .Match(Span.Regex(@"\w[\w\d\s\._áéíóúñÁÉÍÓÚÑ]*"), FormulaToken.Identifier, true)
                .Build();

            return tokenizer;
        }
    }
}