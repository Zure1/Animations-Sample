using System.Windows.Input;

namespace MVVM.Sample.ViewModels;

public class ParticleEffectsViewModel
{
    public ICommand StartAnimationCommand { get; }
    public event EventHandler? StartAnimationEvent;

    public ParticleEffectsViewModel()
	{
        StartAnimationCommand = new Command(() => StartAnimationEvent?.Invoke(this, new EventArgs()));
	}
}