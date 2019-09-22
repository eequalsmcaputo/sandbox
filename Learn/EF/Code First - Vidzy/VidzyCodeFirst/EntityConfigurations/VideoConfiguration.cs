using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.ModelConfiguration;

namespace VidzyCodeFirst.EntityConfigurations
{
    public class VideoConfiguration : EntityTypeConfiguration<Models.Video>
    {
        public VideoConfiguration()
        {
            Property(v => v.Name)
                .IsRequired()
                .HasMaxLength(255);

            HasRequired(v => v.Genre)
                .WithMany(g => g.Videos)
                .HasForeignKey(v => v.GenreId);

            HasMany(v => v.Tags)
                .WithMany(t => t.Videos)
                .Map(m => {
                    m.ToTable("VideoTags");
                    m.MapLeftKey("VideoId");
                    m.MapRightKey("TagId");
                });
        }
    }
}