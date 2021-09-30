using System;
using System.Reflection.Metadata;
using lab.infix2Postfix.token;
using lab.stack;

namespace lab.infix2Postfix
{
    public static class Infix2PostfixTranslator
    {

        public static string Translate(string input)
        {
            var output = string.Empty;
            var ops = new Stack<Token>();
            
            foreach (var token in Tokens.Parse(input))
            {
                switch (token)
                {
                    case NumberToken:
                        output += token + " ";
                        break;
                    case FunctionToken:
                        ops.Push(token);
                        break;
                    case OperatorToken op1:
                        output += handleOp1(op1, ops);
                        break;
                    case BracketToken br:
                        switch (br.Type)
                        {
                            case BracketType.Open:
                                ops.Push(br);
                                break;
                            case BracketType.Close:
                                output += handleCloseBracket(ops);
                                break;
                            default:
                                throw new ArgumentOutOfRangeException();
                        }

                        break;
                    
                }
            }

            while (!ops.IsEmpty)
            {
                output += ops.Pop() + " ";
            }
            
            return output.TrimEnd();
        }

        private static string handleCloseBracket(Stack<Token> ops)
        {
            var res = string.Empty;

            while (ops.Top is not BracketToken) // в стек все равно кладем только открывающуюся
            {
                if (!ops.IsEmpty)
                {
                    res += ops.Pop() + " ";
                }
                else
                {
                    throw new Exception("Количество открывающихся и закрывающихся скобок не совпадает");
                }
            }

            ops.Pop();

            if (!ops.IsEmpty && ops.Top is FunctionToken)
            {
                res += ops.Pop() + " ";
            }

            return res;
        }

        private static string handleOp1(OperatorToken op1, Stack<Token> ops)
        {
            var res = string.Empty;

            while (true)
            {
                if (ops.IsEmpty || ops.Top is not OperatorToken op2)
                {
                    ops.Push(op1);
                    return res;
                }

                if (
                    op2.Priority > op1.Priority ||
                    op2.Priority == op1.Priority && op1.LeftAssociative
                )
                {
                    res += ops.Pop() + " ";
                }
                else
                {
                    ops.Push(op1);

                    return res;
                }
            }
        }
        
    }
}