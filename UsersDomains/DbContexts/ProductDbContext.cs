using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using UsersDomains.Entities;

namespace ProductsDomain.DbContexts;

public class ProductDbContext : DbContext
{

    /* 
    * once everything is done run these following commands
    * dotnet ef migrations add productos_first_migration --context ProductDbContext
    * dotnet ef database update --context ProductDbContext
    */
    public ProductDbContext( DbContextOptions<ProductDbContext> options )
        : base(options)
    {}
    
    public DbSet<Product> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>().ToTable("Products", "TutorialAppSchema");
        base.OnModelCreating(modelBuilder);
    }
}

public class ProductDbContextFactory : IDesignTimeDbContextFactory<ProductDbContext>
{
    public ProductDbContext CreateDbContext(string[] args)
    {
        IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "..", "ProductsAPI"))
            .AddJsonFile("appsettings.json")
            .Build();

        var connectionString = configuration.GetConnectionString("DefaultConnection");

        var optionsBuilder = new DbContextOptionsBuilder<ProductDbContext>();

        optionsBuilder.UseSqlServer(connectionString);

        return new ProductDbContext(optionsBuilder.Options);
    }
}