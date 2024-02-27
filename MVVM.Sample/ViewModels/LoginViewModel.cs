using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace MVVM.Sample.ViewModels;

public class LoginViewModel : INotifyPropertyChanged
{
    public event EventHandler? LoginFailed;
    public event PropertyChangedEventHandler? PropertyChanged;

    private string _loginErrorHintText = string.Empty;
    private bool _isBusy;

    public LoginViewModel()
    {
        LoginCommand = new Command(async () => await LoginAsync());
    }

    public ICommand LoginCommand { get; }

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