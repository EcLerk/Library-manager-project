using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library_manager.Domain.Entities
{
    public class Order:Entity
    {
        public string BookName { get; set; }
        public int UserId { get; set; }
        public DateOnly orderDate { get; set; }//DateOnly
    }
}
