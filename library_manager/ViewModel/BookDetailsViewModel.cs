using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using library_manager.Application.Abstractions;
using library_manager.Domain.Entities;
using library_manager.Domain.Entities.Users;
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

        [ObservableProperty]
        Book book;

        [ObservableProperty]
        ImageSource imageSource;

        [ObservableProperty]
        bool hasEditPermission;
        [ObservableProperty]
        bool hasOrderPermission;

        public BookDetailsViewModel(IUserService userService)
        {
            _userService = userService;
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
    }
}
