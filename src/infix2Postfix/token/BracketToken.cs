using System;

namespace lab.infix2Postfix.token
{
    public class BracketToken : Token
    {
        private readonly char _c;
        private readonly BracketType _type;
        public BracketType Type => _type;

        public BracketToken(char c)
        {
            _type = c switch
            {
                '(' => BracketType.Open,
                ')' => BracketType.Close,
                _ => throw new Exception("Странный символ для скобки")
            };

            _c = c;
        }

        public override string ToString()
        {
            return _c.ToString();
        }
        
    }

    public enum BracketType
    {
        Open, Close
    }
}