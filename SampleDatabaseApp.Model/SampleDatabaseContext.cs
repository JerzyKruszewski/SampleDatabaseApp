using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SampleDatabaseApp.Model.Objects;
using System;
using System.IO;

namespace SampleDatabaseApp.Model
{
    public class SampleDatabaseContext : DbContext
    {
        private static IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
            .AddJsonFile("appsettings.json", false)
            .Build();

        private static SampleDatabaseContext _context;

        public SampleDatabaseContext()
        {

        }

        public SampleDatabaseContext(DbContextOptions<SampleDatabaseContext> options)
            : base(options)
        {

        }

        public static SampleDatabaseContext GetSampleDatabaseContext()
        {
            if (_context is null)
            {
                _context = new SampleDatabaseContext();
            }

            return _context;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(configuration["ConnectionString"]);
        }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Order> Orders { get; set; }
    }
}
