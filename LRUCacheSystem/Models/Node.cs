using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LRUCacheSystem.Models
{
    internal class Node<TKey, TValue>
    {
            public TKey Key;

            public TValue Value;

            public Node<TKey,TValue>? Next { get; set; }

            public Node<TKey,TValue>? Previous { get; set; }

            public Node(TKey key,TValue value) { Key = key; Value = value; }

    }
}
