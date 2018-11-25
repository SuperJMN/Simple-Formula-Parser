using System;
using System.Globalization;
using System.Text;

namespace FormulaParser
{
    public class ExpressionFormatter : IExpressionVisitor
    {
        readonly StringBuilder strBuilder = new StringBuilder();

        public void Visit(Call call)
        {
            strBuilder.Append(call.Name);
            strBuilder.Append("(");

            int t = 1;
            foreach (var callParameter in call.Parameters)
            {
                callParameter.Accept(this);

                if (t < call.Parameters.Length)
                {
                    strBuilder.Append(";");
                }
                t++;
            }

            strBuilder.Append(")");
        }

        public void Visit(ConstantNode call)
        {
            var value = call.Value.ToString(CultureInfo.InvariantCulture);
            strBuilder.Append(value);
        }

        public void Visit(IdentifierNode call)
        {
            strBuilder.Append(call.Identifier);
        }

        public void Visit(OperatorNode node)
        {
            if (node.Operands.Length != 2)
            {
                throw new InvalidOperationException("Solamente se pueden procesar operandos binarios");
            }

            var left = node.Operands[0];
            var right = node.Operands[1];

            VisitAndEncloseIfNecessary(left, node.Operator);

            strBuilder.Append(node.Operator.Symbol);

            VisitAndEncloseIfNecessary(right, node.Operator);
        }

        private void VisitAndEncloseIfNecessary(IExpression child, Operator parentOperator)
        {
            if (child is OperatorNode on && on.Operator.Precedence < parentOperator.Precedence)
            {
                strBuilder.Append("(");
                child.Accept(this);
                strBuilder.Append(")");
            }
            else
            {
                child.Accept(this);
            }
        }

        public string GetResult()
        {
            return strBuilder.ToString();
        }
    }
}