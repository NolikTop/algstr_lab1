namespace lab.infix2Postfix.token
{
    public class FunctionToken : Token
    {
        private readonly string _name;

        public FunctionToken(string name)
        {
            _name = name;
        }

        public override string ToString()
        {
            return _name;
        }
    }
}