using library_manager.ViewModel;

namespace library_manager.Pages;

public partial class UsersBookPage : ContentPage
{
	public UsersBookPage(BooksViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}