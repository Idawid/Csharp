using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CG1_Image_filtering.Filters
{
    public class UniformQuantizationFilter : FunctionFilter
    {
        public int RedDivisions { get; set; }
        public int GreenDivisions { get; set; }
        public int BlueDivisions { get; set; }
        public UniformQuantizationFilter(string name, int redDivisions, int greenDivisions, int blueDivisions,
            Func<Color, Color> function) : base(name, function)
        {
            RedDivisions = redDivisions;
            GreenDivisions = greenDivisions;
            BlueDivisions = blueDivisions;

            Function = c => {
                // Divisions' count is the step size
                int r = (int)Clamp(Math.Round((double)c.R / (255 / (RedDivisions - 1))) * (255 / (RedDivisions - 1)));
                int g = (int)Clamp(Math.Round((double)c.G / (255 / (GreenDivisions - 1))) * (255 / (GreenDivisions - 1)));
                int b = (int)Clamp(Math.Round((double)c.B / (255 / (BlueDivisions - 1))) * (255 / (BlueDivisions - 1)));

                return function(Color.FromArgb(r, g, b));
            };
        }
    }
}
