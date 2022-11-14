using Interview.UserProviderService.Interfaces;

namespace Interview.UserProviderService
{
    public class MemoryCacheService<T> : ICacheService<T>
    {
        private readonly Dictionary<string, T> _cache = new Dictionary<string, T>();
        private readonly CacheConfig _cacheConfig;
        public MemoryCacheService(CacheConfig cacheConfig)
        {
            _cacheConfig = cacheConfig;
        }
        public T GetFromCache(string key)
        {
            if (!_cache.ContainsKey(key))
                throw new InvalidOperationException($"Item with id {key} is not persisted in the cache");

            return _cache[key];
        }

        public bool IsCached(string key)
        {
            return _cache.ContainsKey(key);
        }

        public void SaveInCache(string key, T value)
        {
            _cache.Add(key, value);
            // Below nethod is asynchronous, do not wait for its result
            RemoveFromCache(key);
        }

        private async Task RemoveFromCache(string key)
        {
            await Task.Delay(TimeSpan.FromSeconds(_cacheConfig.CacheTimeInSeconds));

            if (_cache.ContainsKey(key))
                _cache.Remove(key);
        }
    }
}