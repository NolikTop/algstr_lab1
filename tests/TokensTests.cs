using System;
using System.Linq;
using lab.infix2Postfix;
using lab.infix2Postfix.token;
using NUnit.Framework;

namespace tests
{
    public class TokensTests
    {

        [SetUp]
        public void SetUp()
        {
            
        }

        [Test]
        public void Parse()
        {
            var str = "353 + 4634 / sin((228)- 5) * 62 / ( 631 - 5 ) ^ 2 ^ 3";

            var t = Tokens.Parse(str);
            var res  = string.Join(" ", t);
            
            Assert.AreEqual("353 + 4634 / sin ( ( 228 ) - 5 ) * 62 / ( 631 - 5 ) ^ 2 ^ 3", res);
            

            str = "353 + 4634 / sin((228)- 5) % 4 * 62 / ( 631 - 5 ) ^ 2 ^ 3"; // есть недопустимый символ 
            Assert.Catch<Exception>(() => Tokens.Parse(str));
        }
        
    }
}