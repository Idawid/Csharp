using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CG1_Image_filtering.Filters
{
    public class FunctionFilter : IFunctionFilter
    {
        public string Name { get;}
        public Func<Color, Color> Function { get; set; }
        public FunctionFilter(string name, Func<Color, Color> function)
		{
			Name = name;
			Function = function;
		}

        public unsafe Bitmap Apply(Bitmap originalImage)
        {
            Bitmap result = new Bitmap(originalImage.Width, originalImage.Height);

            // Why it works with PixelFormat.Format32bppArgb but not originalImage.PixelFormat - i dont know they return the same values
            BitmapData originalData = originalImage.LockBits(new Rectangle(0, 0, originalImage.Width, originalImage.Height),
                ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
            BitmapData resultData = result.LockBits(new Rectangle(0, 0, result.Width, result.Height),
                ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);

            byte* originalPointer = (byte*)originalData.Scan0.ToPointer();
            byte* resultPointer = (byte*)resultData.Scan0.ToPointer();

            const int bytesPerPixel = 4; // Format32bppArgb 32 = 8 * 4

            for (int y = 0; y < originalImage.Height; y++)
            {
                for (int x = 0; x < originalImage.Width; x++)
                {
                    int offset = y * originalData.Stride + x * bytesPerPixel;
                    // ARGB -> (BGRA, Alpha is the most significant byte)
                    byte b = originalPointer[offset];
                    byte g = originalPointer[offset + 1];
                    byte r = originalPointer[offset + 2];
                    byte a = originalPointer[offset + 3];
                    // 
                    Color newColor = Function(Color.FromArgb(a, r, g, b));

                    resultPointer[offset] = newColor.B;
                    resultPointer[offset + 1] = newColor.G;
                    resultPointer[offset + 2] = newColor.R;
                    resultPointer[offset + 3] = newColor.A;
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
