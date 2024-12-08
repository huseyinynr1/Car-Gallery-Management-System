using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class MaintenanceType : Entity<int>
{
    public string Type { get; set; } // Bakım durumları
    public int SortOrder { get; set; } // Bakım durumlarını sıralamak için
    public virtual ICollection<MaintenanceRecord> MaintenanceRecords { get; set; }
    public virtual ICollection<MaintenancePlanningRecord> MaintenancePlanningRecords { get; set; }

    public MaintenanceType()
    {
        MaintenanceRecords = new HashSet<MaintenanceRecord>();
        MaintenancePlanningRecords = new HashSet<MaintenancePlanningRecord>();
    }
    public MaintenanceType(string type, int sortOrder)
    {
        Type = type;
        SortOrder = sortOrder;
    }


}
