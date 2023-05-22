using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using library_manager.Application.Abstractions;
using library_manager.Domain.Entities.Users;
using library_manager.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library_manager.ViewModel
{
    public partial class SingUpViewModel:ObservableObject
    {
        private readonly IUserService _userService;

        [ObservableProperty]
        User user;
        [ObservableProperty]
        bool isExist = false;
        [ObservableProperty]
        bool isEntryEmpty;

        public SingUpViewModel(IUserService userService)
        {
            _userService = userService;
            user = new User();
        }

        [RelayCommand]
        async void ShowBooks() => await GoToBooksPage();

        private async Task GoToBooksPage()
        {
            await Shell.Current.GoToAsync("//" + nameof(NewPage1));
        }

        [RelayCommand]
        async Task UserSingUp()
        {
            IsEntryEmpty = false;
            var user = await _userService.GetByNameAsync(User.UserName);

            if (user != null)
                IsExist = true;
            else
            {
                if (User.UserName != null && User.Password != null)
                {
                    //все юзеры – читатели
                    User.UserRole = User.Role.Reader;
                    //
                    await _userService.AddAsync(this.User);
                    await GoToBooksPage();
                }
                else
                    IsEntryEmpty = true;
            }
        }
    }
}
