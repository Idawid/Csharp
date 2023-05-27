using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CG1_Image_filtering
{
    public interface IConvolutionFilter : IFilter
    {
        double[,] Kernel { get; set; }
        double Divisor { get; set; }
        double Offset { get; set; }
        Point Anchor { get; set; }
    }
}
