using System;
using lab.list;

namespace algstr_lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = new LinkedList<int>();
            Console.WriteLine(a.ToString());
            
            a.Add(228);
            Console.WriteLine(a.ToString());
            
            a.Add(990);
            Console.WriteLine(a.ToString());
            
            a.Remove(228);
            Console.WriteLine(a.ToString());
        }
    }
}
