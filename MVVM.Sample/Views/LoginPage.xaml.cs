using MVVM.Sample.ViewModels;

namespace MVVM.Sample.Views;

public partial class LoginPage : ContentPage
{
    private const string LoadingIndicatorAnimationNameKey = "loadingIndicatorRotation";
    private const string ShakeAnimationKey = "LoginFailedShake";

    private readonly LoginViewModel _viewModel;
    private Animation _loadingIndicatorAnimation;

    public LoginPage()
	{
		InitializeComponent();
        InitializeAnimations();

        _viewModel = (LoginViewModel)BindingContext;
        _viewModel.PropertyChanged += ViewModel_PropertyChanged;
        _viewModel.LoginFailed += ViewModel_LoginFailed;
    }

    private void InitializeAnimations()
    {
        _loadingIndicatorAnimation = new Animation(value => LoadingIndicator.Rotation = value, 0, 360, Easing.Linear);
    }

    private void ViewModel_LoginFailed(object? sender, EventArgs e)
    {
        var translationLength = 15; // Adjust based on the desired intensity of the shake
        var duration = 50; // Duration of each individual shake movement

        // Create the shake animation
        var shakeAnimation = new Animation
        {
            // Move to the right initially
            { 0, 0.25, new Animation(v => LoginContainer.TranslationX = v, 0, translationLength, Easing.SinOut) },

            // Shake back and forth
            { 0.25, 0.75, new Animation(v => LoginContainer.TranslationX = v, translationLength, -translationLength, Easing.SinInOut) },

            // End in the original position
            { 0.75, 1, new Animation(v => LoginContainer.TranslationX = v, -translationLength, 0, Easing.SinIn) }
        };

        // Commit and start the animation
        LoginContainer.Animate(ShakeAnimationKey, shakeAnimation, 16, (uint)(4 * duration), Easing.Linear,
            (v, c) => LoginContainer.TranslationX = 0);
    }

    private void ViewModel_PropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
    {
        if (e.PropertyName == nameof(_viewModel.IsBusy))
        {
            if (_viewModel.IsBusy)
            {
                // Start animation
                _loadingIndicatorAnimation.Commit(this, LoadingIndicatorAnimationNameKey, 16, 1000, Easing.SinInOut,
                    (v, c) => LoadingIndicator.Rotation = 0,
                    () => true);
            }
            else
            {
                // Stop animation
                this.AbortAnimation(LoadingIndicatorAnimationNameKey);
            }
        }
    }
}
