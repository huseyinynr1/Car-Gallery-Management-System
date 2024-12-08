using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Domain.Entities;
public class Car : Entity<int>
{
    public int BrandId { get; set; }
    public int ModelId { get; set; }
    public int TypeId { get; set; }
    public int TransmissionId { get; set; }
    public int FuelId { get; set; }
    public int? StatusId { get; set; }
    public int? ImageId { get; set; }
    public string ChassisNo { get; set; }
    public string Plate { get; set; }
    public int Kilometer { get; set; }
    public int Year { get; set; }
    public double Price { get; set; }


    public virtual Brand? Brand { get; set; }
    public virtual Transmission? Transmission { get; set; }
    public virtual Fuel? Fuel { get; set; }
    public virtual Model? Model { get; set; }
    public virtual VehicleType? Type { get; set; }
    public virtual CarStatusEntity? CarStatus { get; set; }
    public virtual ICollection<MaintenanceRecord>? MaintenanceRecords { get; set; }
    public virtual ICollection<MaintenancePlanningRecord>? MaintenancePlanningRecords { get; set; }
    public virtual ICollection<CarStatusHistory>? CarStatusHistories { get; set; }

    public Car(int brandId, int modelId, int typeId, int transmissionId, int fuelId, int? statusId, int? ımageId, string chassisNo, string plate, int kilometer, int year, double price, 
        Brand? brand, Transmission? transmission, Fuel? fuel, Model? model, CarStatusEntity? carStatus, VehicleType? type)
    {
        BrandId = brandId;
        ModelId = modelId;
        TypeId = typeId;
        TransmissionId = transmissionId;
        FuelId = fuelId;
        StatusId = statusId;
        ImageId = ımageId;
        ChassisNo = chassisNo;
        Plate = plate;
        Kilometer = kilometer;
        Year = year;
        Price = price;
        Brand = brand;
        Transmission = transmission;
        Fuel = fuel;
        Model = model;
        Type = type;
        CarStatus = carStatus;
        Type = type;
    }

    public Car()
    {
        MaintenanceRecords = new HashSet<MaintenanceRecord>();
        MaintenancePlanningRecords = new HashSet<MaintenancePlanningRecord>();
        CarStatusHistories = new HashSet<CarStatusHistory>();
    }


}//Kullanım kolaylıkalrı sağlamak içim