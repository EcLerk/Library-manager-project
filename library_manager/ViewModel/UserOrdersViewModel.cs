using CommunityToolkit.Mvvm.ComponentModel;
using library_manager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library_manager.ViewModel
{
    public partial class UserOrdersViewModel:ObservableObject
    {
        ObservableCollection<Book> orders;
    }
}
