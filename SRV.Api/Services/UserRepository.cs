using Microsoft.EntityFrameworkCore;
using SRV.DL;

namespace SRV.Api.Services
{
    public class UserRepository : IUserRepository
    {
        private readonly StudentContext _studentContext;

        public UserRepository(StudentContext studentContext)
        {
            this._studentContext = studentContext;
        }

        public async Task<User> GetUserByUserName(string userName)
        {
            return await _studentContext.Users.SingleAsync(u => u.Username == userName);
        }

        public async Task<User> ValidateUserCredentialAsync(string userName, string password)
        {
            return await _studentContext.Users.SingleOrDefaultAsync(u => u.Username == userName && u.Password == password);
        }
    }
}
