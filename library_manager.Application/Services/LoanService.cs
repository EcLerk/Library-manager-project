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
    public class LoanService : ILoanService
    {
        IUnitOfWork _unitOfWork;

        public LoanService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Loan> AddAsync(Loan entity)
        {
            await _unitOfWork.LoansRepository.AddAsync(entity);
            return entity;
        }

        public async Task<Loan> DeleteAsync(int id)
        {
            Loan loan = await _unitOfWork.LoansRepository.GetByIdAsync(id);
            if (loan != null)
            {
                await _unitOfWork.LoansRepository.DeleteAsync(loan);
            }

            return loan;
        }

        public async Task<IEnumerable<Loan>> GetAllAsync()
        {
            return await _unitOfWork.LoansRepository.ListAllAsync();
        }

        public async Task<Loan> GetByIdAsync(int id)
        {
            return await _unitOfWork.LoansRepository.GetByIdAsync(id);
        }

        public async Task<Loan> UpdateAsync(Loan entity)
        {
            await _unitOfWork.LoansRepository.UpdateAsync(entity);
            return entity;
        }
    }
}
