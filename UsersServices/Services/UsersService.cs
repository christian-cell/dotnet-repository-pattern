using UsersModels.Models;
using UsersRepository.Abstractions;

namespace UsersServices.Services;

public class UsersService : IUserService
{
    private readonly IUsersRepository _usersRepository;

    public UsersService(IUsersRepository usersRepository)
    {
        _usersRepository = usersRepository;
    }

    public async Task<List<User>> GetAllUsersAsync()
    {
        return await _usersRepository.GetAllUsers();
    }

    public async Task<User> GetUserAsync(int id)
    {
        var user = await _usersRepository.GetUser(id);
    	
        if (user == null)
        {
            throw new KeyNotFoundException("The user you are trying to get does not exist.");
        }

        return user;
    }

    public async Task AddUserAsync(User newUser)
    {
        await _usersRepository.AddUser(newUser);
    }

    public async Task UpdateUserAsync(int id, User updatedUser)
    {
        if (id != updatedUser.UserId)
        {
            throw new ArgumentException("The user ID in the URL does not match the user ID in the provided data.");
        }

        await _usersRepository.UpdateUser(updatedUser);
    }

    public async Task DeleteUserAsync(int id)
    {
        var user = await _usersRepository.GetUser(id);

        if (user == null)
        {
            throw new KeyNotFoundException("The user you are trying to delete does not exist.");
        }

        await _usersRepository.DeleteUser(id);
    }

    public bool UserExists(int id)
    {
        return _usersRepository.GetUser(id) != null;
    }
}