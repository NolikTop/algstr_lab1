using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace lab.dynamicArray
{
    public class DynamicArray<T> : ICollection<T>
    {
        private T[] _internalArray = new T[2];

        public int Count { get; private set; }

        private int _capacity = 2;
        public int Capacity
        {
            get => _capacity;
            private set
            {
                var newArray = new T[value];
                _capacity = value;

                _internalArray.CopyTo(newArray, 0);
                _internalArray = newArray;
            }
        }

        public bool IsEmpty => Count == 0;

        public bool IsReadOnly => false;

        public T this[int index]
        {
            get => _internalArray[index];
            set
            {
                if (index >= Capacity)
                {
                    Capacity = Math.Max(index, Capacity * 2);
                }
                _internalArray[index] = value;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return (IEnumerator<T>)_internalArray.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(T item)
        {
            if (Count >= Capacity)
            {
                Capacity *= 2;
            }

            _internalArray[Count++] = item;
        }
        
        public void Clear()
        {
            _internalArray = new T[2];
            Count = 0;
            _capacity = 2;
        }

        /// <summary>
        /// Содержит ли массив данный элемент
        /// </summary>
        /// <param name="item">элемент</param>
        /// <returns>true, если элемент найден, и false, если не найден</returns>
        public bool Contains(T item)
        {
            return _internalArray.Contains(item);
        }

        /// <summary>
        /// Копирует массив в указанный
        /// </summary>
        /// <param name="array">массив</param>
        /// <param name="arrayIndex">индекс, с которого начинать копировать</param>
        public void CopyTo(T[] array, int arrayIndex)
        {
            _internalArray.CopyTo(array, arrayIndex);
        }
        
        /// <summary>
        /// Возвращает индекс первого элемента, равного указанному
        /// </summary>
        /// <param name="item">элемент</param>
        /// <returns>индекс элемента, либо -1 если он не найден</returns>
        public int IndexOfFirst(T item)
        {
            for (var i = 0; i < Count; ++i)
            {
                if (!EqualityComparer<T>.Default.Equals(_internalArray[i], item)) continue;

                return i;
            }

            return -1;
        }

        /// <summary>
        /// Удаляет первый элемент
        /// </summary>
        /// <param name="item">элемент</param>
        /// <returns>true, если элемент был удален, и false, если элемент не был найден</returns>
        public bool Remove(T item)
        {
            var index = IndexOfFirst(item);

            if (index == -1)
            {
                return false;
            }

            RemoveAt(index);
            
            return true;
        }

        /// <summary>
        /// Удаляет элемент по индексу
        /// </summary>
        /// <param name="index">индекс элемента</param>
        public void RemoveAt(int index)
        {
            Array.Copy(_internalArray, index + 1, _internalArray, index, _internalArray.Length - index - 1); // сдвигаем массив 
            Count--;
        }
    }
}