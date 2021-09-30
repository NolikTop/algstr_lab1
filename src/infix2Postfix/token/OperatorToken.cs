namespace lab.infix2Postfix.token
{
    public class OperatorToken : Token
    {
        private readonly string _name;

        public OperatorToken(char name)
        {
            _name = name.ToString();
        }

        public override string ToString()
        {
            return _name;
        }
    }
}