using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace EffectPlugin
{
	public interface IEffect
	{
		public string Name { get; }
		public void PlayAnimation(Image image, Image image1, Size size, int duration);
	}
}
