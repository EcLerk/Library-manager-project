using Microsoft.Maui.Controls;

namespace library_manager;

public partial class App : Microsoft.Maui.Controls.Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new AppShell();
		
	}
}
