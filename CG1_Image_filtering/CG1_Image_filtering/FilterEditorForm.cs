using CG1_Image_filtering.Filters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CG1_Image_filtering
{
	public partial class FilterEditorForm : Form
	{
		public ConvolutionFilter Filter { get; }

		public FilterEditorForm(ConvolutionFilter filter = null)
		{
			InitializeComponent();
			InitializeElements();

			Filter = new ConvolutionFilter(filter);

			FilterToComponents();
		}

		private void InitializeElements()
		{
			autoDivisorCheckBox.Checked = true;

			// Properies of the dataGridView1
			dataGridView1.DefaultCellStyle.NullValue = string.Empty;
			dataGridView1.DefaultCellStyle.Format = "N0";
			dataGridView1.AllowUserToAddRows = false;
			dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
			dataGridView1.AllowUserToResizeRows = false;
			dataGridView1.AllowUserToResizeColumns = false;

			offsetNumericUpDown.Maximum = 255;
			offsetNumericUpDown.Minimum = 0;

			widthNumericUpDown.Minimum = 3;
			widthNumericUpDown.Maximum = 9;
			widthNumericUpDown.Increment = 2;
			
			heightNumericUpDown.Minimum = 3;
			heightNumericUpDown.Maximum = 9;
			heightNumericUpDown.Increment = 2;
		}

		private void ComponentsToFilter()
		{
			if (Filter == null)
			{
				return;
			}
			// Name
			Filter.Name = nameTextBox.Text;
			// Divisor
			FixDivisor();
			Filter.Divisor = (int)divisorNumericUpDown.Value;
			// Offset
			Filter.Offset = (int)offsetNumericUpDown.Value;
			// Kernel
			int width = (int)widthNumericUpDown.Value;
			int height = (int)heightNumericUpDown.Value;
			Filter.Kernel = new double[width, height];
			for (int i = 0; i < Filter.Kernel.GetLength(0); i++)
			{
				for (int j = 0; j < Filter.Kernel.GetLength(1); j++)
				{
					Filter.Kernel[i, j] = Convert.ToInt32(dataGridView1.Rows[j].Cells[i].Value);
				}
			}
			// Anchor
			Filter.Anchor = new Point((int)anchorNumericUpDownX.Value, (int)anchorNumericUpDownY.Value);
		}

		private void FilterToComponents()
		{
			// Name
			nameTextBox.Text = Filter.Name;
			// Divisor
			divisorNumericUpDown.Value = (int)Filter.Divisor;
			if (autoDivisorCheckBox.Checked)
			{
				divisorNumericUpDown.Value = (int)Filter.Kernel.Cast<double>().Sum();
			}
			// Offset
			offsetNumericUpDown.Value = (int)Filter.Offset;
			// Kernel
			widthNumericUpDown.Value = Filter.Kernel.GetLength(0);
			heightNumericUpDown.Value = Filter.Kernel.GetLength(1);

			dataGridView1.ColumnCount = Filter.Kernel.GetLength(0);
			dataGridView1.RowCount = Filter.Kernel.GetLength(1);
			for (int i = 0; i < Filter.Kernel.GetLength(0); i++)
			{
				for (int j = 0; j < Filter.Kernel.GetLength(1); j++)
				{
					dataGridView1.Rows[j].Cells[i].Value = Filter.Kernel[i, j];
				}
			}
			// Anchor
			anchorNumericUpDownX.Value = Filter.Anchor.X;
			anchorNumericUpDownY.Value = Filter.Anchor.Y;
		}

		private void FillDataGridView()
		{
			for (int row = 0; row < dataGridView1.Rows.Count; row++)
			{
				for (int col = 0; col < dataGridView1.Columns.Count; col++)
				{
					if (dataGridView1.Rows[row].Cells[col].Value == null)
					{
						dataGridView1.Rows[row].Cells[col].Value = 1;
					}
				}
			}
		}

		private void FixAnchor()
		{
			int xRadius = dataGridView1.Columns.Count / 2;
			anchorNumericUpDownX.Minimum = -xRadius;
			anchorNumericUpDownX.Maximum = xRadius;

			int yRadius = dataGridView1.Rows.Count / 2;
			anchorNumericUpDownY.Minimum = -yRadius;
			anchorNumericUpDownY.Maximum = yRadius;
		}

		private void FixDivisor()
		{
			if (autoDivisorCheckBox.Checked)
			{
				int sum = 0;
				for (int row = 0; row < dataGridView1.Rows.Count; row++)
				{
					for (int col = 0; col < dataGridView1.Columns.Count; col++)
					{
						sum += Convert.ToInt32(dataGridView1.Rows[row].Cells[col].Value);
					}
				}
				divisorNumericUpDown.Value = sum;
			}
		}

		private void OkButton_Click(object sender, EventArgs e)
		{
			if (nameTextBox.Text == string.Empty)
			{
				MessageBox.Show("Please type in a name for your filter");
				return;
			}
			ComponentsToFilter();
			DialogResult = DialogResult.OK;
			Close();
		}

		private void widthNumericUpDown_SelectedItemChanged(object sender, EventArgs e)
		{
			dataGridView1.ColumnCount = (int)widthNumericUpDown.Value;
			FillDataGridView();

			FixAnchor();
			FixDivisor();
		}

		private void heightNumericUpDown_SelectedItemChanged(object sender, EventArgs e)
		{
			dataGridView1.RowCount = (int)heightNumericUpDown.Value;
			FillDataGridView();

			FixAnchor();
			FixDivisor();
		}

		private void deleteButton_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.No;
		}

		private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
		{
			FixDivisor();
		}
	}
}
