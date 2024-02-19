using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using MVVM.Sample.Views;

namespace MVVM.Sample.ViewModels
{
    // Animatinos Tutorial: https://www.youtube.com/watch?v=48qN1h0DUjs
    public class MainViewModel : INotifyPropertyChanged
	{
        private string _loginErrorHintText = string.Empty;
        private bool _isBusy;

        public MainViewModel()
        {
            LoginCommand = new Command(async () => await LoginAsync());
            OpenCardPageCommand = new Command(async () => await Shell.Current.GoToAsync(nameof(CardPage)));
            OpenParallexScrollingExampleCommand = new Command(async () => await Shell.Current.GoToAsync(nameof(ParallexEffectPage)));
            OpenParticleEffectsPageCommand = new Command(async () => await Shell.Current.GoToAsync(nameof(ParticleEffectsPage)));
        }

        public bool IsBusy
        {
            get => _isBusy;
            set
            {
                if (_isBusy != value)
                {
                    _isBusy = value;
                    OnPropertyChanged();
                }
            }
        }

        public ICommand LoginCommand { get; }
        public ICommand OpenCardPageCommand { get; }
        public ICommand OpenParallexScrollingExampleCommand { get; }
        public ICommand OpenParticleEffectsPageCommand { get; }

        public event PropertyChangedEventHandler? PropertyChanged;
        public event EventHandler? LoginFailed;

        public string LoginErrorHintText
        {
            get => _loginErrorHintText;
            set
            {
                if (_loginErrorHintText != value)
                {
                    _loginErrorHintText = value;
                    OnPropertyChanged();
                }
            }
        }

        private async Task LoginAsync()
        {
            IsBusy = true;
            LoginErrorHintText = string.Empty;
            await Task.Delay(2500);
            LoginErrorHintText = "Username/Password combination not found!";
            LoginFailed?.Invoke(this, new EventArgs());
            IsBusy = false;
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}