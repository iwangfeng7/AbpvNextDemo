using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Volo.Abp.EntityFrameworkCore;

namespace wf.abp.EntityFrameworkCore.DbMigrations
{
    public class ProductsMigrationsDbContext : AbpDbContext<ProductsMigrationsDbContext>
    {
        public ProductsMigrationsDbContext(DbContextOptions<ProductsMigrationsDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ConfigureBookStore();
        }
    }

    public class ProductsMigrationsDbContextFactory : IDesignTimeDbContextFactory<ProductsMigrationsDbContext>
    {
        public ProductsMigrationsDbContext CreateDbContext(string[] args)
        {
            var configuration = BuildConfiguration();

            var builder = new DbContextOptionsBuilder<ProductsMigrationsDbContext>()
                .UseMySql(configuration.GetConnectionString("Default"));

            return new ProductsMigrationsDbContext(builder.Options);
        }

        private static IConfigurationRoot BuildConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../wf.abp.WebApi/"))
                .AddJsonFile("appsettings.json", optional: false);

            return builder.Build();
        }
    }
}