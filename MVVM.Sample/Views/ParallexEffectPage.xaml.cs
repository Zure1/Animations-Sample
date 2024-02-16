namespace MVVM.Sample.Views;

public partial class ParallexEffectPage : ContentPage
{
	public ParallexEffectPage()
	{
		InitializeComponent();
        scrollView.Scrolled += OnScrollViewScrolled;
    }

    private void OnScrollViewScrolled(object? sender, ScrolledEventArgs e)
    {
        // Adjust these factors to change the speed of the parallax effect for each element
        double parallaxFactor1 = 0.3;
        double parallaxFactor2 = 0.15;

        // Calculate new positions based on scroll position and parallax factor
        double newPosition1 = e.ScrollY * parallaxFactor1;
        double newPosition2 = e.ScrollY * parallaxFactor2;

        // Apply the calculated positions to the Y translation of foreground elements
        // This moves them at a different speed than the scrolling background, creating a parallax effect
        fgImage1_1.TranslationY = newPosition1;
        fgImage1_2.TranslationY = newPosition2;
        fgText1.TranslationY = newPosition1; // Additional offset for text to follow the image

        fgImage2_1.TranslationY = newPosition1;
        fgImage2_2.TranslationY = newPosition2;
        fgText2.TranslationY = newPosition1; // Adjust these values as needed for your layout

        fgImage3.TranslationY = newPosition1;
        fgText3.TranslationY = newPosition1;
    }
}
