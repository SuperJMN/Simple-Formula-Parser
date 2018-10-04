using System.Linq;

namespace FormulaParser
{
    public class OperatorNode : Expression
    {
        public Operator Operator { get; }
        public Expression[] Operands { get; }

        public OperatorNode(Operator op, params Expression[] operands)
        {
            Operator = op;
            Operands = operands;
        }

        public OperatorNode(Operator op, params int[] operands)
        {
            Operator = op;
            Operands = operands.Select(x => (ConstantNode)x).Cast<Expression>().ToArray();
        }


        public OperatorNode(Operator op, params decimal[] operands)
        {
            Operator = op;
            Operands = operands.Select(x => (ConstantNode)x).Cast<Expression>().ToArray();
        }

        public OperatorNode(Operator op, params double[] operands)
        {
            Operator = op;
            Operands = operands.Select(x => (ConstantNode)x).Cast<Expression>().ToArray();
        }
    }
}