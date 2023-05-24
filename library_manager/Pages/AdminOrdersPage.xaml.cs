using library_manager.ViewModel;

namespace library_manager.Pages;

public partial class AdminOrdersPage : ContentPage
{
	public AdminOrdersPage(UserOrdersViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}