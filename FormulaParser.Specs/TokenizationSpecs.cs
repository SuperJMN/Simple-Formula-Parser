using System;
using System.Linq;
using Superpower.Model;
using Xunit;

namespace FormulaParser.Specs
{
    public class TokenizationSpecs
    {
        [Fact]
        public void Simple()
        {
            var source = "3+4";
            var sut = Tokenizer.Create();
            var tokens = sut.Tokenize(source);

            Assert.Equal(new[] {FormulaToken.Number, FormulaToken.Plus, FormulaToken.Number},
                tokens.Select(x => x.Kind));
        }
    }
}
