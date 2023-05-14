using library_manager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace library_manager.Domain.Entities
{
    public class Book : Entity
    {
        public string? Name { get; set; }
        public Author? author;
        public int? Year { get; set; }
        public string? Description { get; set; }
        public Genre? genre;
        public Publisher? publisher;
        public int? NumberOfBooks { get; set; }

    }
}
