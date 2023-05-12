using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library_manager.Domain.Entities
{
    public class Author
    {
        string name;
        public string Name { get { return name; } set { name = value; } }

        DateTime birthDate;
        public DateTime BirthDate { get { return birthDate; } set { birthDate = value; } }

        DateTime? deathDate;
        public DateTime? DeathDate { get { return deathDate; } set { deathDate = value; } }

        string biography;
        public string Biography { get { return biography; } set { biography = value; } }

        

    }
}
