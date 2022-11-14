using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.UserProviderService.Interfaces
{
    public interface ICacheService<T>
    {
        bool IsCached(string key);
        T GetFromCache(string key);
        void SaveInCache(string key, T value);
    }
}
