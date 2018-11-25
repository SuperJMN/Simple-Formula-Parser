namespace FormulaParser
{
    public interface IExpression
    {
        void Accept(IExpressionVisitor visitor);
    }
}