using library_manager.ViewModel;

namespace library_manager.Pages;

public partial class UserOrdersPage : ContentPage
{
	public UserOrdersPage(UserOrdersViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}