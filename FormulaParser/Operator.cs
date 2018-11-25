namespace FormulaParser
{
    public class Operator
    {
        public OperatorKind Kind { get; }
        public string Symbol { get; }
        public int Precedence { get; }

        public Operator(OperatorKind kind, string symbol, int precedence)
        {
            Kind = kind;
            Symbol = symbol;
            Precedence = precedence;
        }
    }
}