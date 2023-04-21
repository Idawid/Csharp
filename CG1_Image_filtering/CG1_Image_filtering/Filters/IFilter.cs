using System.Drawing;

namespace CG1_Image_filtering
{
	public interface IFilter
	{
		string Name { get; }
		Bitmap Apply(Bitmap originalImage);

	}
}
