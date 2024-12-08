using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class MaintenancePlanningRecordConfiguration : IEntityTypeConfiguration<MaintenancePlanningRecord>
{
    public void Configure(EntityTypeBuilder<MaintenancePlanningRecord> builder)
    {
        builder.ToTable("MaintenancePlanningRecords").HasKey(mpr => mpr.Id);

        builder.Property(mpr => mpr.Id).HasColumnName("Id").IsRequired();
        builder.Property(mpr => mpr.CarID).HasColumnName("CarId");
        builder.Property(mpr => mpr.BrandID).HasColumnName("BrandId");
        builder.Property(mpr => mpr.ModelID).HasColumnName("ModelID");
        builder.Property(mr => mr.TypeID).HasColumnName("TypeID");
        builder.Property(mpr => mpr.MaintenanceStateID).HasColumnName("MaintenanceStateId");
        builder.Property(mpr => mpr.MaintenanceTypeID).HasColumnName("MaintenanceTypeId");
        builder.Property(mpr => mpr.ChassisNo).HasColumnName("ChassisNo");
        builder.Property(mpr => mpr.Plate).HasColumnName("Plate");
        builder.Property(mpr => mpr.Description).HasColumnName("Description");
        builder.Property(mpr => mpr.StartDate).HasColumnName("StartDate");
        builder.Property(mpr => mpr.EndDate).HasColumnName("EndDate");
        builder.Property(mpr => mpr.EstimatedElapsedTime).HasColumnName("EstimatedElapsedTime");
        builder.Property(mpr => mpr.EstimatedCost).HasColumnName("EstimatedCost");
        builder.Property(mpr => mpr.EstimatedComponentCost).HasColumnName("EstimatedComponentCost");
        builder.Property(mpr => mpr.EstimatedWorkmanshipCost).HasColumnName("EstimatedWorkmanshipCost");
        builder.Property(mpr => mpr.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(mpr => mpr.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(mpr => mpr.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(mpr => !mpr.DeletedDate.HasValue);

        builder.HasOne(mpr => mpr.Car)
            .WithMany(c => c.MaintenancePlanningRecords)
            .HasForeignKey(mpr => mpr.CarID)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(mpr => mpr.Brand)
            .WithMany(b => b.MaintenancePlanningRecords)
            .HasForeignKey(mpr => mpr.BrandID)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(mpr => mpr.Model)
               .WithMany(m => m.MaintenancePlanningRecords)
               .HasForeignKey(mpr => mpr.ModelID)
               .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(mpr => mpr.MaintenanceState)
            .WithMany(md => md.MaintenancePlanningRecords)
            .HasForeignKey(mpr => mpr.MaintenanceStateID)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(mpr => mpr.MaintenanceType)
            .WithMany(md => md.MaintenancePlanningRecords)
            .HasForeignKey(mpr => mpr.MaintenanceTypeID)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(mpr => mpr.Type)
            .WithMany(vt => vt.MaintenancePlanningRecords)
            .HasForeignKey(mpr => mpr.TypeID)
            .OnDelete(DeleteBehavior.NoAction);
    }
}