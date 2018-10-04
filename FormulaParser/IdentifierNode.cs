namespace FormulaParser
{
    public class IdentifierNode : Expression
    {
        public string Identifier { get; }

        public IdentifierNode(string identifier)
        {
            Identifier = identifier;
        }
    }
}