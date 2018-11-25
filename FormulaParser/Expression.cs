namespace FormulaParser
{
    public abstract class Expression : IExpression
    {
        public abstract void Accept(IExpressionVisitor visitor);
    }

    public interface IExpressionVisitor
    {
        void Visit(IdentifierNode identifierNode);
        void Visit(OperatorNode node);
        void Visit(Call identifierNode);
        void Visit(ConstantNode identifierNode);
    }
}