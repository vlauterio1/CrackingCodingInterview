using System;
using System.Text;
using System.Collections.Generic;

namespace _2_1_RemoveFromUnsorted
{
    class Program
    {
        static void Main(string[] args)
        {
        	LinkedList<int> items = new LinkedList<int>();
        	items.Add(2);
        	items.Add(4);
        	items.Add(3);
            items.Add(2);
            items.Add(6);
            items.Add(1);
        	items.Add(6);
        	items.Add(3);
        	items.Add(7);

        	Console.WriteLine(items.ToString());

        	items.RemoveDuplicates();
        	Console.WriteLine(items.ToString());

            items.Remove(2);
            Console.WriteLine(items.ToString());

            items.Remove(7);
            Console.WriteLine(items.ToString());
		}
    }

    class LinkedList<T>
    {
    	private LinkedListNode<T> _head;
        private LinkedListNode<T> _tail;
    	private IDictionary<T, bool> _duplicates = new Dictionary<T, bool>();

    	public override string ToString()
    	{
    		LinkedListNode<T> current = _head;

    		StringBuilder sb = new StringBuilder();
    		while (current != null)
    		{
    			sb.Append(string.Format("{0} ", current.Value));

    			current = current.Next;
    		}

    		return sb.ToString();
    	}

    	public void Add(T item)
    	{
    		LinkedListNode<T> node = new LinkedListNode<T>
    		{
    			Value = item
    		};

    		if (_head == null)
    		{
				_head = node;
                _tail = node;
    		}
    		else
    		{
                _tail.Next = node;
                _tail = node;
			}
    	}

        public void Remove(T item)
        {
            LinkedListNode<T> current = _head;

            while (current != null)
            {
                if (current.Value.Equals(item))
                {
                    Remove(current);

                    break;
                }

                current = current.Next;
            }
        }

    	public void Remove(LinkedListNode<T> node)
    	{
    		if (node == _head)
    		{
                if (_head.Next == null)
                {
                    _tail = null;
                }

                _head = _head.Next;
    		}
    		else
    		{
                LinkedListNode<T> prev = null;
                LinkedListNode<T> current = _head;

                while (current != null)
                {
                    if (node == current)
                    {
                        if (node == _tail)
                        {
                            _tail = prev;
                        }

                        prev.Next = current.Next;

                        break;
                    }

                    prev = current;
                    current = current.Next;
                }
    		}
    	}

    	public void RemoveDuplicates()
    	{
    		if (_head == null)
    		{
    			return;
    		}

    		LinkedListNode<T> current = _head;

    		while (current != null)
    		{
    			if (!_duplicates.ContainsKey(current.Value))
    			{
    				_duplicates.Add(current.Value, true);
    			}
    			else
    			{
    				Remove(current);
    			}

    			current = current.Next;
    		}
    	}
    }

    class LinkedListNode<T>
    {
    	public T Value { get; set; }
    	public LinkedListNode<T> Next { get; set; }
    }
}
