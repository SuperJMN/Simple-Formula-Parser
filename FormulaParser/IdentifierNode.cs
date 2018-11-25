namespace FormulaParser
{
    public class IdentifierNode : Expression
    {
        public string Identifier { get; }

        public IdentifierNode(string identifier)
        {
            Identifier = identifier;
        }

        public override void Accept(IExpressionVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}