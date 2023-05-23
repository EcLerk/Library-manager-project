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
    public class OrderService : IOrderService
    {
        IUnitOfWork _unitOfWork;

        public OrderService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Order> AddAsync(Order entity)
        {
            await _unitOfWork.OrdersRepository.AddAsync(entity);
            return entity;
        }

        public async Task<Order> DeleteAsync(int id)
        {
            Order order = await _unitOfWork.OrdersRepository.GetByIdAsync(id);
            if (order != null)
            {
                await _unitOfWork.OrdersRepository.DeleteAsync(order);
            }

            return order;
        }

        public async Task<IEnumerable<Order>> GetAllAsync()
        {
            return await _unitOfWork.OrdersRepository.ListAllAsync();
        }

        public async Task<Order> GetByIdAsync(int id)
        {
            return await _unitOfWork.OrdersRepository.GetByIdAsync(id);
        }

        public async Task<Order> UpdateAsync(Order entity)
        {
            await _unitOfWork.OrdersRepository.UpdateAsync(entity);
            return entity;
        }
    }
}
