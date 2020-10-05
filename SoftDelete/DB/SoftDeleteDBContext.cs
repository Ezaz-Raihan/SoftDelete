using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using SoftDelete.Models;

namespace SoftDelete.DB
{
    public class SoftDeleteDBContext : DbContext
    {

        public SoftDeleteDBContext() : base("SoftDeleteDBContext")
        {
            //Database.SetInitializer<SoftDeleteDBContext>(new CreateDatabaseIfNotExists<SoftDeleteDBContext>());
            //Database.SetInitializer<SoftDeleteDBContext>(null);
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Course> Courses { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            var conv = new AttributeToTableAnnotationConvention<SoftDeleteAttribute, string>(
                "SoftDeleteColumnName",
                (type, attributes) => attributes.Single().ColumnName);

            modelBuilder.Conventions.Add(conv);
        }
    }
}