using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cube3D
{
	internal class Utils
	{
		public static void DrawXiaolinWuLine(Graphics graphics, Color color, Color background, int x1, int y1, int x2, int y2)
		{
			Color L = color;
			Color B = background;

			// Slope
			float dx = x2 - x1;
			float dy = y2 - y1;
			float m = dy / dx;

			bool steep = Math.Abs(dy) > Math.Abs(dx);

			if (steep)
			{
				if (y1 > y2)
				{
					int temp = x1;
					x1 = x2;
					x2 = temp;

					temp = y1;
					y1 = y2;
					y2 = temp;
				}

				float x = x1;
				for (int y = y1; y <= y2; ++y)
				{
					float fpart = x - (float)Math.Floor(x);
					float rfpart = 1.0f - fpart;

					// modf
					Color c1 = Color.FromArgb(
						(int)Math.Round(L.A * rfpart + B.A * fpart),
						(int)Math.Round(L.R * rfpart + B.R * fpart),
						(int)Math.Round(L.G * rfpart + B.G * fpart),
						(int)Math.Round(L.B * rfpart + B.B * fpart)
					);

					// modf
					Color c2 = Color.FromArgb(
						(int)Math.Round(L.A * fpart + B.A * rfpart),
						(int)Math.Round(L.R * fpart + B.R * rfpart),
						(int)Math.Round(L.G * fpart + B.G * rfpart),
						(int)Math.Round(L.B * fpart + B.B * rfpart)
					);

					putPixel(graphics, c1, (int)Math.Floor(x), y);

					putPixel(graphics, c2, (int)Math.Floor(x) + 1, y);

					x += (dx / dy);
				}
			}
			else
			{
				if (x1 > x2)
				{
					int temp = x1;
					x1 = x2;
					x2 = temp;

					temp = y1;
					y1 = y2;
					y2 = temp;
				}

				float y = y1;
				for (int x = x1; x <= x2; ++x)
				{
					float fpart = y - (float)Math.Floor(y);
					float rfpart = 1.0f - fpart;

					// modf
					Color c1 = Color.FromArgb(
						(int)Math.Round(L.A * rfpart + B.A * fpart),
						(int)Math.Round(L.R * rfpart + B.R * fpart),
						(int)Math.Round(L.G * rfpart + B.G * fpart),
						(int)Math.Round(L.B * rfpart + B.B * fpart)
					);

					// modf
					Color c2 = Color.FromArgb(
						(int)Math.Round(L.A * fpart + B.A * rfpart),
						(int)Math.Round(L.R * fpart + B.R * rfpart),
						(int)Math.Round(L.G * fpart + B.G * rfpart),
						(int)Math.Round(L.B * fpart + B.B * rfpart)
					);

					putPixel(graphics, c1, x, (int)Math.Floor(y));

					putPixel(graphics, c2, x, (int)Math.Floor(y) + 1);

					y += m;
				}
			}
		}

		private static void putPixel(Graphics graphics, Color color, int x, int y)
		{
			graphics.FillRectangle(new SolidBrush(color), x, y, 1, 1);
		}
	}
}
