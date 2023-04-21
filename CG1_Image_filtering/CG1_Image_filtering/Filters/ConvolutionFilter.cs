using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CG1_Image_filtering.Filters
{
	public class ConvolutionFilter : IConvolutionFilter
	{
		public string Name { get; set; }
		public double[,] Kernel { get; set; }
		public double Divisor { get; set; }
		public double Offset { get; set; }
		public Point Anchor { get; set; }

		public ConvolutionFilter(string name, double[,] kernel, double divisor = 0,
            double offset = 0, Point anchor = default(Point))
		{
			Name = name;
			Kernel = kernel;
			Divisor = (divisor == 0) ? kernel.Cast<double>().Sum() : divisor;
			Offset = offset;
            Anchor = anchor;
            if (anchor == default(Point))
            {
                Anchor = new Point(Kernel.GetLength(0) / 2, Kernel.GetLength(1) / 2);
            }

			if (Divisor == 0)
			{
				throw new ArgumentException("Divisor was set to 0");
			}
		}

		public ConvolutionFilter(ConvolutionFilter filter)
		{
			if (filter != null)
			{
				Name = filter.Name;
				Kernel = filter.Kernel;
				Divisor = filter.Divisor;
				Offset = filter.Offset;
				Anchor = filter.Anchor;
			}
			else
			{
				Name = string.Empty;
				Kernel = new double[,]
				{
					{ 1, 1, 1 },
					{ 1, 1, 1 },
					{ 1, 1, 1 }
				};
				Divisor = 1;
				Offset = 0;
				Anchor = default(Point);
			}
		}

        public virtual unsafe Bitmap Apply(Bitmap originalImage)
        {
            int kernelWidth = Kernel.GetLength(0);
            int kernelHeight = Kernel.GetLength(1);
            int kernelOffsetX = Anchor.X;
            int kernelOffsetY = Anchor.Y;
            double kernelDivisor = Divisor;
            double kernelOffset = Offset;

            Bitmap result = new Bitmap(originalImage.Width, originalImage.Height);
            
            BitmapData originalData = originalImage.LockBits(new Rectangle(0, 0, originalImage.Width, originalImage.Height),
                ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
            BitmapData resultData = result.LockBits(new Rectangle(0, 0, result.Width, result.Height),
                ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);

            byte* originalPointer = (byte*)originalData.Scan0;
            byte* resultPointer = (byte*)resultData.Scan0;

            const int bytesPerPixel = 4; // Format32bppArgb 32 = 8 * 4

            for (int y = 0; y < originalImage.Height; y++)
            {
                for (int x = 0; x < originalImage.Width; x++)
                {
                    double r = 0, g = 0, b = 0;

                    for (int ky = 0; ky < kernelHeight; ky++)
                    {
                        for (int kx = 0; kx < kernelWidth; kx++)
                        {
                            double kernelValue = Kernel[kx, ky];
                            // X,Y position of the selected pixel in the kernel
                            int pixelX = x + kx - kernelOffsetX;
                            int pixelY = y + ky - kernelOffsetY;

                            int pixelOffset = pixelY * originalData.Stride + pixelX * bytesPerPixel;

                            if (pixelX >= 0 && pixelX < originalImage.Width && pixelY >= 0 && pixelY < originalImage.Height)
                            {
                                b += (double)originalPointer[pixelOffset] * kernelValue;
                                g += (double)originalPointer[pixelOffset + 1] * kernelValue;
                                r += (double)originalPointer[pixelOffset + 2] * kernelValue;
                            }
                        }
                    }

                    r /= kernelDivisor;
                    g /= kernelDivisor;
                    b /= kernelDivisor;

                    r += kernelOffset;
                    g += kernelOffset;
                    b += kernelOffset;

                    r = Clamp(r);
                    g = Clamp(g);
                    b = Clamp(b);

                    byte* filteredPixelPtr = resultPointer + y * originalData.Stride + x * bytesPerPixel;
                    filteredPixelPtr[0] = (byte)b;
                    filteredPixelPtr[1] = (byte)g;
                    filteredPixelPtr[2] = (byte)r;
                    filteredPixelPtr[3] = 255;
                }
            }
            originalImage.UnlockBits(originalData);
            result.UnlockBits(resultData);

            return result;
        }
        protected double Clamp(double value)
        {
            return Math.Max(0, Math.Min(255, value));
        }
        protected int Clamp(int value)
        {
            return Math.Max(0, Math.Min(255, value));
        }
    }
}
