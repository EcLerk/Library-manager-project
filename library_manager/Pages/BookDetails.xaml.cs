using library_manager.ViewModel;

namespace library_manager.Pages;

public partial class BookDetails : ContentPage
{
	public BookDetails(BookDetailsViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}