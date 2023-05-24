using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using library_manager.Application.Abstractions;
using library_manager.Domain.Entities;
using library_manager.Application.Services;
using System.Diagnostics;
using library_manager.Pages;
using Microsoft.Maui.Controls;

namespace library_manager.ViewModel
{
    public partial class BooksViewModel: ObservableObject
    {
        private readonly IBookService _bookService;
        private readonly IUserService _userService;

        public BooksViewModel(IBookService bookService, IUserService userService)
        {
            _bookService = bookService;
            _userService = userService;
        }

        public ObservableCollection<Book> Books { get; set; } = new();

        [ObservableProperty]
        Book selectedBook;

        [RelayCommand]
        public async void UpdateBookList() => await GetBooks();

        [RelayCommand]
        public async void ShowDetails(Book book) => await GoToDetailsPage(book);

        [RelayCommand]
        public async void AddBook() => await GoToAddBookPage();

        [RelayCommand]
        public async void ShowOrders() => await GoToOrdersPage();
        //[RelayCommand]
        //public async void DeleteBook(int id) => await OnDeleteButtonClicked(id);

        public async Task GetBooks()
        {
           
            var selectedBook = SelectedBook;

            try
            {
                var books = await _bookService.GetAllAsync();

                await MainThread.InvokeOnMainThreadAsync(() =>
                {
                    Books.Clear();
                    foreach (var book in books)
                    {
                        Books.Add(book);
                    }
                });
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex);
            }

            if (selectedBook != null)
            {
                SelectedBook = await _bookService.GetByIdAsync(selectedBook.Id);
            }
        }

        private async Task GoToDetailsPage(Book book)
        {
            if (book == null)
                return;

            IDictionary<string, object> parameters = new Dictionary<string, object>()
            {
                {"Book", book }
            };

            await Shell.Current.GoToAsync(nameof(BookDetails), parameters);
        }

        private async Task GoToAddBookPage()
        {
            await Shell.Current.GoToAsync(nameof(AddBookPage));
            //Microsoft.Maui.Controls.Application.Current.OpenWindow(new Window(new AddBookPage())
            //{
            //    Width = 700,
            //    Height = 500 
            //}) ;
        }

        [RelayCommand]
        public async void DeleteBook(Book book)
        {
            if (book != null)
            {
                await _bookService.DeleteAsync(book.Id);
                UpdateBookList();
            }
        }

        [RelayCommand]
        public async Task LogOut()
        {
            _userService.CurrentUser = null;
            await Shell.Current.GoToAsync("//" + nameof(LoginPage));
        }

        
        private async Task GoToOrdersPage()
        {
            await Shell.Current.GoToAsync(nameof(UserOrdersPage));
        }
    }
}
