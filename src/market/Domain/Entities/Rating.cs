using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class Rating : Entity<int>
{

    public int CustomerId { get; set; }

    public int ProductId { get; set; }
    public int Score { get; set; }


    public virtual Product Product { get; set; } // bir rating bir ürüne ait olabiilr

}
