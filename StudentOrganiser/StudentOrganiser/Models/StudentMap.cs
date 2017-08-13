using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace StudentOrganiser.Models
{
    public class StudentMap : EntityTypeConfiguration<Student>

    {
        public StudentMap()
        {
            // Primary Key
            this.HasKey(t => t.StudentId);

            // Table & Column Mappings
            this.ToTable("Student");
            this.Property(t => t.StudentId).HasColumnName("StudentId").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(t => t.FirstName).HasColumnName("FirstName").IsRequired().HasMaxLength(32);
            this.Property(t => t.LastName).HasColumnName("LastName").IsRequired().HasMaxLength(32);
            this.Property(t => t.Birthday).HasColumnName("Birthday").IsRequired();
            this.Property(t => t.Email).HasColumnName("Email").IsRequired().HasMaxLength(32);
            this.Property(t => t.Faculty).HasColumnName("Faculty").IsRequired().HasMaxLength(32);
            this.Property(t => t.FacultyStart).HasColumnName("FacultyStart").IsRequired();
            this.Property(t => t.PhoneNumber).HasColumnName("PhoneNumber").IsRequired().HasMaxLength(32);
            this.Property(t => t.Gender).HasColumnName("Gender").IsRequired().HasMaxLength(32);


        }
    }
}