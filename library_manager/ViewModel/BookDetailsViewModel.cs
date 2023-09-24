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
        private readonly IBookService _bookService;

        public BookDetailsViewModel(IUserService userService, IOrderService orderService, IBookService bookService)
        {
            _userService = userService;
            _orderService = orderService;
            _bookService = bookService;

            hasEditPermission = false;
            hasOrderPermission = false;
        }

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
            if(Book.NumberOfBooks > 0)
            {
                await _orderService.AddAsync(new Order
                {
                    BookName = this.Book.Name,
                    UserName = _userService.CurrentUser.UserName,
                    OrderDate = DateOnly.FromDateTime(DateTime.Now)
                });

                Book.NumberOfBooks -= 1;
                await _bookService.UpdateAsync(Book);
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Sorry",
                    "This book is not currently in the library", "Cancel");
            }
        }
    }
}
