using library_manager.ViewModel;

namespace library_manager.Pages;

public partial class NewPage1 : ContentPage
{
	public NewPage1(BooksViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}