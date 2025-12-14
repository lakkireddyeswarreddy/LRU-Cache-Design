using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LRUCacheSystem.Core
{
    internal class LruCache<TKey, TValue>
    {

        private  CacheProcessor<TKey, TValue> _cacheProcessor ;

        private readonly int _capacity;

        public LruCache(int capacity) { 
        
            _capacity = capacity;

            _cacheProcessor = new CacheProcessor<TKey, TValue>(capacity);

        }


        public int CurrenctCacheCapacity()
        {
            return _cacheProcessor.CurrenctCacheCapacity();
        }

        public TValue Get(TKey key)
        {
           return _cacheProcessor.get(key);
        }

        public void Put(TKey key, TValue value)
        {
            _cacheProcessor.Put(key, value);
        }


    }
}
