using System;
using lab.stack;
using NUnit.Framework;

namespace tests
{
    public class StackTests
    {
        private Stack<int> _stack;

        [SetUp]
        public void SetUp()
        {
            _stack = new Stack<int>();
        }

        [Test]
        public void Push()
        {
            Assert.AreEqual(true, _stack.IsEmpty);
            
            _stack.Push(10);
            _stack.Push(20);
            _stack.Push(30);
            Assert.AreEqual(3, _stack.Count);
            
            Assert.AreEqual("<30<-20<-10>", _stack.ToString());
        }

        [Test]
        public void Pop()
        {
            _stack.Push(10);
            _stack.Push(20);
            _stack.Push(30);
            
            Assert.AreEqual(30, _stack.Top);
            
            Assert.AreEqual(false, _stack.IsEmpty);
            Assert.AreEqual(30, _stack.Pop());
            Assert.AreEqual(20, _stack.Pop());
            Assert.AreEqual(10, _stack.Pop());
            Assert.Catch<IndexOutOfRangeException>(() => _stack.Pop());
            
            Assert.AreEqual(true, _stack.IsEmpty);
        }

    }
}