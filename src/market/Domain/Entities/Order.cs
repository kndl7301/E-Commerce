using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class Order : Entity<Guid>
{
   
    public int OrderNumber { get; set; }
    public int Totalprice { get; set; }
    public int ProductId { get; set; }
    public int CustomerId { get; set; }
    public int PaymentId { get; set; }

    public DateTime OrderDate { get; set; }
    public bool Status { get; set; }

    public virtual Customer Customer { get; set; }// bir order sadece bir customere ait olabilir

    public virtual Payment Payment { get; set; }


}