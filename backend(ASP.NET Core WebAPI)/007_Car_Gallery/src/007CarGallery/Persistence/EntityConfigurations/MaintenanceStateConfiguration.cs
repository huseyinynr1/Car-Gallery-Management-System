using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class MaintenanceStateConfiguration : IEntityTypeConfiguration<MaintenanceState>
{
    public void Configure(EntityTypeBuilder<MaintenanceState> builder)
    {
        builder.ToTable("MaintenanceStates").HasKey(ms => ms.Id);

        builder.Property(ms => ms.Id).HasColumnName("Id").IsRequired();
        builder.Property(ms => ms.State).HasColumnName("State");
        builder.Property(ms => ms.SortOrder).HasColumnName("SortOrder");
        builder.Property(ms => ms.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(ms => ms.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(ms => ms.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(ms => !ms.DeletedDate.HasValue);

        builder.HasMany(ms => ms.MaintenanceRecords)
            .WithOne(mr => mr.MaintenanceState)
            .HasForeignKey(mr => mr.MaintenanceStateID)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasMany(ms => ms.MaintenancePlanningRecords)
            .WithOne(mpr => mpr.MaintenanceState)
            .HasForeignKey(mpr => mpr.MaintenanceStateID)
            .OnDelete(DeleteBehavior.NoAction);
    }
}