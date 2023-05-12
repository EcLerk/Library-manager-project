namespace library_manager;

public partial class App : IApplication
{
	public App()
	{
		InitializeComponent();

		MainPage = new AppShell();
	}
}
