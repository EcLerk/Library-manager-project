using library_manager.ViewModel;

namespace library_manager.Pages;

public partial class SingUpPage : ContentPage
{
	public SingUpPage(SingUpViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}