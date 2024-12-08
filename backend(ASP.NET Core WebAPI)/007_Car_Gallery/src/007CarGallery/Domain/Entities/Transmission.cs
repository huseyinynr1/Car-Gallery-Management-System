using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class Transmission : Entity<int>
{
    public string Type { get; set; }

    public ICollection<Car>? Cars { get; set; }////Bir vites tipine ait birden çok araba var


    public Transmission()
    {
        Cars = new HashSet<Car>();
    }
    public Transmission(int id, string type)
    {
        Id = id;
        Type = type;
    }
}