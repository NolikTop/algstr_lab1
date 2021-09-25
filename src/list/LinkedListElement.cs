namespace lab.list
{
    public class LinkedListElement<T>
    {
        internal LinkedListElement<T>? Next;
        internal T Value;

        internal LinkedListElement(T value)
        {
            Value = value;
        }

        internal LinkedListElement(T value, LinkedListElement<T> next): this(value)
        {
            Next = next;
        }

    }
}