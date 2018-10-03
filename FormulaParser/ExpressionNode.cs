using System.Linq;

namespace FormulaParser
{
    public class ExpressionNode : Expression
    {
        public Operator Operator { get; }
        public Expression[] Operands { get; }

        public ExpressionNode(Operator op, params Expression[] operands)
        {
            Operator = op;
            Operands = operands;
        }

        public ExpressionNode(Operator op, params int[] operands)
        {
            Operator = op;
            Operands = operands.Select(x => (ConstantNode)x).Cast<Expression>().ToArray();
        }


        public ExpressionNode(Operator op, params decimal[] operands)
        {
            Operator = op;
            Operands = operands.Select(x => (ConstantNode)x).Cast<Expression>().ToArray();
        }

        public ExpressionNode(Operator op, params double[] operands)
        {
            Operator = op;
            Operands = operands.Select(x => (ConstantNode)x).Cast<Expression>().ToArray();
        }
    }
}