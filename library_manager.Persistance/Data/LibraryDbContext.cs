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
        public DbSet<Order> Orders { get; set; } = null!;
        public DbSet<Loan> Loans { get; set; } = null!;
        public LibraryDbContext(DbContextOptions<LibraryDbContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .Property(role => role.UserRole).HasConversion<string>();

            base.OnModelCreating(modelBuilder);
        }
    }
}
