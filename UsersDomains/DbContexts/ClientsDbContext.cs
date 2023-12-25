using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using UsersModels.Models;

namespace UsersDomains.DbContexts;

public class ClientsDbContext : DbContext
{
    
    public ClientsDbContext(DbContextOptions<ClientsDbContext> options)
        : base(options)
    { }

    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().ToTable("Clients", "TutorialAppSchema");
        base.OnModelCreating(modelBuilder);
    }
    
    public class ClientsDbContextFactory : IDesignTimeDbContextFactory<ClientsDbContext>
    {
        public ClientsDbContext CreateDbContext(string[] args)
        {
            var appSettingsPath = Environment.GetEnvironmentVariable("APPSETTINGS_PATH");

            var config = new ConfigurationBuilder()
                .AddJsonFile(appSettingsPath)
                .Build();

            var connectionString = config.GetConnectionString("DefaultConnection");

            var optionsBuilder = new DbContextOptionsBuilder<ClientsDbContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return new ClientsDbContext(optionsBuilder.Options);
        }
    }
}