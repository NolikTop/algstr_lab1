using System;
using System.Collections;
using System.Collections.Generic;

namespace lab.list
{
    public class LinkedList<T> : IList<T>
    {
        public LinkedListElement<T>? FirstElement = null;

        public T First => FirstElement!.Value;
        public T Last => LastElement()!.Value;
        
        public IEnumerator<T> GetEnumerator()
        {
            return new LinkedListEnumerator<T>(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public LinkedListElement<T>? LastElement()
        {
            var it = FirstElement;
            if (it == null) return null;

            for (; it.Next != null; it = it.Next) {}

            return it;
        }

        public void Add(T item)
        {
            var last = LastElement();
            if (last == null)
            {
                FirstElement = new LinkedListElement<T>(item);
            }
            else
            {
                last.Next = new LinkedListElement<T>(item);
            }
        }

        public void Clear()
        {
            FirstElement = null; // пофиг, GC их всех съест
        }

        public bool Contains(T item)
        {
            return IndexOf(item) != -1;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new System.NotImplementedException(); // зачем?
        }

        public bool Remove(T item)
        {
            LinkedListElement<T>? prev = null;
            for (var it = FirstElement; it != null; prev = it, it = it.Next)
            {
                if (!EqualityComparer<T>.Default.Equals(it.Value, item)) continue;
                
                if (prev == null)
                {
                    FirstElement = it.Next;
                    return true;
                }
                
                prev.Next = it.Next;
                return true;
            }

            return false;
        }

        public int Count
        {
            get
            {
                var count = 0;
                for (var it = FirstElement; it != null; it = it.Next, count++) { }

                return count;
            }
        }

        public bool IsReadOnly => false;

        public int IndexOf(T item)
        {
            var i = 0;
            for (var it = FirstElement; it != null; it = it.Next, i++)
            {
                if (EqualityComparer<T>.Default.Equals(it.Value, item)) return i;
            }

            return -1;
        }

        public void Insert(int index, T item)
        {
            this[index] = item;
        }

        public void RemoveAt(int index)
        {
            switch (index)
            {
                case < 0:
                    throw new IndexOutOfRangeException();
                case 0:
                    FirstElement = FirstElement?.Next;
                    return; 
                case > 0:
                    var i = 0;
                    LinkedListElement<T>? prev = null;
                    
                    for (var it = FirstElement; it != null; prev = it, it = it.Next, i++)
                    {
                        if (i != index) continue;
                        
                        prev!.Next = it.Next;
                        return;
                    }
                    break;
            }
            
            throw new IndexOutOfRangeException();
        }

        public T this[int index]
        {
            get
            {
                var i = 0;
                    
                for (var it = FirstElement; it != null; it = it.Next, i++)
                {
                    if (i != index) continue;
                    
                    return it.Value;
                }

                throw new IndexOutOfRangeException();
            }
            set
            {
                var i = 0;
                    
                for (var it = FirstElement; it != null; it = it.Next, i++)
                {
                    if (i != index) continue;

                    it.Value = value;
                    return;
                }
                
                throw new IndexOutOfRangeException();
            }
            
        }

        public override string ToString()
        {
            if (FirstElement == null)
            {
                return "<Empty list>";
            }
            
            var r = "<" + FirstElement.Value;
            
            for (var it = FirstElement.Next; it != null; it = it.Next)
            {
                r += "->" + it.Value;
            }

            r += ">";

            return r;
        }
    }
}