using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class Complaint : Entity<int>
{
  
    public string Title { get; set; }
    public string ComplaintText { get; set; }
    public DateTime ComplaintDate { get; set; }
    public int CustomerId { get; set; }
    public string CustomerEmail { get; set; }


    public virtual Customer Customer { get; set; } // her  complaint bir customer a aittir


}
