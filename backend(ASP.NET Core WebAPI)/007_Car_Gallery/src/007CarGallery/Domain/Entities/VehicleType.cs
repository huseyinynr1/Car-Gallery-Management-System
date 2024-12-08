using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class VehicleType : Entity<int>
{
    public string Type { get; set; }

    public virtual ICollection<Car> Cars { get; set; }
    public virtual ICollection<MaintenanceRecord> MaintenanceRecords { get; set; }
    public virtual ICollection<MaintenancePlanningRecord> MaintenancePlanningRecords { get; set; }

    public VehicleType()
    {
        Cars = new HashSet<Car>();
        MaintenanceRecords = new HashSet<MaintenanceRecord>();
        MaintenancePlanningRecords = new HashSet<MaintenancePlanningRecord>();
    }

    
    public VehicleType(int id, string type)
    {
        Id = id;
        Type = type;
    }
}
