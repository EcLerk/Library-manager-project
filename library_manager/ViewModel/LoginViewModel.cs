using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
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
        [RelayCommand]
        async void ShowBooks() => await GoToBooksPage();
        [RelayCommand]
        async void ShowSingUp() => await GoToSingUpPage();

        private async Task GoToBooksPage()
        {
            await Shell.Current.GoToAsync("//"+nameof(NewPage1));
        }

        private async Task GoToSingUpPage()
        {
            await Shell.Current.GoToAsync(nameof(SingUpPage));
        }
    }
}
