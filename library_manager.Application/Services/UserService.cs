using library_manager.Application.Abstractions;
using library_manager.Domain.Abstractions;
using library_manager.Domain.Entities;
using library_manager.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace library_manager.Application.Services
{
    public class UserService : IUserService
    {
        IUnitOfWork _unitOfWork;

        private User _user;
        public User CurrentUser 
        { 
            get { return _user; }
            set { _user = value; } }

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<User> AddAsync(User entity)
        {
            await _unitOfWork.UsersRepository.AddAsync(entity);
            return entity;
        }

        public async Task<User> DeleteAsync(int id)
        {
            User user = await _unitOfWork.UsersRepository.GetByIdAsync(id);
            if (user != null)
            {
                await _unitOfWork.UsersRepository.DeleteAsync(user);
            }

            return user;
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _unitOfWork.UsersRepository.ListAllAsync();
        }

        public async Task<User> GetByIdAsync(int id)
        {
            return await _unitOfWork.UsersRepository.GetByIdAsync(id);
        }

        public async Task<User> UpdateAsync(User entity)
        {
            await _unitOfWork.UsersRepository.UpdateAsync(entity);
            return entity;
        }

        public async Task<User> GetByNameAsync(string name)
        {
            return await _unitOfWork.UsersRepository.FirstOrDefaultAsync(entity => entity.UserName == name);
        }
    }
}
