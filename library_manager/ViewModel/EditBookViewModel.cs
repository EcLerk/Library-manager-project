using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using library_manager.Application.Abstractions;
using library_manager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace library_manager.ViewModel
{
    [QueryProperty(nameof(Book), "Book")]
    public partial class EditBookViewModel:ObservableObject
    {
        private readonly IBookService _bookService;
        public EditBookViewModel(IBookService bookService)
        {
            _bookService = bookService;
        }

        [ObservableProperty]
        Book book;

        [RelayCommand]
        private async Task OnSaveButtonClicked()
        {
            await Shell.Current.GoToAsync("//NewPage1");
        }
    }
}
