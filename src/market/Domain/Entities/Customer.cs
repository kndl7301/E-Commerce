using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class Customer:Entity<int>
{
   
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public int Phone { get; set; }



    public virtual ICollection< Comment> Comments { get; set; } // bir customer birden fazla comment yapabilir
    public virtual ICollection< Order> Orders { get;} // bir customer birden fazla ordera sahip olabilr
    public virtual ICollection< Address> Addresses { get;} // bir customer birden fazla adrese sahip olabilr
    public virtual ICollection< Complaint> Complaints { get;} // bir customer birden fazla complaint yapabilir


}
