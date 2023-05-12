using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using library_manager.Domain.Entities;
using library_manager.Domain.Entities.Users;

namespace library_manager.Domain.Abstractions
{
    public interface IUnitOfWork
    {
        IRepository<Book> BooksRepository { get; }
        IRepository<User> UsersRepository { get; }
        public Task RemoveDatabaseAsync();
        public Task CreateDatabaseAsync();
        public Task SaveAllAsync();

    }
}
