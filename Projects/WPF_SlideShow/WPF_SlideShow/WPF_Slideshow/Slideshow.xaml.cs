using EffectPlugin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;


//link:
//https://www.codeproject.com/Articles/354702/WPF-Slideshowhttps://www.codeproject.com/Articles/354702/WPF-Slideshow
namespace WPF_Slideshow
{
	/// <summary>
	/// slideshow window
	/// </summary>
	public partial class Window1 : Window
	{
		public List<ImageClass> images { get; set; }
		public IEffect effect { get; set; }

		public int ctr = 0;

		public DispatcherTimer timer;

		public Window1(IEffect effect)
		{
			InitializeComponent();
			this.effect = effect;
			images = (List<ImageClass>)(Application.Current.MainWindow.DataContext);
			img.Source = images[0].Image;

			timer = new DispatcherTimer();
			timer.Tick += new EventHandler(timer_Tick);
			timer.Interval = new TimeSpan(0, 0, 4);
			timer.IsEnabled = true;
		}

		void timer_Tick(object sender, EventArgs e)
		{
			PlaySlideShow(ctr);
			ctr++;
			ctr %= images.Count;
		}
		private void PlaySlideShow(int ctr)
		// Function to display image.
		{
			ImageClass myImage = images[ctr % images.Count];
			ImageClass nextImage = images[(ctr + 1) % images.Count];

			img.Source = myImage.Image;
			img1.Source = nextImage.Image;

			effect.PlayAnimation(img, img1, new Size(1024, 720), 1000);
		}
		private void playpause(object sender, RoutedEventArgs e)
		{
			if (timer.IsEnabled)
            {
				timer.Stop();
            }
			else
            {
				timer.Start();
            }
		}
		private void stop(object sender, RoutedEventArgs e)
		{
			this.Close();
		}
		private void rightClick (object sender, RoutedEventArgs e)
		{
			ContextMenu myContextMenu = this.FindResource("rightClickMenu") as ContextMenu;
			myContextMenu.PlacementTarget = sender as Button;
			myContextMenu.IsOpen = true;
		}
	}
}
