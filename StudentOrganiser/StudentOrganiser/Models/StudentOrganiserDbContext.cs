using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace StudentOrganiser.Models
{
    public class StudentOrganiserDbContext : DbContext
    {

            static StudentOrganiserDbContext()
            {
                Database.SetInitializer<StudentOrganiserDbContext>(null);
            }

            public StudentOrganiserDbContext()
                : base("Name=StudentOrganiserDbContext")
            {
            }

            public DbSet<Academy> Academies { get; set; }

            public DbSet<Student> Students { get; set; }

            public DbSet<StudentAcademy> StudentAcademies { get; set; }

            protected override void OnModelCreating(DbModelBuilder modelBuilder)
            {
                base.OnModelCreating(modelBuilder);

                modelBuilder.Configurations.Add(new AcademyMap());
                modelBuilder.Configurations.Add(new StudentMap());
                modelBuilder.Configurations.Add(new StudentAcademyMap());
            }

        }
    
}