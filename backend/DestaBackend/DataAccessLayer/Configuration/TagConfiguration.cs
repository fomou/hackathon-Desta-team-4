using DestaNationConnect.DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DestaNationConnect.DataAccessLayer.Configuration
{
    public class TagConfiguration : IEntityTypeConfiguration<Tag>
    {
        public void Configure(EntityTypeBuilder<Tag> builder)
        {
            builder.ToTable("Tag");
            builder.Property(s => s.Name).IsRequired(false);

            builder.HasData(
                 new Tag{ TagTypeId= 1, Name= "Volunteering"              ,Description =  "Interest WHY tag about .......", CreationDate = DateTime.UtcNow},
	             new Tag{ TagTypeId= 1, Name= "Work opportunities"        ,Description =  "Interest WHY tag about .......", CreationDate = DateTime.UtcNow},	
	             new Tag{ TagTypeId= 1, Name= "Community Event"           ,Description =  "Interest WHY tag about .......", CreationDate = DateTime.UtcNow},
	             new Tag{ TagTypeId= 1, Name= "Promotion / Sale"          ,Description =  "Interest WHY tag about .......", CreationDate = DateTime.UtcNow},
 	             new Tag{ TagTypeId= 2, Name= "Automotive"                ,Description =  "Descriptive WHAT tag about ...", CreationDate = DateTime.UtcNow},
 	             new Tag{ TagTypeId= 2, Name= "Business Services"         ,Description =  "Descriptive WHAT tag about ...", CreationDate = DateTime.UtcNow},
 	             new Tag{ TagTypeId= 2, Name= "Computers & Electronics"   ,Description =  "Descriptive WHAT tag about ...", CreationDate = DateTime.UtcNow},
 	             new Tag{ TagTypeId= 2, Name= "Construction & Contractors",Description =  "Descriptive WHAT tag about ...", CreationDate = DateTime.UtcNow},
 	             new Tag{ TagTypeId= 2, Name= "Education"                 ,Description =  "Descriptive WHAT tag about ...", CreationDate = DateTime.UtcNow},
 	             new Tag{ TagTypeId= 2, Name= "Entertainment"             ,Description =  "Descriptive WHAT tag about ...", CreationDate = DateTime.UtcNow},
 	             new Tag{ TagTypeId= 2, Name= "Food & Dining"             ,Description =  "Descriptive WHAT tag about ...", CreationDate = DateTime.UtcNow},
 	             new Tag{ TagTypeId= 2, Name= "Health & Lifestyle"        ,Description =  "Descriptive WHAT tag about ...", CreationDate = DateTime.UtcNow},
 	             new Tag{ TagTypeId= 2, Name= "Home & Garden"             ,Description =  "Descriptive WHAT tag about ...", CreationDate = DateTime.UtcNow},
                 new Tag{ TagTypeId = 2,Name= "Legal & Financial"         ,Description =  "Descriptive WHAT tag about ...", CreationDate = DateTime.UtcNow }
                );
        }
    }
}
