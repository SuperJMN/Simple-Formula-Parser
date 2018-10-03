namespace FormulaParser
{
    public class Call : Expression
    {
        public string Name { get; }
        public Expression[] Parameters { get; }

        public Call(string name, params Expression[] parameters)
        {
            Name = name;
            Parameters = parameters;
        }
    }
}