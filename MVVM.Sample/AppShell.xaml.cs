using MVVM.Sample.Views;

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
        Routing.RegisterRoute(nameof(BasicAnimationsPage), typeof(BasicAnimationsPage));
        Routing.RegisterRoute(nameof(CardPage), typeof(CardPage));
        Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));
        Routing.RegisterRoute(nameof(ParallexEffectPage), typeof(ParallexEffectPage));
        Routing.RegisterRoute(nameof(ParticleEffectsPage), typeof(ParticleEffectsPage));
        Routing.RegisterRoute(nameof(PerformancePage), typeof(PerformancePage));
    }
}