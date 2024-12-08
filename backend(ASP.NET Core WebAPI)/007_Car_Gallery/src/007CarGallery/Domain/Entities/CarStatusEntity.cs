using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class CarStatusEntity : Entity<int>
{
    public string Status { get; set; }
    public virtual ICollection<CarStatusHistory> CarStatusHistories { get; set; }
    public virtual ICollection<Car> Cars { get; set; }
    public CarStatusEntity()
    {
        CarStatusHistories = new HashSet<CarStatusHistory>();
        Cars = new HashSet<Car>();
    }
    public CarStatusEntity(string status)
    {
        Status = status;
    }

}