using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using RescueRangers.API.Entities;

namespace Web
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<WebApiDbContext>
    {
        public WebApiDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<WebApiDbContext>();

            var connectionString = configuration["ConnectionStrings:DefaultConnection"];

            builder.UseSqlite(connectionString);

            return new WebApiDbContext(builder.Options);
        }
    }
}