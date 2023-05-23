using library_manager.ViewModel;

namespace library_manager.Pages;

public partial class EditBookPage : ContentPage
{
	public EditBookPage(EditBookViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}