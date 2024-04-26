using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class Payment : Entity<int>
{
  
    public int CardNumber { get; set; }

    public string PaymentType { get; set; }
    public DateTime PaymentDate { get; set; }


    public int OrderId { get; set; }

    public virtual Order Order { get; set; }    


 
}