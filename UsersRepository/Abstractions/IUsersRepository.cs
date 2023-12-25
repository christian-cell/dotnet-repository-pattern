namespace UsersRepository.Abstractions;
using UsersModels.Models;

public interface IUsersRepository
{
    Task<List<User>> GetAllUsers();
    Task<User> GetUser(int id);
    Task AddUser(User user);
    Task UpdateUser(User user);
    Task DeleteUser(int id);
}
