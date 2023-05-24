using library_manager.Application.Abstractions;
using library_manager.Domain.Abstractions;
using library_manager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library_manager.Application.Services
{
    public class BookService : IBookService
    {
        IUnitOfWork _unitOfWork;
        public BookService(IUnitOfWork unitOfWork) 
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Book> AddAsync(Book entity)
        {
            await _unitOfWork.BooksRepository.AddAsync(entity);
            return entity;
        }

        public async Task<Book> DeleteAsync(int id)
        {
            Book book = await _unitOfWork.BooksRepository.GetByIdAsync(id);
            if(book != null) 
            {
                await _unitOfWork.BooksRepository.DeleteAsync(book);
            }
            
            return book; 
        }

        public async Task<IEnumerable<Book>> GetAllAsync()
        {
            return await _unitOfWork.BooksRepository.ListAllAsync();
        }

        public async Task<Book> GetByIdAsync(int id)
        {
            return await _unitOfWork.BooksRepository.GetByIdAsync(id);
        }

        public async Task<Book> UpdateAsync(Book entity)
        {
            await _unitOfWork.BooksRepository.UpdateAsync(entity);
            return entity;
        }

        public async Task<Book> GetByNameAsync(string name)
        {
            return await _unitOfWork.BooksRepository.FirstOrDefaultAsync(x => x.Name == name);
        }
    }
}
