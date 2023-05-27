using EffectPlugin;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace OpacityEffect
{
	public class OpacityEffect : IEffect
	{
        public string Name { get; } = "Opacity effect";
        public void PlayAnimation(Image imageOut, Image ImageIn, Size size, int duration)
		{
            Storyboard sbIn = new Storyboard();
            Storyboard sbOut = new Storyboard();

            imageOut.HorizontalAlignment = HorizontalAlignment.Left;
            ImageIn.HorizontalAlignment = HorizontalAlignment.Right;

            var comein = new DoubleAnimation();
            comein.Duration = new Duration(TimeSpan.FromMilliseconds(duration));
            comein.From = 0;
            comein.To = 1;

            var comeout = new DoubleAnimation();
            comeout.Duration = new Duration(TimeSpan.FromMilliseconds(duration));
            comeout.From = 1;
            comeout.To = 0;

            Storyboard.SetTargetProperty(comein, new PropertyPath(UIElement.OpacityProperty));
            Storyboard.SetTargetProperty(comeout, new PropertyPath(UIElement.OpacityProperty));
            Storyboard.SetTarget(comein, ImageIn);
            Storyboard.SetTarget(comeout, imageOut);

            sbIn.Children.Add(comein);
            sbOut.Children.Add(comeout);

            sbOut.Begin();
            sbIn.Begin();
        }
	}
}
