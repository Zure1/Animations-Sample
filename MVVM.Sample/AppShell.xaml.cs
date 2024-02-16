﻿using MVVM.Sample.Views;

namespace MVVM.Sample;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
		RegisterRoutes();
    }

	private void RegisterRoutes()
	{
        Routing.RegisterRoute(nameof(ParallexEffectPage), typeof(ParallexEffectPage));
        Routing.RegisterRoute(nameof(CardPage), typeof(CardPage));
    }
}