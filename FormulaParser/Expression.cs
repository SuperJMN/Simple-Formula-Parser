namespace FormulaParser
{
    public abstract class Expression : IExpression
    {
        public abstract void Accept(IExpressionVisitor visitor);
    }

    public interface IExpressionVisitor
    {
        void Visit(IdentifierNode node);
        void Visit(OperatorNode node);
        void Visit(Call node);
        void Visit(ConstantNode node);
    }
}