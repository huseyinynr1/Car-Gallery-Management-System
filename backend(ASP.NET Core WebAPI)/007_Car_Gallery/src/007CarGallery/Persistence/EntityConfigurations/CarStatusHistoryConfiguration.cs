using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class CarStatusHistoryConfiguration : IEntityTypeConfiguration<CarStatusHistory>
{
    public void Configure(EntityTypeBuilder<CarStatusHistory> builder)
    {
        builder.ToTable("CarStatusHistories").HasKey(csh => csh.Id);

        builder.Property(csh => csh.Id).HasColumnName("Id").IsRequired();
        builder.Property(csh => csh.CarId).HasColumnName("CarId");
        builder.Property(csh => csh.CarStatusId).HasColumnName("CarStatusId");
        builder.Property(csh => csh.StatusChange).HasColumnName("StatusChange");
        builder.Property(csh => csh.Remark).HasColumnName("Remark");
        builder.Property(csh => csh.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(csh => csh.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(csh => csh.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(csh => !csh.DeletedDate.HasValue);

        builder.HasOne(csh => csh.Car)
      .WithMany(c => c.CarStatusHistories)
      .HasForeignKey(c => c.CarId)
      .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(csh => csh.CarStatus)
        .WithMany(cs => cs.CarStatusHistories)
        .HasForeignKey(c => c.CarStatusId)
        .OnDelete(DeleteBehavior.NoAction);
    }
}