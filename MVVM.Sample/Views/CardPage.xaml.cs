namespace MVVM.Sample.Views;

public partial class CardPage : ContentPage
{
	private bool _isFlipped = false;

	public CardPage()
	{
		InitializeComponent();
	}

    private async void OnCardTappedAsync(object sender, EventArgs e)
    {
        // Animate the flip effect
        if (!_isFlipped)
        {
            await FlipCard.RotateYTo(90, 250, Easing.Linear);
            CardFront.IsVisible = false;
            CardBack.IsVisible = true;

            // Counter-rotate the back content to correct the mirrored text
            CardBack.RotationY = 180;
            await FlipCard.RotateYTo(180, 250, Easing.Linear);
        }
        else
        {
            await FlipCard.RotateYTo(270, 250, Easing.Linear);
            CardFront.IsVisible = true;
            CardBack.IsVisible = false;

            // Reset the back content rotation for the next flip
            CardBack.RotationY = 0;
            await FlipCard.RotateYTo(360, 250, Easing.Linear);
            FlipCard.RotationY = 0; // Reset the rotation to avoid accumulation
        }

        _isFlipped = !_isFlipped;
    }
}
