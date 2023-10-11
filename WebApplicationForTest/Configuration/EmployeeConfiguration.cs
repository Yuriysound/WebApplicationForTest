using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationForTest.Model;

namespace WebApplicationForTest.Configuration
{
    public class EmployeeConfigurationIEntityTypeConfiguration<BusinessLocation>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasKey(e => e.Id);
            builder.HasIndex(e => e.Id).IsUnique();
            builder.Property(e => e.LastName).IsRequired().HasMaxLength(250);
        }
    }
}
