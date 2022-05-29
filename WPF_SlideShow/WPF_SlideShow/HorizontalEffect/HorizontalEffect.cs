using EffectPlugin;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

//link:
//https://stackoverflow.com/questions/24139541/smooth-animate-wpf-window-width-and-height-together-with-left-and-top-property
namespace HorizontalEffect
{
    public class HorizontalEffect : IEffect
    {
        public string Name { get; } = "Horizontal effect";

        public void PlayAnimation(Image imageOut, Image imageIn, Size size, int duration)
        {

            Storyboard sbIn = new Storyboard();
            Storyboard sbOut = new Storyboard();

            imageOut.HorizontalAlignment = HorizontalAlignment.Left;
            imageIn.HorizontalAlignment = HorizontalAlignment.Right;

            var comein = new DoubleAnimation();
            comein.Duration = new Duration(TimeSpan.FromMilliseconds(duration));
            comein.From = 0;
            comein.To = 1024;

            var comeout = new DoubleAnimation();
            comeout.Duration = new Duration(TimeSpan.FromMilliseconds(duration));
            comeout.From = 1024;
            comeout.To = 0;

            Storyboard.SetTargetProperty(comein, new PropertyPath(Window.WidthProperty));
            Storyboard.SetTargetProperty(comeout, new PropertyPath(Window.WidthProperty));
            Storyboard.SetTarget(comein, imageIn);
            Storyboard.SetTarget(comeout, imageOut);

            sbIn.Children.Add(comein);
            sbOut.Children.Add(comeout);

            sbOut.Begin();
            sbIn.Begin();
        }
    }
}

//            image.HorizontalAlignment = HorizontalAlignment.Left;
//            image1.HorizontalAlignment = HorizontalAlignment.Right;
//            Storyboard sb;
//            Storyboard sb2;
//            sb = new Storyboard();
//            sb2 = new Storyboard();

//            DoubleAnimation animation = new DoubleAnimation(0.0, windowWidth, new TimeSpan(0, 0, 0, 0, 500));
//            Storyboard.SetTargetProperty(animation, new PropertyPath(FrameworkElement.WidthProperty));
//            Storyboard.SetTarget(animation, imageIn);

//            DoubleAnimation animation2 = new DoubleAnimation(windowWidth, 0.0, new TimeSpan(0, 0, 0, 0, 500));
//            Storyboard.SetTargetProperty(animation2, new PropertyPath(FrameworkElement.WidthProperty));
//            Storyboard.SetTarget(animation2, imageOut);
//            sb.Children.Add(animation);
//            sb2.Children.Add(animation2);
//            sb2.Begin();
//            sb.Begin();
//        }
//	}
//}
