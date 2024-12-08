using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class Brand : Entity<int>
{
    public string Name { get; set; }

    public virtual ICollection<Model> Models { get; set; }//Bir markaya ait birden çok model var
    public virtual ICollection<Car>? Cars { get; set; }
    public virtual ICollection<MaintenanceRecord>? MaintenanceRecords { get; set; }
    public virtual ICollection<MaintenancePlanningRecord>? MaintenancePlanningRecords { get; set; }



    public Brand()
    {
        Models = new HashSet<Model>();
        Cars = new HashSet<Car>();
        MaintenanceRecords = new HashSet<MaintenanceRecord>();
        MaintenancePlanningRecords = new HashSet<MaintenancePlanningRecord>();


    }

    public Brand(int id, string name)
    {
        Id = id;
        Name = name;

    }

}