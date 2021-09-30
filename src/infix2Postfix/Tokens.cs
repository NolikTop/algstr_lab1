using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using lab.dynamicArray;
using lab.infix2Postfix.token;

namespace lab.infix2Postfix
{
    public static class Tokens
    {

        private static bool _inited = false;

        public static readonly Dictionary<string, FunctionToken> Functions = new();
        public static readonly Dictionary<string, OperatorToken> Operators = new();

        public static void Init()
        {
            Add(new FunctionToken("sin"));
            Add(new FunctionToken("cos"));
            
            Add(new OperatorToken('+', 1));
            Add(new OperatorToken('-', 1));
            Add(new OperatorToken('*', 2));
            Add(new OperatorToken('/', 2));
            Add(new OperatorToken('^', 3, false));

            _inited = true;
        }

        private static void Add(FunctionToken token)
        {
            Functions.Add(token.ToString(), token);
        }

        private static void Add(OperatorToken token)
        {
            Operators.Add(token.ToString(), token);
        }

        public static DynamicArray<Token> Parse(string text)
        {
            if (!_inited)
            {
                Init();
            }
            
            DynamicArray<Token> t = new();

            var e = text.GetEnumerator();
            var next = e.MoveNext();
            
            while (next)
            {
                if (e.Current == ' ')
                {
                    next = e.MoveNext();
                    continue;
                }

                if(char.IsDigit(e.Current))
                {
                    var buffer = e.Current.ToString();
                    
                    for(; (next = e.MoveNext()) && char.IsDigit(e.Current);)
                    {
                        buffer += e.Current;
                    }

                    t.Add(new NumberToken(buffer));
                    continue;
                }

                if (char.IsLetter(e.Current))
                {
                    var buffer = e.Current.ToString();

                    for(; (next = e.MoveNext()) && char.IsLetter(e.Current);)
                    {
                        buffer += e.Current;
                    }

                    if (!Functions.ContainsKey(buffer))
                    {
                        throw new Exception($"Функции \"{buffer}\" не существует");
                    }

                    t.Add(new FunctionToken(buffer));
                    continue;
                }

                if (Operators.TryGetValue(e.Current.ToString(), out var op))
                {
                    t.Add(op);

                    next = e.MoveNext();
                    continue;
                }

                if (e.Current is '(' or ')')
                {
                    t.Add(new BracketToken(e.Current));

                    next = e.MoveNext();
                    continue;
                }

                throw new Exception("Неизвестный символ \"" + e.Current + "\"");
            }

            return t;
        }

    }
}