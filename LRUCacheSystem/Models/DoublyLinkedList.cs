using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LRUCacheSystem.Models
{
    internal class DoublyLinkedList<TKey, TValue>
    {

        public Node<TKey, TValue>? Head { get; set; }

        public Node<TKey, TValue>? Tail { get; set; }


        public void Add(Node<TKey, TValue> node)
        {
            if(Head == null)
            {
                Head = node;
                Tail = node;
            }
            else
            {

            var temp = Head;

            Head = node;

            Head.Next = temp;

            temp.Previous = Head;
            }
        }

        public Node<TKey, TValue> RemoveLast()
        {
            if(Tail == null)
            {
                return null;
            }
            else
            {
                var temp = Tail;

                Tail = temp.Previous;

                if(Tail != null)
                {
                    Tail.Next = null;
                }

                return temp;
            }
        }

        public void RemoveAndAddFirst(Node<TKey, TValue> node)
        {
            if (Head == node)
            {
                return ;
            }
            else
            {
                var previous = node.Previous;

                if(Tail == node)
                {
                    Tail = previous;
                }

                var next = node.Next;

                previous.Next = next;

                if(next != null)
                {

                next.Previous = previous;

                }

                Add(node);
            }
        }


    }
}
