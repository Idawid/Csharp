namespace CG1_Image_filtering
{
	partial class FilterEditorForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.nameTextBox = new System.Windows.Forms.TextBox();
			this.nameLabel = new System.Windows.Forms.Label();
			this.divisorNumericUpDown = new System.Windows.Forms.NumericUpDown();
			this.kernelUpDown = new System.Windows.Forms.Label();
			this.divisorLabel = new System.Windows.Forms.Label();
			this.offsetLabel = new System.Windows.Forms.Label();
			this.offsetNumericUpDown = new System.Windows.Forms.NumericUpDown();
			this.anchorLabel = new System.Windows.Forms.Label();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.OkButton = new System.Windows.Forms.Button();
			this.autoDivisorCheckBox = new System.Windows.Forms.CheckBox();
			this.anchorNumericUpDownY = new System.Windows.Forms.NumericUpDown();
			this.anchorNumericUpDownX = new System.Windows.Forms.NumericUpDown();
			this.deleteButton = new System.Windows.Forms.Button();
			this.widthNumericUpDown = new System.Windows.Forms.NumericUpDown();
			this.heightNumericUpDown = new System.Windows.Forms.NumericUpDown();
			((System.ComponentModel.ISupportInitialize)(this.divisorNumericUpDown)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.offsetNumericUpDown)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.anchorNumericUpDownY)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.anchorNumericUpDownX)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.widthNumericUpDown)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.heightNumericUpDown)).BeginInit();
			this.SuspendLayout();
			// 
			// nameTextBox
			// 
			this.nameTextBox.Location = new System.Drawing.Point(71, 15);
			this.nameTextBox.Margin = new System.Windows.Forms.Padding(4);
			this.nameTextBox.Name = "nameTextBox";
			this.nameTextBox.Size = new System.Drawing.Size(132, 22);
			this.nameTextBox.TabIndex = 0;
			// 
			// nameLabel
			// 
			this.nameLabel.AutoSize = true;
			this.nameLabel.Location = new System.Drawing.Point(16, 18);
			this.nameLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.nameLabel.Name = "nameLabel";
			this.nameLabel.Size = new System.Drawing.Size(45, 17);
			this.nameLabel.TabIndex = 1;
			this.nameLabel.Text = "Name";
			// 
			// divisorNumericUpDown
			// 
			this.divisorNumericUpDown.Location = new System.Drawing.Point(148, 62);
			this.divisorNumericUpDown.Margin = new System.Windows.Forms.Padding(4);
			this.divisorNumericUpDown.Name = "divisorNumericUpDown";
			this.divisorNumericUpDown.Size = new System.Drawing.Size(55, 22);
			this.divisorNumericUpDown.TabIndex = 3;
			// 
			// kernelUpDown
			// 
			this.kernelUpDown.AutoSize = true;
			this.kernelUpDown.Location = new System.Drawing.Point(16, 160);
			this.kernelUpDown.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.kernelUpDown.Name = "kernelUpDown";
			this.kernelUpDown.Size = new System.Drawing.Size(49, 17);
			this.kernelUpDown.TabIndex = 5;
			this.kernelUpDown.Text = "Kernel";
			// 
			// divisorLabel
			// 
			this.divisorLabel.AutoSize = true;
			this.divisorLabel.Location = new System.Drawing.Point(14, 64);
			this.divisorLabel.Name = "divisorLabel";
			this.divisorLabel.Size = new System.Drawing.Size(51, 17);
			this.divisorLabel.TabIndex = 6;
			this.divisorLabel.Text = "Divisor";
			// 
			// offsetLabel
			// 
			this.offsetLabel.AutoSize = true;
			this.offsetLabel.Location = new System.Drawing.Point(19, 90);
			this.offsetLabel.Name = "offsetLabel";
			this.offsetLabel.Size = new System.Drawing.Size(46, 17);
			this.offsetLabel.TabIndex = 7;
			this.offsetLabel.Text = "Offset";
			// 
			// offsetNumericUpDown
			// 
			this.offsetNumericUpDown.Location = new System.Drawing.Point(148, 88);
			this.offsetNumericUpDown.Name = "offsetNumericUpDown";
			this.offsetNumericUpDown.Size = new System.Drawing.Size(55, 22);
			this.offsetNumericUpDown.TabIndex = 8;
			// 
			// anchorLabel
			// 
			this.anchorLabel.AutoSize = true;
			this.anchorLabel.Cursor = System.Windows.Forms.Cursors.Default;
			this.anchorLabel.Location = new System.Drawing.Point(12, 115);
			this.anchorLabel.Name = "anchorLabel";
			this.anchorLabel.Size = new System.Drawing.Size(53, 17);
			this.anchorLabel.TabIndex = 9;
			this.anchorLabel.Text = "Anchor";
			// 
			// dataGridView1
			// 
			this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.ColumnHeadersVisible = false;
			this.dataGridView1.Location = new System.Drawing.Point(17, 201);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.RowHeadersVisible = false;
			this.dataGridView1.RowHeadersWidth = 51;
			this.dataGridView1.RowTemplate.Height = 30;
			this.dataGridView1.Size = new System.Drawing.Size(254, 188);
			this.dataGridView1.TabIndex = 10;
			this.dataGridView1.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellValueChanged);
			// 
			// OkButton
			// 
			this.OkButton.Location = new System.Drawing.Point(343, 320);
			this.OkButton.Name = "OkButton";
			this.OkButton.Size = new System.Drawing.Size(92, 45);
			this.OkButton.TabIndex = 12;
			this.OkButton.Text = "Confirm";
			this.OkButton.UseVisualStyleBackColor = true;
			this.OkButton.Click += new System.EventHandler(this.OkButton_Click);
			// 
			// autoDivisorCheckBox
			// 
			this.autoDivisorCheckBox.AutoSize = true;
			this.autoDivisorCheckBox.Location = new System.Drawing.Point(210, 63);
			this.autoDivisorCheckBox.Name = "autoDivisorCheckBox";
			this.autoDivisorCheckBox.Size = new System.Drawing.Size(91, 21);
			this.autoDivisorCheckBox.TabIndex = 13;
			this.autoDivisorCheckBox.Text = "automatic";
			this.autoDivisorCheckBox.UseVisualStyleBackColor = true;
			// 
			// anchorNumericUpDownY
			// 
			this.anchorNumericUpDownY.Location = new System.Drawing.Point(163, 113);
			this.anchorNumericUpDownY.Name = "anchorNumericUpDownY";
			this.anchorNumericUpDownY.Size = new System.Drawing.Size(41, 22);
			this.anchorNumericUpDownY.TabIndex = 14;
			// 
			// anchorNumericUpDownX
			// 
			this.anchorNumericUpDownX.Location = new System.Drawing.Point(116, 113);
			this.anchorNumericUpDownX.Name = "anchorNumericUpDownX";
			this.anchorNumericUpDownX.Size = new System.Drawing.Size(41, 22);
			this.anchorNumericUpDownX.TabIndex = 15;
			// 
			// deleteButton
			// 
			this.deleteButton.Location = new System.Drawing.Point(343, 258);
			this.deleteButton.Name = "deleteButton";
			this.deleteButton.Size = new System.Drawing.Size(92, 45);
			this.deleteButton.TabIndex = 16;
			this.deleteButton.Text = "Delete!";
			this.deleteButton.UseVisualStyleBackColor = true;
			this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
			// 
			// widthNumericUpDown
			// 
			this.widthNumericUpDown.Location = new System.Drawing.Point(116, 158);
			this.widthNumericUpDown.Name = "widthNumericUpDown";
			this.widthNumericUpDown.Size = new System.Drawing.Size(41, 22);
			this.widthNumericUpDown.TabIndex = 17;
			this.widthNumericUpDown.ValueChanged += new System.EventHandler(this.widthNumericUpDown_SelectedItemChanged);
			// 
			// heightNumericUpDown
			// 
			this.heightNumericUpDown.Location = new System.Drawing.Point(163, 158);
			this.heightNumericUpDown.Name = "heightNumericUpDown";
			this.heightNumericUpDown.Size = new System.Drawing.Size(41, 22);
			this.heightNumericUpDown.TabIndex = 18;
			this.heightNumericUpDown.ValueChanged += new System.EventHandler(this.heightNumericUpDown_SelectedItemChanged);
			// 
			// FilterEditorForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(505, 412);
			this.Controls.Add(this.heightNumericUpDown);
			this.Controls.Add(this.widthNumericUpDown);
			this.Controls.Add(this.deleteButton);
			this.Controls.Add(this.anchorNumericUpDownX);
			this.Controls.Add(this.anchorNumericUpDownY);
			this.Controls.Add(this.autoDivisorCheckBox);
			this.Controls.Add(this.OkButton);
			this.Controls.Add(this.dataGridView1);
			this.Controls.Add(this.anchorLabel);
			this.Controls.Add(this.offsetNumericUpDown);
			this.Controls.Add(this.offsetLabel);
			this.Controls.Add(this.divisorLabel);
			this.Controls.Add(this.kernelUpDown);
			this.Controls.Add(this.divisorNumericUpDown);
			this.Controls.Add(this.nameLabel);
			this.Controls.Add(this.nameTextBox);
			this.Margin = new System.Windows.Forms.Padding(4);
			this.Name = "FilterEditorForm";
			this.Text = "Choose your filter ...";
			((System.ComponentModel.ISupportInitialize)(this.divisorNumericUpDown)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.offsetNumericUpDown)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.anchorNumericUpDownY)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.anchorNumericUpDownX)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.widthNumericUpDown)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.heightNumericUpDown)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox nameTextBox;
		private System.Windows.Forms.Label nameLabel;
		private System.Windows.Forms.NumericUpDown divisorNumericUpDown;
		private System.Windows.Forms.Label kernelUpDown;
		private System.Windows.Forms.Label divisorLabel;
		private System.Windows.Forms.Label offsetLabel;
		private System.Windows.Forms.NumericUpDown offsetNumericUpDown;
		private System.Windows.Forms.Label anchorLabel;
		private System.Windows.Forms.DataGridView dataGridView1;
		private System.Windows.Forms.Button OkButton;
		private System.Windows.Forms.CheckBox autoDivisorCheckBox;
		private System.Windows.Forms.NumericUpDown anchorNumericUpDownY;
		private System.Windows.Forms.NumericUpDown anchorNumericUpDownX;
		private System.Windows.Forms.Button deleteButton;
		private System.Windows.Forms.NumericUpDown widthNumericUpDown;
		private System.Windows.Forms.NumericUpDown heightNumericUpDown;
	}
}