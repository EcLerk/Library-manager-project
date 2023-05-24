using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using library_manager.Application.Abstractions;
using library_manager.Domain.Entities;
using library_manager.Domain.Entities.Users;
using library_manager.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library_manager.ViewModel
{
    [QueryProperty(nameof(Book),"Book")]
    public partial class BookDetailsViewModel:ObservableObject
    {
        private readonly IUserService _userService;
        private readonly IOrderService _orderService;

        [ObservableProperty]
        Book book;

        [ObservableProperty]
        ImageSource imageSource;

        [ObservableProperty]
        bool hasEditPermission;
        [ObservableProperty]
        bool hasOrderPermission;

        [RelayCommand]
        public async void AddOrder() => await OnOrderButtonClicked();

        public BookDetailsViewModel(IUserService userService, IOrderService orderService)
        {
            _userService = userService;
            _orderService = orderService;

            hasEditPermission = false;
            hasOrderPermission = false;        
        }

        [RelayCommand]
        public void CheckPermissions()
        {
            var userRole = _userService.CurrentUser.UserRole;

            foreach(var permission in _userService.CurrentUser.roles[userRole])
            {
                if(permission == User.Permissions.edit)
                {
                    HasEditPermission = true;
                }

                if(permission == User.Permissions.order)
                {
                    HasOrderPermission = true;
                }
            }
        }

        [RelayCommand]
        public async Task GoToEditBookPage()
        {
            if (Book == null)
                return;

            IDictionary<string, object> parameters = new Dictionary<string, object>()
            {
                {"Book", Book }
            };

            await Shell.Current.GoToAsync(nameof(EditBookPage), parameters);
        }

        
        private async Task OnOrderButtonClicked()
        {
            await _orderService.AddAsync(new Order
            {
                BookName = this.book.Name,
                UserId = _userService.CurrentUser.Id,
                orderDate = DateOnly.FromDateTime(DateTime.Now)
            });
        }
    }
}
