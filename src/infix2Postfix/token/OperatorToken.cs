namespace lab.infix2Postfix.token
{
    public class OperatorToken : Token
    {
        private readonly string _name;
        private readonly int _priority;
        private readonly bool _leftAssociative;

        public int Priority => _priority;
        public bool LeftAssociative => _leftAssociative;

        public OperatorToken(char name, int priority, bool leftAssociative = true)
        {
            _name = name.ToString();
            _priority = priority;
            _leftAssociative = leftAssociative;
        }

        public override string ToString()
        {
            return _name;
        }
    }
}