using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using library_manager.Application.Abstractions;
using library_manager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library_manager.ViewModel
{
    public partial class AddBookViewModel:ObservableObject
    {
        IBookService _bookService;
        public AddBookViewModel(IBookService bookService)
        {
            _bookService = bookService;
        }

        [ObservableProperty]
        string name;
        [ObservableProperty]
        string? description;
        [ObservableProperty]
        string? numberOfBooks;
        [ObservableProperty]
        string? year;

        [RelayCommand]
        private async Task OnSaveButtonClicked()
        {
            await _bookService.AddAsync(new Book() 
            {Name = Name, Description = Description,
            NumberOfBooks = Convert.ToInt32(NumberOfBooks), Year = Convert.ToInt32(Year)});

            await Shell.Current.GoToAsync("..");
        }
    }
}
