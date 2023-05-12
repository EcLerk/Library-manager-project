using library_manager.ViewModel;

namespace library_manager;

public partial class TestPage : ContentPage
{
	public TestPage(BooksViewModel vm)
	{
		InitializeComponent();
		BindingContext= vm;
	}
}