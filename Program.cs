using Interview.UserProviderService.Domain;
using System;

namespace Interview.UserProviderService
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var cacheConfig = new CacheConfig()
            {
                CacheTimeInSeconds = 60
            };
            var cache = new MemoryCacheService<User>(cacheConfig);
            var userRepo = new UserMockedRepository();
            var userProvider = new UserService(cache, userRepo);

            var random = new Random();
            for (int i = 0; i < 1000; i++)
            {
                var userId = random.Next(1, 10);
                var user =  userProvider.GetUser(userId.ToString());
                Console.WriteLine($"User id: {user.user.Id}");
                Console.WriteLine($"Taken from cache: {user.fromCache}");
            }
            Console.WriteLine("Finished");
            Console.ReadLine();
        }
     }
}