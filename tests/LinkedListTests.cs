using lab.list;
using NUnit.Framework;

namespace tests
{
    public class Tests
    {
        private LinkedList<int> _list;

        [SetUp]
        public void Setup()
        {
            _list = new LinkedList<int>();
            _list.Add(10);
            _list.Add(20);
            _list.Add(30);
        }

        [Test]
        public void Clear()
        {
            _list.Clear();
            
            Assert.AreEqual(_list.Count, 0);
            Assert.AreEqual(_list.ToString(), "<Empty list>");
        }
        
        [Test]
        public void Add()
        {
            _list.Clear();
            
            Assert.AreEqual(_list.Count, 0);
            
            _list.Add(10);
            Assert.AreEqual(_list.Count, 1);
            
            _list.Add(20);
            Assert.AreEqual(_list.Count, 2);
            
            _list.Add(30);
            Assert.AreEqual(_list.Count, 3);

            Assert.AreEqual(_list.ToString(), "<10->20->30>");

            Assert.Pass();
        }

        [Test]
        public void IndexOf()
        {
            Assert.AreEqual(_list.IndexOf(10), 0);
            Assert.AreEqual(_list.IndexOf(20), 1);
            Assert.AreEqual(_list.IndexOf(30), 2);
            Assert.AreEqual(_list.IndexOf(40), -1);
        }

        [Test]
        public void RemoveAt()
        {
            _list.RemoveAt(1);
            Assert.AreEqual(_list.ToString(), "<10->30>");

            _list.Clear();
            Setup();
            _list.RemoveAt(0);
            Assert.AreEqual(_list.ToString(), "<20->30>");
            
            _list.Clear();
            Setup();
            _list.RemoveAt(2);
            Assert.AreEqual(_list.ToString(), "<10->20>");
        }

        [Test]
        public void LastElement()
        {
            Assert.AreEqual(_list.Last, 30);
        }

        [Test]
        public void Remove()
        {
            _list.Remove(20);
            Assert.AreEqual(_list.ToString(), "<10->30>");

            _list.Clear();
            Setup();
            _list.Remove(10);
            Assert.AreEqual(_list.ToString(), "<20->30>");
            
            _list.Clear();
            Setup();
            _list.Remove(30);
            Assert.AreEqual(_list.ToString(), "<10->20>");
        }
    }
}