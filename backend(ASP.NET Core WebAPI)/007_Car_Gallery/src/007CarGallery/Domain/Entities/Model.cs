using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class Model : Entity<int>
{
    public string Name { get; set; }
    public int BrandId { get; set; }

    public virtual Brand? Brand { get; set; }
    public ICollection<Car>? Cars { get; set; }
    public ICollection<MaintenanceRecord>? MaintenanceRecords { get; set; }
    public ICollection<MaintenancePlanningRecord>? MaintenancePlanningRecords { get; set; }

    public Model()
    {
        Cars = new HashSet<Car>();
        MaintenanceRecords = new HashSet<MaintenanceRecord>();
        MaintenancePlanningRecords = new HashSet<MaintenancePlanningRecord>();
    }

    public Model(int id, string name, int brandId)
    {
        Id = id;
        Name = name;
        BrandId = brandId;
    }
}