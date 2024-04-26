using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class Address : Entity<int>
{


    public string City { get; set; }
    public string District { get; set; }
    public string Street { get; set; }
    public string Title { get; set; }
    public int CustomerId { get; set; }




    public virtual Customer Customer { get; set; }// bir adres sadece bir customere sahip olabilr

}
