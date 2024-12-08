using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class CarStatusHistory : Entity<int>
{
    public int CarId { get; set; }
    public int CarStatusId { get; set; }
    public DateTime StatusChange { get; set; }//Durumun Değiştiği Tarih
    public string Remark { get; set; }//Durumla ilgili ek açıklama
    public virtual Car Car { get; set; }
    public virtual CarStatusEntity CarStatus { get; set; }
    public CarStatusHistory()
    {

    }
    public CarStatusHistory(int carId, int carStatusId, DateTime statusChange, string remark)
    {
        CarId = carId;
        CarStatusId = carStatusId;
        StatusChange = statusChange;
        Remark = remark;
    }


}