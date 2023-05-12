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

namespace library_manager.ViewModel
{
    public partial class BooksViewModel: ObservableObject
    {
        private readonly IBookService _bookService;

        public BooksViewModel()
        { }

        public BooksViewModel(IBookService bookService)
        {

            _bookService = bookService;
        }

        public ObservableCollection<Book> Books { get; set; } = new();

        [ObservableProperty]
        Book selectedBook;

        [RelayCommand]
        public async void UpdateBookList() => await GetBooks();


        public async Task GetBooks()
        {
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
        }
    }
}
