namespace MVVM.Sample.Views;

public partial class PerformancePage : ContentPage
{
    public PerformancePage()
    {
        InitializeComponent();
        StartAnimation();
    }

    private async void StartAnimation()
    {
        var toRight = true;
        while (true) // Infinite loop for continuous animation
        {
            // Calculate the translation based on the current direction and width of the page
            // var translateToX = toRight ? Width - animatedBox.Width : -Width + animatedBox.Width;
            var translateToX = toRight ? 150 : -150;

            // Run the animation
            var direction = toRight ? "right" : "left";
            Console.WriteLine($"Moving to {direction}. X: {translateToX}");
            await animatedBox.TranslateTo(translateToX, 0, 1000, Easing.SinInOut);

            // Toggle the direction
            toRight = !toRight;
        }
    }
}
