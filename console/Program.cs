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
            var str = "sin ( cos ( 2) / 3 * 4 )";
            //var str = "3 + 4 * 2 / sin( 1 - 5 ) ^ 2 ^ cos((3))";
            // 3 4 2 * 1 5 - sin 2 3 cos ^ ^ / + 
            Console.WriteLine(Infix2PostfixTranslator.Translate(str));
        }
    }
}
