namespace lab.infix2Postfix.token
{
    public class NumberToken : Token
    {
        private readonly string _number;
        
        public NumberToken(int number)
        {
            _number = number.ToString();
        }
        
        public NumberToken(string number)
        {
            _number = number;
        }
        
        public override string ToString()
        {
            return _number;
        }
    }
}