using Application.Features.Auth.Constants;
using Application.Features.OperationClaims.Constants;
using Application.Features.UserOperationClaims.Constants;
using Application.Features.Users.Constants;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NArchitecture.Core.Security.Constants;
using Application.Features.Brands.Constants;
using Application.Features.Cars.Constants;
using Application.Features.CarStatus.Constants;
using Application.Features.CarStatusHistories.Constants;
using Application.Features.Fuels.Constants;
using Application.Features.MaintenancePlanningRecords.Constants;
using Application.Features.MaintenanceRecords.Constants;
using Application.Features.Models.Constants;
using Application.Features.Transmissions.Constants;
using Application.Features.MaintenanceStates.Constants;
using Application.Features.MaintenanceTypes.Constants;
using Application.Features.VehicleTypes.Constants;

namespace Persistence.EntityConfigurations;

public class OperationClaimConfiguration : IEntityTypeConfiguration<OperationClaim>
{
    public void Configure(EntityTypeBuilder<OperationClaim> builder)
    {
        builder.ToTable("OperationClaims").HasKey(oc => oc.Id);

        builder.Property(oc => oc.Id).HasColumnName("Id").IsRequired();
        builder.Property(oc => oc.Name).HasColumnName("Name").IsRequired();
        builder.Property(oc => oc.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(oc => oc.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(oc => oc.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(oc => !oc.DeletedDate.HasValue);

        builder.HasData(_seeds);

        builder.HasBaseType((string)null!);
    }

    public static int AdminId => 1;
    private IEnumerable<OperationClaim> _seeds
    {
        get
        {
            yield return new() { Id = AdminId, Name = GeneralOperationClaims.Admin };

            IEnumerable<OperationClaim> featureOperationClaims = getFeatureOperationClaims(AdminId);
            foreach (OperationClaim claim in featureOperationClaims)
                yield return claim;
        }
    }

#pragma warning disable S1854 // Unused assignments should be removed
    private IEnumerable<OperationClaim> getFeatureOperationClaims(int initialId)
    {
        int lastId = initialId;
        List<OperationClaim> featureOperationClaims = new();

        #region Auth
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = AuthOperationClaims.Admin },
                new() { Id = ++lastId, Name = AuthOperationClaims.Read },
                new() { Id = ++lastId, Name = AuthOperationClaims.Write },
                new() { Id = ++lastId, Name = AuthOperationClaims.RevokeToken },
            ]
        );
        #endregion

        #region OperationClaims
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = OperationClaimsOperationClaims.Admin },
                new() { Id = ++lastId, Name = OperationClaimsOperationClaims.Read },
                new() { Id = ++lastId, Name = OperationClaimsOperationClaims.Write },
                new() { Id = ++lastId, Name = OperationClaimsOperationClaims.Create },
                new() { Id = ++lastId, Name = OperationClaimsOperationClaims.Update },
                new() { Id = ++lastId, Name = OperationClaimsOperationClaims.Delete },
            ]
        );
        #endregion

        #region UserOperationClaims
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = UserOperationClaimsOperationClaims.Admin },
                new() { Id = ++lastId, Name = UserOperationClaimsOperationClaims.Read },
                new() { Id = ++lastId, Name = UserOperationClaimsOperationClaims.Write },
                new() { Id = ++lastId, Name = UserOperationClaimsOperationClaims.Create },
                new() { Id = ++lastId, Name = UserOperationClaimsOperationClaims.Update },
                new() { Id = ++lastId, Name = UserOperationClaimsOperationClaims.Delete },
            ]
        );
        #endregion

        #region Users
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = UsersOperationClaims.Admin },
                new() { Id = ++lastId, Name = UsersOperationClaims.Read },
                new() { Id = ++lastId, Name = UsersOperationClaims.Write },
                new() { Id = ++lastId, Name = UsersOperationClaims.Create },
                new() { Id = ++lastId, Name = UsersOperationClaims.Update },
                new() { Id = ++lastId, Name = UsersOperationClaims.Delete },
            ]
        );
        #endregion

        
        #region Brands
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = BrandsOperationClaims.Admin },
                new() { Id = ++lastId, Name = BrandsOperationClaims.Read },
                new() { Id = ++lastId, Name = BrandsOperationClaims.Write },
                new() { Id = ++lastId, Name = BrandsOperationClaims.Create },
                new() { Id = ++lastId, Name = BrandsOperationClaims.Update },
                new() { Id = ++lastId, Name = BrandsOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region Brands
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = BrandsOperationClaims.Admin },
                new() { Id = ++lastId, Name = BrandsOperationClaims.Read },
                new() { Id = ++lastId, Name = BrandsOperationClaims.Write },
                new() { Id = ++lastId, Name = BrandsOperationClaims.Create },
                new() { Id = ++lastId, Name = BrandsOperationClaims.Update },
                new() { Id = ++lastId, Name = BrandsOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region Cars
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = CarsOperationClaims.Admin },
                new() { Id = ++lastId, Name = CarsOperationClaims.Read },
                new() { Id = ++lastId, Name = CarsOperationClaims.Write },
                new() { Id = ++lastId, Name = CarsOperationClaims.Create },
                new() { Id = ++lastId, Name = CarsOperationClaims.Update },
                new() { Id = ++lastId, Name = CarsOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region CarStatus
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = CarStatusOperationClaims.Admin },
                new() { Id = ++lastId, Name = CarStatusOperationClaims.Read },
                new() { Id = ++lastId, Name = CarStatusOperationClaims.Write },
                new() { Id = ++lastId, Name = CarStatusOperationClaims.Create },
                new() { Id = ++lastId, Name = CarStatusOperationClaims.Update },
                new() { Id = ++lastId, Name = CarStatusOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region CarStatusHistories
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = CarStatusHistoriesOperationClaims.Admin },
                new() { Id = ++lastId, Name = CarStatusHistoriesOperationClaims.Read },
                new() { Id = ++lastId, Name = CarStatusHistoriesOperationClaims.Write },
                new() { Id = ++lastId, Name = CarStatusHistoriesOperationClaims.Create },
                new() { Id = ++lastId, Name = CarStatusHistoriesOperationClaims.Update },
                new() { Id = ++lastId, Name = CarStatusHistoriesOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region Fuels
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = FuelsOperationClaims.Admin },
                new() { Id = ++lastId, Name = FuelsOperationClaims.Read },
                new() { Id = ++lastId, Name = FuelsOperationClaims.Write },
                new() { Id = ++lastId, Name = FuelsOperationClaims.Create },
                new() { Id = ++lastId, Name = FuelsOperationClaims.Update },
                new() { Id = ++lastId, Name = FuelsOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region MaintenancePlanningRecords
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = MaintenancePlanningRecordsOperationClaims.Admin },
                new() { Id = ++lastId, Name = MaintenancePlanningRecordsOperationClaims.Read },
                new() { Id = ++lastId, Name = MaintenancePlanningRecordsOperationClaims.Write },
                new() { Id = ++lastId, Name = MaintenancePlanningRecordsOperationClaims.Create },
                new() { Id = ++lastId, Name = MaintenancePlanningRecordsOperationClaims.Update },
                new() { Id = ++lastId, Name = MaintenancePlanningRecordsOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region MaintenanceRecords
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = MaintenanceRecordsOperationClaims.Admin },
                new() { Id = ++lastId, Name = MaintenanceRecordsOperationClaims.Read },
                new() { Id = ++lastId, Name = MaintenanceRecordsOperationClaims.Write },
                new() { Id = ++lastId, Name = MaintenanceRecordsOperationClaims.Create },
                new() { Id = ++lastId, Name = MaintenanceRecordsOperationClaims.Update },
                new() { Id = ++lastId, Name = MaintenanceRecordsOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region Models
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = ModelsOperationClaims.Admin },
                new() { Id = ++lastId, Name = ModelsOperationClaims.Read },
                new() { Id = ++lastId, Name = ModelsOperationClaims.Write },
                new() { Id = ++lastId, Name = ModelsOperationClaims.Create },
                new() { Id = ++lastId, Name = ModelsOperationClaims.Update },
                new() { Id = ++lastId, Name = ModelsOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region Transmissions
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = TransmissionsOperationClaims.Admin },
                new() { Id = ++lastId, Name = TransmissionsOperationClaims.Read },
                new() { Id = ++lastId, Name = TransmissionsOperationClaims.Write },
                new() { Id = ++lastId, Name = TransmissionsOperationClaims.Create },
                new() { Id = ++lastId, Name = TransmissionsOperationClaims.Update },
                new() { Id = ++lastId, Name = TransmissionsOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region MaintenanceStates
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = MaintenanceStatesOperationClaims.Admin },
                new() { Id = ++lastId, Name = MaintenanceStatesOperationClaims.Read },
                new() { Id = ++lastId, Name = MaintenanceStatesOperationClaims.Write },
                new() { Id = ++lastId, Name = MaintenanceStatesOperationClaims.Create },
                new() { Id = ++lastId, Name = MaintenanceStatesOperationClaims.Update },
                new() { Id = ++lastId, Name = MaintenanceStatesOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region MaintenanceTypes
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = MaintenanceTypesOperationClaims.Admin },
                new() { Id = ++lastId, Name = MaintenanceTypesOperationClaims.Read },
                new() { Id = ++lastId, Name = MaintenanceTypesOperationClaims.Write },
                new() { Id = ++lastId, Name = MaintenanceTypesOperationClaims.Create },
                new() { Id = ++lastId, Name = MaintenanceTypesOperationClaims.Update },
                new() { Id = ++lastId, Name = MaintenanceTypesOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region VehicleTypes
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = VehicleTypesOperationClaims.Admin },
                new() { Id = ++lastId, Name = VehicleTypesOperationClaims.Read },
                new() { Id = ++lastId, Name = VehicleTypesOperationClaims.Write },
                new() { Id = ++lastId, Name = VehicleTypesOperationClaims.Create },
                new() { Id = ++lastId, Name = VehicleTypesOperationClaims.Update },
                new() { Id = ++lastId, Name = VehicleTypesOperationClaims.Delete },
            ]
        );
        #endregion
        
        return featureOperationClaims;
    }
#pragma warning restore S1854 // Unused assignments should be removed
}
