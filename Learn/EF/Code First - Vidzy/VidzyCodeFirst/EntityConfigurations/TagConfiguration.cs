using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.ModelConfiguration;

namespace VidzyCodeFirst.EntityConfigurations
{
    public class TagConfiguration : EntityTypeConfiguration<Models.Tag>
    {
        public TagConfiguration()
        {
            Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(255);
        }
    }
}