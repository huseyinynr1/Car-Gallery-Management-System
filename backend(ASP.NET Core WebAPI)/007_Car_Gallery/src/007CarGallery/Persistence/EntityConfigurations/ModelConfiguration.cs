using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class ModelConfiguration : IEntityTypeConfiguration<Model>
{
    public void Configure(EntityTypeBuilder<Model> builder)
    {
        builder.ToTable("Models").HasKey(m => m.Id);

        builder.Property(m => m.Id).HasColumnName("Id").IsRequired();
        builder.Property(m => m.Name).HasColumnName("Name");
        builder.Property(m => m.BrandId).HasColumnName("BrandId").IsRequired();
        builder.Property(m => m.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(m => m.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(m => m.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(m => !m.DeletedDate.HasValue);

        builder.HasOne(md => md.Brand)
             .WithMany(b => b.Models)
             .HasForeignKey(m => m.BrandId)
             .OnDelete(DeleteBehavior.NoAction);

        builder.HasMany(m => m.Cars)
               .WithOne(c => c.Model)
               .HasForeignKey(c => c.ModelId)
               .OnDelete(DeleteBehavior.NoAction);

        builder.HasMany(m => m.MaintenancePlanningRecords)
               .WithOne(mpr => mpr.Model)
               .HasForeignKey(mpr => mpr.ModelID)
               .OnDelete(DeleteBehavior.NoAction);

        builder.HasMany(m => m.MaintenanceRecords)
               .WithOne(mr => mr.Model)
               .HasForeignKey(mr => mr.ModelID)
               .OnDelete(DeleteBehavior.NoAction);

   
    }
}