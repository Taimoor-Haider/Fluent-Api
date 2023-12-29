using FluentAPI.Entity_Configuration;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace FluentAPI
{
    public partial class PlutoContext : DbContext
    {
        public PlutoContext()
            : base("name=PlutoContext")
        {
        }

        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Cours> Courses { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }
        public virtual DbSet<Cover> Covers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Configurations.Add(new CourseConfiguration());
        }
    }
}
