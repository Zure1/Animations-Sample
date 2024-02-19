namespace MVVM.Sample.CustomControls;

using Microsoft.Maui.Controls;
using Microsoft.Maui.Layouts;
using System;

public class ParticleSystem : ContentView
{
    public static readonly BindableProperty ParticleTemplateProperty =
        BindableProperty.Create(nameof(ParticleTemplate), typeof(DataTemplate), typeof(ParticleSystem));

    public DataTemplate ParticleTemplate
    {
        get => (DataTemplate)GetValue(ParticleTemplateProperty);
        set => SetValue(ParticleTemplateProperty, value);
    }

    // Adjust the method signature to be asynchronous
    public async Task GenerateParticlesAsync(
        int count = 1,
        double minAngle = 0,
        double maxAngle = 360,
        double minX = 0,
        double maxX = 0,
        double minY = 0,
        double maxY = 0,
        double minParticleSpeed = 1d,
        double maxParticleSpeed = 1d,
        int minParticleLifetimeInMs = 2000,
        int maxParticleLifetimeInMs = 2000,
        int delayBetweenParticlesInMs = 0)
    {
        var layout = new AbsoluteLayout();
        Content = layout;

        var random = new Random();
        for (int i = 0; i < count; i++)
        {
            if (ParticleTemplate.CreateContent() is View particle)
            {
                // Randomize starting position within specified bounds
                var startX = minX + (maxX - minX) * random.NextDouble();
                var startY = minY + (maxY - minY) * random.NextDouble();

                particle.Opacity = 1;
                AbsoluteLayout.SetLayoutBounds(particle, new Rect(startX, startY, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));
                AbsoluteLayout.SetLayoutFlags(particle, AbsoluteLayoutFlags.None);
                layout.Children.Add(particle);

                // Convert angle from degrees to radians for direction
                var angleDegrees = minAngle + (maxAngle - minAngle) * random.NextDouble();
                var randomParticleSpeed = minParticleSpeed + (maxParticleSpeed - minParticleSpeed) * random.NextDouble();
                var randomParticleLifetime = minParticleLifetimeInMs + (maxParticleLifetimeInMs - minParticleLifetimeInMs) * random.NextDouble();
                var radians = (Math.PI / 180) * angleDegrees;
                var moveX = Math.Cos(radians) * 0.01;
                var moveY = Math.Sin(radians) * 0.01;

                // Define the movement and fading animation
                var animation = new Animation
                {
                    { 0, 1, new Animation(v => particle.TranslationX += moveX * v * randomParticleSpeed, 0, 100) },
                    { 0, 1, new Animation(v => particle.TranslationY += moveY * v * randomParticleSpeed, 0, 100) },
                    { 0.8, 1, new Animation(v => particle.Opacity = 1 - v, 0, 1) } // Adjusted fading effect
                };

                // Commit the animation
                var animationName = $"particle{i}";
                animation.Commit(this, animationName, 16, (uint)randomParticleLifetime, Easing.Linear,
                    finished: (d, b) =>
                    {
                        layout.Children.Remove(particle);
                    });

                // Introduce a delay between particle generations if specified
                if (delayBetweenParticlesInMs > 0)
                {
                    await Task.Delay(delayBetweenParticlesInMs);
                }
            }
        }
    }
}
