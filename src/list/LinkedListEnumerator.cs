using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace lab.list
{
    public class LinkedListEnumerator<T> : IEnumerator<T>
    {
        private LinkedListElement<T>? _current;

        public T Current => _current!.Value;
        
        public LinkedListEnumerator(LinkedList<T> list)
        {
            if (list.FirstElement != null)
            {
                _current = list.FirstElement;
            }
        }

        public bool MoveNext()
        {
            _current = _current?.Next;
            
            return _current != null;
        }

        public void Reset() => _current = default;

        public void Dispose() => Reset();

        object IEnumerator.Current => Current!;
    }
}