namespace lab.infix2Postfix.token
{
    public class BracketToken : Token
    {
        private readonly char _bracket;

        public BracketToken(char name)
        {
            _bracket = name;
        }

        public override string ToString()
        {
            return _bracket.ToString();
        }
        
    }
}