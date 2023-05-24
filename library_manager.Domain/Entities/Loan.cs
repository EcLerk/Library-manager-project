using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library_manager.Domain.Entities
{
    public class Loan:Entity
    {
        public DateOnly LoanDate { get; set; }

        public string BookName { get; set; }
        public string UserName { get; set; }
    }
}
