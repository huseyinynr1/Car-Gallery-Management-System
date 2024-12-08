using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class Fuel : Entity<int>
{
    public string Type { get; set; }
    public ICollection<Car>? Cars { get; set; }//Bir yakıt tipine ait birden çok araba var

    public Fuel()
    {
        Cars = new HashSet<Car>();
    }
    public Fuel(int id, string type)
    {
        Id = id;
        Type = type;
    }

}