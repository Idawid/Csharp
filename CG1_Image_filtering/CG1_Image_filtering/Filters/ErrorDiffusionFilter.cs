using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CG1_Image_filtering.Filters
{
    public class ErrorDiffusionFilter : ConvolutionFilter, IErrorDiffusionFilter
    {
        public int ColorsPerChannel { get; set; }

        public ErrorDiffusionFilter(string name, double[,] kernel, int colorDepth = 8, double divisor = 0,
            double offset = 0, Point anchor = default) : base(name, kernel, divisor, offset, anchor)
        {
            ColorsPerChannel = colorDepth;
            if (ColorsPerChannel <= 1)
            {
                throw new ArgumentException("Color depth was set too low");
            }
        }

        public ErrorDiffusionFilter(ErrorDiffusionFilter filter) : base(filter)
        {
            ColorsPerChannel = (filter != null) ? filter.ColorsPerChannel : 8;
        }

        public override unsafe Bitmap Apply(Bitmap originalImage)
        {
            int kernelWidth = Kernel.GetLength(0);
            int kernelHeight = Kernel.GetLength(1);
            int kernelOffsetX = Anchor.X;
            int kernelOffsetY = Anchor.Y;

            Bitmap result = (Bitmap)originalImage.Clone();

            BitmapData resultData = result.LockBits(new Rectangle(0, 0, result.Width, result.Height),
                ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);

            byte* resultPointer = (byte*)resultData.Scan0;

            const int bytesPerPixel = 4; // 4 channels

            for (int y = 0; y < result.Height; y++)
            {
                for (int x = 0; x < result.Width; x++)
                {
                    int offset = y * resultData.Stride + x * bytesPerPixel;

                    // Approximate
                    Color approximatedColor = GetClosestColor(
                        Color.FromArgb(
                            resultPointer[offset + 2],
                            resultPointer[offset + 1],
                            resultPointer[offset + 0]));

                    // Calculate the error before setting the pixel
                    int errorB = resultPointer[offset + 0] - approximatedColor.B;
                    int errorG = resultPointer[offset + 1] - approximatedColor.G;
                    int errorR = resultPointer[offset + 2] - approximatedColor.R;

                    // Set the approximated pixel values at the anchor point
                    resultPointer[offset + 0] = approximatedColor.B;
                    resultPointer[offset + 1] = approximatedColor.G;
                    resultPointer[offset + 2] = approximatedColor.R;

                    for (int ky = 0; ky < kernelHeight; ky++)
                    {
                        for (int kx = 0; kx < kernelWidth; kx++)
                        {
                            double kernelWeight = Kernel[kx, ky];

                            if (kernelWeight == 0)
                            {
                                // So it doesn't override the anchor pixel later on
                                continue;
                            }

                            int pixelX = x + kx - kernelOffsetX;
                            int pixelY = y + ky - kernelOffsetY;

                            int pixelOffset = pixelY * resultData.Stride + pixelX * bytesPerPixel;

                            if (pixelX >= 0 && pixelX < result.Width && pixelY >= 0 && pixelY < result.Height)
                            {
                                // Add the approximation error to neighboring pixels

                                resultPointer[pixelOffset + 0] = (byte)Clamp((int)(resultPointer[pixelOffset + 0] + errorB * kernelWeight));
                                resultPointer[pixelOffset + 1] = (byte)Clamp((int)(resultPointer[pixelOffset + 1] + errorG * kernelWeight));
                                resultPointer[pixelOffset + 2] = (byte)Clamp((int)(resultPointer[pixelOffset + 2] + errorR * kernelWeight));
                            }
                        }
                    }
                }
            }

            result.UnlockBits(resultData);

            return result;
        }

        private Color GetClosestColor(Color inputColor)
        {
            int stepSize = 255 / (ColorsPerChannel - 1);
            int colorR = (int)Clamp((Math.Round((double)inputColor.R / stepSize) * stepSize));
            int colorG = (int)Clamp((Math.Round((double)inputColor.G / stepSize) * stepSize));
            int colorB = (int)Clamp((Math.Round((double)inputColor.B / stepSize) * stepSize));
            Color ColorTwo = Color.FromArgb(colorR, colorG, colorB);
            return ColorTwo;
        }
    }
}
