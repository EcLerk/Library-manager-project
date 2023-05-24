﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library_manager.Domain.Entities
{
    public class Order:Entity
    {
        public string BookName { get; set; }
        public string UserName { get; set; }
        public DateOnly OrderDate { get; set; }//DateOnly
    }
}
