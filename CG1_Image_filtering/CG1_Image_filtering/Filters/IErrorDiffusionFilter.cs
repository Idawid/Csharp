using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CG1_Image_filtering
{
    public interface IErrorDiffusionFilter : IFilter
    {
        double[,] Kernel { get; set; }
        int ColorsPerChannel { get; set; }
    }
}
