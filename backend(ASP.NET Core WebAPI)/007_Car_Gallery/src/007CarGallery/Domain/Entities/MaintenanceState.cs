using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class MaintenanceState : Entity<int>
{
    public string State { get; set; } // Bakım durumları
    public int SortOrder { get; set; } // Bakım durumlarını sıralamak için 

    public virtual ICollection<MaintenanceRecord> MaintenanceRecords { get; set; }
    public virtual ICollection<MaintenancePlanningRecord> MaintenancePlanningRecords { get; set; }
    public MaintenanceState()
    {
        MaintenanceRecords = new HashSet<MaintenanceRecord>();
        MaintenancePlanningRecords = new HashSet<MaintenancePlanningRecord>();

    }

    public MaintenanceState(string state, int sortOrder )
    {
        State = state;
        SortOrder = sortOrder;
    }

    

}
