using System;

namespace FormulaParser
{
    public enum FormulaToken
    {
        Text,
        Minus,
        LeftParenthesis,
        RightParenthesis,
        Asterisk,
        Slash,
        Plus,
        Number,
        Identifier,
        Comma
    }
}
