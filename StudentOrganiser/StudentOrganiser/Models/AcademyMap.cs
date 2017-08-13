using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace StudentOrganiser.Models
{
    public class AcademyMap : EntityTypeConfiguration<Academy>
    {
        public AcademyMap()
        {
            // Primary Key
            this.HasKey(t => t.AcademyId);

            // Table & Column Mappings
            this.ToTable("Academy");
            this.Property(t => t.AcademyId).HasColumnName("AcademyId").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(t => t.Name).HasColumnName("Name").IsRequired().HasMaxLength(32);
            this.Property(t => t.Remarks).HasColumnName("Remarks").IsRequired().HasMaxLength(32);
            this.Property(t => t.Start).HasColumnName("Start").IsRequired();
            this.Property(t => t.Finish).HasColumnName("Finish").IsRequired();
            this.Property(t => t.Department).HasColumnName("Department").IsRequired().HasMaxLength(32);
            this.Property(t => t.Task).HasColumnName("Task").IsRequired().HasMaxLength(32);
        }
    }
}