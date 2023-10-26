using SRV.DL;

namespace SRV.Api.Services
{
    public interface IUserRepository
    {
        Task<User> GetUserByUserName(string userName);
    }
}
