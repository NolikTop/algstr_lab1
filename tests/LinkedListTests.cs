using lab.list;
using NUnit.Framework;

namespace tests
{
    public class LinkedListTests
    {
        private LinkedList<int> _list;

        [SetUp]
        public void Setup()
        {
            _list = new LinkedList<int> { 10, 20, 30 };
        }

        [Test]
        public void Clear()
        {
            _list.Clear();
            
            Assert.AreEqual(0, _list.Count);
            Assert.AreEqual("<Empty list>", _list.ToString());
        }
        
        [Test]
        public void Add()
        {
            _list.Clear();
            
            Assert.AreEqual("<Empty list>", _list.ToString());
            
            _list.Add(10);
            Assert.AreEqual("<10>", _list.ToString());
            
            _list.Add(20);
            Assert.AreEqual("<10->20>", _list.ToString());
            
            _list.Add(30);
            Assert.AreEqual("<10->20->30>", _list.ToString());

            Assert.AreEqual("<10->20->30>", _list.ToString());

            Assert.Pass();
        }

        [Test]
        public void IndexOf()
        {
            Assert.AreEqual(0, _list.IndexOf(10));
            Assert.AreEqual(1, _list.IndexOf(20));
            Assert.AreEqual(2, _list.IndexOf(30));
            Assert.AreEqual(-1, _list.IndexOf(40));
        }

        [Test]
        public void RemoveAt()
        {
            _list.RemoveAt(1);
            Assert.AreEqual("<10->30>", _list.ToString());

            _list.Clear();
            Setup();
            _list.RemoveAt(0);
            Assert.AreEqual("<20->30>", _list.ToString());
            
            _list.Clear();
            Setup();
            _list.RemoveAt(2);
            Assert.AreEqual("<10->20>", _list.ToString());
        }

        [Test]
        public void LastElement()
        {
            Assert.AreEqual(30, _list.Last);
        }

        [Test]
        public void Remove()
        {
            _list.Remove(20);
            Assert.AreEqual("<10->30>", _list.ToString());

            _list.Clear();
            Setup();
            _list.Remove(10);
            Assert.AreEqual("<20->30>", _list.ToString());
            
            _list.Clear();
            Setup();
            _list.Remove(30);
            Assert.AreEqual("<10->20>", _list.ToString());
        }
    }
}