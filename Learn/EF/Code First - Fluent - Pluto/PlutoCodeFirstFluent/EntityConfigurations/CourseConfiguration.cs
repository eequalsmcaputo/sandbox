using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.ModelConfiguration;

namespace PlutoCodeFirstFluent.EntityConfigurations
{
    public class CourseConfiguration : EntityTypeConfiguration<Models.Course>
    {
        public CourseConfiguration()
        {
            ToTable("Course");

            HasKey(c => c.Id);

            Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(255);

            Property(c => c.Description)
                .IsRequired()
                .HasMaxLength(2000);

            HasMany(e => e.Tags)
                .WithMany(e => e.Courses)
                .Map(m => m.ToTable("CourseTags").MapLeftKey("CourseId")
                    .MapRightKey("TagId"));

            HasRequired(c => c.Author)
                .WithMany(a => a.Courses)
                .HasForeignKey(c => c.AuthorId)
                .WillCascadeOnDelete(false);

            HasRequired(c => c.Cover)
                .WithRequiredPrincipal(c => c.Course);
        }

    }
}