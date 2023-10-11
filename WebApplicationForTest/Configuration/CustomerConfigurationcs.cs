using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationForTest.Model;

namespace WebApplicationForTest.Configuration
{
    public class CustomerConfigurationcs : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(c => c.Id);
            builder.HasIndex(c => c.Id).IsUnique();
            builder.Property(c => c.Name).IsRequired().HasMaxLength(250);

            builder.HasMany<BusinessLocation>(b => b.BusinessLocations);
        }
    }
}
