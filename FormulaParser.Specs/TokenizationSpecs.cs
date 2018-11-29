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

        [Fact]
        public void Formula1()
        {
            var source = "SUMA( Formula REPSOL)";
            var sut = Tokenizer.Create();
            var tokens = sut.Tokenize(source);

            Assert.Equal(new[] {FormulaToken.Identifier,  FormulaToken.LeftParenthesis, FormulaToken.Identifier, FormulaToken.RightParenthesis },
                tokens.Select(x => x.Kind));
        }

        [Fact]
        public void Logic()
        {
            var source = "5 > 4";
            var sut = Tokenizer.Create();
            var tokens = sut.Tokenize(source);

            Assert.Equal(new[] {FormulaToken.Number,  FormulaToken.Greater, FormulaToken.Number },
                tokens.Select(x => x.Kind));
        }

        [Fact]
        public void DecimalNumber()
        {
            var source = "0.5";
            var sut = Tokenizer.Create();
            var tokens = sut.Tokenize(source);

            Assert.Equal(new[] {FormulaToken.Number },
                tokens.Select(x => x.Kind));
        }

        [Fact]
        public void Formula2()
        {
            var source = "TWOFORMULAS(Consumo de gas; ME_USO_1.09 +50)";
            var sut = Tokenizer.Create();
            var tokens = sut.Tokenize(source);

            Assert.Equal(new[] {FormulaToken.Identifier,  FormulaToken.LeftParenthesis, 

                    FormulaToken.Identifier, 
                    FormulaToken.Semicolon,
                    FormulaToken.Identifier, 
                    FormulaToken.Plus,
                    FormulaToken.Number,                    
                    FormulaToken.RightParenthesis,
                },
                tokens.Select(x => x.Kind));
        }
    }
}
