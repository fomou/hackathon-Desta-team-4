using DestaNationConnect.DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DestaNationConnect.DataAccessLayer.Configuration
{
    public class TagPurposeConfiguration : IEntityTypeConfiguration<TagPurpose>
    {
        public void Configure(EntityTypeBuilder<TagPurpose> builder)
        {
            builder.ToTable("TagPurpose");
            builder.Property(s => s.Name).IsRequired(true);

            builder.HasData(
                  new TagPurpose { Name = "Interest",    Description = "Description de what is a tag of type Interest", CreationDate = DateTime.UtcNow },
                  new TagPurpose { Name = "Descriptive", Description = "Description de what is a tag of type Descriptive", CreationDate = DateTime.UtcNow }
                );
        }
    }
}
