namespace FormulaParser
{
    public class Operators
    {
        public static readonly Operator Add = new Operator(OperatorKind.Add, "+", 2);
        public static readonly Operator Subtract = new Operator(OperatorKind.Subtract, "-", 2);
        public static readonly Operator Multiply = new Operator(OperatorKind.Multiply, "*", 3);
        public static readonly Operator Divide = new Operator(OperatorKind.Divide, "/", 3);
        public static readonly Operator Neq = new Operator(OperatorKind.NotEqual, "<>", 1);
        public static readonly Operator Gt = new Operator(OperatorKind.Greater, ">", 1);
        public static readonly Operator Lt = new Operator(OperatorKind.Less, ">", 1);
        public static readonly Operator LtEq = new Operator(OperatorKind.GreaterEqual, ">=", 1);
        public static readonly Operator GtEq = new Operator(OperatorKind.LessEqual, "<=", 1);
        public static readonly Operator Eq = new Operator(OperatorKind.Equal, "=", 1);
    }
}