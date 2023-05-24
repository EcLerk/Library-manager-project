using library_manager.Domain.Abstractions;
using library_manager.Persistance.Data;
using library_manager.Domain.Entities;
using library_manager.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library_manager.Persistance.Repository
{
    public class EFUnitOfWork:IUnitOfWork
    {
        private readonly LibraryDbContext _context;
        private readonly Lazy<IRepository<Book>> _booksRepository;
        private readonly Lazy<IRepository<User>> _usersRepository;
        private readonly Lazy<IRepository<Order>> _ordersRepository;
        private readonly Lazy<IRepository<Loan>> _loansRepository;


        public EFUnitOfWork(LibraryDbContext context)
        {
            _context = context;
            _booksRepository= new Lazy<IRepository<Book>>(()=> new EFRepository<Book>(context));
            _usersRepository= new Lazy<IRepository<User>>(()=> new EFRepository<User>(context));
            _ordersRepository= new Lazy<IRepository<Order>>(()=> new EFRepository<Order>(context));
            _loansRepository = new Lazy<IRepository<Loan>>(()=> new EFRepository<Loan>(context));
        }

        IRepository<Book> IUnitOfWork.BooksRepository => _booksRepository.Value;
        IRepository<User> IUnitOfWork.UsersRepository => _usersRepository.Value;
        IRepository<Order> IUnitOfWork.OrdersRepository => _ordersRepository.Value;
        IRepository<Loan> IUnitOfWork.LoansRepository => _loansRepository.Value;

        public async Task CreateDatabaseAsync()
        {
            await _context.Database.EnsureCreatedAsync();
        }

        public async Task RemoveDatabaseAsync()
        {
            await _context.Database.EnsureDeletedAsync();
        }

        public async Task SaveAllAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
