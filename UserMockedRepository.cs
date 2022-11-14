using Interview.UserProviderService.Domain;
using Interview.UserProviderService.Interfaces;

namespace Interview.UserProviderService
{
    public class UserMockedRepository : IUserRepository
    {
        public User GetUser(string id)
        {
            return new User()
            {
                Id = id,
                Name = id
            };
        }
    }
}