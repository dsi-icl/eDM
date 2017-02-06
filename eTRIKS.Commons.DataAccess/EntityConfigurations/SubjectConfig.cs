using eTRIKS.Commons.Core.Domain.Model;
using eTRIKS.Commons.DataAccess.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eTRIKS.Commons.DataAccess.EntityConfigurations
{
    public class SubjectConfig : EntityTypeConfiguration<HumanSubject>
    {
        public override void Configure(EntityTypeBuilder<HumanSubject> builder)
        {
            // Primary Key
            builder.HasKey(t => t.Id);
            builder.ToTable("Subjects");
            builder.Property(t => t.Id).HasColumnName("SubjectDBId");

            // Relationships
            builder.HasOne(t => t.StudyArm)
                .WithOne()
                .HasForeignKey<HumanSubject>(t => t.StudyArmId);

            builder.HasOne(t => t.Study)
               .WithMany(s=>s.Subjects)
               .IsRequired()
               .HasForeignKey(t => t.StudyId);

            builder.HasOne(t => t.Dataset)
               .WithOne()
               .IsRequired()
               .HasForeignKey<HumanSubject>(t => t.DatasetId);
        }
    }
}
