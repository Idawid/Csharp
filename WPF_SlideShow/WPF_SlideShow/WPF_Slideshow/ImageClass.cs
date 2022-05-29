using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace WPF_Slideshow
{
    public class ImageClass
    {
        public ImageClass(string title, ImageSource image, string path)
        {
            this.Title = title;
            this.Image = image;
            this.Path = path;
        }

        public string Path { get; set; }
        public string Title { get; set; }
        public ImageSource Image { get; set; }
    }
}
