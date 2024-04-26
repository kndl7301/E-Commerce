using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class Comment : Entity<int>
{
 
    public string Title { get; set; }
    public string CommentText { get; set; }
    public DateTime CommentDate { get; set; }
    public int CustomerId { get; set; }
    public int ProductId { get; set; }



    public virtual Customer Customer { get; set; } // bir commnet bir customer tarafından yapılır
    public virtual Product Product { get; set; } // bir comment bir producta ait olabilir ancak


}
