using Interview.UserProviderService.Domain;

namespace Interview.UserProviderService.Interfaces
{
    public interface IUserRepository
    {
        User GetUser(string id);
    }
}