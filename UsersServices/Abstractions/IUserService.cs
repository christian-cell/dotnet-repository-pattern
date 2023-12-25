using UsersModels.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace UsersServices.Services
{
    public interface IUserService
    {
        Task<List<User>> GetAllUsersAsync();
        Task<User> GetUserAsync(int id);
        Task AddUserAsync(User newUser);
        Task UpdateUserAsync(int id, User updatedUser);
        Task DeleteUserAsync(int id);
        bool UserExists(int id);
    }
}