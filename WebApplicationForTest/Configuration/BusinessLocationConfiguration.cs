using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationForTest.Model;

namespace WebApplicationForTest.Configuration
{
    public class BusinessLocationConfiguration : IEntityTypeConfiguration<BusinessLocation>
    {
        public void Configure(EntityTypeBuilder<BusinessLocation> builder)
        {
            builder.HasKey(b => b.Id);
            builder.HasIndex(b => b.Id).IsUnique();
            builder.Property(b => b.Name).IsRequired().HasMaxLength(250);
        }
    }
}
