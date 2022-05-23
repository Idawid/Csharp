using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace MiniPaint
{
    enum PaintingTool
	{
        Pen = 0,
        Ellipse = 1,
        Rectangle = 2
	}
    enum ToolState
	{
        ToolNotSelected,
        ToolSelected,
        ToolDown,
        ToolMoving,
        ToolUp,
	}
    public partial class Form1 : Form
    {
        private Bitmap drawArea;
        private Graphics g;

        //default tool
        private PaintingTool tool = PaintingTool.Pen;
        //private ToolState state = ToolState.ToolNotSelected;

        private Pen pen = new Pen(Color.Black, 1);

        private bool paint = false;
        private bool toolSelected = false;

        //point temp, down, up
        Point pt, pd, pu;

        Button? lastButton = null;
        public Form1()
        {
            InitializeComponent();

            //drawArea = new Bitmap(Screen.PrimaryScreen.WorkingArea.Width, Screen.PrimaryScreen.WorkingArea.Width);
            drawArea = new Bitmap(Canvas.Width, Canvas.Height);
            Canvas.Image = drawArea;
            g = Graphics.FromImage(drawArea);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            g.Clear(Color.White);

            KnownColor[] colors = (KnownColor[])Enum.GetValues(typeof(KnownColor));
            for (int i = 0; i < colors.Length; i++)
			{
				Button button = new Button();
				button.BackColor = Color.FromName(colors[i].ToString());
				button.Size = new Size(25, 25);
                button.FlatStyle = FlatStyle.Flat;
                button.FlatAppearance.BorderSize = 0;
                button.MouseClick += Button_MouseClick;
                button.Paint += Button_Paint;
				flowColors.Controls.Add(button);
			}
		}

		private void Button_Paint(object sender, PaintEventArgs e)
		{
            Button? button = sender as Button;
            if (button == null || button.Tag == null) return;

            Color borderColor;
            Pen borderPen;
            Rectangle borderRectangle = e.ClipRectangle;
            borderRectangle.Inflate(-1, -1);

            //draw dashed frame around the clicked button
            if (button.Tag.ToString() == "clicked")
            {
                borderColor = Color.FromArgb(button.BackColor.ToArgb() ^ 0xffffff);
                borderPen = new Pen(borderColor, 2);
                borderPen.DashPattern = new float[] { 2, 1 };
                e.Graphics.DrawRectangle(borderPen, borderRectangle);
            }
            //draw invisible frame around unclicked button
            if (button.Tag.ToString() == "undo")
            {
                //delete the undo tag
                button.Tag = null;
                borderColor = button.BackColor;
                borderPen = new Pen(borderColor, 2);
                e.Graphics.DrawRectangle(borderPen, borderRectangle);
            }
        }

		private void Button_MouseClick(object? sender, MouseEventArgs e)
		{
			Button? button = sender as Button;
            if (button == null || flowColors.Controls.Count <= 0) return;

            pen.Color = button.BackColor;
            colorPreviewButton.BackColor = button.BackColor;

            if(lastButton != null && button == lastButton)
			{
                //do nothing we clicked the same button
            }
            if(lastButton == null || (lastButton!= null && button != lastButton))
			{
                //we have the last button, it's not the same as this one
                button.Tag = "clicked";
                if (lastButton != null)
                {
                    lastButton.Tag = "undo";
                    lastButton.Invalidate();
                }
                button.Invalidate();
                lastButton = button;
            }
        }

		private void Canvas_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && toolSelected)
            {
                paint = true;
                pt = e.Location;
                //this below doesnt change when moving - useful for ellipse and rectangle
                pd = e.Location;
            }
            if (e.Button == MouseButtons.Right)
            {
                paint = false;
                Canvas.Refresh();
            }
        }

        private void Canvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (paint)
			{
                Canvas.Invalidate();
                if (tool == PaintingTool.Pen)
                {
                    g.DrawLine(pen, pt.X, pt.Y, e.X, e.Y);
                }
                //update the points
                pt = e.Location;
                pu = e.Location;
                pu.Offset(-pd.X, -pd.Y);
            }
            //Canvas.Refresh();
        }

        private void Canvas_MouseUp(object sender, MouseEventArgs e)
        {
            if(paint)
            {
                paint = false;
                pu = e.Location;
                pu.Offset(-pd.X, -pd.Y);
                if (toolSelected && tool == PaintingTool.Ellipse)
                {
                    g.DrawEllipse(pen, new Rectangle(pd, (Size)pu));
                }
                if (toolSelected && tool == PaintingTool.Rectangle)
                {
                    g.DrawRectangle(pen, Math.Min(pd.X, pd.X + pu.X), Math.Min(pd.Y, pd.Y + pu.Y),
                        Math.Abs(pu.X), Math.Abs(pu.Y));
                }
            }
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
		{
            pen.Width = 1;
            ThicknessMenu.Text = "1";
            ThicknessMenu.TextAlign = ContentAlignment.MiddleLeft;
		}
		private void toolStripMenuItem3_Click(object sender, EventArgs e)
		{
            pen.Width = 2;
            ThicknessMenu.Text = "2";
            ThicknessMenu.TextAlign = ContentAlignment.MiddleLeft;
        }
		private void toolStripMenuItem4_Click(object sender, EventArgs e)
		{
            pen.Width = 3;
            ThicknessMenu.Text = "3";
            ThicknessMenu.TextAlign = ContentAlignment.MiddleLeft;
        }
		private void clearButton_Click(object sender, EventArgs e)
		{
            g.Clear(Color.White);
            Canvas.Invalidate();
		}
        private void brushButton_Click(object sender, EventArgs e)
        {
            tool = PaintingTool.Pen;
            ellipseButton.Checked = false;
            rectangleButton.Checked = false;
            toolSelected = brushButton.Checked;
        }
		private void Canvas_Paint(object sender, PaintEventArgs e)
		{
            Graphics t = e.Graphics;
            if(paint)
			{
                if (toolSelected && tool == PaintingTool.Ellipse)
                {
                    t.DrawEllipse(pen, new Rectangle(pd, (Size)pu));
                }
                if (toolSelected && tool == PaintingTool.Rectangle)
                {
                    t.DrawRectangle(pen, Math.Min(pd.X, pd.X + pu.X), Math.Min(pd.Y, pd.Y + pu.Y),
                        Math.Abs(pu.X), Math.Abs(pu.Y));
                }
            }
		}
        private void saveButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Bitmap Image (.bmp *.bmp)|*.bmp|JPEG Image (.jpeg *.jpeg)|*.jpeg|PNG Image (.png *.png)|*.png";
            saveFileDialog.InitialDirectory = "%userprofile%\\Documents";
            saveFileDialog.FileName = "Untitled";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                drawArea.Save(saveFileDialog.FileName);
            }
        }
        private void loadButton_Click(object sender, EventArgs e)
		{
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Bitmap Image (.bmp *.bmp)|*.bmp|JPEG Image (.jpeg *.jpeg)|*.jpeg|PNG Image (.png *.png)|*.png";
            openFileDialog.InitialDirectory = "%userprofile%\\Documents";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                Image image = Image.FromFile(openFileDialog.FileName);

                //because the proportions are constant we can just multiply canvas' dimensions by their inverse
                this.Size = new Size((int)(image.Width * 1.13576), (int)(image.Height * 1.09424));
                Canvas.Size = new Size((int)(this.Size.Width * 0.88047), this.Size.Height);
                Bitmap temp = new Bitmap(image);
                Canvas.Image = temp;
                g.Dispose();
                g = Graphics.FromImage(temp);
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                g.Clear(Color.White);
                g.DrawImage(image, 0, 0);
                drawArea = temp;
            }
        }

		private void Form1_SizeChanged(object sender, EventArgs e)
		{
			Bitmap temp = new Bitmap(Canvas.Width, Canvas.Height);
			Canvas.Image = temp;
            g.Dispose();
			g = Graphics.FromImage(temp);
			g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
			g.Clear(Color.White);
			g.DrawImage(drawArea, 0, 0);
            drawArea = temp;
		}

		private void ellipseButton_Click(object sender, EventArgs e)
        {
            tool = PaintingTool.Ellipse;
            brushButton.Checked = false;
            rectangleButton.Checked = false;
            toolSelected = ellipseButton.Checked;
        }
        private void rectangleButton_Click(object sender, EventArgs e)
		{
            tool = PaintingTool.Rectangle;
            brushButton.Checked = false;
            ellipseButton.Checked = false;
            toolSelected = rectangleButton.Checked;
        }
        private void EnglishButton_Click(object sender, EventArgs e)
        {
            Size size= this.Size;
            //chaning culture and ui culture
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-US");
            this.Controls.Clear();
            InitializeComponent();
            //back to the old size
            this.Size = size;
            this.Refresh();
            //redrawing the canvas
            Bitmap temp = new Bitmap(Canvas.Width, Canvas.Height);
            Canvas.Image = temp;
            g.Dispose();
            g = Graphics.FromImage(temp);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            g.Clear(Color.White);
            Thread.Sleep(1000);
            g.DrawImage(drawArea, 0, 0);
            drawArea = temp;

            Canvas.Refresh();

            //chosen color
            colorPreviewButton.BackColor = pen.Color;
            ThicknessMenu.Text = pen.Width.ToString();
            //tools
            switch (tool)
            {
                case PaintingTool.Pen:
                    if (toolSelected)
                        brushButton.Checked = true;
                    break;
                case PaintingTool.Ellipse:
                    if (toolSelected)
                        ellipseButton.Checked = true;
                    break;
                case PaintingTool.Rectangle:
                    if (toolSelected)
                        rectangleButton.Checked = true;
                    break;
            }
            //language button press
            PolishButton.Checked = false;
            EnglishButton.Checked = true;
            //dreoing all color buttons on the right
            KnownColor[] colors = (KnownColor[])Enum.GetValues(typeof(KnownColor));
            for (int i = 0; i < colors.Length; i++)
            {
                Button button = new Button();
                button.BackColor = Color.FromName(colors[i].ToString());
                button.Size = new Size(25, 25);
                button.FlatStyle = FlatStyle.Flat;
                button.FlatAppearance.BorderSize = 0;
                button.MouseClick += Button_MouseClick;
                button.Paint += Button_Paint;
                flowColors.Controls.Add(button);

                Point start = button.Location;
                Rectangle borderRectangle = new Rectangle(start.X, start.Y, 25, 25);
                borderRectangle.Inflate(-1, -1);
            }
        }

        private void PolishButton_Click(object sender, EventArgs e)
        {
            Size size = this.Size;
            //chaning culture and ui culture
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("pl-PL");
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("pl-PL");
            this.Controls.Clear();
            InitializeComponent();
            //back to the old size
            this.Size = size;
            this.Refresh();
            //redrawing the canvas
            Bitmap temp = new Bitmap(Canvas.Width, Canvas.Height);
            Canvas.Image = temp;
            g.Dispose();
            g = Graphics.FromImage(temp);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            g.Clear(Color.White);
            Thread.Sleep(1000);
            g.DrawImage(drawArea, 0, 0);
            drawArea = temp;

            Canvas.Refresh();

            colorPreviewButton.BackColor = pen.Color;
            ThicknessMenu.Text = pen.Width.ToString();
            switch (tool)
            {
                case PaintingTool.Pen:
                    if (toolSelected)
                        brushButton.Checked = true;
                    break;
                case PaintingTool.Ellipse:
                    if (toolSelected)
                        ellipseButton.Checked = true;
                    break;
                case PaintingTool.Rectangle:
                    if (toolSelected)
                        rectangleButton.Checked = true;
                    break;
            }
            //language button press
            PolishButton.Checked = true;
            EnglishButton.Checked = false;
            //dreoing all color buttons on the right
            KnownColor[] colors = (KnownColor[])Enum.GetValues(typeof(KnownColor));
            for (int i = 0; i < colors.Length; i++)
            {
                Button button = new Button();
                button.BackColor = Color.FromName(colors[i].ToString());
                button.Size = new Size(25, 25);
                button.FlatStyle = FlatStyle.Flat;
                button.FlatAppearance.BorderSize = 0;
                button.MouseClick += Button_MouseClick;
                button.Paint += Button_Paint;
                flowColors.Controls.Add(button);

                Point start = button.Location;
                Rectangle borderRectangle = new Rectangle(start.X, start.Y, 25, 25);
                borderRectangle.Inflate(-1, -1);
            }
        }
    }
}
