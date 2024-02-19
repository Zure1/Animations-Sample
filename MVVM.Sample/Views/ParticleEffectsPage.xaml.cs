using MVVM.Sample.ViewModels;

namespace MVVM.Sample.Views;

public partial class ParticleEffectsPage : ContentPage
{
    private readonly ParticleEffectsViewModel _viewModel;

    public ParticleEffectsPage()
	{
        InitializeComponent();

        _viewModel = (ParticleEffectsViewModel)BindingContext;
        _viewModel.StartAnimationEvent += ViewModel_StartAnimationEvent;
    }

    private async void ViewModel_StartAnimationEvent(object? sender, EventArgs e)
    {
        // Set default values directly here
        int defaultCount = 1;
        double defaultMinAngle = 0, defaultMaxAngle = 360;
        double defaultMinX = 0, defaultMaxX = 0;
        double defaultMinY = 0, defaultMaxY = 0;
        double defaultMinParticleSpeed = 1, defaultMaxParticleSpeed = 1;
        int defaultParticleLifetimeInMs = 2000, defaultDelayBetweenParticlesInMs = 0;

        // Parse each entry, falling back to default values if empty or parsing fails
        int count = int.TryParse(CountEntry.Text, out var parsedCount) ? parsedCount : defaultCount;
        double minAngle = double.TryParse(MinAngleEntry.Text, out var parsedMinAngle) ? parsedMinAngle : defaultMinAngle;
        double maxAngle = double.TryParse(MaxAngleEntry.Text, out var parsedMaxAngle) ? parsedMaxAngle : defaultMaxAngle;
        double minX = double.TryParse(MinXEntry.Text, out var parsedMinX) ? parsedMinX : defaultMinX;
        double maxX = double.TryParse(MaxXEntry.Text, out var parsedMaxX) ? parsedMaxX : defaultMaxX;
        double minY = double.TryParse(MinYEntry.Text, out var parsedMinY) ? parsedMinY : defaultMinY;
        double maxY = double.TryParse(MaxYEntry.Text, out var parsedMaxY) ? parsedMaxY : defaultMaxY;
        double minParticleSpeed = double.TryParse(MinParticleSpeedEntry.Text, out var parsedMinParticleSpeed) ? parsedMinParticleSpeed : defaultMinParticleSpeed;
        double maxParticleSpeed = double.TryParse(MaxParticleSpeedEntry.Text, out var parsedMaxParticleSpeed) ? parsedMaxParticleSpeed : defaultMaxParticleSpeed;
        int minParticleLifetimeInMs = int.TryParse(MinParticleLifetimeEntry.Text, out var parsedMinParticleLifetimeInMs) ? parsedMinParticleLifetimeInMs : defaultParticleLifetimeInMs;
        int maxParticleLifetimeInMs = int.TryParse(MinParticleLifetimeEntry.Text, out var parsedMaxParticleLifetimeInMs) ? parsedMaxParticleLifetimeInMs : defaultParticleLifetimeInMs;
        int delayBetweenParticlesInMs = int.TryParse(DelayBetweenParticlesEntry.Text, out var parsedDelayBetweenParticlesInMs) ? parsedDelayBetweenParticlesInMs : defaultDelayBetweenParticlesInMs;

        await DemoParticleSystem.GenerateParticlesAsync(count, minAngle, maxAngle, minX, maxX, minY, maxY, minParticleSpeed, maxParticleSpeed, minParticleLifetimeInMs, maxParticleLifetimeInMs, delayBetweenParticlesInMs);
    }
}