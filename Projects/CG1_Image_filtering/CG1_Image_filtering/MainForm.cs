using CG1_Image_filtering.Filters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CG1_Image_filtering
{
	public partial class MainForm : Form
	{
		private Bitmap originalImage;
		private Bitmap filteredImage;
		private readonly Dictionary<string, IFilter> _filters;
		private bool _isEditingFilter = false;
		public enum FilterType
		{
			FunctionFilter,
			ConvolutionFilter,
			OtherFilter
		}

		public MainForm()
		{
			InitializeComponent();

			_filters = new Dictionary<string, IFilter>();
			_isEditingFilter = false;

			InitializeFilters();

			foreach (string filterName in _filters.Keys)
			{
				if (_filters[filterName].GetType() == typeof(FunctionFilter))
				{
					FunctionFilterComboBox.Items.Add(filterName);
				}
				else if (_filters[filterName].GetType() == typeof(ConvolutionFilter))
				{
					ConvolutionFilterComboBox.Items.Add(filterName);
				}
				else
				{
					OtherFilterComboBox.Items.Add(filterName);
				}
			}
		}
		private void InitializeFilters()
		{
			// Create and add the filters

			// Box blur

			var blurFilter = new ConvolutionFilter("Blur", new double[,]
			{
				{ 1, 1, 1 },
				{ 1, 1, 1 },
				{ 1, 1, 1 }
			});

			var gaussianBlurFilter = new ConvolutionFilter("Gaussian Blur", new double[,]
			{
				{ 0, 1, 0 },
				{ 1, 4, 1 },
				{ 0, 1, 0 }
			});

			// Mean Removal Sharpen

			var sharpenFilter = new ConvolutionFilter("Sharpen", new double[,]
			{
				{ -1, -1, -1 },
				{ -1, 9, -1 },
				{ -1, -1, -1 }
			});

			// Laplacian Edge Detection

			var edgeDetectionFilter = new ConvolutionFilter("Edge Detection", new double[,]
			{
				{ -1, -1, -1 },
				{ -1, 8, -1 },
				{ -1, -1, -1 }
			}, 1, 127);

			// South‐east Emboss

			var embossFilter = new ConvolutionFilter("Emboss", new double[,]
			{
				{ -1, -1, 0 },
				{ -1, 1, 1 },
				{ 0, 1, 1 }
			});

			_filters.Add(blurFilter.Name, blurFilter);
			_filters.Add(gaussianBlurFilter.Name, gaussianBlurFilter);
			_filters.Add(sharpenFilter.Name, sharpenFilter);
			_filters.Add(edgeDetectionFilter.Name, edgeDetectionFilter);
			_filters.Add(embossFilter.Name, embossFilter);

			// Initialize function filters
			var inversionFilter = new FunctionFilter("Inversion", c =>
			{
				// No parameter
				return Color.FromArgb(255 - c.R, 255 - c.G, 255 - c.B);
			});
			var grayscaleFilter = new FunctionFilter("Grayscale", c =>
			{
				int grayValue = (int)(0.299 * c.R + 0.587 * c.G + 0.114 * c.B);
				return Color.FromArgb(grayValue, grayValue, grayValue);
			});
			var brightnessFilter = new FunctionFilter("Brightness", c =>
			{
				int brightness = 50;
				return Color.FromArgb(Clamp(c.R + brightness), Clamp(c.G + brightness), Clamp(c.B + brightness));
			});
			var contrastFilter = new FunctionFilter("Contrast enhancement", c =>
			{
				//double factor = (259.0 * (128 + 50)) / (255.0 * (259 - 50));
				double factor = 2;
				return Color.FromArgb(Clamp((int)((c.R - 128) * factor + 128)), Clamp((int)((c.G - 128) * factor + 128)), Clamp((int)((c.B - 128) * factor + 128)));
			});
			var gammaFilter = new FunctionFilter("Gamma correction", c =>
			{
				double gammaExp = 0.4;
				return Color.FromArgb(Clamp((int)(255 * Math.Pow(c.R / 255.0, gammaExp))), Clamp((int)(255 * Math.Pow(c.G / 255.0, gammaExp))), Clamp((int)(255 * Math.Pow(c.B / 255.0, gammaExp))));
			});

			_filters.Add(inversionFilter.Name, inversionFilter);
			_filters.Add(grayscaleFilter.Name, grayscaleFilter);
			_filters.Add(brightnessFilter.Name, brightnessFilter);
			_filters.Add(contrastFilter.Name, contrastFilter);
			_filters.Add(gammaFilter.Name, gammaFilter);

			// Custom median filter

			var medianFilter = new MedianFilter("Median", 3);
			_filters.Add(medianFilter.Name, medianFilter);

			// Create error diffusion filters

			var floydAndSteinbergFilter = new ErrorDiffusionFilter("Floyd and Steinberg", new double[,]
			{
				{ 0, 0, 0 },
				{ 0, 0, 7.0 / 16 },
				{ 3.0 / 16, 5.0 / 16, 1.0 / 16 }
			}, 4, 1);

			var BurkesFilter = new ErrorDiffusionFilter("Burkes", new double[,]
			{
				{ 0, 0, 0, 0, 0 },
				{ 0, 0, 0, 8.0 / 32, 8.0 / 32 },
				{ 2.0 / 32, 4.0 / 32, 8.0 / 32, 4.0 / 32, 2.0 / 32 }
			}, 4, 1);

			var StuckyFilter = new ErrorDiffusionFilter("Stucky", new double[,]
			{
				{ 0, 0, 0, 0, 0 },
				{ 0, 0, 0, 0, 0 },
				{ 0, 0, 0, 8.0 / 42, 4.0 / 42 },
				{ 2.0 / 42, 4.0 / 42, 8.0 / 42, 4.0 / 42, 2.0 / 42 },
				{ 1.0 / 42, 2.0 / 42, 4.0 / 42, 2.0 / 42, 1.0 / 42 }
			}, 4, 1);

			var SierraFilter = new ErrorDiffusionFilter("Sierra", new double[,]
			{
				{ 0, 0, 0, 0, 0 },
				{ 0, 0, 0, 0, 0 },
				{ 0, 0, 0, 5.0 / 32, 3.0 / 32 },
				{ 2.0 / 32, 4.0 / 32, 5.0 / 32, 4.0 / 32, 2.0 / 32 },
				{ 0, 2.0 / 32, 3.0 / 32, 2.0 / 32, 0 },
			}, 4, 1);

			var AtkinsonFilter = new ErrorDiffusionFilter("Atkinson", new double[,]
			{
				{ 0, 0, 0, 0, 0 },
				{ 0, 0, 0, 0, 0 },
				{ 0, 0, 0, 1.0 / 8, 1.0 / 8 },
				{ 0, 1.0 / 8, 1.0 / 8, 0, 0 },
				{ 0, 0, 1.0 / 8, 0, 0 },
			}, 4, 1);

			var YCBCRDiffusionFilter = new YCBCRDiffusionFilter("YCbCr Diffusion", new double[,]
			{
				{ 0, 0, 0 },
				{ 0, 0, 7.0 / 16 },
				{ 3.0 / 16, 5.0 / 16, 1.0 / 16 }
			}, 4, 1);
			_filters.Add(floydAndSteinbergFilter.Name, floydAndSteinbergFilter);
			_filters.Add(BurkesFilter.Name, BurkesFilter);
			_filters.Add(StuckyFilter.Name, StuckyFilter);
			_filters.Add(SierraFilter.Name, SierraFilter);
			_filters.Add(AtkinsonFilter.Name, AtkinsonFilter);
			_filters.Add(YCBCRDiffusionFilter.Name, YCBCRDiffusionFilter);

            var quantizationFilter = new UniformQuantizationFilter("Uniform Quantization",
                redDivisions: 8,
                greenDivisions: 4,
                blueDivisions: 2,
                function: c =>
                {
                    return c;
                }
            );
            _filters.Add(quantizationFilter.Name, quantizationFilter);
		}

		private int Clamp(int value)
		{
			return Math.Max(0, Math.Min(255, value));
		}

		private void LoadAndDisplayImage(string path)
		{
			originalImage = new Bitmap(path);
			OriginalPictureBox.Image = originalImage;
			ResetFilter();
		}

		private void ApplyFilter(IFilter filter)
		{
			if (OriginalPictureBox.Image == null)
			{
				MessageBox.Show("Please load an image first!");
				return;
			}

			Bitmap filteredImage;
			if (stackCheckBox.Checked)
			{
				filteredImage = filter.Apply(FilteredPictureBox.Image as Bitmap);
			}
			else
			{
				filteredImage = filter.Apply(OriginalPictureBox.Image as Bitmap);
			}
			FilteredPictureBox.Image = filteredImage;
		}

		private void SaveFilteredResult()
		{
			if (originalImage == null)
			{
				MessageBox.Show("Please load an image first!");
				return;
			}
			using (SaveFileDialog dialog = new SaveFileDialog())
			{
				dialog.Filter = "JPEG Image|*.jpg|PNG Image|*.png|BMP Image|*.bmp";
				dialog.Title = "Save filtered image";
				if (dialog.ShowDialog() == DialogResult.OK)
				{
					ImageFormat format;
					string extension = Path.GetExtension(dialog.FileName);
					switch (extension)
					{
						case ".jpg":
							format = ImageFormat.Jpeg;
							break;
						case ".png":
							format = ImageFormat.Png;
							break;
						case ".bmp":
							format = ImageFormat.Bmp;
							break;
						default:
							throw new NotSupportedException($"Unsupported file extension: {extension}");
					}
					FilteredPictureBox.Image.Save(dialog.FileName, format);
				}
			}
		}

		private void ResetFilter()
		{
			if (originalImage == null)
			{
				MessageBox.Show("Please load an image first!");
				return;
			}
			filteredImage = new Bitmap(originalImage);
			FilteredPictureBox.Image = filteredImage;
		}

		private void EditConvolutionFilter(IFilter oldFilter) {
			using (FilterEditorForm filterEditorForm = new FilterEditorForm(oldFilter as ConvolutionFilter))
			{
				DialogResult result = filterEditorForm.ShowDialog();
				if (result == DialogResult.OK)
				{
					ConvolutionFilter newFilter = new ConvolutionFilter(filterEditorForm.Filter);
					// Delete and re-add to the dictionary in case the name got changed
					if (oldFilter.Name != newFilter.Name)
					{
						if (_filters.ContainsKey(newFilter.Name))
						{
							MessageBox.Show("Your filter name has to be unique!");
							return;
						}

						_filters.Remove(oldFilter.Name);
						ConvolutionFilterComboBox.Items.Remove(oldFilter.Name);
						_filters.Add(newFilter.Name, newFilter);
						ConvolutionFilterComboBox.Items.Add(newFilter.Name);
						// This is problematic because it triggers the SelectedIndexChanged event
						ConvolutionFilterComboBox.SelectedIndex = ConvolutionFilterComboBox.Items.IndexOf(newFilter.Name);
					}
					else
					{
						_filters[newFilter.Name] = newFilter;
					}
				}
				else if (result == DialogResult.No)
				{
					_filters.Remove(oldFilter.Name);
					ConvolutionFilterComboBox.Items.Remove(oldFilter.Name);
				}
			}
		}

		private void CreateConvolutionFilter()
		{
			using (FilterEditorForm filterEditorForm = new FilterEditorForm())
			{
				DialogResult result = filterEditorForm.ShowDialog();
				if (result == DialogResult.OK)
				{
					ConvolutionFilter customFilter = new ConvolutionFilter(filterEditorForm.Filter);
					if (_filters.ContainsKey(customFilter.Name))
					{
						MessageBox.Show("Your filter name has to be unique!");
						return;
					}
					_filters.Add(customFilter.Name, customFilter);
					ConvolutionFilterComboBox.Items.Add(customFilter.Name);
					ConvolutionFilterComboBox.SelectedIndex = ConvolutionFilterComboBox.Items.IndexOf(customFilter.Name);
				}
			}
		}

		private void SelectFilter(FilterType type)
		{
			if (_isEditingFilter)
			{
				return;
			}
			string selectedFilterName;
			switch (type)
			{
				case FilterType.FunctionFilter:
					{
						selectedFilterName = FunctionFilterComboBox.SelectedItem.ToString();
						break;
					}
				case FilterType.ConvolutionFilter:
					{
						selectedFilterName = ConvolutionFilterComboBox.SelectedItem.ToString();
						break;
					}
				case FilterType.OtherFilter:
					{
						selectedFilterName = OtherFilterComboBox.SelectedItem.ToString();
						break;
					}
				default:
					throw new NotSupportedException($"Unsupported filter type: {type}");
			}

			IFilter selectedFilter = _filters[selectedFilterName];

			if (type == FilterType.ConvolutionFilter
				&& editFiltersCheckBox.Checked
				&& selectedFilter.GetType() == typeof(ConvolutionFilter))
			{
				_isEditingFilter = true;
				EditConvolutionFilter(selectedFilter);
				// In case the name gets changed
				selectedFilterName = ConvolutionFilterComboBox.SelectedItem == null ?
					"" : ConvolutionFilterComboBox.SelectedItem.ToString();
				_isEditingFilter = false;
			}

			if (_filters.ContainsKey(selectedFilter.Name))
			{
				selectedFilter = _filters[selectedFilterName];
				ApplyFilter(selectedFilter);
			}
		}

        private void TurnQuantizationFilterControls(bool _switch)
        {
            RedTrackBar.Visible = _switch;
            GreenTrackBar.Visible = _switch;
            BlueTrackBar.Visible = _switch;
			RedLabel.Visible = _switch;
			GreenLabel.Visible = _switch;
			BlueLabel.Visible = _switch;
			DivisionNumberLabel.Visible = _switch;
        }
		
		private void TurnErrorDiffusionFilterControls(bool _switch)
		{
			ColorsPerChannelLabel.Visible = _switch;
			ColorsPerChannelTrackBar.Visible = _switch;
		}

        private void LoadButton_Click(object sender, EventArgs e)
		{
			using (OpenFileDialog dialog = new OpenFileDialog())
			{
				dialog.Filter = "Image Files (*.bmp;*.jpg;*.png)|*.bmp;*.jpg;*.png";
				dialog.Title = "Load image";
				if (dialog.ShowDialog() == DialogResult.OK)
				{
					LoadAndDisplayImage(dialog.FileName);
				}
			}
		}
		private void FunctionFilterComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
            ColorsPerChannelTrackBar.Visible = false;

			TurnQuantizationFilterControls(false);
            TurnErrorDiffusionFilterControls(false);

			SelectFilter(FilterType.FunctionFilter);
		}

		private void ConvolutionFilterComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
            ColorsPerChannelTrackBar.Visible = false;

			TurnQuantizationFilterControls(false);
            TurnErrorDiffusionFilterControls(false);

			SelectFilter(FilterType.ConvolutionFilter);
		}


        private void OtherFilterComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
            if ((typeof(ErrorDiffusionFilter)).IsAssignableFrom(_filters[OtherFilterComboBox.SelectedItem.ToString()].GetType()))
            {
				TurnErrorDiffusionFilterControls(true);
            } else
			{
				TurnErrorDiffusionFilterControls(false);
            }
            if ((typeof(UniformQuantizationFilter)).IsAssignableFrom(_filters[OtherFilterComboBox.SelectedItem.ToString()].GetType()))
            {
				TurnQuantizationFilterControls(true);
            }
            else
            {
				TurnQuantizationFilterControls(false);
            }
            SelectFilter(FilterType.OtherFilter);
        }

        private void SaveButton_Click(object sender, EventArgs e)
		{
			SaveFilteredResult();
		}

		private void ResetButton_Click(object sender, EventArgs e)
		{
			ResetFilter();
		}

		private void createFilterButton_Click(object sender, EventArgs e)
		{
			_isEditingFilter = true;
			CreateConvolutionFilter();
			_isEditingFilter = false;
		}

		private void editFiltersCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			if (editFiltersCheckBox.Checked)
			{
				MessageBox.Show("You will now begin editing selected convolution filters!");
			}
		}

		private void ColorsPerChannelTrackBar_Scroll(object sender, EventArgs e)
		{
			int colorsPerChannel = (int)Math.Pow(2, ColorsPerChannelTrackBar.Value);
			if (OtherFilterComboBox.SelectedItem != null
				&& (typeof(ErrorDiffusionFilter)).IsAssignableFrom(_filters[OtherFilterComboBox.SelectedItem.ToString()].GetType()))
            {
                IErrorDiffusionFilter selectedFilter = (IErrorDiffusionFilter)_filters[OtherFilterComboBox.SelectedItem.ToString()];
				selectedFilter.ColorsPerChannel = colorsPerChannel;
				SelectFilter(FilterType.OtherFilter);
            }
		}

        private void RedTrackBar_Scroll(object sender, EventArgs e)
        {
            if (!((typeof(UniformQuantizationFilter)).IsAssignableFrom(_filters[OtherFilterComboBox.SelectedItem.ToString()].GetType())))
            {
                return;
			}
            int divisions = (int)Math.Pow(2, RedTrackBar.Value);
            IFilter selectedFilter = _filters[OtherFilterComboBox.SelectedItem.ToString()];
			((UniformQuantizationFilter) selectedFilter).RedDivisions = divisions;
            SelectFilter(FilterType.OtherFilter);
        }

        private void GreenTrackBar_Scroll(object sender, EventArgs e)
        {
            if (!((typeof(UniformQuantizationFilter)).IsAssignableFrom(_filters[OtherFilterComboBox.SelectedItem.ToString()].GetType())))
            {
                return;
            }
            int divisions = (int)Math.Pow(2, GreenTrackBar.Value);
            IFilter selectedFilter = _filters[OtherFilterComboBox.SelectedItem.ToString()];
            ((UniformQuantizationFilter)selectedFilter).GreenDivisions = divisions;
            SelectFilter(FilterType.OtherFilter);
        }

        private void BlueTrackBar_Scroll(object sender, EventArgs e)
        {
            if (!((typeof(UniformQuantizationFilter)).IsAssignableFrom(_filters[OtherFilterComboBox.SelectedItem.ToString()].GetType())))
            {
                return;
            }
            int divisions = (int)Math.Pow(2, BlueTrackBar.Value);
            IFilter selectedFilter = _filters[OtherFilterComboBox.SelectedItem.ToString()];
            ((UniformQuantizationFilter)selectedFilter).BlueDivisions = divisions;
            SelectFilter(FilterType.OtherFilter);
        }
    }
}
