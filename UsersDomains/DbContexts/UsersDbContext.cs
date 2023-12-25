using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using UsersModels.Models;

namespace UsersDomains.DbContexts
{
    /*$env:APPSETTINGS_PATH="C:\Users\ChristianGarciaMarti\Desktop\dotnet\api\UsersProject\UsersApi\appsettings.json"; dotnet ef migrations add InitialCreate --context ClientsDbContext*/
    /*$env:APPSETTINGS_PATH="C:\Users\ChristianGarciaMarti\Desktop\dotnet\api\UsersProject\UsersApi\appsettings.json"; dotnet ef database update --context ClientsDbContext*/
    public class UsersDbContext : DbContext
    {
        public UsersDbContext(DbContextOptions<UsersDbContext> options)
            : base(options)
        { }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("Users", "TutorialAppSchema");
            base.OnModelCreating(modelBuilder);
        }
    }

    public class UsersDbContextFactory : IDesignTimeDbContextFactory<UsersDbContext>
    {
        public UsersDbContext CreateDbContext(string[] args)
        {
            var appSettingsPath = Environment.GetEnvironmentVariable("APPSETTINGS_PATH");

            var config = new ConfigurationBuilder()
                .AddJsonFile(appSettingsPath)
                .Build();

            var connectionString = config.GetConnectionString("DefaultConnection");

            var optionsBuilder = new DbContextOptionsBuilder<UsersDbContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return new UsersDbContext(optionsBuilder.Options);
        }
    }
}