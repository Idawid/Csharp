using EffectPlugin;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace VerticalEffect
{
    //mirrored HorizontalEffect
	public class VerticalEffect : IEffect
	{
        public string Name { get; } = "Vertical effect";
        public void PlayAnimation(Image imageIn, Image imageOut, Size size, int duration)
		{
            Storyboard sbIn = new Storyboard();
            Storyboard sbOut = new Storyboard();

            imageIn.VerticalAlignment = VerticalAlignment.Top;
            imageOut.VerticalAlignment = VerticalAlignment.Bottom;

            var comein = new DoubleAnimation();
            comein.Duration = new Duration(TimeSpan.FromMilliseconds(duration));
            comein.From = 720;
            comein.To = 0;

            var comeout = new DoubleAnimation();
            comeout.Duration = new Duration(TimeSpan.FromMilliseconds(duration));
            comeout.From = 0;
            comeout.To = 720;

            Storyboard.SetTargetProperty(comein, new PropertyPath(Window.HeightProperty));
            Storyboard.SetTargetProperty(comeout, new PropertyPath(Window.HeightProperty));
            Storyboard.SetTarget(comeout, imageOut);
            Storyboard.SetTarget(comein, imageIn);

            sbIn.Children.Add(comein);
            sbOut.Children.Add(comeout);

            sbIn.Begin();
            sbOut.Begin();
        }
	}
}
