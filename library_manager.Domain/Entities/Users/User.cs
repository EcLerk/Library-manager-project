using library_manager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library_manager.Domain.Entities.Users
{
    public class User:Entity
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
