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
            _array = new DynamicArray<int>();
            _array.Add(10);
        }

        [Test]
        public void ReAlloc()
        {
            _array.Clear();
            
            Assert.AreEqual(_array.Count, 0);
            Assert.AreEqual(_array.Capacity, 2);
            
            //Assert.AreEqual(_array.);
        }
        
    }
}