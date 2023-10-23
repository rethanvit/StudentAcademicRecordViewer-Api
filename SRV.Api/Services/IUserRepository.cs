using SRV.DL;

namespace SRV.Api.Services
{
    public interface IUserRepository
    {
        Task<User> GetUserByUserName(string userName);
        Task<User> ValidateUserCredentialAsync(string userName, string password);
    }
}
