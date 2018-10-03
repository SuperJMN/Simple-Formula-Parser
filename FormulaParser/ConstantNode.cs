using System.Linq.Expressions;

namespace FormulaParser
{
    public class ConstantNode : Expression
    {
        public decimal Value { get; }

        public ConstantNode(decimal value)
        {
            Value = value;
        }

        public static implicit operator ConstantNode(int de)
        {
            return new ConstantNode(new decimal(de));
        }

        public static implicit operator ConstantNode(double de)
        {
            return new ConstantNode(new decimal(de));
        }

        public static implicit operator ConstantNode(decimal de)
        {
            return new ConstantNode(de);
        }      
    }
}