using LRUCacheSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LRUCacheSystem.Core
{
    internal class CacheProcessor<TKey, TValue>
    {
        private Dictionary<TKey, Node<TKey, TValue>> _cache = new Dictionary<TKey, Node<TKey, TValue>>();

        private DoublyLinkedList<TKey, TValue> _cacheList = new DoublyLinkedList<TKey, TValue>();

        private readonly int _capacity;

        public CacheProcessor(int capacity)
        {
            _capacity = capacity;
        }


        public int CurrenctCacheCapacity()
        {
            return this._cache.Count;
        }

        public TValue get(TKey key)
        {
            if(_cache.TryGetValue(key, out Node<TKey, TValue> node))
            {
                _cacheList.RemoveAndAddFirst(node);

                return node.Value;
            }
            else
            {
                return default(TValue);
            }
        }

        public void Put(TKey key, TValue value)
        {
            if(_cache.Count >= _capacity)
            {
               var node = _cacheList.RemoveLast();

               if(node != null)
                {
                    _cache.Remove(node.Key);
                }

            }
            var temp = new Node<TKey,TValue>(key, value);

            _cache.Add(key, temp);

            _cacheList.Add(temp);

        }






    }
}
