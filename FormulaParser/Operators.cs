namespace FormulaParser
{
    public class Operators
    {
        public static Operator Add = new Operator(OperatorKind.Add, "+", 1);
        public static Operator Subtract = new Operator(OperatorKind.Subtract, "-", 1);
        public static Operator Multiply = new Operator(OperatorKind.Multiply, "*", 2);
        public static Operator Divide = new Operator(OperatorKind.Divide, "/", 2);
    }
}