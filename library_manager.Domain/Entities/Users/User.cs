using library_manager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library_manager.Domain.Entities.Users
{
    public class User:Entity
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        //role + enum of permissions
        [Column(TypeName ="Role")]
        public Role UserRole { get; set; }

        Dictionary<Role, List<Permissions>> roles = new Dictionary<Role, List<Permissions>>()
        {
            {Role.Admin, new List<Permissions>{ Permissions.edit, Permissions.add, Permissions.delete} },
            {Role.Reader, new List<Permissions>{ Permissions.order} }
        };

        public enum Role
        {
            Admin,
            Reader
        }

        enum Permissions
        {
            edit,
            add,
            delete,
            order
        }
    }
}
