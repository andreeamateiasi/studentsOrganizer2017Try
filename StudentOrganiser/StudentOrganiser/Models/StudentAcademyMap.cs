using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace StudentOrganiser.Models
{
    public class StudentAcademyMap : EntityTypeConfiguration<StudentAcademy>
    {
        public StudentAcademyMap()
        {
            this.HasKey(t => t.StudentId);

            // Table & Column Mappings
            this.ToTable("StudentAcademy");
            this.Property(t => t.Id).HasColumnName("Id").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(t => t.AcademyId).HasColumnName("AcademyId").IsRequired();
            this.Property(t => t.StudentId).HasColumnName("StudentId").IsRequired();




            DbModelBuilder modelBuilder = new DbModelBuilder();


            modelBuilder.Entity<Student>()
                        .HasMany<Academy>(s => s.Academies)
                        .WithMany(c => c.Students)
                        .Map(cs =>
                        {
                            cs.MapLeftKey("StudentId");
                            cs.MapRightKey("AcademyId");
                            cs.ToTable("StudentAcademy");
                        });



        }  
    
    }
}