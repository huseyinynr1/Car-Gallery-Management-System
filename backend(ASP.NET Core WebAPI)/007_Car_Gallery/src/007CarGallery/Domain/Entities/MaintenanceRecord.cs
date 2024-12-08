using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class MaintenanceRecord : Entity<int>
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
    public int? ComponentCost { get; set; }
    public int? WorkmanshipCost { get; set; }
    public int? DealPrice { get; set; }
    public int? ElapsedTime { get; set; }
   

    public virtual Car? Car { get; set; }
    public virtual Brand? Brand { get; set; }
    public virtual Model? Model { get; set; }
    public virtual MaintenanceState? MaintenanceState { get; set; }
    public virtual MaintenanceType? MaintenanceType { get; set; }
    public virtual VehicleType? Type { get; set; }

    public MaintenanceRecord(int carID, int brandID, int modelID, int typeID, int maintenanceStateID, int maintenanceTypeID, string chassisNo, string plate, string? description, 
        DateTime? startDate, DateTime? endDate, int? componentCost, int? workmanshipCost, int? dealPrice, int? elapsedTime, Car? car, Brand? brand, Model? model, 
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
        ComponentCost = componentCost;
        WorkmanshipCost = workmanshipCost;
        DealPrice = dealPrice;
        ElapsedTime = elapsedTime;
        Car = car;
        Brand = brand;
        Model = model;
        MaintenanceState = maintenanceState;
        MaintenanceType = maintenanceType;
        Type = type;
    }

    public MaintenanceRecord()
    {
    }







}