using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class Product:Entity<int>
{
 
    public string ProductName { get; set; }
    public string ProductDescription { get; set; }
    public string ProductImage { get; set; }
    public int Price { get; set; }
    public int Stock { get; set; }
    public int CategoryId { get; set; }

    public virtual Category Category { get; set; }  //her productın bağlı oldugu bir category vardır

    public virtual ICollection<Comment> Comments{ get; set; }  //her productın  birden fazla commenti olabilir

    public virtual Rating  Rating { get; set; }  //her productın bir rating scoru  vardır



}
