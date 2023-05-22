using library_manager.ViewModel;

namespace library_manager.Pages;

public partial class AddBookPage : ContentPage
{
	public AddBookPage(AddBookViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}