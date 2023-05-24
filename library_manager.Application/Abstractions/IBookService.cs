using library_manager.Domain.Entities;
using library_manager.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library_manager.Application.Abstractions
{
    public interface IBookService: IBaseService<Book>
    {
        //public Task<Book> GetByNameAsync(string name);
    }
}
