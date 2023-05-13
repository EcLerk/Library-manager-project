using library_manager.Application.Abstractions;
using library_manager.ViewModel;

namespace library_manager;

public partial class MainPage : ContentPage
{

	public MainPage()
	{
		//BooksViewModel vm = new BooksViewModel();

		InitializeComponent();
		//this.BindingContext = new BooksViewModel(bookService);
	}

	
}

