using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class Category : Entity<int>
{
   
    public string CategoryName { get; set; }
    public string Description { get; set; }
    public bool IsActive { get; set; }



    public virtual ICollection<Product> Products { get; set; } // Bir kategoride birden fazla product olabilir
}
