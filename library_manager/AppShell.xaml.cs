﻿using library_manager.Pages;

namespace library_manager;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

		Routing.RegisterRoute(nameof(BookDetails), typeof(BookDetails));
		Routing.RegisterRoute(nameof(NewPage1), typeof(NewPage1));
		Routing.RegisterRoute(nameof(SingUpPage), typeof(SingUpPage));
	}
}
