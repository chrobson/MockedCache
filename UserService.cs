using Interview.UserProviderService.Domain;
using Interview.UserProviderService.Interfaces;

namespace Interview.UserProviderService
{
    public class UserService
    {
        private ICacheService<User> _cache;
        private IUserRepository _usersRepository;

        public UserService(ICacheService<User> cache,
             IUserRepository usersRepository)
        {
            _usersRepository = usersRepository;
            _cache = cache;
        }

        public (bool fromCache, User user) GetUser(string userId)
        {
            if (_cache.IsCached(userId))
                return (true, _cache.GetFromCache(userId));

            var user = _usersRepository.GetUser(userId);
            _cache.SaveInCache(userId, user);
            return (false,user);
        }
    }
}