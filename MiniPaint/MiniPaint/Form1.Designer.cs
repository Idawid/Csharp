
namespace MiniPaint
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
			this.nameContainer = new System.Windows.Forms.SplitContainer();
			this.Canvas = new System.Windows.Forms.PictureBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.flowColors = new System.Windows.Forms.FlowLayoutPanel();
			this.brushButton = new System.Windows.Forms.ToolStripButton();
			this.toolStrip = new System.Windows.Forms.ToolStrip();
			this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
			this.saveButton = new System.Windows.Forms.ToolStripButton();
			this.loadButton = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.nameTools = new System.Windows.Forms.ToolStripLabel();
			this.rectangleButton = new System.Windows.Forms.ToolStripButton();
			this.ellipseButton = new System.Windows.Forms.ToolStripButton();
			this.clearButton = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
			this.ThicknessMenu = new System.Windows.Forms.ToolStripDropDownButton();
			this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.chosenColorLabel = new System.Windows.Forms.ToolStripLabel();
			this.colorPreviewButton = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripLabel4 = new System.Windows.Forms.ToolStripLabel();
			this.EnglishButton = new System.Windows.Forms.ToolStripButton();
			this.PolishButton = new System.Windows.Forms.ToolStripButton();
			((System.ComponentModel.ISupportInitialize)(this.nameContainer)).BeginInit();
			this.nameContainer.Panel1.SuspendLayout();
			this.nameContainer.Panel2.SuspendLayout();
			this.nameContainer.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.Canvas)).BeginInit();
			this.groupBox1.SuspendLayout();
			this.toolStrip.SuspendLayout();
			this.SuspendLayout();
			// 
			// nameContainer
			// 
			resources.ApplyResources(this.nameContainer, "nameContainer");
			this.nameContainer.ForeColor = System.Drawing.SystemColors.ControlText;
			this.nameContainer.Name = "nameContainer";
			// 
			// nameContainer.Panel1
			// 
			this.nameContainer.Panel1.Controls.Add(this.Canvas);
			// 
			// nameContainer.Panel2
			// 
			this.nameContainer.Panel2.Controls.Add(this.groupBox1);
			this.nameContainer.TabStop = false;
			// 
			// Canvas
			// 
			this.Canvas.Cursor = System.Windows.Forms.Cursors.Cross;
			resources.ApplyResources(this.Canvas, "Canvas");
			this.Canvas.Name = "Canvas";
			this.Canvas.TabStop = false;
			this.Canvas.Paint += new System.Windows.Forms.PaintEventHandler(this.Canvas_Paint);
			this.Canvas.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Canvas_MouseDown);
			this.Canvas.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Canvas_MouseMove);
			this.Canvas.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Canvas_MouseUp);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.flowColors);
			resources.ApplyResources(this.groupBox1, "groupBox1");
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.TabStop = false;
			// 
			// flowColors
			// 
			resources.ApplyResources(this.flowColors, "flowColors");
			this.flowColors.Name = "flowColors";
			// 
			// brushButton
			// 
			this.brushButton.CheckOnClick = true;
			this.brushButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			resources.ApplyResources(this.brushButton, "brushButton");
			this.brushButton.Name = "brushButton";
			this.brushButton.Click += new System.EventHandler(this.brushButton_Click);
			// 
			// toolStrip
			// 
			this.toolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.saveButton,
            this.loadButton,
            this.toolStripSeparator1,
            this.nameTools,
            this.brushButton,
            this.rectangleButton,
            this.ellipseButton,
            this.clearButton,
            this.toolStripSeparator2,
            this.toolStripLabel2,
            this.ThicknessMenu,
            this.toolStripSeparator3,
            this.chosenColorLabel,
            this.colorPreviewButton,
            this.toolStripSeparator4,
            this.toolStripLabel4,
            this.EnglishButton,
            this.PolishButton});
			resources.ApplyResources(this.toolStrip, "toolStrip");
			this.toolStrip.Name = "toolStrip";
			// 
			// toolStripLabel1
			// 
			this.toolStripLabel1.Name = "toolStripLabel1";
			resources.ApplyResources(this.toolStripLabel1, "toolStripLabel1");
			// 
			// saveButton
			// 
			this.saveButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			resources.ApplyResources(this.saveButton, "saveButton");
			this.saveButton.Name = "saveButton";
			this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
			// 
			// loadButton
			// 
			this.loadButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			resources.ApplyResources(this.loadButton, "loadButton");
			this.loadButton.Name = "loadButton";
			this.loadButton.Click += new System.EventHandler(this.loadButton_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
			// 
			// nameTools
			// 
			this.nameTools.Name = "nameTools";
			resources.ApplyResources(this.nameTools, "nameTools");
			// 
			// rectangleButton
			// 
			this.rectangleButton.CheckOnClick = true;
			this.rectangleButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			resources.ApplyResources(this.rectangleButton, "rectangleButton");
			this.rectangleButton.Name = "rectangleButton";
			this.rectangleButton.Click += new System.EventHandler(this.rectangleButton_Click);
			// 
			// ellipseButton
			// 
			this.ellipseButton.CheckOnClick = true;
			this.ellipseButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			resources.ApplyResources(this.ellipseButton, "ellipseButton");
			this.ellipseButton.Name = "ellipseButton";
			this.ellipseButton.Click += new System.EventHandler(this.ellipseButton_Click);
			// 
			// clearButton
			// 
			this.clearButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			resources.ApplyResources(this.clearButton, "clearButton");
			this.clearButton.Name = "clearButton";
			this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			resources.ApplyResources(this.toolStripSeparator2, "toolStripSeparator2");
			// 
			// toolStripLabel2
			// 
			this.toolStripLabel2.Name = "toolStripLabel2";
			resources.ApplyResources(this.toolStripLabel2, "toolStripLabel2");
			// 
			// ThicknessMenu
			// 
			resources.ApplyResources(this.ThicknessMenu, "ThicknessMenu");
			this.ThicknessMenu.BackColor = System.Drawing.Color.White;
			this.ThicknessMenu.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.ThicknessMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2,
            this.toolStripMenuItem3,
            this.toolStripMenuItem4});
			this.ThicknessMenu.Name = "ThicknessMenu";
			// 
			// toolStripMenuItem2
			// 
			this.toolStripMenuItem2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.toolStripMenuItem2.Name = "toolStripMenuItem2";
			resources.ApplyResources(this.toolStripMenuItem2, "toolStripMenuItem2");
			this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
			// 
			// toolStripMenuItem3
			// 
			this.toolStripMenuItem3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.toolStripMenuItem3.Name = "toolStripMenuItem3";
			resources.ApplyResources(this.toolStripMenuItem3, "toolStripMenuItem3");
			this.toolStripMenuItem3.Click += new System.EventHandler(this.toolStripMenuItem3_Click);
			// 
			// toolStripMenuItem4
			// 
			this.toolStripMenuItem4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.toolStripMenuItem4.Name = "toolStripMenuItem4";
			resources.ApplyResources(this.toolStripMenuItem4, "toolStripMenuItem4");
			this.toolStripMenuItem4.Click += new System.EventHandler(this.toolStripMenuItem4_Click);
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			resources.ApplyResources(this.toolStripSeparator3, "toolStripSeparator3");
			// 
			// chosenColorLabel
			// 
			this.chosenColorLabel.Name = "chosenColorLabel";
			resources.ApplyResources(this.chosenColorLabel, "chosenColorLabel");
			// 
			// colorPreviewButton
			// 
			resources.ApplyResources(this.colorPreviewButton, "colorPreviewButton");
			this.colorPreviewButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.colorPreviewButton.Name = "colorPreviewButton";
			// 
			// toolStripSeparator4
			// 
			this.toolStripSeparator4.Name = "toolStripSeparator4";
			resources.ApplyResources(this.toolStripSeparator4, "toolStripSeparator4");
			// 
			// toolStripLabel4
			// 
			this.toolStripLabel4.Name = "toolStripLabel4";
			resources.ApplyResources(this.toolStripLabel4, "toolStripLabel4");
			// 
			// EnglishButton
			// 
			this.EnglishButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			resources.ApplyResources(this.EnglishButton, "EnglishButton");
			this.EnglishButton.Name = "EnglishButton";
			this.EnglishButton.Click += new System.EventHandler(this.EnglishButton_Click);
			// 
			// PolishButton
			// 
			this.PolishButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			resources.ApplyResources(this.PolishButton, "PolishButton");
			this.PolishButton.Name = "PolishButton";
			this.PolishButton.Click += new System.EventHandler(this.PolishButton_Click);
			// 
			// Form1
			// 
			resources.ApplyResources(this, "$this");
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.nameContainer);
			this.Controls.Add(this.toolStrip);
			this.Name = "Form1";
			this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
			this.nameContainer.Panel1.ResumeLayout(false);
			this.nameContainer.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.nameContainer)).EndInit();
			this.nameContainer.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.Canvas)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.toolStrip.ResumeLayout(false);
			this.toolStrip.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.SplitContainer nameContainer;
        private System.Windows.Forms.PictureBox Canvas;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.FlowLayoutPanel flowColors;
		private System.Windows.Forms.ToolStripButton brushButton;
		private System.Windows.Forms.ToolStrip toolStrip;
		private System.Windows.Forms.ToolStripLabel nameTools;
		private System.Windows.Forms.ToolStripButton rectangleButton;
		private System.Windows.Forms.ToolStripButton ellipseButton;
		private System.Windows.Forms.ToolStripButton clearButton;
		private System.Windows.Forms.ToolStripLabel toolStripLabel1;
		private System.Windows.Forms.ToolStripButton saveButton;
		private System.Windows.Forms.ToolStripButton loadButton;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripLabel toolStripLabel2;
		private System.Windows.Forms.ToolStripDropDownButton ThicknessMenu;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		private System.Windows.Forms.ToolStripLabel chosenColorLabel;
		private System.Windows.Forms.ToolStripButton colorPreviewButton;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
		private System.Windows.Forms.ToolStripLabel toolStripLabel4;
		private System.Windows.Forms.ToolStripButton EnglishButton;
		private System.Windows.Forms.ToolStripButton PolishButton;
	}
}

