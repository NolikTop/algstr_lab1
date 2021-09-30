using lab.infix2Postfix;
using NUnit.Framework;

namespace tests
{
    public class Infix2PostfixTests
    {

        [SetUp]
        public void SetUp()
        {
            
        }

        [Test]
        public void TranslateWithoutFunctions()
        {
            Assert.AreEqual("1 2 + 3 *", Infix2PostfixTranslator.Translate("(1+2)*3"));   
            Assert.AreEqual("3 4 2 * 1 5 - 2 3 ^ ^ / +", Infix2PostfixTranslator.Translate("3 + 4 * 2/( 1 - 5 ) ^ 2 ^ 3"));   
            Assert.AreEqual("0 1 2 3 ^ 4 - 5 6 7 * + ^ * + 8 -", Infix2PostfixTranslator.Translate("0+1*(2^3-4)^(5+6*7)-8"));   
        }

        [Test]
        public void TranslateWithFunctions()
        {
            Assert.AreEqual("2 cos 3 / 4 * sin", Infix2PostfixTranslator.Translate("sin ( cos ( 2) / 3 * 4 )"));
        }
        
    }
}