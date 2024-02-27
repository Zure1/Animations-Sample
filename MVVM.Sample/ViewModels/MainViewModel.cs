using System.Windows.Input;
using MVVM.Sample.Views;

namespace MVVM.Sample.ViewModels
{
    // Animatinos Tutorial: https://www.youtube.com/watch?v=48qN1h0DUjs
    public class MainViewModel
	{
        public MainViewModel()
        {
            OpenLoginPageCommand = new Command(async () => await Shell.Current.GoToAsync(nameof(LoginPage)));
            OpenCardPageCommand = new Command(async () => await Shell.Current.GoToAsync(nameof(CardPage)));
            OpenParallexScrollingExampleCommand = new Command(async () => await Shell.Current.GoToAsync(nameof(ParallexEffectPage)));
            OpenParticleEffectsPageCommand = new Command(async () => await Shell.Current.GoToAsync(nameof(ParticleEffectsPage)));
            OpenBasicAnimationsPageCommand = new Command(async () => await Shell.Current.GoToAsync(nameof(BasicAnimationsPage)));
        }


        public ICommand OpenCardPageCommand { get; }
        public ICommand OpenLoginPageCommand { get; }
        public ICommand OpenParallexScrollingExampleCommand { get; }
        public ICommand OpenParticleEffectsPageCommand { get; }
        public ICommand OpenBasicAnimationsPageCommand { get; }
    }
}