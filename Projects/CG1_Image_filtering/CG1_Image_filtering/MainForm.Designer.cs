namespace CG1_Image_filtering
{
	partial class MainForm
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
            this.OriginalPictureBox = new System.Windows.Forms.PictureBox();
            this.FilteredPictureBox = new System.Windows.Forms.PictureBox();
            this.FunctionFilterComboBox = new System.Windows.Forms.ComboBox();
            this.LoadButton = new System.Windows.Forms.Button();
            this.ResetButton = new System.Windows.Forms.Button();
            this.SaveButton = new System.Windows.Forms.Button();
            this.stackCheckBox = new System.Windows.Forms.CheckBox();
            this.OriginalImageLabel = new System.Windows.Forms.Label();
            this.FilteredImageLabel = new System.Windows.Forms.Label();
            this.FiltersLabel = new System.Windows.Forms.Label();
            this.createFilterButton = new System.Windows.Forms.Button();
            this.editFiltersCheckBox = new System.Windows.Forms.CheckBox();
            this.FunctionFiltersLabel = new System.Windows.Forms.Label();
            this.ConvolutionFiltersLabel = new System.Windows.Forms.Label();
            this.OtherFiltersLabel = new System.Windows.Forms.Label();
            this.ConvolutionFilterComboBox = new System.Windows.Forms.ComboBox();
            this.OtherFilterComboBox = new System.Windows.Forms.ComboBox();
            this.ColorsPerChannelTrackBar = new System.Windows.Forms.TrackBar();
            this.ColorsPerChannelLabel = new System.Windows.Forms.Label();
            this.GreenTrackBar = new System.Windows.Forms.TrackBar();
            this.BlueTrackBar = new System.Windows.Forms.TrackBar();
            this.RedTrackBar = new System.Windows.Forms.TrackBar();
            this.RedLabel = new System.Windows.Forms.Label();
            this.BlueLabel = new System.Windows.Forms.Label();
            this.GreenLabel = new System.Windows.Forms.Label();
            this.DivisionNumberLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.OriginalPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FilteredPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ColorsPerChannelTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GreenTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BlueTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RedTrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // OriginalPictureBox
            // 
            this.OriginalPictureBox.Location = new System.Drawing.Point(31, 31);
            this.OriginalPictureBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.OriginalPictureBox.Name = "OriginalPictureBox";
            this.OriginalPictureBox.Size = new System.Drawing.Size(428, 433);
            this.OriginalPictureBox.TabIndex = 0;
            this.OriginalPictureBox.TabStop = false;
            // 
            // FilteredPictureBox
            // 
            this.FilteredPictureBox.Location = new System.Drawing.Point(465, 31);
            this.FilteredPictureBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.FilteredPictureBox.Name = "FilteredPictureBox";
            this.FilteredPictureBox.Size = new System.Drawing.Size(416, 433);
            this.FilteredPictureBox.TabIndex = 1;
            this.FilteredPictureBox.TabStop = false;
            // 
            // FunctionFilterComboBox
            // 
            this.FunctionFilterComboBox.FormattingEnabled = true;
            this.FunctionFilterComboBox.Location = new System.Drawing.Point(31, 565);
            this.FunctionFilterComboBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.FunctionFilterComboBox.Name = "FunctionFilterComboBox";
            this.FunctionFilterComboBox.Size = new System.Drawing.Size(111, 24);
            this.FunctionFilterComboBox.TabIndex = 2;
            this.FunctionFilterComboBox.SelectedIndexChanged += new System.EventHandler(this.FunctionFilterComboBox_SelectedIndexChanged);
            // 
            // LoadButton
            // 
            this.LoadButton.Location = new System.Drawing.Point(887, 123);
            this.LoadButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.LoadButton.Name = "LoadButton";
            this.LoadButton.Size = new System.Drawing.Size(91, 23);
            this.LoadButton.TabIndex = 3;
            this.LoadButton.Text = "Load";
            this.LoadButton.UseVisualStyleBackColor = true;
            this.LoadButton.Click += new System.EventHandler(this.LoadButton_Click);
            // 
            // ResetButton
            // 
            this.ResetButton.Location = new System.Drawing.Point(887, 151);
            this.ResetButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ResetButton.Name = "ResetButton";
            this.ResetButton.Size = new System.Drawing.Size(91, 23);
            this.ResetButton.TabIndex = 4;
            this.ResetButton.Text = "Reset";
            this.ResetButton.UseVisualStyleBackColor = true;
            this.ResetButton.Click += new System.EventHandler(this.ResetButton_Click);
            // 
            // SaveButton
            // 
            this.SaveButton.Cursor = System.Windows.Forms.Cursors.Default;
            this.SaveButton.Location = new System.Drawing.Point(887, 250);
            this.SaveButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(91, 23);
            this.SaveButton.TabIndex = 5;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // stackCheckBox
            // 
            this.stackCheckBox.AutoSize = true;
            this.stackCheckBox.Location = new System.Drawing.Point(488, 565);
            this.stackCheckBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.stackCheckBox.Name = "stackCheckBox";
            this.stackCheckBox.Size = new System.Drawing.Size(97, 20);
            this.stackCheckBox.TabIndex = 6;
            this.stackCheckBox.Text = "Stack filters";
            this.stackCheckBox.UseVisualStyleBackColor = true;
            // 
            // OriginalImageLabel
            // 
            this.OriginalImageLabel.AutoSize = true;
            this.OriginalImageLabel.Location = new System.Drawing.Point(181, 466);
            this.OriginalImageLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.OriginalImageLabel.Name = "OriginalImageLabel";
            this.OriginalImageLabel.Size = new System.Drawing.Size(94, 16);
            this.OriginalImageLabel.TabIndex = 7;
            this.OriginalImageLabel.Text = "Original image";
            // 
            // FilteredImageLabel
            // 
            this.FilteredImageLabel.AutoSize = true;
            this.FilteredImageLabel.Location = new System.Drawing.Point(632, 466);
            this.FilteredImageLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.FilteredImageLabel.Name = "FilteredImageLabel";
            this.FilteredImageLabel.Size = new System.Drawing.Size(93, 16);
            this.FilteredImageLabel.TabIndex = 8;
            this.FilteredImageLabel.Text = "Filtered image";
            // 
            // FiltersLabel
            // 
            this.FiltersLabel.AutoSize = true;
            this.FiltersLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.FiltersLabel.Location = new System.Drawing.Point(24, 495);
            this.FiltersLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.FiltersLabel.Name = "FiltersLabel";
            this.FiltersLabel.Size = new System.Drawing.Size(119, 39);
            this.FiltersLabel.TabIndex = 9;
            this.FiltersLabel.Text = "Filters:";
            // 
            // createFilterButton
            // 
            this.createFilterButton.Location = new System.Drawing.Point(184, 632);
            this.createFilterButton.Name = "createFilterButton";
            this.createFilterButton.Size = new System.Drawing.Size(111, 30);
            this.createFilterButton.TabIndex = 10;
            this.createFilterButton.Text = "Create filter";
            this.createFilterButton.UseVisualStyleBackColor = true;
            this.createFilterButton.Click += new System.EventHandler(this.createFilterButton_Click);
            // 
            // editFiltersCheckBox
            // 
            this.editFiltersCheckBox.AutoSize = true;
            this.editFiltersCheckBox.Location = new System.Drawing.Point(189, 606);
            this.editFiltersCheckBox.Name = "editFiltersCheckBox";
            this.editFiltersCheckBox.Size = new System.Drawing.Size(86, 20);
            this.editFiltersCheckBox.TabIndex = 11;
            this.editFiltersCheckBox.Text = "Edit filters";
            this.editFiltersCheckBox.UseVisualStyleBackColor = true;
            this.editFiltersCheckBox.CheckedChanged += new System.EventHandler(this.editFiltersCheckBox_CheckedChanged);
            // 
            // FunctionFiltersLabel
            // 
            this.FunctionFiltersLabel.AutoSize = true;
            this.FunctionFiltersLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.FunctionFiltersLabel.Location = new System.Drawing.Point(27, 534);
            this.FunctionFiltersLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.FunctionFiltersLabel.Name = "FunctionFiltersLabel";
            this.FunctionFiltersLabel.Size = new System.Drawing.Size(89, 24);
            this.FunctionFiltersLabel.TabIndex = 12;
            this.FunctionFiltersLabel.Text = "Function:";
            // 
            // ConvolutionFiltersLabel
            // 
            this.ConvolutionFiltersLabel.AutoSize = true;
            this.ConvolutionFiltersLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.ConvolutionFiltersLabel.Location = new System.Drawing.Point(185, 534);
            this.ConvolutionFiltersLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ConvolutionFiltersLabel.Name = "ConvolutionFiltersLabel";
            this.ConvolutionFiltersLabel.Size = new System.Drawing.Size(115, 24);
            this.ConvolutionFiltersLabel.TabIndex = 13;
            this.ConvolutionFiltersLabel.Text = "Convolution:";
            // 
            // OtherFiltersLabel
            // 
            this.OtherFiltersLabel.AutoSize = true;
            this.OtherFiltersLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.OtherFiltersLabel.Location = new System.Drawing.Point(344, 534);
            this.OtherFiltersLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.OtherFiltersLabel.Name = "OtherFiltersLabel";
            this.OtherFiltersLabel.Size = new System.Drawing.Size(62, 24);
            this.OtherFiltersLabel.TabIndex = 14;
            this.OtherFiltersLabel.Text = "Other:";
            // 
            // ConvolutionFilterComboBox
            // 
            this.ConvolutionFilterComboBox.FormattingEnabled = true;
            this.ConvolutionFilterComboBox.Location = new System.Drawing.Point(189, 565);
            this.ConvolutionFilterComboBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ConvolutionFilterComboBox.Name = "ConvolutionFilterComboBox";
            this.ConvolutionFilterComboBox.Size = new System.Drawing.Size(111, 24);
            this.ConvolutionFilterComboBox.TabIndex = 15;
            this.ConvolutionFilterComboBox.SelectedIndexChanged += new System.EventHandler(this.ConvolutionFilterComboBox_SelectedIndexChanged);
            // 
            // OtherFilterComboBox
            // 
            this.OtherFilterComboBox.FormattingEnabled = true;
            this.OtherFilterComboBox.Location = new System.Drawing.Point(348, 565);
            this.OtherFilterComboBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.OtherFilterComboBox.Name = "OtherFilterComboBox";
            this.OtherFilterComboBox.Size = new System.Drawing.Size(111, 24);
            this.OtherFilterComboBox.TabIndex = 16;
            this.OtherFilterComboBox.SelectedIndexChanged += new System.EventHandler(this.OtherFilterComboBox_SelectedIndexChanged);
            // 
            // ColorsPerChannelTrackBar
            // 
            this.ColorsPerChannelTrackBar.Location = new System.Drawing.Point(665, 529);
            this.ColorsPerChannelTrackBar.Maximum = 5;
            this.ColorsPerChannelTrackBar.Minimum = 1;
            this.ColorsPerChannelTrackBar.Name = "ColorsPerChannelTrackBar";
            this.ColorsPerChannelTrackBar.Size = new System.Drawing.Size(177, 56);
            this.ColorsPerChannelTrackBar.TabIndex = 17;
            this.ColorsPerChannelTrackBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.ColorsPerChannelTrackBar.Value = 1;
            this.ColorsPerChannelTrackBar.Visible = false;
            this.ColorsPerChannelTrackBar.Scroll += new System.EventHandler(this.ColorsPerChannelTrackBar_Scroll);
            // 
            // ColorsPerChannelLabel
            // 
            this.ColorsPerChannelLabel.AutoSize = true;
            this.ColorsPerChannelLabel.Location = new System.Drawing.Point(701, 566);
            this.ColorsPerChannelLabel.Name = "ColorsPerChannelLabel";
            this.ColorsPerChannelLabel.Size = new System.Drawing.Size(116, 16);
            this.ColorsPerChannelLabel.TabIndex = 18;
            this.ColorsPerChannelLabel.Text = "ColorsPerChannel";
            this.ColorsPerChannelLabel.Visible = false;
            // 
            // GreenTrackBar
            // 
            this.GreenTrackBar.Location = new System.Drawing.Point(665, 557);
            this.GreenTrackBar.Maximum = 5;
            this.GreenTrackBar.Minimum = 1;
            this.GreenTrackBar.Name = "GreenTrackBar";
            this.GreenTrackBar.Size = new System.Drawing.Size(177, 56);
            this.GreenTrackBar.TabIndex = 19;
            this.GreenTrackBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.GreenTrackBar.Value = 1;
            this.GreenTrackBar.Visible = false;
            this.GreenTrackBar.Scroll += new System.EventHandler(this.GreenTrackBar_Scroll);
            // 
            // BlueTrackBar
            // 
            this.BlueTrackBar.Location = new System.Drawing.Point(665, 606);
            this.BlueTrackBar.Maximum = 5;
            this.BlueTrackBar.Minimum = 1;
            this.BlueTrackBar.Name = "BlueTrackBar";
            this.BlueTrackBar.Size = new System.Drawing.Size(177, 56);
            this.BlueTrackBar.TabIndex = 20;
            this.BlueTrackBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.BlueTrackBar.Value = 1;
            this.BlueTrackBar.Visible = false;
            this.BlueTrackBar.Scroll += new System.EventHandler(this.BlueTrackBar_Scroll);
            // 
            // RedTrackBar
            // 
            this.RedTrackBar.Location = new System.Drawing.Point(665, 507);
            this.RedTrackBar.Maximum = 5;
            this.RedTrackBar.Minimum = 1;
            this.RedTrackBar.Name = "RedTrackBar";
            this.RedTrackBar.Size = new System.Drawing.Size(177, 56);
            this.RedTrackBar.TabIndex = 21;
            this.RedTrackBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.RedTrackBar.Value = 1;
            this.RedTrackBar.Visible = false;
            this.RedTrackBar.Scroll += new System.EventHandler(this.RedTrackBar_Scroll);
            // 
            // RedLabel
            // 
            this.RedLabel.AutoSize = true;
            this.RedLabel.Location = new System.Drawing.Point(865, 518);
            this.RedLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.RedLabel.Name = "RedLabel";
            this.RedLabel.Size = new System.Drawing.Size(33, 16);
            this.RedLabel.TabIndex = 22;
            this.RedLabel.Text = "Red";
            this.RedLabel.Visible = false;
            // 
            // BlueLabel
            // 
            this.BlueLabel.AutoSize = true;
            this.BlueLabel.Location = new System.Drawing.Point(865, 610);
            this.BlueLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.BlueLabel.Name = "BlueLabel";
            this.BlueLabel.Size = new System.Drawing.Size(34, 16);
            this.BlueLabel.TabIndex = 23;
            this.BlueLabel.Text = "Blue";
            this.BlueLabel.Visible = false;
            // 
            // GreenLabel
            // 
            this.GreenLabel.AutoSize = true;
            this.GreenLabel.Location = new System.Drawing.Point(865, 565);
            this.GreenLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.GreenLabel.Name = "GreenLabel";
            this.GreenLabel.Size = new System.Drawing.Size(44, 16);
            this.GreenLabel.TabIndex = 24;
            this.GreenLabel.Text = "Green";
            this.GreenLabel.Visible = false;
            // 
            // DivisionNumberLabel
            // 
            this.DivisionNumberLabel.AutoSize = true;
            this.DivisionNumberLabel.Location = new System.Drawing.Point(701, 639);
            this.DivisionNumberLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.DivisionNumberLabel.Name = "DivisionNumberLabel";
            this.DivisionNumberLabel.Size = new System.Drawing.Size(125, 16);
            this.DivisionNumberLabel.TabIndex = 25;
            this.DivisionNumberLabel.Text = "Number of divisions";
            this.DivisionNumberLabel.Visible = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1002, 683);
            this.Controls.Add(this.DivisionNumberLabel);
            this.Controls.Add(this.GreenLabel);
            this.Controls.Add(this.BlueLabel);
            this.Controls.Add(this.RedLabel);
            this.Controls.Add(this.RedTrackBar);
            this.Controls.Add(this.BlueTrackBar);
            this.Controls.Add(this.GreenTrackBar);
            this.Controls.Add(this.ColorsPerChannelLabel);
            this.Controls.Add(this.ColorsPerChannelTrackBar);
            this.Controls.Add(this.OtherFilterComboBox);
            this.Controls.Add(this.ConvolutionFilterComboBox);
            this.Controls.Add(this.OtherFiltersLabel);
            this.Controls.Add(this.ConvolutionFiltersLabel);
            this.Controls.Add(this.FunctionFiltersLabel);
            this.Controls.Add(this.editFiltersCheckBox);
            this.Controls.Add(this.createFilterButton);
            this.Controls.Add(this.FiltersLabel);
            this.Controls.Add(this.FilteredImageLabel);
            this.Controls.Add(this.OriginalImageLabel);
            this.Controls.Add(this.stackCheckBox);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.ResetButton);
            this.Controls.Add(this.LoadButton);
            this.Controls.Add(this.FunctionFilterComboBox);
            this.Controls.Add(this.FilteredPictureBox);
            this.Controls.Add(this.OriginalPictureBox);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "MainForm";
            this.Text = "CG1 Image filtering";
            ((System.ComponentModel.ISupportInitialize)(this.OriginalPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FilteredPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ColorsPerChannelTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GreenTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BlueTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RedTrackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.PictureBox OriginalPictureBox;
		private System.Windows.Forms.PictureBox FilteredPictureBox;
		private System.Windows.Forms.ComboBox FunctionFilterComboBox;
		private System.Windows.Forms.Button LoadButton;
		private System.Windows.Forms.Button ResetButton;
		private System.Windows.Forms.Button SaveButton;
		private System.Windows.Forms.CheckBox stackCheckBox;
		private System.Windows.Forms.Label FiltersLabel;
		private System.Windows.Forms.Label OriginalImageLabel;
		private System.Windows.Forms.Label FilteredImageLabel;
		private System.Windows.Forms.Button createFilterButton;
		private System.Windows.Forms.CheckBox editFiltersCheckBox;
        private System.Windows.Forms.Label FunctionFiltersLabel;
        private System.Windows.Forms.Label ConvolutionFiltersLabel;
        private System.Windows.Forms.Label OtherFiltersLabel;
        private System.Windows.Forms.ComboBox ConvolutionFilterComboBox;
        private System.Windows.Forms.ComboBox OtherFilterComboBox;
        private System.Windows.Forms.TrackBar ColorsPerChannelTrackBar;
        private System.Windows.Forms.Label ColorsPerChannelLabel;
        private System.Windows.Forms.TrackBar GreenTrackBar;
        private System.Windows.Forms.TrackBar BlueTrackBar;
        private System.Windows.Forms.TrackBar RedTrackBar;
        private System.Windows.Forms.Label RedLabel;
        private System.Windows.Forms.Label BlueLabel;
        private System.Windows.Forms.Label GreenLabel;
        private System.Windows.Forms.Label DivisionNumberLabel;
    }
}

