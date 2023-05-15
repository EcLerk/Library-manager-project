using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using library_manager.Domain.Entities;
using library_manager.Domain.Entities.Users;

namespace library_manager.Persistance.Data
{
    public class LibraryDbContext : DbContext
    {
        public DbSet<Book> Books { get; set; } = null!;
        public DbSet<User> Users { get; set; } = null!;
        public LibraryDbContext(DbContextOptions<LibraryDbContext> options)
            : base(options)
        { }

    }
}
