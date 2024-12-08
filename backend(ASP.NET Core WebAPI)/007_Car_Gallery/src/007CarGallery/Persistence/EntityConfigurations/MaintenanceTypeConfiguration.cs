using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class MaintenanceTypeConfiguration : IEntityTypeConfiguration<MaintenanceType>
{
    public void Configure(EntityTypeBuilder<MaintenanceType> builder)
    {
        builder.ToTable("MaintenanceTypes").HasKey(mt => mt.Id);

        builder.Property(mt => mt.Id).HasColumnName("Id").IsRequired();
        builder.Property(mt => mt.Type).HasColumnName("Type");
        builder.Property(mt => mt.SortOrder).HasColumnName("SortOrder");
        builder.Property(mt => mt.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(mt => mt.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(mt => mt.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(mt => !mt.DeletedDate.HasValue);

        builder.HasMany(mt => mt.MaintenanceRecords)
            .WithOne(mr => mr.MaintenanceType)
            .HasForeignKey(mr => mr.MaintenanceTypeID)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasMany(ms => ms.MaintenancePlanningRecords)
            .WithOne(mpr => mpr.MaintenanceType)
            .HasForeignKey(mpr => mpr.MaintenanceTypeID)
            .OnDelete(DeleteBehavior.NoAction);
    }
}