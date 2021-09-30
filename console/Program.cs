using System;
using System.Linq;
using lab.dynamicArray;
using lab.infix2Postfix;
using lab.list;

namespace algstr_lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            var str = "353 + 4634 / sin(228- 5) * 62 / ( 631 - 5 ) ^ 2 ^ 3";

            var t = Tokens.Parse(str);
            var res  = string.Join(" ", t);
            
            Console.WriteLine(res);
        }
    }
}
