using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class MaintenanceRecordConfiguration : IEntityTypeConfiguration<MaintenanceRecord>
{
    public void Configure(EntityTypeBuilder<MaintenanceRecord> builder)
    {
        builder.ToTable("MaintenanceRecords").HasKey(mr => mr.Id);

        builder.Property(mr => mr.Id).HasColumnName("Id").IsRequired();
        builder.Property(mr => mr.CarID).HasColumnName("CarId");
        builder.Property(mr => mr.BrandID).HasColumnName("BrandId");
        builder.Property(mr => mr.ModelID).HasColumnName("ModelId");
        builder.Property(mr => mr.TypeID).HasColumnName("TypeID");
        builder.Property(mr => mr.MaintenanceStateID).HasColumnName("MaintenanceStateId");
        builder.Property(mr => mr.MaintenanceTypeID).HasColumnName("MaintenanceTypeId");
        builder.Property(mr => mr.ChassisNo).HasColumnName("ChassisNo");
        builder.Property(mr => mr.Plate).HasColumnName("Plate");
        builder.Property(mr => mr.Description).HasColumnName("Description");
        builder.Property(mr => mr.StartDate).HasColumnName("StartDate");
        builder.Property(mr => mr.EndDate).HasColumnName("EndDate");
        builder.Property(mr => mr.ComponentCost).HasColumnName("ComponentCost");
        builder.Property(mr => mr.WorkmanshipCost).HasColumnName("WorkmanshipCost");
        builder.Property(mr => mr.DealPrice).HasColumnName("DealPrice");
        builder.Property(mr => mr.ElapsedTime).HasColumnName("ElapsedTime");
        builder.Property(mr => mr.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(mr => mr.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(mr => mr.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(mr => !mr.DeletedDate.HasValue);

        builder.HasOne(mr => mr.Car).WithMany(c => c.MaintenanceRecords).HasForeignKey(mr => mr.CarID).OnDelete(DeleteBehavior.NoAction);
        builder.HasOne(mr => mr.Brand).WithMany(b => b.MaintenanceRecords).HasForeignKey(mr => mr.BrandID).OnDelete(DeleteBehavior.NoAction);
        builder.HasOne(mr => mr.Model).WithMany(m => m.MaintenanceRecords).HasForeignKey(mr => mr.ModelID).OnDelete(DeleteBehavior.NoAction);
        builder.HasOne(mr => mr.MaintenanceState).WithMany(ms => ms.MaintenanceRecords).HasForeignKey(mr => mr.MaintenanceStateID).OnDelete(DeleteBehavior.NoAction);
        builder.HasOne(mr => mr.MaintenanceType).WithMany(mt => mt.MaintenanceRecords).HasForeignKey(mr => mr.MaintenanceTypeID).OnDelete(DeleteBehavior.NoAction);
        builder.HasOne(mr => mr.Type).WithMany(vt => vt.MaintenanceRecords).HasForeignKey(mr => mr.TypeID).OnDelete(DeleteBehavior.NoAction);

    }
}