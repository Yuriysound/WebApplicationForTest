using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationForTest.Configuration;
using WebApplicationForTest.Model;

namespace WebApplicationForTest
{
    public class AppDBContexts : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<BusinessLocation> BusinessLocation { get; set; }

        public AppDBContexts(DbContextOptions<AppDBContexts> options) :
            base(options)
        { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new CustomerConfigurationcs());
            SeedInitialData(builder);
            base.OnModelCreating(builder);
        }

        void SeedInitialData(ModelBuilder builder)
        {

        }

    }
}
