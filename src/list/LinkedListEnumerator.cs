using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace lab.list
{
    public class LinkedListEnumerator<T> : IEnumerator<T>
    {
        public LinkedListEnumerator(LinkedList<T> list)
        {
            if (list.FirstElement != null)
            {
                _current = list.FirstElement;
            }
        }

        public bool MoveNext()
        {
            if (_current == null) return false; // вдруг лист сразу пустой 
            
            _current = _current.Next;
            
            return _current != null;
        }

        public void Reset()
        {
            throw new System.NotImplementedException();
        }

        private LinkedListElement<T>? _current;

        public T Current => _current!.Value;

        object IEnumerator.Current => Current!;

        public void Dispose()
        {
            _current = default;
        }
    }
}