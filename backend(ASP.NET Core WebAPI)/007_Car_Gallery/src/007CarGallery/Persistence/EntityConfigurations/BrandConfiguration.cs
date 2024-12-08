using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class BrandConfiguration : IEntityTypeConfiguration<Brand>
{
    public void Configure(EntityTypeBuilder<Brand> builder)
    {
        builder.ToTable("Brands").HasKey(b => b.Id);

        builder.Property(b => b.Id).HasColumnName("Id").IsRequired();
        builder.Property(b => b.Name).HasColumnName("Name");
        builder.Property(b => b.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(b => b.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(b => b.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(b => !b.DeletedDate.HasValue);

        builder.HasMany(b => b.Models)
              .WithOne(md => md.Brand)
              .HasForeignKey(m => m.BrandId)
              .OnDelete(DeleteBehavior.NoAction);

        builder.HasMany(b => b.Cars)
               .WithOne(c => c.Brand)
               .HasForeignKey(c => c.BrandId)
               .OnDelete(DeleteBehavior.NoAction);

        builder.HasMany(b => b.MaintenanceRecords)
              .WithOne(mr => mr.Brand)
              .HasForeignKey(mr => mr.BrandID)
              .OnDelete(DeleteBehavior.NoAction);

        builder.HasMany(b => b.MaintenancePlanningRecords)
              .WithOne(mpr => mpr.Brand)
              .HasForeignKey(mpr => mpr.BrandID)
              .OnDelete(DeleteBehavior.NoAction);
    }
}