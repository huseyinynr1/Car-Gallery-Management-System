using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class CarConfiguration : IEntityTypeConfiguration<Car>
{
    public void Configure(EntityTypeBuilder<Car> builder)
    {
        builder.ToTable("Cars").HasKey(c => c.Id);

        builder.Property(c => c.Id).HasColumnName("Id").IsRequired();
        builder.Property(c => c.BrandId).HasColumnName("BrandId");
        builder.Property(c => c.ModelId).HasColumnName("ModelId");
        builder.Property(c => c.TypeId).HasColumnName("TypeId");
        builder.Property(c => c.TransmissionId).HasColumnName("TransmissionId");
        builder.Property(c => c.FuelId).HasColumnName("FuelId");
        builder.Property(c => c.StatusId).HasColumnName("StatusId");
        builder.Property(c => c.ImageId).HasColumnName("ImageId");
        builder.Property(c => c.ChassisNo).HasColumnName("ChassisNo");
        builder.Property(c => c.Plate).HasColumnName("Plate");
        builder.Property(c => c.Kilometer).HasColumnName("Kilometer");
        builder.Property(c => c.Year).HasColumnName("Year");
        builder.Property(c => c.Price).HasColumnName("Price");
        builder.Property(c => c.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(c => c.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(c => c.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(c => !c.DeletedDate.HasValue);

        builder.HasOne(c => c.Brand)
     .WithMany(b => b.Cars)
     .HasForeignKey(c => c.BrandId)
     .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(c => c.Model)
               .WithMany(m => m.Cars)
               .HasForeignKey(c => c.ModelId)
               .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(c => c.Type)
               .WithMany(m => m.Cars)
               .HasForeignKey(c => c.TypeId)
               .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(c => c.Transmission)
               .WithMany(t => t.Cars)
               .HasForeignKey(c => c.TransmissionId)
               .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(c => c.Fuel)
               .WithMany(f => f.Cars)
               .HasForeignKey(c => c.FuelId)
               .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(c => c.CarStatus)
            .WithMany(cs => cs.Cars)
            .HasForeignKey(c => c.StatusId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasMany(c => c.CarStatusHistories)
            .WithOne(csh => csh.Car)
            .HasForeignKey(c => c.CarId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasMany(c => c.MaintenanceRecords)
               .WithOne(mr => mr.Car)
               .HasForeignKey(c => c.CarID)
               .OnDelete(DeleteBehavior.NoAction);

        builder.HasMany(c => c.MaintenancePlanningRecords)
               .WithOne(mpr => mpr.Car)
               .HasForeignKey(mpr => mpr.CarID)
               .OnDelete(DeleteBehavior.NoAction);
    }
}