using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CG1_Image_filtering.Filters
{
    internal class YCBCRDiffusionFilter : ErrorDiffusionFilter
    {
        public YCBCRDiffusionFilter(string name, double[,] kernel, int colorDepth = 8, double divisor = 0, double offset = 0, Point anchor = default) : base(name, kernel, colorDepth, divisor, offset, anchor)
        {
            // Pass
        }

        public YCBCRDiffusionFilter(YCBCRDiffusionFilter filter) : base(filter) 
        {
            // Pass
        }

        public override unsafe Bitmap Apply(Bitmap originalImage)
        {
            var ErrorDiffusionFilter = new ErrorDiffusionFilter(this);

            Bitmap result = (Bitmap)originalImage.Clone();

            result = RGBtoYCBCR(result);
            result = ErrorDiffusionFilter.Apply(result);
            result = YCBCRtoRGB(result);

            return result;
        }

        public Bitmap RGBtoYCBCR(Bitmap bmp)
        {
            Bitmap ycbcrBmp = new Bitmap(bmp.Width, bmp.Height);

            for (int x = 0; x < bmp.Width; x++)
            {
                for (int y = 0; y < bmp.Height; y++)
                {
                    Color pixel = bmp.GetPixel(x, y);

                    int r = pixel.R;
                    int g = pixel.G;
                    int b = pixel.B;

                    int Y  = (int) Clamp((0.299 * r + 0.587 * g + 0.114 * b));
                    int Cb = (int) Clamp((128 - 0.168736 * r - 0.331264 * g + 0.5 * b));
                    int Cr = (int) Clamp((128 + 0.5 * r - 0.418688 * g - 0.081312 * b));

                    ycbcrBmp.SetPixel(x, y, Color.FromArgb(Y, Cb, Cr));
                }
            }

            return ycbcrBmp;
        }

        public Bitmap YCBCRtoRGB(Bitmap bmp)
        {
            Bitmap rgbBmp = new Bitmap(bmp.Width, bmp.Height);

            for (int x = 0; x < bmp.Width; x++)
            {
                for (int y = 0; y < bmp.Height; y++)
                {
                    Color pixel = bmp.GetPixel(x, y);

                    int Y = pixel.R;
                    int Cb = pixel.G;
                    int Cr = pixel.B;

                    int r = (int) Clamp((Y + 1.402 * (Cr - 128)));
                    int g = (int) Clamp((Y - 0.344136 * (Cb - 128) - 0.714136 * (Cr - 128)));
                    int b = (int) Clamp((Y + 1.772 * (Cb - 128)));

                    rgbBmp.SetPixel(x, y, Color.FromArgb(r, g, b));
                }
            }

            return rgbBmp;
        }
    }
}
