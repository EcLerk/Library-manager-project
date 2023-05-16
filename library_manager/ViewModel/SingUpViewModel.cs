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
            await _userService.AddAsync(this.User);
            await GoToBooksPage();
        }
    }
}
