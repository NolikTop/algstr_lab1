using System;
using lab.dynamicArray;
using NUnit.Framework;

namespace tests
{
    public class DynamicArrayTests
    {
        private DynamicArray<int> _array;

        [SetUp]
        public void Setup()
        {
            _array = new DynamicArray<int> { 10, 20, 30, 40 };
        }

        [Test]
        public void Add()
        {
            _array.Clear();
            Assert.AreEqual("[Count=0, Capacity=2]<Empty dynamic array>", _array.ToString());
            
            _array.Add(10);
            Assert.AreEqual("[Count=1, Capacity=2]<10>", _array.ToString());
            
            _array.Add(20);
            Assert.AreEqual("[Count=2, Capacity=2]<10,20>", _array.ToString());
        }

        [Test]
        public void ReAlloc()
        {
            _array.Clear();
            Assert.AreEqual(0, _array.Count);
            Assert.AreEqual(2, _array.Capacity);
            
            _array.Add(10);
            Assert.AreEqual(1, _array.Count);
            Assert.AreEqual(2, _array.Capacity);
            
            _array.Add(20);
            Assert.AreEqual(2, _array.Count);
            Assert.AreEqual(2, _array.Capacity);
            
            _array.Add(30);
            Assert.AreEqual(3, _array.Count);
            Assert.AreEqual(4, _array.Capacity);
            
            _array.Clear();
            Assert.AreEqual(0, _array.Count);
            Assert.AreEqual(2, _array.Capacity);
        }

        [Test]
        public void ReAllocUsingIndex()
        {
            _array[6] = 100;
            Assert.AreEqual(7, _array.Count);
            Assert.AreEqual(8, _array.Capacity);

            _array[99] = 22;
            Assert.AreEqual(100, _array.Count);
            Assert.AreEqual(100, _array.Capacity);
        }

        [Test]
        public void IndexOf()
        {
            Assert.AreEqual(2, _array.IndexOf(30));
            Assert.AreEqual(-1, _array.IndexOf(100));
        }

        [Test]
        public void Remove()
        {
            _array.Remove(20);
            
            Assert.AreEqual("[Count=3, Capacity=4]<10,30,40>", _array.ToString());
        }
        
    }
}