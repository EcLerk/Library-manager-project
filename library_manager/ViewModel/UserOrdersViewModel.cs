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

        public UserOrdersViewModel(IOrderService orderService, IUserService userService)
        {
            _orderService = orderService;
            _userService = userService;
        }

        public ObservableCollection<Order> Orders { get; set; } = new();

        [RelayCommand]
        public async void UpdateOrdersList() => await GetOrders();

        public async Task GetOrders()
        {
            try
            {
                var orders = await _orderService.GetOrdersByUserId(_userService.CurrentUser.Id);

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
    }
}
