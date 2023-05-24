using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using library_manager.Application.Abstractions;
using library_manager.Application.Services;
using library_manager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace library_manager.ViewModel
{
    public partial class UserOrdersViewModel:ObservableObject
    {
        IOrderService _orderService;
        IUserService _userService;
        ILoanService _loanService;
        IBookService _bookService;

        public UserOrdersViewModel(IOrderService orderService, IUserService userService,
            ILoanService loanService, IBookService bookService)
        {
            _orderService = orderService;
            _userService = userService;
            _loanService = loanService;
            _bookService = bookService;
        }

        public ObservableCollection<Order> Orders { get; set; } = new();
        public ObservableCollection<Loan> Loans { get; set; } = new();

        [ObservableProperty]
        Order selectedOrder;
        [ObservableProperty]
        Loan selectedLoan;

        [RelayCommand]
        public async void UpdateUserOrdersList() => await GetUserOrders();

        [RelayCommand]
        public async void UpdateAdminOrdersList() => await GetAllOrders();

        [RelayCommand]
        public async void UpdateLoansList() => await GetLoans();
        [RelayCommand]
        public async void Lended(Order order) => await OnLendedButtonClicked(order);

        [RelayCommand]
        public async void BookReturned(Loan loan) => await OnReturnedButtonCLicked(loan);

        [RelayCommand]
        public async Task UpdateAll()
        {
            await GetAllOrders();
            await GetLoans();
        }

        public async Task GetUserOrders()
        {
            try
            {
                var orders = await _orderService.GetOrdersByUserName(_userService.CurrentUser.UserName);

                await MainThread.InvokeOnMainThreadAsync(() =>
                {
                    Orders.Clear();
                    foreach (var order in orders)
                    {
                        Orders.Add(order);
                    }
                });
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }

        }

        private async Task GetAllOrders()
        {
            var orders = await _orderService.GetAllAsync();

            await MainThread.InvokeOnMainThreadAsync(() =>
            {
                Orders.Clear();
                foreach (var order in orders)
                {
                    Orders.Add(order);
                }
            });
        }

        private async Task GetLoans()
        {
            var loans = await _loanService.GetAllAsync();

            await MainThread.InvokeOnMainThreadAsync(() =>
            {
                Loans.Clear();
                foreach (var loan in loans)
                {
                    Loans.Add(loan);
                }
            });
        }

        private async Task OnLendedButtonClicked(Order order)
        {
            if(order != null)
            {
                await _loanService.AddAsync(new Loan()
                {
                    BookName = order.BookName,
                    UserName = order.UserName,
                    LoanDate = DateOnly.FromDateTime(DateTime.Now)
                });

                await _orderService.DeleteAsync(order.Id);

                await GetAllOrders();
                await GetLoans();
            }
        }

        private async Task OnReturnedButtonCLicked(Loan loan)
        {
            if(loan != null)
            {
                await _loanService.DeleteAsync(loan.Id);

                var book = await _bookService.GetByNameAsync(loan.BookName);
                book.NumberOfBooks++;
                await _bookService.UpdateAsync(book);

                await GetLoans();
            }
        }
    }
}
