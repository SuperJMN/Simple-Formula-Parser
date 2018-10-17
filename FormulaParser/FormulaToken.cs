using System;

namespace FormulaParser
{
    public enum FormulaToken
    {
        Minus,
        LeftParenthesis,
        RightParenthesis,
        Asterisk,
        Slash,
        Plus,
        Number,
        Identifier,
        Comma,
        Semicolon
    }
}
