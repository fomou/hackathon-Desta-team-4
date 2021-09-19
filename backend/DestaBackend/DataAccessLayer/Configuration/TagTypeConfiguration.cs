using DestaNationConnect.DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DestaNationConnect.DataAccessLayer.Configuration
{
    public class TagTypeConfiguration : IEntityTypeConfiguration<TagType>
    {
        public void Configure(EntityTypeBuilder<TagType> builder)
        {
            builder.ToTable("TagType");
            builder.Property(s => s.Name).IsRequired(true);

            builder.HasData(
                  new TagType { Name = "Why", Description = "Description of what is a WHY tag", CreationDate = DateTime.UtcNow },
                  new TagType { Name = "What", Description = "Description of what is a WHAT tag ", CreationDate = DateTime.UtcNow }
                );
        }
    }
}
