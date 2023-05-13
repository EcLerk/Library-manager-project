using CommunityToolkit.Mvvm.ComponentModel;
using library_manager.Domain.Entities;
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
        [ObservableProperty]
        Book book;
        public BookDetailsViewModel()
        {
            
        }
    }
}
