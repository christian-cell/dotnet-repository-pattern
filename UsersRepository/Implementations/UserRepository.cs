using Microsoft.EntityFrameworkCore;
using UsersModels.Models;
using UsersRepository.Abstractions;


namespace UsersRepository.Implementations;

public class YourDbContext : DbContext
{
    public YourDbContext(DbContextOptions<YourDbContext> options)
        : base(options)
    { }

    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().ToTable("Users", "TutorialAppSchema");
    }
}

public class UserRepository : IUsersRepository
{
    private readonly YourDbContext _dbContext;

    public UserRepository(YourDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<List<User>> GetAllUsers()
    {
        return await _dbContext.Users.ToListAsync();
    }

    public async Task<User> GetUser(int id)
    {
        return await _dbContext.Users.FindAsync(id);
    }

    public async Task AddUser(User user)
    {
        _dbContext.Users.Add(user);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateUser(User user)
    {
        _dbContext.Users.Update(user);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteUser(int id)
    {
        var user = await _dbContext.Users.FindAsync(id);
        if (user != null)
        {
            _dbContext.Users.Remove(user);
            await _dbContext.SaveChangesAsync();
        }
    }
    
    
}