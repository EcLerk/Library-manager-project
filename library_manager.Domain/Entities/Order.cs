using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library_manager.Domain.Entities
{
    public class Order:Entity
    {
        public int BookId { get; set; }
        public int UserId { get; set; }
        public DateTime orderDate { get; set; }
    }
}
