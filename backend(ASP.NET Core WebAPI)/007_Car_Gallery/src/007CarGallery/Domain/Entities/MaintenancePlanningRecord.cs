using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class MaintenancePlanningRecord : Entity<int>
{
    public int CarID { get; set; }
    public int BrandID { get; set; }
    public int ModelID { get; set; }
    public int TypeID { get; set; }
    public int MaintenanceStateID { get; set; }
    public int MaintenanceTypeID { get; set; }
    public string ChassisNo { get; set; }
    public string Plate { get; set; }
    public string? Description { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public int? EstimatedElapsedTime { get; set; }
    public int? EstimatedCost { get; set; }
    public int? EstimatedComponentCost { get; set; }
    public int? EstimatedWorkmanshipCost { get; set; }




    public virtual Car? Car { get; set; }
    public virtual Brand? Brand { get; set; }
    public virtual Model? Model { get; set; }
    public virtual MaintenanceState? MaintenanceState { get; set; }
    public virtual MaintenanceType? MaintenanceType { get; set; }
    public virtual VehicleType? Type { get; set; }

    public MaintenancePlanningRecord(int carID, int brandID, int modelID, int typeID, int maintenanceStateID, int maintenanceTypeID, string chassisNo, string plate, string? description, 
        DateTime? startDate, DateTime? endDate, int? estimatedElapsedTime, int? estimatedCost, int? estimatedComponentCost, int? estimatedWorkmanshipCost, Car? car, Brand? brand, Model? model, 
        MaintenanceState? maintenanceState, MaintenanceType? maintenanceType, VehicleType? type)
    {
        CarID = carID;
        BrandID = brandID;
        ModelID = modelID;
        TypeID = typeID;
        MaintenanceStateID = maintenanceStateID;
        MaintenanceTypeID = maintenanceTypeID;
        ChassisNo = chassisNo;
        Plate = plate;
        Description = description;
        StartDate = startDate;
        EndDate = endDate;
        EstimatedElapsedTime = estimatedElapsedTime;
        EstimatedCost = estimatedCost;
        EstimatedComponentCost = estimatedComponentCost;
        EstimatedWorkmanshipCost = estimatedWorkmanshipCost;
        Car = car;
        Brand = brand;
        Model = model;
        MaintenanceState = maintenanceState;
        MaintenanceType = maintenanceType;
        Type = type;
    }

    public MaintenancePlanningRecord()
    {

    }


   


}