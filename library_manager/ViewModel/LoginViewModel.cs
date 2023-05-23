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
        string name;
        [ObservableProperty]
        string password;
        [ObservableProperty]
        bool isExist = false;

        public LoginViewModel(IUserService userService)
        {
            _userService = userService;
        }

        [RelayCommand]
        void SomeMethod()
        {
            Name = String.Empty;
            Password = String.Empty;
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
            var user = await _userService.GetByNameAsync(Name);
            bool isUser = CheckUser(user);

            if (isUser) 
            {
                if (user.UserRole == User.Role.Admin)
                    await Shell.Current.GoToAsync("//" + nameof(NewPage1));
                else if(user.UserRole == User.Role.Reader)
                    await Shell.Current.GoToAsync("//" + nameof(UsersBookPage));
            }
        }

        private bool CheckUser(User checkUser)
        {
            if (checkUser == null)
                IsExist = true;
            else
            {
                if (checkUser.Password == Password)
                {
                    _userService.CurrentUser = checkUser;
                    return true;
                }
                else
                    IsExist = true;                  
                
            }

            return false;
        }
    }
}
