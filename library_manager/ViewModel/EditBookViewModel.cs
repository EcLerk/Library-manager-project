using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using library_manager.Application.Abstractions;
using library_manager.Domain.Entities;
using library_manager.Pages;
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
        [ObservableProperty]
        string? name;
        [ObservableProperty]
        string? description;
        [ObservableProperty]
        string? numberOfBooks;
        [ObservableProperty]
        string? year;

        [RelayCommand]
        private void PageLoaded()
        {
            Name = Book.Name;
            Description = Book.Description;
            NumberOfBooks = Book.NumberOfBooks.ToString();
            Year = Book.Year.ToString();
        }

        [RelayCommand]
        private async Task OnSaveButtonClicked()
        {
            Book.Name = Name;
            Book.Description = Description;

            bool result = int.TryParse(NumberOfBooks, out int number);
            if (result)
                Book.NumberOfBooks = number;
            else
            {
                await App.Current.MainPage.DisplayAlert("Incorrect Input",
                    "Number of books field enterred incorectly", "Cancel");
                return;
            }

            result = int.TryParse(Year, out number);
            if(result) 
                Book.Year = number;
            else
            {
                await App.Current.MainPage.DisplayAlert("Incorrect Input",
                    "Year field enterred incorectly", "Cancel");
                return;
            }

            
            await _bookService.UpdateAsync(Book);
            await Shell.Current.GoToAsync("//"+nameof(NewPage1));
        }
    }
}
