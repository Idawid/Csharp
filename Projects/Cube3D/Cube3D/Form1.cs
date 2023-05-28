using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cube3D
{
	public partial class Form1 : Form
	{
		private const float CubeSize = 100f;
		private const float Perspective = 800f;

		private float rotationX;
		private float rotationY;
		private float distance;

		private readonly Color cubeColor = Color.FromArgb(245, 245, 220);
		private readonly Color perspectiveColor = Color.FromArgb(70, 70, 70);

		public Form1()
		{
			InitializeComponent();
			rotationX = 0f;
			rotationY = 0f;
			distance = 1000f;
			Canvas.BackColor = perspectiveColor;
		}

		private void pictureBox_Paint(object sender, PaintEventArgs e)
		{
			Graphics g = e.Graphics;

			float halfWidth = ClientSize.Width / 2f;
			float halfHeight = ClientSize.Height / 2f;

			float angleX = rotationX * (float)Math.PI / 180f;
			float angleY = rotationY * (float)Math.PI / 180f;

			float cosX = (float)Math.Cos(angleX);
			float sinX = (float)Math.Sin(angleX);
			float cosY = (float)Math.Cos(angleY);
			float sinY = (float)Math.Sin(angleY);

			Point3D[] cubeVertices =
			{
				new Point3D(-CubeSize, -CubeSize, -CubeSize),
				new Point3D(CubeSize, -CubeSize, -CubeSize),
				new Point3D(CubeSize, CubeSize, -CubeSize),
				new Point3D(-CubeSize, CubeSize, -CubeSize),
				new Point3D(-CubeSize, -CubeSize, CubeSize),
				new Point3D(CubeSize, -CubeSize, CubeSize),
				new Point3D(CubeSize, CubeSize, CubeSize),
				new Point3D(-CubeSize, CubeSize, CubeSize)
			};

			Point[] screenPoints = new Point[cubeVertices.Length];

			for (int i = 0; i < cubeVertices.Length; i++)
			{
				// current vertex
				float x1 = cubeVertices[i].X;
				float y1 = cubeVertices[i].Y;
				float z1 = cubeVertices[i].Z;

				// 3D rotation calculations
				float x2 = cosY * x1 + sinY * sinX * y1 - sinY * cosX * z1;
				float y2 = cosX * y1 + sinX * z1;
				float z2 = sinY * x1 - cosY * sinX * y1 + cosY * cosX * z1;

				// perspective projection calculations
				float distanceRatio = Perspective / (Perspective + z2 + distance);
				float projectedX = x2 * distanceRatio;
				float projectedY = y2 * distanceRatio;

				screenPoints[i] = new Point(
					(int)(halfWidth + projectedX),
					(int)(halfHeight + projectedY)
				);
			}

			// Draw the cube edges
			int[] cubeEdges =
			{
				0, 1, 1, 2, 2, 3, 3, 0, 0, 4, 1, 5, 2, 6, 3, 7, 4, 5, 5, 6, 6, 7, 7, 4
			};

			for (int i = 0; i < cubeEdges.Length; i += 2)
			{
				int index1 = cubeEdges[i];
				int index2 = cubeEdges[i + 1];

				Point p1 = screenPoints[index1];
				Point p2 = screenPoints[index2];

				Utils.DrawXiaolinWuLine(g, cubeColor, perspectiveColor, p1.X, p1.Y, p2.X, p2.Y);
			}
		}

		private bool keyUpPressed = false;
		private bool keyDownPressed = false;
		private bool keyLeftPressed = false;
		private bool keyRightPressed = false;
		private bool keySPressed = false;
		private bool keyWPressed = false;

		private void Form1_KeyDown(object sender, KeyEventArgs e)
		{
			// Handle arrow keys to rotate the cube
			switch (e.KeyCode)
			{
				case Keys.Up:
					keyUpPressed = true;
					break;
				case Keys.Down:
					keyDownPressed = true;
					break;
				case Keys.Left:
					keyLeftPressed = true;
					break;
				case Keys.Right:
					keyRightPressed = true;
					break;
				case Keys.S:
					keySPressed = true;
					break;
				case Keys.W:
					keyWPressed = true;
					break;
			}

			UpdateCubeRotation();
		}

		private void Form1_KeyUp(object sender, KeyEventArgs e)
		{
			switch (e.KeyCode)
			{
				case Keys.Up:
					keyUpPressed = false;
					break;
				case Keys.Down:
					keyDownPressed = false;
					break;
				case Keys.Left:
					keyLeftPressed = false;
					break;
				case Keys.Right:
					keyRightPressed = false;
					break;
				case Keys.S:
					keySPressed = false;
					break;
				case Keys.W:
					keyWPressed = false;
					break;
			}

			UpdateCubeRotation();
		}

		private void UpdateCubeRotation()
		{
			// Calculate the rotation based on the state of the pressed keys
			float rotationXDelta = 0f;
			float rotationYDelta = 0f;
			float distanceDelta = 0f;

			if (keyUpPressed)
				rotationXDelta -= 10f;
			if (keyDownPressed)
				rotationXDelta += 10f;
			if (keyLeftPressed)
				rotationYDelta -= 10f;
			if (keyRightPressed)
				rotationYDelta += 10f;
			if (keySPressed)
				distanceDelta -= 15f;
			if (keyWPressed)
				distanceDelta += 15f;

			// Apply the rotation and distance changes to the cube
			rotationX += rotationXDelta;
			rotationY += rotationYDelta;
			distance += distanceDelta;

			Canvas.Invalidate(); // Redraw the form
		}

		public struct Point3D
		{
			public float X { get; set; }
			public float Y { get; set; }
			public float Z { get; set; }

			public Point3D(float x, float y, float z)
			{
				X = x;
				Y = y;
				Z = z;
			}
		}
	}
}
