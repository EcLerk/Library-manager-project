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
        private void LoadPage()
        {
            Name= string.Empty;
            Description= string.Empty;
            NumberOfBooks= string.Empty;
            Year= string.Empty;
        }

        [RelayCommand]
        private async Task OnSaveButtonClicked()
        {
            Book book = new Book();

            book.Name = Name;
            book.Description = Description;

            bool result = int.TryParse(NumberOfBooks, out int number);
            if (result) 
                book.NumberOfBooks = number;
            else
            {
                await App.Current.MainPage.DisplayAlert("Incorrect Input",
                    "Number of books field entered incorrectly", "Cancel");
                return;
            }

            result = int.TryParse(Year, out number);
            if (result)
                book.Year = number;
            else
            {
                await App.Current.MainPage.DisplayAlert("Incorrect Input",
                    "Year field entered incorrectly", "Cancel");
                return;
            }

            await _bookService.AddAsync(book);
            await Shell.Current.GoToAsync("..");
        }
    }
}
