using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class CarStatusConfiguration : IEntityTypeConfiguration<CarStatusEntity>
{
    public void Configure(EntityTypeBuilder<CarStatusEntity> builder)
    {
        builder.ToTable("CarStatus").HasKey(cs => cs.Id);

        builder.Property(cs => cs.Id).HasColumnName("Id").IsRequired();
        builder.Property(cs => cs.Status).HasColumnName("Status");
        builder.Property(cs => cs.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(cs => cs.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(cs => cs.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(cs => !cs.DeletedDate.HasValue);

        builder.HasMany(cs => cs.Cars)
        .WithOne(c => c.CarStatus)
        .HasForeignKey(c => c.StatusId)
        .OnDelete(DeleteBehavior.NoAction);

        builder.HasMany(cs => cs.CarStatusHistories)
        .WithOne(csh => csh.CarStatus)
        .HasForeignKey(csh => csh.CarStatusId)
        .OnDelete(DeleteBehavior.NoAction);
    }
}