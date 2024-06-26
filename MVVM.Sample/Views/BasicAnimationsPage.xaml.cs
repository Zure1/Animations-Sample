﻿namespace MVVM.Sample.Views;

public partial class BasicAnimationsPage : ContentPage
{
	public BasicAnimationsPage()
	{
		InitializeComponent();
	}

    private async void OnRotateLeftClicked(object sender, EventArgs e)
    {
        // Rotate the image 90° to the left.
        await AnimatedImage.RotateTo(AnimatedImage.Rotation - 90, 200);
    }

    private async void OnRotateRightClicked(object sender, EventArgs e)
    {
        // Rotate the image 90° to the right.
        await AnimatedImage.RotateTo(AnimatedImage.Rotation + 90, 200);
    }

    private async void OnSpringAnimationButtonClicked(object sender, EventArgs e)
    {
        // Scale up quickly
        await AnimatedImage.ScaleTo(1.5, 100);

        // Scale down a bit slower
        await AnimatedImage.ScaleTo(0.8, 150);

        // Scale back up a bit slower
        await AnimatedImage.ScaleTo(1.2, 150);

        // Return to normal size quickly
        await AnimatedImage.ScaleTo(1, 100);
    }

    private async void OnFullscreenButtonClicked(object sender, EventArgs e)
    {
        // Scale to full screen
        await AnimatedImage.ScaleTo(3, 500); // You may need to adjust the scale factor and length of animation to suit your app

        // Wait for 1 second
        await Task.Delay(1000);

        // Scale back to original size
        await AnimatedImage.ScaleTo(1, 500);
    }

    async void ShowNotificationButtonClicked(object sender, EventArgs e)
    {
        // Make the banner visible and animate it into view
        notification.IsVisible = true;
        await notification.TranslateTo(0, 0, 500);

        // Wait for 2 seconds
        await Task.Delay(2000);

        // Animate the banner back out of view and hide it
        await notification.TranslateTo(0, -60, 500);
        notification.IsVisible = false;
    }

    async void FadeAnimationButtonClicked(object sender, EventArgs e)
    {
        splashscreen.IsVisible = true;

        // Fade the splash screen in, wait 2 seconds, then fade it out.
        await splashscreen.FadeTo(1, 500);
        await Task.Delay(2000);
        await splashscreen.FadeTo(0, 500);

        splashscreen.IsVisible = false;
    }
}