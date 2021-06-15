using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SampleDatabaseApp.Model.Objects;
using System;
using System.IO;

namespace SampleDatabaseApp.Model
{
    public class SampleDatabaseContext : DbContext
    {
        public static IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
            .AddJsonFile("appsettings.json", false)
            .Build();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(configuration["ConnectionString"]);
        }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Order> Orders { get; set; }
    }
}
