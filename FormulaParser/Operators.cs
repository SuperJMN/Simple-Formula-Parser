namespace FormulaParser
{
    public class Operators
    {
        public static readonly Operator Add = new Operator(OperatorKind.Add, "+", 1);
        public static readonly Operator Subtract = new Operator(OperatorKind.Subtract, "-", 1);
        public static readonly Operator Multiply = new Operator(OperatorKind.Multiply, "*", 2);
        public static readonly Operator Divide = new Operator(OperatorKind.Divide, "/", 2);
    }
}