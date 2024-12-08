using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class VehicleTypeConfiguration : IEntityTypeConfiguration<VehicleType>
{
    public void Configure(EntityTypeBuilder<VehicleType> builder)
    {
        builder.ToTable("VehicleTypes").HasKey(vt => vt.Id);

        builder.Property(vt => vt.Id).HasColumnName("Id").IsRequired();
        builder.Property(vt => vt.Type).HasColumnName("Type");
        builder.Property(vt => vt.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(vt => vt.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(vt => vt.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(vt => !vt.DeletedDate.HasValue);

        builder.HasMany(vt => vt.Cars)
               .WithOne(c => c.Type)
               .HasForeignKey(c => c.TypeId)
               .OnDelete(DeleteBehavior.NoAction);

        builder.HasMany(vt => vt.MaintenanceRecords)
               .WithOne(mr => mr.Type)
               .HasForeignKey(mpr => mpr.TypeID)
               .OnDelete(DeleteBehavior.NoAction);

        builder.HasMany(vt => vt.MaintenancePlanningRecords)
                .WithOne(mpr => mpr.Type)
                .HasForeignKey(mpr => mpr.TypeID)
                .OnDelete(DeleteBehavior.NoAction);
    }
}