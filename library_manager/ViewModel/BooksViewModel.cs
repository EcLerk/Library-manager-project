﻿using System;
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

namespace library_manager.ViewModel
{
    public partial class BooksViewModel: ObservableObject
    {
        private readonly IBookService _bookService;

        public BooksViewModel(IBookService bookService)
        {
            _bookService = bookService;
        }

        public ObservableCollection<Book> Books { get; set; } = new();

        [ObservableProperty]
        Book selectedBook;

        [RelayCommand]
        public async void UpdateBookList() => await GetBooks();

        [RelayCommand]
        async void ShowDetails(Book book) => await GoToDetailsPage(book);

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
    }
}
