using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CG1_Image_filtering
{
    public interface IFunctionFilter : IFilter
    {
        Func<Color, Color> Function { get; set; }
    }
}
