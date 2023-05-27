using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CG1_Image_filtering.Filters
{
	class MedianFilter : IFilter
	{
		public string Name { get; }
        private int kernelSize { get; }

        public MedianFilter(string name, int kernelSize = 1)
        {
            Name = name;
            this.kernelSize = kernelSize;
        }
        public Bitmap Apply(Bitmap originalImage)
		{
            Bitmap result = new Bitmap(originalImage.Width, originalImage.Height);

            for (int x = 0; x < originalImage.Width; x++)
            {
                for (int y = 0; y < originalImage.Height; y++)
                {
                    List<int> rValues = new List<int>();
                    List<int> gValues = new List<int>();
                    List<int> bValues = new List<int>();

                    for (int i = -kernelSize; i <= kernelSize; i++)
                    {
                        for (int j = -kernelSize; j <= kernelSize; j++)
                        {
                            Color pixel;
                            int pixelX = x + j;
                            int pixelY = y + i;
                            if (pixelX < 0 || pixelX >= originalImage.Width || pixelY < 0 || pixelY >= originalImage.Height)
                            {
                                pixel = Color.FromArgb(0, 0, 0);
                            }
                            else
                            {
                                pixel = originalImage.GetPixel(pixelX, pixelY);
                            }
                            rValues.Add(pixel.R);
                            gValues.Add(pixel.G);
                            bValues.Add(pixel.B);
                        }
                    }

                    rValues.Sort();
                    gValues.Sort();
                    bValues.Sort();

                    int medianIndex = (kernelSize * kernelSize) / 2;

                    Color newColor = Color.FromArgb(
                        rValues[medianIndex],
                        gValues[medianIndex],
                        bValues[medianIndex]);

                    result.SetPixel(x, y, newColor);
                }
            }

            return result;
        }
	}
}
