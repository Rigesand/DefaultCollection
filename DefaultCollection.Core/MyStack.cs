namespace DefaultCollection.Core;

public class MyStack<T>
{
    private sealed class Node
    {
        internal readonly T _value;
        internal Node? _next;

        internal Node(T value)
        {
            _value = value;
            _next = null;
        }
    }

    private volatile Node? _head;

    public void Push(T newItem)
    {
        Node newNode = new(newItem);
        newNode._next = _head;
        while (Interlocked.CompareExchange(ref _head, newNode, newNode._next) != newNode._next)
        {
            newNode._next = _head;
        }
    }

    public T Pop()
    {
        Node head;
        head = _head;
        if (Interlocked.CompareExchange(ref _head, _head._next, head) == head)
        {
            return head._value;
        }

        return default;
    }

    public T Peek()
    {
        return _head._value;
    }

    public int Count
    {
        get
        {
            int count = 0;
            Node current = _head;
            do
            {
                count++;
                current = current._next;
            } while (current != null);

            return count;
        }
    }
}