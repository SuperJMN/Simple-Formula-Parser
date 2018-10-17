﻿using Superpower;

namespace FormulaParser.Expressions
{
    public class SimpleExpressionParser
    {
        private readonly Tokenizer<FormulaToken> tokenizer;

        public SimpleExpressionParser()
        {
            tokenizer = Tokenizer.Create();
        }

        public Expression Parse(string input)
        {            
            return SimpleExpressionParserDefinitions.Expression.Parse(tokenizer.Tokenize(input));
        }
    }
}