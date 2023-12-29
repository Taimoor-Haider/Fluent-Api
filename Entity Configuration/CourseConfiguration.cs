using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentAPI.Entity_Configuration
{
    internal class CourseConfiguration : EntityTypeConfiguration<Cours>
    {
        public CourseConfiguration()
        {
            Property(c => c.Title).IsRequired().HasMaxLength(255);
            Property(c => c.Description).IsRequired().HasMaxLength(2000);

            HasRequired(c => c.Author).WithMany(a => a.Courses).HasForeignKey(a => a.AuthorID).WillCascadeOnDelete(false);
            HasMany(c => c.Tags).WithMany(t => t.Courses).Map(m =>
            {
                m.ToTable("CourseTags");
                m.MapLeftKey("CourseID");
                m.MapRightKey("TagID");
            });
            HasRequired(c => c.Cover).WithRequiredPrincipal(c => c.Cours);

            HasMany(e => e.Tags)
            .WithMany(e => e.Courses)
            .Map(m => m.ToTable("TagCourses").MapLeftKey("Course_Id"));
        }
    }
}
