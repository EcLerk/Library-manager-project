using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using library_manager.Application.Abstractions;
using library_manager.Application.Services;
using library_manager.Domain.Entities.Users;
using library_manager.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library_manager.ViewModel
{
    public partial class LoginViewModel:ObservableObject
    {
        private readonly IUserService _userService;

        [ObservableProperty]
        User user;
        [ObservableProperty]
        bool isExist = false;

        public LoginViewModel(IUserService userService)
        {
            _userService = userService;
            user = new User();
        }

        [RelayCommand]
        async void ShowBooks() => await GoToBooksPage();
        [RelayCommand]
        async void ShowSingUp() => await GoToSingUpPage();

        [RelayCommand]
        async Task UserLogin() => await OnLoginButtonClicked();

        private async Task GoToBooksPage()
        {
            await Shell.Current.GoToAsync("//"+nameof(NewPage1));
        }

        private async Task GoToSingUpPage()
        {
            await Shell.Current.GoToAsync(nameof(SingUpPage));
        }

        private async Task OnLoginButtonClicked()
        {
            var checkUser = await _userService.GetByNameAsync(User.UserName);

            if (checkUser == null)
                IsExist = true;
            else
            {
                if (checkUser.Password == User.Password)
                    await GoToBooksPage();
                else
                    IsExist = true;
            }
        }

        
    }
}
